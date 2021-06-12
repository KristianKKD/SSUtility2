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
    public partial class DebugWindow : Form {
        
        ScriptCommand sc;

        public DebugWindow() {
            InitializeComponent();
        }

        private void b_Debug_Click(object sender, EventArgs e) {
            sc = CustomScriptCommands.CheckForCommands(tB_Debug.Text, 0, false).Result;

            string fullMsg = GenName();
            fullMsg += "\nVALUES(" + sc.valueCount.ToString() + ")   CONTENT:";

            if (sc.codeContent != null)
                fullMsg += Tools.ReadCommand(sc.codeContent);
            else
                fullMsg += "NULL";

            MessageBox.Show(fullMsg);
        }


        string GenName() {
            string name = "";

            if (sc.names != null)
                foreach (string s in sc.names)
                    name += s + ", ";

                if (name != "")
                    name = name.Substring(0, name.Length - 2); //remove last comma+whitespace

            return name;
        }
    }
}
