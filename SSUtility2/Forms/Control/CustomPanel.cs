using System;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class CustomPanel : Form {

        public Panel myPanel;

        public CustomPanel() {
            InitializeComponent();
        }

        private void b_1_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_1.Text);
        }

        private void b_2_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_2.Text);
        }

        private void b_3_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_3.Text);
        }

        private void b_4_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_4.Text);
        }

        private void b_5_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_5.Text);
        }

        private void b_6_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_6.Text);
        }

        private void b_7_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_7.Text);
        }

        private void b_8_Click(object sender, EventArgs e) {
            CustomScriptCommands.QuickCommand(MainForm.m.setPage.tB_Custom_8.Text);
        }
    }
}
