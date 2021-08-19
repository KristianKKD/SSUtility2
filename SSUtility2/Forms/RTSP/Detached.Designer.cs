namespace SSUtility2 {

    partial class Detached {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detached));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.Menu_VideoStream = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Attach = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_StopRecording = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Video = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Player = new System.Windows.Forms.Panel();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.Color.White;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_VideoStream,
            this.Menu_Recording});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(772, 24);
            this.MenuBar.TabIndex = 42;
            this.MenuBar.Text = "Menu";
            // 
            // Menu_VideoStream
            // 
            this.Menu_VideoStream.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings,
            this.Menu_Attach});
            this.Menu_VideoStream.Name = "Menu_VideoStream";
            this.Menu_VideoStream.Size = new System.Drawing.Size(89, 20);
            this.Menu_VideoStream.Text = "Video Stream";
            // 
            // Menu_Settings
            // 
            this.Menu_Settings.Name = "Menu_Settings";
            this.Menu_Settings.Size = new System.Drawing.Size(181, 22);
            this.Menu_Settings.Text = "Connection Settings";
            this.Menu_Settings.Click += new System.EventHandler(this.Menu_Settings_Click);
            // 
            // Menu_Attach
            // 
            this.Menu_Attach.Name = "Menu_Attach";
            this.Menu_Attach.Size = new System.Drawing.Size(181, 22);
            this.Menu_Attach.Text = "Attach To Main";
            this.Menu_Attach.Click += new System.EventHandler(this.Menu_Attach_Click);
            // 
            // Menu_Recording
            // 
            this.Menu_Recording.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Recording_StopRecording,
            this.Menu_Recording_Video,
            this.Menu_Recording_Snapshot});
            this.Menu_Recording.Name = "Menu_Recording";
            this.Menu_Recording.Size = new System.Drawing.Size(73, 20);
            this.Menu_Recording.Text = "Recording";
            // 
            // Menu_Recording_StopRecording
            // 
            this.Menu_Recording_StopRecording.Name = "Menu_Recording_StopRecording";
            this.Menu_Recording_StopRecording.Size = new System.Drawing.Size(155, 22);
            this.Menu_Recording_StopRecording.Text = "Stop Recording";
            this.Menu_Recording_StopRecording.Visible = false;
            this.Menu_Recording_StopRecording.Click += new System.EventHandler(this.Menu_Recording_StopRecording_Click);
            // 
            // Menu_Recording_Video
            // 
            this.Menu_Recording_Video.Name = "Menu_Recording_Video";
            this.Menu_Recording_Video.Size = new System.Drawing.Size(155, 22);
            this.Menu_Recording_Video.Text = "Video";
            this.Menu_Recording_Video.Click += new System.EventHandler(this.Menu_Recording_Video_Click);
            // 
            // Menu_Recording_Snapshot
            // 
            this.Menu_Recording_Snapshot.Name = "Menu_Recording_Snapshot";
            this.Menu_Recording_Snapshot.Size = new System.Drawing.Size(155, 22);
            this.Menu_Recording_Snapshot.Text = "Snapshot";
            this.Menu_Recording_Snapshot.Click += new System.EventHandler(this.Menu_Recording_Snapshot_Click);
            // 
            // p_Player
            // 
            this.p_Player.BackColor = System.Drawing.Color.Black;
            this.p_Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Player.Location = new System.Drawing.Point(0, 24);
            this.p_Player.Name = "p_Player";
            this.p_Player.Size = new System.Drawing.Size(772, 465);
            this.p_Player.TabIndex = 43;
            // 
            // Detached
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(772, 489);
            this.Controls.Add(this.p_Player);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.Name = "Detached";
            this.Text = "Detached Player";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Detached_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip MenuBar;
        public System.Windows.Forms.ToolStripMenuItem Menu_VideoStream;
        public System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolStripMenuItem Menu_Settings;
        public System.Windows.Forms.Panel p_Player;
        private System.Windows.Forms.ToolStripMenuItem Menu_Attach;
        private System.Windows.Forms.ToolStripMenuItem Menu_Recording;
        private System.Windows.Forms.ToolStripMenuItem Menu_Recording_Video;
        private System.Windows.Forms.ToolStripMenuItem Menu_Recording_Snapshot;
        private System.Windows.Forms.ToolStripMenuItem Menu_Recording_StopRecording;
    }
}