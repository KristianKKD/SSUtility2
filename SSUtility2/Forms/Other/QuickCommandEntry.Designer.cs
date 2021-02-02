namespace SSUtility2
{
    partial class QuickCommandEntry
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
            this.l_EntryInfo = new System.Windows.Forms.Label();
            this.rtb_Entry = new System.Windows.Forms.RichTextBox();
            this.b_Done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_EntryInfo
            // 
            this.l_EntryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_EntryInfo.AutoSize = true;
            this.l_EntryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.l_EntryInfo.Location = new System.Drawing.Point(12, 9);
            this.l_EntryInfo.Name = "l_EntryInfo";
            this.l_EntryInfo.Size = new System.Drawing.Size(77, 15);
            this.l_EntryInfo.TabIndex = 1;
            this.l_EntryInfo.Text = "LABEL TEXT";
            // 
            // rtb_Entry
            // 
            this.rtb_Entry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Entry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Entry.Location = new System.Drawing.Point(15, 28);
            this.rtb_Entry.Name = "rtb_Entry";
            this.rtb_Entry.Size = new System.Drawing.Size(161, 23);
            this.rtb_Entry.TabIndex = 2;
            this.rtb_Entry.Text = "";
            // 
            // b_Done
            // 
            this.b_Done.Location = new System.Drawing.Point(182, 28);
            this.b_Done.Name = "b_Done";
            this.b_Done.Size = new System.Drawing.Size(75, 23);
            this.b_Done.TabIndex = 3;
            this.b_Done.Text = "Done";
            this.b_Done.UseVisualStyleBackColor = true;
            this.b_Done.Click += new System.EventHandler(this.b_Done_Click);
            // 
            // QuickCommandEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(269, 63);
            this.Controls.Add(this.b_Done);
            this.Controls.Add(this.rtb_Entry);
            this.Controls.Add(this.l_EntryInfo);
            this.Name = "QuickCommandEntry";
            this.Text = "QuickCommandEntry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label l_EntryInfo;
        public System.Windows.Forms.RichTextBox rtb_Entry;
        private System.Windows.Forms.Button b_Done;
    }
}