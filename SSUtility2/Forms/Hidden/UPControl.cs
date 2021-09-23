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

        void SendUP(string text) {
            try {
                messagePos = 0;
                byte[] SYNC = new byte[] { 0x5A, 0xA5 }; //Big endian
                byte[] FID = BitConverter.GetBytes(incrementalCounter++);
                byte[] TIME = GetMillisecondTime();
                //XT
                byte[] CMD = GetCMD();
                byte[] DATA = GetData();
                byte[] DATALEN = GetDataLen(DATA);

                //SYNC:2, TIME:4, FID:2, XT:4, CMD:2, LEN:2, DATA:0-65517, CRC:2    //bytes (8 bits)
                //byte[] message = new byte[65535];
                byte[] message = new byte[128];

                AddToMessage(message, SYNC);
                AddToMessage(message, FID);
                AddToMessage(message, TIME);
                //XT
                AddToMessage(message, CMD);
                AddToMessage(message, DATALEN);
                AddToMessage(message, DATA);

                byte[] CRC = GetCRC(message);

                AddToMessage(message, CRC);

                //AsyncCamCom.SendNonAsync(message);

                l_Send.Text = "Sending: " + BitConverter.ToString(message);
            } catch (Exception e) {
                MessageBox.Show("UP\n" + e.ToString());
            }
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
