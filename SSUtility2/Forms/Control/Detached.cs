using System;
using System.Drawing;
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

        public AxAXVLC.AxVLCPlugin2 secondaryPlayer;

        public Detached(bool second = false) {
            InitializeComponent();
            settings = new VideoSettings();
            if (second)
                return;
            settings.originalDetached = this;
            InitSecond();
        }

        async Task InitSecond() {
            try {
                settings.originalDetached = this;
                sP_Player.Hide();
                await Task.Delay(300).ConfigureAwait(false);

                Invoke((MethodInvoker)delegate {
                    secondView = new Detached(true);
                    secondView.settings.originalDetached = this;
                    secondView.settings.Copy(settings);
                    secondView.settings.Text = "Secondary Video Settings";
                    secondView.settings.isSecondary = true;

                    var c = MainForm.m.GetAllType(secondView, typeof(AxAXVLC.AxVLCPlugin2));
                    sP_Player.Controls.Add(c.ElementAt(0));

                    var secondPlayer = MainForm.m.GetAllType(sP_Player, typeof(AxAXVLC.AxVLCPlugin2));
                    AxAXVLC.AxVLCPlugin2 p = (AxAXVLC.AxVLCPlugin2)secondPlayer.ElementAt(0);
                    secondView.secondaryPlayer = p;

                    sP_Player.Location = new Point(MainForm.m.Width - sP_Player.Width - 80, 30);
                    p.Dock = DockStyle.None;
                    p.Location = new Point(7, 5);
                    p.Size = new Size(sP_Player.Width - 15, sP_Player.Height - 10);
                    p.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
                });


            } catch (Exception e) {
                MessageBox.Show(e.ToString());
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
            if (isPlaying) {
                StopPlaying();
            } else {
                StartPlaying(true);
            }
        }

        public async Task StartPlaying(bool showErrors) {
            try {
                if (await Play(showErrors, this).ConfigureAwait(false)) {
                    isPlaying = true;
                    MainForm.m.Menu_Video_StartStop.Text = "Stop Video Playback";
                    if (ConfigControl.autoReconnect.boolVal) {
                        MainForm.m.setPage.tB_IPCon_Adr.Text = settings.tB_PlayerD_Adr.Text;
                        ConfigControl.savedIP.UpdateValue(MainForm.m.setPage.tB_IPCon_Adr.Text);
                        AsyncCamCom.TryConnect(showErrors);
                    }
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

        public async Task<bool> Play(bool showError, Detached player) {
            try {
                Uri combinedUrl = player.GetCombined();

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

                Invoke((MethodInvoker)delegate {
                    player.settings.tB_PlayerD_SimpleAdr.Text = combinedUrl.ToString();
                });

                AxAXVLC.AxVLCPlugin2 vlc;
                if (player.settings.isSecondary)
                    vlc = player.secondaryPlayer;
                else
                    vlc = VLCPlayer_D;

                if (vlc.playlist.isPlaying) {
                    vlc.playlist.stop();
                    vlc.playlist.items.clear();
                }

                vlc.playlist.add(combinedUrl.ToString(), null, ":avcodec -hw:network -caching="
                    + player.settings.tB_PlayerD_Buffering.Text); //might have to look at more options
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
            sP_Player.BringToFront();
            secondView.settings.Copy(settings);
            secondView.Play(true, secondView);
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
            Console.WriteLine((Cursor.Position.X - MainForm.m.Location.X).ToString());
            if (MainForm.m.mainPlayer != this || MainForm.m.mainCp.myPanel.Visible)
                return;
            if (Cursor.Position.X - MainForm.m.Location.X < 70) {
                MainForm.m.b_Open.Visible = true;
                MainForm.m.b_Open.BringToFront();
            } else
                MainForm.m.b_Open.Visible = false;
        }

        public void Swap() {
            try {
                if ((ConfigControl.savedCamera.stringVal.Contains("Thermal") || ConfigControl.savedCamera.stringVal.Contains("Daylight"))) {
                    
                    secondView.settings.Copy(settings);
                    
                    if (thermalMode) {
                        settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;
                        secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;
                    } else {
                        settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;
                        secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;
                    }

                } else {
                    VideoSettings tempSets = new VideoSettings();
                    tempSets.Copy(secondView.settings, false);

                    secondView.settings.Copy(settings, false);
                    settings.Copy(tempSets, false);

                    secondView.settings.checkB_PlayerD_Manual.Checked = true;
                    settings.checkB_PlayerD_Manual.Checked = true;

                    secondView.Play(false, secondView);
                    Play(false, this);

                    tempSets.Dispose();
                }
            } catch { };
        }

        public void UpdateMode() {
            if (ConfigControl.savedCamera.stringVal.Contains("Thermal")) {
                thermalMode = true;
                MainForm.m.Menu_Video_Swap.Text = "Swap to Daylight";
                settings.cB_PlayerD_Type.Text = "Thermal";
            } else if (ConfigControl.savedCamera.stringVal.Contains("Daylight")) {
                thermalMode = false;
                MainForm.m.Menu_Video_Swap.Text = "Swap to Thermal";
                settings.cB_PlayerD_Type.Text = "Daylight";
            }
        }
        
        private void sP_Player_DoubleClick(object sender, EventArgs e) {
            secondView.settings.Show();
            secondView.settings.BringToFront();
        }
    }
}
