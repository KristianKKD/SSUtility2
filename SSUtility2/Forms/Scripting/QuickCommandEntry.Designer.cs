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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickCommandEntry));
            this.l_EntryInfo = new System.Windows.Forms.Label();
            this.b_Done = new System.Windows.Forms.Button();
            this.b_CommandList = new System.Windows.Forms.Button();
            this.tB_Entry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // l_EntryInfo
            // 
            this.l_EntryInfo.AutoSize = true;
            this.l_EntryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.l_EntryInfo.Location = new System.Drawing.Point(12, 9);
            this.l_EntryInfo.Name = "l_EntryInfo";
            this.l_EntryInfo.Size = new System.Drawing.Size(77, 15);
            this.l_EntryInfo.TabIndex = 1;
            this.l_EntryInfo.Text = "LABEL TEXT";
            // 
            // b_Done
            // 
            this.b_Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.b_Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Done.Location = new System.Drawing.Point(217, 33);
            this.b_Done.Name = "b_Done";
            this.b_Done.Size = new System.Drawing.Size(75, 31);
            this.b_Done.TabIndex = 3;
            this.b_Done.Text = "Send";
            this.b_Done.UseVisualStyleBackColor = false;
            this.b_Done.Click += new System.EventHandler(this.b_Done_Click);
            // 
            // b_CommandList
            // 
            this.b_CommandList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_CommandList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.b_CommandList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_CommandList.Location = new System.Drawing.Point(171, 6);
            this.b_CommandList.Name = "b_CommandList";
            this.b_CommandList.Size = new System.Drawing.Size(121, 23);
            this.b_CommandList.TabIndex = 4;
            this.b_CommandList.Text = "Open Command List";
            this.b_CommandList.UseVisualStyleBackColor = false;
            this.b_CommandList.Click += new System.EventHandler(this.b_CommandList_Click);
            // 
            // tB_Entry
            // 
            this.tB_Entry.Location = new System.Drawing.Point(12, 39);
            this.tB_Entry.Name = "tB_Entry";
            this.tB_Entry.Size = new System.Drawing.Size(195, 20);
            this.tB_Entry.TabIndex = 5;
            this.tB_Entry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_Entry_KeyDown);
            // 
            // QuickCommandEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 76);
            this.Controls.Add(this.tB_Entry);
            this.Controls.Add(this.b_CommandList);
            this.Controls.Add(this.b_Done);
            this.Controls.Add(this.l_EntryInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(320, 115);
            this.MinimumSize = new System.Drawing.Size(320, 115);
            this.Name = "QuickCommandEntry";
            this.Text = "Quick Command Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label l_EntryInfo;
        private System.Windows.Forms.Button b_Done;
        private System.Windows.Forms.Button b_CommandList;
        private System.Windows.Forms.TextBox tB_Entry;
    }
}