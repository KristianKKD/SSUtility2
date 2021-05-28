using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class VideoSettings : Form {

        public enum CopyType {
            CopyFull,
            CopyAsSecondary,
            NoCopy,
        }

        public Detached myDetached;
        public TabPage myLinkedMainPage;

        public List<Detached> attachedList = new List<Detached>();

        public const string dayRTSP = "videoinput_1:0/h264_1/onvif.stm";
        public const string thermalRTSP = "videoinput_2:0/h264_1/onvif.stm";

        const int minExtendedHeight = 375;
        const int minSimpleHeight = 275;

        public int channelID = -1;
        public bool isMainPlayer;
        public bool isAttached = false;

        public bool customName = false;
        public bool customFull = false;

        public static Control[] extendedControls;

        public VideoSettings(Detached d, bool isMain) {
            InitializeComponent();

            if (d == null)
                return;

            myDetached = d;
            isMainPlayer = isMain;

            Size = new Size(500, minSimpleHeight);
            MinimumSize = new Size(500, minSimpleHeight);
            MaximumSize = new Size(9999, MinimumSize.Height);

            extendedControls = new Control[] {
                tB_PlayerD_RTSP,
                tB_PlayerD_Buffering,
                tB_PlayerD_Username,
                tB_PlayerD_Password,

                l_PlayerD_RTSP,
                l_PlayerD_Buffering,
                l_PlayerD_Username,
                l_PlayerD_Password,
            };

            if (!isMain)
                tP_Main.Text = "Detached Player";

            GetCombined();
        }

        public static void SwapSettings(VideoSettings second) {
            try {
                VideoSettings main = MainForm.m.mainPlayer.settings;

                VideoSettings tempSettings = new VideoSettings(null, false);

                main.myDetached.StopPlaying();
                second.myDetached.StopPlaying();

                CopySettings(tempSettings, main, CopyType.CopyFull); //temp save old settings
                CopySettings(main, second, CopyType.CopyFull);
                CopySettings(second, tempSettings, CopyType.CopyFull);

                main.myDetached.Play(false);
                second.myDetached.Play(false);

                tempSettings.Dispose();

                if (OtherCamCom.PingAdr(main.tB_PlayerD_Adr.Text).Result && ConfigControl.autoReconnect.boolVal) {
                    MainForm.m.setPage.tB_IPCon_Adr.Text = main.tB_PlayerD_Adr.Text;
                    MainForm.m.setPage.cB_ipCon_CamType.Text = main.cB_PlayerD_CamType.Text;
                    
                    ConfigControl.savedIP.UpdateValue(main.tB_PlayerD_Adr.Text);

                    AsyncCamCom.TryConnect(false, null, true);
                }

            } catch (Exception e) {
                MessageBox.Show("Swap Fail\n" + e.ToString());
            }
        }
  
        private void VideoSettings_VisibleChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            GetCombined();
            
            if (!isMainPlayer && isAttached)
                b_PlayerD_Detach.Show();

            if (isMainPlayer) 
                AddPages();
            else if (myLinkedMainPage == null)
                MainForm.m.mainPlayer.settings.AddPages();
        }

        public void AddPages() {
            foreach (TabPage tp in tC_PlayerSettings.TabPages) {
                if (tp == tP_Main)
                    continue;

                tp.Dispose();
            }

            foreach (Detached d in myDetached.attachedPlayers) { //order them based on name later
                TabPage tp = CopyPage(d.settings);
                tp.Text = d.settings.tP_Main.Text;
                tC_PlayerSettings.TabPages.Add(tp);
                d.settings.myLinkedMainPage = tp;
            }
        }

        public static TabPage CopyPage(VideoSettings originalSets) {
            TabPage tp = new TabPage();

            try {
                VideoSettings mainSettings = MainForm.m.mainPlayer.settings;

                tp.Size = mainSettings.tP_Main.Size;

                foreach (Control c in mainSettings.tP_Main.Controls) {
                    Control copyC = null;

                    if (c.GetType() == typeof(TextBox)) {
                        copyC = new TextBox();
                    } else if (c.GetType() == typeof(Label)) {
                        Label copyL = new Label();

                        Label l = new Label();
                        l = (Label)c;

                        copyL.AutoSize = true;
                        copyC = copyL;
                    } else if (c.GetType() == typeof(CheckBox)) {
                        CheckBox copyCb = new CheckBox();

                        CheckBox cb = new CheckBox();
                        cb = (CheckBox)c;

                        copyCb.Checked = cb.Checked;
                        copyCb.AutoSize = true;
                        copyCb.CheckedChanged += (s, e) => {
                            ExtendFields(tp, copyCb.Checked, mainSettings);
                        };
                        copyC = copyCb;
                    } else if (c.GetType() == typeof(ComboBox)) {
                        ComboBox cb = new ComboBox();
                        ComboBox copyCB = new ComboBox();
                        cb = (ComboBox)c;

                        foreach (var entry in cb.Items) {
                            copyCB.Items.Add(entry);
                        }

                        copyC = copyCB;
                        copyC.Text = originalSets.cB_PlayerD_CamType.Text; //because cb text should be inverted to main
                        copyCB.SelectedIndexChanged += (s, e) => { 
                            CameraCBType(tp); 
                        };
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
                        copyC.Visible = c.Visible;
                        copyC.Name = c.Name;
                        copyC.BackColor = c.BackColor;

                        if (copyC.GetType() == typeof(ComboBox) || copyC.GetType() == typeof(TextBox)) {
                            copyC.KeyUp += (s, e) => {
                                originalSets.UpdateField(copyC, originalSets, originalSets.tP_Main);
                                originalSets.GetCombined();

                                if (copyC.Name == FindControl(tp, mainSettings.tB_PlayerD_Name).Name)
                                    originalSets.UpdateName(copyC);
                                else if (copyC.Name == FindControl(tp, mainSettings.tB_PlayerD_SimpleAdr).Name)
                                    originalSets.UpdateCustomFull(copyC);
                            };
                        } else if (copyC.GetType() != typeof(ComboBox))
                            copyC.Text = c.Text;

                        if (copyC.GetType() == typeof(Button))
                            copyC.Visible = true;

                        foreach (TextBox sourceTB in Tools.GetAllType(originalSets, typeof(TextBox))) {
                            if (copyC.Name == sourceTB.Name) {
                                copyC.Text = sourceTB.Text;
                                break;
                            }
                        }

                        tp.Controls.Add(copyC);
                    }

                }

                FindControl(tp, mainSettings.b_PlayerD_Play).Click += (s, e) => {
                    originalSets.myDetached.Play(true, originalSets.isMainPlayer);
                };
                FindControl(tp, mainSettings.b_PlayerD_Stop).Click += (s, e) => {
                    originalSets.myDetached.StopPlaying();
                };
                FindControl(tp, mainSettings.b_PlayerD_Detach).Click += (s, e) => {
                    MainForm.m.mainPlayer.Detach(originalSets.myDetached, false);
                    mainSettings.Hide();
                };

                tp.BackColor = mainSettings.tP_Main.BackColor;
            } catch (Exception e) {
                MessageBox.Show("SPAWN TAB\n" + e.ToString());
            }
            return tp;
        }

        public static void CopySettings(VideoSettings target, VideoSettings source, CopyType type) {
            try {
                VideoSettings mainSets = MainForm.m.mainPlayer.settings;

                string sourceCB = FindControl(source.tP_Main, mainSets.cB_PlayerD_CamType).Text;

                switch (type) {
                    case CopyType.CopyFull:
                        target.cB_PlayerD_CamType.Text = sourceCB;
                        target.tB_PlayerD_RTSP.Text = FindControl(source.tP_Main, mainSets.tB_PlayerD_RTSP).Text;
                        break;
                    case CopyType.CopyAsSecondary:
                        ComboBox cb = (ComboBox)FindControl(target.tP_Main, mainSets.cB_PlayerD_CamType);
                        TextBox tb = (TextBox)FindControl(target.tP_Main, mainSets.tB_PlayerD_RTSP);
                        if (sourceCB.ToLower().Contains("daylight")) {
                            cb.SelectedIndex = 1;
                            tb.Text = thermalRTSP;
                        } else if (sourceCB.ToLower().Contains("thermal")) {
                            cb.SelectedIndex = 0;
                            tb.Text = dayRTSP;
                        } else {
                            cb.Text = sourceCB;
                            tb.Text = FindControl(source.tP_Main, mainSets.tB_PlayerD_RTSP).Text;
                        }
                        break;
                    case CopyType.NoCopy:
                        return;
                }

                foreach (TextBox targetTB in Tools.GetAllType(target.tP_Main, typeof(TextBox))) {
                    foreach (TextBox sourceTB in Tools.GetAllType(source.tP_Main, typeof(TextBox))) {
                        if (targetTB.Name == sourceTB.Name && targetTB.Name != target.tB_PlayerD_RTSP.Name) {
                            targetTB.Text = sourceTB.Text;
                            break;
                        }
                    }
                }

                target.GetCombined();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            };
        }

        public string GetCombined() {
            string full = "";

            try {
                string ipaddress = FindControl(tP_Main, tB_PlayerD_Adr).Text;

                if (customFull) {
                    full = FindControl(tP_Main, tB_PlayerD_SimpleAdr).Text;
                } else {
                    full = GetFullAdr();
                    FindControl(tP_Main, tB_PlayerD_SimpleAdr).Text = full;
                }

                if (!customName)
                    FindControl(tP_Main, tB_PlayerD_Name).Text = ipaddress;

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            };

            return full;
        }

        string GetFullAdr() {
            string ipaddress = FindControl(tP_Main, tB_PlayerD_Adr).Text;
            string port = FindControl(tP_Main, tB_PlayerD_Port).Text;
            string url = FindControl(tP_Main, tB_PlayerD_RTSP).Text;
            string username = FindControl(tP_Main, tB_PlayerD_Username).Text;
            string password = FindControl(tP_Main, tB_PlayerD_Password).Text;

            return "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
        }

        public bool AdrValid(bool showErrors) {
            try {
                Uri newUri = null;
                string errorMsg = "";

                try {
                    newUri = new Uri(tB_PlayerD_SimpleAdr.Text);
                } catch {
                    errorMsg = "Address was invalid!\n";
                }

                if (newUri != null && !ConfigControl.ignoreAddress.boolVal 
                    && !customFull && isMainPlayer) {
                    if (!OtherCamCom.PingAdr(newUri.Host).Result) {
                        errorMsg += "Address had no RTSP stream attached!\n";
                    }
                }

                if (errorMsg != "") {
                    if (showErrors)
                        MessageBox.Show(errorMsg);
                    return false;
                }

                return true;
            } catch (Exception e) {
                if (showErrors)
                    Tools.ShowPopup("Failed to parse address!\nShow more?", "Error Occurred!", e.ToString());
                return false;
            }
        }

        private void VideoSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void cB_PlayerD_Type_SelectedIndexChanged(object sender, EventArgs e) {
            CameraCBType(tP_Main);
        }

        public static void CameraCBType(TabPage tp) {
            try {
                VideoSettings refSets = MainForm.m.mainPlayer.settings;

                string enc = FindControl(tp, refSets.cB_PlayerD_CamType).Text;
                string username = "";
                string password = "";
                string rtsp = "";

                if (enc.Contains("Daylight")) {
                    username = "admin";
                    password = "admin";
                    rtsp = "videoinput_1:0/h264_1/onvif.stm";
                } else if (enc.Contains("Thermal")) {
                    username = "admin";
                    password = "admin";
                    rtsp = "videoinput_2:0/h264_1/onvif.stm";
                } else if (enc.Contains("VIVOTEK")) {
                    username = "root";
                    password = "root1234";
                    rtsp = "live.sdp";
                } else if (enc.Contains("BOSCH")) {
                    username = "service";
                    password = "Service123!";
                    rtsp = "";
                }

                FindControl(tp, refSets.tB_PlayerD_RTSP).Text = rtsp;
                FindControl(tp, refSets.tB_PlayerD_Username).Text = username;
                FindControl(tp, refSets.tB_PlayerD_Password).Text = password;


                VideoSettings vs = (VideoSettings)tp.Parent.Parent;
                vs.GetCombined();
            } catch (Exception e) {
                MessageBox.Show("SELECTINDEX\n" + e.ToString());
            }
        }

        static Control FindControl(TabPage tp, object reference) {
            foreach (Control c in Tools.GetAllType(tp, reference.GetType())){
                Control refCopy = (Control)reference;
                if (c.Name == refCopy.Name) {
                    return c;
                }
            }

            return null;
        }

        private void check_PlayerD_Manual_CheckedChanged(object sender, EventArgs e) {
            ExtendFields(tP_Main, check_PlayerD_Manual.Checked, this);
        }

        static void ExtendFields(TabPage tp, bool check, VideoSettings sets) {
            foreach (Control c in tp.Controls) {
                foreach (Control eC in extendedControls) {
                    if (eC.Name == c.Name)
                        c.Visible = check;
                }
            }

            foreach (TabPage t in sets.tC_PlayerSettings.TabPages) {
                CheckBox cb = (CheckBox)FindControl(t, sets.check_PlayerD_Manual);
                cb.Checked = check;
            }

            if (check) {
                if (sets.Height < minExtendedHeight) {
                    sets.Height = minExtendedHeight;
                }
                sets.MinimumSize = new Size(500, minExtendedHeight);
            } else {
                sets.MinimumSize = new Size(500, minSimpleHeight);
                sets.Height -= 100;
            }
            sets.MaximumSize = new Size(9999, sets.MinimumSize.Height);
        }

        private void b_PlayerD_Play_Click(object sender, EventArgs e) {
            myDetached.Play(true, isMainPlayer);
        }

        private void b_PlayerD_Stop_Click(object sender, EventArgs e) {
            myDetached.StopPlaying();
        }

        private void Fields_Any_Click(object sender, MouseEventArgs e) {
            customFull = false;
        }

        private void tB_PlayerD_Name_KeyUp(object sender, EventArgs e) {
            UpdateName(sender);   
        }

        void UpdateName(object sender) {
            string name = FindControl(tP_Main, tB_PlayerD_Name).Text.Trim();
            if (name.Length == 0 || name == FindControl(tP_Main, tB_PlayerD_Adr).Text) {
                customName = false;
            } else {
                customName = true;
            }

            if (!isMainPlayer)
                UpdateField((Control)sender, this, myLinkedMainPage);
        }

        private void AddressField_KeyUp(object sender, KeyEventArgs e) {
            if (!isMainPlayer && myLinkedMainPage != null) {
                UpdateField((Control)sender, this, myLinkedMainPage);
            }

            GetCombined();
        }

        public void UpdateMode() {
            int val = ConfigControl.pelcoID.intVal;
            ComboBox cb = (ComboBox)FindControl(tP_Main, cB_PlayerD_CamType);
            TextBox tb = (TextBox)FindControl(tP_Main, tB_PlayerD_RTSP);

            if (val == 1) {
                cb.SelectedIndex = 1;
                tb.Text = thermalRTSP;
            } else if (val == 2) {
                cb.SelectedIndex = 0;
                tb.Text = dayRTSP;
            }

            myDetached.Play(false, false);
        }

        private void b_PlayerD_Detach_Click(object sender, EventArgs e) {
            MainForm.m.mainPlayer.Detach(myDetached, false);
            b_PlayerD_Detach.Visible = false;
            Hide();
            MainForm.m.mainPlayer.settings.Hide();
        }

        private void tB_PlayerD_SimpleAdr_KeyUp(object sender, KeyEventArgs e) {
            UpdateCustomFull(sender);
        }

        void UpdateCustomFull(object sender) {
            string val = FindControl(tP_Main, tB_PlayerD_SimpleAdr).Text.Trim();

            if (val == "" || val == GetFullAdr())
                customFull = false;
            else
                customFull = true;

            if (!isMainPlayer) {
                UpdateField((Control)sender, this, myLinkedMainPage);
                GetCombined();
            }
        }

        public void UpdateField(Control senderControl, VideoSettings sets, TabPage tp) {
            try {
                foreach (Control tabPageControl in tp.Controls) {
                    if (tabPageControl.Name == senderControl.Name) {
                        tabPageControl.Text = senderControl.Text;
                        break;
                    }
                }

                FindControl(tp, sets.tB_PlayerD_SimpleAdr).Text = sets.GetCombined();
                FindControl(tp, sets.tB_PlayerD_Name).Text = sets.tB_PlayerD_Name.Text;
            } catch (Exception e){
                Tools.ShowPopup("Updating player field failed!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        public List<(string, string)> SaveToConfig() {
            List<(string, string)> varList = new List<(string, string)>();

            Control[] saveList = {
                tB_PlayerD_Name,
                tB_PlayerD_SimpleAdr,
                cB_PlayerD_CamType,
                tB_PlayerD_Adr,
                tB_PlayerD_Port,
                tB_PlayerD_Buffering,
                tB_PlayerD_Username,
                tB_PlayerD_Password,

            };

            foreach (Control c in saveList) {
                varList.Add((c.Name, FindControl(tP_Main, c).Text));
            }

            varList.Add(("CUSTOMNAME", customName.ToString()));
            varList.Add(("CUSTOMFULL", customFull.ToString()));

            varList.Add((tP_Main.Text, varList.Count.ToString())); //needs to be first so reverse the list

            varList.Reverse();
            return varList;
        }

        public void LoadConfig(List<ConfigVar> configList) {
            for (int i = 0; i < configList.Count; i++) {
                ConfigVar v = configList[i];
                foreach (Control c in tP_Main.Controls) {
                    if (v.name == c.Name) {
                        c.Text = v.value;
                        break;
                    } else if (v.name.ToLower() == "customname") {
                        customName = ConfigSetting.CheckVal(v.value);
                        break;
                    }
                    else if (v.name.ToLower() == "customfull") {
                        customName = ConfigSetting.CheckVal(v.value);
                        break;
                    }
                }
            }

            if(ConfigControl.autoPlay.boolVal)
                myDetached.Play(false, false);
        }

    }
}

