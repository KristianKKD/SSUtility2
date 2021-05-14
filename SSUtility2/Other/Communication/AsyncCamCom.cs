using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class AsyncCamCom {

        public static Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static byte[] receiveBuffer;
        static bool connectingAlready = false;

        public static async Task<bool> TryConnect(bool showErrors = false, IPEndPoint customep = null,
            bool noPlayerReplay = false) {
            bool result = true;
            try {
                if (connectingAlready)
                    return false;

                connectingAlready = true;
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
                    result = Connect(ep, showErrors, noPlayerReplay);
                }

            } catch (Exception e){
                if (showErrors)
                    Tools.ShowPopup("Failed to initialize connection to camera!\nShow more?", "Connection Attempt Failed!"
                        , e.ToString());
                Console.WriteLine(e.ToString());

                result = false;
            }

            connectingAlready = false;
            OtherCamCom.LabelDisplay(result);
            return result;
        }

        public static void SendNonAsync(byte[] code) {
            if (!sock.Connected) {
                MessageBox.Show("Not connected!");
                return;
            }

            MainForm.m.WriteToResponses("Non-async command sent: " + Tools.ReadCommand(code), true, false);
            sock.SendTo(code, sock.RemoteEndPoint);
        }

        public static Command SendScriptCommand(ScriptCommand com) {
            Command sendCommand = new Command(com.codeContent, false, false, com.isQuery, com.names[0]);
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

        private static bool Connect(IPEndPoint ep, bool showErrors, bool isPlayer) {
            try {
                if (sock == null || ep == null || ep.Address == null || ep.Port == 0 || ep.Address.ToString().Length == 0) {
                    return false;
                } else if (sock.Connected && ep.ToString() == sock.RemoteEndPoint.ToString()) {
                    return true;
                } else if (sock.Connected && ep.ToString() != sock.RemoteEndPoint.ToString()) {
                    Console.WriteLine("trying to disconnect " + sock.RemoteEndPoint.ToString() + "\n" + ep.ToString());
                    Disconnect(true);
                }

                Console.WriteLine("trying to connect to " + ep.Address.ToString() + ":" + ep.Port.ToString());

                if (!ConfigControl.forceCamera.boolVal)
                    InfoPanel.i.isCamera = false;

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                bool parsedIP = IPAddress.TryParse(ep.Address.ToString(), out IPAddress ip);
                bool parsedPort = int.TryParse(ep.Port.ToString(), out int port);
                
                string errorMessage = "IP (" + ep.Address.ToString() + ") valid: " + parsedIP.ToString() + "\nPort (" + ep.Port.ToString()
                                        + ") valid: " + parsedPort.ToString();

                if (!parsedIP || !parsedPort) {
                    if (showErrors)
                        Tools.ShowPopup("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        errorMessage);
                    return false;
                }

                if (!OtherCamCom.PingAdr(ep.Address.ToString()).Result) {
                    if (showErrors)
                        Tools.ShowPopup("Failed to ping IP address!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        errorMessage + "\nPing: Failed");
                    return false;
                }

                IPEndPoint end = new IPEndPoint(ip, port);

                if (end == null) {
                    return false;
                }

                if (showErrors && !ConfigControl.subnetNotif.boolVal) {
                    if (!OtherCamCom.CheckIsSameSubnet(ep.Address.ToString())) {
                        return false;
                    }
                }

                if (ConfigControl.autoReconnect.boolVal && !isPlayer) {
                    MainForm.m.mainPlayer.settings.tB_PlayerD_Adr.Text = ip.ToString();
                    MainForm.m.mainPlayer.Play(false);
                }

                connecting = sock.BeginConnect(end, ConnectCallback, null);

                MainForm.m.WriteToResponses("Successfully connected to: " + end.Address.ToString() + ":" + end.Port.ToString(), true);
                return true;
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                if (showErrors)
                    MessageBox.Show("An error occured whilst connecting to camera!\n" + e.ToString());
                Console.WriteLine("CONNECT\n" + e.ToString());
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
                //Tools.ShowPopup("Connect callback failed!\nIP likely does not belong to a camera!\nShow more?", "Connect Failed!", e.ToString());
                //Disconnect();
            }
        }

        public static void Disconnect(bool showErrors = true) {
            try {
                if (sock == null || !MainForm.m.finishedLoading)
                    return;

                string oldAdr = null;
                try {
                    oldAdr = sock.RemoteEndPoint.ToString();
                } catch { }

                OtherCamCom.LabelDisplay(false);

                if (!ConfigControl.forceCamera.boolVal)
                    InfoPanel.i.isCamera = false;
                if (!sock.Connected)
                    return;
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();

                if (oldAdr != null)
                    MainForm.m.WriteToResponses("Disconnected from: " + oldAdr, true);

                Console.WriteLine("disconnected");
            } catch (Exception e){
                if (showErrors)
                    Tools.ShowPopup("Disconnect error occurred!\nShow more?", "Error Occurred!", e.ToString());
            }
        }

        public static Command currentCom;

        public static void SendCurrent(bool repeatedCommand) {
            try {
                if (!repeatedCommand) {
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
            } catch (ArgumentException ex) {
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
                //Tools.ShowPopup(CommandQueue.GetNameString() + "Message processing failed!\nShow more?", "Receive Failed!", e.ToString());
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
