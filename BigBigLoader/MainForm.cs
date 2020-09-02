/*
 * Created by SharpDevelop.
 * User: Alistair
 * Date: 17/03/2018
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
/*
 * Based on ManagePTZ2 by Alistair Windram, with amendments by Filip Ionita
 * Form layout modelled on SSUTILITY Firmware tab for continuity
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBigLoader
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        // Public variable declarations

        D protocol = new D();
        public static MainForm m;

        public static string config = "config.txt";
        public static string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SSUtility\";
        public static string scFolder = appFolder + @"Screenshots\";
        private bool isPaused;
        public static string lastAdr;

        public static byte Address;
        public static byte CheckSum;
        public static byte Command1, Command2, Data1, Data2;
        private readonly byte STX = 0xFF;
        public int camno = 1;   // Default camera number (1 for now)
        public bool camisthere = false; // True if camera has replied to SSCP query
        public int waitval = 0; // Wait n millisecs before sending next protocol packet
        public int waitresponseval = 0; // Wait for n bytes of response packet
        public int readtimeout = 1000;  // Standard read timeout of 1000 millisecs (see #Port.ReadTimeout:n)
        public int[] rawbuf = new int[80];  // Buffer for current protocol line
        public int rawlen;  // Length of current protocol line
        public long whencmdsent;    // Stopwatch value when last command was sent
        public int replylen = 0;    // Length of last serial port reply (in bytes)
        public byte[] replybuf = new byte[128]; // Buffer for serial port replies
        public string replyerrmsg;  // Last reply error
        public string hexfilefilename;  // Filename of current hex file
        public string hexfilesafefilename;  // Safe filename of current hex file
        public string hexfilepath;  // Path to current hex file
        public string hexfilefilter;    // Filter for current hex file types
        public string[] hexfilelines;   // Content of hex file
        public int hexfileformat = 1;   // Expected is encrypted (1); alternative is unencrypted (0)
        public int hexfilestartaddress = 0x8000;    // Expected start address
        public int hexfileendaddress = 0x8000;  // Expected much bigger than this
        public int hexfilelength = 0;   // Expected non-zero
        public int hexfilenblocks = 0;  // Number of blocks in hex file
        public int currentblock = 0;    // Current block being transferred
        public uint hexfiledatachecksum = 0;    // Gets checksum of hex file data (assuming unencrypted)
        public string hexfilechecksum;
        public bool loadit = false; // Firmware upload is not running
        public bool pauseit = false;     //Pause upload
        public bool EscapeWasPressed = false;   // Whether Escape was pressed during firmware upload
        public Stopwatch mystopwatch1;  //Run Script Stopwatch
        public Stopwatch mystopwatch2;  //Pause Script Sto
        public string cts;      //CurrentTimeStamp
        public bool debugSSCP = false;
        public bool isactive = false;   // true if we have an active main firmware, false if not
                                        //string oldroline; 		// Temp buffer saver
        static readonly uint[] crc_table = new uint[256] {
            0x00, 0x25, 0x4A, 0x6F, 0x94, 0xB1, 0xDE, 0xFB,
            0x0D, 0x28, 0x47, 0x62, 0x99, 0xBC, 0xD3, 0xF6,
            0x1A, 0x3F, 0x50, 0x75, 0x8E, 0xAB, 0xC4, 0xE1,
            0x17, 0x32, 0x5D, 0x78, 0x83, 0xA6, 0xC9, 0xEC,
            0x34, 0x11, 0x7E, 0x5B, 0xA0, 0x85, 0xEA, 0xCF,
            0x39, 0x1C, 0x73, 0x56, 0xAD, 0x88, 0xE7, 0xC2,
            0x2E, 0x0B, 0x64, 0x41, 0xBA, 0x9F, 0xF0, 0xD5,
            0x23, 0x06, 0x69, 0x4C, 0xB7, 0x92, 0xFD, 0xD8,
            0x68, 0x4D, 0x22, 0x07, 0xFC, 0xD9, 0xB6, 0x93,
            0x65, 0x40, 0x2F, 0x0A, 0xF1, 0xD4, 0xBB, 0x9E,
            0x72, 0x57, 0x38, 0x1D, 0xE6, 0xC3, 0xAC, 0x89,
            0x7F, 0x5A, 0x35, 0x10, 0xEB, 0xCE, 0xA1, 0x84,
            0x5C, 0x79, 0x16, 0x33, 0xC8, 0xED, 0x82, 0xA7,
            0x51, 0x74, 0x1B, 0x3E, 0xC5, 0xE0, 0x8F, 0xAA,
            0x46, 0x63, 0x0C, 0x29, 0xD2, 0xF7, 0x98, 0xBD,
            0x4B, 0x6E, 0x01, 0x24, 0xDF, 0xFA, 0x95, 0xB0,
            0xD0, 0xF5, 0x9A, 0xBF, 0x44, 0x61, 0x0E, 0x2B,
            0xDD, 0xF8, 0x97, 0xB2, 0x49, 0x6C, 0x03, 0x26,
            0xCA, 0xEF, 0x80, 0xA5, 0x5E, 0x7B, 0x14, 0x31,
            0xC7, 0xE2, 0x8D, 0xA8, 0x53, 0x76, 0x19, 0x3C,
            0xE4, 0xC1, 0xAE, 0x8B, 0x70, 0x55, 0x3A, 0x1F,
            0xE9, 0xCC, 0xA3, 0x86, 0x7D, 0x58, 0x37, 0x12,
            0xFE, 0xDB, 0xB4, 0x91, 0x6A, 0x4F, 0x20, 0x05,
            0xF3, 0xD6, 0xB9, 0x9C, 0x67, 0x42, 0x2D, 0x08,
            0xB8, 0x9D, 0xF2, 0xD7, 0x2C, 0x09, 0x66, 0x43,
            0xB5, 0x90, 0xFF, 0xDA, 0x21, 0x04, 0x6B, 0x4E,
            0xA2, 0x87, 0xE8, 0xCD, 0x36, 0x13, 0x7C, 0x59,
            0xAF, 0x8A, 0xE5, 0xC0, 0x3B, 0x1E, 0x71, 0x54,
            0x8C, 0xA9, 0xC6, 0xE3, 0x18, 0x3D, 0x52, 0x77,
            0x81, 0xA4, 0xCB, 0xEE, 0x15, 0x30, 0x5F, 0x7A,
            0x96, 0xB3, 0xDC, 0xF9, 0x02, 0x27, 0x48, 0x6D,
            0x9B, 0xBE, 0xD1, 0xF4, 0x0F, 0x2A, 0x45, 0x60
            };



        public MainForm()
        {
            m = this;
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            // Catch MainForm closing event to close Serial Port if it is Open
            this.FormClosing += new FormClosingEventHandler(MainForm_Closing);

            StartupStuff();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            string[] stdspeeds = { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            string[] loadspeeds = { "9600", "19200", "38400", "57600", "115200", "230400" };


            int i;
            for (i = 0; i < 7; i++)
            {
                this.SpeedcomboBox.Items.Add(stdspeeds[i]);
            }
            this.SpeedcomboBox.SelectedIndex = 2;   // Default contact speed is 9600
            for (i = 0; i < 6; i++)
            {
                this.LoadSpeedcomboBox.Items.Add(loadspeeds[i]);
            }
            this.LoadSpeedcomboBox.SelectedIndex = 3;   // Default load speed is 57600
                                                        //foreach (String portName in System.IO.Ports.SerialPort.GetPortNames()) {
                                                        //	this.PortcomboBox.Items.Add(portName);
                                                        //}
                                                        //this.PortcomboBox.SelectedIndex = 0;
            mystopwatch1 = System.Diagnostics.Stopwatch.StartNew(); // Get stopwatch object and init and start
        } // end of MainForm()

        private void MainForm_Closing(Object sender, FormClosingEventArgs e)
        {
            if (this.serialPort1.IsOpen)
            {
                this.serialPort1.Close();
                //System.Windows.Forms.MessageBox.Show("Closed Serial Port on Application Finish");
            }
        } // end of MainForm_Closing()

        private int SSCPChecksum(byte[] cmd, int len)
        {
            int i;
            int rv = 0;
            if (len < 3 || cmd[0] != 0x02 || cmd[len - 1] != 0x03) return rv;
            for (i = 1; i < len - 1; i++)
            {
                rv = (int)crc_table[rv ^ (int)cmd[i]];
            }
            return rv;
        } // end of SSCPChecksum()

        private int Char2Hex(char c)
        {
            int rv;
            rv = "0123456789ABCDEF".IndexOf(Char.ToUpper(c));
            return rv;
        }

        private int HexByte(char c1, char c2)
        {
            int rv;
            rv = Char2Hex(c1) * 16 + Char2Hex(c2);
            return rv;
        } // end of HexByte()

        private int SSCPHexValue(int start, int length)
        {
            int rv = 0;
            int i;
            length += start;
            for (i = start; i < length; i++) rv = (rv << 4) + Char2Hex((char)replybuf[i]);
            return rv;
        } // end of SSCPHexValue()

        private void escapeProtocol()
        {
            var tmpbytearray = new byte[] { Convert.ToByte(27) };
            this.serialPort1.Write(tmpbytearray, 0, 1); // Write Esc
            System.Threading.Thread.Sleep(1000);
        } // end of escapeProtocol()

        private int sendSSCP(byte cmd1, byte cmd2, string data, bool expectreply, int discardto, int sendto, int ackto, int replyto)
        {
            string tpkt;
            string tcmd1;
            string tcksum;
            int tpktlen;
            int ms2send;
            int rv = -1;    // Default result is Fail code
            int i;
            int j;
            int timeout = 0;    // variable timeout wherever needed
            int retries = 5;    // 5 retries
            int ret = 0;
            int tnb = 0;
            int nb = 0;
            long tt;        // Total ms that this stage took
            if (cmd1 != 0) tcmd1 = cmd1.ToString("X2");
            else tcmd1 = "";
            camno = (int)this.CamNoUpDown.Value;    // Remember current camera number
                                                    // *** 27-Apr-2018 We now implement 300ms timeout and 5 retries
            if (!this.serialPort1.IsOpen) return rv;
            // Format SSCP packet and calc checksum
            tpkt = "\x02" + camno.ToString("X2") + tcmd1 + cmd2.ToString("X2") + data + "\x03";
            byte[] btpkt = System.Text.Encoding.UTF8.GetBytes(tpkt);
            tpktlen = btpkt.Length + 2; // How many bytes in packet
            tcksum = SSCPChecksum(btpkt, btpkt.Length).ToString("X2");
            ms2send = (tpktlen * 9600) / this.serialPort1.BaudRate + 1; // Estimate how many ms to send packet
                                                                        // For first attempt just discard for 5 ms; for remaining tries discard for discardto ms
            timeout = 5;
            for (ret = 0; ret < retries; ret++)
            {
                // Discard anything in port receive buffer for up to discardto ms
                if (debugSSCP)
                {
                    nb = ret + 1;
                    this.LogtextBox.AppendText("SSCP attempt " + nb.ToString() + Environment.NewLine);
                }
                this.mystopwatch1.Restart();
                tnb = 0;    // How many bytes were discarded
                while (this.mystopwatch1.ElapsedMilliseconds < timeout)
                {
                    nb = this.serialPort1.BytesToRead;
                    if (nb > 0)
                    {
                        tnb = tnb + nb; // Count bytes discarded
                        this.serialPort1.ReadExisting();
                    }
                }
                this.mystopwatch1.Stop();
                if (debugSSCP && tnb > 0)
                {
                    this.LogtextBox.AppendText(ret.ToString() + ": SSCP discarded " + tnb.ToString() + " bytes" + Environment.NewLine);
                }
                // Write SSCP packet
                this.serialPort1.Write(tpkt);
                // Show SSCP sent packet in Log pane
                if (debugSSCP)
                {
                    this.LogtextBox.AppendText("SSCP sent ");
                    for (i = 0; i < btpkt.Length; i++)
                    {
                        j = btpkt[i];
                        if (j < 33 || j > 126) this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
                        else this.LogtextBox.AppendText(((char)j).ToString());
                    }
                    //this.serialPort1.Write(SSCPChecksum(btpkt,btpkt.Length).ToString("X2"));
                    this.LogtextBox.AppendText(tcksum + Environment.NewLine);
                }
                this.serialPort1.Write(tcksum);
                // Wait for ms2send ms for packet to go
                this.mystopwatch1.Restart();
                while (this.mystopwatch1.ElapsedMilliseconds < ms2send)
                {
                }
                tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
                this.mystopwatch1.Stop();
                this.mystopwatch1.Restart();
                while (this.mystopwatch1.ElapsedMilliseconds < sendto)
                {
                    if (this.serialPort1.BytesToWrite < 2) break;
                }
                tt = tt + this.mystopwatch1.ElapsedMilliseconds;    // How long it took overall
                this.mystopwatch1.Stop();
                nb = this.serialPort1.BytesToWrite;
                if (nb > 1)
                { // Failed to write packet within allowed time
                    if (debugSSCP)
                    {
                        this.LogtextBox.AppendText("Write not finished after " + sendto.ToString() + "ms; " + nb.ToString() + " bytes to go" + Environment.NewLine);
                    }
                    continue;   // Failed to write the packet within sendto ms
                }
                else
                {
                    if (debugSSCP)
                    {
                        this.LogtextBox.AppendText("Write took " + tt.ToString() + "ms" + Environment.NewLine);
                    }
                }
                // Now we need to wait for a reply (maybe)
                // If we do not get a protocol packet we should get Ack or Nak
                replylen = 0;   // Clear reply buffer
                replyerrmsg = null; // Clear reply error message
                                    //while (replylen < 1) {
                                    //	try {
                                    //		replylen = this.serialPort1.Read(replybuf,0,1);
                                    //	}
                                    //	catch (TimeoutException ex)
                                    //	{
                                    //		replyerrmsg = ex.Message;
                                    //		break;
                                    //	}
                                    //} // end of while waiting for 1st reply char
                                    // We now use a stopwatch and expect a byte to return within ackto ms
                this.mystopwatch1.Restart();
                replybuf[0] = 0;    // Init 1st byte of replybuf to 0 meaning no reply
                while (this.mystopwatch1.ElapsedMilliseconds < ackto)
                {
                    if (this.serialPort1.BytesToRead > 0)
                    {
                        replybuf[0] = (byte)this.serialPort1.ReadByte();
                        replylen = 1;
                        break;
                    }
                }
                tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
                this.mystopwatch1.Stop();
                // Fake reply
                //if (cmd2==0)
                //{ // Fake Boot Loader version response
                //	tpkt = "\x02" + camno.ToString("X2") + "FF00no boot loader" + "\x03" + "AB";
                //}
                //else
                //{ // Fake Serial Number response
                //	tpkt = "\x02" + camno.ToString("X2") + "FF" + cmd2.ToString("X2") + "01023456" + "\x03" + "CD";
                //}
                //replybuf = System.Text.Encoding.UTF8.GetBytes(tpkt);
                //replylen = replybuf.Length;
                if (debugSSCP)
                { // We either have nothing or 1 byte
                    this.LogtextBox.AppendText("SSCP rcvd ");
                    if (replylen < 1) this.LogtextBox.AppendText("nothing after " + tt.ToString() + "ms" + Environment.NewLine);
                    else
                    {
                        j = replybuf[0];
                        if (j < 33 || j > 126) this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
                        else this.LogtextBox.AppendText(((char)j).ToString());
                        this.LogtextBox.AppendText(" after " + tt.ToString() + "ms" + Environment.NewLine);
                    }
                }
                //return 0;
                // Did we get a reply or did we time out??
                //if (replylen < 1)	return rv;	// Failed to get reply
                if (replylen < 1) continue; // Failed to get reply
                rv = replybuf[0];
                if (rv == 2)
                {
                    rv = 0; // No Ack or Nak but got reply packet - leave Stx at start
                }
                else
                {
                    replylen = 0;   // Lose Ack or Nak from buffer but we will return its code
                }
                // If we saw a Stx we try to read a reply packet (whether or not we were expecting one
                if (replylen == 0 && !expectreply) return rv;
                //while (replylen < 128) {
                //	try {
                //		replylen = replylen + this.serialPort1.Read(replybuf,replylen,128-replylen);
                //		// We now call a halt if we have Etx as 3rd last char in replybuf[]
                //		if (replylen>7 && replybuf[replylen-3]==0x03)	break;
                //	}
                //	catch (TimeoutException ex)
                //	{
                //		replyerrmsg = ex.Message;
                //		break;
                //	}
                //}
                // We now use a stopwatch and expect a reply to return within replyto ms
                this.mystopwatch1.Restart();
                while (this.mystopwatch1.ElapsedMilliseconds < replyto)
                {
                    if (this.serialPort1.BytesToRead > 0)
                    {
                        replybuf[replylen] = (byte)this.serialPort1.ReadByte(); // Read 1 byte at a time
                        replylen++;
                        // We now call a halt if we have Etx as 3rd last char in replybuf[]
                        if (replylen > 7 && replybuf[replylen - 3] == 0x03) break;
                    }
                }
                tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
                this.mystopwatch1.Stop();
                if (debugSSCP)
                {
                    this.LogtextBox.AppendText("SSCP rcvd ");
                    if (replylen < 1) this.LogtextBox.AppendText("nothing after " + tt.ToString() + "ms" + Environment.NewLine);
                    else
                    {
                        for (i = 0; i < replylen; i++)
                        {
                            j = replybuf[i];
                            if (j < 33 || j > 126) this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
                            else this.LogtextBox.AppendText(((char)j).ToString());
                        }
                        this.LogtextBox.AppendText(Environment.NewLine);
                        this.LogtextBox.AppendText(" Reply took " + tt.ToString() + "ms" + Environment.NewLine);
                    }
                }
                if (replylen < 8 || replybuf[replylen - 3] != 0x03) rv = -1;
                if (rv == 6 || (expectreply && rv == 0)) return rv;
                timeout = discardto;    // We will use this timeout for discard next time
            } // end of for (ret=0;... trying up to 5 times
            return rv;
        } // end of sendSSCP()

        private int ClassifyFWLine(string roline)
        { // Return line type byte value (0-3 or 9) or -1 if not recognised
          //string sline;
            int rv = -1;
            int datalen;
            int linetype;
            if (String.IsNullOrWhiteSpace(roline)) return (rv); // Blank line
            if (roline[0] != ':') return (rv);      // Bad start
            if (roline.Length < 11) return (rv);    // Too short
            datalen = HexByte(roline[1], roline[2]);
            linetype = HexByte(roline[7], roline[8]);
            //if (roline.Length != (datalen + datalen + 11))	return(rv);	// Wrong length
            rv = linetype;
            return (rv);    // Return line type
        } // end of ClassifyFWLine()

        private string gethexfilelinedata(int addr)
        { // Given code address of start of line, return substring of code line that contains code
          // If we reach a non-code line at end of file, return an empty string
            int n;  // This will be the index in hexfilelines[] of the relevant code line
            string s;   // This will get the return substring
            n = (addr >> 4) + (addr >> 16) - 0x800;
            if (hexfilelines[n].Substring(0, 3) == ":10")
                s = hexfilelines[n].Substring(9, 32);
            else
                s = "";
            return s;
        } // end of gethexfilelinedata()

        private bool WriteFromBuffer(int addr, int length, int destaddr)
        {
            string s;
            int rv = -1;
            int i = 0;
            bool brv;
            statusStrip1.Show();
            // Keep buttons refreshed
            Application.DoEvents();
            while (i < length && !EscapeWasPressed)
            { // Transfer another 16 bytes of the current 4096 byte block
              // Build next 16-byte line
                s = gethexfilelinedata(addr + i);
                if (s.Length == 0)
                { // Reached end of file - fake that last block was sent OK
                  // Update status bar with progress
                    this.toolStripStatusLabel5.Text = "Off end of file";
                    this.statusStrip1.Refresh();
                    i = length;
                    rv = 0;
                    break;
                }
                s = destaddr.ToString("X4") + "10" + gethexfilelinedata(addr + i);
                // Update status bar with progress
                this.toolStripStatusLabel3.Text = i.ToString() + "/" + length.ToString();
                this.statusStrip1.Refresh();
                rv = sendSSCP((byte)0x7F, (byte)2, s, true, 300, 40, 50, 100);
                i += 16;
                destaddr += 16;
                // Break out if not Ack or just reply
                if (rv != 0 && rv != 6) break;
                // Keep buttons refreshed
                Application.DoEvents();
            } // end of while (i<length && ...
              // Now, if Abort button was pressed, just say Upload aborted
            if (EscapeWasPressed)
            {
                this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + "Upload aborted." + Environment.NewLine);
                brv = false;
            }
            else if (i >= length && (rv == 0 || rv == 6))
            {
                this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + i.ToString() + " bytes transferred." + Environment.NewLine);
                brv = true;
            }
            else
            {
                this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + "Failed after " + i.ToString() + " bytes of " + length.ToString() + Environment.NewLine);
                brv = false;
            }
            this.toolStripStatusLabel3.Text = "";
            this.statusStrip1.Refresh();
            return brv;
        } // end of WriteFromBuffer()

        private int WriteToFlash(int addr, int length)
        {
            string s;
            int rv;
            this.LogtextBox.AppendText("Flashed at " + addr.ToString("X5"));
            addr = addr >> 3;
            s = addr.ToString("X4") + length.ToString("X4");
            // Send Write To Flash message
            rv = sendSSCP((byte)0x7F, (byte)3, s, true, 100, 20, 500, 500);
            if ((rv == 0 || rv == 6) && replylen > 9)
                rv = HexByte((char)replybuf[7], (char)replybuf[8]);
            else
                rv = -1;
            this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
            return rv;
        } // end of WriteToFlash()

        private int EraseFlash(int addr, int length)
        {
            string s;
            int rv;
            length = addr + length;
            this.LogtextBox.AppendText("Erased " + addr.ToString("X5") + " to " + length.ToString("X5"));
            addr = addr >> 3;
            length = length >> 3;
            s = addr.ToString("X4") + length.ToString("X4");
            // Send Erase Flash message
            rv = sendSSCP((byte)0x7F, (byte)4, s, true, 100, 20, 50, 1000);
            if ((rv == 0 || rv == 6) && replylen > 9)
                rv = HexByte((char)replybuf[7], (char)replybuf[8]);
            else
                rv = -1;
            this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
            isactive = false;
            return rv;
        } // end of EraseFlash()

        private int ActivateFlash(int length)
        {
            string s;
            int rv;
            this.LogtextBox.AppendText("Activated " + length.ToString("X5"));
            length = length >> 3;
            s = length.ToString("X4");
            // Send Activate Flash message
            //rv = sendSSCP((byte)0x7F,(byte)5,s,true,100,20,1000,20);
            // It seems that BootLoader does not send a reply, only Ack
            rv = sendSSCP((byte)0x7F, (byte)5, s, false, 100, 20, 20, 0);
            //if ((rv==0 || rv==6) && replylen>9)
            //	rv = HexByte((char)replybuf[7],(char)replybuf[8]);
            if (rv != 0 && rv != 6)
                rv = -1;
            this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
            if (rv < 0) isactive = false;
            else isactive = true;
            return rv;
        } // end of ActivateFlash()

        private int ReadChecksum(int addr, int length)
        {
            string s;
            int rv;
            rv = addr + length;
            this.LogtextBox.AppendText("Checksum of " + addr.ToString("X5") + " to " + rv.ToString("X5"));
            addr = addr >> 3;
            length = length >> 3;
            s = addr.ToString("X4") + length.ToString("X4");
            // Send Do Checksum message - takes about 250 ms to get reply back for 112 block firmware
            rv = sendSSCP((byte)0x7F, (byte)7, s, true, 100, 20, 50, 300);
            if ((rv == 0 || rv == 6) && replylen > 15)
                rv = SSCPHexValue(7, 8);    // Get value of hex number at replybuf[7] 8 bytes long
            else
                rv = -1;
            this.LogtextBox.AppendText(", result=0x" + rv.ToString("X8") + Environment.NewLine);
            return rv;
        } // end of ReadChecksum()

        private void AnalyseFirmwareFile()
        { // Parse the firmware file contents in Textbox1 and setup stats vars
            int lastaddr = 0;
            int last64kblock = 0;
            int lno = 0;
            int val;
            int i;
            // Firmware file lines will be in one of the following formats:
            // Each line has ':' 2-dig-length 4-dig-addr 2-dig-type length_2-dig-bytes 2-dig-checksum
            // Type 00 content line 16 bytes at addr 8000 unencrypted (starts 18F09FE5)
            // :1080000018F09FE518F09FE518F09FE518F09FE540
            // Type 02 block address line 2 bytes new block at 1000 (i.e. 10000 on)
            // :020000021000EC
            // Type 03 start address line 4 bytes SA is 00008000
            // :040000030000800079
            // Type 01 end of file line 0 bytes
            // :00000001FF
            //
            // Encrypted files have first data line like so: (not starting 18F09FE5)
            // :108000004BE81483E262890370E503D7FB3A96419B
            // But Type 02 records are the same
            // At the end of the file, the Type 03 start address line is replaced by
            // Type 09 checksum line 4 bytes Checksum is 02A9C148
            // :0400000902A9C1483F
            // And Type 01 end of file line is the same
            // Start address is implied to be 00008000

            hexfiledatachecksum = 0;
            foreach (String roline in hexfilelines)
            {
                lno++;
                val = ClassifyFWLine(roline);
                if (val == 0)
                { // Data line
                    if (lno == 1 && roline.StartsWith(":1080000018F09FE5")) hexfileformat = 0;  // Unencrypted
                    lastaddr = HexByte(roline[3], roline[4]) * 256 + HexByte(roline[5], roline[6]); // Last addr value seen on data line
                    for (i = 9; i < 41; i = i + 2) hexfiledatachecksum = hexfiledatachecksum + (uint)HexByte(roline[i], roline[i + 1]);
                }
                else if (val == 2)
                { // Next 64K block line
                    last64kblock = Char2Hex(roline[9]); // Last 64K block number seen
                }
                else if (val == 9)
                {
                    hexfilechecksum = roline.Substring(9, 8);
                }
                else
                { // Anything else is bad or record at end of file
                    break;
                }
            } // end of for each line in textBox1
              //System.Windows.Forms.MessageBox.Show("Stopped Setup lno: " + lno.ToString() + " Val: " + val.ToString());
              // Update useful info vars from values gleaned from file
            hexfilestartaddress = 0x8000;
            hexfileendaddress = last64kblock * 65536 + lastaddr + 16;
            hexfilelength = hexfileendaddress - hexfilestartaddress;
        } // end of AnalyseFirmwareFile()

        /////////////////////////////////////

        private uint MakeAdr() {
            if (cB_IPCon_Selected.Text == "Daylight") {
                return 1;
            } else {
                return 2;
            }
        }

        private void Play(AxAXVLC.AxVLCPlugin2 player, string combinedUrl) {
            if (combinedUrl == "") {
                MessageBox.Show("Address is invalid!");
                return;
            }

            if (player.playlist.isPlaying == true) {
                player.playlist.stop();
                player.playlist.items.clear();
            }

            player.playlist.add(combinedUrl, null, ":network-caching=" + tB_PlayerL_Buffering.Text);
            player.playlist.next();
            player.playlist.play();
        }


        private void BrowseFolderButton(TextBox tb) {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK) {
                tb.Text = folderDlg.SelectedPath;
            }
        }

        private async Task ApplyAll() { //
            ConfigControl.Create(appFolder + config);
            MessageBox.Show("Applied settings to: " + appFolder + config);
        }

        void PTZMove(bool IsTilt, D.Tilt tilt = D.Tilt.Up, D.Pan pan = D.Pan.Left) {

            byte[] code;
            uint address = MakeAdr();
            uint speed = Convert.ToUInt32(tB_PTZ_Speed.Value);

            if (IsTilt) {
                code = protocol.CameraTilt(address, tilt, speed);
            } else {
                code = protocol.CameraPan(address, pan, speed);
            }

            CameraCommunicate.sendtoIPAsync(code);
        }

        void PTZZoom(D.Zoom dir) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraZoom(MakeAdr(), dir));
        }

        private async Task SaveSnap(AxAXVLC.AxVLCPlugin2 player) {
            var imagePath = scFolder + @"\Capture" + (Directory.GetFiles(scFolder).Length + 1) + ".jpg";

            Image bmp = new Bitmap(player.Width, player.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            Rectangle rec = player.RectangleToScreen(player.ClientRectangle);
            gfx.CopyFromScreen(rec.Location, Point.Empty, player.Size);

            bmp.Save(imagePath, ImageFormat.Jpeg);

            MessageBox.Show("Image saved : " + scFolder);
        }

        static void CheckCreateFile(string fileName, string folderName = null) {
            if (folderName != null) {
                if (!Directory.Exists(folderName)) {
                    Directory.CreateDirectory(folderName);
                }
            }
            if (fileName != null) {
                if (!File.Exists(appFolder + fileName)) {
                    if (appFolder + fileName == appFolder + config) {
                        ConfigControl.Create(appFolder + fileName);
                    }
                }
            }
        }

        async Task StartupStuff() {
            ConfigControl.SetDefaults();

            CheckCreateFile(config, appFolder);
            await ConfigControl.SearchForVarsAsync(appFolder + config);
            foreach (PathVariable v in ConfigControl.varList) {
                if (v.name == ConfigControl.ScreenshotFolderVar) {
                    scFolder = v.value;
                }
            }
            CheckCreateFile(config, scFolder);

            ApplySettingText();
        }

        public async Task ApplySettingText() {
            tB_Paths_sCFolder.Text = scFolder;
        }

        private void b_PlayerL_Play_Click(object sender, EventArgs e) {
            string combinedUrl;

            if (checkB_PlayerL_Manual.Checked) { //make a function to automatically grab these from gB_...
                string ipaddress = tB_PlayerL_Adr.Text; //is it possible? the variables need to be in an order
                string port = tB_PlayerL_Port.Text;
                string url = tB_PlayerL_RTSP.Text;
                string username = tB_PlayerL_Username.Text;
                string password = tB_PlayerL_Password.Text;

                combinedUrl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
            } else {
                combinedUrl = tB_PlayerL_SimpleAdr.Text;
            }

            Play(VLCPlayer_L, combinedUrl);
        }

        private void b_PlayerR_Play_Click(object sender, EventArgs e) {
            string combinedUrl;

            if (checkB_PlayerR_Manual.Checked) { //make a function to automatically grab these from gB_...
                string ipaddress = tB_PlayerR_Adr.Text; //is it possible? the variables need to be in an order
                string port = tB_PlayerR_Port.Text;
                string url = tB_PlayerR_RTSP.Text;
                string username = tB_PlayerR_Username.Text;
                string password = tB_PlayerR_Password.Text;

                combinedUrl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + "/" + url;
            } else {
                combinedUrl = tB_PlayerR_SimpleAdr.Text;
            }

            Play(VLCPlayer_R, combinedUrl);
        }

        private void OnFinishedTypingAdr(object sender, EventArgs e) {
            CameraCommunicate.Connect(m);
        }

        private void tB_IPCon_Adr_PreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                CameraCommunicate.Connect(m);
            }
        }

        private void b_PTZ_Up_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(true, D.Tilt.Up);
        }

        private void b_PTZ_Down_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(true, D.Tilt.Down);
        }

        private void b_PTZ_Left_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(false, D.Tilt.Null, D.Pan.Left);
        }

        private void b_PTZ_Right_MouseDown(object sender, MouseEventArgs e) {
            PTZMove(false, D.Tilt.Null, D.Pan.Right);
        }

        private void b_PTZ_ZoomPos_MouseDown(object sender, MouseEventArgs e) {
            PTZZoom(D.Zoom.Tele);
        }

        private void b_PTZ_ZoomNeg_MouseDown(object sender, MouseEventArgs e) {
            PTZZoom(D.Zoom.Wide);
        }

        private void b_PTZ_Any_MouseUp(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraStop(MakeAdr()));
        }

        private void b_Presets_Admin_MechMen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 });
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 });
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 });
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFF, 0x07 });
        }

        private void b_Presets_Admin_SetupMen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 });
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 });
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 });
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFE, 0x06 });
        }

        private void b_Presets_Admin_DebugToggle_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(MakeAdr(), 2, D.PresetAction.Goto));
        }

        private void tC_Control_KeyDown(object sender, KeyEventArgs e) {
            if (cB_IPCon_KeyboardCon.Checked == true) {
                uint address = MakeAdr();
                uint speed = Convert.ToUInt32(tB_PTZ_Speed.Value);
                byte[] code = null;

                switch (e.KeyCode) { //is there a command that accepts diagonal?
                    case Keys.Up:
                        code = protocol.CameraTilt(address, D.Tilt.Up, speed);
                        break;
                    case Keys.Down:
                        code = protocol.CameraTilt(address, D.Tilt.Down, speed);
                        break;
                    case Keys.Left:
                        code = protocol.CameraPan(address, D.Pan.Left, speed);
                        break;
                    case Keys.Right:
                        code = protocol.CameraPan(address, D.Pan.Right, speed);
                        break;
                    case Keys.Enter:
                        code = protocol.CameraZoom(address, D.Zoom.Tele);
                        break;
                    case Keys.Escape:
                        code = protocol.CameraZoom(address, D.Zoom.Wide);
                        break;
                }

                CameraCommunicate.sendtoIPAsync(code);
            }
        }

        private void tC_Control_KeyUp(object sender, KeyEventArgs e) { //change the way to control this
            if (cB_IPCon_KeyboardCon.Checked == true) {
                CameraCommunicate.sendtoIPAsync(protocol.CameraStop(MakeAdr()));
            }
        }

        private void b_PTZ_FocusPos_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraFocus(MakeAdr(), D.Focus.Far));
        }

        private void b_PTZ_FocusNeg_MouseDown(object sender, MouseEventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.CameraFocus(MakeAdr(), D.Focus.Near));
        }

        private void b_Presets_Daylight_Wiper_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 4, D.PresetAction.Goto));
        }

        private void b_Presets_Daylight_ColMono_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 3, D.PresetAction.Goto));
        }

        private void b_Presets_Daylight_AF_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 12, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_WhiteBlack_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 8, D.PresetAction.Goto));
        }

        private void b_Presets_Daylight_WDR_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 11, D.PresetAction.Goto));
        }

        private void b_Presets_Daylight_Stabilizer_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 19, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_AF_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 12, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_ICE_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 16, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_ICENeg_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 17, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_ICEPos_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 18, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_BrightNeg_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 176, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_BrightPos_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 177, D.PresetAction.Goto));
        }

        private void button31_Click(object sender, EventArgs e) { //"Contrast -"; {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 178, D.PresetAction.Goto));
        }

        private void button32_Click(object sender, EventArgs e) { //"Contrast +";
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 179, D.PresetAction.Goto));
        }

        private void b_Presets_SLG_SteadyGreen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 30, D.PresetAction.Goto));
        }

        private void b_Presets_SLG_FlashingGreen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 31, D.PresetAction.Goto));
        }

        private void b_Presets_SLG_SteadyRed_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 32, D.PresetAction.Goto));
        }

        private void b_Presets_SLG_FlashingRed_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 33, D.PresetAction.Goto)); 
        }

        private void b_Presets_SLG_FlashingWhite_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 34, D.PresetAction.Goto));
        }

        private void b_Presets_SLG_FlashingRG_Click(object sender, EventArgs e)  {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 35, D.PresetAction.Goto));
        }

        private void b_Presets_SLG_AllLightsOff_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 36, D.PresetAction.Goto));
        }

        private void b_Presets_Peak_SteadyLamp_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 188, D.PresetAction.Goto));
        }

        private void b_Presets_Peak_StrobeLamp_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 189, D.PresetAction.Goto));
        }

        private void Presets_Peak_LampOff_Click(object sender, EventArgs e)  {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 187, D.PresetAction.Goto));
        }

        private void b_Presets_Peak_ZoomIn_Click(object sender, EventArgs e)  {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 185, D.PresetAction.Goto));
        }

        private void b_Presets_Peak_ZoomOut_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 186, D.PresetAction.Goto));
        }

        private void b_Presets_Peak_StopZoom_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 184, D.PresetAction.Goto));
        }

        private void b_Presets_Thermal_NUC_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 175, D.PresetAction.Goto));
        }

        private void b_Presets_GoTo_Click(object sender, EventArgs e) {
            byte presetnumber = Convert.ToByte(tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(protocol.Preset(MakeAdr(), presetnumber, D.PresetAction.Goto));
        }

        private void b_Presets_Learn_Click(object sender, EventArgs e) {
            byte presetnumber = Convert.ToByte(tB_Presets_Number.Text);

            CameraCommunicate.sendtoIPAsync(protocol.Preset(MakeAdr(), presetnumber, D.PresetAction.Set));
        }

        private void cB_PlayerL_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enc = cB_PlayerL_Type.Text;
            string username = "";
            string password = "";
            string rtsp = "";

            if (enc == "IONodes - Daylight")
            {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_1:0/h264_1/onvif.stm";
            }
            else if (enc == "IONodes - Thermal")
            {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
            }
            else if (enc == "VIVOTEK")
            {
                username = "root";
                password = "root1234";
                rtsp = "live.sdp";
            }
            else if (enc == "BOSCH")
            {
                username = "service";
                password = "Service123!";
                rtsp = "";
            }


            tB_PlayerL_RTSP.Text = rtsp;
            tB_PlayerL_Username.Text = username;
            tB_PlayerL_Password.Text = password;

        }

        private void cB_PlayerR_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enc = cB_PlayerR_Type.Text;
            string username = "";
            string password = "";
            string rtsp = "";

            if (enc == "IONodes - Daylight")
            {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_1:0/h264_1/onvif.stm";
            }
            else if (enc == "IONodes - Thermal")
            {
                username = "admin";
                password = "admin";
                rtsp = "videoinput_2:0/h264_1/onvif.stm";
            }
            else if (enc == "VIVOTEK")
            {
                username = "root";
                password = "root1234";
                rtsp = "live.sdp";
            }
            else if (enc == "BOSCH")
            {
                username = "service";
                password = "Service123!";
                rtsp = "";
            }

            tB_PlayerR_RTSP.Text = rtsp;
            tB_PlayerR_Username.Text = username;
            tB_PlayerR_Password.Text = password;
        }

        private void b_PlayerL_SaveSnap_Click(object sender, EventArgs e) {
            SaveSnap(VLCPlayer_L);
        }
        private void b_PlayerR_SaveSnap_Click(object sender, EventArgs e) {
            SaveSnap(VLCPlayer_R);
        }

        private void cB_IPCon_Type_SelectedIndexChanged(object sender, EventArgs e) {
            string control = cB_IPCon_Type.Text;
            string port = "";

            if (control == "Encoder")
            {
                port = "6791";
            }
            else if (control == "MOXA nPort")
            {
                port = "4001";
            }

            tB_IPCon_Port.Text = port;
        }

        private void checkB_PlayerL_Manual_CheckedChanged(object sendeL, EventArgs e) {
            ExtendOptions(checkB_PlayerL_Manual.Checked, gB_PlayerL_Extended, gB_PlayerL_Simple);
        }
        private void checkB_PlayerR_Manual_CheckedChanged(object sender, EventArgs e) {
            ExtendOptions(checkB_PlayerR_Manual.Checked, gB_PlayerR_Extended, gB_PlayerR_Simple);
        }

        void ExtendOptions(bool check, GroupBox gbExt, GroupBox gbSim) {
            if (check) {
                gbSim.Hide();
                gbExt.Show();
            } else {
                gbExt.Hide();
                gbSim.Show();
            }
        }

        private void OnFinishedTypingScFolder(object sender, EventArgs e) {
            if (tB_Paths_sCFolder.Text.Length < 1) {
                tB_Paths_sCFolder.Text = appFolder;
                return;
            }
            if (ConfigControl.CheckIfExists(tB_Paths_sCFolder, l_Paths_sCCheck).Result) {
                scFolder = tB_Paths_sCFolder.Text;
            }
        }

        private void b_Paths_sCBrowse_Click(object sender, EventArgs e) {
            BrowseFolderButton(tB_Paths_sCFolder);
        }
        
        private void b_Settings_Apply_Click(object sender, EventArgs e) {
            ApplyAll();
        }

        private void b_Settings_Default_Click(object sender, EventArgs e) {
            scFolder = ConfigControl.DefScFolder;
            ApplySettingText();
        }


    } // end of class MainForm
} // end of namespace BigBigLoader
