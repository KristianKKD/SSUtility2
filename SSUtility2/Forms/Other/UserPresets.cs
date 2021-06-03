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
            StartupDefaults();
        }

        DataGridViewRow dayRow;
        DataGridViewRow thermalRow;
        DataGridViewRow vivoRow;
        DataGridViewRow boschRow;

        DataGridViewRow[] defaults;

        //Name;PelcoID;IP;Port;RTSP;Username;Password;

        void StartupDefaults() {
            try {
                dayRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
                AddPreset("IONodes - Daylight;2; ; ;videoinput_1:0/h264_1/onvif.stm;", dayRow);

                thermalRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
                AddPreset("IONodes - Thermal;1; ; ;videoinput_2:0/h264_1/onvif.stm;", thermalRow);

                vivoRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
                AddPreset("VIVOTEK;1; ; ;live.sdp;root;root1234;", vivoRow);

                boschRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
                AddPreset("BOSCH;1; ; ; ;service;Service123!;", boschRow);

                defaults = new DataGridViewRow[]{
                    dayRow,
                    thermalRow,
                    vivoRow,
                    boschRow,
                };
            } catch (Exception e) {
                MessageBox.Show("ADD STARTUP ROWS\n" + e.ToString());
            }
        }

        void RemoveDefaults() {
            if (!dgv_Presets.Rows.Contains(defaults[0]))
                return;

            for (int i = 0; i < defaults.Length; i++)
                RemoveFromOptions(defaults[i]);
        }

        public static int GetPelcoID(string enteredString) {
            try {
                int parsed;
                if (int.TryParse(enteredString, out parsed))
                    return parsed;

                DataGridView dgv = MainForm.m.up.dgv_Presets;

                for (int i = 0; i < dgv.Rows.Count - 1; i++) {
                    if (dgv.Rows[i].Cells[0].Value.ToString().Contains(enteredString)) {
                        int val = 0;
                        int.TryParse(dgv.Rows[i].Cells[1].Value.ToString(), out val);
                        return val;
                    }
                }

            }catch(Exception e) {
                MessageBox.Show("GET PELCO ID\n" + e.ToString());
            }

            return 0;
        }

        public void AddPreset(string line, DataGridViewRow curRow = null) {
            if (curRow == null)
                RemoveDefaults();
            
            try {
                line = line.Trim();
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

                if (curRow == null)
                    curRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();

                for (int i = 0; i < sets.Length; i++)
                    curRow.Cells[i].Value = sets[i];

                dgv_Presets.Rows.Add(curRow);

                AddToOptions(curRow);
            } catch (Exception e) {
                MessageBox.Show("ADD PRESET\n" + e.ToString());
            }
        }

        void AddToOptions(DataGridViewRow row) {
            MainForm.m.setPage.AddPresetOption(row);
            VideoSettings(row);
        }

        void RemoveFromOptions(DataGridViewRow row) {
            if(dgv_Presets.Rows.Contains(row))
                dgv_Presets.Rows.Remove(row);

            MainForm.m.setPage.RemovePresetOption(row);
        }

        void EditInOptions() {
            MainForm.m.setPage.EditPresetOption(dgv_Presets.Rows[rowIndex], editRow);
        }

        public int CountRows() {
            int rowCount = 0;
            foreach (DataGridViewRow row in dgv_Presets.Rows) {
                if (!RowIsNull(row))
                    rowCount++;
            }

            return rowCount;
        }

        bool RowIsNull(DataGridViewRow row) {
            string val = GetRowCellVals(row);

            string checkForNull = val.Replace(";", "");
            checkForNull = checkForNull.Replace(" ", "");

            return (checkForNull.Length == 0);
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

        DataGridViewRow editRow;
        int rowIndex = -1;

        private void dgv_Presets_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            rowIndex = e.RowIndex;
            editRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
            for (int i = 0; i < dgv_Presets.Columns.Count; i++)
                editRow.Cells[i].Value = dgv_Presets.Rows[rowIndex].Cells[i].Value;
        }
        
        private void dgv_Presets_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            rowIndex = -1;
        }

        private void dgv_Presets_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (rowIndex == -1)
                return;

            EditInOptions();
        }
    }
}
