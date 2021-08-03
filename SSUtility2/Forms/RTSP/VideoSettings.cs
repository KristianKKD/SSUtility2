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

        Timer updateControl;

        public VideoSettings(Detached d, bool isMain) {
            InitializeComponent();

            updateControl = new Timer();
            updateControl.Interval = 1000;
            updateControl.Tick += new EventHandler(UpdateControlCallback);

            myDetached = d;
            isMainPlayer = isMain;

            if (!isMain)
                tP_Main.Text = "Detached Player";

            allSettings.Add(this);
            if (!isMainPlayer) {
                UpdateSinglePresetBox(this);
                MinimumSize = new Size(Width, 120);
                MaximumSize = new Size(Width, 120);
            }
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
            tp.Text = d.settings.tP_Main.Text;
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
                    } if (c.GetType() == typeof(ComboBox)) {
                        ComboBox cb = new ComboBox();
                        ComboBox copyCB = new ComboBox();
                        cb = (ComboBox)c;

                        foreach (var entry in cb.Items)
                            copyCB.Items.Add(entry);

                        copyC = copyCB;
                        copyCB.SelectedIndexChanged += (s, e) => {
                            originalSets.cB_RTSP.SelectedIndex = copyCB.SelectedIndex;
                        };

                        copyCB.FlatStyle = cb.FlatStyle;
                        copyCB.DropDownStyle = cb.DropDownStyle;
                        copyCB.SelectedIndex = cb.SelectedIndex;
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

                       if (copyC.GetType() != typeof(ComboBox))
                            copyC.Text = c.Text;

                        tp.Controls.Add(copyC);
                    }

                }

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

        //public static void CopySettings(VideoSettings target, VideoSettings source, CopyType type) {
        //    try {
        //        VideoSettings mainSets = MainForm.m.mainPlayer.settings;

        //        //string sourceCB = FindControl(source.tP_Main, mainSets.cB_PlayerD_CamType).Text;

        //        switch (type) {
        //            case CopyType.CopyFull:
        //                //target.cB_PlayerD_CamType.Text = sourceCB;
        //                break;
        //            case CopyType.NoCopy:
        //                return;
        //        }

        //        foreach (TextBox targetTB in Tools.GetAllType(target.tP_Main, typeof(TextBox))) {
        //            foreach (TextBox sourceTB in Tools.GetAllType(source.tP_Main, typeof(TextBox))) {
        //                if (targetTB.Name == sourceTB.Name) {
        //                    targetTB.Text = sourceTB.Text;
        //                    break;
        //                }
        //            }
        //        }

        //        //target.GetCombined();
        //    } catch (Exception e) {
        //        MessageBox.Show(e.ToString());
        //    };
        //}

        static Control FindControl(TabPage tp, object reference) {
            foreach (Control c in Tools.GetAllType(tp, reference.GetType())){
                Control refCopy = (Control)reference;
                if (c.Name == refCopy.Name) {
                    return c;
                }
            }

            return null;
        }

        static void UpdateSinglePresetBox(VideoSettings vs) {
            int oldVal = vs.cB_RTSP.SelectedIndex;

            vs.cB_RTSP.Items.Clear();
            foreach (string s in RTSPPresets.GetPresetList())
                vs.cB_RTSP.Items.Add(s);

            vs.cB_RTSP.Items.Add("Add New...");

            if (oldVal <= vs.cB_RTSP.Items.Count - 2)
                vs.cB_RTSP.SelectedIndex = oldVal;
        }

        public static void UpdateAllPresetBoxes() {
            foreach (VideoSettings vs in allSettings)
                UpdateSinglePresetBox(vs);
        }

        private void b_Edit_Click(object sender, EventArgs e) {
            string rtspName = cB_RTSP.Text;
            if (rtspName.Length > 0 && rtspName.Trim().Length > 0) {
                RTSPPresets.OpenPreset(cB_RTSP.Text, this);
                return;
            }
        }

        private void b_Play_Click(object sender, EventArgs e) {
            myDetached.Play(true, false);
        }

        private void b_Stop_Click(object sender, EventArgs e) {
            myDetached.StopPlaying();
        }

        private void cB_RTSP_SelectedIndexChanged(object sender, EventArgs e) {
            if (cB_RTSP.Text == "") {
                toolTip1.SetToolTip(cB_RTSP, "Select a camera preset");
                return;
            }

            bool visibleBool = false;

            if (cB_RTSP.SelectedIndex == cB_RTSP.Items.Count - 1) {
                cB_RTSP.Text = "";
                RTSPPresets.CreateNew(this);
            } else {
                //Use new settings
                visibleBool = true;
                myDetached.Play(false, false);

                CompleteControlValues();
            }

            b_Edit.Visible = visibleBool;
            b_Play.Visible = visibleBool;
            b_Stop.Visible = visibleBool;

            if (isMainPlayer)
                ConfigControl.mainPlayerPreset.UpdateValue(cB_RTSP.Text);
            else if (myLinkedPage != null) {
                foreach (Control c in myLinkedPage.Controls) {
                    if (c.GetType() == typeof(Button))
                        c.Visible = visibleBool;
                    else if (c.GetType() == typeof(ComboBox)) {
                        ComboBox cb = (ComboBox)c;
                        cb.SelectedIndex = cB_RTSP.SelectedIndex;
                    }

                }
            }

            string fullAdr = RTSPPresets.GetValue(PresetColumn.FullAdr, cB_RTSP.Text);
            toolTip1.SetToolTip(cB_RTSP, fullAdr);
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
                port = MainForm.m.setPage.tB_IPCon_Port.Text;

            cB_ID.Text = id;
            tB_IP.Text = ip;
            tB_Port.Text = port;
        }

        private void VideoSettings_VisibleChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;
        }

        private void VideoSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        public string GetTabName() {
            if (isMainPlayer)
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
            string val = RTSPPresets.GetValue(PresetColumn.PelcoID, cB_RTSP.Text);
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

            MainForm.m.setPage.tB_IPCon_Adr.Text = tB_IP.Text; //changing these triggers settings page timer, needs fix
            MainForm.m.setPage.tB_IPCon_Port.Text = tB_Port.Text;

            AsyncCamCom.TryConnect(false);

            updateControl.Stop();
        }

        private void check_Manual_CheckedChanged(object sender, EventArgs e) {
            bool enabled = check_Manual.Checked;

            l_PelcoID.Enabled = enabled;
            cB_ID.Enabled = enabled;

            l_IP.Enabled = enabled;
            tB_IP.Enabled = enabled;

            l_Port.Enabled = enabled;
            tB_Port.Enabled = enabled;
        }

    }
}

