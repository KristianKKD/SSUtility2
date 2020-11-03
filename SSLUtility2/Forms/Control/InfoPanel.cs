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
            mySock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
            myUri = new Uri(d.tB_PlayerD_SimpleAdr.Text);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(myUri.Host), myUri.Port);
            mySock.Connect(ep);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            UpdateAll();
        }

        async Task UpdateAll() {
            if (d.VLCPlayer_D.playlist.isPlaying) {
                l_Pan.Text = "PAN: " + GetPan().Result;
                l_Tilt.Text = "TILT: " + GetTilt().Result;
                //l_FOV.Text = "FOV: " + GetFOV().Result;
            }
        }

        async Task<string> ReadResult(string result) {
            //string result = CameraCommunicate.StringFromSock(d.GetCombined().Host, d.GetCombined().Port.ToString(), null).Result;
            string commandType = result.Substring(9, 2);
            string d1 = result.Substring(12, 2);
            string d2 = result.Substring(15, 2);

            string finalResult = uint.Parse(d1, System.Globalization.NumberStyles.HexNumber).ToString()
                        + " " + uint.Parse(d2, System.Globalization.NumberStyles.HexNumber).ToString();
            switch (commandType) {
                case "59":
                    finalResult += " °";
                    break;
                case "5B":
                    finalResult += " °";
                    break;
            }

            //"xx xx xx 5Y YY YY xx"
            return finalResult;
        }

        public async Task<string> GetPan() {
            string response = CameraCommunicate.Query(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, mySock, myUri).Result;
            return ReadResult(response).Result;
        }

        public async Task<string> GetTilt() {
            string response = CameraCommunicate.Query(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, mySock, myUri).Result;
            return ReadResult(response).Result;
        }

        public async Task<string> GetFOV() {
            return null;
        }


    }
}