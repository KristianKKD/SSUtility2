using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class ControlPanel : Form {
    
        public MainForm mainRef;
        public string pathToAuto;
        D protocol = new D();

        public ControlPanel() {
            InitializeComponent();
        }

        private void cB_IPCon_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string control = cB_IPCon_Type.Text;
            string port = "";

            if (control == "Encoder") {
                port = "6791";
            } else if (control == "MOXA nPort") {
                port = "4001";
            }

            tB_IPCon_Port.Text = port;
        }
        private void cB_IPCon_KeyboardCon_CheckedChanged(object sender, EventArgs e) {
            if (cB_IPCon_KeyboardCon.Checked) {
                b_PTZ_Up.Focus();
            }
        }

        private void b_PlayerL_Detach_Click(object sender, EventArgs e) {
            Detached d = mainRef.DetachVid();

            //d.cB_PlayerD_Type.SelectedIndex = cB_PlayerL_Type.SelectedIndex;
            //d.checkB_PlayerD_Manual.Checked = checkB_PlayerL_Manual.Checked;
            //d.tB_PlayerD_SimpleAdr.Text = tB_PlayerL_SimpleAdr.Text;
            //d.tB_PlayerD_Adr.Text = tB_PlayerL_Adr.Text;
            //d.tB_PlayerD_Port.Text = tB_PlayerL_Port.Text;
            //d.tB_PlayerD_RTSP.Text = tB_PlayerL_RTSP.Text;
            //d.tB_PlayerD_Buffering.Text = tB_PlayerL_Buffering.Text;
            //d.tB_PlayerD_Username.Text = tB_PlayerL_Username.Text;
            //d.tB_PlayerD_Password.Text = tB_PlayerL_Password.Text;
        }

        private void b_Presets_GoTo_Click(object sender, EventArgs e) {
            if (mainRef.tB_Presets_Number.Text.ToString() == "") {
                return;
            }
            byte presetnumber = Convert.ToByte(mainRef.tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(protocol.Preset(mainRef.MakeAdr(), presetnumber, D.PresetAction.Goto), l_IPCon_Connected);
        }

        private void b_Presets_Learn_Click(object sender, EventArgs e) {
            if (mainRef.tB_Presets_Number.Text.ToString() == "") {
                return;
            }
            byte presetnumber = Convert.ToByte(mainRef.tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(protocol.Preset(mainRef.MakeAdr(), presetnumber, D.PresetAction.Set), l_IPCon_Connected);
        }

        private void b_PTZ_Up_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(true, D.Tilt.Up);
        }

        private void b_PTZ_Down_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(true, D.Tilt.Down);
        }

        private void b_PTZ_Left_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(false, D.Tilt.Null, D.Pan.Left);
        }

        private void b_PTZ_Right_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(false, D.Tilt.Null, D.Pan.Right);
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZZoom(D.Zoom.Tele);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZZoom(D.Zoom.Wide);
        }
        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraFocus(mainRef.MakeAdr(), D.Focus.Far), l_IPCon_Connected);
        }
        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraFocus(mainRef.MakeAdr(), D.Focus.Near), l_IPCon_Connected);
        }

        private void ControlPanel_KeyUp(object sender, KeyEventArgs e) {
            if (cB_IPCon_KeyboardCon.Checked == true) {
                CameraCommunicate.sendtoIPAsync(protocol.CameraStop(mainRef.MakeAdr()), l_IPCon_Connected);
            }
        }

        private void ControlPanel_KeyDown(object sender, KeyEventArgs e) {
            if (cB_IPCon_KeyboardCon.Checked == true) {
                uint address = mainRef.MakeAdr();
                uint ptSpeed = Convert.ToUInt32(track_PTZ_PTSpeed.Value);
                byte[] code = null;

                switch (e.KeyCode) { //is there a command that accepts diagonal?
                    case Keys.Up:
                        code = protocol.CameraTilt(address, D.Tilt.Up, ptSpeed);
                        break;
                    case Keys.Down:
                        code = protocol.CameraTilt(address, D.Tilt.Down, ptSpeed);
                        break;
                    case Keys.Left:
                        code = protocol.CameraPan(address, D.Pan.Left, ptSpeed);
                        break;
                    case Keys.Right:
                        code = protocol.CameraPan(address, D.Pan.Right, ptSpeed);
                        break;
                    case Keys.Enter:
                        code = protocol.CameraZoom(address, D.Zoom.Tele);
                        break;
                    case Keys.Escape:
                        code = protocol.CameraZoom(address, D.Zoom.Wide);
                        break;
                }

                CameraCommunicate.sendtoIPAsync(code, l_IPCon_Connected);
            }
        }

        private void b_PTZ_Any_MouseUp(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraStop(mainRef.MakeAdr()), l_IPCon_Connected);
        }

        private void tB_IPCon_Adr_Leave(object sender, EventArgs e) {
            mainRef.AutoFillConnect(true, l_IPCon_Connected);
        }

        private void tB_IPCon_Adr_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                mainRef.AutoFillConnect(false ,l_IPCon_Connected);
            }
        }

        private void b_IPCon_LayoutMode_Click(object sender, EventArgs e) {
            mainRef.lite = true;
            Application.Restart();
            Application.ExitThread();
            this.Close();
        }

        private void ControlPanel_Load(object sender, EventArgs e) {
            mainRef.PopulateSettingText();
        }

    }
}
