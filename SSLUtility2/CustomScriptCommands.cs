using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSLUtility2 {

    public static class CustomScriptCommands {

        public static async Task<byte[]> CheckForCommands(string line, uint adr, PelcoD pdRef) {
            D protocol = new D();
            byte[] code = null;
            line = line.ToLower();
            string start = line;
            int value = 0;
            int firstSpace = line.IndexOf(" ");
            if (firstSpace != -1) {
                start = line.Substring(0, firstSpace);
            }

            switch (start) {
                case "wait":
                case "pause":
                    value = int.Parse(line.Substring(firstSpace + 1));
                    if (firstSpace != -1) {
                        await Task.Delay(value).ConfigureAwait(false);
                    }
                    pdRef.WriteToResponses("Waiting: " + value);
                    code = PelcoD.noGo;
                    break;
                case "stop":
                    code = protocol.CameraStop(adr);
                    break;
                case "mono":
                    code = protocol.Preset((adr), 3, D.PresetAction.Goto);
                    break;
            }

            return code;
        }

    }
}
