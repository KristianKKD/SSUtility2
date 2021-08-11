using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {

    public class FFMPEGRecord {

        public enum RecordType {
            Desktop,
            Player,
            SSUtility,
        }

        RecordType type;
        Detached givenPlayer;
        Process p;
        public bool recording;
        public string outPath;

        public FFMPEGRecord(RecordType rt, Detached player) {
            type = rt;
            givenPlayer = player;
            Record();
        }

        public void Record() {
            try {
                string programPath = Application.ExecutablePath.Replace("SSUtility2.0.exe", "");
                string libPath = programPath + "Lib/ffmpeg/ffmpeg.exe";

                string input = "";
                string gdigrab = "-f gdigrab -draw_mouse 0";

                switch (type) {
                    case RecordType.Desktop:
                        input = "desktop";
                        givenPlayer = null;
                        break;
                    case RecordType.Player:
                        if (givenPlayer == null) {
                            MessageBox.Show("No player given for player recording!");
                            return;
                        }
                        input = givenPlayer.settings.GetCombined();
                        gdigrab = "";
                        break;
                    case RecordType.SSUtility:
                        input = "title=\"" + "SSUtility2.0" + "\"";
                        givenPlayer = MainForm.m.mainPlayer;
                        break;
                }

                outPath = Tools.GivePath(Tools.PathType.Video, givenPlayer);
                outPath = outPath.Replace(" ", "_");

                string arguments = gdigrab + " -i " + input
                    + " -framerate " + ConfigControl.recFPS.stringVal + " -b:v " + (ConfigControl.recQual.intVal * 30) + "k " + outPath;

                Console.WriteLine("args-------------------" + arguments);

                p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = libPath;
                p.StartInfo.Arguments = arguments;
                p.Start();

                recording = true;
            } catch (Exception e) {
                recording = false;
            }
        }

        public void StopRecording() {
            p.StandardInput.Write("q");
            p.WaitForExit();
            p.Close();
        }

    }

}
