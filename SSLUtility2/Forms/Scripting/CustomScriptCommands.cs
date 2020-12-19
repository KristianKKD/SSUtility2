using System;
using System.Threading.Tasks;

namespace SSLUtility2 {
    public static class CustomScriptCommands {

        public static async Task<byte[]> CheckForCommands(string line, uint adr) {
            byte[] code = new byte[3];

            code = CheckForPresets(line).Result;
            code = RefineCode(code, adr, CheckForVal(line)).Result;

            return code;
        }

        static int CheckForVal(string line) {
            int value = 0;
            int marker = line.IndexOf(" ");

            if (marker != -1) {
                value = int.Parse(line.Substring(marker + 1));
            }

            return value;
        }

        static async Task<byte[]> RefineCode(byte[] code, uint adr, int value) {
            if (value > 255) { //need to test
                code[2] = 0x01;
                value -= 255;
            }
            if (code[3] == 0x00) {
                code[3] = Convert.ToByte(value);
            }

            if (code == PelcoD.pause) {
                await Task.Delay(value).ConfigureAwait(false);
                MainForm.m.WriteToResponses("Waiting: " + value.ToString(), true);
            }

            if (code == null || code == PelcoD.pause) {
                return code;
            }

            uint checksum = GetCheckSum(code, adr, value);

            code = new byte[] { 0xFF, (byte)adr, code[0], code[1], code[2], code[3], (byte)checksum };

            return code;
        }

        public static uint GetCheckSum(byte[] code, uint adr, int value) {
            uint checksum = 0;
            for (int i = 0; i < code.Length; i++) {
                checksum += code[i];
            }
            checksum += adr;
            checksum += Convert.ToByte(value);
            checksum = checksum % 256;

            return checksum;
        }

        public static async Task<byte[]> CheckForPresets(string line) {
            byte[] code = null;

            string start = line;

            int markerPos = line.IndexOf(" ");

            if (markerPos > 0) {
                start = line.Substring(0, markerPos);
                start = start.Trim();
            }

            switch (start) {
                // value accepting //
                case "wait":
                case "pause":
                    code = PelcoD.pause;
                    break;

                case "up":
                    code = new byte[] { 0x00, 0x08, 0x00, 0x00 };
                    break;
                case "down":
                    break;
                case "left":
                    break;
                case "right":
                    break;

                case "pan":
                    break;
                case "tilt":
                    break;
                case "fov":
                    break;

                case "setzoomspeed":
                    code = new byte[] { 0x00, 0x25, 0x00, 0x00 }; //keep trying to get this work//try 0x19
                    break;
                case "setpantiltspeed":
                    code = new byte[] { 0x00, 0x4B, 0x00, 0x00 };
                    break;

                case "setpanpos":
                    code = new byte[] { 0x00, 0x4B, 0x00, 0x00 }; //test
                    break;
                case "settiltpos":
                    code = new byte[] { 0x00, 0x4D, 0x00, 0x00 }; //test
                    break;

                // no values // 
                case "stop":
                    code = new byte[] { 0x00, 0x00, 0x00, 0x00 };
                    break;
                case "mono":
                case "monocolor":
                case "monocolour":
                    code = new byte[] { 0x00, 0x07, 0x00, 0x03 };
                    break;
                case "zeropan":
                case "panzero":
                    code = new byte[] { 0x00, 0x49, 0x00, 0x00 }; //test
                    break;

                // queries //
                case "querytilt":
                    code = new byte[] { 0x00, 0x51, 0x00, 0x00 };
                    break;
                case "querypan":
                    code = new byte[] { 0x00, 0x53, 0x00, 0x00 };
                    break;
                case "queryfov":
                case "queryzoom":
                    code = new byte[] { 0x00, 0x55, 0x00, 0x00 }; //test
                    break;
                case "queryfocus":
                    code = new byte[] { 0x01, 0x55, 0x00, 0x00 }; //test
                    break;
                case "querypost":
                    code = new byte[] { 0x07, 0x6B, 0x00, 0x00 }; //test
                    break;
                case "queryconfig":
                    code = new byte[] { 0x03, 0x6B, 0x00, 0x00 };
                    break;
                default:
                    code = null;
                    break;
            }

            return code;
        }

        public static async Task QuickCommand(string command) {
            if (CameraCommunicate.Connect(MainForm.m.ipCon.l_IPCon_Adr.Text, MainForm.m.ipCon.l_IPCon_Port.Text, MainForm.m.ipCon.l_IPCon_Connected, true).Result) {
                byte[] code = CheckForCommands(command, MainForm.m.MakeAdr(MainForm.m.ipCon.cB_IPCon_Selected)).Result;
                CameraCommunicate.sendtoIPAsync(code);
            }
        }


    }
}
