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
        
        public const string version = "v2.2.1.2";

        private bool lite = false;
        private bool isOriginal = false;
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
                mainCp.track_PTZ_PTSpeed,

                mainPlayer.settings.cB_PlayerD_Type,
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
            CommandQueue.Init();

            setPage.PopulateSettingText();
            SetFeatureToAllControls(m.Controls);
            b_Open.BringToFront();
            AutoConnect();
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

        void AttachInfoPanel() {
            Panel p = new Panel();
            InfoPanel i = new InfoPanel();
            
            p.Size = new Size(i.Width, i.Height - 35);
            p.Location = new Point(m.Size.Width - i.Width, 0);

            var c = GetAllType(i, typeof(Label));
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

            var c = GetAllType(custom, typeof(Button));
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
            mainPlayer.myPanel.Location = new Point(0,0);
            mainPlayer.myPanel.Size = new Size(m.Size.Width - 14, m.Size.Height - 62);
            mainPlayer.VLCPlayer_D.Refresh();
        }

        public void ShowControlPanel() {
            mainCp.myPanel.Show();
            mainCp.myPanel.Visible = true;
            mainPlayer.myPanel.Location = new Point(mainCp.Location.X + mainCp.Size.Width - 15, mainCp.Location.Y);
            mainPlayer.myPanel.Size = new Size(m.Size.Width - mainCp.Size.Width, m.Size.Height - 62);
        }

        Detached AttachPlayer() {
            Detached d = DetachVid(false, new VideoSettings()).Result;
            Panel p = new Panel();
            d.myPanel = p;

            var c = GetAllType(d, typeof(SizeablePanel.SizeablePanel));
            p.Controls.AddRange(c.ToArray());
            var c2 = GetAllType(d, typeof(AxAXVLC.AxVLCPlugin2));
            p.Controls.AddRange(c2.ToArray());
            

            p.Size = new Size(m.Size.Width - mainCp.Size.Width, m.Size.Height - 62);
            p.Location = new Point(mainCp.Location.X + mainCp.Size.Width - 15, mainCp.Location.Y);
            p.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            
            p_Control.Controls.Add(p);

            p.BringToFront();
            d.sP_Player.Location = new Point(p_Control.Width - d.sP_Player.Width - 400, d.sP_Player.Height - 100);
            d.sP_Player.BringToFront();

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


        public async Task<Detached> DetachVid(bool show, VideoSettings set) {
            Detached dv = new Detached();
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
                if(mainPlayer.isPlaying)
                    dv.StartPlaying(false);
            }
            SetFeatureToAllControls(dv.Controls);
            return dv;
        }

        public void OpenPelco() {
            pd.tB_IPCon_Adr.Text = ConfigControl.savedIP.stringVal;
            pd.tB_IPCon_Port.Text = ConfigControl.savedPort.stringVal;
            pd.cB_IPCon_Selected.Text = ConfigControl.savedCamera.stringVal;
            pd.Show();
            pd.BringToFront();
        }

        ControlPanel SpawnControlPanel(Panel p, bool makeLite = true) {
            Panel pan = new Panel();
            ControlPanel cp = new ControlPanel();
            cp.myPanel = pan;

            SetFeatureToAllControls(cp.Controls);

            pan.Size = new Size(cp.Size.Width, cp.Size.Height - 30);
            pan.Location = new Point(pan.Location.X, pan.Location.Y);
            p.Controls.Add(pan);

            AddControls(pan, cp);

            return cp;
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

        public static bool ShowPopup(string message, string caption, string error, bool isErrorType = true) {
            bool res = false;
            DialogResult d = MessageBox.Show(message, caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (d == DialogResult.Yes) {
                res = true;
                if (isErrorType) {
                    MessageBox.Show(error, caption, MessageBoxButtons.OK);
                }
            }
            return res;
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
                comboBox = MainForm.m.setPage.cB_ipCon_Selected;
            }
            if (comboBox.Text.Contains("Daylight")) {
                return 1;
            } else if (comboBox.Text.Contains("Thermal")) {
                return 2;
            } else {
                return uint.Parse(comboBox.Text);
            }
        }

        public string ReadCommand(byte[] command, bool hide = true) {
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
                isPlaying = true;

                Recorder rec = Record(fullVideoPath, player.VLCPlayer_D);

                return (isPlaying, rec);
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
            string adr = GetPlayerAdrOrName(detachedPlayer.settings);

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

        public static string GetPlayerAdrOrName(VideoSettings settings) {
            try {
                string nameText = settings.tB_PlayerD_Name.Text;
                string adrText = settings.tB_PlayerD_SimpleAdr.Text;
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
            if (nameArray.Length == 0) {
                return false;
            }
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

        bool closing = false;
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            closing = true;
            AsyncCamCom.Disconnect(true);
            if (!lite) {
                AutoSave.SaveAuto(ConfigControl.appFolder + ConfigControl.autoSave);
            }
        }

        private void Menu_Window_Detached_Click(object sender, EventArgs e) {
            DetachVid(true, mainPlayer.settings);
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
            if (mainPlayer.thermalMode) {
                mainPlayer.thermalMode = false;
                ConfigControl.savedCamera.UpdateValue("Daylight");
            } else {
                mainPlayer.thermalMode = true;
                ConfigControl.savedCamera.UpdateValue("Thermal");
            }

            mainPlayer.UpdateMode();
            setPage.cB_ipCon_Selected.Text = ConfigControl.savedCamera.stringVal;
            mainPlayer.settings.cB_PlayerD_Type.Text = ConfigControl.savedCamera.stringVal;

            mainPlayer.Swap();
        }

        private void Menu_Video_EnableSecondary_Click(object sender, EventArgs e) {
            Menu_Video_EnableSecondary.Visible = false;
            mainPlayer.EnableSecond();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e) {
            mainPlayer.VLCPlayer_D.Refresh();
        }

    } // end of class MainForm
} // end of namespace SSLUtility2
