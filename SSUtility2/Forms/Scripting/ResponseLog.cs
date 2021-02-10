using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class ResponseLog : Form {

        public string myText;

        public ResponseLog() {
            InitializeComponent();
        }

        private void b_RL_Clear_Click(object sender, EventArgs e) {
            bool clear = MainForm.ShowPopup("Are you sure you want to clear the response log?", "Clear Response Log", "", false);
            if(clear)
                rtb_Log.Clear();
        }

        private void b_RL_Save_Click(object sender, EventArgs e) {
            PelcoD.SaveScript(rtb_Log.Lines, "ResponseLog");
        }

        private void ResponseLog_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void ResponseLog_VisibleChanged(object sender, EventArgs e) {
            rtb_Log.Text = myText;
        }

    }
}
