using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class InfoPanel : Form {

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

        static OtherCameraCommunication.CamConfig myConfig;

        public void InitializeTimer() {
            if (CameraCommunicate.sock.Connected) {
                CheckTypeToDisplay();
                commandPos = 0;
            } else {
                MessageBox.Show("Couldn't start the info panel collection socket!");
            }
        }

        async Task StartTicking() {
            try {
                if (!CheckCam()) {
                    HideNotTFOV();
                    l_TFOV.Text = "Camera check failed!";
                    await Task.Delay(3000).ConfigureAwait(false);
                    HideAll();
                    d.check_PlayerD_StatsEnabled.Checked = false;
                    l_TFOV.Text = "THERMAL FOV: " + tfov;
                    return;
                }

                myConfig = OtherCameraCommunication.CheckConfiguration().Result;
                GenCommands();

                if (ConfigControl.updateMs.intVal > 0) {
                    UpdateTimer.Interval = ConfigControl.updateMs.intVal;
                    UpdateTimer.Enabled = true;
                }
                isActive = true;
            } catch(Exception e) {
                MainForm.ShowPopup("Error in updating info panel!\nShow more?", "Failed to update info panel!", e.ToString());
            }
        }

        public void UpdateTickInterval() {
            UpdateTimer.Interval = ConfigControl.updateMs.intVal;
        }

        public void StopTicking() {
            HideAll();
            isActive = false;
            UpdateTimer.Stop();
        }

        public bool CheckCam() {
            try {
                if (!AsyncCameraCommunicate.TryConnect().Result) {
                    return false;
                }

                byte[] send = new byte[7];
                if (thermalCam) {
                    send = new byte[] { 0xFF, 0x00, 0x00, 0x53, 0x00, 0x00, 0x53 };
                } else {
                    send = new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 };
                }

                string result = AsyncCameraCommunicate.QueryNewCommand(send).Result;

                if (result == OtherCameraCommunication.defaultResult) {
                    return false;
                } else {
                    return true;
                }
            } catch {
                return false;
            }
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
        
       

        private void UpdateTimer_Tick(object sender, EventArgs e) { //maybe have command reference this instead
            if (CommandQueue.lowPriority && AsyncCameraCommunicate.sock.Connected) {
                UpdateAll();
            }
        }

        async Task UpdateAll() {
            if (commandPos == 4) {
                commandPos = 0;
            }

            switch (commandPos) {
                case 0:
                    AsyncCameraCommunicate.QueueRepeatingCommand(panID);
                    break;
                case 1:
                    AsyncCameraCommunicate.QueueRepeatingCommand(tiltID);
                    break;
                case 2:
                    AsyncCameraCommunicate.QueueRepeatingCommand(fovID);
                    break;
                case 3:
                    AsyncCameraCommunicate.QueueRepeatingCommand(tFovID);
                    break;
            }

            commandPos++;
            l_Tilt.Text = "TILT: " + tilt.ToString() + " °";
            l_FOV.Text = "DAYLIGHT FOV: " + fov.ToString() + " °";
            l_TFOV.Text = "THERMAL FOV: " + tfov.ToString() + " °";
            l_Pan.Text = "PAN: " + pan.ToString() + " °";
        }

        static float pan;
        static float tilt;
        static float fov;
        static float tfov;

        public static async Task ReadResult(string result) {
            string commandType = result.Substring(9, 2);

            switch (commandType) {
                case "59": //pan
                    pan = OtherCameraCommunication.CalculatePan(result, myConfig);
                    break;
                case "5B": //tilt
                    tilt = OtherCameraCommunication.CalculateTilt(result, myConfig);
                    break;
                case "5D": //fov
                    if (commandPos == 3) {
                        fov = OtherCameraCommunication.ReturnedHexValToFloat(result);
                    } else {
                        tfov = OtherCameraCommunication.ReturnedHexValToFloat(result);
                    }
                    break;
                }
        }

        void GenCommands() {
            panID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, true).id;
            tiltID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, true).id;
            fovID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x55, 0x00, 0x00, 0x56 }, true).id;
            tFovID = new Command(new byte[] { 0xFF, 0x02, 0x00, 0x55, 0x00, 0x00, 0x57 }, true).id;
        }

    }
}