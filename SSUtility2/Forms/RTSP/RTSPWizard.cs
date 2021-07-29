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


        public RTSPWizard(VideoSettings sets) {
            InitializeComponent();
        }

        private void b_Confirm_Click(object sender, EventArgs e) {

        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            Close();
        }

        public string GetCombined() {
            try {
                string ipaddress = tB_Adr.Text;
                string port = tB_Port.Text;
                string url = tB_RTSP.Text;
                string username = tB_Username.Text;
                string password = tB_Password.Text;

                return "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            };

            return null;
        }

    }
}
