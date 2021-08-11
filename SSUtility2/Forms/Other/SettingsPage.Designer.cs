
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
            this.tC_Settings = new System.Windows.Forms.TabControl();
            this.tP_Control = new System.Windows.Forms.TabPage();
            this.check_IPCon_Override = new System.Windows.Forms.CheckBox();
            this.cB_IPCon_Port = new System.Windows.Forms.ComboBox();
            this.cB_IPCon_PelcoDID = new System.Windows.Forms.ComboBox();
            this.l_PelcoDID = new System.Windows.Forms.Label();
            this.b_IPCon_Edit = new System.Windows.Forms.Button();
            this.cB_IPCon_MainPlayerPreset = new System.Windows.Forms.ComboBox();
            this.l_IPCon_MainPlayerPreset = new System.Windows.Forms.Label();
            this.l_IPCon_Subnet = new System.Windows.Forms.Label();
            this.b_IPCon_Recheck = new System.Windows.Forms.Button();
            this.l_IPCon_Percent = new System.Windows.Forms.Label();
            this.tB_IPCon_CamSpeed = new System.Windows.Forms.TextBox();
            this.l_IPCon_TrackBar = new System.Windows.Forms.Label();
            this.l_IPCon_ForceMode = new System.Windows.Forms.Label();
            this.cB_IPCon_ForceMode = new System.Windows.Forms.ComboBox();
            this.check_IPCon_ForceCam = new System.Windows.Forms.CheckBox();
            this.tB_IPCon_Adr = new System.Windows.Forms.TextBox();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.l_IPCon_Port = new System.Windows.Forms.Label();
            this.l_IPCon_Adr = new System.Windows.Forms.Label();
            this.slider_IPCon_ControlMultiplier = new System.Windows.Forms.TrackBar();
            this.tP_Recording = new System.Windows.Forms.TabPage();
            this.l_Recording_vCheck = new System.Windows.Forms.Label();
            this.l_Recording_sCCheck = new System.Windows.Forms.Label();
            this.cB_Recording_Quality = new System.Windows.Forms.ComboBox();
            this.l_Recording_Quality = new System.Windows.Forms.Label();
            this.l_Recording_FPS = new System.Windows.Forms.Label();
            this.tB_Recording_scFileN = new System.Windows.Forms.TextBox();
            this.l_Recording_vFileN = new System.Windows.Forms.Label();
            this.l_Recording_sCFileN = new System.Windows.Forms.Label();
            this.tB_Recording_vFileN = new System.Windows.Forms.TextBox();
            this.cB_Recording_FPS = new System.Windows.Forms.ComboBox();
            this.check_Recording_Manual = new System.Windows.Forms.CheckBox();
            this.l_Recording_sCFolder = new System.Windows.Forms.Label();
            this.b_Recording_sCBrowse = new System.Windows.Forms.Button();
            this.tB_Recording_sCFolder = new System.Windows.Forms.TextBox();
            this.b_Recording_vBrowse = new System.Windows.Forms.Button();
            this.l_Paths_vFolder = new System.Windows.Forms.Label();
            this.tB_Recording_vFolder = new System.Windows.Forms.TextBox();
            this.tP_Customs = new System.Windows.Forms.TabPage();
            this.dgv_Custom_Buttons = new System.Windows.Forms.DataGridView();
            this.ButtonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonsCommand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tP_Startup = new System.Windows.Forms.TabPage();
            this.l_Startup_Panels = new System.Windows.Forms.Label();
            this.check_Startup_ControlPanel = new System.Windows.Forms.CheckBox();
            this.check_Startup_QuickFunctions = new System.Windows.Forms.CheckBox();
            this.check_Startup_CustomPanel = new System.Windows.Forms.CheckBox();
            this.check_Startup_InfoPanel = new System.Windows.Forms.CheckBox();
            this.l_Startup_PlayerCount = new System.Windows.Forms.Label();
            this.cB_Startup_PlayerCount = new System.Windows.Forms.ComboBox();
            this.check_Startup_AutoPlay = new System.Windows.Forms.CheckBox();
            this.tP_Other = new System.Windows.Forms.TabPage();
            this.l_Other_CurrentResolution = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tB_Other_ResolutionHeight = new System.Windows.Forms.TextBox();
            this.tB_Other_ResolutionWidth = new System.Windows.Forms.TextBox();
            this.l_Other_ResolutionWidth = new System.Windows.Forms.Label();
            this.l_Other_Dir = new System.Windows.Forms.Label();
            this.b_ChangeDir = new System.Windows.Forms.Button();
            this.l_Other_Ratio = new System.Windows.Forms.Label();
            this.check_Other_Aspect = new System.Windows.Forms.CheckBox();
            this.check_Other_AddressInvalid = new System.Windows.Forms.CheckBox();
            this.b_Custom_CommandList = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.l_Version = new System.Windows.Forms.Label();
            this.check_Other_FullToParts = new System.Windows.Forms.CheckBox();
            this.tC_Settings.SuspendLayout();
            this.tP_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_IPCon_ControlMultiplier)).BeginInit();
            this.tP_Recording.SuspendLayout();
            this.tP_Customs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Custom_Buttons)).BeginInit();
            this.tP_Startup.SuspendLayout();
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
            // tC_Settings
            // 
            this.tC_Settings.Controls.Add(this.tP_Control);
            this.tC_Settings.Controls.Add(this.tP_Recording);
            this.tC_Settings.Controls.Add(this.tP_Customs);
            this.tC_Settings.Controls.Add(this.tP_Startup);
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
            this.tP_Control.Controls.Add(this.check_IPCon_Override);
            this.tP_Control.Controls.Add(this.cB_IPCon_Port);
            this.tP_Control.Controls.Add(this.cB_IPCon_PelcoDID);
            this.tP_Control.Controls.Add(this.l_PelcoDID);
            this.tP_Control.Controls.Add(this.b_IPCon_Edit);
            this.tP_Control.Controls.Add(this.cB_IPCon_MainPlayerPreset);
            this.tP_Control.Controls.Add(this.l_IPCon_MainPlayerPreset);
            this.tP_Control.Controls.Add(this.l_IPCon_Subnet);
            this.tP_Control.Controls.Add(this.b_IPCon_Recheck);
            this.tP_Control.Controls.Add(this.l_IPCon_Percent);
            this.tP_Control.Controls.Add(this.tB_IPCon_CamSpeed);
            this.tP_Control.Controls.Add(this.l_IPCon_TrackBar);
            this.tP_Control.Controls.Add(this.l_IPCon_ForceMode);
            this.tP_Control.Controls.Add(this.cB_IPCon_ForceMode);
            this.tP_Control.Controls.Add(this.check_IPCon_ForceCam);
            this.tP_Control.Controls.Add(this.tB_IPCon_Adr);
            this.tP_Control.Controls.Add(this.l_IPCon_Connected);
            this.tP_Control.Controls.Add(this.l_IPCon_Port);
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
            // check_IPCon_Override
            // 
            this.check_IPCon_Override.AutoSize = true;
            this.check_IPCon_Override.Location = new System.Drawing.Point(255, 62);
            this.check_IPCon_Override.Name = "check_IPCon_Override";
            this.check_IPCon_Override.Size = new System.Drawing.Size(99, 17);
            this.check_IPCon_Override.TabIndex = 4;
            this.check_IPCon_Override.Text = "Override Preset";
            this.check_IPCon_Override.UseVisualStyleBackColor = true;
            this.check_IPCon_Override.CheckedChanged += new System.EventHandler(this.check_IPCon_Override_CheckedChanged);
            // 
            // cB_IPCon_Port
            // 
            this.cB_IPCon_Port.Enabled = false;
            this.cB_IPCon_Port.FormattingEnabled = true;
            this.cB_IPCon_Port.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_IPCon_Port.Location = new System.Drawing.Point(115, 31);
            this.cB_IPCon_Port.Name = "cB_IPCon_Port";
            this.cB_IPCon_Port.Size = new System.Drawing.Size(183, 21);
            this.cB_IPCon_Port.TabIndex = 2;
            this.cB_IPCon_Port.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_Port_SelectedIndexChanged);
            this.cB_IPCon_Port.TextChanged += new System.EventHandler(this.tB_IPCon_ControlFields_TextChanged);
            // 
            // cB_IPCon_PelcoDID
            // 
            this.cB_IPCon_PelcoDID.Enabled = false;
            this.cB_IPCon_PelcoDID.FormattingEnabled = true;
            this.cB_IPCon_PelcoDID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cB_IPCon_PelcoDID.Location = new System.Drawing.Point(115, 58);
            this.cB_IPCon_PelcoDID.Name = "cB_IPCon_PelcoDID";
            this.cB_IPCon_PelcoDID.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_PelcoDID.TabIndex = 3;
            this.cB_IPCon_PelcoDID.TextChanged += new System.EventHandler(this.tB_IPCon_ControlFields_TextChanged);
            // 
            // l_PelcoDID
            // 
            this.l_PelcoDID.AutoSize = true;
            this.l_PelcoDID.Location = new System.Drawing.Point(4, 61);
            this.l_PelcoDID.Name = "l_PelcoDID";
            this.l_PelcoDID.Size = new System.Drawing.Size(48, 13);
            this.l_PelcoDID.TabIndex = 102;
            this.l_PelcoDID.Text = "Pelco ID";
            this.toolTips.SetToolTip(this.l_PelcoDID, "Changes the lens that the camera sends commands to");
            // 
            // b_IPCon_Edit
            // 
            this.b_IPCon_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_IPCon_Edit.BackColor = System.Drawing.SystemColors.Control;
            this.b_IPCon_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_IPCon_Edit.Location = new System.Drawing.Point(304, 84);
            this.b_IPCon_Edit.Name = "b_IPCon_Edit";
            this.b_IPCon_Edit.Size = new System.Drawing.Size(23, 23);
            this.b_IPCon_Edit.TabIndex = 6;
            this.b_IPCon_Edit.Text = "⛭";
            this.b_IPCon_Edit.UseVisualStyleBackColor = false;
            this.b_IPCon_Edit.Visible = false;
            this.b_IPCon_Edit.Click += new System.EventHandler(this.b_IPCon_Edit_Click);
            // 
            // cB_IPCon_MainPlayerPreset
            // 
            this.cB_IPCon_MainPlayerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_IPCon_MainPlayerPreset.FormattingEnabled = true;
            this.cB_IPCon_MainPlayerPreset.Items.AddRange(new object[] {
            "Add New..."});
            this.cB_IPCon_MainPlayerPreset.Location = new System.Drawing.Point(115, 85);
            this.cB_IPCon_MainPlayerPreset.Name = "cB_IPCon_MainPlayerPreset";
            this.cB_IPCon_MainPlayerPreset.Size = new System.Drawing.Size(183, 21);
            this.cB_IPCon_MainPlayerPreset.TabIndex = 5;
            this.toolTips.SetToolTip(this.cB_IPCon_MainPlayerPreset, "Defaults IP Address and Port fields to preset values");
            this.cB_IPCon_MainPlayerPreset.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_MainPlayerPreset_SelectedIndexChanged);
            // 
            // l_IPCon_MainPlayerPreset
            // 
            this.l_IPCon_MainPlayerPreset.AutoSize = true;
            this.l_IPCon_MainPlayerPreset.Location = new System.Drawing.Point(4, 88);
            this.l_IPCon_MainPlayerPreset.Name = "l_IPCon_MainPlayerPreset";
            this.l_IPCon_MainPlayerPreset.Size = new System.Drawing.Size(95, 13);
            this.l_IPCon_MainPlayerPreset.TabIndex = 98;
            this.l_IPCon_MainPlayerPreset.Text = "Main Player Preset";
            this.toolTips.SetToolTip(this.l_IPCon_MainPlayerPreset, "Change the Main Player\'s Preset");
            // 
            // l_IPCon_Subnet
            // 
            this.l_IPCon_Subnet.AutoSize = true;
            this.l_IPCon_Subnet.ForeColor = System.Drawing.Color.DimGray;
            this.l_IPCon_Subnet.Location = new System.Drawing.Point(320, 9);
            this.l_IPCon_Subnet.Name = "l_IPCon_Subnet";
            this.l_IPCon_Subnet.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Subnet.TabIndex = 96;
            // 
            // b_IPCon_Recheck
            // 
            this.b_IPCon_Recheck.Location = new System.Drawing.Point(250, 191);
            this.b_IPCon_Recheck.Name = "b_IPCon_Recheck";
            this.b_IPCon_Recheck.Size = new System.Drawing.Size(90, 21);
            this.b_IPCon_Recheck.TabIndex = 11;
            this.b_IPCon_Recheck.Text = "Recheck Mode";
            this.b_IPCon_Recheck.UseVisualStyleBackColor = true;
            this.b_IPCon_Recheck.Click += new System.EventHandler(this.b_IPCon_Recheck_Click);
            // 
            // l_IPCon_Percent
            // 
            this.l_IPCon_Percent.AutoSize = true;
            this.l_IPCon_Percent.Location = new System.Drawing.Point(291, 127);
            this.l_IPCon_Percent.Name = "l_IPCon_Percent";
            this.l_IPCon_Percent.Size = new System.Drawing.Size(15, 13);
            this.l_IPCon_Percent.TabIndex = 92;
            this.l_IPCon_Percent.Text = "%";
            // 
            // tB_IPCon_CamSpeed
            // 
            this.tB_IPCon_CamSpeed.Location = new System.Drawing.Point(255, 124);
            this.tB_IPCon_CamSpeed.Name = "tB_IPCon_CamSpeed";
            this.tB_IPCon_CamSpeed.Size = new System.Drawing.Size(34, 20);
            this.tB_IPCon_CamSpeed.TabIndex = 8;
            this.tB_IPCon_CamSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_IPCon_CamSpeed_KeyPress);
            this.tB_IPCon_CamSpeed.Leave += new System.EventHandler(this.tB_IPCon_CamSpeed_Leave);
            // 
            // l_IPCon_TrackBar
            // 
            this.l_IPCon_TrackBar.AutoSize = true;
            this.l_IPCon_TrackBar.Location = new System.Drawing.Point(6, 124);
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
            this.cB_IPCon_ForceMode.TabIndex = 10;
            this.toolTips.SetToolTip(this.cB_IPCon_ForceMode, "Affects the processing of received commands");
            this.cB_IPCon_ForceMode.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_ForceMode_SelectedIndexChanged);
            // 
            // check_IPCon_ForceCam
            // 
            this.check_IPCon_ForceCam.Location = new System.Drawing.Point(5, 165);
            this.check_IPCon_ForceCam.Name = "check_IPCon_ForceCam";
            this.check_IPCon_ForceCam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_IPCon_ForceCam.Size = new System.Drawing.Size(125, 24);
            this.check_IPCon_ForceCam.TabIndex = 9;
            this.check_IPCon_ForceCam.Text = "Force Camera Mode";
            this.check_IPCon_ForceCam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_IPCon_ForceCam, "SSUtility is forced to see the connect device as a camera");
            this.check_IPCon_ForceCam.UseVisualStyleBackColor = true;
            this.check_IPCon_ForceCam.CheckedChanged += new System.EventHandler(this.check_IPCon_ForceCam_CheckedChanged);
            // 
            // tB_IPCon_Adr
            // 
            this.tB_IPCon_Adr.Enabled = false;
            this.tB_IPCon_Adr.Location = new System.Drawing.Point(115, 6);
            this.tB_IPCon_Adr.Name = "tB_IPCon_Adr";
            this.tB_IPCon_Adr.Size = new System.Drawing.Size(183, 20);
            this.tB_IPCon_Adr.TabIndex = 1;
            this.toolTips.SetToolTip(this.tB_IPCon_Adr, "IP Address of the camera");
            this.tB_IPCon_Adr.TextChanged += new System.EventHandler(this.tB_IPCon_ControlFields_TextChanged);
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(304, 9);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Connected.TabIndex = 81;
            // 
            // l_IPCon_Port
            // 
            this.l_IPCon_Port.AutoSize = true;
            this.l_IPCon_Port.Location = new System.Drawing.Point(4, 35);
            this.l_IPCon_Port.Name = "l_IPCon_Port";
            this.l_IPCon_Port.Size = new System.Drawing.Size(67, 13);
            this.l_IPCon_Port.TabIndex = 75;
            this.l_IPCon_Port.Text = "Address Port";
            this.toolTips.SetToolTip(this.l_IPCon_Port, "Port of the camera");
            // 
            // l_IPCon_Adr
            // 
            this.l_IPCon_Adr.AutoSize = true;
            this.l_IPCon_Adr.Location = new System.Drawing.Point(4, 9);
            this.l_IPCon_Adr.Name = "l_IPCon_Adr";
            this.l_IPCon_Adr.Size = new System.Drawing.Size(58, 13);
            this.l_IPCon_Adr.TabIndex = 73;
            this.l_IPCon_Adr.Text = "IP Address";
            this.toolTips.SetToolTip(this.l_IPCon_Adr, "IP Address of the camera");
            // 
            // slider_IPCon_ControlMultiplier
            // 
            this.slider_IPCon_ControlMultiplier.BackColor = System.Drawing.SystemColors.Window;
            this.slider_IPCon_ControlMultiplier.Location = new System.Drawing.Point(115, 119);
            this.slider_IPCon_ControlMultiplier.Maximum = 200;
            this.slider_IPCon_ControlMultiplier.Minimum = 1;
            this.slider_IPCon_ControlMultiplier.Name = "slider_IPCon_ControlMultiplier";
            this.slider_IPCon_ControlMultiplier.Size = new System.Drawing.Size(134, 45);
            this.slider_IPCon_ControlMultiplier.TabIndex = 7;
            this.slider_IPCon_ControlMultiplier.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTips.SetToolTip(this.slider_IPCon_ControlMultiplier, "Multiplier of PTZ commands sent to the camera");
            this.slider_IPCon_ControlMultiplier.Value = 100;
            this.slider_IPCon_ControlMultiplier.Scroll += new System.EventHandler(this.slider_IPCon_ControlMultiplier_Scroll);
            this.slider_IPCon_ControlMultiplier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_IPCon_ControlMultiplier_MouseDown);
            this.slider_IPCon_ControlMultiplier.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_IPCon_ControlMultiplier_MouseUp);
            // 
            // tP_Recording
            // 
            this.tP_Recording.Controls.Add(this.l_Recording_vCheck);
            this.tP_Recording.Controls.Add(this.l_Recording_sCCheck);
            this.tP_Recording.Controls.Add(this.cB_Recording_Quality);
            this.tP_Recording.Controls.Add(this.l_Recording_Quality);
            this.tP_Recording.Controls.Add(this.l_Recording_FPS);
            this.tP_Recording.Controls.Add(this.tB_Recording_scFileN);
            this.tP_Recording.Controls.Add(this.l_Recording_vFileN);
            this.tP_Recording.Controls.Add(this.l_Recording_sCFileN);
            this.tP_Recording.Controls.Add(this.tB_Recording_vFileN);
            this.tP_Recording.Controls.Add(this.cB_Recording_FPS);
            this.tP_Recording.Controls.Add(this.check_Recording_Manual);
            this.tP_Recording.Controls.Add(this.l_Recording_sCFolder);
            this.tP_Recording.Controls.Add(this.b_Recording_sCBrowse);
            this.tP_Recording.Controls.Add(this.tB_Recording_sCFolder);
            this.tP_Recording.Controls.Add(this.b_Recording_vBrowse);
            this.tP_Recording.Controls.Add(this.l_Paths_vFolder);
            this.tP_Recording.Controls.Add(this.tB_Recording_vFolder);
            this.tP_Recording.Location = new System.Drawing.Point(4, 22);
            this.tP_Recording.Name = "tP_Recording";
            this.tP_Recording.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Recording.Size = new System.Drawing.Size(370, 219);
            this.tP_Recording.TabIndex = 1;
            this.tP_Recording.Text = "Recording";
            this.tP_Recording.UseVisualStyleBackColor = true;
            // 
            // l_Recording_vCheck
            // 
            this.l_Recording_vCheck.AutoSize = true;
            this.l_Recording_vCheck.Location = new System.Drawing.Point(345, 68);
            this.l_Recording_vCheck.Name = "l_Recording_vCheck";
            this.l_Recording_vCheck.Size = new System.Drawing.Size(14, 13);
            this.l_Recording_vCheck.TabIndex = 50;
            this.l_Recording_vCheck.Text = "X";
            // 
            // l_Recording_sCCheck
            // 
            this.l_Recording_sCCheck.AutoSize = true;
            this.l_Recording_sCCheck.Location = new System.Drawing.Point(345, 42);
            this.l_Recording_sCCheck.Name = "l_Recording_sCCheck";
            this.l_Recording_sCCheck.Size = new System.Drawing.Size(14, 13);
            this.l_Recording_sCCheck.TabIndex = 49;
            this.l_Recording_sCCheck.Text = "X";
            // 
            // cB_Recording_Quality
            // 
            this.cB_Recording_Quality.BackColor = System.Drawing.SystemColors.Window;
            this.cB_Recording_Quality.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cB_Recording_Quality.FormattingEnabled = true;
            this.cB_Recording_Quality.Items.AddRange(new object[] {
            "50",
            "70",
            "100"});
            this.cB_Recording_Quality.Location = new System.Drawing.Point(113, 169);
            this.cB_Recording_Quality.Name = "cB_Recording_Quality";
            this.cB_Recording_Quality.Size = new System.Drawing.Size(119, 21);
            this.cB_Recording_Quality.TabIndex = 42;
            this.toolTips.SetToolTip(this.cB_Recording_Quality, "Video capture output quality, lower to reduce output file size and to improve per" +
        "formance during capture, increase to improve output file quality.");
            this.cB_Recording_Quality.TextChanged += new System.EventHandler(this.cB_Recording_Quality_TextChanged);
            // 
            // l_Recording_Quality
            // 
            this.l_Recording_Quality.AutoSize = true;
            this.l_Recording_Quality.Location = new System.Drawing.Point(4, 172);
            this.l_Recording_Quality.Name = "l_Recording_Quality";
            this.l_Recording_Quality.Size = new System.Drawing.Size(105, 13);
            this.l_Recording_Quality.TabIndex = 48;
            this.l_Recording_Quality.Text = "Video Quality (1-100)";
            this.toolTips.SetToolTip(this.l_Recording_Quality, "Video capture output quality, lower to reduce output file size and to improve per" +
        "formance during capture, increase to improve output file quality.");
            // 
            // l_Recording_FPS
            // 
            this.l_Recording_FPS.AutoSize = true;
            this.l_Recording_FPS.Location = new System.Drawing.Point(4, 145);
            this.l_Recording_FPS.Name = "l_Recording_FPS";
            this.l_Recording_FPS.Size = new System.Drawing.Size(97, 13);
            this.l_Recording_FPS.TabIndex = 43;
            this.l_Recording_FPS.Text = "Video Capture FPS";
            this.toolTips.SetToolTip(this.l_Recording_FPS, "Video capture framerate, lower to reduce latency, increase to improve smoothness " +
        "of output video.");
            // 
            // tB_Recording_scFileN
            // 
            this.tB_Recording_scFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Recording_scFileN.Enabled = false;
            this.tB_Recording_scFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Recording_scFileN.Location = new System.Drawing.Point(113, 116);
            this.tB_Recording_scFileN.Name = "tB_Recording_scFileN";
            this.tB_Recording_scFileN.Size = new System.Drawing.Size(200, 20);
            this.tB_Recording_scFileN.TabIndex = 45;
            this.tB_Recording_scFileN.TextChanged += new System.EventHandler(this.tB_Recording_scFileN_TextChanged);
            // 
            // l_Recording_vFileN
            // 
            this.l_Recording_vFileN.AutoSize = true;
            this.l_Recording_vFileN.Location = new System.Drawing.Point(4, 93);
            this.l_Recording_vFileN.Name = "l_Recording_vFileN";
            this.l_Recording_vFileN.Size = new System.Drawing.Size(84, 13);
            this.l_Recording_vFileN.TabIndex = 46;
            this.l_Recording_vFileN.Text = "Video File Name";
            // 
            // l_Recording_sCFileN
            // 
            this.l_Recording_sCFileN.AutoSize = true;
            this.l_Recording_sCFileN.Location = new System.Drawing.Point(4, 119);
            this.l_Recording_sCFileN.Name = "l_Recording_sCFileN";
            this.l_Recording_sCFileN.Size = new System.Drawing.Size(102, 13);
            this.l_Recording_sCFileN.TabIndex = 47;
            this.l_Recording_sCFileN.Text = "Snapshot File Name";
            // 
            // tB_Recording_vFileN
            // 
            this.tB_Recording_vFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Recording_vFileN.Enabled = false;
            this.tB_Recording_vFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Recording_vFileN.Location = new System.Drawing.Point(113, 90);
            this.tB_Recording_vFileN.Name = "tB_Recording_vFileN";
            this.tB_Recording_vFileN.Size = new System.Drawing.Size(200, 20);
            this.tB_Recording_vFileN.TabIndex = 44;
            this.tB_Recording_vFileN.TextChanged += new System.EventHandler(this.tB_Recording_vFileN_TextChanged);
            // 
            // cB_Recording_FPS
            // 
            this.cB_Recording_FPS.BackColor = System.Drawing.SystemColors.Window;
            this.cB_Recording_FPS.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cB_Recording_FPS.FormattingEnabled = true;
            this.cB_Recording_FPS.Items.AddRange(new object[] {
            "15",
            "24",
            "30",
            "45",
            "60"});
            this.cB_Recording_FPS.Location = new System.Drawing.Point(113, 142);
            this.cB_Recording_FPS.Name = "cB_Recording_FPS";
            this.cB_Recording_FPS.Size = new System.Drawing.Size(119, 21);
            this.cB_Recording_FPS.TabIndex = 41;
            this.toolTips.SetToolTip(this.cB_Recording_FPS, "Video capture framerate, lower to reduce latency, increase to improve smoothness " +
        "of output video.");
            this.cB_Recording_FPS.TextChanged += new System.EventHandler(this.cB_Recording_FPS_TextChanged);
            // 
            // check_Recording_Manual
            // 
            this.check_Recording_Manual.Checked = true;
            this.check_Recording_Manual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Recording_Manual.Location = new System.Drawing.Point(4, 11);
            this.check_Recording_Manual.Name = "check_Recording_Manual";
            this.check_Recording_Manual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Recording_Manual.Size = new System.Drawing.Size(124, 21);
            this.check_Recording_Manual.TabIndex = 34;
            this.check_Recording_Manual.Text = "Automatic Paths";
            this.check_Recording_Manual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Recording_Manual, "Automatic paths are Documents\\SSUtility\\Saved\\[CAMERA NAME]");
            this.check_Recording_Manual.UseVisualStyleBackColor = true;
            this.check_Recording_Manual.CheckedChanged += new System.EventHandler(this.check_Recording_Manual_CheckedChanged);
            // 
            // l_Recording_sCFolder
            // 
            this.l_Recording_sCFolder.AutoSize = true;
            this.l_Recording_sCFolder.Location = new System.Drawing.Point(4, 41);
            this.l_Recording_sCFolder.Name = "l_Recording_sCFolder";
            this.l_Recording_sCFolder.Size = new System.Drawing.Size(84, 13);
            this.l_Recording_sCFolder.TabIndex = 36;
            this.l_Recording_sCFolder.Text = "Snapshot Folder";
            // 
            // b_Recording_sCBrowse
            // 
            this.b_Recording_sCBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Recording_sCBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Recording_sCBrowse.Enabled = false;
            this.b_Recording_sCBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Recording_sCBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.b_Recording_sCBrowse.Location = new System.Drawing.Point(312, 38);
            this.b_Recording_sCBrowse.Name = "b_Recording_sCBrowse";
            this.b_Recording_sCBrowse.Size = new System.Drawing.Size(27, 20);
            this.b_Recording_sCBrowse.TabIndex = 37;
            this.b_Recording_sCBrowse.Text = "...";
            this.b_Recording_sCBrowse.UseVisualStyleBackColor = false;
            this.b_Recording_sCBrowse.Click += new System.EventHandler(this.b_Recording_sCBrowse_Click);
            // 
            // tB_Recording_sCFolder
            // 
            this.tB_Recording_sCFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Recording_sCFolder.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Recording_sCFolder.Enabled = false;
            this.tB_Recording_sCFolder.Location = new System.Drawing.Point(113, 38);
            this.tB_Recording_sCFolder.Name = "tB_Recording_sCFolder";
            this.tB_Recording_sCFolder.Size = new System.Drawing.Size(200, 20);
            this.tB_Recording_sCFolder.TabIndex = 35;
            this.tB_Recording_sCFolder.TextChanged += new System.EventHandler(this.tB_Recording_sCFolder_TextChanged);
            // 
            // b_Recording_vBrowse
            // 
            this.b_Recording_vBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Recording_vBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.b_Recording_vBrowse.Enabled = false;
            this.b_Recording_vBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Recording_vBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.b_Recording_vBrowse.Location = new System.Drawing.Point(312, 64);
            this.b_Recording_vBrowse.Name = "b_Recording_vBrowse";
            this.b_Recording_vBrowse.Size = new System.Drawing.Size(26, 20);
            this.b_Recording_vBrowse.TabIndex = 39;
            this.b_Recording_vBrowse.Text = "...";
            this.b_Recording_vBrowse.UseVisualStyleBackColor = false;
            this.b_Recording_vBrowse.Click += new System.EventHandler(this.b_Recording_vBrowse_Click);
            // 
            // l_Paths_vFolder
            // 
            this.l_Paths_vFolder.AutoSize = true;
            this.l_Paths_vFolder.Location = new System.Drawing.Point(4, 67);
            this.l_Paths_vFolder.Name = "l_Paths_vFolder";
            this.l_Paths_vFolder.Size = new System.Drawing.Size(106, 13);
            this.l_Paths_vFolder.TabIndex = 40;
            this.l_Paths_vFolder.Text = "Video Capture Folder";
            // 
            // tB_Recording_vFolder
            // 
            this.tB_Recording_vFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Recording_vFolder.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Recording_vFolder.Enabled = false;
            this.tB_Recording_vFolder.Location = new System.Drawing.Point(113, 64);
            this.tB_Recording_vFolder.Name = "tB_Recording_vFolder";
            this.tB_Recording_vFolder.Size = new System.Drawing.Size(200, 20);
            this.tB_Recording_vFolder.TabIndex = 38;
            this.tB_Recording_vFolder.TextChanged += new System.EventHandler(this.tB_Recording_vFolder_TextChanged);
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
            // tP_Startup
            // 
            this.tP_Startup.Controls.Add(this.l_Startup_Panels);
            this.tP_Startup.Controls.Add(this.check_Startup_ControlPanel);
            this.tP_Startup.Controls.Add(this.check_Startup_QuickFunctions);
            this.tP_Startup.Controls.Add(this.check_Startup_CustomPanel);
            this.tP_Startup.Controls.Add(this.check_Startup_InfoPanel);
            this.tP_Startup.Controls.Add(this.l_Startup_PlayerCount);
            this.tP_Startup.Controls.Add(this.cB_Startup_PlayerCount);
            this.tP_Startup.Controls.Add(this.check_Startup_AutoPlay);
            this.tP_Startup.Location = new System.Drawing.Point(4, 22);
            this.tP_Startup.Name = "tP_Startup";
            this.tP_Startup.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Startup.Size = new System.Drawing.Size(370, 219);
            this.tP_Startup.TabIndex = 5;
            this.tP_Startup.Text = "Startup";
            this.tP_Startup.UseVisualStyleBackColor = true;
            // 
            // l_Startup_Panels
            // 
            this.l_Startup_Panels.AutoSize = true;
            this.l_Startup_Panels.Location = new System.Drawing.Point(4, 72);
            this.l_Startup_Panels.Name = "l_Startup_Panels";
            this.l_Startup_Panels.Size = new System.Drawing.Size(102, 13);
            this.l_Startup_Panels.TabIndex = 56;
            this.l_Startup_Panels.Text = "On Launch, Enable:";
            // 
            // check_Startup_ControlPanel
            // 
            this.check_Startup_ControlPanel.Location = new System.Drawing.Point(3, 137);
            this.check_Startup_ControlPanel.Name = "check_Startup_ControlPanel";
            this.check_Startup_ControlPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Startup_ControlPanel.Size = new System.Drawing.Size(107, 17);
            this.check_Startup_ControlPanel.TabIndex = 55;
            this.check_Startup_ControlPanel.Text = "Control Panel";
            this.check_Startup_ControlPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Startup_ControlPanel, "Play videos upon launch of the program if any have been entered previously.");
            this.check_Startup_ControlPanel.UseVisualStyleBackColor = true;
            this.check_Startup_ControlPanel.CheckedChanged += new System.EventHandler(this.check_Startup_ControlPanel_CheckedChanged);
            // 
            // check_Startup_QuickFunctions
            // 
            this.check_Startup_QuickFunctions.Location = new System.Drawing.Point(3, 91);
            this.check_Startup_QuickFunctions.Name = "check_Startup_QuickFunctions";
            this.check_Startup_QuickFunctions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Startup_QuickFunctions.Size = new System.Drawing.Size(107, 17);
            this.check_Startup_QuickFunctions.TabIndex = 54;
            this.check_Startup_QuickFunctions.Text = "Quick Functions";
            this.check_Startup_QuickFunctions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Startup_QuickFunctions, "Play videos upon launch of the program if any have been entered previously.");
            this.check_Startup_QuickFunctions.UseVisualStyleBackColor = true;
            this.check_Startup_QuickFunctions.CheckedChanged += new System.EventHandler(this.check_Startup_QuickFunctions_CheckedChanged);
            // 
            // check_Startup_CustomPanel
            // 
            this.check_Startup_CustomPanel.Location = new System.Drawing.Point(3, 160);
            this.check_Startup_CustomPanel.Name = "check_Startup_CustomPanel";
            this.check_Startup_CustomPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Startup_CustomPanel.Size = new System.Drawing.Size(107, 17);
            this.check_Startup_CustomPanel.TabIndex = 53;
            this.check_Startup_CustomPanel.Text = "Custom Panel";
            this.check_Startup_CustomPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Startup_CustomPanel, "Play videos upon launch of the program if any have been entered previously.");
            this.check_Startup_CustomPanel.UseVisualStyleBackColor = true;
            this.check_Startup_CustomPanel.CheckedChanged += new System.EventHandler(this.check_Startup_CustomPanel_CheckedChanged);
            // 
            // check_Startup_InfoPanel
            // 
            this.check_Startup_InfoPanel.Location = new System.Drawing.Point(3, 114);
            this.check_Startup_InfoPanel.Name = "check_Startup_InfoPanel";
            this.check_Startup_InfoPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Startup_InfoPanel.Size = new System.Drawing.Size(107, 17);
            this.check_Startup_InfoPanel.TabIndex = 52;
            this.check_Startup_InfoPanel.Text = "Info Panel";
            this.check_Startup_InfoPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Startup_InfoPanel, "Play videos upon launch of the program if any have been entered previously.");
            this.check_Startup_InfoPanel.UseVisualStyleBackColor = true;
            this.check_Startup_InfoPanel.CheckedChanged += new System.EventHandler(this.check_Startup_InfoPanel_CheckedChanged);
            // 
            // l_Startup_PlayerCount
            // 
            this.l_Startup_PlayerCount.AutoSize = true;
            this.l_Startup_PlayerCount.Location = new System.Drawing.Point(4, 36);
            this.l_Startup_PlayerCount.Name = "l_Startup_PlayerCount";
            this.l_Startup_PlayerCount.Size = new System.Drawing.Size(147, 13);
            this.l_Startup_PlayerCount.TabIndex = 49;
            this.l_Startup_PlayerCount.Text = "Number of Players on Launch";
            this.toolTips.SetToolTip(this.l_Startup_PlayerCount, "Number of players (including the MainPlayer) spawned");
            // 
            // cB_Startup_PlayerCount
            // 
            this.cB_Startup_PlayerCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Startup_PlayerCount.FormattingEnabled = true;
            this.cB_Startup_PlayerCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cB_Startup_PlayerCount.Location = new System.Drawing.Point(163, 33);
            this.cB_Startup_PlayerCount.Name = "cB_Startup_PlayerCount";
            this.cB_Startup_PlayerCount.Size = new System.Drawing.Size(114, 21);
            this.cB_Startup_PlayerCount.TabIndex = 45;
            this.toolTips.SetToolTip(this.cB_Startup_PlayerCount, "Number of players (including the Main Player) spawned on launch");
            this.cB_Startup_PlayerCount.SelectedIndexChanged += new System.EventHandler(this.cB_Startup_PlayerCount_SelectedIndexChanged);
            // 
            // check_Startup_AutoPlay
            // 
            this.check_Startup_AutoPlay.Location = new System.Drawing.Point(4, 10);
            this.check_Startup_AutoPlay.Name = "check_Startup_AutoPlay";
            this.check_Startup_AutoPlay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Startup_AutoPlay.Size = new System.Drawing.Size(174, 17);
            this.check_Startup_AutoPlay.TabIndex = 2;
            this.check_Startup_AutoPlay.Text = "Autoplay Videos on Launch";
            this.check_Startup_AutoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Startup_AutoPlay, "Play videos upon launch of the program if any have been entered previously.");
            this.check_Startup_AutoPlay.UseVisualStyleBackColor = true;
            this.check_Startup_AutoPlay.CheckedChanged += new System.EventHandler(this.check_Startup_AutoPlay_CheckedChanged);
            // 
            // tP_Other
            // 
            this.tP_Other.Controls.Add(this.check_Other_FullToParts);
            this.tP_Other.Controls.Add(this.l_Other_CurrentResolution);
            this.tP_Other.Controls.Add(this.label1);
            this.tP_Other.Controls.Add(this.tB_Other_ResolutionHeight);
            this.tP_Other.Controls.Add(this.tB_Other_ResolutionWidth);
            this.tP_Other.Controls.Add(this.l_Other_ResolutionWidth);
            this.tP_Other.Controls.Add(this.l_Other_Dir);
            this.tP_Other.Controls.Add(this.b_ChangeDir);
            this.tP_Other.Controls.Add(this.l_Other_Ratio);
            this.tP_Other.Controls.Add(this.check_Other_Aspect);
            this.tP_Other.Controls.Add(this.check_Other_AddressInvalid);
            this.tP_Other.Location = new System.Drawing.Point(4, 22);
            this.tP_Other.Name = "tP_Other";
            this.tP_Other.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Other.Size = new System.Drawing.Size(370, 219);
            this.tP_Other.TabIndex = 2;
            this.tP_Other.Text = "Other";
            this.tP_Other.UseVisualStyleBackColor = true;
            // 
            // l_Other_CurrentResolution
            // 
            this.l_Other_CurrentResolution.AutoSize = true;
            this.l_Other_CurrentResolution.Location = new System.Drawing.Point(4, 143);
            this.l_Other_CurrentResolution.Name = "l_Other_CurrentResolution";
            this.l_Other_CurrentResolution.Size = new System.Drawing.Size(116, 13);
            this.l_Other_CurrentResolution.TabIndex = 55;
            this.l_Other_CurrentResolution.Text = "Current MainForm Size:";
            this.toolTips.SetToolTip(this.l_Other_CurrentResolution, "Width x Height");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // tB_Other_ResolutionHeight
            // 
            this.tB_Other_ResolutionHeight.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Other_ResolutionHeight.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Other_ResolutionHeight.Location = new System.Drawing.Point(266, 117);
            this.tB_Other_ResolutionHeight.Name = "tB_Other_ResolutionHeight";
            this.tB_Other_ResolutionHeight.Size = new System.Drawing.Size(75, 20);
            this.tB_Other_ResolutionHeight.TabIndex = 52;
            this.toolTips.SetToolTip(this.tB_Other_ResolutionHeight, "Launches the program with this height (does not change current resolution).");
            this.tB_Other_ResolutionHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Other_Resolution_KeyUp);
            // 
            // tB_Other_ResolutionWidth
            // 
            this.tB_Other_ResolutionWidth.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Other_ResolutionWidth.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Other_ResolutionWidth.Location = new System.Drawing.Point(165, 117);
            this.tB_Other_ResolutionWidth.Name = "tB_Other_ResolutionWidth";
            this.tB_Other_ResolutionWidth.Size = new System.Drawing.Size(75, 20);
            this.tB_Other_ResolutionWidth.TabIndex = 51;
            this.toolTips.SetToolTip(this.tB_Other_ResolutionWidth, "Launches the program with this width (does not change current resolution).");
            this.tB_Other_ResolutionWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tB_Other_Resolution_KeyUp);
            // 
            // l_Other_ResolutionWidth
            // 
            this.l_Other_ResolutionWidth.AutoSize = true;
            this.l_Other_ResolutionWidth.Location = new System.Drawing.Point(4, 120);
            this.l_Other_ResolutionWidth.Name = "l_Other_ResolutionWidth";
            this.l_Other_ResolutionWidth.Size = new System.Drawing.Size(109, 13);
            this.l_Other_ResolutionWidth.TabIndex = 53;
            this.l_Other_ResolutionWidth.Text = "Main Form Resolution";
            this.toolTips.SetToolTip(this.l_Other_ResolutionWidth, "Launches the program with this Width x Height (does not update on manual resizing" +
        ").");
            // 
            // l_Other_Dir
            // 
            this.l_Other_Dir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Other_Dir.AutoSize = true;
            this.l_Other_Dir.Location = new System.Drawing.Point(4, 165);
            this.l_Other_Dir.Name = "l_Other_Dir";
            this.l_Other_Dir.Size = new System.Drawing.Size(89, 13);
            this.l_Other_Dir.TabIndex = 43;
            this.l_Other_Dir.Text = "Current Directory:";
            // 
            // b_ChangeDir
            // 
            this.b_ChangeDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_ChangeDir.BackColor = System.Drawing.SystemColors.Control;
            this.b_ChangeDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_ChangeDir.Location = new System.Drawing.Point(4, 190);
            this.b_ChangeDir.Name = "b_ChangeDir";
            this.b_ChangeDir.Size = new System.Drawing.Size(113, 23);
            this.b_ChangeDir.TabIndex = 42;
            this.b_ChangeDir.Text = "Change Directory";
            this.toolTips.SetToolTip(this.b_ChangeDir, "Change the program\'s base directory");
            this.b_ChangeDir.UseVisualStyleBackColor = false;
            this.b_ChangeDir.Click += new System.EventHandler(this.b_Other_ChangeDir_Click);
            // 
            // l_Other_Ratio
            // 
            this.l_Other_Ratio.AutoSize = true;
            this.l_Other_Ratio.Location = new System.Drawing.Point(186, 98);
            this.l_Other_Ratio.Name = "l_Other_Ratio";
            this.l_Other_Ratio.Size = new System.Drawing.Size(22, 13);
            this.l_Other_Ratio.TabIndex = 39;
            this.l_Other_Ratio.Text = "1:1";
            this.l_Other_Ratio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Other_Ratio.Visible = false;
            // 
            // check_Other_Aspect
            // 
            this.check_Other_Aspect.Location = new System.Drawing.Point(4, 93);
            this.check_Other_Aspect.Name = "check_Other_Aspect";
            this.check_Other_Aspect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_Aspect.Size = new System.Drawing.Size(175, 24);
            this.check_Other_Aspect.TabIndex = 7;
            this.check_Other_Aspect.Text = "Maintain Current Aspect Ratio";
            this.check_Other_Aspect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Other_Aspect, "Resize the Main Player to maintain the shown aspect ratio");
            this.check_Other_Aspect.UseVisualStyleBackColor = true;
            this.check_Other_Aspect.CheckedChanged += new System.EventHandler(this.check_Other_Aspect_CheckedChanged);
            // 
            // check_Other_AddressInvalid
            // 
            this.check_Other_AddressInvalid.Location = new System.Drawing.Point(4, 6);
            this.check_Other_AddressInvalid.Name = "check_Other_AddressInvalid";
            this.check_Other_AddressInvalid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_AddressInvalid.Size = new System.Drawing.Size(174, 17);
            this.check_Other_AddressInvalid.TabIndex = 3;
            this.check_Other_AddressInvalid.Text = "Hide Address Invalid Error";
            this.check_Other_AddressInvalid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Other_AddressInvalid, "Ignores errors to do with given player addresses being invalid");
            this.check_Other_AddressInvalid.UseVisualStyleBackColor = true;
            this.check_Other_AddressInvalid.CheckedChanged += new System.EventHandler(this.check_Other_AddressInvalid_CheckedChanged);
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
            // check_Other_FullToParts
            // 
            this.check_Other_FullToParts.Location = new System.Drawing.Point(4, 29);
            this.check_Other_FullToParts.Name = "check_Other_FullToParts";
            this.check_Other_FullToParts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_FullToParts.Size = new System.Drawing.Size(174, 17);
            this.check_Other_FullToParts.TabIndex = 56;
            this.check_Other_FullToParts.Text = "Full Address RTSP Breakdown";
            this.check_Other_FullToParts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTips.SetToolTip(this.check_Other_FullToParts, "Toggles the software from automatically trying to break down custom full addresse" +
        "s (copy/pasting a full address into the full address field) into the other compo" +
        "nent fields within the RTSP Wizard");
            this.check_Other_FullToParts.UseVisualStyleBackColor = true;
            this.check_Other_FullToParts.CheckedChanged += new System.EventHandler(this.check_Other_FullToParts_CheckedChanged);
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
            this.tP_Recording.ResumeLayout(false);
            this.tP_Recording.PerformLayout();
            this.tP_Customs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Custom_Buttons)).EndInit();
            this.tP_Startup.ResumeLayout(false);
            this.tP_Startup.PerformLayout();
            this.tP_Other.ResumeLayout(false);
            this.tP_Other.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button b_Settings_Default;
        public System.Windows.Forms.TabControl tC_Settings;
        public System.Windows.Forms.TabPage tP_Recording;
        public System.Windows.Forms.TabPage tP_Other;
        public System.Windows.Forms.ToolTip toolTips;
        public System.Windows.Forms.TabPage tP_Control;
        public System.Windows.Forms.TextBox tB_IPCon_Adr;
        public System.Windows.Forms.Label l_IPCon_Connected;
        public System.Windows.Forms.Label l_IPCon_Port;
        public System.Windows.Forms.Label l_IPCon_Adr;
        public System.Windows.Forms.TabPage tP_Customs;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Label l_Version;
        private System.Windows.Forms.Button b_Custom_CommandList;
        public System.Windows.Forms.CheckBox check_Other_AddressInvalid;
        public System.Windows.Forms.DataGridView dgv_Custom_Buttons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ButtonsCommand;
        public System.Windows.Forms.Label l_IPCon_ForceMode;
        private System.Windows.Forms.ComboBox cB_IPCon_ForceMode;
        public System.Windows.Forms.CheckBox check_IPCon_ForceCam;
        public System.Windows.Forms.TextBox tB_IPCon_CamSpeed;
        public System.Windows.Forms.Label l_IPCon_TrackBar;
        private System.Windows.Forms.TrackBar slider_IPCon_ControlMultiplier;
        private System.Windows.Forms.Label l_IPCon_Percent;
        public System.Windows.Forms.CheckBox check_Other_Aspect;
        private System.Windows.Forms.Label l_Other_Ratio;
        private System.Windows.Forms.Button b_IPCon_Recheck;
        public System.Windows.Forms.Label l_IPCon_Subnet;
        public System.Windows.Forms.ComboBox cB_IPCon_MainPlayerPreset;
        public System.Windows.Forms.Label l_IPCon_MainPlayerPreset;
        public System.Windows.Forms.Button b_IPCon_Edit;
        public System.Windows.Forms.ComboBox cB_IPCon_PelcoDID;
        public System.Windows.Forms.Label l_PelcoDID;
        public System.Windows.Forms.ComboBox cB_IPCon_Port;
        private System.Windows.Forms.CheckBox check_IPCon_Override;
        private System.Windows.Forms.TabPage tP_Startup;
        private System.Windows.Forms.Label l_Startup_PlayerCount;
        private System.Windows.Forms.ComboBox cB_Startup_PlayerCount;
        public System.Windows.Forms.CheckBox check_Startup_AutoPlay;
        public System.Windows.Forms.Label l_Other_Dir;
        public System.Windows.Forms.Button b_ChangeDir;
        public System.Windows.Forms.ComboBox cB_Recording_Quality;
        public System.Windows.Forms.Label l_Recording_Quality;
        public System.Windows.Forms.Label l_Recording_FPS;
        public System.Windows.Forms.TextBox tB_Recording_scFileN;
        public System.Windows.Forms.Label l_Recording_vFileN;
        public System.Windows.Forms.Label l_Recording_sCFileN;
        public System.Windows.Forms.TextBox tB_Recording_vFileN;
        public System.Windows.Forms.ComboBox cB_Recording_FPS;
        public System.Windows.Forms.CheckBox check_Recording_Manual;
        public System.Windows.Forms.Label l_Recording_sCFolder;
        public System.Windows.Forms.Button b_Recording_sCBrowse;
        public System.Windows.Forms.TextBox tB_Recording_sCFolder;
        public System.Windows.Forms.Button b_Recording_vBrowse;
        public System.Windows.Forms.Label l_Paths_vFolder;
        public System.Windows.Forms.TextBox tB_Recording_vFolder;
        public System.Windows.Forms.CheckBox check_Startup_ControlPanel;
        public System.Windows.Forms.CheckBox check_Startup_QuickFunctions;
        public System.Windows.Forms.CheckBox check_Startup_CustomPanel;
        public System.Windows.Forms.CheckBox check_Startup_InfoPanel;
        public System.Windows.Forms.Label l_Other_CurrentResolution;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tB_Other_ResolutionHeight;
        public System.Windows.Forms.TextBox tB_Other_ResolutionWidth;
        public System.Windows.Forms.Label l_Other_ResolutionWidth;
        private System.Windows.Forms.Label l_Recording_vCheck;
        private System.Windows.Forms.Label l_Recording_sCCheck;
        private System.Windows.Forms.Label l_Startup_Panels;
        public System.Windows.Forms.CheckBox check_Other_FullToParts;
    }
}