﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class InfoPanel : Form { //PROBLEM: CURRENTLY THIS LOCKS UP THE MAIN SOCK SO WHEN ITS ACTIVE, 
        //COMMANDS/RESPONSES MAY GET MIXED UP

        public InfoPanel() {
            InitializeComponent();
            HideAll();
            UpdateTimer = new Timer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
        }

        public Timer UpdateTimer;
        public Detached d;
        public Detached otherD;

        public bool thermalCam;

        public bool isActive;

        static int commandPos;

        int panID;
        int tiltID;
        int fovID;
        int tFovID;

        enum CamConfig {
            SSTraditional,
            Strict,
            RevTilt,
            Legacy
        }

        static CamConfig myConfig;

        public void InitializeTimer() {
            if (CameraCommunicate.sock.Connected) {
                //Uri currentlyConnected = new Uri("http://" + CameraCommunicate.GetSockEndpoint());
                //AsyncSocket.ConnectAsync(currentlyConnected);
                CheckTypeToDisplay();
                commandPos = 0;
            } else {
                MessageBox.Show("Couldn't start the info panel collection socket!");
            }
        }

        void StartTicking() {
            try {
                if (!CheckCam()) {
                    HideNotTFOV();
                    l_TFOV.Text = "Camera check failed!";
                    return;
                }

                CheckConfiguration();
                GenCommands();

                int updateInterval = Convert.ToInt32(Math.Round(float.Parse(ConfigControl.updateMs.intVal.ToString()) / 4f));
                if (updateInterval > 0) {
                    UpdateTimer.Interval = updateInterval;
                    UpdateTimer.Enabled = true;
                }
                isActive = true;
            } catch(Exception e) {
                MainForm.ShowPopup("Error in updating info panel!", "Failed to update info panel!", e.ToString());
            }
        }

        public void StopTicking() {
            HideAll();
            isActive = false;
            UpdateTimer.Stop();
        }

        public bool CheckCam() {
            bool result = CameraCommunicate.CheckPelcoCam(thermalCam).Result;
            return result;
        }

        public void HideAll() {
            l_Pan.Hide();
            l_Tilt.Hide();
            l_FOV.Hide();
            l_TFOV.Hide();
        }

        public void ShowAll() {
            l_Pan.Show();
            l_Tilt.Show();
            l_FOV.Show();
            l_TFOV.Show();
        }

        public void HideNotTFOV() {
            l_Pan.Hide();
            l_Tilt.Hide();
            l_FOV.Hide();
        }

        public void HideTFOV() {
            l_TFOV.Hide();
        }

        void CheckTypeToDisplay() {
            string curType = d.cB_PlayerD_Type.Text;

            thermalCam = !curType.Contains("Daylight");

            if (thermalCam) {
                if (otherD.myInfoRef.isActive) {
                    HideAll();
                    StopTicking();
                } else {
                    ShowAll();
                    StartTicking();
                }
            } else {
                if (otherD.myInfoRef.isActive && otherD.myInfoRef.thermalCam) {
                    otherD.myInfoRef.StopTicking();
                }
                StartTicking();
            }

        }
        
        void CheckConfiguration() {
            string result = GetQueryResults(new byte[] { 0xFF, 0x01, 0x03, 0x6B, 0x00, 0x00, 0x6F });
            int type = int.Parse(result.Substring(12, 1));

            switch (type) {
                case 0:
                    myConfig = CamConfig.SSTraditional;
                    break;
                case 1:
                    myConfig = CamConfig.Strict;
                    break;
                case 2:
                    myConfig = CamConfig.RevTilt;
                    break;
                case 3:
                    myConfig = CamConfig.Legacy;
                    break;
                default:
                    myConfig = CamConfig.Strict;
                    break;
            }
           
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            if (CommandQueue.lowPriority && AsyncCameraCommunicate.sock.Connected) {
                Console.WriteLine("lowprio");
                UpdateAll();
            }
        }

        async Task UpdateAll() {
            if (commandPos == 4) {
                commandPos = 0;
            }

            switch (commandPos) {
                case 0:
                    GetPan();
                    break;
                case 1:
                    GetTilt();
                    break;
                case 2:
                    GetFOV();
                    break;
                case 3:
                    GetThermalFOV();
                    break;
            }

            commandPos++;
            l_Tilt.Text = "TILT: " + tilt.ToString() + " °";
            l_FOV.Text = "DAYLIGHT FOV: " + fov.ToString() + " °";
            l_TFOV.Text = "THERMAL FOV: " + tfov.ToString() + " °";
            l_Pan.Text = "PAN: " + pan.ToString() + " °";
        }

        string GetQueryResults(byte[] query) {
            Uri currentlyConnected = new Uri("http://" + CameraCommunicate.GetSockEndpoint());
            if (currentlyConnected == null) {
                return null;
            }
            string result = CameraCommunicate.Query(query, currentlyConnected).Result.Trim();

            //if(thermalCam)
            //MessageBox.Show(result);

            return result;
        }

        static float pan;
        static float tilt;
        static float fov;
        static float tfov;

        public static async Task ReadResult(string result) {
            //string result = GetQueryResults(query);
            string commandType = result.Substring(9, 2);

            //finalResult += " °";

            switch (commandType) {
                case "59": //pan
                    pan = CalculatePan(result);
                    break;
                case "5B": //tilt
                    tilt = CalculateTilt(result);
                    break;
                case "5D": //fov
                    if (commandPos == 3) {
                        fov = ReturnedHexValToFloat(result);
                    } else {
                        tfov = ReturnedHexValToFloat(result);
                    }
                    break;
                }
        }

        static float CalculateTilt(string code) {
            float full = ReturnedHexValToFloat(code);

            switch (myConfig) {
                case CamConfig.SSTraditional:
                case CamConfig.Legacy:

                    break;
                case CamConfig.Strict:
                    break;
                case CamConfig.RevTilt:
                    break;

            }
            //SSTraditional and Legacy
                //Tilt 0-90 positive, -0.01 - -90 negative
                //0-9000 = positive, -1 - -9000 (65535-56536) = negative

            //Strict Only
                //horizontal (normally 90 degrees clockwise) = 0
                //vertical = 270, increasing value goes clockwise(through negative)
                //illegal range 90.01 - 269.99
                //65535-36001 illegal, 00000-35999 legal

            //RevTilt
                //Same as Strict, anticlockwise instead of clockwise
                //0-9000 = from horizontal to vertically up, etc
            return full;
        }

        static float CalculatePan(string code) {
            float finalResult = 0;
            float full = ReturnedHexValToFloat(code);

            switch (myConfig) {
                case CamConfig.SSTraditional:
                case CamConfig.Legacy:

                    if (full <= 360.00f) {
                        finalResult = full;
                    } else {
                        finalResult = -(655.36f - full);
                    }

                    break;
                case CamConfig.Strict:
                case CamConfig.RevTilt:
                    finalResult = ReturnedHexValToFloat(code); //same thing anyway
                    break;
            }

            return finalResult;
        }

        static float ReturnedHexValToFloat(string code) {
            string combined = GetCombinedDataInHex(code);

            string added = int.Parse(combined, System.Globalization.NumberStyles.HexNumber).ToString();
            float finalResult = float.Parse(added) / 100f;
            return finalResult;
        }

        static string GetCombinedDataInHex(string code) {
            string d1 = code.Substring(12, 2);
            string d2 = code.Substring(15, 2);

            return (d1 + d2);
        }

        void GenCommands() {
            panID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, true).id;
            tiltID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, true).id;
            fovID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x55, 0x00, 0x00, 0x56 }, true).id;
            tFovID = new Command(new byte[] { 0xFF, 0x02, 0x00, 0x55, 0x00, 0x00, 0x57 }, true).id;
        }

        public async Task GetPan() {
            //CameraCommunicate.SendToSocket(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, true);
            AsyncCameraCommunicate.QueueRepeatingCommand(panID);
        }

        public async Task GetTilt() {
            //CameraCommunicate.SendToSocket(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, true);
            AsyncCameraCommunicate.QueueRepeatingCommand(tiltID);
        }

        public async Task GetFOV() {
            //CameraCommunicate.SendToSocket(new byte[] { 0xFF, 0x01, 0x00, 0x55, 0x00, 0x00, 0x56 }, true);
            AsyncCameraCommunicate.QueueRepeatingCommand(fovID);
        }

        public async Task GetThermalFOV() {
            //CameraCommunicate.SendToSocket(new byte[] { 0xFF, 0x02, 0x00, 0x55, 0x00, 0x00, 0x57 }, true);
            AsyncCameraCommunicate.QueueRepeatingCommand(tFovID);
        }


    }
}