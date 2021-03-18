using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public partial class ControlPanel : Form {
    
        public Panel myPanel;

        public ControlPanel() {
            InitializeComponent();
            Program.cp = this;
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            PTZZoom(D.Zoom.Tele);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            PTZZoom(D.Zoom.Wide);
        }
        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraFocus(MainForm.m.MakeAdr(), D.Focus.Far));
        }

        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraFocus(MainForm.m.MakeAdr(), D.Focus.Near));
        }

        public void PTZZoom(D.Zoom dir) {
            AsyncCamCom.SendNonAsync(D.protocol.CameraZoom(MainForm.m.MakeAdr(), dir));
        }

        private void b_PTZ_Any_MouseUp(object sender, MouseEventArgs e) {
            DelayStop();
        }

        async Task DelayStop() {
            if (!AsyncCamCom.sock.Connected) {
                return;
            }
            AsyncCamCom.SendNonAsync(D.protocol.CameraStop(MainForm.m.MakeAdr()));
            await Task.Delay(ConfigControl.commandRateMs.intVal).ConfigureAwait(false);
            AsyncCamCom.SendNonAsync(D.protocol.CameraStop(MainForm.m.MakeAdr()));
        }

        private void ControlPanel_Load(object sender, EventArgs e) {
            MainForm.m.setPage.PopulateSettingText();
        }

        public void StopCam() {
            if (check_IPCon_KeyboardCon.Checked == true) {
                CustomScriptCommands.QuickCommand("stop", false);
            }
        }

        public void KeyControl(Keys k) {
            if (check_IPCon_KeyboardCon.Checked == true) {
                uint ptSpeed = Convert.ToUInt32(63);
                byte[] code = null;
                uint address = MainForm.m.MakeAdr();

                switch (k) { //maybe add diagonal support later
                    case Keys.Up:
                        code = D.protocol.CameraTilt(address, D.Tilt.Up, ptSpeed);
                        break;
                    case Keys.Down:
                        code = D.protocol.CameraTilt(address, D.Tilt.Down, ptSpeed);
                        break;
                    case Keys.Left:
                        code = D.protocol.CameraPan(address, D.Pan.Left, ptSpeed);
                        break;
                    case Keys.Right:
                        code = D.protocol.CameraPan(address, D.Pan.Right, ptSpeed);
                        break;
                    case Keys.Enter:
                        code = D.protocol.CameraZoom(address, D.Zoom.Tele);
                        break;
                    case Keys.Escape:
                        code = D.protocol.CameraZoom(address, D.Zoom.Wide);
                        break;
                }

                AsyncCamCom.SendNewCommand(code);
            }
        }

        public void Tick() {
            try {
                Point coords = Joystick.coords;

                if (Joystick.distance != 0 && AsyncCamCom.sock.Connected) {
                    byte[] code = null;

                    uint adr = MainForm.m.MakeAdr();
                    int x = coords.X;
                    int y = coords.Y;

                    uint xSpeed = Convert.ToUInt32(Math.Abs(x));
                    uint ySpeed = Convert.ToUInt32(Math.Abs(y));

                    //diagonals
                    D.Pan p = D.Pan.Null;
                    D.Tilt t = D.Tilt.Null;

                    if (x < 0 && y < 0) {
                        p = D.Pan.Left;
                        t = D.Tilt.Down;
                    } else if (x > 0 && y < 0) {
                        p = D.Pan.Right;
                        t = D.Tilt.Down;
                    } else if (x < 0 && y > 0) {
                        p = D.Pan.Left;
                        t = D.Tilt.Up;
                    } else if (x > 0 && y > 0) {
                        p = D.Pan.Right;
                        t = D.Tilt.Up;
                    }
                    //

                    if (p != D.Pan.Null && t != D.Tilt.Null) {
                        code = D.protocol.CameraPanTilt(adr, p, xSpeed, t, ySpeed);
                    } else {
                        //horizontal/vertical only
                        if (x > 0 && y == 0) {
                            code = D.protocol.CameraPan(adr, D.Pan.Right, xSpeed);
                        } else if (x < 0 && y == 0) {
                            code = D.protocol.CameraPan(adr, D.Pan.Left, xSpeed);
                        } else if (y > 0 && x == 0) {
                            code = D.protocol.CameraTilt(adr, D.Tilt.Up, ySpeed);
                        } else if (y < 0 && x == 0) {
                            code = D.protocol.CameraTilt(adr, D.Tilt.Down, ySpeed);
                        }
                        //
                    }

                    if (code != null)
                        AsyncCamCom.SendNonAsync(code);
                }

            } catch { }
        }

        private void Joystick_MouseUp(object sender, MouseEventArgs e) {
            if(AsyncCamCom.sock.Connected)
                CustomScriptCommands.QuickCommand("stop", false);
        }

    }
}
