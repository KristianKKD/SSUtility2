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
            Player,
            SSUtility,
            Global,
        }

        RecordType type;
        Detached givenPlayer;
        public Process p;
        public bool recording;
        public string outPath;

        //press recording->video->global
        //all open detached + attached + main player + SSUtility are recorded
        //press same button stops recording
        //dialogue opens to ask for location

        public static FFMPEGRecord ssutilRecorder = null;

        public static async Task GlobalRecord() {
            string customTempFolder = ConfigControl.savedFolder + @"temp\";

            try {
                if (ssutilRecorder == null) {
                    StopAll();

                    List<string> listOfRecordingPresets = new List<string>();

                    Tools.CheckCreateFile(null, customTempFolder);

                    foreach (Detached d in MainForm.m.detachedList) {
                        string presetName = d.settings.GetPresetName();

                        if (presetName == "" || !d.IsPlaying() || listOfRecordingPresets.Contains(presetName))
                            continue;

                        d.recorder = null;
                        d.recorder = Tools.ToggleRecord(d, null, null, true, customTempFolder + presetName + ".mp4");
                        listOfRecordingPresets.Add(presetName);
                    }

                    ssutilRecorder = Tools.ToggleRecord(null, MainForm.m.Menu_Recording_Video, MainForm.m.Menu_Recording_StopRecording, false, customTempFolder + "SSUtility.mp4");
                } else {
                    List<string> outPaths = new List<string>();
                    foreach (Detached d in MainForm.m.detachedList) {
                        if (d.recorder != null && d.recorder.recording)
                            outPaths.Add(d.recorder.outPath);
                    }

                    if (ssutilRecorder != null && ssutilRecorder.recording)
                        outPaths.Add(ssutilRecorder.outPath);

                    StopAll();
                    MainForm.m.Menu_Recording_StopRecording.Visible = false;

                    FolderBrowserDialog fdg = new FolderBrowserDialog();
                    fdg.SelectedPath = ConfigControl.savedFolder;
                    fdg.ShowNewFolderButton = true;
                    DialogResult result = fdg.ShowDialog();
                    if (result == DialogResult.OK) {
                        foreach (string path in outPaths)
                            Tools.CopySingleFile(fdg.SelectedPath + path.Substring(path.LastIndexOf(@"\")), path);

                        MessageBox.Show("Saved recordings to: " + fdg.SelectedPath);

                        Tools.DeleteDirectory(customTempFolder);
                    } else {
                        MessageBox.Show("Saved recordings to: " + customTempFolder);
                    }


                    MainForm.m.Menu_Recording_Video.Visible = true;
                    MainForm.m.Menu_Recording_StopRecording.Visible = false;
                }
            }catch(Exception e) {
                MessageBox.Show("GLOBALRECORDING\n" + e.ToString());
            }
        }

        public static void StopAll() {
            try {
                foreach (Process pr in MainForm.m.recorderProcessList)
                    StopRecording(pr, false);

                foreach (Detached d in MainForm.m.detachedList)
                    d.recorder = null;

                ssutilRecorder = null;

                MainForm.m.recorderProcessList.Clear();
            } catch (Exception e) {
                MessageBox.Show("STOPALL\n" + e.ToString());
            }
        }

        public static void StopSingleInGlobal(Detached d) {
            if (d.recorder == null)
                return;

            d.recorder = Tools.ToggleRecord(d, null, null);
        }

        public FFMPEGRecord(RecordType rt, Detached player, string customPath = "") {
            type = rt;
            givenPlayer = player;
            Record(customPath);
        }

        void Record(string customPath) {
            try {
                string programPath = Application.ExecutablePath.Replace("SSUtility2.0.exe", "");
                string libPath = programPath + "Lib/ffmpeg/ffmpeg.exe";

                string input = "";
                string gdigrab = "-f gdigrab -draw_mouse 0";

                switch (type) {
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
                        givenPlayer = null;
                        break;
                }

                if (customPath != "")
                    outPath = Tools.PathNoOverwrite(customPath);
                else
                    outPath = Tools.GivePath(Tools.PathType.Video, givenPlayer);

                string arguments = gdigrab + " -i " + input
                    + " -framerate " + ConfigControl.recFPS.stringVal + " -b:v " + (ConfigControl.recQual.intVal * 30) + "k "
                    + "\"" + outPath + "\"";

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
                MainForm.m.recorderProcessList.Add(p);
            } catch (Exception e) {
                Console.WriteLine("RECORD\n" + e.ToString());
                recording = false;
            }
        }

        public static void StopRecording(Process proc, bool remove = true) {
            try {
                if (proc == null || proc.HasExited)
                    return;

                if (remove)
                    MainForm.m.recorderProcessList.Remove(proc);

                proc.StandardInput.Write("n");
                proc.StandardInput.Write("q");
                proc.WaitForExit();
                proc.Close();
            } catch (Exception e) {
                MessageBox.Show("STOPRECORDING\n" + e.ToString());
            }
        }

    }

}
