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
    public partial class MediaCollection : Form {
        public MediaCollection() {
            InitializeComponent();
        }

        private void MediaCollection_Enter(object sender, EventArgs e) {
            //UpdateAll();
        }

        private void dgv_Media_Enter(object sender, EventArgs e) {
            //UpdateAll();
        }

        async Task UpdateAll() {
            CheckForMediaFiles(ConfigControl.appFolder);
        }

        async Task<List<string>> CheckForMediaFiles(string path) {
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetFiles(path);
            List<string> mediaFiles = new List<string>();
            foreach (string f in files) {
                string name = f.Substring(f.LastIndexOf("/") + 1);
                if (name.Contains("jpg") || name.Contains("avi") || name.Contains("mp4") || name.Contains("png"))
                    mediaFiles.Add(f);
            }

            foreach (string d in dirs) {
                foreach (string s in await CheckForMediaFiles(d))
                    mediaFiles.Add(s);
            }

            return mediaFiles;
        }

        private void MediaCollection_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
