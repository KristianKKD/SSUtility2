using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class CommandQueue {

        public static List<Command> savedCommandList;
        public static List<Command> queueList;
        public static List<Command> oldList; //need to add response log handling for this

        public static int total = 0;

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
            SendTimer.Interval = ConfigControl.commandRateMs.intVal;
            SendTimer.Tick += new EventHandler(SendCurrentCommand);
            SendTimer.Start();
        }

        public static void UpdateTimerRate() {
            SendTimer.Interval = ConfigControl.commandRateMs.intVal;
        }

        private static void SendCurrentCommand(object sender, EventArgs e) {
            try {
                if (MainForm.m.mainCp != null) {
                    MainForm.m.mainCp.Tick();
                }
                //Console.WriteLine("QUEUE: " + queueList.Count.ToString() + " LOWPRIORITY: " + lowPriority.ToString());
                if (!AsyncCamCom.sock.Connected) {
                    return;
                }

                if (queueList.Count > 0) {
                    Command com = queueList[0];

                    if (!com.invalid && !com.sent && com != null) {
                        AsyncCamCom.currentCom = com;
                        WaitForCommandResponse(com).ConfigureAwait(false);
                    } else {
                        queueList.RemoveAt(0);
                    }
                } else {
                    InfoPanel.i.InfoPanelTick();
                }
            } catch (Exception err){
                MessageBox.Show("Error in queuelist.\n" + err.ToString());
            }
        }

        public static async Task<bool> WaitForCommandDone(Command com) {
            for (int i = 0; i < commandRetries; i++) {
                if (!com.done) {
                    await Task.Delay(ConfigControl.commandRateMs.intVal).ConfigureAwait(false);
                } else {
                    return true;

                }
            }
            return false;
        }

        static async Task WaitForCommandResponse(Command com) {
            try {
                SendTimer.Stop();

                if (com.isInfo)
                    com.done = false;

                int i = 0;
                while (i < commandRetries) {
                    bool repeated = false;
                    if (i > 0)
                        repeated = true;

                    AsyncCamCom.SendCurrent(repeated);
                    if (!com.spammable && !com.isInfo) {
                        break;
                    }
                    
                    if (com.done) {
                        break;
                    } else {
                        await Task.Delay(ConfigControl.commandRateMs.intVal);
                    }
                    i++;
                }
                if(i > 1)
                    MainForm.m.WriteToResponses("Sent command " + i + " times!", true, false);


                if (!com.done) {
                    MainForm.m.WriteToResponses(GetNameString() + "No response!", false, true);
                } else {
                    if (com.isInfo) {
                        MainForm.m.WriteToResponses(GetNameString() + "Received: " + com.myReturn.msg, true, true);
                    } else {
                        MainForm.m.WriteToResponses(GetNameString() + "Received: " + com.myReturn.msg, false);
                    }
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
