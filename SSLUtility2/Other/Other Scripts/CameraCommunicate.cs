using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class CameraCommunicate {
        static string failedConnectMsg = "Issue connecting to TCP Port\n" +
                    "Would you like to see more information?";
        static string errorCaption = "Error Occured!";

        public static Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);

        public static string lastIPPort = "1";

        public const string defaultResult = "00 00 00 00 00 00 00";


        public static async Task<bool> sendtoIPAsync(byte[] code, Control lab = null, string ip = null, string port = null, bool hideError = false) {
            //MainForm.m.ReadCommand(code, true);
            try {
                if (!sock.Connected) {
                    bool ableToConnect = Connect(ip, port, lab, hideError).Result;
                    if (!ableToConnect) {
                        return false;
                    }
                }
                lastIPPort = ip + port;
                
                bool success = SendToSocket(code).Result;
                return success;
            } catch (Exception e) {
                if (!hideError) {
                    MainForm.ShowError(failedConnectMsg, errorCaption, e.ToString());
                }
                return false;
            }
        }

        public static async Task<bool> Connect(string ipAdr, string port, Control lCon, bool stopError = false) {
            try {
                LabelDisplay(false, lCon);
                if (!stopError && !ConfigControl.subnetNotif) {
                    if (!CheckIsSameSubnet(ipAdr)) {
                        CloseSock();
                        return false;
                    }
                }

                if (sock.Connected) {
                    CloseSock();
                }

                Uri u;
                if (ipAdr != null && port != null && ipAdr != "" && port != "") {
                    u = new Uri("http://" + ipAdr + ":" + port);
                } else {
                    return false;
                }

                if (!PingAdr(u).Result) {
                    if (!stopError) {
                        MainForm.ShowError(failedConnectMsg, errorCaption, ipAdr + ":" + port + " ping timed out with no response.");
                    }
                    return false;
                }
                LabelDisplay(true, lCon);

                IPAddress serverAddr = IPAddress.Parse(ipAdr);
                IPEndPoint endPoint = new IPEndPoint(serverAddr, Convert.ToInt32(port));
                sock = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(endPoint); //used to be async (maybe i can get it back at some point)
                return true;
            } catch (Exception e){
                MainForm.ShowError(failedConnectMsg, errorCaption, e.ToString(), true);
                return false;
            }
        }

        public static async Task<string> Query(byte[] code, Uri addr) {
            try {
                SendToSocket(code, false); // might want to consider using sendtoip //also maybe swap to async?
                if (!sock.Connected) {
                    if (!Connect(addr.Host, addr.Port.ToString(), null, true).Result) {
                        return defaultResult;
                    }
                }

                string result = StringFromSock().Result;
                 if(result.Length == 20) {
                    string subbed = result.Substring(0, 2);
                    if(subbed == "FF") {
                        MainForm.m.WriteToResponses(subbed, false);
                        return result;
                    }
                 }
            
                MainForm.m.WriteToResponses("Failed to get a response", false);
                return defaultResult;
            } catch (Exception e){
                MainForm.m.WriteToResponses("An error occured whilst trying to query the camera!", false);
                MainForm.m.WriteToResponses(e.ToString(), true);
                return defaultResult;
            }
        }

        public static async Task<bool> CheckPelcoCam(bool thermalCam) {
            if (thermalCam) {
                SendToSocket(new byte[] { 0xFF, 0x00, 0x00, 0x53, 0x00, 0x00, 0x53 });
            } else {
                SendToSocket(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 });
            }
            string result = StringFromSock().Result;
            if (result == defaultResult) {
                return false;
            } else {
                return true;
            }
        }

        public static void LabelDisplay(bool connected, Control l) {
            if (l == null)
                return;
            if (connected) {
                l.Text = "✓";
                l.ForeColor = Color.Green;
            } else {
                l.Text = "❌";
                l.ForeColor = Color.Red;
            }
        }

        public static async Task<bool> PingAdr(Uri address) {
            Ping pinger = null;

            if (address == null) {
                return false;
            }

            try {
                pinger = new Ping();
                PingReply reply = pinger.Send(address.Host, 2);
                if (reply.Status == IPStatus.Success) {
                    //if (address.Port == 0 || address.ToString().Contains("w")) {
                    //    return true;
                    //}
                    //using (var client = new TcpClient(address.Host, address.Port)) {
                    //    return true;
                    //}
                    return true;
                }
            } catch {
            } finally {
                pinger.Dispose();
            }
            return false;
        }

        public static async Task<bool> SendToSocket(byte[] code, bool async = false) {
            try {
                if (code != null) {
                    MainForm.m.WriteToResponses("Sending command: " + MainForm.m.ReadCommand(code, false), true);
                    if (async) {
                        AsyncSocket.SendAsync(code);
                    } else {
                        sock.SendTo(code, sock.RemoteEndPoint);
                    }
                    return true;
                }
                return false;
            } catch (Exception e) {
                MainForm.m.WriteToResponses("An error occured whilst trying to send a command to the camera", false);
                MainForm.m.WriteToResponses(e.ToString(), true);
                return false;
            };
        }

        public static async Task<string> StringFromSock() {
            try {
                byte[] buffer = new byte[7];
                Receive(sock, buffer, 0, buffer.Length, 1500);
                string m = "";
                int zeroCount = 0;
                for (int i = 0; i < buffer.Length; i++) {
                    string hex = buffer[i].ToString("X");
                    if (int.Parse(buffer[i].ToString()) <= 10) {
                        hex = "0" + hex;
                        if(hex == "00") {
                            zeroCount++;
                        }
                        if(zeroCount > 6) {
                            return defaultResult;
                        }
                    }
                    m += hex + " ";
                }
                m = m.Trim();

                return m;
            } catch (Exception e) {
                MainForm.ShowError("Failed to receive response!\nShow more?", errorCaption, e.ToString(), true);
                return null;
            }
        }

        private static async void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout) {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received

            while (received < size) {
                if (Environment.TickCount > startTickCount + timeout)
                    return;
                try {
                    sock.ReceiveTimeout = timeout;
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                } catch (SocketException ex) {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable) {
                        await Task.Delay(30);// socket buffer is probably empty, wait and try again
                    }
                }
            }
        }

        public static void CloseSock(Socket usedSock = null) {
            if (usedSock == null) {
                usedSock = sock;
            }
            if (usedSock != null && usedSock.Connected) {
                usedSock.Shutdown(SocketShutdown.Both);
                usedSock.Close();
            }
        }

        public static bool CheckIsSameSubnet(string newIp) {
            if (!IPAddress.TryParse(newIp, out IPAddress dontuse)) {
                return false;
            }

            string rawIp = GetLocalIPAddress();
            string mySub = FindSubnet(rawIp);
            string newSub = FindSubnet(newIp);

            Int32.TryParse(mySub, out int mine);
            Int32.TryParse(newSub, out int other);

            if (mine != other) {
                MainForm.ShowError("Local IP subnet is not the same as the camera subnet!\nShow possible fix?", errorCaption,
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

        public static string GetSockEndpoint() {
            return sock.RemoteEndPoint.ToString();
        }

    }
}
