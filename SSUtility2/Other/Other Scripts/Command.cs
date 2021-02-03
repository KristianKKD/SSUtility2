using System;
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

        public static int total = 0;

        public static bool lowPriority;

        public static void Init() {
            savedCommandList = new List<Command>();
            queueList = new List<Command>();

            StartTimer();
        }

        static Timer SendTimer;
        public static void StartTimer() {
            SendTimer = new Timer();
            SendTimer.Interval = 300;
            SendTimer.Tick += new EventHandler(SendCurrentCommand);
            SendTimer.Start();
        }

        private static void SendCurrentCommand(object sender, EventArgs e) {
            try {
                //Console.WriteLine("QUEUE: " + queueList.Count.ToString() + " HEADER: " + header.ToString());

                if (queueList.Count > 0) {
                    lowPriority = false;

                    Command com = queueList[0];
                    if (!com.invalid && !com.sent && !com.repeatable) {
                        var result = WaitForCommandResponse(com).Result;
                    }
                } else {
                    lowPriority = true;
                }
            } catch (Exception err){
                MessageBox.Show("Error in queuelist.\n" + err.ToString());
            }
        }

        static async Task<bool> WaitForCommandResponse(Command com) {
            bool done = false;
            //int i = 0;
            //while (i < 3 && !com.myReturn.done) {
            AsyncCameraCommunicate.SendCurrent();
            //await Task.Delay(1000);

            //MessageBox.Show(i.ToString());
            //if (com.myReturn.done) {
            //    done = true;
            //    //break;
            //}
            ////    //await Task.Delay(1000);
            ////    i++;
            ////}

            //if (!done) {
            //    MainForm.m.WriteToResponses("Failed to get response", false, false);
            //}
            queueList.RemoveAt(0);

            return done;
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

        //public static void MoveHeaderToCommand(Command com) {
        //    int prevCount = header;
        //    for (int i = 0; i < queueList.Count; i++) {
        //        if (com == queueList[i]) {
        //            header = i;
        //            break;
        //        }
        //    }
        //    if (prevCount == header) {
        //        MainForm.ShowPopup("Failed to find command in command queue!", "Command Search Failed!",
        //            com.id.ToString() + "Couldn't be found in queue list!", true);
        //    }
        //}
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

        public Command(byte[] code, bool repeat = false) {
            if (code == null || code.Length == 0) {
                invalid = true;
            }
            content = code;
            repeatable = repeat;

            id = ++CommandQueue.total;

            myReturn = new ReturnCommand();

            if (repeat) {
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
