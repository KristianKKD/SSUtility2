
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Media
            // 
            this.dgv_Media.AllowUserToAddRows = false;
            this.dgv_Media.AllowUserToDeleteRows = false;
            this.dgv_Media.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Media.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Media.Location = new System.Drawing.Point(0, 0);
            this.dgv_Media.Name = "dgv_Media";
            this.dgv_Media.ReadOnly = true;
            this.dgv_Media.Size = new System.Drawing.Size(800, 450);
            this.dgv_Media.TabIndex = 0;
            this.dgv_Media.Enter += new System.EventHandler(this.dgv_Media_Enter);
            // 
            // MediaCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Media);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MediaCollection";
            this.Text = "Media Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MediaCollection_FormClosing);
            this.Enter += new System.EventHandler(this.MediaCollection_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Media;
    }
}