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

        static OtherCamCom.CamConfig myConfig;

        public void InitializeTimer() {
            if (AsyncCamCom.sock.Connected) {
                CheckTypeToDisplay();
                commandPos = 0;
            } else {
                MessageBox.Show("Couldn't start the info panel collection socket!");
            }
        }

        async Task StartTicking() {
            try {
                myConfig = await OtherCamCom.CheckConfiguration();
                GenCommands();

                if (ConfigControl.updateMs.intVal > 0) {
                    UpdateTimer.Interval = ConfigControl.updateMs.intVal;
                    UpdateTimer.Enabled = true;
                    UpdateTimer.Start();
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

        public async Task<bool> CheckCam() {
            try {
                if (!await AsyncCamCom.TryConnect(true).ConfigureAwait(false)) {
                    return false;
                }

                byte[] send = new byte[7];
                if (thermalCam) {
                    send = new byte[] { 0xFF, 0x00, 0x00, 0x53, 0x00, 0x00, 0x53 };
                } else {
                    send = new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 };
                }

                string result = await AsyncCamCom.QueryNewCommand(send).ConfigureAwait(false);

                if (result == OtherCamCom.defaultResult) {
                    return false;
                } else {
                    return true;
                }
            } catch {
                return false;
            }
        }

        public void HideAll() {
            try {
                l_Pan.Hide();
                l_Tilt.Hide();
                l_FOV.Hide();
                l_TFOV.Hide();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public void ShowAll() {
            try {
                l_Pan.Show();
                l_Tilt.Show();
                l_FOV.Show();
                l_TFOV.Show();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        void CheckTypeToDisplay() {
            try {
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
            }catch(Exception e) {
                MessageBox.Show("INFO TYPE\n" + e.ToString());
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            Console.WriteLine("CONNECTED : " + AsyncCamCom.sock.Connected.ToString());
            if (CommandQueue.lowPriority && AsyncCamCom.sock.Connected) {
                UpdateAll();
            }
        }

        async Task UpdateAll() {
            try {
                if (commandPos >= 4) {
                    commandPos = 0;
                }

                switch (commandPos) {
                    case 0:
                        AsyncCamCom.QueueRepeatingCommand(panID);
                        break;
                    case 1:
                        AsyncCamCom.QueueRepeatingCommand(tiltID);
                        break;
                    case 2:
                        AsyncCamCom.QueueRepeatingCommand(fovID);
                        break;
                    case 3:
                        AsyncCamCom.QueueRepeatingCommand(tFovID);
                        break;
                }

                l_Tilt.Text = "TILT: " + tilt.ToString() + " °";
                l_FOV.Text = "DAYLIGHT FOV: " + fov.ToString() + " °";
                l_TFOV.Text = "THERMAL FOV: " + tfov.ToString() + " °";
                l_Pan.Text = "PAN: " + pan.ToString() + " °";
                commandPos++;

            } catch (Exception e){
                MessageBox.Show(e.ToString());
            }
        }

        static float pan;
        static float tilt;
        static float fov;
        static float tfov;

        public static async Task ReadResult(string result) {
            try {
                string commandType = result.Substring(9, 2);

                switch (commandType) {
                    case "59": //pan
                        pan = OtherCamCom.CalculatePan(result, myConfig);
                        break;
                    case "5B": //tilt
                        tilt = OtherCamCom.CalculateTilt(result, myConfig);
                        break;
                    case "5D": //fov
                        if (commandPos == 3) {
                            fov = OtherCamCom.ReturnedHexValToFloat(result);
                        } else {
                            tfov = OtherCamCom.ReturnedHexValToFloat(result);
                        }
                        break;
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
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