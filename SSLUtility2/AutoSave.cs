using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    
    class AutoSave {

        public static async Task SaveAuto(string path) {
            ConfigControl.ResetFile(path);

            foreach (Control c in MainForm.saveList) {
                File.AppendAllText(path, c.Text + "\n");
            }

        }

        public static async Task LoadAuto(string path) {
            if (!File.Exists(path)) {
                ConfigControl.ResetFile(path);
                return;
            }

            string[] lines = File.ReadAllLines(path);

            if (MainForm.saveList.Length != lines.Length) {
                if (MainForm.ShowError("Misaligment of autosaved variables! \nWould you like to regenerate the file?" +
                    "\n(Press 'yes' if you don't know what to do)", "Reset autosave?", null, false)) {
                    ConfigControl.ResetFile(path);
                    return;
                }
            }

            for (int i = 0; i < MainForm.saveList.Length; i++) {
                MainForm.saveList[i].Text = lines[i];
            }


        }


    }

}
