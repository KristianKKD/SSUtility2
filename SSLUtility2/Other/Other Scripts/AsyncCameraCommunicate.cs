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

namespace SSLUtility2 {
    public class AsyncCameraCommunicate {
        public static Socket sock;

        public const string defaultResult = "00 00 00 00 00 00 00";

        static byte[] receiveBuffer;

        public static int SendNewCommand(byte[] code) {
            Command com = new Command(code);
            if (com.invalid) {
                //do something
                return -1;
            }
            //CommandQueue.MoveHeaderToCommand(com);
            //Send();
            return com.id;
        }

        public static void SendExistingCommand(int id) {
            Command com = CommandQueue.FindCommandByID(id);
            if (com != null) {
                CommandQueue.MoveHeaderToCommand(com);
                //Send();
            }
        }

        public static void QueueRepeatingCommand(int id) {
            Command oldCom = CommandQueue.FindCommandByID(id);
            Command com = new Command(oldCom.content, true);
        }

        public static void Connect(IPEndPoint ep = null) {
            try {
                if (sock != null) {
                    if (sock.Connected) {
                        //Disconnect();
                        return;
                    }
                }

                bool parsedIP = IPAddress.TryParse(MainForm.m.ipCon.tB_IPCon_Adr.Text, out IPAddress ip);
                bool parsedPort = int.TryParse(MainForm.m.ipCon.tB_IPCon_Port.Text, out int port);
                if (ep == null && (!parsedIP || !parsedPort)) {
                    MainForm.ShowError("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return;
                }

                if (!OtherCameraCommunication.PingAdr(ep.Address).Result) {
                    MainForm.ShowError("Failed to ping IP address!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return;
                }
                
                ep = new IPEndPoint(ip, port);

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.BeginConnect(ep, ConnectCallback, null);
                MainForm.m.WriteToResponses("Successfully connected to: " + ep.Address.ToString() + ":" + ep.Port.ToString(), true);
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
                receiveSock.Shutdown(SocketShutdown.Both);
                receiveSock.Close();
            } catch { }
        }

        private static void ConnectCallback(IAsyncResult AR) {
            try {
                sock.EndConnect(AR);
                receiveBuffer = new byte[sock.ReceiveBufferSize];
                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
<<<<<<< HEAD:SSLUtility2/Other/Communication/AsyncCameraCommunicate.cs
        
        public static void SendCurrent() {
=======

        public static void Disconnect() {
            try {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            } catch { }
        }

        static void Send() {
>>>>>>> 77ec14a31a32f7a14babd619bc7a095ff38ed2a0:SSLUtility2/Other/Other Scripts/AsyncCameraCommunicate.cs
            try {
                Command com = CommandQueue.GetCurCommand();
                Console.WriteLine("sending");

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
                CommandQueue.MoveHeaderNext(); //need to have it not ignore failed command, this is temporary
            }
            catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult AR) { //why is this inconsistent?
            try {
<<<<<<< HEAD:SSLUtility2/Other/Communication/AsyncCameraCommunicate.cs
                if (receiveBuffer.Length < 7) {
                    return;
                }
                
                int received = receiveSock.EndReceive(AR);
=======
                int received = sock.EndReceive(AR);
>>>>>>> 77ec14a31a32f7a14babd619bc7a095ff38ed2a0:SSLUtility2/Other/Other Scripts/AsyncCameraCommunicate.cs
                if(received == 0) {
                    return;
                }
                SaveResponse();

<<<<<<< HEAD:SSLUtility2/Other/Communication/AsyncCameraCommunicate.cs
                //CommandQueue.MoveHeaderNext();

                receiveBuffer = new byte[receiveSock.ReceiveBufferSize];
                receiveSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
=======
                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
>>>>>>> 77ec14a31a32f7a14babd619bc7a095ff38ed2a0:SSLUtility2/Other/Other Scripts/AsyncCameraCommunicate.cs
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        static void SaveResponse() {
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
                }
            }

            msg = msg.Trim();
<<<<<<< HEAD:SSLUtility2/Other/Communication/AsyncCameraCommunicate.cs

            Command sendCom = CommandQueue.GetCurCommand();
            sendCom.Finish();
            ReturnCommand returnCom = sendCom.myReturn;
            returnCom.UpdateReturnMsg(msg);

            MainForm.m.WriteToResponses("Received: " + msg, false);
=======
            ReturnCommand com = CommandQueue.FindReturnByID(CommandQueue.GetCurCommand().id); //might cause issues
            com.UpdateReturnMsg(msg);
            MainForm.m.WriteToResponses(msg, false);
>>>>>>> 77ec14a31a32f7a14babd619bc7a095ff38ed2a0:SSLUtility2/Other/Other Scripts/AsyncCameraCommunicate.cs
        }

        public static string GetSockEndpoint() {
            return sock.RemoteEndPoint.ToString();
        }

    }
}
