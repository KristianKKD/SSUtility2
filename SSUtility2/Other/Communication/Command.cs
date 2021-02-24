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

        public static bool lowPriority;

        public static void Init() {
            savedCommandList = new List<Command>();
            queueList = new List<Command>();
            oldList = new List<Command>();

            StartTimer();
        }

        static Timer SendTimer;

        public static void StartTimer() {
            SendTimer = new Timer();
            SendTimer.Interval = 400;
            SendTimer.Tick += new EventHandler(SendCurrentCommand);
            SendTimer.Start();
        }

        private static void SendCurrentCommand(object sender, EventArgs e) {  //too many commands overload
            try {
                //Console.WriteLine("QUEUE: " + queueList.Count.ToString() + " LOWPRIORITY: " + lowPriority.ToString());
                if (!AsyncCamCom.sock.Connected) {
                    return;
                }

                if (queueList.Count > 0) { //first command broken
                    lowPriority = false;

                    Command com = queueList[0];

                    if (!com.invalid && !com.sent && com != null) {
                        AsyncCamCom.currentCom = com;
                        WaitForCommandResponse(com).ConfigureAwait(false);
                    } else {
                        queueList.RemoveAt(0);
                    }
                } else {
                    lowPriority = true;
                }
            } catch (Exception err){
                MessageBox.Show("Error in queuelist.\n" + err.ToString());
            }
        }

        static async Task WaitForCommandResponse(Command com) {
            try {
                SendTimer.Stop();

                if (com.isInfo)
                    com.done = false;

                int i = 0;
                while (i < 5) {
                    bool repeated = false;
                    if (i > 0)
                        repeated = true;

                    AsyncCamCom.SendCurrent(repeated);
                    if (!com.spammable && !com.isInfo) {
                        break;
                    }
                    
                    await Task.Delay(600);
                    if (com.done) {
                        break;
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
                MainForm.ShowPopup("Failed to process message return!\nShow more?", "Response Failed!", e.ToString());
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
