using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class CommandListWindow : Form {

        bool pelcoWindow;

        public CommandListWindow(bool pelcod) {
            InitializeComponent();
            LoadContents();
            pelcoWindow = pelcod;
        }

        void LoadContents() {
            ScriptCommand[][] coms = CustomScriptCommands.cameraArrayCommands;

            foreach (ScriptCommand[] commandArray in coms) {
                foreach (ScriptCommand sc in commandArray) {
                    DataGridViewRow row = (DataGridViewRow)dgv_Coms.Rows[0].Clone();
                    ScriptCommand curCom = sc;

                    string names = "";
                    for (int x = 0; x < curCom.names.Length; x++) {
                        names += curCom.names[x];
                        if (curCom.valueAccepting) {
                            names += " 0";
                        }

                        if (x < curCom.names.Length - 1)
                            names += ", ";
                    }
                    row.Cells[0].Value = names;

                    if (!curCom.custom) {
                        row.Cells[1].Value = Tools.ReadCommand(curCom.codeContent, true);
                    } else {
                        row.Cells[2].Value = "(Custom Command) ";
                    }

                    row.Cells[2].Value += curCom.description;

                    dgv_Coms.Rows.Add(row);
                }

                dgv_Coms.AllowUserToAddRows = false;
            }
        }

        private void dgv_Coms_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (!pelcoWindow) {
                return;
            }
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            if (column == 2) {
                return;
            }

            if (MainForm.m.pd.tB_Commands.Text.Length > 0) {
                MainForm.m.pd.tB_Commands.Text += Environment.NewLine;
            }

            string val = dgv_Coms.Rows[row].Cells[column].Value.ToString();
            if (column == 0) {
                if (val.Contains(",")) {
                    val = val.Substring(0, val.IndexOf(","));
                }
            }

            MainForm.m.pd.tB_Commands.Text += val;
        }

        private void CommandListWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
