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
            Legacy,
            Null,
        }

        public static CamConfig currentConfig = CamConfig.Null;

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
                Tools.ShowPopup("Local IP subnet is not the same as the camera subnet!\nShow possible fix?",
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
                Label l = MainForm.m.setPage.l_IPCon_Connected;
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
            try {
                CamConfig newConfig;
                string result = defaultResult;

                for (int i = 0; i < 3; i++) {
                    result = await AsyncCamCom.QueryNewCommand(new byte[] { 0xFF, 0x01, 0x03, 0x6B, 0x00, 0x00, 0x6F }).ConfigureAwait(false);

                    bool failed = false;
                    if (result == null) {
                        failed = true;
                        ;
                    } else if (result.Length < 12) {
                        failed = true;
                    } else if (result == defaultResult) {
                        failed = true;
                    }

                    if (!failed) {
                        break;
                    } else if (i >= 2) {
                        return CamConfig.Null;
                    }
                }

                string type = result.Substring(13, 1);
                MainForm.m.WriteToResponses("Cam config received response: " + result + "(" + type + ")", true);

                switch (type) {
                    case "0":
                        newConfig = CamConfig.SSTraditional;
                        break;
                    case "1":
                        newConfig = CamConfig.Strict;
                        break;
                    case "2":
                        newConfig = CamConfig.RevTilt;
                        break;
                    case "3":
                        newConfig = CamConfig.Legacy;
                        break;
                    default:
                        newConfig = CamConfig.Null;
                        break;
                }


                MainForm.m.WriteToResponses("Cam config type: " + newConfig.ToString(), true);

                currentConfig = newConfig;
                return newConfig;
            } catch (Exception e) {
                MessageBox.Show("CHECK CAM CONFIG\n" + e.ToString());
                return CamConfig.Null;
            }
        }

        public static float CalculateTilt(string code) {
            float finalValue = ReturnedHexValToFloat(code);

            switch (currentConfig) {
                case CamConfig.SSTraditional:
                case CamConfig.Legacy:
                    if (finalValue > 360) {
                        finalValue -= 360;
                        finalValue *= -1;
                    }
                    break;
                case CamConfig.Strict:
                    finalValue = 360 - finalValue;
                    break;
                case CamConfig.RevTilt:
                    break;

            }

            finalValue = (float)Math.Round(finalValue, 1);
            return finalValue;
        }

        public static float CalculatePan(string code) {
            float finalValue = ReturnedHexValToFloat(code);

            switch (currentConfig) {
                case CamConfig.SSTraditional:
                case CamConfig.Legacy:
                    if (finalValue > 360.00f) {
                        finalValue = -(655.36f - finalValue);
                    }
                    break;
                case CamConfig.Strict:
                case CamConfig.RevTilt:
                    break;
            }

            finalValue = (float)Math.Round(finalValue, 1);
            return finalValue;
        }

        public static float ReturnedHexValToFloat(string code) {
            string d1 = code.Substring(12, 2);
            string d2 = code.Substring(15, 2);

            string combined = (d1 + d2);

            string added = int.Parse(combined, System.Globalization.NumberStyles.HexNumber).ToString();
            float finalValue = float.Parse(added) / 100f;
            finalValue = (float)Math.Round(finalValue, 1);
            return finalValue;
        }

    }
}
