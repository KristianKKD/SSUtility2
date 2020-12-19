using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    public class CommandQueue {

        public static List<Command> queueList { 
            get;
        }
        public static List<ReturnCommand> returnList {
            get;
        }
        public static int header {
            get; set;
        }

        public static Command GetCurCommand() {
            return queueList[header];
        }

        public static void QueueCommand(Command com) {
            if (!com.invalid) {
                queueList.Add(com);
            }
        }

        public static ReturnCommand GetReturnMsg(int id) {
            for (int i = 0; i < returnList.Count; i++) {
                if (id == returnList[i].id) {
                    return returnList[i];
                }
            }
            return null;
        }

        public static void MoveHeaderToCommand(Command com) {
            int prevHeader = header;
            for (int i = 0; i < queueList.Count; i++) {
                if (queueList[i] == com) {
                    header = i;
                    break;
                }
            }
            if (prevHeader == header) {
                MainForm.ShowError("Failed to find command in command queue!", "Command Search Failed!",
                    com.id.ToString() + "Couldn't be found in queue list!", true);
            }
        }
    }

    public class ReturnCommand {
        public int id;
        public string msg;
        public bool invalid;

        public ReturnCommand(int commandId, string content) {
            if (content == CameraCommunicate.defaultResult || content.Length == 0) {
                invalid = true;
            }
            if (commandId == -1) {
                id = CommandQueue.header;
            } else {
                id = commandId;
            }
            msg = content;
        }

    }

    public class Command {

        public int id;
        public byte[] content;
        public bool invalid;
        public bool sent;

        public Command(byte[] code) {
            if (code == null || code.Length == 0) {
                invalid = true;
            }
            content = code;
            id = CommandQueue.queueList.Count;
            CommandQueue.queueList.Add(this);
        }

    }


}
