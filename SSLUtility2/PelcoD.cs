using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class PelcoD : Form {

        public MainForm mainRef;

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

        private void b_PD_Save_Click(object sender, EventArgs e) {
            FolderBrowserDialog fdg = OpenTxt();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                //
            }
        }

        private void b_PD_Load_Click(object sender, EventArgs e) {
            FolderBrowserDialog fdg = OpenTxt();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.SelectedPath.Contains(".txt")) {
                    string[] lines = File.ReadAllLines(fdg.SelectedPath);
                    foreach (string line in lines) {
                        rtb_PD_Commands.Text += line + "\n";
                    }
                } else {
                    MessageBox.Show("Please open a .txt file!");
                }
            }
        }

        FolderBrowserDialog OpenTxt() {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.Description = "Select PelcoD Script (txt file)";
            return folderDlg;
        }

        private void b_PD_FireSingle_Click(object sender, EventArgs e) {
            
        }
    }
}
