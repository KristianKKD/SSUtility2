using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2
{
    public partial class PelcoD : Form
    {
        public PelcoD() {
            InitializeComponent();
        }

        private void b_PD_Fire_Click(object sender, EventArgs e) {
            for (int i = 0; i < rtb_PD_Commands.Lines.Length; i++) {
                string line = rtb_PD_Commands.Lines[i];
                //if (line != "") {
                //    byte[] bytes = Encoding.ASCII.GetBytes(line);
                //    if (!CameraCommunicate.sendtoIPAsync(bytes).Result) {
                //        MessageBox.Show("Command: " + line + " could not be sent.");
                //        break;
                //    }
                //}
            }
            MessageBox.Show("Finished sending commands!");
        }
    }
}
