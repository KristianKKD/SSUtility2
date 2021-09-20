using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2.Hidden
{
    public partial class FirstTime : Form
    {
        public FirstTime() {
            InitializeComponent();
            tB_IP.Text = ConfigControl.savedIP.defaultVal;
            cB_Port.Text = ConfigControl.savedPort.defaultVal;
        }

        private void b_Cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void b_Next_Click(object sender, EventArgs e) {
            if (tB_IP.Text != "") {
                ConfigControl.savedIP.UpdateValue(tB_IP.Text);
                MainForm.m.setPage.tB_IPCon_Adr.Text = tB_IP.Text;
            }

            if (cB_Port.Text != "") {
                ConfigControl.savedPort.UpdateValue(cB_Port.Text);
                MainForm.m.setPage.cB_IPCon_Port.Text = cB_Port.Text;
            }

            RTSPPresets.CreateNew(MainForm.m.mainPlayer.settings, this);
        }

        async Task DelayedIndex() {
            await Task.Delay(100);
            cB_Port.Text = Tools.GetPortValueFromEncoder(cB_Port);
        }

        private void cB_Port_SelectedIndexChanged(object sender, EventArgs e) {
            DelayedIndex();
        }
    }
}
