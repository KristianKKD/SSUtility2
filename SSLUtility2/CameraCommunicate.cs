using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class CameraCommunicate {
        public static MainForm mainRef;

        static string failedConnectMsg = "Issue connecting to TCP Port\n" +
                    "Would you like to see more information?";
        static string failedConnectCaption = "Error";

        static IPAddress serverAddr = null;
        static Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
        static IPEndPoint endPoint = new IPEndPoint(0, 0);

        public static string lastIPPort = "1";

        public static async Task<bool> sendtoIPAsync(byte[] code, Control lab, string ip = null, string port = null) {
            //string m = "";
            //for (int i = 0; i < code.Length; i++) {
            //    m += code[i].ToString() + " ";
            //}
            //MessageBox.Show(m);
            try {
                if (!sock.Connected) {
                    bool ableToConnect = Connect(ip, port, lab, false).Result;
                    if (!ableToConnect) {
                        return false;
                    }
                }
                lastIPPort = ip + port;
                
                bool success = SendToSocket(code).Result;
                return success;
            } catch (Exception e) {
                MainForm.ShowError(failedConnectMsg, failedConnectCaption, e.ToString());
                return false;
            }
        }

        public static async Task<bool> Connect(string ipAdr, string port, Control lCon, bool stopError = false) {
            LabelDisplay(false, lCon);
            if (!stopError) {
                if (!CheckIsSameSubnet(ipAdr) && !ConfigControl.subnetNotif) {
                    CloseSock();
                    return false;
                }
            }

            if (sock.Connected) {
                CloseSock();
            }
            if (!PingAdr(ipAdr).Result) {
                if (!stopError) {
                    MainForm.ShowError(failedConnectMsg, failedConnectCaption, ipAdr + ":" + port + " ping timed out with no response.");
                }
                return false;
            }
            LabelDisplay(true, lCon);

            serverAddr = IPAddress.Parse(ipAdr);
            sock = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(serverAddr, Convert.ToInt32(port));
            sock.Connect(endPoint); //used to be async (maybe i can get it back at some point)
            return true;
        }

        public static void LabelDisplay(bool connected, Control l) {
            if (connected) {
                l.Text = "✓";
                l.ForeColor = Color.Green;
            } else {
                l.Text = "❌";
                l.ForeColor = Color.Red;
            }
        }

        public static async Task<bool> PingAdr(string address) {
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
            } catch {
            } finally {
                pinger.Dispose();
            }
            return false;
        }

        private static async Task<bool> SendToSocket(byte[] code) {
            if (code != null) {
                sock.SendTo(code, endPoint);
                return true;
            }
            return false;
        }

        public static async Task<string> StringFromSock(string ipAdr, string port, Control lCon, bool stopError = false) {
            if (!sock.Connected) {
                if (!Connect(ipAdr, port, lCon, stopError).Result) {
                    return null;
                }
            }
            try {
                byte[] buffer = new byte[4];
                Receive(sock, buffer, 0, buffer.Length, 10000);
                string m = "";
                for (int i = 0; i < buffer.Length; i++) {
                    m += buffer[i].ToString() + " ";
                }
                return m;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        private static async void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout) {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received
            while (received < size) {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                } catch (SocketException ex) {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable) {
                        // socket buffer is probably empty, wait and try again
                        await Task.Delay(30);
                    } else
                        throw ex;  // any serious error occurr
                }
            } 
        }

       
        public static void CloseSock() {
            if (sock != null && sock.Connected) {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }
        public static bool CheckIsSameSubnet(string newIp) {
            string rawIp = GetLocalIPAddress();
            string mySub = FindSubnet(rawIp);
            string newSub = FindSubnet(newIp);

            Int32.TryParse(mySub, out int mine);
            Int32.TryParse(newSub, out int other);

            if (mine != other) {
                MainForm.ShowError("Local IP subnet is not the same as the camera subnet!\nShow possible fix?", "Incorrect subnet!",
                    "Try changing your IP from: " + rawIp + "\n To: " + rawIp.Replace(mySub, newSub) +
                    "\nThe new IP will also have to be static!");
                return false;
            } else {
                return true;
            }
        }
        static string FindSubnet(string ip) {
            string difference = ip.Substring(ip.IndexOf(".", ip.IndexOf(".") + 1));
            string endChunk = ip.Substring(ip.LastIndexOf("."));
            difference = difference.Replace(endChunk, "");
            difference = difference.Replace(".", "").Trim();
            return difference;
        }

        public static string GetLocalIPAddress() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
