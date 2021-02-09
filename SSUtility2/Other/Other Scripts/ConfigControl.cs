using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    class ConfigControl {

        public static string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SSUtility\";
        public const string config = "config.txt";
        public const string autoSave = "auto.txt";

        public static string savedFolder = appFolder + @"Saved\";

        public static string dirCheck = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SSUtility\";
        public static string dirLocationFile = dirCheck + "location.txt";

        private const string varPrefix = "v"; //What the prefix of the actual value is ([varPrefix]ScreenshotFolder:bin/obj/)
        
        public static ConfigSetting scFolder = new ConfigSetting(savedFolder, "SnapshotFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting vFolder = new ConfigSetting(savedFolder, "VideoFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting vFileName = new ConfigSetting("Video", "VideoFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting scFileName = new ConfigSetting("Snapshot", "SnapshotFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting screencapFileName = new ConfigSetting("Recording", "ScreenRecordingFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting recQual = new ConfigSetting("70", "RecordingQuality", ConfigSetting.VarType.integer);
        public static ConfigSetting recFPS = new ConfigSetting("30", "RecordingFramerate", ConfigSetting.VarType.integer);
        public static ConfigSetting updateMs = new ConfigSetting("500", "UpdateStatsTimerMs", ConfigSetting.VarType.integer);
        public static ConfigSetting subnetNotif = new ConfigSetting("false", "SubnetNotificationHidden", ConfigSetting.VarType.boolean);
        public static ConfigSetting autoPlay = new ConfigSetting("true", "AutoPlayLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting automaticPaths = new ConfigSetting("true", "AutomaticPaths", ConfigSetting.VarType.boolean);
        public static ConfigSetting portableMode = new ConfigSetting("false", "PortableMode", ConfigSetting.VarType.boolean);
        public static ConfigSetting finalSource = new ConfigSetting(@"\\192.168.1.118\netdrive\ProductionTesting\DEFAULT FILES", "FinalModeSourceFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting finalDestination = new ConfigSetting(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FinalModeDestinationFolder", ConfigSetting.VarType.strings);


        public static ConfigSetting[] configArray = new ConfigSetting[] { //make sure to add any new vars to here if they should be saved
            scFolder,
            vFolder,
            vFileName,
            scFileName,
            recQual,
            recFPS,
            updateMs,
            subnetNotif,
            autoPlay,
            automaticPaths,
            portableMode,
            finalSource,
            finalDestination,
        };


        public static List<ConfigVar> stringVarList {
            get;
            set;
        }

        public static async Task SetToDefaults() {
            savedFolder = appFolder + @"Saved\";
            scFolder.ChangeDefault(savedFolder);
            vFolder.ChangeDefault(savedFolder);

            foreach (ConfigSetting setting in configArray) {
                setting.UpdateValue(setting.defaultVal);
            }
        }

        public static void CreateConfig(string path) {
            ResetFile(path);

            foreach (ConfigSetting setting in configArray) {
                if (!portableMode.boolVal && (setting.settingName == finalSource.settingName || setting.settingName == finalDestination.settingName)) {
                    continue;
                }

                ConfigLine(path, setting.settingName, setting.stringVal);
            }


            if (MainForm.m.finalMode) {
                MainForm.CopySingleFile(MainForm.m.finalDest + @"\SSUtility2\" + config, path);
            }
            if (MainForm.m.playerL.myInfoRef != null) {
                MainForm.m.playerL.myInfoRef.UpdateTickInterval();
            }
        }

        static void ConfigLine(string path, string variable, string value) {
            File.AppendAllText(path, varPrefix + variable + ":" + value + "\n");
        }

        public static async Task FindVars() {
            foreach (ConfigVar v in stringVarList) {
                foreach (ConfigSetting setting in configArray) {
                    if (v.name == setting.settingName) {
                        setting.UpdateValue(v.value);
                    }
                }
            }
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


    class ConfigSetting {

        public string defaultVal;
        public string settingName;

        public string stringVal;
        public bool boolVal;
        public int intVal;

        public enum VarType {
            strings,
            boolean,
            integer,
        }
        
        public VarType myType;

        public ConfigSetting(string defVal, string varName, VarType type) {
            defaultVal = defVal;
            settingName = varName;
            myType = type;
            stringVal = defVal;

            switch (type) {
                case VarType.boolean:
                    boolVal = ConfigControl.CheckVal(defVal);
                    break;
                case VarType.integer:
                    intVal = int.Parse(defVal);
                    break;
            }
        }

        public void UpdateValue(string val) {
            switch (myType) {
                case VarType.boolean:
                    boolVal = ConfigControl.CheckVal(val);
                    break;
                case VarType.integer:
                    intVal = int.Parse(val);
                    break;
            }
            stringVal = val;
        }

        public void ChangeDefault(string val) {
            defaultVal = val;
        }

    }
}
