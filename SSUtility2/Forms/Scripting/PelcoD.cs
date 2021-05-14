using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public partial class PelcoD : Form {

        bool stop;

        public static byte[] noCommand = { 2, 3, 4, 5 };
        public readonly static byte[] pause = { 1, 2, 3, 4 };
        public static byte[] loop = { 3, 4, 5, 6 };
        public static byte[] loopStop = { 4, 5, 6, 7 };
        public static byte[] connect = { 5, 6, 7, 8 };
        public static byte[] disconnect = { 6, 7, 8, 9 };

        int loopPos = -1;
        int currentLoops = 0;
        int loopAmount = 0;
        bool loopNow = false;

        public PelcoD() {
            InitializeComponent();
        }

        async Task Fire() {
            try {
                if (cB_Mode.Text == "IP") {
                    if (!await AsyncCamCom.TryConnect(false).ConfigureAwait(false)) {
                        if (Tools.ShowPopup("Failed to connect to camera!\nIP: " + ConfigControl.savedIP.stringVal
                            + "\nPort: " + ConfigControl.savedPort.stringVal + "\nCancel script execution?", "Failed to Connect!", null, false)){
                            b_PD_Fire.Enabled = true;
                            return;
                        }
                    }
                }

                Invoke((MethodInvoker)delegate {
                    b_PD_Fire.Enabled = false;
                    b_PD_Stop.Enabled = true;
                });

                loopAmount = 0;
                loopPos = -1;
                for (int i = 0; i < tB_Commands.Lines.Length; i++) {

                    string l = tB_Commands.Lines[i];
                    if (!stop) {
                        await CheckLine(l, i);
                    } else {
                        stop = false;
                        break;
                    }

                    if (loopNow && loopPos != -1) {
                        MainForm.m.WriteToResponses("Looped " + currentLoops.ToString() + "/" + loopAmount.ToString(), true, false);
                        if (currentLoops < loopAmount) {
                            i = loopPos;
                        } else {
                            loopPos = -1;
                            currentLoops = 0;
                        }
                        loopNow = false;
                    }

                    await Task.Delay(100).ConfigureAwait(false);
                }

            } catch (Exception e) {
                Tools.ShowPopup("Failed to send commands!\nShow more?", "Command firing failed", e.ToString());
            }

            Invoke((MethodInvoker)delegate {
                MessageBox.Show("Finished sending commands!");
                stop = false;
                b_PD_Stop.Enabled = false;
                b_PD_Fire.Enabled = true;
            });
        }

        async Task CheckLine(string line, int linePos) {
            if (line != "" && !line.StartsWith("//")) {
                line = line.Replace(",", "");
                line = line.ToLower().Replace("x", "0");

                ScriptCommand sendCom = new ScriptCommand(null, new byte[] { 0, 0, 0, 0 }, null, 0);
                if (check_PD_Perfect.Checked) {
                    sendCom.codeContent = FullCommand(line);
                } else {
                    uint adr = 0;
                    Invoke((MethodInvoker)delegate {
                        adr = Tools.MakeAdr();
                    });
                    sendCom = await CustomScriptCommands.CheckForCommands(line, adr, true).ConfigureAwait(false);
                    if (sendCom.codeContent == noCommand) {
                        sendCom.codeContent = MakeCommand(line);
                    }
                }

                if (sendCom.codeContent == null || sendCom.custom) {

                    if (sendCom.codeContent == null) {
                        MainForm.m.WriteToResponses(line + " is invalid!", true);
                    } else if (sendCom.codeContent == loop) {
                        int val = CustomScriptCommands.CheckForVal(line);
                        if (val > 0) {
                            loopPos = linePos;
                            loopAmount = val;
                        }
                    } else if (sendCom.codeContent == loopStop) {
                        if (loopPos != -1) {
                            currentLoops++;
                        }
                        loopNow = true;
                    }
                    return;
                }

                if (cB_Mode.Text == "IP") {
                    await IPSend(sendCom, line);
                } else {
                    //SerialSend(send, line);
                }
            }
        }

        async Task IPSend(ScriptCommand send, string curLine) {
            Command sendCommand = AsyncCamCom.SendScriptCommand(send);
            if (sendCommand.invalid) {
                MainForm.m.WriteToResponses("Command: " + curLine + " could not be sent because it's invalid!", true);
            }

            await CommandQueue.WaitForCommandDone(sendCommand).ConfigureAwait(false);

            if (sendCommand.myReturn.msg == OtherCamCom.defaultResult) {
                MainForm.m.WriteToResponses("Command: " + curLine + " didn't receive a response.", true);
            }
        }

        void SerialSend(byte[] send, string curLine) {

        }

        public static byte[] FullCommand(string line) {
            try {
                line = line.Trim();
                if (line.Length != 20) {
                    MainForm.m.WriteToResponses(line + " was not in the correct perfect format, ignored.", true, false);
                    return null;
                }
                uint send = uint.Parse(line.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                uint camAdr = uint.Parse(line.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);

                uint cm1 = uint.Parse(line.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                uint cm2 = uint.Parse(line.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);
                uint d1 = uint.Parse(line.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);
                uint d2 = uint.Parse(line.Substring(15, 2), System.Globalization.NumberStyles.HexNumber);

                uint checksum = uint.Parse(line.Substring(18, 2), System.Globalization.NumberStyles.HexNumber);

                byte[] fullCommand = new byte[7] { (byte)send, (byte)camAdr, (byte)cm1, (byte)cm2, (byte)d1, (byte)d2, (byte)checksum };

                return fullCommand;
            } catch {
                return null;
            }
        }

        byte[] MakeCommand(string line) {
            try {
                line = line.Trim();
                if (line.Length != 11) {
                    MainForm.m.WriteToResponses(line + " was not in the correct format, ignored.", true, false);
                    return null;
                }
                uint cm1 = uint.Parse(line.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                uint cm2 = uint.Parse(line.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                uint d1 = uint.Parse(line.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                uint d2 = uint.Parse(line.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);

                uint adr = 0;
                Invoke((MethodInvoker)delegate {
                    adr = Tools.MakeAdr();
                });

                uint checksum = (cm1 + cm2 + d1 + d2 + adr) % 256;

                byte[] fullCommand = new byte[7] { 0xFF, (byte)adr, (byte)cm1, (byte)cm2, (byte)d1, (byte)d2, (byte)checksum };
                return fullCommand;
            } catch {
                return null;
            }
        }

        private void b_PD_Save_Click(object sender, EventArgs e) {
            Tools.SaveTextFile(tB_Commands.Lines, "PelcoScript");
        }

        private void b_PD_Fire_Click(object sender, EventArgs e) {
            stop = false;
            CustomScriptCommands.stopScript = false;
            Fire();
        }

        private void b_PD_Load_Click(object sender, EventArgs e) {
            OpenFileDialog fdg = Tools.OpenFile();
            DialogResult result = fdg.ShowDialog();
            if (result == DialogResult.OK) {
                if (fdg.FileName.Contains(".txt")) {
                    tB_Commands.Clear();
                    string[] lines = File.ReadAllLines(fdg.FileName);
                    foreach (string line in lines) {
                        tB_Commands.Text += line + "\n";
                    }
                } else {
                    Tools.ShowPopup("Please open a .txt file!\nUser tried to open an unsupported file type! Show more info?", "Invalid File Type!",
                        "User tried opening: " + fdg.FileName + "\nTry opening a .txt file instead.");
                }
            }
        }

        private void b_PD_Stop_Click(object sender, EventArgs e) { //make it cancel current script
            b_PD_Stop.Enabled = false;
            b_PD_Fire.Enabled = true;
            stop = true;
            CustomScriptCommands.stopScript = true;
            if (AsyncCamCom.sock.Connected)
                CustomScriptCommands.QuickCommand("stop");
        }

        private void b_PD_RL_Click(object sender, EventArgs e) {
            MainForm.m.OpenResponseLog();
            MainForm.m.rl.Location = new System.Drawing.Point(Location.X + MainForm.m.rl.Width, Location.Y);
        }

        CommandListWindow clw = null;
        private void b_PD_ComList_Click(object sender, EventArgs e) {
            if (clw == null) {
                clw = new CommandListWindow(true);
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

        private void tB_Commands_DragDrop(object sender, DragEventArgs e) {
            string[] fileName = e.Data.GetData(DataFormats.FileDrop) as string[];
            try {
                if (fileName != null) {
                    foreach (string line in fileName)
                        tB_Commands.AppendText(File.ReadAllText(line) + "\n");
                }
            } catch (Exception error) {
                Tools.ShowPopup("Failed to open script!\nShow more?", "Script load failed!", error.ToString());
            }
        }

        private void tB_Commands_DragEnter(object sender, DragEventArgs e) {
            tB_Commands.Enabled = true;
            tB_Commands.Clear();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void cB_Mode_SelectedIndexChanged(object sender, EventArgs e) {
            if (cB_Mode.Text == "IP") {
                p_Serial.Hide();
            } else if (cB_Mode.Text == "Serial") {
                MessageBox.Show("Not implemented yet!");
                p_Serial.Show();
            }
        }
    }
}
