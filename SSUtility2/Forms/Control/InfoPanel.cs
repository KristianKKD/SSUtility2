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

        int commandPos = 0;

        int panID;
        int tiltID;
        int fovID;
        int tFovID;

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
                if (MainForm.m.lite)
                    return;

                if (!this.IsHandleCreated)
                    this.CreateHandle();

                if (isActive) {
                    HideAll();
                    isActive = false;
                    MainForm.m.Menu_Settings_Info.Text = "Enable Info Panel";
                    return;
                }

                GenCommands();

                isActive = true;
                UpdateNext();
                MainForm.m.Menu_Settings_Info.Text = "Disable Info Panel";
                ShowAll();
            } catch (Exception e) {
                Tools.ShowPopup("Error in updating info panel!\nShow more?", "Failed to update info panel!", e.ToString());
                isActive = false;
            }
        }

        public async Task InfoPanelTick() {
            try {
                tickCount++;

                if (isActive && isCamera) {
                    if (tickCount > CommandQueue.commandRate)
                        UpdateNext();
                } else {
                    if (!isCamera) {
                        if (!MainForm.m.mainPlayer.IsPlaying() && !MainForm.m.lite
                            && timeoutTime >= 30) {
                            timeoutTime = 0;
                            CheckForCamera();
                        } else {
                            timeoutTime++;
                        }
                    }
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public async Task CheckForCamera() {
            try {
                Console.WriteLine("checking for cam");
                if (ConfigControl.forceCamera.boolVal && MainForm.m.finishedLoading) {
                    isCamera = true;
                    SettingsPage.UpdateCamType();
                } else if (AsyncCamCom.sock.Connected) {
                    OtherCamCom.CamConfig cfg = await OtherCamCom.CheckConfiguration();
                    if (cfg != OtherCamCom.CamConfig.Null) {
                        isCamera = true;
                    }
                    MainForm.m.setPage.UpdateCamConfig(cfg);
                } else {
                    isCamera = false;
                    isActive = false;
                }
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public async Task UpdateNext() {
            try {
                if (!isActive)
                    return;

                if (commandPos >= 4) {
                    commandPos = 0;
                    return;
                }

                tickCount = 0;

                int id = 0;
                switch (commandPos) {
                    case 0:
                        id = panID;
                        break;
                    case 1:
                        id = tiltID;
                        break;
                    case 2:
                        id = fovID;
                        break;
                    case 3:
                        id = tFovID;
                        break;
                }

                string result = await AsyncCamCom.QueueRepeatingCommand(id);
                if (result == OtherCamCom.defaultResult) {
                    UpdateNext();
                    return;
                }

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
                    default:
                        return;
                }

                Invoke((MethodInvoker)delegate {
                    l_Tilt.Text = "TILT: " + tilt.ToString() + " °";
                    l_FOV.Text = "DAYLIGHT FOV: " + fov.ToString() + " °";
                    l_TFOV.Text = "THERMAL FOV: " + tfov.ToString() + " °";
                    l_Pan.Text = "PAN: " + pan.ToString() + " °";
                });

                commandPos++;
                UpdateNext();
            } catch (Exception e){
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