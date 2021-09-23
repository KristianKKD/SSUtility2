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

        private const string configVarPrefix = "v"; //What the prefix of the actual value is ([varPrefix]ScreenshotFolder:bin/obj/)
        private const string playerPrefix = "p"; 
        private const string customButtonsPrefix = "c";
        private const string userAddedComPrefix = "u";
        private const string rtspPresetPrefix = "r";
        private const string subPrefix = " ";
        
        public static ConfigSetting scFolder = new ConfigSetting(savedFolder, "SnapshotFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting vFolder = new ConfigSetting(savedFolder, "VideoFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting vFileName = new ConfigSetting("Video", "VideoFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting scFileName = new ConfigSetting("Snapshot", "SnapshotFileName", ConfigSetting.VarType.strings);
        public static ConfigSetting recQual = new ConfigSetting("70", "RecordingQuality", ConfigSetting.VarType.integer);
        public static ConfigSetting recFPS = new ConfigSetting("50", "RecordingFramerate", ConfigSetting.VarType.integer);
        public static ConfigSetting autoPlay = new ConfigSetting("true", "AutoPlayLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting ignoreAddress = new ConfigSetting("false", "AddressInvalidHidden", ConfigSetting.VarType.boolean);
        public static ConfigSetting forceCamera = new ConfigSetting("false", "ForceCameraModeEnabled", ConfigSetting.VarType.boolean);
        public static ConfigSetting automaticPaths = new ConfigSetting("true", "AutomaticPaths", ConfigSetting.VarType.boolean);
        public static ConfigSetting portableMode = new ConfigSetting("true", "PortableMode", ConfigSetting.VarType.boolean);
        public static ConfigSetting finalSource = new ConfigSetting(@"\\192.168.1.118\netdrive\ProductionTesting\DEFAULT FILES", "FinalModeSourceFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting finalDestination = new ConfigSetting(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FinalModeDestinationFolder", ConfigSetting.VarType.strings);
        public static ConfigSetting savedIP = new ConfigSetting("192.168.1.71", "SavedIP", ConfigSetting.VarType.strings);
        public static ConfigSetting savedPort = new ConfigSetting("6791", "SavedPort", ConfigSetting.VarType.strings);
        public static ConfigSetting cameraPTSpeedMultiplier = new ConfigSetting("100", "CameraPanTiltSpeedMultiplier", ConfigSetting.VarType.integer);
        public static ConfigSetting cameraZoomSpeedMultiplier = new ConfigSetting("2", "CameraZoomSpeedMultiplier", ConfigSetting.VarType.integer);
        public static ConfigSetting cameraFocusSpeedMultiplier = new ConfigSetting("2", "CameraFocusSpeedMultiplier", ConfigSetting.VarType.integer);
        public static ConfigSetting forceType = new ConfigSetting("Strict", "ForcedCameraType", ConfigSetting.VarType.strings);
        public static ConfigSetting startupWidth = new ConfigSetting("1280", "StartupWidth", ConfigSetting.VarType.integer);
        public static ConfigSetting startupHeight = new ConfigSetting("720", "StartupHeight", ConfigSetting.VarType.integer);
        public static ConfigSetting maintainAspectRatio = new ConfigSetting("false", "MaintainAspectRatio", ConfigSetting.VarType.boolean);
        public static ConfigSetting playerCount = new ConfigSetting("1", "PlayerCount", ConfigSetting.VarType.integer);
        public static ConfigSetting pelcoOverrideID = new ConfigSetting("1", "PelcoOverrideID", ConfigSetting.VarType.integer);
        public static ConfigSetting mainPlayerPreset = new ConfigSetting("", "MainPlayerPresetName", ConfigSetting.VarType.strings);
        public static ConfigSetting player2Preset = new ConfigSetting("", "SecondaryPresetName", ConfigSetting.VarType.strings);
        public static ConfigSetting player3Preset = new ConfigSetting("", "TertiaryPresetName", ConfigSetting.VarType.strings);
        public static ConfigSetting mainPlayerTabName = new ConfigSetting("Main Player", "MainPlayerTabName", ConfigSetting.VarType.strings);
        public static ConfigSetting player2TabName = new ConfigSetting("Player 2", "SecondaryTabName", ConfigSetting.VarType.strings);
        public static ConfigSetting player3TabName = new ConfigSetting("Player 3", "TertiaryTabName", ConfigSetting.VarType.strings);
        public static ConfigSetting launchQuickFunctions = new ConfigSetting("false", "EnableQuickFunctionsOnLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting launchInfoPanel = new ConfigSetting("false", "EnableInfoPanelOnLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting launchControlPanel = new ConfigSetting("false", "EnableControlPanelOnLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting launchCustomPanel = new ConfigSetting("false", "EnableCustomPanelOnLaunch", ConfigSetting.VarType.boolean);
        public static ConfigSetting enableFullToParts = new ConfigSetting("true", "EnableFullToParts", ConfigSetting.VarType.boolean);
        public static ConfigSetting startInMaximised = new ConfigSetting("false", "StartInMaximised", ConfigSetting.VarType.boolean);

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
            cameraPTSpeedMultiplier,
            cameraZoomSpeedMultiplier,
            cameraFocusSpeedMultiplier,
            forceType,
            startupWidth,
            startupHeight,
            playerCount,
            maintainAspectRatio,
            pelcoOverrideID,
            mainPlayerPreset,
            player2Preset,
            player3Preset,
            mainPlayerTabName,
            player2TabName,
            player3TabName,
            launchQuickFunctions,
            launchInfoPanel,
            launchControlPanel,
            launchCustomPanel,
            enableFullToParts,
            startInMaximised,
        };

        public static async Task SetToDefaults() {
            savedFolder = appFolder + @"Saved\";
            scFolder.ChangeDefault(savedFolder);
            vFolder.ChangeDefault(savedFolder);

            foreach (ConfigSetting setting in configArray)
                setting.UpdateValue(setting.defaultVal);
        }

        public static void CreateConfig(string path) {
            try {
                Tools.ResetFile(path);

                File.AppendAllText(path, "#SSUtility2.0 " + MainForm.version + " Config\n\n");

                foreach (ConfigSetting setting in configArray) {
                    if (!portableMode.boolVal && (setting.settingName == finalSource.settingName || setting.settingName == finalDestination.settingName))
                        continue;

                    ConfigLine(path, setting.settingName, setting.stringVal, configVarPrefix);
                }

                List<string> rtspPresets = RTSPPresets.GetAll();
                ConfigLine(path, "RTSPPresets", RTSPPresets.currentPresetCount.ToString(), rtspPresetPrefix);
                foreach (string line in rtspPresets)
                    File.AppendAllText(path, subPrefix + line + "\n");

                SaveDGV(path, MainForm.m.setPage.dgv_Custom_Buttons, "CustomButtons", customButtonsPrefix);

                CommandListWindow clw = MainForm.m.clw;
                SaveDGV(path, MainForm.m.clw.dgv_Coms, "UserAddedCommands", userAddedComPrefix, clw.defaultCommandCount);

                if (MainForm.m.finalMode)
                    Tools.CopySingleFile(MainForm.m.finalDest + @"\SSUtility2\" + config, path);

            } catch (Exception e) {
                Tools.ShowPopup("Failed to write config!\nShow more?", "Critical Error Occurred!", e.ToString());
            }
        }

        static void SaveDGV(string path, DataGridView dgv, string saveName, string definingRowPrefix, int fromRow = 0) {
            List<int> validRows = Tools.GetValidRows(dgv, fromRow);
            ConfigLine(path, saveName, validRows.Count.ToString(), definingRowPrefix);
            foreach (int validRow in validRows)
                File.AppendAllText(path, subPrefix + Tools.GetRowCellVals(dgv.Rows[validRow]) + "\n");
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

                    if (line.StartsWith("//") || line.StartsWith("#")
                        || line.StartsWith(@"\\") || line.StartsWith(" "))
                        continue;

                    if (line.StartsWith(configVarPrefix))
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
                        } else if (line.StartsWith(customButtonsPrefix)) {
                            i++;

                            for (int o = 0; o < val; o++)
                                if (lines.Length - 1 >= i + o)
                                    MainForm.m.setPage.AddCustomButton(lines[i + o]);

                            i += val - 1;
                        } else if (line.StartsWith(userAddedComPrefix)) {
                            i++;

                            for (int o = 0; o < val; o++)
                                if (lines.Length - 1 >= i + o)
                                    MainForm.m.clw.LoadCommand(lines[i + o]);

                            i += val - 1;
                        } else if (line.StartsWith(rtspPresetPrefix)) {
                            i++;

                            for (int o = 0; o < val; o++)
                                if (lines.Length - 1 >= i + o)
                                    RTSPPresets.LoadPreset(lines[i+o]);

                            i += val - 1;
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
                    for (int o = 1; o < playersFound.Count; o++)
                        MainForm.m.playerConfigList.Add(playersFound[o]);
                }
            } catch (Exception e) {
                MessageBox.Show("LOAD CONFIG\n" + e.ToString());
            }
        }

        static ConfigVar CreateConfigVar(string l) {
            int nameMarker = l.IndexOf(":") + 1;
            string name = l.Substring(1, nameMarker - configVarPrefix.Length - 1);
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
