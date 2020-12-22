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
    class AsyncCameraCommunicate {
        public static Socket sock;

        public const string defaultResult = "00 00 00 00 00 00 00";

        static byte[] receiveBuffer;

        public static int SendNewCommand(byte[] code) {
            Command com = new Command(code);
            if (com.invalid) {
                //do something
                return -1;
            }
            CommandQueue.header = com.id;
            Send();
            return com.id;
        }

        public static void SendExistingCommand(int id) {
            Command com = CommandQueue.FindCommandByID(id);
            if (com != null) {
                CommandQueue.MoveHeaderToCommand(com);
                Send();
            }
        }

        public static void Connect(IPEndPoint ep = null) {
            try {
                if (sock != null) {
                    if (sock.Connected) {
                        Disconnect();
                    }
                }
                if (ep == null) {
                    bool parsedIP = IPAddress.TryParse(MainForm.m.ipCon.tB_IPCon_Adr.Text, out IPAddress ip);
                    bool parsedPort = int.TryParse(MainForm.m.ipCon.tB_IPCon_Port.Text, out int port);
                    if (!parsedIP || !parsedPort) {
                        MainForm.ShowError("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                            "IP parsed: " + parsedIP.ToString() +"\nPort parsed: " + parsedPort.ToString());
                        return;
                    }
                    ep = new IPEndPoint(ip, port);
                }

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.BeginConnect(ep, ConnectCallback, null);
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
            } catch (SocketException ex) {
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

        static void Send() {
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
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult AR) {
            try {
                sock.EndReceive(AR);
                SaveResponse();

                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        static void SaveResponse() {
            string m = "";
            int comCount = 0;
            for (int i = 0; i < receiveBuffer.Length; i++) {
                string hex = receiveBuffer[i].ToString("X").ToUpper();
                if (hex == "FF") {
                    comCount = 7;
                }
                if (comCount > 0) {
                    if (hex.Length == 1) {
                        hex = "0" + hex;
                    }
                    m += hex + " ";
                    comCount--;
                }

            }
            m = m.Trim();
            ReturnCommand com = CommandQueue.FindReturnByID(CommandQueue.GetCurCommand().id); //might cause issues
            com.UpdateReturnMsg(m);
        }

    }
}
