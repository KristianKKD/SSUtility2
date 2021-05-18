namespace SSUtility2
{
    partial class ResponseLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponseLog));
            this.b_RL_Clear = new System.Windows.Forms.Button();
            this.b_RL_Save = new System.Windows.Forms.Button();
            this.l_RL_RL = new System.Windows.Forms.Label();
            this.check_Hide = new System.Windows.Forms.CheckBox();
            this.check_Spam = new System.Windows.Forms.CheckBox();
            this.tB_Log = new System.Windows.Forms.RichTextBox();
            this.check_Timestamp = new System.Windows.Forms.CheckBox();
            this.check_AutoScroll = new System.Windows.Forms.CheckBox();
            this.l_TotalSent = new System.Windows.Forms.Label();
            this.l_Queue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_RL_Clear
            // 
            this.b_RL_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_RL_Clear.BackColor = System.Drawing.SystemColors.Control;
            this.b_RL_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_RL_Clear.Location = new System.Drawing.Point(444, 61);
            this.b_RL_Clear.Name = "b_RL_Clear";
            this.b_RL_Clear.Size = new System.Drawing.Size(87, 23);
            this.b_RL_Clear.TabIndex = 1;
            this.b_RL_Clear.Text = "Clear";
            this.b_RL_Clear.UseVisualStyleBackColor = false;
            this.b_RL_Clear.Click += new System.EventHandler(this.b_RL_Clear_Click);
            // 
            // b_RL_Save
            // 
            this.b_RL_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_RL_Save.BackColor = System.Drawing.SystemColors.Control;
            this.b_RL_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_RL_Save.Location = new System.Drawing.Point(444, 32);
            this.b_RL_Save.Name = "b_RL_Save";
            this.b_RL_Save.Size = new System.Drawing.Size(87, 23);
            this.b_RL_Save.TabIndex = 2;
            this.b_RL_Save.Text = "Save";
            this.b_RL_Save.UseVisualStyleBackColor = false;
            this.b_RL_Save.Click += new System.EventHandler(this.b_RL_Save_Click);
            // 
            // l_RL_RL
            // 
            this.l_RL_RL.AutoSize = true;
            this.l_RL_RL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_RL_RL.Location = new System.Drawing.Point(12, 9);
            this.l_RL_RL.Name = "l_RL_RL";
            this.l_RL_RL.Size = new System.Drawing.Size(125, 20);
            this.l_RL_RL.TabIndex = 14;
            this.l_RL_RL.Text = "Response Log";
            // 
            // check_Hide
            // 
            this.check_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_Hide.AutoSize = true;
            this.check_Hide.Checked = true;
            this.check_Hide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Hide.Location = new System.Drawing.Point(444, 90);
            this.check_Hide.Name = "check_Hide";
            this.check_Hide.Size = new System.Drawing.Size(90, 17);
            this.check_Hide.TabIndex = 15;
            this.check_Hide.Text = "Show Hidden";
            this.check_Hide.UseVisualStyleBackColor = true;
            // 
            // check_Spam
            // 
            this.check_Spam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_Spam.AutoSize = true;
            this.check_Spam.Checked = true;
            this.check_Spam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Spam.Location = new System.Drawing.Point(444, 113);
            this.check_Spam.Name = "check_Spam";
            this.check_Spam.Size = new System.Drawing.Size(83, 17);
            this.check_Spam.TabIndex = 16;
            this.check_Spam.Text = "Show Spam";
            this.check_Spam.UseVisualStyleBackColor = true;
            // 
            // tB_Log
            // 
            this.tB_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Log.BackColor = System.Drawing.SystemColors.Control;
            this.tB_Log.Location = new System.Drawing.Point(16, 32);
            this.tB_Log.Name = "tB_Log";
            this.tB_Log.Size = new System.Drawing.Size(422, 402);
            this.tB_Log.TabIndex = 17;
            this.tB_Log.Text = "";
            // 
            // check_Timestamp
            // 
            this.check_Timestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_Timestamp.AutoSize = true;
            this.check_Timestamp.Location = new System.Drawing.Point(444, 136);
            this.check_Timestamp.Name = "check_Timestamp";
            this.check_Timestamp.Size = new System.Drawing.Size(82, 17);
            this.check_Timestamp.TabIndex = 18;
            this.check_Timestamp.Text = "Timestamps";
            this.check_Timestamp.UseVisualStyleBackColor = true;
            // 
            // check_AutoScroll
            // 
            this.check_AutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.check_AutoScroll.AutoSize = true;
            this.check_AutoScroll.Location = new System.Drawing.Point(449, 417);
            this.check_AutoScroll.Name = "check_AutoScroll";
            this.check_AutoScroll.Size = new System.Drawing.Size(77, 17);
            this.check_AutoScroll.TabIndex = 19;
            this.check_AutoScroll.Text = "Auto Scroll";
            this.check_AutoScroll.UseVisualStyleBackColor = true;
            // 
            // l_TotalSent
            // 
            this.l_TotalSent.AutoSize = true;
            this.l_TotalSent.Location = new System.Drawing.Point(441, 303);
            this.l_TotalSent.Name = "l_TotalSent";
            this.l_TotalSent.Size = new System.Drawing.Size(89, 26);
            this.l_TotalSent.TabIndex = 20;
            this.l_TotalSent.Text = "Total Commands \r\nSent:";
            // 
            // l_Queue
            // 
            this.l_Queue.AutoSize = true;
            this.l_Queue.Location = new System.Drawing.Point(441, 352);
            this.l_Queue.Name = "l_Queue";
            this.l_Queue.Size = new System.Drawing.Size(92, 26);
            this.l_Queue.TabIndex = 21;
            this.l_Queue.Text = "Command Queue \r\nLength:";
            // 
            // ResponseLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(543, 446);
            this.Controls.Add(this.l_Queue);
            this.Controls.Add(this.l_TotalSent);
            this.Controls.Add(this.check_AutoScroll);
            this.Controls.Add(this.check_Timestamp);
            this.Controls.Add(this.tB_Log);
            this.Controls.Add(this.check_Spam);
            this.Controls.Add(this.check_Hide);
            this.Controls.Add(this.l_RL_RL);
            this.Controls.Add(this.b_RL_Save);
            this.Controls.Add(this.b_RL_Clear);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResponseLog";
            this.Text = "ResponseLog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResponseLog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button b_RL_Clear;
        public System.Windows.Forms.Button b_RL_Save;
        public System.Windows.Forms.Label l_RL_RL;
        public System.Windows.Forms.CheckBox check_Hide;
        public System.Windows.Forms.CheckBox check_Spam;
        public System.Windows.Forms.RichTextBox tB_Log;
        public System.Windows.Forms.CheckBox check_Timestamp;
        public System.Windows.Forms.CheckBox check_AutoScroll;
        private System.Windows.Forms.Label l_TotalSent;
        private System.Windows.Forms.Label l_Queue;
    }
}