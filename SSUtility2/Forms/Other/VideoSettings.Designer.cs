
namespace SSUtility2
{
    partial class VideoSettings
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
            this.l_Name = new System.Windows.Forms.Label();
            this.tB_PlayerD_Name = new System.Windows.Forms.TextBox();
            this.p_PlayerD_Simple = new System.Windows.Forms.Panel();
            this.tB_PlayerD_SimpleAdr = new System.Windows.Forms.TextBox();
            this.l_PlayerD_SimpleAdr = new System.Windows.Forms.Label();
            this.p_PlayerD_Extended = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.l_PlayerD_Type = new System.Windows.Forms.Label();
            this.cB_PlayerD_Type = new System.Windows.Forms.ComboBox();
            this.l_PlayerD_RTSP = new System.Windows.Forms.Label();
            this.tB_PlayerD_Password = new System.Windows.Forms.TextBox();
            this.tB_PlayerD_Adr = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Buffering = new System.Windows.Forms.Label();
            this.l_PlayerD_Password = new System.Windows.Forms.Label();
            this.l_PlayerD_Username = new System.Windows.Forms.Label();
            this.tB_PlayerD_Port = new System.Windows.Forms.TextBox();
            this.tB_PlayerD_Buffering = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Port = new System.Windows.Forms.Label();
            this.tB_PlayerD_Username = new System.Windows.Forms.TextBox();
            this.tB_PlayerD_RTSP = new System.Windows.Forms.TextBox();
            this.l_PlayerD_Adr = new System.Windows.Forms.Label();
            this.checkB_PlayerD_Manual = new System.Windows.Forms.CheckBox();
            this.b_Play = new System.Windows.Forms.Button();
            this.p_PlayerD_Simple.SuspendLayout();
            this.p_PlayerD_Extended.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_Name
            // 
            this.l_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Name.AutoSize = true;
            this.l_Name.Location = new System.Drawing.Point(12, 9);
            this.l_Name.Name = "l_Name";
            this.l_Name.Size = new System.Drawing.Size(70, 13);
            this.l_Name.TabIndex = 58;
            this.l_Name.Text = "Player Name:";
            // 
            // tB_PlayerD_Name
            // 
            this.tB_PlayerD_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Name.Location = new System.Drawing.Point(92, 6);
            this.tB_PlayerD_Name.Name = "tB_PlayerD_Name";
            this.tB_PlayerD_Name.Size = new System.Drawing.Size(213, 20);
            this.tB_PlayerD_Name.TabIndex = 54;
            // 
            // p_PlayerD_Simple
            // 
            this.p_PlayerD_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_PlayerD_Simple.Controls.Add(this.tB_PlayerD_SimpleAdr);
            this.p_PlayerD_Simple.Controls.Add(this.l_PlayerD_SimpleAdr);
            this.p_PlayerD_Simple.Location = new System.Drawing.Point(7, 32);
            this.p_PlayerD_Simple.Name = "p_PlayerD_Simple";
            this.p_PlayerD_Simple.Size = new System.Drawing.Size(301, 203);
            this.p_PlayerD_Simple.TabIndex = 57;
            // 
            // tB_PlayerD_SimpleAdr
            // 
            this.tB_PlayerD_SimpleAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_SimpleAdr.Location = new System.Drawing.Point(85, 5);
            this.tB_PlayerD_SimpleAdr.Name = "tB_PlayerD_SimpleAdr";
            this.tB_PlayerD_SimpleAdr.Size = new System.Drawing.Size(213, 20);
            this.tB_PlayerD_SimpleAdr.TabIndex = 28;
            // 
            // l_PlayerD_SimpleAdr
            // 
            this.l_PlayerD_SimpleAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_SimpleAdr.AutoSize = true;
            this.l_PlayerD_SimpleAdr.Location = new System.Drawing.Point(5, 6);
            this.l_PlayerD_SimpleAdr.Name = "l_PlayerD_SimpleAdr";
            this.l_PlayerD_SimpleAdr.Size = new System.Drawing.Size(80, 13);
            this.l_PlayerD_SimpleAdr.TabIndex = 27;
            this.l_PlayerD_SimpleAdr.Text = "RTSP Address:";
            // 
            // p_PlayerD_Extended
            // 
            this.p_PlayerD_Extended.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_PlayerD_Extended.Controls.Add(this.label1);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_Type);
            this.p_PlayerD_Extended.Controls.Add(this.cB_PlayerD_Type);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_RTSP);
            this.p_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Password);
            this.p_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Adr);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_Buffering);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_Password);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_Username);
            this.p_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Port);
            this.p_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Buffering);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_Port);
            this.p_PlayerD_Extended.Controls.Add(this.tB_PlayerD_Username);
            this.p_PlayerD_Extended.Controls.Add(this.tB_PlayerD_RTSP);
            this.p_PlayerD_Extended.Controls.Add(this.l_PlayerD_Adr);
            this.p_PlayerD_Extended.Location = new System.Drawing.Point(7, 32);
            this.p_PlayerD_Extended.Name = "p_PlayerD_Extended";
            this.p_PlayerD_Extended.Size = new System.Drawing.Size(301, 203);
            this.p_PlayerD_Extended.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "*Changed fields will not apply until the stream is replayed*";
            // 
            // l_PlayerD_Type
            // 
            this.l_PlayerD_Type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Type.AutoSize = true;
            this.l_PlayerD_Type.Location = new System.Drawing.Point(5, 8);
            this.l_PlayerD_Type.Name = "l_PlayerD_Type";
            this.l_PlayerD_Type.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerD_Type.TabIndex = 2;
            this.l_PlayerD_Type.Text = "Encoder Type:";
            // 
            // cB_PlayerD_Type
            // 
            this.cB_PlayerD_Type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_PlayerD_Type.FormattingEnabled = true;
            this.cB_PlayerD_Type.Items.AddRange(new object[] {
            "IONodes - Daylight",
            "IONodes - Thermal",
            "VIVOTEK",
            "BOSCH"});
            this.cB_PlayerD_Type.Location = new System.Drawing.Point(88, 5);
            this.cB_PlayerD_Type.Name = "cB_PlayerD_Type";
            this.cB_PlayerD_Type.Size = new System.Drawing.Size(210, 21);
            this.cB_PlayerD_Type.TabIndex = 5;
            this.cB_PlayerD_Type.Text = "Daylight";
            this.cB_PlayerD_Type.SelectedIndexChanged += new System.EventHandler(this.cB_PlayerD_Type_SelectedIndexChanged);
            // 
            // l_PlayerD_RTSP
            // 
            this.l_PlayerD_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_RTSP.AutoSize = true;
            this.l_PlayerD_RTSP.Location = new System.Drawing.Point(5, 82);
            this.l_PlayerD_RTSP.Name = "l_PlayerD_RTSP";
            this.l_PlayerD_RTSP.Size = new System.Drawing.Size(69, 13);
            this.l_PlayerD_RTSP.TabIndex = 2;
            this.l_PlayerD_RTSP.Text = "RTSP String:";
            // 
            // tB_PlayerD_Password
            // 
            this.tB_PlayerD_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Password.Location = new System.Drawing.Point(88, 161);
            this.tB_PlayerD_Password.Name = "tB_PlayerD_Password";
            this.tB_PlayerD_Password.Size = new System.Drawing.Size(210, 20);
            this.tB_PlayerD_Password.TabIndex = 4;
            this.tB_PlayerD_Password.Text = "admin";
            // 
            // tB_PlayerD_Adr
            // 
            this.tB_PlayerD_Adr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Adr.Location = new System.Drawing.Point(88, 32);
            this.tB_PlayerD_Adr.Name = "tB_PlayerD_Adr";
            this.tB_PlayerD_Adr.Size = new System.Drawing.Size(211, 20);
            this.tB_PlayerD_Adr.TabIndex = 4;
            this.tB_PlayerD_Adr.Text = "192.168.1.71";
            // 
            // l_PlayerD_Buffering
            // 
            this.l_PlayerD_Buffering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Buffering.AutoSize = true;
            this.l_PlayerD_Buffering.Location = new System.Drawing.Point(5, 108);
            this.l_PlayerD_Buffering.Name = "l_PlayerD_Buffering";
            this.l_PlayerD_Buffering.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerD_Buffering.TabIndex = 2;
            this.l_PlayerD_Buffering.Text = "Buffering (ms): ";
            // 
            // l_PlayerD_Password
            // 
            this.l_PlayerD_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Password.AutoSize = true;
            this.l_PlayerD_Password.Location = new System.Drawing.Point(5, 159);
            this.l_PlayerD_Password.Name = "l_PlayerD_Password";
            this.l_PlayerD_Password.Size = new System.Drawing.Size(56, 13);
            this.l_PlayerD_Password.TabIndex = 2;
            this.l_PlayerD_Password.Text = "Password:";
            // 
            // l_PlayerD_Username
            // 
            this.l_PlayerD_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Username.AutoSize = true;
            this.l_PlayerD_Username.Location = new System.Drawing.Point(5, 134);
            this.l_PlayerD_Username.Name = "l_PlayerD_Username";
            this.l_PlayerD_Username.Size = new System.Drawing.Size(58, 13);
            this.l_PlayerD_Username.TabIndex = 2;
            this.l_PlayerD_Username.Text = "Username:";
            // 
            // tB_PlayerD_Port
            // 
            this.tB_PlayerD_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Port.Location = new System.Drawing.Point(88, 58);
            this.tB_PlayerD_Port.Name = "tB_PlayerD_Port";
            this.tB_PlayerD_Port.Size = new System.Drawing.Size(210, 20);
            this.tB_PlayerD_Port.TabIndex = 4;
            this.tB_PlayerD_Port.Text = "554";
            // 
            // tB_PlayerD_Buffering
            // 
            this.tB_PlayerD_Buffering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Buffering.Location = new System.Drawing.Point(88, 109);
            this.tB_PlayerD_Buffering.Name = "tB_PlayerD_Buffering";
            this.tB_PlayerD_Buffering.Size = new System.Drawing.Size(210, 20);
            this.tB_PlayerD_Buffering.TabIndex = 4;
            this.tB_PlayerD_Buffering.Text = "200";
            // 
            // l_PlayerD_Port
            // 
            this.l_PlayerD_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Port.AutoSize = true;
            this.l_PlayerD_Port.Location = new System.Drawing.Point(5, 59);
            this.l_PlayerD_Port.Name = "l_PlayerD_Port";
            this.l_PlayerD_Port.Size = new System.Drawing.Size(29, 13);
            this.l_PlayerD_Port.TabIndex = 2;
            this.l_PlayerD_Port.Text = "Port:";
            // 
            // tB_PlayerD_Username
            // 
            this.tB_PlayerD_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Username.Location = new System.Drawing.Point(88, 135);
            this.tB_PlayerD_Username.Name = "tB_PlayerD_Username";
            this.tB_PlayerD_Username.Size = new System.Drawing.Size(210, 20);
            this.tB_PlayerD_Username.TabIndex = 4;
            this.tB_PlayerD_Username.Text = "admin";
            // 
            // tB_PlayerD_RTSP
            // 
            this.tB_PlayerD_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_RTSP.Location = new System.Drawing.Point(88, 83);
            this.tB_PlayerD_RTSP.Name = "tB_PlayerD_RTSP";
            this.tB_PlayerD_RTSP.Size = new System.Drawing.Size(210, 20);
            this.tB_PlayerD_RTSP.TabIndex = 4;
            this.tB_PlayerD_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            // 
            // l_PlayerD_Adr
            // 
            this.l_PlayerD_Adr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Adr.AutoSize = true;
            this.l_PlayerD_Adr.Location = new System.Drawing.Point(5, 34);
            this.l_PlayerD_Adr.Name = "l_PlayerD_Adr";
            this.l_PlayerD_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_PlayerD_Adr.TabIndex = 2;
            this.l_PlayerD_Adr.Text = "IP Address:";
            // 
            // checkB_PlayerD_Manual
            // 
            this.checkB_PlayerD_Manual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkB_PlayerD_Manual.AutoSize = true;
            this.checkB_PlayerD_Manual.Location = new System.Drawing.Point(7, 252);
            this.checkB_PlayerD_Manual.Name = "checkB_PlayerD_Manual";
            this.checkB_PlayerD_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_PlayerD_Manual.TabIndex = 55;
            this.checkB_PlayerD_Manual.Text = "Extended RTSP Controls";
            this.checkB_PlayerD_Manual.UseVisualStyleBackColor = true;
            this.checkB_PlayerD_Manual.CheckedChanged += new System.EventHandler(this.checkB_PlayerD_Manual_CheckedChanged);
            // 
            // b_Play
            // 
            this.b_Play.BackColor = System.Drawing.SystemColors.Control;
            this.b_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Play.Location = new System.Drawing.Point(218, 241);
            this.b_Play.Name = "b_Play";
            this.b_Play.Size = new System.Drawing.Size(90, 28);
            this.b_Play.TabIndex = 59;
            this.b_Play.Text = "Play";
            this.b_Play.UseVisualStyleBackColor = false;
            this.b_Play.Click += new System.EventHandler(this.b_Play_Click);
            // 
            // VideoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(318, 280);
            this.Controls.Add(this.b_Play);
            this.Controls.Add(this.l_Name);
            this.Controls.Add(this.tB_PlayerD_Name);
            this.Controls.Add(this.p_PlayerD_Simple);
            this.Controls.Add(this.p_PlayerD_Extended);
            this.Controls.Add(this.checkB_PlayerD_Manual);
            this.MinimumSize = new System.Drawing.Size(334, 303);
            this.Name = "VideoSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoSettings_FormClosing);
            this.p_PlayerD_Simple.ResumeLayout(false);
            this.p_PlayerD_Simple.PerformLayout();
            this.p_PlayerD_Extended.ResumeLayout(false);
            this.p_PlayerD_Extended.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Name;
        public System.Windows.Forms.TextBox tB_PlayerD_Name;
        private System.Windows.Forms.Panel p_PlayerD_Simple;
        public System.Windows.Forms.TextBox tB_PlayerD_SimpleAdr;
        public System.Windows.Forms.Label l_PlayerD_SimpleAdr;
        private System.Windows.Forms.Panel p_PlayerD_Extended;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label l_PlayerD_Type;
        public System.Windows.Forms.ComboBox cB_PlayerD_Type;
        public System.Windows.Forms.Label l_PlayerD_RTSP;
        public System.Windows.Forms.TextBox tB_PlayerD_Password;
        public System.Windows.Forms.TextBox tB_PlayerD_Adr;
        public System.Windows.Forms.Label l_PlayerD_Buffering;
        public System.Windows.Forms.Label l_PlayerD_Password;
        public System.Windows.Forms.Label l_PlayerD_Username;
        public System.Windows.Forms.TextBox tB_PlayerD_Port;
        public System.Windows.Forms.TextBox tB_PlayerD_Buffering;
        public System.Windows.Forms.Label l_PlayerD_Port;
        public System.Windows.Forms.TextBox tB_PlayerD_Username;
        public System.Windows.Forms.TextBox tB_PlayerD_RTSP;
        public System.Windows.Forms.Label l_PlayerD_Adr;
        public System.Windows.Forms.CheckBox checkB_PlayerD_Manual;
        private System.Windows.Forms.Button b_Play;
    }
}