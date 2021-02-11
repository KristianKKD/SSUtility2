using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public partial class PelcoD : Form {

        bool stop;

        public static byte[] noCommand = { 2, 3, 4, 5 };
        public static byte[] pause = { 1, 2, 3, 4 };

        public PelcoD() {
            InitializeComponent();
            tt_CommandFormat.SetToolTip(check_PD_Perfect, "Perfect Format disabled example: 00 53 00 00");
        }

        async Task Fire() {
            if (!AsyncCameraCommunicate.TryConnect(new IPEndPoint(IPAddress.Parse(tB_IPCon_Adr.Text),int.Parse(tB_IPCon_Port.Text))).Result) {
                return;
            }
            try {
                stop = false;
                b_PD_Stop.Enabled = true;
                for (int i = 0; i < rtb_PD_Commands.Lines.Length; i++) {
                    string l = rtb_PD_Commands.Lines[i];
                    if (!stop) {
                        CheckLine(l);
                    } else {
                        stop = false;
                        break;
                    }
                    await Task.Delay(400).ConfigureAwait(false);
                }
            }catch(Exception e) {
                MainForm.ShowPopup("Failed to send commands!\nShow more?", "Command firing failed", e.ToString());
            }

            MessageBox.Show("Finished sending commands!");
            stop = false;
            b_PD_Stop.Enabled = false;
        }

        async Task CheckLine(string line) {
            if (line != "") {

                line = line.Replace(",", "");
                line = line.ToLower().Replace("x", "0");

                if (tB_IPCon_Adr.Text == "" || tB_IPCon_Port.Text == null) {
                    MainForm.m.WriteToResponses("No IP/Port found", false);
                }

                byte[] send;
                if (check_PD_Perfect.Checked) {
                    send = FullCommand(line);
                } else {
                    send = CustomScriptCommands.CheckForCommands(line, MainForm.m.MakeAdr(cB_IPCon_Selected)).Result;
                }

                if (send == pause) {
                    return;
                } else if (send == noCommand) {
                    send = MakeCommand(line);
                }

                Command sendCommand = AsyncCameraCommunicate.SendNewCommand(send);
                if (sendCommand.invalid) {
                    MainForm.m.WriteToResponses("Command: " + line + " could not be sent because it's invalid!", true);
                }
                await Task.Delay(400).ConfigureAwait(false);

                if (sendCommand.myReturn.msg == CameraCommunicate.defaultResult) {
                    MainForm.m.WriteToResponses("Command: " + line + " didn't receive a response.", true);
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
            MainForm.m.WriteToResponses("Sending " + MainForm.m.ReadCommand(fullCommand, true), true);

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
            MainForm.m.WriteToResponses("Sending " + MainForm.m.ReadCommand(fullCommand, true), true);

            return fullCommand;
        }

        public static void SaveScript(string[] lines, string name = null) {
            SaveFileDialog fdg = MainForm.SaveFile(name, ".txt", ConfigControl.savedFolder);
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                ConfigControl.ResetFile(fdg.FileName);
                File.AppendAllLines(fdg.FileName, lines);
            }
        }

        private void b_PD_Save_Click(object sender, EventArgs e) {
            SaveScript(rtb_PD_Commands.Lines, "PelcoScript");
        }

        private void b_PD_Fire_Click(object sender, EventArgs e) {
            if (CameraCommunicate.Connect(tB_IPCon_Adr.Text, tB_IPCon_Port.Text, null, false).Result) {
                Fire();
            } else {
                MessageBox.Show("Not connected to camera!");
            }
        }

        private void b_PD_Load_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = MainForm.OpenFile();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.FileName.Contains(".txt")) {
                    rtb_PD_Commands.Clear();
                    string[] lines = File.ReadAllLines(fdg.FileName);
                    foreach (string line in lines) {
                        rtb_PD_Commands.Text += line + "\n";
                    }
                } else {
                    MainForm.ShowPopup("Please open a .txt file!\nYou tried to open an unsupported file type! Show more info?", "Invalid File Type!",
                        "You tried opening: " + fdg.FileName + "\nTry opening a .txt file instead.");
                }
            }
        }

        private void b_PD_FireSingle_Click(object sender, EventArgs e) {
            CheckLine(tB_PD_Single.Text);
            MessageBox.Show("Sent!");
        }
       
        private void b_PD_Stop_Click(object sender, EventArgs e) { //make it cancel current script
            stop = true;
            b_PD_Stop.Enabled = false;
            CustomScriptCommands.QuickCommand("stop");
        }

        private void b_PD_RL_Click(object sender, EventArgs e) {
            MainForm.m.OpenResponseLog();
            MainForm.m.rl.Location = new System.Drawing.Point(Location.X + MainForm.m.rl.Width, Location.Y);
        }

        CommandListWindow clw = null;
        private void b_PD_ComList_Click(object sender, EventArgs e) {
            if (clw == null) {
                clw = new CommandListWindow();
            }
            clw.Show();
            clw.BringToFront();
        }

        private void check_PD_Perfect_CheckedChanged(object sender, EventArgs e) {
            if (check_PD_Perfect.Checked) {
                tt_CommandFormat.SetToolTip(check_PD_Perfect, "Perfect Format enabled example: FF 01 00 53 00 00 54");
            } else {
                tt_CommandFormat.SetToolTip(check_PD_Perfect, "Perfect Format disabled example: 00 53 00 00");
            }
        }

        private void PelcoD_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
