using SSUtility2.Forms.FinalTest;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class MainForm : Form {
        
        public const string version = "v2.3.2.1";

        private bool closing = false;
        private bool keyboardControl = false;

        public bool finalMode = false;

        public static Control[] saveList;
        private static Control[] controlPanel;

        public CustomPanel custom;
        public SettingsPage setPage;
        public PelcoD pd;
        public ResponseLog rl;
        public PresetPanel pp;

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
                pp = new PresetPanel();
                D.protocol = new D();

                bool first = CheckIfFirstTime();

                mainPlayer = AttachPlayer();

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
                controlPanel = new Control[] {
                    b_PTZ_Up,
                    b_PTZ_Down,
                    b_PTZ_Left,
                    b_PTZ_Right,
                    b_PTZ_ZoomPos,
                    b_PTZ_ZoomNeg,
                    b_PTZ_FocusPos,
                    b_PTZ_FocusNeg,
                    pB_Background,
                    Joystick,
                };

                FileStuff(first);

                setPage.PopulateSettingText();
                
                Tools.SetFeatureToAllControls(m.Controls);
                HideControlPanel();
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

        public void ShowControlPanel() {
            foreach (Control c in controlPanel) {
                c.Show();
                c.BringToFront();
            }
            Menu_Settings_CP.Text = "Hide Control Panel";
            b_Open.Text = "<<";
        }

        public void HideControlPanel() {
            foreach (Control c in controlPanel) {
                c.Hide();
            }
            Menu_Settings_CP.Text = "Show Control Panel";
            b_Open.Text = ">>";
        }

        Detached AttachPlayer() {
            Detached d = DetachVid(false, new VideoSettings(), true).Result;

            var c = Tools.GetAllType(d, typeof(WebEye.StreamControl.WinForms.StreamControl));
            p_Control.Controls.AddRange(c.ToArray());

            return d;
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
            pd.Location = Location;
        }

        void OpenFinal() {
            Final fin = new Final();
            fin.Show();
            fin.BringToFront();
            fin.Location = Location;
        }

        public void OpenOsiris() {
            Osiris o = new Osiris();
            o.Show();
            o.BringToFront();
            o.Location = Location;
        }
        void OpenCloseCP() {
            if (!Joystick.Visible) {
                ShowControlPanel();
            } else {
                HideControlPanel();
            }
        }

        void OpenSettings() {
            setPage.Show();
            setPage.BringToFront();
            setPage.Location = Location;
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

        public void WriteToResponses(string text, bool hide, bool isInfo = false) {
            if (closing) {
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
            AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
        }

        private void Menu_Window_Detached_Click(object sender, EventArgs e) {
            DetachVid(true, mainPlayer.settings, false);
        }

        private void Menu_Window_PelcoD_Click(object sender, EventArgs e) {
            OpenPelco();
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
            rl.Location = Location;
        }

        private void Menu_Window_Osiris_Click(object sender, EventArgs e) {
            OpenOsiris();
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

        private void Menu_Window_Presets_Click(object sender, EventArgs e) {
            pp.Show();
            pp.BringToFront();
            pp.Location = Location;
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
            OpenCloseCP();
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

        private void Menu_Settings_Open_Click(object sender, EventArgs e) {
            OpenSettings();
        }

        private void Menu_Settings_Info_Click(object sender, EventArgs e) {
            InfoPanel.i.StartStopTicking();
        }

        private void Menu_Settings_Swap_Click(object sender, EventArgs e) {
            string value;
            if (ConfigControl.savedCamera.stringVal.Contains("Thermal")) {
                value = "Daylight";
            } else {
                value = "Thermal";
            }

            setPage.cB_ipCon_Selected.Text = value;
            setPage.UpdateSelectedCam(true);
        }


        public void StopCam() {
            if (keyboardControl) {
                CustomScriptCommands.QuickCommand("stop", false);
            }
        }

        public void KeyControl(Keys k) {
            if (keyboardControl) {
                uint ptSpeed = Convert.ToUInt32(63);
                byte[] code = null;
                uint address = Tools.MakeAdr();

                switch (k) { //maybe add diagonal support later
                    case Keys.Up:
                        code = D.protocol.CameraTilt(address, D.Tilt.Up, ptSpeed);
                        break;
                    case Keys.Down:
                        code = D.protocol.CameraTilt(address, D.Tilt.Down, ptSpeed);
                        break;
                    case Keys.Left:
                        code = D.protocol.CameraPan(address, D.Pan.Left, ptSpeed);
                        break;
                    case Keys.Right:
                        code = D.protocol.CameraPan(address, D.Pan.Right, ptSpeed);
                        break;
                    case Keys.Enter:
                        code = D.protocol.CameraZoom(address, D.Zoom.Tele);
                        break;
                    case Keys.Escape:
                        code = D.protocol.CameraZoom(address, D.Zoom.Wide);
                        break;
                }

                AsyncCamCom.SendNewCommand(code);
            }
        }

        private void Menu_Settings_Keyboard_Click(object sender, EventArgs e) {
            if (keyboardControl) {
                keyboardControl = false;
                Menu_Settings_Keyboard.Text = "Enable PTZ Keyboard";
            } else {
                keyboardControl = true;
                Menu_Settings_Keyboard.Text = "Disable PTZ Keyboard";
            }
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            PTZZoom(D.Zoom.Tele);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            PTZZoom(D.Zoom.Wide);
        }
        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraFocus(Tools.MakeAdr(), D.Focus.Far));
        }

        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraFocus(Tools.MakeAdr(), D.Focus.Near));
        }

        private void b_PTZ_Up_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(D.Tilt.Up);
        }

        private void b_PTZ_Down_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(D.Tilt.Down);
        }

        private void b_PTZ_Left_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(D.Tilt.Null, D.Pan.Left);
        }

        private void b_PTZ_Right_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(D.Tilt.Null, D.Pan.Right);
        }

        private void b_PTZ_Any_MouseUp(object sender, MouseEventArgs e) {
            DelayStop();
        }

        public void PTZZoom(D.Zoom dir) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraZoom(Tools.MakeAdr(), dir));
        }

        void PTZMove(D.Tilt tilt = D.Tilt.Null, D.Pan pan = D.Pan.Null) {
            byte[] code;
            uint speed = Convert.ToUInt32(63);

            if (tilt != D.Tilt.Null) {
                code = D.protocol.CameraTilt(Tools.MakeAdr(), tilt, speed);
            } else {
                code = D.protocol.CameraPan(Tools.MakeAdr(), pan, speed);
            }

            AsyncCamCom.SendNonAsync(code);
        }

        async Task DelayStop() {
            if (!AsyncCamCom.sock.Connected) {
                return;
            }
            AsyncCamCom.SendNonAsync(D.protocol.CameraStop(Tools.MakeAdr()));
            await Task.Delay(ConfigControl.commandRateMs.intVal).ConfigureAwait(false);
            AsyncCamCom.SendNonAsync(D.protocol.CameraStop(Tools.MakeAdr()));
        }

        private void Joystick_MouseUp(object sender, MouseEventArgs e) {
            if (AsyncCamCom.sock.Connected)
                CustomScriptCommands.QuickCommand("stop", false);
        }
        public void Tick() {
            try {
                Point coords = Joystick.coords;

                if (Joystick.distance != 0 && AsyncCamCom.sock.Connected) {
                    byte[] code = null;

                    uint adr = Tools.MakeAdr();
                    int x = coords.X;
                    int y = coords.Y;

                    uint xSpeed = Convert.ToUInt32(((0.25f * Math.Pow(Math.Abs(x), 2)) / 992) * 63);
                    uint ySpeed = Convert.ToUInt32(((0.25f * Math.Pow(Math.Abs(y), 2)) / 992) * 63);

                    //diagonals
                    D.Pan p = D.Pan.Null;
                    D.Tilt t = D.Tilt.Null;

                    if (x < 0 && y < 0) {
                        p = D.Pan.Left;
                        t = D.Tilt.Down;
                    } else if (x > 0 && y < 0) {
                        p = D.Pan.Right;
                        t = D.Tilt.Down;
                    } else if (x < 0 && y > 0) {
                        p = D.Pan.Left;
                        t = D.Tilt.Up;
                    } else if (x > 0 && y > 0) {
                        p = D.Pan.Right;
                        t = D.Tilt.Up;
                    }
                    //

                    if (p != D.Pan.Null && t != D.Tilt.Null) {
                        code = D.protocol.CameraPanTilt(adr, p, xSpeed, t, ySpeed);
                    } else {
                        //horizontal/vertical only
                        if (x > 0 && y == 0) {
                            code = D.protocol.CameraPan(adr, D.Pan.Right, xSpeed);
                        } else if (x < 0 && y == 0) {
                            code = D.protocol.CameraPan(adr, D.Pan.Left, xSpeed);
                        } else if (y > 0 && x == 0) {
                            code = D.protocol.CameraTilt(adr, D.Tilt.Up, ySpeed);
                        } else if (y < 0 && x == 0) {
                            code = D.protocol.CameraTilt(adr, D.Tilt.Down, ySpeed);
                        }
                        //
                    }

                    if (code != null)
                        AsyncCamCom.SendNonAsync(code);
                }

            } catch (Exception e) {
                Tools.ShowPopup("Failed to send virtual joystick commands!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        private void Menu_Settings_CP_Click(object sender, EventArgs e) {
            OpenCloseCP();
        }
        
        private void Menu_Window_Settings_Click(object sender, EventArgs e) {
            OpenSettings();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            setPage.l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
        }
    } // end of class MainForm
} // end of namespace SSLUtility2
