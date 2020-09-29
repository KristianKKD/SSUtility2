using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class ConfigControl {

        //Defaults//
        public static string defScFolder = @"Screenshots\";
        public static string defVFolder = @"Videos\";
        public static string defSavedFolder = @"Saved\";

        public static string defVName = "Video";
        public static string defScName = "Screenshot";

        public static string defVRecQual = "70";
        public static string defVRecFPS = "30";

        public static bool defSubnetNot = false;
        public static bool defConfigNot = false;
        public static bool defAutoPlay = true;
        public static bool defAutomaticPaths = true;

        public static string config = "config.txt";
        public const string autoSave = "auto.txt";
        public static string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SSUtility\";
        //Defaults//

        //RuntimeVars//
        public static string scFolder;
        public static string vFolder;
        public static string savedFolder;
        public static string scFileName;
        public static string vFileName;
        public static string recQual;
        public static string recFPS;

        public static bool subnetNotif;
        public static bool configNotif;
        public static bool autoPlay;
        public static bool automaticPaths;
        //RuntimeVars//

        //SearchForVars//
        static string configPath = "";

        public const string varPrefix = "v"; //What the prefix of the actual value is (ScreenshotFolder:bin/obj/)

        public const string screenshotFolderVar = "ScreenshotFolder";
        public const string videoFolderVar = "VideoFolder";

        public const string videoFileNVar = "VideoFileName";
        public const string scFileNVar = "ScreenshotFileName";

        public const string recQualVar = "RecordingQuality";
        public const string recFPSVar = "RecordingFramerate";

        public const string subnetNotifVar = "SubnetNotificationHidden";
        public const string configNotifVar = "BadConfigNotificationHidden";
        public const string autoPlayVar = "AutoPlayLaunch";
        public const string automaticPathsVar = "AutomaticPaths";
        //SearchForVars//

        public static List<ConfigVar> stringVarList {
            get;
            set;
        }

        public static async Task SetToDefaults() {
            defScFolder = appFolder + defScFolder;
            defVFolder = appFolder + defVFolder;
            defSavedFolder = appFolder + defSavedFolder;

            scFolder = defScFolder;
            vFolder = defVFolder;
            savedFolder = defSavedFolder;

            scFileName = defScName;
            vFileName = defVName;

            recQual = defVRecQual;
            recFPS = defVRecFPS;

            subnetNotif = defSubnetNot;
            configNotif = defConfigNot;
            autoPlay = defAutoPlay;
            automaticPaths = defAutomaticPaths;
        }

        public static void CreateConfig(string path) {
            ResetFile(path);
            configPath = path;

            File.AppendAllText(path, varPrefix + screenshotFolderVar + ":" + scFolder + "\n");
            File.AppendAllText(path, varPrefix + videoFolderVar + ":" + vFolder + "\n");

            File.AppendAllText(path, varPrefix + scFileNVar + ":" + scFileName + "\n");
            File.AppendAllText(path, varPrefix + videoFileNVar + ":" + vFileName + "\n");

            File.AppendAllText(path, varPrefix + recQualVar + ":" + recQual + "\n");
            File.AppendAllText(path, varPrefix + recFPSVar + ":" + recFPS + "\n");

            File.AppendAllText(path, varPrefix + subnetNotifVar + ":" + subnetNotif + "\n");
            File.AppendAllText(path, varPrefix + configNotifVar + ":" + configNotif + "\n");
            File.AppendAllText(path, varPrefix + autoPlayVar + ":" + autoPlay + "\n");
            File.AppendAllText(path, varPrefix + automaticPathsVar + ":" + automaticPaths + "\n");
        }

        public static bool CheckVal(string v) {
            if (v.ToLower() == "true") {
                return true;
            } else {
                return false;
            }
        }

        public static void ResetFile(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
            var newFile = File.Create(path);
            newFile.Close();
        }

        public static void Append(string text) {
            if (configPath == "") {
                configPath = appFolder + config;
            }
            File.AppendAllText(configPath, varPrefix + text);
        }

        public static async Task<bool> CheckIfExists(TextBox tb, Label linkedLabel) {
            if (!Directory.Exists(tb.Text)) {
                linkedLabel.Text = "❌";
                return false;
            }
            linkedLabel.Text = "✓";
            return true;
        }

        public async static Task SearchForVarsAsync(string path) {
            string[] lines = File.ReadAllLines(path);

            List<ConfigVar> varFound = new List<ConfigVar>();
            foreach (string line in lines) {
                if (line.StartsWith(varPrefix)) {
                    varFound.Add(CreateConfigVar(line));
                }
            }
           
            stringVarList = varFound;
        }

        static ConfigVar CreateConfigVar(string l) {
            int nameMarker = l.IndexOf(":") + 1;
            string name = l.Substring(varPrefix.Length, nameMarker - varPrefix.Length - 1);
            string text = l.Substring(nameMarker);

            return new ConfigVar(name, text);
        }

    }

    class ConfigVar {

        public string name;
        public string value;

        public ConfigVar(string n, string t) {
            name = n;
            value = t;
        }

    }

}
