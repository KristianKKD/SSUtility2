using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class CommandQueue {

        public static List<Command> queueList;
        public static int header;
        public static int total;

        public static bool lowPriority;

        public static void Init() {
            queueList = new List<Command>();
            header = 1;
            total = 0;

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

                if (queueList.Count >= header && queueList.Count > 0) {
                    lowPriority = false;

                    Command com = queueList[header - 1];
                    if (!com.invalid && !com.sent && !com.repeatable) {
                        AsyncCameraCommunicate.SendCurrent();
                    } else {
                        MoveHeaderNext();
                    }
                } else {
                    lowPriority = true;
                }
            } catch { }
        }

        public static void MoveHeaderNext() { // make a way so it doesnt move when waiting for a command to finish
            header++;
        }

        public static Command GetCurCommand() {
            return queueList[header - 1];
        }

        public static void QueueCommand(Command com) {
            if (!com.invalid) {
                queueList.Add(com);
            }
        }

        public static Command FindCommandByID(int id) {
            for (int i = 0; i < queueList.Count; i++) {
                if (id == queueList[i].id) {
                    return queueList[i];
                }
            }
            return null;
        }

        public static void MoveHeaderToCommand(Command com) {
            int prevHeader = header;
            for (int i = 0; i < queueList.Count; i++) {
                if (com == queueList[i]) {
                    header = i;
                    break;
                }
            }
            if (prevHeader == header) {
                MainForm.ShowPopup("Failed to find command in command queue!", "Command Search Failed!",
                    com.id.ToString() + "Couldn't be found in queue list!", true);
            }
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

        public Command(byte[] code, bool repeat = false) {
            if (code == null || code.Length == 0) {
                invalid = true;
            }
            content = code;
            repeatable = repeat;

            CommandQueue.total++;
            id = CommandQueue.total;
            
            myReturn = new ReturnCommand();

            CommandQueue.queueList.Add(this);
        }

        public void Finish() {
            if (!repeatable) {
                sent = true;
            }
        }

    }


}
