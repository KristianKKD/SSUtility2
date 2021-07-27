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

        void StartupDefaults() {
            try {
                dayRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
                AddPreset("IONodes - Daylight;1; ; ;videoinput_1:0/h264_1/onvif.stm;admin;admin;", dayRow);

                thermalRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();
                AddPreset("IONodes - Thermal;2; ; ;videoinput_2:0/h264_1/onvif.stm;admin;admin;", thermalRow);

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

                foreach (DataGridViewRow row in MainForm.m.up.dgv_Presets.Rows) {
                    if (row.Cells[0].Value.ToString().Contains(enteredString)) {
                        int val = 0;
                        if (int.TryParse(row.Cells[1].Value.ToString(), out val))
                            return val;
                        else
                            return 0;
                    }
                }

            } catch { }

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
                MessageBox.Show("ADD PRESET\n" + line + "\n" + e.ToString());
            }
        }

        void AddToOptions(DataGridViewRow row) {
            row.Cells[dgv_Presets.Columns.Count - 1].Value = "X";
            MainForm.m.setPage.AddPresetOption(row);
            VideoSettings.AddPresetOption(row);
        }

        void RemoveFromOptions(DataGridViewRow row) {
            if(dgv_Presets.Rows.Contains(row))
                dgv_Presets.Rows.Remove(row);

            MainForm.m.setPage.RemovePresetOption(row);
            VideoSettings.RemovePresetOption(row);
        }

        void EditInOptions() {
            MainForm.m.setPage.EditPresetOption(dgv_Presets.Rows[rowIndex], editRow);
            VideoSettings.EditPresetOption(dgv_Presets.Rows[rowIndex], editRow);
        }

    }
}
