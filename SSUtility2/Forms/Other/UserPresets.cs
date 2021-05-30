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
    public partial class UserPresets : Form {
        public UserPresets() {
            InitializeComponent();
        }

        public static int GetPelcoID(string enteredString) {
            try {
                int parsed;
                if (int.TryParse(enteredString, out parsed))
                    return parsed;

                DataGridView dgv = MainForm.m.up.dgv_Presets;

                for (int i = 0; i < dgv.Rows.Count - 1; i++) {
                    if (dgv.Rows[i].Cells[0].Value.ToString().Contains(enteredString))
                        return (int)dgv.Rows[i].Cells[1].Value;
                }

            }catch(Exception e) {
                MessageBox.Show("GET PELCO ID\n" + e.ToString());
            }

            return 0;
        }

        public void AddPreset(string line) {
            try {
                string[] sets = new string[dgv_Presets.Columns.Count];

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

                DataGridViewRow curRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();

                for (int i = 0; i < sets.Length; i++) {
                    curRow.Cells[i].Value = sets[i];
                }

                dgv_Presets.Rows.Add(curRow);
            } catch (Exception e) {
                MessageBox.Show("ADD PRESET\n" + e.ToString());
            }
        }

        public int CountRows() {
            int rowCount = 0;
            foreach (DataGridViewRow row in dgv_Presets.Rows) {
                string val = GetRowCellVals(row);

                string checkForNull = val.Replace(";", "");
                checkForNull = checkForNull.Replace(" ", "");
                if (checkForNull.Length != 0)
                    rowCount++;
            }

            return rowCount;
        }

        public string GetRowCellVals(DataGridViewRow row) {
            string val = "";

            for (int i = 0; i < row.Cells.Count; i++) {
                string cellVal = row.Cells[i].Value + ";";
                if (cellVal == ";")
                    cellVal = " ;";

                val += cellVal;
            }

            return val;
        }

        private void UserPresets_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
