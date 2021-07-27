using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class QuickCommandEntry : Form {

        string command;
        bool customCommand;

        public QuickCommandEntry(string com, string labelText, bool custom = false) {
            InitializeComponent();
            Location = MainForm.m.Location;
            command = com;
            customCommand = custom;
            l_EntryInfo.Text = labelText;
            Show();
            BringToFront();
            tB_Entry.Focus();
        }

        private void b_Done_Click(object sender, EventArgs e) {
            Send();
        }

        void Send() {
            string text = tB_Entry.Text;
            if (text.Length == 0)
                return;

            if (customCommand)
                CustomScriptCommands.QuickCommand(text, false);
            else
                if (int.TryParse(text, out int output))
                    CustomScriptCommands.QuickCommand(command + " " + output.ToString(), false);

            InfoPanel.i.UpdateNext();
            tB_Entry.Text = "";
            this.Close();
        }

        private void b_CommandList_Click(object sender, EventArgs e) {
            MainForm.m.clw.ShowWindow();
        }

        private void tB_Entry_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                Send();
        }
    }
}
