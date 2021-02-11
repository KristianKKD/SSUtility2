using SSUtility2.Forms.FinalTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class MainForm : Form {

        public const string version = "v1.3.13.7";

        private bool lite = false;
        private bool isOriginal = false;
        private bool movedUp = true;
        public bool finalMode = false;

        public static Control[] saveList = new Control[0];

        public ControlPanel ipCon;
        public SettingsPage setPage;
        public PelcoD pd;
        public ResponseLog rl;

        public Detached playerL;
        public Detached playerR;

        private Recorder screenRec;
        
        private string inUseVideoPath;
        private string screenRecordName;
        
        public string finalDest;

        public static MainForm m { get; set; }

        public async Task StartupStuff() {
            m = this;
            setPage = new SettingsPage();
            rl = new ResponseLog();
            pd = new PelcoD();
            D.protocol = new D();
            CommandQueue.Init();

            lite = false;
            l_Version.Text = l_Version.Text + version;
            bool first = CheckIfFirstTime();

            p_Main.Select();

            AttachControlPanel();
            playerL = AttachDetached(10);
            playerR = AttachDetached(690);

            CreateInfoPanels(playerL, playerR);

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
                playerL.tB_PlayerD_Name,

                playerR.cB_PlayerD_Type,
                playerR.tB_PlayerD_Adr,
                playerR.tB_PlayerD_Port,
                playerR.tB_PlayerD_RTSP,
                playerR.tB_PlayerD_Buffering,
                playerR.tB_PlayerD_Username,
                playerR.tB_PlayerD_Password,
                playerR.tB_PlayerD_SimpleAdr,
                playerR.tB_PlayerD_Name,
            };

            FileStuff(first);

            setPage.PopulateSettingText();
            SetFeatureToAllControls(m.Controls);
            AutoConnect();
        }

        void CreateInfoPanels(Detached playerL, Detached playerR) {
            AttachInfoPanel(playerL, 270);
            AttachInfoPanel(playerR, 950);
            playerL.myInfoRef.otherD = playerR;
            playerR.myInfoRef.otherD = playerL;
        }

        bool CheckIfFirstTime() {
            if (!File.Exists(ConfigControl.appFolder + ConfigControl.config)) {
                return true;
            } else {
                return false;
            }
        }

        async Task AutoConnect() {
            bool connected = CameraCommunicate.Connect(ipCon.tB_IPCon_Adr.Text, ipCon.tB_IPCon_Port.Text, ipCon.l_IPCon_Connected, true).Result;
            await Task.Delay(1000);
            if (ConfigControl.autoPlay.boolVal) {
                if (playerL.tB_PlayerD_SimpleAdr.Text != "") {
                    if (Play(playerL.VLCPlayer_D, playerL.GetCombined(), playerL.tB_PlayerD_SimpleAdr, playerL.tB_PlayerD_Buffering.Text, false).Result
                        && connected && playerL.GetCombined().ToString().Contains(ipCon.tB_IPCon_Adr.Text)) {

                        playerL.StartPlaying(false);
                    }
                }
                if (playerR.tB_PlayerD_SimpleAdr.Text != "") {
                    if (Play(playerR.VLCPlayer_D, playerR.GetCombined(), playerR.tB_PlayerD_SimpleAdr, playerR.tB_PlayerD_Buffering.Text, false).Result
                        && connected && playerR.GetCombined().ToString().Contains(ipCon.tB_IPCon_Adr.Text)) {

                        playerR.StartPlaying(false);
                    }
                }
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

        public static SaveFileDialog SaveFile(string name, string extension, string startDir) {
            SaveFileDialog fileDlg = new SaveFileDialog();
            fileDlg.InitialDirectory = startDir;
            fileDlg.DefaultExt = extension;
            fileDlg.Filter = "All files (*.*)|*.*";
            fileDlg.FilterIndex = 1;
            fileDlg.RestoreDirectory = true;
            fileDlg.Title = "Select File";
            fileDlg.FileName = name;
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
            CheckCreateFile(ConfigControl.config, ConfigControl.appFolder);
            CheckCreateFile(ConfigControl.autoSave, ConfigControl.appFolder);
            CheckCreateFile(null, ConfigControl.savedFolder);
        }

        string CheckFileForDir() {
            try {
                string[] lines = File.ReadAllLines(ConfigControl.dirLocationFile);

                foreach (string line in lines) {
                    string currentLine = line.Trim();
                    if (currentLine.Contains(@":\")) {
                        if (CheckIfNameValid(currentLine)) {
                            CheckCreateFile(null, currentLine);
                        }
                        return currentLine;
                    }
                }
            } catch { }
            return null;   
        }

        void CheckForNewDir() {
            bool noFile = CheckCreateFile(null, ConfigControl.dirCheck).Result;

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
            bool choose = ShowPopup("Would you like to change your default directory?\nCurrent app folder: " + ConfigControl.appFolder, "Choose your directory", null, false);
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
            }
        }

        void AttachInfoPanel(Detached d, int xOffset) {
            Panel p = new Panel();
            InfoPanel i = new InfoPanel();
            
            d.myInfoRef = i;
            i.d = d;

            p.Size = i.Size;
            p.Location = new Point(d.VLCPlayer_D.Location.X + xOffset, d.VLCPlayer_D.Location.Y);

            var c = GetAll(i);
            p.Controls.AddRange(c.ToArray());

            p_Control.Controls.Add(p);
        }

        void AttachControlPanel() {
            ipCon = SpawnControlPanel(p_Control, false);

            PresetPanel pp = AttachPresetPanel(p_Control, ipCon);
            pp.cp = ipCon;

            isOriginal = true; 
        }

        Detached AttachDetached(int xOffset) {
            Panel pan = new Panel();
            Detached d = DetachVid(false);

            var c = GetAllType(d, typeof(Panel));
            var c2 = GetAllType(d, typeof(Button));
            var c3 = GetAllType(d, typeof(Label));
            var c4 = GetAllType(d, typeof(AxAXVLC.AxVLCPlugin2));
            var c5 = GetAllType(d, typeof(CheckBox));
            var c6 = GetAllType(d, typeof(TextBox));

            pan.Controls.AddRange(c.ToArray());
            pan.Controls.AddRange(c2.ToArray());
            pan.Controls.AddRange(c3.ToArray());
            pan.Controls.AddRange(c4.ToArray());
            pan.Controls.AddRange(c5.ToArray());
            pan.Controls.AddRange(c6.ToArray());

            d.VLCPlayer_D.Location = new Point(d.VLCPlayer_D.Location.X, d.VLCPlayer_D.Location.Y + 5);

            pan.Size = new Size(d.Width - 18, d.Height - 40);
            pan.Location = new Point(ipCon.Location.X + ipCon.Size.Width + xOffset, ipCon.Location.Y + 45);

            p_Control.Controls.Add(pan);

            return d;
        }
       
        public void InitLiteMode() {
            m.Size = new Size(300, Height);
            AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
            lite = true;
            
            p_Control.Dispose();

            ControlPanel cp = SpawnControlPanel(p_Main);
            PresetPanel pp = AttachPresetPanel(p_Main, cp);
            saveList = new Control[]{
                cp.cB_IPCon_Type,
                cp.tB_IPCon_Adr,
                cp.tB_IPCon_Port,
                cp.cB_IPCon_Selected,
            };
            ipCon = cp;
            AutoSave.LoadAuto(ConfigControl.appFolder + ConfigControl.autoSave, false);

            pp.cp = cp;
            isOriginal = false;
            Menu_Window_Lite.Text = "Dual Mode";
        }


        public void MovePlayers(bool showingStats) {
            Control parL = playerL.b_PlayerD_Play.Parent;
            Control parR = playerR.b_PlayerD_Play.Parent;

            if (movedUp) {
                if (showingStats) {
                    parR.Location = new Point(parR.Location.X, parR.Location.Y + 20);
                    parL.Location = new Point(parL.Location.X, parL.Location.Y + 20);
                    movedUp = false;
                }
            } else {
                if (!showingStats) {
                    if (!playerL.check_PlayerD_StatsEnabled.Checked && !playerR.check_PlayerD_StatsEnabled.Checked) {
                        parL.Location = new Point(parL.Location.X, parL.Location.Y - 20);
                        parR.Location = new Point(parR.Location.X, parR.Location.Y - 20);
                        movedUp = true;
                    }
                }
            }
        }

        public Detached DetachVid(bool show) {
            Detached dv = new Detached();
            if (show) {
                dv.Show();
            }
            SetFeatureToAllControls(dv.Controls);
            return dv;
        }

        public PelcoD OpenPelco(string ip, string port, string selected) {
            pd.tB_IPCon_Adr.Text = ip;
            pd.tB_IPCon_Port.Text = port;
            pd.cB_IPCon_Selected.Text = selected;
            pd.Show();
            pd.BringToFront();
            return pd;
        }

        ControlPanel SpawnControlPanel(Panel p, bool makeLite = true) {
            Panel pan = new Panel();
            ControlPanel cp = new ControlPanel();

            if (makeLite) {
                cp.cB_IPCon_Type.Text = ipCon.cB_IPCon_Type.Text;
                cp.tB_IPCon_Adr.Text = ipCon.tB_IPCon_Adr.Text;
                cp.tB_IPCon_Port.Text = ipCon.tB_IPCon_Port.Text;
                cp.cB_IPCon_Selected.Text = ipCon.cB_IPCon_Selected.Text;
            }


            SetFeatureToAllControls(cp.Controls);

            cp.StartConnect();

            pan.Size = new Size(cp.Size.Width, cp.Size.Height - 30);
            pan.Location = new Point(pan.Location.X, pan.Location.Y);
            p.Controls.Add(pan);

            AddControls(pan, cp);
            return cp;
        }

        PresetPanel AttachPresetPanel(Panel p, ControlPanel panel) {
            Panel pan = new Panel();
            PresetPanel pp = new PresetPanel();
            
            SetFeatureToAllControls(pp.Controls);
            pp.mainRef = m;
            panel.SendToBack();

            pan.Location = new Point(0, panel.Size.Height - 40);
            pan.Size = pp.Size;

            p.Controls.Add(pan);

            var c = GetAllType(pp, typeof(TabControl));
            var cTwo = GetAllType(pp, typeof(Label));
            pan.Controls.AddRange(c.ToArray());
            pan.Controls.AddRange(cTwo.ToArray());
            return pp;
        }

        void AddControls(Panel pan, Control panel) {
            var c = GetAll(panel);
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
                    if (control != p_Control) {
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

        public static bool ShowPopup(string message, string caption, string error, bool showError = true) {
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
            try {
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
            } catch (Exception e) {
                ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                return false;
            }
        }

        public void Replay(AxAXVLC.AxVLCPlugin2 player, string combinedUrl, string buffering) {
            if (player.playlist.isPlaying) {
                player.playlist.stop();
                player.playlist.items.clear();
            }

            player.playlist.add(combinedUrl, null, ":avcodec -hw:network -caching=" + buffering); //might have to look at more options
            player.playlist.next();
            player.playlist.play();
        }

        public void ExtendOptions(bool check, Panel gbExt, Panel gbSim) {
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

        public uint MakeAdr(ComboBox comboBox = null) {
            if (comboBox == null) {
                comboBox = ipCon.cB_IPCon_Selected;
            }
            if (comboBox.Text == "Daylight") {
                return 1;
            } else if (comboBox.Text == "Thermal") {
                return 2;
            } else {
                return uint.Parse(comboBox.Text);
            }
        }

        public string ReadCommand(byte[] command, bool hide = false) {
            string msg = "";
            for (int i = 0; i < command.Length; i++) {
                string hex = command[i].ToString("X").ToUpper();
                if (hex.Length == 1) {
                    hex = "0" + hex;
                }
                msg += hex + " ";
            }
            msg = msg.Trim();
            if (!hide) {
                MessageBox.Show(msg);
            }
            return msg;
        }

        public void WriteToResponses(string text, bool hide, bool isSpam = false) {
            this.Invoke((MethodInvoker)delegate {
                if (rl.rtb_Log.Text.Length > 2000000000) {
                    rl.rtb_Log.Clear();
                }
                string sender = AsyncCameraCommunicate.GetSockEndpoint();
                if (hide && !isSpam) {
                    sender = "CLIENT";
                }
                if (isSpam && !rl.check_Info.Enabled) {
                    return;
                }
                if (!hide || rl.check_RL_All.Checked) {
                    rl.rtb_Log.AppendText("[" + sender + " at " + DateTime.Now + "]: " + text + "\n");
                }
            });
        }

        public void PTZMove(bool IsTilt, uint address, uint speed,
            D.Tilt tilt = D.Tilt.Up, D.Pan pan = D.Pan.Left,
            string ip = null, string port = null, Control lcon = null) {
            byte[] code;

            if (CameraCommunicate.lastIPPort != ip + port) {
                CameraCommunicate.Connect(ip, port, lcon);
            }

            if (IsTilt) {
                code = D.protocol.CameraTilt(address, tilt, speed);
            } else {
                code = D.protocol.CameraPan(address, pan, speed);
            }

            CameraCommunicate.sendtoIPAsync(code, ipCon.l_IPCon_Connected, ip, port, true);
        }

        public void PTZZoom(D.Zoom dir, uint address, string ip, string port, Label lcon) {
            if (CameraCommunicate.lastIPPort != ip + port) {
                CameraCommunicate.Connect(ip, port, lcon);
            }

            CameraCommunicate.sendtoIPAsync(D.protocol.CameraZoom(address, dir), lcon, ip, port, true);
        }

        public void SaveSnap(Detached player) {
            string fullImagePath = GivePath(ConfigControl.scFolder.stringVal, ConfigControl.scFileName.stringVal, player, "Snapshots") + ".jpg";

            Image bmp = new Bitmap(player.VLCPlayer_D.Width, player.VLCPlayer_D.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            Rectangle rec = player.VLCPlayer_D.RectangleToScreen(player.VLCPlayer_D.ClientRectangle);
            gfx.CopyFromScreen(rec.Location, Point.Empty, player.VLCPlayer_D.Size);

            bmp.Save(fullImagePath, ImageFormat.Jpeg);

            if (finalMode) {
                SaveFileDialog fdg = SaveFile(ConfigControl.scFileName.stringVal, ".jpg", finalDest);
                DialogResult result = fdg.ShowDialog();
                if (result == DialogResult.OK) {
                    CopySingleFile(fdg.FileName, fullImagePath);
                }
                MessageBox.Show("Image saved : " + fullImagePath +
                        "\nFinal saved: " + fdg.FileName);
            } else {
                MessageBox.Show("Image saved : " + fullImagePath);
            }
        }

        public (bool, Recorder) StopStartRec(bool isPlaying, Detached player, Recorder r) {
            if (isPlaying) {
                player.b_PlayerD_StartRec.Text = "START Recording";
                isPlaying = false;
                
                r.Dispose();

                if (finalMode) {
                    SaveFileDialog fdg = SaveFile(ConfigControl.vFileName.stringVal, ".avi", finalDest);
                    DialogResult result = fdg.ShowDialog();
                    if (result == DialogResult.OK) {
                        CopySingleFile(fdg.FileName, inUseVideoPath);
                    }
                    MessageBox.Show("Saved recording to: " + inUseVideoPath +
                        "\nFinal saved: " + fdg.FileName);
                } else {
                    MessageBox.Show("Saved recording to: " + inUseVideoPath);
                }

                return (isPlaying, null);
            } else {
                string fullVideoPath = GivePath(ConfigControl.vFolder.stringVal, ConfigControl.vFileName.stringVal, player, "Recordings") + ".avi";
                inUseVideoPath = fullVideoPath;
                player.b_PlayerD_StartRec.Text = "STOP Recording";
                isPlaying = true;

                Recorder rec = Record(fullVideoPath, player.VLCPlayer_D);

                return (isPlaying, rec);
            }
        }

        private void Menu_Record_Click(object sender, EventArgs e) {
            if (screenRec != null) {
                screenRec.Dispose();
                screenRec = null;
                Menu_Record.Text = "Record SSUtility2";

                if (finalMode) {
                    SaveFileDialog fdg = SaveFile(ConfigControl.screencapFileName.stringVal, ".avi", finalDest);
                    DialogResult result = fdg.ShowDialog();
                    if (result == DialogResult.OK) {
                        CopySingleFile(fdg.FileName, screenRecordName);
                    }
                    MessageBox.Show("Saved recording to: " + screenRecordName +
                        "\nFinal saved: " + fdg.FileName);
                } else {
                    MessageBox.Show("Saved recording to: " + screenRecordName);
                }

            } else {
                CheckCreateFile(null, ConfigControl.vFolder.stringVal + @"\SSUtility2\");
                string folder = ConfigControl.vFolder.stringVal + @"\SSUtility2\";
                screenRecordName = folder + ConfigControl.screencapFileName.stringVal + (Directory.GetFiles(folder).Length + 1).ToString() + ".avi";
                screenRec = Record(screenRecordName, null);
                Menu_Record.Text = "Stop Recording";
            }

        }

        private Recorder Record(string path, AxAXVLC.AxVLCPlugin2 player) {
            Recorder rec = new Recorder(new Record(path, ConfigControl.recFPS.intVal,
                    SharpAvi.KnownFourCCs.Codecs.MotionJpeg, ConfigControl.recQual.intVal, player));
            return rec;
        }

        string GivePath(string orgFolder, string orgName, Detached detachedPlayer, string folderType) {
            string folder = orgFolder;
            string fileName = orgName + (Directory.GetFiles(orgFolder).Length + 1).ToString();
            string adr = GetPlayerAdrOrName(detachedPlayer);

            if (adr != "") {
                adr += @"\";
            } else {
                folderType = "";
            }

            if (ConfigControl.automaticPaths.boolVal) {
                folder = ConfigControl.savedFolder + adr + folderType;
                string timeText = DateTime.Now.ToString().Replace("/", "-").Replace(":", ";");
                fileName = orgName + " " + timeText;
            }

            CheckCreateFile(null, folder);

            string full = folder + @"\" + fileName;
            return full;
        }

        public static void CopySingleFile(string destination, string sourceFile, bool copyingDirectory = false) {
            string curFile = string.Empty;
            string newLocation = string.Empty;
            try {
                string name = sourceFile.Substring(sourceFile.LastIndexOf("\\") + 1);
                curFile = sourceFile;
                newLocation = destination + name;

                if (copyingDirectory) {
                    destination += @"\";
                    string tempFile = destination + @"CopiedFile";

                    if (!File.Exists(newLocation)) {
                        if (name == ConfigControl.config) {
                            ConfigControl.portableMode.UpdateValue("true");
                            ConfigControl.CreateConfig(destination + @"\" + ConfigControl.config);
                            ConfigControl.portableMode.UpdateValue("false");
                        } else {
                            File.Copy(sourceFile, tempFile, true);
                            File.Move(tempFile, destination + @"\" + name); //renames file
                        }
                    }

                } else {
                    File.Copy(sourceFile, destination, true);
                }
            } catch (Exception e) {
                MainForm.ShowPopup("Couldn't copy individual file to new directory!\nShow more info?", 
                    "Copy failed!", "File: " + curFile + "\nfailed to copy to:\n" + newLocation + 
                    "\n\nError: " + e.ToString());
            }
        }

        public static void CopyFiles(string destination, string[] sourceDir) {
            foreach (string file in sourceDir) {
                CopySingleFile(destination, file, true);
            }
        }

        public static void DeleteDirectory(string oldFolderPath) {
            string[] files = Directory.GetFiles(oldFolderPath);
            string[] dirs = Directory.GetDirectories(oldFolderPath);

            foreach (string file in files) {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs) {
                DeleteDirectory(dir);
            }

            Directory.Delete(oldFolderPath, false);
        }

        public static void CopyDirs(string pathTo, string[] copyDir) {
            string curDir = string.Empty;
            string newLocation = string.Empty;
            try {
                foreach (string subDir in copyDir) {
                    string name = subDir.Substring(subDir.LastIndexOf("\\"));
                    curDir = subDir;
                    newLocation = pathTo + name;

                    DirectoryInfo newDir = Directory.CreateDirectory(pathTo + name);

                    if (Directory.GetFiles(subDir).Length > 0) {
                        CopyFiles(newDir.FullName, Directory.GetFiles(subDir));
                    }
                    if (Directory.GetDirectories(subDir).Length > 0) {
                        CopyDirs(newDir.FullName, Directory.GetDirectories(subDir));
                    }
                }
            } catch (Exception e) {
                MainForm.ShowPopup("Couldn't copy directory to new location!\nShow more info?", 
                    "Copy failed!", "Directory: " + curDir + "\nfailed to copy to:\n" + newLocation + 
                    "\n\nError: " + e.ToString());
            }
        }

        public static string GetPlayerAdrOrName(Detached player) {
            try {
                string nameText = player.tB_PlayerD_Name.Text;
                string adrText = player.tB_PlayerD_SimpleAdr.Text;
                string returnString = "";

                if (adrText != "") {
                    Uri uriAddress = new Uri(adrText);
                    returnString = uriAddress.Host;
                }
                if (nameText != "") {
                    returnString = nameText;
                }
                if (!CheckIfNameValid(returnString, false)) {
                    return "";
                }

                return returnString;
            } catch {
                return "";
            } 
        }

        public static bool CheckIfNameValid(string name, bool everythingBad = false) {
            char[] nameArray = name.ToCharArray();
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
                        ShowPopup("Invalid character detected, Show more?", "Cannot create file",
                            "Do not use invalid symbols in file names.\nInvalid character found: " + c);
                        return false;
                    }
                }
            }
            return true;
        }

        public static async Task<bool> CheckCreateFile(string fileName, string folderName = null) {
            bool didntExist = false;

            if (folderName != null) {
                if (!Directory.Exists(folderName)) {
                    Directory.CreateDirectory(folderName);
                    didntExist = true;
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
                    didntExist = true;
                }
            }
            return didntExist;
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

        private void Menu_QC_PanZero_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand("panzero");
        }

        private void Menu_Window_Osiris_Click(object sender, EventArgs e) {
            OpenOsiris();
        }

        private void Menu_Window_Settings_Click(object sender, EventArgs e) {
            setPage.Show();
            setPage.BringToFront();
        }

        private void Menu_QC_Pan_Click(object sender, EventArgs e) {
            new QuickCommandEntry("setpan", "Enter pan pos value");
        }

        private void Menu_QC_Tilt_Click(object sender, EventArgs e) {
            new QuickCommandEntry("settilt", "Enter tilt pos value");
        }


    } // end of class MainForm
} // end of namespace SSLUtility2
