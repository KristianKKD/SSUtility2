using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class InfoPanel : Form {

        public InfoPanel() {
            InitializeComponent();
        }

        private Timer UpdateTimer;
        public Detached d;

        public void InitTimer() {
            UpdateTimer = new Timer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Interval = int.Parse(ConfigControl.updateMs);
            UpdateTimer.Enabled = true;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            UpdateAll();
        }

        async Task UpdateAll() {
            //await GetData();

            UpdatePan();
            UpdateTilt();
            UpdateFOV();
        }

        int pan = 0;
        int tilt = 0;
        int fov = 0;
        async Task GetData() {
            GetPan();
            GetTilt();
            GetFOV();
            
        }

        async Task<string> ReadResult() {
            string result = CameraCommunicate.StringFromSock(d.GetCombined().Host, d.GetCombined().Port.ToString(), null).Result;
            return result;
        }

        async Task GetPan() {
            await CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x51, 0x00, 0x00, 0x52 }, null);
            ReadResult();
        }

        async Task GetTilt() {
            await CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x53, 0x00, 0x00, 0x54 }, null);
            ReadResult();
        }

        async Task GetFOV() {
        
        }

        async Task UpdatePan() {
            l_Pan.Text = "PAN:" + pan.ToString() + "°";
        }

        async Task UpdateTilt() {
            l_Tilt.Text = "TILT:" + tilt.ToString() + "°";
        }

        async Task UpdateFOV() {
            l_FOV.Text = "FOV:" /* receive function */;
        }

    }
}
