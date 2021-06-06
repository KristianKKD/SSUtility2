using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class SettingsPage : Form {

        CommandListWindow clw = null;
        Timer connectTimer;
        Timer pelcoIdTimer;


        public SettingsPage() {
            InitializeComponent();
            CreateHandle();
            l_Version.Text = l_Version.Text + MainForm.version;
            UpdatePresetCB();
            connectTimer = new Timer();
            connectTimer.Interval = 1000;
            connectTimer.Tick += new EventHandler(ConnectTimerCallback);

            pelcoIdTimer = new Timer();
            pelcoIdTimer.Interval = 500;
            pelcoIdTimer.Tick += new EventHandler(PelcoIDTimerCallback);

            ButtonsCommand.Items.Add(" ");

            for (int i = 0; i < 200; i++)
                ButtonsCommand.Items.Add("Preset " + (i + 1).ToString());

        }

        public async Task PopulateSettingText() {
            try {
                tB_IPCon_Adr.Text = ConfigControl.savedIP.stringVal;
                tB_IPCon_Port.Text = ConfigControl.savedPort.stringVal;
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

                check_Other_AutoPlay.Checked = ConfigControl.autoPlay.boolVal;
                check_Other_AutoReconnect.Checked = ConfigControl.autoReconnect.boolVal;
                check_AddressInvalid.Checked = ConfigControl.ignoreAddress.boolVal;
                check_Paths_Manual.Checked = ConfigControl.automaticPaths.boolVal;
                cB_IPCon_ForceMode.Enabled = ConfigControl.forceCamera.boolVal;
                check_IPCon_ForceCam.Checked = ConfigControl.forceCamera.boolVal;
                check_Other_Aspect.Checked = ConfigControl.maintainAspectRatio.boolVal;
                cB_IPCon_ForceMode.Text = ConfigControl.forceType.stringVal;
                cB_Other_PlayerCount.Text = ConfigControl.playerCount.stringVal;

                Tools.CheckIfExists(tB_Paths_sCFolder, l_Paths_sCCheck);
                Tools.CheckIfExists(tB_Paths_vFolder, l_Paths_vCheck);

                MainForm.m.Width = ConfigControl.startupWidth.intVal;
                MainForm.m.Height = ConfigControl.startupHeight.intVal;
                l_Other_CurrentResolution.Text = "Current MainForm resolution: " + MainForm.m.Width.ToString() + "x" + MainForm.m.Height.ToString();
                l_Paths_Dir.Text = "Current Directory: " + ConfigControl.appFolder;

                l_IPCon_PelcoID.Text = "Pelco ID: " + ConfigControl.pelcoID.stringVal;

                UpdateSelectedCam(false);
                MainForm.m.custom.UpdateButtonNames();
                UpdateCamType();
                UpdateRatioLabel();
            }catch (Exception e) {
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
                PopulateSettingText();
            }
        }

        private void check_Other_AutoPlay_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.autoPlay.UpdateValue(check_Other_AutoPlay.Checked.ToString());
        }

        private void check_Paths_Manual_CheckedChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

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

        private void tB_IPCon_Adr_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) { //bug with using arrow keys + enter to close error
                ConnectToCamera(true);
                connectTimer.Stop();
            } else
                DoConnectTimer();
        }

        void DoConnectTimer() {
            if (connectTimer.Enabled)
                connectTimer.Stop();

            connectTimer.Start();
        }

        void ConnectTimerCallback(object sender, EventArgs e) {
            try {
                connectTimer.Stop();

                IPAddress parsed;
                if (IPAddress.TryParse(tB_IPCon_Adr.Text, out parsed)) {
                    ConnectToCamera(false);
                } else {
                    OtherCamCom.LabelDisplay(false);
                }
            } catch {
                OtherCamCom.LabelDisplay(false);
            }
        }

        private void cB_ipCon_CamType_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateID(cB_ipCon_CamType);
        }

        private void cB_ipCon_CamType_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                UpdateID(cB_ipCon_CamType);
                connectTimer.Stop();
            } else
                DoIDTimer();
        }

        void DoIDTimer() {
            if (pelcoIdTimer.Enabled)
                pelcoIdTimer.Stop();

            pelcoIdTimer.Start();
        }

        void PelcoIDTimerCallback(object sender, EventArgs e) {
            pelcoIdTimer.Stop();
            UpdateID(cB_ipCon_CamType);
        }

        public void UpdateID(ComboBox cb) {
            ConfigControl.pelcoID.UpdateValue(UserPresets.GetPelcoID(cb.Text).ToString());
            ConfigControl.selectedPresetName.UpdateValue(cb.Text.ToString());
            if (cb == cB_ipCon_CamType)
                MainForm.m.mainPlayer.settings.UpdateMode();
            else
                cB_ipCon_CamType.Text = ConfigControl.selectedPresetName.stringVal;

            l_IPCon_PelcoID.Text = "Pelco ID: " + ConfigControl.pelcoID.stringVal;
        }

        async Task ConnectToCamera(bool showErrors) {
            connectTimer.Stop();

            ConfigControl.savedIP.UpdateValue(tB_IPCon_Adr.Text);
            if (await AsyncCamCom.TryConnect(showErrors).ConfigureAwait(false)) {
                if (!MainForm.m.lite)
                    return;

                if (ConfigControl.autoReconnect.boolVal && MainForm.m.mainPlayer.settings.tB_PlayerD_Adr.Text != ConfigControl.savedIP.stringVal) {
                    MainForm.m.mainPlayer.settings.tB_PlayerD_Adr.Text = ConfigControl.savedIP.stringVal;
                    MainForm.m.mainPlayer.Play(false);
                }
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
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.autoReconnect.UpdateValue(check_Other_AutoReconnect.Checked.ToString());
        }

        public async Task UpdateSelectedCam(bool play) {
            cB_ipCon_CamType.Text = ConfigControl.selectedPresetName.stringVal;

            if (MainForm.m.lite) {
                MainForm.m.b_PTZ_Daylight.BackColor = System.Drawing.Color.Silver;
                MainForm.m.b_PTZ_Thermal.BackColor = System.Drawing.Color.Silver;
                MainForm.m.b_PTZ_Daylight.Visible = true;
                MainForm.m.b_PTZ_Thermal.Visible = true;

                if (ConfigControl.pelcoID.intVal == 1)
                    MainForm.m.b_PTZ_Daylight.BackColor = System.Drawing.Color.LightGreen;
                else if (ConfigControl.pelcoID.intVal == 2)
                    MainForm.m.b_PTZ_Thermal.BackColor = System.Drawing.Color.LightGreen;
                else {
                    MainForm.m.b_PTZ_Daylight.Visible = false;
                    MainForm.m.b_PTZ_Thermal.Visible = false;
                }
            }

            //if (play && AsyncCamCom.sock.Connected && !MainForm.m.lite) { //cb is changed
            //    MainForm.m.mainPlayer.settings.UpdateSettingsMode();
            //}
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
            if (!MainForm.m.finishedLoading)
                return;
            ConfigControl.ignoreAddress.UpdateValue(check_AddressInvalid.Checked.ToString());
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
            l_Other_Ratio.Text = "(" + Math.Round(MainForm.m.currentAspectRatio,3).ToString() + ":1)";
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

        private void cB_Other_PlayerCount_SelectedIndexChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            ConfigControl.playerCount.UpdateValue(cB_Other_PlayerCount.Text);
            MainForm.m.AttachPlayers();
        }

        private void b_IPCon_EditCamType_Click(object sender, EventArgs e) {
            MainForm.m.up.Show();
        }

        public void AddPresetOption(DataGridViewRow row) {
            cB_ipCon_CamType.Items.Add(row.Cells[0].Value);
        }

        public void RemovePresetOption(DataGridViewRow row) {
            if(cB_ipCon_CamType.Items.Contains(row.Cells[0].Value))
                cB_ipCon_CamType.Items.Remove(row.Cells[0].Value);
        }

        public void EditPresetOption(DataGridViewRow row, DataGridViewRow oldRow) {
            int index = -1;
            if (cB_ipCon_CamType.Items.Contains(oldRow.Cells[0].Value))
                index = cB_ipCon_CamType.Items.IndexOf(oldRow.Cells[0].Value);

            if (index == -1)
                cB_ipCon_CamType.Items.Add(row.Cells[0].Value);
            else
                cB_ipCon_CamType.Items[index] = row.Cells[0].Value;
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

                if (e.ColumnIndex == 0)
                    custom.UpdateButtonNames();
                else if (e.ColumnIndex == 1) {
                    AddToOptions(val);
                    row.SetValues(row.Cells[0].Value, val);
                }
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

            string val = "";
            if (dgv_Custom_Buttons.Rows[pos].Cells[0].Value != null)
                val = dgv_Custom_Buttons.Rows[pos].Cells[0].Value.ToString();

            MainForm.m.custom.AddButton(val);
        }

    }
}
