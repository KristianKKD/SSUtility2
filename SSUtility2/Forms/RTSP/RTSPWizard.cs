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

        bool editing;

        public RTSPWizard(string fullAdr) {
            InitializeComponent();
            if (fullAdr != null) {
                editing = true;
                FullToParts(fullAdr);
            }

            //Inititate cloning immediately
        }

        private void b_Confirm_Click(object sender, EventArgs e) {
            string full = tB_FullAdr.Text;
            if (full.Length <= 0) {
                MessageBox.Show("Invalid values!");
                return;
            }

            if (editing) {

            } else {
                RTSPPresets.LoadPreset(full);
            }
        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            Close();
            Dispose();
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
                string ipaddress = tB_RTSPAdr.Text;
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
        }
        
    }
}
