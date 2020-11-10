using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class InfoPanel : Form {

        public InfoPanel() {
            InitializeComponent();
        }

        private Timer UpdateTimer;
        public Detached d;

        Socket mySock;
        Uri myUri;

        public bool fovOnly;

        public void InitTimer() {
            MessageBox.Show(fovOnly.ToString());
            UpdateTimer = new Timer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            int updateInterval = int.Parse(ConfigControl.updateMs);
            if (updateInterval > 0) {
                UpdateTimer.Interval = updateInterval;
                UpdateTimer.Enabled = true;
            }
            //TryConnect();
            //CameraCommunicate.CheckPelcoCam(d.GetCombined());
        }

        public void HideNotFOV() {
            l_Pan.Hide();
            l_Tilt.Hide();
            fovOnly = true;
        }

        void TryConnect() {
            mySock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
            myUri = new Uri(d.tB_PlayerD_SimpleAdr.Text);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(myUri.Host), myUri.Port);
            MessageBox.Show(d.VLCPlayer_D.playlist.currentItem.ToString());
            mySock.Connect(ep);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            UpdateAll();
        }

        async Task UpdateAll() {
            if (d.VLCPlayer_D.playlist.isPlaying && mySock.Connected) {
                if (!fovOnly) {
                    GetPan();
                    GetTilt();
                }
                GetFOV();
            } 
            //else if (d.VLCPlayer_D.playlist.isPlaying) {
            //    TryConnect();
            //}
        }

        async Task ReadResult(byte[] query) {
            string result = CameraCommunicate.Query(query, d.GetCombined()).Result;

            if (result.Length < 14) {
                return;
            }

            Console.WriteLine(result);

            string commandType = result.Substring(9, 2);
            string d1 = result.Substring(12, 2);
            string d2 = result.Substring(15, 2);

            string added = int.Parse(d1 + d2, System.Globalization.NumberStyles.HexNumber).ToString();

            string finalResult = (float.Parse(added) / 100f).ToString();
            finalResult += " °";


            switch (commandType) {
                case "59":
                    l_Pan.Text = "PAN: " + finalResult;
                    break;
                case "5B":
                    l_Tilt.Text = "TILT: " + finalResult;
                    break;
                case "6D":
                    l_FOV.Text = "FOV: " + finalResult;
                    break;
            }

        }

        public async Task GetPan() {
            ReadResult(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 });
        }

        public async Task GetTilt() {
            ReadResult(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 });
        }

        public async Task GetFOV() {
            ReadResult(new byte[] { 0xFF, 0x01, 0x0A, 0x6B, 0x00, 0x00, 0x76 });
        }


    }
}