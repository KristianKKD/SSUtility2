using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSUtility2 {

    public class RTSPPresets {

        //Name;FullAdr;RTSPIP;RTSPPort;RTSP;Username;Password;ManualEnabled;PelcoID;ControlIP;ControlPort;
        const int columns = 11;
        public string[,] allPresets = new string[columns, 99];

        public void SaveToConfig() {
            for (int i = 0; i < allPresets.Length; i++) {
                
            }
        }

        public void LoadConfig(List<ConfigVar> configList) {
            //reference stuff
            //try {
            //    line = line.Trim();
            //    string[] sets = new string[allPresets..Columns.Count];

            //    string val = "";
            //    int setsPos = 0;
            //    foreach (char c in line.ToCharArray()) {
            //        if (c.ToString() == ";") {
            //            sets[setsPos] = val;
            //            val = "";
            //            setsPos++;
            //        } else
            //            val += c.ToString();
            //    }

            //    if (curRow == null)
            //        curRow = (DataGridViewRow)dgv_Presets.Rows[0].Clone();

            //    for (int i = 0; i < sets.Length; i++)
            //        curRow.Cells[i].Value = sets[i];

            //    dgv_Presets.Rows.Add(curRow);

            //    AddToOptions(curRow);


                //load defaults here too?
                int defaultCount = 4;
            for (int i = 0; i < configList.Count; i++) { //count - 1 ?
                for (int o = 0; o < 11; o++) {
                    allPresets[o, i + defaultCount] = configList[i].
                }
            }
        }

    }

}
