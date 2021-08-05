﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kaiser;
using static Kaiser.SizeablePanel;

namespace SSUtility2 {
    public partial class MainForm : Form {

        public const string version = "v2.8.0.12";
        private bool startLiteVersion = false; //only for launch

        private bool closing = false;
        private bool keyboardControl = false;

        public bool finalMode = false;
        public bool lite = false;
        public bool finishedLoading = false;

        public static MainForm m;

        public static List<Control> controlPanel;

        public CustomButtons custom;
        public SettingsPage setPage;
        public PelcoD pd;
        public ResponseLog rl;
        public PresetPanel pp;
        public TabControl attachedpp;
        public Detached mainPlayer;
        public CommandListWindow clw;
        private Recorder screenRec;

        private string inUseVideoPath;
        private string screenRecordName;
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
                RTSPPresets.Reload();
                VideoSettings.allSettings = new List<VideoSettings>();
                CustomScriptCommands.userAddedCommands = new List<ScriptCommand>();
                setPage = new SettingsPage();
                rl = new ResponseLog();
                pd = new PelcoD();
                pp = new PresetPanel();
                custom = new CustomButtons();
                clw = new CommandListWindow();
                D.protocol = new D();
                playerConfigList = new List<List<ConfigVar>>();

                Console.WriteLine("ACTIVATION: " + EasyPlayerNetSDK.PlayerSdk.EasyPlayer_Init().ToString());

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
                };

                HideControlPanel();
                b_Open.BringToFront();

                bool hasLiteInName = FileStuff.FileWork().Result;
                if (!startLiteVersion)
                    startLiteVersion = hasLiteInName;

                setPage.PopulateSettingText();

                Tools.SetFeatureToAllControls(m.Controls);

                CommandQueue.Init();

                if (startLiteVersion) {
                    LiteToggle();
                } else
                    await AttachPlayers();

                finishedLoading = true;

                if (ConfigControl.maintainAspectRatio.boolVal)
                    StartRatioTimer();

                AsyncCamCom.TryConnect(false);
            } catch (Exception e) {
                Tools.ShowPopup("Init failed!\nShow more?", "Error Occurred!", e.ToString());
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
                string fullVideoPath = Tools.GivePath(ConfigControl.vFolder.stringVal,
                    ConfigControl.vFileName.stringVal, player.settings, "Recordings", ".avi");
                inUseVideoPath = fullVideoPath;
                isPlaying = true;

                Recorder rec = Tools.Record(fullVideoPath, player.p_Player);

                return (isPlaying, rec);
            }
        }

        Detached secondPlayer;
        Detached thirdPlayer;
        public async Task AttachPlayers() {
            try {
                bool autoPlay = ConfigControl.autoPlay.boolVal;

                if (autoPlay)
                    mainPlayer.Play(false, false);

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

                if (secondPlayer != null)
                    secondPlayer.settings.LoadSecondary(ConfigControl.player2Preset.stringVal, autoPlay);
                if (thirdPlayer != null)
                    thirdPlayer.settings.LoadSecondary(ConfigControl.player3Preset.stringVal, autoPlay);

            } catch (Exception e) {
                MessageBox.Show("ATTACH\n" + e.ToString());
            }
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
                PresetPanel hiddenpanel = new PresetPanel();
                attachedpp = hiddenpanel.tC_Presets_Default;

                Controls.Add(attachedpp);

                attachedpp.Size = hiddenpanel.tC_Presets_Default.Size;
                attachedpp.Location = new Point(0, Height - hiddenpanel.Height);
                attachedpp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                attachedpp.Hide();
            } catch (Exception e) {
                MessageBox.Show("ATTACH PRESET\n" + e.ToString());
            }
        }

        public void ShowControlPanel() {
            foreach (Control c in controlPanel) {
                c.Show();
                c.BringToFront();
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
                    m.Size = new Size(305, 340);
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
                    Menu_Video.Dispose();
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
            if (!JoyBack.Visible) {
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

        public void WriteToResponses(string text, bool hide, bool isSpam = false) {
            if (closing) {
                return;
            }
            if (this.InvokeRequired) {
                this.Invoke((MethodInvoker)delegate {
                    WriteToResponses(text, hide, isSpam);
                });
            } else {
                string finalText = text;

                if (rl.tB_Log.Text.Length > 2000000000) {
                    rl.tB_Log.Clear();
                }
                string sender = AsyncCamCom.GetSockEndpoint();
                if (hide && !isSpam) {
                    sender = "CLIENT";
                }
                if (isSpam && !rl.check_Spam.Checked) {
                    return;
                }
                if (!hide || rl.check_Hide.Checked) {
                    rl.AddText(finalText, sender);
                }
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            closing = true;
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
            EasyPlayerNetSDK.PlayerSdk.EasyPlayer_Release();
        }

        private void Menu_Window_Detached_Click(object sender, EventArgs e) {
            Detached d = new Detached(false);
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

        private void Menu_Window_Osiris_Click(object sender, EventArgs e) {
            OpenOsiris();
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

        private void Menu_Video_Settings_Click(object sender, EventArgs e) {
            mainPlayer.settings.Show();
            mainPlayer.settings.BringToFront();
            mainPlayer.settings.Location = Location;
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

        private void Menu_Settings_Open_Click(object sender, EventArgs e) {
            OpenSettings();
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

                if (custom.isVisible && k.ToString().Length == 2) {
                    int but;
                    if (int.TryParse(k.ToString().Substring(1, 1), out but)) {
                        if (but > 0 && but < 10)
                            custom.DoCommand(but - 1);
                    }
                }

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
            uint newVal = (Convert.ToUInt32(((0.5f * Math.Pow(Math.Abs(val), 2) * (ConfigControl.cameraSpeedMultiplier.intVal / 100f)) / 3969) * 63) + 3);

            if (newVal > 63) {
                newVal = 63;
            }

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
            if (attachedpp.Visible) {
                attachedpp.Hide();
                Menu_Settings_Panels_QF.Text = "Quick Functions";
            } else {
                attachedpp.Show();
                attachedpp.BringToFront();
                Menu_Settings_Panels_QF.Text = "Hide Quick Functions";
            }
        }

        private void Menu_Settings_Panels_IP_Click(object sender, EventArgs e) {
            InfoPanel.i.StartStopTicking();
        }

        private void Menu_Settings_Panels_Custom_Click(object sender, EventArgs e) {
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
            if (!AsyncCamCom.sock.Connected || lite)
                return;
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
            float initialRatio = (float)Width / (float)Height;
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

        private void Menu_Video_Snap_Single_Click(object sender, EventArgs e) {
            Tools.SaveSnap(mainPlayer);
        }

        bool displayingPano = false;
        bool stopPano = false;
        int panoFOV = 40;
        private void Menu_Video_Snap_Panoramic_Click(object sender, EventArgs e) {
            panoFOV = 40;
            string stop = "Stop Panoramic";

            if (displayingPano) {
                pB_Panoramic.Hide();
                displayingPano = false;
                Menu_Video_Snap_Panoramic.Text = "Panoramic";
                return;
            }

            if (Menu_Video_Snap_Panoramic.Text == stop) {
                stopPano = true;
            } else {
                Menu_Video_Snap_Panoramic.Text = stop;
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
                    string fullImagePath = Tools.GivePath(ConfigControl.scFolder.stringVal,
                    "Panoramic", mainPlayer.settings, "Snapshots", ".jpg");

                    fullScreenshot.Save(fullImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Tools.FinalScreenshot(fullImagePath);

                    pB_Panoramic.Parent = pPlayer;
                    pB_Panoramic.Show();
                    pB_Panoramic.BringToFront();
                    pB_Panoramic.Height = (int)Math.Round(Height / 4f);
                    pB_Panoramic.SizeMode = PictureBoxSizeMode.Zoom;
                    pB_Panoramic.Image = fullScreenshot;

                    displayingPano = true;
                    Menu_Video_Snap_Panoramic.Text = "Hide Panoramic";
                }

                //if (Directory.Exists(tempStorage))
                //    Tools.DeleteDirectory(tempStorage); //test this //doesnt work because it conflicts with pB_Pano

            } catch (Exception e) {
                Tools.ShowPopup("Error occurred whilst creating a panoramic screenshot!\nShow more?", "Error Occurred!", e.ToString());
            }

            mainPlayer.ShowAttached();
            stopPano = false;

            if (!displayingPano)
                Menu_Video_Snap_Panoramic.Text = "Panoramic";
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

            //pB_Panoramic.Hide();
        }

    } // end of class MainForm
} // end of namespace SSUtility2
