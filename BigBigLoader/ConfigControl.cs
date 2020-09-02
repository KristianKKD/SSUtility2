using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBigLoader {
    class ConfigControl {

        public static string DefScFolder;

        const string varString = "v";
        public const string ScreenshotFolderVar = "ScreenshotFolder";

        public static List<PathVariable> varList { get;
            set; }

        public static async Task SetDefaults() {
            DefScFolder = MainForm.scFolder;
        }

        public static void Create(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
            var newFile = File.Create(path);
            newFile.Close();

            File.AppendAllText(path, varString + ScreenshotFolderVar + ":" + MainForm.scFolder);
            // anything else i want in the config file
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

            List<PathVariable> found = new List<PathVariable>();
            foreach (string line in lines) {
                if (line.StartsWith(varString)) {
                    found.Add(CreateVar(line));
                }
            }

            varList = found;
        }

        static PathVariable CreateVar(string l) {
            int nameMarker = l.IndexOf(":") + 1;
            string name = l.Substring(varString.Length, nameMarker - varString.Length - 1);
            string text = l.Substring(nameMarker);

            return new PathVariable(name, text);
        }
      
    }

    class PathVariable {

        public string name;
        public string value;

        public PathVariable(string n, string t) {
            value = t;
            name = n;
        }

    }

}
