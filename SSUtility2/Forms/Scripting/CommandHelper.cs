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

        int defaultCommandCount;

        public CommandListWindow() {
            InitializeComponent();
            LoadContents();
        }

        void LoadContents() {
            ScriptCommand[][] coms = CustomScriptCommands.cameraArrayCommands;
            defaultCommandCount = 0;

            foreach (ScriptCommand[] commandArray in coms) {
                defaultCommandCount += commandArray.Length;
                foreach (ScriptCommand sc in commandArray) {
                    DataGridViewRow row = (DataGridViewRow)dgv_Coms.Rows[0].Clone();
                    ScriptCommand curCom = sc;

                    string names = "";
                    for (int x = 0; x < curCom.names.Length; x++) {
                        names += curCom.names[x];
                        if (curCom.valueCount > 0)
                            names += " X";

                        if (x < curCom.names.Length - 1)
                            names += ", ";
                    }
                    row.Cells[0].Value = names;

                    if (!curCom.custom) {
                        string comContent = Tools.ReadCommand(curCom.codeContent, true);
                        //comcontent(11) = XX XX YY YY

                        if (curCom.valueCount == 1)
                            comContent = comContent.Substring(0, 9) + "XX";
                        else if (curCom.valueCount == 2)
                            comContent = comContent.Substring(0, 6) + "XX XX";
                        

                        row.Cells[1].Value = comContent;
                    } else {
                        row.Cells[1].Value = "Scripting";
                        row.Cells[2].Value = "(Scripting Command) ";
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

            }
        }

        public void ShowWindow() {
            Show();
            BringToFront();
        }

        private void dgv_Coms_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (!MainForm.m.pd.Visible || dgv_Coms.Rows[e.RowIndex].IsNewRow)
                return;

            int row = e.RowIndex;
            int column = e.ColumnIndex;
            string val = dgv_Coms.Rows[row].Cells[column].Value.ToString();

            if (column == 2 || val == "Scripting")
                return;

            if (MainForm.m.pd.tB_Commands.Text.Length > 0)
                MainForm.m.pd.tB_Commands.Text += Environment.NewLine;

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

        private void dgv_Coms_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridViewRow curRow = dgv_Coms.Rows[e.RowIndex];

            if (e.RowIndex < defaultCommandCount)
                return;

            if (destroyRow != null && destroyRow.Cells.Contains(curRow.Cells[e.ColumnIndex]))
                return;

            dgv_Coms.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
        }

        void AddCustomCommand(DataGridViewRow row) {
            //if (row.Cells[1].Value.ToString().Trim() == "")
            //    MessageBox.Show("New custom command content is empty, command ignored");
            Console.WriteLine("added");

            if (!addedRows.Contains(row.Index))
                addedRows.Add(row.Index);
        }

        void DestroyCustomCommand(DataGridViewRow row) { //ctrl+x bug
            if (row.IsNewRow)
                return;

            destroyRow = row;

            Console.WriteLine("destroy");

            if(addedRows.Contains(row.Index))
                addedRows.Remove(row.Index);

            if(dgv_Coms.Rows.Contains(row))
                dgv_Coms.Rows.Remove(row);
        }

        void EditCustomCommand(DataGridViewRow row) {
            Console.WriteLine("edit");

            GenNames(row);

            //ScriptCommand newsc = new ScriptCommand(GenNames(row), null, GenDescription(row), CountValues(row));

            //for (int i = 0; i < CustomScriptCommands.userAddedCommands.Count; i++)
            //    if (CustomScriptCommands.userAddedCommands[i].codeContent == newsc.codeContent) {
            //        CustomScriptCommands.userAddedCommands[i] = newsc;
            //        return;
            //    }

            //AddCustomCommand(row); //if it cant find the scriptcommand
        }

        string GenDescription(DataGridViewRow row) {
            if (row.Cells[2].Value != null)
                return row.Cells[2].Value.ToString();

            return "";
        }

        string[] GenNames(DataGridViewRow row) {
            if (row.Cells[0].Value == null)
                return null;

            string vals = row.Cells[0].Value.ToString();
            List<string> namesFound = new List<string>();

            int lastPos = 0;
            while (true) {
                int posOfNext = vals.Substring(lastPos).IndexOf(",");
                if (posOfNext <= 0)
                    break;

                namesFound.Add(vals.Substring(lastPos, posOfNext).Trim());
                lastPos += posOfNext + 1;
            }
            if (lastPos > 0 && vals[vals.Length - 1] != ',')
                namesFound.Add(vals.Substring(lastPos).Trim());

            Console.WriteLine("-------");

            foreach (string s in namesFound)
                Console.WriteLine(s);

            return namesFound.ToArray();
        }

        int CountValues(DataGridViewRow row) {
            //count xx in message
            return 0;
        }

        List<int> addedRows;
        DataGridViewRow destroyRow;

        private void dgv_Coms_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (addedRows == null)
                addedRows = new List<int>();

            //add to customscriptcommands, consider checking for content too?
            DataGridViewRow row = dgv_Coms.Rows[e.RowIndex];
            var val = row.Cells[e.ColumnIndex].Value;
            if (val == null || val.ToString().Length == 0)
                DestroyCustomCommand(row);
            else if (addedRows.Contains(e.RowIndex))
                EditCustomCommand(row);
            else if (e.RowIndex == dgv_Coms.Rows.Count - 2)
                AddCustomCommand(row);

        }
    }
}
