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
    class OtherCamCom {

        public enum CamConfig {
            SSTraditional,
            Strict,
            RevTilt,
            Legacy
        }

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

            if (mine != other) {
                MainForm.ShowPopup("Local IP subnet is not the same as the camera subnet!\nShow possible fix?",
                    "Subnet Error!", "Try changing your IP from: " + rawIp + "\n To: "
                    + rawIp.Replace(mySub, newSub) + "\nThe new IP will also have to be static!");
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
        public static void LabelDisplay(bool connected) {
            MainForm.m.Invoke((MethodInvoker)delegate {
                Label l = MainForm.m.ipCon.l_IPCon_Connected;
                if (connected) {
                    l.Text = "✓";
                    l.ForeColor = Color.Green;
                } else {
                    l.Text = "❌";
                    l.ForeColor = Color.Red;
                }
            });
        }


        public static async Task<bool> PingAdr(IPAddress address) {
            Ping pinger = null;

            if (address == null) {
                return false;
            }

            try {
                pinger = new Ping();
                PingReply reply = pinger.Send(address, 3);
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
        
        public static async Task<CamConfig> CheckConfiguration() {
            string result = await AsyncCamCom.QueryNewCommand(new byte[] { 0xFF, 0x01, 0x03, 0x6B, 0x00, 0x00, 0x6F }).ConfigureAwait(false);
            CamConfig myConfig = CamConfig.Strict;
            if (result == null) {
                return myConfig;
            }
            if (result.Length < 2) {
                return myConfig;
            }

            string type = result.Substring(12, 1);

            switch (type) { //maybe add defaultresult handling? also currently has a different setting than expected?
                case "0":
                    myConfig = CamConfig.SSTraditional;
                    break;
                case "1":
                    myConfig = CamConfig.Strict;
                    break;
                case "2":
                    myConfig = CamConfig.RevTilt;
                    break;
                case "3":
                    myConfig = CamConfig.Legacy;
                    break;
            }
            //MessageBox.Show("config " + result + "\n" + myConfig.ToString());

            return myConfig;
        }

        public static float CalculateTilt(string code, CamConfig config) { //need to revist this and change value handling
            float full = ReturnedHexValToFloat(code);

            switch (config) {
                case CamConfig.SSTraditional:
                case CamConfig.Legacy:
                    break;
                case CamConfig.Strict:
                    break;
                case CamConfig.RevTilt:
                    break;

            }
            //SSTraditional and Legacy
            //Tilt 0-90 positive, -0.01 - -90 negative
            //0-9000 = positive, -1 - -9000 (65535-56536) = negative

            //Strict Only
            //horizontal (normally 90 degrees clockwise) = 0
            //vertical = 270, increasing value goes clockwise(through negative)
            //illegal range 90.01 - 269.99
            //65535-36001 illegal, 00000-35999 legal

            //RevTilt
            //Same as Strict, anticlockwise instead of clockwise
            //0-9000 = from horizontal to vertically up, etc
            return full;
        }

        public static float CalculatePan(string code, CamConfig config) {
            float finalResult = 0;
            float full = ReturnedHexValToFloat(code);

            switch (config) {
                case CamConfig.SSTraditional:
                case CamConfig.Legacy:

                    if (full <= 360.00f) {
                        finalResult = full;
                    } else {
                        finalResult = -(655.36f - full);
                    }

                    break;
                case CamConfig.Strict:
                case CamConfig.RevTilt:
                    finalResult = ReturnedHexValToFloat(code); //same thing anyway
                    break;
            }

            return finalResult;
        }

        public static float ReturnedHexValToFloat(string code) {
            string d1 = code.Substring(12, 2);
            string d2 = code.Substring(15, 2);

            string combined = (d1 + d2);

            string added = int.Parse(combined, System.Globalization.NumberStyles.HexNumber).ToString();
            float finalResult = float.Parse(added) / 100f;
            return finalResult;
        }

    }
}
