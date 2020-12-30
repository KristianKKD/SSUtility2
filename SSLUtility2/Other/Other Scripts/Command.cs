﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    public class CommandQueue {



        public static List<Command> queueList;
        public static List<ReturnCommand> returnList;
        public static int header;
        public static int total;

        public static void Init() {
            queueList = new List<Command>();
            returnList = new List<ReturnCommand>();
            header = 0;
            total = 0;
        }

        public static Command GetCurCommand() {
            return queueList[header - 1];
        }

        public static ReturnCommand GetCurReturn() {
            return returnList[header - 1];
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
        public static ReturnCommand FindReturnByID(int id) {
            for (int i = 0; i < returnList.Count; i++) {
                if (id == returnList[i].comID) {
                    return returnList[i];
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
                MainForm.ShowError("Failed to find command in command queue!", "Command Search Failed!",
                    com.id.ToString() + "Couldn't be found in queue list!", true);
            }
        }
    }

    public class ReturnCommand {
        public int comID;
        public string msg;
        public bool invalid;
        public bool done;

        public ReturnCommand(int id) {
            comID = id;
        }

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
        public bool sent;

        public Command(byte[] code) {
            if (code == null || code.Length == 0) {
                invalid = true;
            }
            content = code;
            CommandQueue.total++;
            id = CommandQueue.total;
            ReturnCommand com = new ReturnCommand(id);

            CommandQueue.returnList.Add(com);
            CommandQueue.queueList.Add(this);
        }

    }


}