using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    class AsyncSocket {

        public static Socket sock;
        static byte[] receiveBuffer;

        public static void ConnectAsync(Uri addr) {
            try {
                if (sock != null) {
                    if (sock.Connected) {
                        Disconnect();
                    }
                }
                IPAddress ip = IPAddress.Parse(addr.Host);
                int port = addr.Port;
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                sock.BeginConnect(endPoint, ConnectCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message, false);
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        public static void Disconnect() {
            try {
                sock = null;
                //sock.Shutdown(SocketShutdown.Both);
                //sock.Close();
            } catch { }
        }

        public static void SendAsync(byte[] send) {
            try {
                sock.BeginSend(send, 0, send.Length, SocketFlags.None, SendCallback, null);
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

        private static void ReceiveCallback(IAsyncResult AR) {
            try {
                int received = sock.EndReceive(AR);
                if (received == 0) {
                    return;
                }

                GetResponse();

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

        static async Task GetResponse() {
            try {
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
                if (m.Length > 1) {
                    MainForm.m.WriteToResponses("Server says: " + m, true, false);
                    InfoPanel.ReadResult(m);
                }
            } catch { }
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
    
    }
}
