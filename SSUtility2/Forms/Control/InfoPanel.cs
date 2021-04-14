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

        public bool isActive = false;

        public bool isCamera = false;
        
        public bool forcedQueueing = false;

        int panID;
        int tiltID;
        int fovID;
        int tFovID;

        public int commandPos = 0;
        int timeoutTime = 0;
        int tickCount = 0;

        static float pan;
        static float tilt;
        static float fov;
        static float tfov;


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

                if (MainForm.m.lite)
                    return;

                if (isActive) {
                    StopTicking();
                    return;
                }

                GenCommands();

                isActive = true;
                forcedQueueing = true;
                MainForm.m.Menu_Settings_Info.Text = "Disable Info Panel";
                ShowAll();
            } catch (Exception e) {
                Tools.ShowPopup("Error in updating info panel!\nShow more?", "Failed to update info panel!", e.ToString());
                isActive = false;
            }
        }

        public void StopTicking() {
            HideAll();
            isActive = false;
            MainForm.m.Menu_Settings_Info.Text = "Enable Info Panel";
        }


        public async Task InfoPanelTick() {
            try {
                tickCount++;

                if (!AsyncCamCom.sock.Connected) {
                    return;
                }

                if (isActive && isCamera) {
                    if (tickCount > CommandQueue.commandRate * 2 || forcedQueueing)
                        UpdateAll();
                } else {
                    if (!isCamera) {
                        if ((MainForm.m.mainPlayer.settings.isPlaying || MainForm.m.lite) && timeoutTime < CommandQueue.commandRetries) {
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
                if (ConfigControl.forceCamera.boolVal) {
                    SettingsPage.UpdateCamType();
                } else if (await OtherCamCom.CheckConfiguration() != OtherCamCom.CamConfig.Null) {
                    isCamera = true;
                    Detached.EnableSecond(true);
                } else {
                    isCamera = false;
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        async Task UpdateAll() {
            try {
                if (commandPos >= 4) {
                    forcedQueueing = false;
                    tickCount = 0;
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
                        pan = OtherCamCom.CalculatePan(result);
                        break;
                    case "5B": //tilt
                        tilt = OtherCamCom.CalculateTilt(result);
                        break;
                    case "5D": //fov
                        if (InfoPanel.i.commandPos == 3) {
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
            try {
                panID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, true, false, true, "querypan").id;
                tiltID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, true, false, true, "querytilt").id;
                fovID = new Command(new byte[] { 0xFF, 0x01, 0x00, 0x55, 0x00, 0x00, 0x56 }, true, false, true, "queryfov").id;
                tFovID = new Command(new byte[] { 0xFF, 0x02, 0x00, 0x55, 0x00, 0x00, 0x57 }, true, false, true, "querytfov").id;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

    }
}