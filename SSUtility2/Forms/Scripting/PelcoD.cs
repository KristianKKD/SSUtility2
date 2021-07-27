using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public partial class PelcoD : Form {

        bool stop;

        public static byte[] noCommand = { 2, 3, 4, 5 };
        public readonly static byte[] pause = { 3, 3, 4, 5 };
        public readonly static byte[] loop = { 4, 3, 4, 5 };
        public readonly static byte[] loopStop = { 5, 3, 4, 5 };
        public readonly static byte[] connect = { 6, 3, 4, 5 };
        public readonly static byte[] disconnect = { 7, 3, 4, 5 };
        public readonly static byte[] reconfig = { 8, 3, 4, 5 };
        public readonly static byte[] mainplay = { 9, 3, 4, 5 };
        public readonly static byte[] swapPreset = { 0, 3, 4, 5 };
        public readonly static byte[] execScript = { 3, 4, 5, 6 };

        int loopPos = -1;
        int currentLoops = 0;
        int loopAmount = 0;
        bool loopNow = false;

        public enum FireType {
            IP,
            Serial
        }

        public PelcoD() {
            InitializeComponent();
            cB_Mode.SelectedIndex = 0;
        }

        async Task Fire(FireType type) {
            try {
                if (type == FireType.IP) {
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
                        await CheckLine(l, i, type);
                    } else {
                        stop = false;
                        break;
                    }

                    if (loopNow && loopPos != -1) {
                        MainForm.m.WriteToResponses("Looped " + currentLoops.ToString() + "/" + loopAmount.ToString(), true, false);
                        if (currentLoops < loopAmount)
                            i = loopPos;
                        else {
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

        public async Task CheckLine(string line, int linePos, FireType type) {
            try {
                if (line != "" && !line.StartsWith("//")) {
                    line = line.Replace(",", "").Trim();
                    line = line.ToLower().Replace("x", "0");

                    ScriptCommand sendCom = new ScriptCommand(null, new byte[] { 0, 0, 0, 0 }, null, 0);
                    if (line.Length == 20) {
                        sendCom = new ScriptCommand(new string[] { "" }, Tools.ConvertMsgToByte(line), "", 0);
                    } else {
                        uint adr = 0;
                        Invoke((MethodInvoker)delegate {
                            adr = Tools.MakeAdr();
                        });
                        sendCom = await CustomScriptCommands.CheckForCommands(line, adr, true).ConfigureAwait(false);
                        if (sendCom.codeContent == noCommand) {
                            sendCom = new ScriptCommand(new string[] { "" }, MakeCommand(line), "", 0);
                        }
                    }

                    if (sendCom == null || sendCom.codeContent == null || sendCom.custom) {

                        if ((sendCom == null || sendCom.codeContent == null) && !sendCom.custom) {
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
                        
                        if(sendCom != null && !sendCom.custom)
                            Console.WriteLine("null command");
                        return;
                    }

                    if (type == FireType.IP) {
                        await IPSend(sendCom, line);
                    } else {
                        //SerialSend(send, line);
                    }
                }
            } catch (Exception e) {
                MainForm.m.WriteToResponses("Failed to parse line! (" + line + ")\n" + e.ToString()
                    , false);
            }
        }

        async Task IPSend(ScriptCommand send, string curLine) {
            Command sendCommand = AsyncCamCom.SendScriptCommand(send);

            if (sendCommand == null || sendCommand.invalid)
                MainForm.m.WriteToResponses("Command: " + curLine + " could not be sent because it's invalid!", true);
        }

        public byte[] MakeCommand(string line) {
            try {
                line = line.Trim();
                if (line.Length != 11) {
                    //MainForm.m.WriteToResponses(line + " was not in the correct format, ignored.", true, false);
                    return null;
                }
                uint cm1 = uint.Parse(line.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                uint cm2 = uint.Parse(line.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                uint d1 = uint.Parse(line.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                uint d2 = uint.Parse(line.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);

                uint adr = Tools.MakeAdr();

                uint checksum = (cm1 + cm2 + d1 + d2 + adr) % 256;

                byte[] fullCommand = new byte[7] { 0xFF, (byte)adr, (byte)cm1, (byte)cm2, (byte)d1, (byte)d2, (byte)checksum };

                return fullCommand;
            } catch {
                Console.WriteLine("Not made");
                return null;
            }
        }

        private void b_PD_Save_Click(object sender, EventArgs e) {
            Tools.SaveTextFile(tB_Commands.Lines, "PelcoScript");
        }

        private void b_PD_Fire_Click(object sender, EventArgs e) {
            stop = false;
            CustomScriptCommands.stopScript = false;
            FireType type =  FireType.IP; //implement changing this later
            Fire(type);
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

        private void b_PD_ComList_Click(object sender, EventArgs e) {
            MainForm.m.clw.ShowWindow();
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
