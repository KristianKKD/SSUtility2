using System;
using System.Windows.Forms;

namespace BigBigLoader
{
    public partial class Detached : Form
    {
        private MainForm mainRef;

        public MainForm MainRef {
            get {
                return mainRef;
            }
            set {
                mainRef = value;
            }
        }

        public Detached() {
            InitializeComponent();
        }

        private void b_PlayerD_Play_Click(object sender, EventArgs e) {
            mainRef.Play(VLCPlayer_D, "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov");
        }

        private void b_PlayerD_SaveSnap_Click(object sender, EventArgs e) {
            mainRef.SaveSnap(VLCPlayer_D);
        }

        private void checkB_PlayerD_Manual_CheckedChanged(object sender, EventArgs e) {
            mainRef.ExtendOptions(checkB_PlayerD_Manual.Checked, gB_PlayerD_Extended, gB_PlayerD_Simple);
        }
    }
}
