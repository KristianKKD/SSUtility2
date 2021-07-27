﻿namespace SSUtility2 {

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
            this.videoStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Attach = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Player = new System.Windows.Forms.Panel();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.Color.White;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoStreamToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(772, 24);
            this.MenuBar.TabIndex = 42;
            this.MenuBar.Text = "Menu";
            // 
            // videoStreamToolStripMenuItem
            // 
            this.videoStreamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings,
            this.Menu_Snapshot,
            this.Menu_Record,
            this.Menu_Attach});
            this.videoStreamToolStripMenuItem.Name = "videoStreamToolStripMenuItem";
            this.videoStreamToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.videoStreamToolStripMenuItem.Text = "Video Stream";
            // 
            // Menu_Settings
            // 
            this.Menu_Settings.Name = "Menu_Settings";
            this.Menu_Settings.Size = new System.Drawing.Size(181, 22);
            this.Menu_Settings.Text = "Connection Settings";
            this.Menu_Settings.Click += new System.EventHandler(this.Menu_Settings_Click);
            // 
            // Menu_Snapshot
            // 
            this.Menu_Snapshot.Name = "Menu_Snapshot";
            this.Menu_Snapshot.Size = new System.Drawing.Size(181, 22);
            this.Menu_Snapshot.Text = "Save Snapshot";
            this.Menu_Snapshot.Click += new System.EventHandler(this.Menu_Snapshot_Click);
            // 
            // Menu_Record
            // 
            this.Menu_Record.Name = "Menu_Record";
            this.Menu_Record.Size = new System.Drawing.Size(181, 22);
            this.Menu_Record.Text = "Start Recording";
            this.Menu_Record.Click += new System.EventHandler(this.Menu_Record_Click);
            // 
            // Menu_Attach
            // 
            this.Menu_Attach.Name = "Menu_Attach";
            this.Menu_Attach.Size = new System.Drawing.Size(181, 22);
            this.Menu_Attach.Text = "Attach To Main";
            this.Menu_Attach.Click += new System.EventHandler(this.Menu_Attach_Click);
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
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip MenuBar;
        public System.Windows.Forms.ToolStripMenuItem videoStreamToolStripMenuItem;
        public System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolStripMenuItem Menu_Settings;
        public System.Windows.Forms.ToolStripMenuItem Menu_Snapshot;
        public System.Windows.Forms.ToolStripMenuItem Menu_Record;
        public System.Windows.Forms.Panel p_Player;
        private System.Windows.Forms.ToolStripMenuItem Menu_Attach;
    }
}