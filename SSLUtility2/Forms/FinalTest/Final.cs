using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SSLUtility2.Forms.FinalTest
{
    public partial class Final : Form
    {
        public Final() {
            InitializeComponent();
            tB_Name_Path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            tB_Name_PathFrom.Text = ConfigControl.appFolder;
        }

        private void b_Final_Next_Click(object sender, EventArgs e) {
            string pathTo = tB_Name_Path.Text;
            if (rtb_Name_NameList.Lines.Length > 1) {
                pathTo += @"\FinalTestMode";
                MainForm.CheckCreateFile(null, pathTo);
            }

            foreach (string line in rtb_Name_NameList.Lines) {
                if (line != "") {
                    pathTo += @"\" + line;
                    MainForm.CheckCreateFile(null, pathTo);
                    CopyFiles(pathTo, Directory.GetFiles(tB_Name_PathFrom.Text));
                    CopyDirs(pathTo, Directory.GetDirectories(tB_Name_PathFrom.Text));
                }
            }

            string self = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            File.Copy(self, pathTo + @"\" + System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName);

        }

        void CopyFiles(string pathTo, string[] copyDir) {
            string curFile = string.Empty;
            string newLocation = string.Empty;
            try {
                pathTo += @"\";
                string tempFile = pathTo + @"\CopiedFile";

                foreach (string file in copyDir) {
                    string name = file.Substring(file.LastIndexOf("\\") + 1);
                    curFile = file;
                    newLocation = pathTo + name;

                    if (!File.Exists(pathTo)) {
                        if (name == ConfigControl.config) {
                            ConfigControl.portableMode = true;
                            ConfigControl.CreateConfig(pathTo + @"\" + ConfigControl.config);
                            ConfigControl.portableMode = false;
                        } else {
                            File.Copy(file, tempFile, true);
                            File.Move(tempFile, pathTo + @"\" + name);
                        }
                    }
                }
            }catch(Exception e) {
                MainForm.ShowError("Couldn't copy individual file to new directory!\nShow more info?", "Copy failed!", "File: " + curFile + "\nfailed to copy to:\n" + newLocation + "\n\nError: " + e.ToString());
            }
        }

        void CopyDirs(string pathTo, string[] copyDir) {
            string curDir = string.Empty;
            string newLocation = string.Empty;
            try {
                foreach (string subDir in copyDir) {
                    string name = subDir.Substring(subDir.LastIndexOf("\\"));
                    curDir = subDir;
                    newLocation = pathTo + name;

                    DirectoryInfo newDir = Directory.CreateDirectory(pathTo + name);

                    if (Directory.GetFiles(subDir).Length > 0) {
                        MessageBox.Show("Copying files from: " + pathTo + name);
                        CopyFiles(newDir.FullName, Directory.GetFiles(subDir));
                    }
                    if (Directory.GetDirectories(subDir).Length > 0) {
                        MessageBox.Show("Copying directory from: " + newDir.FullName);
                        CopyDirs(newDir.FullName, Directory.GetDirectories(subDir));
                    }
                }
            } catch (Exception e) {
                MainForm.ShowError("Couldn't copy directory to new location!\nShow more info?", "Copy failed!", "Directory: " + curDir + "\nfailed to copy to:\n" + newLocation + "\n\nError: " + e.ToString());
            }
        }

        private void b_Final_Browse_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Name_Path);
        }

        private void b_Name_BrowseFrom_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Name_PathFrom);
        }
    }
}
