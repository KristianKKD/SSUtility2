using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    class AutoSave {

        public static async Task SaveAuto(string path) {
            ConfigControl.ResetFile(path);

            foreach (Control c in MainForm.saveList) {
                File.AppendAllText(path, c.Text + "\n");
            }

            if (MainForm.m.finalMode) {
                MainForm.CopySingleFile(MainForm.m.finalSS + ConfigControl.autoSave, path);
            }
        }

        public static async Task LoadAuto(string path, bool firstTime) {
            if (firstTime) {
                return;
            }

            if (!File.Exists(path)) {
                ConfigControl.ResetFile(path);
                return;
            }

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < MainForm.saveList.Length; i++) {
                MainForm.saveList[i].Text = lines[i];
            }
        }


    }
}
