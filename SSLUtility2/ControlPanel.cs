using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2
{

    public partial class ControlPanel : Form {
    
        public MainForm mainRef;
        public string pathToAuto;
        D protocol = new D();
        public Control l;
        public bool isOriginal = false;

        public ControlPanel() {
            InitializeComponent();
            l = l_IPCon_Connected;
            Program.cp = this;
        }

        public void StartConnect() {
            CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l, true);
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

        private void b_Detach(object sender, EventArgs e) {
            Detached d = mainRef.DetachVid(true);

            d.tB_PlayerD_Adr.Text = tB_IPCon_Adr.Text;
            d.checkB_PlayerD_Manual.Checked = true;
        }

        private void b_Presets_GoTo_Click(object sender, EventArgs e) {
            if (tB_Presets_Number.Text.ToString() == "") {
                return;
            }
            byte presetnumber = Convert.ToByte(tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(protocol.Preset(mainRef.MakeAdr(cB_IPCon_Selected), presetnumber, D.PresetAction.Goto), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_Presets_Learn_Click(object sender, EventArgs e) { //can combine these 2 easily
            if (tB_Presets_Number.Text.ToString() == "") {
                return;
            }
            byte presetnumber = Convert.ToByte(tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(protocol.Preset(mainRef.MakeAdr(cB_IPCon_Selected), presetnumber, D.PresetAction.Set),
                l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_PTZ_Up_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(true, mainRef.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Up, D.Pan.Left, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_Down_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(true, mainRef.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Down, D.Pan.Left, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_Left_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(false, mainRef.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Null, D.Pan.Left, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_Right_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZMove(false, mainRef.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Null, D.Pan.Right, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZZoom(D.Zoom.Tele, mainRef.MakeAdr(cB_IPCon_Selected), tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            mainRef.PTZZoom(D.Zoom.Wide, mainRef.MakeAdr(cB_IPCon_Selected), tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }
        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraFocus(mainRef.MakeAdr(cB_IPCon_Selected), D.Focus.Far), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }
        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraFocus(mainRef.MakeAdr(cB_IPCon_Selected), D.Focus.Near), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_PTZ_Any_MouseUp(object sender, MouseEventArgs e) {
            DelayStop();
        }

        async Task DelayStop() {
            CameraCommunicate.sendtoIPAsync(protocol.CameraStop(mainRef.MakeAdr(cB_IPCon_Selected)), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
            Task.Delay(100);
            CameraCommunicate.sendtoIPAsync(protocol.CameraStop(mainRef.MakeAdr(cB_IPCon_Selected)), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void tB_IPCon_Adr_Leave(object sender, EventArgs e) {
            CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l, true);
        }

        private void tB_IPCon_Adr_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l, false);
            }
        }

        private void b_IPCon_LayoutMode_Click(object sender, EventArgs e) {
            if (!isOriginal) {
                Application.Restart();
                Application.ExitThread();
                this.Close();
            } else {
                mainRef.InitLiteMode();
            }
        }

        private void ControlPanel_Load(object sender, EventArgs e) {
            mainRef.PopulateSettingText();
        }

        private void b_IPCon_CustomD_Click(object sender, EventArgs e) {
            mainRef.OpenPelco(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, cB_IPCon_Selected.Text);
        }

        public void StopCam() {
            if (cB_IPCon_KeyboardCon.Checked == true) {
                CameraCommunicate.sendtoIPAsync(protocol.CameraStop(mainRef.MakeAdr(cB_IPCon_Selected)), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
            }
        }
        public void KeyControl(Control lab, Keys k, uint address, string ip, string port) { //test this
            if (cB_IPCon_KeyboardCon.Checked == true) {
                uint ptSpeed = Convert.ToUInt32(track_PTZ_PTSpeed.Value);
                byte[] code = null;

                switch (k) { //is there a command that accepts diagonal? // there is but its in byte codes
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

                CameraCommunicate.sendtoIPAsync(code, lab, ip, port);
            }
        }

    }
}
