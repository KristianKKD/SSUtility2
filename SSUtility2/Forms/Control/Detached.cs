using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPlayerNetSDK;

namespace SSUtility2 {

    public partial class Detached : Form {

        public VideoSettings settings;
        public Detached secondView;

        Recorder recorderD;

        public bool recording = false;

        public Panel myPlayer;

        public int channelID = -1;

        public Detached(bool attachSecond) {
            InitializeComponent();
            settings = new VideoSettings();
            settings.originalDetached = this;
            myPlayer = p_Player;
            CreateHandle();

            if (attachSecond) {
                var t = new Thread(AttachSecond);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            } else {
                settings.tP_Main.Text = "Detached Player";
                settings.tP_Secondary.Dispose();
            }

        }

        void AttachSecond() {
            try {
                if (MainForm.m.p_Control.InvokeRequired) {
                    MainForm.m.p_Control.Invoke(new MethodInvoker(this.AttachSecond));
                } else {
                    secondView = new Detached(false);
                    secondView.settings.originalDetached = this;
                    secondView.settings.CopyPlayerD(settings);
                    secondView.settings.Text = "Secondary Video Settings";
                    secondView.settings.isSecondary = true;
                    secondView.settings.tP_Main.Text = "Secondary Player";

                    secondView.p_Player.Dispose();
                    secondView.myPlayer = MainForm.m.sP_Player; //this might be interesting
                }
            } catch (Exception e) {
                MessageBox.Show("ATTACHSECOND\n" + e.ToString());
            }
        }

        public void StartStop() {
            if (settings.isPlaying) {
                StopPlaying();
            } else {
                if (this == MainForm.m.mainPlayer)
                    StartPlaying(true);
                else
                    Play(true, this);
            }
        }

        public void StopPlaying() {
            if (!settings.isPlaying)
                return;

            int ret = PlayerSdk.EasyPlayer_CloseStream(channelID);
            if (ret == 0)
                channelID = -1;

            myPlayer.BackColor = Color.Black;

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
                        if (InfoPanel.i.isCamera) {
                            secondView.settings.CopyPlayerD(settings);
                            Play(false, secondView);
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
                if(showErrors)
                    Tools.ShowPopup("Failed to init stream!\nShow more?", "Stream Failed!", e.ToString());
                StopPlaying();
            }
        }

        public static async Task<bool> Play(bool showError, Detached player) {
            try {
                if (MainForm.m.lite) {
                    player.settings.isPlaying = true;
                    return true;
                }

                Uri combinedUrl = new Uri(VideoSettings.GetCombined(player.settings));
                //rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov
               
                if (!ConfigControl.ignoreAddress.boolVal) {
                    if (showError && !player.settings.isSecondary) {
                        if (combinedUrl.Host == "") {
                            MessageBox.Show("Address is invalid!");
                            return false;
                        }
                        if (!OtherCamCom.PingAdr(combinedUrl.Host).Result) {
                            MessageBox.Show("Address had no RTSP stream attached!");
                            return false;
                        }
                    }
                }

                if (player.settings.isPlaying)
                    player.StopPlaying();


                SafePlay(player);

                player.settings.isPlaying = true;
                    
                return true;
            } catch (Exception e) {
                Tools.ShowPopup("Failed to play stream!\nShow more?", "Stream Failed!", e.ToString());
                return false;
            }
        }


        static void SafePlay(Detached player) {
            try {

                if (player.myPlayer.InvokeRequired) {
                    player.Invoke((MethodInvoker)delegate {
                        SafePlay(player);
                    });
                    return;
                }

                player.channelID = PlayerSdk.EasyPlayer_OpenStream(VideoSettings.GetCombined(player.settings),
                    player.myPlayer.Handle, PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI,
                        1, "", "", null, IntPtr.Zero, false);

                if (player.channelID > 0) {
                    PlayerSdk.EasyPlayer_SetFrameCache(player.channelID, 3);
                }

            }catch(Exception e) {
                Tools.ShowPopup("Failed to safely starting playing!\nShow more?", "Error occurred!", e.ToString());
            }
        }

        public void Replay() {
            if (settings.isPlaying)
                Play(false, this);

            if (InfoPanel.i.isCamera) {
                MainForm.m.mainPlayer.secondView.settings.CopyPlayerD(MainForm.m.mainPlayer.settings);
                Play(false, secondView);
            }
        }

        public static async Task EnableSecond(bool copySettings) {
            if (MainForm.m.lite)
                return;

            MainForm.m.Menu_Settings_Info.Visible = true;
            if(MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages.Count == 1)
                MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages.Add(MainForm.m.mainPlayer.settings.secondaryPage);

            MainForm.m.sP_Player.Show();
            MainForm.m.sP_Player.BringToFront();
            
            if (copySettings) {
                MainForm.m.mainPlayer.secondView.settings.CopyPlayerD(MainForm.m.mainPlayer.settings);
            }
            Play(false, MainForm.m.mainPlayer.secondView);
        }

        public static async Task DisableSecond() {
            MainForm.m.Menu_Settings_Info.Visible = false;
            MainForm.m.mainPlayer.settings.tC_PlayerSettings.TabPages.Remove(MainForm.m.mainPlayer.settings.tP_Secondary);

            MainForm.m.sP_Player.Hide(); //here

            if (MainForm.m.mainPlayer.secondView.settings.isPlaying)
                MainForm.m.mainPlayer.secondView.StopPlaying();
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

        public void CustomSwap() {
            try {
                VideoSettings tempSettings = new VideoSettings();

                tempSettings.CopyPlayerD(settings, true); //temp save old main settings
                VideoSettings.CopySecondarySettingsMoveToMain(settings, settings); //move second to main
                VideoSettings.CopyPrimarySettingsMoveToSecondary(tempSettings, settings); //move old settings to second

                Play(true, this);
                Play(true, secondView);

                MainForm.m.setPage.tB_IPCon_Adr.Text = settings.tB_PlayerD_Adr.Text;
                AsyncCamCom.TryConnect();

                tempSettings.Dispose();
            } catch (Exception e) {
                MessageBox.Show("Swap Fail\n" + e.ToString());
            }
        }

        public async Task UpdateMode() {
            try {
                settings.cB_PlayerD_CamType.Text = ConfigControl.mainPlayerCamType.stringVal;

                secondView.settings.CopyPlayerD(settings);

                if (ConfigControl.mainPlayerCamType.stringVal.ToLower().Contains("thermal")) {
                    settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;

                    secondView.settings.cB_PlayerD_CamType.Text = "Daylight";
                    secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;
                } else if (ConfigControl.mainPlayerCamType.stringVal.ToLower().Contains("daylight")) {
                    settings.tB_PlayerD_RTSP.Text = VideoSettings.dayRTSP;

                    secondView.settings.cB_PlayerD_CamType.Text = "Thermal";
                    secondView.settings.tB_PlayerD_RTSP.Text = VideoSettings.thermalRTSP;
                }

                Play(false, this);
                if (InfoPanel.i.isCamera) {
                    Play(false, secondView);
                }
            } catch (Exception e) {
                MessageBox.Show("UPDATEMODE\n" + e.ToString());
            }
        }

    }
}
