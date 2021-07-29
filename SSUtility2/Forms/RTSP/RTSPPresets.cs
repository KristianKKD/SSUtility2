using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public static class RTSPPresets {

        public enum PresetColumn {
            Name,
            FullAdr,
            RTSPIP,
            RTSPPort,
            RTSP,
            Username,
            Password,
            ManualEnabled,
            PelcoID,
            ControlIP,
            ControlPort
        }

        //Name;FullAdr;RTSPIP;RTSPPort;RTSP;Username;Password;ManualEnabled;PelcoID;ControlIP;ControlPort;
        static int columns = 11;
        public static string[,] allPresets = new string[columns, 99];
        public static int currentPresetCount = 0;

        public static List<string> GetAll() {
            List<string> all = new List<string>();
            for (int y = 0; y < currentPresetCount; y++) {
                string currentLine = "";
                for (int x = 0; x < columns; x++)
                    currentLine += allPresets[x, y] + ";";

                all.Add(currentLine);
            }

            return all;
        }

        public static void LoadPreset(string line) {
            line = line.Trim();

            int nextPos = 0;
            for (int i = 0; i < columns; i++) {
                int lastPos = nextPos;
                nextPos = line.Substring(nextPos).IndexOf(";") + 1 + lastPos;
                allPresets[i, currentPresetCount] = line.Substring(lastPos, nextPos - lastPos - 1);
            }

            if (allPresets[columns - 1, currentPresetCount] != null)
                currentPresetCount++;

            ReloadAll();
        }

        static void ReloadAll() {
            //Reloads all settings every time this is updated, make a way so it reloads after it finishes loading later
            List<string> all = new List<string>();

            for (int i = 0; i < currentPresetCount; i++)
                all.Add(allPresets[0, i]);
            
            VideoSettings.UpdateAllPresetBoxes(all);
        }

        static RTSPWizard wiz;
        public static void OpenPreset(string presetName) {
            if (wiz != null)
                wiz.Dispose();

            string returnedVal = GetValue(PresetColumn.FullAdr, presetName);
            if (returnedVal == "") {
                MessageBox.Show("Failed to find preset:\n" + presetName);
                return;
            }

            wiz = new RTSPWizard(returnedVal);
            wiz.Show();
        }

        public static string GetValue(PresetColumn targetValue, string identifierValue, PresetColumn identifierType = PresetColumn.Name) {
            for (int i = 0; i < currentPresetCount; i++) {
                if (allPresets[(int)identifierType, i] == identifierValue)
                    return allPresets[1, i];
            }

            return "";
        }

        public static void CreateNew() {
            RTSPWizard wiz = new RTSPWizard(null);
            wiz.Show();
        }

    }

}
