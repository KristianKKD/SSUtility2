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

    public partial class PelcoD : Form
    {

        public MainForm mainRef;
        D protocol = new D();

        public PelcoD() {
            InitializeComponent();
        }

        private void b_PD_Fire_Click(object sender, EventArgs e) {
            for (int i = 0; i < rtb_PD_Commands.Lines.Length; i++) {
                string line = rtb_PD_Commands.Lines[i];
                if (line != "") {
                    if (!CheckForCommands(line).Result) {
                        byte[] split = MakeBytes(line);
                        byte[] bytes = D.Message.GetMessage(mainRef.MakeAdr(l_IPCon_Connected), 0x00, 0x00, 0x00, 0x00, split);
                        if (!CameraCommunicate.sendtoIPAsync(bytes, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text).Result) {
                            MessageBox.Show("Command: " + line + " could not be sent.");
                            break;
                        }
                    }
                }
            }
            MessageBox.Show("Finished sending commands!");
        }

        byte[] MakeBytes(string line) {
            byte[] bytes = new byte[4];
            int[] spacePos = new int[4];
            int index = 0;
            int spaceCount = 0;

            foreach (char c in line) {
                index++;
                if (index == 1) {
                    spacePos[0] = 0;
                    spaceCount++;
                } else {
                    if (spaceCount == bytes.Length) {
                        break;
                    }
                    if (c.ToString() == " ") {
                        spacePos[spaceCount] = index - spaceCount;
                        spaceCount++;
                    }
                }
            }
            line = line.Replace(" ", "");
            line = line.ToLower().Replace("x", "0");

            for (int i = 0; i < spacePos.Length; i++) {
                string subbed = line.Substring(spacePos[i], 4);
                byte.TryParse(subbed , out byte result);
                bytes[i] = result;
            }

            return bytes;
        }

        async Task<bool> CheckForCommands(string line) {
            byte[] code = null;
            switch (line) {
                case "WAIT":
                    break;
                case "STOP":
                    break;
                    //case "SPEED":
                    //    break;
            }
            if (code != null) {
                CameraCommunicate.sendtoIPAsync(code, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
                return true;
            } else {
                return false;
            }
        }

        private void b_PD_Save_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = OpenTxt();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                ConfigControl.ResetFile(fdg.FileName);
                File.AppendAllLines(fdg.FileName, rtb_PD_Commands.Lines);
            }
        }

        private void b_PD_Load_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = OpenTxt();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.FileName.Contains(".txt")) {
                    rtb_PD_Commands.Clear();
                    string[] lines = File.ReadAllLines(fdg.FileName);
                    foreach (string line in lines) {
                        rtb_PD_Commands.Text += line + "\n";
                    }
                } else {
                    MainForm.ShowError("Please open a .txt file!\nYou tried to open an unsupported file type! Show more info?", "Invalid File Type!",
                        "You tried opening: " + fdg.FileName + "\nTry opening a .txt file instead.");
                }
            }
        }

        OpenFileDialog OpenTxt() {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Multiselect = false;
            fileDlg.Title = "Select PelcoD Script (txt file)";
            return fileDlg;
        }

        private void b_PD_FireSingle_Click(object sender, EventArgs e) {
            byte[] split = MakeBytes(tB_PD_Single.Text);
            byte[] bytes = D.Message.GetMessage(mainRef.MakeAdr(l_IPCon_Connected), 0x00, 0x00, 0x00, 0x00, split);
            CameraCommunicate.sendtoIPAsync(bytes, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
            MessageBox.Show("done");
        }

        private void button1_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraStop(1), l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }
    }
}
