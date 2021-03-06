
namespace SSUtility2
{
    partial class SettingsPage
    {

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.b_Settings_Default = new System.Windows.Forms.Button();
            this.cB_Rec_Quality = new System.Windows.Forms.ComboBox();
            this.l_Rec_Quality = new System.Windows.Forms.Label();
            this.tB_Rec_scFileN = new System.Windows.Forms.TextBox();
            this.l_Rec_sCFileN = new System.Windows.Forms.Label();
            this.cB_Rec_FPS = new System.Windows.Forms.ComboBox();
            this.tB_Rec_vFileN = new System.Windows.Forms.TextBox();
            this.l_Rec_vFileN = new System.Windows.Forms.Label();
            this.l_Rec_FPS = new System.Windows.Forms.Label();
            this.l_Paths_sCFolder = new System.Windows.Forms.Label();
            this.b_Paths_sCBrowse = new System.Windows.Forms.Button();
            this.tB_Paths_sCFolder = new System.Windows.Forms.TextBox();
            this.l_Paths_vFolder = new System.Windows.Forms.Label();
            this.tB_Paths_vFolder = new System.Windows.Forms.TextBox();
            this.b_Paths_vBrowse = new System.Windows.Forms.Button();
            this.l_Paths_vCheck = new System.Windows.Forms.Label();
            this.l_Paths_sCCheck = new System.Windows.Forms.Label();
            this.check_Paths_Manual = new System.Windows.Forms.CheckBox();
            this.cB_Other_RefreshRate = new System.Windows.Forms.ComboBox();
            this.check_Other_AutoPlay = new System.Windows.Forms.CheckBox();
            this.l_Other_CommandRate = new System.Windows.Forms.Label();
            this.check_Other_Subnet = new System.Windows.Forms.CheckBox();
            this.b_ChangeDir = new System.Windows.Forms.Button();
            this.tC_Settings = new System.Windows.Forms.TabControl();
            this.tP_Control = new System.Windows.Forms.TabPage();
            this.cB_ipCon_Selected = new System.Windows.Forms.ComboBox();
            this.l_ipCon_Selected = new System.Windows.Forms.Label();
            this.tB_IPCon_Port = new System.Windows.Forms.TextBox();
            this.tB_IPCon_Adr = new System.Windows.Forms.TextBox();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.cB_IPCon_Type = new System.Windows.Forms.ComboBox();
            this.l_IPCon_Port = new System.Windows.Forms.Label();
            this.l_IPCon_ConType = new System.Windows.Forms.Label();
            this.l_IPCon_Adr = new System.Windows.Forms.Label();
            this.tP_Paths = new System.Windows.Forms.TabPage();
            this.tP_Recording = new System.Windows.Forms.TabPage();
            this.tP_Presets = new System.Windows.Forms.TabPage();
            this.l_Presets_8 = new System.Windows.Forms.Label();
            this.tB_Presets_8 = new System.Windows.Forms.TextBox();
            this.l_Presets_7 = new System.Windows.Forms.Label();
            this.tB_Presets_7 = new System.Windows.Forms.TextBox();
            this.l_Presets_6 = new System.Windows.Forms.Label();
            this.tB_Presets_6 = new System.Windows.Forms.TextBox();
            this.l_Presets_5 = new System.Windows.Forms.Label();
            this.tB_Presets_5 = new System.Windows.Forms.TextBox();
            this.l_Presets_4 = new System.Windows.Forms.Label();
            this.tB_Presets_4 = new System.Windows.Forms.TextBox();
            this.l_Presets_3 = new System.Windows.Forms.Label();
            this.tB_Presets_3 = new System.Windows.Forms.TextBox();
            this.l_Presets_2 = new System.Windows.Forms.Label();
            this.tB_Presets_2 = new System.Windows.Forms.TextBox();
            this.l_Presets_1 = new System.Windows.Forms.Label();
            this.tB_Presets_1 = new System.Windows.Forms.TextBox();
            this.tP_Other = new System.Windows.Forms.TabPage();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.l_Version = new System.Windows.Forms.Label();
            this.tC_Settings.SuspendLayout();
            this.tP_Control.SuspendLayout();
            this.tP_Paths.SuspendLayout();
            this.tP_Recording.SuspendLayout();
            this.tP_Presets.SuspendLayout();
            this.tP_Other.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_Settings_Default
            // 
            this.b_Settings_Default.BackColor = System.Drawing.SystemColors.Control;
            this.b_Settings_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Settings_Default.Location = new System.Drawing.Point(12, 215);
            this.b_Settings_Default.Name = "b_Settings_Default";
            this.b_Settings_Default.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Default.TabIndex = 14;
            this.b_Settings_Default.Text = "Default All";
            this.b_Settings_Default.UseVisualStyleBackColor = false;
            this.b_Settings_Default.Click += new System.EventHandler(this.b_Settings_Default_Click);
            // 
            // cB_Rec_Quality
            // 
            this.cB_Rec_Quality.BackColor = System.Drawing.SystemColors.Window;
            this.cB_Rec_Quality.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cB_Rec_Quality.FormattingEnabled = true;
            this.cB_Rec_Quality.Items.AddRange(new object[] {
            "50",
            "70",
            "100"});
            this.cB_Rec_Quality.Location = new System.Drawing.Point(132, 41);
            this.cB_Rec_Quality.Name = "cB_Rec_Quality";
            this.cB_Rec_Quality.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_Quality.TabIndex = 26;
            this.cB_Rec_Quality.TextChanged += new System.EventHandler(this.cB_Rec_Quality_TextChanged);
            // 
            // l_Rec_Quality
            // 
            this.l_Rec_Quality.AutoSize = true;
            this.l_Rec_Quality.Location = new System.Drawing.Point(6, 44);
            this.l_Rec_Quality.Name = "l_Rec_Quality";
            this.l_Rec_Quality.Size = new System.Drawing.Size(75, 13);
            this.l_Rec_Quality.TabIndex = 25;
            this.l_Rec_Quality.Text = "Quality (1-100)";
            // 
            // tB_Rec_scFileN
            // 
            this.tB_Rec_scFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Rec_scFileN.Enabled = false;
            this.tB_Rec_scFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Rec_scFileN.Location = new System.Drawing.Point(132, 98);
            this.tB_Rec_scFileN.Name = "tB_Rec_scFileN";
            this.tB_Rec_scFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_scFileN.TabIndex = 24;
            this.tB_Rec_scFileN.TextChanged += new System.EventHandler(this.tB_Rec_scFileN_TextChanged);
            // 
            // l_Rec_sCFileN
            // 
            this.l_Rec_sCFileN.AutoSize = true;
            this.l_Rec_sCFileN.Location = new System.Drawing.Point(6, 102);
            this.l_Rec_sCFileN.Name = "l_Rec_sCFileN";
            this.l_Rec_sCFileN.Size = new System.Drawing.Size(102, 13);
            this.l_Rec_sCFileN.TabIndex = 23;
            this.l_Rec_sCFileN.Text = "Snapshot File Name";
            // 
            // cB_Rec_FPS
            // 
            this.cB_Rec_FPS.BackColor = System.Drawing.SystemColors.Window;
            this.cB_Rec_FPS.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cB_Rec_FPS.FormattingEnabled = true;
            this.cB_Rec_FPS.Items.AddRange(new object[] {
            "15",
            "24",
            "30",
            "45",
            "60"});
            this.cB_Rec_FPS.Location = new System.Drawing.Point(132, 14);
            this.cB_Rec_FPS.Name = "cB_Rec_FPS";
            this.cB_Rec_FPS.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_FPS.TabIndex = 16;
            this.cB_Rec_FPS.TextChanged += new System.EventHandler(this.cB_Rec_FPS_TextChanged);
            // 
            // tB_Rec_vFileN
            // 
            this.tB_Rec_vFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Rec_vFileN.Enabled = false;
            this.tB_Rec_vFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Rec_vFileN.Location = new System.Drawing.Point(132, 72);
            this.tB_Rec_vFileN.Name = "tB_Rec_vFileN";
            this.tB_Rec_vFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_vFileN.TabIndex = 22;
            this.tB_Rec_vFileN.TextChanged += new System.EventHandler(this.tB_Rec_vFileN_TextChanged);
            // 
            // l_Rec_vFileN
            // 
            this.l_Rec_vFileN.AutoSize = true;
            this.l_Rec_vFileN.Location = new System.Drawing.Point(6, 75);
            this.l_Rec_vFileN.Name = "l_Rec_vFileN";
            this.l_Rec_vFileN.Size = new System.Drawing.Size(84, 13);
            this.l_Rec_vFileN.TabIndex = 21;
            this.l_Rec_vFileN.Text = "Video File Name";
            // 
            // l_Rec_FPS
            // 
            this.l_Rec_FPS.AutoSize = true;
            this.l_Rec_FPS.Location = new System.Drawing.Point(6, 14);
            this.l_Rec_FPS.Name = "l_Rec_FPS";
            this.l_Rec_FPS.Size = new System.Drawing.Size(57, 13);
            this.l_Rec_FPS.TabIndex = 2;
            this.l_Rec_FPS.Text = "Frame rate";
            // 
            // l_Paths_sCFolder
            // 
            this.l_Paths_sCFolder.AutoSize = true;
            this.l_Paths_sCFolder.Location = new System.Drawing.Point(5, 44);
            this.l_Paths_sCFolder.Name = "l_Paths_sCFolder";
            this.l_Paths_sCFolder.Size = new System.Drawing.Size(84, 13);
            this.l_Paths_sCFolder.TabIndex = 2;
            this.l_Paths_sCFolder.Text = "Snapshot Folder";
            // 
            // b_Paths_sCBrowse
            // 
            this.b_Paths_sCBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Paths_sCBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Paths_sCBrowse.Enabled = false;
            this.b_Paths_sCBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Paths_sCBrowse.Location = new System.Drawing.Point(315, 39);
            this.b_Paths_sCBrowse.Name = "b_Paths_sCBrowse";
            this.b_Paths_sCBrowse.Size = new System.Drawing.Size(27, 22);
            this.b_Paths_sCBrowse.TabIndex = 13;
            this.b_Paths_sCBrowse.Text = "...";
            this.b_Paths_sCBrowse.UseVisualStyleBackColor = false;
            this.b_Paths_sCBrowse.Click += new System.EventHandler(this.b_Paths_sCBrowse_Click);
            // 
            // tB_Paths_sCFolder
            // 
            this.tB_Paths_sCFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Paths_sCFolder.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Paths_sCFolder.Enabled = false;
            this.tB_Paths_sCFolder.Location = new System.Drawing.Point(112, 41);
            this.tB_Paths_sCFolder.Name = "tB_Paths_sCFolder";
            this.tB_Paths_sCFolder.Size = new System.Drawing.Size(197, 20);
            this.tB_Paths_sCFolder.TabIndex = 16;
            this.tB_Paths_sCFolder.TextChanged += new System.EventHandler(this.tB_Paths_sCFolder_TextChanged);
            // 
            // l_Paths_vFolder
            // 
            this.l_Paths_vFolder.AutoSize = true;
            this.l_Paths_vFolder.Location = new System.Drawing.Point(5, 77);
            this.l_Paths_vFolder.Name = "l_Paths_vFolder";
            this.l_Paths_vFolder.Size = new System.Drawing.Size(101, 13);
            this.l_Paths_vFolder.TabIndex = 17;
            this.l_Paths_vFolder.Text = "Video Output Folder";
            // 
            // tB_Paths_vFolder
            // 
            this.tB_Paths_vFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Paths_vFolder.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Paths_vFolder.Enabled = false;
            this.tB_Paths_vFolder.Location = new System.Drawing.Point(112, 74);
            this.tB_Paths_vFolder.Name = "tB_Paths_vFolder";
            this.tB_Paths_vFolder.Size = new System.Drawing.Size(197, 20);
            this.tB_Paths_vFolder.TabIndex = 18;
            this.tB_Paths_vFolder.TextChanged += new System.EventHandler(this.tB_Paths_vFolder_TextChanged);
            // 
            // b_Paths_vBrowse
            // 
            this.b_Paths_vBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Paths_vBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Paths_vBrowse.Enabled = false;
            this.b_Paths_vBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Paths_vBrowse.Location = new System.Drawing.Point(315, 72);
            this.b_Paths_vBrowse.Name = "b_Paths_vBrowse";
            this.b_Paths_vBrowse.Size = new System.Drawing.Size(26, 22);
            this.b_Paths_vBrowse.TabIndex = 19;
            this.b_Paths_vBrowse.Text = "...";
            this.b_Paths_vBrowse.UseVisualStyleBackColor = false;
            this.b_Paths_vBrowse.Click += new System.EventHandler(this.b_Paths_vBrowse_Click);
            // 
            // l_Paths_vCheck
            // 
            this.l_Paths_vCheck.AutoSize = true;
            this.l_Paths_vCheck.Location = new System.Drawing.Point(373, 77);
            this.l_Paths_vCheck.Name = "l_Paths_vCheck";
            this.l_Paths_vCheck.Size = new System.Drawing.Size(0, 13);
            this.l_Paths_vCheck.TabIndex = 20;
            // 
            // l_Paths_sCCheck
            // 
            this.l_Paths_sCCheck.AutoSize = true;
            this.l_Paths_sCCheck.Location = new System.Drawing.Point(373, 44);
            this.l_Paths_sCCheck.Name = "l_Paths_sCCheck";
            this.l_Paths_sCCheck.Size = new System.Drawing.Size(0, 13);
            this.l_Paths_sCCheck.TabIndex = 16;
            // 
            // check_Paths_Manual
            // 
            this.check_Paths_Manual.Checked = true;
            this.check_Paths_Manual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Paths_Manual.Location = new System.Drawing.Point(6, 14);
            this.check_Paths_Manual.Name = "check_Paths_Manual";
            this.check_Paths_Manual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Paths_Manual.Size = new System.Drawing.Size(119, 21);
            this.check_Paths_Manual.TabIndex = 32;
            this.check_Paths_Manual.Text = "Automatic Paths";
            this.check_Paths_Manual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Paths_Manual, "Automatic paths are Documents\\SSUtility\\Saved\\[CAMERA NAME]");
            this.check_Paths_Manual.UseVisualStyleBackColor = true;
            this.check_Paths_Manual.CheckedChanged += new System.EventHandler(this.check_Paths_Manual_CheckedChanged);
            // 
            // cB_Other_RefreshRate
            // 
            this.cB_Other_RefreshRate.BackColor = System.Drawing.SystemColors.Window;
            this.cB_Other_RefreshRate.FormattingEnabled = true;
            this.cB_Other_RefreshRate.Items.AddRange(new object[] {
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            this.cB_Other_RefreshRate.Location = new System.Drawing.Point(166, 65);
            this.cB_Other_RefreshRate.Name = "cB_Other_RefreshRate";
            this.cB_Other_RefreshRate.Size = new System.Drawing.Size(114, 21);
            this.cB_Other_RefreshRate.TabIndex = 28;
            this.cB_Other_RefreshRate.TextChanged += new System.EventHandler(this.cB_Other_RefreshRate_TextChanged);
            // 
            // check_Other_AutoPlay
            // 
            this.check_Other_AutoPlay.Location = new System.Drawing.Point(6, 16);
            this.check_Other_AutoPlay.Name = "check_Other_AutoPlay";
            this.check_Other_AutoPlay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_AutoPlay.Size = new System.Drawing.Size(174, 17);
            this.check_Other_AutoPlay.TabIndex = 30;
            this.check_Other_AutoPlay.Text = "Autoplay Videos on Launch";
            this.check_Other_AutoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Other_AutoPlay.UseVisualStyleBackColor = true;
            this.check_Other_AutoPlay.CheckedChanged += new System.EventHandler(this.check_Other_AutoPlay_CheckedChanged);
            // 
            // l_Other_CommandRate
            // 
            this.l_Other_CommandRate.AutoSize = true;
            this.l_Other_CommandRate.Location = new System.Drawing.Point(7, 68);
            this.l_Other_CommandRate.Name = "l_Other_CommandRate";
            this.l_Other_CommandRate.Size = new System.Drawing.Size(130, 13);
            this.l_Other_CommandRate.TabIndex = 27;
            this.l_Other_CommandRate.Text = "Command Send Rate (ms)";
            // 
            // check_Other_Subnet
            // 
            this.check_Other_Subnet.Location = new System.Drawing.Point(6, 39);
            this.check_Other_Subnet.Name = "check_Other_Subnet";
            this.check_Other_Subnet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_Subnet.Size = new System.Drawing.Size(174, 17);
            this.check_Other_Subnet.TabIndex = 0;
            this.check_Other_Subnet.Text = "Hide Subnet Notification";
            this.check_Other_Subnet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Other_Subnet.UseVisualStyleBackColor = true;
            this.check_Other_Subnet.CheckedChanged += new System.EventHandler(this.check_Other_Subnet_CheckedChanged);
            // 
            // b_ChangeDir
            // 
            this.b_ChangeDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_ChangeDir.BackColor = System.Drawing.SystemColors.Control;
            this.b_ChangeDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_ChangeDir.Location = new System.Drawing.Point(8, 146);
            this.b_ChangeDir.Name = "b_ChangeDir";
            this.b_ChangeDir.Size = new System.Drawing.Size(113, 23);
            this.b_ChangeDir.TabIndex = 30;
            this.b_ChangeDir.Text = "Change Directory";
            this.b_ChangeDir.UseVisualStyleBackColor = false;
            this.b_ChangeDir.Click += new System.EventHandler(this.b_ChangeDir_Click);
            // 
            // tC_Settings
            // 
            this.tC_Settings.Controls.Add(this.tP_Control);
            this.tC_Settings.Controls.Add(this.tP_Paths);
            this.tC_Settings.Controls.Add(this.tP_Recording);
            this.tC_Settings.Controls.Add(this.tP_Presets);
            this.tC_Settings.Controls.Add(this.tP_Other);
            this.tC_Settings.Location = new System.Drawing.Point(12, 12);
            this.tC_Settings.Name = "tC_Settings";
            this.tC_Settings.SelectedIndex = 0;
            this.tC_Settings.Size = new System.Drawing.Size(356, 201);
            this.tC_Settings.TabIndex = 31;
            // 
            // tP_Control
            // 
            this.tP_Control.Controls.Add(this.cB_ipCon_Selected);
            this.tP_Control.Controls.Add(this.l_ipCon_Selected);
            this.tP_Control.Controls.Add(this.tB_IPCon_Port);
            this.tP_Control.Controls.Add(this.tB_IPCon_Adr);
            this.tP_Control.Controls.Add(this.l_IPCon_Connected);
            this.tP_Control.Controls.Add(this.cB_IPCon_Type);
            this.tP_Control.Controls.Add(this.l_IPCon_Port);
            this.tP_Control.Controls.Add(this.l_IPCon_ConType);
            this.tP_Control.Controls.Add(this.l_IPCon_Adr);
            this.tP_Control.Location = new System.Drawing.Point(4, 22);
            this.tP_Control.Name = "tP_Control";
            this.tP_Control.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Control.Size = new System.Drawing.Size(348, 175);
            this.tP_Control.TabIndex = 3;
            this.tP_Control.Text = "IP Control";
            this.tP_Control.UseVisualStyleBackColor = true;
            // 
            // cB_ipCon_Selected
            // 
            this.cB_ipCon_Selected.FormattingEnabled = true;
            this.cB_ipCon_Selected.Items.AddRange(new object[] {
            "Daylight",
            "Thermal"});
            this.cB_ipCon_Selected.Location = new System.Drawing.Point(115, 92);
            this.cB_ipCon_Selected.Name = "cB_ipCon_Selected";
            this.cB_ipCon_Selected.Size = new System.Drawing.Size(123, 21);
            this.cB_ipCon_Selected.TabIndex = 83;
            this.cB_ipCon_Selected.Text = "Daylight";
            this.cB_ipCon_Selected.TextUpdate += new System.EventHandler(this.cB_ipCon_Selected_TextUpdate);
            // 
            // l_ipCon_Selected
            // 
            this.l_ipCon_Selected.AutoSize = true;
            this.l_ipCon_Selected.Location = new System.Drawing.Point(6, 95);
            this.l_ipCon_Selected.Name = "l_ipCon_Selected";
            this.l_ipCon_Selected.Size = new System.Drawing.Size(88, 13);
            this.l_ipCon_Selected.TabIndex = 82;
            this.l_ipCon_Selected.Text = "Selected Camera";
            // 
            // tB_IPCon_Port
            // 
            this.tB_IPCon_Port.Location = new System.Drawing.Point(115, 66);
            this.tB_IPCon_Port.Name = "tB_IPCon_Port";
            this.tB_IPCon_Port.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Port.TabIndex = 78;
            this.tB_IPCon_Port.Text = "6791";
            this.tB_IPCon_Port.TextChanged += new System.EventHandler(this.tB_IPCon_Port_TextChanged);
            // 
            // tB_IPCon_Adr
            // 
            this.tB_IPCon_Adr.Location = new System.Drawing.Point(115, 40);
            this.tB_IPCon_Adr.Name = "tB_IPCon_Adr";
            this.tB_IPCon_Adr.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Adr.TabIndex = 77;
            this.tB_IPCon_Adr.Text = "192.168.1.71";
            this.tB_IPCon_Adr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_IPCon_Adr_KeyDown);
            this.tB_IPCon_Adr.Leave += new System.EventHandler(this.tB_IPCon_Adr_Leave);
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(254, 43);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Connected.TabIndex = 81;
            // 
            // cB_IPCon_Type
            // 
            this.cB_IPCon_Type.FormattingEnabled = true;
            this.cB_IPCon_Type.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_IPCon_Type.Location = new System.Drawing.Point(115, 13);
            this.cB_IPCon_Type.Name = "cB_IPCon_Type";
            this.cB_IPCon_Type.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_Type.TabIndex = 80;
            this.cB_IPCon_Type.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_Type_SelectedIndexChanged);
            // 
            // l_IPCon_Port
            // 
            this.l_IPCon_Port.AutoSize = true;
            this.l_IPCon_Port.Location = new System.Drawing.Point(6, 69);
            this.l_IPCon_Port.Name = "l_IPCon_Port";
            this.l_IPCon_Port.Size = new System.Drawing.Size(70, 13);
            this.l_IPCon_Port.TabIndex = 75;
            this.l_IPCon_Port.Text = "Address Port:";
            // 
            // l_IPCon_ConType
            // 
            this.l_IPCon_ConType.AutoSize = true;
            this.l_IPCon_ConType.Location = new System.Drawing.Point(6, 16);
            this.l_IPCon_ConType.Name = "l_IPCon_ConType";
            this.l_IPCon_ConType.Size = new System.Drawing.Size(103, 13);
            this.l_IPCon_ConType.TabIndex = 74;
            this.l_IPCon_ConType.Text = "Preset Control Type:";
            // 
            // l_IPCon_Adr
            // 
            this.l_IPCon_Adr.AutoSize = true;
            this.l_IPCon_Adr.Location = new System.Drawing.Point(6, 43);
            this.l_IPCon_Adr.Name = "l_IPCon_Adr";
            this.l_IPCon_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_IPCon_Adr.TabIndex = 73;
            this.l_IPCon_Adr.Text = "IP Address:";
            // 
            // tP_Paths
            // 
            this.tP_Paths.Controls.Add(this.b_ChangeDir);
            this.tP_Paths.Controls.Add(this.check_Paths_Manual);
            this.tP_Paths.Controls.Add(this.l_Paths_sCFolder);
            this.tP_Paths.Controls.Add(this.l_Paths_sCCheck);
            this.tP_Paths.Controls.Add(this.b_Paths_sCBrowse);
            this.tP_Paths.Controls.Add(this.l_Paths_vCheck);
            this.tP_Paths.Controls.Add(this.tB_Paths_sCFolder);
            this.tP_Paths.Controls.Add(this.b_Paths_vBrowse);
            this.tP_Paths.Controls.Add(this.l_Paths_vFolder);
            this.tP_Paths.Controls.Add(this.tB_Paths_vFolder);
            this.tP_Paths.Location = new System.Drawing.Point(4, 22);
            this.tP_Paths.Name = "tP_Paths";
            this.tP_Paths.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Paths.Size = new System.Drawing.Size(348, 175);
            this.tP_Paths.TabIndex = 0;
            this.tP_Paths.Text = "Paths";
            this.tP_Paths.UseVisualStyleBackColor = true;
            // 
            // tP_Recording
            // 
            this.tP_Recording.Controls.Add(this.cB_Rec_Quality);
            this.tP_Recording.Controls.Add(this.l_Rec_Quality);
            this.tP_Recording.Controls.Add(this.l_Rec_FPS);
            this.tP_Recording.Controls.Add(this.tB_Rec_scFileN);
            this.tP_Recording.Controls.Add(this.l_Rec_vFileN);
            this.tP_Recording.Controls.Add(this.l_Rec_sCFileN);
            this.tP_Recording.Controls.Add(this.tB_Rec_vFileN);
            this.tP_Recording.Controls.Add(this.cB_Rec_FPS);
            this.tP_Recording.Location = new System.Drawing.Point(4, 22);
            this.tP_Recording.Name = "tP_Recording";
            this.tP_Recording.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Recording.Size = new System.Drawing.Size(348, 175);
            this.tP_Recording.TabIndex = 1;
            this.tP_Recording.Text = "Recording";
            this.tP_Recording.UseVisualStyleBackColor = true;
            // 
            // tP_Presets
            // 
            this.tP_Presets.Controls.Add(this.l_Presets_8);
            this.tP_Presets.Controls.Add(this.tB_Presets_8);
            this.tP_Presets.Controls.Add(this.l_Presets_7);
            this.tP_Presets.Controls.Add(this.tB_Presets_7);
            this.tP_Presets.Controls.Add(this.l_Presets_6);
            this.tP_Presets.Controls.Add(this.tB_Presets_6);
            this.tP_Presets.Controls.Add(this.l_Presets_5);
            this.tP_Presets.Controls.Add(this.tB_Presets_5);
            this.tP_Presets.Controls.Add(this.l_Presets_4);
            this.tP_Presets.Controls.Add(this.tB_Presets_4);
            this.tP_Presets.Controls.Add(this.l_Presets_3);
            this.tP_Presets.Controls.Add(this.tB_Presets_3);
            this.tP_Presets.Controls.Add(this.l_Presets_2);
            this.tP_Presets.Controls.Add(this.tB_Presets_2);
            this.tP_Presets.Controls.Add(this.l_Presets_1);
            this.tP_Presets.Controls.Add(this.tB_Presets_1);
            this.tP_Presets.Location = new System.Drawing.Point(4, 22);
            this.tP_Presets.Name = "tP_Presets";
            this.tP_Presets.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Presets.Size = new System.Drawing.Size(348, 175);
            this.tP_Presets.TabIndex = 4;
            this.tP_Presets.Text = "Presets";
            this.tP_Presets.UseVisualStyleBackColor = true;
            // 
            // l_Presets_8
            // 
            this.l_Presets_8.AutoSize = true;
            this.l_Presets_8.Location = new System.Drawing.Point(167, 92);
            this.l_Presets_8.Name = "l_Presets_8";
            this.l_Presets_8.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_8.TabIndex = 31;
            this.l_Presets_8.Text = "Button 8";
            // 
            // tB_Presets_8
            // 
            this.tB_Presets_8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_8.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_8.Location = new System.Drawing.Point(220, 89);
            this.tB_Presets_8.Name = "tB_Presets_8";
            this.tB_Presets_8.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_8.TabIndex = 32;
            // 
            // l_Presets_7
            // 
            this.l_Presets_7.AutoSize = true;
            this.l_Presets_7.Location = new System.Drawing.Point(167, 66);
            this.l_Presets_7.Name = "l_Presets_7";
            this.l_Presets_7.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_7.TabIndex = 29;
            this.l_Presets_7.Text = "Button 7";
            // 
            // tB_Presets_7
            // 
            this.tB_Presets_7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_7.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_7.Location = new System.Drawing.Point(220, 63);
            this.tB_Presets_7.Name = "tB_Presets_7";
            this.tB_Presets_7.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_7.TabIndex = 30;
            // 
            // l_Presets_6
            // 
            this.l_Presets_6.AutoSize = true;
            this.l_Presets_6.Location = new System.Drawing.Point(167, 40);
            this.l_Presets_6.Name = "l_Presets_6";
            this.l_Presets_6.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_6.TabIndex = 27;
            this.l_Presets_6.Text = "Button 6";
            // 
            // tB_Presets_6
            // 
            this.tB_Presets_6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_6.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_6.Location = new System.Drawing.Point(220, 37);
            this.tB_Presets_6.Name = "tB_Presets_6";
            this.tB_Presets_6.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_6.TabIndex = 28;
            // 
            // l_Presets_5
            // 
            this.l_Presets_5.AutoSize = true;
            this.l_Presets_5.Location = new System.Drawing.Point(167, 14);
            this.l_Presets_5.Name = "l_Presets_5";
            this.l_Presets_5.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_5.TabIndex = 25;
            this.l_Presets_5.Text = "Button 5";
            // 
            // tB_Presets_5
            // 
            this.tB_Presets_5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_5.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_5.Location = new System.Drawing.Point(220, 11);
            this.tB_Presets_5.Name = "tB_Presets_5";
            this.tB_Presets_5.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_5.TabIndex = 26;
            // 
            // l_Presets_4
            // 
            this.l_Presets_4.AutoSize = true;
            this.l_Presets_4.Location = new System.Drawing.Point(6, 92);
            this.l_Presets_4.Name = "l_Presets_4";
            this.l_Presets_4.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_4.TabIndex = 23;
            this.l_Presets_4.Text = "Button 4";
            // 
            // tB_Presets_4
            // 
            this.tB_Presets_4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_4.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_4.Location = new System.Drawing.Point(59, 89);
            this.tB_Presets_4.Name = "tB_Presets_4";
            this.tB_Presets_4.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_4.TabIndex = 24;
            // 
            // l_Presets_3
            // 
            this.l_Presets_3.AutoSize = true;
            this.l_Presets_3.Location = new System.Drawing.Point(6, 66);
            this.l_Presets_3.Name = "l_Presets_3";
            this.l_Presets_3.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_3.TabIndex = 21;
            this.l_Presets_3.Text = "Button 3";
            // 
            // tB_Presets_3
            // 
            this.tB_Presets_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_3.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_3.Location = new System.Drawing.Point(59, 63);
            this.tB_Presets_3.Name = "tB_Presets_3";
            this.tB_Presets_3.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_3.TabIndex = 22;
            // 
            // l_Presets_2
            // 
            this.l_Presets_2.AutoSize = true;
            this.l_Presets_2.Location = new System.Drawing.Point(6, 40);
            this.l_Presets_2.Name = "l_Presets_2";
            this.l_Presets_2.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_2.TabIndex = 19;
            this.l_Presets_2.Text = "Button 2";
            // 
            // tB_Presets_2
            // 
            this.tB_Presets_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_2.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_2.Location = new System.Drawing.Point(59, 37);
            this.tB_Presets_2.Name = "tB_Presets_2";
            this.tB_Presets_2.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_2.TabIndex = 20;
            // 
            // l_Presets_1
            // 
            this.l_Presets_1.AutoSize = true;
            this.l_Presets_1.Location = new System.Drawing.Point(6, 14);
            this.l_Presets_1.Name = "l_Presets_1";
            this.l_Presets_1.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_1.TabIndex = 17;
            this.l_Presets_1.Text = "Button 1";
            // 
            // tB_Presets_1
            // 
            this.tB_Presets_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Presets_1.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Presets_1.Location = new System.Drawing.Point(59, 11);
            this.tB_Presets_1.Name = "tB_Presets_1";
            this.tB_Presets_1.Size = new System.Drawing.Size(102, 20);
            this.tB_Presets_1.TabIndex = 18;
            // 
            // tP_Other
            // 
            this.tP_Other.Controls.Add(this.cB_Other_RefreshRate);
            this.tP_Other.Controls.Add(this.check_Other_Subnet);
            this.tP_Other.Controls.Add(this.check_Other_AutoPlay);
            this.tP_Other.Controls.Add(this.l_Other_CommandRate);
            this.tP_Other.Location = new System.Drawing.Point(4, 22);
            this.tP_Other.Name = "tP_Other";
            this.tP_Other.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Other.Size = new System.Drawing.Size(348, 175);
            this.tP_Other.TabIndex = 2;
            this.tP_Other.Text = "Other";
            this.tP_Other.UseVisualStyleBackColor = true;
            // 
            // l_Version
            // 
            this.l_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Version.AutoSize = true;
            this.l_Version.Location = new System.Drawing.Point(189, 220);
            this.l_Version.Name = "l_Version";
            this.l_Version.Size = new System.Drawing.Size(102, 13);
            this.l_Version.TabIndex = 32;
            this.l_Version.Text = "SSUtility2.0 Version:";
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(373, 248);
            this.Controls.Add(this.l_Version);
            this.Controls.Add(this.tC_Settings);
            this.Controls.Add(this.b_Settings_Default);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsPage";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsPage_FormClosing);
            this.tC_Settings.ResumeLayout(false);
            this.tP_Control.ResumeLayout(false);
            this.tP_Control.PerformLayout();
            this.tP_Paths.ResumeLayout(false);
            this.tP_Paths.PerformLayout();
            this.tP_Recording.ResumeLayout(false);
            this.tP_Recording.PerformLayout();
            this.tP_Presets.ResumeLayout(false);
            this.tP_Presets.PerformLayout();
            this.tP_Other.ResumeLayout(false);
            this.tP_Other.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button b_Settings_Default;
        public System.Windows.Forms.ComboBox cB_Rec_Quality;
        public System.Windows.Forms.Label l_Rec_Quality;
        public System.Windows.Forms.TextBox tB_Rec_scFileN;
        public System.Windows.Forms.Label l_Rec_sCFileN;
        public System.Windows.Forms.ComboBox cB_Rec_FPS;
        public System.Windows.Forms.TextBox tB_Rec_vFileN;
        public System.Windows.Forms.Label l_Rec_vFileN;
        public System.Windows.Forms.Label l_Rec_FPS;
        public System.Windows.Forms.Label l_Paths_sCFolder;
        public System.Windows.Forms.Button b_Paths_sCBrowse;
        public System.Windows.Forms.TextBox tB_Paths_sCFolder;
        public System.Windows.Forms.Label l_Paths_vFolder;
        public System.Windows.Forms.TextBox tB_Paths_vFolder;
        public System.Windows.Forms.Button b_Paths_vBrowse;
        public System.Windows.Forms.Label l_Paths_vCheck;
        public System.Windows.Forms.Label l_Paths_sCCheck;
        public System.Windows.Forms.CheckBox check_Paths_Manual;
        public System.Windows.Forms.ComboBox cB_Other_RefreshRate;
        public System.Windows.Forms.CheckBox check_Other_AutoPlay;
        public System.Windows.Forms.Label l_Other_CommandRate;
        public System.Windows.Forms.CheckBox check_Other_Subnet;
        public System.Windows.Forms.Button b_ChangeDir;
        public System.Windows.Forms.TabControl tC_Settings;
        public System.Windows.Forms.TabPage tP_Paths;
        public System.Windows.Forms.TabPage tP_Recording;
        public System.Windows.Forms.TabPage tP_Other;
        public System.Windows.Forms.ToolTip toolTips;
        public System.Windows.Forms.TabPage tP_Control;
        public System.Windows.Forms.TextBox tB_IPCon_Port;
        public System.Windows.Forms.TextBox tB_IPCon_Adr;
        public System.Windows.Forms.Label l_IPCon_Connected;
        public System.Windows.Forms.ComboBox cB_IPCon_Type;
        public System.Windows.Forms.Label l_IPCon_Port;
        public System.Windows.Forms.Label l_IPCon_ConType;
        public System.Windows.Forms.Label l_IPCon_Adr;
        public System.Windows.Forms.TabPage tP_Presets;
        public System.Windows.Forms.Label l_Presets_6;
        public System.Windows.Forms.TextBox tB_Presets_6;
        public System.Windows.Forms.Label l_Presets_5;
        public System.Windows.Forms.TextBox tB_Presets_5;
        public System.Windows.Forms.Label l_Presets_4;
        public System.Windows.Forms.TextBox tB_Presets_4;
        public System.Windows.Forms.Label l_Presets_3;
        public System.Windows.Forms.TextBox tB_Presets_3;
        public System.Windows.Forms.Label l_Presets_2;
        public System.Windows.Forms.TextBox tB_Presets_2;
        public System.Windows.Forms.Label l_Presets_1;
        public System.Windows.Forms.TextBox tB_Presets_1;
        public System.Windows.Forms.Label l_Presets_8;
        public System.Windows.Forms.TextBox tB_Presets_8;
        public System.Windows.Forms.Label l_Presets_7;
        public System.Windows.Forms.TextBox tB_Presets_7;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ComboBox cB_ipCon_Selected;
        public System.Windows.Forms.Label l_ipCon_Selected;
        public System.Windows.Forms.Label l_Version;
    }
}