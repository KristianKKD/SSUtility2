using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2
{
    public partial class VideoSettings : Form
    {

        public enum CopyType
        {
            CopyFull,
            CopyAsSecondary,
            NoCopy
        }

        public Detached myDetached;

        public int myAttachedIndex = 0; //0 means it is the base
        public List<Detached> attachedList = new List<Detached>();

        public const string dayRTSP = "videoinput_1:0/h264_1/onvif.stm";
        public const string thermalRTSP = "videoinput_2:0/h264_1/onvif.stm";

        const int minExtendedHeight = 375;
        const int minSimpleHeight = 275;

        public int channelID = -1;
        public bool isMainPlayer;
        public bool isAttached = false;

        Control[] extendedControls;

        Timer saveTimer;

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


            if (isMain) {
                saveTimer = new Timer();
                saveTimer.Interval = 1000;
                saveTimer.Tick += new EventHandler(SaveConfigFields);
            } else {
                tP_Main.Text = "Player " + (MainForm.m.mainPlayer.attachedPlayers.Count + 1).ToString();
            }
            GetCombined();
        }

        public void SwapSettings(VideoSettings other) {
            try {
                VideoSettings tempSettings = new VideoSettings(null, false);

                myDetached.StopPlaying();
                other.myDetached.StopPlaying();

                CopySettings(tempSettings, this, CopyType.CopyFull); //temp save old settings
                CopySettings(this, other, CopyType.CopyFull);
                CopySettings(other, tempSettings, CopyType.CopyFull);

                myDetached.Play(false);
                other.myDetached.Play(false);

                tempSettings.Dispose();

                if (OtherCamCom.PingAdr(tB_PlayerD_Adr.Text).Result) {
                    MainForm.m.setPage.tB_IPCon_Adr.Text = tB_PlayerD_Adr.Text;
                    MainForm.m.setPage.cB_ipCon_CamType.Text = cB_PlayerD_CamType.Text;
                    
                    ConfigControl.savedIP.UpdateValue(tB_PlayerD_Adr.Text);

                    AsyncCamCom.TryConnect(false, null, true);

                    SaveConfigFields(null,null);
                }

            } catch (Exception e) {
                MessageBox.Show("Swap Fail\n" + e.ToString());
            }
        }

        public static void CopySettings(VideoSettings target, VideoSettings source, CopyType type) {
            try {
                string sourceCB = source.cB_PlayerD_CamType.Text;

                switch (type) {
                    case CopyType.CopyFull:
                        target.cB_PlayerD_CamType.Text = sourceCB;
                        target.tB_PlayerD_RTSP.Text = source.tB_PlayerD_RTSP.Text;
                        break;
                    case CopyType.CopyAsSecondary:
                        if (sourceCB.ToLower().Contains("daylight")) {
                            target.cB_PlayerD_CamType.SelectedIndex = 1;
                            target.tB_PlayerD_RTSP.Text = thermalRTSP;
                        } else if (sourceCB.ToLower().Contains("thermal")) {
                            target.cB_PlayerD_CamType.SelectedIndex = 0;
                            target.tB_PlayerD_RTSP.Text = dayRTSP;
                        } else {
                            target.cB_PlayerD_CamType.Text = sourceCB;
                            target.tB_PlayerD_RTSP.Text = source.tB_PlayerD_RTSP.Text;
                        }
                        break;
                    case CopyType.NoCopy:
                        return;
                }

                foreach (TextBox targetTB in Tools.GetAllType(target, typeof(TextBox))) {
                    foreach (TextBox sourceTB in Tools.GetAllType(source, typeof(TextBox))) {
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

        public string GetCombined(bool ignoreConditions = false) {
            string full = "";

            try {
                string ipaddress = tB_PlayerD_Adr.Text;

                if (ConfigControl.mainPlayerCustomFull.boolVal && isMainPlayer && !ignoreConditions) {
                    full = tB_PlayerD_SimpleAdr.Text;
                } else {
                    string port = tB_PlayerD_Port.Text;
                    string url = tB_PlayerD_RTSP.Text;
                    string username = tB_PlayerD_Username.Text;
                    string password = tB_PlayerD_Password.Text;

                    full = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;

                    if(!ignoreConditions)
                        tB_PlayerD_SimpleAdr.Text = full;
                }

                if (ConfigControl.mainPlayerCustomName.boolVal
                    && ConfigControl.mainPlayerName.stringVal.Trim() != ""
                    && isMainPlayer && !ignoreConditions)
                    tB_PlayerD_Name.Text = ConfigControl.mainPlayerName.stringVal;
                else
                    tB_PlayerD_Name.Text = ipaddress;


            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            };

            return full;
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

                if (!ConfigControl.ignoreAddress.boolVal && isMainPlayer && newUri != null) {
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
            SaveConfigFields(null,null);
        }

        private void cB_PlayerD_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string enc = cB_PlayerD_CamType.Text;
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

            tB_PlayerD_RTSP.Text = rtsp;
            tB_PlayerD_Username.Text = username;
            tB_PlayerD_Password.Text = password;

            GetCombined();
        }

        private void check_PlayerD_Manual_CheckedChanged(object sender, EventArgs e) {
            foreach (Control c in extendedControls)
                c.Visible = check_PlayerD_Manual.Checked;

            if (check_PlayerD_Manual.Checked) {
                if (Size.Height < minExtendedHeight) {
                    Height = minExtendedHeight;
                }
                MinimumSize = new Size(500, minExtendedHeight);
            } else {
                MinimumSize = new Size(500, minSimpleHeight);
                Height -= 100;
            }
            MaximumSize = new Size(9999, MinimumSize.Height);
        }

        private void b_PlayerD_Play_Click(object sender, EventArgs e) {
            myDetached.Play(true, isMainPlayer);
        }

        private void VideoSettings_VisibleChanged_1(object sender, EventArgs e) {
            if (MainForm.m.finishedLoading) {
                GetCombined();
                if (!isMainPlayer && isAttached) {
                    b_Detach.Show();
                }
            }
        }

        private void b_PlayerD_Stop_Click(object sender, EventArgs e) {
            myDetached.StopPlaying();
        }

        private void Fields_Any_Click(object sender, MouseEventArgs e) {
            ConfigControl.mainPlayerCustomFull.UpdateValue("false");
        }

        private void tB_PlayerD_Name_KeyUp(object sender, EventArgs e) {
            string name = tB_PlayerD_Name.Text.Trim();
            if (name.Length == 0 || name == " " || name == tB_PlayerD_Adr.Text) {
                ConfigControl.mainPlayerCustomName.UpdateValue("false");
            } else {
                ConfigControl.mainPlayerCustomName.UpdateValue("true");
            }

            ConfigControl.mainPlayerName.UpdateValue(tB_PlayerD_Name.Text);
        }

        void SaveConfigFields(object sender, EventArgs e) {
            if (!isMainPlayer || !MainForm.m.finishedLoading)
                return;

            ConfigControl.mainPlayerName.UpdateValue(tB_PlayerD_Name.Text);
            ConfigControl.mainPlayerFullAdr.UpdateValue(tB_PlayerD_SimpleAdr.Text);
            ConfigControl.mainPlayerCamType.UpdateValue(cB_PlayerD_CamType.Text);
            ConfigControl.mainPlayerIPAdr.UpdateValue(tB_PlayerD_Adr.Text);
            ConfigControl.mainPlayerPort.UpdateValue(tB_PlayerD_Port.Text);
            ConfigControl.mainPlayerRTSP.UpdateValue(tB_PlayerD_RTSP.Text);
            ConfigControl.mainPlayerBuffering.UpdateValue(tB_PlayerD_Buffering.Text);
            ConfigControl.mainPlayerUsername.UpdateValue(tB_PlayerD_Username.Text);
            ConfigControl.mainPlayerPassword.UpdateValue(tB_PlayerD_Password.Text);
        }

        private void AddressField_KeyUp(object sender, KeyEventArgs e) {
            GetCombined();

            if (isMainPlayer) {
                if (e.KeyCode == Keys.Enter) { //bug with using arrow keys + enter to close error
                    SaveConfigFields(null, null);
                } else
                    DoSaveTimer();
            }
        }

        void DoSaveTimer() {
            if (saveTimer != null && saveTimer.Enabled)
                saveTimer.Stop();

            saveTimer.Start();
        }

        public void UpdateMode() {
            string value = ConfigControl.mainPlayerCamType.stringVal.ToLower();

            if (value.Contains("thermal")) {
                cB_PlayerD_CamType.SelectedIndex = 1;
                tB_PlayerD_RTSP.Text = thermalRTSP;
            } else if (value.Contains("daylight")) {
                cB_PlayerD_CamType.SelectedIndex = 0;
                tB_PlayerD_RTSP.Text = dayRTSP;
            }

            myDetached.Play(false, false);
        }

        private void b_Detach_Click(object sender, EventArgs e) {
            MainForm.m.mainPlayer.Detach(myDetached);
            b_Detach.Visible = false;
            Hide();
        }

        private void tB_PlayerD_SimpleAdr_KeyPress(object sender, KeyPressEventArgs e) {
            string val = tB_PlayerD_SimpleAdr.Text.Trim();
            
            if (val == "" || val == GetCombined(true))
                ConfigControl.mainPlayerCustomFull.UpdateValue("false");
            else
                ConfigControl.mainPlayerCustomFull.UpdateValue("true");

            ConfigControl.mainPlayerFullAdr.UpdateValue(val);
        }

    }
}

