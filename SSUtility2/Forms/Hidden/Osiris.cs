using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2.Hidden {

    public partial class Osiris : Form {
        public Osiris() {
            InitializeComponent();
        }

        IPEndPoint lastEP;

        async Task Connect() {
            //string ip = tB_IP.Text;
            //string port = tB_Port.Text;

            //if (ip.Length == 0 || port.Length == 0) {
            //    Tools.ShowPopup("Connection fields are empty!\nShow more?", "Can't Connect!",
            //        "Full address: " + ip + ":" + port);
            //    return;
            //}

            //IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            //if (ep == lastEP) {
            //    return;
            //}

            //lastEP = ep;
            //OsirisComs.Connect(lastEP);
            //CheckConfig();
        }

        async Task<string> SendCommand(byte[] command) {
            Connect();
            //command[command.Length - 1] = (byte)GetCRC(command); //apply crc to 2nd last byte

            //bool checkPassed = false;
            //for (int i = 3; i < 4 && !checkPassed; i++) {
            //    OsirisComs.Send(command);

            //    for (int x = 0; x < 5 && !OsirisComs.doneReceive; x++) {
            //        Task.Delay(100);
            //    }
            //    checkPassed = CheckResponse(OsirisComs.lastMsg);
            //}

            //if (!checkPassed) {
            //    Tools.ShowPopup("Failed to send message!\nShow more?", "Send Failed!",
            //        "Failed to send:\n" + Tools.ReadCommand(command, true));
            //    return "";
            //}

            //return OsirisComs.lastMsg;
            return "";
        }

        void GenWriteCommand(uint command1, uint command2) {
            byte[] fullCommand = new byte[] {
                0x01, 0x02, 0xFF, 0x01, 0x40, 0x02, (byte)command1, (byte)command2, 0x00, 0x03 };

            //01 02 FF 01 40 02 command crc 03

            SendCommand(fullCommand);
        }

        bool CheckResponse(string msg) {
            if (msg.Length < 15) {
                return false;
            }

            string validCheck = msg.Substring(0, 5);
            string boolCheck = msg.Substring(13, 1);

            if (validCheck != "01 02") {
                return false;
            }

            if (boolCheck == "03") {
                return false;
            } else {
                return true;
            }
        }

        static uint GetCRC(uint dataByte) {
            uint totalCRC = 0;
            uint carryCheck = 0;
            uint dataSnapshot = dataByte;

            for (uint i = 0; i <= 7; i++) {
                dataByte ^= totalCRC;
                totalCRC >>= 1;
                dataSnapshot >>= 1;
                carryCheck = dataByte & 0x01;

                if (carryCheck == 1) {
                    totalCRC ^= 0x8C;
                }
                dataByte = dataSnapshot;
            }

            return totalCRC;
        }

        void CheckConfig() {
            ConfigUpdateControls();
            ReadSystemHealth();

        }

        private void cB_Focus_SelectedIndexChanged(object sender, EventArgs e) {
            int selected = cB_Focus.SelectedIndex;
            byte[] command = new byte[0];

            switch(selected){
                case 0: //WIDE
                    break;
                case 1: //SPOT
                    break;
                case 2: //MID
                    break;
            }

            SendCommand(command);
        }

        void ReadSystemHealth() {
            string response = GetResponseSend(new byte[] { 0x01, 0x02, 0xFE, 0x01, 0x41, 0x00, 0x00, 0x00, 0x03 });
            if (response.Length < 4) {
                return;
            }

            response = Convert.ToString(Convert.ToInt32(response, 16), 2);
            response.Replace(" ", "");

            string lampInd = response.Substring(0,1);
            
            string powerHealth = response.Substring(1,1);
            string tempHealth = response.Substring(2,1);

            string powerHealthType = response.Substring(3,2);
            string tempHealthType = response.Substring(5,2);

            string psuBeam = response.Substring(7,2);
            string psuMode = response.Substring(9,2);

            string leftFilter = response.Substring(11,2);
            string leftFilterPos = response.Substring(13,2);

            string rightFilter = response.Substring(15,2);
            string rightFilterPos = response.Substring(17,2);

            string filterActuatorConfig = response.Substring(19,2);
            string filterActuatorReturn = response.Substring(21,2);

            string focusActuatorConfig = response.Substring(23,2);
            string focusActuatorReturn = response.Substring(25,2);

            if (lampInd == "1") {
                l_Status.Text = "Lamp Status: ON";
            } else {
                l_Status.Text = "Lamp Status: OFF";
            }


            //change stuff

        }

        string GetResponseSend(byte[] command) {
            string response = SendCommand(command).Result;
            response = Convert.ToString(Convert.ToInt32(response, 16), 2);
            return response;
        }

        void ConfigUpdateControls() {
            string response = GetResponseSend(new byte[] { 0x01, 0x02, 0xFE, 0x01, 0x06, 0x00, 0x00, 0x00, 0x03 });
            response.Replace(" ", "");
            if (response.Length < 4) {
                return;
            }

            bool series3k = false;

            string lampType = response.Substring(6, 2);
            string filter = response.Substring(10, 1);
            string focus = response.Substring(11, 1);

            l_Series.Show();
            l_LampType.Show();

            string msg = "";
            switch (lampType) {
                case "00":
                    msg = "Undefined";
                    break;
                case "01":
                    msg = "175w";
                    break;
                case "10":
                    msg = "300w";
                    break;
                case "11":
                    msg = "400w";
                    break;
            }
            l_LampType.Text = msg;

            if (filter == "1" || focus == "1") {
                series3k = true;
            }

            if (series3k) {
                l_Series.Text = "MR3000";
                l_FilterActuator.Text = "Filter";
                cB_Filter.Show();
                cB_Actuator.Hide();
            } else {
                l_Series.Text = "MR2000";
                l_FilterActuator.Text = "Actuator";
                cB_Filter.Hide();
                cB_Actuator.Show();
            }
        }

        private void cB_Filter_SelectedIndexChanged(object sender, EventArgs e) {
            int selected = cB_Filter.SelectedIndex;
            byte[] command = new byte[0];

            switch (selected) {
                case 0: //Right CLOSED
                    break;
                case 1: //Left CLOSED
                    break;
                case 2: //All OPEN
                    break;
            }

            SendCommand(command);
        }

        private void cB_Actuator_SelectedIndexChanged(object sender, EventArgs e) {
            int selected = cB_Filter.SelectedIndex;
            byte[] command = new byte[0];

            switch (selected) {
                case 0: //Actuator OPEN
                    break;
                case 1: //Actuator CLOSED
                    break;
            }

            SendCommand(command);
        }

        private void cB_Mode_SelectedIndexChanged(object sender, EventArgs e) {
            int selected = cB_Mode.SelectedIndex;
            byte[] command = new byte[0];

            switch (selected) {
                case 0: //PULSE
                    break;
                case 1: //STROBE
                    break;
                case 2: //CONTINUOUS
                    break;
            }

            SendCommand(command);
        }

        private void cB_Beam_SelectedIndexChanged(object sender, EventArgs e) {
            int selected = cB_Beam.SelectedIndex;
            byte[] command = new byte[0];

            switch (selected) {
                case 0: //LOW
                    break;
                case 1: //HIGH
                    break;
                case 2: //OFF
                    break;
            }

            SendCommand(command);
        }

        private void b_Connect_Click(object sender, EventArgs e) {
            //Connect();
            byte[] b = new byte[] { (byte)GetCRC(uint.Parse(tB_IP.Text)) };
            Console.WriteLine(Tools.ReadCommand(b, false));
        }

    }
}
