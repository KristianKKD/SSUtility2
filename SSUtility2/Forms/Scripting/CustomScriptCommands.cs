using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class ScriptCommand {
        public string[] names;
        public byte[] codeContent;
        public string description;
        public bool custom;
        public int valueCount;
        public bool isQuery;

        public ScriptCommand(string[] n, byte[] code, string text, int values,
            bool queryType = false, bool scriptCommand = false) {
            names = n;
            codeContent = code;
            description = text;
            custom = scriptCommand;
            valueCount = values;
            isQuery = queryType;
        }
    }

    public class CustomScriptCommands {

        readonly static ScriptCommand pause = new ScriptCommand(new string[] { "pause", "wait" }, PelcoD.pause, "Pause the script execution for X milliseconds", 1, false, true);
        readonly static ScriptCommand loop = new ScriptCommand(new string[] { "loop", "repeat" }, PelcoD.loop, "Loop any following commands X number of times. Looped commands will continue to be sent until the stated quanitity of loops is met or the stop execution button is pressed", 1, false, true);
        readonly static ScriptCommand loopStop = new ScriptCommand(new string[] { "loopstop", "stoploop" }, PelcoD.loopStop, "Will start reading scripted lines directly below the previous loop command. *If there is no loop, this command will be ignored.*", 1, false, true);
        readonly static ScriptCommand connect = new ScriptCommand(new string[] { "connect", "ip" }, PelcoD.connect, "Connect to specified IP + port, example usage: 'connect 192.168.1.183:554'", 1, false, true);
        
        readonly static ScriptCommand stop = new ScriptCommand(new string[] { "stop" }, new byte[] { 0x00, 0x00, 0x00, 0x00 }, "Stops whatever the camera is doing", 0);
        readonly static ScriptCommand mono = new ScriptCommand(new string[] { "mono", "monocolour", "monocolor" }, new byte[] { 0x00, 0x07, 0x00, 0x03 }, "Camera video toggles between color and black/white pallete", 0);
        readonly static ScriptCommand panzero = new ScriptCommand(new string[] { "panzero", "zeropan", "azimuth" }, new byte[] { 0x00, 0x49, 0x00, 0x00 }, "The camera's zero pan is set to the current rotation", 0);

        readonly static ScriptCommand setzoomspeed = new ScriptCommand(new string[] { "setzoomspeed" }, new byte[] { 0x00, 0x25, 0x00, 0x00 }, "Sets camera zoom speed to X (DATA 2)", 1);
        readonly static ScriptCommand setpantiltspeed = new ScriptCommand(new string[] { "setpantiltspeed" }, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan and tilt speed to X (DATA 2)", 1);
        readonly static ScriptCommand setpanpos = new ScriptCommand(new string[] { "setpanpos", "setpan" }, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan position to X (DATA 1 & DATA 2)", 2);
        readonly static ScriptCommand setiltpos = new ScriptCommand(new string[] { "settiltpos", "settilt" }, new byte[] { 0x00, 0x4D, 0x00, 0x00 }, "Sets camera tilt position to X (DATA 1 & DATA 2)", 2);

        readonly static ScriptCommand querypan = new ScriptCommand(new string[] { "querypan" }, new byte[] { 0x00, 0x51, 0x00, 0x00 }, "Returns camera pan position", 0, true);
        readonly static ScriptCommand querytilt = new ScriptCommand(new string[] { "querytilt" }, new byte[] { 0x00, 0x53, 0x00, 0x00 }, "Returns camera tilt position", 0, true);
        readonly static ScriptCommand queryzoom = new ScriptCommand(new string[] { "queryzoom", "queryfov" }, new byte[] { 0x00, 0x55, 0x00, 0x00 }, "Returns camera FOV", 0, true);
        readonly static ScriptCommand queryfocus = new ScriptCommand(new string[] { "queryfocus" }, new byte[] { 0x01, 0x55, 0x00, 0x00 }, "Returns camera focus value", 0, true);
        readonly static ScriptCommand querypost = new ScriptCommand(new string[] { "querypost" }, new byte[] { 0x07, 0x6B, 0x00, 0x00 }, "Returns camera test data", 0, true);
        readonly static ScriptCommand queryconfig = new ScriptCommand(new string[] { "queryconfig" }, new byte[] { 0x03, 0x6B, 0x00, 0x00 }, "Returns camera config, (thermal only)", 0, true);
        
        readonly static ScriptCommand learnPreset = new ScriptCommand(new string[] { "learnpreset", "setpreset", "learn" }, new byte[] { 0x00, 0x03, 0x00, 0x00 }, "Saves current PTZ state of the camera and assigns it to the X value memory position", 1);
        readonly static ScriptCommand clearPreset = new ScriptCommand(new string[] { "clearpreset", "clear" }, new byte[] { 0x00, 0x05, 0x00, 0x00 }, "Clears preset X from camera memory", 1);
        readonly static ScriptCommand gotoPreset = new ScriptCommand(new string[] { "gotopreset", "goto" }, new byte[] { 0x00, 0x07, 0x00, 0x00 }, "Restores preset X's PTZ settings", 1);


        public readonly static ScriptCommand[] customCommands = new ScriptCommand[] {
            pause,
            loop,
            loopStop,
            connect,
        };

        public readonly static ScriptCommand[] queryCommands = new ScriptCommand[] {
            querypan,
            querytilt,
            queryzoom,
            queryfocus,
            querypost,
            queryconfig,
        };

        public readonly static ScriptCommand[] controlCommands = new ScriptCommand[] {
            setzoomspeed,
            setpantiltspeed,
            setpanpos,
            setiltpos,
            learnPreset,
            clearPreset,
            gotoPreset,
            stop,
            panzero,
            mono,
        };

        public readonly static ScriptCommand[][] cameraArrayCommands = new ScriptCommand[][]{ //megalist
            customCommands,
            controlCommands,
            queryCommands,
        };

        public static bool stopScript;

        public static async Task<ScriptCommand> CheckForCommands(string line, uint adr, bool allowCustom) {
            ScriptCommand presetCom = CheckForPresets(line).Result;
            ScriptCommand fail = new ScriptCommand(null, PelcoD.noCommand, null, 0, false, true);
            
            if (presetCom == null || (!allowCustom && presetCom.custom)) {
                return fail;
            }

            ScriptCommand com = new ScriptCommand(presetCom.names, presetCom.codeContent, presetCom.description,
                 presetCom.valueCount, presetCom.isQuery, presetCom.custom); //need to be careful not to overwrite my commands

            if (com.custom) {
                await DoCustomCommand(com, line);
                return com;
            }
            
            int value = CheckForVal(line);
            com = RefineCode(com, adr, value).Result;

            return com;
        }

        public static int CheckForVal(string line) {
            int value = 0;
            
            int marker = line.IndexOf(" ");
            if(marker == -1)
                marker = line.IndexOf(":");

            if (marker != -1)
                int.TryParse(line.Substring(marker + 1), out value);

            return value;
        }

        static async Task<ScriptCommand> RefineCode(ScriptCommand com, uint adr, int value) {
            byte[] code = com.codeContent;

            if (com.valueCount == 1) {
                code[3] = Convert.ToByte(value);
            } else if (com.valueCount == 2) {
                if (value > 255) {
                    code[2] = 0xFF;
                    code[3] = Convert.ToByte(value - 255);
                } else {
                    code[2] = Convert.ToByte(value);
                }
            }

            uint checksum = GetCheckSum(code, adr);
            com.codeContent = new byte[] { 0xFF, (byte)adr, code[0], code[1], code[2], code[3], (byte)checksum };
            return com;
        }

        public static uint GetCheckSum(byte[] code, uint adr) {
            uint checksum = 0;
            for (int i = 0; i < code.Length; i++) {
                checksum += code[i];
            }
            checksum += adr;
            checksum = checksum % 256;

            return checksum;
        }

        public static async Task<ScriptCommand> CheckForPresets(string line) {
            string start = line;

            int markerPos = line.IndexOf(" ");

            if (markerPos > 0) {
                start = line.Substring(0, markerPos);
                start = start.Trim();
            }

                foreach (ScriptCommand[] commandArray in cameraArrayCommands) {
                    foreach (ScriptCommand sc in commandArray) {

                    if(line.Contains(Tools.ReadCommand(sc.codeContent, true))){
                        return sc;
                    }

                    for (int x = 0; x < sc.names.Length; x++) {
                        if (sc.names[x] == start) {
                            return sc;
                        }
                    }

                }
            }

            return null;
        }

        public static async Task<string> QuickQuery(string command) {
            uint adr = Tools.MakeAdr();
            ScriptCommand send = CheckForCommands(command, adr, false).Result;

            string result = "";
            var t = Task.Factory.StartNew(() => {
                result = AsyncCamCom.QueryNewCommand(send.codeContent).Result;
            });
            Task.WaitAll();

            return result;
        }

        public static async Task QuickCommand(string command, bool sendAsync = true, int manualAdr = -5) {
            try {
                if (!await AsyncCamCom.TryConnect().ConfigureAwait(false)) {
                    return;
                }

                uint adr = Tools.MakeAdr();

                if (manualAdr != -5) { //if sending preset
                    adr = Convert.ToUInt32(manualAdr);
                }

                ScriptCommand send = CheckForCommands(command, adr, false).Result;
                if (send.codeContent == PelcoD.noCommand) {
                    if (command.Length == 0) {
                        MessageBox.Show("Command length is 0!\nMake sure to check the command in the settings!");
                        return;
                    } else {
                        byte[] code = PelcoD.FullCommand(command);
                        if (code == null) {
                            MessageBox.Show("Command invalid!\nMake sure to enter command in perfect format!\n(FF 0x xx xx xx xx yy)");
                            return;
                        }
                        send = new ScriptCommand(new string[] { "custom" }, code, "", 0);
                    }
                }

                if (!sendAsync) {
                    AsyncCamCom.SendNonAsync(send.codeContent);
                } else {
                    var t = Task.Factory.StartNew(() => {
                        AsyncCamCom.SendScriptCommand(send);
                    });
                    Task.WaitAll();
                }
            } catch (Exception e) {
                Tools.ShowPopup("Failed to send quick command!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        public static void DoPreset(int adr, byte p) {
            QuickCommand("goto " + p, false, adr);
        }

        public static async Task SendMechanicalMenu() {
            if (!await AsyncCamCom.TryConnect().ConfigureAwait(false)) {
                return;
            }

            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFF, 0x07 });
        }

        public static async Task SendAdminMenu() {
            if (!await AsyncCamCom.TryConnect().ConfigureAwait(false)) {
                return;
            }

            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFE, 0x06 });
        }


        static async Task DoCustomCommand(ScriptCommand com, string line) {
            if (com.codeContent == PelcoD.pause) {
                int value = CheckForVal(line);
                MainForm.m.WriteToResponses("Waiting: " + value.ToString() + "ms", true);
                
                while (value > 0) {
                    if (stopScript) {
                        break;
                    }
                    value -= 200;
                    await Task.Delay(200).ConfigureAwait(false);
                }
                stopScript = false;

            } else if (com.codeContent == PelcoD.connect) {

                int ipmarker = line.IndexOf(" ");
                int portmarker = line.IndexOf(":");
                if (ipmarker == -1 || portmarker == -1) {
                    MainForm.m.WriteToResponses("Failed to parse IP or port! (" + line + ")", false);
                    return;
                }

                IPAddress parsed;
                int port;
                if (IPAddress.TryParse(line.Substring(ipmarker + 1, portmarker - ipmarker - 1), out parsed) && int.TryParse(line.Substring(portmarker + 1), out port)) {
                    await AsyncCamCom.TryConnect(false, new IPEndPoint(parsed, port), true);
                }

            }

        }

    }
}
