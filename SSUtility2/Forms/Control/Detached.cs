using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye;

namespace SSUtility2 {

    public partial class Detached : Form {

        public VideoSettings settings;
        public Detached secondView;

        Recorder recorderD;

        public bool recording = false;

        Stream vid;

        public Detached(bool attachSecond) {
            InitializeComponent();
            settings = new VideoSettings();
            settings.originalDetached = this;
            if (attachSecond)
                InitSecond();
        }

        void InitSecond() {
            try {
                if (MainForm.m.p_Control.InvokeRequired) {
                    MainForm.m.p_Control.Invoke(new MethodInvoker(this.InitSecond));
                } else {
                    MainForm.m.p_Control.Controls.Add(MainForm.m.sP_Player);

                    MainForm.m.sP_Player.BringToFront();

                    secondView = new Detached(false);
                    secondView.settings.originalDetached = this;
                    secondView.settings.Copy(settings);
                    secondView.settings.Text = "Secondary Video Settings";
                    secondView.settings.isSecondary = true;
                    //secondView.settings.tP_Main.Dispose();

                    MainForm.m.sP_Player.Hide(); //and below too

                    secondView.stream_Player = MainForm.m.stream_SecondPlayer;
                }

            } catch (Exception e) {
                MessageBox.Show("INITSECOND\n" + e.ToString());
            }
        }
     
        public Uri GetCombined() {
            Uri defaultAdr = new Uri("http://0.0.0.0:1234");
            try {
                Uri combinedUrl;

                if (settings.checkB_PlayerD_Manual.Checked || settings.isSecondary) {
                    string ipaddress = settings.tB_PlayerD_Adr.Text;
                    string port = settings.tB_PlayerD_Port.Text;
                    string url = settings.tB_PlayerD_RTSP.Text;
                    string username = settings.tB_PlayerD_Username.Text;
                    string password = settings.tB_PlayerD_Password.Text;

                    combinedUrl = new Uri("rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url);
                } else {
                    if (settings.tB_PlayerD_SimpleAdr.Text != "") {
                        combinedUrl = new Uri(settings.tB_PlayerD_SimpleAdr.Text);
                    } else {
                        combinedUrl = defaultAdr;
                    }
                }

                if (combinedUrl != defaultAdr) {
                    settings.tB_PlayerD_Name.Text = combinedUrl.Host;
                }

                return combinedUrl;
            } catch {
                return defaultAdr;
            }
        }

        public void StartStop() {
            if (settings.isPlaying) {
                StopPlaying();
            } else {
                StartPlaying(true);
            }
        }

        public void StopPlaying() {
            if (!settings.isPlaying)
                return;
            vid.Stop();
            settings.isPlaying = false;
            if(!settings.isSecondary)
                MainForm.m.Menu_Video_StartStop.Text = "Start Video Playback";
        }

        public async Task StartPlaying(bool showErrors) {
            try {
                if (MainForm.m.lite) {
                    settings.isPlaying = true;
                    return;
                }

                if (await Play(showErrors, this).ConfigureAwait(false)) {
                    Invoke((MethodInvoker)delegate {
                        MainForm.m.Menu_Video_StartStop.Text = "Stop Video Playback";
                    });
                    if (this == MainForm.m.mainPlayer && showErrors) {
                        if (!secondView.settings.isPlaying) {
                            secondView.settings.Copy(settings);
                            secondView.Play(false, secondView);
                        }
                    }

                    if (ConfigControl.autoReconnect.boolVal) {
                        MainForm.m.setPage.tB_IPCon_Adr.Text = settings.tB_PlayerD_Adr.Text;
                        ConfigControl.savedIP.UpdateValue(MainForm.m.setPage.tB_IPCon_Adr.Text);
                        AsyncCamCom.TryConnect(showErrors);
                    }
                } else {
                    StopPlaying();
                }
            } catch (Exception e) {
                Tools.ShowPopup("Failed to init stream!\nShow more?", "Stream Failed!", e.ToString());
                StopPlaying();
            }
        }

        public async Task<bool> Play(bool showError, Detached player) {
            try {
                if (MainForm.m.lite) {
                    settings.isPlaying = true;
                    return true;
                }

                if (!this.IsHandleCreated)
                    this.CreateHandle();

                Uri combinedUrl;
                if (player.settings.checkB_PlayerD_Manual.Checked) {
                    combinedUrl = player.GetCombined();
                    player.settings.tB_PlayerD_SimpleAdr.Text = combinedUrl.ToString();
                } else
                    combinedUrl = new Uri(player.settings.tB_PlayerD_SimpleAdr.Text);

                //rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov

                if (showError && !player.settings.isSecondary) {
                    bool parsed = IPAddress.TryParse(combinedUrl.Host, out IPAddress parsedIP);
                    if (combinedUrl.Host == "" || !parsed) {
                        MessageBox.Show("Address is invalid!");
                        return false;
                    }
                    if (!OtherCamCom.PingAdr(parsedIP).Result) {
                        MessageBox.Show("Address had no RTSP stream attached!");
                        return false;
                    }
                }

                if (player.settings.isPlaying)
                    player.StopPlaying();

                vid = Stream.FromUri(combinedUrl, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10), RtspTransport.Undefined, RtspFlags.PreferTcp);
                player.stream_Player.AttachStream(vid);
                vid.Start();

                settings.isPlaying = true;

                return true;
            } catch (Exception e) {
                Tools.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                return false;
            }
        }

        float timeoutTime = 0;

        public void PlayMe() {
            if (settings.isPlaying) {
                if (timeoutTime < 7500f/ConfigControl.commandRateMs.intVal) {
                    timeoutTime++;
                } else {
                    timeoutTime = 0;
                    Restart();
                    MainForm.m.WriteToResponses("replay", false);
                }
            }
        }

        void Restart() {
            vid.Stop();
            vid.Start();
        }

        public async Task EnableSecond(bool copySettings) {
            if (MainForm.m.lite)
                return;

            MainForm.m.Menu_Settings_Info.Visible = true;

            MainForm.m.sP_Player.Show();
            MainForm.m.sP_Player.BringToFront();
            if(copySettings)
                secondView.settings.Copy(settings);
            if (settings.isPlaying)
                secondView.Play(false, secondView);
        }

        public async Task DisableSecond() {
            MainForm.m.Menu_Settings_Info.Visible = false;
            MainForm.m.sP_Player.Hide();
            if (secondView.settings.isPlaying)
                secondView.StopPlaying();
        }

        public void SnapShot() {
            Tools.SaveSnap(this);
        }

        private void Menu_Settings_Click(object sender, EventArgs e) {
            settings.Show();
        }

        private void Menu_StartStop_Click(object sender, EventArgs e) {
            StartStop();
        }

        private void Menu_Snapshot_Click(object sender, EventArgs e) {
            Tools.SaveSnap(this);
        }

        private void Menu_Record_Click(object sender, EventArgs e) {
            (bool, Recorder) vals = MainForm.m.StopStartRec(recording, this, recorderD);
            recording = vals.Item1;
            recorderD = vals.Item2;
        }

        public void UpdateMode() {
            try {
                bool isCam = InfoPanel.i.isCamera;

                settings.cB_PlayerD_CamType.Text = ConfigControl.savedCamera.stringVal;
                settings.checkB_PlayerD_Manual.Checked = true;

                if (isCam) {
                    secondView.settings.Copy(settings);
                }

                if (ConfigControl.savedCamera.stringVal.Contains("Thermal")) {
                    settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;

                    if (isCam) {
                        secondView.settings.cB_PlayerD_CamType.Text = "Daylight";
                        secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;
                    }
                } else if (ConfigControl.savedCamera.stringVal.Contains("Daylight")) {
                    settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;

                    if (isCam) {
                        secondView.settings.cB_PlayerD_CamType.Text = "Thermal";
                        secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;
                    }
                }

                Play(false, this);
                if (isCam && secondView.settings.isPlaying) {
                    secondView.settings.checkB_PlayerD_Manual.Checked = true;
                    secondView.Play(false, secondView);
                }
            } catch (Exception e) {
                MessageBox.Show("UPDATEMODE\n" + e.ToString());
            }
        }

        private void stream_Player_MouseMove(object sender, MouseEventArgs e) {
            if (!AsyncCamCom.sock.Connected)
                return;
            if (Cursor.Position.X - MainForm.m.Location.X < 70) {
                MainForm.m.b_Open.Visible = true;
                MainForm.m.b_Open.BringToFront();
            } else
                MainForm.m.b_Open.Visible = false;
        }
    }
}
