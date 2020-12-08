using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    public partial class SettingsPage : Form {
        public SettingsPage() {
            InitializeComponent();
        }

        public async Task PopulateSettingText() {
            tB_Paths_sCFolder.Text = ConfigControl.savedFolder;
            tB_Paths_vFolder.Text = ConfigControl.savedFolder;

            tB_Rec_vFileN.Text = ConfigControl.vFileName;
            tB_Rec_scFileN.Text = ConfigControl.scFileName;

            cB_Rec_Quality.Text = ConfigControl.recQual;
            cB_Rec_FPS.Text = ConfigControl.recFPS;

            cB_Other_RefreshRate.Text = ConfigControl.updateMs;

            check_Other_Subnet.Checked = ConfigControl.subnetNotif;
            check_Other_AutoPlay.Checked = ConfigControl.autoPlay;
            check_Paths_Manual.Checked = ConfigControl.automaticPaths;
        }

        private void b_Settings_Apply_Click(object sender, EventArgs e) {
            ApplyAll();
        }

        private async Task ApplyAll() {
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
            MessageBox.Show("Applied settings to: " + ConfigControl.appFolder + ConfigControl.config);
        }

        private void b_Settings_Default_Click(object sender, EventArgs e) {
            DialogResult d = MessageBox.Show("Are you sure you want to reset all settings? \n" +
                    "Settings will not automatically be applied so the user may edit the defaults before applying.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes) {
                ConfigControl.SetToDefaults();
                PopulateSettingText();
            }
        }

        private void check_Other_AutoPlay_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.autoPlay = check_Other_AutoPlay.Checked;
        }

        private void check_Other_Subnet_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.subnetNotif = check_Other_Subnet.Checked;
        }

        private void check_Paths_Manual_CheckedChanged(object sender, EventArgs e) {
            bool auto = !check_Paths_Manual.Checked;

            ConfigControl.automaticPaths = !auto;

            tB_Paths_sCFolder.Enabled = auto;
            tB_Paths_vFolder.Enabled = auto;

            tB_Rec_vFileN.Enabled = auto;
            tB_Rec_scFileN.Enabled = auto;

            b_Paths_sCBrowse.Enabled = auto;
            b_Paths_vBrowse.Enabled = auto;
        }

        private void cB_Other_RefreshRate_TextChanged(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(cB_Other_RefreshRate.Text.ToCharArray(), true).Result) {
                ConfigControl.updateMs = cB_Other_RefreshRate.Text;
            }
        }

        private void b_Paths_sCBrowse_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Paths_sCFolder);

        }

        private void b_Paths_vBrowse_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Paths_vFolder);
        }

        private void tB_Paths_sCFolder_TextChanged(object sender, EventArgs e) {
            if (MainForm.m.CheckFinishedTypingPath(tB_Paths_sCFolder, l_Paths_sCCheck).Result) {
                ConfigControl.scFolder = tB_Paths_sCFolder.Text;
            }
        }

        private void tB_Paths_vFolder_TextChanged(object sender, EventArgs e) {
            if (MainForm.m.CheckFinishedTypingPath(tB_Paths_vFolder, l_Paths_vCheck).Result) {
                ConfigControl.vFolder = tB_Paths_vFolder.Text;
            }
        }

        private void cB_Rec_FPS_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Rec_Quality.Text, out int fps)) {
                cB_Rec_FPS.Text = fps.ToString();
                return;
            }
            if (fps < 1) {
                cB_Rec_FPS.Text = "1";
            }

            ConfigControl.recFPS = cB_Rec_FPS.Text;
        }

        private void cB_Rec_Quality_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Rec_Quality.Text, out int q)) {
                cB_Rec_Quality.Text = q.ToString();
                return;
            }
            if (q > 100) {
                cB_Rec_Quality.Text = "100";
            } else if (q < 1) {
                cB_Rec_Quality.Text = "1";
            }

            ConfigControl.recQual = cB_Rec_Quality.Text;
        }

        private void tB_Rec_vFileN_TextChanged(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(tB_Rec_vFileN.Text.ToCharArray()).Result) {
                ConfigControl.vFileName = tB_Rec_vFileN.Text;
            } else {
                tB_Rec_vFileN.Text = ConfigControl.vFileName;
            }
        }

        private void tB_Rec_scFileN_TextChanged(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(tB_Rec_scFileN.Text.ToCharArray()).Result) {
                ConfigControl.scFileName = tB_Rec_scFileN.Text;
            } else {
                tB_Rec_vFileN.Text = ConfigControl.scFileName;
            }
        }

        private void SettingsPage_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
