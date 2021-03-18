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

        public SPanel.SizeablePanel sP_Player;
        public AxAXVLC.AxVLCPlugin2 myPlayer;

        Recorder recorderD;

        public bool recording = false;

        bool dragging = false;
        Point eOriginalPos;

        public Detached(bool attachSecond) {
            InitializeComponent();
            settings = new VideoSettings();
            settings.originalDetached = this;
            myPlayer = VLCPlayer_D;
            if (attachSecond)
                InitSecond();
        }

        async Task InitSecond() {
            try {
                sP_Player = new SPanel.SizeablePanel();

                await Task.Delay(100).ConfigureAwait(false);

                Invoke((MethodInvoker)delegate {
                    myPanel.Controls.Add(sP_Player);

                    sP_Player.BackColor = Color.Black;
                    sP_Player.BorderStyle = BorderStyle.FixedSingle;
                    sP_Player.Size = new Size(400, 250);

                    sP_Player.BringToFront();

                    secondView = new Detached(false);
                    secondView.settings.originalDetached = this;
                    secondView.settings.Copy(settings);
                    secondView.settings.Text = "Secondary Video Settings";
                    secondView.settings.isSecondary = true;

                    AxAXVLC.AxVLCPlugin2 player = new AxAXVLC.AxVLCPlugin2();

                    sP_Player.Controls.Add(player);
                    player.Toolbar = false;
                    player.Branding = false;
                    player.volume = 0;

                    sP_Player.Hide(); //and below too

                    secondView.myPlayer = player;
                    secondView.VLCPlayer_D.Dispose();

                    AttachSecondaryFunctions();

                    sP_Player.Location = new Point(MainForm.m.Width - sP_Player.Width - 80, 30);
                    player.Location = new Point(7, 5);
                    player.Size = new Size(sP_Player.Width - 15, sP_Player.Height - 10);
                    player.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
                });

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
            myPlayer.playlist.stop();
            settings.isPlaying = false;
            MainForm.m.Menu_Video_StartStop.Text = "Start Video Playback";
        }

        public async Task StartPlaying(bool showErrors) {
            try {
                if (await Play(showErrors, this).ConfigureAwait(false)) {
                    MainForm.m.Menu_Video_StartStop.Text = "Stop Video Playback";
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
                MainForm.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                StopPlaying();
            }
        }

        public async Task<bool> Play(bool showError, Detached player) {
            try {
                Uri combinedUrl = player.GetCombined();
                //combinedUrl = new Uri(@"rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov"); //

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

                AxAXVLC.AxVLCPlugin2 vlc = player.myPlayer;

                if (vlc.playlist.isPlaying) {
                    vlc.playlist.stop();
                    vlc.playlist.items.clear();
                }

                vlc.playlist.add(combinedUrl.ToString(), null, ":avcodec -hw:network -caching="
                    + player.settings.tB_PlayerD_Buffering.Text); //might have to look at more options
                vlc.playlist.next();
                settings.isPlaying = true;

                return true;
            } catch (Exception e) {
                MainForm.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                return false;
            }
        }

        public async Task EnableSecond(bool show = true) {
            MainForm.m.Menu_Video_Info.Enabled = true;
            MainForm.m.Menu_Video_Swap.Enabled = true;

            sP_Player.Show();
            sP_Player.BringToFront();
            secondView.settings.Copy(settings);
            if (settings.isPlaying && show)
                secondView.Play(false, secondView);
        }

        public async Task DisableSecond() {
            MainForm.m.Menu_Video_Info.Enabled = false;
            MainForm.m.Menu_Video_Swap.Enabled = false;

            sP_Player.Hide(); //here
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
            if (MainForm.m.mainCp.myPanel.Visible)
                return;
            if (Cursor.Position.X - MainForm.m.Location.X < 70) {
                MainForm.m.b_Open.Visible = true;
                MainForm.m.b_Open.BringToFront();
            } else
                MainForm.m.b_Open.Visible = false;

        }

        public void UpdateMode(bool play) {
            settings.cB_PlayerD_Type.Text = ConfigControl.savedCamera.stringVal;
            settings.checkB_PlayerD_Manual.Checked = true;
            secondView.settings.checkB_PlayerD_Manual.Checked = true;

            if (ConfigControl.savedCamera.stringVal.Contains("Thermal")) {
                MainForm.m.Menu_Video_Swap.Text = "Swap to Daylight";
                settings.cB_PlayerD_Type.Text = "Thermal";
                ConfigControl.savedCamera.UpdateValue("Thermal");

                secondView.settings.Copy(settings);

                settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;
                if (secondView.settings.isPlaying)
                    secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;

            } else if (ConfigControl.savedCamera.stringVal.Contains("Daylight")) {
                MainForm.m.Menu_Video_Swap.Text = "Swap to Thermal";
                settings.cB_PlayerD_Type.Text = "Daylight";
                ConfigControl.savedCamera.UpdateValue("Daylight");

                secondView.settings.Copy(settings);

                settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;
                if (secondView.settings.isPlaying)
                    secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;
            }

            if (play) {
                Play(false, this);
                secondView.Play(false, secondView);
            }
        }

        void AttachSecondaryFunctions() {
            secondView.myPlayer.MouseDownEvent += (s, e) => {
                if (e.button == 2) {
                    secondView.settings.Show();
                    secondView.settings.BringToFront();
                } else if (e.button == 1) {
                    eOriginalPos = new Point(e.x, e.y);
                    dragging = true;
                }
            };

            secondView.myPlayer.MouseMoveEvent += (s, e) => {

                if (dragging) {
                    int xDragDist = e.x - eOriginalPos.X;
                    int xLocationDragDist = sP_Player.Location.X + (xDragDist * 2);
                    int w = MainForm.m.Width - sP_Player.Width;
                    if (MainForm.m.mainCp.myPanel.Visible)
                        w -= MainForm.m.mainCp.Width;

                    int yDragDist = e.y - eOriginalPos.Y;
                    int yLocationDragDist = sP_Player.Location.Y + (yDragDist * 2);
                    int h = MainForm.m.Height - sP_Player.Height;

                    if (xLocationDragDist < w && xLocationDragDist > -2)
                        sP_Player.Left += xDragDist;

                    if (yLocationDragDist < h && yLocationDragDist > -1)
                        sP_Player.Top += yDragDist;

                }
            };

            secondView.myPlayer.MouseUpEvent += (s, e) => {
                dragging = false;
                eOriginalPos = new Point(0, 0);
            };

        }

    }
}
