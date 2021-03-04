using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class VideoSettings : Form {

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
            } else if (enc == "IONodes - Thermal") {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
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

    }
}
