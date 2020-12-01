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
            int marker = line.IndexOf(":");
            
            if (marker != -1) {
                value = int.Parse(line.Substring(marker + 1));
            }

            return value;
        }

        static async Task<byte[]> RefineCode(byte[] code, uint adr, int value) {
            if (code == PelcoD.pause) {
                await Task.Delay(value).ConfigureAwait(false);
                MainForm.m.WriteToResponses("Waiting: " + value.ToString());
            }

            if (code == null || code == PelcoD.pause) {
                return code;
            }

            uint checksum = 0;
            for (int i = 0; i < code.Length; i++) {
                checksum += code[i];
            }
            checksum += adr;
            checksum += Convert.ToByte(value);
            checksum = checksum % 256;

            code = new byte[]{ 0xFF, (byte)adr, code[0], code[1], code[2], Convert.ToByte(value), (byte)checksum };

            return code;
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
                    code = new byte[] { 0x00, 0x08, 0x00 };
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
                    code = new byte[] { 0x25, 0x00, 0x00 };
                    break;
                case "setpantiltspeed":
                    break;

                // no values // 
                case "stop":
                    code = new byte[] { 0x00, 0x00, 0x00 };
                    break;
                case "mono":
                case "monocolor":
                case "monocolour":
                    code = new byte[] { 0x00, 0x07, 0x03 };
                    break;


                // queries //
                case "querytilt":
                    code = new byte[] { 0x00, 0x51, 0x00 };
                    break;
                case "querypan":
                    code = new byte[] { 0x00, 0x53, 0x00 };
                    break;
                case "queryfov":
                case "queryzoom":
                    code = new byte[] { 0x00, 0x55, 0x00 };
                    break;

                default:
                    code = null;
                    break;
            }

            return code;
        }

    }
}
