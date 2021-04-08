using System;
using System.Linq;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class CustomPanel : Form {

        public Panel myPanel;

        Button[] buttonArray;

        public CustomPanel() {
            InitializeComponent();
            buttonArray = new Button[]{
                b_1,
                b_2,
                b_3,
                b_4,
                b_5,
                b_6,
                b_7,
                b_8,
            };
        }

        public void UpdateButtonNames() {
            for (int i = 0; i < buttonArray.Length; i++) {
                buttonArray[i].Text = ConfigControl.customButtonNamesArray[i].stringVal;
            }
        }

        private void b_1_Click(object sender, EventArgs e) {
            DoCommand(1);
        }

        private void b_2_Click(object sender, EventArgs e) {
            DoCommand(2);
        }

        private void b_3_Click(object sender, EventArgs e) {
            DoCommand(3);
        }

        private void b_4_Click(object sender, EventArgs e) {
            DoCommand(4);
        }

        private void b_5_Click(object sender, EventArgs e) {
            DoCommand(5);
        }

        private void b_6_Click(object sender, EventArgs e) {
            DoCommand(6);
        }

        private void b_7_Click(object sender, EventArgs e) {
            DoCommand(7);
        }

        private void b_8_Click(object sender, EventArgs e) {
            DoCommand(8);
        }

        void DoCommand(int index) {
            string val = ConfigControl.customButtonCommandsArray[index - 1].stringVal;
            bool isDigitPresent = false;
            string valueChar = "";

            foreach (char c in val.ToArray()) {
                if (char.IsDigit(c)) {
                    isDigitPresent = true;
                    valueChar = c.ToString();
                }
            }

            if (val.ToLower().Contains("preset") && isDigitPresent)
                val = "gotopreset " + valueChar;

            CustomScriptCommands.QuickCommand(val, false);
        }
    }
}
