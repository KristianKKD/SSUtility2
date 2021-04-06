
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoSettings));
            this.l_PlayerD_Name = new System.Windows.Forms.Label();
            this.tB_PlayerD_Name = new System.Windows.Forms.TextBox();
            this.tB_PlayerD_SimpleAdr = new System.Windows.Forms.TextBox();
            this.l_PlayerD_SimpleAdr = new System.Windows.Forms.Label();
            this.l_PlayerD_CamType = new System.Windows.Forms.Label();
            this.cB_PlayerD_CamType = new System.Windows.Forms.ComboBox();
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
            this.b_PlayerD_Play = new System.Windows.Forms.Button();
            this.b_PlayerD_Stop = new System.Windows.Forms.Button();
            this.tC_PlayerSettings = new System.Windows.Forms.TabControl();
            this.tP_Main = new System.Windows.Forms.TabPage();
            this.tP_Secondary = new System.Windows.Forms.TabPage();
            this.b_Secondary_Play = new System.Windows.Forms.Button();
            this.b_Secondary_Stop = new System.Windows.Forms.Button();
            this.b_Hide = new System.Windows.Forms.Button();
            this.tC_PlayerSettings.SuspendLayout();
            this.tP_Main.SuspendLayout();
            this.tP_Secondary.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_PlayerD_Name
            // 
            this.l_PlayerD_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Name.AutoSize = true;
            this.l_PlayerD_Name.Location = new System.Drawing.Point(11, 10);
            this.l_PlayerD_Name.Name = "l_PlayerD_Name";
            this.l_PlayerD_Name.Size = new System.Drawing.Size(70, 13);
            this.l_PlayerD_Name.TabIndex = 58;
            this.l_PlayerD_Name.Text = "Player Name:";
            // 
            // tB_PlayerD_Name
            // 
            this.tB_PlayerD_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Name.Location = new System.Drawing.Point(94, 7);
            this.tB_PlayerD_Name.Name = "tB_PlayerD_Name";
            this.tB_PlayerD_Name.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_Name.TabIndex = 54;
            this.tB_PlayerD_Name.TextChanged += new System.EventHandler(this.tB_PlayerD_Name_TextChanged);
            this.tB_PlayerD_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_PlayerD_Name_KeyPress);
            // 
            // tB_PlayerD_SimpleAdr
            // 
            this.tB_PlayerD_SimpleAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_SimpleAdr.Location = new System.Drawing.Point(94, 36);
            this.tB_PlayerD_SimpleAdr.Name = "tB_PlayerD_SimpleAdr";
            this.tB_PlayerD_SimpleAdr.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_SimpleAdr.TabIndex = 28;
            this.tB_PlayerD_SimpleAdr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_PlayerD_SimpleAdr_KeyPress);
            // 
            // l_PlayerD_SimpleAdr
            // 
            this.l_PlayerD_SimpleAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_SimpleAdr.AutoSize = true;
            this.l_PlayerD_SimpleAdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PlayerD_SimpleAdr.Location = new System.Drawing.Point(11, 39);
            this.l_PlayerD_SimpleAdr.Name = "l_PlayerD_SimpleAdr";
            this.l_PlayerD_SimpleAdr.Size = new System.Drawing.Size(67, 13);
            this.l_PlayerD_SimpleAdr.TabIndex = 27;
            this.l_PlayerD_SimpleAdr.Text = "Full Address:";
            // 
            // l_PlayerD_CamType
            // 
            this.l_PlayerD_CamType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_CamType.AutoSize = true;
            this.l_PlayerD_CamType.Location = new System.Drawing.Point(11, 78);
            this.l_PlayerD_CamType.Name = "l_PlayerD_CamType";
            this.l_PlayerD_CamType.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerD_CamType.TabIndex = 2;
            this.l_PlayerD_CamType.Text = "Encoder Type:";
            // 
            // cB_PlayerD_CamType
            // 
            this.cB_PlayerD_CamType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_PlayerD_CamType.FormattingEnabled = true;
            this.cB_PlayerD_CamType.Items.AddRange(new object[] {
            "IONodes - Daylight",
            "IONodes - Thermal",
            "VIVOTEK",
            "BOSCH"});
            this.cB_PlayerD_CamType.Location = new System.Drawing.Point(94, 75);
            this.cB_PlayerD_CamType.Name = "cB_PlayerD_CamType";
            this.cB_PlayerD_CamType.Size = new System.Drawing.Size(349, 21);
            this.cB_PlayerD_CamType.TabIndex = 5;
            this.cB_PlayerD_CamType.Text = "Daylight";
            this.cB_PlayerD_CamType.SelectedIndexChanged += new System.EventHandler(this.cB_PlayerD_Type_SelectedIndexChanged);
            this.cB_PlayerD_CamType.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // l_PlayerD_RTSP
            // 
            this.l_PlayerD_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_RTSP.AutoSize = true;
            this.l_PlayerD_RTSP.Location = new System.Drawing.Point(11, 158);
            this.l_PlayerD_RTSP.Name = "l_PlayerD_RTSP";
            this.l_PlayerD_RTSP.Size = new System.Drawing.Size(69, 13);
            this.l_PlayerD_RTSP.TabIndex = 2;
            this.l_PlayerD_RTSP.Text = "RTSP String:";
            this.l_PlayerD_RTSP.Visible = false;
            // 
            // tB_PlayerD_Password
            // 
            this.tB_PlayerD_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Password.Location = new System.Drawing.Point(94, 233);
            this.tB_PlayerD_Password.Name = "tB_PlayerD_Password";
            this.tB_PlayerD_Password.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_Password.TabIndex = 4;
            this.tB_PlayerD_Password.Text = "admin";
            this.tB_PlayerD_Password.Visible = false;
            this.tB_PlayerD_Password.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // tB_PlayerD_Adr
            // 
            this.tB_PlayerD_Adr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Adr.Location = new System.Drawing.Point(94, 102);
            this.tB_PlayerD_Adr.Name = "tB_PlayerD_Adr";
            this.tB_PlayerD_Adr.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_Adr.TabIndex = 4;
            this.tB_PlayerD_Adr.Text = "192.168.1.71";
            this.tB_PlayerD_Adr.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // l_PlayerD_Buffering
            // 
            this.l_PlayerD_Buffering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Buffering.AutoSize = true;
            this.l_PlayerD_Buffering.Location = new System.Drawing.Point(11, 184);
            this.l_PlayerD_Buffering.Name = "l_PlayerD_Buffering";
            this.l_PlayerD_Buffering.Size = new System.Drawing.Size(77, 13);
            this.l_PlayerD_Buffering.TabIndex = 2;
            this.l_PlayerD_Buffering.Text = "Buffering (ms): ";
            this.l_PlayerD_Buffering.Visible = false;
            // 
            // l_PlayerD_Password
            // 
            this.l_PlayerD_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Password.AutoSize = true;
            this.l_PlayerD_Password.Location = new System.Drawing.Point(11, 236);
            this.l_PlayerD_Password.Name = "l_PlayerD_Password";
            this.l_PlayerD_Password.Size = new System.Drawing.Size(56, 13);
            this.l_PlayerD_Password.TabIndex = 2;
            this.l_PlayerD_Password.Text = "Password:";
            this.l_PlayerD_Password.Visible = false;
            // 
            // l_PlayerD_Username
            // 
            this.l_PlayerD_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Username.AutoSize = true;
            this.l_PlayerD_Username.Location = new System.Drawing.Point(11, 210);
            this.l_PlayerD_Username.Name = "l_PlayerD_Username";
            this.l_PlayerD_Username.Size = new System.Drawing.Size(58, 13);
            this.l_PlayerD_Username.TabIndex = 2;
            this.l_PlayerD_Username.Text = "Username:";
            this.l_PlayerD_Username.Visible = false;
            // 
            // tB_PlayerD_Port
            // 
            this.tB_PlayerD_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Port.Location = new System.Drawing.Point(94, 129);
            this.tB_PlayerD_Port.Name = "tB_PlayerD_Port";
            this.tB_PlayerD_Port.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_Port.TabIndex = 4;
            this.tB_PlayerD_Port.Text = "554";
            this.tB_PlayerD_Port.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // tB_PlayerD_Buffering
            // 
            this.tB_PlayerD_Buffering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Buffering.Location = new System.Drawing.Point(94, 181);
            this.tB_PlayerD_Buffering.Name = "tB_PlayerD_Buffering";
            this.tB_PlayerD_Buffering.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_Buffering.TabIndex = 4;
            this.tB_PlayerD_Buffering.Text = "200";
            this.tB_PlayerD_Buffering.Visible = false;
            this.tB_PlayerD_Buffering.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // l_PlayerD_Port
            // 
            this.l_PlayerD_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Port.AutoSize = true;
            this.l_PlayerD_Port.Location = new System.Drawing.Point(11, 132);
            this.l_PlayerD_Port.Name = "l_PlayerD_Port";
            this.l_PlayerD_Port.Size = new System.Drawing.Size(68, 13);
            this.l_PlayerD_Port.TabIndex = 2;
            this.l_PlayerD_Port.Text = "Port:             ";
            // 
            // tB_PlayerD_Username
            // 
            this.tB_PlayerD_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_Username.Location = new System.Drawing.Point(94, 207);
            this.tB_PlayerD_Username.Name = "tB_PlayerD_Username";
            this.tB_PlayerD_Username.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_Username.TabIndex = 4;
            this.tB_PlayerD_Username.Text = "admin";
            this.tB_PlayerD_Username.Visible = false;
            this.tB_PlayerD_Username.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // tB_PlayerD_RTSP
            // 
            this.tB_PlayerD_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PlayerD_RTSP.Location = new System.Drawing.Point(94, 155);
            this.tB_PlayerD_RTSP.Name = "tB_PlayerD_RTSP";
            this.tB_PlayerD_RTSP.Size = new System.Drawing.Size(349, 20);
            this.tB_PlayerD_RTSP.TabIndex = 4;
            this.tB_PlayerD_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            this.tB_PlayerD_RTSP.Visible = false;
            this.tB_PlayerD_RTSP.TextChanged += new System.EventHandler(this.tB_TextChanged);
            // 
            // l_PlayerD_Adr
            // 
            this.l_PlayerD_Adr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PlayerD_Adr.AutoSize = true;
            this.l_PlayerD_Adr.Location = new System.Drawing.Point(11, 105);
            this.l_PlayerD_Adr.Name = "l_PlayerD_Adr";
            this.l_PlayerD_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_PlayerD_Adr.TabIndex = 2;
            this.l_PlayerD_Adr.Text = "IP Address:";
            // 
            // checkB_PlayerD_Manual
            // 
            this.checkB_PlayerD_Manual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkB_PlayerD_Manual.AutoSize = true;
            this.checkB_PlayerD_Manual.Location = new System.Drawing.Point(6, 265);
            this.checkB_PlayerD_Manual.Name = "checkB_PlayerD_Manual";
            this.checkB_PlayerD_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_PlayerD_Manual.TabIndex = 55;
            this.checkB_PlayerD_Manual.Text = "Extended RTSP Controls";
            this.checkB_PlayerD_Manual.UseVisualStyleBackColor = true;
            this.checkB_PlayerD_Manual.CheckedChanged += new System.EventHandler(this.checkB_PlayerD_Manual_CheckedChanged);
            // 
            // b_PlayerD_Play
            // 
            this.b_PlayerD_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PlayerD_Play.BackColor = System.Drawing.SystemColors.Control;
            this.b_PlayerD_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PlayerD_Play.Location = new System.Drawing.Point(395, 259);
            this.b_PlayerD_Play.Name = "b_PlayerD_Play";
            this.b_PlayerD_Play.Size = new System.Drawing.Size(54, 23);
            this.b_PlayerD_Play.TabIndex = 59;
            this.b_PlayerD_Play.Text = "Play";
            this.b_PlayerD_Play.UseVisualStyleBackColor = false;
            this.b_PlayerD_Play.Click += new System.EventHandler(this.b_Play_Click);
            // 
            // b_PlayerD_Stop
            // 
            this.b_PlayerD_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PlayerD_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.b_PlayerD_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PlayerD_Stop.Location = new System.Drawing.Point(335, 259);
            this.b_PlayerD_Stop.Name = "b_PlayerD_Stop";
            this.b_PlayerD_Stop.Size = new System.Drawing.Size(54, 23);
            this.b_PlayerD_Stop.TabIndex = 61;
            this.b_PlayerD_Stop.Text = "Stop";
            this.b_PlayerD_Stop.UseVisualStyleBackColor = false;
            this.b_PlayerD_Stop.Click += new System.EventHandler(this.b_Stop_Click);
            // 
            // tC_PlayerSettings
            // 
            this.tC_PlayerSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tC_PlayerSettings.Controls.Add(this.tP_Main);
            this.tC_PlayerSettings.Controls.Add(this.tP_Secondary);
            this.tC_PlayerSettings.Location = new System.Drawing.Point(12, 12);
            this.tC_PlayerSettings.Name = "tC_PlayerSettings";
            this.tC_PlayerSettings.SelectedIndex = 0;
            this.tC_PlayerSettings.Size = new System.Drawing.Size(463, 314);
            this.tC_PlayerSettings.TabIndex = 62;
            // 
            // tP_Main
            // 
            this.tP_Main.Controls.Add(this.l_PlayerD_RTSP);
            this.tP_Main.Controls.Add(this.tB_PlayerD_Password);
            this.tP_Main.Controls.Add(this.l_PlayerD_CamType);
            this.tP_Main.Controls.Add(this.l_PlayerD_Buffering);
            this.tP_Main.Controls.Add(this.cB_PlayerD_CamType);
            this.tP_Main.Controls.Add(this.l_PlayerD_Password);
            this.tP_Main.Controls.Add(this.tB_PlayerD_SimpleAdr);
            this.tP_Main.Controls.Add(this.l_PlayerD_Username);
            this.tP_Main.Controls.Add(this.tB_PlayerD_Buffering);
            this.tP_Main.Controls.Add(this.l_PlayerD_SimpleAdr);
            this.tP_Main.Controls.Add(this.tB_PlayerD_Username);
            this.tP_Main.Controls.Add(this.tB_PlayerD_Port);
            this.tP_Main.Controls.Add(this.tB_PlayerD_RTSP);
            this.tP_Main.Controls.Add(this.tB_PlayerD_Adr);
            this.tP_Main.Controls.Add(this.b_PlayerD_Play);
            this.tP_Main.Controls.Add(this.l_PlayerD_Port);
            this.tP_Main.Controls.Add(this.b_PlayerD_Stop);
            this.tP_Main.Controls.Add(this.l_PlayerD_Name);
            this.tP_Main.Controls.Add(this.tB_PlayerD_Name);
            this.tP_Main.Controls.Add(this.checkB_PlayerD_Manual);
            this.tP_Main.Controls.Add(this.l_PlayerD_Adr);
            this.tP_Main.Location = new System.Drawing.Point(4, 22);
            this.tP_Main.Name = "tP_Main";
            this.tP_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Main.Size = new System.Drawing.Size(455, 288);
            this.tP_Main.TabIndex = 0;
            this.tP_Main.Text = "Main Player";
            this.tP_Main.UseVisualStyleBackColor = true;
            // 
            // tP_Secondary
            // 
            this.tP_Secondary.Controls.Add(this.b_Secondary_Play);
            this.tP_Secondary.Controls.Add(this.b_Secondary_Stop);
            this.tP_Secondary.Controls.Add(this.b_Hide);
            this.tP_Secondary.Location = new System.Drawing.Point(4, 22);
            this.tP_Secondary.Name = "tP_Secondary";
            this.tP_Secondary.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Secondary.Size = new System.Drawing.Size(455, 288);
            this.tP_Secondary.TabIndex = 1;
            this.tP_Secondary.Text = "Secondary Player";
            this.tP_Secondary.UseVisualStyleBackColor = true;
            // 
            // b_Secondary_Play
            // 
            this.b_Secondary_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Secondary_Play.BackColor = System.Drawing.SystemColors.Control;
            this.b_Secondary_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Secondary_Play.Location = new System.Drawing.Point(395, 259);
            this.b_Secondary_Play.Name = "b_Secondary_Play";
            this.b_Secondary_Play.Size = new System.Drawing.Size(54, 23);
            this.b_Secondary_Play.TabIndex = 64;
            this.b_Secondary_Play.Text = "Play";
            this.b_Secondary_Play.UseVisualStyleBackColor = false;
            this.b_Secondary_Play.Click += new System.EventHandler(this.b_Secondary_Play_Click);
            // 
            // b_Secondary_Stop
            // 
            this.b_Secondary_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Secondary_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.b_Secondary_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Secondary_Stop.Location = new System.Drawing.Point(335, 259);
            this.b_Secondary_Stop.Name = "b_Secondary_Stop";
            this.b_Secondary_Stop.Size = new System.Drawing.Size(54, 23);
            this.b_Secondary_Stop.TabIndex = 66;
            this.b_Secondary_Stop.Text = "Stop";
            this.b_Secondary_Stop.UseVisualStyleBackColor = false;
            this.b_Secondary_Stop.Click += new System.EventHandler(this.b_Secondary_Stop_Click);
            // 
            // b_Hide
            // 
            this.b_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Hide.BackColor = System.Drawing.SystemColors.Control;
            this.b_Hide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Hide.Location = new System.Drawing.Point(256, 259);
            this.b_Hide.Name = "b_Hide";
            this.b_Hide.Size = new System.Drawing.Size(73, 23);
            this.b_Hide.TabIndex = 65;
            this.b_Hide.Text = "Hide Player";
            this.b_Hide.UseVisualStyleBackColor = false;
            this.b_Hide.Visible = false;
            this.b_Hide.Click += new System.EventHandler(this.b_Hide_Click);
            // 
            // VideoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 336);
            this.Controls.Add(this.tC_PlayerSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoSettings_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.VideoSettings_VisibleChanged);
            this.tC_PlayerSettings.ResumeLayout(false);
            this.tP_Main.ResumeLayout(false);
            this.tP_Main.PerformLayout();
            this.tP_Secondary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label l_PlayerD_Name;
        public System.Windows.Forms.TextBox tB_PlayerD_Name;
        public System.Windows.Forms.TextBox tB_PlayerD_SimpleAdr;
        public System.Windows.Forms.Label l_PlayerD_SimpleAdr;
        public System.Windows.Forms.Label l_PlayerD_CamType;
        public System.Windows.Forms.ComboBox cB_PlayerD_CamType;
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
        public System.Windows.Forms.Button b_PlayerD_Play;
        public System.Windows.Forms.Button b_PlayerD_Stop;
        public System.Windows.Forms.TabControl tC_PlayerSettings;
        public System.Windows.Forms.TabPage tP_Main;
        public System.Windows.Forms.TabPage tP_Secondary;
        public System.Windows.Forms.Button b_Secondary_Play;
        public System.Windows.Forms.Button b_Secondary_Stop;
        public System.Windows.Forms.Button b_Hide;
    }
}