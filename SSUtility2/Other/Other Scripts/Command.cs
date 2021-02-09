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
            SendTimer.Interval = 500;
            SendTimer.Tick += new EventHandler(SendCurrentCommand);
            SendTimer.Start();
        }

        private static void SendCurrentCommand(object sender, EventArgs e) {  //too many commands overload
            try {
                Console.WriteLine("QUEUE: " + queueList.Count.ToString() + " LOWPRIORITY: " + lowPriority.ToString());
                if (!AsyncCameraCommunicate.sock.Connected) {
                    return;
                }

                if (queueList.Count > 0) { //first command broken
                    lowPriority = false;

                    Command com = queueList[0];

                    if (!com.invalid && !com.sent && com != null) {
                        AsyncCameraCommunicate.currentCom = com;
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

                if (com.repeatable)
                    com.myReturn.done = false;

                int i = 0;
                while (i < 4) {
                    AsyncCameraCommunicate.SendCurrent();
                    await Task.Delay(700);
                    if (com.myReturn.done) {
                        break;
                    }
                    i++;
                }

                if (!com.myReturn.done) {
                    MainForm.m.WriteToResponses("Failed to get response", false, true);
                } else {
                    MainForm.m.WriteToResponses("Received: " + com.myReturn.msg, false);
                }

                queueList.Remove(queueList[0]);
                
                
                SendTimer.Start();
            } catch (Exception e) {
                MainForm.ShowPopup("Failed to process message return!\nShow more?", "Response Failed!", e.ToString());
            }
        }

        public static Command GetCurCommand() {
            return queueList[0];
        }

        public static void QueueCommand(Command com) {
            if (!com.invalid) {
                queueList.Add(com);
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
        public bool invalid;
        public bool done;

        public void UpdateReturnMsg(string content) {
            if (content == CameraCommunicate.defaultResult || content.Length == 0) {
                invalid = true;
            }
            msg = content;
            done = true;
        }

    }

    public class Command {

        public int id;
        public byte[] content;
        public bool invalid;
        public bool repeatable;

        public bool sent;

        public ReturnCommand myReturn;

        public Command(byte[] code, bool repeat = false, bool isCopy = false) {
            if (code == null || code.Length == 0) {
                invalid = true;
            }
            content = code;
            repeatable = repeat;

            id = ++CommandQueue.total;

            myReturn = new ReturnCommand();

            if (repeat && !isCopy) {
                CommandQueue.savedCommandList.Add(this);
            } else {
                CommandQueue.queueList.Add(this);
            }
        }

        public void Finish() {
            sent = true;
        }

    }


}
