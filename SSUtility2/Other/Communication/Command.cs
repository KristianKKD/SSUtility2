using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class CommandQueue {

        public static List<Command> savedCommandList;
        public static List<Command> queueList;
        public static List<Command> oldList; //need to add response log handling for this
        public static int totalCommands = 0;

        public static int total = 0;
        public const int commandRate = 100;

        public static int commandRetries = 10;
        
        static Timer SendTimer;

        public static void Init() {
            savedCommandList = new List<Command>();
            queueList = new List<Command>();
            oldList = new List<Command>();

            StartTimer();
        }

        public static void StartTimer() {
            SendTimer = new Timer();
            SendTimer.Interval = commandRate;
            SendTimer.Tick += new EventHandler(SendCurrentCommand);
            SendTimer.Start();
        }

        private static void SendCurrentCommand(object sender, EventArgs e) {
            try {
                if (!MainForm.m.finishedLoading) {
                    return;
                }

                MainForm.m.Tick();
                MainForm.m.rl.UpdateLabels();

                bool infoTicked = false;
                if (ConfigControl.forceCamera.boolVal) {
                    InfoPanel.i.InfoPanelTick();
                    infoTicked = true;
                }

                if (queueList.Count > 0) {
                    Command com = queueList[0];

                    if (!com.invalid && !com.sent && com != null) {
                        AsyncCamCom.currentCom = com;

                        if (com.isInfo && queueList.Count > 1) {
                            foreach (Command c in queueList) {
                                if (c != null && c != com && !c.isInfo) {
                                    queueList.RemoveAt(0);
                                    com = queueList[0];
                                    break;
                                }
                            }
                        }

                        WaitForCommandResponse(com).ConfigureAwait(false);
                    } else {
                        SendCurrentCommand(null, null);
                        queueList.RemoveAt(0);
                    }
                } else {
                    if(!infoTicked)
                        InfoPanel.i.InfoPanelTick();
                }

            } catch (Exception err){
                MessageBox.Show("Error in queuelist.\n" + err.ToString());
            }
        }

        public static async Task WaitForCommandDone(Command com) {
            for (int i = 0; i < commandRetries * 2; i++) {
                await Task.Delay(commandRate).ConfigureAwait(false);

                if (com.done) 
                    break;
            }
        }

        static async Task WaitForCommandResponse(Command com) {
            try {
                SendTimer.Stop();

                if (com.isInfo)
                    com.done = false;

                int i = 0;
                bool repeated = false;
                while (i < commandRetries) {
                     repeated = i > 0;

                    AsyncCamCom.SendCurrent(repeated);
                    if (!com.spammable && !com.isInfo) {
                        break;
                    }
                    
                    if (com.done) {
                        break;
                    } else {
                        await Task.Delay(commandRate);
                    }
                    i++;
                }
                if(repeated)
                    MainForm.m.WriteToResponses("Sent command " + i + " times!", true, com.isInfo);

                if (!com.done) {
                    MainForm.m.WriteToResponses(GetNameString() + "No response!", true, com.isInfo);
                } else {
                    string msg = com.myReturn.msg;
                    if (com.name.Contains("query"))
                        msg = OtherCamCom.ConvertQueryResult(com.name, com.myReturn.msg);
                    
                    MainForm.m.WriteToResponses(GetNameString() + "Received: " + msg, false, com.isInfo);
                }

                com.done = true;

                if (queueList.Contains(com))
                    queueList.Remove(com);
                
                SendTimer.Start();
            } catch (Exception e) {
                Tools.ShowPopup("Failed to process message return!\nShow more?", "Response Failed!", e.ToString());
            }
        }

        public static string GetNameString() {
            try {
                Command com = AsyncCamCom.currentCom;
                string nameString = "";
                if (com.name != null) {
                    nameString = "(" + com.name + ") ";
                }
                return nameString;
            } catch {
                return "";
            }
        }

        public static Command FindCommandByID(int id) {
            for (int i = 0; i < savedCommandList.Count; i++) {
                if (id == savedCommandList[i].id) {
                    return savedCommandList[i];
                }
            }
            return null;
        }

         public static Command FindResultByID(int id) {
            for (int i = 0; i < oldList.Count; i++) {
                if (id == oldList[i].id) {
                    return oldList[i];
                }
            }
            return null;
        }
    }

    public class ReturnCommand {

        public string msg;

        public Command myCommand;

        public void UpdateReturnMsg(string content) {
            msg = content;
            myCommand.done = true;
        }

        public static bool CheckInvalid(string message) {
            if (message == null) {
                return true;
            }
            if (message == OtherCamCom.defaultResult || message.Length < 3) {
                return true;
            }
            return false;
        }

    }

    public class Command {

        public int id;
        public byte[] content;
        public bool invalid;
        public bool isInfo;
        public bool spammable;
        public string name;

        public bool sent;
        public bool done;

        public ReturnCommand myReturn;

        public Command(byte[] code, bool repeat = false, bool isCopy = false, bool spam = false, string firstName = null) {
            content = code;
            isInfo = repeat;
            spammable = spam;
            invalid = CheckInvalid();

            id = ++CommandQueue.total;

            myReturn = new ReturnCommand();
            myReturn.myCommand = this;
            if (firstName != null) {
                name = firstName;
            }

            if (repeat && !isCopy) {
                CommandQueue.savedCommandList.Add(this);
            } else {
                CommandQueue.queueList.Add(this);
            }
        }

        public void Finish() {
            sent = true;
        }

        public bool CheckInvalid() {
            if (content == null || content.Length < 3) {
                return true;
            }
            return false;
        }

    }


}
