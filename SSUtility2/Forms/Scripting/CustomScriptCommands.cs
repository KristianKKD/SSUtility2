using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class ScriptCommand {
        public string[] names;
        public byte[] codeContent;
        public string description;
        public bool custom;
        public int valueCount;
        public bool isQuery;
        public string validValues;

        public ScriptCommand(string[] n, byte[] code, string text, int values,
            bool queryType = false, bool scriptCommand = false, string validVals = "") {
            names = n;
            codeContent = code;
            description = text;
            custom = scriptCommand;
            valueCount = values;
            isQuery = queryType;
            validValues = validVals;
        }
    }

    public class CustomScriptCommands {

        readonly static ScriptCommand pause = new ScriptCommand(new string[] { "pause", "wait" }, PelcoD.pause, "Pause the script execution for X milliseconds", 1, false, true, "0-inf");
        readonly static ScriptCommand loop = new ScriptCommand(new string[] { "loop", "repeat" }, PelcoD.loop, "Loop any following commands X number of times. Looped commands will continue to be sent until the stated quanitity of loops is met or the stop execution button is pressed", 1, false, true, "0-INF");
        readonly static ScriptCommand loopStop = new ScriptCommand(new string[] { "loopstop", "stoploop" }, PelcoD.loopStop, "Will start reading scripted lines directly below the previous loop command. *If there is no loop, this command will be ignored.*", 1, false, true);
        readonly static ScriptCommand connect = new ScriptCommand(new string[] { "connect", "ip" }, PelcoD.connect, "Connect to specified IP + port, example usage: 'connect 192.168.1.183:554'", 1, false, true);
        readonly static ScriptCommand reconfig = new ScriptCommand(new string[] { "reconfig" }, PelcoD.reconfig, "Query for camera config and apply it to settings", 0, true, true);
        readonly static ScriptCommand mainplayerconnect = new ScriptCommand(new string[] { "play", "mainplayerplay" }, PelcoD.mainplay, "Play given X RTSP address on the mainplayer", 1, false, true);//
        readonly static ScriptCommand swapToPreset = new ScriptCommand(new string[] { "swapto", "campreset", "usecampreset" }, PelcoD.swapPreset, "Select given User Preset (can give index or name)", 1, false, true);//
        readonly static ScriptCommand execScript = new ScriptCommand(new string[] { "exec", "script" }, PelcoD.execScript, "Execute the script found in the given absolute path, example path: \"" + @"C:\Users\SilentSentinel\Documents\SSUtility\script.txt" + "\"", 1, false, true);

        readonly static ScriptCommand stop = new ScriptCommand(new string[] { "stop" }, new byte[] { 0x00, 0x00, 0x00, 0x00 }, "Stops whatever the camera is doing", 0);
        readonly static ScriptCommand mono = new ScriptCommand(new string[] { "mono", "monocolour", "monocolor" }, new byte[] { 0x00, 0x07, 0x00, 0x03 }, "Camera video toggles between color and black/white pallete", 0);
        readonly static ScriptCommand panzero = new ScriptCommand(new string[] { "panzero", "zeropan", "azimuth" }, new byte[] { 0x00, 0x49, 0x00, 0x00 }, "The camera's zero pan is set to the current rotation", 0);
        readonly static ScriptCommand systemrestart = new ScriptCommand(new string[] { "restart", "remotereset" }, new byte[] { 0x00, 0x0F, 0x00, 0x00 }, "Causes a system restart (soft boot)", 0); //
        readonly static ScriptCommand toggleosd = new ScriptCommand(new string[] { "osd", "toggleosd" }, new byte[] { 0x00, 0x17, 0x00, 0x00 }, "Toggle OSD On/Off", 0);//
        readonly static ScriptCommand startrecordpattern = new ScriptCommand(new string[] { "recordpatternstart" }, new byte[] { 0x00, 0x1F, 0x00, 0x00 }, "Starts recording X Mimic Tour", 1, false, false, "0-3");//
        readonly static ScriptCommand stoprecordpattern = new ScriptCommand(new string[] { "recordpatternstop" }, new byte[] { 0x00, 0x21, 0x00, 0x00 }, "Stops recording X Mimic Tour", 0);//
        readonly static ScriptCommand runpattern = new ScriptCommand(new string[] { "runpattern" }, new byte[] { 0x00, 0x23, 0x00, 0x00 }, "Run tour X", 1, false, false, "0-19");//

        readonly static ScriptCommand setzoomspeed = new ScriptCommand(new string[] { "setzoomspeed", "zoomspeed", "speedzoom" }, new byte[] { 0x00, 0x25, 0x00, 0x00 }, "Sets camera zoom speed to X", 1, false, false, "0-3");
        readonly static ScriptCommand setfocusspeed = new ScriptCommand(new string[] { "setfocusspeed", "focusspeed", "speedfocus" }, new byte[] { 0x00, 0x27, 0x00, 0x00 }, "Sets camera focus speed to X", 1, false, false, "0-3");
        readonly static ScriptCommand setpanpos = new ScriptCommand(new string[] { "setpanpos", "setpan", "abspan" }, new byte[] { 0x00, 0x4B, 0x00, 0x00 }, "Sets camera pan position to X", 2, false, false, "0-360");
        readonly static ScriptCommand setiltpos = new ScriptCommand(new string[] { "settiltpos", "settilt", "abstilt" }, new byte[] { 0x00, 0x4D, 0x00, 0x00 }, "Sets camera tilt position to X", 2, false, false, "0-360");
        readonly static ScriptCommand setzoompos = new ScriptCommand(new string[] { "setzoompos", "setzoom", "abszoom" }, new byte[] { 0x00, 0x4F, 0x00, 0x00 }, "Sets camera zoom pos position to X", 2, false, false, "0-655");//
        readonly static ScriptCommand setfocuspos = new ScriptCommand(new string[] { "setfocuspos", "setfocus", "absfocus" }, new byte[] { 0x01, 0x4F, 0x00, 0x00 }, "Sets camera focus pos position to X", 2, false, false, "0-655");//
        
        readonly static ScriptCommand setautofocus = new ScriptCommand(new string[] { "af", "setautofocus" }, new byte[] { 0x00, 0x2B, 0x00, 0x00 }, "Set autofocus to On or Off with X", 1, false, false, "0-1");//
        readonly static ScriptCommand setautoiris = new ScriptCommand(new string[] { "autoiris", "setautoiris" }, new byte[] { 0x00, 0x2D, 0x00, 0x00 }, "Set autoiris to On or Off with X", 1, false, false, "0-1");//
        readonly static ScriptCommand setagc = new ScriptCommand(new string[] { "agc", "setautomaticgaincontrol" }, new byte[] { 0x00, 0x2F, 0x00, 0x00 }, "Set Automatic Gain Control to On or Off with X", 1, false, false, "0-1");//
        readonly static ScriptCommand setblc = new ScriptCommand(new string[] { "blc", "setbacklightcompensation" }, new byte[] { 0x00, 0x31, 0x00, 0x00 }, "Set Back Light Compensation to On or Off with X", 1, false, false, "0-1");//
        readonly static ScriptCommand setwdr = new ScriptCommand(new string[] { "wdr", "setwidedynamicrange" }, new byte[] { 0x01, 0x31, 0x00, 0x00 }, "Set Wide Dynamic Range to On or Off with X", 1, false, false, "0-1");//
        //readonly static ScriptCommand settagcgb = new ScriptCommand(new string[] { "tagcgb", "setthermalagcgainbias" }, new byte[] { 0x02, 0x3F, 0x00, 0x00 }, "Set Thermal AGC Gain Bias to X", 2);//values seem weird
        //readonly static ScriptCommand settagclb = new ScriptCommand(new string[] { "tagclb", "setthermalagclevelbias" }, new byte[] { 0x03, 0x3F, 0x00, 0x00 }, "Set Thermal AGC Level Bias to X", 2);//values seem weird
        readonly static ScriptCommand setdrsice = new ScriptCommand(new string[] { "drsice", "setdrsice" }, new byte[] { 0x04, 0x3F, 0x00, 0x00 }, "Set DRS ICE level to X", 1, false, false, "0-7");

        readonly static ScriptCommand querypan = new ScriptCommand(new string[] { "querypan" }, new byte[] { 0x00, 0x51, 0x00, 0x00 }, "Returns camera pan position", 0, true);
        readonly static ScriptCommand querytilt = new ScriptCommand(new string[] { "querytilt" }, new byte[] { 0x00, 0x53, 0x00, 0x00 }, "Returns camera tilt position", 0, true);
        readonly static ScriptCommand queryzoom = new ScriptCommand(new string[] { "queryfov", "queryzoom"}, new byte[] { 0x00, 0x55, 0x00, 0x00 }, "Returns camera FOV", 0, true);
        readonly static ScriptCommand queryfocus = new ScriptCommand(new string[] { "queryfocus" }, new byte[] { 0x01, 0x55, 0x00, 0x00 }, "Returns camera focus value", 0, true);
        readonly static ScriptCommand querypost = new ScriptCommand(new string[] { "querypost" }, new byte[] { 0x07, 0x6B, 0x00, 0x00 }, "Returns camera test data", 0, true);
        readonly static ScriptCommand queryconfig = new ScriptCommand(new string[] { "queryconfig" }, new byte[] { 0x03, 0x6B, 0x00, 0x00 }, "Returns camera config", 0, true);
        
        readonly static ScriptCommand learnPreset = new ScriptCommand(new string[] { "learnpreset", "setpreset", "learn" }, new byte[] { 0x00, 0x03, 0x00, 0x00 }, "Saves current PTZ state of the camera and assigns it to the X value memory position", 1, false, false, "1-255");
        readonly static ScriptCommand clearPreset = new ScriptCommand(new string[] { "clearpreset", "clear" }, new byte[] { 0x00, 0x05, 0x00, 0x00 }, "Clears preset X from camera memory", 1, false, false, "1-255");
        readonly static ScriptCommand gotoPreset = new ScriptCommand(new string[] { "gotopreset", "goto" }, new byte[] { 0x00, 0x07, 0x00, 0x00 }, "Restores preset X PTZ settings", 1, false, false, "1-255");


        public readonly static ScriptCommand[] customCommands = new ScriptCommand[] {
            pause,
            loop,
            loopStop,
            connect,
            reconfig,
            mainplayerconnect,
            swapToPreset,
            execScript,
        };

        public readonly static ScriptCommand[] queryCommands = new ScriptCommand[] {
            querypan,
            querytilt,
            queryzoom,
            queryfocus,
            querypost,
            queryconfig,
        };

        public readonly static ScriptCommand[] controlCommands = new ScriptCommand[] {
            setzoomspeed,
            setfocusspeed,
            setautofocus,
            setpanpos,
            setiltpos,
            setzoompos,
            setfocuspos,
        };

        public readonly static ScriptCommand[] miscCommands = new ScriptCommand[] {
            learnPreset,
            clearPreset,
            gotoPreset,
            stop,
            panzero,
            mono,
            systemrestart,
            toggleosd,
            startrecordpattern,
            stoprecordpattern,
            runpattern,

            setautoiris,
            setagc,
            setblc,
            setwdr,
            //settagcgb,
            //settagclb,
            setdrsice,
        };

        public readonly static ScriptCommand[][] cameraArrayCommands = new ScriptCommand[][]{ //megalist
            customCommands,
            controlCommands,
            queryCommands,
            miscCommands,
        };

        public static bool stopScript;

        public static List<ScriptCommand> userAddedCommands;

        public static async Task<ScriptCommand> CheckForCommands(string line, uint adr, bool allowCustom) {
            ScriptCommand presetCom = CheckForPresets(line).Result;
            ScriptCommand fail = new ScriptCommand(null, PelcoD.noCommand, null, 0, false, true);
            
            if (presetCom == null || (!allowCustom && presetCom.custom))
                return fail;

            ScriptCommand com = new ScriptCommand(presetCom.names, presetCom.codeContent, presetCom.description,
                 presetCom.valueCount, presetCom.isQuery, presetCom.custom); //need to be careful not to overwrite my commands

            if (com.custom) {
                await DoCustomCommand(com, line);
                return com;
            }
            
            int value = CheckForVal(line);
            com = RefineCode(com, adr, value).Result;

            return com;
        }

        public static int CheckForVal(string line) {
            int value = 0;
            
            int marker = line.IndexOf(" ");
            if(marker == -1)
                marker = line.IndexOf(":");

            if (marker != -1)
                int.TryParse(line.Substring(marker + 1), out value);

            return value;
        }

        static async Task<ScriptCommand> RefineCode(ScriptCommand com, uint adr, int value) {
            byte[] code = com.codeContent;

            if (com.valueCount == 1) {
                code[3] = Convert.ToByte(value);
            } else if (com.valueCount == 2) {
                string hexVal = (value * 100).ToString("X4");
               
                code[2] = Convert.ToByte(int.Parse(hexVal.Substring(0, 2), System.Globalization.NumberStyles.HexNumber));
                code[3] = Convert.ToByte(int.Parse(hexVal.Substring(2, 2), System.Globalization.NumberStyles.HexNumber));
            }

            uint checksum = Tools.GetCheckSum(code, adr);
            com.codeContent = new byte[] { 0xFF, (byte)adr, code[0], code[1], code[2], code[3], (byte)checksum };
            return com;
        }

        public static async Task<ScriptCommand> CheckForPresets(string line) {
            try {
                string start = line;

                int markerPos = line.IndexOf(" ");

                if (markerPos > 0)
                    start = line.Substring(0, markerPos).Trim();

                List<ScriptCommand> allCommands = new List<ScriptCommand>();

                foreach (ScriptCommand[] commandArray in cameraArrayCommands)
                    foreach (ScriptCommand sc in commandArray)
                        allCommands.Add(sc);

                foreach (ScriptCommand sc in userAddedCommands)
                    allCommands.Add(sc);

                foreach (ScriptCommand sc in allCommands) {
                    if (line.Contains(Tools.ReadCommand(sc.codeContent, true)))
                        return sc;

                    for (int x = 0; x < sc.names.Length; x++)
                        if (sc.names[x] == start)
                            return sc;

                }
            }catch(Exception e) {
                Console.WriteLine("CUSTOMSCRIPTCOMMANDSPRESETCHECK\n" + e.ToString());
            }

            return null;
        }

        public static async Task<string> QuickQuery(string command) {
            ScriptCommand send = CheckForCommands(command, Tools.MakeAdr(), false).Result;

            return await AsyncCamCom.QueryNewCommand(send);
        }

        public static async Task QuickCommand(string command, bool sendAsync = true, int manualAdr = -5) {
            try {
                if (!await AsyncCamCom.TryConnect().ConfigureAwait(false)) {
                    MessageBox.Show("Not connected to camera!\nTried sending: " + command);
                    return;
                }

                uint adr = Tools.MakeAdr();

                if (manualAdr != -5) //if sending preset
                    adr = Convert.ToUInt32(manualAdr);

                ScriptCommand send = CheckForCommands(command, adr, false).Result;
                if (send.codeContent == PelcoD.noCommand) {
                    if (command.Length == 0) {
                        MessageBox.Show("Command length is 0!\nMake sure to check the command in the settings!");
                        return;
                    } else {
                        byte[] code = Tools.ConvertMsgToByte(command);
                        if (code == null) {
                            MessageBox.Show("Command invalid!\nMake sure to enter command in perfect format!\n(FF 0x xx xx xx xx yy)");
                            return;
                        }
                        send = new ScriptCommand(new string[] { "custom" }, code, "", 0);
                    }
                }

                if (!sendAsync) {
                    AsyncCamCom.SendNonAsync(send.codeContent);
                } else {
                    var t = Task.Factory.StartNew(() => {
                        AsyncCamCom.SendScriptCommand(send);
                    });
                    Task.WaitAll();
                }
            } catch (Exception e) {
                Tools.ShowPopup("Failed to send quick command!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        public static void DoPreset(int adr, byte p) {
            QuickCommand("goto " + p, false, adr);
        }

        public static async Task SendMechanicalMenu() {
            if (!await AsyncCamCom.TryConnect().ConfigureAwait(false)) {
                return;
            }

            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFF, 0x07 });
        }

        public static async Task SendAdminMenu() {
            if (!await AsyncCamCom.TryConnect().ConfigureAwait(false)) {
                return;
            }

            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 });
            AsyncCamCom.SendNonAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFE, 0x06 });
        }


        static async Task DoCustomCommand(ScriptCommand com, string line) {
            try {
                if (com.codeContent == PelcoD.pause) {
                    int value = CheckForVal(line);
                    MainForm.m.WriteToResponses("Waiting: " + value.ToString() + "ms", true);

                    while (value > 0) {
                        if (stopScript) {
                            break;
                        }
                        value -= 200;
                        await Task.Delay(200).ConfigureAwait(false);
                    }
                    stopScript = false;

                } else if (com.codeContent == PelcoD.connect) {
                    int ipmarker = line.IndexOf(" ");
                    int portmarker = line.IndexOf(":");
                    if (ipmarker == -1 || portmarker == -1) {
                        MainForm.m.WriteToResponses("Failed to parse IP or port! (" + line + ")", false);
                        return;
                    }

                    IPAddress parsed;
                    int port;
                    if (IPAddress.TryParse(line.Substring(ipmarker + 1, portmarker - ipmarker - 1), out parsed) && int.TryParse(line.Substring(portmarker + 1), out port)) {
                        await AsyncCamCom.TryConnect(false, new IPEndPoint(parsed, port));
                    }
                } else if (com.codeContent == PelcoD.reconfig) {
                    InfoPanel.i.CheckForCamera();
                } else if (com.codeContent == PelcoD.mainplay) {
                    int marker = line.IndexOf(" "); //maybe move this up if more customs need it
                    if (marker <= 0)
                        marker = line.IndexOf(":");

                    MainForm.m.mainPlayer.Play(false, false);
                } else if (com.codeContent == PelcoD.swapPreset) {
                    //ComboBox cb = MainForm.m.setPage.cB_ipCon_CamType;
                    //string oldVal = cb.Text;

                    //int marker = line.IndexOf(" ");
                    //if (marker <= 0)
                    //    marker = line.IndexOf(":");

                    //string val = line.Substring(marker + 1).Trim().ToLower();
                    //int foundInt;

                    //if (int.TryParse(val, out foundInt) && cb.Items[foundInt - 1] != null) //index of preset
                    //    cb.SelectedIndex = foundInt - 1;
                    //else {
                    //    foreach (DataGridViewRow row in MainForm.m.up.dgv_Presets.Rows) {
                    //        if (row.Cells[0].Value != null) {
                    //            if (row.Cells[0].Value.ToString().ToLower().Trim().Contains(val)) { //set it to the preset found
                    //                cb.Text = row.Cells[0].Value.ToString();
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}

                    //if (cb.Text != oldVal)
                    //    MainForm.m.setPage.UpdateID(cb);
                    //else
                    //    MainForm.m.WriteToResponses("Failed to find user preset: " + val, false);
                }


            }catch(Exception e) {
                MainForm.m.WriteToResponses("Failed to execute custom command: " + line + Tools.ShowScriptCommandInfo(com, false) + "\n" + e.ToString(), false);
            }
        }

    }
}
