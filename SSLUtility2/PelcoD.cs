using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class PelcoD : Form
    {

        public MainForm mainRef;
        D protocol = new D();
        string responses;
        ResponseLog rl;

        public PelcoD() {
            InitializeComponent();
        }

        private void b_PD_Fire_Click(object sender, EventArgs e) {
            Fire();
        }

        async Task Fire() {
            for (int i = 0; i < rtb_PD_Commands.Lines.Length; i++) {
                string line = rtb_PD_Commands.Lines[i];
                byte[] send;
                if (line != "") {
                    byte[] command = CheckForCommands(line).Result;
                    if (command != null) {
                        send = command;
                    } else {
                        send = MakeBytes(line);
                    }
                    if (!CameraCommunicate.sendtoIPAsync(send, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text).Result) {
                        MessageBox.Show("Command: " + line + " could not be sent.");
                        break;
                    } else {
                        //wait for response
                    }
                }
            }
            MessageBox.Show("Finished sending commands!");
        }

        byte[] MakeBytes(string line) { //ignores the first byte and turns it automatically to 0xFF, need to fix
            int index = 0;
            int spaceCount = 0;
            List<int> foundSpacePos = new List<int>();

            line = line.Replace(",", "");

            foreach (char c in line) {
                index++;
                if (index == 1) {
                    foundSpacePos.Add(0);
                    spaceCount++;
                } else {
                    if (c.ToString() == " ") {
                        foundSpacePos.Add(index - spaceCount);
                        spaceCount++;
                    }
                }
            }
            int[] spacePos = new int[foundSpacePos.Count];

            for (int i = 0; i < foundSpacePos.Count; i++) {
                spacePos[i] = foundSpacePos[i];
            }

            line = line.Replace(" ", "");
            line = line.ToLower().Replace("x", "0");

            byte checksum = 0x00;
            byte[] b = new byte[spaceCount + 2]; //2
            for (int i = 1; i < spacePos.Length; i++) { //1
                string subbed = line.Substring(spacePos[i], 4);
                byte.TryParse(subbed , out byte result);
                b[i] = result;
                if (result != D.Message.STX) {
                    checksum += result;
                }
            }

            b[0] = 0xFF;
            b[spaceCount] = checksum;

            return b;
        }

        async Task<byte[]> CheckForCommands(string line) {
            byte[] code = null;
            line = line.ToLower();
            string start = line;
            int firstSpace = line.IndexOf(" ");
            if (firstSpace != -1) {
                start = line.Substring(0, firstSpace);
            }

            switch (start) {
                case "wait": case "pause":
                    if (firstSpace != -1) {
                        Thread.Sleep(int.Parse(line.Substring(firstSpace + 1)));
                    }
                    break;
                case "stop":
                    code = protocol.CameraStop(mainRef.MakeAdr(cB_IPCon_Selected));
                    break;
                case "mono":
                    code = protocol.Preset(mainRef.MakeAdr(cB_IPCon_Selected), 3, D.PresetAction.Goto);
                    break;
            }
            return code;
        }

        public void WriteToResponses(string text) {
            responses += "[" + tB_IPCon_Adr + ":" + tB_IPCon_Port + " at "
                + DateTime.Now + "]" + text + "\n";
            if (rl != null) {
                rl.rtb_Log.Text = responses;
            }
        }

        private void b_PD_Save_Click(object sender, EventArgs e) {
            SaveFile(rtb_PD_Commands.Lines, "PelcoScript");
        }

        private void b_PD_Load_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = MainForm.OpenTxt();
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

        public static void SaveFile(string[] lines, string name = null) {
            SaveFileDialog fdg = MainForm.SaveTxt(name);
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                ConfigControl.ResetFile(fdg.FileName);
                File.AppendAllLines(fdg.FileName, lines);
            }
        }


        private void b_PD_FireSingle_Click(object sender, EventArgs e) {
            byte[] split = MakeBytes(tB_PD_Single.Text);
            byte[] bytes = D.Message.GetMessage(mainRef.MakeAdr(l_IPCon_Connected), 0x00, 0x00, 0x00, 0x00, split);
            CameraCommunicate.sendtoIPAsync(bytes, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
            MessageBox.Show("done");
        }

        private void b_PD_Stop_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraStop(1), l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
        }

        private void b_PD_RL_Click(object sender, EventArgs e) {
            if (rl == null) {
                rl = new ResponseLog();
                rl.rtb_Log.Text = responses;
            }
            rl.Show();
        }

        private void PelcoD_FormClosing(object sender, FormClosingEventArgs e) {
            if (rl != null) {
                rl.Dispose();
            }
        }
    }
}
