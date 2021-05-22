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
                        if (curCom.valueCount > 0) {
                            names += " X";
                        }

                        if (x < curCom.names.Length - 1)
                            names += ", ";
                    }
                    row.Cells[0].Value = names;

                    if (!curCom.custom) {
                        string comContent = Tools.ReadCommand(curCom.codeContent, true);
                        //comcontent(11) = XX XX YY YY

                        if (curCom.valueCount == 1) {
                            comContent = comContent.Substring(0, 9) + "XX";
                        } else if (curCom.valueCount == 2) {
                            comContent = comContent.Substring(0, 6) + "XX XX";
                        }

                        row.Cells[1].Value = comContent;
                    } else {
                        row.Cells[1].Value = "Scripting";
                        row.Cells[2].Value = "(Custom Command) ";
                    }

                    string description = curCom.description;
                    if (curCom.valueCount > 0 && !curCom.custom) {
                        int xIndex = description.IndexOf("X") + 1;

                        string vals = " (" + curCom.validValues + ") ";

                        description = description.Substring(0, xIndex) + vals
                             + description.Substring(xIndex);
                    }

                    row.Cells[2].Value += description;

                    dgv_Coms.Rows.Add(row);
                }

                dgv_Coms.AllowUserToAddRows = false;
            }
        }

        private void dgv_Coms_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (!pelcoWindow)
                return;

            int row = e.RowIndex;
            int column = e.ColumnIndex;
            string val = dgv_Coms.Rows[row].Cells[column].Value.ToString();

            if (column == 2 || val == "Scripting")
                return;

            if (MainForm.m.pd.tB_Commands.Text.Length > 0) {
                MainForm.m.pd.tB_Commands.Text += Environment.NewLine;
            }

            if (column == 0) {
                if (val.Contains(","))
                    val = val.Substring(0, val.IndexOf(","));

                if (val.Contains(" X"))
                    val = val.Substring(0, val.IndexOf(" X")) + " 0";
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
