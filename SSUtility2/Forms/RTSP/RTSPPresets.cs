using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSUtility2 {

    public class RTSPPresets {

        public static RTSPPresets presets;

        public void Init() {
            presets = this;
        }

        //Name;FullAdr;RTSPIP;RTSPPort;RTSP;Username;Password;ManualEnabled;PelcoID;ControlIP;ControlPort;
        const int columns = 11;
        public string[,] allPresets = new string[columns, 99];
        public int currentPresetCount = 0;

        public List<string> GetAll() {
            List<string> all = new List<string>();
            for (int y = 0; y < currentPresetCount; y++) {
                string currentLine = "";
                for (int x = 0; x < columns; x++)
                    currentLine += allPresets[x, y] + ";";

                all.Add(currentLine);
            }

            return all;
        }

        public void LoadPreset(string line) {
            line = line.Trim();

            int nextPos = 0;
            for (int i = 0; i < columns; i++) {
                int lastPos = nextPos;
                nextPos = line.Substring(nextPos).IndexOf(";") + 1 + lastPos;
                allPresets[i, currentPresetCount] = line.Substring(lastPos, nextPos - lastPos - 1);
            }

            if (allPresets[columns - 1, currentPresetCount] != null)
                currentPresetCount++;
        }

        void FullToParts(string full) {
            int usernamePos = full.IndexOf(":") + 1; //should be the first one
            if (full[6] != '/' && usernamePos <= 0) //if fullAdr isn't completed in the expected way
                return;

            int atPos = full.IndexOf("@") + 1;
            int secondColonPos = full.IndexOf(":", usernamePos); // + secondColonPos?

            string username = full.Substring(7, usernamePos - 7); //7 = rtsp://
            string password = full.Substring(usernamePos, atPos - usernamePos);
            string ipaddress = full.Substring(atPos, secondColonPos - atPos);
            string port = full.Substring(secondColonPos, full.IndexOf("/", 7) - secondColonPos);
            string url = full.Substring(secondColonPos + port.Length + 1);

            Console.WriteLine("rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url);
        }

        public void WizardFull(string fullAdr) {
            
        }

    }

}
