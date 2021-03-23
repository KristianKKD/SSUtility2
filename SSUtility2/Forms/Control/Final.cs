using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SSUtility2.Forms.FinalTest {
    public partial class Final : Form {
        public Final() {
            InitializeComponent();
            tB_Destination.Text = ConfigControl.finalDestination.stringVal;
            tB_Source.Text = ConfigControl.finalSource.stringVal;
        }

        private void b_Final_Next_Click(object sender, EventArgs e) {
            try {
                bool notCompleted = false;
                var textboxList = Tools.GetAllType(this, typeof(TextBox));

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

                if (Directory.Exists(tB_Destination.Text + @"\" + customer + @"\")) {
                    MessageBox.Show("Folder already exists!");
                    return;
                }

                string ip = HasIP(tB_Source.Text);
                if (ip != "") {
                    if (!OtherCamCom.PingAdr(IPAddress.Parse(ip)).Result) {
                        Tools.ShowPopup("Couldn't ping address given within Source Folder input!\nShow more?",
                            "Final Mode Failed!", "Tried to ping: " + ip);
                        return;
                    }
                }

                if (!Directory.Exists(tB_Source.Text)) {
                    MessageBox.Show("Source folder doesn't exist!");
                    return;
                }

                string dest = Directory.CreateDirectory(tB_Destination.Text + @"\" + customer + @"\").FullName;
                string appFolder = Directory.CreateDirectory(dest + @"SSUtility2\").FullName;
                string manuals = Directory.CreateDirectory(dest + @"Manuals\").FullName;
                string evidence = Directory.CreateDirectory(dest + @"Test Evidence\").FullName;
                string useful = Directory.CreateDirectory(dest + @"Useful Applications\").FullName;

                this.Hide();

                string self = Process.GetCurrentProcess().MainModule.FileName;
                File.Copy(self, appFolder + System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName);

                if (Tools.CheckIfNameValid(dest, false) &&
                    Tools.CheckIfNameValid(tB_Source.Text, false)) {

                    if (check_Default.Checked) {
                        ConfigControl.finalSource.UpdateValue(tB_Source.Text);
                        ConfigControl.finalDestination.UpdateValue(tB_Destination.Text);
                        ConfigControl.CreateConfig(ConfigControl.appFolder + ConfigControl.config);
                    }

                    if (check_Old.Checked) {
                        Tools.CopyFiles(appFolder, Directory.GetFiles(tB_Source.Text));
                        Tools.CopyDirs(appFolder, Directory.GetDirectories(tB_Source.Text));
                    }
                }

                MainForm.m.Text = "FINAL TEST MODE - " + customer.Replace("_", " ");
                MainForm.m.ToggleFinalMode(dest);
            } catch (Exception error){
                Tools.ShowPopup("Failed to start Final Test Mode!\nShow more?", "Final Test Mode Failed!", error.ToString());
            }
        }

        public static string HasIP(String text) {
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(text);
            if (result.Count == 0) {
                return "";
            } else {
                return result[0].ToString();
            }
        }

        private void b_BrowseSource_Click(object sender, EventArgs e) {
            Tools.BrowseFolderButton(tB_Source);
        }

        private void b_BrowseDest_Click(object sender, EventArgs e) {
            Tools.BrowseFolderButton(tB_Destination);
        }

    }
}
