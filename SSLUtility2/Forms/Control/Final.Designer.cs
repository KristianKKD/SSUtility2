namespace SSLUtility2.Forms.FinalTest
{
    partial class Final
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
            this.b_Final_Next = new System.Windows.Forms.Button();
            this.l_Name_Path = new System.Windows.Forms.Label();
            this.l_Name_NameList = new System.Windows.Forms.Label();
            this.tB_Name_Path = new System.Windows.Forms.TextBox();
            this.rtb_Name_NameList = new System.Windows.Forms.RichTextBox();
            this.b_Final_Browse = new System.Windows.Forms.Button();
            this.b_Name_BrowseFrom = new System.Windows.Forms.Button();
            this.l_Name_From = new System.Windows.Forms.Label();
            this.tB_Name_PathFrom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_Final_Next
            // 
            this.b_Final_Next.BackColor = System.Drawing.SystemColors.Control;
            this.b_Final_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Final_Next.Location = new System.Drawing.Point(295, 309);
            this.b_Final_Next.Name = "b_Final_Next";
            this.b_Final_Next.Size = new System.Drawing.Size(174, 73);
            this.b_Final_Next.TabIndex = 0;
            this.b_Final_Next.Text = "Next";
            this.b_Final_Next.UseVisualStyleBackColor = false;
            this.b_Final_Next.Click += new System.EventHandler(this.b_Final_Next_Click);
            // 
            // l_Name_Path
            // 
            this.l_Name_Path.AutoSize = true;
            this.l_Name_Path.Location = new System.Drawing.Point(292, 35);
            this.l_Name_Path.Name = "l_Name_Path";
            this.l_Name_Path.Size = new System.Drawing.Size(103, 13);
            this.l_Name_Path.TabIndex = 19;
            this.l_Name_Path.Text = "Path to copy files to:";
            // 
            // l_Name_NameList
            // 
            this.l_Name_NameList.AutoSize = true;
            this.l_Name_NameList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Name_NameList.Location = new System.Drawing.Point(12, 9);
            this.l_Name_NameList.Name = "l_Name_NameList";
            this.l_Name_NameList.Size = new System.Drawing.Size(89, 20);
            this.l_Name_NameList.TabIndex = 18;
            this.l_Name_NameList.Text = "Name List";
            // 
            // tB_Name_Path
            // 
            this.tB_Name_Path.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Name_Path.Location = new System.Drawing.Point(292, 54);
            this.tB_Name_Path.Name = "tB_Name_Path";
            this.tB_Name_Path.Size = new System.Drawing.Size(177, 20);
            this.tB_Name_Path.TabIndex = 17;
            // 
            // rtb_Name_NameList
            // 
            this.rtb_Name_NameList.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_Name_NameList.Location = new System.Drawing.Point(12, 32);
            this.rtb_Name_NameList.Name = "rtb_Name_NameList";
            this.rtb_Name_NameList.Size = new System.Drawing.Size(274, 350);
            this.rtb_Name_NameList.TabIndex = 16;
            this.rtb_Name_NameList.Text = "";
            // 
            // b_Final_Browse
            // 
            this.b_Final_Browse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Final_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Final_Browse.Location = new System.Drawing.Point(408, 30);
            this.b_Final_Browse.Name = "b_Final_Browse";
            this.b_Final_Browse.Size = new System.Drawing.Size(61, 22);
            this.b_Final_Browse.TabIndex = 20;
            this.b_Final_Browse.Text = "Browse";
            this.b_Final_Browse.UseVisualStyleBackColor = false;
            this.b_Final_Browse.Click += new System.EventHandler(this.b_Final_Browse_Click);
            // 
            // b_Name_BrowseFrom
            // 
            this.b_Name_BrowseFrom.BackColor = System.Drawing.SystemColors.Control;
            this.b_Name_BrowseFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Name_BrowseFrom.Location = new System.Drawing.Point(408, 111);
            this.b_Name_BrowseFrom.Name = "b_Name_BrowseFrom";
            this.b_Name_BrowseFrom.Size = new System.Drawing.Size(61, 22);
            this.b_Name_BrowseFrom.TabIndex = 23;
            this.b_Name_BrowseFrom.Text = "Browse";
            this.b_Name_BrowseFrom.UseVisualStyleBackColor = false;
            this.b_Name_BrowseFrom.Click += new System.EventHandler(this.b_Name_BrowseFrom_Click);
            // 
            // l_Name_From
            // 
            this.l_Name_From.AutoSize = true;
            this.l_Name_From.Location = new System.Drawing.Point(292, 116);
            this.l_Name_From.Name = "l_Name_From";
            this.l_Name_From.Size = new System.Drawing.Size(114, 13);
            this.l_Name_From.TabIndex = 22;
            this.l_Name_From.Text = "Path to copy files from:";
            // 
            // tB_Name_PathFrom
            // 
            this.tB_Name_PathFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Name_PathFrom.Location = new System.Drawing.Point(292, 135);
            this.tB_Name_PathFrom.Name = "tB_Name_PathFrom";
            this.tB_Name_PathFrom.Size = new System.Drawing.Size(177, 20);
            this.tB_Name_PathFrom.TabIndex = 21;
            // 
            // Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(486, 394);
            this.Controls.Add(this.b_Name_BrowseFrom);
            this.Controls.Add(this.l_Name_From);
            this.Controls.Add(this.tB_Name_PathFrom);
            this.Controls.Add(this.b_Final_Browse);
            this.Controls.Add(this.l_Name_Path);
            this.Controls.Add(this.l_Name_NameList);
            this.Controls.Add(this.tB_Name_Path);
            this.Controls.Add(this.rtb_Name_NameList);
            this.Controls.Add(this.b_Final_Next);
            this.Name = "Final";
            this.Text = "Final Test Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Final_Next;
        private System.Windows.Forms.Label l_Name_Path;
        public System.Windows.Forms.Label l_Name_NameList;
        private System.Windows.Forms.TextBox tB_Name_Path;
        private System.Windows.Forms.RichTextBox rtb_Name_NameList;
        public System.Windows.Forms.Button b_Final_Browse;
        public System.Windows.Forms.Button b_Name_BrowseFrom;
        private System.Windows.Forms.Label l_Name_From;
        private System.Windows.Forms.TextBox tB_Name_PathFrom;
    }
}