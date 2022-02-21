using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public static class Tools {

        public static IEnumerable<Control> GetAll(Control control) {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }

        public static IEnumerable<Control> GetAllType(Control control, Type type) {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllType(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static void SetFeatureToAllControls(Control.ControlCollection cc) {
            if (cc != null) {
                foreach (Control control in cc) {
                    if (control != MainForm.m) {
                        control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    }
                    SetFeatureToAllControls(control.Controls);
                }
            }
        }

        private static void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter) {
                e.IsInputKey = true;
            }
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

        public static uint MakeAdr() {
            int id = 0;

            if (MainForm.m.setPage.overridePreset || MainForm.m.lite)
                id = ConfigControl.pelcoOverrideID.intVal;
            else
                id = MainForm.m.mainPlayer.settings.GetPelcoID();

            if (id == -1)
                id = 0;

            return Convert.ToUInt32(id);
        }

        public static uint GetCheckSum(byte[] code, uint adr) {
            uint checksum = 0;
            for (int i = 0; i < code.Length; i++) {
                checksum += code[i];
            }
            checksum += adr;

            checksum = checksum % 256;

            return checksum;
        }

        public static string ValidateResponse(string msg) {
            try {
                if (msg == null)
                    return null;

                msg = RemoveWhitespace(msg);

                if (msg.Length < 14)
                    return null;

                int startPos = msg.IndexOf("FF");
                if (startPos == -1) {
                    return null;
                } else if (startPos > 0) { //restructures incoming responses
                    try {
                        string newMsg = "";
                        foreach (char c in msg.Substring(startPos, 14 - startPos))
                            newMsg += c;

                        foreach (char c in msg.Substring(0, startPos))
                            newMsg += c;

                        if (CheckMessage(newMsg)) {
                            newMsg = ReformatMessage(newMsg);
                            //Console.WriteLine("new msg(" + newMsg.Length.ToString() + ")= " + newMsg + " old msg(" + msg.Length.ToString() + ")= " + ReformatMessage(msg));

                            return newMsg;
                        }
                    } catch (Exception e) {
                        Console.WriteLine("NEW MSG\n" + e.ToString());
                        return null;
                    }
                }

                if (!CheckMessage(msg)) {
                    return null;
                } else {
                    Console.WriteLine("GOOD MESSAGE: " + msg);
                }

                return ReformatMessage(msg);
            }catch(Exception e) {
                Console.WriteLine("VALIDATE(" + msg+")\n" + e.ToString());
                return null;
            }
        }

        static string ReformatMessage(string msg) {
            string newMsg = "";
            for (int i = 0; i < 7; i++) {
                newMsg += msg.Substring(i * 2, 2) + " ";
            }
            return newMsg;
        }

        static bool CheckMessage(string msg) {
            try {
                bool isGoodNewMsg = false;
                byte[] tryConvert = ConvertMsgToByte(msg);
                if (tryConvert != null) {
                    byte[] checksumCheck = new byte[4] { tryConvert[2], tryConvert[3], tryConvert[4], tryConvert[5] };
                    if ((byte)GetCheckSum(checksumCheck, Convert.ToUInt32(tryConvert[1])) == Convert.ToUInt32(tryConvert[6])
                        && Convert.ToUInt32(tryConvert[6]) != 0) {
                        isGoodNewMsg = true;
                    }
                }

                //if (!isGoodNewMsg)
                //    Console.WriteLine(msg + " BBBB\nChecksum should be:" + GetCheckSum(tryConvert, 0).ToString() + " instead got: " + tryConvert[6].ToString());

                return isGoodNewMsg;
            } catch (Exception e){
                Console.WriteLine("CHECK MESSAGE\n" + e.ToString());
                return false;
            }
        }

        public static byte[] ConvertMsgToByte(string msg) {
            try {
                msg = RemoveWhitespace(msg);
                if (msg.Length != 14)
                    return null;

                byte[] fullCommand = new byte[7];

                for (int i = 0; i < 7; i++) {
                    uint b = uint.Parse(msg.Substring(i*2, 2), System.Globalization.NumberStyles.HexNumber);
                    fullCommand[i] = (byte)b;
                }

                return fullCommand;
            } catch (Exception e) {
                Console.WriteLine("FAILED TO CONVERT\n" + e.ToString());
                return null; 
            }
        }

        public static string RemoveWhitespace(this string input) {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string ReadCommand(byte[] command, bool hide = true) {
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

        public static int HexToInt(string hex) {
            return Convert.ToInt32(hex, 16);
        }

        public static void SaveSnap(Detached player, bool showConfirmation = true, string customPath = "") {
            string fullImagePath = GivePath(PathType.Snapshot, player, customPath);

            Screenshot(player, fullImagePath);
            FinalScreenshot(fullImagePath, showConfirmation);
        }

        private static void Screenshot(Detached d, string path) {
            try {
                Panel player = d.p_Player;

                Image bmp = new Bitmap(player.Width, player.Height);
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.CopyFromScreen(player.RectangleToScreen(player.ClientRectangle).Location, Point.Empty, player.Size);

                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            } catch (Exception e) {
                MessageBox.Show("SCREENSHOT\n" + e.ToString());
            }
        }

        public static void FinalScreenshot(string fullImagePath, bool showConfirmation = true) {
            if (MainForm.m.finalMode) {
                SaveFileDialog fdg = SaveFile(ConfigControl.scFileName.stringVal, ".jpg", MainForm.m.finalDest);
                DialogResult result = fdg.ShowDialog();
                if (result == DialogResult.OK) {
                    CopySingleFile(fdg.FileName, fullImagePath);
                    MainForm.m.col.AddToSavedLocations(fdg.FileName);
                }

                if (showConfirmation)
                    MessageBox.Show("Image saved : " + fullImagePath +
                        "\nFinal saved: " + fdg.FileName);
            } else {
                if(showConfirmation)
                    MessageBox.Show("Image saved : " + fullImagePath);
            }
        }

        public static string PathNoOverwrite(string originalPath) {
            try {
                string path = originalPath.Substring(0, originalPath.LastIndexOf(@"\") + 1);
                string name = originalPath.Substring(path.Length);
                string extension = name.Substring(name.IndexOf("."));
                name = name.Substring(0, name.Length - extension.Length);

                string fullPath = path + name + extension;

                int numAdd = 0;

                while (File.Exists(fullPath))
                    fullPath = path + name + "(" + (++numAdd).ToString() + ")" + extension;

                return fullPath;
            } catch (Exception e) {
                MessageBox.Show("PATHNOOVERWRITE\n" + e.ToString());
                return "";
            }
        }
 
        
        public static async Task<bool> CheckFinishedTypingPath(TextBox tb, Label linkLabel) {
            if (tb.Text.Length < 1) {
                tb.Text = ConfigControl.appFolder;
                return false;
            }
            if (Tools.CheckIfExists(tb, linkLabel)) {
                return true;
            }
            return false;
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

        public enum PathType {
            Snapshot,
            Video,
            Panoramic,
            Folder,
        }

        public static string GivePath(PathType pt, Detached player, string customPath = "") {
            string defaultName, folder, name, full, folderType, extension;

            try {
                switch (pt) {
                    case PathType.Snapshot:
                        defaultName = ConfigControl.scFileName.stringVal;
                        folder = ConfigControl.scFolder.stringVal;
                        folderType = "Snapshots";
                        extension = ".jpg";
                        break;
                    case PathType.Video:
                        defaultName = ConfigControl.vFileName.stringVal;
                        folder = ConfigControl.vFolder.stringVal;
                        folderType = "Recordings";
                        extension = ".mp4";
                        break;
                    case PathType.Panoramic:
                        defaultName = "Panoramic";
                        folder = ConfigControl.scFolder.stringVal;
                        folderType = "Panoramic";
                        extension = ".jpg";
                        break;
                    default: //folder type
                        defaultName = "";
                        folder = "";
                        folderType = "";
                        extension = "";
                        break;
                }

                if (ConfigControl.automaticPaths.boolVal && customPath == "") {
                    string playerName = "";

                    if (player != null)
                        playerName = player.settings.GetPresetName();
                    else
                        playerName = "SSUtility";

                    if (playerName != "" && playerName[playerName.Length - 1] != '\\')
                        playerName += @"\";
                    else if (playerName == "")
                        folderType = "";

                    folder = ConfigControl.savedFolder + playerName + folderType + @"\";

                    string timeText = "";
                    if (pt != PathType.Folder)
                        timeText = GetTimeText();

                    name = timeText;

                    if (defaultName != "")
                        name = defaultName + " " + timeText;

                    full = folder + name + timeText + extension;
                } else {
                    if (pt != PathType.Folder && folder[folder.Length - 1] != '\\')
                        folder += @"\";
                    else if (customPath != "")
                        folder = customPath;

                    full = folder + defaultName + extension;
                }

                if (pt != PathType.Folder) {
                    if (customPath == "")
                        CheckCreateFile(null, folder);

                    full = PathNoOverwrite(full);
                }

                Console.WriteLine(full);
            }catch(Exception e) {
                Console.WriteLine("GIVEPATH\n" + e.ToString());
                full = "";
            }

            return full;
        }

        public static string GetTimeText() {
            return DateTime.Now.ToString().Replace("/", "-").Replace(":", ";"); ;
        }


        public static FFMPEGRecord ToggleRecord(Detached player, ToolStripMenuItem startRecord, ToolStripMenuItem stopRecord,
            bool showFinish = true, string customPath = "") {
            FFMPEGRecord.RecordType type = FFMPEGRecord.RecordType.SSUtility;

            FFMPEGRecord recorder;

            if (player != null) {
                type = FFMPEGRecord.RecordType.Player;
                recorder = player.recorder;
            } else {
                recorder = FFMPEGRecord.ssutilRecorder;
            }

            if (recorder == null) {
                recorder = new FFMPEGRecord(type, player, customPath);

                if (!recorder.recording)
                    recorder = null;
                else if (startRecord != null) { //global gives null
                    stopRecord.Text = "Stop Recording";
                    stopRecord.Visible = true;
                    startRecord.Visible = false;
                }
            } else {
                if (MainForm.m.finalMode) {
                    SaveFileDialog fdg = Tools.SaveFile("Recording", ".mp4", MainForm.m.finalDest);
                    DialogResult result = fdg.ShowDialog();
                    if (result == DialogResult.OK) {
                        Tools.CopySingleFile(fdg.FileName, recorder.outPath);
                        MainForm.m.col.AddToSavedLocations(fdg.FileName);
                    }

                    MessageBox.Show("Saved recording to: " + recorder.outPath +
                        "\nFinal saved: " + fdg.FileName);
                } else {
                    if (showFinish)
                        MessageBox.Show("Saved recording to: " + recorder.outPath);
                }

                FFMPEGRecord.StopRecording(recorder.p);
                recorder = null;

                if (startRecord != null) {
                    stopRecord.Visible = false;
                    startRecord.Visible = true;
                }
            }

            return recorder;
        }


        public static void CopySingleFile(string destination, string sourceFile, bool copyingDirectory = false) {
            string curFile = string.Empty;
            string newLocation = string.Empty;
            try {
                string name = sourceFile.Substring(sourceFile.LastIndexOf("\\") + 1);
                curFile = sourceFile;
                newLocation = destination + name;

                if (copyingDirectory) {
                    if(!destination.EndsWith(@"\"))
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
                    File.Copy(sourceFile, PathNoOverwrite(destination), true);
                }
            } catch (Exception e) {
                ShowPopup("Couldn't copy individual file to new directory!\nShow more info?",
                    "Copy failed!", "File: " + curFile + "\nfailed to copy to:\n" + newLocation +
                    "\n\nError: " + e.ToString());
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

        public static void CopyFiles(string destination, string[] sourceDir) {
            foreach (string file in sourceDir)
                CopySingleFile(destination, file, true);
        }

        public static void SaveTextFile(string[] lines, string name = null) {
            SaveFileDialog fdg = SaveFile(name, ".txt", ConfigControl.savedFolder);
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                ResetFile(fdg.FileName);
                File.AppendAllLines(fdg.FileName, lines);
            }
        }

        public static async Task ImportConfig(string name, bool dragdrop) {
            try {
                MainForm.m.finishedLoading = false;
                string configFile = ConfigControl.appFolder + ConfigControl.config;
                if (name != configFile) {
                    ResetFile(configFile);

                    string[] lines = File.ReadAllLines(name);
                    bool isValid = false;
                    foreach (string line in lines) {
                        string val = line.ToLower();
                        if (val.Contains("ssutility2.0") && val.Contains("config")) {
                            isValid = true;
                            break;
                        }
                    }

                    if (!isValid) {
                        MessageBox.Show("Text file is not a config file!");
                        MainForm.m.finishedLoading = true;
                        return;
                    } else if (dragdrop && !ShowPopup("Config file detected!\n(" + name + ")\nImport new settings, replacing current config?", "New Config Detected!", "", false)) {
                        MainForm.m.finishedLoading = true;
                        return;
                    }

                    foreach (string line in lines)
                        File.AppendAllText(configFile, line + "\n");

                    RTSPPresets.Reload(true);
                    ConfigControl.SetToDefaults();
                    await ConfigControl.SearchForVarsAsync(ConfigControl.appFolder + ConfigControl.config);
                    MainForm.m.setPage.LoadSettings();
                    MessageBox.Show("Updated config file!\n(" + configFile + ")");
                    MainForm.m.AttachPlayers();
                } else {
                    if (name == configFile)
                        MessageBox.Show("Please don't try to replace the config file with itself!");
                }
            } catch (Exception e) {
                ShowPopup("Failed to import config!\nShow more?", "Error Occurred!", e.ToString());
            }

            MainForm.m.finishedLoading = true;
        }

        public static void ResetFile(string path) {
            if (File.Exists(path))
                File.Delete(path);

            var newFile = File.Create(path);
            newFile.Close();
        }

        public static void DeleteDirectory(string oldFolderPath) {
            string[] files = Directory.GetFiles(oldFolderPath);
            string[] dirs = Directory.GetDirectories(oldFolderPath);

            foreach (string file in files) {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
                DeleteDirectory(dir);

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
                ShowPopup("Couldn't copy directory to new location!\nShow more info?",
                    "Copy failed!", "Directory: " + curDir + "\nfailed to copy to:\n" + newLocation +
                    "\n\nError: " + e.ToString());
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

        public static bool CheckIfExists(TextBox tb, Label linkedLabel) {
            bool exists;
            string lText;
            exists = Directory.Exists(tb.Text);

            if (linkedLabel != null) {
                if (exists) {
                    lText = "✓";
                } else {
                    lText = "❌";
                }
                linkedLabel.Text = lText;
            }
            return exists;
        }

        public static List<int> GetValidRows(DataGridView dgv, int startingFrom) {
            List<int> validRows = new List<int>();
            for (int i = startingFrom; i < dgv.Rows.Count; i++) {
                DataGridViewRow row = dgv.Rows[i];

                if (row.IsNewRow)
                    continue;

                if (!RowIsNull(row))
                    validRows.Add(i);
            }


            return validRows;
        }

        public static bool RowIsNull(DataGridViewRow row) {
            string val = GetRowCellVals(row);

            string checkForNull = val.Replace(";", "");
            checkForNull = checkForNull.Replace(" ", "");

            return (checkForNull.Length == 0);
        }

        public static string GetRowCellVals(DataGridViewRow row) {
            string val = "";

            for (int i = 0; i < row.Cells.Count; i++) {
                string cellVal = row.Cells[i].Value + ";";
                if (cellVal == ";")
                    cellVal = " ;";

                val += cellVal;
            }

            return val;
        }

        public static string[] GetRowValueArray(DataGridView dgv, string line) {
            line = line.Trim();
            string[] sets = new string[dgv.Columns.Count];

            string val = "";
            int setsPos = 0;
            foreach (char c in line.ToCharArray()) {
                if (c.ToString() == ";") {
                    sets[setsPos] = val;
                    val = "";
                    setsPos++;
                } else
                    val += c.ToString();
            }

            return sets;
        }

        public static bool IsMainActive() {
            try {
                Control currentControl = GetFocusedControl();

                if (currentControl == null)
                    return false;

                MainForm m = MainForm.m;

                if ((currentControl == m.mainPlayer || currentControl == m.MenuBar || currentControl == m))
                    return true;

                foreach (Button b in MainForm.controlPanel)
                    if (currentControl == b)
                        return true;

            } catch { }
            return false;
        }

        public static Control GetFocusedControl() {
            try {
                IntPtr focusedHandle = Program.GetFocus();
                if (focusedHandle != IntPtr.Zero) {
                    Control c = Control.FromHandle(focusedHandle);
                    if (c == null)
                        return null;

                    if (c.GetType() == typeof(Form) || c.GetType() == typeof(PictureBox) || c.GetType() == typeof(Menu) || c.GetType() == typeof(MainForm))
                        return c;
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public static string ShowScriptCommandInfo(ScriptCommand sc, bool show) {
            string fullMsg = "";

            if (sc.names != null)
                foreach (string s in sc.names)
                    fullMsg += s + ", ";

            if (fullMsg != "")
                fullMsg = fullMsg.Substring(0, fullMsg.Length - 2); //removes last comma+whitespace

            fullMsg += "\nVALUES(" + sc.valueCount.ToString() + ")   CONTENT:";

            if (sc.codeContent != null)
                fullMsg += ReadCommand(sc.codeContent);
            else
                fullMsg += "NULL";

            if (show)
                MessageBox.Show(fullMsg);

            return fullMsg;
        }

        public static string GetPortValueFromEncoder(ComboBox cb) {
            string val = cb.Text.Trim();
            string result = "";

            if (val == "Encoder")
                result = "6791";
            else if (val == "MOXA nPort")
                result = "4001";

            if (result == "")
                result = val;

            return result;
        }
        public static int IsValidVal(object sender, int min, int max) {
            TextBox tb = (TextBox)sender;
            if (float.TryParse(tb.Text, out float val)) {
                if (val < min)
                    val = min;
                else if (val > max)
                    val = max;

                val = (float)Math.Truncate(val);

                return (int)val;
            }

            return -1;
        }

    }
}
