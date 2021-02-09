using System;
using System.Net;
using System.Threading.Tasks;

namespace SSUtility2 {
    public class ScriptCommand {
        public string[] names;
        public byte[] codeContent;
        public string description;
        public bool custom;
        public bool valueAccepting;
        public bool dualValue;

        public ScriptCommand(string[] n, byte[] code, string text, bool value = false, bool dual = false, bool scriptCommand = false) {
            names = n;
            codeContent = code;
            description = text;
            custom = scriptCommand;
            valueAccepting = value;
            dualValue = dual;
        }
    }

    public class CustomScriptCommands {

        public static ScriptCommand[] cameraCommands = new ScriptCommand[]{
            new ScriptCommand(new string[] {"pause", "wait"}, PelcoD.pause, "Pause the script execution for X milliseconds", true, false, true),

            new ScriptCommand(new string[] {"stop"}, new byte[] { 0x00, 0x00, 0x00, 0x00 }, "Stops whatever the camera is doing"),
            new ScriptCommand(new string[] {"mono", "monocolour", "monocolor"}, new byte[] { 0x00, 0x07, 0x00, 0x03 }, "Camera video toggles between color and black/white pallete"),
            new ScriptCommand(new string[] {"panzero", "zeropan", "azimuth"}, new byte[] { 0x00, 0x49, 0x00, 0x00 }, "Sets camera pan to zero"),

            new ScriptCommand(new string[] {"setzoomspeed"}, new byte[] { 0x00, 0x25, 0x00, 0x00 }, "Sets camera zoom speed to X (DATA 2)", true),
            new ScriptCommand(new string[] {"setpantiltspeed"}, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan and tilt speed to X (DATA 2)", true),
            new ScriptCommand(new string[] {"setpanpos", "setpan"}, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan position to X (DATA 1 & DATA 2)", true, true),
            new ScriptCommand(new string[] {"settiltpos", "settilt"}, new byte[] { 0x00, 0x4D, 0x00, 0x00 }, "Sets camera tilt position to X (DATA 1 & DATA 2)", true, true),

            new ScriptCommand(new string[] {"querypan"}, new byte[] { 0x00, 0x51, 0x00, 0x00 }, "Returns camera pan position"),
            new ScriptCommand(new string[] {"querytilt"}, new byte[] { 0x00, 0x53, 0x00, 0x00 }, "Returns camera tilt position"),
            new ScriptCommand(new string[] {"queryzoom", "queryfov"}, new byte[] { 0x00, 0x55, 0x00, 0x00 }, "Returns camera FOV"),
            new ScriptCommand(new string[] {"queryfocus"}, new byte[] { 0x01, 0x55, 0x00, 0x00 }, "Returns camera focus value"),
            new ScriptCommand(new string[] {"querypost"}, new byte[] { 0x07, 0x6B, 0x00, 0x00 }, "Returns camera test data"),
            new ScriptCommand(new string[] {"queryconfig"}, new byte[] { 0x03, 0x6B, 0x00, 0x00 }, "Returns camera config, (thermal only)"),
        };

        public static async Task<byte[]> CheckForCommands(string line, uint adr) {
            ScriptCommand com = CheckForPresets(line).Result;
            int value = CheckForVal(line);

            if (com == null) {
                return PelcoD.noCommand;
            } else if (com.codeContent == PelcoD.pause) {
                MainForm.m.WriteToResponses("Waiting: " + value.ToString() + "ms", true);
                await Task.Delay(value).ConfigureAwait(false);
                return PelcoD.pause;
            }

            byte[] code = RefineCode(com, adr, value).Result;
            MainForm.m.WriteToResponses("Sending: " + MainForm.m.ReadCommand(code, true) + " (" + com.names[0] + ")", true);

            return code;
        }

        static int CheckForVal(string line) {
            int value = 0;
            int marker = line.IndexOf(" ");

            if (marker != -1) {
                int.TryParse(line.Substring(marker + 1), out value);
            }

            return value;
        }

        static async Task<byte[]> RefineCode(ScriptCommand com, uint adr, int value) {
            byte[] code = com.codeContent;

            if (com.valueAccepting) { //test this
                if (com.dualValue) {
                    if (value > 255) {
                        //code[2] = 0xFF;
                        //code[3] = Convert.ToByte(value - 255);
                        code[2] = Convert.ToByte(value - 255);
                    } else {
                        code[2] = Convert.ToByte(value);
                    }
                } else {
                    code[3] = Convert.ToByte(value);
                }
            }

            uint checksum = GetCheckSum(code, adr);

            code = new byte[] { 0xFF, (byte)adr, code[0], code[1], code[2], code[3], (byte)checksum };
            return code;
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

            for (int i = 0; i < cameraCommands.Length; i++) {
                for (int x = 0; x < cameraCommands[i].names.Length; x++) {
                    if (cameraCommands[i].names[x] == start) {
                        return cameraCommands[i];
                    }
                }
            }

            return null;
        }

        public static async Task QuickCommand(string command) {
            if (!AsyncCameraCommunicate.sock.Connected) {
                AsyncCameraCommunicate.Connect(new IPEndPoint(IPAddress.Parse(MainForm.m.ipCon.tB_IPCon_Adr.Text), int.Parse(MainForm.m.ipCon.tB_IPCon_Port.Text)));

                await Task.Delay(200);
                if (!AsyncCameraCommunicate.sock.Connected) {
                    return;
                }
            }

            byte[] code = CheckForCommands(command, MainForm.m.MakeAdr(MainForm.m.ipCon.cB_IPCon_Selected)).Result;
            var t = Task.Factory.StartNew(() => {
                AsyncCameraCommunicate.SendNewCommand(code);
            });
            Task.WaitAll();
        }


    }
}
