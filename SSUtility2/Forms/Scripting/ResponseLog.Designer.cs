namespace SSLUtility2
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
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.b_RL_Clear = new System.Windows.Forms.Button();
            this.b_RL_Save = new System.Windows.Forms.Button();
            this.l_RL_RL = new System.Windows.Forms.Label();
            this.check_RL_All = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rtb_Log
            // 
            this.rtb_Log.Location = new System.Drawing.Point(12, 32);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(429, 402);
            this.rtb_Log.TabIndex = 0;
            this.rtb_Log.Text = "";
            // 
            // b_RL_Clear
            // 
            this.b_RL_Clear.BackColor = System.Drawing.SystemColors.Control;
            this.b_RL_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_RL_Clear.Location = new System.Drawing.Point(449, 61);
            this.b_RL_Clear.Name = "b_RL_Clear";
            this.b_RL_Clear.Size = new System.Drawing.Size(75, 23);
            this.b_RL_Clear.TabIndex = 1;
            this.b_RL_Clear.Text = "Clear";
            this.b_RL_Clear.UseVisualStyleBackColor = false;
            this.b_RL_Clear.Click += new System.EventHandler(this.b_RL_Clear_Click);
            // 
            // b_RL_Save
            // 
            this.b_RL_Save.BackColor = System.Drawing.SystemColors.Control;
            this.b_RL_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_RL_Save.Location = new System.Drawing.Point(449, 32);
            this.b_RL_Save.Name = "b_RL_Save";
            this.b_RL_Save.Size = new System.Drawing.Size(75, 23);
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
            // check_RL_All
            // 
            this.check_RL_All.AutoSize = true;
            this.check_RL_All.Location = new System.Drawing.Point(412, 9);
            this.check_RL_All.Name = "check_RL_All";
            this.check_RL_All.Size = new System.Drawing.Size(112, 17);
            this.check_RL_All.TabIndex = 15;
            this.check_RL_All.Text = "All Communication";
            this.check_RL_All.UseVisualStyleBackColor = true;
            // 
            // ResponseLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(533, 446);
            this.Controls.Add(this.check_RL_All);
            this.Controls.Add(this.l_RL_RL);
            this.Controls.Add(this.b_RL_Save);
            this.Controls.Add(this.b_RL_Clear);
            this.Controls.Add(this.rtb_Log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResponseLog";
            this.Text = "ResponseLog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResponseLog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtb_Log;
        public System.Windows.Forms.Button b_RL_Clear;
        public System.Windows.Forms.Button b_RL_Save;
        public System.Windows.Forms.Label l_RL_RL;
        public System.Windows.Forms.CheckBox check_RL_All;
    }
}