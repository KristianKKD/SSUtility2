﻿using System;
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

        public RTSPWizard(string fullAdr) {
            InitializeComponent();
            if (fullAdr != null) {
                string retVal = RTSPPresets.GetValue(RTSPPresets.PresetColumn.Index, fullAdr, RTSPPresets.PresetColumn.FullAdr);
                if (retVal != "")
                    editIndex = int.Parse(retVal);

                FullToParts(fullAdr);
                b_Forget.Visible = true;
            }

            //Inititate cloning immediately
        }

        void CloseWindow() {
            Close();
            Dispose();
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
            
            if (full.Length <= 0 || tB_FullAdr.Text.Length <= 0 || tB_Name.Text.Length <= 0) {
                MessageBox.Show("Invalid values!");
                return;
            }

            string stringCheckIndex = RTSPPresets.GetValue(RTSPPresets.PresetColumn.Index, tB_Name.Text);
            int checkIndex = -1;
            if (stringCheckIndex != "")
                checkIndex = int.Parse(stringCheckIndex);

            if (checkIndex == editIndex && editIndex >= 0) { //existing
                Console.WriteLine("EDITING");
                RTSPPresets.LoadPreset(full, editIndex);
            } else if (checkIndex != -1) { //duplicate
                MessageBox.Show("Duplicate name!");
                return;
            } else { //new
                Console.WriteLine("NEW");
                RTSPPresets.LoadPreset(full);
            }

            CloseWindow();
        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            CloseWindow(); 
        }

        static void FullToParts(string full) {
            int usernamePos = full.IndexOf(":") + 1; //should be the first one
            if (full[6] != '/' && usernamePos <= 0) //if fullAdr isn't completed in the expected way
                return;

            int atPos = full.IndexOf("@") + 1;
            int secondColonPos = full.IndexOf(":", usernamePos); // + secondColonPos?

            string username = full.Substring(7, usernamePos - 7); //7 = rtsp://
            string password = full.Substring(usernamePos, atPos - usernamePos);
            string ipaddress = full.Substring(atPos, secondColonPos - atPos);
            string port = full.Substring(secondColonPos, full.IndexOf("/", 7) - secondColonPos);
            string url = full.Substring(secondColonPos + port.Length + 1);

            Console.WriteLine("rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url);
        }

        public string GetCombined() {
            try {
                string ipaddress = tB_RTSPIP.Text;
                string port = tB_RTSPPort.Text;
                string url = tB_RTSPString.Text;
                string username = tB_Username.Text;
                string password = tB_Password.Text;

                return "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            };

            return "";
        }

        void FillFull() {
            tB_FullAdr.Text = GetCombined();
        }

        private void tB_Any_Keyup(object sender, KeyEventArgs e) {
            FillFull();
            if (editIndex == -1 && !nameChanged)
                tB_Name.Text = tB_RTSPIP.Text;
        }

        private void b_Forget_Click(object sender, EventArgs e) {
            RTSPPresets.ForgetPreset(editIndex);
            CloseWindow();
        }

        private void tB_Name_KeyUp(object sender, KeyEventArgs e) {
            string text = tB_Name.Text;

            nameChanged = !(text.Trim().Length <= 0 || text == tB_RTSPIP.Text);
        }
    }
}
