using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class SettingsPage : Form {

        Timer resolutionTimer;
        Timer updateControl;

        public bool overridePreset;

        public SettingsPage() {
            InitializeComponent();
            CreateHandle();
            l_Version.Text = l_Version.Text + MainForm.version;

            resolutionTimer = new Timer();
            resolutionTimer.Interval = 1500;
            resolutionTimer.Tick += new EventHandler(ResolutionTimerCallback);

            updateControl = new Timer();
            updateControl.Interval = 1000;
            updateControl.Tick += new EventHandler(UpdateControlCallback);

            ButtonsCommand.Items.Add(" ");

            for (int i = 0; i < 200; i++)
                ButtonsCommand.Items.Add("Preset " + (i + 1).ToString());

        }

        public async Task LoadSettings() {
            try {
                slider_IPCon_ControlMultiplier.Value = ConfigControl.cameraSpeedMultiplier.intVal;

                tB_IPCon_Adr.Text = ConfigControl.savedIP.stringVal;
                tB_IPCon_CamSpeed.Text = ConfigControl.cameraSpeedMultiplier.intVal.ToString();
                tB_Recording_sCFolder.Text = ConfigControl.scFolder.stringVal;
                tB_Recording_vFolder.Text = ConfigControl.vFolder.stringVal;
                tB_Recording_vFileN.Text = ConfigControl.vFileName.stringVal;
                tB_Recording_scFileN.Text = ConfigControl.scFileName.stringVal;
                tB_Other_ResolutionWidth.Text = ConfigControl.startupWidth.stringVal;
                tB_Other_ResolutionHeight.Text = ConfigControl.startupHeight.stringVal;


                cB_IPCon_Port.Text = ConfigControl.savedPort.stringVal;
                cB_IPCon_ForceMode.Enabled = ConfigControl.forceCamera.boolVal;
                cB_IPCon_ForceMode.Text = ConfigControl.forceType.stringVal;
                cB_Recording_Quality.Text = ConfigControl.recQual.stringVal;
                cB_Recording_FPS.Text = ConfigControl.recFPS.stringVal;
                cB_Startup_PlayerCount.Text = ConfigControl.playerCount.stringVal;

                check_IPCon_ForceCam.Checked = ConfigControl.forceCamera.boolVal;
                check_Recording_Manual.Checked = ConfigControl.automaticPaths.boolVal;
                check_Startup_AutoPlay.Checked = ConfigControl.autoPlay.boolVal;
                check_Startup_QuickFunctions.Checked = ConfigControl.launchQuickFunctions.boolVal;
                check_Startup_InfoPanel.Checked = ConfigControl.launchInfoPanel.boolVal;
                check_Startup_ControlPanel.Checked = ConfigControl.launchControlPanel.boolVal;
                check_Startup_CustomPanel.Checked = ConfigControl.launchCustomPanel.boolVal;
                check_Other_AddressInvalid.Checked = ConfigControl.ignoreAddress.boolVal;
                check_Other_Aspect.Checked = ConfigControl.maintainAspectRatio.boolVal;
                check_Other_FullToParts.Checked = ConfigControl.enableFullToParts.boolVal;

                Tools.CheckIfExists(tB_Recording_sCFolder, l_Recording_sCCheck);
                Tools.CheckIfExists(tB_Recording_vFolder, l_Recording_vCheck);

                MainForm.m.Width = ConfigControl.startupWidth.intVal;
                MainForm.m.Height = ConfigControl.startupHeight.intVal;
                l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
                l_Other_Dir.Text = "Current Directory: " + ConfigControl.appFolder;

                MainForm.m.custom.UpdateButtonNames();
                UpdateCamType();
                UpdateRatioLabel();

                int index;
                if (int.TryParse(RTSPPresets.GetValue(RTSPPresets.PresetColumn.Index, ConfigControl.mainPlayerPreset.stringVal), out index)) {
                    MainForm.m.mainPlayer.settings.cB_RTSP.SelectedIndex = index;
                    cB_IPCon_MainPlayerPreset.SelectedIndex = index;
                }

                MainForm.m.mainPlayer.settings.LoadTabName();
            } catch (Exception e) {
                Tools.ShowPopup("Failed to update settings!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        private async Task ApplyAll() {
            ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
        }

        private void b_Settings_Default_Click(object sender, EventArgs e) {
            DialogResult d = MessageBox.Show("Are you sure you want to reset all settings?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes) {
                ConfigControl.SetToDefaults();
                LoadSettings();
                MainForm.m.mainPlayer.DestroyAll();
            }
        }

        private void check_Startup_AutoPlay_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.autoPlay.UpdateValue(check_Startup_AutoPlay.Checked.ToString());
        }

        private void check_Recording_Manual_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            bool auto = !check_Recording_Manual.Checked;

            ConfigControl.automaticPaths.UpdateValue((!auto).ToString());

            tB_Recording_sCFolder.Enabled = auto;
            tB_Recording_vFolder.Enabled = auto;

            tB_Recording_vFileN.Enabled = auto;
            tB_Recording_scFileN.Enabled = auto;

            b_Recording_sCBrowse.Enabled = auto;
            b_Recording_vBrowse.Enabled = auto;
        }

        private void b_Recording_sCBrowse_Click(object sender, EventArgs e) {
            Tools.BrowseFolderButton(tB_Recording_sCFolder);
        }

        private void b_Recording_vBrowse_Click(object sender, EventArgs e) {
            Tools.BrowseFolderButton(tB_Recording_vFolder);
        }

        private void tB_Recording_sCFolder_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckFinishedTypingPath(tB_Recording_sCFolder, l_Recording_sCCheck).Result) {
                MainForm.m.col.recentSavedLocations.Remove(ConfigControl.scFolder.stringVal);
                ConfigControl.scFolder.UpdateValue(tB_Recording_sCFolder.Text);
                MainForm.m.col.recentSavedLocations.Add(ConfigControl.scFolder.stringVal);
            }
        }

        private void tB_Recording_vFolder_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckFinishedTypingPath(tB_Recording_vFolder, l_Recording_vCheck).Result) {
                MainForm.m.col.recentSavedLocations.Remove(ConfigControl.vFolder.stringVal);
                ConfigControl.vFolder.UpdateValue(tB_Recording_vFolder.Text);
                MainForm.m.col.recentSavedLocations.Add(ConfigControl.vFolder.stringVal);

            }
        }

        private void cB_Recording_FPS_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Recording_FPS.Text, out int fps)) {
                cB_Recording_FPS.Text = fps.ToString();
                return;
            }
            if (fps < 1) {
                cB_Recording_FPS.Text = "1";
            } else if (fps > 200) {
                cB_Recording_FPS.Text = "200";
            }

            ConfigControl.recFPS.UpdateValue(cB_Recording_FPS.Text);
        }

        private void cB_Recording_Quality_TextChanged(object sender, EventArgs e) {
            if (!int.TryParse(cB_Recording_Quality.Text, out int q)) {
                cB_Recording_Quality.Text = q.ToString();
                return;
            }
            if (q > 100) {
                cB_Recording_Quality.Text = "100";
            } else if (q < 1) {
                cB_Recording_Quality.Text = "1";
            }

            ConfigControl.recQual.UpdateValue(cB_Recording_Quality.Text);
        }

        private void tB_Recording_vFileN_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckIfNameValid(tB_Recording_vFileN.Text)) {
                ConfigControl.vFileName.UpdateValue(tB_Recording_vFileN.Text);
            } else {
                tB_Recording_vFileN.Text = ConfigControl.vFileName.stringVal;
            }
        }

        private void tB_Recording_scFileN_TextChanged(object sender, EventArgs e) {
            if (Tools.CheckIfNameValid(tB_Recording_scFileN.Text)) {
                ConfigControl.scFileName.UpdateValue(tB_Recording_scFileN.Text);
            } else {
                tB_Recording_vFileN.Text = ConfigControl.scFileName.stringVal;
            }
        }

        private void SettingsPage_FormClosing(object sender, FormClosingEventArgs e) {
            ApplyAll();
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void b_Other_ChangeDir_Click(object sender, EventArgs e) {
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

            l_Other_Dir.Text = "Current Directory: " + ConfigControl.appFolder;
            MainForm.m.col.recentSavedLocations.Clear();
            MainForm.m.col.AddDefaultSavedLocations();
        }

        public void ToggleOverridePreset(bool enabled) {
            overridePreset = enabled;
            MainForm.m.mainPlayer.settings.ToggleOverride(enabled);
            check_IPCon_Override.Checked = enabled;
        }

        public async Task ConnectToCamera() {
            if (!MainForm.m.finishedLoading)
                return;

            ConfigControl.savedIP.UpdateValue(tB_IPCon_Adr.Text);

            int parsed;
            if(int.TryParse(cB_IPCon_Port.Text, out parsed))
                ConfigControl.savedPort.UpdateValue(parsed.ToString());

            AsyncCamCom.TryConnect(false).ConfigureAwait(false);
        }

        private void b_Custom_CommandList_Click(object sender, EventArgs e) {
            MainForm.m.clw.ShowWindow();
        }

        public async Task LiteButtonSelect() {
            if (MainForm.m.lite) {
                MainForm.m.b_PTZ_Daylight.BackColor = System.Drawing.Color.Silver;
                MainForm.m.b_PTZ_Thermal.BackColor = System.Drawing.Color.Silver;
                MainForm.m.b_PTZ_Daylight.Visible = true;
                MainForm.m.b_PTZ_Thermal.Visible = true;

                Console.WriteLine(ConfigControl.pelcoOverrideID.intVal);

                if (ConfigControl.pelcoOverrideID.intVal == 1)
                    MainForm.m.b_PTZ_Daylight.BackColor = System.Drawing.Color.LightGreen;
                else if (ConfigControl.pelcoOverrideID.intVal == 2)
                    MainForm.m.b_PTZ_Thermal.BackColor = System.Drawing.Color.LightGreen;
                else {
                    MainForm.m.b_PTZ_Daylight.Visible = false;
                    MainForm.m.b_PTZ_Thermal.Visible = false;
                }
            }
        }

        private void tB_Other_Resolution_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                resolutionTimer.Stop();
                ResolutionTimerCallback(sender, e);
            } else {
                if (resolutionTimer.Enabled)
                    resolutionTimer.Stop();

                resolutionTimer.Start();
            }
        }

        void ResolutionTimerCallback(object sender, EventArgs e) {
            resolutionTimer.Stop();

            if (!int.TryParse(tB_Other_ResolutionHeight.Text, out int h) || h < 600)
                h = 600;

            if (!int.TryParse(tB_Other_ResolutionWidth.Text, out int w) || w < 800)
                w = 800;

            tB_Other_ResolutionHeight.Text = h.ToString();
            tB_Other_ResolutionWidth.Text = w.ToString();

            ConfigControl.startupWidth.UpdateValue(tB_Other_ResolutionWidth.Text);
            ConfigControl.startupHeight.UpdateValue(tB_Other_ResolutionHeight.Text);

            Console.WriteLine(w + " " + h);
            System.Drawing.Size s = new System.Drawing.Size(w, h);
            MainForm.m.MinimumSize = s;
            MainForm.m.MaximumSize = s;

            l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
            this.BringToFront();
            check_Other_Aspect_CheckedChanged(sender, e);
        }

        private void check_Other_AddressInvalid_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.ignoreAddress.UpdateValue(check_Other_AddressInvalid.Checked.ToString());
        }

        private void tC_Settings_SelectedIndexChanged(object sender, EventArgs e) {
            if (tC_Settings.SelectedTab == tP_Customs)
                b_Custom_CommandList.Visible = true;
            else
                b_Custom_CommandList.Visible = false;

            UpdateRatioLabel();
        }

        private void check_IPCon_ForceCam_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            ConfigControl.forceCamera.UpdateValue(check_IPCon_ForceCam.Checked.ToString());
            cB_IPCon_ForceMode.Enabled = ConfigControl.forceCamera.boolVal;


            InfoPanel.i.isCamera = ConfigControl.forceCamera.boolVal;
        }

        private void cB_IPCon_ForceMode_SelectedIndexChanged(object sender, EventArgs e) {
            ConfigControl.forceType.UpdateValue(cB_IPCon_ForceMode.Text);
            UpdateCamType();
        }

        public static void UpdateCamType() {
            if (ConfigControl.forceCamera.boolVal) {
                OtherCamCom.CamConfig config = OtherCamCom.CamConfig.Strict;

                switch (ConfigControl.forceType.stringVal) {
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
            } 
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

        private void check_Other_Aspect_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            bool val = check_Other_Aspect.Checked;

            ConfigControl.maintainAspectRatio.UpdateValue(val.ToString());

            if (val)
                MainForm.m.StartRatioTimer();
            else
                MainForm.m.StopRatioTimer();

            UpdateRatioLabel();

            BringToFront();
        }

        public void UpdateRatioLabel() {
            l_Other_Ratio.Visible = ConfigControl.maintainAspectRatio.boolVal;
            l_Other_Ratio.Text = MainForm.m.GetRatio();
        }

        public void UpdateCamConfig(OtherCamCom.CamConfig type) {
            Invoke((MethodInvoker)delegate {
                cB_IPCon_ForceMode.Text = type.ToString();
                ConfigControl.forceType.UpdateValue(cB_IPCon_ForceMode.Text);
            });
        }

        private void b_IPCon_Recheck_Click(object sender, EventArgs e) {
            CheckConfig();
        }

        async Task CheckConfig() {
            UpdateCamConfig(await OtherCamCom.CheckConfiguration());
        }

        private void cB_Startup_PlayerCount_SelectedIndexChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            ConfigControl.playerCount.UpdateValue(cB_Startup_PlayerCount.Text);
            MainForm.m.AttachPlayers();
        }

        public void AddCustomButton(string line) {
            try {
                string[] sets = Tools.GetRowValueArray(dgv_Custom_Buttons, line);

                DataGridViewRow curRow = (DataGridViewRow)dgv_Custom_Buttons.Rows[0].Clone();

                for (int i = 0; i < sets.Length; i++)
                    curRow.Cells[i].Value = sets[i];

                dgv_Custom_Buttons.Rows.Add(curRow);

                AddToOptions(sets[1]);

                MainForm.m.custom.AddButton(sets[1]);
            } catch (Exception e) {
                MessageBox.Show("ADD PRESET\n" + line + "\n" + e.ToString());
            }
        }

        void AddToOptions(string cbVal) {
            try {
                cbVal = cbVal.Trim();

                if (!ButtonsCommand.Items.Contains(cbVal))
                    ButtonsCommand.Items.Add(cbVal);
            } catch { }
        }

        private void dgv_Custom_Buttons_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if (dgv_Custom_Buttons.CurrentCellAddress.X == ButtonsCommand.DisplayIndex) { //type into cell
                ComboBox cb = (ComboBox)e.Control;
                if (cb != null)
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void dgv_Custom_Buttons_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (dgv_Custom_Buttons.Rows.Count >= 9) {
                dgv_Custom_Buttons.AllowUserToAddRows = false;
                return;
            }
            if (!MainForm.m.finishedLoading)
                return;
            try {
                CustomButtons custom = MainForm.m.custom;
                DataGridViewRow row = dgv_Custom_Buttons.Rows[e.RowIndex];

                if (row.Cells[e.ColumnIndex].Value == null) {
                    custom.RemoveButton(e.RowIndex);
                    dgv_Custom_Buttons.Rows.Remove(row);
                    if (dgv_Custom_Buttons.Rows.Count < 9)
                        dgv_Custom_Buttons.AllowUserToAddRows = true;
                    return;
                }

                string val = row.Cells[e.ColumnIndex].Value.ToString().Trim();

                if (e.ColumnIndex == 1 && val.Length > 0) {
                    AddToOptions(val);
                    row.SetValues(row.Cells[0].Value, val);
                }

                if (custom.buttonList.Count > 0)
                    custom.UpdateButtonNames();
            } catch (Exception er) {
                MessageBox.Show("DGV VAL CHANGED\n" + er.ToString());
            }
        }

        private void dgv_Custom_Buttons_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            int pos = e.RowIndex - 2;

            if (e.RowIndex == 1)
                pos = 1;

            string val = "-";
            if (dgv_Custom_Buttons.Rows[pos].Cells[0].Value != null)
                val = dgv_Custom_Buttons.Rows[pos].Cells[0].Value.ToString();

            MainForm.m.custom.AddButton(val);
        }

        private void dgv_Custom_Buttons_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == ButtonsCommand.DisplayIndex) { //save cell value
                if (!ButtonsCommand.Items.Contains(e.FormattedValue) && e.FormattedValue.ToString() != "") {
                    ButtonsCommand.Items.Add(e.FormattedValue);
                    dgv_Custom_Buttons.Rows[e.RowIndex].SetValues(dgv_Custom_Buttons.Rows[e.RowIndex].Cells[0].Value, e.FormattedValue);
                }
            }

            MainForm.m.custom.UpdateTip(e.RowIndex);
        }

        private void b_IPCon_Edit_Click(object sender, EventArgs e) {
            VideoSettings.OpenEdit(MainForm.m.mainPlayer.settings);
        }

        private void cB_IPCon_MainPlayerPreset_SelectedIndexChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            if (cB_IPCon_MainPlayerPreset.SelectedIndex == cB_IPCon_MainPlayerPreset.Items.Count - 1
                && RTSPPresets.currentPresetCount == 0) //if no presets exist and the user clicks Add New...
                RTSPPresets.CreateNew(MainForm.m.mainPlayer.settings);
            else
                MainForm.m.mainPlayer.settings.cB_RTSP.SelectedIndex = cB_IPCon_MainPlayerPreset.SelectedIndex;
        }

        private void check_IPCon_Override_CheckedChanged(object sender, EventArgs e) {
            bool check = check_IPCon_Override.Checked;
            MainForm.m.mainPlayer.settings.UpdateCheckOverride(check);

            tB_IPCon_Adr.Enabled = check;
            cB_IPCon_Port.Enabled = check;
            cB_IPCon_PelcoDID.Enabled = check;
        }


        private void tB_IPCon_ControlFields_TextChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            if (updateControl.Enabled)
                updateControl.Stop();

            updateControl.Start();
        }

        private async void UpdateControlCallback(object sender, EventArgs e) {
            int parsedVal;
            if (int.TryParse(cB_IPCon_PelcoDID.Text, out parsedVal))
                ConfigControl.pelcoOverrideID.intVal = parsedVal;

            //video setting controls get updated in asynccamcom

            ConnectToCamera();
            updateControl.Stop();
        }

        private void cB_IPCon_Port_SelectedIndexChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            DelayedIndex();
        }

        async Task DelayedIndex() {
            await Task.Delay(100);
            cB_IPCon_Port.Text = Tools.GetPortValueFromEncoder(cB_IPCon_Port);
        }

        private void check_Startup_QuickFunctions_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.launchQuickFunctions.UpdateValue(check_Startup_QuickFunctions.Checked.ToString());
        }

        private void check_Startup_InfoPanel_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.launchInfoPanel.UpdateValue(check_Startup_InfoPanel.Checked.ToString());
        }

        private void check_Startup_ControlPanel_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.launchControlPanel.UpdateValue(check_Startup_ControlPanel.Checked.ToString());
        }

        private void check_Startup_CustomPanel_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.launchCustomPanel.UpdateValue(check_Startup_CustomPanel.Checked.ToString());
        }

        private void check_Other_FullToParts_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.enableFullToParts.UpdateValue(check_Other_FullToParts.Checked.ToString());
        }
    }
}
