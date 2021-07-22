using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public class CustomButtons {

        public CustomButtons() {
            buttonList = new List<Button>();
            tips = new ToolTip();
        }

        ToolTip tips;
        public List<Button> buttonList;

        public bool isVisible = false;

        public void AddButton(string name) {
            try {
                Button b = new Button();
                buttonList.Add(b);

                b.AutoSize = true;
                b.Size = new Size(70, 23);
                b.Text = name;
                b.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                b.FlatStyle = FlatStyle.Flat;
                b.BackColor = Color.White;
                b.TabStop = false;
                b.Visible = isVisible;
                b.Click += (s, e) => {
                    DoCommand(buttonList.IndexOf(b));
                };


                if (b.Text.Length > 0) {
                    UpdateTip(buttonList.IndexOf(b));
                    MainForm.m.mainPlayer.p_Player.Controls.Add(b);
                }
            } catch (Exception e) {
                MessageBox.Show("ADD BUTTON\n" + e.ToString());
            }

            Reorder();
        }

        public void RemoveButton(int rowIndex) {
            try {
                if (rowIndex > buttonList.Count - 1)
                    return;

                Button b = buttonList[rowIndex];
                buttonList.Remove(b);
                b.Text = "AA";
                b.Dispose();
            } catch (Exception e) {
                MessageBox.Show("REMOVE BUTTON\n" + e.ToString());
            }

            Reorder();
        }

        void Reorder() {
            try {
                int cumuWidth = 0;
                for (int i = 0; i < buttonList.Count; i++)
                    cumuWidth += buttonList[i].Width;

                for (int i = buttonList.Count - 1; i > -1; i--) {
                    buttonList[i].Location = new Point(MainForm.m.mainPlayer.p_Player.Width - cumuWidth,
                        MainForm.m.mainPlayer.p_Player.Height - 25);
                    cumuWidth -= buttonList[i].Width;
                }
            } catch (Exception e) {
                MessageBox.Show("REORDER\n" + e.ToString());
            }
        }

        public void HideButtons() {
            foreach (Button b in buttonList) {
                b.Hide();
            }
            MainForm.m.Menu_Settings_Panels_Custom.Text = "Custom Panel";
            isVisible = false;
        }

        public void ShowButtons() {
            foreach (Button b in buttonList) {
                b.Show();
                b.BringToFront();
            }
            MainForm.m.Menu_Settings_Panels_Custom.Text = "Hide Custom Panel";
            isVisible = true;
        }

        public void UpdateButtonNames() {
            DataGridView dgv = MainForm.m.setPage.dgv_Custom_Buttons;
            List<int> validRows = Tools.GetValidRows(dgv, 0);

            int i = 0;
            foreach (int valid in validRows) {
                if (buttonList.Count - 1 < i)
                    break;
                buttonList[i].Text = dgv.Rows[valid].Cells[0].Value.ToString();
                i++;
            }

            Reorder();
        }

        public void UpdateTip(int buttonIndex) {
            try {
                if (buttonIndex > buttonList.Count - 1)
                    return;

                string val = "";
                DataGridViewCell cell = MainForm.m.setPage.dgv_Custom_Buttons.Rows[buttonIndex].Cells[1];
                if (cell != null && cell.Value != null)
                    val = cell.Value.ToString();

                tips.SetToolTip(buttonList[buttonIndex], val);
            }catch(Exception e) {
                MessageBox.Show("TIP\n" + e.ToString());
            }
        }

        public void DoCommand(int index) {
            try {
                if (index > buttonList.Count - 1
                    || MainForm.m.setPage.dgv_Custom_Buttons.Rows[index].Cells[1].Value == null)
                    return;

                string val = MainForm.m.setPage.dgv_Custom_Buttons.Rows[index].Cells[1].Value.ToString();

                if (val.ToLower().Trim().StartsWith("preset")) {
                    string presetValue = "";
                    bool isDigitPresent = false;

                    foreach (char c in val.ToArray()) {
                        if (char.IsDigit(c)) {
                            isDigitPresent = true;
                            presetValue += c.ToString();
                        } else if (isDigitPresent)
                            break;
                    }

                    if (isDigitPresent)
                        val = "gotopreset " + presetValue;
                }

                CustomScriptCommands.QuickCommand(val, false);
            } catch (Exception e) {
                MessageBox.Show("DO COMMAND\n" + index.ToString() + "\n" + e.ToString());
            }
        }

    }
}
