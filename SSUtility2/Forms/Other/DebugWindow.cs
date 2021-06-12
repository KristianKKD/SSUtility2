using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2.Forms.Other
{
    public partial class DebugWindow : Form
    {
        public DebugWindow() {
            InitializeComponent();
        }

        private void b_Debug_Click(object sender, EventArgs e) {
            var x = CustomScriptCommands.CheckForCommands(tB_Debug.Text, 0, false).Result;
            MessageBox.Show(Tools.ReadCommand(x.codeContent));
        }
    }
}
