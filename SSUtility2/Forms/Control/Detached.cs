using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public partial class Detached : Form {

        public Panel myPanel;
        public VideoSettings settings;
        public Detached secondView;
        Recorder recorderD;

        public bool recording = false;
        public bool isPlaying = false;
        public bool thermalMode = false;

        public Detached(bool second = false) {
            InitializeComponent();
            settings = new VideoSettings();
            if (second)
                return;
            settings.myDetached = this;
            InitSecond();
        }

        async Task InitSecond() {
            try {
                settings.myDetached = this;
                sP_Player.Hide();
                await Task.Delay(300).ConfigureAwait(false);

                Invoke((MethodInvoker)delegate {
                    secondView = new Detached(true);
                    secondView.settings.myDetached = this;
                    secondView.settings.Copy(true);

                    Detached tempDetached = new Detached(true);
                    var c = MainForm.m.GetAllType(tempDetached, typeof(AxAXVLC.AxVLCPlugin2));
                    sP_Player.Controls.Add(c.ElementAt(0));
                    tempDetached.Dispose();

                    var controls = MainForm.m.GetAllType(sP_Player, typeof(AxAXVLC.AxVLCPlugin2));
                    AxAXVLC.AxVLCPlugin2 player = (AxAXVLC.AxVLCPlugin2)controls.ElementAt(0);

                    player.Dock = DockStyle.None;
                    player.Location = new System.Drawing.Point(3,3);
                    player.Size = new System.Drawing.Size(sP_Player.Width - 7, sP_Player.Height - 7);
                    player.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
                });


            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public Uri GetCombined() {
            Uri defaultAdr = new Uri("http://0.0.0.0:1234");
            try {
                Uri combinedUrl;

                if (settings.checkB_PlayerD_Manual.Checked) {
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
            if (isPlaying) {
                StopPlaying();
            } else {
                StartPlaying(true);
            }
        }

        public async Task StartPlaying(bool showErrors) {
            try {
                Uri combined = GetCombined();

                if (await Play(showErrors).ConfigureAwait(false)) {
                    MainForm.m.Menu_Video_StartStop.Text = "Stop Video Playback";
                    isPlaying = true;
                } else {
                    StopPlaying();
                }
            } catch (Exception e) {
                MainForm.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                StopPlaying();
            }
        }

        public void StopPlaying() {
            VLCPlayer_D.playlist.stop();
            isPlaying = false;
            MainForm.m.Menu_Video_StartStop.Text = "Start Video Playback";
        }

        public async Task<bool> Play(bool showError) {
            try {
                Uri combinedUrl = GetCombined();

                if (showError) {
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

                Invoke((MethodInvoker)delegate {
                    settings.tB_PlayerD_SimpleAdr.Text = combinedUrl.ToString();
                });

                AxAXVLC.AxVLCPlugin2 vlc = VLCPlayer_D;
                if (vlc.playlist.isPlaying) {
                    vlc.playlist.stop();
                    vlc.playlist.items.clear();
                }

                vlc.playlist.add(combinedUrl.ToString(), null, ":avcodec -hw:network -caching=" + settings.tB_PlayerD_Buffering.Text); //might have to look at more options
                vlc.playlist.next();
                vlc.playlist.play();

                return true;
            } catch (Exception e) {
                MainForm.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                return false;
            }
        }

        public async Task EnableSecond() {
            MainForm.m.Menu_Video_Info.Enabled = true;
            MainForm.m.Menu_Video_Swap.Enabled = true;

            sP_Player.Show();
            secondView.settings.Copy(false);
            await Task.Delay(300).ConfigureAwait(false);
            if (!secondView.isPlaying)
                sP_Player.Hide();
        }

        public void SnapShot() {
            MainForm.m.SaveSnap(this);
        }

        private void Menu_Settings_Click(object sender, EventArgs e) {
            settings.Show();
        }

        private void Menu_StartStop_Click(object sender, EventArgs e) {
            StartStop();
        }

        private void Menu_Snapshot_Click(object sender, EventArgs e) {
            MainForm.m.SaveSnap(this);
        }

        private void Menu_Record_Click(object sender, EventArgs e) {
            (bool, Recorder) vals = MainForm.m.StopStartRec(recording, this, recorderD);
            recording = vals.Item1;
            recorderD = vals.Item2;
        }

        private void VLCPlayer_D_MouseMoveEvent(object sender, AxAXVLC.DVLCEvents_MouseMoveEvent e) {
            if (MainForm.m.mainPlayer != this || MainForm.m.mainCp.myPanel.Visible)
                return;
            if (e.x < 75 && e.y < 75)
                MainForm.m.b_Open.Visible = true;
            else
                MainForm.m.b_Open.Visible = false;
        }

    }
}
