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
                bool result = Tools.ShowPopup("Local IP subnet is not the same as the camera subnet!" + "\nYour IP: " + rawIp + "\nOther IP: "
                    + rawIp.Replace(mySub, newSub) + "\nProceed anyway?",
                    "Subnet Error!", "", false);
                return result;
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

        public static async Task LabelDisplay(bool connected) {
            try {
                if (!MainForm.m.finishedLoading)
                    await Task.Delay(1000).ConfigureAwait(false);

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
            } catch (Exception e) { 
                Console.WriteLine("LABEL DISPLAY\n" + e.ToString());
            };
        }

        public static async Task<bool> PingAdr(string address) {
            if (address == null) {
                return false;
            }

            Ping pinger = null;
            bool success = false;

            for (int i = 0; i < 2; i++) {
                try {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(address, 2);
                    if (reply.Status == IPStatus.Success) {
                        success = true;
                        break;
                    }
                } catch {
                } finally {
                    pinger.Dispose();
                }
            }
            
            return success;
        }
        
        public static async Task<CamConfig> CheckConfiguration() {
            try {
                CamConfig newConfig;
                string result = defaultResult;

                result = await AsyncCamCom.QueryNewCommand(new byte[] { 0xFF, 0x01, 0x03, 0x6B, 0x00, 0x00, 0x6F }).ConfigureAwait(false);

                if (result == defaultResult || result.Length < 12 || !result.ToLower().Contains("6d")) {
                    return CamConfig.Null;
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
