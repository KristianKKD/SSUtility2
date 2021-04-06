using System;
using System.Drawing;
using System.Windows.Forms;

namespace SSUtility2
{
    public partial class VideoSettings : Form
    {

        public Detached originalDetached;
        public bool isSecondary = false;
        public bool isPlaying = false;
        public bool customName = false;
        public bool customFull = false;

        public const string dayRTSP = "videoinput_1:0/h264_1/onvif.stm";
        public const string thermalRTSP = "videoinput_2:0/h264_1/onvif.stm";

        Control[] extendedControls;
        const int minExtendedHeight = 375;
        const int minSimpleHeight = 275;

        public VideoSettings() {
            InitializeComponent();
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
        }

        private void VideoSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void checkB_PlayerD_Manual_CheckedChanged(object sender, EventArgs e) {
            bool enable = checkB_PlayerD_Manual.Checked;
            foreach (Control c in extendedControls) {
                c.Visible = enable;
            }

            if (enable) {
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

        public void Copy(VideoSettings sets) {
            tB_PlayerD_Name.Text = sets.tB_PlayerD_Name.Text + " 2";

            tB_PlayerD_Adr.Text = sets.tB_PlayerD_Adr.Text;
            tB_PlayerD_Port.Text = sets.tB_PlayerD_Port.Text;
            cB_PlayerD_CamType.Text = sets.cB_PlayerD_CamType.Text;
            tB_PlayerD_Buffering.Text = sets.tB_PlayerD_Buffering.Text;
            tB_PlayerD_Username.Text = sets.tB_PlayerD_Username.Text;
            tB_PlayerD_Password.Text = sets.tB_PlayerD_Password.Text;

            if (ConfigControl.savedCamera.stringVal.Contains("Daylight"))
                tB_PlayerD_RTSP.Text = thermalRTSP;
            else if (ConfigControl.savedCamera.stringVal.Contains("Thermal"))
                tB_PlayerD_RTSP.Text = dayRTSP;
            else
                HideSecond();

            tB_PlayerD_SimpleAdr.Text = GetCombined(this);
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
                if (originalDetached.secondView != null)
                    originalDetached.secondView.settings.tB_PlayerD_RTSP.Text = "videoinput_2:0/h264_1/onvif.stm";
            } else if (enc.Contains("Thermal")) {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
                if (originalDetached.secondView != null)
                    originalDetached.secondView.settings.tB_PlayerD_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
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
        }

        private void b_Play_Click(object sender, EventArgs e) {
            if (isSecondary)
                originalDetached.Play(true, originalDetached.secondView);
            else {
                originalDetached.StartPlaying(true);
                if (originalDetached == MainForm.m.mainPlayer && InfoPanel.i.isCamera)
                    originalDetached.Play(true, MainForm.m.mainPlayer);
            }
        }

        private void VideoSettings_VisibleChanged(object sender, EventArgs e) {
            if (isSecondary)
                b_Hide.Show();
        }

        public void HideSecond() {
            MainForm.m.sP_Player.Hide();
            Hide();
            MainForm.m.Menu_Video_EnableSecondary.Visible = true;
            MainForm.m.mainPlayer.secondView.StopPlaying();
        }

        private void b_Stop_Click(object sender, EventArgs e) {
            if (!isSecondary)
                originalDetached.StopPlaying();
            else
                originalDetached.secondView.StopPlaying();
        }

        private void tB_TextChanged(object sender, EventArgs e) {
            tB_PlayerD_SimpleAdr.Text = GetCombined(this);
        }

        public static string GetCombined(VideoSettings sets) {
            string full = "";

            try {
                string ipaddress = sets.tB_PlayerD_Adr.Text;

                if (sets.customFull) {
                    full = sets.tB_PlayerD_SimpleAdr.Text;
                } else {
                    string port = sets.tB_PlayerD_Port.Text;
                    string url = sets.tB_PlayerD_RTSP.Text;
                    string username = sets.tB_PlayerD_Username.Text;
                    string password = sets.tB_PlayerD_Password.Text;

                    full = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
                }

                if (!sets.customName)
                    sets.tB_PlayerD_Name.Text = ipaddress;

            } catch { };

            return full;
        }

        private void tB_PlayerD_Name_KeyPress(object sender, KeyPressEventArgs e) {
            if (tB_PlayerD_Name.Text != tB_PlayerD_Adr.Text) {
                customName = true;
            }
        }

        private void tB_PlayerD_Name_TextChanged(object sender, EventArgs e) {
            if (tB_PlayerD_Name.Text == tB_PlayerD_Adr.Text || tB_PlayerD_Name.Text.Length == 0) {
                customName = false;
            }
        }

        private void tB_PlayerD_SimpleAdr_KeyPress(object sender, KeyPressEventArgs e) {
            if (tB_PlayerD_SimpleAdr.Text.Length > 0)
                customFull = true;
            else
                customFull = false;
        }

        private void b_Secondary_Play_Click(object sender, EventArgs e) {
            MainForm.m.mainPlayer.Play(true, MainForm.m.mainPlayer.secondView);
        }

        private void b_Secondary_Stop_Click(object sender, EventArgs e) {
            MainForm.m.mainPlayer.secondView.StopPlaying();
        }

        private void b_Hide_Click(object sender, EventArgs e) {
            HideSecond();
        }

    }
}
