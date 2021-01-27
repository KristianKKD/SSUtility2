using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class ConfigControl {

        //Defaults//
        private static string defScFolder = @"Snapshots\";
        private static string defVFolder = @"Videos\";
        private static string defSavedFolder = @"Saved\";

        private static string defVName = "Video";
        private static string defScName = "Snapshot";

        private static string defVRecQual = "70";
        private static string defVRecFPS = "30";

        private static string defVUpdateMs = "500";

        private static bool defSubnetNot = false;
        private static bool defAutoPlay = true;
        private static bool defAutomaticPaths = true;

        private static string defFinalSource = @"\\192.168.1.118\netdrive\ProductionTesting\DEFAULT FILES";
        private static string defFinalDestination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static string config = "config.txt";
        public const string autoSave = "auto.txt";
        public static string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SSUtility\";
        public static string ScreenRecordingName = "Recording";
        //Defaults//

        //RuntimeVars//
        public static string scFolder;
        public static string vFolder;
        public static string savedFolder;
        public static string scFileName;
        public static string vFileName;
        public static string recQual;
        public static string recFPS;
        public static string updateMs;

        public static bool subnetNotif;
        public static bool autoPlay;
        public static bool automaticPaths;

        public static bool portableMode;
        public static string finalSource;
        public static string finalDestination;

        //RuntimeVars//

        //SearchForVars//
        static string configPath = "";

        private const string varPrefix = "v"; //What the prefix of the actual value is (ScreenshotFolder:bin/obj/)

        private const string screenshotFolderVar = "SnapshotFolder";
        private const string videoFolderVar = "VideoFolder";

        private const string videoFileNVar = "VideoFileName";
        private const string scFileNVar = "SnapshotFileName";

        private const string recQualVar = "RecordingQuality";
        private const string recFPSVar = "RecordingFramerate";

        private const string updateMsVar = "UpdateStatsTimerMs";

        private const string subnetNotifVar = "SubnetNotificationHidden";
        private const string autoPlayVar = "AutoPlayLaunch";
        private const string automaticPathsVar = "AutomaticPaths";

        private const string portableModeVar = "PortableMode";
        private const string finalSourceVar = "FinalModeSourceFolder";
        private const string finalDestinationVar = "FinalModeDestinationFolder";
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
            updateMs = defVUpdateMs;

            subnetNotif = defSubnetNot;
            autoPlay = defAutoPlay;
            automaticPaths = defAutomaticPaths;

            finalSource = defFinalSource;
            finalDestination = defFinalDestination;
        }

        public static void CreateConfig(string path) {
            ResetFile(path);
            configPath = path;

            (string, string)[] configArray = new (string, string)[] {
                (screenshotFolderVar, scFolder),
                (videoFolderVar, vFolder),

                (scFileNVar, scFileName),
                (videoFileNVar, vFileName),

                (recQualVar, recQual),
                (recFPSVar, recFPS),
                (updateMsVar, updateMs),

                (subnetNotifVar, subnetNotif.ToString()),
                (autoPlayVar, autoPlay.ToString()),
                (automaticPathsVar, automaticPaths.ToString()),

                (portableModeVar, portableMode.ToString()),
                (finalSourceVar, finalSource),
                (finalDestinationVar, finalDestination),
            };

            foreach ((string, string) line in configArray) {
                if (!portableMode && (line.Item1 == finalSourceVar || line.Item1 == finalDestinationVar)) {
                    continue;
                }

                ConfigLine(path, line.Item1, line.Item2);
            }

            if (MainForm.m.finalMode) {
                MainForm.CopySingleFile(MainForm.m.finalDest + @"\SSUtility2\" + config, path);
            }
        }

        static void ConfigLine(string path, string variable, string value) {
            File.AppendAllText(path, varPrefix + variable + ":" + value + "\n");
        }

        public static async Task FindVars() {
            foreach (ConfigVar v in stringVarList) {
                if (v.value.ToLower() == "false" || v.value.ToLower() == "true") {
                    bool val = CheckVal(v.value);
                    switch (v.name) {
                        case subnetNotifVar:
                            subnetNotif = val;
                            break;
                        case automaticPathsVar:
                            automaticPaths = val;
                            break;
                        case autoPlayVar:
                            autoPlay = val;
                            break;
                        case portableModeVar:
                            portableMode = val;
                            break;
                    }
                } else {
                    switch (v.name) {
                        case screenshotFolderVar:
                            scFolder = v.value;
                            break;
                        case videoFolderVar:
                            vFolder = v.value;
                            break;
                        case scFileNVar:
                            scFileName = v.value;
                            break;
                        case videoFileNVar:
                            vFileName = v.value;
                            break;
                        case recQualVar:
                            recQual = v.value;
                            break;
                        case recFPSVar:
                            recFPS = v.value;
                            break;
                        case updateMsVar:
                            updateMs = v.value;
                            break;
                        case finalSourceVar:
                            finalSource = v.value;
                            break;
                        case finalDestinationVar:
                            finalDestination = v.value;
                            break;
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
