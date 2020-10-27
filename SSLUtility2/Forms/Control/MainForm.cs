using SSLUtility2.Forms.FinalTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2
{
    public partial class MainForm : Form {

        public const string version = "v1.2.10.1";
        D protocol = new D();
        public static MainForm m;
        public bool lite = false;
        bool isOriginal = false;

        public static Control[] saveList = new Control[0];

        ControlPanel ipCon;

        public async Task StartupStuff() {
            m = this;
            lite = false;
            CameraCommunicate.mainRef = m;
            l_Version.Text = l_Version.Text + version;
            bool first = CheckIfFirstTime();
            firmwareUp.Dispose(); //remove the firmware page

            AttachControlPanel();
            Detached playerL = AttachDetached(10);
            Detached playerR = AttachDetached(690);
            AttachInfoPanel(playerL, 270);
            AttachInfoPanel(playerR, 950);

            saveList = new Control[]{
                ipCon.cB_IPCon_Type,
                ipCon.tB_IPCon_Adr,
                ipCon.tB_IPCon_Port,
                ipCon.cB_IPCon_Selected,

                playerL.cB_PlayerD_Type,
                playerL.tB_PlayerD_Adr,
                playerL.tB_PlayerD_Port,
                playerL.tB_PlayerD_RTSP,
                playerL.tB_PlayerD_Buffering,
                playerL.tB_PlayerD_Username,
                playerL.tB_PlayerD_Password,
                playerL.tB_PlayerD_SimpleAdr,

                playerR.cB_PlayerD_Type,
                playerR.tB_PlayerD_Adr,
                playerR.tB_PlayerD_Port,
                playerR.tB_PlayerD_RTSP,
                playerR.tB_PlayerD_Buffering,
                playerR.tB_PlayerD_Username,
                playerR.tB_PlayerD_Password,
                playerR.tB_PlayerD_SimpleAdr,
            };

            FileStuff(first);

            PopulateSettingText();
            SetFeatureToAllControls(m.Controls);
            AutoConnect(playerL, playerR);
        }

        public async Task PopulateSettingText() {
            tB_Paths_sCFolder.Text = ConfigControl.savedFolder;
            tB_Paths_vFolder.Text = ConfigControl.savedFolder;

            tB_Rec_vFileN.Text = ConfigControl.vFileName;
            tB_Rec_scFileN.Text = ConfigControl.scFileName;

            cB_Rec_Quality.Text = ConfigControl.recQual;
            cB_Rec_FPS.Text = ConfigControl.recFPS;

            cB_Other_Rate.Text = ConfigControl.updateMs;

            check_Other_Subnet.Checked = ConfigControl.subnetNotif;
            check_Other_AutoPlay.Checked = ConfigControl.autoPlay;
            check_Paths_Manual.Checked = ConfigControl.automaticPaths;
        }

        bool CheckIfFirstTime() {
            if (!File.Exists(ConfigControl.appFolder + ConfigControl.config)) {
                return true;
            } else {
                return false;
            }
        }

        async Task AutoConnect(Detached playerL, Detached playerR) {
            CameraCommunicate.Connect(ipCon.tB_IPCon_Adr.Text, ipCon.tB_IPCon_Port.Text, ipCon.l_IPCon_Connected, true);
            if (ConfigControl.autoPlay) {
                if (playerL.tB_PlayerD_SimpleAdr.Text != "") {
                    Play(playerL.VLCPlayer_D, playerL.GetCombined(), playerL.tB_PlayerD_SimpleAdr, playerL.tB_PlayerD_Buffering.Text, false);
                    //playerL.myInfoRef.InitTimer();
                }
                if (playerR.tB_PlayerD_SimpleAdr.Text != "") {
                    Play(playerR.VLCPlayer_D, playerR.GetCombined(), playerR.tB_PlayerD_SimpleAdr, playerR.tB_PlayerD_Buffering.Text, false);
                    //playerR.myInfoRef.InitTimer();
                }
            }
        }

        async Task FindVars() {
            foreach (ConfigVar v in ConfigControl.stringVarList) {
                if (v.value.ToLower() == "false" || v.value.ToLower() == "true") {
                    bool val = ConfigControl.CheckVal(v.value);
                    switch (v.name) {
                        case ConfigControl.subnetNotifVar:
                            ConfigControl.subnetNotif = val;
                            break;
                        case ConfigControl.automaticPathsVar:
                            ConfigControl.automaticPaths = val;
                            break;
                        case ConfigControl.autoPlayVar:
                            ConfigControl.autoPlay = val;
                            break;
                        case ConfigControl.portableModeVar:
                            ConfigControl.portableMode = val;
                            break;
                    }
                } else {
                    switch (v.name) {
                        case ConfigControl.screenshotFolderVar:
                            ConfigControl.scFolder = v.value;
                            break;
                        case ConfigControl.videoFolderVar:
                            ConfigControl.vFolder = v.value;
                            break;
                        case ConfigControl.scFileNVar:
                            ConfigControl.scFileName = v.value;
                            break;
                        case ConfigControl.videoFileNVar:
                            ConfigControl.vFileName = v.value;
                            break;
                        case ConfigControl.recQualVar:
                            ConfigControl.recQual = v.value;
                            break;
                        case ConfigControl.recFPSVar:
                            ConfigControl.recFPS = v.value;
                            break;
                        case ConfigControl.updateMsVar:
                            ConfigControl.updateMs = v.value;
                            break;
                    }
                }
            }
        }

        public static OpenFileDialog OpenTxt() {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.InitialDirectory = ConfigControl.savedFolder;
            fileDlg.Multiselect = false;
            fileDlg.DefaultExt = ".txt";
            fileDlg.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*";
            fileDlg.FilterIndex = 1;
            fileDlg.RestoreDirectory = true;
            fileDlg.Title = "Select Text File";
            return fileDlg;
        }

        public static SaveFileDialog SaveTxt(string name) {
            SaveFileDialog fileDlg = new SaveFileDialog();
            fileDlg.InitialDirectory = ConfigControl.savedFolder;
            fileDlg.DefaultExt = ".txt";
            fileDlg.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*";
            fileDlg.FilterIndex = 1;
            fileDlg.RestoreDirectory = true;
            fileDlg.Title = "Select Text File";
            fileDlg.FileName = name;
            return fileDlg;
        }

        async Task FileStuff(bool first) {
            CheckPortableMode();

            ConfigControl.SetToDefaults();

            CheckCreateFile(ConfigControl.config, ConfigControl.appFolder);
            CheckCreateFile(ConfigControl.autoSave, ConfigControl.appFolder);
            CheckCreateFile(null, ConfigControl.savedFolder);

            await ConfigControl.SearchForVarsAsync(ConfigControl.appFolder + ConfigControl.config);
            FindVars();
            AutoSave.LoadAuto(ConfigControl.appFolder + ConfigControl.autoSave, first);

            if (ConfigControl.portableMode) {
                Menu_Final.Dispose();
            }
        }

        void CheckPortableMode() {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + ConfigControl.config)) {
                ConfigControl.appFolder = Directory.GetCurrentDirectory() + @"\";
            }
        }

        void AttachInfoPanel(Detached d, int xOffset) {
            TabPage tp = tC_Main.TabPages[0];

            Panel p = new Panel();
            InfoPanel i = new InfoPanel();
            
            d.myInfoRef = i;
            i.d = d;

            p.Size = i.Size;
            p.Location = new Point(d.VLCPlayer_D.Location.X + xOffset, d.VLCPlayer_D.Location.Y);

            var c = GetAll(i);
            p.Controls.AddRange(c.ToArray());

            tp.Controls.Add(p);
        }

        void AttachControlPanel() {
            TabPage tp = tC_Main.TabPages[0];
            
            ipCon = SpawnControlPanel(tp, false);
            ipCon.mainRef = m;

            PresetPanel pp = AttachPresetPanel(tp, ipCon);
            pp.cp = ipCon;

            isOriginal = true; 
        }

        Detached AttachDetached(int xOffset) {
            TabPage tp = tC_Main.TabPages[0];
            GroupBox gb = new GroupBox();
            Detached d = DetachVid(false);

            var c = GetAllType(d, typeof(GroupBox));
            var c2 = GetAllType(d, typeof(Button));
            var c3 = GetAllType(d, typeof(Label));
            var c4 = GetAllType(d, typeof(AxAXVLC.AxVLCPlugin2));
            var c5 = GetAllType(d, typeof(CheckBox));

            gb.Controls.AddRange(c.ToArray());
            gb.Controls.AddRange(c2.ToArray());
            gb.Controls.AddRange(c3.ToArray());
            gb.Controls.AddRange(c4.ToArray());
            gb.Controls.AddRange(c5.ToArray());

            d.VLCPlayer_D.Location = new Point(d.VLCPlayer_D.Location.X, d.VLCPlayer_D.Location.Y + 5);

            gb.Size = new Size(d.Width - 18, d.Height - 40);
            gb.Location = new Point(ipCon.Location.X + ipCon.Size.Width + xOffset, ipCon.Location.Y + 65);

            tp.Controls.Add(gb);

            return d;
        }
       
        public void InitLiteMode() {
            TabPage tp = LiteMode();
            ControlPanel cp = SpawnControlPanel(tp);
            PresetPanel pp = AttachPresetPanel(tp, cp);
            pp.cp = cp;
            isOriginal = false;
            Menu_Window_Lite.Text = "Dual Mode";
            foreach (TabPage tab in tC_Main.TabPages) {
                if (tab != tp) {
                    tab.Dispose();
                }
            }
        }

        public TabPage LiteMode() {
            TabPage tp = new TabPage();
            tp.Text = "Camera Control";
            tC_Main.Controls.Add(tp);
            m.Size = new Size(300, 1000);
            AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
            lite = true;
            return tp;
        }

        public Detached DetachVid(bool show) {
            Detached dv = new Detached();
            if (show) {
                dv.Show();
            }
            dv.mainRef = m;
            SetFeatureToAllControls(dv.Controls);
            return dv;
        }

        public PelcoD OpenPelco(string ip, string port, string selected) {
            PelcoD pd = new PelcoD();
            pd.mainRef = m;
            pd.tB_IPCon_Adr.Text = ip;
            pd.tB_IPCon_Port.Text = port;
            pd.cB_IPCon_Selected.Text = selected;
            pd.Show();
            SetFeatureToAllControls(pd.Controls);
            return pd;
        }

        ControlPanel SpawnControlPanel(TabPage tp, bool makeLite = true) {
            GroupBox gb = new GroupBox();
            ControlPanel cp = new ControlPanel();

            if (makeLite) {
                cp.mainRef = m;
                cp.pathToAuto = ConfigControl.appFolder + ConfigControl.autoSave;
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

        void OpenFinal() {
            Final fin = new Final();
            fin.Show();
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

        public void SetFeatureToAllControls(Control.ControlCollection cc) {
            if (cc != null) {
                foreach (Control control in cc) {
                    if (control != tC_Main) {
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

        async Task<bool> CheckFinishedTypingPath(TextBox tb, Label linkLabel) {
            if (tb.Text.Length < 1) {
                tb.Text = ConfigControl.appFolder;
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

        public async Task<bool> Play(AxAXVLC.AxVLCPlugin2 player, Uri combinedUrl, TextBox linkedTB, string buffering, bool showError) {
            if (showError) {
                if (combinedUrl.Host == "") {
                    MessageBox.Show("Address is invalid!");
                    return false;
                }
                if (!CameraCommunicate.PingAdr(combinedUrl).Result) {
                    MessageBox.Show("Address had no RTSP stream attached!");
                    return false;
                }
            }
            linkedTB.Text = combinedUrl.ToString();
            Replay(player, combinedUrl.ToString(), buffering);
            return true;
        }

        public void Replay(AxAXVLC.AxVLCPlugin2 player, string combinedUrl, string buffering) {
            if (player.playlist.isPlaying) {
                player.playlist.stop();
                player.playlist.items.clear();
            }

            player.playlist.add(combinedUrl, null, ":network-caching=" +buffering);
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

        public static void BrowseFolderButton(TextBox tb) {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK) {
                tb.Text = folderDlg.SelectedPath;
            }
        }

        private async Task ApplyAll() { 
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
            MessageBox.Show("Applied settings to: " + ConfigControl.appFolder + ConfigControl.config);
        }

        public uint MakeAdr(Control comboBox = null) {
            if (comboBox == null) {
                comboBox = ipCon.cB_IPCon_Selected;
            }
            if (comboBox.Text == "Daylight") {
                return 1;
            } else {
                return 2;
            }
        }

        public void PTZMove(bool IsTilt, uint address, uint speed,
            D.Tilt tilt = D.Tilt.Up, D.Pan pan = D.Pan.Left,
            string ip = null, string port = null, Control lcon = null) {
            byte[] code;

            if (CameraCommunicate.lastIPPort != ip + port) {
                CameraCommunicate.Connect(ip, port, lcon);
            }

            if (IsTilt) {
                code = protocol.CameraTilt(address, tilt, speed);
            } else {
                code = protocol.CameraPan(address, pan, speed);
            }

            CameraCommunicate.sendtoIPAsync(code, ipCon.l_IPCon_Connected, ip, port);
        }

        public void PTZZoom(D.Zoom dir, uint address, string ip, string port, Control lcon) {
            if (CameraCommunicate.lastIPPort != ip + port) {
                CameraCommunicate.Connect(ip, port, lcon);
            }

            CameraCommunicate.sendtoIPAsync(protocol.CameraZoom(address, dir), lcon, ip, port);
        }

        public async Task SaveSnap(Detached player) {
            string fullImagePath = GivePath(ConfigControl.scFolder, ConfigControl.scFileName, player.tB_PlayerD_SimpleAdr.Text, "Screenshots") + ".jpg";

            Image bmp = new Bitmap(player.VLCPlayer_D.Width, player.VLCPlayer_D.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            Rectangle rec = player.VLCPlayer_D.RectangleToScreen(player.VLCPlayer_D.ClientRectangle);
            gfx.CopyFromScreen(rec.Location, Point.Empty, player.VLCPlayer_D.Size);

            bmp.Save(fullImagePath, ImageFormat.Jpeg);

            MessageBox.Show("Image saved : " + fullImagePath);
        }

        string inUsePath;

        public (bool, Recorder) StopStartRec(bool isPlaying, Detached player, Recorder r) {
            if (isPlaying) {
                player.b_PlayerD_StartRec.Text = "START Recording";
                isPlaying = false;
                
                r.Dispose();
                
                MessageBox.Show("Saved recording to: " + inUsePath);

                return (isPlaying, null);
            } else {
                string fullVideoPath = GivePath(ConfigControl.vFolder, ConfigControl.vFileName, player.tB_PlayerD_SimpleAdr.Text, "Recordings") + ".avi";
                inUsePath = fullVideoPath;
                player.b_PlayerD_StartRec.Text = "STOP Recording";
                isPlaying = true;

                Recorder rec = new Recorder(new Record(fullVideoPath, int.Parse(ConfigControl.recFPS),
                SharpAvi.KnownFourCCs.Codecs.MotionJpeg, int.Parse(ConfigControl.recQual), player.VLCPlayer_D));

                return (isPlaying, rec);
            }
        }

        string GivePath(string orgFolder, string orgName, string adr, string folderType) {
            string folder = orgFolder;
            string fileName = orgName + (Directory.GetFiles(orgFolder).Length + 1).ToString();

            adr = GetAdr(adr);

            if (adr != "") {
                adr += @"\";
            } else {
                folderType = "";
            }

            if (ConfigControl.automaticPaths) {
                folder = ConfigControl.savedFolder + adr + folderType;
                string timeText = DateTime.Now.ToString().Replace("/", "-").Replace(":", ";");
                fileName = orgName + " " + timeText;
            }

            CheckCreateFile(null, folder);

            string full = folder + @"\" + fileName;
            return full;
        }

        public static string GetAdr(string orgAdr) {
            if (orgAdr != "") {
                try {
                    Uri uriAddress = new Uri(orgAdr);
                    return uriAddress.Host;
                } catch {
                    return "";
                }
            } else {
                return "";
            }
        }

        public static async Task<bool> CheckIfNameValid(char[] nameArray, bool everythingBad = false) {
            foreach (Char c in nameArray) {
                foreach (Char symbol in Path.GetInvalidFileNameChars()) {
                    bool isBad = false;
                    if (c == symbol) {
                        if (everythingBad) {
                            isBad = true;
                        } else {
                            if (c.ToString() != ":" && c.ToString() != "\\") {
                                isBad = false;
                            }
                        }

                    }

                    if (isBad) {
                        ShowError("Invalid character detected, Show more?", "Cannot create file",
                            "Do not use invalid symbols in file names.\nInvalid character found: " + c);
                        return false;
                    }
                }
            }
            return true;
        }

        public static async Task<bool> CheckCreateFile(string fileName, string folderName = null, bool returnValid = false) {
            if (returnValid) {
                if (!CheckIfNameValid((fileName + folderName).ToCharArray()).Result) {
                    return false;
                }
            }

            if (folderName != null) {
                if (!Directory.Exists(folderName)) {
                    Directory.CreateDirectory(folderName);
                }
            }
            if (fileName != null) {
                if (!File.Exists(ConfigControl.appFolder + fileName)) {
                    if (ConfigControl.appFolder + fileName == ConfigControl.appFolder + ConfigControl.config) {
                        ConfigControl.CreateConfig(ConfigControl.appFolder + fileName);
                    } else {
                        var newFile = File.Create(ConfigControl.appFolder + fileName);
                        newFile.Close();
                    }
                }
            }
            return true;
        }
       
        private void b_Settings_Default_Click(object sender, EventArgs e) {
            DialogResult d = MessageBox.Show("Are you sure you want to reset all settings? \n" +
                "Settings will not automatically be applied so the user may edit the defaults before applying.",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes) {
                ConfigControl.SetToDefaults();
                PopulateSettingText();
            }
        }

        private void OnFinishedTypingScFolder(object sender, EventArgs e) {
            if (CheckFinishedTypingPath(tB_Paths_sCFolder, l_Paths_sCCheck).Result) {
                ConfigControl.scFolder = tB_Paths_sCFolder.Text;
            }
        }

        private void OnFinishedTypingVFolder(object sender, EventArgs e) {
            if (CheckFinishedTypingPath(tB_Paths_vFolder, l_Paths_vCheck).Result) {
                ConfigControl.vFolder = tB_Paths_vFolder.Text;
            }
        }

        private void check_Not_Subnet_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.subnetNotif = check_Other_Subnet.Checked;
        }

        private void check_Other_AutoPlay_CheckChanged(object sender, EventArgs e) {
            ConfigControl.autoPlay = check_Other_AutoPlay.Checked;
        }

        private void cB_Other_Rate_SelectedIndexChanged(object sender, EventArgs e) {
            if (CheckIfNameValid(cB_Other_Rate.Text.ToCharArray(), true).Result){
                ConfigControl.updateMs = cB_Other_Rate.Text;
            }
        }

        private void check_Paths_Manual_CheckedChanged(object sender, EventArgs e) {
            bool auto = !check_Paths_Manual.Checked;

            ConfigControl.automaticPaths = !auto;
            
            tB_Paths_sCFolder.Enabled = auto;
            tB_Paths_vFolder.Enabled = auto;

            tB_Rec_vFileN.Enabled = auto;
            tB_Rec_scFileN.Enabled = auto;

            b_Paths_sCBrowse.Enabled = auto;
            b_Paths_vBrowse.Enabled = auto;
        }

        private void b_Paths_sCBrowse_Click(object sender, EventArgs e) {
            BrowseFolderButton(tB_Paths_sCFolder);
        }

        private void b_Paths_vBrowse_Click(object sender, EventArgs e) {
            BrowseFolderButton(tB_Paths_vFolder);
        }

        private void tB_Rec_vFileN_TextChanged(object sender, EventArgs e) {
            if (CheckIfNameValid(tB_Rec_vFileN.Text.ToCharArray()).Result) {
                ConfigControl.vFileName = tB_Rec_vFileN.Text;
            } else {
                tB_Rec_vFileN.Text = ConfigControl.vFileName;
            }
        }

        private void tB_Rec_sCFileN_TextChanged(object sender, EventArgs e) {
            if (CheckIfNameValid(tB_Rec_scFileN.Text.ToCharArray()).Result) {
                ConfigControl.scFileName = tB_Rec_scFileN.Text;
            } else {
                tB_Rec_vFileN.Text = ConfigControl.scFileName;
            }
        }

        private void cB_Rec_Quality_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Rec_Quality.Text, out int q)) {
                cB_Rec_Quality.Text = q.ToString();
                return;
            }
            if (q > 100) {
                cB_Rec_Quality.Text = "100";
            } else if (q < 1) {
                cB_Rec_Quality.Text = "1";
            }

            ConfigControl.recQual = cB_Rec_Quality.Text;
        }

        private void cB_Rec_FPS_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Rec_Quality.Text, out int fps)) {
                cB_Rec_FPS.Text = fps.ToString();
                return;
            }
            if (fps < 1) {
                cB_Rec_FPS.Text = "1";
            }

            ConfigControl.recFPS = cB_Rec_FPS.Text;
        }

        private void b_Settings_Apply_Click(object sender, EventArgs e) {
            ApplyAll();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            CameraCommunicate.CloseSock();
            if (!lite) {
                AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
            }
        }

        private void Menu_Window_Detached_Click(object sender, EventArgs e) {
            Detached d = DetachVid(true);

            d.tB_PlayerD_Adr.Text = ipCon.tB_IPCon_Adr.Text;
            d.checkB_PlayerD_Manual.Checked = true;
        }

        private void Menu_Window_PelcoD_Click(object sender, EventArgs e) {
            OpenPelco(ipCon.tB_IPCon_Adr.Text, ipCon.tB_IPCon_Port.Text, ipCon.cB_IPCon_Selected.Text);
        }

        private void Menu_Window_Lite_Click(object sender, EventArgs e) {
            if (!isOriginal) {
                Application.Restart();
                Application.ExitThread();
                this.Close();
            } else {
                InitLiteMode();
            }
        }

        private void Menu_FTM_Open_Click(object sender, EventArgs e) {
            OpenFinal();
        }


    } // end of class MainForm
} // end of namespace SSLUtility2
