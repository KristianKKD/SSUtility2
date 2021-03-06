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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.videoStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_StartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_SwapView = new System.Windows.Forms.ToolStripMenuItem();
            this.VLCPlayer_D = new AxAXVLC.AxVLCPlugin2();
            this.sizeablePanel1 = new SizeablePanel.SizeablePanel();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_D)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoStreamToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(772, 24);
            this.Menu.TabIndex = 42;
            this.Menu.Text = "Menu";
            // 
            // videoStreamToolStripMenuItem
            // 
            this.videoStreamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings,
            this.Menu_StartStop,
            this.Menu_Snapshot,
            this.Menu_Record,
            this.Menu_SwapView});
            this.videoStreamToolStripMenuItem.Name = "videoStreamToolStripMenuItem";
            this.videoStreamToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.videoStreamToolStripMenuItem.Text = "Video Stream";
            // 
            // Menu_Settings
            // 
            this.Menu_Settings.Name = "Menu_Settings";
            this.Menu_Settings.Size = new System.Drawing.Size(191, 22);
            this.Menu_Settings.Text = "Connection Settings";
            this.Menu_Settings.Click += new System.EventHandler(this.Menu_Settings_Click);
            // 
            // Menu_StartStop
            // 
            this.Menu_StartStop.Name = "Menu_StartStop";
            this.Menu_StartStop.Size = new System.Drawing.Size(191, 22);
            this.Menu_StartStop.Text = "Start Video Playback";
            this.Menu_StartStop.Click += new System.EventHandler(this.Menu_StartStop_Click);
            // 
            // Menu_Snapshot
            // 
            this.Menu_Snapshot.Name = "Menu_Snapshot";
            this.Menu_Snapshot.Size = new System.Drawing.Size(191, 22);
            this.Menu_Snapshot.Text = "Save Snapshot";
            this.Menu_Snapshot.Click += new System.EventHandler(this.Menu_Snapshot_Click);
            // 
            // Menu_Record
            // 
            this.Menu_Record.Name = "Menu_Record";
            this.Menu_Record.Size = new System.Drawing.Size(191, 22);
            this.Menu_Record.Text = "Start Recording";
            this.Menu_Record.Click += new System.EventHandler(this.Menu_Record_Click);
            // 
            // Menu_SwapView
            // 
            this.Menu_SwapView.Name = "Menu_SwapView";
            this.Menu_SwapView.Size = new System.Drawing.Size(191, 22);
            this.Menu_SwapView.Text = "Swap To Thermal View";
            this.Menu_SwapView.Click += new System.EventHandler(this.Menu_SwapView_Click);
            // 
            // VLCPlayer_D
            // 
            this.VLCPlayer_D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VLCPlayer_D.Enabled = true;
            this.VLCPlayer_D.Location = new System.Drawing.Point(0, 24);
            this.VLCPlayer_D.Name = "VLCPlayer_D";
            this.VLCPlayer_D.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VLCPlayer_D.OcxState")));
            this.VLCPlayer_D.Size = new System.Drawing.Size(772, 465);
            this.VLCPlayer_D.TabIndex = 41;
            // 
            // sizeablePanel1
            // 
            this.sizeablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeablePanel1.BackColor = System.Drawing.Color.White;
            this.sizeablePanel1.Location = new System.Drawing.Point(482, 115);
            this.sizeablePanel1.Name = "sizeablePanel1";
            this.sizeablePanel1.Size = new System.Drawing.Size(200, 100);
            this.sizeablePanel1.TabIndex = 43;
            // 
            // Detached
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(772, 489);
            this.Controls.Add(this.sizeablePanel1);
            this.Controls.Add(this.VLCPlayer_D);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "Detached";
            this.Text = "Player";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_D)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public AxAXVLC.AxVLCPlugin2 VLCPlayer_D;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem videoStreamToolStripMenuItem;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem Menu_Settings;
        private System.Windows.Forms.ToolStripMenuItem Menu_StartStop;
        private System.Windows.Forms.ToolStripMenuItem Menu_Snapshot;
        private System.Windows.Forms.ToolStripMenuItem Menu_Record;
        private System.Windows.Forms.ToolStripMenuItem Menu_SwapView;
        private SizeablePanel.SizeablePanel sizeablePanel1;
    }
}