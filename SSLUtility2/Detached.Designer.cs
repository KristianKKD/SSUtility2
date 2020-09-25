namespace SSLUtility2 {

    partial class Detached {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detached));
            this.gB_PlayerD_Simple = new System.Windows.Forms.GroupBox();
            this.tB_PlayerD_SimpleAdr = new System.Windows.Forms.TextBox();
            this.l_PlayerD_SimpleAdr = new System.Windows.Forms.Label();
            this.gB_PlayerD_Extended = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.l_PlayerD_Type = new System.Windows.Forms.Label();
            this.l_PlayerD_RTSP = new System.Windows.Forms.Label();
            this.tB_PlayerD_Adr = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Password = new System.Windows.Forms.Label();
            this.tB_PlayerD_Port = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Port = new System.Windows.Forms.Label();
            this.tB_PlayerD_RTSP = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Adr = new System.Windows.Forms.Label();
            this.tB_PlayerD_Username = new System.Windows.Forms.TextBox();
            this.tB_PlayerD_Buffering = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Username = new System.Windows.Forms.Label();
            this.l_PlayerD_Buffering = new System.Windows.Forms.Label();
            this.tB_PlayerD_Password = new System.Windows.Forms.TextBox();
            this.cB_PlayerD_Type = new System.Windows.Forms.ComboBox();
            this.VLCPlayer_D = new AxAXVLC.AxVLCPlugin2();
            this.checkB_PlayerD_Manual = new System.Windows.Forms.CheckBox();
            this.b_PlayerD_StartRec = new System.Windows.Forms.Button();
            this.b_PlayerD_SaveSnap = new System.Windows.Forms.Button();
            this.b_PlayerD_Play = new System.Windows.Forms.Button();
            this.gB_PlayerD_Simple.SuspendLayout();
            this.gB_PlayerD_Extended.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_D)).BeginInit();
            this.SuspendLayout();
            // 
            // gB_PlayerD_Simple
            // 
            this.gB_PlayerD_Simple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gB_PlayerD_Simple.Controls.Add(this.tB_PlayerD_SimpleAdr);
            this.gB_PlayerD_Simple.Controls.Add(this.l_PlayerD_SimpleAdr);
            this.gB_PlayerD_Simple.Location = new System.Drawing.Point(2, 516);
            this.gB_PlayerD_Simple.Name = "gB_PlayerD_Simple";
            this.gB_PlayerD_Simple.Size = new System.Drawing.Size(313, 239);
            this.gB_PlayerD_Simple.TabIndex = 48;
            this.gB_PlayerD_Simple.TabStop = false;
            // 
            // tB_PlayerD_SimpleAdr
            // 
            this.tB_PlayerD_SimpleAdr.Location = new System.Drawing.Point(89, 26);
            this.tB_PlayerD_SimpleAdr.Name = "tB_PlayerD_SimpleAdr";
            this.tB_PlayerD_SimpleAdr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_SimpleAdr.TabIndex = 28;
            // 
            // l_PlayerD_SimpleAdr
            // 
            this.l_PlayerD_SimpleAdr.AutoSize = true;
            this.l_PlayerD_SimpleAdr.Location = new System.Drawing.Point(3, 27);
            this.l_PlayerD_SimpleAdr.Name = "l_PlayerD_SimpleAdr";
            this.l_PlayerD_SimpleAdr.Size = new System.Drawing.Size(80, 13);
            this.l_PlayerD_SimpleAdr.TabIndex = 27;
            this.l_PlayerD_SimpleAdr.Text = "RTSP Address:";
            // 
            // gB_PlayerD_Extended
            // 
            this.gB_PlayerD_Extended.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gB_PlayerD_Extended.Controls.Add(this.label1);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_Type);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_RTSP);
            this.gB_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Adr);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_Password);
            this.gB_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Port);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_Port);
            this.gB_PlayerD_Extended.Controls.Add(this.tB_PlayerD_RTSP);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_Adr);
            this.gB_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Username);
            this.gB_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Buffering);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_Username);
            this.gB_PlayerD_Extended.Controls.Add(this.l_PlayerD_Buffering);
            this.gB_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Password);
            this.gB_PlayerD_Extended.Controls.Add(this.cB_PlayerD_Type);
            this.gB_PlayerD_Extended.Location = new System.Drawing.Point(2, 516);
            this.gB_PlayerD_Extended.Name = "gB_PlayerD_Extended";
            this.gB_PlayerD_Extended.Size = new System.Drawing.Size(313, 239);
            this.gB_PlayerD_Extended.TabIndex = 26;
            this.gB_PlayerD_Extended.TabStop = false;
            this.gB_PlayerD_Extended.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "*Changed fields will not apply until the stream is replayed*";
            // 
            // l_PlayerD_Type
            // 
            this.l_PlayerD_Type.AutoSize = true;
            this.l_PlayerD_Type.Location = new System.Drawing.Point(6, 17);
            this.l_PlayerD_Type.Name = "l_PlayerD_Type";
            this.l_PlayerD_Type.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerD_Type.TabIndex = 2;
            this.l_PlayerD_Type.Text = "Encoder Type:";
            // 
            // l_PlayerD_RTSP
            // 
            this.l_PlayerD_RTSP.AutoSize = true;
            this.l_PlayerD_RTSP.Location = new System.Drawing.Point(6, 91);
            this.l_PlayerD_RTSP.Name = "l_PlayerD_RTSP";
            this.l_PlayerD_RTSP.Size = new System.Drawing.Size(69, 13);
            this.l_PlayerD_RTSP.TabIndex = 2;
            this.l_PlayerD_RTSP.Text = "RTSP String:";
            // 
            // tB_PlayerD_Adr
            // 
            this.tB_PlayerD_Adr.Location = new System.Drawing.Point(89, 41);
            this.tB_PlayerD_Adr.Name = "tB_PlayerD_Adr";
            this.tB_PlayerD_Adr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_Adr.TabIndex = 4;
            this.tB_PlayerD_Adr.Text = "192.168.1.71";
            // 
            // l_PlayerD_Password
            // 
            this.l_PlayerD_Password.AutoSize = true;
            this.l_PlayerD_Password.Location = new System.Drawing.Point(6, 168);
            this.l_PlayerD_Password.Name = "l_PlayerD_Password";
            this.l_PlayerD_Password.Size = new System.Drawing.Size(56, 13);
            this.l_PlayerD_Password.TabIndex = 2;
            this.l_PlayerD_Password.Text = "Password:";
            // 
            // tB_PlayerD_Port
            // 
            this.tB_PlayerD_Port.Location = new System.Drawing.Point(89, 67);
            this.tB_PlayerD_Port.Name = "tB_PlayerD_Port";
            this.tB_PlayerD_Port.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_Port.TabIndex = 4;
            this.tB_PlayerD_Port.Text = "554";
            // 
            // l_PlayerD_Port
            // 
            this.l_PlayerD_Port.AutoSize = true;
            this.l_PlayerD_Port.Location = new System.Drawing.Point(6, 66);
            this.l_PlayerD_Port.Name = "l_PlayerD_Port";
            this.l_PlayerD_Port.Size = new System.Drawing.Size(29, 13);
            this.l_PlayerD_Port.TabIndex = 2;
            this.l_PlayerD_Port.Text = "Port:";
            // 
            // tB_PlayerD_RTSP
            // 
            this.tB_PlayerD_RTSP.Location = new System.Drawing.Point(89, 92);
            this.tB_PlayerD_RTSP.Name = "tB_PlayerD_RTSP";
            this.tB_PlayerD_RTSP.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_RTSP.TabIndex = 4;
            this.tB_PlayerD_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            // 
            // l_PlayerD_Adr
            // 
            this.l_PlayerD_Adr.AutoSize = true;
            this.l_PlayerD_Adr.Location = new System.Drawing.Point(6, 43);
            this.l_PlayerD_Adr.Name = "l_PlayerD_Adr";
            this.l_PlayerD_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_PlayerD_Adr.TabIndex = 2;
            this.l_PlayerD_Adr.Text = "IP Address:";
            // 
            // tB_PlayerD_Username
            // 
            this.tB_PlayerD_Username.Location = new System.Drawing.Point(89, 144);
            this.tB_PlayerD_Username.Name = "tB_PlayerD_Username";
            this.tB_PlayerD_Username.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_Username.TabIndex = 4;
            this.tB_PlayerD_Username.Text = "admin";
            // 
            // tB_PlayerD_Buffering
            // 
            this.tB_PlayerD_Buffering.Location = new System.Drawing.Point(89, 118);
            this.tB_PlayerD_Buffering.Name = "tB_PlayerD_Buffering";
            this.tB_PlayerD_Buffering.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_Buffering.TabIndex = 4;
            this.tB_PlayerD_Buffering.Text = "200";
            // 
            // l_PlayerD_Username
            // 
            this.l_PlayerD_Username.AutoSize = true;
            this.l_PlayerD_Username.Location = new System.Drawing.Point(6, 143);
            this.l_PlayerD_Username.Name = "l_PlayerD_Username";
            this.l_PlayerD_Username.Size = new System.Drawing.Size(58, 13);
            this.l_PlayerD_Username.TabIndex = 2;
            this.l_PlayerD_Username.Text = "Username:";
            // 
            // l_PlayerD_Buffering
            // 
            this.l_PlayerD_Buffering.AutoSize = true;
            this.l_PlayerD_Buffering.Location = new System.Drawing.Point(6, 117);
            this.l_PlayerD_Buffering.Name = "l_PlayerD_Buffering";
            this.l_PlayerD_Buffering.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerD_Buffering.TabIndex = 2;
            this.l_PlayerD_Buffering.Text = "Buffering (ms): ";
            // 
            // tB_PlayerD_Password
            // 
            this.tB_PlayerD_Password.Location = new System.Drawing.Point(89, 170);
            this.tB_PlayerD_Password.Name = "tB_PlayerD_Password";
            this.tB_PlayerD_Password.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerD_Password.TabIndex = 4;
            this.tB_PlayerD_Password.Text = "admin";
            // 
            // cB_PlayerD_Type
            // 
            this.cB_PlayerD_Type.FormattingEnabled = true;
            this.cB_PlayerD_Type.Items.AddRange(new object[] {
            "IONodes - Daylight",
            "IONodes - Thermal",
            "VIVOTEK",
            "BOSCH"});
            this.cB_PlayerD_Type.Location = new System.Drawing.Point(89, 14);
            this.cB_PlayerD_Type.Name = "cB_PlayerD_Type";
            this.cB_PlayerD_Type.Size = new System.Drawing.Size(214, 21);
            this.cB_PlayerD_Type.TabIndex = 5;
            this.cB_PlayerD_Type.Text = "Daylight";
            this.cB_PlayerD_Type.SelectedIndexChanged += new System.EventHandler(this.cB_PlayerD_Type_SelectedIndexChanged);
            // 
            // VLCPlayer_D
            // 
            this.VLCPlayer_D.Enabled = true;
            this.VLCPlayer_D.Location = new System.Drawing.Point(1, 1);
            this.VLCPlayer_D.Name = "VLCPlayer_D";
            this.VLCPlayer_D.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VLCPlayer_D.OcxState")));
            this.VLCPlayer_D.Size = new System.Drawing.Size(639, 512);
            this.VLCPlayer_D.TabIndex = 41;
            // 
            // checkB_PlayerD_Manual
            // 
            this.checkB_PlayerD_Manual.AutoSize = true;
            this.checkB_PlayerD_Manual.Location = new System.Drawing.Point(321, 526);
            this.checkB_PlayerD_Manual.Name = "checkB_PlayerD_Manual";
            this.checkB_PlayerD_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_PlayerD_Manual.TabIndex = 47;
            this.checkB_PlayerD_Manual.Text = "Extended RTSP Controls";
            this.checkB_PlayerD_Manual.UseVisualStyleBackColor = true;
            this.checkB_PlayerD_Manual.CheckedChanged += new System.EventHandler(this.checkB_PlayerD_Manual_CheckedChanged);
            // 
            // b_PlayerD_StartRec
            // 
            this.b_PlayerD_StartRec.Location = new System.Drawing.Point(320, 583);
            this.b_PlayerD_StartRec.Name = "b_PlayerD_StartRec";
            this.b_PlayerD_StartRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerD_StartRec.TabIndex = 45;
            this.b_PlayerD_StartRec.Text = "START Recording";
            this.b_PlayerD_StartRec.UseVisualStyleBackColor = true;
            this.b_PlayerD_StartRec.Click += new System.EventHandler(this.b_PlayerD_StartRec_Click);
            // 
            // b_PlayerD_SaveSnap
            // 
            this.b_PlayerD_SaveSnap.Location = new System.Drawing.Point(320, 554);
            this.b_PlayerD_SaveSnap.Name = "b_PlayerD_SaveSnap";
            this.b_PlayerD_SaveSnap.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerD_SaveSnap.TabIndex = 46;
            this.b_PlayerD_SaveSnap.Text = "Save Snapshot";
            this.b_PlayerD_SaveSnap.UseVisualStyleBackColor = true;
            this.b_PlayerD_SaveSnap.Click += new System.EventHandler(this.b_PlayerD_SaveSnap_Click);
            // 
            // b_PlayerD_Play
            // 
            this.b_PlayerD_Play.Location = new System.Drawing.Point(320, 662);
            this.b_PlayerD_Play.Name = "b_PlayerD_Play";
            this.b_PlayerD_Play.Size = new System.Drawing.Size(320, 93);
            this.b_PlayerD_Play.TabIndex = 42;
            this.b_PlayerD_Play.Text = "Play";
            this.b_PlayerD_Play.UseVisualStyleBackColor = true;
            this.b_PlayerD_Play.Click += new System.EventHandler(this.b_PlayerD_Play_Click);
            // 
            // Detached
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 767);
            this.Controls.Add(this.gB_PlayerD_Extended);
            this.Controls.Add(this.gB_PlayerD_Simple);
            this.Controls.Add(this.VLCPlayer_D);
            this.Controls.Add(this.checkB_PlayerD_Manual);
            this.Controls.Add(this.b_PlayerD_StartRec);
            this.Controls.Add(this.b_PlayerD_SaveSnap);
            this.Controls.Add(this.b_PlayerD_Play);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Detached";
            this.Text = "Player";
            this.gB_PlayerD_Simple.ResumeLayout(false);
            this.gB_PlayerD_Simple.PerformLayout();
            this.gB_PlayerD_Extended.ResumeLayout(false);
            this.gB_PlayerD_Extended.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_D)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox gB_PlayerD_Simple;
        public System.Windows.Forms.TextBox tB_PlayerD_SimpleAdr;
        public System.Windows.Forms.Label l_PlayerD_SimpleAdr;
        public System.Windows.Forms.GroupBox gB_PlayerD_Extended;
        public System.Windows.Forms.Label l_PlayerD_Type;
        public System.Windows.Forms.Label l_PlayerD_RTSP;
        public System.Windows.Forms.TextBox tB_PlayerD_Adr;
        public System.Windows.Forms.Label l_PlayerD_Password;
        public System.Windows.Forms.TextBox tB_PlayerD_Port;
        public System.Windows.Forms.Label l_PlayerD_Port;
        public System.Windows.Forms.TextBox tB_PlayerD_RTSP;
        public System.Windows.Forms.Label l_PlayerD_Adr;
        public System.Windows.Forms.TextBox tB_PlayerD_Username;
        public System.Windows.Forms.TextBox tB_PlayerD_Buffering;
        public System.Windows.Forms.Label l_PlayerD_Username;
        public System.Windows.Forms.Label l_PlayerD_Buffering;
        public System.Windows.Forms.TextBox tB_PlayerD_Password;
        public System.Windows.Forms.ComboBox cB_PlayerD_Type;
        public AxAXVLC.AxVLCPlugin2 VLCPlayer_D;
        public System.Windows.Forms.CheckBox checkB_PlayerD_Manual;
        public System.Windows.Forms.Button b_PlayerD_StartRec;
        public System.Windows.Forms.Button b_PlayerD_SaveSnap;
        public System.Windows.Forms.Button b_PlayerD_Play;
        public System.Windows.Forms.Label label1;
    }
}