﻿using System;
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
            PelcoID,
            ControlIP,
            ControlPort,
            Index,
        }

        //Name;FullAdr;RTSPIP;RTSPPort;RTSP;Username;Password;PelcoID;ControlIP;ControlPort;
        readonly static int columns = 10;
        public static string[,] allPresets;
        public static int currentPresetCount = 0;
        static RTSPWizard wiz;

        public static List<string> GetAll() {
            List<string> all = new List<string>();
            for (int y = 0; y < currentPresetCount; y++)
                all.Add(UnpackPresetToLine(y));

            return all;
        }

        public static void Reload(bool force) {
            allPresets = new string[columns, 99];
            currentPresetCount = 0;
            VideoSettings.UpdateAllPresetBoxes(force);
        }

        public static string UnpackPresetToLine(int y) {
            string currentLine = "";
            for (int x = 0; x < columns; x++)
                currentLine += allPresets[x, y] + ";";

            return currentLine;
        }

        public static int LoadPreset(string line, int loadIndex = -1) {
            line = line.Trim();

            int loadPos = currentPresetCount;
            if (loadIndex != -1)
                loadPos = loadIndex;

            int nextPos = 0;
            for (int i = 0; i < columns; i++) {
                int lastPos = nextPos;
                nextPos = line.Substring(nextPos).IndexOf(";") + 1 + lastPos;
                if (nextPos - lastPos > 0)
                    allPresets[i, loadPos] = line.Substring(lastPos, nextPos - lastPos - 1);
                else
                    allPresets[i, loadPos] = "";
            }

            if(loadPos == currentPresetCount)
                currentPresetCount++;

            ReloadAll();

            return loadPos;
        }

        static void ReloadAll() {
            //Reloads all settings every time this is updated, make a way so it reloads after it finishes loading later

            VideoSettings.UpdateAllPresetBoxes();
        }

        public static List<string> GetPresetList() {
            List<string> all = new List<string>();

            for (int i = 0; i < currentPresetCount; i++)
                all.Add(allPresets[0, i]);

            return all;
        }

        public static void OpenPreset(string presetName, VideoSettings sets) {
            if (wiz != null)
                wiz.Dispose();

            wiz = new RTSPWizard(GetPreset(presetName), sets);
            wiz.Show();
        }

        public static string[] GetPreset(string identifierName) {
            string[] returnPreset = new string[10];

            for (int i = 0; i < currentPresetCount; i++) {
                if (allPresets[TableValue(PresetColumn.Name), i] == identifierName) {
                    for (int o = 0; o < columns; o++) {
                        returnPreset[o] = allPresets[o, i];
                    }
                }
            }

            return returnPreset;
        }

        public static string GetValue(PresetColumn targetValue, string identifierValue, PresetColumn identifierType = PresetColumn.Name) {
            for (int i = 0; i < currentPresetCount; i++) {
                if (allPresets[(int)identifierType, i] == identifierValue) {
                    if (targetValue == PresetColumn.Index)
                        return i.ToString();
                    else
                        return allPresets[(int)targetValue, i];
                }
            }

            return "";
        }

        public static void CreateNew(VideoSettings sets, Hidden.FirstTime firstWindow = null) {
            RTSPWizard wiz = new RTSPWizard(null, sets, firstWindow);
            if (firstWindow != null) {
                firstWindow.Hide();
                wiz.ShowDialog();
            } else
                wiz.Show();
        }

        public static void ForgetPreset(int index) {
            currentPresetCount--;
            for (int y = index; y < currentPresetCount; y++)
                for (int x = 0; x < columns; x++)
                    allPresets[x, y] = allPresets[x, y + 1]; //shift all values back by one, ignoring the ones before the changed one

            ReloadAll();
        }

        public static int TableValue(PresetColumn column) {
            return (int)column;
        }

    }

}
