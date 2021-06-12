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

        public int defaultCommandCount;

        List<int> addedRows;
        DataGridViewRow destroyRow;

        public CommandListWindow() {
            InitializeComponent();
            addedRows = new List<int>();

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
            if (!MainForm.m.pd.Visible || dgv_Coms.Rows[e.RowIndex].IsNewRow ||
                    dgv_Coms.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
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
            try {
                DataGridViewRow curRow = dgv_Coms.Rows[e.RowIndex];

                if (e.RowIndex < defaultCommandCount)
                    return;

                if (destroyRow != null && destroyRow.Cells.Contains(curRow.Cells[e.ColumnIndex]))
                    return;

                dgv_Coms.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            }catch(Exception err) {
                MessageBox.Show("CELLCLICK\n" + err.ToString());
            }
        }

        public void LoadCommand(string line) {
            try {
                line = line.Trim();
                string[] sets = new string[dgv_Coms.Columns.Count];

                string val = "";
                int setsPos = 0;
                foreach (char c in line.ToCharArray()) {
                    if (c.ToString() == ";") {
                        sets[setsPos] = val;
                        val = "";
                        setsPos++;
                    } else
                        val += c.ToString();
                }

                DataGridViewRow curRow = (DataGridViewRow)dgv_Coms.Rows[0].Clone();

                for (int i = 0; i < sets.Length; i++)
                    curRow.Cells[i].Value = sets[i];

                dgv_Coms.Rows.Add(curRow);

                AddCustomCommand(curRow);
            } catch (Exception e) {
                MessageBox.Show("ADD PRESET\n" + line + "\n" + e.ToString());
            }
        }

        void AddCustomCommand(DataGridViewRow row) {
            try {
                Console.WriteLine("adding");

                if (!addedRows.Contains(row.Index))
                    addedRows.Add(row.Index);

                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    return;

                ScriptCommand newsc = CreateCommand(row);

                if (!IsNullSC(newsc))
                    CustomScriptCommands.userAddedCommands.Add(newsc);

            } catch (Exception e) {
                MessageBox.Show("ADD\n" + e.ToString());
            }
        }

        bool IsNullSC(ScriptCommand sc) {
            bool returnVal = (sc == null || sc.names == null || sc.codeContent == null);
            if(returnVal)
                Console.WriteLine("null com");

            return returnVal;
        }

        void DestroyCustomCommand(DataGridViewRow row) { //ctrl+x bug
            try {
                Console.WriteLine("destroy");

                if (row.IsNewRow)
                    return;

                destroyRow = row;


                if (addedRows.Contains(row.Index))
                    addedRows.Remove(row.Index);

                if (dgv_Coms.Rows.Contains(row))
                    dgv_Coms.Rows.Remove(row);
            }catch(Exception e) {
                MessageBox.Show("DESTROY\n" + e.ToString());
            }
        }

        void EditCustomCommand(DataGridViewRow row) {
            try {
                Console.WriteLine("edit");

                ScriptCommand newsc = CreateCommand(row);

                if (IsNullSC(newsc))
                    return;

                for (int i = 0; i < CustomScriptCommands.userAddedCommands.Count; i++) {
                    bool foundCode = false;
                    bool foundName = false;
                    
                    if (Tools.ReadCommand(CustomScriptCommands.userAddedCommands[i].codeContent) == Tools.ReadCommand(newsc.codeContent))
                        foundCode = true;

                    if (!foundCode)
                        for (int x = 0; x < newsc.names.Length; x++)
                            if (CustomScriptCommands.userAddedCommands[i].names.Contains(newsc.names[x].Trim())) {
                                foundName = true;
                                break;
                            } 

                    if (foundCode || foundName) {
                        if (foundName)
                            newsc.valueCount = CustomScriptCommands.userAddedCommands[i].valueCount;

                        CustomScriptCommands.userAddedCommands.RemoveAt(i);
                        CustomScriptCommands.userAddedCommands.Add(newsc);
                        return;
                    }
                }

                AddCustomCommand(row); //if it cant find the scriptcommand
            }catch(Exception e) {
                MessageBox.Show("EDIT\n" + e.ToString());
            }
        }

        ScriptCommand CreateCommand(DataGridViewRow row) {
            int countedVals = CountValues(row);
            if (countedVals < 0)
                return null;


            byte[] fullCom = MainForm.m.pd.MakeCommand(row.Cells[1].Value.ToString());

            ScriptCommand sc = new ScriptCommand(GenNames(row), new byte[] { fullCom[2], fullCom[3], fullCom[4], fullCom[5] },
                GenDescription(row), countedVals);

            return sc;
        }

        string GenDescription(DataGridViewRow row) {
            try {
                if (row.Cells[2].Value != null)
                    return row.Cells[2].Value.ToString();
            } catch (Exception e) {
                MessageBox.Show("GENDESC\n" + e.ToString());
            }

            return "";

        }

        string[] GenNames(DataGridViewRow row) {
            try {
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
                if (row.Cells[0].Value.ToString().Replace(" ", "").Length != 0 && vals[vals.Length - 1] != ',')
                    namesFound.Add(vals.Substring(lastPos).Trim());

                return namesFound.ToArray();
            } catch (Exception e) {
                MessageBox.Show("GEN NAMES\n" + e.ToString());
                return null;
            }
        }

        int CountValues(DataGridViewRow row) {
            int foundX = 0;
            try {

                if (row.Cells[1].Value == null)
                    return foundX;


                string cellVal = row.Cells[1].Value.ToString().ToUpper();
                while (true) {
                    int posOfNext = cellVal.IndexOf("X");
                    if (posOfNext < 0)
                        break;

                    foundX++;
                    cellVal = cellVal.Substring(posOfNext + 1);
                }

                if (foundX % 2 == 1)
                    foundX++;

                row.Cells[1].Value = row.Cells[1].Value.ToString().Replace("X", "0");
            } catch (Exception e) {
                MessageBox.Show("COUNT VALS\n" + e.ToString());
            }

            return foundX;
        }

        private void dgv_Coms_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridViewRow row = dgv_Coms.Rows[e.RowIndex];
                var val = row.Cells[e.ColumnIndex].Value;
                if (val == null || val.ToString().Length == 0)
                    DestroyCustomCommand(row);
                else if (addedRows.Contains(e.RowIndex))
                    EditCustomCommand(row);
                else if (e.RowIndex == dgv_Coms.Rows.Count - 2)
                    AddCustomCommand(row);
            }catch(Exception err) {
                MessageBox.Show("CELLENDEDIT\n" + err.ToString());
            }

        }

    }
}
