using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class RTSPWizard : Form {

        int editIndex = -1;
        bool nameChanged = false;
        VideoSettings mySets;

        public RTSPWizard(string[] preset, VideoSettings sets) {
            InitializeComponent();
            mySets = sets;
            if (preset != null) {
                string retVal = RTSPPresets.GetValue(RTSPPresets.PresetColumn.Index, preset[0], RTSPPresets.PresetColumn.Name);
                if (retVal != "")
                    editIndex = int.Parse(retVal);

                b_Forget.Visible = true;
                if (editIndex != -1)
                    LoadPreset(preset);
            }

            //Inititate cloning immediately
        }

        void CloseWindow() {
            Close();
            Dispose();
        }

        void LoadPreset(string[] preset) {
            tB_Name.Text = preset[0];
            tB_FullAdr.Text = preset[1];

            tB_RTSPIP.Text = preset[2];
            tB_RTSPPort.Text = preset[3];
            tB_RTSPString.Text = preset[4];
            tB_Username.Text = preset[5];
            tB_Password.Text = preset[6];

            tB_PelcoID.Text = preset[7];
            tB_ControlIP.Text = preset[8];
            tB_ControlPort.Text = preset[9];
        }

        private void b_Confirm_Click(object sender, EventArgs e) {
            //Name;FullAdr;RTSPIP;RTSPPort;RTSP;Username;Password;PelcoID;ControlIP;ControlPort;

            string name = tB_Name.Text;
            string fullAdr = tB_FullAdr.Text;
            string ipaddress = tB_RTSPIP.Text;
            string port = tB_RTSPPort.Text;
            string url = tB_RTSPString.Text;
            string username = tB_Username.Text;
            string password = tB_Password.Text;
            string pelco = tB_PelcoID.Text;
            string controlip = tB_ControlIP.Text;
            string controlport = tB_ControlPort.Text;

            string full = name + ";" + fullAdr + ";" + ipaddress + ";" + port + ";" + url + ";" + username
                + ";" + password + ";" + pelco + ";" + controlip + ";" + controlport + ";";
            
            if (name.Length <= 0 || fullAdr.Length <= 0 || pelco.Length <= 0) {
                MessageBox.Show("Invalid RTSP values!\nPreset Name, Full Address, and Pelco ID must be completed!");
                return;
            }

            string stringCheckIndex = RTSPPresets.GetValue(RTSPPresets.PresetColumn.Index, tB_Name.Text);
            int checkIndex = -1;
            if (stringCheckIndex != "")
                checkIndex = int.Parse(stringCheckIndex);

            if (checkIndex == editIndex && editIndex >= 0) { //existing
                Console.WriteLine("EDITING");
                mySets.cB_RTSP.SelectedIndex = RTSPPresets.LoadPreset(full, editIndex);
            } else if (checkIndex != -1) { //duplicate
                MessageBox.Show("Duplicate name!");
                return;
            } else { //new
                Console.WriteLine("NEW");
                mySets.cB_RTSP.SelectedIndex = RTSPPresets.LoadPreset(full);
            }

            CloseWindow();
        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            CloseWindow();
        }

        void FullToParts(string full) {
            int usernamePos = full.IndexOf(":", 7) + 1; //should be the first one

            if (full[6] != '/' && usernamePos <= 0) //if fullAdr isn't completed in the expected way
                return;

            int atPos = full.IndexOf("@") + 1;
            int secondColonPos = full.IndexOf(":", usernamePos);

            string username = "";
            string password = "";

            string ipaddress = full.Substring(atPos, secondColonPos - atPos);
            string port = full.Substring(secondColonPos + 1, full.IndexOf("/", 7) - secondColonPos - 1);
            string url = full.Substring(secondColonPos + port.Length + 2); //cant be null because it doesnt use length
           
            if (usernamePos > 8) {
                username = full.Substring(7, usernamePos - 8); //7 = rtsp://
                password = full.Substring(usernamePos, atPos - usernamePos - 1);
            }

            tB_Username.Text = username;
            tB_Password.Text = password;
            tB_RTSPIP.Text = ipaddress;
            tB_RTSPPort.Text = port;
            tB_RTSPString.Text = url;

            tB_FullAdr.Text = GetCombined();
        }

        public string GetCombined() {
            try {
                string ipaddress = tB_RTSPIP.Text;
                string port = tB_RTSPPort.Text;
                string url = tB_RTSPString.Text;
                string username = tB_Username.Text;
                string password = tB_Password.Text;

                string userPass = username + ":" + password + "@";
                if (username.Length <= 0 && password.Length <= 0)
                    userPass = "";

                return "rtsp://" + userPass + ipaddress + ":" + port + "/" + url;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            };

            return "";
        }

        void ChangeFullAndName() {
            tB_FullAdr.Text = GetCombined();
            if (editIndex == -1 && !nameChanged)
                tB_Name.Text = tB_RTSPIP.Text;
        }

        private void tB_Any_Keyup(object sender, KeyEventArgs e) {
            ChangeFullAndName();
        }

        private void b_Forget_Click(object sender, EventArgs e) {
            RTSPPresets.ForgetPreset(editIndex);
            CloseWindow();
            int index = mySets.cB_RTSP.SelectedIndex;
            if (index > 0)
                mySets.cB_RTSP.SelectedIndex = index - 1;
            else
                mySets.Text = "";
        }

        private void tB_Name_KeyUp(object sender, KeyEventArgs e) {
            string text = tB_Name.Text;

            nameChanged = !(text.Trim().Length <= 0 || text == tB_RTSPIP.Text);
        }

        private void check_Manual_CheckedChanged(object sender, EventArgs e) {
            bool enabled = check_Manual.Checked;

            l_PelcoID.Enabled = enabled;
            tB_PelcoID.Enabled = enabled;

            l_ControlIP.Enabled = enabled;
            tB_ControlIP.Enabled = enabled;

            l_ControlPort.Enabled = enabled;
            tB_ControlPort.Enabled = enabled;
        }

        bool isSelected = false;
        private void tB_FullAdr_TextChanged(object sender, EventArgs e) {
            if (isSelected) {
                FullToParts(tB_FullAdr.Text);
                ChangeFullAndName();
            }
        }

        private void tB_FullAdr_Enter(object sender, EventArgs e) {
            isSelected = true;
        }

        private void tB_FullAdr_Leave(object sender, EventArgs e) {
            isSelected = false;
        }
    }
}
