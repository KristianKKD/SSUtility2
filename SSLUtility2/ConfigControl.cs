using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class ConfigControl {

        public static string DefScFolder;
        public static string DefVFolder;
        public static string DefScName;
        public static string DefVName;

        static string configPath = "";

        const string varString = "v";
        public const string screenshotFolderVar = "ScreenshotFolder";
        public const string videoFolderVar = "VideoFolder";
        public const string videoFileNVar = "VideoFileName";
        public const string scFileNVar = "ScreenshotFileName";

        public static List<PathVar> varList {
            get;
            set;
        }

        public static async Task SetDefaults() {
            DefScFolder = MainForm.scFolder;
            DefVFolder = MainForm.vFolder;
            DefVName = MainForm.vFileName;
            DefScName = MainForm.scFileName;
        }

        public static void Create(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
            var newFile = File.Create(path);
            newFile.Close();
            configPath = path;

            File.AppendAllText(path, varString + screenshotFolderVar + ":" + MainForm.scFolder + "\n");
            File.AppendAllText(path, varString + videoFolderVar + ":" + MainForm.vFolder + "\n");
            File.AppendAllText(path, varString + scFileNVar + ":" + MainForm.scFileName + "\n");
            File.AppendAllText(path, varString + videoFileNVar + ":" + MainForm.vFileName + "\n");
        }

        public static void Append(string text) {
            if (configPath == "") {
                configPath = MainForm.appFolder + MainForm.config;
            }
            File.AppendAllText(configPath, varString + text);
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

            List<PathVar> found = new List<PathVar>();
            foreach (string line in lines) {
                if (line.StartsWith(varString)) {
                    found.Add(CreateVar(line));
                }
            }

            varList = found;
        }

        static PathVar CreateVar(string l) {
            int nameMarker = l.IndexOf(":") + 1;
            string name = l.Substring(varString.Length, nameMarker - varString.Length - 1);
            string text = l.Substring(nameMarker);

            return new PathVar(name, text);
        }

    }

    class PathVar {

        public string name;
        public string value;

        public PathVar(string n, string t) {
            value = t;
            name = n;
        }

    }
    class SavedControl {

        public string value;
        public string name;

        public SavedControl( string t, string n) {
            value = t;
            name = n;
        }

    }

}
