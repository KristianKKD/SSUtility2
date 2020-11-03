using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSLUtility2 {

    public static class CustomScriptCommands {

        public static async Task<string> CheckForQueries(string line) {
            string returnVal = "";
            byte[] code = null;

            switch (line) {
                case "querytilt":
                    code = new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 };
                    break;
                case "querypan":
                    code = new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 };
                    break;
            }

            string response = CameraCommunicate.Query(code, null, null).Result;
            return response;
        }

        public static async Task<byte[]> CheckForCommands(string line, uint adr, PelcoD pdRef) {
            byte[] code = null;
            line = line.ToLower();
            string start = line;
            int value = 0;
            int firstSpace = line.IndexOf(" ");
            if (firstSpace != -1) {
                start = line.Substring(0, firstSpace);
            }
            byte adrByte = Convert.ToByte(adr);
            byte valByte = Convert.ToByte(value);

            switch (start) {
                // value accepting //
                case "wait":
                case "pause":
                    value = int.Parse(line.Substring(firstSpace + 1));
                    if (firstSpace != -1) {
                        await Task.Delay(value).ConfigureAwait(false);
                    }
                    pdRef.WriteToResponses("Waiting: " + value);
                    code = PelcoD.noGo;
                    break;
                case "up":
                    code = new byte[] { 0xFF, adrByte, 0x00, 0x08, 0x00, valByte, 0x00 };
                    break;
                case "down":
//                    code = new byte[] { 0xFF, adrByte, 0x00, 0x08, 0x00, valByte, 0x00 };
                    break;
                case "left":
                    break;
                case "right":
                    break;
                // no values // 
                case "stop":
                    code = protocol.CameraStop(adr);
                    break;
                case "mono":
                case "monocolour":
                    code = protocol.Preset((adr), 3, D.PresetAction.Goto);
                    break;
                case "getpan":
                    code = new byte[] { 0XFF, adrByte, 0x00, 0x51, 0x00, 0x00, 0x00 };
                    break;
               
            }

            return code;
        }

    }
}
