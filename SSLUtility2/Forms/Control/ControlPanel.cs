using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2
{

    public partial class ControlPanel : Form {
    
        public Control l;

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

        private void b_Presets_GoTo_Click(object sender, EventArgs e) {
            if (tB_Presets_Number.Text.ToString() == "") {
                return;
            }
            byte presetnumber = Convert.ToByte(tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(D.protocol.Preset(MainForm.m.MakeAdr(cB_IPCon_Selected), presetnumber, D.PresetAction.Goto), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_Presets_Learn_Click(object sender, EventArgs e) { //can combine these 2 easily
            if (tB_Presets_Number.Text.ToString() == "") {
                return;
            }
            byte presetnumber = Convert.ToByte(tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(D.protocol.Preset(MainForm.m.MakeAdr(cB_IPCon_Selected), presetnumber, D.PresetAction.Set),
                l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_PTZ_Up_MouseDown(object sender, MouseEventArgs e) {
            MainForm.m.PTZMove(true, MainForm.m.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Up, D.Pan.Left, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_Down_MouseDown(object sender, MouseEventArgs e) {
            MainForm.m.PTZMove(true, MainForm.m.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Down, D.Pan.Left, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_Left_MouseDown(object sender, MouseEventArgs e) {
            MainForm.m.PTZMove(false, MainForm.m.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Null, D.Pan.Left, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_Right_MouseDown(object sender, MouseEventArgs e) {
            MainForm.m.PTZMove(false, MainForm.m.MakeAdr(cB_IPCon_Selected), Convert.ToUInt32(track_PTZ_PTSpeed.Value),
                D.Tilt.Null, D.Pan.Right, tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            MainForm.m.PTZZoom(D.Zoom.Tele, MainForm.m.MakeAdr(cB_IPCon_Selected), tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            MainForm.m.PTZZoom(D.Zoom.Wide, MainForm.m.MakeAdr(cB_IPCon_Selected), tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l);
        }
        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(D.protocol.CameraFocus(MainForm.m.MakeAdr(cB_IPCon_Selected), D.Focus.Far), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }
        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(D.protocol.CameraFocus(MainForm.m.MakeAdr(cB_IPCon_Selected), D.Focus.Near), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_PTZ_Any_MouseUp(object sender, MouseEventArgs e) {
            DelayStop();
        }

        async Task DelayStop() {
            CameraCommunicate.sendtoIPAsync(D.protocol.CameraStop(MainForm.m.MakeAdr(cB_IPCon_Selected)), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
            Task.Delay(100);
            CameraCommunicate.sendtoIPAsync(D.protocol.CameraStop(MainForm.m.MakeAdr(cB_IPCon_Selected)), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void tB_IPCon_Adr_Leave(object sender, EventArgs e) {
            CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l, true);
        }

        private void tB_IPCon_Adr_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, l, false);
            }
        }

        private void ControlPanel_Load(object sender, EventArgs e) {
            MainForm.m.PopulateSettingText();
        }

        public void StopCam() {
            if (cB_IPCon_KeyboardCon.Checked == true) {
                CameraCommunicate.sendtoIPAsync(D.protocol.CameraStop(MainForm.m.MakeAdr(cB_IPCon_Selected)), l, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
            }
        }

        public void KeyControl(Control lab, Keys k, uint address, string ip, string port) { //test this
            if (cB_IPCon_KeyboardCon.Checked == true) {
                uint ptSpeed = Convert.ToUInt32(track_PTZ_PTSpeed.Value);
                byte[] code = null;

                switch (k) { //is there a command that accepts diagonal? // there is but its in byte codes // need to accept multiple keys
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

                CameraCommunicate.sendtoIPAsync(code, lab, ip, port);
            }
        }

        private void track_IPCon_Zoom_MouseUp(object sender, MouseEventArgs e) {
            int zoomSpeed = track_IPCon_Zoom.Value;
            //byte[] code = CustomScriptCommands.CheckForCommands("setzoomspeed " + zoomSpeed.ToString(), MainForm.m.MakeAdr(cB_IPCon_Selected)).Result;
            //CameraCommunicate.sendtoIPAsync(code, null);
            byte[] code = new byte[] { 0xFF, 0x01, 0x00, 0x25, 0x00, Convert.ToByte(zoomSpeed), 0x00 };
            uint checksum = CustomScriptCommands.GetCheckSum(code, 1, zoomSpeed);
            code[6] = (byte)checksum;

            string text = CameraCommunicate.Query(code, new Uri("http://" + tB_IPCon_Adr.Text + ":" + tB_IPCon_Port.Text)).Result;
        }

    }
}
