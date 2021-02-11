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
    class OtherCameraCommunication {

        static string failedConnectMsg = "Issue connecting to TCP Port\n" +
                   "Would you like to see more information?";
        static string errorCaption = "Error Occured!";
        public const string defaultResult = "00 00 00 00 00 00 00";

        public static bool CheckIsSameSubnet(string newIp) {
            if (!IPAddress.TryParse(newIp, out IPAddress dontuse)) {
                return false;
            }

            string rawIp = GetLocalIPAddress();
            string mySub = FindSubnet(rawIp);
            string newSub = FindSubnet(newIp);

            Int32.TryParse(mySub, out int mine);
            Int32.TryParse(newSub, out int other);

            if (mine != other && !ConfigControl.subnetNotif.boolVal) {
                MainForm.ShowPopup("Local IP subnet is not the same as the camera subnet!\nShow possible fix?", errorCaption,
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
        public static void LabelDisplay(bool connected, Label l) {
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

        public static async Task<bool> PingAdr(IPAddress address) {
            Ping pinger = null;

            if (address == null) {
                return false;
            }

            try {
                pinger = new Ping();
                PingReply reply = pinger.Send(address, 2);
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
    }
}
