using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2.Hidden {
    public partial class UPControl : Form {
        public UPControl() {
            InitializeComponent();
        }

        private void b_Send_Click(object sender, EventArgs e) {
            SendUP(tB_Text.Text);
        }

        static uint incrementalCounter = 0;
        static int messagePos = 0;

        static void SendUP(string text) {
            messagePos = 0;
            byte[] SYNC = new byte[] { 0x5A, 0xA5 };
            byte[] FID = BitConverter.GetBytes(incrementalCounter++);
            byte[] TIME = GetMillisecondTime();
            byte[] CMD = GetCMD();
            byte[] DATA = GetData();
            byte[] DATALEN = GetDataLen(DATA);

            //SYNC:16, TIME:32, FID:16, CMD:16, LEN:16, DATA:0-65521, CRC:16 
            byte[] message = new byte[65535];

            AddToMessage(message, SYNC);
            AddToMessage(message, FID);
            AddToMessage(message, TIME);
            AddToMessage(message, CMD);
            AddToMessage(message, DATALEN);
            AddToMessage(message, DATA);

            byte[] CRC = GetCRC(message);

            AddToMessage(message, CRC);

            AsyncCamCom.SendNonAsync(message);
        }

        static byte[] AddToMessage(byte[] message, byte[] vals) {
            for (int i = 0; i < vals.Length; i++)
                message[messagePos++] = vals[i];

            return message;
        }

        static byte[] GetMillisecondTime() {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            byte[] time = BitConverter.GetBytes(milliseconds);
            return time;
        }

        static byte[] GetCMD() {
            return new byte[] { };
        }

        static byte[] GetDataLen(byte[] data) {
            return new byte[] { };
        }

        static byte[] GetData() {
            return new byte[] { };
        }

        static byte[] GetCRC(byte[] message) {
            return new byte[] { };
        }

        static string SingleCRC(string input) {
            int resultLength = 16;
            string divisor = "1011";

            for (int i = 0; i < resultLength; i++)
                input += "0";

            char[] dividend = input.ToCharArray();

            for (int i = 0; i < dividend.Length - resultLength; i++) {
                if (dividend[i] == '1') {
                    for (int o = 0; o < divisor.Length; o++) {
                        if (dividend.Length < i + o + 1) //if there are no more bits in input
                            break;

                        if (dividend[i + o] == divisor[o])
                            dividend[i + o] = '0';
                        else
                            dividend[i + o] = '1';
                    }
                }
            }

            Console.WriteLine(dividend);

            string result = "";

            for (int i = dividend.Length - resultLength; i < dividend.Length; i++)
                result += dividend[i];

            Console.WriteLine(result);

            return result;
        }

    }
}
