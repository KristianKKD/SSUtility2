
namespace SSUtility2
{
    partial class DirectoryChooser
    {
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
            this.l_Description = new System.Windows.Forms.Label();
            this.b_Browse = new System.Windows.Forms.Button();
            this.b_Default = new System.Windows.Forms.Button();
            this.b_Done = new System.Windows.Forms.Button();
            this.tB_Dir = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // l_Description
            // 
            this.l_Description.AutoSize = true;
            this.l_Description.Location = new System.Drawing.Point(9, 13);
            this.l_Description.Name = "l_Description";
            this.l_Description.Size = new System.Drawing.Size(241, 13);
            this.l_Description.TabIndex = 0;
            this.l_Description.Text = "Please select a directory for SSUtility2 to install to:";
            // 
            // b_Browse
            // 
            this.b_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Browse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Browse.Location = new System.Drawing.Point(258, 28);
            this.b_Browse.Name = "b_Browse";
            this.b_Browse.Size = new System.Drawing.Size(75, 23);
            this.b_Browse.TabIndex = 2;
            this.b_Browse.Text = "Browse";
            this.b_Browse.UseVisualStyleBackColor = false;
            this.b_Browse.Click += new System.EventHandler(this.b_Browse_Click);
            // 
            // b_Default
            // 
            this.b_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Default.BackColor = System.Drawing.SystemColors.Control;
            this.b_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Default.Location = new System.Drawing.Point(12, 59);
            this.b_Default.Name = "b_Default";
            this.b_Default.Size = new System.Drawing.Size(75, 23);
            this.b_Default.TabIndex = 3;
            this.b_Default.Text = "Default";
            this.b_Default.UseVisualStyleBackColor = false;
            this.b_Default.Click += new System.EventHandler(this.b_Default_Click);
            // 
            // b_Done
            // 
            this.b_Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Done.BackColor = System.Drawing.SystemColors.Control;
            this.b_Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Done.Location = new System.Drawing.Point(258, 59);
            this.b_Done.Name = "b_Done";
            this.b_Done.Size = new System.Drawing.Size(75, 23);
            this.b_Done.TabIndex = 4;
            this.b_Done.Text = "Confirm";
            this.b_Done.UseVisualStyleBackColor = false;
            this.b_Done.Click += new System.EventHandler(this.b_Done_Click);
            // 
            // tB_Dir
            // 
            this.tB_Dir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Dir.Location = new System.Drawing.Point(12, 30);
            this.tB_Dir.Name = "tB_Dir";
            this.tB_Dir.Size = new System.Drawing.Size(237, 20);
            this.tB_Dir.TabIndex = 5;
            // 
            // DirectoryChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(345, 94);
            this.Controls.Add(this.tB_Dir);
            this.Controls.Add(this.b_Done);
            this.Controls.Add(this.b_Default);
            this.Controls.Add(this.b_Browse);
            this.Controls.Add(this.l_Description);
            this.Name = "DirectoryChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectoryChooser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Description;
        private System.Windows.Forms.Button b_Browse;
        private System.Windows.Forms.Button b_Default;
        private System.Windows.Forms.Button b_Done;
        private System.Windows.Forms.TextBox tB_Dir;
    }
}