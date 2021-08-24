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
            OpenPreset(preset);

            UpdateAll();
            //Inititate cloning immediately
        }

        void OpenPreset(string[] preset) {
            if (preset != null) {
                string retVal = RTSPPresets.GetValue(RTSPPresets.PresetColumn.Index, preset[0], RTSPPresets.PresetColumn.Name);
                if (retVal != "")
                    editIndex = int.Parse(retVal);

                b_Forget.Visible = true;
                if (editIndex != -1)
                    LoadPreset(preset);

                check_Manual.Checked = (preset[RTSPPresets.TableValue(RTSPPresets.PresetColumn.ControlIP)] != ""
                    || preset[RTSPPresets.TableValue(RTSPPresets.PresetColumn.ControlPort)] != ""
                    || preset[RTSPPresets.TableValue(RTSPPresets.PresetColumn.PelcoID)] != "1");
            }
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
            cB_ControlPort.Text = preset[9];
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
            string controlport = cB_ControlPort.Text;

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

            if (editIndex >= 0) { //existing
                mySets.cB_RTSP.SelectedIndex = RTSPPresets.LoadPreset(full, editIndex);
            } else if (checkIndex != -1) { //duplicate
                MessageBox.Show("Duplicate preset name!");
                return;
            } else { //new
                mySets.cB_RTSP.SelectedIndex = RTSPPresets.LoadPreset(full);
            }

            CloseWindow();
        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            CloseWindow();
        }

        void FullToParts(string full) {
            if (!ConfigControl.enableFullToParts.boolVal)
                return;

            try {
                tB_RTSPIP.Text = "";
                tB_RTSPPort.Text = "";
                tB_RTSPString.Text = "";
                tB_Username.Text = "";
                tB_Password.Text = "";

                int rtspLength = 7; //should be pos of username or ip in expected format

                if (full.Length < rtspLength + 1)
                    return;

                if (full.Substring(0, rtspLength) != "rtsp://") //if fullAdr isn't completed in any expected way
                    return;

                full = full.Substring(rtspLength);

                int atPos = full.IndexOf("@");
                
                int portColonPos = full.IndexOf(":");

                int passwordPos = full.IndexOf(":", 0);
                if (passwordPos > 0 && passwordPos < atPos) //password exists
                    portColonPos = full.IndexOf(":", passwordPos + 1);
                else if (passwordPos > atPos)
                    passwordPos = 0;

                int usernameLength = 0;
               
                if (atPos > 1) { //rtsp url has username
                    int usernameEnd = full.IndexOf(":");
                    if (atPos < usernameEnd)
                        usernameEnd = atPos; //no password

                    if (usernameEnd > 0)
                        usernameLength = TryFillField(full, 0, usernameEnd, tB_Username) - 1;
                }

                int portFinisher = full.IndexOf("/", atPos + 1); //can be 0 to signify the end of the string

                int ipStart = atPos + 1;
                int ipLength = portColonPos - ipStart;

                //if (portFinisher < firstFoundColon) // maybe no port? implement later 
                //    ipEnd = portFinisher + 1;

                TryFillField(full, ipStart, ipLength, tB_RTSPIP);

                int portPos = ipStart + ipLength + 1;
                if (full.Length > portPos && full[portPos - 1] == ':')
                    TryFillField(full, portPos, portFinisher - portPos, tB_RTSPPort);

                TryFillField(full, full.IndexOf('/') + 1, -1, tB_RTSPString);

                if (usernameLength > 0 && passwordPos > 0 && atPos - usernameLength > 2)
                    TryFillField(full, passwordPos + 1, atPos - usernameLength - 2, tB_Password);

            } catch (Exception e) {
                Console.WriteLine("Failed to extract values from full address\n" + e.ToString());
            }
        }

        int TryFillField(string full, int startPos, int length, TextBox tb) {
            try {
                string val = "";
                if (length > 0)
                    val = full.Substring(startPos, length);
                else
                    val = full.Substring(startPos);

                tb.Text = val;

                return val.Length;
            } catch (Exception e){ }

            return 0;
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

                string colonPort = ":" + port;
                if (port.Length <= 0)
                    colonPort = "";

                return "rtsp://" + userPass + ipaddress + colonPort + "/" + url;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            };

            return "";
        }

        void ChangeName() {
            if (editIndex == -1 && !nameChanged)
                tB_Name.Text = tB_RTSPIP.Text;
        }

        private void tB_Any_Keyup(object sender, KeyEventArgs e) {
            tB_FullAdr.Text = GetCombined();
            ChangeName();
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
            cB_ControlPort.Enabled = enabled;
        }

        bool isSelected = false;
        private void tB_FullAdr_TextChanged(object sender, EventArgs e) {
            if (isSelected) {
                isSelected = false;
                FullToParts(tB_FullAdr.Text);
                ChangeName();
                isSelected = true;
            }
        }

        private void tB_FullAdr_Enter(object sender, EventArgs e) {
            isSelected = true;
        }

        private void tB_FullAdr_Leave(object sender, EventArgs e) {
            isSelected = false;
        }

        private void tB_RTSPString_TextChanged(object sender, EventArgs e) {
            string val = tB_RTSPString.Text;
            if (val.StartsWith("/"))
                val = val.Substring(1);

            tB_RTSPString.Text = val;
        }

        private void cB_ControlPort_SelectedIndexChanged(object sender, EventArgs e) {
            DelayedIndex();
        }

        async Task DelayedIndex() {
            await Task.Delay(100);
            cB_ControlPort.Text = Tools.GetPortValueFromEncoder(cB_ControlPort);
        }

        private void cB_Clone_DropDown(object sender, EventArgs e) {
            if (cB_Clone.Items.Contains("Clone..."))
                cB_Clone.Items.Remove("Clone...");
        }

        private void cB_Clone_DropDownClosed(object sender, EventArgs e) {
            if (!cB_Clone.Items.Contains("Clone..."))
                cB_Clone.Items.Add("Clone...");

            if (cB_Clone.Items.Count > 0 && cB_Clone.SelectedIndex >= 0 && cB_Clone.Items[cB_Clone.SelectedIndex].ToString() != "Clone...") {
                OpenPreset(RTSPPresets.GetPreset(cB_Clone.Text));
                editIndex = -1;
            }

            cB_Clone.SelectedIndex = cB_Clone.FindStringExact("Clone...");
        }

        bool refresh = false;

        void UpdateAll() {
            if (RTSPPresets.currentPresetCount == 0)
                cB_Clone.Hide();
            else
                cB_Clone.Show();

            cB_Clone.Items.Clear();

            cB_Clone.Items.Clear();
            foreach (string s in RTSPPresets.GetPresetList())
                cB_Clone.Items.Add(s);

            if (!cB_Clone.Items.Contains("Clone...") && !refresh)
                cB_Clone.Items.Add("Clone...");

            cB_Clone.Text = "Clone...";
        }

        private void RTSPWizard_Deactivate(object sender, EventArgs e) {
            refresh = true;
        }

        private void ClickOnForm_Click(object sender, MouseEventArgs e) {
            if (refresh)
                UpdateAll();

            refresh = false;
        }
    }
}
