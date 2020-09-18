/*
 * Created by SharpDevelop.
 * User: Alistair
 * Date: 17/03/2018
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
/*
 * Based on ManagePTZ2 by Alistair Windram, with amendments by Filip Ionita
 * Form layout modelled on SSUTILITY Firmware tab for continuity
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    public partial class MainForm : Form {

        D protocol = new D();
        public static MainForm m;
        Recorder recorderL;
        Recorder recorderR;
        public bool lite = false;
        Control lab;

        public static Control[] saveList = new Control[0];

        public static string config = "config.txt";
        public const string autoSave = "auto.txt";
        public static string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SSUtility\";
        public static string scFolder = appFolder + @"Screenshots\";
        public static string vFolder = appFolder + @"Videos\";
        public static string vFileName = "VideoCapture";
        public static string scFileName = "ScreenCapture";
        public static string RecFPS = "30";
        public static string RecQual = "70";
        const string defaultIP = "192.168.1.71";

        ControlPanel ipCon;

        public async Task StartupStuff() {
            m = this;
            tC_Main.TabPages[1].Dispose(); //remove the firmware page
            CameraCommunicate.mainRef = m;

            TabPage tp = tC_Control.TabPages[0];
            ipCon = AttachControlPanel(tp, false);
            ipCon.mainRef = m;
            PresetPanel pp = AttachPresetPanel(tp, ipCon);
            pp.cp = ipCon;

            ipCon.isOriginal = true;

            lab = ipCon.l_IPCon_Connected;

            saveList = new Control[]{
                ipCon.cB_IPCon_Type,
                ipCon.tB_IPCon_Adr,
                ipCon.tB_IPCon_Port,
                ipCon.cB_IPCon_Selected,

                cB_PlayerL_Type,
                tB_PlayerL_Adr,
                tB_PlayerL_Port,
                tB_PlayerL_RTSP,
                tB_PlayerL_Buffering,
                tB_PlayerL_Username,
                tB_PlayerL_Password,
                tB_PlayerL_SimpleAdr,

                cB_PlayerR_Type,
                tB_PlayerR_Adr,
                tB_PlayerR_Port,
                tB_PlayerR_RTSP,
                tB_PlayerR_Buffering,
                tB_PlayerR_Username,
                tB_PlayerR_Password,
                tB_PlayerR_SimpleAdr,
            };

            AutoSave.LoadAuto(appFolder + autoSave);

            ConfigControl.SetDefaults();

            CheckCreateFile(config, appFolder);
            CheckCreateFile(autoSave, appFolder);
            CheckCreateFile(null, scFolder);
            CheckCreateFile(null, vFolder);

            await ConfigControl.SearchForVarsAsync(appFolder + config);
            foreach (PathVar v in ConfigControl.varList) {
                switch (v.name) {
                    case ConfigControl.screenshotFolderVar:
                        scFolder = v.value;
                        break;
                    case ConfigControl.videoFolderVar:
                        vFolder = v.value;
                        break;
                    case ConfigControl.scFileNVar:
                        scFileName = v.value;
                        break;
                    case ConfigControl.videoFileNVar:
                        vFileName = v.value;
                        break;
                    case ConfigControl.RecQualVar:
                        RecQual = v.value;
                        break;
                    case ConfigControl.RecFPSVar:
                        RecFPS = v.value;
                        break;
                }
            }


            PopulateSettingText();
            SetFeatureToAllControls(m.Controls);

            if (ipCon.tB_IPCon_Adr.Text != defaultIP) {
                CameraCommunicate.Connect(ipCon.tB_IPCon_Adr.Text, ipCon.tB_IPCon_Port.Text, lab, true);
            }
            lite = false;
        }

        public void InitLiteMode() {
            TabPage tp = LiteMode();
            ControlPanel cp = AttachControlPanel(tp);
            PresetPanel pp = AttachPresetPanel(tp, cp);
            pp.cp = cp;
            cp.isOriginal = false;
            cp.b_IPCon_LayoutMode.Text = "Swap To: Dual Mode";
            foreach (TabPage tab in tC_Control.TabPages) {
                if (tab != tp) {
                    tab.Dispose();
                }
            }
        }

        public TabPage LiteMode() {
            TabPage tp = new TabPage();
            tp.Text = "Camera Control";
            tC_Control.Controls.Add(tp);
            m.Size = new Size(300, 1000);
            AutoSave.SaveAuto(appFolder + autoSave);
            lite = true;
            return tp;
        }

        ControlPanel AttachControlPanel(TabPage tp, bool makeLite = true) {
            GroupBox gb = new GroupBox();
            ControlPanel cp = new ControlPanel();

            if (makeLite) {
                cp.mainRef = m;
                cp.pathToAuto = appFolder + autoSave;
                cp.cB_IPCon_Type.Text = ipCon.cB_IPCon_Type.Text;
                cp.tB_IPCon_Adr.Text = ipCon.tB_IPCon_Adr.Text;
                cp.tB_IPCon_Port.Text = ipCon.tB_IPCon_Port.Text;
                cp.cB_IPCon_Selected.Text = ipCon.cB_IPCon_Selected.Text;
            }


            SetFeatureToAllControls(cp.Controls);

            cp.StartConnect();

            gb.Size = new Size(cp.Size.Width, cp.Size.Height - 30);
            tp.Controls.Add(gb);

            AddControls(gb, cp);
            return cp;
        }

        PresetPanel AttachPresetPanel(TabPage tp, ControlPanel panel) {
            GroupBox gb = new GroupBox();
            PresetPanel pp = new PresetPanel();
            
            SetFeatureToAllControls(pp.Controls);
            pp.mainRef = m;
            panel.SendToBack();

            gb.Location = new Point(0, panel.Size.Height - 40);
            gb.Size = pp.Size;

            tp.Controls.Add(gb);

            var c = GetAllType(pp, typeof(TabControl));
            var cTwo = GetAllType(pp, typeof(Label));
            gb.Controls.AddRange(c.ToArray());
            gb.Controls.AddRange(cTwo.ToArray());
            return pp;
        }

        void AddControls(GroupBox g, Control panel) {
            var c = GetAll(panel);
            g.Controls.AddRange(c.ToArray());
        }

        public IEnumerable<Control> GetAll(Control control) {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }

        public IEnumerable<Control> GetAllType(Control control, Type type) {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllType(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }


        async Task<bool> CheckFinishedTypingPath(TextBox tb, Label linkLabel) {
            if (tb.Text.Length < 1) {
                tb.Text = appFolder;
                return false;
            }
            if (ConfigControl.CheckIfExists(tb, linkLabel).Result) {
                return true;
            }
            return false;
        }

        public static bool ShowError(string message, string caption, string error, bool showError = true) {
            bool res = false;
            DialogResult d = MessageBox.Show(message, caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (d == DialogResult.Yes) {
                res = true;
                if (showError) {
                    MessageBox.Show(error, caption, MessageBoxButtons.OK);
                }
            }
            return res;
        }

        public async Task AutoFillConnect(bool supressError = false) {
            //if (CameraCommunicate.Connect(ipCon.tB_IPCon_Adr.Text, ipCon.tB_IPCon_Port.Text, lab, supressError).Result) {
            //    if (tB_PlayerL_Adr.Text == defaultIP || tB_PlayerL_Adr.Text == "") {
            //        tB_PlayerL_Adr.Text = ipCon.tB_IPCon_Adr.Text;
            //    }
            //}
        }

        public Recorder StartRec(AxAXVLC.AxVLCPlugin2 player) {
            Recorder rec = new Recorder(new Record(tB_Paths_vFolder.Text + vFileName +
                (Directory.GetFiles(vFolder).Length + 1) + ".avi", int.Parse(RecFPS),
                 SharpAvi.KnownFourCCs.Codecs.MotionJpeg, int.Parse(RecQual), player));//add quality and framerate changing too 
            return rec;
        }

        public void StopRec(Recorder r) {
            r.Dispose();
        }

        public (bool, Recorder) StopStartRec(bool isPlaying, AxAXVLC.AxVLCPlugin2 player, Button control, Recorder r) {
            if (isPlaying) {
                control.Text = "START Recording";
                isPlaying = false;
                StopRec(r);
                return (isPlaying, null);
            } else {
                control.Text = "STOP Recording";
                isPlaying = true;
                MessageBox.Show("Saved recording to: " + appFolder + vFolder);
                return (isPlaying, StartRec(player));
            }
        }

        public uint MakeAdr(Control selected = null) {
            if (selected == null) {
                //selected = ipCon.cB_IPCon_Selected;
            }
            if (selected.Text == "Daylight") {
                return 1;
            } else {
                return 2;
            }
        }

        public void Play(AxAXVLC.AxVLCPlugin2 player, string combinedUrl, TextBox linkedTB) {
            if (combinedUrl == "") {
                MessageBox.Show("Address is invalid!");
                return;
            }
            if (CameraCommunicate.PingAdr(combinedUrl).Result) {
                MessageBox.Show("Address could not be pinged!");
                return;
            }
            linkedTB.Text = combinedUrl;
            Replay(player, combinedUrl);
        }

        public void Replay(AxAXVLC.AxVLCPlugin2 player, string combinedUrl) {
            if (player.playlist.isPlaying) {
                player.playlist.stop();
                player.playlist.items.clear();
            }

            player.playlist.add(combinedUrl, null, ":network-caching=" + tB_PlayerL_Buffering.Text);
            player.playlist.next();
            player.playlist.play();
        }

        public void ExtendOptions(bool check, GroupBox gbExt, GroupBox gbSim) {
            if (check) {
                gbSim.Hide();
                gbExt.Show();
            } else {
                gbExt.Hide();
                gbSim.Show();
            }
        }

        private void BrowseFolderButton(TextBox tb) {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK) {
                tb.Text = folderDlg.SelectedPath;
            }
        }

        private async Task ApplyAll() { //
            ConfigControl.CreateConfig(appFolder + config);
            MessageBox.Show("Applied settings to: " + appFolder + config);
        }
        private void b_Settings_Default_Click(object sender, EventArgs e) {
            DialogResult d = MessageBox.Show("Are you sure you want to reset all settings? \n" +
                "Settings will not automatically be applied so the user may edit the defaults before applying.",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes) {
                scFolder = ConfigControl.DefScFolder;
                vFolder = ConfigControl.DefVFolder;
                scFileName = ConfigControl.DefScName;
                vFileName = ConfigControl.DefVName;
                RecQual = ConfigControl.DefvRecQualVar;
                RecFPS = ConfigControl.DefvRecFPSVar;
                PopulateSettingText();
            }
        }

        public void SetFeatureToAllControls(Control.ControlCollection cc) {
            if (cc != null) {
                foreach (Control control in cc) {
                    if (control != tC_Control) {
                        control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    }
                    SetFeatureToAllControls(control.Controls);
                }
            }
        }
        public void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter) {
                e.IsInputKey = true;
            }
        }

        public void PTZMove(bool IsTilt, uint address, uint speed,
            D.Tilt tilt = D.Tilt.Up, D.Pan pan = D.Pan.Left,
            string ip = null, string port = null, Control lcon = null) {
            byte[] code;

            if (ip == null) {
                //ip = ipCon.tB_IPCon_Adr.Text;
                //port = ipCon.tB_IPCon_Port.Text;
                lcon = lab;
            }

            if (CameraCommunicate.lastIPPort != ip + port) {
                CameraCommunicate.Connect(ip, port, lcon);
            }

            if (IsTilt) {
                code = protocol.CameraTilt(address, tilt, speed);
            } else {
                code = protocol.CameraPan(address, pan, speed);
            }

            CameraCommunicate.sendtoIPAsync(code, lab, ip, port);
        }

        public void PTZZoom(D.Zoom dir) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraZoom(MakeAdr(), dir), lab);
        }

        public async Task SaveSnap(AxAXVLC.AxVLCPlugin2 player) {
            var imagePath = scFolder + @"\" + scFileName + (Directory.GetFiles(scFolder).Length + 1) + ".jpg";
            
            Image bmp = new Bitmap(player.Width, player.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            Rectangle rec = player.RectangleToScreen(player.ClientRectangle);
            gfx.CopyFromScreen(rec.Location, Point.Empty, player.Size);

            bmp.Save(imagePath, ImageFormat.Jpeg);

            MessageBox.Show("Image saved : " + scFolder);
        }

        static async Task<bool> CheckIfNameValid(char[] nameArray) {
            foreach (Char c in nameArray) {
                foreach (Char symbol in Path.GetInvalidFileNameChars()) {
                    if (c == symbol && c.ToString() != ":" && c.ToString() != "\\") {
                        ShowError("Invalid character detected, Show more?", "Cannot create file",
                        "Do not use invalid symbols in file names.\nInvalid character found: " + c);
                        return false;
                    }
                }
            }
            return true;
        }

        static async Task CheckCreateFile(string fileName, string folderName = null) {
            CheckIfNameValid((fileName + folderName).ToCharArray());

            if (folderName != null) {
                if (!Directory.Exists(folderName)) {
                    Directory.CreateDirectory(folderName);
                }
            }
            if (fileName != null) {
                if (!File.Exists(appFolder + fileName)) {
                    if (appFolder + fileName == appFolder + config) {
                        ConfigControl.CreateConfig(appFolder + fileName);
                    } else {
                        var newFile = File.Create(appFolder + fileName);
                        newFile.Close();
                    }
                }
            }
        }

        public async Task PopulateSettingText() {
            tB_Paths_sCFolder.Text = scFolder;
            tB_Paths_vFolder.Text = vFolder;

            tB_Rec_vFileN.Text = vFileName;
            tB_Rec_scFileN.Text = scFileName;

            cB_Rec_Quality.Text = RecQual;
            cB_Rec_FPS.Text = RecFPS;
        }

        public Detached DetachVid() {
            Detached dv = new Detached();
            dv.Show();
            dv.MainRef = m;
            SetFeatureToAllControls(dv.Controls);
            return dv;
        }

        public PelcoD OpenPelco() {
            PelcoD pd = new PelcoD();
            pd.mainRef = m;
            pd.Show();
            SetFeatureToAllControls(pd.Controls);
            return pd;
        }

        private void b_PlayerL_Play_Click(object sender, EventArgs e) {
            string combinedUrl;

            if (checkB_PlayerL_Manual.Checked) { //make a function to automatically grab these from gB_...
                string ipaddress = tB_PlayerL_Adr.Text; //is it possible? the variables need to be in an order
                string port = tB_PlayerL_Port.Text;
                string url = tB_PlayerL_RTSP.Text;
                string username = tB_PlayerL_Username.Text;
                string password = tB_PlayerL_Password.Text;

                combinedUrl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
            } else {
                combinedUrl = tB_PlayerL_SimpleAdr.Text;
            }

            Play(VLCPlayer_L, combinedUrl, tB_PlayerL_SimpleAdr);
        }

        private void b_PlayerR_Play_Click(object sender, EventArgs e) {
            string combinedUrl;

            if (checkB_PlayerR_Manual.Checked) { //make a function to automatically grab these from gB_...
                string ipaddress = tB_PlayerR_Adr.Text; //is it possible? the variables need to be in an order
                string port = tB_PlayerR_Port.Text;
                string url = tB_PlayerR_RTSP.Text;
                string username = tB_PlayerR_Username.Text;
                string password = tB_PlayerR_Password.Text;

                combinedUrl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
            } else {
                combinedUrl = tB_PlayerR_SimpleAdr.Text;
            }

            Play(VLCPlayer_R, combinedUrl, tB_PlayerR_SimpleAdr);
        }

        System.Threading.Timer timer = null;

        public void tB_IPCon_Adr_TextChanged(object sender, EventArgs e) { // i cant implement this into cp for some reason?
            TextBox origin = sender as TextBox;
            if (!origin.ContainsFocus)
                return;

            DisposeTimer();
            timer = new System.Threading.Timer(TimerElapsed, null, 300, 300);
        }


        private void TimerElapsed(Object obj) {
            CheckSyntaxAndReport();
            DisposeTimer();
        }

        private void CheckSyntaxAndReport() {
            this.Invoke(new Action(() => {
                //Control l = ipCon.l_IPCon_Connected;
                //if (CameraCommunicate.Connect(ipCon.tB_IPCon_Adr.Text, ipCon.tB_IPCon_Port.Text, ipCon.l_IPCon_Connected, true).Result) {
                //    CameraCommunicate.LabelDisplay(true, l);
                //} else {
                //    CameraCommunicate.LabelDisplay(false, l);
                //}
            }));
        }


        private void DisposeTimer() {
            if (timer != null) {
                timer.Dispose();
                timer = null;
            }
        }

        public void KeyControl(Control lab, KeyEventArgs e) {
            //if (ipCon.cB_IPCon_KeyboardCon.Checked == true) {
            //    uint address = MakeAdr();
            //    uint ptSpeed = Convert.ToUInt32(ipCon.track_PTZ_PTSpeed.Value);
            //    byte[] code = null;

            //    switch (e.KeyCode) { //is there a command that accepts diagonal?
            //        case Keys.Up:
            //            code = protocol.CameraTilt(address, D.Tilt.Up, ptSpeed);
            //            break;
            //        case Keys.Down:
            //            code = protocol.CameraTilt(address, D.Tilt.Down, ptSpeed);
            //            break;
            //        case Keys.Left:
            //            code = protocol.CameraPan(address, D.Pan.Left, ptSpeed);
            //            break;
            //        case Keys.Right:
            //            code = protocol.CameraPan(address, D.Pan.Right, ptSpeed);
            //            break;
            //        case Keys.Enter:
            //            code = protocol.CameraZoom(address, D.Zoom.Tele);
            //            break;
            //        case Keys.Escape:
            //            code = protocol.CameraZoom(address, D.Zoom.Wide);
            //            break;
            //    }

            //    CameraCommunicate.sendtoIPAsync(code, lab);
            //}
        }

        private void tC_Control_KeyDown(object sender, KeyEventArgs e) {
            KeyControl(lab, e);   
        }

        private void tC_Control_KeyUp(object sender, KeyEventArgs e) {
            //if (ipCon.cB_IPCon_KeyboardCon.Checked == true) {
            //    CameraCommunicate.sendtoIPAsync(protocol.CameraStop(MakeAdr()), lab);
            //}
        }

        private void cB_PlayerL_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string enc = cB_PlayerL_Type.Text;
            string username = "";
            string password = "";
            string rtsp = "";

            if (enc == "IONodes - Daylight") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_1:0/h264_1/onvif.stm";
            } else if (enc == "IONodes - Thermal") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
            } else if (enc == "VIVOTEK") {
                username = "root";
                password = "root1234";
                rtsp = "live.sdp";
            } else if (enc == "BOSCH") {
                username = "service";
                password = "Service123!";
                rtsp = "";
            }


            tB_PlayerL_RTSP.Text = rtsp;
            tB_PlayerL_Username.Text = username;
            tB_PlayerL_Password.Text = password;

        }

        private void cB_PlayerR_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string enc = cB_PlayerR_Type.Text;
            string username = "";
            string password = "";
            string rtsp = "";

            if (enc == "IONodes - Daylight") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_1:0/h264_1/onvif.stm";
            } else if (enc == "IONodes - Thermal") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
            } else if (enc == "VIVOTEK") {
                username = "root";
                password = "root1234";
                rtsp = "live.sdp";
            } else if (enc == "BOSCH") {
                username = "service";
                password = "Service123!";
                rtsp = "";
            }

            tB_PlayerR_RTSP.Text = rtsp;
            tB_PlayerR_Username.Text = username;
            tB_PlayerR_Password.Text = password;
        }

        private void b_PlayerL_SaveSnap_Click(object sender, EventArgs e) {
            SaveSnap(VLCPlayer_L);
        }
        private void b_PlayerR_SaveSnap_Click(object sender, EventArgs e) {
            SaveSnap(VLCPlayer_R);
        }

        private void cB_IPCon_Type_SelectedIndexChanged(object sender, EventArgs e) {
            //string control = ipCon.cB_IPCon_Type.Text;
            //string port = "";

            //if (control == "Encoder") {
            //    port = "6791";
            //} else if (control == "MOXA nPort") {
            //    port = "4001";
            //}

            //ipCon.tB_IPCon_Port.Text = port;
        }

        private void checkB_PlayerL_Manual_CheckedChanged(object sendeL, EventArgs e) {
            ExtendOptions(checkB_PlayerL_Manual.Checked, gB_PlayerL_Extended, gB_PlayerL_Simple);
        }
        private void checkB_PlayerR_Manual_CheckedChanged(object sender, EventArgs e) {
            ExtendOptions(checkB_PlayerR_Manual.Checked, gB_PlayerR_Extended, gB_PlayerR_Simple);
        }

        private void OnFinishedTypingScFolder(object sender, EventArgs e) {
            if (CheckFinishedTypingPath(tB_Paths_sCFolder, l_Paths_sCCheck).Result) {
                scFolder = tB_Paths_sCFolder.Text;
            }
        }

        private void OnFinishedTypingVFolder(object sender, EventArgs e) {
            if (CheckFinishedTypingPath(tB_Paths_vFolder, l_Paths_vCheck).Result) {
                vFolder = tB_Paths_vFolder.Text;
            }
        }

        bool Lplaying = false;
        bool Rplaying = false;

        private void b_PlayerL_StartRec_Click(object sender, EventArgs e) {
            (bool, Recorder) vals = StopStartRec(Lplaying, VLCPlayer_L, b_PlayerL_StartRec, recorderL);
            Lplaying = vals.Item1;
            recorderL = vals.Item2;
        }
        private void b_PlayerR_StartRec_Click(object sender, EventArgs e) {
            (bool, Recorder) vals = StopStartRec(Rplaying, VLCPlayer_R, b_PlayerR_StartRec, recorderR);
            Rplaying = vals.Item1;
            recorderR = vals.Item2;
        }

        private void b_Paths_vBrowse_Click(object sender, EventArgs e) {
            BrowseFolderButton(tB_Paths_vFolder);
        }

        private void tB_Rec_vFileN_TextChanged(object sender, EventArgs e) {
            if (CheckIfNameValid(tB_Rec_vFileN.Text.ToCharArray()).Result) {
                vFileName = tB_Rec_vFileN.Text;
            } else {
                tB_Rec_vFileN.Text = vFileName;
            }
        }

        private void tB_Rec_sCFileN_TextChanged(object sender, EventArgs e) {
            if (CheckIfNameValid(tB_Rec_scFileN.Text.ToCharArray()).Result) {
                scFileName = tB_Rec_scFileN.Text;
            } else {
                tB_Rec_vFileN.Text = scFileName;
            }
        }

        private void cB_Rec_Quality_TextChanged(object sender, EventArgs e) {
            int q = int.Parse(ConfigControl.DefvRecQualVar);
            if (!int.TryParse(cB_Rec_Quality.Text, out q)) {
                cB_Rec_Quality.Text = q.ToString();
                return;
            }
            if (q > 100) {
                cB_Rec_Quality.Text = "100";
            } else if (q < 1) {
                cB_Rec_Quality.Text = "1";
            }

            RecQual = cB_Rec_Quality.Text;
        }

        private void cB_Rec_FPS_TextChanged(object sender, EventArgs e) {
            int fps = int.Parse(ConfigControl.DefvRecFPSVar);
            if (!int.TryParse(cB_Rec_Quality.Text, out fps)) {
                cB_Rec_FPS.Text = fps.ToString();
                return;
            }
            if (fps < 1) {
                cB_Rec_FPS.Text = "1";
            }

            RecFPS = cB_Rec_FPS.Text;
        }

        private void b_Paths_sCBrowse_Click(object sender, EventArgs e) {
            BrowseFolderButton(tB_Paths_sCFolder);
        }

        private void b_Settings_Apply_Click(object sender, EventArgs e) {
            ApplyAll();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (!lite) {
                AutoSave.SaveAuto(appFolder + autoSave);
            }
        }


    } // end of class MainForm
} // end of namespace SSLUtility2
