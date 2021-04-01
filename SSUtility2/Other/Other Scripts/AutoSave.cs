using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    class AutoSave {

        public static async Task SaveAuto(string path) {
            ConfigControl.ResetFile(path);

            foreach (Control c in MainForm.autosaveControls) {
                if (c is TrackBar) {
                    TrackBar t = (TrackBar)c;
                    File.AppendAllText(path, t.Value.ToString() + "\n");
                } else {
                    File.AppendAllText(path, c.Text + "\n");
                }
            }

            if (MainForm.m.finalMode) {
                Tools.CopySingleFile(MainForm.m.finalDest + @"\SSUtility2\" + ConfigControl.autoSave, path);
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

            for (int i = 0; i < MainForm.autosaveControls.Length; i++) {
                if (MainForm.autosaveControls[i] is TrackBar) {
                    TrackBar t = (TrackBar)MainForm.autosaveControls[i];
                    t.Value = int.Parse(lines[i]);
                } else {
                    MainForm.autosaveControls[i].Text = lines[i];
                }
            }
        }


    }
}
