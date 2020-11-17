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
        public Detached otherD;

        public bool thermalCam;

        public bool isActive;

        public void InitTimer() {
            CheckTypeToDisplay();
        }

        void StartTimer() {
            if (!CheckCam()) {
                if (thermalCam) {
                    HideAll();
                } else {
                    HideNotFOV();
                    l_FOV.Text = "Camera check failed!";
                }
                return;
            }

            UpdateTimer = new Timer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            int updateInterval = int.Parse(ConfigControl.updateMs);
            if (updateInterval > 0) {
                UpdateTimer.Interval = updateInterval;
                UpdateTimer.Enabled = true;
            }
            isActive = true;
        }

        public void StopTimer() {
            UpdateTimer.Stop();
        }

        public bool CheckCam() {
            bool result = CameraCommunicate.CheckPelcoCam().Result;
            
            if (!result) {
                HideAll();
            } else {
                ShowAll();
            }

            return result;
        }

        public void HideAll() {
            l_Pan.Hide();
            l_Tilt.Hide();
            l_FOV.Hide();
        }

        public void ShowAll() {
            if (!thermalCam) {
                l_Pan.Show();
                l_Tilt.Show();
            }
            l_FOV.Show();
        }

        public void HideNotFOV() {
            l_Pan.Hide();
            l_Tilt.Hide();
        }

        void CheckTypeToDisplay() {
            string curType = d.cB_PlayerD_Type.Text;

            thermalCam = !curType.Contains("Daylight");

            if (!thermalCam) {
                if (otherD.myInfoRef.isActive) {
                    otherD.myInfoRef.StopTimer();
                }
                StartTimer();
            } else {
                if (!otherD.myInfoRef.isActive) {
                    StartTimer();
                } else {
                    HideNotFOV();
                }
            }

            //check if the current player is the only one and also if its a thermal or daylight. use the current sock ip
            //not the d player ip.

        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            UpdateAll();
        }

        async Task UpdateAll() {
            if (!thermalCam) {
                GetPan();
                GetTilt();
            }
            GetFOV();
        }

        async Task ReadResult(byte[] query) {
            Uri currentlyConnected = new Uri(CameraCommunicate.GetSockEndpoint());
            string result = CameraCommunicate.Query(query, currentlyConnected).Result;

            if (result.Length < 14) {
                return;
            }

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

            //FF 01 00 5B 00 69 C5 = 1.05
            //FF 01 00 5B FF 70 CB = 653.92  
            //FF 01 00 5B F6 C6 18 = 631.74
            //FF 01 00 5B 03 2C 8B = 8.12

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