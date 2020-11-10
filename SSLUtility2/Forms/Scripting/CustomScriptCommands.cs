using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSLUtility2 {

    public static class CustomScriptCommands {


        public static async Task<byte[]> CheckForCommands(string line, uint adr, PelcoD pdRef) {
            byte[] code = new byte[3];

            code = CheckForPresets(line).Result;

            int value = CheckForVal(line);
            code = RefineCode(code, adr, pdRef, value).Result;

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

        static async Task<byte[]> RefineCode(byte[] code, uint adr, PelcoD pdRef, int value) {
            if (code == PelcoD.pause) {
                await Task.Delay(value).ConfigureAwait(false);
                pdRef.WriteToResponses("Waiting: " + value.ToString());
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
            
            int markerPos = line.IndexOf(":");

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

                // no values // 
                case "stop":
                    code = new byte[] { 0x00, 0x00, 0x00 };
                    break;
                case "mono":
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
                    code = new byte[] { 0x0A, 0x6B, 0x00 };
                    break;
            }

            return code;
        }

    }
}
