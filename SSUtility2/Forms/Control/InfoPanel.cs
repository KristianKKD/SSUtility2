using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class InfoPanel : Form {

        public InfoPanel() {
            InitializeComponent();
            i = this;
        }

        public static InfoPanel i;

        public Panel myPanel;

        public bool thermalCam;

        public bool isActive;

        public bool isCamera = false;

        int panID;
        int tiltID;
        int fovID;
        int tFovID;

        static int commandPos = 0;
        int timeoutTime = 0;

        static float pan;
        static float tilt;
        static float fov;
        static float tfov;

        static OtherCamCom.CamConfig myConfig;

        public void HideAll() {
            try {
                Invoke((MethodInvoker)delegate {
                    myPanel.Hide();
                    myPanel.SendToBack();
                });
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public void ShowAll() {
            try {
                Invoke((MethodInvoker)delegate {
                    myPanel.Show();
                    myPanel.BringToFront();
                });
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public async Task StartStopTicking() {
            try {
                if (!this.IsHandleCreated) {
                    this.CreateHandle();
                }

                if (isActive) {
                    StopTicking();
                    return;
                }
                GenCommands();
                myConfig = await OtherCamCom.CheckConfiguration().ConfigureAwait(false);

                isActive = true;
                MainForm.m.Menu_Video_Info.Text = "Disable Info Panel";
                ShowAll();
            } catch (Exception e) {
                Tools.ShowPopup("Error in updating info panel!\nShow more?", "Failed to update info panel!", e.ToString());
                isActive = false;
            }
        }

        public void StopTicking() {
            HideAll();
            isActive = false;
            MainForm.m.Menu_Video_Info.Text = "Enable Info Panel";
        }

        public async Task InfoPanelTick() {
            try {
                if (!AsyncCamCom.sock.Connected) {
                    return;
                }

                if (isActive && isCamera) {
                    UpdateAll();
                } else {
                    if (!isCamera) {
                        if (MainForm.m.mainPlayer.settings.isPlaying && timeoutTime < CommandQueue.commandRetries) {
                            timeoutTime++;
                        } else {
                            timeoutTime = 0;
                            CheckForCamera();
                        }
                    }
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
}

        public async Task CheckForCamera() {
            try {
                if (await CheckCam().ConfigureAwait(false)) {
                    isCamera = true;
                    myConfig = await OtherCamCom.CheckConfiguration().ConfigureAwait(false);
                    MainForm.m.mainPlayer.EnableSecond();
                } else {
                    MainForm.m.Menu_Video_Info.Enabled = false;
                    MainForm.m.Menu_Video_Swap.Enabled = false;
                    isCamera = false;
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
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

        private async Task<bool> CheckCam() {
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

        void GenCommands() {
            try {
                panID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, true).id;
                tiltID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, true).id;
                fovID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x55, 0x00, 0x00, 0x56 }, true).id;
                tFovID = new Command(new byte[] { 0xFF, 0x02, 0x00, 0x55, 0x00, 0x00, 0x57 }, true).id;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

    }
}