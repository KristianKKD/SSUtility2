using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSUtility2 {
    public partial class MediaCollection : Form {
        public MediaCollection() {
            InitializeComponent();
        }

        private void dgv_Media_Enter(object sender, EventArgs e) {
            UpdateAll();
        }

        async Task UpdateAll() {
            dgv_Media.Rows.Clear();

            List<string> results = await CheckForMediaFiles(ConfigControl.appFolder);
            foreach (string s in results) {
                Console.WriteLine(s);
                string name = s.Substring(s.LastIndexOf(@"\") + 1);
                string extension = s.Substring(s.LastIndexOf(".") + 1);
                string date = File.GetCreationTime(s).ToString();
                dgv_Media.Rows.Add(name, extension, date, s);
            }
        }

        async Task<List<string>> CheckForMediaFiles(string path) {
            List<string> mediaFiles = new List<string>();

            try {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);
                foreach (string f in files) {
                    string name = f.Substring(f.LastIndexOf("/") + 1);
                    if (name.Contains("jpg") || name.Contains("avi") || name.Contains("mp4") || name.Contains("png"))
                        mediaFiles.Add(f);
                }

                foreach (string d in dirs) {
                    foreach (string s in await CheckForMediaFiles(d))
                        mediaFiles.Add(s);
                }

            }catch(Exception e) {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("done");
            return mediaFiles;
        }

        private void MediaCollection_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void dgv_Media_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                string fullPath = dgv_Media.Rows[e.RowIndex].Cells[3].Value.ToString();
                Process.Start("explorer.exe", @"/select," + fullPath);
            }catch(Exception err) {
                MessageBox.Show("Failed to find path!\n" + e.ToString());
            }
        }

        private void Menu_Refresh_Click(object sender, EventArgs e) {
            UpdateAll();
        }
    }
}
