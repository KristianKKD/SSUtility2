namespace BigBigLoader
{
    partial class Player
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
            this.b_PlayerL_Pause = new System.Windows.Forms.Button();
            this.l_PlayerL_SimpleAdr = new System.Windows.Forms.Label();
            this.tB_PlayerL_SimpleAdr = new System.Windows.Forms.TextBox();
            this.gB_PlayerL_Extended = new System.Windows.Forms.GroupBox();
            this.l_PlayerL_Type = new System.Windows.Forms.Label();
            this.l_PlayerL_RTSP = new System.Windows.Forms.Label();
            this.tB_PlayerL_Adr = new System.Windows.Forms.TextBox();
            this.l_PlayerL_Password = new System.Windows.Forms.Label();
            this.tB_PlayerL_Port = new System.Windows.Forms.TextBox();
            this.l_PlayerL_Port = new System.Windows.Forms.Label();
            this.tB_PlayerL_RTSP = new System.Windows.Forms.TextBox();
            this.l_PlayerL_Adr = new System.Windows.Forms.Label();
            this.tB_PlayerL_Username = new System.Windows.Forms.TextBox();
            this.tB_PlayerL_Buffering = new System.Windows.Forms.TextBox();
            this.l_PlayerL_Username = new System.Windows.Forms.Label();
            this.l_PlayerL_Buffering = new System.Windows.Forms.Label();
            this.tB_PlayerL_Password = new System.Windows.Forms.TextBox();
            this.cB_PlayerL_Type = new System.Windows.Forms.ComboBox();
            this.checkB_PlayerL_Manual = new System.Windows.Forms.CheckBox();
            this.b_PlayerL_Detach = new System.Windows.Forms.Button();
            this.b_PlayerL_StopRec = new System.Windows.Forms.Button();
            this.b_PlayerL_StartRec = new System.Windows.Forms.Button();
            this.b_PlayerL_SaveSnap = new System.Windows.Forms.Button();
            this.b_PlayerL_Play = new System.Windows.Forms.Button();
            this.gB_PlayerL_Extended.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_PlayerL_Pause
            // 
            this.b_PlayerL_Pause.Location = new System.Drawing.Point(390, 514);
            this.b_PlayerL_Pause.Name = "b_PlayerL_Pause";
            this.b_PlayerL_Pause.Size = new System.Drawing.Size(120, 35);
            this.b_PlayerL_Pause.TabIndex = 40;
            this.b_PlayerL_Pause.Text = "Pause";
            this.b_PlayerL_Pause.UseVisualStyleBackColor = true;
            this.b_PlayerL_Pause.Visible = false;
            // 
            // l_PlayerL_SimpleAdr
            // 
            this.l_PlayerL_SimpleAdr.AutoSize = true;
            this.l_PlayerL_SimpleAdr.Location = new System.Drawing.Point(25, 559);
            this.l_PlayerL_SimpleAdr.Name = "l_PlayerL_SimpleAdr";
            this.l_PlayerL_SimpleAdr.Size = new System.Drawing.Size(80, 13);
            this.l_PlayerL_SimpleAdr.TabIndex = 38;
            this.l_PlayerL_SimpleAdr.Text = "RTSP Address:";
            // 
            // tB_PlayerL_SimpleAdr
            // 
            this.tB_PlayerL_SimpleAdr.Location = new System.Drawing.Point(108, 556);
            this.tB_PlayerL_SimpleAdr.Name = "tB_PlayerL_SimpleAdr";
            this.tB_PlayerL_SimpleAdr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_SimpleAdr.TabIndex = 39;
            // 
            // gB_PlayerL_Extended
            // 
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_Type);
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_RTSP);
            this.gB_PlayerL_Extended.Controls.Add(this.tB_PlayerL_Adr);
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_Password);
            this.gB_PlayerL_Extended.Controls.Add(this.tB_PlayerL_Port);
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_Port);
            this.gB_PlayerL_Extended.Controls.Add(this.tB_PlayerL_RTSP);
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_Adr);
            this.gB_PlayerL_Extended.Controls.Add(this.tB_PlayerL_Username);
            this.gB_PlayerL_Extended.Controls.Add(this.tB_PlayerL_Buffering);
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_Username);
            this.gB_PlayerL_Extended.Controls.Add(this.l_PlayerL_Buffering);
            this.gB_PlayerL_Extended.Controls.Add(this.tB_PlayerL_Password);
            this.gB_PlayerL_Extended.Controls.Add(this.cB_PlayerL_Type);
            this.gB_PlayerL_Extended.Enabled = false;
            this.gB_PlayerL_Extended.Location = new System.Drawing.Point(19, 542);
            this.gB_PlayerL_Extended.Name = "gB_PlayerL_Extended";
            this.gB_PlayerL_Extended.Size = new System.Drawing.Size(313, 194);
            this.gB_PlayerL_Extended.TabIndex = 37;
            this.gB_PlayerL_Extended.TabStop = false;
            this.gB_PlayerL_Extended.Visible = false;
            // 
            // l_PlayerL_Type
            // 
            this.l_PlayerL_Type.AutoSize = true;
            this.l_PlayerL_Type.Location = new System.Drawing.Point(6, 17);
            this.l_PlayerL_Type.Name = "l_PlayerL_Type";
            this.l_PlayerL_Type.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerL_Type.TabIndex = 2;
            this.l_PlayerL_Type.Text = "Encoder Type:";
            // 
            // l_PlayerL_RTSP
            // 
            this.l_PlayerL_RTSP.AutoSize = true;
            this.l_PlayerL_RTSP.Location = new System.Drawing.Point(6, 91);
            this.l_PlayerL_RTSP.Name = "l_PlayerL_RTSP";
            this.l_PlayerL_RTSP.Size = new System.Drawing.Size(69, 13);
            this.l_PlayerL_RTSP.TabIndex = 2;
            this.l_PlayerL_RTSP.Text = "RTSP String:";
            // 
            // tB_PlayerL_Adr
            // 
            this.tB_PlayerL_Adr.Location = new System.Drawing.Point(89, 41);
            this.tB_PlayerL_Adr.Name = "tB_PlayerL_Adr";
            this.tB_PlayerL_Adr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_Adr.TabIndex = 4;
            this.tB_PlayerL_Adr.Text = "192.168.1.71";
            // 
            // l_PlayerL_Password
            // 
            this.l_PlayerL_Password.AutoSize = true;
            this.l_PlayerL_Password.Location = new System.Drawing.Point(6, 168);
            this.l_PlayerL_Password.Name = "l_PlayerL_Password";
            this.l_PlayerL_Password.Size = new System.Drawing.Size(56, 13);
            this.l_PlayerL_Password.TabIndex = 2;
            this.l_PlayerL_Password.Text = "Password:";
            // 
            // tB_PlayerL_Port
            // 
            this.tB_PlayerL_Port.Location = new System.Drawing.Point(89, 67);
            this.tB_PlayerL_Port.Name = "tB_PlayerL_Port";
            this.tB_PlayerL_Port.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_Port.TabIndex = 4;
            this.tB_PlayerL_Port.Text = "554";
            // 
            // l_PlayerL_Port
            // 
            this.l_PlayerL_Port.AutoSize = true;
            this.l_PlayerL_Port.Location = new System.Drawing.Point(6, 66);
            this.l_PlayerL_Port.Name = "l_PlayerL_Port";
            this.l_PlayerL_Port.Size = new System.Drawing.Size(29, 13);
            this.l_PlayerL_Port.TabIndex = 2;
            this.l_PlayerL_Port.Text = "Port:";
            // 
            // tB_PlayerL_RTSP
            // 
            this.tB_PlayerL_RTSP.Location = new System.Drawing.Point(89, 92);
            this.tB_PlayerL_RTSP.Name = "tB_PlayerL_RTSP";
            this.tB_PlayerL_RTSP.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_RTSP.TabIndex = 4;
            this.tB_PlayerL_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            // 
            // l_PlayerL_Adr
            // 
            this.l_PlayerL_Adr.AutoSize = true;
            this.l_PlayerL_Adr.Location = new System.Drawing.Point(6, 43);
            this.l_PlayerL_Adr.Name = "l_PlayerL_Adr";
            this.l_PlayerL_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_PlayerL_Adr.TabIndex = 2;
            this.l_PlayerL_Adr.Text = "IP Address:";
            // 
            // tB_PlayerL_Username
            // 
            this.tB_PlayerL_Username.Location = new System.Drawing.Point(89, 144);
            this.tB_PlayerL_Username.Name = "tB_PlayerL_Username";
            this.tB_PlayerL_Username.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_Username.TabIndex = 4;
            this.tB_PlayerL_Username.Text = "admin";
            // 
            // tB_PlayerL_Buffering
            // 
            this.tB_PlayerL_Buffering.Location = new System.Drawing.Point(89, 118);
            this.tB_PlayerL_Buffering.Name = "tB_PlayerL_Buffering";
            this.tB_PlayerL_Buffering.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_Buffering.TabIndex = 4;
            this.tB_PlayerL_Buffering.Text = "200";
            // 
            // l_PlayerL_Username
            // 
            this.l_PlayerL_Username.AutoSize = true;
            this.l_PlayerL_Username.Location = new System.Drawing.Point(6, 143);
            this.l_PlayerL_Username.Name = "l_PlayerL_Username";
            this.l_PlayerL_Username.Size = new System.Drawing.Size(58, 13);
            this.l_PlayerL_Username.TabIndex = 2;
            this.l_PlayerL_Username.Text = "Username:";
            // 
            // l_PlayerL_Buffering
            // 
            this.l_PlayerL_Buffering.AutoSize = true;
            this.l_PlayerL_Buffering.Location = new System.Drawing.Point(6, 117);
            this.l_PlayerL_Buffering.Name = "l_PlayerL_Buffering";
            this.l_PlayerL_Buffering.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerL_Buffering.TabIndex = 2;
            this.l_PlayerL_Buffering.Text = "Buffering (ms): ";
            // 
            // tB_PlayerL_Password
            // 
            this.tB_PlayerL_Password.Location = new System.Drawing.Point(89, 170);
            this.tB_PlayerL_Password.Name = "tB_PlayerL_Password";
            this.tB_PlayerL_Password.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_Password.TabIndex = 4;
            this.tB_PlayerL_Password.Text = "admin";
            // 
            // cB_PlayerL_Type
            // 
            this.cB_PlayerL_Type.FormattingEnabled = true;
            this.cB_PlayerL_Type.Items.AddRange(new object[] {
            "IONodes - Daylight",
            "IONodes - Thermal",
            "VIVOTEK",
            "BOSCH"});
            this.cB_PlayerL_Type.Location = new System.Drawing.Point(89, 14);
            this.cB_PlayerL_Type.Name = "cB_PlayerL_Type";
            this.cB_PlayerL_Type.Size = new System.Drawing.Size(214, 21);
            this.cB_PlayerL_Type.TabIndex = 5;
            // 
            // checkB_PlayerL_Manual
            // 
            this.checkB_PlayerL_Manual.AutoSize = true;
            this.checkB_PlayerL_Manual.Location = new System.Drawing.Point(10, 519);
            this.checkB_PlayerL_Manual.Name = "checkB_PlayerL_Manual";
            this.checkB_PlayerL_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_PlayerL_Manual.TabIndex = 36;
            this.checkB_PlayerL_Manual.Text = "Extended RTSP Controls";
            this.checkB_PlayerL_Manual.UseVisualStyleBackColor = true;
            // 
            // b_PlayerL_Detach
            // 
            this.b_PlayerL_Detach.Location = new System.Drawing.Point(338, 631);
            this.b_PlayerL_Detach.Name = "b_PlayerL_Detach";
            this.b_PlayerL_Detach.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_Detach.TabIndex = 31;
            this.b_PlayerL_Detach.Text = "Detach Video";
            this.b_PlayerL_Detach.UseVisualStyleBackColor = true;
            // 
            // b_PlayerL_StopRec
            // 
            this.b_PlayerL_StopRec.Location = new System.Drawing.Point(338, 606);
            this.b_PlayerL_StopRec.Name = "b_PlayerL_StopRec";
            this.b_PlayerL_StopRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_StopRec.TabIndex = 32;
            this.b_PlayerL_StopRec.Text = "STOP Recording";
            this.b_PlayerL_StopRec.UseVisualStyleBackColor = true;
            // 
            // b_PlayerL_StartRec
            // 
            this.b_PlayerL_StartRec.Location = new System.Drawing.Point(338, 580);
            this.b_PlayerL_StartRec.Name = "b_PlayerL_StartRec";
            this.b_PlayerL_StartRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_StartRec.TabIndex = 33;
            this.b_PlayerL_StartRec.Text = "START Recording";
            this.b_PlayerL_StartRec.UseVisualStyleBackColor = true;
            // 
            // b_PlayerL_SaveSnap
            // 
            this.b_PlayerL_SaveSnap.Location = new System.Drawing.Point(338, 553);
            this.b_PlayerL_SaveSnap.Name = "b_PlayerL_SaveSnap";
            this.b_PlayerL_SaveSnap.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_SaveSnap.TabIndex = 34;
            this.b_PlayerL_SaveSnap.Text = "Save Snapshot";
            this.b_PlayerL_SaveSnap.UseVisualStyleBackColor = true;
            // 
            // b_PlayerL_Play
            // 
            this.b_PlayerL_Play.Location = new System.Drawing.Point(4, 742);
            this.b_PlayerL_Play.Name = "b_PlayerL_Play";
            this.b_PlayerL_Play.Size = new System.Drawing.Size(506, 23);
            this.b_PlayerL_Play.TabIndex = 30;
            this.b_PlayerL_Play.Text = "Play";
            this.b_PlayerL_Play.UseVisualStyleBackColor = true;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 772);
            this.Controls.Add(this.b_PlayerL_Pause);
            this.Controls.Add(this.l_PlayerL_SimpleAdr);
            this.Controls.Add(this.tB_PlayerL_SimpleAdr);
            this.Controls.Add(this.gB_PlayerL_Extended);
            this.Controls.Add(this.checkB_PlayerL_Manual);
            this.Controls.Add(this.b_PlayerL_Detach);
            this.Controls.Add(this.b_PlayerL_StopRec);
            this.Controls.Add(this.b_PlayerL_StartRec);
            this.Controls.Add(this.b_PlayerL_SaveSnap);
            this.Controls.Add(this.b_PlayerL_Play);
            this.Name = "Player";
            this.Text = "Player";
            this.gB_PlayerL_Extended.ResumeLayout(false);
            this.gB_PlayerL_Extended.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_PlayerL_Pause;
        private System.Windows.Forms.Label l_PlayerL_SimpleAdr;
        private System.Windows.Forms.TextBox tB_PlayerL_SimpleAdr;
        private System.Windows.Forms.GroupBox gB_PlayerL_Extended;
        private System.Windows.Forms.Label l_PlayerL_Type;
        private System.Windows.Forms.Label l_PlayerL_RTSP;
        private System.Windows.Forms.TextBox tB_PlayerL_Adr;
        private System.Windows.Forms.Label l_PlayerL_Password;
        private System.Windows.Forms.TextBox tB_PlayerL_Port;
        private System.Windows.Forms.Label l_PlayerL_Port;
        private System.Windows.Forms.TextBox tB_PlayerL_RTSP;
        private System.Windows.Forms.Label l_PlayerL_Adr;
        private System.Windows.Forms.TextBox tB_PlayerL_Username;
        private System.Windows.Forms.TextBox tB_PlayerL_Buffering;
        private System.Windows.Forms.Label l_PlayerL_Username;
        private System.Windows.Forms.Label l_PlayerL_Buffering;
        private System.Windows.Forms.TextBox tB_PlayerL_Password;
        private System.Windows.Forms.ComboBox cB_PlayerL_Type;
        private System.Windows.Forms.CheckBox checkB_PlayerL_Manual;
        private System.Windows.Forms.Button b_PlayerL_Detach;
        private System.Windows.Forms.Button b_PlayerL_StopRec;
        private System.Windows.Forms.Button b_PlayerL_StartRec;
        private System.Windows.Forms.Button b_PlayerL_SaveSnap;
        private System.Windows.Forms.Button b_PlayerL_Play;
    }
}