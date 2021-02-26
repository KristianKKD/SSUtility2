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
        public bool valueAccepting;
        public bool dualValue;
        public bool spammable;

        public ScriptCommand(string[] n, byte[] code, string text, bool canSpam = false, bool value = false, bool dual = false, bool scriptCommand = false) {
            names = n;
            codeContent = code;
            description = text;
            custom = scriptCommand;
            valueAccepting = value;
            dualValue = dual;
            spammable = canSpam;
        }
    }

    public class CustomScriptCommands {

        readonly static ScriptCommand pause = new ScriptCommand(new string[] { "pause", "wait" }, PelcoD.pause, "Pause the script execution for X milliseconds", false, true, false, true);
        readonly static ScriptCommand loop = new ScriptCommand(new string[] { "loop", "repeat" }, PelcoD.loop, "Loop any following commands X number of times. Looped commands will continue to be sent until the stated quanitity of loops is met or the stop execution button is pressed", false, true, false, true);
        readonly static ScriptCommand loopStop = new ScriptCommand(new string[] { "loopstop", "stoploop" }, PelcoD.loopStop, "Will start reading scripted lines directly below the previous loop command. *If there is no loop, this command will be ignored.*", false, false, false, true);
        readonly static ScriptCommand stop = new ScriptCommand(new string[] { "stop" }, new byte[] { 0x00, 0x00, 0x00, 0x00 }, "Stops whatever the camera is doing");
        readonly static ScriptCommand mono = new ScriptCommand(new string[] { "mono", "monocolour", "monocolor" }, new byte[] { 0x00, 0x07, 0x00, 0x03 }, "Camera video toggles between color and black/white pallete");
        readonly static ScriptCommand panzero = new ScriptCommand(new string[] { "panzero", "zeropan", "azimuth" }, new byte[] { 0x00, 0x49, 0x00, 0x00 }, "Sets camera pan to zero");

        readonly static ScriptCommand setzoomspeed = new ScriptCommand(new string[] { "setzoomspeed" }, new byte[] { 0x00, 0x25, 0x00, 0x00 }, "Sets camera zoom speed to X (DATA 2)", true, true);
        readonly static ScriptCommand setpantiltspeed = new ScriptCommand(new string[] { "setpantiltspeed" }, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan and tilt speed to X (DATA 2)", true, true);
        readonly static ScriptCommand setpanpos = new ScriptCommand(new string[] { "setpanpos", "setpan" }, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan position to X (DATA 1 & DATA 2)", true, true, true);
        readonly static ScriptCommand setiltpos = new ScriptCommand(new string[] { "settiltpos", "settilt" }, new byte[] { 0x00, 0x4D, 0x00, 0x00 }, "Sets camera tilt position to X (DATA 1 & DATA 2)", true, true, true);

        readonly static ScriptCommand querypan = new ScriptCommand(new string[] { "querypan" }, new byte[] { 0x00, 0x51, 0x00, 0x00 }, "Returns camera pan position", true);
        readonly static ScriptCommand querytilt = new ScriptCommand(new string[] { "querytilt" }, new byte[] { 0x00, 0x53, 0x00, 0x00 }, "Returns camera tilt position", true);
        readonly static ScriptCommand queryzoom = new ScriptCommand(new string[] { "queryzoom", "queryfov" }, new byte[] { 0x00, 0x55, 0x00, 0x00 }, "Returns camera FOV", true);
        readonly static ScriptCommand queryfocus = new ScriptCommand(new string[] { "queryfocus" }, new byte[] { 0x01, 0x55, 0x00, 0x00 }, "Returns camera focus value", true);
        readonly static ScriptCommand querypost = new ScriptCommand(new string[] { "querypost" }, new byte[] { 0x07, 0x6B, 0x00, 0x00 }, "Returns camera test data", true);
        readonly static ScriptCommand queryconfig = new ScriptCommand(new string[] { "queryconfig" }, new byte[] { 0x03, 0x6B, 0x00, 0x00 }, "Returns camera config, (thermal only)", true);

        public readonly static ScriptCommand[] queryCommands = new ScriptCommand[] {
            querypan,
            querytilt,
            queryzoom,
            queryfocus,
            querypost,
            queryconfig,
        };

        public readonly static ScriptCommand[] setCommands = new ScriptCommand[] {
            setzoomspeed,
            setpantiltspeed,
            setpanpos,
            setiltpos,
        };

        public readonly static ScriptCommand[] otherCommands = new ScriptCommand[] {
            pause,
            loop,
            loopStop,
            stop,
            mono,
            panzero,
        };

        public readonly static ScriptCommand[][] cameraArrayCommands = new ScriptCommand[][]{
            otherCommands,
            setCommands,
            queryCommands,
        };

        public static bool stopScript;

        public static async Task<ScriptCommand> CheckForCommands(string line, uint adr) {
            ScriptCommand presetCom = CheckForPresets(line).Result;
            
            if (presetCom == null) {
                return new ScriptCommand(null, PelcoD.noCommand, null, false, false, false, true);
            }

            ScriptCommand com = new ScriptCommand(presetCom.names, presetCom.codeContent, presetCom.description,
                 presetCom.spammable, presetCom.valueAccepting, presetCom.dualValue, presetCom.custom); //need to be careful not to overwrite my commands
            int value = CheckForVal(line);


            if (com.codeContent == PelcoD.pause) {
                MainForm.m.WriteToResponses("Waiting: " + value.ToString() + "ms", true);
                while (value > 0) {
                    if (stopScript) {
                        break;
                    }
                    value -= 200;
                    await Task.Delay(200).ConfigureAwait(false);
                }
                stopScript = false;
                return com;
            } else if (com.codeContent == PelcoD.loop || com.codeContent == PelcoD.loopStop) {
                return com;
            }

            com = RefineCode(com, adr, value).Result;

            return com;
        }

        public static int CheckForVal(string line) {
            int value = 0;
            int marker = line.IndexOf(" ");

            if (marker != -1) {
                int.TryParse(line.Substring(marker + 1), out value);
            }

            return value;
        }

        static async Task<ScriptCommand> RefineCode(ScriptCommand com, uint adr, int value) {
            byte[] code = com.codeContent;

            if (com.valueAccepting) {
                if (com.dualValue) {
                    if (value > 255) {
                        code[2] = 0xFF;
                        code[3] = Convert.ToByte(value - 255);
                    } else {
                        code[2] = Convert.ToByte(value);
                    }
                } else {
                    code[3] = Convert.ToByte(value);
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

                    if(line.Contains(MainForm.m.ReadCommand(sc.codeContent, true))){
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

        public static async Task QuickCommand(string command) {
            if (!AsyncCamCom.TryConnect().Result) {
                return;
            }

            ScriptCommand send = CheckForCommands(command, MainForm.m.MakeAdr(MainForm.m.ipCon.cB_IPCon_Selected)).Result;
            var t = Task.Factory.StartNew(() => {
                AsyncCamCom.SendScriptCommand(send);
            });
            Task.WaitAll();
        }


    }
}
