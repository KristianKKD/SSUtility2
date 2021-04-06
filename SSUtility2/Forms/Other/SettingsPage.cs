using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class SettingsPage : Form {

        CommandListWindow clw = null;

        public SettingsPage() {
            InitializeComponent();
            l_Version.Text = l_Version.Text + MainForm.version;
            UpdatePresetCB();
        }

        public async Task PopulateSettingText() {
            tB_IPCon_Adr.Text = ConfigControl.savedIP.stringVal;
            tB_IPCon_Port.Text = ConfigControl.savedPort.stringVal;
            cB_ipCon_CamType.Text = ConfigControl.savedCamera.stringVal;

            tB_Paths_sCFolder.Text = ConfigControl.scFolder.stringVal;
            tB_Paths_vFolder.Text = ConfigControl.vFolder.stringVal;

            tB_Rec_vFileN.Text = ConfigControl.vFileName.stringVal;
            tB_Rec_scFileN.Text = ConfigControl.scFileName.stringVal;

            tB_Other_ResolutionWidth.Text = ConfigControl.startupWidth.stringVal;
            tB_Other_ResolutionHeight.Text = ConfigControl.startupHeight.stringVal;

            cB_Rec_Quality.Text = ConfigControl.recQual.stringVal;
            cB_Rec_FPS.Text = ConfigControl.recFPS.stringVal;

            cB_IPCon_RefreshRate.Text = ConfigControl.commandRateMs.stringVal;

            check_Other_Subnet.Checked = ConfigControl.subnetNotif.boolVal;
            check_Other_AutoPlay.Checked = ConfigControl.autoPlay.boolVal;
            check_Other_AutoReconnect.Checked = ConfigControl.autoReconnect.boolVal;
            check_AddressInvalid.Checked = ConfigControl.ignoreAddress.boolVal;
            check_Paths_Manual.Checked = ConfigControl.automaticPaths.boolVal;

            ConfigControl.CheckIfExists(tB_Paths_sCFolder, l_Paths_sCCheck);
            ConfigControl.CheckIfExists(tB_Paths_vFolder, l_Paths_vCheck);

            MainForm.m.Width = ConfigControl.startupWidth.intVal;
            MainForm.m.Height = ConfigControl.startupHeight.intVal;
            l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
            MainForm.m.sP_Player.Location = new System.Drawing.Point(MainForm.m.Width - MainForm.m.sP_Player.Width - 30, 15);

            UpdateSelectedCam(false);
        }

        private async Task ApplyAll() {
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
            //MessageBox.Show("Applied settings to: " + ConfigControl.appFolder + ConfigControl.config);
        }

        private void b_Settings_Default_Click(object sender, EventArgs e) {
            DialogResult d = MessageBox.Show("Are you sure you want to reset all settings?",
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

        private void cB_IPCon_RefreshRate_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckIfNameValid(cB_IPCon_RefreshRate.Text, true)) {
                ConfigControl.commandRateMs.UpdateValue(cB_IPCon_RefreshRate.Text);
            }
        }

        private void b_Paths_sCBrowse_Click(object sender, EventArgs e) {
            Tools.BrowseFolderButton(tB_Paths_sCFolder);
        }

        private void b_Paths_vBrowse_Click(object sender, EventArgs e) {
            Tools.BrowseFolderButton(tB_Paths_vFolder);
        }

        private void tB_Paths_sCFolder_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckFinishedTypingPath(tB_Paths_sCFolder, l_Paths_sCCheck).Result) {
                ConfigControl.scFolder.UpdateValue(tB_Paths_sCFolder.Text);
            }
        }

        private void tB_Paths_vFolder_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckFinishedTypingPath(tB_Paths_vFolder, l_Paths_vCheck).Result) {
                ConfigControl.vFolder.UpdateValue(tB_Paths_vFolder.Text);
            }
        }

        private void cB_Rec_FPS_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Rec_FPS.Text, out int fps)) {
                cB_Rec_FPS.Text = fps.ToString();
                return;
            }
            if (fps < 1) {
                cB_Rec_FPS.Text = "1";
            } else if (fps > 200) {
                cB_Rec_FPS.Text = "200";
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
            if (Tools.CheckIfNameValid(tB_Rec_vFileN.Text)) {
                ConfigControl.vFileName.UpdateValue(tB_Rec_vFileN.Text);
            } else {
                tB_Rec_vFileN.Text = ConfigControl.vFileName.stringVal;
            }
        }

        private void tB_Rec_scFileN_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckIfNameValid(tB_Rec_scFileN.Text)) {
                ConfigControl.scFileName.UpdateValue(tB_Rec_scFileN.Text);
            } else {
                tB_Rec_vFileN.Text = ConfigControl.scFileName.stringVal;
            }
        }

        private void SettingsPage_FormClosing(object sender, FormClosingEventArgs e) {
            ApplyAll();
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void b_ChangeDir_Click(object sender, EventArgs e) {
            bool confirm = Tools.ShowPopup("Moving the directory will reset app configuration AND WILL ALSO DELETE ALL FILES WITHIN THE OLD APP FOLDER!\nYou will have the option to save these files.\nAre you sure you want to continue?", "Warning", null, false);
            if (confirm) {
                bool moveFiles = Tools.ShowPopup("Would you like to move all current directory files to the new directory too?", "Move files?", null, false);
                string oldAppFolder = ConfigControl.appFolder;

                MainForm.ChooseNewDirectory();
                ConfigControl.SetToDefaults();
                MainForm.CreateConfigFiles();

                if (oldAppFolder != ConfigControl.appFolder && oldAppFolder != ConfigControl.appFolder + @"SSUtility\") {
                    if (moveFiles) {
                        Tools.CopyFiles(ConfigControl.appFolder, Directory.GetFiles(oldAppFolder));
                    }

                    Tools.DeleteDirectory(oldAppFolder);
                }
                MessageBox.Show("Finished changing directories!");
            }
        }

        private void cB_IPCon_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string port = "";

            if (cB_IPCon_PresetType.Text == "Encoder") {
                port = "6791";
            } else if (cB_IPCon_PresetType.Text == "MOXA nPort") {
                port = "4001";
            }

            tB_IPCon_Port.Text = port;
        }

        private void tB_IPCon_Adr_Leave(object sender, EventArgs e) {
            AsyncCamCom.TryConnect(false);
            ConfigControl.savedIP.UpdateValue(tB_IPCon_Adr.Text);
        }

        private void tB_IPCon_Adr_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                AsyncCamCom.TryConnect(false);
                ConfigControl.savedIP.UpdateValue(tB_IPCon_Adr.Text);
            }
        }

        void UpdatePresetCB() {
            if (tB_IPCon_Port.Text == "6791") {
                cB_IPCon_PresetType.Text = "Encoder";
            } else if (tB_IPCon_Port.Text == "4001") {
                cB_IPCon_PresetType.Text = "MOXA nPort";
            } else {
                cB_IPCon_PresetType.Text = "Custom";
            }
        }

        private void tB_IPCon_Port_TextChanged(object sender, EventArgs e) {
            AsyncCamCom.TryConnect(true);
            ConfigControl.savedPort.UpdateValue(tB_IPCon_Port.Text);
            UpdatePresetCB();
        }

        private void b_Custom_CommandList_Click(object sender, EventArgs e) {
            if (clw == null) {
                clw = new CommandListWindow(false);
            }
            clw.Show();
            clw.BringToFront();
        }

        private void check_Other_AutoReconnect_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.autoReconnect.UpdateValue(check_Other_AutoReconnect.Checked.ToString());
        }

        private void cB_ipCon_Selected_TextChanged(object sender, EventArgs e) {
            UpdateSelectedCam(true);
        }

        public async Task UpdateSelectedCam(bool play) {
            ConfigControl.savedCamera.UpdateValue(cB_ipCon_CamType.Text);

            MainForm.m.Menu_Settings_Swap.Enabled = true; // to disable in case it's not swappable (in else condition)

            if (ConfigControl.savedCamera.stringVal.Contains("Daylight"))
                MainForm.m.Menu_Settings_Swap.Text = "Swap to Thermal";
            else if (ConfigControl.savedCamera.stringVal.Contains("Thermal"))
                MainForm.m.Menu_Settings_Swap.Text = "Swap to Daylight";
            else
                MainForm.m.Menu_Settings_Swap.Enabled = false;

            if (play && AsyncCamCom.sock.Connected && !MainForm.m.lite)
                MainForm.m.mainPlayer.UpdateMode();
        }

        private void tB_Other_ResolutionWidth_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(tB_Other_ResolutionWidth.Text, out int w)) {
                tB_Other_ResolutionWidth.Text = ConfigControl.startupWidth.stringVal;
                return;
            }
            if (w > Screen.PrimaryScreen.Bounds.Width || w < 800) {
                tB_Other_ResolutionWidth.Text = w.ToString();
            } else {
                ConfigControl.startupWidth.UpdateValue(tB_Other_ResolutionWidth.Text);
            }
        }

        private void tB_Other_ResolutionHeight_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(tB_Other_ResolutionHeight.Text, out int h)) {
                tB_Other_ResolutionHeight.Text = ConfigControl.startupHeight.stringVal;
                return;
            }
            if (h > Screen.PrimaryScreen.Bounds.Height || h < 600) {
                tB_Other_ResolutionHeight.Text = h.ToString();
            } else {
                ConfigControl.startupHeight.UpdateValue(tB_Other_ResolutionHeight.Text);
            }
        }

        private void check_AddressInvalid_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.ignoreAddress.UpdateValue(check_AddressInvalid.Checked.ToString());
        }
    }
}
