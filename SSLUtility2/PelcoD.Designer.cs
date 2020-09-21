namespace SSLUtility2
{
    partial class PelcoD
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
            this.b_PD_Load = new System.Windows.Forms.Button();
            this.b_PD_Save = new System.Windows.Forms.Button();
            this.b_PD_Fire = new System.Windows.Forms.Button();
            this.rtb_PD_Commands = new System.Windows.Forms.RichTextBox();
            this.l_PD_Scripting = new System.Windows.Forms.Label();
            this.l_PD_Single = new System.Windows.Forms.Label();
            this.b_PD_FireSingle = new System.Windows.Forms.Button();
            this.tB_PD_Single = new System.Windows.Forms.TextBox();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.tB_IPCon_Port = new System.Windows.Forms.TextBox();
            this.tB_IPCon_Adr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_IPCon_Selected = new System.Windows.Forms.ComboBox();
            this.l_IPCon_SelectedCam = new System.Windows.Forms.Label();
            this.l_IPCon_Port = new System.Windows.Forms.Label();
            this.l_IPCon_Adr = new System.Windows.Forms.Label();
            this.b_PD_Stop = new System.Windows.Forms.Button();
            this.b_PD_RL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_PD_Load
            // 
            this.b_PD_Load.Location = new System.Drawing.Point(348, 110);
            this.b_PD_Load.Name = "b_PD_Load";
            this.b_PD_Load.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Load.TabIndex = 9;
            this.b_PD_Load.Text = "Load Script";
            this.b_PD_Load.UseVisualStyleBackColor = true;
            this.b_PD_Load.Click += new System.EventHandler(this.b_PD_Load_Click);
            // 
            // b_PD_Save
            // 
            this.b_PD_Save.Location = new System.Drawing.Point(348, 71);
            this.b_PD_Save.Name = "b_PD_Save";
            this.b_PD_Save.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Save.TabIndex = 8;
            this.b_PD_Save.Text = "Save Script";
            this.b_PD_Save.UseVisualStyleBackColor = true;
            this.b_PD_Save.Click += new System.EventHandler(this.b_PD_Save_Click);
            // 
            // b_PD_Fire
            // 
            this.b_PD_Fire.Location = new System.Drawing.Point(348, 32);
            this.b_PD_Fire.Name = "b_PD_Fire";
            this.b_PD_Fire.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Fire.TabIndex = 7;
            this.b_PD_Fire.Text = "Fire Commands";
            this.b_PD_Fire.UseVisualStyleBackColor = true;
            this.b_PD_Fire.Click += new System.EventHandler(this.b_PD_Fire_Click);
            // 
            // rtb_PD_Commands
            // 
            this.rtb_PD_Commands.Location = new System.Drawing.Point(12, 32);
            this.rtb_PD_Commands.Name = "rtb_PD_Commands";
            this.rtb_PD_Commands.Size = new System.Drawing.Size(330, 385);
            this.rtb_PD_Commands.TabIndex = 6;
            this.rtb_PD_Commands.Text = "";
            // 
            // l_PD_Scripting
            // 
            this.l_PD_Scripting.AutoSize = true;
            this.l_PD_Scripting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PD_Scripting.Location = new System.Drawing.Point(12, 9);
            this.l_PD_Scripting.Name = "l_PD_Scripting";
            this.l_PD_Scripting.Size = new System.Drawing.Size(142, 20);
            this.l_PD_Scripting.TabIndex = 13;
            this.l_PD_Scripting.Text = "PelcoD Scripting";
            // 
            // l_PD_Single
            // 
            this.l_PD_Single.AutoSize = true;
            this.l_PD_Single.Location = new System.Drawing.Point(13, 437);
            this.l_PD_Single.Name = "l_PD_Single";
            this.l_PD_Single.Size = new System.Drawing.Size(127, 13);
            this.l_PD_Single.TabIndex = 16;
            this.l_PD_Single.Text = "Single PelcoD Command:";
            // 
            // b_PD_FireSingle
            // 
            this.b_PD_FireSingle.Location = new System.Drawing.Point(271, 434);
            this.b_PD_FireSingle.Name = "b_PD_FireSingle";
            this.b_PD_FireSingle.Size = new System.Drawing.Size(75, 23);
            this.b_PD_FireSingle.TabIndex = 15;
            this.b_PD_FireSingle.Text = "Fire";
            this.b_PD_FireSingle.UseVisualStyleBackColor = true;
            this.b_PD_FireSingle.Click += new System.EventHandler(this.b_PD_FireSingle_Click);
            // 
            // tB_PD_Single
            // 
            this.tB_PD_Single.Location = new System.Drawing.Point(146, 434);
            this.tB_PD_Single.Name = "tB_PD_Single";
            this.tB_PD_Single.Size = new System.Drawing.Size(119, 20);
            this.tB_PD_Single.TabIndex = 14;
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(572, 176);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Connected.TabIndex = 79;
            // 
            // tB_IPCon_Port
            // 
            this.tB_IPCon_Port.Location = new System.Drawing.Point(348, 211);
            this.tB_IPCon_Port.Name = "tB_IPCon_Port";
            this.tB_IPCon_Port.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Port.TabIndex = 85;
            this.tB_IPCon_Port.Text = "6791";
            // 
            // tB_IPCon_Adr
            // 
            this.tB_IPCon_Adr.Location = new System.Drawing.Point(348, 172);
            this.tB_IPCon_Adr.Name = "tB_IPCon_Adr";
            this.tB_IPCon_Adr.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Adr.TabIndex = 84;
            this.tB_IPCon_Adr.Text = "192.168.1.71";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 88;
            // 
            // cB_IPCon_Selected
            // 
            this.cB_IPCon_Selected.FormattingEnabled = true;
            this.cB_IPCon_Selected.Items.AddRange(new object[] {
            "Daylight",
            "Thermal"});
            this.cB_IPCon_Selected.Location = new System.Drawing.Point(348, 250);
            this.cB_IPCon_Selected.Name = "cB_IPCon_Selected";
            this.cB_IPCon_Selected.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_Selected.TabIndex = 86;
            this.cB_IPCon_Selected.Text = "Daylight";
            // 
            // l_IPCon_SelectedCam
            // 
            this.l_IPCon_SelectedCam.AutoSize = true;
            this.l_IPCon_SelectedCam.Location = new System.Drawing.Point(345, 234);
            this.l_IPCon_SelectedCam.Name = "l_IPCon_SelectedCam";
            this.l_IPCon_SelectedCam.Size = new System.Drawing.Size(91, 13);
            this.l_IPCon_SelectedCam.TabIndex = 83;
            this.l_IPCon_SelectedCam.Text = "Selected Camera:";
            // 
            // l_IPCon_Port
            // 
            this.l_IPCon_Port.AutoSize = true;
            this.l_IPCon_Port.Location = new System.Drawing.Point(345, 195);
            this.l_IPCon_Port.Name = "l_IPCon_Port";
            this.l_IPCon_Port.Size = new System.Drawing.Size(29, 13);
            this.l_IPCon_Port.TabIndex = 82;
            this.l_IPCon_Port.Text = "Port:";
            // 
            // l_IPCon_Adr
            // 
            this.l_IPCon_Adr.AutoSize = true;
            this.l_IPCon_Adr.Location = new System.Drawing.Point(345, 156);
            this.l_IPCon_Adr.Name = "l_IPCon_Adr";
            this.l_IPCon_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_IPCon_Adr.TabIndex = 80;
            this.l_IPCon_Adr.Text = "IP Address:";
            // 
            // b_PD_Stop
            // 
            this.b_PD_Stop.Location = new System.Drawing.Point(348, 367);
            this.b_PD_Stop.Name = "b_PD_Stop";
            this.b_PD_Stop.Size = new System.Drawing.Size(111, 50);
            this.b_PD_Stop.TabIndex = 89;
            this.b_PD_Stop.Text = "Camera Stop Command";
            this.b_PD_Stop.UseVisualStyleBackColor = true;
            this.b_PD_Stop.Click += new System.EventHandler(this.b_PD_Stop_Click);
            // 
            // b_PD_RL
            // 
            this.b_PD_RL.Location = new System.Drawing.Point(348, 311);
            this.b_PD_RL.Name = "b_PD_RL";
            this.b_PD_RL.Size = new System.Drawing.Size(111, 50);
            this.b_PD_RL.TabIndex = 90;
            this.b_PD_RL.Text = "Open Response Log";
            this.b_PD_RL.UseVisualStyleBackColor = true;
            this.b_PD_RL.Click += new System.EventHandler(this.b_PD_RL_Click);
            // 
            // PelcoD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 472);
            this.Controls.Add(this.b_PD_RL);
            this.Controls.Add(this.b_PD_Stop);
            this.Controls.Add(this.tB_IPCon_Port);
            this.Controls.Add(this.tB_IPCon_Adr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cB_IPCon_Selected);
            this.Controls.Add(this.l_IPCon_SelectedCam);
            this.Controls.Add(this.l_IPCon_Port);
            this.Controls.Add(this.l_IPCon_Adr);
            this.Controls.Add(this.l_IPCon_Connected);
            this.Controls.Add(this.l_PD_Single);
            this.Controls.Add(this.b_PD_FireSingle);
            this.Controls.Add(this.tB_PD_Single);
            this.Controls.Add(this.l_PD_Scripting);
            this.Controls.Add(this.b_PD_Load);
            this.Controls.Add(this.b_PD_Save);
            this.Controls.Add(this.b_PD_Fire);
            this.Controls.Add(this.rtb_PD_Commands);
            this.Name = "PelcoD";
            this.Text = "PelcoD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PelcoD_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_PD_Load;
        private System.Windows.Forms.Button b_PD_Save;
        private System.Windows.Forms.Button b_PD_Fire;
        private System.Windows.Forms.RichTextBox rtb_PD_Commands;
        public System.Windows.Forms.Label l_PD_Scripting;
        private System.Windows.Forms.Label l_PD_Single;
        private System.Windows.Forms.Button b_PD_FireSingle;
        private System.Windows.Forms.TextBox tB_PD_Single;
        public System.Windows.Forms.Label l_IPCon_Connected;
        public System.Windows.Forms.TextBox tB_IPCon_Port;
        public System.Windows.Forms.TextBox tB_IPCon_Adr;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cB_IPCon_Selected;
        public System.Windows.Forms.Label l_IPCon_SelectedCam;
        public System.Windows.Forms.Label l_IPCon_Port;
        public System.Windows.Forms.Label l_IPCon_Adr;
        private System.Windows.Forms.Button b_PD_Stop;
        private System.Windows.Forms.Button b_PD_RL;
    }
}