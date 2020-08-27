using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBigLoader
{
    class CameraCommunicate {

        static IPAddress serverAddr = null;
        static Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
        static IPEndPoint endPoint = new IPEndPoint(0, 0);


        public static async Task sendtoIPAsync(byte[] code) {
            try {
                if (!sock.Connected) {
                    await Connect(MainForm.m);
                }
                SendToSocket(code);
            } catch (Exception e) {
                string message = "Issue connecting to TCP Port\n" +
                    "Would you like to see more information?";
                string caption = "Error";

                DialogResult d = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                if (d == DialogResult.Yes) {
                    MessageBox.Show(e.ToString(), caption, MessageBoxButtons.OK);
                }
            }
        }

        public static async Task Connect(MainForm m) {
            if (sock.Connected) {
                sock.Close();
            }
            string ipAdr = m.tB_IPCon_Adr.Text;

            if (!PingAdr(ipAdr)) {
                m.l_IPCon_Connected.Text = "❌";
                m.l_IPCon_Connected.ForeColor = Color.Red;
                return;
            }
            m.l_IPCon_Connected.Text = "✓";
            m.l_IPCon_Connected.ForeColor = Color.Green;

            serverAddr = IPAddress.Parse(ipAdr);
            sock = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(serverAddr, Convert.ToInt32(m.tB_IPCon_Port.Text));
            sock.ConnectAsync(endPoint);
        }


        public static bool PingAdr(string address) {
            Ping pinger = null;

            if (address == null) {
                return false;
            }

            try {
                pinger = new Ping();
                PingReply reply = pinger.Send(address, 2);
                if (reply.Status == IPStatus.Success) {
                    return true;
                }
            } catch (PingException) {
                //not connected
            } finally {
                pinger.Dispose();
            }
            return false;
        }

        private static async Task SendToSocket(byte[] code) {
            if (code != null) {
                sock.SendTo(code, endPoint);
                //sock.Close();
            }
        }

    }
}
