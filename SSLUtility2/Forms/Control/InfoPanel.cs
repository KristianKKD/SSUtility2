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

        public void InitTimer() {
            UpdateTimer = new Timer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Interval = int.Parse(ConfigControl.updateMs);
            UpdateTimer.Enabled = true;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            UpdatePan();
            UpdateTilt();
            UpdateFOV();
        }

        void UpdatePan() {
            l_Pan.Text = "PAN:" /* + receive function */ + "°";
        }

        void UpdateTilt() {
            l_Tilt.Text = "TILT:" /* receive function */ + "°";
        }

        void UpdateFOV() {
            l_FOV.Text = "FOV:" /* receive function */ +  "°";
        }

    }
}
