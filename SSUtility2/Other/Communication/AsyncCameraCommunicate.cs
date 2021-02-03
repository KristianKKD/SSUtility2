using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class AsyncCameraCommunicate {
        public static Socket sock;
        public const string defaultResult = "00 00 00 00 00 00 00";
        static byte[] receiveBuffer;

        public static int SendNewCommand(byte[] code) {
            Command com = new Command(code);
            if (com.invalid) {
                MainForm.m.WriteToResponses("Failed to send " + MainForm.m.ReadCommand(code), true);
                //do something
                return -1;
            }
            return com.id;
        }

        public static void QueueRepeatingCommand(int id) {
            Command oldCom = CommandQueue.FindCommandByID(id);
            if (oldCom != null) {
                Command com = new Command(oldCom.content);
            }
            //return response
        }

        public static void Connect(IPEndPoint ep) {
            try {
                if (sock != null) {
                    if (sock.Connected) {
                        //Disconnect(); //need to be able to reconnect with new ip
                        return;
                    }
                }

                bool parsedIP = IPAddress.TryParse(MainForm.m.ipCon.tB_IPCon_Adr.Text, out IPAddress ip);
                bool parsedPort = int.TryParse(MainForm.m.ipCon.tB_IPCon_Port.Text, out int port);
                if (ep == null && (!parsedIP || !parsedPort)) {
                    MainForm.ShowPopup("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return;
                }

                if (!OtherCameraCommunication.PingAdr(ep.Address).Result) {
                    MainForm.ShowPopup("Failed to ping IP address!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return;
                }
                
                ep = new IPEndPoint(ip, port);

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.BeginConnect(ep, ConnectCallback, null);

                MainForm.m.WriteToResponses("Successfully connected to: " + ep.Address.ToString() + ":" + ep.Port.ToString(), true);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult AR) {
            try {
                sock.EndConnect(AR);
                receiveBuffer = new byte[sock.ReceiveBufferSize];
                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        
        public static void Disconnect() {
            try {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            } catch { }
        }

        public static void SendCurrent() {
            try {
                Command com = CommandQueue.GetCurCommand();

                sock.BeginSend(com.content, 0, com.content.Length, SocketFlags.None, SendCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult AR) {
            try {
                sock.EndSend(AR);
            }
            catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static async void ReceiveCallback(IAsyncResult AR) { //why is this inconsistent?
            try {
                if (receiveBuffer.Length < 7) {
                    return;
                }
                
                int received = sock.EndReceive(AR);
                if(received == 0) {
                    return;
                }

                await SaveResponse();

                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
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

                if (msg.Length > 5 && msg.Contains("F")) {
                    //Command sendCom = CommandQueue.GetCurCommand();
                    //sendCom.Finish();

                    //ReturnCommand returnCom = sendCom.myReturn;
                    //returnCom.UpdateReturnMsg(msg);

                    //if (sendCom.repeatable) {
                    //    InfoPanel.ReadResult(msg);
                    //}

                    MainForm.m.WriteToResponses("Received: " + msg, false);
                } else {
                    MainForm.m.WriteToResponses("Received corrupted response", true);
                }

            } catch (Exception e) {
                MessageBox.Show("Error in message processing\n" + e.ToString());
            };
        }

        public static string GetSockEndpoint() {
            return sock.RemoteEndPoint.ToString();
        }

    }
}
