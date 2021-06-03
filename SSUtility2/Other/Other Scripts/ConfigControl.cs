using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    class ConfigControl {

        public static string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SSUtility\";
        public static string config = "config.txt";

        public static string savedFolder = appFolder + @"Saved\";

        public static string dirCheck = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SSUtility\";
        public static string dirLocationFile = dirCheck + "location.txt";

        private const string varPrefix = "v"; //What the prefix of the actual value is ([varPrefix]ScreenshotFolder:bin/obj/)
        private const string playerPrefix = "p"; //Player config prefix
        private const string presetTypePrefix = "t"; //Preset config prefix
        private const string subPrefix = " "; //Preset config prefix
        
        public static ConfigSetting scFolder = new ConfigSetting(savedFolder, "SnapshotFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting vFolder = new ConfigSetting(savedFolder, "VideoFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting vFileName = new ConfigSetting("Video", "VideoFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting scFileName = new ConfigSetting("Snapshot", "SnapshotFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting screencapFileName = new ConfigSetting("Recording", "ScreenRecordingFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting recQual = new ConfigSetting("100", "RecordingQuality", ConfigSetting.VarType.integer);
        public static ConfigSetting recFPS = new ConfigSetting("30", "RecordingFramerate", ConfigSetting.VarType.integer);
        public static ConfigSetting autoPlay = new ConfigSetting("true", "AutoPlayLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting ignoreAddress = new ConfigSetting("false", "AddressInvalidHidden", ConfigSetting.VarType.boolean);
        public static ConfigSetting forceCamera = new ConfigSetting("false", "ForceCameraModeEnabled", ConfigSetting.VarType.boolean);
        public static ConfigSetting automaticPaths = new ConfigSetting("true", "AutomaticPaths", ConfigSetting.VarType.boolean);
        public static ConfigSetting portableMode = new ConfigSetting("true", "PortableMode", ConfigSetting.VarType.boolean);
        public static ConfigSetting finalSource = new ConfigSetting(@"\\192.168.1.118\netdrive\ProductionTesting\DEFAULT FILES", "FinalModeSourceFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting finalDestination = new ConfigSetting(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FinalModeDestinationFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting savedIP = new ConfigSetting("192.168.1.71", "SavedIP", ConfigSetting.VarType.strings);
        public static ConfigSetting savedPort = new ConfigSetting("6791", "SavedPort", ConfigSetting.VarType.strings);
        public static ConfigSetting cameraSpeedMultiplier = new ConfigSetting("100", "CameraSpeedMultiplier", ConfigSetting.VarType.integer);
        public static ConfigSetting forceType = new ConfigSetting("Strict", "ForcedCameraType", ConfigSetting.VarType.strings);
        public static ConfigSetting autoReconnect = new ConfigSetting("true", "AutoReconnect", ConfigSetting.VarType.boolean);
        public static ConfigSetting startupWidth = new ConfigSetting("1280", "StartupWidth", ConfigSetting.VarType.integer);
        public static ConfigSetting startupHeight = new ConfigSetting("720", "StartupHeight", ConfigSetting.VarType.integer);
        public static ConfigSetting maintainAspectRatio = new ConfigSetting("false", "MaintainAspectRatio", ConfigSetting.VarType.boolean);
        public static ConfigSetting playerCount = new ConfigSetting("1", "PlayerCount", ConfigSetting.VarType.integer);
        public static ConfigSetting pelcoID = new ConfigSetting("1", "SelectedPelcoID", ConfigSetting.VarType.integer);
        public static ConfigSetting selectedPresetName = new ConfigSetting("IONodes - Daylight", "SelectedPresetName", ConfigSetting.VarType.strings);

        public static ConfigSetting customButtonName1 = new ConfigSetting("1", "CustomButtonName1", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName2 = new ConfigSetting("2", "CustomButtonName2", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName3 = new ConfigSetting("3", "CustomButtonName3", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName4 = new ConfigSetting("4", "CustomButtonName4", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName5 = new ConfigSetting("5", "CustomButtonName5", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName6 = new ConfigSetting("6", "CustomButtonName6", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName7 = new ConfigSetting("7", "CustomButtonName7", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName8 = new ConfigSetting("8", "CustomButtonName8", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonName9 = new ConfigSetting("9", "CustomButtonName9", ConfigSetting.VarType.strings);

        public static ConfigSetting customButtonCommand1 = new ConfigSetting("Preset 1", "CustomButtonCommand1", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand2 = new ConfigSetting("Preset 2", "CustomButtonCommand2", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand3 = new ConfigSetting("Preset 3", "CustomButtonCommand3", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand4 = new ConfigSetting("Preset 4", "CustomButtonCommand4", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand5 = new ConfigSetting("Preset 5", "CustomButtonCommand5", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand6 = new ConfigSetting("Preset 6", "CustomButtonCommand6", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand7 = new ConfigSetting("Preset 7", "CustomButtonCommand7", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand8 = new ConfigSetting("Preset 8", "CustomButtonCommand8", ConfigSetting.VarType.strings);
        public static ConfigSetting customButtonCommand9 = new ConfigSetting("Preset 9", "CustomButtonCommand9", ConfigSetting.VarType.strings);

        public static ConfigSetting[] customButtonNamesArray = new ConfigSetting[] {
            customButtonName1,
            customButtonName2,
            customButtonName3,
            customButtonName4,
            customButtonName5,
            customButtonName6,
            customButtonName7,
            customButtonName8,
            customButtonName9,
        };

        public static ConfigSetting[] customButtonCommandsArray = new ConfigSetting[] {
            customButtonCommand1,
            customButtonCommand2,
            customButtonCommand3,
            customButtonCommand4,
            customButtonCommand5,
            customButtonCommand6,
            customButtonCommand7,
            customButtonCommand8,
            customButtonCommand9,
        };

        public static ConfigSetting[] configArray = new ConfigSetting[] { //make sure to add any new vars to here if they should be saved (and on settings page load)
            scFolder,
            vFolder,
            vFileName,
            scFileName,
            recQual,
            recFPS,
            autoPlay,
            ignoreAddress,
            forceCamera,
            automaticPaths,
            portableMode,
            finalSource,
            finalDestination,
            savedIP,
            savedPort,
            cameraSpeedMultiplier,
            forceType,
            autoReconnect,
            startupWidth,
            startupHeight,
            playerCount,
            maintainAspectRatio,
            pelcoID,
            selectedPresetName,

            customButtonName1,
            customButtonName2,
            customButtonName3,
            customButtonName4,
            customButtonName5,
            customButtonName6,
            customButtonName7,
            customButtonName8,
            customButtonName9,

            customButtonCommand1,
            customButtonCommand2,
            customButtonCommand3,
            customButtonCommand4,
            customButtonCommand5,
            customButtonCommand6,
            customButtonCommand7,
            customButtonCommand8,
            customButtonCommand9,
        };

        public static async Task SetToDefaults() {
            savedFolder = appFolder + @"Saved\";
            scFolder.ChangeDefault(savedFolder);
            vFolder.ChangeDefault(savedFolder);

            foreach (ConfigSetting setting in configArray) {
                setting.UpdateValue(setting.defaultVal);
            }
        }

        public static void CreateConfig(string path) {
            try {
                Tools.ResetFile(path);

                File.AppendAllText(path, "SSUtility2.0 " + MainForm.version + " Config\n\n");

                foreach (ConfigSetting setting in configArray) {
                    if (!portableMode.boolVal && (setting.settingName == finalSource.settingName || setting.settingName == finalDestination.settingName)) {
                        continue;
                    }

                    ConfigLine(path, setting.settingName, setting.stringVal, varPrefix);
                }

                for (int i = -1; i < MainForm.m.mainPlayer.attachedPlayers.Count; i++) {
                    Detached d = MainForm.m.mainPlayer;
                    if (i != -1)
                        d = MainForm.m.mainPlayer.attachedPlayers[i];

                    List<(string, string)> setList = d.settings.SaveToConfig();
                    for (int o = 0; o < setList.Count; o++) {
                        (string, string) s = setList[o];

                        if(o == 0)
                            ConfigLine(path, s.Item1, s.Item2, playerPrefix);
                        else
                            ConfigLine(path, s.Item1, s.Item2, subPrefix);
                    }
                }

                UserPresets up = MainForm.m.up;
                int rowCount = up.CountRows();
                ConfigLine(path, "Presets", rowCount.ToString(), presetTypePrefix);
                for (int i = 0; i < rowCount; i++)
                    File.AppendAllText(path, subPrefix + up.GetRowCellVals(up.dgv_Presets.Rows[i]) + "\n");

                if (MainForm.m.finalMode)
                    Tools.CopySingleFile(MainForm.m.finalDest + @"\SSUtility2\" + config, path);

            } catch (Exception e) {
                Tools.ShowPopup("Failed to write config!\nShow more?", "Critical Error Occurred!", e.ToString());
            }
        }

        static void ConfigLine(string path, string variable, string value, string prefix) {
            File.AppendAllText(path, prefix + variable + ":" + value + "\n");
        }

        public async static Task SearchForVarsAsync(string path) {
            try {
                string[] lines = File.ReadAllLines(path);

                List<ConfigVar> varFound = new List<ConfigVar>();
                List<List<ConfigVar>> playersFound = new List<List<ConfigVar>>();

                for (int i = 0; i < lines.Length; i++) {
                    string line = lines[i];

                    if (line.StartsWith(varPrefix))
                        varFound.Add(CreateConfigVar(line));
                    else {
                        int valPos = line.IndexOf(":") + 1;
                        if (valPos <= 0)
                            continue;

                        int val = 0;
                        if (!int.TryParse(line.Substring(valPos), out val))
                            continue;

                        if (line.StartsWith(playerPrefix)) {
                            List<ConfigVar> config = new List<ConfigVar>();

                            for (int o = 0; o < val; o++)
                                if (lines.Length - 1 >= i + o)
                                    config.Add(CreateConfigVar(lines[i + o]));

                            playersFound.Add(config);
                            i += val;
                        } else if (line.StartsWith(presetTypePrefix)) {
                            i++;

                            for (int o = 0; o < val; o++)
                                if (lines.Length - 1 >= i + o)
                                    MainForm.m.up.AddPreset(lines[i + o]);

                            i += val;
                        }
                    }

                }

                foreach (ConfigVar v in varFound) {
                    foreach (ConfigSetting setting in configArray) {
                        if (v.name == setting.settingName)
                            setting.UpdateValue(v.value);
                    }
                }

                if (playersFound.Count > 0) {
                    MainForm.m.mainPlayer.settings.LoadConfig(playersFound[0]);

                    for (int o = 1; o < playersFound.Count; o++)
                        MainForm.m.playerConfigList.Add(playersFound[o]);
                }
            } catch (Exception e) {
                MessageBox.Show("LOAD CONFIG\n" + e.ToString());
            }
        }

        static ConfigVar CreateConfigVar(string l) {
            int nameMarker = l.IndexOf(":") + 1;
            string name = l.Substring(1, nameMarker - varPrefix.Length - 1);
            string text = l.Substring(nameMarker);

            return new ConfigVar(name, text);
        }

    }

    public class ConfigVar {
        public string name;
        public string value;

        public ConfigVar(string n, string t) {
            name = n;
            value = t;
        }
    }

    public class ConfigSetting {

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
                    boolVal = CheckBoolVal(defVal);
                    break;
                case VarType.integer:
                    UpdateIntVal(defVal);
                    break;
            }
        }

        public void UpdateValue(string val) {
            if(val.Length == 0) {
                return;
            }

            switch (myType) {
                case VarType.boolean:
                    boolVal = CheckBoolVal(val);
                    break;
                case VarType.integer:
                    UpdateIntVal(val);
                    break;
            }

            stringVal = val;
        }

        void UpdateIntVal(string val) {
            int parsed;
            if (int.TryParse(val, out parsed))
                intVal = parsed;
            else
                intVal = 0;
        }

        public void ChangeDefault(string val) {
            defaultVal = val;
        }

        public static bool CheckBoolVal(string v) {
            if (v.ToLower() == "true") {
                return true;
            } else {
                return false;
            }
        }
    }
}
