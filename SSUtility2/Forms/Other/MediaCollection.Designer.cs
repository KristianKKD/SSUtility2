﻿
namespace SSUtility2 {
    partial class MediaCollection {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaCollection));
            this.dgv_Media = new System.Windows.Forms.DataGridView();
            this.MediaFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Media
            // 
            this.dgv_Media.AllowUserToAddRows = false;
            this.dgv_Media.AllowUserToDeleteRows = false;
            this.dgv_Media.AllowUserToResizeRows = false;
            this.dgv_Media.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Media.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MediaFileName,
            this.Type,
            this.Date,
            this.FilePath});
            this.dgv_Media.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Media.Location = new System.Drawing.Point(0, 24);
            this.dgv_Media.Name = "dgv_Media";
            this.dgv_Media.ReadOnly = true;
            this.dgv_Media.RowHeadersVisible = false;
            this.dgv_Media.Size = new System.Drawing.Size(800, 426);
            this.dgv_Media.TabIndex = 0;
            this.dgv_Media.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Media_CellContentDoubleClick);
            this.dgv_Media.Enter += new System.EventHandler(this.dgv_Media_Enter);
            // 
            // MediaFileName
            // 
            this.MediaFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MediaFileName.FillWeight = 85F;
            this.MediaFileName.HeaderText = "File Name";
            this.MediaFileName.Name = "MediaFileName";
            this.MediaFileName.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.FillWeight = 20F;
            this.Type.HeaderText = "Extension";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.FillWeight = 35F;
            this.Date.HeaderText = "Date Created";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilePath.HeaderText = "Path";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Refresh});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Refresh
            // 
            this.Menu_Refresh.Name = "Menu_Refresh";
            this.Menu_Refresh.Size = new System.Drawing.Size(58, 20);
            this.Menu_Refresh.Text = "Refresh";
            this.Menu_Refresh.Click += new System.EventHandler(this.Menu_Refresh_Click);
            // 
            // MediaCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Media);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MediaCollection";
            this.Text = "Media Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MediaCollection_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Media;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediaFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Refresh;
    }
}