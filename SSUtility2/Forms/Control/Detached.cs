using System;
using System.Collections.Generic;
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
        public List<Detached> attachedPlayers = new List<Detached>();

        public Detached(bool isMain) {
            InitializeComponent();
            settings = new VideoSettings(this, isMain);
            CreateHandle();
            if (isMain) 
                p_Player = MainForm.m.p_PlayerPanel;
        }

        public void HidePlayer() {
                    
        }

        public async Task StopPlaying() {
            int ret = PlayerSdk.EasyPlayer_CloseStream(settings.channelID);
            if (ret == 0)
                settings.channelID = -1;

            p_Player.BackColor = Color.Black;
            p_Player.Refresh();
        }

        public void ToggleStopStart() {
            if (settings.channelID > 0) {
                StopPlaying();
            } else {
                Play(true);
            }
        }

        public async Task Play(bool showErrors, bool updateValues = true) {
            try {
                if (MainForm.m.lite && settings.isMainPlayer) {
                    settings.channelID = 1;
                    return;
                }

                if (!settings.AdrValid(showErrors))
                    return;

                if (InvokeRequired) {
                    Invoke((MethodInvoker)delegate {
                        Play(showErrors);
                    });
                    return;
                }

                Uri combinedUrl = new Uri(settings.tB_PlayerD_SimpleAdr.Text);
                //rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov

                if (settings.channelID > 0)
                    StopPlaying();

                settings.channelID = PlayerSdk.EasyPlayer_OpenStream(combinedUrl.ToString(),
                    p_Player.Handle, PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI,
                        1, "", "", null, IntPtr.Zero, false);

                if (settings.channelID > 0)
                    PlayerSdk.EasyPlayer_SetFrameCache(settings.channelID, 3);
                else {
                    if(showErrors)
                        MessageBox.Show("Failed to attach to channel!");
                    StopPlaying();
                }

                if (settings.isMainPlayer && showErrors) {
                    //if (InfoPanel.i.isCamera) { //all players instead of this
                    //    secondView.settings.CopyPlayerD(settings);
                    //    Play(false, secondView);
                    //}
                }

                if (ConfigControl.autoReconnect.boolVal && updateValues) {
                    MainForm.m.setPage.tB_IPCon_Adr.Text = settings.tB_PlayerD_Adr.Text;
                    ConfigControl.savedIP.UpdateValue(MainForm.m.setPage.tB_IPCon_Adr.Text);
                    AsyncCamCom.TryConnect(false, null, true);
                }

            } catch (Exception e) {
                if(showErrors)
                    Tools.ShowPopup("Failed to init player stream!\nShow more?", "Error Occurred!", e.ToString());
                StopPlaying();
                return;
            }
        }

        public void AttachPlayerToThis(Detached secondPlayer, Point pos, VideoSettings.CopyType type) {
            attachedPlayers.Add(secondPlayer);
            secondPlayer.settings.isAttached = true;

            SPanel.SizeablePanel sP_Secondary = new SPanel.SizeablePanel();
            secondPlayer.p_Player = sP_Secondary;
            p_Player.Controls.Add(sP_Secondary);

            sP_Secondary.Size = new Size(300, 200);
            sP_Secondary.Location = pos;
            sP_Secondary.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            sP_Secondary.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Right) {
                    secondPlayer.settings.Show();
                    secondPlayer.settings.BringToFront();
                }
            };

            sP_Secondary.DoubleClick += (s, e) => {
                MainForm.m.SwapSettings(secondPlayer);
            };

            VideoSettings.CopySettings(secondPlayer.settings, MainForm.m.mainPlayer.settings, type);
            secondPlayer.Play(false);
        }

        public void Detach(Detached detachable) {
            attachedPlayers.Remove(detachable);
            detachable.settings.isAttached = false;

            bool wasPlaying = false;
            if (detachable.settings.channelID > 0)
                wasPlaying = true;

            detachable.StopPlaying();

            detachable.p_Player.Dispose();

            detachable.p_Player = (Panel)Tools.GetAllType(detachable, typeof(Panel)).First();
            detachable.Show();

            if (wasPlaying)
                detachable.Play(false, false);
        }

        private void Menu_Settings_Click(object sender, EventArgs e) {
            settings.Show();
        }

        private void Menu_StartStop_Click(object sender, EventArgs e) {
            ToggleStopStart();
        }

        private void Menu_Snapshot_Click(object sender, EventArgs e) {
            Tools.SaveSnap(this);
        }

        private void Menu_Record_Click(object sender, EventArgs e) {
            try {
                string location = ConfigControl.vFolder.stringVal + ConfigControl.mainPlayerName.stringVal + @"\";

                Console.WriteLine(Menu_Record.Text);

                if (Menu_Record.Text == "Start Recording") {
                    Menu_Record.Text = "Stop Recording";
                    PlayerSdk.EasyPlayer_StartManuRecording(settings.channelID, location);
                } else {
                    Menu_Record.Text = "Start Recording";
                    PlayerSdk.EasyPlayer_StopManuRecording(settings.channelID);

                    if (MainForm.m.finalMode) {
                        SaveFileDialog fdg = Tools.SaveFile(ConfigControl.screencapFileName.stringVal, ".avi", MainForm.m.finalDest);
                        DialogResult result = fdg.ShowDialog();
                        if (result == DialogResult.OK) {
                            Tools.CopySingleFile(fdg.FileName, location);
                            MessageBox.Show("Saved recording to: " + location +
                            "\nFinal saved: " + fdg.FileName);
                        }
                    } else {
                        MessageBox.Show("Saved recording to: " + location);
                    }
                }
            }catch(Exception err) {
                MessageBox.Show(err.ToString());
            }
        }

        private void Menu_Attach_Click(object sender, EventArgs e) {
            Hide();

            Detached main = MainForm.m.mainPlayer;
            main.AttachPlayerToThis(this, new Point((int)Math.Round(main.Width / 2f),
                (int)Math.Round(main.Height / 2f)), VideoSettings.CopyType.NoCopy);
        }
    }

}
