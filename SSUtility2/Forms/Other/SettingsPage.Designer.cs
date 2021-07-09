
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
            this.check_Other_AutoPlay = new System.Windows.Forms.CheckBox();
            this.b_ChangeDir = new System.Windows.Forms.Button();
            this.tC_Settings = new System.Windows.Forms.TabControl();
            this.tP_Control = new System.Windows.Forms.TabPage();
            this.l_IPCon_Subnet = new System.Windows.Forms.Label();
            this.b_IPCon_EditCamType = new System.Windows.Forms.Button();
            this.l_IPCon_PelcoID = new System.Windows.Forms.Label();
            this.b_IPCon_Recheck = new System.Windows.Forms.Button();
            this.l_IPCon_Percent = new System.Windows.Forms.Label();
            this.tB_IPCon_CamSpeed = new System.Windows.Forms.TextBox();
            this.l_IPCon_TrackBar = new System.Windows.Forms.Label();
            this.l_IPCon_ForceMode = new System.Windows.Forms.Label();
            this.cB_IPCon_ForceMode = new System.Windows.Forms.ComboBox();
            this.check_IPCon_ForceCam = new System.Windows.Forms.CheckBox();
            this.cB_ipCon_CamType = new System.Windows.Forms.ComboBox();
            this.l_ipCon_Selected = new System.Windows.Forms.Label();
            this.tB_IPCon_Port = new System.Windows.Forms.TextBox();
            this.tB_IPCon_Adr = new System.Windows.Forms.TextBox();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.cB_IPCon_PresetType = new System.Windows.Forms.ComboBox();
            this.l_IPCon_Port = new System.Windows.Forms.Label();
            this.l_IPCon_ConType = new System.Windows.Forms.Label();
            this.l_IPCon_Adr = new System.Windows.Forms.Label();
            this.slider_IPCon_ControlMultiplier = new System.Windows.Forms.TrackBar();
            this.tP_Paths = new System.Windows.Forms.TabPage();
            this.l_Paths_Dir = new System.Windows.Forms.Label();
            this.tP_Recording = new System.Windows.Forms.TabPage();
            this.cB_Rec_Quality = new System.Windows.Forms.ComboBox();
            this.l_Rec_Quality = new System.Windows.Forms.Label();
            this.tP_Customs = new System.Windows.Forms.TabPage();
            this.dgv_Custom_Buttons = new System.Windows.Forms.DataGridView();
            this.ButtonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonsCommand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tP_Other = new System.Windows.Forms.TabPage();
            this.l_Other_PlayerCount = new System.Windows.Forms.Label();
            this.cB_Other_PlayerCount = new System.Windows.Forms.ComboBox();
            this.l_Other_Ratio = new System.Windows.Forms.Label();
            this.check_Other_Aspect = new System.Windows.Forms.CheckBox();
            this.check_AddressInvalid = new System.Windows.Forms.CheckBox();
            this.l_Other_CurrentResolution = new System.Windows.Forms.Label();
            this.tB_Other_ResolutionHeight = new System.Windows.Forms.TextBox();
            this.l_Other_ResolutionHeight = new System.Windows.Forms.Label();
            this.tB_Other_ResolutionWidth = new System.Windows.Forms.TextBox();
            this.l_Other_ResolutionWidth = new System.Windows.Forms.Label();
            this.check_Other_AutoReconnect = new System.Windows.Forms.CheckBox();
            this.b_Custom_CommandList = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.l_Version = new System.Windows.Forms.Label();
            this.tC_Settings.SuspendLayout();
            this.tP_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_IPCon_ControlMultiplier)).BeginInit();
            this.tP_Paths.SuspendLayout();
            this.tP_Recording.SuspendLayout();
            this.tP_Customs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Custom_Buttons)).BeginInit();
            this.tP_Other.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_Settings_Default
            // 
            this.b_Settings_Default.BackColor = System.Drawing.SystemColors.Control;
            this.b_Settings_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Settings_Default.Location = new System.Drawing.Point(12, 253);
            this.b_Settings_Default.Name = "b_Settings_Default";
            this.b_Settings_Default.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Default.TabIndex = 14;
            this.b_Settings_Default.Text = "Default All";
            this.b_Settings_Default.UseVisualStyleBackColor = false;
            this.b_Settings_Default.Click += new System.EventHandler(this.b_Settings_Default_Click);
            // 
            // tB_Rec_scFileN
            // 
            this.tB_Rec_scFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Rec_scFileN.Enabled = false;
            this.tB_Rec_scFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Rec_scFileN.Location = new System.Drawing.Point(133, 90);
            this.tB_Rec_scFileN.Name = "tB_Rec_scFileN";
            this.tB_Rec_scFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_scFileN.TabIndex = 24;
            this.tB_Rec_scFileN.TextChanged += new System.EventHandler(this.tB_Rec_scFileN_TextChanged);
            // 
            // l_Rec_sCFileN
            // 
            this.l_Rec_sCFileN.AutoSize = true;
            this.l_Rec_sCFileN.Location = new System.Drawing.Point(7, 94);
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
            this.cB_Rec_FPS.Location = new System.Drawing.Point(133, 6);
            this.cB_Rec_FPS.Name = "cB_Rec_FPS";
            this.cB_Rec_FPS.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_FPS.TabIndex = 16;
            this.toolTips.SetToolTip(this.cB_Rec_FPS, "Video capture framerate, lower to reduce latency, increase to improve smoothness " +
        "of output video.");
            this.cB_Rec_FPS.TextChanged += new System.EventHandler(this.cB_Rec_FPS_TextChanged);
            // 
            // tB_Rec_vFileN
            // 
            this.tB_Rec_vFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Rec_vFileN.Enabled = false;
            this.tB_Rec_vFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Rec_vFileN.Location = new System.Drawing.Point(133, 64);
            this.tB_Rec_vFileN.Name = "tB_Rec_vFileN";
            this.tB_Rec_vFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_vFileN.TabIndex = 22;
            this.tB_Rec_vFileN.TextChanged += new System.EventHandler(this.tB_Rec_vFileN_TextChanged);
            // 
            // l_Rec_vFileN
            // 
            this.l_Rec_vFileN.AutoSize = true;
            this.l_Rec_vFileN.Location = new System.Drawing.Point(7, 67);
            this.l_Rec_vFileN.Name = "l_Rec_vFileN";
            this.l_Rec_vFileN.Size = new System.Drawing.Size(84, 13);
            this.l_Rec_vFileN.TabIndex = 21;
            this.l_Rec_vFileN.Text = "Video File Name";
            // 
            // l_Rec_FPS
            // 
            this.l_Rec_FPS.AutoSize = true;
            this.l_Rec_FPS.Location = new System.Drawing.Point(7, 6);
            this.l_Rec_FPS.Name = "l_Rec_FPS";
            this.l_Rec_FPS.Size = new System.Drawing.Size(87, 13);
            this.l_Rec_FPS.TabIndex = 2;
            this.l_Rec_FPS.Text = "Video Frame rate";
            this.toolTips.SetToolTip(this.l_Rec_FPS, "Video capture framerate, lower to reduce latency, increase to improve smoothness " +
        "of output video.");
            // 
            // l_Paths_sCFolder
            // 
            this.l_Paths_sCFolder.AutoSize = true;
            this.l_Paths_sCFolder.Location = new System.Drawing.Point(5, 36);
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
            this.b_Paths_sCBrowse.Location = new System.Drawing.Point(337, 31);
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
            this.tB_Paths_sCFolder.Location = new System.Drawing.Point(112, 33);
            this.tB_Paths_sCFolder.Name = "tB_Paths_sCFolder";
            this.tB_Paths_sCFolder.Size = new System.Drawing.Size(219, 20);
            this.tB_Paths_sCFolder.TabIndex = 16;
            this.tB_Paths_sCFolder.TextChanged += new System.EventHandler(this.tB_Paths_sCFolder_TextChanged);
            // 
            // l_Paths_vFolder
            // 
            this.l_Paths_vFolder.AutoSize = true;
            this.l_Paths_vFolder.Location = new System.Drawing.Point(5, 69);
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
            this.tB_Paths_vFolder.Location = new System.Drawing.Point(112, 66);
            this.tB_Paths_vFolder.Name = "tB_Paths_vFolder";
            this.tB_Paths_vFolder.Size = new System.Drawing.Size(219, 20);
            this.tB_Paths_vFolder.TabIndex = 18;
            this.tB_Paths_vFolder.TextChanged += new System.EventHandler(this.tB_Paths_vFolder_TextChanged);
            // 
            // b_Paths_vBrowse
            // 
            this.b_Paths_vBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Paths_vBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Paths_vBrowse.Enabled = false;
            this.b_Paths_vBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Paths_vBrowse.Location = new System.Drawing.Point(337, 64);
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
            this.check_Paths_Manual.Location = new System.Drawing.Point(6, 6);
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
            // check_Other_AutoPlay
            // 
            this.check_Other_AutoPlay.Location = new System.Drawing.Point(9, 6);
            this.check_Other_AutoPlay.Name = "check_Other_AutoPlay";
            this.check_Other_AutoPlay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_AutoPlay.Size = new System.Drawing.Size(174, 17);
            this.check_Other_AutoPlay.TabIndex = 30;
            this.check_Other_AutoPlay.Text = "Autoplay Videos on Launch";
            this.check_Other_AutoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Other_AutoPlay, "Play videos upon launch of the program if any have been entered previously.");
            this.check_Other_AutoPlay.UseVisualStyleBackColor = true;
            this.check_Other_AutoPlay.CheckedChanged += new System.EventHandler(this.check_Other_AutoPlay_CheckedChanged);
            // 
            // b_ChangeDir
            // 
            this.b_ChangeDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_ChangeDir.BackColor = System.Drawing.SystemColors.Control;
            this.b_ChangeDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_ChangeDir.Location = new System.Drawing.Point(8, 190);
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
            this.tC_Settings.Controls.Add(this.tP_Customs);
            this.tC_Settings.Controls.Add(this.tP_Other);
            this.tC_Settings.Location = new System.Drawing.Point(3, 2);
            this.tC_Settings.Name = "tC_Settings";
            this.tC_Settings.SelectedIndex = 0;
            this.tC_Settings.Size = new System.Drawing.Size(378, 245);
            this.tC_Settings.TabIndex = 31;
            this.tC_Settings.SelectedIndexChanged += new System.EventHandler(this.tC_Settings_SelectedIndexChanged);
            // 
            // tP_Control
            // 
            this.tP_Control.Controls.Add(this.l_IPCon_Subnet);
            this.tP_Control.Controls.Add(this.b_IPCon_EditCamType);
            this.tP_Control.Controls.Add(this.l_IPCon_PelcoID);
            this.tP_Control.Controls.Add(this.b_IPCon_Recheck);
            this.tP_Control.Controls.Add(this.l_IPCon_Percent);
            this.tP_Control.Controls.Add(this.tB_IPCon_CamSpeed);
            this.tP_Control.Controls.Add(this.l_IPCon_TrackBar);
            this.tP_Control.Controls.Add(this.l_IPCon_ForceMode);
            this.tP_Control.Controls.Add(this.cB_IPCon_ForceMode);
            this.tP_Control.Controls.Add(this.check_IPCon_ForceCam);
            this.tP_Control.Controls.Add(this.cB_ipCon_CamType);
            this.tP_Control.Controls.Add(this.l_ipCon_Selected);
            this.tP_Control.Controls.Add(this.tB_IPCon_Port);
            this.tP_Control.Controls.Add(this.tB_IPCon_Adr);
            this.tP_Control.Controls.Add(this.l_IPCon_Connected);
            this.tP_Control.Controls.Add(this.cB_IPCon_PresetType);
            this.tP_Control.Controls.Add(this.l_IPCon_Port);
            this.tP_Control.Controls.Add(this.l_IPCon_ConType);
            this.tP_Control.Controls.Add(this.l_IPCon_Adr);
            this.tP_Control.Controls.Add(this.slider_IPCon_ControlMultiplier);
            this.tP_Control.Location = new System.Drawing.Point(4, 22);
            this.tP_Control.Name = "tP_Control";
            this.tP_Control.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Control.Size = new System.Drawing.Size(370, 219);
            this.tP_Control.TabIndex = 3;
            this.tP_Control.Text = "IP Control";
            this.tP_Control.UseVisualStyleBackColor = true;
            // 
            // l_IPCon_Subnet
            // 
            this.l_IPCon_Subnet.AutoSize = true;
            this.l_IPCon_Subnet.ForeColor = System.Drawing.Color.DimGray;
            this.l_IPCon_Subnet.Location = new System.Drawing.Point(272, 36);
            this.l_IPCon_Subnet.Name = "l_IPCon_Subnet";
            this.l_IPCon_Subnet.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Subnet.TabIndex = 96;
            // 
            // b_IPCon_EditCamType
            // 
            this.b_IPCon_EditCamType.Location = new System.Drawing.Point(316, 85);
            this.b_IPCon_EditCamType.Name = "b_IPCon_EditCamType";
            this.b_IPCon_EditCamType.Size = new System.Drawing.Size(43, 21);
            this.b_IPCon_EditCamType.TabIndex = 95;
            this.b_IPCon_EditCamType.Text = "Edit...";
            this.b_IPCon_EditCamType.UseVisualStyleBackColor = true;
            this.b_IPCon_EditCamType.Click += new System.EventHandler(this.b_IPCon_EditCamType_Click);
            // 
            // l_IPCon_PelcoID
            // 
            this.l_IPCon_PelcoID.AutoSize = true;
            this.l_IPCon_PelcoID.Location = new System.Drawing.Point(244, 88);
            this.l_IPCon_PelcoID.Name = "l_IPCon_PelcoID";
            this.l_IPCon_PelcoID.Size = new System.Drawing.Size(66, 13);
            this.l_IPCon_PelcoID.TabIndex = 94;
            this.l_IPCon_PelcoID.Text = "(Pelco ID: 1)";
            // 
            // b_IPCon_Recheck
            // 
            this.b_IPCon_Recheck.Location = new System.Drawing.Point(257, 192);
            this.b_IPCon_Recheck.Name = "b_IPCon_Recheck";
            this.b_IPCon_Recheck.Size = new System.Drawing.Size(90, 21);
            this.b_IPCon_Recheck.TabIndex = 93;
            this.b_IPCon_Recheck.Text = "Recheck Mode";
            this.b_IPCon_Recheck.UseVisualStyleBackColor = true;
            this.b_IPCon_Recheck.Click += new System.EventHandler(this.b_IPCon_Recheck_Click);
            // 
            // l_IPCon_Percent
            // 
            this.l_IPCon_Percent.AutoSize = true;
            this.l_IPCon_Percent.Location = new System.Drawing.Point(281, 121);
            this.l_IPCon_Percent.Name = "l_IPCon_Percent";
            this.l_IPCon_Percent.Size = new System.Drawing.Size(15, 13);
            this.l_IPCon_Percent.TabIndex = 92;
            this.l_IPCon_Percent.Text = "%";
            // 
            // tB_IPCon_CamSpeed
            // 
            this.tB_IPCon_CamSpeed.Location = new System.Drawing.Point(245, 118);
            this.tB_IPCon_CamSpeed.Name = "tB_IPCon_CamSpeed";
            this.tB_IPCon_CamSpeed.Size = new System.Drawing.Size(34, 20);
            this.tB_IPCon_CamSpeed.TabIndex = 91;
            this.tB_IPCon_CamSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_IPCon_CamSpeed_KeyPress);
            this.tB_IPCon_CamSpeed.Leave += new System.EventHandler(this.tB_IPCon_CamSpeed_Leave);
            // 
            // l_IPCon_TrackBar
            // 
            this.l_IPCon_TrackBar.AutoSize = true;
            this.l_IPCon_TrackBar.Location = new System.Drawing.Point(6, 120);
            this.l_IPCon_TrackBar.Name = "l_IPCon_TrackBar";
            this.l_IPCon_TrackBar.Size = new System.Drawing.Size(98, 13);
            this.l_IPCon_TrackBar.TabIndex = 90;
            this.l_IPCon_TrackBar.Text = "PTZ Control Speed";
            this.toolTips.SetToolTip(this.l_IPCon_TrackBar, "Multiplier of PTZ commands sent to the camera");
            // 
            // l_IPCon_ForceMode
            // 
            this.l_IPCon_ForceMode.AutoSize = true;
            this.l_IPCon_ForceMode.Location = new System.Drawing.Point(6, 195);
            this.l_IPCon_ForceMode.Name = "l_IPCon_ForceMode";
            this.l_IPCon_ForceMode.Size = new System.Drawing.Size(73, 13);
            this.l_IPCon_ForceMode.TabIndex = 88;
            this.l_IPCon_ForceMode.Text = "Camera Mode";
            this.toolTips.SetToolTip(this.l_IPCon_ForceMode, "Affects the processing of received commands");
            // 
            // cB_IPCon_ForceMode
            // 
            this.cB_IPCon_ForceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_IPCon_ForceMode.FormattingEnabled = true;
            this.cB_IPCon_ForceMode.Items.AddRange(new object[] {
            "SSTraditional",
            "Strict",
            "RevTilt",
            "Legacy"});
            this.cB_IPCon_ForceMode.Location = new System.Drawing.Point(115, 192);
            this.cB_IPCon_ForceMode.Name = "cB_IPCon_ForceMode";
            this.cB_IPCon_ForceMode.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_ForceMode.TabIndex = 87;
            this.toolTips.SetToolTip(this.cB_IPCon_ForceMode, "Affects the processing of received commands");
            this.cB_IPCon_ForceMode.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_ForceMode_SelectedIndexChanged);
            // 
            // check_IPCon_ForceCam
            // 
            this.check_IPCon_ForceCam.Location = new System.Drawing.Point(5, 165);
            this.check_IPCon_ForceCam.Name = "check_IPCon_ForceCam";
            this.check_IPCon_ForceCam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_IPCon_ForceCam.Size = new System.Drawing.Size(125, 24);
            this.check_IPCon_ForceCam.TabIndex = 86;
            this.check_IPCon_ForceCam.Text = "Force Camera Mode";
            this.check_IPCon_ForceCam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_IPCon_ForceCam, "SSUtility is forced to see the connect device as a camera");
            this.check_IPCon_ForceCam.UseVisualStyleBackColor = true;
            this.check_IPCon_ForceCam.CheckedChanged += new System.EventHandler(this.check_IPCon_ForceCam_CheckedChanged);
            // 
            // cB_ipCon_CamType
            // 
            this.cB_ipCon_CamType.FormattingEnabled = true;
            this.cB_ipCon_CamType.Location = new System.Drawing.Point(115, 85);
            this.cB_ipCon_CamType.Name = "cB_ipCon_CamType";
            this.cB_ipCon_CamType.Size = new System.Drawing.Size(123, 21);
            this.cB_ipCon_CamType.TabIndex = 83;
            this.toolTips.SetToolTip(this.cB_ipCon_CamType, "Commands are sent to this Pelco ID in the camera");
            this.cB_ipCon_CamType.SelectedIndexChanged += new System.EventHandler(this.cB_ipCon_CamType_SelectedIndexChanged);
            this.cB_ipCon_CamType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cB_ipCon_CamType_KeyUp);
            // 
            // l_ipCon_Selected
            // 
            this.l_ipCon_Selected.AutoSize = true;
            this.l_ipCon_Selected.Location = new System.Drawing.Point(6, 88);
            this.l_ipCon_Selected.Name = "l_ipCon_Selected";
            this.l_ipCon_Selected.Size = new System.Drawing.Size(93, 13);
            this.l_ipCon_Selected.TabIndex = 82;
            this.l_ipCon_Selected.Text = "Selected Pelco ID";
            this.toolTips.SetToolTip(this.l_ipCon_Selected, "Commands are sent to this Pelco ID in the camera");
            // 
            // tB_IPCon_Port
            // 
            this.tB_IPCon_Port.Location = new System.Drawing.Point(115, 59);
            this.tB_IPCon_Port.Name = "tB_IPCon_Port";
            this.tB_IPCon_Port.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Port.TabIndex = 78;
            this.toolTips.SetToolTip(this.tB_IPCon_Port, "Port of the camera");
            this.tB_IPCon_Port.TextChanged += new System.EventHandler(this.tB_IPCon_Port_TextChanged);
            this.tB_IPCon_Port.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_IPCon_Adr_KeyUp);
            // 
            // tB_IPCon_Adr
            // 
            this.tB_IPCon_Adr.Location = new System.Drawing.Point(115, 33);
            this.tB_IPCon_Adr.Name = "tB_IPCon_Adr";
            this.tB_IPCon_Adr.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Adr.TabIndex = 77;
            this.toolTips.SetToolTip(this.tB_IPCon_Adr, "IP Address of the camera");
            this.tB_IPCon_Adr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_IPCon_Adr_KeyUp);
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(244, 36);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(14, 13);
            this.l_IPCon_Connected.TabIndex = 81;
            this.l_IPCon_Connected.Text = "X";
            // 
            // cB_IPCon_PresetType
            // 
            this.cB_IPCon_PresetType.FormattingEnabled = true;
            this.cB_IPCon_PresetType.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_IPCon_PresetType.Location = new System.Drawing.Point(115, 6);
            this.cB_IPCon_PresetType.Name = "cB_IPCon_PresetType";
            this.cB_IPCon_PresetType.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_PresetType.TabIndex = 80;
            this.toolTips.SetToolTip(this.cB_IPCon_PresetType, "Defaults IP Address and Port fields to preset values");
            this.cB_IPCon_PresetType.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_Type_SelectedIndexChanged);
            // 
            // l_IPCon_Port
            // 
            this.l_IPCon_Port.AutoSize = true;
            this.l_IPCon_Port.Location = new System.Drawing.Point(6, 62);
            this.l_IPCon_Port.Name = "l_IPCon_Port";
            this.l_IPCon_Port.Size = new System.Drawing.Size(67, 13);
            this.l_IPCon_Port.TabIndex = 75;
            this.l_IPCon_Port.Text = "Address Port";
            this.toolTips.SetToolTip(this.l_IPCon_Port, "Port of the camera");
            // 
            // l_IPCon_ConType
            // 
            this.l_IPCon_ConType.AutoSize = true;
            this.l_IPCon_ConType.Location = new System.Drawing.Point(6, 9);
            this.l_IPCon_ConType.Name = "l_IPCon_ConType";
            this.l_IPCon_ConType.Size = new System.Drawing.Size(100, 13);
            this.l_IPCon_ConType.TabIndex = 74;
            this.l_IPCon_ConType.Text = "Preset Control Type";
            this.toolTips.SetToolTip(this.l_IPCon_ConType, "Defaults IP Address and Port fields to preset values");
            // 
            // l_IPCon_Adr
            // 
            this.l_IPCon_Adr.AutoSize = true;
            this.l_IPCon_Adr.Location = new System.Drawing.Point(6, 36);
            this.l_IPCon_Adr.Name = "l_IPCon_Adr";
            this.l_IPCon_Adr.Size = new System.Drawing.Size(58, 13);
            this.l_IPCon_Adr.TabIndex = 73;
            this.l_IPCon_Adr.Text = "IP Address";
            this.toolTips.SetToolTip(this.l_IPCon_Adr, "IP Address of the camera");
            // 
            // slider_IPCon_ControlMultiplier
            // 
            this.slider_IPCon_ControlMultiplier.BackColor = System.Drawing.SystemColors.Window;
            this.slider_IPCon_ControlMultiplier.Location = new System.Drawing.Point(109, 116);
            this.slider_IPCon_ControlMultiplier.Maximum = 200;
            this.slider_IPCon_ControlMultiplier.Minimum = 1;
            this.slider_IPCon_ControlMultiplier.Name = "slider_IPCon_ControlMultiplier";
            this.slider_IPCon_ControlMultiplier.Size = new System.Drawing.Size(134, 45);
            this.slider_IPCon_ControlMultiplier.TabIndex = 89;
            this.slider_IPCon_ControlMultiplier.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTips.SetToolTip(this.slider_IPCon_ControlMultiplier, "Multiplier of PTZ commands sent to the camera");
            this.slider_IPCon_ControlMultiplier.Value = 100;
            this.slider_IPCon_ControlMultiplier.Scroll += new System.EventHandler(this.slider_IPCon_ControlMultiplier_Scroll);
            this.slider_IPCon_ControlMultiplier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_IPCon_ControlMultiplier_MouseDown);
            this.slider_IPCon_ControlMultiplier.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_IPCon_ControlMultiplier_MouseUp);
            // 
            // tP_Paths
            // 
            this.tP_Paths.Controls.Add(this.l_Paths_Dir);
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
            this.tP_Paths.Size = new System.Drawing.Size(370, 219);
            this.tP_Paths.TabIndex = 0;
            this.tP_Paths.Text = "Paths";
            this.tP_Paths.UseVisualStyleBackColor = true;
            // 
            // l_Paths_Dir
            // 
            this.l_Paths_Dir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Paths_Dir.AutoSize = true;
            this.l_Paths_Dir.Location = new System.Drawing.Point(6, 165);
            this.l_Paths_Dir.Name = "l_Paths_Dir";
            this.l_Paths_Dir.Size = new System.Drawing.Size(89, 13);
            this.l_Paths_Dir.TabIndex = 34;
            this.l_Paths_Dir.Text = "Current Directory:";
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
            this.tP_Recording.Size = new System.Drawing.Size(370, 219);
            this.tP_Recording.TabIndex = 1;
            this.tP_Recording.Text = "Recording";
            this.tP_Recording.UseVisualStyleBackColor = true;
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
            this.cB_Rec_Quality.Location = new System.Drawing.Point(133, 33);
            this.cB_Rec_Quality.Name = "cB_Rec_Quality";
            this.cB_Rec_Quality.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_Quality.TabIndex = 26;
            this.toolTips.SetToolTip(this.cB_Rec_Quality, "Video capture output quality, lower to reduce output file size and to improve per" +
        "formance during capture, increase to improve output file quality.");
            this.cB_Rec_Quality.TextChanged += new System.EventHandler(this.cB_Rec_Quality_TextChanged);
            // 
            // l_Rec_Quality
            // 
            this.l_Rec_Quality.AutoSize = true;
            this.l_Rec_Quality.Location = new System.Drawing.Point(7, 36);
            this.l_Rec_Quality.Name = "l_Rec_Quality";
            this.l_Rec_Quality.Size = new System.Drawing.Size(105, 13);
            this.l_Rec_Quality.TabIndex = 25;
            this.l_Rec_Quality.Text = "Video Quality (1-100)";
            this.toolTips.SetToolTip(this.l_Rec_Quality, "Video capture output quality, lower to reduce output file size and to improve per" +
        "formance during capture, increase to improve output file quality.");
            // 
            // tP_Customs
            // 
            this.tP_Customs.Controls.Add(this.dgv_Custom_Buttons);
            this.tP_Customs.Location = new System.Drawing.Point(4, 22);
            this.tP_Customs.Name = "tP_Customs";
            this.tP_Customs.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Customs.Size = new System.Drawing.Size(370, 219);
            this.tP_Customs.TabIndex = 4;
            this.tP_Customs.Text = "Custom";
            this.tP_Customs.UseVisualStyleBackColor = true;
            // 
            // dgv_Custom_Buttons
            // 
            this.dgv_Custom_Buttons.AllowUserToDeleteRows = false;
            this.dgv_Custom_Buttons.AllowUserToResizeColumns = false;
            this.dgv_Custom_Buttons.AllowUserToResizeRows = false;
            this.dgv_Custom_Buttons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Custom_Buttons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtonName,
            this.ButtonsCommand});
            this.dgv_Custom_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Custom_Buttons.Location = new System.Drawing.Point(3, 3);
            this.dgv_Custom_Buttons.Name = "dgv_Custom_Buttons";
            this.dgv_Custom_Buttons.RowHeadersVisible = false;
            this.dgv_Custom_Buttons.Size = new System.Drawing.Size(364, 213);
            this.dgv_Custom_Buttons.TabIndex = 0;
            this.dgv_Custom_Buttons.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_Custom_Buttons_CellValidating);
            this.dgv_Custom_Buttons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Custom_Buttons_CellValueChanged);
            this.dgv_Custom_Buttons.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Custom_Buttons_EditingControlShowing);
            this.dgv_Custom_Buttons.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Custom_Buttons_RowsAdded);
            // 
            // ButtonName
            // 
            this.ButtonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ButtonName.FillWeight = 180F;
            this.ButtonName.HeaderText = "Button Text";
            this.ButtonName.Name = "ButtonName";
            this.ButtonName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ButtonsCommand
            // 
            this.ButtonsCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ButtonsCommand.FillWeight = 180F;
            this.ButtonsCommand.HeaderText = "Command";
            this.ButtonsCommand.Name = "ButtonsCommand";
            this.ButtonsCommand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ButtonsCommand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tP_Other
            // 
            this.tP_Other.Controls.Add(this.l_Other_PlayerCount);
            this.tP_Other.Controls.Add(this.cB_Other_PlayerCount);
            this.tP_Other.Controls.Add(this.l_Other_Ratio);
            this.tP_Other.Controls.Add(this.check_Other_Aspect);
            this.tP_Other.Controls.Add(this.check_AddressInvalid);
            this.tP_Other.Controls.Add(this.l_Other_CurrentResolution);
            this.tP_Other.Controls.Add(this.tB_Other_ResolutionHeight);
            this.tP_Other.Controls.Add(this.l_Other_ResolutionHeight);
            this.tP_Other.Controls.Add(this.tB_Other_ResolutionWidth);
            this.tP_Other.Controls.Add(this.l_Other_ResolutionWidth);
            this.tP_Other.Controls.Add(this.check_Other_AutoReconnect);
            this.tP_Other.Controls.Add(this.check_Other_AutoPlay);
            this.tP_Other.Location = new System.Drawing.Point(4, 22);
            this.tP_Other.Name = "tP_Other";
            this.tP_Other.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Other.Size = new System.Drawing.Size(370, 219);
            this.tP_Other.TabIndex = 2;
            this.tP_Other.Text = "Other";
            this.tP_Other.UseVisualStyleBackColor = true;
            // 
            // l_Other_PlayerCount
            // 
            this.l_Other_PlayerCount.AutoSize = true;
            this.l_Other_PlayerCount.Location = new System.Drawing.Point(6, 55);
            this.l_Other_PlayerCount.Name = "l_Other_PlayerCount";
            this.l_Other_PlayerCount.Size = new System.Drawing.Size(147, 13);
            this.l_Other_PlayerCount.TabIndex = 41;
            this.l_Other_PlayerCount.Text = "Number of Players on Launch";
            this.toolTips.SetToolTip(this.l_Other_PlayerCount, "Number of players (including the MainPlayer) spawned");
            // 
            // cB_Other_PlayerCount
            // 
            this.cB_Other_PlayerCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Other_PlayerCount.FormattingEnabled = true;
            this.cB_Other_PlayerCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cB_Other_PlayerCount.Location = new System.Drawing.Point(165, 52);
            this.cB_Other_PlayerCount.Name = "cB_Other_PlayerCount";
            this.cB_Other_PlayerCount.Size = new System.Drawing.Size(114, 21);
            this.cB_Other_PlayerCount.TabIndex = 40;
            this.toolTips.SetToolTip(this.cB_Other_PlayerCount, "Number of players (including the MainPlayer) spawned on launch");
            this.cB_Other_PlayerCount.SelectedIndexChanged += new System.EventHandler(this.cB_Other_PlayerCount_SelectedIndexChanged);
            // 
            // l_Other_Ratio
            // 
            this.l_Other_Ratio.AutoSize = true;
            this.l_Other_Ratio.Location = new System.Drawing.Point(186, 171);
            this.l_Other_Ratio.Name = "l_Other_Ratio";
            this.l_Other_Ratio.Size = new System.Drawing.Size(22, 13);
            this.l_Other_Ratio.TabIndex = 39;
            this.l_Other_Ratio.Text = "1:1";
            this.l_Other_Ratio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Other_Ratio.Visible = false;
            // 
            // check_Other_Aspect
            // 
            this.check_Other_Aspect.Location = new System.Drawing.Point(5, 166);
            this.check_Other_Aspect.Name = "check_Other_Aspect";
            this.check_Other_Aspect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_Aspect.Size = new System.Drawing.Size(175, 24);
            this.check_Other_Aspect.TabIndex = 38;
            this.check_Other_Aspect.Text = "Maintain Current Aspect Ratio";
            this.check_Other_Aspect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Other_Aspect, "Resize the MainPlayer to maintain the given aspect ratio");
            this.check_Other_Aspect.UseVisualStyleBackColor = true;
            this.check_Other_Aspect.CheckedChanged += new System.EventHandler(this.check_Other_Aspect_CheckedChanged);
            // 
            // check_AddressInvalid
            // 
            this.check_AddressInvalid.Location = new System.Drawing.Point(9, 29);
            this.check_AddressInvalid.Name = "check_AddressInvalid";
            this.check_AddressInvalid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_AddressInvalid.Size = new System.Drawing.Size(174, 17);
            this.check_AddressInvalid.TabIndex = 37;
            this.check_AddressInvalid.Text = "Hide Address Invalid Error";
            this.check_AddressInvalid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_AddressInvalid, "Ignores errors to do with given player addresses being invalid");
            this.check_AddressInvalid.UseVisualStyleBackColor = true;
            this.check_AddressInvalid.CheckedChanged += new System.EventHandler(this.check_AddressInvalid_CheckedChanged);
            // 
            // l_Other_CurrentResolution
            // 
            this.l_Other_CurrentResolution.AutoSize = true;
            this.l_Other_CurrentResolution.Location = new System.Drawing.Point(5, 193);
            this.l_Other_CurrentResolution.Name = "l_Other_CurrentResolution";
            this.l_Other_CurrentResolution.Size = new System.Drawing.Size(116, 13);
            this.l_Other_CurrentResolution.TabIndex = 36;
            this.l_Other_CurrentResolution.Text = "Current MainForm Size:";
            this.toolTips.SetToolTip(this.l_Other_CurrentResolution, "Launches the program with this width (does not change current resolution)");
            // 
            // tB_Other_ResolutionHeight
            // 
            this.tB_Other_ResolutionHeight.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Other_ResolutionHeight.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Other_ResolutionHeight.Location = new System.Drawing.Point(165, 140);
            this.tB_Other_ResolutionHeight.Name = "tB_Other_ResolutionHeight";
            this.tB_Other_ResolutionHeight.Size = new System.Drawing.Size(114, 20);
            this.tB_Other_ResolutionHeight.TabIndex = 35;
            this.toolTips.SetToolTip(this.tB_Other_ResolutionHeight, "Launches the program with this height (does not change current resolution).");
            this.tB_Other_ResolutionHeight.TextChanged += new System.EventHandler(this.tB_Other_ResolutionHeight_TextChanged);
            // 
            // l_Other_ResolutionHeight
            // 
            this.l_Other_ResolutionHeight.AutoSize = true;
            this.l_Other_ResolutionHeight.Location = new System.Drawing.Point(6, 144);
            this.l_Other_ResolutionHeight.Name = "l_Other_ResolutionHeight";
            this.l_Other_ResolutionHeight.Size = new System.Drawing.Size(124, 13);
            this.l_Other_ResolutionHeight.TabIndex = 34;
            this.l_Other_ResolutionHeight.Text = "Startup MainForm Height";
            this.toolTips.SetToolTip(this.l_Other_ResolutionHeight, "Launches the program with this height (does not change current resolution).");
            // 
            // tB_Other_ResolutionWidth
            // 
            this.tB_Other_ResolutionWidth.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Other_ResolutionWidth.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Other_ResolutionWidth.Location = new System.Drawing.Point(165, 115);
            this.tB_Other_ResolutionWidth.Name = "tB_Other_ResolutionWidth";
            this.tB_Other_ResolutionWidth.Size = new System.Drawing.Size(114, 20);
            this.tB_Other_ResolutionWidth.TabIndex = 33;
            this.toolTips.SetToolTip(this.tB_Other_ResolutionWidth, "Launches the program with this width (does not change current resolution).");
            this.tB_Other_ResolutionWidth.TextChanged += new System.EventHandler(this.tB_Other_ResolutionWidth_TextChanged);
            // 
            // l_Other_ResolutionWidth
            // 
            this.l_Other_ResolutionWidth.AutoSize = true;
            this.l_Other_ResolutionWidth.Location = new System.Drawing.Point(6, 118);
            this.l_Other_ResolutionWidth.Name = "l_Other_ResolutionWidth";
            this.l_Other_ResolutionWidth.Size = new System.Drawing.Size(121, 13);
            this.l_Other_ResolutionWidth.TabIndex = 32;
            this.l_Other_ResolutionWidth.Text = "Startup MainForm Width";
            this.toolTips.SetToolTip(this.l_Other_ResolutionWidth, "Launches the program with this width (does not change current resolution).");
            // 
            // check_Other_AutoReconnect
            // 
            this.check_Other_AutoReconnect.Location = new System.Drawing.Point(189, 6);
            this.check_Other_AutoReconnect.Name = "check_Other_AutoReconnect";
            this.check_Other_AutoReconnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_AutoReconnect.Size = new System.Drawing.Size(174, 17);
            this.check_Other_AutoReconnect.TabIndex = 31;
            this.check_Other_AutoReconnect.Text = "Reconnect on Player Connect";
            this.check_Other_AutoReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Other_AutoReconnect, "Reconnect upon entering a new IP in the IP Control section.");
            this.check_Other_AutoReconnect.UseVisualStyleBackColor = true;
            this.check_Other_AutoReconnect.CheckedChanged += new System.EventHandler(this.check_Other_AutoReconnect_CheckedChanged);
            // 
            // b_Custom_CommandList
            // 
            this.b_Custom_CommandList.BackColor = System.Drawing.SystemColors.Control;
            this.b_Custom_CommandList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Custom_CommandList.Location = new System.Drawing.Point(103, 253);
            this.b_Custom_CommandList.Name = "b_Custom_CommandList";
            this.b_Custom_CommandList.Size = new System.Drawing.Size(118, 23);
            this.b_Custom_CommandList.TabIndex = 33;
            this.b_Custom_CommandList.Text = "Open Command List";
            this.b_Custom_CommandList.UseVisualStyleBackColor = false;
            this.b_Custom_CommandList.Visible = false;
            this.b_Custom_CommandList.Click += new System.EventHandler(this.b_Custom_CommandList_Click);
            // 
            // l_Version
            // 
            this.l_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Version.AutoSize = true;
            this.l_Version.Location = new System.Drawing.Point(227, 258);
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
            this.ClientSize = new System.Drawing.Size(384, 286);
            this.Controls.Add(this.b_Custom_CommandList);
            this.Controls.Add(this.l_Version);
            this.Controls.Add(this.tC_Settings);
            this.Controls.Add(this.b_Settings_Default);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 325);
            this.MinimumSize = new System.Drawing.Size(400, 325);
            this.Name = "SettingsPage";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsPage_FormClosing);
            this.tC_Settings.ResumeLayout(false);
            this.tP_Control.ResumeLayout(false);
            this.tP_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_IPCon_ControlMultiplier)).EndInit();
            this.tP_Paths.ResumeLayout(false);
            this.tP_Paths.PerformLayout();
            this.tP_Recording.ResumeLayout(false);
            this.tP_Recording.PerformLayout();
            this.tP_Customs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Custom_Buttons)).EndInit();
            this.tP_Other.ResumeLayout(false);
            this.tP_Other.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button b_Settings_Default;
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
        public System.Windows.Forms.CheckBox check_Other_AutoPlay;
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
        public System.Windows.Forms.ComboBox cB_IPCon_PresetType;
        public System.Windows.Forms.Label l_IPCon_Port;
        public System.Windows.Forms.Label l_IPCon_ConType;
        public System.Windows.Forms.Label l_IPCon_Adr;
        public System.Windows.Forms.TabPage tP_Customs;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ComboBox cB_ipCon_CamType;
        public System.Windows.Forms.Label l_ipCon_Selected;
        public System.Windows.Forms.Label l_Version;
        private System.Windows.Forms.Button b_Custom_CommandList;
        public System.Windows.Forms.CheckBox check_Other_AutoReconnect;
        public System.Windows.Forms.Label l_Other_CurrentResolution;
        public System.Windows.Forms.TextBox tB_Other_ResolutionHeight;
        public System.Windows.Forms.Label l_Other_ResolutionHeight;
        public System.Windows.Forms.TextBox tB_Other_ResolutionWidth;
        public System.Windows.Forms.Label l_Other_ResolutionWidth;
        public System.Windows.Forms.ComboBox cB_Rec_Quality;
        public System.Windows.Forms.Label l_Rec_Quality;
        public System.Windows.Forms.CheckBox check_AddressInvalid;
        public System.Windows.Forms.DataGridView dgv_Custom_Buttons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ButtonsCommand;
        public System.Windows.Forms.Label l_IPCon_ForceMode;
        private System.Windows.Forms.ComboBox cB_IPCon_ForceMode;
        public System.Windows.Forms.CheckBox check_IPCon_ForceCam;
        public System.Windows.Forms.Label l_Paths_Dir;
        public System.Windows.Forms.TextBox tB_IPCon_CamSpeed;
        public System.Windows.Forms.Label l_IPCon_TrackBar;
        private System.Windows.Forms.TrackBar slider_IPCon_ControlMultiplier;
        private System.Windows.Forms.Label l_IPCon_Percent;
        public System.Windows.Forms.CheckBox check_Other_Aspect;
        private System.Windows.Forms.Label l_Other_Ratio;
        private System.Windows.Forms.Button b_IPCon_Recheck;
        private System.Windows.Forms.Label l_Other_PlayerCount;
        private System.Windows.Forms.ComboBox cB_Other_PlayerCount;
        private System.Windows.Forms.Label l_IPCon_PelcoID;
        private System.Windows.Forms.Button b_IPCon_EditCamType;
        public System.Windows.Forms.Label l_IPCon_Subnet;
    }
}