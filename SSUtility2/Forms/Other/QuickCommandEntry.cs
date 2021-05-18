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
        }

        private void b_Done_Click(object sender, EventArgs e) {
            if (rtb_Entry.Text.Length == 0) {
                return;
            }

            if (customCommand) {
                CustomScriptCommands.QuickCommand(rtb_Entry.Text, false);
                InfoPanel.i.UpdateNext();
                this.Close();
            } else {
                if (int.TryParse(rtb_Entry.Text, out int output)) {
                    CustomScriptCommands.QuickCommand(command + " " + output.ToString(), false);
                    this.Close();
                }
            }

        }

    }
}
