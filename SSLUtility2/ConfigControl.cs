using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class ConfigControl {

        public static string DefScFolder;

        static string configPath = "";

        const string varString = "v";
        public const string ScreenshotFolderVar = "ScreenshotFolder";

        public static List<PathVar> varList {
            get;
            set;
        }

        public static async Task SetDefaults() {
            DefScFolder = MainForm.scFolder;
        }

        public static void Create(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
            var newFile = File.Create(path);
            newFile.Close();
            configPath = path;

            File.AppendAllText(path, varString + ScreenshotFolderVar + ":" + MainForm.scFolder);
            // anything else i want in the config file
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
