using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SSUtility2.RTSPPresets;

namespace SSUtility2 {
    public partial class VideoSettings : Form {

        public static List<VideoSettings> allSettings;

        public Detached myDetached;
        public TabPage myLinkedPage;

        public List<Detached> attachedList = new List<Detached>();

        public int channelID = -1;
        public bool isMainPlayer;
        public bool isAttached = false;
        public bool refreshBox = true; //trigger cB_RTSP selectindex update

        Timer updateControl;
        Timer cursorTimer;

        public VideoSettings(Detached d, bool isMain) {
            InitializeComponent();

            updateControl = new Timer();
            updateControl.Interval = 1000;
            updateControl.Tick += new EventHandler(UpdateControlCallback);

            cursorTimer = new Timer();
            cursorTimer.Interval = 500;
            cursorTimer.Tick += new EventHandler(CursorTimerCallback);

            myDetached = d;
            isMainPlayer = isMain;

            if (!isMain)
                tP_Main.Text = "Detached Player";

            allSettings.Add(this);

            if (!isMainPlayer) {
                UpdateSinglePresetBox(cB_RTSP);
                MinimumSize = new Size(Width, 120);
                MaximumSize = new Size(Width, 120);
            } else {
                b_Detach.Visible = false;
                tC_PlayerSettings.SelectedIndex = 0;
            }
        }

        public void LoadTabName() {
            if (myLinkedPage != null) {
                int pageIndex = MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages.IndexOf(myLinkedPage);
                string text = "";
                if (pageIndex == 1)
                    text = ConfigControl.player2TabName.stringVal;
                else if (pageIndex == 2)
                    text = ConfigControl.player3TabName.stringVal;

                if (text == "")
                    text = "Attached Player";

                tP_Main.Text = text;
                myLinkedPage.Text = text;
            } else if (isMainPlayer) {
                tP_Main.Text = ConfigControl.mainPlayerTabName.stringVal;

                foreach (Detached d in myDetached.attachedPlayers)
                    d.settings.LoadTabName();
            }

            this.Text = tP_Main.Text + " Settings";
            myDetached.Text = tP_Main.Text;
        }

        public static void SwapSettings(VideoSettings second) {
            try {
                ComboBox mainBox = MainForm.m.mainPlayer.settings.cB_RTSP;

                int mainIndex = mainBox.SelectedIndex;
                mainBox.SelectedIndex = second.cB_RTSP.SelectedIndex;
                second.cB_RTSP.SelectedIndex = mainIndex;
            } catch (Exception e) {
                MessageBox.Show("Swap Fail\n" + e.ToString());
            }
        }

        public void AddPage(Detached d) {
            TabPage tp = CopyPage(d.settings);
            tC_PlayerSettings.TabPages.Add(tp);
            d.settings.myLinkedPage = tp;
        }

        public static TabPage CopyPage(VideoSettings originalSets) {
            TabPage tp = new TabPage();

            try {
                VideoSettings mainSettings = MainForm.m.mainPlayer.settings;

                tp.Size = mainSettings.tP_Main.Size;

                foreach (Control c in mainSettings.tP_Main.Controls) {
                    Control copyC = null;

                    if (c.GetType() == typeof(Label)) {
                        Label copyL = new Label();

                        Label l = new Label();
                        l = (Label)c;

                        copyL.AutoSize = true;
                        copyC = copyL;
                    }
                    if (c.GetType() == typeof(ComboBox)) {
                        ComboBox cb = new ComboBox();
                        ComboBox copyCB = new ComboBox();
                        cb = (ComboBox)c;

                        foreach (var entry in cb.Items)
                            copyCB.Items.Add(entry);

                        copyC = copyCB;
                        copyCB.SelectedIndexChanged += (s, e) => {
                            originalSets.cB_RTSP.SelectedIndex = copyCB.SelectedIndex;
                        };
                        copyCB.TextChanged += (s, e) => {
                            originalSets.CBTextChanged();
                        };

                        copyCB.FlatStyle = cb.FlatStyle;
                        copyCB.DropDownStyle = cb.DropDownStyle;
                    } else if (c.GetType() == typeof(Button)) {
                        Button b = new Button();
                        Button copyB = new Button();
                        b = (Button)c;

                        copyB.FlatStyle = b.FlatStyle;
                        copyC = copyB;
                    }

                    if (copyC != null) {
                        copyC.Anchor = c.Anchor;
                        copyC.Location = c.Location;
                        copyC.Size = c.Size;
                        copyC.Name = c.Name;
                        copyC.BackColor = c.BackColor;
                        copyC.Font = c.Font;
                        copyC.Visible = true;

                        if (copyC.GetType() == typeof(Button))
                            copyC.Visible = false;

                        if (copyC.GetType() != typeof(ComboBox))
                            copyC.Text = c.Text;

                        tp.Controls.Add(copyC);
                    }

                }

                FindControl(tp, mainSettings.b_Edit).Click += (s, e) => {
                    originalSets.b_Edit_Click(s, e);
                };
                FindControl(tp, mainSettings.b_Play).Click += (s, e) => {
                    originalSets.myDetached.Play(true, false);
                };
                FindControl(tp, mainSettings.b_Stop).Click += (s, e) => {
                    originalSets.myDetached.StopPlaying();
                };

                tp.BackColor = mainSettings.tP_Main.BackColor;
            } catch (Exception e) {
                MessageBox.Show("SPAWN TAB\n" + e.ToString());
            }
            return tp;
        }

        public void LoadPlayer(string presetName, bool autoPlay) {
            string indexVal = RTSPPresets.GetValue(PresetColumn.Index, presetName);
            int presetIndex = 0;
            if (indexVal != "")
                presetIndex = int.Parse(indexVal);

            if (presetIndex >= RTSPPresets.currentPresetCount) {
                presetIndex = MainForm.m.mainPlayer.attachedPlayers.IndexOf(myDetached) + 1;
                if (presetIndex >= RTSPPresets.currentPresetCount)
                    return;
            }

            cB_RTSP.SelectedIndex = presetIndex;

            if (autoPlay)
                myDetached.Play(false, false);
            if (isMainPlayer)
                MainForm.m.setPage.cB_IPCon_MainPlayerPreset.SelectedIndex = cB_RTSP.SelectedIndex;
        }

        static Control FindControl(TabPage tp, object reference) {
            foreach (Control c in Tools.GetAllType(tp, reference.GetType())) {
                Control refCopy = (Control)reference;
                if (c.Name == refCopy.Name) {
                    return c;
                }
            }

            return null;
        }

        static void UpdateSinglePresetBox(ComboBox box, VideoSettings refreshSettings = null) {
            if(refreshSettings != null)
                refreshSettings.refreshBox = false;

            int oldVal = box.SelectedIndex;
            
            box.Items.Clear();
            foreach (string s in RTSPPresets.GetPresetList())
                box.Items.Add(s);

            box.Items.Add("Add New...");

            if (oldVal <= box.Items.Count - 2)
                box.SelectedIndex = oldVal;

            if (refreshSettings != null)
                refreshSettings.refreshBox = true;
        }

        public static void UpdateAllPresetBoxes(bool force = false, bool refresh = true) {
            if (!MainForm.m.finishedLoading && !force)
                return;

            VideoSettings v = null; //if the box needs to be repopulated without triggering a selectindex update

            foreach (VideoSettings vs in allSettings) {
                if (!refresh) 
                    v = vs;

                UpdateSinglePresetBox(vs.cB_RTSP, v);
            }

            foreach (TabPage tp in MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages) {
                if (tp == MainForm.m.mainPlayer.settings.tP_Main)
                    continue;

                UpdateSinglePresetBox((ComboBox)FindControl(tp, MainForm.m.mainPlayer.settings.cB_RTSP), MainForm.m.mainPlayer.settings);
            }

            UpdateSinglePresetBox(MainForm.m.setPage.cB_IPCon_MainPlayerPreset); //need to look into what happens if this doesnt get refresh affected
        }

        private void b_Edit_Click(object sender, EventArgs e) {
            OpenEdit(this);
        }

        public static void OpenEdit(VideoSettings sets) {
            string rtspName = sets.cB_RTSP.Text;
            if (rtspName.Length > 0 && rtspName.Trim().Length > 0) {
                RTSPPresets.OpenPreset(sets.cB_RTSP.Text, sets);
                return;
            }
        }

        private void b_Play_Click(object sender, EventArgs e) {
            myDetached.Play(true, true);
        }

        private void b_Stop_Click(object sender, EventArgs e) {
            myDetached.StopPlaying();
        }

        int previousIndex = -1;
        private void cB_RTSP_SelectedIndexChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading || !refreshBox)
                return;

            previousIndex = cB_RTSP.SelectedIndex;

            if (cB_RTSP.Text == "") {
                toolTip1.SetToolTip(cB_RTSP, "Select a camera preset");
                return;
            }

            bool visibleBool = false;

            if (cB_RTSP.SelectedIndex == cB_RTSP.Items.Count - 1) {
                if (previousIndex != -1 || isMainPlayer)
                    RTSPPresets.CreateNew(this);
            } else {
                //Use new settings
                if (cB_RTSP.Text != "")
                    visibleBool = true;

                if (isMainPlayer)
                    MainForm.m.setPage.cB_IPCon_MainPlayerPreset.SelectedIndex = cB_RTSP.SelectedIndex;

                if (!check_Manual.Checked)
                    CompleteControlValues();
            }

            UpdateButtonVisibility(visibleBool);

            string rtspText = cB_RTSP.Text;
            if (isMainPlayer) {
                ConfigControl.mainPlayerPreset.UpdateValue(rtspText);
                MainForm.m.setPage.b_IPCon_Edit.Visible = visibleBool;
            } else if (myLinkedPage != null) {
                int pageIndex = MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages.IndexOf(myLinkedPage);
                if (pageIndex == 1)
                    ConfigControl.player2Preset.UpdateValue(rtspText);
                else if (pageIndex == 2)
                    ConfigControl.player3Preset.UpdateValue(rtspText);
            }

            string fullAdr = RTSPPresets.GetValue(PresetColumn.FullAdr, cB_RTSP.Text);
            toolTip1.SetToolTip(cB_RTSP, fullAdr);
            myDetached.Play(false, false);
        }

        void UpdateButtonVisibility(bool visible) {
            b_Edit.Visible = visible;
            b_Play.Visible = visible;
            b_Stop.Visible = visible;

            if (myLinkedPage == null)
                return;

            foreach (Control c in myLinkedPage.Controls) {
                if (c.GetType() == typeof(Button))
                    c.Visible = visible;
                else if (c.GetType() == typeof(ComboBox)) {
                    ComboBox cb = (ComboBox)c;
                    if (cb.SelectedIndex < cB_RTSP.Items.Count)
                        cb.SelectedIndex = cB_RTSP.SelectedIndex;
                }
            }
        }

        void CompleteControlValues() {
            string presetName = cB_RTSP.Text;
            string id = "";
            string ip = "";
            string port = "";

            if (presetName.Length > 0) {
                id = RTSPPresets.GetValue(PresetColumn.PelcoID, presetName);
                ip = RTSPPresets.GetValue(PresetColumn.ControlIP, presetName);
                port = RTSPPresets.GetValue(PresetColumn.ControlPort, presetName);
            }

            if (id == "")
                id = "0";

            if (ip == "")
                ip = MainForm.m.setPage.tB_IPCon_Adr.Text;

            if (port == "")
                port = MainForm.m.setPage.cB_IPCon_Port.Text;

            cB_ID.Text = id;
            tB_IP.Text = ip;
            cB_Port.Text = port;
        }

        private void VideoSettings_VisibleChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            UpdateAllPresetBoxes(false, false);
        }

        private void VideoSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        public string GetTabName() {
            if (myLinkedPage == null)
                return tP_Main.Text;

            return myLinkedPage.Text;
        }

        public string GetPresetName() {
            return cB_RTSP.Text;
        }

        public string GetRTSPIP() {
            return RTSPPresets.GetValue(PresetColumn.RTSPIP, cB_RTSP.Text);
        }

        public string GetCombined() {
            return RTSPPresets.GetValue(PresetColumn.FullAdr, cB_RTSP.Text);
        }

        public int GetPelcoID() {
            string val = RTSPPresets.GetValue(PresetColumn.PelcoID, ConfigControl.mainPlayerPreset.stringVal);
            int returnVal;
            if (!int.TryParse(val, out returnVal))
                returnVal = -1;

            return returnVal;
        }

        private void tB_ControlFields_TextChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            if (updateControl.Enabled)
                updateControl.Stop();

            updateControl.Start();
        }

        private async void UpdateControlCallback(object sender, EventArgs e) {
            int parsedVal;
            if (int.TryParse(cB_ID.Text, out parsedVal))
                ConfigControl.pelcoOverrideID.intVal = parsedVal;

            SettingsPage sp = MainForm.m.setPage;

            sp.tB_IPCon_Adr.Text = tB_IP.Text; //changing these triggers settings page timer
            sp.cB_IPCon_Port.Text = cB_Port.Text;
            sp.cB_IPCon_PelcoDID.Text = cB_ID.Text;

            updateControl.Stop();
        }

        private void check_Manual_CheckedChanged(object sender, EventArgs e) {
            bool enabled = check_Manual.Checked;

            l_PelcoID.Enabled = enabled;
            cB_ID.Enabled = enabled;

            l_IP.Enabled = enabled;
            tB_IP.Enabled = enabled;

            l_Port.Enabled = enabled;
            cB_Port.Enabled = enabled;

            MainForm.m.setPage.ToggleOverridePreset(enabled);

            if (!enabled) {
                string[] preset = RTSPPresets.GetPreset(ConfigControl.mainPlayerPreset.stringVal);

                tB_IP.Text = preset[TableValue(PresetColumn.ControlIP)];
                cB_Port.Text = preset[TableValue(PresetColumn.ControlPort)];
                cB_ID.Text = preset[TableValue(PresetColumn.PelcoID)];
            }
        }

        private void b_Detach_Click(object sender, EventArgs e) {
            if (isAttached)
                MainForm.m.mainPlayer.Detach(myDetached, false);
            else {
                Detached main = MainForm.m.mainPlayer;
                main.AttachPlayerToThis(myDetached, new Point((int)Math.Round(main.Width / 2f),
                    (int)Math.Round(main.Height / 2f)));
            }
        }

        private void cB_RTSP_TextChanged(object sender, EventArgs e) {
            CBTextChanged();
        }

        void CBTextChanged() {
            string text = cB_RTSP.Text.ToLower();
            UpdateButtonVisibility(text != "" && text != "add new...");
        }

        public void ToggleOverride(bool enabled) {
            check_Manual.Checked = enabled;
        }

        public static void UpdateControlFields() {
            VideoSettings vs = MainForm.m.mainPlayer.settings;
            vs.tB_IP.Text = ConfigControl.savedIP.stringVal;
            vs.cB_Port.Text = ConfigControl.savedPort.stringVal;
            vs.cB_ID.Text = Tools.MakeAdr().ToString();
        }

        public void UpdateCheckOverride(bool check) {
            check_Manual.Checked = check;
        }

        private void cB_Port_SelectedIndexChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            DelayedIndex();
        }

        async Task DelayedIndex() {
            await Task.Delay(100);
            cB_Port.Text = Tools.GetPortValueFromEncoder(cB_Port);
        }

        TabPage selectedPage;
        string cursor = "";
        private void tC_PlayerSettings_MouseDoubleClick(object sender, MouseEventArgs e) {
            selectedPage = tC_PlayerSettings.SelectedTab;
            tB_SecretNameTB.Text = "";
            selectedPage.Text = "";
            tB_SecretNameTB.Focus();
            cursorTimer.Start();
        }

        private void tC_PlayerSettings_SelectedIndexChanged(object sender, EventArgs e) {
            StopTyping();
        }

        private void tB_SecretNameTB_Leave(object sender, EventArgs e) {
            StopTyping();
        }

        private void tB_SecretNameTB_TextChanged(object sender, EventArgs e) {
            if (selectedPage == null)
                return;

            cursor = "|";
            cursorTimer.Start();

            selectedPage.Text = tB_SecretNameTB.Text + cursor;
        }

        void StopTyping() {
            cursor = "";
            cursorTimer.Stop();

            if (selectedPage != null) {
                selectedPage.Text = tB_SecretNameTB.Text;
                string currentText = selectedPage.Text;

                if (currentText != "") {
                    int pageIndex = -1;

                    if (myLinkedPage != null)
                        pageIndex = MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages.IndexOf(myLinkedPage);
                    else if (isMainPlayer)
                        pageIndex = tC_PlayerSettings.SelectedIndex;

                    if (pageIndex == 0)
                        ConfigControl.mainPlayerTabName.UpdateValue(currentText);
                    else if (pageIndex == 1)
                        ConfigControl.player2TabName.UpdateValue(currentText);
                    else if (pageIndex == 2)
                        ConfigControl.player3TabName.UpdateValue(currentText);
                }

                LoadTabName();

                selectedPage = null;
            }
        }

        void CursorTimerCallback(object sender, EventArgs e) {
            if (cursor == "")
                cursor = "|";
            else
                cursor = "";

            selectedPage.Text = tB_SecretNameTB.Text + cursor;
        }

        private void tB_SecretNameTB_KeyUp(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape))
                StopTyping();
        }

        private void VideoSettings_MouseClick(object sender, MouseEventArgs e) {
            StopTyping();
        }

        private void tP_Main_Click(object sender, EventArgs e) {
            StopTyping();
        }

        private void l_RTSP_Click(object sender, EventArgs e) {
            StopTyping();
        }

        private void tC_PlayerSettings_MouseClick(object sender, MouseEventArgs e) {
            StopTyping();
        }

    }
}

