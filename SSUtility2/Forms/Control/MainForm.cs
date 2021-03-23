using SSUtility2.Forms.FinalTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class MainForm : Form {
        
        public const string version = "v2.3.0.0";

        private bool lite = false;
        private bool isOriginal = false;
        private bool closing = false;

        public bool finalMode = false;

        public static Control[] saveList = new Control[0];

        public ControlPanel mainCp;
        public CustomPanel custom;
        public SettingsPage setPage;
        public PelcoD pd;
        public ResponseLog rl;

        public Detached mainPlayer;
        
        private Recorder screenRec;

        private string inUseVideoPath;
        private string screenRecordName;
        
        public string finalDest;

        public static MainForm m;

        public async Task StartupStuff() {
            try {
                m = this;
                setPage = new SettingsPage();
                rl = new ResponseLog();
                pd = new PelcoD();
                D.protocol = new D();

                lite = false;
                bool first = CheckIfFirstTime();

                p_Main.Select();

                AttachControlPanel();
                mainPlayer = AttachPlayer();
                HideControlPanel();

                AttachInfoPanel();
                AttachCustomPanel();

                saveList = new Control[]{

                mainPlayer.settings.tB_PlayerD_Adr,
                mainPlayer.settings.tB_PlayerD_Port,
                mainPlayer.settings.tB_PlayerD_RTSP,
                mainPlayer.settings.tB_PlayerD_Buffering,
                mainPlayer.settings.tB_PlayerD_Username,
                mainPlayer.settings.tB_PlayerD_Password,
                mainPlayer.settings.tB_PlayerD_SimpleAdr,
                mainPlayer.settings.tB_PlayerD_Name,

                setPage.tB_Custom_1,
                setPage.tB_Custom_2,
                setPage.tB_Custom_3,
                setPage.tB_Custom_4,
                setPage.tB_Custom_5,
                setPage.tB_Custom_6,
                setPage.tB_Custom_7,
                setPage.tB_Custom_8,
            };

                FileStuff(first);

                setPage.PopulateSettingText();
                Tools.SetFeatureToAllControls(m.Controls);
                b_Open.BringToFront();
                CommandQueue.Init();
                AutoConnect();

            } catch (Exception e) {
                Tools.ShowPopup("Init failed!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        bool CheckIfFirstTime() {
            if (!File.Exists(ConfigControl.appFolder + ConfigControl.config)) {
                return true;
            } else {
                return false;
            }
        }

        async Task AutoConnect() {
            await Task.Delay(500).ConfigureAwait(false);
            bool connected = await AsyncCamCom.TryConnect(true).ConfigureAwait(false);
            if (ConfigControl.autoPlay.boolVal && connected && mainPlayer.settings.tB_PlayerD_SimpleAdr.Text != "") {
                mainPlayer.StartPlaying(false);
            }
        }

        public static OpenFileDialog OpenFile() {
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

        async Task FileStuff(bool first) {
            CheckPortableMode();
            CheckForNewDir();

            ConfigControl.SetToDefaults();
            
            CreateConfigFiles();

            await ConfigControl.SearchForVarsAsync(ConfigControl.appFolder + ConfigControl.config);
            ConfigControl.FindVars();
            AutoSave.LoadAuto(ConfigControl.appFolder + ConfigControl.autoSave, first);

            if (ConfigControl.portableMode.boolVal) {
                Menu_Final.Dispose();
            }
        }

        public static void CreateConfigFiles() {
            Tools.CheckCreateFile(ConfigControl.config, ConfigControl.appFolder);
            Tools.CheckCreateFile(ConfigControl.autoSave, ConfigControl.appFolder);
            Tools.CheckCreateFile(null, ConfigControl.savedFolder);
        }

        public (bool, Recorder) StopStartRec(bool isPlaying, Detached player, Recorder r) {
            if (isPlaying) {
                isPlaying = false;

                r.Dispose();

                if (MainForm.m.finalMode) {
                    SaveFileDialog fdg = Tools.SaveFile(ConfigControl.vFileName.stringVal, ".avi", MainForm.m.finalDest);
                    DialogResult result = fdg.ShowDialog();
                    if (result == DialogResult.OK) {
                        Tools.CopySingleFile(fdg.FileName, inUseVideoPath);
                    }
                    MessageBox.Show("Saved recording to: " + inUseVideoPath +
                        "\nFinal saved: " + fdg.FileName);
                } else {
                    MessageBox.Show("Saved recording to: " + inUseVideoPath);
                }

                return (isPlaying, null);
            } else {
                string fullVideoPath = Tools.GivePath(ConfigControl.vFolder.stringVal, ConfigControl.vFileName.stringVal, player, "Recordings") + ".avi";
                inUseVideoPath = fullVideoPath;
                isPlaying = true;

                Recorder rec = Tools.Record(fullVideoPath, player.stream_Player);

                return (isPlaying, rec);
            }
        }

        string CheckFileForDir() {
            try {
                string[] lines = File.ReadAllLines(ConfigControl.dirLocationFile);

                foreach (string line in lines) {
                    string currentLine = line.Trim();
                    if (currentLine.Contains(@":\")) {
                        if (Tools.CheckIfNameValid(currentLine)) {
                            Tools.CheckCreateFile(null, currentLine);
                        }
                        return currentLine;
                    }
                }
            } catch { }
            return null;   
        }

        void CheckForNewDir() {
            bool noFile = Tools.CheckCreateFile(null, ConfigControl.dirCheck).Result;

            if (noFile) {
                ChooseNewDirectory();
            } else {
                string appLocation = CheckFileForDir();
                if (appLocation != null) {
                    ConfigControl.appFolder = appLocation;
                } else {
                    File.Delete(ConfigControl.dirCheck + "location.txt");
                    ChooseNewDirectory();
                }
            }
        }

        public static void ChooseNewDirectory() {
            bool choose = Tools.ShowPopup("Would you like to change your default directory?\nCurrent app folder: " + ConfigControl.appFolder, "Choose your directory", null, false);
            if (choose) {
                DirectoryChooser dc = new DirectoryChooser();
                dc.ShowDialog();
            }
            ConfigControl.ResetFile(ConfigControl.dirLocationFile);
            File.AppendAllText(ConfigControl.dirLocationFile, ConfigControl.appFolder);
        }

        void CheckPortableMode() {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + ConfigControl.config)) {
                ConfigControl.appFolder = (Directory.GetCurrentDirectory() + @"\");
                ConfigControl.portableMode.UpdateValue("true");
            }
        }

        void AttachInfoPanel() {
            Panel p = new Panel();
            InfoPanel i = new InfoPanel();
            
            p.Size = new Size(i.Width, i.Height - 35);
            p.Location = new Point(m.Size.Width - i.Width, 0);

            var c = Tools.GetAllType(i, typeof(Label));
            p.Controls.AddRange(c.ToArray());

            p.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            p_Control.Controls.Add(p);

            i.myPanel = p;
            p.Hide();
        }

        void AttachControlPanel() {
            mainCp = SpawnControlPanel(p_Control, false);
            isOriginal = true;
        }

        void AttachCustomPanel() {
            Panel p = new Panel();
            custom = new CustomPanel();

            p.Size = new Size(80, 160);
            p.Location = new Point(m.p_Control.Width - p.Width, m.p_Control.Height - p.Height);

            var c = Tools.GetAllType(custom, typeof(Button));
            p.Controls.AddRange(c.ToArray());

            p.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            p_Control.Controls.Add(p);

            custom.myPanel = p;
            p.Visible = false;
            p.BringToFront();
        }

        public void HideControlPanel() {
            mainCp.myPanel.Hide();
            mainCp.myPanel.Visible = false;
        }

        public void ShowControlPanel() {
            mainCp.myPanel.Show();
            mainCp.myPanel.Visible = true;
        }

        Detached AttachPlayer() {
            Detached d = DetachVid(false, new VideoSettings(), true).Result;

            var c = Tools.GetAllType(d, typeof(WebEye.StreamControl.WinForms.StreamControl));
            p_Control.Controls.AddRange(c.ToArray());

            return d;
        }

        public void InitLiteMode() {
            m.Size = new Size(300, Height);
            AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
            lite = true;
            
            p_Control.Dispose();

            ControlPanel cp = SpawnControlPanel(p_Main);
            mainCp = cp;
            AutoSave.LoadAuto(ConfigControl.appFolder + ConfigControl.autoSave, false);

            isOriginal = false;
            Menu_Window_Lite.Text = "Dual Mode";
        }


        public async Task<Detached> DetachVid(bool show, VideoSettings set, bool attachSecond) {
            Detached dv = new Detached(attachSecond);
            if (show) {
                dv.Show();
                await Task.Delay(100).ConfigureAwait(false);
                dv.settings.tB_PlayerD_Adr.Text = set.tB_PlayerD_Adr.Text;
                dv.settings.tB_PlayerD_Port.Text = set.tB_PlayerD_Port.Text;
                dv.settings.tB_PlayerD_RTSP.Text = set.tB_PlayerD_RTSP.Text;
                dv.settings.tB_PlayerD_Username.Text = set.tB_PlayerD_Username.Text;
                dv.settings.tB_PlayerD_Password.Text = set.tB_PlayerD_Password.Text;
                dv.settings.tB_PlayerD_Name.Text = set.tB_PlayerD_Name.Text;
                dv.settings.tB_PlayerD_SimpleAdr.Text = set.tB_PlayerD_SimpleAdr.Text;
                if(mainPlayer.settings.isPlaying)
                    dv.Play(false, dv);
            }
            Tools.SetFeatureToAllControls(dv.Controls);
            return dv;
        }

        public void OpenPelco() {
            pd.Show();
            pd.BringToFront();
        }

        ControlPanel SpawnControlPanel(Panel p, bool makeLite = true) {
            Panel pan = new Panel();
            ControlPanel cp = new ControlPanel();
            cp.myPanel = pan;

            Tools.SetFeatureToAllControls(cp.Controls);

            pan.Size = new Size(cp.Size.Width, cp.Size.Height - 30);
            pan.Location = new Point(pan.Location.X, pan.Location.Y);
            p.Controls.Add(pan);

            AddControls(pan, cp);

            return cp;
        }

        void AddControls(Panel pan, Control panel) {
            var c = Tools.GetAll(panel);
            pan.Controls.AddRange(c.ToArray());
        }

        void OpenFinal() {
            Final fin = new Final();
            fin.Show();
            fin.BringToFront();
        }

        public static void OpenOsiris() {
            Osiris o = new Osiris();
            o.Show();
            o.BringToFront();
        }

        public void ToggleFinalMode(string destination) {
            if (destination == "") {
                finalMode = false;
                Text = "SSUtility2";
                Menu_Final_Open.Text = "Open...";
            } else {
                finalMode = true;
                Menu_Final_Open.Text = "Stop File Recording";
            }
            finalDest = destination;
        }

        public async Task<bool> CheckFinishedTypingPath(TextBox tb, Label linkLabel) {
            if (tb.Text.Length < 1) {
                tb.Text = ConfigControl.appFolder;
                return false;
            }
            if (ConfigControl.CheckIfExists(tb, linkLabel)) {
                return true;
            }
            return false;
        }

        public void WriteToResponses(string text, bool hide, bool isInfo = false) {
            if (MainForm.m.closing) {
                return;
            }
            if (this.InvokeRequired) {
                this.Invoke((MethodInvoker)delegate {
                    WriteToResponses(text, hide, isInfo);
                });
            } else {
                string finalText = text;

                if (rl.tB_Log.Text.Length > 2000000000) {
                    rl.tB_Log.Clear();
                }
                string sender = AsyncCamCom.GetSockEndpoint();
                if (hide && !isInfo) {
                    sender = "CLIENT";
                }
                if (isInfo && !rl.check_Info.Enabled) {
                    return;
                }
                if (!hide || rl.check_RL_All.Checked) {
                    rl.AddText(finalText, sender);
                }
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            closing = true;
            AsyncCamCom.Disconnect(true);
            if (!lite) {
                AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
            }
        }

        private void Menu_Window_Detached_Click(object sender, EventArgs e) {
            DetachVid(true, mainPlayer.settings, false);
        }

        private void Menu_Window_PelcoD_Click(object sender, EventArgs e) {
            OpenPelco();
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

        private void Menu_Final_Open_Click(object sender, EventArgs e) {
            if (finalMode) {
                ToggleFinalMode("");
            } else {
                OpenFinal();
            }
        }

        private void Menu_Window_Response_Click(object sender, EventArgs e) {
            OpenResponseLog();
        }

        public void OpenResponseLog() {
            rl.Show();
            rl.BringToFront();
        }

        private void Menu_Window_Osiris_Click(object sender, EventArgs e) {
            OpenOsiris();
        }

        private void Menu_Window_Settings_Click(object sender, EventArgs e) {
            setPage.Show();
            setPage.BringToFront();
        }

        private void Menu_QC_PanZero_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand("panzero");
        }

        private void Menu_QC_Pan_Click(object sender, EventArgs e) {
            new QuickCommandEntry("setpan", "Enter pan pos value");
        }

        private void Menu_QC_Tilt_Click(object sender, EventArgs e) {
            new QuickCommandEntry("settilt", "Enter tilt pos value");
        }

        private void Menu_Video_Settings_Click(object sender, EventArgs e) {
            mainPlayer.settings.Show();
        }

        private void Menu_Video_Stop_Click(object sender, EventArgs e) {
            mainPlayer.StartStop();
        }

        private void Menu_Video_Snapshot_Click(object sender, EventArgs e) {
            mainPlayer.SnapShot();
        }

        private void Menu_Video_Record_Click(object sender, EventArgs e) {
            if (screenRec != null) {
                screenRec.Dispose();
                screenRec = null;
                Menu_Video_Record.Text = "Start Recording";

                if (finalMode) {
                    SaveFileDialog fdg = Tools.SaveFile(ConfigControl.screencapFileName.stringVal, ".avi", finalDest);
                    DialogResult result = fdg.ShowDialog();
                    if (result == DialogResult.OK) {
                        Tools.CopySingleFile(fdg.FileName, screenRecordName);
                    }
                    MessageBox.Show("Saved recording to: " + screenRecordName +
                        "\nFinal saved: " + fdg.FileName);
                } else {
                    MessageBox.Show("Saved recording to: " + screenRecordName);
                }

            } else {
                Tools.CheckCreateFile(null, ConfigControl.vFolder.stringVal + @"\SSUtility2\");
                string folder = ConfigControl.vFolder.stringVal + @"\SSUtility2\";
                screenRecordName = folder + ConfigControl.screencapFileName.stringVal + (Directory.GetFiles(folder).Length + 1).ToString() + ".avi";
                screenRec = Tools.Record(screenRecordName, null);
                Menu_Video_Record.Text = "Stop Recording";
            }
        }

        private void Menu_Video_Info_Click(object sender, EventArgs e) {
            InfoPanel.i.StartStopTicking();
        }

        private void Menu_Window_Presets_Click(object sender, EventArgs e) {
            PresetPanel pp = new PresetPanel();
            pp.Show();
            pp.BringToFront();
        }

        private void Menu_Window_Custom_Click(object sender, EventArgs e) {
            if (custom.myPanel.Visible) {
                custom.myPanel.Visible = false;
                Menu_Window_Custom.Text = "Show Custom Panel";
            } else {
                custom.myPanel.Visible = true;
                custom.myPanel.BringToFront();
                Menu_Window_Custom.Text = "Hide Custom Panel";
            }
        }

        private void b_Open_Click(object sender, EventArgs e) {
            if (!mainCp.myPanel.Visible) {
                ShowControlPanel();
                b_Open.Text = "<<";
                b_Open.Location = new Point(mainCp.Width - 15, 0);
            } else {
                HideControlPanel();
                b_Open.Text = ">>";
                b_Open.Location = new Point(0, 0);
            }
        }

        private void Menu_Video_Swap_Click(object sender, EventArgs e) { //ADD SWAP FUNCTIONALITY
            string value;
            if (ConfigControl.savedCamera.stringVal.Contains("Thermal")) {
                value = "Daylight";
            } else {
                value = "Thermal";
            }

            setPage.cB_ipCon_Selected.Text = value;
            setPage.UpdateSelectedCam(true);
        }

        private void Menu_Video_EnableSecondary_Click(object sender, EventArgs e) {
            Menu_Video_EnableSecondary.Visible = false;
            mainPlayer.EnableSecond();
        }

        bool dragging = false;
        Point eOriginalPos;
        private void stream_SecondPlayer_MouseMove(object sender, MouseEventArgs e) {
            Cursor = Cursors.Default;
            if (dragging) {
                int xDragDist = e.X - eOriginalPos.X;
                int yDragDist = e.Y - eOriginalPos.Y;

                if (sP_Player.Location.X + xDragDist > 0 && sP_Player.Location.X + xDragDist < Width - sP_Player.Width)
                    sP_Player.Left += xDragDist;

                if(sP_Player.Location.Y + yDragDist > 0 && sP_Player.Location.Y + yDragDist < Height - sP_Player.Height)
                    sP_Player.Top += yDragDist;
            }
        }

        private void stream_SecondPlayer_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                mainPlayer.secondView.settings.Show();
                mainPlayer.secondView.settings.BringToFront();
            } else if (e.Button == MouseButtons.Left) {
                eOriginalPos = new Point(e.X, e.Y);
                dragging = true;
            }
        }

        private void stream_SecondPlayer_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
            eOriginalPos = new Point(0, 0);
        }

    } // end of class MainForm
} // end of namespace SSLUtility2
