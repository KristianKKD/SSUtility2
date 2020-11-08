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

        public void InitTimer() {
            UpdateTimer = new Timer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Interval = int.Parse(ConfigControl.updateMs);
            UpdateTimer.Enabled = true;
            TryConnect();
        }

        void TryConnect() {
            mySock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
            myUri = new Uri(d.tB_PlayerD_SimpleAdr.Text);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(myUri.Host), myUri.Port);
            mySock.Connect(ep);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            UpdateAll();
        }

        async Task UpdateAll() {
            if (d.VLCPlayer_D.playlist.isPlaying && mySock.Connected) {
                GetPan();
                GetTilt();
                GetFOV();
            } else if (d.VLCPlayer_D.playlist.isPlaying) {
                TryConnect();
            }
        }

        async Task ReadResult(byte[] query) {
            //string result = CameraCommunicate.StringFromSock(d.GetCombined().Host, d.GetCombined().Port.ToString(), null).Result;
            string result = CameraCommunicate.Query(query, mySock, myUri).Result;

            string commandType = result.Substring(9, 2);
            string d1 = result.Substring(12, 2);
            string d2 = result.Substring(15, 2);

            string finalResult = (float.Parse(d1 + d2, System.Globalization.NumberStyles.HexNumber) / 100f).ToString();
            finalResult += " °";

            switch (commandType) {
                case "59":
                    l_Pan.Text = "PAN: " + finalResult;
                    break;
                case "5B":
                    l_Pan.Text = "TILT: " + finalResult;
                    break;
            }

        }

        public async Task GetPan() {
            //string response = CameraCommunicate.Query(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, mySock, myUri).Result;
            //return ReadResult(response).Result;
            ReadResult(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 });
        }

        public async Task GetTilt() {
            //string response = CameraCommunicate.Query(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, mySock, myUri).Result;
            //return ReadResult(response).Result;
            ReadResult(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 });
        }

        public async Task<string> GetFOV() {
            return null;
        }


    }
}