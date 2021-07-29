using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class VideoSettings : Form {

        public Detached myDetached;
        public TabPage myLinkedMainPage;

        public List<Detached> attachedList = new List<Detached>();

        public int channelID = -1;
        public bool isMainPlayer;
        public bool isAttached = false;

        RTSPWizard myWiz;

        public VideoSettings(Detached d, bool isMain) {
            InitializeComponent();

            myDetached = d;
            isMainPlayer = isMain;

            if (!isMain)
                tP_Main.Text = "Detached Player";

            myWiz = new RTSPWizard(this);
        }

        public static void SwapSettings(VideoSettings second) {
            //try {
            //    VideoSettings main = MainForm.m.mainPlayer.settings;

            //    VideoSettings tempSettings = new VideoSettings(null, false);

            //    main.myDetached.StopPlaying();
            //    second.myDetached.StopPlaying();

            //    CopySettings(tempSettings, main, CopyType.CopyFull); //temp save old settings
            //    CopySettings(main, second, CopyType.CopyFull);
            //    CopySettings(second, tempSettings, CopyType.CopyFull);

            //    main.myDetached.Play(false);
            //    second.myDetached.Play(false);

            //    tempSettings.Dispose();

            //    //if (OtherCamCom.PingAdr(main.tB_PlayerD_Adr.Text).Result && ConfigControl.autoReconnect.boolVal) {
            //    //    MainForm.m.setPage.tB_IPCon_Adr.Text = main.tB_PlayerD_Adr.Text;
            //    //    MainForm.m.setPage.cB_ipCon_CamType.Text = main.cB_PlayerD_CamType.Text;
                    
            //    //    ConfigControl.savedIP.UpdateValue(main.tB_PlayerD_Adr.Text);

            //    //    AsyncCamCom.TryConnect(false, null, true);
            //    //}

            //} catch (Exception e) {
            //    MessageBox.Show("Swap Fail\n" + e.ToString());
            //}
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
                        copyC = copyCb;
                    } else if (c.GetType() == typeof(ComboBox)) {
                        ComboBox cb = new ComboBox();
                        ComboBox copyCB = new ComboBox();
                        cb = (ComboBox)c;

                        foreach (var entry in cb.Items)
                            copyCB.Items.Add(entry);

                        copyC = copyCB;
                        copyCB.SelectedIndexChanged += (s, e) => { 
                            originalSets.UpdateField(copyC, originalSets, originalSets.tP_Main);
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

                FindControl(tp, mainSettings.b_Play).Click += (s, e) => {
                    originalSets.myDetached.Play(true, originalSets.isMainPlayer);
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

        private void b_Edit_Click(object sender, EventArgs e) {

        }

        private void b_Play_Click(object sender, EventArgs e) {
            myDetached.Play(true, isMainPlayer);
        }

        private void b_Stop_Click(object sender, EventArgs e) {
            myDetached.StopPlaying();
        }

        public void UpdateField(Control senderControl, VideoSettings sets, TabPage tp, bool noUpdate = false) {
            try {
                foreach (Control tabPageControl in tp.Controls) {
                    if (tabPageControl.Name == senderControl.Name) {
                        tabPageControl.Text = senderControl.Text;
                        break;
                    }
                }
            } catch (Exception e){
                Tools.ShowPopup("Updating player field failed!\nShow more?", "Error Occurred!", e.ToString());
            }
        }
        private void VideoSettings_VisibleChanged(object sender, EventArgs e) {
            if (!MainForm.m.finishedLoading)
                return;

            if (isMainPlayer)
                AddPages();
        }

        private void VideoSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        public string GetName() {
            return myLinkedMainPage.Name;
        }

        public string GetRTSPIP() {
            return myWiz.tB_Adr.Text;
        }

        public string GetCombined() {
            return myWiz.GetCombined();
        }

    }
}

