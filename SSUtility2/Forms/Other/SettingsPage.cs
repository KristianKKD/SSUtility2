using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class SettingsPage : Form {
        public SettingsPage() {
            InitializeComponent();
        }

        public async Task PopulateSettingText() {
            tB_Paths_sCFolder.Text = ConfigControl.scFolder.stringVal;
            tB_Paths_vFolder.Text = ConfigControl.vFolder.stringVal;

            tB_Rec_vFileN.Text = ConfigControl.vFileName.stringVal;
            tB_Rec_scFileN.Text = ConfigControl.scFileName.stringVal;

            cB_Rec_Quality.Text = ConfigControl.recQual.stringVal;
            cB_Rec_FPS.Text = ConfigControl.recFPS.stringVal;

            cB_Other_RefreshRate.Text = ConfigControl.commandRateMs.stringVal;

            check_Other_Subnet.Checked = ConfigControl.subnetNotif.boolVal;
            check_Other_AutoPlay.Checked = ConfigControl.autoPlay.boolVal;
            check_Paths_Manual.Checked = ConfigControl.automaticPaths.boolVal;

            ConfigControl.CheckIfExists(tB_Paths_sCFolder, l_Paths_sCCheck);
            ConfigControl.CheckIfExists(tB_Paths_vFolder, l_Paths_vCheck);
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
            ConfigControl.autoPlay.UpdateValue(check_Other_AutoPlay.Checked.ToString());
        }

        private void check_Other_Subnet_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.subnetNotif.UpdateValue(check_Other_Subnet.Checked.ToString());
        }

        private void check_Paths_Manual_CheckedChanged(object sender, EventArgs e) {
            bool auto = !check_Paths_Manual.Checked;

            ConfigControl.automaticPaths.UpdateValue((!auto).ToString());

            tB_Paths_sCFolder.Enabled = auto;
            tB_Paths_vFolder.Enabled = auto;

            tB_Rec_vFileN.Enabled = auto;
            tB_Rec_scFileN.Enabled = auto;

            b_Paths_sCBrowse.Enabled = auto;
            b_Paths_vBrowse.Enabled = auto;
        }

        private void cB_Other_RefreshRate_TextChanged(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(cB_Other_RefreshRate.Text, true)) {
                ConfigControl.commandRateMs.UpdateValue(cB_Other_RefreshRate.Text);
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
                ConfigControl.scFolder.UpdateValue(tB_Paths_sCFolder.Text);
            }
        }

        private void tB_Paths_vFolder_TextChanged(object sender, EventArgs e) {
            if (MainForm.m.CheckFinishedTypingPath(tB_Paths_vFolder, l_Paths_vCheck).Result) {
                ConfigControl.vFolder.UpdateValue(tB_Paths_vFolder.Text);
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

            ConfigControl.recFPS.UpdateValue(cB_Rec_FPS.Text);
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

            ConfigControl.recQual.UpdateValue(cB_Rec_Quality.Text);
        }

        private void tB_Rec_vFileN_TextChanged(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(tB_Rec_vFileN.Text)) {
                ConfigControl.vFileName.UpdateValue(tB_Rec_vFileN.Text);
            } else {
                tB_Rec_vFileN.Text = ConfigControl.vFileName.stringVal;
            }
        }

        private void tB_Rec_scFileN_TextChanged(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(tB_Rec_scFileN.Text)) {
                ConfigControl.scFileName.UpdateValue(tB_Rec_scFileN.Text);
            } else {
                tB_Rec_vFileN.Text = ConfigControl.scFileName.stringVal;
            }
        }

        private void SettingsPage_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void b_ChangeDir_Click(object sender, EventArgs e) {
            bool confirm = MainForm.ShowPopup("Moving the directory will reset app configuration AND WILL ALSO DELETE ALL FILES WITHIN THE OLD APP FOLDER!\nYou will have the option to save these files.\nAre you sure you want to continue?", "Warning", null, false);
            if (confirm) {
                bool moveFiles = MainForm.ShowPopup("Would you like to move all current directory files to the new directory too?", "Move files?", null, false);
                string oldAppFolder = ConfigControl.appFolder;

                MainForm.ChooseNewDirectory();
                ConfigControl.SetToDefaults();
                MainForm.CreateConfigFiles();

                if (oldAppFolder != ConfigControl.appFolder && oldAppFolder != ConfigControl.appFolder + @"SSUtility\") {
                    if (moveFiles) {
                        MainForm.CopyFiles(ConfigControl.appFolder, Directory.GetFiles(oldAppFolder));
                    }

                    MainForm.DeleteDirectory(oldAppFolder);
                }
                MessageBox.Show("Finished changing directories!");
            }
        }

    }
}
