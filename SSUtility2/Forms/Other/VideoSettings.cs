using System;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class VideoSettings : Form {

        public Detached myDetached;

        public VideoSettings() {
            InitializeComponent();
        }

        private void VideoSettings_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void checkB_PlayerD_Manual_CheckedChanged(object sender, EventArgs e) {
            if (checkB_PlayerD_Manual.Checked) {
                p_PlayerD_Simple.Hide();
                p_PlayerD_Extended.Show();
            } else {
                p_PlayerD_Extended.Hide();
                p_PlayerD_Simple.Show();
            }
        }

        public void Copy(bool full) {
            tB_PlayerD_Adr.Text = myDetached.settings.tB_PlayerD_Adr.Text;
            tB_PlayerD_Port.Text = myDetached.settings.tB_PlayerD_Port.Text;
            tB_PlayerD_Username.Text = myDetached.settings.tB_PlayerD_Username.Text;
            tB_PlayerD_Password.Text = myDetached.settings.tB_PlayerD_Password.Text;
            tB_PlayerD_Name.Text = myDetached.settings.tB_PlayerD_Name.Text + " 2";
            tB_PlayerD_SimpleAdr.Text = myDetached.settings.tB_PlayerD_SimpleAdr.Text;
            if (full) {
                if (myDetached.settings.cB_PlayerD_Type.Text.Contains("Daylight"))
                    myDetached.secondView.settings.tB_PlayerD_RTSP.Text = "videoinput_2:0/h264_1/onvif.stm";
                else
                    myDetached.secondView.settings.tB_PlayerD_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            }
        }

        private void cB_PlayerD_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string enc = cB_PlayerD_Type.Text;
            string username = "";
            string password = "";
            string rtsp = "";

            if (enc == "Daylight") {
                cB_PlayerD_Type.Text = "IONodes - Daylight";
                enc = cB_PlayerD_Type.Text;
            }

            if (enc == "IONodes - Daylight") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_1:0/h264_1/onvif.stm";
                if (myDetached.secondView != null)
                    myDetached.secondView.settings.tB_PlayerD_RTSP.Text = "videoinput_2:0/h264_1/onvif.stm";
            } else if (enc == "IONodes - Thermal") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
                if (myDetached.secondView != null)
                    myDetached.secondView.settings.tB_PlayerD_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            } else if (enc == "VIVOTEK") {
                username = "root";
                password = "root1234";
                rtsp = "live.sdp";
            } else if (enc == "BOSCH") {
                username = "service";
                password = "Service123!";
                rtsp = "";
            }


            tB_PlayerD_RTSP.Text = rtsp;
            tB_PlayerD_Username.Text = username;
            tB_PlayerD_Password.Text = password;
        }

        private void b_Play_Click(object sender, EventArgs e) {
            myDetached.Play(true);
        }
    }
}
