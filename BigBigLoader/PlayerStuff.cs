using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye;

namespace BigBigLoader {

    class PlayerStuff {

        static Stream s;

        public async static Task EnableControls(Control c, bool on) {
            if (on) {
                c.Show();
            } else {
                c.Hide();
            }
            c.Enabled = on;
        }

        public async static Task PlayStreamAsync(WebEye.StreamControl.WinForms.StreamControl st, string adr) {
            Uri u;
            try {
                u = new Uri(adr);
            } catch {
                MessageBox.Show("Address invalid!");
                return;
            }
            try {
                s = Stream.FromUri(u);
                st.AttachStream(s);
                s.Start();
            } catch {
                MessageBox.Show("Failed to start stream!");
                return;
            }
            MainForm.lastAdr = adr;
        }

        public static void PauseStream(WebEye.StreamControl.WinForms.StreamControl st) {
            st.DetachStream();
            s.Stop();
        }

    }
}
