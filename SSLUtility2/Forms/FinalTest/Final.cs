using System;
using System.Windows.Forms;

namespace SSLUtility2.Forms.FinalTest
{
    public partial class Final : Form
    {
        public Final() {
            InitializeComponent();
            tB_Name_Path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            tB_Name_Path.Text = ConfigControl.appFolder;
        }

        private void b_Final_Next_Click(object sender, EventArgs e) {
            string path = tB_Name_Path.Text;
            if (rtb_Name_NameList.Lines.Length > 1) {
                MainForm.CheckCreateFile(null, path + @"\FinalTestMode");
                path += @"\FinalTestMode";
            }

            foreach (string line in rtb_Name_NameList.Lines) {
                path += @"\" + line;
                if (line != "") {
                    MainForm.CheckCreateFile(null, path);

                    //copy files

                }
            }
                
        }

        private void b_Final_Browse_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Name_Path);
        }

        private void b_Name_BrowseFrom_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Name_PathFrom);
        }
    }
}
