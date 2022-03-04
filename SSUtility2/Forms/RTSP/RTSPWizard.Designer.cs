namespace SSUtility2
{
    partial class RTSPWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTSPWizard));
            this.l_RTSP = new System.Windows.Forms.Label();
            this.tB_Password = new System.Windows.Forms.TextBox();
            this.l_Password = new System.Windows.Forms.Label();
            this.tB_FullAdr = new System.Windows.Forms.TextBox();
            this.l_Username = new System.Windows.Forms.Label();
            this.l_FullAdr = new System.Windows.Forms.Label();
            this.tB_Username = new System.Windows.Forms.TextBox();
            this.tB_RTSPPort = new System.Windows.Forms.TextBox();
            this.tB_RTSPString = new System.Windows.Forms.TextBox();
            this.tB_RTSPIP = new System.Windows.Forms.TextBox();
            this.l_Port = new System.Windows.Forms.Label();
            this.l_Adr = new System.Windows.Forms.Label();
            this.l_Title = new System.Windows.Forms.Label();
            this.b_Confirm = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.b_Forget = new System.Windows.Forms.Button();
            this.tB_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_Scan = new System.Windows.Forms.Button();
            this.l_Control = new System.Windows.Forms.Label();
            this.l_PelcoID = new System.Windows.Forms.Label();
            this.tB_PelcoID = new System.Windows.Forms.TextBox();
            this.tB_ControlIP = new System.Windows.Forms.TextBox();
            this.l_ControlPort = new System.Windows.Forms.Label();
            this.l_ControlIP = new System.Windows.Forms.Label();
            this.check_Manual = new System.Windows.Forms.CheckBox();
            this.l_PresetDetails = new System.Windows.Forms.Label();
            this.cB_ControlPort = new System.Windows.Forms.ComboBox();
            this.cB_Clone = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // l_RTSP
            // 
            this.l_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_RTSP.AutoSize = true;
            this.l_RTSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_RTSP.Location = new System.Drawing.Point(10, 96);
            this.l_RTSP.Name = "l_RTSP";
            this.l_RTSP.Size = new System.Drawing.Size(66, 13);
            this.l_RTSP.TabIndex = 59;
            this.l_RTSP.Text = "RTSP String";
            this.l_RTSP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // tB_Password
            // 
            this.tB_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Password.Location = new System.Drawing.Point(84, 145);
            this.tB_Password.Name = "tB_Password";
            this.tB_Password.Size = new System.Drawing.Size(302, 20);
            this.tB_Password.TabIndex = 5;
            this.tB_Password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_Password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Any_Keyup);
            // 
            // l_Password
            // 
            this.l_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Password.AutoSize = true;
            this.l_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Password.Location = new System.Drawing.Point(10, 148);
            this.l_Password.Name = "l_Password";
            this.l_Password.Size = new System.Drawing.Size(53, 13);
            this.l_Password.TabIndex = 61;
            this.l_Password.Text = "Password";
            this.l_Password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // tB_FullAdr
            // 
            this.tB_FullAdr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_FullAdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_FullAdr.Location = new System.Drawing.Point(85, 320);
            this.tB_FullAdr.Name = "tB_FullAdr";
            this.tB_FullAdr.Size = new System.Drawing.Size(301, 20);
            this.tB_FullAdr.TabIndex = 10;
            this.tB_FullAdr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_FullAdr.TextChanged += new System.EventHandler(this.tB_FullAdr_TextChanged);
            this.tB_FullAdr.Enter += new System.EventHandler(this.tB_FullAdr_Enter);
            this.tB_FullAdr.Leave += new System.EventHandler(this.tB_FullAdr_Leave);
            // 
            // l_Username
            // 
            this.l_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Username.AutoSize = true;
            this.l_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Username.Location = new System.Drawing.Point(10, 122);
            this.l_Username.Name = "l_Username";
            this.l_Username.Size = new System.Drawing.Size(55, 13);
            this.l_Username.TabIndex = 62;
            this.l_Username.Text = "Username";
            this.l_Username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // l_FullAdr
            // 
            this.l_FullAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_FullAdr.AutoSize = true;
            this.l_FullAdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_FullAdr.Location = new System.Drawing.Point(10, 324);
            this.l_FullAdr.Name = "l_FullAdr";
            this.l_FullAdr.Size = new System.Drawing.Size(68, 13);
            this.l_FullAdr.TabIndex = 71;
            this.l_FullAdr.Text = "Full Address*";
            this.l_FullAdr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // tB_Username
            // 
            this.tB_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Username.Location = new System.Drawing.Point(85, 119);
            this.tB_Username.Name = "tB_Username";
            this.tB_Username.Size = new System.Drawing.Size(301, 20);
            this.tB_Username.TabIndex = 4;
            this.tB_Username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_Username.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Any_Keyup);
            // 
            // tB_RTSPPort
            // 
            this.tB_RTSPPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_RTSPPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_RTSPPort.Location = new System.Drawing.Point(84, 67);
            this.tB_RTSPPort.Name = "tB_RTSPPort";
            this.tB_RTSPPort.Size = new System.Drawing.Size(302, 20);
            this.tB_RTSPPort.TabIndex = 2;
            this.tB_RTSPPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_RTSPPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Any_Keyup);
            // 
            // tB_RTSPString
            // 
            this.tB_RTSPString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_RTSPString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_RTSPString.Location = new System.Drawing.Point(85, 93);
            this.tB_RTSPString.Name = "tB_RTSPString";
            this.tB_RTSPString.Size = new System.Drawing.Size(301, 20);
            this.tB_RTSPString.TabIndex = 3;
            this.tB_RTSPString.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_RTSPString.TextChanged += new System.EventHandler(this.tB_RTSPString_TextChanged);
            this.tB_RTSPString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Any_Keyup);
            // 
            // tB_RTSPIP
            // 
            this.tB_RTSPIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_RTSPIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_RTSPIP.Location = new System.Drawing.Point(84, 40);
            this.tB_RTSPIP.Name = "tB_RTSPIP";
            this.tB_RTSPIP.Size = new System.Drawing.Size(302, 20);
            this.tB_RTSPIP.TabIndex = 1;
            this.tB_RTSPIP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_RTSPIP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Any_Keyup);
            // 
            // l_Port
            // 
            this.l_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Port.AutoSize = true;
            this.l_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Port.Location = new System.Drawing.Point(10, 70);
            this.l_Port.Name = "l_Port";
            this.l_Port.Size = new System.Drawing.Size(58, 13);
            this.l_Port.TabIndex = 63;
            this.l_Port.Text = "RTSP Port";
            this.l_Port.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // l_Adr
            // 
            this.l_Adr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Adr.AutoSize = true;
            this.l_Adr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Adr.Location = new System.Drawing.Point(10, 43);
            this.l_Adr.Name = "l_Adr";
            this.l_Adr.Size = new System.Drawing.Size(49, 13);
            this.l_Adr.TabIndex = 64;
            this.l_Adr.Text = "RTSP IP";
            this.l_Adr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // l_Title
            // 
            this.l_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Title.AutoSize = true;
            this.l_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Title.Location = new System.Drawing.Point(9, 9);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(179, 20);
            this.l_Title.TabIndex = 73;
            this.l_Title.Text = "RTSP Stream Details";
            this.l_Title.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // b_Confirm
            // 
            this.b_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Confirm.BackColor = System.Drawing.SystemColors.Control;
            this.b_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Confirm.Location = new System.Drawing.Point(321, 346);
            this.b_Confirm.Name = "b_Confirm";
            this.b_Confirm.Size = new System.Drawing.Size(64, 23);
            this.b_Confirm.TabIndex = 12;
            this.b_Confirm.Text = "Confirm";
            this.b_Confirm.UseVisualStyleBackColor = false;
            this.b_Confirm.Click += new System.EventHandler(this.b_Confirm_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.b_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Cancel.Location = new System.Drawing.Point(251, 346);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(64, 23);
            this.b_Cancel.TabIndex = 11;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = false;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // b_Forget
            // 
            this.b_Forget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Forget.BackColor = System.Drawing.SystemColors.Control;
            this.b_Forget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Forget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Forget.Location = new System.Drawing.Point(13, 346);
            this.b_Forget.Name = "b_Forget";
            this.b_Forget.Size = new System.Drawing.Size(64, 23);
            this.b_Forget.TabIndex = 76;
            this.b_Forget.Text = "Forget";
            this.b_Forget.UseVisualStyleBackColor = false;
            this.b_Forget.Visible = false;
            this.b_Forget.Click += new System.EventHandler(this.b_Forget_Click);
            // 
            // tB_Name
            // 
            this.tB_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Name.Location = new System.Drawing.Point(84, 294);
            this.tB_Name.Name = "tB_Name";
            this.tB_Name.Size = new System.Drawing.Size(301, 20);
            this.tB_Name.TabIndex = 9;
            this.tB_Name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.tB_Name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Name_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Preset Name*";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // b_Scan
            // 
            this.b_Scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Scan.BackColor = System.Drawing.SystemColors.Control;
            this.b_Scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Scan.Location = new System.Drawing.Point(221, 11);
            this.b_Scan.Name = "b_Scan";
            this.b_Scan.Size = new System.Drawing.Size(64, 23);
            this.b_Scan.TabIndex = 80;
            this.b_Scan.Text = "Scan";
            this.b_Scan.UseVisualStyleBackColor = false;
            this.b_Scan.Visible = false;
            // 
            // l_Control
            // 
            this.l_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Control.AutoSize = true;
            this.l_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Control.Location = new System.Drawing.Point(9, 168);
            this.l_Control.Name = "l_Control";
            this.l_Control.Size = new System.Drawing.Size(195, 20);
            this.l_Control.TabIndex = 81;
            this.l_Control.Text = "Camera Control Details";
            this.l_Control.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // l_PelcoID
            // 
            this.l_PelcoID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PelcoID.AutoSize = true;
            this.l_PelcoID.Enabled = false;
            this.l_PelcoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PelcoID.Location = new System.Drawing.Point(10, 198);
            this.l_PelcoID.Name = "l_PelcoID";
            this.l_PelcoID.Size = new System.Drawing.Size(52, 13);
            this.l_PelcoID.TabIndex = 82;
            this.l_PelcoID.Text = "Pelco ID*";
            this.l_PelcoID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // tB_PelcoID
            // 
            this.tB_PelcoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_PelcoID.Enabled = false;
            this.tB_PelcoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_PelcoID.Location = new System.Drawing.Point(85, 195);
            this.tB_PelcoID.Name = "tB_PelcoID";
            this.tB_PelcoID.Size = new System.Drawing.Size(301, 20);
            this.tB_PelcoID.TabIndex = 8;
            this.tB_PelcoID.Text = "1";
            this.tB_PelcoID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // tB_ControlIP
            // 
            this.tB_ControlIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_ControlIP.Enabled = false;
            this.tB_ControlIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_ControlIP.Location = new System.Drawing.Point(84, 221);
            this.tB_ControlIP.Name = "tB_ControlIP";
            this.tB_ControlIP.Size = new System.Drawing.Size(302, 20);
            this.tB_ControlIP.TabIndex = 6;
            this.tB_ControlIP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // l_ControlPort
            // 
            this.l_ControlPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ControlPort.AutoSize = true;
            this.l_ControlPort.Enabled = false;
            this.l_ControlPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ControlPort.Location = new System.Drawing.Point(10, 251);
            this.l_ControlPort.Name = "l_ControlPort";
            this.l_ControlPort.Size = new System.Drawing.Size(62, 13);
            this.l_ControlPort.TabIndex = 83;
            this.l_ControlPort.Text = "Control Port";
            this.l_ControlPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // l_ControlIP
            // 
            this.l_ControlIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_ControlIP.AutoSize = true;
            this.l_ControlIP.Enabled = false;
            this.l_ControlIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ControlIP.Location = new System.Drawing.Point(10, 224);
            this.l_ControlIP.Name = "l_ControlIP";
            this.l_ControlIP.Size = new System.Drawing.Size(53, 13);
            this.l_ControlIP.TabIndex = 84;
            this.l_ControlIP.Text = "Control IP";
            this.l_ControlIP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // check_Manual
            // 
            this.check_Manual.AutoSize = true;
            this.check_Manual.Location = new System.Drawing.Point(325, 172);
            this.check_Manual.Name = "check_Manual";
            this.check_Manual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Manual.Size = new System.Drawing.Size(61, 17);
            this.check_Manual.TabIndex = 85;
            this.check_Manual.Text = "Manual";
            this.check_Manual.UseVisualStyleBackColor = true;
            this.check_Manual.CheckedChanged += new System.EventHandler(this.check_Manual_CheckedChanged);
            // 
            // l_PresetDetails
            // 
            this.l_PresetDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_PresetDetails.AutoSize = true;
            this.l_PresetDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PresetDetails.Location = new System.Drawing.Point(9, 271);
            this.l_PresetDetails.Name = "l_PresetDetails";
            this.l_PresetDetails.Size = new System.Drawing.Size(122, 20);
            this.l_PresetDetails.TabIndex = 86;
            this.l_PresetDetails.Text = "Preset Details";
            this.l_PresetDetails.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // cB_ControlPort
            // 
            this.cB_ControlPort.FormattingEnabled = true;
            this.cB_ControlPort.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_ControlPort.Location = new System.Drawing.Point(85, 248);
            this.cB_ControlPort.Name = "cB_ControlPort";
            this.cB_ControlPort.Size = new System.Drawing.Size(300, 21);
            this.cB_ControlPort.TabIndex = 87;
            this.cB_ControlPort.SelectedIndexChanged += new System.EventHandler(this.cB_ControlPort_SelectedIndexChanged);
            this.cB_ControlPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // cB_Clone
            // 
            this.cB_Clone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Clone.FormattingEnabled = true;
            this.cB_Clone.Items.AddRange(new object[] {
            "Clone..."});
            this.cB_Clone.Location = new System.Drawing.Point(291, 13);
            this.cB_Clone.Name = "cB_Clone";
            this.cB_Clone.Size = new System.Drawing.Size(95, 21);
            this.cB_Clone.TabIndex = 88;
            this.cB_Clone.DropDown += new System.EventHandler(this.cB_Clone_DropDown);
            this.cB_Clone.DropDownClosed += new System.EventHandler(this.cB_Clone_DropDownClosed);
            this.cB_Clone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            // 
            // RTSPWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(394, 381);
            this.Controls.Add(this.cB_Clone);
            this.Controls.Add(this.cB_ControlPort);
            this.Controls.Add(this.l_PresetDetails);
            this.Controls.Add(this.check_Manual);
            this.Controls.Add(this.l_PelcoID);
            this.Controls.Add(this.tB_PelcoID);
            this.Controls.Add(this.tB_ControlIP);
            this.Controls.Add(this.l_ControlPort);
            this.Controls.Add(this.l_ControlIP);
            this.Controls.Add(this.l_Control);
            this.Controls.Add(this.b_Scan);
            this.Controls.Add(this.tB_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Forget);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_Confirm);
            this.Controls.Add(this.l_Title);
            this.Controls.Add(this.l_RTSP);
            this.Controls.Add(this.tB_Password);
            this.Controls.Add(this.l_Password);
            this.Controls.Add(this.tB_FullAdr);
            this.Controls.Add(this.l_Username);
            this.Controls.Add(this.l_FullAdr);
            this.Controls.Add(this.tB_Username);
            this.Controls.Add(this.tB_RTSPPort);
            this.Controls.Add(this.tB_RTSPString);
            this.Controls.Add(this.tB_RTSPIP);
            this.Controls.Add(this.l_Port);
            this.Controls.Add(this.l_Adr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(9999, 420);
            this.MinimumSize = new System.Drawing.Size(410, 420);
            this.Name = "RTSPWizard";
            this.Text = "RTSP Wizard";
            this.Deactivate += new System.EventHandler(this.RTSPWizard_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RTSPWizard_FormClosing);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickOnForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label l_RTSP;
        public System.Windows.Forms.TextBox tB_Password;
        public System.Windows.Forms.Label l_Password;
        public System.Windows.Forms.TextBox tB_FullAdr;
        public System.Windows.Forms.Label l_Username;
        public System.Windows.Forms.Label l_FullAdr;
        public System.Windows.Forms.TextBox tB_Username;
        public System.Windows.Forms.TextBox tB_RTSPPort;
        public System.Windows.Forms.TextBox tB_RTSPString;
        public System.Windows.Forms.TextBox tB_RTSPIP;
        public System.Windows.Forms.Label l_Port;
        public System.Windows.Forms.Label l_Adr;
        public System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Button b_Confirm;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_Forget;
        public System.Windows.Forms.TextBox tB_Name;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_Scan;
        public System.Windows.Forms.Label l_Control;
        public System.Windows.Forms.Label l_PelcoID;
        public System.Windows.Forms.TextBox tB_PelcoID;
        public System.Windows.Forms.TextBox tB_ControlIP;
        public System.Windows.Forms.Label l_ControlPort;
        public System.Windows.Forms.Label l_ControlIP;
        private System.Windows.Forms.CheckBox check_Manual;
        public System.Windows.Forms.Label l_PresetDetails;
        private System.Windows.Forms.ComboBox cB_ControlPort;
        private System.Windows.Forms.ComboBox cB_Clone;
    }
}