﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;

//Big credit to Mathew Sachin for the majority of the code, can be found here:
//https://stackoverflow.com/questions/4068414/how-to-capture-screen-to-be-video-using-c-sharp-net

namespace SSUtility2 {

    //https://stackoverflow.com/questions/67393857/how-to-record-video-playing-on-a-picturebox

    public class Record {

        public Record(string filename, int FrameRate, int Quality, Panel player) {
            FileName = filename;
            FramesPerSecond = FrameRate;

            Codec = SharpAvi.KnownFourCCs.Codecs.MotionJpeg;
            this.Quality = Quality;

            if (player != null) {
                Height = player.Height;
                Width = player.Width;
                Rectangle rec = player.RectangleToScreen(player.ClientRectangle);
                pos = rec.Location;
            } else {
                Height = MainForm.m.Height - 11;
                Width = MainForm.m.Width - 12; 
                pos = new Point(MainForm.m.Location.X + 6, MainForm.m.Location.Y + 5);
            }
        }

        string FileName;
        public int FramesPerSecond, Quality;
        FourCC Codec;

        public int Height {
            get; set;
        }

        public int Width {
            get; set;
        }

        public Point pos {
            get; set;
        }


        public AviWriter CreateAviWriter() {
            return new AviWriter(FileName) {
                FramesPerSecond = FramesPerSecond,
                EmitIndex1 = true,
            };
        }

        public IAviVideoStream CreateVideoStream(AviWriter writer) {
            // Select encoder type based on FOURCC of codec
            if (Codec == KnownFourCCs.Codecs.Uncompressed)
                return writer.AddUncompressedVideoStream(Width, Height);
            else if (Codec == KnownFourCCs.Codecs.MotionJpeg)
                return writer.AddMotionJpegVideoStream(Width, Height, Quality);
            else {
                return writer.AddMpeg4VideoStream(Width, Height, (double)writer.FramesPerSecond,
                    quality: Quality,
                    codec: Codec,
                    forceSingleThreadedAccess: true);
            }
        }
    }

    public class Recorder : IDisposable {
        #region Fields
        AviWriter writer;
        Record Params;
        IAviVideoStream videoStream;
        Thread screenThread;
        ManualResetEvent stopThread = new ManualResetEvent(false);
        #endregion

        public Recorder(Record Params) {
            this.Params = Params;

            // Create AVI writer and specify FPS
            writer = Params.CreateAviWriter();

            // Create video stream
            videoStream = Params.CreateVideoStream(writer);
            // Set only name. Other properties were when creating stream, 
            // either explicitly by arguments or implicitly by the encoder used
            videoStream.Name = "SilentSentinelRecording";

            screenThread = new Thread(RecordScreen) {
                Name = typeof(Recorder).Name + ".RecordScreen",
                IsBackground = true
            };

            screenThread.Start();
        }

        public void Dispose() {
            stopThread.Set();
            screenThread.Join();

            // Close writer: the remaining data is written to a file and file is closed
            writer.Close();

            stopThread.Dispose();
        }

        void RecordScreen() {
            var frameInterval = TimeSpan.FromSeconds(1 / (double)writer.FramesPerSecond);
            var buffer = new byte[Params.Width * Params.Height * 4];
            Task videoWriteTask = null;
            var timeTillNextFrame = TimeSpan.Zero;

            while (!stopThread.WaitOne(timeTillNextFrame)) {
                var timestamp = DateTime.Now;

                Screenshot(buffer);

                // Wait for the previous frame is written
                videoWriteTask?.Wait();

                // Start asynchronous (encoding and) writing of the new frame
                videoWriteTask = videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);

                timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
                if (timeTillNextFrame < TimeSpan.Zero)
                    timeTillNextFrame = TimeSpan.Zero;
            }

            // Wait for the last frame is written
            videoWriteTask?.Wait();
        }

        public void Screenshot(byte[] Buffer) {
            using (var BMP = new Bitmap(Params.Width, Params.Height)) {
                using (var g = Graphics.FromImage(BMP)) {
                    g.CopyFromScreen(Params.pos, Point.Empty, new Size(Params.Width, Params.Height), CopyPixelOperation.SourceCopy);

                    g.Flush();

                    var bits = BMP.LockBits(new Rectangle(0, 0, Params.Width, Params.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                    Marshal.Copy(bits.Scan0, Buffer, 0, Buffer.Length);
                    BMP.UnlockBits(bits);
                }
            }
        }

    }
}
