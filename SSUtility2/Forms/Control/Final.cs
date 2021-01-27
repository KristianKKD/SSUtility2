using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SSLUtility2.Forms.FinalTest {
    public partial class Final : Form {
        public Final() {
            InitializeComponent();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            tB_Destination.Text = desktopPath;

            string sourceFolder = @"\\192.168.1.118\netdrive\ProductionTesting\DEFAULT FILES";
            //string sourceFolder = ConfigControl.appFolder;

            tB_Source.Text = sourceFolder;
        }

        private void b_Final_Next_Click(object sender, EventArgs e) {
            bool notCompleted = false;
            var textboxList = MainForm.m.GetAllType(this, typeof(TextBox));

            foreach (TextBox tb in textboxList) {
                if (tb.Text.Length < 1) {
                    notCompleted = true;
                }
            }
            if (notCompleted) {
                MessageBox.Show("Some fields are empty!");
                return;
            }

            string customer = tB_SO.Text + "_" + tB_Customer.Text;

            string dest = Directory.CreateDirectory(tB_Destination.Text + @"\" + customer + @"\").FullName;
            string appFolder = Directory.CreateDirectory(dest + @"SSUtility2\").FullName;
            string manuals = Directory.CreateDirectory(dest + @"Manuals\").FullName;
            string evidence = Directory.CreateDirectory(dest + @"Test Evidence\").FullName;
            string useful = Directory.CreateDirectory(dest + @"Useful Applications\").FullName;
            
            //copy config file and record it
            //copy any new and old saved snapshots/recordings,etc

            this.Hide();

            //string self = Process.GetCurrentProcess().MainModule.FileName;
            //File.Copy(self, dest + @"\" + System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName);

            if (MainForm.CheckIfNameValid(dest.ToCharArray(), false).Result) {
                MainForm.CopyFiles(appFolder, Directory.GetFiles(tB_Source.Text));
                MainForm.CopyDirs(appFolder, Directory.GetDirectories(tB_Source.Text));
            }

            MainForm.m.Text = "FINAL TEST MODE - " + customer.Replace("_", " ");
            MainForm.m.ActivateFinalMode(dest, appFolder);

        }

        private void b_BrowseSource_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Source);
        }

        private void b_BrowseDest_Click(object sender, EventArgs e) {
            MainForm.BrowseFolderButton(tB_Destination);
        }

    }
}
