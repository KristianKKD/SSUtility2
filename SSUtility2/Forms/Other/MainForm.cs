using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kaiser;
using static Kaiser.SizeablePanel;

namespace SSUtility2 {
    public partial class MainForm : Form {

        public const string version = "v2.8.4.1";
        private bool startLiteVersion = false; //only for launch

        private bool closing = false;
        private bool keyboardControl = false;

        public bool finalMode = false;
        public bool lite = false;
        public bool finishedLoading = false;

        public static MainForm m;

        public static List<Control> controlPanel;
        public List<Detached> detachedList;
        public List<Process> recorderProcessList;

        public CustomButtons custom;
        public SettingsPage setPage;
        public PelcoD pd;
        public ResponseLog rl;
        public QuickFunctions pp;
        public TabControl attachedqf;
        public Detached mainPlayer;
        public CommandListWindow clw;
        public MediaCollection col;

        public string finalDest;

        private Timer RatioTimer;
        private Point currentDragPos;
        
        private bool resizing = false;
        public int currentAspectRatio;
        public int currentAspectRatioSecondary;
        private Direction resizeDir;

        public List<List<ConfigVar>> playerConfigList;

        public async Task StartupStuff() {
            try {
                CreateHandle();
                m = this;
                RTSPPresets.Reload(false);
                detachedList = new List<Detached>();
                recorderProcessList = new List<Process>();
                VideoSettings.allSettings = new List<VideoSettings>();
                CustomScriptCommands.userAddedCommands = new List<ScriptCommand>();
                setPage = new SettingsPage();
                rl = new ResponseLog();
                pd = new PelcoD();
                pp = new QuickFunctions();
                custom = new CustomButtons();
                clw = new CommandListWindow();
                col = new MediaCollection();
                D.protocol = new D();
                playerConfigList = new List<List<ConfigVar>>();

                if (!startLiteVersion) {
                    if(FileStuff.CheckForLibs())
                        Console.WriteLine("ACTIVATION: " + EasyPlayerNetSDK.PlayerSdk.EasyPlayer_Init().ToString());
                }

                mainPlayer = new Detached(true);
                AttachInfoPanel();
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
                    JoyBack,
                    p_PTZ_Sliders,
                };

                HideControlPanel();
                b_Open.BringToFront();

                bool hasLiteInName = FileStuff.FileWork().Result;
                if (!startLiteVersion)
                    startLiteVersion = hasLiteInName;

                setPage.LoadSettings();

                Tools.SetFeatureToAllControls(m.Controls);

                CommandQueue.Init();

                if (startLiteVersion)
                    LiteToggle();
                else if (ConfigControl.legacyLayout.boolVal)
                    LoadLegacy();
                else
                    AttachPlayers().ConfigureAwait(false);

                finishedLoading = true;

                if (ConfigControl.maintainAspectRatio.boolVal)
                    StartRatioTimer();

                AsyncCamCom.TryConnect(false);

                ActivatePanels();
                col.AddDefaultSavedLocations();
            } catch (Exception e) {
                Tools.ShowPopup("Init failed!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        void ActivatePanels() {
            if (ConfigControl.launchQuickFunctions.boolVal)
                ToggleQF();
            if (ConfigControl.launchInfoPanel.boolVal)
                InfoPanel.i.StartStopTicking();
            if (ConfigControl.launchControlPanel.boolVal)
                OpenCloseCP();
            if (ConfigControl.launchCustomPanel.boolVal)
                ToggleCustomPanel();
        }

        Detached secondPlayer;
        Detached thirdPlayer;
        public async Task AttachPlayers() {
            try {
                bool autoPlay = ConfigControl.autoPlay.boolVal;

                int playercount = ConfigControl.playerCount.intVal;

                if (playercount >= 2 && mainPlayer.attachedPlayers.Count < 1) {
                    if (secondPlayer == null) {
                        secondPlayer = new Detached(false);
                        SizeablePanel second = mainPlayer.AttachPlayerToThis(secondPlayer,
                            new Point(mainPlayer.p_Player.Width - 350, 50));

                        second.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    }
                } else if (playercount < 2 && mainPlayer.attachedPlayers.Contains(secondPlayer)) {
                    mainPlayer.Detach(secondPlayer, true);
                    secondPlayer = null;
                }

                if (playercount >= 3 && mainPlayer.attachedPlayers.Count < 2) {
                    if (thirdPlayer == null) {
                        thirdPlayer = new Detached(false);
                        SizeablePanel third = mainPlayer.AttachPlayerToThis(thirdPlayer,
                            new Point(mainPlayer.p_Player.Width - 350, mainPlayer.p_Player.Height - 250), autoPlay);

                        third.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    }
                } else if (playercount < 3 && mainPlayer.attachedPlayers.Contains(thirdPlayer)) {
                    mainPlayer.Detach(thirdPlayer, true);
                    thirdPlayer = null;
                }

                VideoSettings.UpdateAllPresetBoxes(true, false);
                mainPlayer.settings.LoadPlayer(ConfigControl.mainPlayerPreset.stringVal, autoPlay);

                if (secondPlayer != null)
                    secondPlayer.settings.LoadPlayer(ConfigControl.player2Preset.stringVal, autoPlay);
                if (thirdPlayer != null)
                    thirdPlayer.settings.LoadPlayer(ConfigControl.player3Preset.stringVal, autoPlay);

            } catch (Exception e) {
                MessageBox.Show("ATTACH\n" + e.ToString());
            }
        }

         void LoadLegacy() {
            Detached d = new Detached(false);
            mainPlayer.p_Player = p_Player1;
            d.p_Player = mainPlayer.p_Player;

            p_PlayerPanel.Hide();
        }

        void AttachInfoPanel() {
            try {
                Panel p = new Panel();
                InfoPanel i = new InfoPanel();

                p.Size = new Size(i.Width, i.Height - 35);
                p.Location = new Point(m.Size.Width - i.Width, MenuBar.Height + 3);

                var c = Tools.GetAllType(i, typeof(Label));
                p.Controls.AddRange(c.ToArray());

                p.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                Controls.Add(p);

                i.myPanel = p;
                p.Hide();
            } catch (Exception e) {
                MessageBox.Show("ATTACH INFO\n" + e.ToString());
            }
        }

        void AttachPresetPanel() {
            try {
                QuickFunctions hiddenpanel = new QuickFunctions();
                attachedqf = hiddenpanel.tC_Presets_Default;

                Controls.Add(attachedqf);

                attachedqf.Size = hiddenpanel.tC_Presets_Default.Size;
                attachedqf.Location = new Point(0, Height - hiddenpanel.Height);
                attachedqf.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                attachedqf.Hide();
            } catch (Exception e) {
                MessageBox.Show("ATTACH PRESET\n" + e.ToString());
            }
        }

        public void ShowControlPanel() {
            foreach (Control c in controlPanel) {
                c.Show();
                c.BringToFront();
            }

            p_PTZ_Sliders.Visible = ConfigControl.cpSliders.boolVal;
            QuerySliders();

            switch (ConfigControl.cpLayout.stringVal) {
                case "Standard":
                    b_PTZ_FocusPos.Location = new Point(12, 56);
                    b_PTZ_ZoomNeg.Location = new Point(224, 248);
                    break;
                case "Legacy":
                    b_PTZ_FocusPos.Location = new Point(224, 248);
                    b_PTZ_ZoomNeg.Location = new Point(12, 56);
                    break;
                default:
                    b_PTZ_FocusPos.Location = new Point(12, 56);
                    b_PTZ_ZoomNeg.Location = new Point(224, 248);
                    break;
            }

            Menu_Settings_Panels_CP.Text = "Hide Control Panel";
            b_Open.Text = "<<";
        }

        public void HideControlPanel() {
            try {
                foreach (Control c in controlPanel) {
                    c.Hide();
                }
                Menu_Settings_Panels_CP.Text = "Control Panel";
                b_Open.Text = ">>";
            } catch (Exception e) {
                MessageBox.Show("HIDE PANEL\n" + e.ToString());
            }
        }

        async Task LiteToggle() {
            try {
                if (!lite) {
                    await Task.Delay(50);
                    lite = true;
                    ShowControlPanel();
                    m.MinimumSize = new Size(0, 0);
                    m.Size = new Size(305, 410);
                    m.MinimumSize = Size;
                    m.MaximumSize = Size;

                    controlPanel.Add(b_PTZ_Daylight);
                    controlPanel.Add(b_PTZ_Thermal);

                    foreach (Control c in controlPanel) {
                        c.Show();
                        c.Top -= 50;
                    }

                    int id = MainForm.m.mainPlayer.settings.GetPelcoID();
                    if (id == -1)
                        id = 1;

                    ConfigControl.pelcoOverrideID.UpdateValue(id.ToString());

                    setPage.LiteButtonSelect();

                    Menu_Settings_Panels_IP.Dispose();
                    Menu_Settings_Panels_CP.Dispose();
                    Menu_Settings_ConnectionSettings.Dispose();
                    Menu_Recording.Dispose();
                    b_Open.Dispose();

                    mainPlayer.DestroyAll();

                    mainPlayer.StopPlaying();
                    JoyBack.Joystick.UpdateJoystickCentre();

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

        public void OpenPelco() {
            pd.Show();
            pd.BringToFront();
            pd.Location = Location;
        }

        void OpenFinal() {
            Hidden.Final fin = new Hidden.Final();
            fin.Show();
            fin.BringToFront();
            fin.Location = Location;
        }

        void OpenCloseCP() {
            if (!JoyBack.Visible)
                ShowControlPanel();
            else
                HideControlPanel();
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
            MainForm.m.col.AddToSavedLocations(destination);
        }

        public void WriteToResponses(string text, bool hide, bool isSpam = false) {
            if (closing) {
                return;
            }
            if (this.InvokeRequired) {
                this.Invoke((MethodInvoker)delegate {
                    WriteToResponses(text, hide, isSpam);
                });
            } else {
                if (isSpam && !rl.check_Spam.Checked)
                    return;

                string finalText = text;
                string sender = AsyncCamCom.GetSockEndpoint();

                if (rl.tB_Log.Text.Length > 2000000000)
                    rl.tB_Log.Clear();
                if (hide && !isSpam)
                    sender = "CLIENT";
                if (!hide || rl.check_Hide.Checked)
                    rl.AddText(finalText, sender);
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            closing = true;
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);

            FFMPEGRecord.StopAll();

            try {
                if (!startLiteVersion)
                    EasyPlayerNetSDK.PlayerSdk.EasyPlayer_Release();
            } catch (Exception err) { }
        }

        private void Menu_Window_Detached_Click(object sender, EventArgs e) {
            Detached d = new Detached(false, true);
            d.Show();
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

        private void Menu_QC_PanZero_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand("panzero");
        }

        private void Menu_QC_Pan_Click(object sender, EventArgs e) {
            new QuickCommandEntry("abspan", "Enter pan pos value");
        }

        private void Menu_QC_Tilt_Click(object sender, EventArgs e) {
            new QuickCommandEntry("abstilt", "Enter tilt pos value");
        }

        private void Menu_QC_Zoom_Click(object sender, EventArgs e) {
            new QuickCommandEntry("abszoom", "Enter zoom pos value");
        }

        public FFMPEGRecord.RecordType currentType;

        private void Menu_Recording_Video_SSUtility_Click(object sender, EventArgs e) {
            currentType = FFMPEGRecord.RecordType.SSUtility;
            FFMPEGRecord.ssutilRecorder = Tools.ToggleRecord(null, Menu_Recording_Video, Menu_Recording_StopRecording);
        }

        private void Menu_Recording_Video_MainPlayer_Click(object sender, EventArgs e) {
            currentType = FFMPEGRecord.RecordType.Player;
            mainPlayer.recorder = Tools.ToggleRecord(mainPlayer, Menu_Recording_Video, Menu_Recording_StopRecording);
        }

        private void Menu_Recording_Global_Click(object sender, EventArgs e) {
            currentType = FFMPEGRecord.RecordType.Global;
            FFMPEGRecord.GlobalRecord();
        }


        private void Menu_RecordIndicator_Click(object sender, EventArgs e) {
            currentType = FFMPEGRecord.RecordType.Global;
            FFMPEGRecord.GlobalRecord();
        }

        private void Menu_Recording_StopRecording_Click(object sender, EventArgs e) {
            switch (currentType) {
                case FFMPEGRecord.RecordType.Player:
                    mainPlayer.recorder = Tools.ToggleRecord(mainPlayer, Menu_Recording_Video, Menu_Recording_StopRecording);
                    break;
                case FFMPEGRecord.RecordType.SSUtility:
                    FFMPEGRecord.ssutilRecorder = Tools.ToggleRecord(null, Menu_Recording_Video, Menu_Recording_StopRecording);
                    break;
                case FFMPEGRecord.RecordType.Global:
                    FFMPEGRecord.GlobalRecord();
                    break;
            }

            currentType = FFMPEGRecord.RecordType.Global;
        }

        private void Menu_Window_Presets_Click(object sender, EventArgs e) {
            pp.Show();
            pp.BringToFront();
            pp.Location = Location;
        }

        private void b_Open_Click(object sender, EventArgs e) {
            OpenCloseCP();
        }

        private void Menu_Settings_Open_Click(object sender, EventArgs e) {
            OpenSettings();
        }

        private void Menu_Settings_ConnectionSettings_Click(object sender, EventArgs e) {
            mainPlayer.settings.Show();
            mainPlayer.settings.BringToFront();
            mainPlayer.settings.Location = Location;
        }

        public void SwapSettings(Detached player) {
            VideoSettings.SwapSettings(player.settings);
        }

        public void StopCam() {
            if (keyboardControl)
                DelayStop();
        }

        public void KeyControl(Keys k, Keys oldK) {
            try {
                if (!Tools.IsMainActive())
                    return;

                if ((oldK == Keys.LControlKey && k == Keys.L) ||
                    (k == Keys.LControlKey && oldK == Keys.L)) {
                    DebugWindow dg = new DebugWindow();
                    dg.Show();
                    dg.BringToFront();
                    return;
                }

                if ((oldK == Keys.LControlKey && k == Keys.U) ||
                    (k == Keys.LControlKey && oldK == Keys.U)) {
                    Hidden.UPControl uc = new Hidden.UPControl();
                    uc.Show();
                    uc.BringToFront();
                    return;
                }

                if (custom.isVisible && k.ToString().Length == 2) {
                    int but;
                    if (int.TryParse(k.ToString().Substring(1, 1), out but)) {
                        if (but > 0 && but < 10)
                            custom.DoCommand(but - 1);
                    }
                }

                if (keyboardControl) {
                    uint ptSpeed = Convert.ToUInt32((ConfigControl.cameraPTSpeedMultiplier.intVal / 200f) * 63);
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

                    if (x != 0 || y != 0)
                        code = GetDirCode(x, y, ptSpeed, ptSpeed, address);

                    if (code == null)
                        return;
                    else if (AsyncCamCom.sock.Connected)
                        AsyncCamCom.SendNonAsync(code);
                }
            } catch (Exception e) {
                MessageBox.Show("SENDKEY\n" + e.ToString());
            }
        }

        private void Menu_Settings_Keyboard_Click(object sender, EventArgs e) {
            if (keyboardControl) {
                keyboardControl = false;
                Menu_Settings_Keyboard.Text = "PTZ Keyboard";
            } else {
                keyboardControl = true;
                Menu_Settings_Keyboard.Text = "Hide PTZ Keyboard";
            }
        }

        async Task Zoom(bool isPositive) {
            //int val = 32767 + (int)Math.Round(((ConfigControl.cameraZoomSpeedMultiplier.intVal - 100) / 100f) * 32767);
            int val = ConfigControl.cameraZoomSpeedMultiplier.intVal;
            await CustomScriptCommands.QuickCommand("setzoomspeed " + val.ToString(), false).ConfigureAwait(true);

            D.Zoom type = D.Zoom.Wide;
            if (isPositive)
                type = D.Zoom.Tele;

            AsyncCamCom.SendNonAsync(D.protocol.CameraZoom(Tools.MakeAdr(), type));
        }

        async Task Focus(bool isPositive) {
            //int val = 32767 + (int)Math.Round(((ConfigControl.cameraFocusSpeedMultiplier.intVal - 100) / 100f) * 32767);
            int val = ConfigControl.cameraFocusSpeedMultiplier.intVal;
            await CustomScriptCommands.QuickCommand("setfocusspeed " + val.ToString(), false).ConfigureAwait(true);

            D.Focus type = D.Focus.Near;
            if (isPositive)
                type = D.Focus.Far;

            AsyncCamCom.SendNonAsync(D.protocol.CameraFocus(Tools.MakeAdr(), type));
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            Zoom(true);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            Zoom(false);
        }

        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            Focus(true);
        }

        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            Focus(false);
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
            uint speed = Convert.ToUInt32((ConfigControl.cameraPTSpeedMultiplier.intVal / 200f) * 63);

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
            InfoPanel.i.UpdateNext();
        }

        private void JoyBack_JoyReleased(object sender, EventArgs e) {
            if (AsyncCamCom.sock.Connected)
                DelayStop();
            else
                MessageBox.Show("Not connected to camera!\nNo commands were sent!");
        }

        uint JoystickSpeedFunction(float val) {
            //0.5x^2 * y + 3
            uint newVal = (Convert.ToUInt32(((0.5f * Math.Pow(Math.Abs(val), 2) * (ConfigControl.cameraPTSpeedMultiplier.intVal / 100f)) / 3969) * 63) + 3);

            if (newVal > 63)
                newVal = 63;

            return newVal;
        }

        byte[] lastCode;
        public void Tick() {
            try {
                Point coords = JoyBack.Joystick.coords;

                if (JoyBack.Joystick.distance != 0 && AsyncCamCom.sock.Connected) {
                    uint adr = Tools.MakeAdr();
                    int x = coords.X;
                    int y = coords.Y;

                    uint xSpeed = JoystickSpeedFunction(x);
                    uint ySpeed = JoystickSpeedFunction(y);

                    byte[] code = GetDirCode(x, y, xSpeed, ySpeed, adr);

                    if (code != null & code != lastCode)
                        AsyncCamCom.SendNonAsync(code);

                    lastCode = code;
                }

            } catch (Exception err) {
                Tools.ShowPopup("Failed to send virtual joystick commands!\nShow more?", "Error Occurred!", err.ToString());
                JoyBack.Joystick.Centre();
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

        private void Menu_Settings_Panels_QF_Click(object sender, EventArgs e) {
            ToggleQF();
        }

        void ToggleQF() {
            if (attachedqf.Visible) {
                attachedqf.Hide();
                Menu_Settings_Panels_QF.Text = "Quick Functions";
            } else {
                attachedqf.Show();
                attachedqf.BringToFront();
                Menu_Settings_Panels_QF.Text = "Hide Quick Functions";
            }
        }

        private void Menu_Settings_Panels_IP_Click(object sender, EventArgs e) {
            InfoPanel.i.StartStopTicking();
        }

        private void Menu_Settings_Panels_Custom_Click(object sender, EventArgs e) {
            ToggleCustomPanel();
        }

        void ToggleCustomPanel() {
            if (custom.isVisible)
                custom.HideButtons();
            else
                custom.ShowButtons();
        }

        private void Menu_Settings_Panels_CP_Click(object sender, EventArgs e) {
            OpenCloseCP();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            try {
                setPage.l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
                resizing = false;
                mainPlayer.RefreshPlayers();
            } catch { }
        }

        private void Menu_Settings_Lite_Click(object sender, EventArgs e) {
            LiteToggle();
        }

        private void Menu_QC_Custom_Click(object sender, EventArgs e) {
            new QuickCommandEntry("", "Enter quick command", true);
        }

        private void Menu_Settings_Config_Import_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = Tools.OpenFile();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.FileName.Contains(".txt")) {
                    Tools.ImportConfig(fdg.FileName, false);
                } else {
                    Tools.ShowPopup("Please open a .txt file!\nUser tried to open an unsupported file type! Show more info?", "Invalid File Type!",
                        "User tried opening: " + fdg.FileName + "\nTry opening a .txt file instead.");
                }
            }
        }

        private void Menu_Settings_Config_Export_Click(object sender, EventArgs e) {
            string[] lines = File.ReadAllLines(ConfigControl.appFolder + ConfigControl.config);
            Tools.SaveTextFile(lines, "configCopy");
        }

        private void b_PTZ_Daylight_Click(object sender, EventArgs e) {
            ConfigControl.pelcoOverrideID.UpdateValue("1");
            setPage.LiteButtonSelect();
        }

        private void b_PTZ_Thermal_Click(object sender, EventArgs e) {
            ConfigControl.pelcoOverrideID.UpdateValue("2");
            setPage.LiteButtonSelect();
        }

        private void p_PlayerPanel_MouseMove(object sender, MouseEventArgs e) {
            if ((!AsyncCamCom.sock.Connected || lite) && !JoyBack.Visible && !InfoPanel.i.isCamera) {
                b_Open.Visible = false;
                return;
            }

            if (Cursor.Position.X - Location.X < 70) {
                b_Open.Visible = true;
                b_Open.BringToFront();
            } else
                b_Open.Visible = false;
        }

        private void p_PlayerPanel_DragOver(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void p_PlayerPanel_DragDrop(object sender, DragEventArgs e) {
            try {
                string[] fileName = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (fileName != null && fileName[0].Contains("txt")) {
                    Tools.ImportConfig(fileName[0], true);
                } else {
                    MessageBox.Show("SSUtility2 only supports dragging/dropping .txt config files!");
                }
            } catch (Exception error) {
                Tools.ShowPopup("Failed to open script!\nShow more?", "Script load failed!", error.ToString());
            }
        }

        public void StopRatioTimer() {
            MinimumSize = new Size(800, 600);
            MaximumSize = new Size(0, 0);

            RatioTimer.Stop();
        }

        int minWidth = 0;
        int minHeight = 0;
        public void StartRatioTimer() {
            try {
                float initialRatio = (float)Width / (float)Height;

                //TO DO:
                //grab initial frame as reference (remove resizing restrictions of main player maybe)
                //find out ratio of the frame
                //find nearest resolution using that ratio

                for (int i = 1; true; i++) {
                    float val = i * initialRatio;
                    if (val - Math.Floor(val) < 0.1) {
                        currentAspectRatio = (int)Math.Floor(val);
                        currentAspectRatioSecondary = i;
                        break;
                    }
                }

                setPage.UpdateRatioLabel();
                Console.WriteLine(currentAspectRatio + ":" + currentAspectRatioSecondary);

                minWidth = 0;
                minHeight = 0;
                for (int o = 1; o * currentAspectRatioSecondary < Width + currentAspectRatio; o++) {
                    int heightVal = o * currentAspectRatioSecondary;
                    if (heightVal >= 600) {
                        for (int i = 1; i * currentAspectRatio <= Width + currentAspectRatio; i++) {
                            int widthVal = i * currentAspectRatio;

                            if ((int)Math.Round(widthVal / initialRatio) == heightVal && widthVal >= 800) {
                                Console.WriteLine("------FOUND " + widthVal + "x" + heightVal);
                                minWidth = widthVal;
                                minHeight = heightVal;
                                break;
                            }
                        }
                    }

                    if (minWidth != 0)
                        break;
                }

                if (minWidth == 0) {
                    minWidth = 800;
                    minHeight = 600;
                }

                Console.WriteLine(minWidth.ToString() + "x" + minHeight.ToString());

                MinimumSize = Size;
                MaximumSize = Size;

                RatioTimer = new Timer();
                RatioTimer.Interval = 1;
                RatioTimer.Tick += new EventHandler(MaintainRatio);
                RatioTimer.Start();
            } catch (Exception e) {
                MessageBox.Show("RATIOTIMER\n" + e.ToString());
            }
        }

        public string GetRatio() {
            return "(" + currentAspectRatio.ToString() + ":" + currentAspectRatioSecondary.ToString() + ")";
        }

        void MaintainRatio(object sender, EventArgs e) {
            try {
                if (resizing) {
                    Point pos = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);

                    Size s = new Size();

                    switch (resizeDir) {
                        case Direction.Up:
                            s = new Size(Width, Height - pos.Y);
                            break;
                        case Direction.Down:
                            s = new Size(Width, Height + (pos.Y - currentDragPos.Y));
                            break;
                        case Direction.Left:
                            s = new Size(Width - pos.X, Height);
                            break;
                        case Direction.Right:
                            s = new Size(Width + (pos.X - currentDragPos.X), Height);
                            break;
                        case Direction.UpL:
                            s = new Size(Width - pos.X, Height - pos.Y);
                            break;
                        case Direction.UpR:
                            s = new Size(Width + (pos.X - currentDragPos.X), Height - pos.Y);
                            break;
                        case Direction.DownR:
                            s = new Size(Width + (pos.X - currentDragPos.X), Height + (pos.Y - currentDragPos.Y));
                            break;
                        case Direction.DownL:
                            s = new Size(Width - pos.X, Height + (pos.Y - currentDragPos.Y));
                            break;
                        default:
                            break;
                    }

                    currentDragPos = pos;

                    if ((s.Width > 0 || s.Height > 0)) {
                        float ratio = (float)currentAspectRatio / (float)currentAspectRatioSecondary;

                        int wVal = s.Width;
                        int hVal = s.Height;
                        if (s.Width != Width)
                            hVal = (int)Math.Round(s.Width / ratio);
                        else if (s.Height != Height)
                            wVal = (int)Math.Round(s.Height * ratio);

                        if (hVal < minHeight)
                            hVal = minHeight;
                        if (wVal < minWidth)
                            wVal = minWidth;

                        s = new Size(wVal, hVal);

                        MinimumSize = s;
                        MaximumSize = s;
                    }

                }
            } catch { }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e) {
            try {
                currentDragPos = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);

                int grip = 5;
                Point pos = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);

                if (pos.X >= this.ClientSize.Width - grip) {       //grabbed right side
                    if (pos.Y >= this.ClientSize.Height - grip) {  // bottom right
                        resizeDir = Direction.DownR;
                    } else if (pos.Y <= grip) {                    // top right
                        resizeDir = Direction.UpR;
                    } else {                                            // right
                        resizeDir = Direction.Right;
                    }
                } else if (pos.X <= grip) {                        //grabbed left side
                    if (pos.Y >= this.ClientSize.Height - grip) {  // bottom left
                        resizeDir = Direction.DownL;
                    } else if (pos.Y <= grip) {                    // top left
                        resizeDir = Direction.UpL;
                    } else {                                            // left
                        resizeDir = Direction.Left;
                    }
                } else if (pos.Y >= this.ClientSize.Height - grip) {//grabbed down
                    resizeDir = Direction.Down;
                } else if (pos.Y <= grip) {                        //up
                    resizeDir = Direction.Up;
                } else {
                    resizeDir = Direction.None;
                }

                if (resizeDir != Direction.None)
                    resizing = true;

            } catch { }
        }

       
        bool displayingPano = false;
        bool stopPano = false;
        int panoFOV = 40;

        private void Menu_Recording_Snapshot_Single_Click(object sender, EventArgs e) {
            Tools.SaveSnap(mainPlayer);
        }

        private void Menu_Recording_Snapshot_Panoramic_Click(object sender, EventArgs e) {
            panoFOV = 40;
            string stop = "Stop Panoramic";

            if (displayingPano) {
                pB_Panoramic.Hide();
                displayingPano = false;
                Menu_Recording_Snapshot_Panoramic.Text = "Panoramic";
                return;
            }

            if (Menu_Recording_Snapshot_Panoramic.Text == stop) {
                stopPano = true;
            } else {
                Menu_Recording_Snapshot_Panoramic.Text = stop;
                Panoramic();
            }
        }

        async Task Panoramic() {
            try {
                if (!mainPlayer.IsPlaying()) {
                    MessageBox.Show("Player is not playing!");
                    return;
                }

                if (!await AsyncCamCom.TryConnect(true)) //has inbuilt error messages
                    return;

                //string fovString = "";
                //float parsedFOV = -999;

                //for (int i = 0; i < 5; i++) {
                //    fovString = await CustomScriptCommands.QuickQuery("queryfov");
                //    if (fovString != "" && fovString != OtherCamCom.defaultResult) {
                //        parsedFOV = OtherCamCom.ReturnedHexValToFloat(fovString);
                //        break;
                //    } else {
                //        await Task.Delay(500);
                //    }
                //}

                //if (parsedFOV != -999) {
                //    fov = (int)Math.Round(30 - parsedFOV);
                //} else {
                //    if (!Tools.ShowPopup("Failed to fetch FOV!\nIgnore and proceed with FOV of " + panoFOV.ToString() + "?", "Fetch Failed!", null, false))
                //        return;
                //}

                mainPlayer.HideAttached();
                HideControlPanel();

                string tempStorage = ConfigControl.savedFolder + @"temp\";
                Tools.CheckCreateFile(null, tempStorage);

                Panel pPlayer = mainPlayer.p_Player;
                int width = pPlayer.Width;
                int height = pPlayer.Height;

                int snapshotCount = (int)Math.Round(360f / panoFOV) - 1; //look into this
                Image fullScreenshot = new Bitmap(@"C:\Users\waakk\Documents\SSUtility\Saved\temp\test.jpg");

                CustomScriptCommands.QuickCommand("abszoom 0", true);

                for (int i = 0; i < snapshotCount || stopPano; i++) {
                    CustomScriptCommands.QuickCommand("setpan " + (i * panoFOV).ToString(), true);

                    int waitAmount = 1500;
                    if (i == 0)
                        waitAmount = 3000;

                    await Task.Delay(waitAmount);

                    using (Image part = new Bitmap(width, height)) {
                        Graphics gfx = Graphics.FromImage(part);
                        gfx.CopyFromScreen(pPlayer.RectangleToScreen(pPlayer.ClientRectangle).Location, Point.Empty, pPlayer.Size);
                        Graphics.FromImage(fullScreenshot).DrawImage(part, new Point(width * i, 0));
                        part.Save(tempStorage + "test" + i.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

                if (!stopPano) {
                    string fullImagePath = Tools.GivePath(Tools.PathType.Panoramic, mainPlayer);

                    fullScreenshot.Save(fullImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Tools.FinalScreenshot(fullImagePath);

                    pB_Panoramic.Parent = pPlayer;
                    pB_Panoramic.Show();
                    pB_Panoramic.BringToFront();
                    pB_Panoramic.Height = (int)Math.Round(Height / 4f);
                    pB_Panoramic.SizeMode = PictureBoxSizeMode.Zoom;
                    pB_Panoramic.Image = fullScreenshot;

                    displayingPano = true;
                    Menu_Recording_Snapshot_Panoramic.Text = "Hide Panoramic";
                }

                //if (Directory.Exists(tempStorage))
                //    Tools.DeleteDirectory(tempStorage); //test this //doesnt work because it conflicts with pB_Pano

            } catch (Exception e) {
                Tools.ShowPopup("Error occurred whilst creating a panoramic screenshot!\nShow more?", "Error Occurred!", e.ToString());
            }

            mainPlayer.ShowAttached();
            stopPano = false;

            if (!displayingPano)
                Menu_Recording_Snapshot_Panoramic.Text = "Panoramic";
        }

        private void pB_Panoramic_MouseClick(object sender, MouseEventArgs e) {
            try {
                if (displayingPano) {
                    float scaled = e.X / (MainForm.m.mainPlayer.p_Player.Width / 360f);
                    int pos = ((int)Math.Round(scaled / panoFOV) * panoFOV);
                    Console.WriteLine(scaled.ToString() + " " + pos.ToString());
                    CustomScriptCommands.QuickCommand("abspan " + pos.ToString(), true);
                }
            } catch (Exception er) {
                MessageBox.Show("PANOMOUSECLICK\n" + er.ToString());
            }

            pB_Panoramic.Hide();
        }

        private void Menu_Recording_Collection_Click(object sender, EventArgs e) {
            col.Show();
            col.UpdateAll();
        }

        private void Menu_Recording_Snapshot_All_Click(object sender, EventArgs e) {
            SnapshotAll();
        }

        async Task SnapshotAll() {
            try {
                List<Control> enabledPanels = new List<Control>();

                if (InfoPanel.i.myPanel.Visible)
                    enabledPanels.Add(InfoPanel.i.myPanel);

                if (custom.isVisible)
                    foreach (Button b in custom.buttonList)
                        enabledPanels.Add(b);

                if (attachedqf.Visible)
                    enabledPanels.Add(attachedqf);

                foreach (Detached d in mainPlayer.attachedPlayers) {
                    d.p_Player.Hide();
                    enabledPanels.Add(d.p_Player);
                }

                if (JoyBack.Visible)
                    foreach (Control c in controlPanel)
                        enabledPanels.Add(c);

                foreach (Control c in enabledPanels)
                    c.Hide();

                string timeText = DateTime.Now.ToString().Replace("/", "-").Replace(":", ";");
                string customPath = Tools.GivePath(Tools.PathType.Folder, mainPlayer) + @"Snapshots/" + timeText + @"/";
                Tools.CheckCreateFile(null, customPath);
                Console.WriteLine(customPath);

                for (int i = -1; i < mainPlayer.attachedPlayers.Count; i++) {
                    Detached d;
                    if (i == -1)
                        d = mainPlayer;
                    else
                        d = mainPlayer.attachedPlayers[i];


                    Panel sp = d.p_Player;

                    sp.Show();

                    sp.Dock = DockStyle.Fill;

                    sp.BringToFront();
                    await Task.Delay(100);
                    Tools.SaveSnap(d, i == mainPlayer.attachedPlayers.Count, customPath);
                    await Task.Delay(100);

                    if (i > -1)
                        sp.Dock = DockStyle.None;
                }


                foreach (Control c in enabledPanels) {
                    c.Show();
                    c.BringToFront();
                }

            } catch(Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        bool draggingZ;
        bool draggingF;

        void ZScrollFunction(bool send = true) {
            tB_PTZ_SlidersZText.Text = slider_PTZ_AbsZoom.Value.ToString();
            if (send)
                CustomScriptCommands.QuickCommand("abszoom " + Math.Round(655.35 * slider_PTZ_AbsZoom.Value));
        }

        void FScrollFunction(bool send = true) {
            tB_PTZ_SlidersFText.Text = slider_PTZ_AbsFocus.Value.ToString();
            if (send)
                CustomScriptCommands.QuickCommand("absfocus " + Math.Round(655.35 * slider_PTZ_AbsFocus.Value));
        }

        private void tB_PTZ_SlidersZText_KeyPress(object sender, KeyPressEventArgs e) {
            int val = Tools.IsValidVal(sender, 1, 65535);

            if (e.KeyChar == (char)Keys.Enter) {
                tB_PTZ_SlidersZText.Text = val.ToString();
                slider_PTZ_AbsZoom.Value = val;
                ZScrollFunction();
            }
        }

        private void tB_PTZ_SlidersZText_Leave(object sender, EventArgs e) {
            tB_PTZ_SlidersZText.Text = slider_PTZ_AbsZoom.Value.ToString();
        }

        private void slider_PTZ_AbsZoom_Scroll(object sender, EventArgs e) {
            if (draggingZ)
                ZScrollFunction(false);
        }

        private void slider_PTZ_AbsZoom_MouseDown(object sender, MouseEventArgs e) {
            draggingZ = true;
        }

        private void slider_PTZ_AbsZoom_MouseUp(object sender, MouseEventArgs e) {
            ZScrollFunction();
            draggingZ = false;
        }
    
        private void tB_PTZ_SlidersFText_KeyPress(object sender, KeyPressEventArgs e) {
            int val = Tools.IsValidVal(sender, 1, 65535);

            if (e.KeyChar == (char)Keys.Enter) {
                tB_PTZ_SlidersFText.Text = val.ToString();
                slider_PTZ_AbsFocus.Value = val;
                FScrollFunction();
            }
        }

        private void tB_PTZ_SlidersFText_Leave(object sender, EventArgs e) {
            tB_PTZ_SlidersFText.Text = slider_PTZ_AbsFocus.Value.ToString();
        }

        private void slider_PTZ_AbsFocus_Scroll(object sender, EventArgs e) {
            if (draggingF)
                FScrollFunction(false);
        }
        private void slider_PTZ_AbsFocus_MouseDown(object sender, MouseEventArgs e) {
            draggingF = true;
        }

        private void slider_PTZ_AbsFocus_MouseUp(object sender, MouseEventArgs e) {
            FScrollFunction();
            draggingF = false;
        }

        async Task QuerySliders() {
            string zoomTb = "0";
            string focusTb = "0";

            if (InfoPanel.i.isCamera && p_PTZ_Sliders.Visible) {
                string zoomResponse = await CustomScriptCommands.QuickQuery("queryzoom");
                if (float.TryParse(OtherCamCom.ConvertQueryResult("queryzoom", zoomResponse), out float zoom))
                    zoomTb = ((float)Math.Round(zoom / 65535f) * 100).ToString();

                string focusResponse = await CustomScriptCommands.QuickQuery("queryfocus");
                if (float.TryParse(OtherCamCom.ConvertQueryResult("queryfocus", focusResponse), out float focus))
                    focusTb = ((float)Math.Round(focus / 65535f) * 100).ToString();
            }

            tB_PTZ_SlidersZText.Text = zoomTb;
            tB_PTZ_SlidersFText.Text = focusTb;
            ZScrollFunction(false);
            FScrollFunction(false);
        }

        private void b_Player1_Stop_Click(object sender, EventArgs e) {
            mainPlayer.StopPlaying();
            b_Player1_Stop.Visible = false;
        }

        private void b_Player1_Play_Click(object sender, EventArgs e) {
            string full = "";
            try {
                if (checkB_Player1_Manual.Checked)
                    full = tB_Player1_SimpleAdr.Text;
                else {
                    string ipaddress = tB_Player1_Adr.Text;
                    string port = tB_Player1_Port.Text;
                    string url = tB_Player1_RTSP.Text;
                    string username = tB_Player1_Username.Text;
                    string password = tB_Player1_Password.Text;

                    string userPass = username + ":" + password + "@";
                    if (username.Length <= 0 && password.Length <= 0)
                        userPass = "";

                    string colonPort = ":" + port;
                    if (port.Length <= 0)
                        colonPort = "";

                    full = "rtsp://" + userPass + ipaddress + colonPort + "/" + url;

                    mainPlayer.Play(true, true, full);
                    b_Player1_Stop.Visible = true;

                    //full = tB_Player1_Name.Text + ";" + full + ";" + ipaddress + ";" + port + ";" + url + ";" + username
                    //   + ";" + password + ";" + tB_Legacy_PelcoID.Text + ";;;";

                    //RTSPPresets.LoadPreset(full);
                }


            } catch (Exception err) {
                Console.WriteLine(err.ToString());
            };

        }

        private void checkB_Player1_Manual_CheckedChanged(object sender, EventArgs e) {
            if (checkB_Player1_Manual.Checked) {
                p_Player1_Simple.Hide();
                p_Player1_Extended.Show();
            } else {
                p_Player1_Extended.Hide();
                p_Player1_Simple.Show();
            }
        }

        private void b_Legacy_Connect_Click(object sender, EventArgs e) {
            IPAddress ip;
            if(!IPAddress.TryParse(tB_Legacy_IP.Text, out ip)) {
                MessageBox.Show("Please enter a valid IP Address!");
                return;
            }

            int port;
            if (!int.TryParse(tB_Legacy_Port.Text, out port)) {
                MessageBox.Show("Please enter a valid port, must be a number!");
                return;
            }


            IPEndPoint ep = new IPEndPoint(ip, port);
            if(AsyncCamCom.TryConnect(true, ep).Result) {
                ConfigControl.savedIP.UpdateValue(tB_Legacy_IP.Text);
                ConfigControl.savedPort.UpdateValue(tB_Legacy_Port.Text);
            }
        }

        private void tB_Legacy_PelcoID_TextChanged(object sender, EventArgs e) {
            int parsedVal;
            if (int.TryParse(tB_Legacy_PelcoID.Text, out parsedVal))
                ConfigControl.pelcoOverrideID.intVal = parsedVal;
            else
                ConfigControl.pelcoOverrideID.intVal = 0;
        }
    } // end of class MainForm
} // end of namespace SSUtility2
