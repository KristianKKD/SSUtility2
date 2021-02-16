using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SSUtility2 {
    public class AsyncCameraCommunicate {
        public static Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public const string defaultResult = "00 00 00 00 00 00 00";
        static byte[] receiveBuffer;

        public static async Task<bool> TryConnect(IPEndPoint ep = null, bool hideErrors = false) {
            if (!sock.Connected) {
                if (ep == null) {
                    if (MainForm.m.ipCon.tB_IPCon_Adr.Text.Length == 0 || MainForm.m.ipCon.tB_IPCon_Port.Text.Length == 0) {
                        return false;
                    }
                    ep = new IPEndPoint(IPAddress.Parse(MainForm.m.ipCon.tB_IPCon_Adr.Text), int.Parse(MainForm.m.ipCon.tB_IPCon_Port.Text));
                }
                Connect(ep, hideErrors);
                await Task.Delay(500).ConfigureAwait(false);
                if (!sock.Connected)
                    return false;
            }
            return true;
        }

        public static Command SendScriptCommand(ScriptCommand com) {
            Command sendCommand = new Command(com.codeContent, false, false, com.spammable);
            MainForm.m.WriteToResponses("Sending: " + MainForm.m.ReadCommand(com.codeContent, true) + " (" + com.names[0] + ")", true);
            return sendCommand;
        }

        public static Command SendNewCommand(byte[] code, bool spammable = false) {
            Command com = new Command(code, false, false, spammable);

            if (com.invalid) {
                MainForm.m.WriteToResponses("Failed to send " + MainForm.m.ReadCommand(code), true);
                return null;
            }
            return com;
        }

        public async static Task<string> QueryNewCommand(byte[] send) {
            Command com = SendNewCommand(send, false);
            string result = CheckCommandResult(com).Result;
            return result;
        }

        public static async Task<string> CheckCommandResult(Command oldCom) {
            if (oldCom != null) {
                //if (!ReturnCommand.CheckInvalid(oldCom.myReturn.msg)) { //need to have this wait for the result and make sure it's not invalid
                    return oldCom.myReturn.msg;
                //}
            }
            return defaultResult;
        }

        public static void QueueRepeatingCommand(int id) {
            Command oldCom = CommandQueue.FindCommandByID(id);
            if (oldCom != null) {
                Command com = new Command(oldCom.content, true, true);
            }
        }

        public static void Connect(IPEndPoint ep, bool hideErrors = false) {
            try {
                if (sock == null || (sock.Connected && ep == sock.RemoteEndPoint as IPEndPoint)) {
                    return;
                } else {
                    Disconnect();
                }

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                bool parsedIP = IPAddress.TryParse(MainForm.m.ipCon.tB_IPCon_Adr.Text, out IPAddress ip);
                bool parsedPort = int.TryParse(MainForm.m.ipCon.tB_IPCon_Port.Text, out int port);
                if (!parsedIP || !parsedPort) {
                    if (!hideErrors)
                        MainForm.ShowPopup("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return;
                }

                if (!OtherCameraCommunication.PingAdr(ep.Address).Result) {
                    if (!hideErrors)
                        MainForm.ShowPopup("Failed to ping IP address!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString() + "\nPing: Failed");
                    return;
                }

                IPEndPoint end = new IPEndPoint(ip, port);

                if (end == null) {
                    return;
                }

                sock.BeginConnect(end, ConnectCallback, null);

                MainForm.m.WriteToResponses("Successfully connected to: " + end.Address.ToString() + ":" + end.Port.ToString(), true);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                if (!hideErrors)
                    MessageBox.Show("An error occured whilst connecting to camera!\n" + e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult AR) {
            try {
                sock.EndConnect(AR);
                if (!sock.Connected)
                    return;
                receiveBuffer = new byte[sock.ReceiveBufferSize];
                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MainForm.ShowPopup("Connect callback failed!\nIP likely does not belong to a camera!\nShow more?", "Connect Failed!", e.ToString());
            }
        }

        public static void Disconnect() {
            try {
                if (sock == null)
                    return;
                if (!sock.Connected)
                    return;
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            } catch { }
        }

        public static Command currentCom;

        public static void SendCurrent() {
            try {
                if (!sock.Connected) {
                    Connect(null);
                }
                Console.WriteLine("\nSending new command");
                if (currentCom == null) {
                    MessageBox.Show("Send command returned null!");
                    return;
                }

                sock.BeginSend(currentCom.content, 0, currentCom.content.Length, SocketFlags.None, SendCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MainForm.ShowPopup("Failed to send queued command!\nShow more?", "Send Failed!", e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult AR) {
            try {
                sock.EndSend(AR);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MainForm.ShowPopup("Send callback failed!\nShow more?", "Send Failed!", e.ToString());
            }
        }

        private static async void ReceiveCallback(IAsyncResult AR) { //why is this inconsistent?
            try {
                if (receiveBuffer.Length < 7) {
                    return;
                }

                int received = sock.EndReceive(AR);
                if (received > 0) {
                    await SaveResponse();
                }

                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MainForm.ShowPopup("Receive callback failed!\nShow more?", "Receive Failed!", e.ToString());
            }
        }

        static async Task SaveResponse() {
            try {
                string msg = "";
                int comCount = 0;
                bool startedCom = false;

                for (int i = 0; i < receiveBuffer.Length; i++) {
                    string hex = receiveBuffer[i].ToString("X").ToUpper();

                    if (hex != "0" && !startedCom) {
                        comCount = 7;
                        startedCom = true;
                    }

                    if (comCount > 0) {
                        if (hex.Length == 1) {
                            hex = "0" + hex;
                        }
                        msg += hex + " ";
                        comCount--;
                    } else {
                        break;
                    }
                }

                msg = msg.Trim();

                if (msg.Length > 0) {
                    if (currentCom.repeatable) {
                        InfoPanel.ReadResult(msg);
                    }

                    if (currentCom == null) {
                        return;
                    }

                    CommandQueue.oldList.Add(currentCom);

                    if (currentCom.myReturn != null) {
                        currentCom.myReturn.UpdateReturnMsg(msg);
                        currentCom.Finish();
                        //Response written to command to avoid spam
                    } else {
                        MainForm.m.WriteToResponses("Received response but send command is corrupt!", true, currentCom.repeatable);
                    }

                } else {
                    MainForm.m.WriteToResponses("Received corrupted response", true, currentCom.repeatable);
                }
            } catch (Exception e) {
                MainForm.ShowPopup("Message processing failed!\nShow more?", "Receive Failed!", e.ToString());
            };
        }

        public static string GetSockEndpoint() {
            return sock.RemoteEndPoint.ToString();
        }

    }
}
