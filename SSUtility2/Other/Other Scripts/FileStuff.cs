using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SSUtility2 {
    public class FileStuff {
        
        static int configFinderCurPoint = 0;

        public static async Task<bool> FileWork() {
            try {
                if (!CheckForNewDir())
                    CheckForMultipleConfigs();

                ConfigControl.SetToDefaults();

                CreateConfigFiles();

                await ConfigControl.SearchForVarsAsync(ConfigControl.appFolder + ConfigControl.config);
                MainForm.m.custom.HideButtons();

                if (ConfigControl.portableMode.boolVal)
                    MainForm.m.Menu_Final.Dispose();

                if (AppDomain.CurrentDomain.FriendlyName.ToLower().Contains("lite"))
                    return true;

                return false;
            } catch (Exception e) {
                Tools.ShowPopup("File work error occurred!\nShow more?", "Error Occurred!", e.ToString());
                return false;
            }
        }

        static string CheckFileForDir() {
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

        static bool CheckForNewDir() {
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

            return noFile;
        }

        public static void ChooseNewDirectory() {
            bool choose = Tools.ShowPopup("Would you like to change your default directory?\nCurrent app folder: " + ConfigControl.appFolder, "Choose your directory", null, false);
            if (choose) {
                DirectoryChooser dc = new DirectoryChooser();
                dc.ShowDialog();
            }
            Tools.ResetFile(ConfigControl.dirLocationFile);
            File.AppendAllText(ConfigControl.dirLocationFile, ConfigControl.appFolder);
        }


        static void CheckForMultipleConfigs() {
            try {
                configFinderCurPoint = 0;

                string curDir = Directory.GetCurrentDirectory();
                List<string> configsCurDir = CheckFilesForConfig(curDir);
                List<string> configsNormalDir = CheckFilesForConfig(ConfigControl.appFolder);

                if (configsNormalDir.Count == 0 && configsCurDir.Count == 0 || (configsNormalDir.Count == 1 && configsCurDir.Count == 0)) {
                    //first time or deleted files or normal

                    return;
                } else if (configsNormalDir.Count == 0 && configsCurDir.Count == 1) {
                    //portable mode

                    string name = configsCurDir[0].Substring(configsCurDir[0].LastIndexOf(@"\") + 1);
                    ConfigControl.config = name;
                    ConfigControl.appFolder = (Directory.GetCurrentDirectory() + @"\");
                    ConfigControl.portableMode.UpdateValue("true");

                    return;
                }

                (string, string)[] configArray = new (string, string)[configsCurDir.Count + configsNormalDir.Count];

                configArray = UpdateConfigArray(configArray, configsCurDir);
                configArray = UpdateConfigArray(configArray, configsNormalDir);

                ChooseConfig chooser = new ChooseConfig(configArray);
                chooser.ShowDialog();
            } catch { }
        }

        static (string, string)[] UpdateConfigArray((string, string)[] arr, List<string> fields) {
            foreach (string s in fields) {
                string fileName = s.Substring(s.LastIndexOf(@"\") + 1);
                arr[configFinderCurPoint].Item1 = fileName;
                arr[configFinderCurPoint].Item2 = s;
                configFinderCurPoint++;
            }

            return arr;
        }

        static List<string> CheckFilesForConfig(string path) {
            string[] arr = Directory.GetFiles(path);
            List<string> configs = new List<string>();
            foreach (string f in arr) {
                string firstLine = File.ReadLines(f).First();
                if (firstLine.ToLower().Contains("ssutility") && firstLine.ToLower().Contains("config")) {
                    configs.Add(f);
                }
            }

            return configs;
        }

        public static void CreateConfigFiles() {
            Tools.CheckCreateFile(ConfigControl.config, ConfigControl.appFolder);
            Tools.CheckCreateFile(null, ConfigControl.savedFolder);
        }
    }
}
