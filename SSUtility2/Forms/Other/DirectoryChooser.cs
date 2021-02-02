using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class DirectoryChooser : Form {
        public DirectoryChooser() {
            InitializeComponent();
        }

        private void b_Done_Click(object sender, EventArgs e) {
            if (MainForm.CheckIfNameValid(tB_Dir.Text) && ConfigControl.CheckIfExists(tB_Dir, null)) {
                string dirLocation = tB_Dir.Text;
                if (!dirLocation.EndsWith(@"\")){
                    dirLocation += @"\";
                }
                if (Directory.GetFiles(dirLocation).Length > 0) {
                    dirLocation += @"SSUtility\";
                }
                ConfigControl.appFolder = dirLocation;
                Dispose();
            } else {
                MainForm.ShowPopup("Invalid directory name!\nShow more?", "Directory path invalid",
                    "You entered: " + tB_Dir.Text + "\nUse format similar to: " + ConfigControl.appFolder);
            }
        }

        private void b_Browse_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Dir);
        }

        private void b_Default_Click(object sender, EventArgs e) {
            tB_Dir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
