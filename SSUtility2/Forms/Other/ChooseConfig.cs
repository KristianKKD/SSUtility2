using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class ChooseConfig : Form {

        public ChooseConfig((string, string)[] dirs) {
            InitializeComponent();

            foreach ((string,string) entry in dirs) {
                dgv_Config.Rows.Add(entry.Item1, entry.Item2);
            }
        }

        private void dgv_Config_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ConfigControl.config = dgv_Config.Rows[e.RowIndex].Cells[0].Value.ToString();
            Dispose();
        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            Dispose();
        }

        private void b_Browse_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = Tools.OpenFile();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.FileName.Contains(".txt")) {
                    ConfigControl.config = fdg.FileName;
                } else {
                    Tools.ShowPopup("Please open a .txt file!\nUser tried to open an unsupported file type! Show more info?", "Invalid File Type!",
                        "User tried opening: " + fdg.FileName + "\nTry opening a .txt file instead.");
                }
            }
            Dispose();
        }

    }
}
