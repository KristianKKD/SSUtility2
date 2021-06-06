using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class CustomPanel : Form {

        public Panel myPanel;

        int buttonIndex;

        List<Button> buttonList;

        public CustomPanel() {
            InitializeComponent();
            buttonList = new List<Button>();
            buttonIndex = 1;
        }

        public void AddButton(string name) {
            //70 30
            Button b = new Button();

            b.Size = new Size(70, 30);
            b.Location = new Point(buttonList.Count * 70, 0);
            b.Text = name;
            
            buttonList.Add(b);
            myPanel.Controls.Add(b);
            myPanel.Size = new Size(buttonList.Count * 71, 32);
            myPanel.Location = new Point(MainForm.m.mainPlayer.p_Player.Width - myPanel.Width, MainForm.m.mainPlayer.p_Player.Height - 32);
        }

        public void UpdateButtonNames() {
            DataGridView dgv = MainForm.m.setPage.dgv_Custom_Buttons;
            List<int> validRows = Tools.GetValidRows(dgv);

            int i = 0;
            foreach (int valid in validRows) {
                if (buttonList.Count < i)
                    break;

                buttonList[i].Text = dgv.Rows[valid].Cells[0].Value.ToString();
                i++;
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

        private void b_9_Click(object sender, EventArgs e) {
            DoCommand(9);
        }

        public void DoCommand(int index) {
            try {
                //string val = ConfigControl.customButtonCommandsArray[index - 1].stringVal;
                //bool isDigitPresent = false;
                //string presetValue = "";

                //foreach (char c in val.ToArray()) {
                //    if (char.IsDigit(c)) {
                //        isDigitPresent = true;
                //        presetValue += c.ToString();
                //    }
                //}

                //if (val.ToLower().Contains("preset") && isDigitPresent)
                //    val = "gotopreset " + presetValue;

                //CustomScriptCommands.QuickCommand(val, false);
            } catch (Exception e) {
                MessageBox.Show("DO COMMAND" + e.ToString());
            }
        }


    }
}
