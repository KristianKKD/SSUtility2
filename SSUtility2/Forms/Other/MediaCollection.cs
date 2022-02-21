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

        Timer cooldownUpdateTimer;

        bool timeout;

        public List<string> recentSavedLocations;

        public MediaCollection() {
            InitializeComponent();
            recentSavedLocations = new List<string>();
            
            cooldownUpdateTimer = new Timer();
            cooldownUpdateTimer.Interval = 1500;
            cooldownUpdateTimer.Tick += new EventHandler(CooldownTimerCallback);
        }

        public void AddDefaultSavedLocations() {
            AddToSavedLocations(ConfigControl.appFolder);
            AddToSavedLocations(ConfigControl.scFolder.stringVal);
            AddToSavedLocations(ConfigControl.vFolder.stringVal);
        }

        private void CooldownTimerCallback(object sender, EventArgs e) {
            timeout = false;
            cooldownUpdateTimer.Stop();
            if (askedToUpdateWhileOnCooldown)
                UpdateAll();

            askedToUpdateWhileOnCooldown = false;
        }

        public void AddToSavedLocations(string path) {
            if (path == null || path == "")
                return;

            if (!path.EndsWith(@"\"))
                path += @"\";

            if (!(Directory.Exists(path) || File.Exists(path)))
                return;

            path = path.Trim();

            foreach (string s in recentSavedLocations) {
                if (path == s || path.Contains(s))
                    return;
            }

            MainForm.m.col.recentSavedLocations.Add(path);
            UpdateAll();
        }

        bool askedToUpdateWhileOnCooldown = false;

        public async Task UpdateAll() {
            if (timeout)
                return;

            await Task.Delay(500); //for windows to update just in case

            Console.WriteLine("updating");
            dgv_Media.Rows.Clear();

            List<string> results = new List<string>();

            foreach (string s in recentSavedLocations)
                foreach (string entry in await CheckForMediaFiles(s))
                    if(!results.Contains(entry))
                        results.Add(entry);

            foreach (string s in results) {
                Console.WriteLine(s);
                string name = s.Substring(s.LastIndexOf(@"\") + 1);
                string extension = s.Substring(s.LastIndexOf(".") + 1);
                string date = File.GetCreationTime(s).ToString();
                dgv_Media.Rows.Add(name, extension, date, s);
            }

            timeout = true;
            cooldownUpdateTimer.Start();
        }

        async Task<List<string>> CheckForMediaFiles(string path) {
            List<string> mediaFiles = new List<string>();

            try {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);
                foreach (string f in files) {
                    string name = f.Substring(f.LastIndexOf("/") + 1);
                    if ((name.Contains("jpg") || name.Contains("avi") || name.Contains("mp4") || name.Contains("png")) && !mediaFiles.Contains(f))
                        mediaFiles.Add(f);
                }

                foreach (string d in dirs) {
                    foreach (string s in await CheckForMediaFiles(d))
                        mediaFiles.Add(s);
                }

            }catch(Exception e) {
                Console.WriteLine(e.ToString());
            }

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
                MessageBox.Show("Failed to find path!\n" + err.ToString());
            }
        }

        bool refresh = true;

        private void MediaCollection_Deactivate(object sender, EventArgs e) {
            refresh = true;
        }

        private void dgv_Media_MouseClick(object sender, MouseEventArgs e) {
            if (refresh)
                UpdateAll();

            refresh = false;
        }
    }
}
