using System;
using System.Windows.Forms;

namespace SSUtility2 {

    public partial class Detached : Form {

        public InfoPanel myInfoRef;

        bool Dplaying = false;
        Recorder recorderD;

        public Detached() {
            InitializeComponent();
        }

        public Uri GetCombined() {
            Uri defaultAdr = new Uri("http://0.0.0.0:1234");
            try {
                Uri combinedUrl;

                if (checkB_PlayerD_Manual.Checked) { //make a function to automatically grab these from gB_...
                    string ipaddress = tB_PlayerD_Adr.Text; //is it possible? the variables need to be in an order
                    string port = tB_PlayerD_Port.Text;
                    string url = tB_PlayerD_RTSP.Text;
                    string username = tB_PlayerD_Username.Text;
                    string password = tB_PlayerD_Password.Text;

                    combinedUrl = new Uri("rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url);
                } else {
                    if (tB_PlayerD_SimpleAdr.Text != "") {
                        combinedUrl = new Uri(tB_PlayerD_SimpleAdr.Text);
                    } else {
                        combinedUrl = defaultAdr;
                    }
                }

                if (combinedUrl != defaultAdr) {
                    tB_PlayerD_Name.Text = combinedUrl.Host;
                }

                return combinedUrl;
            } catch {
                return defaultAdr;
            }
        }

        private void b_PlayerD_Play_Click(object sender, EventArgs e) {
            StartPlaying(true);
        }

        public void StartPlaying(bool manuallyPressed) {
            try {
                Uri combined = GetCombined();

                if (MainForm.m.Play(VLCPlayer_D, combined, tB_PlayerD_SimpleAdr,
                    tB_PlayerD_Buffering.Text, manuallyPressed).Result) {

                    if (manuallyPressed) {
                        if (myInfoRef != null) {
                            if (myInfoRef.CheckCam()) {
                                check_PlayerD_StatsEnabled.Show();
                                checkB_PlayerD_Manual.Checked = false;
                            } else {
                                check_PlayerD_StatsEnabled.Hide();
                            }
                        }
                    }

                    b_PlayerD_Stop.Show();

                    if (check_PlayerD_StatsEnabled.Checked) {
                        StartInfo();
                    }

                } else {
                    if (myInfoRef != null) {
                        myInfoRef.HideAll();
                    }

                    b_PlayerD_Stop.Hide();
                }
            } catch (Exception e) {
                MainForm.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
            }
        }

        public void StartInfo() {
            if (ConfigControl.updateMs.intVal != 0 && myInfoRef != null
                && CameraCommunicate.sock.Connected &&
                check_PlayerD_StatsEnabled.Checked) {
                myInfoRef.InitializeTimer();
                return;
            } else if (ConfigControl.updateMs.intVal == 0) {
                MessageBox.Show("Info panel refresh rate is set to 0!\nPanel will be hidden!");
            }
            myInfoRef.HideAll();
        }

        private void b_PlayerD_SaveSnap_Click(object sender, EventArgs e) {
            MainForm.m.SaveSnap(this);
        }

        private void checkB_PlayerD_Manual_CheckedChanged(object sender, EventArgs e) {
            MainForm.m.ExtendOptions(checkB_PlayerD_Manual.Checked, p_PlayerD_Extended, p_PlayerD_Simple);
        }

        private void b_PlayerD_StartRec_Click(object sender, EventArgs e) {
            (bool, Recorder) vals = MainForm.m.StopStartRec(Dplaying, this, recorderD);
            Dplaying = vals.Item1;
            recorderD = vals.Item2;
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

        private void check_PlayerD_StatsEnabled_CheckedChanged(object sender, EventArgs e) {
            if (myInfoRef != null) {
                if (check_PlayerD_StatsEnabled.Checked) {
                    MainForm.m.MovePlayers(true);
                    myInfoRef.ShowAll();
                    if (!myInfoRef.UpdateTimer.Enabled) {
                        StartInfo();
                    }
                } else {
                    myInfoRef.StopTicking();
                    MainForm.m.MovePlayers(false);
                }
            } else {
                check_PlayerD_StatsEnabled.Hide();
            }
        }

        private void b_PlayerD_Stop_Click(object sender, EventArgs e) {
            VLCPlayer_D.playlist.stop();
            b_PlayerD_Stop.Hide();
            myInfoRef.UpdateTimer.Stop();
        }
    }
}
