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
            cB_ipCon_CamType.Text = ConfigControl.mainPlayerCamType.stringVal;
            slider_IPCon_ControlMultiplier.Value = ConfigControl.cameraSpeedMultiplier.intVal;
            tB_IPCon_CamSpeed.Text = ConfigControl.cameraSpeedMultiplier.intVal.ToString();

            tB_Paths_sCFolder.Text = ConfigControl.scFolder.stringVal;
            tB_Paths_vFolder.Text = ConfigControl.vFolder.stringVal;

            tB_Rec_vFileN.Text = ConfigControl.vFileName.stringVal;
            tB_Rec_scFileN.Text = ConfigControl.scFileName.stringVal;

            tB_Other_ResolutionWidth.Text = ConfigControl.startupWidth.stringVal;
            tB_Other_ResolutionHeight.Text = ConfigControl.startupHeight.stringVal;

            cB_Rec_Quality.Text = ConfigControl.recQual.stringVal;
            cB_Rec_FPS.Text = ConfigControl.recFPS.stringVal;

            check_Other_Subnet.Checked = ConfigControl.subnetNotif.boolVal;
            check_Other_AutoPlay.Checked = ConfigControl.autoPlay.boolVal;
            check_Other_AutoReconnect.Checked = ConfigControl.autoReconnect.boolVal;
            check_AddressInvalid.Checked = ConfigControl.ignoreAddress.boolVal;
            check_Paths_Manual.Checked = ConfigControl.automaticPaths.boolVal;
            cB_IPCon_ForceMode.Enabled = ConfigControl.forceCamera.boolVal;
            check_IPCon_ForceCam.Checked = ConfigControl.forceCamera.boolVal;
            cB_IPCon_ForceMode.Text = ConfigControl.forceCameraType.stringVal;

            ConfigControl.CheckIfExists(tB_Paths_sCFolder, l_Paths_sCCheck);
            ConfigControl.CheckIfExists(tB_Paths_vFolder, l_Paths_vCheck);

            MainForm.m.Width = ConfigControl.startupWidth.intVal;
            MainForm.m.Height = ConfigControl.startupHeight.intVal;
            l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
            MainForm.m.sP_Player.Location = new System.Drawing.Point(MainForm.m.Width - MainForm.m.sP_Player.Width - 30, 15);
            l_Paths_Dir.Text = "Current Directory: " + ConfigControl.appFolder;
           
            UpdateSelectedCam(false);
            LoadCustoms();
            MainForm.m.custom.UpdateButtonNames();
            UpdateCamType();

            MainForm.m.mainPlayer.settings.tB_PlayerD_Name.Text = ConfigControl.mainPlayerName.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_SimpleAdr.Text = ConfigControl.mainPlayerFullAdr.stringVal;
            MainForm.m.mainPlayer.settings.cB_PlayerD_CamType.Text = ConfigControl.mainPlayerCamType.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_Adr.Text = ConfigControl.mainPlayerIPAdr.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_Port.Text = ConfigControl.mainPlayerPort.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_RTSP.Text = ConfigControl.mainPlayerRTSP.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_Buffering.Text = ConfigControl.mainPlayerBuffering.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_Username.Text = ConfigControl.mainPlayerUsername.stringVal;
            MainForm.m.mainPlayer.settings.tB_PlayerD_Password.Text = ConfigControl.mainPlayerPassword.stringVal;
        }

        private async Task ApplyAll() {
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
            MainForm.m.custom.UpdateButtonNames();
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

                FileStuff.ChooseNewDirectory();
                ConfigControl.SetToDefaults();
                FileStuff.CreateConfigFiles();

                if (oldAppFolder != ConfigControl.appFolder && oldAppFolder != ConfigControl.appFolder + @"SSUtility\") {
                    if (moveFiles) {
                        Tools.CopyFiles(ConfigControl.appFolder, Directory.GetFiles(oldAppFolder));
                    }

                    Tools.DeleteDirectory(oldAppFolder);
                }
                MessageBox.Show("Finished changing directories!");
            }

            l_Paths_Dir.Text = "Current Directory: " + ConfigControl.appFolder;
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
            ConfigControl.savedIP.UpdateValue(tB_IPCon_Adr.Text);
            AsyncCamCom.TryConnect(false);
        }

        private void tB_IPCon_Adr_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ConfigControl.savedIP.UpdateValue(tB_IPCon_Adr.Text);
                AsyncCamCom.TryConnect(false);
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
            ConfigControl.savedPort.UpdateValue(tB_IPCon_Port.Text);
            AsyncCamCom.TryConnect(true);
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

        public async Task UpdateSelectedCam(bool play) {
            cB_ipCon_CamType.Text = ConfigControl.mainPlayerCamType.stringVal;

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

        private void tC_Settings_SelectedIndexChanged(object sender, EventArgs e) {
            if (tC_Settings.SelectedTab == tP_Customs)
                b_Custom_CommandList.Visible = true;
            else
                b_Custom_CommandList.Visible = false;
        }

        void LoadCustoms() {
            if (dgv_Custom_Buttons.Rows.Count < 1) { //on launch
                for (int i = 0; i < 200; i++) {
                    ButtonsCommand.Items.Add("Preset " + (i + 1).ToString());
                }

                for (int i = 0; i < 8; i++) {
                    dgv_Custom_Buttons.Rows.Add(ConfigControl.customButtonNamesArray[i].stringVal);
                }
            } else { //if defaulting
                for (int i = 0; i < 8; i++) {
                    dgv_Custom_Buttons.Rows[i].SetValues(ConfigControl.customButtonNamesArray[i].stringVal, ConfigControl.customButtonCommandsArray[i].stringVal);
                }
            }

            for (int i = 0; i < ConfigControl.customButtonCommandsArray.Length; i++) {
                string val = ConfigControl.customButtonCommandsArray[i].stringVal;
                if (val != "") {
                    if(!ButtonsCommand.Items.Contains(val))
                        ButtonsCommand.Items.Add(val);
                    dgv_Custom_Buttons.Rows[i].SetValues(dgv_Custom_Buttons.Rows[i].Cells[0].Value, val);
                }
            }
        }

        private void dgv_Custom_Buttons_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (dgv_Custom_Buttons.CurrentCellAddress.X == ButtonsCommand.DisplayIndex) { //type into cell
                ComboBox cb = e.Control as ComboBox;
                if (cb != null) {
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }
        }

        private void dgv_Custom_Buttons_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == ButtonsCommand.DisplayIndex) { //save cell value
                if (!ButtonsCommand.Items.Contains(e.FormattedValue) && e.FormattedValue.ToString() != "") {
                    ButtonsCommand.Items.Add(e.FormattedValue);
                    dgv_Custom_Buttons.Rows[e.RowIndex].SetValues(dgv_Custom_Buttons.Rows[e.RowIndex].Cells[0].Value, e.FormattedValue);
                }
            }

            if (e.ColumnIndex == 0) { //changed name
                ConfigControl.customButtonNamesArray[e.RowIndex].UpdateValue(e.FormattedValue.ToString());
            } else { //changed command
                ConfigControl.customButtonCommandsArray[e.RowIndex].UpdateValue(e.FormattedValue.ToString());
            }
        }

        private void check_IPCon_ForceCam_CheckedChanged(object sender, EventArgs e) {
            ConfigControl.forceCamera.UpdateValue(check_IPCon_ForceCam.Checked.ToString());
            cB_IPCon_ForceMode.Enabled = ConfigControl.forceCamera.boolVal;
            if(ConfigControl.forceCamera.boolVal)
                Detached.EnableSecond(true);
            else
                Detached.DisableSecond();
        }

        private void cB_IPCon_ForceMode_SelectedIndexChanged(object sender, EventArgs e) {
            ConfigControl.forceCameraType.UpdateValue(cB_IPCon_ForceMode.Text);
            UpdateCamType();
        }

        public static void UpdateCamType() {
            if (ConfigControl.forceCameraType.boolVal) {
                OtherCamCom.CamConfig config = OtherCamCom.CamConfig.Strict;

                switch (ConfigControl.forceCameraType.stringVal) {
                    case "SSTraditional":
                        config = OtherCamCom.CamConfig.SSTraditional;
                        break;
                    case "Strict":
                        config = OtherCamCom.CamConfig.Strict;
                        break;
                    case "RevTilt":
                        config = OtherCamCom.CamConfig.RevTilt;
                        break;
                    case "Legacy":
                        config = OtherCamCom.CamConfig.Legacy;
                        break;
                }

                OtherCamCom.currentConfig = config;
                Detached.EnableSecond(true);
            }

            InfoPanel.i.isCamera = ConfigControl.forceCameraType.boolVal;
        }

        private void cB_ipCon_CamType_SelectedIndexChanged(object sender, EventArgs e) {
            ConfigControl.mainPlayerCamType.UpdateValue(cB_ipCon_CamType.Text);
            UpdateSelectedCam(true);
        }

        private void cB_ipCon_CamType_KeyPress(object sender, KeyPressEventArgs e) {
            ConfigControl.mainPlayerCamType.UpdateValue(cB_ipCon_CamType.Text);
            UpdateSelectedCam(true);
        }

        private void tB_IPCon_CamSpeed_KeyPress(object sender, KeyPressEventArgs e) {
            if (float.TryParse(tB_IPCon_CamSpeed.Text, out float val)) {
                if (val < 1f)
                    val = 1;
                else if (val > 200f)
                    val = 200;

                val = (float)Math.Truncate(val);

                ConfigControl.cameraSpeedMultiplier.UpdateValue(val.ToString());
            }
            if (e.KeyChar == (char)Keys.Enter) {
                tB_IPCon_CamSpeed.Text = ConfigControl.cameraSpeedMultiplier.intVal.ToString();
                slider_IPCon_ControlMultiplier.Value = ConfigControl.cameraSpeedMultiplier.intVal;
            }
        }

        private void tB_IPCon_CamSpeed_Leave(object sender, EventArgs e) {
            tB_IPCon_CamSpeed.Text = (ConfigControl.cameraSpeedMultiplier.intVal).ToString();
            slider_IPCon_ControlMultiplier.Value = ConfigControl.cameraSpeedMultiplier.intVal;
        }

        bool dragging = false;

        private void slider_IPCon_ControlMultiplier_Scroll(object sender, EventArgs e) {
            if (dragging) {
                ConfigControl.cameraSpeedMultiplier.UpdateValue(slider_IPCon_ControlMultiplier.Value.ToString());
                tB_IPCon_CamSpeed.Text = (ConfigControl.cameraSpeedMultiplier.intVal).ToString();
            }
        }

        private void slider_IPCon_ControlMultiplier_MouseDown(object sender, MouseEventArgs e) {
            dragging = true;
        }

        private void slider_IPCon_ControlMultiplier_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
        }

    }
}
