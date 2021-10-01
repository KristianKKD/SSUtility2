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
                byte[] SYNC = new byte[] { 0xA5, 0x00 }; //Low endian
                byte[] TIME = GetMillisecondTime();
                byte[] FID = GetFID();
                byte[] XT = GetXT(); //Future will need it to take in an input
                byte[] CMD = GetCMD(text);
                byte[] DATA = GetData();
                byte[] DATALEN = GetDataLen(DATA);

                //SYNC:2, TIME:4, FID:2, XT:4, CMD:2, LEN:2, DATA:0-65517, CRC:2    //bytes (8 bits)
                byte[] message = new byte[18];

                AddToMessage(message, SYNC);
                AddToMessage(message, FID);
                AddToMessage(message, TIME);
                AddToMessage(message, XT);
                AddToMessage(message, CMD);
                AddToMessage(message, DATALEN);
                //AddToMessage(message, DATA);

                byte[] CRC = GetCRC(message);

                AddToMessage(message, CRC);

                //AsyncCamCom.SendNonAsync(message);
                incrementalCounter++;


                string s = "";
                for (int i = 0; i < message.Length; i++) {
                    if (i > 18 && i < 20) {
                        s += "... ";
                        i = message.Length - 2;
                    }
                        s += message[i].ToString("X") + " ";
                }

                l_Send.Text = s;
            } catch (Exception e) {
                MessageBox.Show("UP\n" + e.ToString());
            }
        }

        static byte[] AddToMessage(byte[] message, byte[] vals) {
            for (int i = 0; i < vals.Length; i++)
                message[messagePos++] = vals[i];

            return message;
        }

        static byte[] GetFID() {
            if (incrementalCounter > 65535)
                incrementalCounter = 0;

            byte[] fid = LowEndianConvert(incrementalCounter);
            return fid;
        }

        static byte[] GetMillisecondTime() {
            byte[] time = new byte[4];
            time = BitConverter.GetBytes(DateTime.Now.Millisecond);
            return time;
        }

        static byte[] GetXT() { //Future will need it to take in an input
            //byte[] XT = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
            return new byte[4];
        }
        
        static byte[] GetCMD(string text) {
            byte[] cmd = LowEndianConvert(Convert.ToUInt16(text, 16));
            return cmd;
        }

        static byte[] LowEndianConvert(uint val) {
            return new byte[2] { (byte)(val >> 8), (byte)(val & 255) };
        }

        static byte[] GetDataLen(byte[] data) { //Count Data length
            return new byte[2];
        }

        static byte[] GetData() {
            //byte[] data = new byte[65517];
            return new byte[65517];
        }

        static byte[] GetCRC(byte[] message) {
            string stringcrc = "";
            for (int i = 0; i < message.Length; i++)
                stringcrc += Convert.ToString(message[i], 2).PadLeft(8, '0');

            return CalculateCRC(stringcrc);
        }

        static byte[] CalculateCRC(string input) {
            int resultLength = 16;
            string divisor = "1000000100001";

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

            string result = "";

            for (int i = dividend.Length - resultLength; i < dividend.Length; i++)
                result += dividend[i];

            byte[] CRC = new byte[2];
            for (int i = 0; i < 2; ++i)
                CRC[i] = Convert.ToByte(result.Substring(8 * i, 8), 2);

            return CRC;
        }

    }
}
