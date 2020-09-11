﻿using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    class CameraCommunicate {
        public MainForm MainRef {
            get;
            set;
        }

        static string failedConnectMsg = "Issue connecting to TCP Port\n" +
                    "Would you like to see more information?";
        static string failedConnectCaption = "Error";

        static IPAddress serverAddr = null;
        static Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
        static IPEndPoint endPoint = new IPEndPoint(0, 0);
        public static Control defaultLabel;

        public static async Task sendtoIPAsync(byte[] code, Control lab = null) {
            try {
                if (lab == null) {
                    lab = defaultLabel;
                }
                if (!sock.Connected) {
                    await Connect(MainForm.m, false, lab);
                }
                SendToSocket(code);
            } catch (Exception e) {
                MainForm.ShowError(failedConnectMsg, failedConnectCaption, e.ToString());
            }
        }

        public static async Task<bool> Connect(MainForm m, bool stopError = false, Control lCon = null) {
            if (lCon == null) {
                lCon = defaultLabel;
            }
            if (sock.Connected) {
                sock.Close();
            }
            string ipAdr = m.tB_IPCon_Adr.Text;

            if (!PingAdr(ipAdr)) {
                lCon.Text = "❌";
                lCon.ForeColor = Color.Red;
                if (!stopError) {
                    MainForm.ShowError(failedConnectMsg, failedConnectCaption, "IP ping timed out with no response.");
                }
                return false;
            }
            lCon.Text = "✓";
            lCon.ForeColor = Color.Green;

            serverAddr = IPAddress.Parse(ipAdr);
            sock = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(serverAddr, Convert.ToInt32(m.tB_IPCon_Port.Text));
            sock.ConnectAsync(endPoint);
            return true;
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
