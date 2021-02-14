using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class ResponseLog : Form {

        public ResponseLog() {
            InitializeComponent();
        }

        private void b_RL_Clear_Click(object sender, EventArgs e) {
            bool clear = MainForm.ShowPopup("Are you sure you want to clear the response log?", "Clear Response Log", "", false);
            if(clear)
                tB_Log.Clear();
        }

        private void b_RL_Save_Click(object sender, EventArgs e) {
            PelcoD.SaveScript(tB_Log.Lines, "ResponseLog");
        }

        private void ResponseLog_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        public void AddText(string text, string sender) {
            string finalText = text;
            if(check_Timestamp.Checked)
                finalText = "[" + sender + " at " + DateTime.Now + "]: " + text;
            tB_Log.AppendText(finalText + "\n");
        }

    }
}
