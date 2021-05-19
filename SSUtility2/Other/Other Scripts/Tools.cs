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
            string val = MainForm.m.mainPlayer.settings.cB_PlayerD_CamType.Text;
            string mainCamVal = ConfigControl.mainPlayerCamType.stringVal;

            if (val.Contains("Daylight") && !MainForm.m.lite)
                return 1;
            else if (val.Contains("Thermal") && !MainForm.m.lite)
                return 2;
            else {
                if (mainCamVal.Contains("Daylight"))
                    return 1;
                else if (mainCamVal.Contains("Thermal"))
                    return 2;
                else if (int.TryParse(mainCamVal, out int dontUse))
                    return uint.Parse(mainCamVal);
                else
                    return 1;
            }
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
                } else if (startPos > 0) { //restructure
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
                if (msg.Length != 14) {
                    return null;
                }

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

        public static void SaveSnap(Detached player) {
            string fullImagePath = GivePath(ConfigControl.scFolder.stringVal,
                ConfigControl.scFileName.stringVal, player.settings, "Snapshots", ".jpg");

            Screenshot(player, fullImagePath);

            if (MainForm.m.finalMode) {
                SaveFileDialog fdg = SaveFile(ConfigControl.scFileName.stringVal, ".jpg", MainForm.m.finalDest);
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

        private static Image Screenshot(Detached d, string path) {
            try {
                Panel player = d.p_Player;

                Image bmp = new Bitmap(player.Width, player.Height);
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.CopyFromScreen(player.RectangleToScreen(player.ClientRectangle).Location, Point.Empty, player.Size);

                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                return bmp;
            } catch (Exception e) {
                MessageBox.Show("SCREENSHOT\n" + e.ToString());
                return null;
            }
        }

        public static string NameNoOverwrite(string originalPath) {
            string path = originalPath.Substring(0, originalPath.LastIndexOf(@"\") + 1);
            string name = originalPath.Substring(path.Length);
            string extension = name.Substring(name.IndexOf("."));
            name = name.Substring(0, name.Length - extension.Length);
            string fullPath = path + name + extension;

            int numAdd = 0;

            while (File.Exists(fullPath)) {
                fullPath = path + name + "(" + (++numAdd).ToString() + ")" + extension;
            }

            return fullPath;
        }

        public static async Task<bool> CheckFinishedTypingPath(TextBox tb, Label linkLabel) {
            if (tb.Text.Length < 1) {
                tb.Text = ConfigControl.appFolder;
                return false;
            }
            if (ConfigControl.CheckIfExists(tb, linkLabel)) {
                return true;
            }
            return false;
        }

        public static Recorder Record(string path, Panel player) {
            Recorder rec = new Recorder(new Record(path, ConfigControl.recFPS.intVal,
                    SharpAvi.KnownFourCCs.Codecs.MotionJpeg, ConfigControl.recQual.intVal, player));
            return rec;
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

        public static string GivePath(string orgFolder, string orgName, VideoSettings player, string folderType, string extension) {
            string folder = orgFolder;
            //string fileName = orgName + (Directory.GetFiles(orgFolder).Length + 1).ToString();
            string fullTemp = NameNoOverwrite(orgFolder + orgName + extension);
            string name = fullTemp.Substring(fullTemp.LastIndexOf(@"\") + 1);

            string adr = GetPlayerAdrOrName(player);

            if (adr != "") {
                adr += @"\";
            } else {
                folderType = "";
            }

            if (ConfigControl.automaticPaths.boolVal) {
                folder = ConfigControl.savedFolder + adr + folderType;
                string timeText = DateTime.Now.ToString().Replace("/", "-").Replace(":", ";");
                name = orgName + " " + timeText;
            }

            CheckCreateFile(null, folder);

            string full = folder + @"\" + name;
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
            foreach (string file in sourceDir) {
                CopySingleFile(destination, file, true);
            }
        }

        public static void SaveTextFile(string[] lines, string name = null) {
            SaveFileDialog fdg = SaveFile(name, ".txt", ConfigControl.savedFolder);
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                ResetFile(fdg.FileName);
                File.AppendAllLines(fdg.FileName, lines);
            }
        }

        public static async Task CopyConfig(string name) {
            MainForm.m.finishedLoading = false;
            string configFile = ConfigControl.appFolder + ConfigControl.config;
            if (name != configFile) {
                ResetFile(configFile);

                string[] lines = File.ReadAllLines(name);
                bool isValid = false;
                foreach (string line in lines) {
                    string val = line.ToLower();
                    if (val.Contains("ssutility2.0") && val.Contains("config"))
                        isValid = true;
                }

                if (!isValid) {
                    MessageBox.Show("Text file is not a config file!");
                    return;
                }

                foreach (string line in lines) {
                    File.AppendAllText(configFile, line + "\n");
                }

                ConfigControl.SetToDefaults();
                await ConfigControl.SearchForVarsAsync(ConfigControl.appFolder + ConfigControl.config);
                ConfigControl.FindVars();
                MainForm.m.setPage.PopulateSettingText();
                MainForm.m.finishedLoading = true;
                MessageBox.Show("Updated config file!\n(" + configFile + ")");

                MainForm.m.mainPlayer.Play(false, false);
            } else {
                if (name == configFile)
                    MessageBox.Show("Please don't try to replace the config file with itself!\nIgnored request!");
            }
        }

        public static void ResetFile(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
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
                ShowPopup("Couldn't copy directory to new location!\nShow more info?",
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

    }
}
