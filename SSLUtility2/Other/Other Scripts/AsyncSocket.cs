using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {
    class AsyncSocket : Form {

        Socket sock;
        byte[] receiveBuffer;

        void ConnectAsync(IPAddress ip, int port) {
            try {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                sock.BeginConnect(endPoint, ConnectCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            }
        }

        void SendAsync(byte[] send) {
            try {
                // Serialize the textBoxes text before sending.
                sock.BeginSend(send, 0, send.Length, SocketFlags.None, SendCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            }
        }

        private void ConnectCallback(IAsyncResult AR) {
            try {
                sock.EndConnect(AR);
                receiveBuffer = new byte[sock.ReceiveBufferSize];
                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            }
        }

        private void ReceiveCallback(IAsyncResult AR) {
            try {
                int received = sock.EndReceive(AR);
                if (received == 0) {
                    return;
                }

                string message = Encoding.ASCII.GetString(receiveBuffer);

                Invoke((Action)delegate {
                    MainForm.m.WriteToResponses("Server says: " + message);
                });

                sock.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            // Avoid Pokemon exception handling in cases like these.
            catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR) {
            try {
                sock.EndSend(AR);
            } catch (SocketException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            } catch (ObjectDisposedException ex) {
                MainForm.m.WriteToResponses(ex.Message);
            }
        }

    }
}
