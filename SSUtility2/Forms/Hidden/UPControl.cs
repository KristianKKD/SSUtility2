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
            SendUP("1234");
        }

        static uint incrementalCounter = 0;
        static int messagePos = 0;

        public static void SendUP(string text) {
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
                byte[] message = new byte[65535]; //18 for debug, 65535 for full

                AddToMessage(message, SYNC);
                AddToMessage(message, FID);
                AddToMessage(message, TIME);
                AddToMessage(message, XT);
                AddToMessage(message, CMD);
                AddToMessage(message, DATALEN);
                AddToMessage(message, DATA);

                var result = Crc16.ComputeChecksum(message);
                byte[] CRC = BitConverter.GetBytes(result);

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

                //l_Send.Text = s;
                Console.WriteLine(s);
            } catch (Exception e) {
                Console.WriteLine("FAIL\n" + e.ToString());
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
            var temp = BitConverter.GetBytes(DateTimeOffset.Now.ToUnixTimeSeconds());
            for (int i = 0; i < 4; i++)
                time[i] = temp[i];

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

        public static byte[] HexToBytes(string input) {
            byte[] result = new byte[input.Length / 2];
            for (int i = 0; i < result.Length; i++)
                result[i] = Convert.ToByte(input.Substring(2 * i, 2), 16);
            return result;
        }

        public static class Crc16
        {
            const ushort polynomial = 0x1021;
            static readonly ushort[] table = new ushort[256];

            public static ushort ComputeChecksum(byte[] bytes) {
                ushort crc = 0;
                for (int i = 0; i < bytes.Length; ++i) {
                    byte index = unchecked((byte)(crc ^ bytes[i]));
                    crc = (ushort)((crc >> 8) ^ table[index]);
                }
                return crc;
            }

            public static string ToBinary(byte data) {
                return string.Join(" ", Convert.ToString(data, 2).PadLeft(8, '0'));
            }

            static Crc16() {
                ushort value;
                ushort temp;
                for (ushort i = 0; i < table.Length; ++i) {
                    value = 0;
                    temp = i;
                    for (byte j = 0; j < 8; ++j) {
                        if (((value ^ temp) & 0x0001) != 0) {
                            value = (ushort)((value >> 1) ^ polynomial);
                        } else {
                            value >>= 1;
                        }
                        temp >>= 1;
                    }
                    table[i] = value;
                }
            }
        }

    }
}
