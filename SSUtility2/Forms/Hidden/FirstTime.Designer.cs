namespace SSUtility2.Hidden
{
    partial class FirstTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTime));
            this.l_Title = new System.Windows.Forms.Label();
            this.l_Subtitle = new System.Windows.Forms.Label();
            this.tB_IP = new System.Windows.Forms.TextBox();
            this.l_IP = new System.Windows.Forms.Label();
            this.l_Port = new System.Windows.Forms.Label();
            this.b_Next = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.cB_Port = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // l_Title
            // 
            this.l_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Title.AutoSize = true;
            this.l_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Title.Location = new System.Drawing.Point(12, 9);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(117, 20);
            this.l_Title.TabIndex = 74;
            this.l_Title.Text = "Setup Wizard";
            // 
            // l_Subtitle
            // 
            this.l_Subtitle.AutoSize = true;
            this.l_Subtitle.Location = new System.Drawing.Point(12, 41);
            this.l_Subtitle.Name = "l_Subtitle";
            this.l_Subtitle.Size = new System.Drawing.Size(260, 13);
            this.l_Subtitle.TabIndex = 75;
            this.l_Subtitle.Text = "Fill out the below fields to get started with SSUtility2.0:";
            // 
            // tB_IP
            // 
            this.tB_IP.Location = new System.Drawing.Point(120, 69);
            this.tB_IP.Name = "tB_IP";
            this.tB_IP.Size = new System.Drawing.Size(183, 20);
            this.tB_IP.TabIndex = 76;
            // 
            // l_IP
            // 
            this.l_IP.AutoSize = true;
            this.l_IP.Location = new System.Drawing.Point(13, 72);
            this.l_IP.Name = "l_IP";
            this.l_IP.Size = new System.Drawing.Size(92, 13);
            this.l_IP.TabIndex = 77;
            this.l_IP.Text = "Camera Control IP";
            // 
            // l_Port
            // 
            this.l_Port.AutoSize = true;
            this.l_Port.Location = new System.Drawing.Point(13, 98);
            this.l_Port.Name = "l_Port";
            this.l_Port.Size = new System.Drawing.Size(101, 13);
            this.l_Port.TabIndex = 79;
            this.l_Port.Text = "Camera Control Port";
            // 
            // b_Next
            // 
            this.b_Next.BackColor = System.Drawing.SystemColors.Control;
            this.b_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Next.Location = new System.Drawing.Point(228, 139);
            this.b_Next.Name = "b_Next";
            this.b_Next.Size = new System.Drawing.Size(75, 23);
            this.b_Next.TabIndex = 80;
            this.b_Next.Text = "Next";
            this.b_Next.UseVisualStyleBackColor = false;
            this.b_Next.Click += new System.EventHandler(this.b_Next_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.b_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Cancel.Location = new System.Drawing.Point(147, 139);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 81;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = false;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // cB_Port
            // 
            this.cB_Port.FormattingEnabled = true;
            this.cB_Port.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_Port.Location = new System.Drawing.Point(120, 95);
            this.cB_Port.Name = "cB_Port";
            this.cB_Port.Size = new System.Drawing.Size(183, 21);
            this.cB_Port.TabIndex = 82;
            this.cB_Port.SelectedIndexChanged += new System.EventHandler(this.cB_Port_SelectedIndexChanged);
            // 
            // FirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(314, 171);
            this.Controls.Add(this.cB_Port);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_Next);
            this.Controls.Add(this.l_Port);
            this.Controls.Add(this.l_IP);
            this.Controls.Add(this.tB_IP);
            this.Controls.Add(this.l_Subtitle);
            this.Controls.Add(this.l_Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(330, 210);
            this.MinimumSize = new System.Drawing.Size(330, 210);
            this.Name = "FirstTime";
            this.Text = "Setup Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Label l_Subtitle;
        private System.Windows.Forms.TextBox tB_IP;
        private System.Windows.Forms.Label l_IP;
        private System.Windows.Forms.Label l_Port;
        private System.Windows.Forms.Button b_Next;
        private System.Windows.Forms.Button b_Cancel;
        public System.Windows.Forms.ComboBox cB_Port;
    }
}