using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class AsyncCamCom {

        public static Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static byte[] receiveBuffer;

        public static async Task<bool> TryConnect(bool hideErrors = false, IPEndPoint customep = null) {
            bool result = true;
            try {
                if (!sock.Connected) {
                    if (ConfigControl.savedIP.stringVal.Length == 0 ||
                        ConfigControl.savedPort.stringVal.Length == 0) {

                        result = false;
                    }

                    IPEndPoint ep;
                    if (customep == null) {
                        ep = new IPEndPoint(IPAddress.Parse(ConfigControl.savedIP.stringVal),
                            int.Parse(ConfigControl.savedPort.stringVal));
                    } else {
                        ep = customep;
                    }
                     

                    if (result) {
                        result = Connect(ep, hideErrors);
                    }

                }
            } catch (Exception e){
                if (!hideErrors)
                    Tools.ShowPopup("Failed to initialize connection to camera!\nShow more?", "Connection Attempt Failed!"
                        , e.ToString());
                result = false;
            }
            OtherCamCom.LabelDisplay(result);
            return result;
        }

        public static void SendNonAsync(byte[] code) {
            if (!TryConnect().Result) {
                return;
            }
            MainForm.m.WriteToResponses(Tools.ReadCommand(code), true, false);
            sock.SendTo(code, sock.RemoteEndPoint);
        }

        public static Command SendScriptCommand(ScriptCommand com) {
            Command sendCommand = new Command(com.codeContent, false, false, com.spammable, com.names[0]);
            return sendCommand;
        }

        public static Command SendNewCommand(byte[] code, bool spammable = false) {
            Command com = new Command(code, false, false, spammable, null);

            if (com.invalid) {
                MainForm.m.WriteToResponses("Failed to send " + Tools.ReadCommand(code), true);
                return null;
            }
            return com;
        }

        public async static Task<string> QueryNewCommand(byte[] send) {
            Command com = SendNewCommand(send, true);
            string result = await CheckCommandResult(com).ConfigureAwait(false);
            return result;
        }

        private static async Task<string> CheckCommandResult(Command oldCom) { //have timer check if queued result and if it is send it back
            await CommandQueue.WaitForCommandDone(oldCom).ConfigureAwait(false);

            if (oldCom != null) {
                if (!ReturnCommand.CheckInvalid(oldCom.myReturn.msg)) {
                    return oldCom.myReturn.msg;
                }
            }
            return OtherCamCom.defaultResult;
        }

        public static void QueueRepeatingCommand(int id) {
            try {
                Command oldCom = CommandQueue.FindCommandByID(id);
                if (oldCom != null) {
                    Command com = new Command(oldCom.content, true, true, true, oldCom.name);
                }
            } catch (Exception e) {
                Tools.ShowPopup("Failed to queue a repeating command!\nShow more?", "Command Queuing Failed!", e.ToString());
            }
        }

        private static bool Connect(IPEndPoint ep, bool hideErrors = false) {
            try {
                if (sock == null)
                    return false;
                else if (sock.Connected && ep == sock.RemoteEndPoint as IPEndPoint)
                    return true;
                else
                    Disconnect();

                if(!MainForm.m.lite)
                    MainForm.m.mainPlayer.DisableSecond();
                if(!ConfigControl.forceCamera.boolVal)
                    InfoPanel.i.isCamera = false;

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                bool parsedIP = IPAddress.TryParse(ConfigControl.savedIP.stringVal, out IPAddress ip);
                bool parsedPort = int.TryParse(ConfigControl.savedPort.stringVal, out int port);
                if (!parsedIP || !parsedPort) {
                    if (!hideErrors)
                        Tools.ShowPopup("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "IP valid: " + parsedIP.ToString() + "\nPort valid: " + parsedPort.ToString());
                    return false;
                }

                if (!OtherCamCom.PingAdr(ep.Address).Result) {
                    if (!hideErrors)
                        Tools.ShowPopup("Failed to ping IP address!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "IP valid: " + parsedIP.ToString() + "\nPort valid: " + parsedPort.ToString() + "\nPing: Failed");
                    return false;
                }

                IPEndPoint end = new IPEndPoint(ip, port);

                if (end == null) {
                    return false;
                }

                if (!hideErrors && !ConfigControl.subnetNotif.boolVal) {
                    if (!OtherCamCom.CheckIsSameSubnet(ep.Address.ToString())) {
                        return false;
                    }
                }

                connecting = sock.BeginConnect(end, ConnectCallback, null);

                MainForm.m.WriteToResponses("Successfully connected to: " + end.Address.ToString() + ":" + end.Port.ToString(), true);
                return true;
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                if (!hideErrors)
                    MessageBox.Show("An error occured whilst connecting to camera!\n" + e.ToString());
            }
            return false;
        }

        static IAsyncResult connecting = null;

        private static void ConnectCallback(IAsyncResult AR) {
            try {
                if (AR == connecting)
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
                Tools.ShowPopup("Connect callback failed!\nIP likely does not belong to a camera!\nShow more?", "Connect Failed!", e.ToString());
            }
        }

        public static void Disconnect(bool hideErrors = false) {
            try {
                if (sock == null)
                    return;

                InfoPanel.i.isCamera = false;
                if (!sock.Connected)
                    return;
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            } catch (Exception e){
                if (!hideErrors)
                    Tools.ShowPopup("Disconnection error occurred!", "Error Occurred!", e.ToString());
            }
        }

        public static Command currentCom;

        public static void SendCurrent(bool repeatedCommand) {
            try {
                if (!repeatedCommand) {
                    TryConnect();
                    Console.WriteLine("\nSending new command");
                    if (currentCom == null) {
                        MessageBox.Show("Send command returned null!");
                        return;
                    }
                    string commandText = Tools.ReadCommand(currentCom.content);
                    if (currentCom.name != null) {
                        commandText = commandText + " (" + currentCom.name + ")";
                    }
                    MainForm.m.WriteToResponses("Sending: " + commandText, true, currentCom.isInfo);
                }
                sock.BeginSend(currentCom.content, 0, currentCom.content.Length, SocketFlags.None, SendCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                Tools.ShowPopup("Failed to send queued command!\nShow more?", "Send Failed!", e.ToString());
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
                Tools.ShowPopup("Send callback failed!\nShow more?", "Send Failed!", e.ToString());
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
                Tools.ShowPopup("Receive callback failed!\nShow more?", "Receive Failed!", e.ToString());
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

                if (msg.Length > 0 && msg.StartsWith("F")) {
                    if (currentCom == null) {
                        MainForm.m.WriteToResponses("(Listening) Received: " + msg, true, false);
                        return;
                    }

                    if (currentCom.isInfo) {
                        InfoPanel.ReadResult(msg);
                    }

                    CommandQueue.oldList.Add(currentCom);

                    if (currentCom.myReturn != null) {
                        currentCom.myReturn.UpdateReturnMsg(msg);
                        currentCom.Finish();
                        //Response written to command to avoid spam
                    } else {
                        MainForm.m.WriteToResponses(CommandQueue.GetNameString() + "Received response but send command is corrupt!", true, currentCom.isInfo);
                    }

                } else {
                    if (MainForm.m == null)
                        return;

                    if (currentCom == null) {
                        MainForm.m.WriteToResponses("(Listening) Received CORRUPTED message: " + msg, true, currentCom.isInfo);
                    } else {
                        MainForm.m.WriteToResponses(CommandQueue.GetNameString() + "Received CORRUPTED response: " + msg, true, currentCom.isInfo);
                    }
                }
            } catch (Exception e) {
                Tools.ShowPopup(CommandQueue.GetNameString() + "Message processing failed!\nShow more?", "Receive Failed!", e.ToString());
            };
        }

        public static string GetSockEndpoint() {
            if (sock == null)
                return "";
            if (!sock.Connected)
                return "";
            return sock.RemoteEndPoint.ToString();
        }

    }
}
