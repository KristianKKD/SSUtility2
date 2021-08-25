using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPlayerNetSDK;
using Kaiser;

namespace SSUtility2 {

    public partial class Detached : Form {

        public VideoSettings settings;
        public List<Detached> attachedPlayers = new List<Detached>();

        public FFMPEGRecord recorder;

        public Detached(bool isMain, bool autoPlay = false) {
            InitializeComponent();
            settings = new VideoSettings(this, isMain);
            CreateHandle();
            if (isMain)
                p_Player = MainForm.m.p_PlayerPanel;
            else if (autoPlay && settings.cB_RTSP.Items.Count > 1)
                settings.cB_RTSP.SelectedIndex = 0;

            MainForm.m.detachedList.Add(this);
        }

        public void DestroyPlayer() {
            try {
                p_Player.Dispose();
            } catch { }
            try {
                VideoSettings.allSettings.Remove(settings);
                settings.Dispose();
            } catch { }
            try {
                Dispose();
            } catch { }
        }

        public void HideAttached() {
            foreach (Detached d in attachedPlayers)
                d.p_Player.Hide();
        }

        public void ShowAttached() {
            foreach (Detached d in attachedPlayers) {
                d.p_Player.Visible = true;
                d.p_Player.BringToFront();
            }
        }

        public async Task StopPlaying() {
            int ret = PlayerSdk.EasyPlayer_CloseStream(settings.channelID);
            if (ret == 0)
                settings.channelID = -1;

            p_Player.BackColor = Color.Black;
            p_Player.Refresh();
        }

        public async Task Play(bool showErrors, bool doPing = true) {
            try {
                if (MainForm.m.lite && settings.isMainPlayer) {
                    settings.channelID = 1;
                    return;
                }

                if (InvokeRequired) {
                    Invoke((MethodInvoker)delegate {
                        Play(showErrors, doPing);
                    });
                    return;
                }

                string fullAdr = settings.GetCombined();

                Uri combinedUrl = ConfirmAdr(showErrors, fullAdr, doPing);
                if (combinedUrl == null)
                    return;

                Console.WriteLine("playing " + combinedUrl.ToString());

                if (IsPlaying())
                    StopPlaying();

                settings.channelID = PlayerSdk.EasyPlayer_OpenStream(combinedUrl.ToString(),
                    p_Player.Handle, PlayerSdk.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI,
                        1, "", "", null, IntPtr.Zero, false);

                if (IsPlaying())
                    PlayerSdk.EasyPlayer_SetFrameCache(settings.channelID, 3);
                else {
                    if (showErrors)
                        MessageBox.Show("Failed to attach to channel!");
                    StopPlaying();
                }
            } catch (Exception e) {
                if(showErrors)
                    Tools.ShowPopup("Failed to init player stream!\nShow more?", "Error Occurred!", e.ToString());
                Console.WriteLine("PLAY " + e.ToString());
                StopPlaying();
                return;
            }
        }

        public Uri ConfirmAdr(bool showErrors, string fullAdr, bool doPing) {
            try {
                Uri newUri = null;
                string errorMsg = "";

                try {
                    newUri = new Uri(fullAdr);
                } catch {
                    errorMsg = "Address was invalid!\n";
                }

                if (newUri != null && !ConfigControl.ignoreAddress.boolVal
                    && settings.isMainPlayer && doPing) {
                    if (!OtherCamCom.PingAdr(newUri.Host).Result)
                        errorMsg += "Address had no RTSP stream attached!\n";
                }

                if (errorMsg != "") {
                    if (showErrors)
                        MessageBox.Show(errorMsg);
                    return null;
                }

                return newUri;
            } catch (Exception e) {
                if (showErrors)
                    Tools.ShowPopup("Failed to parse address!\nShow more?", "Error Occurred!", e.ToString());
                return null;
            }
        }

        public SizeablePanel AttachPlayerToThis(Detached secondPlayer, Point pos, bool playOnLaunch = true) {
            try {
                secondPlayer.Hide();
                attachedPlayers.Add(secondPlayer);
                secondPlayer.settings.isAttached = true;

                SizeablePanel sP_Secondary = new SizeablePanel();
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

                //string name = "Player " + (MainForm.m.mainPlayer.attachedPlayers.Count + 1).ToString();
                //secondPlayer.settings.tP_Main.Text = name;

                settings.AddPage(secondPlayer);
                secondPlayer.settings.b_Detach.Text = "Detach";

                secondPlayer.settings.LoadTabName();

                return sP_Secondary;
            } catch (Exception e) {
                Tools.ShowPopup("Failed to attach player!\nShow more?", "Error Occurred!", e.ToString());
                return null;
            }
        }

        public void DestroyAll() {
            List<Detached> dList = new List<Detached>();
            foreach (Detached d in attachedPlayers)
                dList.Add(d);

            foreach (Detached d in dList) {
                d.RemoveSelfFromList();
                attachedPlayers.Remove(d);
                d.DestroyPlayer();
            }
        }

        public void Detach(Detached detachable, bool destroy) {
            TabPage tp = detachable.settings.myLinkedPage;
            if (tp != null && settings.tC_PlayerSettings.TabPages.Contains(tp))
                settings.tC_PlayerSettings.TabPages.Remove(tp);

            detachable.RemoveSelfFromList();

            attachedPlayers.Remove(detachable);

            if (destroy) {
                detachable.DestroyPlayer();
                return;
            }

            detachable.settings.myLinkedPage = null;
            detachable.settings.isAttached = false;

            bool wasPlaying = false;
            if (detachable.IsPlaying())
                wasPlaying = true;

            detachable.StopPlaying();
            detachable.settings.b_Detach.Text = "Attach";

            detachable.p_Player.Dispose();

            detachable.p_Player = (Panel)Tools.GetAllType(detachable, typeof(Panel)).First();
            detachable.Show();

            if (wasPlaying)
                detachable.Play(false, false);
        }

        private void Menu_Settings_Click(object sender, EventArgs e) {
            settings.Show();
        }

        private void Menu_Attach_Click(object sender, EventArgs e) {
            Hide();

            Detached main = MainForm.m.mainPlayer;
            main.AttachPlayerToThis(this, new Point((int)Math.Round(main.Width / 2f),
                (int)Math.Round(main.Height / 2f)));
        }

        public void RefreshPlayers() {
            p_Player.Refresh();
            foreach (Detached d in attachedPlayers) {
                d.p_Player.Refresh();
            }
        }

        public bool IsPlaying() {
            return settings.channelID > 0;
        }

        private void Menu_Recording_Snapshot_Click(object sender, EventArgs e) {
            Tools.SaveSnap(this);
        }

        private void Menu_Recording_Video_Click(object sender, EventArgs e) {
            recorder = Tools.ToggleRecord(this, Menu_Recording_Video, Menu_Recording_StopRecording);
        }

        private void Menu_Recording_StopRecording_Click(object sender, EventArgs e) {
            recorder = Tools.ToggleRecord(this, Menu_Recording_Video, Menu_Recording_StopRecording);
        }

        private void Detached_FormClosing(object sender, FormClosingEventArgs e) {
            RemoveSelfFromList();
        }

        public void RemoveSelfFromList() {
            FFMPEGRecord.StopSingleInGlobal(this);
            MainForm.m.detachedList.Remove(this);
        }
    }

}
