using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2
{

    public partial class PelcoD : Form {

        bool stop;

        public static byte[] pause = { 1, 2, 3, 4 };

        public PelcoD() {
            InitializeComponent();
        }

        async Task Fire() {
            try {
                for (int i = 0; i < rtb_PD_Commands.Lines.Length; i++) {
                    string l = rtb_PD_Commands.Lines[i];
                    if (!stop) {
                        CheckLine(l);
                    } else {
                        stop = false;
                        break;
                    }
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

                if (tB_IPCon_Adr.Text == "" || tB_IPCon_Port.Text == null) {
                    MainForm.m.WriteToResponses("No IP/Port found");
                }

                Uri u = new Uri("http://" + tB_IPCon_Adr.Text + ":" + tB_IPCon_Port.Text);

                if (check_PD_Perfect.Checked) {
                    byte[] perfect = FullCommand(line);
                    CameraCommunicate.sendtoIPAsync(perfect, l_IPCon_Connected, tB_IPCon_Adr.Text, tB_IPCon_Port.Text);
                    return;
                }

                byte[] send = CustomScriptCommands.CheckForCommands(line, MainForm.m.MakeAdr(cB_IPCon_Selected)).Result;

                //if(send != null) {
                //    string m = "";
                //    for (int i = 0; i < send.Length; i++) {
                //        m += send[i].ToString() + " ";
                //    }
                //    MessageBox.Show(m);
                //}

                //MessageBox.Show("NULL");

                if (send == null) {
                    send = MakeCommand(line);
                } else if (send == pause) {
                    return;
                } else {
                    MainForm.m.WriteToResponses("Firing: " + line);
                }

                string response = CameraCommunicate.Query(send, u).Result;

                if (response == "0") {
                    MainForm.m.WriteToResponses("Command: " + line + " could not be sent.");
                } else {
                    MainForm.m.WriteToResponses(response);
                }

            }
        }

        byte[] FullCommand(string line) {
            line = line.Trim();
            uint send = uint.Parse(line.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            uint camAdr = uint.Parse(line.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            uint cm1 = uint.Parse(line.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            uint cm2 = uint.Parse(line.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);
            uint d1 = uint.Parse(line.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);
            uint d2 = uint.Parse(line.Substring(15, 2), System.Globalization.NumberStyles.HexNumber);
            uint checksum = uint.Parse(line.Substring(18, 2), System.Globalization.NumberStyles.HexNumber);
            
            byte[] fullCommand = new byte[7] {(byte)send, (byte)camAdr, (byte)cm1, (byte)cm2, (byte)d1, (byte)d2, (byte)checksum };
            
            return fullCommand;
        }

        byte[] MakeCommand(string line) {
            line = line.Trim();
            uint cm1 = uint.Parse(line.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
            uint cm2 = uint.Parse(line.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            uint d1 = uint.Parse(line.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            uint d2 = uint.Parse(line.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);
            uint checksum = (cm1 + cm2 + d1 + d2 + MainForm.m.MakeAdr(cB_IPCon_Selected)) % 256;
            
            byte[] fullCommand = new byte[7] { 0xFF, (byte)MainForm.m.MakeAdr(cB_IPCon_Selected), (byte)cm1, (byte)cm2, (byte)d1, (byte)d2, (byte)checksum } ;

            return fullCommand;
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
            CheckLine(tB_PD_Single.Text);
            MessageBox.Show("Sent!");
        }
       
        private void b_PD_Stop_Click(object sender, EventArgs e) { //make it cancel current script
        
        }

        private void b_PD_RL_Click(object sender, EventArgs e) {
            
        }
    }
}
