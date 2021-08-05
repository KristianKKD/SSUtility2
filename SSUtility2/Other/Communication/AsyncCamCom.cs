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

        public static Command currentCom;

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
            VideoSettings.UpdateControlFields();
            return result;
        }

        public static void SendNonAsync(byte[] code) {
            if (!sock.Connected) {
                MessageBox.Show("Not connected!");
                return;
            }

            MainForm.m.WriteToResponses("Non-async command sent: " + Tools.ReadCommand(code), true, false);
            sock.SendTo(code, sock.RemoteEndPoint);
            CommandQueue.totalCommands++;
        }

        public static Command SendScriptCommand(ScriptCommand com) {
            Command sendCommand = new Command(com.codeContent, false, false, com.isQuery, com.names[0]);
            return sendCommand;
        }

        public static Command SendNewCommand(byte[] code, bool spammable = false) {
            Command com = new Command(code, false, false, spammable, null);

            if (com.invalid) {
                MainForm.m.WriteToResponses("Failed to create " + Tools.ReadCommand(code), true);
                return null;
            }
            return com;
        }

        public async static Task<string> QueryNewCommand(ScriptCommand com) {
            Command sendCommand = new Command(com.codeContent, false, false, com.isQuery, com.names[0]);
            return await WaitForResponse(sendCommand);
        }

        public static async Task<string> QueueRepeatingCommand(int id) {
            try {
                Command oldCom = CommandQueue.FindCommandByID(id);
                Command com = new Command(oldCom.content, true, true, true, oldCom.name);
                return await WaitForResponse(com);
            } catch (Exception e) {
                Tools.ShowPopup("Failed to queue a repeating command!\nShow more?", "Command Queuing Failed!", e.ToString());
            }

            return OtherCamCom.defaultResult;
        }

        private static async Task<string> WaitForResponse(Command sendCommand) {
            if (!sendCommand.invalid) {
                await CommandQueue.WaitForCommandDone(sendCommand);

                if (!ReturnCommand.CheckInvalid(sendCommand.myReturn.msg)) {
                    return sendCommand.myReturn.msg;
                }
            }

            return OtherCamCom.defaultResult;
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

                OtherCamCom.CheckIsSameSubnet(ep.Address.ToString());

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
                receiveBuffer = new byte[14];
                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
                InfoPanel.i.CheckForCamera();
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                Tools.ShowPopup("Connect callback failed!\nIP likely does not belong to a camera!\nShow more?", "Connect Failed!", e.ToString());
                Disconnect();
            }
        }

        public static void Disconnect(bool showErrors = true) {
            try {
                if (sock == null || !MainForm.m.finishedLoading)
                    return;

                string oldAdr = null;
                try {
                    if(sock.RemoteEndPoint != null)
                        oldAdr = sock.RemoteEndPoint.ToString();
                } catch (Exception e) { }

                OtherCamCom.LabelDisplay(false);

                if (!ConfigControl.forceCamera.boolVal)
                    InfoPanel.i.isCamera = false;
                if (!sock.Connected)
                    return;
                sock.Shutdown(SocketShutdown.Both);
                if (oldAdr != null)
                    MainForm.m.WriteToResponses("Disconnected from: " + oldAdr, true);

                Console.WriteLine("disconnected");
            } catch (Exception e){
                if (showErrors)
                    Tools.ShowPopup("Disconnect error occurred!\nShow more?", "Error Occurred!", e.ToString());
            }
        }


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
                    CommandQueue.totalCommands++;
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
                        if (hex != null && hex.Length == 1) {
                            hex = "0" + hex;
                        }
                        msg += hex + " ";
                        comCount--;
                    } else {
                        break;
                    }
                }

                string oldMsg = msg;
                msg = Tools.ValidateResponse(msg);

                if (msg != null) {
                    if (currentCom == null) {
                        MainForm.m.WriteToResponses("(Listening) Received: " + msg, true, false);
                        return;
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
                        MainForm.m.WriteToResponses("(Listening) Received CORRUPTED message: " + oldMsg, true, true);
                    } else {
                        MainForm.m.WriteToResponses(CommandQueue.GetNameString() + "Received CORRUPTED response: " + oldMsg, true, true);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                MainForm.m.WriteToResponses(CommandQueue.GetNameString() + "Message processing failed!\n" + e.ToString(), true, true);
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
