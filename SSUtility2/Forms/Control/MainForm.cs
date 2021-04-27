using SSUtility2.Forms.FinalTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class MainForm : Form {
        
        public const string version = "v2.5.2.0";
        private bool startLiteVersion = false; //only for launch

        private bool closing = false;
        private bool keyboardControl = false;

        public bool finalMode = false;
        public bool lite = false;
        public bool finishedLoading = false;

        public static MainForm m;

        private static List<Control> controlPanel;

        public CustomPanel custom;
        public SettingsPage setPage;
        public PelcoD pd;
        public ResponseLog rl;
        public PresetPanel pp;
        public TabControl attachedpp;
        public Detached mainPlayer;
        public Detached thirdView;
        private Recorder screenRec;

        private string inUseVideoPath;
        private string screenRecordName;
        public string finalDest;

        private const string initString = "6D75724D7A4969576B5A7541475835676E34486D5965784659584E3555477868655756794C564A55553141755A58686C567778576F502F682F69426C59584E35";

        public async Task StartupStuff() {
            try {
                m = this;
                setPage = new SettingsPage();
                rl = new ResponseLog();
                pd = new PelcoD();
                pp = new PresetPanel();
                D.protocol = new D();
                EasyPlayerNetSDK.PlayerSdk.EasyPlayer_Init(initString);


                AttachPlayer();
                AttachInfoPanel();
                AttachCustomPanel();
                AttachPresetPanel();

                controlPanel = new List<Control>() {
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

                FileStuff.FileWork();

                setPage.PopulateSettingText();
                
                Tools.SetFeatureToAllControls(m.Controls);
                HideControlPanel();
                b_Open.BringToFront();
                
                CommandQueue.Init();
                if(startLiteVersion)
                    LiteToggle();

                AutoConnect();

                await Task.Delay(500).ConfigureAwait(false);
                finishedLoading = true;
            } catch (Exception e) {
                Tools.ShowPopup("Init failed!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        async Task AutoConnect() {
            await Task.Delay(250).ConfigureAwait(false);
            bool connected = await AsyncCamCom.TryConnect(true).ConfigureAwait(false);
            await Task.Delay(250).ConfigureAwait(false);
            if (ConfigControl.autoPlay.boolVal && connected && mainPlayer.settings.tB_PlayerD_SimpleAdr.Text != "") {
                mainPlayer.StartPlaying(false);
            }
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

                Recorder rec = Tools.Record(fullVideoPath, player.myPlayer);

                return (isPlaying, rec);
            }
        }

        void AttachPlayer() {
            Detached d = DetachVid(false, new VideoSettings(), true).Result;

            if (!startLiteVersion) {
                var c = Tools.GetAllType(d, typeof(Panel));
                p_Control.Controls.AddRange(c.ToArray());
            }

            Panel player = d.myPlayer;
    
            player.DragOver += (s, e) => {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            player.DragDrop += (s, e) => {
                try {
                    string[] fileName = e.Data.GetData(DataFormats.FileDrop) as string[];
                    if (fileName != null && fileName[0].Contains("txt")) {
                        Tools.CopyConfig(fileName[0]);
                    } else {
                        MessageBox.Show("SSUtility2 only supports dragging/dropping .txt config files!");
                    }
                } catch (Exception error) {
                    Tools.ShowPopup("Failed to open script!\nShow more?", "Script load failed!", error.ToString());
                }
            };
            if (!startLiteVersion) {
                player.MouseMove += (s, e) => {
                    if (!AsyncCamCom.sock.Connected)
                        return;
                    if (Cursor.Position.X - Location.X < 70) {
                        b_Open.Visible = true;
                        b_Open.BringToFront();
                    } else
                        b_Open.Visible = false;
                };
            }
             mainPlayer = d;
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

            p.Size = new Size(140, 160);
            p.Location = new Point(m.p_Control.Width - p.Width, m.p_Control.Height - p.Height);

            var c = Tools.GetAllType(custom, typeof(Button));
            p.Controls.AddRange(c.ToArray());

            p.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            p_Control.Controls.Add(p);

            custom.myPanel = p;
            p.Visible = false;
            p.BringToFront();
        }

        void AttachPresetPanel() {
            try {
                PresetPanel hiddenpanel = new PresetPanel();
                attachedpp = hiddenpanel.tC_Presets_Default;

                p_Control.Controls.Add(attachedpp);

                attachedpp.Location = new Point(0, Height - attachedpp.Height - 65);
                attachedpp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                attachedpp.Hide();
            } catch (Exception e) {
                MessageBox.Show("TC\n" + e.ToString());
            }
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

        void LiteToggle() {
            try {
                if (!lite) {
                    lite = true;
                    ShowControlPanel();
                    m.MinimumSize = new Size(0, 0);
                    m.Size = new Size(305, 340);
                    m.MinimumSize = Size;
                    m.MaximumSize = Size;

                    controlPanel.Add(b_PTZ_Daylight);
                    controlPanel.Add(b_PTZ_Thermal);

                    b_PTZ_Daylight.Visible = true;
                    b_PTZ_Thermal.Visible = true;

                    setPage.UpdateSelectedCam(false);

                    foreach (Control c in controlPanel) {
                        c.Top -= 50;
                    }

                    Menu_Settings_Info.Dispose();
                    Menu_Settings_CP.Dispose();
                    Menu_Video.Dispose();
                    b_Open.Dispose();

                    sP_Player.Hide();
                    mainPlayer.myPlayer.Hide();
                    mainPlayer.settings.isPlaying = true;
                    Joystick.UpdateJoystickCentre();

                    if (startLiteVersion)
                        Menu_Settings_Lite.Dispose();
                    else
                        Menu_Settings_Lite.Text = "Dual Mode";
                    Text = "SSUtility V2.0 Lite";
                } else {
                    Application.Restart();
                    Application.ExitThread();
                    this.Close();
                }
            } catch (Exception er) {
                Tools.ShowPopup("Failed to init Lite Mode!\nShow more?", "Error Occured!", er.ToString());
            }
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
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
            AsyncCamCom.Disconnect(true);
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
            mainPlayer.settings.BringToFront();
            mainPlayer.settings.Location = Location;
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

        private void b_Open_Click(object sender, EventArgs e) {
            OpenCloseCP();
        }

        private void Menu_Video_EnableSecondary_Click(object sender, EventArgs e) {
            Menu_Video_EnableSecondary.Visible = false;

            Detached.EnableSecond(true);
        }

        private void Menu_Settings_Open_Click(object sender, EventArgs e) {
            OpenSettings();
        }

        private void Menu_Settings_Info_Click(object sender, EventArgs e) {
            InfoPanel.i.StartStopTicking();
        }

        void SwapPlayers() {
            string value = "";
            bool daythermswap = false;
            if (ConfigControl.mainPlayerCamType.stringVal.ToLower().Contains("thermal")) {
                value = "Daylight";
                daythermswap = true;
            } else if (ConfigControl.mainPlayerCamType.stringVal.ToLower().Contains("daylight")) {
                value = "Thermal";
                daythermswap = true;
            } else if (mainPlayer.settings.tB_PlayerD_Adr.Text != mainPlayer.secondView.settings.tB_PlayerD_Adr.Text || ConfigControl.forceCamera.boolVal) {
                mainPlayer.CustomSwap();
            }

            if (daythermswap) {
                ConfigControl.mainPlayerCamType.UpdateValue(value);
                setPage.UpdateSelectedCam(true);
            }

        }

        public void StopCam() {
            if (keyboardControl) {
                DelayStop();
            }
        }

        public void KeyControl(Keys k, Keys oldK) {
            try {
                if (keyboardControl) {
                    uint ptSpeed = Convert.ToUInt32((ConfigControl.cameraSpeedMultiplier.intVal / 200f) * 63);
                    byte[] code = null;
                    uint address = Tools.MakeAdr();

                    int x = 0;
                    int y = 0;

                    switch (k) {
                        case Keys.Up:
                            y += 1;
                            break;
                        case Keys.Down:
                            y += -1;
                            break;
                        case Keys.Right:
                            x += 1;
                            break;
                        case Keys.Left:
                            x += -1;
                            break;
                        case Keys.Enter:
                            code = D.protocol.CameraZoom(address, D.Zoom.Tele);
                            break;
                        case Keys.Escape:
                        case Keys.Back:
                            code = D.protocol.CameraZoom(address, D.Zoom.Wide);
                            break;
                    }
                    switch (oldK) {
                        case Keys.Up:
                            y += 1;
                            break;
                        case Keys.Down:
                            y += -1;
                            break;
                        case Keys.Right:
                            x += 1;
                            break;
                        case Keys.Left:
                            x += -1;
                            break;
                    }
                    switch ((k, oldK)) {
                        case (Keys.LShiftKey, Keys.M):
                        case (Keys.M, Keys.LShiftKey):
                            CustomScriptCommands.SendMechanicalMenu();
                            break;
                        case (Keys.LShiftKey, Keys.S):
                        case (Keys.S, Keys.LShiftKey):
                            CustomScriptCommands.SendAdminMenu();
                            break;
                        case (Keys.LShiftKey, Keys.D):
                        case (Keys.D, Keys.LShiftKey):
                            CustomScriptCommands.DoPreset(Convert.ToInt32(address), 2);
                            break;
                    }

                    if (x != 0 || y != 0) {
                        code = GetDirCode(x, y, ptSpeed, ptSpeed, address);
                    }

                    if (code == null)
                        return;
                    else if (AsyncCamCom.sock.Connected)
                        AsyncCamCom.SendNonAsync(code);
                }
            }catch(Exception e) {
                MessageBox.Show("SENDKEY\n" + e.ToString());
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
            AsyncCamCom.SendNonAsync(D.protocol.CameraZoom(Tools.MakeAdr(), D.Zoom.Tele));
        }
         
        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraZoom(Tools.MakeAdr(), D.Zoom.Wide));
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

        void PTZMove(D.Tilt tilt = D.Tilt.Null, D.Pan pan = D.Pan.Null) {
            byte[] code;
            uint speed = Convert.ToUInt32((ConfigControl.cameraSpeedMultiplier.intVal / 200f) * 63);

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
            await Task.Delay(100).ConfigureAwait(false);
            AsyncCamCom.SendNonAsync(D.protocol.CameraStop(Tools.MakeAdr()));
            InfoPanel.i.forcedQueueing = true;
            InfoPanel.i.commandPos = 0;
        }

        private void Joystick_MouseUp(object sender, MouseEventArgs e) {
            if (AsyncCamCom.sock.Connected)
                DelayStop();
            else
                MessageBox.Show("Not connected to camera!\nNo commands were sent!");
        }

        uint JoystickSpeedFunction(float val) {
            //0.5x^2 * y + 3
            uint newVal = (Convert.ToUInt32(((0.5f * Math.Pow(Math.Abs(val), 2) * (ConfigControl.cameraSpeedMultiplier.intVal / 100f)) / 3969) * 63) + 3);

            if (newVal > 63) {
                newVal = 63;
            }

            return newVal;
        }

        public void Tick() {
            try {
                Point coords = Joystick.coords;

                if (Joystick.distance != 0 && AsyncCamCom.sock.Connected) {
                    uint adr = Tools.MakeAdr();
                    int x = coords.X;
                    int y = coords.Y;

                    uint xSpeed = JoystickSpeedFunction(x);
                    uint ySpeed = JoystickSpeedFunction(y);

                    byte[] code = GetDirCode(x, y, xSpeed, ySpeed, adr);

                    if (code != null)
                        AsyncCamCom.SendNonAsync(code);
                }

            } catch (Exception e) {
                Tools.ShowPopup("Failed to send virtual joystick commands!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        byte[] GetDirCode(int x, int y, uint xSpeed, uint ySpeed, uint adr) {
            byte[] code = null;

            D.Pan p = D.Pan.Null;
            D.Tilt t = D.Tilt.Null;

            //diagonals
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
                //horizontal/verticals
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

            return code;
        }

        private void Menu_Settings_CP_Click(object sender, EventArgs e) {
            OpenCloseCP();
        }
        
        private void Menu_Window_Settings_Click(object sender, EventArgs e) {
            OpenSettings();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            try {
                setPage.l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
            } catch{ }
            }

        private void Menu_Settings_Lite_Click(object sender, EventArgs e) {
            LiteToggle();
        }

        private void Menu_QC_Custom_Click(object sender, EventArgs e) {
            new QuickCommandEntry("", "Enter custom command", true);
        }

        private void Menu_Settings_Presets_Click(object sender, EventArgs e) {
            if (attachedpp.Visible) {
                attachedpp.Hide();
                Menu_Settings_Presets.Text = "Enable Preset Panel";
            } else {
                attachedpp.Show();
                attachedpp.BringToFront();
                Menu_Settings_Presets.Text = "Disable Preset Panel";
            }
        }

        private void Menu_Settings_Custom_Click(object sender, EventArgs e) {
            if (custom.myPanel.Visible) {
                custom.myPanel.Visible = false;
                Menu_Settings_Custom.Text = "Enable Custom Panel";
            } else {
                custom.myPanel.Visible = true;
                custom.myPanel.BringToFront();
                Menu_Settings_Custom.Text = "Disable Custom Panel";
            }
        }

        private void Menu_Settings_ImportConfig_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = Tools.OpenFile();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.FileName.Contains(".txt")) {
                    Tools.CopyConfig(fdg.FileName);
                } else {
                    Tools.ShowPopup("Please open a .txt file!\nUser tried to open an unsupported file type! Show more info?", "Invalid File Type!",
                        "User tried opening: " + fdg.FileName + "\nTry opening a .txt file instead.");
                }
            }
        }

        private void Menu_Settings_ExportConfig_Click(object sender, EventArgs e) {
            string[] lines = File.ReadAllLines(ConfigControl.appFolder + ConfigControl.config);
            Tools.SaveTextFile(lines, "configCopy");
        }

        private void b_PTZ_Daylight_Click(object sender, EventArgs e) {
            ConfigControl.mainPlayerCamType.UpdateValue("Daylight");
            setPage.UpdateSelectedCam(false);
        }

        private void b_PTZ_Thermal_Click(object sender, EventArgs e) {
            ConfigControl.mainPlayerCamType.UpdateValue("Thermal");
            setPage.UpdateSelectedCam(false);
        }

        private void sP_Player_DoubleClick(object sender, EventArgs e) {
            SwapPlayers();
        }


        bool dragging = false;
        Point eOriginalPos;

        private void sP_Player_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (sender == sP_Player) {
                    mainPlayer.secondView.settings.Show();
                    mainPlayer.secondView.settings.BringToFront();
                } else if (sender == sP_Third) {
                    thirdView.settings.Show();
                    thirdView.settings.BringToFront();
                }
            } else if (e.Button == MouseButtons.Left) {
                eOriginalPos = new Point(e.X, e.Y);
                dragging = true;
            }
        }

        private void sP_Player_MouseMove(object sender, MouseEventArgs e) {
            SPanel.SizeablePanel p = (SPanel.SizeablePanel)sender;

            if (dragging && !p.resizing) {
                int xDragDist = e.X - eOriginalPos.X;
                int yDragDist = e.Y - eOriginalPos.Y;

                if (p.Location.X + xDragDist > 0 && p.Location.X + xDragDist < Width - p.Width)
                    p.Left += xDragDist;

                if (p.Location.Y + yDragDist > 0 && p.Location.Y + yDragDist < Height - p.Height)
                    p.Top += yDragDist;
            }
        }

        private void sP_Player_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
            eOriginalPos = new Point(0, 0);
        }

        private void Menu_Video_Third_Click(object sender, EventArgs e) {
            if (thirdView == null) {
                thirdView = new Detached(false);
                thirdView.myPlayer.Dispose();
                thirdView.myPlayer = sP_Third;
                thirdView.settings.originalDetached = thirdView;
                thirdView.settings.CopyPlayerD(mainPlayer.settings, true);
                thirdView.settings.Text = "Third Video Settings";
                thirdView.settings.isThird = true;
                thirdView.settings.tP_Main.Text = "Third Player";
                Menu_Video_Third.Text = "Disable Third Player";
                Detached.Play(false, thirdView);
                sP_Third.Show();
                sP_Third.BringToFront();
            } else if (sP_Third.Visible) {
                Menu_Video_Third.Text = "Enable Third Player";
                sP_Third.Hide();
                thirdView.StopPlaying();
            } else {
                Menu_Video_Third.Text = "Disable Third Player";
                sP_Third.Show();
                sP_Third.BringToFront();
                Detached.Play(false, thirdView);
            }
        }

    } // end of class MainForm
} // end of namespace SSLUtility2
