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
    public class OsirisComs {
        public static Socket sock;
        public static Socket receiveSock;

        public const string defaultResult = "00 00 00 00 00 00 00";

        static byte[] receiveBuffer;

        public static bool doneReceive;
        public static string lastMsg;

        public static bool Connect(IPEndPoint ep) {
            try {
                if (sock != null) {
                    if (sock.Connected) {
                        //Disconnect(); //need to be able to reconnect with new ip
                        return false;
                    }
                }

                bool parsedIP = IPAddress.TryParse(MainForm.m.ipCon.tB_IPCon_Adr.Text, out IPAddress ip);
                bool parsedPort = int.TryParse(MainForm.m.ipCon.tB_IPCon_Port.Text, out int port);
                if (ep == null && (!parsedIP || !parsedPort)) {
                    MainForm.ShowPopup("Failed to parse endpoint!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return false;
                }

                if (!OtherCameraCommunication.PingAdr(ep.Address).Result) {
                    MainForm.ShowPopup("Failed to ping IP address!\nAddress provided is likely invalid!\nShow more?", "Failed to connect!",
                                        "Successfully parsed\nIP: " + parsedIP.ToString() + "\nPort: " + parsedPort.ToString());
                    return false;
                }
                
                ep = new IPEndPoint(ip, port);

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                receiveSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                sock.BeginConnect(ep, ConnectCallback, null);

                MainForm.m.WriteToResponses("Successfully connected to: " + ep.Address.ToString() + ":" + ep.Port.ToString(), true);
                return true;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        private static void ConnectCallback(IAsyncResult AR) {
            try {
                sock.EndConnect(AR);
                receiveSock.BeginConnect(sock.RemoteEndPoint, ReceiveConnectCallback, null);
            } catch (SocketException ex) {
            } catch (ObjectDisposedException ex) {
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

        private static void ReceiveConnectCallback(IAsyncResult AR) {
            try {
                receiveSock.EndConnect(AR);

                receiveBuffer = new byte[receiveSock.ReceiveBufferSize];
                receiveSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
            } catch (ObjectDisposedException ex) {
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        
        public static void Send(byte[] code) {
            try {
                doneReceive = true;
                sock.BeginSend(code, 0, code.Length, SocketFlags.None, SendCallback, null);
            } catch (SocketException ex) {
            } catch (ObjectDisposedException ex) {
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult AR) {
            try {
                sock.EndSend(AR);
            } catch (SocketException ex) {
            } catch (ObjectDisposedException ex) {
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult AR) {
            try {
                //if (receiveBuffer.Length < 7) {
                //    return;
                //}
                
                int received = receiveSock.EndReceive(AR);
                if(received == 0) {
                    return;
                }

                SaveResponse();

                doneReceive = true;
                
                receiveBuffer = new byte[receiveSock.ReceiveBufferSize];
                receiveSock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                
            } catch (ObjectDisposedException ex) {
                
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        static async Task SaveResponse() {
            string msg = "";

            for (int i = 0; i < receiveBuffer.Length; i++) {
                string hex = receiveBuffer[i].ToString("X").ToUpper();
                
                if (hex.Length == 1) {
                    hex = "0" + hex;
                }
                msg += hex + " ";
            }

            lastMsg = msg.Trim();
        }

    }
}
