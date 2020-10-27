using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class PelcoD : Form {

        public MainForm mainRef;
        string responses;
        ResponseLog rl;

        public static byte[] noGo = { 9, 9, 9, 9 };

        public PelcoD() {
            InitializeComponent();
        }

        async Task Fire() {
            try {
                for (int i = 0; i < rtb_PD_Commands.Lines.Length; i++) {
                    string l = rtb_PD_Commands.Lines[i];
                    CheckLine(l);
                }
            }catch(Exception e) {
                MessageBox.Show(e.ToString());
            }
            MessageBox.Show("Finished sending commands!");
        }

        async Task CheckLine(string line) {
            if (line != "") {
                line = line.Replace(",", "");
                line = line.ToLower().Replace("x", "0");
                if (check_PD_Perfect.Checked) {
                    byte[] perfect = PerfectMakeBytes(line);
                    CameraCommunicate.sendtoIPAsync(perfect, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
                    return;
                }
                byte[] send = CustomScriptCommands.CheckForCommands(line, mainRef.MakeAdr(cB_IPCon_Selected), this).Result;
                if (send != noGo) {
                    if (send == null) {
                        //send = MakeBytes(line);
                        send = MakeCommand(line);
                    }
                    if (!CameraCommunicate.sendtoIPAsync(send, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text).Result) {
                        WriteToResponses("Command: " + line + " could not be sent.");
                    } else {
                        WriteToResponses(CameraCommunicate.StringFromSock(tB_IPCon_Adr.Text,
                            tB_IPCon_Port.Text, l_IPCon_Connected).Result);
                        //wait for response
                    }
                }
            }

        }

        byte[] PerfectMakeBytes(string line) {
            List<int> spacePos = new List<int>();
            line = line.ToLower().Replace(" ", "");
            char[] c = line.Trim().ToCharArray();

            for (int i = 0; i < c.Length; i++) {
                if (i == 0) {
                    spacePos.Add(0);
                } else {
                    if (i % 4 == 0) {
                        spacePos.Add(i);
                    }
                }
            }
            spacePos.Add(c.Length);

            byte[] bytes = new byte[spacePos.Count + 1];

            for (int i = 0; i < spacePos.Count - 1; i++) {

                string subbed = "";
                for (int cI = 0; cI < spacePos[i + 1] - spacePos[i]; cI++) {
                    subbed += c[spacePos[i] + cI];
                }
                subbed = subbed.Trim();

                if (!byte.TryParse(subbed, out byte result)) {
                    string tryAgain = int.Parse(subbed, System.Globalization.NumberStyles.HexNumber).ToString();
                    byte.TryParse(tryAgain, out result);
                    if (int.Parse(result.ToString()) == int.Parse(D.Message.STX.ToString())) {
                        result = D.Message.STX;
                    }
                }
                bytes[i] = result;

            }

            return bytes;
        }

        //byte[] MakeBytes(string line) {

        //    List<int> spacePos = new List<int>();
        //    char[] c = line.Trim().ToCharArray();

        //    for (int i = 0; i < c.Length; i++) {
        //        if (i == 0) {
        //            spacePos.Add(0);
        //        } else {
        //            if (c[i].ToString() == " ") {
        //                spacePos.Add(i+1);
        //            }
        //        }
        //    }
        //    spacePos.Add(c.Length);

        //    byte[] bytes = new byte[spacePos.Count + 1];
        //    int checksum = 0;

        //    for (int i = 0; i < spacePos.Count - 1; i++) {
        //        string subbed = "";
        //        for (int cI = 0; cI < spacePos[i + 1] - spacePos[i]; cI++) {
        //            subbed += c[spacePos[i] + cI];
        //        }
        //        subbed = subbed.Trim();

        //        if (!byte.TryParse(subbed, out byte result)) {
        //            string tryAgain = int.Parse(subbed, System.Globalization.NumberStyles.HexNumber).ToString();
        //            byte.TryParse(tryAgain, out result);
        //            if (int.Parse(result.ToString()) == int.Parse(D.Message.STX.ToString())) {
        //                result = D.Message.STX;
        //            }
        //        }
        //        bytes[i] = result;
                
        //        if (result != D.Message.STX) {
        //            checksum += result;
        //        }

        //    }
        //    bytes[spacePos.Count - 1] = (byte)(checksum % 256);
        //    return bytes;
        //}

        byte[] MakeCommand(string line) {
            uint cm1 = uint.Parse(line.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
            uint cm2 = uint.Parse(line.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            uint d1 = uint.Parse(line.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            uint d2 = uint.Parse(line.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);
            uint checksum = (cm1 + cm2 + d1 + d2 + mainRef.MakeAdr(cB_IPCon_Selected)) % 256;
            MessageBox.Show(checksum.ToString());
            byte[] fullCommand = new byte[7] { 0xFF, (byte)mainRef.MakeAdr(cB_IPCon_Selected), (byte)cm1, (byte)cm2, (byte)d1, (byte)d2, (byte)checksum } ;

            return fullCommand;

        }

        public async Task WriteToResponses(string text) {
            responses += "[" + tB_IPCon_Adr.Text + ":" + tB_IPCon_Port.Text + " at "
                + DateTime.Now + "]: " + text + "\n";
            if (rl != null) {
                rl.rtb_Log.Text = responses;
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

        private void b_PD_Save_Click(object sender, EventArgs e) {
            SaveFile(rtb_PD_Commands.Lines, "PelcoScript");
        }
        private void b_PD_Fire_Click(object sender, EventArgs e) {
            if (CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, null, false).Result) {
                Fire();
            } else {
                MessageBox.Show("Not connected to camera!");
            }
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

        private void b_PD_FireSingle_Click(object sender, EventArgs e) {
            //CheckLine(tB_PD_Single.Text);
            t();
            //MessageBox.Show("Sent!");
        }

        async Task t() {
            await CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, label1);
            await WriteToResponses(CameraCommunicate.StringFromSock(tB_IPCon_Adr.Text,
                            tB_IPCon_Port.Text, l_IPCon_Connected).Result);
            MessageBox.Show("Sent!");
        }

        private void b_PD_Stop_Click(object sender, EventArgs e) { //make it cancel current script
        
        }

        private void b_PD_RL_Click(object sender, EventArgs e) {
            if (rl == null) {
                rl = new ResponseLog();
            }
            rl.rtb_Log.Text = responses;
            rl.BringToFront();
            rl.Show();
        }

        private void PelcoD_FormClosing(object sender, FormClosingEventArgs e) {
            if (rl != null) {
                rl.Dispose();
            }
        }
    }
}
