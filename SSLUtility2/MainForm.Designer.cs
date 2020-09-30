/*
 * Created by SharpDevelop.
 * User: Alistair
 * Date: 17/03/2018
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SSLUtility2 {

	partial class MainForm {

		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GetSNbutton = new System.Windows.Forms.Button();
            this.Versionlabel = new System.Windows.Forms.Label();
            this.Writebutton = new System.Windows.Forms.Button();
            this.Erasebutton = new System.Windows.Forms.Button();
            this.Checksumbutton = new System.Windows.Forms.Button();
            this.LoadHexbutton = new System.Windows.Forms.Button();
            this.Activatebutton = new System.Windows.Forms.Button();
            this.DeActivatebutton = new System.Windows.Forms.Button();
            this.Gobutton = new System.Windows.Forms.Button();
            this.Speedlabel = new System.Windows.Forms.Label();
            this.LoadSpeedlabel = new System.Windows.Forms.Label();
            this.SpeedcomboBox = new System.Windows.Forms.ComboBox();
            this.LoadSpeedcomboBox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Portlabel = new System.Windows.Forms.Label();
            this.PortcomboBox = new System.Windows.Forms.ComboBox();
            this.Portbutton = new System.Windows.Forms.Button();
            this.LogtextBox = new System.Windows.Forms.TextBox();
            this.Loglabel = new System.Windows.Forms.Label();
            this.ClearLogbutton = new System.Windows.Forms.Button();
            this.Versiontext = new System.Windows.Forms.Label();
            this.SNtext = new System.Windows.Forms.Label();
            this.CamNoUpDown = new System.Windows.Forms.NumericUpDown();
            this.CamNolabel = new System.Windows.Forms.Label();
            this.Abortbutton = new System.Windows.Forms.Button();
            this.ResetMemorybutton = new System.Windows.Forms.Button();
            this.tC_Main = new System.Windows.Forms.TabControl();
            this.camControl = new System.Windows.Forms.TabPage();
            this.tC_Control = new System.Windows.Forms.TabControl();
            this.tP_CameraCon = new System.Windows.Forms.TabPage();
            this.l_Version = new System.Windows.Forms.Label();
            this.tP_Settings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.l_Other = new System.Windows.Forms.Label();
            this.check_Other_AutoPlay = new System.Windows.Forms.CheckBox();
            this.check_Not_Config = new System.Windows.Forms.CheckBox();
            this.check_Not_Subnet = new System.Windows.Forms.CheckBox();
            this.l_Notifs = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cB_Rec_Quality = new System.Windows.Forms.ComboBox();
            this.l_Rec_Quality = new System.Windows.Forms.Label();
            this.tB_Rec_scFileN = new System.Windows.Forms.TextBox();
            this.l_Rec_sCFileN = new System.Windows.Forms.Label();
            this.cB_Rec_FPS = new System.Windows.Forms.ComboBox();
            this.tB_Rec_vFileN = new System.Windows.Forms.TextBox();
            this.l_Rec_vFileN = new System.Windows.Forms.Label();
            this.l_Rec = new System.Windows.Forms.Label();
            this.l_Rec_FPS = new System.Windows.Forms.Label();
            this.gB_Paths = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check_Paths_Manual = new System.Windows.Forms.CheckBox();
            this.l_Paths_sCCheck = new System.Windows.Forms.Label();
            this.l_Paths_vCheck = new System.Windows.Forms.Label();
            this.b_Paths_vBrowse = new System.Windows.Forms.Button();
            this.tB_Paths_vFolder = new System.Windows.Forms.TextBox();
            this.l_Paths_vFolder = new System.Windows.Forms.Label();
            this.tB_Paths_sCFolder = new System.Windows.Forms.TextBox();
            this.b_Paths_sCBrowse = new System.Windows.Forms.Button();
            this.l_Paths = new System.Windows.Forms.Label();
            this.l_Paths_sCFolder = new System.Windows.Forms.Label();
            this.b_Settings_Default = new System.Windows.Forms.Button();
            this.b_Settings_Apply = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalTestModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detachedPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pelcoDScriptingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.responseLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liteModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.CamNoUpDown)).BeginInit();
            this.tC_Main.SuspendLayout();
            this.camControl.SuspendLayout();
            this.tC_Control.SuspendLayout();
            this.tP_CameraCon.SuspendLayout();
            this.tP_Settings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gB_Paths.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetSNbutton
            // 
            this.GetSNbutton.Location = new System.Drawing.Point(6, 36);
            this.GetSNbutton.Name = "GetSNbutton";
            this.GetSNbutton.Size = new System.Drawing.Size(75, 23);
            this.GetSNbutton.TabIndex = 0;
            this.GetSNbutton.Text = "GetSN";
            this.GetSNbutton.UseVisualStyleBackColor = true;
            this.GetSNbutton.Click += new System.EventHandler(this.GetSNbuttonClick);
            // 
            // Versionlabel
            // 
            this.Versionlabel.Location = new System.Drawing.Point(6, 14);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(75, 19);
            this.Versionlabel.TabIndex = 1;
            this.Versionlabel.Text = "BootLoader:";
            // 
            // Writebutton
            // 
            this.Writebutton.Location = new System.Drawing.Point(6, 94);
            this.Writebutton.Name = "Writebutton";
            this.Writebutton.Size = new System.Drawing.Size(75, 23);
            this.Writebutton.TabIndex = 5;
            this.Writebutton.Text = "Write";
            this.Writebutton.UseVisualStyleBackColor = true;
            this.Writebutton.Click += new System.EventHandler(this.WritebuttonClick);
            // 
            // Erasebutton
            // 
            this.Erasebutton.Location = new System.Drawing.Point(6, 124);
            this.Erasebutton.Name = "Erasebutton";
            this.Erasebutton.Size = new System.Drawing.Size(75, 23);
            this.Erasebutton.TabIndex = 6;
            this.Erasebutton.Text = "Erase";
            this.Erasebutton.UseVisualStyleBackColor = true;
            this.Erasebutton.Click += new System.EventHandler(this.ErasebuttonClick);
            // 
            // Checksumbutton
            // 
            this.Checksumbutton.Location = new System.Drawing.Point(6, 154);
            this.Checksumbutton.Name = "Checksumbutton";
            this.Checksumbutton.Size = new System.Drawing.Size(75, 23);
            this.Checksumbutton.TabIndex = 7;
            this.Checksumbutton.Text = "Checksum";
            this.Checksumbutton.UseVisualStyleBackColor = true;
            this.Checksumbutton.Click += new System.EventHandler(this.ChecksumbuttonClick);
            // 
            // LoadHexbutton
            // 
            this.LoadHexbutton.Location = new System.Drawing.Point(139, 93);
            this.LoadHexbutton.Name = "LoadHexbutton";
            this.LoadHexbutton.Size = new System.Drawing.Size(75, 23);
            this.LoadHexbutton.TabIndex = 8;
            this.LoadHexbutton.Text = "LoadHex";
            this.LoadHexbutton.UseVisualStyleBackColor = true;
            this.LoadHexbutton.Click += new System.EventHandler(this.LoadHexbuttonClick);
            // 
            // Activatebutton
            // 
            this.Activatebutton.Location = new System.Drawing.Point(139, 124);
            this.Activatebutton.Name = "Activatebutton";
            this.Activatebutton.Size = new System.Drawing.Size(75, 23);
            this.Activatebutton.TabIndex = 9;
            this.Activatebutton.Text = "Activate";
            this.Activatebutton.UseVisualStyleBackColor = true;
            this.Activatebutton.Click += new System.EventHandler(this.ActivatebuttonClick);
            // 
            // DeActivatebutton
            // 
            this.DeActivatebutton.Location = new System.Drawing.Point(139, 153);
            this.DeActivatebutton.Name = "DeActivatebutton";
            this.DeActivatebutton.Size = new System.Drawing.Size(75, 23);
            this.DeActivatebutton.TabIndex = 10;
            this.DeActivatebutton.Text = "DeActivate";
            this.DeActivatebutton.UseVisualStyleBackColor = true;
            this.DeActivatebutton.Click += new System.EventHandler(this.DeActivatebuttonClick);
            // 
            // Gobutton
            // 
            this.Gobutton.Location = new System.Drawing.Point(245, 94);
            this.Gobutton.Name = "Gobutton";
            this.Gobutton.Size = new System.Drawing.Size(75, 82);
            this.Gobutton.TabIndex = 11;
            this.Gobutton.Text = "GO";
            this.Gobutton.UseVisualStyleBackColor = true;
            this.Gobutton.Click += new System.EventHandler(this.GobuttonClick);
            // 
            // Speedlabel
            // 
            this.Speedlabel.Location = new System.Drawing.Point(34, 198);
            this.Speedlabel.Name = "Speedlabel";
            this.Speedlabel.Size = new System.Drawing.Size(47, 23);
            this.Speedlabel.TabIndex = 12;
            this.Speedlabel.Text = "Speed";
            // 
            // LoadSpeedlabel
            // 
            this.LoadSpeedlabel.Location = new System.Drawing.Point(139, 198);
            this.LoadSpeedlabel.Name = "LoadSpeedlabel";
            this.LoadSpeedlabel.Size = new System.Drawing.Size(75, 23);
            this.LoadSpeedlabel.TabIndex = 13;
            this.LoadSpeedlabel.Text = "Load Speed";
            // 
            // SpeedcomboBox
            // 
            this.SpeedcomboBox.FormattingEnabled = true;
            this.SpeedcomboBox.Location = new System.Drawing.Point(6, 224);
            this.SpeedcomboBox.Name = "SpeedcomboBox";
            this.SpeedcomboBox.Size = new System.Drawing.Size(90, 21);
            this.SpeedcomboBox.TabIndex = 14;
            // 
            // LoadSpeedcomboBox
            // 
            this.LoadSpeedcomboBox.FormattingEnabled = true;
            this.LoadSpeedcomboBox.Location = new System.Drawing.Point(114, 223);
            this.LoadSpeedcomboBox.Name = "LoadSpeedcomboBox";
            this.LoadSpeedcomboBox.Size = new System.Drawing.Size(100, 21);
            this.LoadSpeedcomboBox.TabIndex = 15;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Hex files|*.hex";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Title = "Open Firmware File";
            // 
            // Portlabel
            // 
            this.Portlabel.Location = new System.Drawing.Point(268, 198);
            this.Portlabel.Name = "Portlabel";
            this.Portlabel.Size = new System.Drawing.Size(31, 13);
            this.Portlabel.TabIndex = 16;
            this.Portlabel.Text = "Port";
            // 
            // PortcomboBox
            // 
            this.PortcomboBox.FormattingEnabled = true;
            this.PortcomboBox.Location = new System.Drawing.Point(245, 223);
            this.PortcomboBox.Name = "PortcomboBox";
            this.PortcomboBox.Size = new System.Drawing.Size(75, 21);
            this.PortcomboBox.TabIndex = 17;
            // 
            // Portbutton
            // 
            this.Portbutton.Location = new System.Drawing.Point(245, 35);
            this.Portbutton.Name = "Portbutton";
            this.Portbutton.Size = new System.Drawing.Size(75, 23);
            this.Portbutton.TabIndex = 18;
            this.Portbutton.Text = "Open Port";
            this.Portbutton.UseVisualStyleBackColor = true;
            this.Portbutton.Click += new System.EventHandler(this.PortbuttonClick);
            // 
            // LogtextBox
            // 
            this.LogtextBox.Location = new System.Drawing.Point(5, 273);
            this.LogtextBox.Multiline = true;
            this.LogtextBox.Name = "LogtextBox";
            this.LogtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogtextBox.Size = new System.Drawing.Size(1157, 218);
            this.LogtextBox.TabIndex = 20;
            this.LogtextBox.WordWrap = false;
            // 
            // Loglabel
            // 
            this.Loglabel.Location = new System.Drawing.Point(6, 248);
            this.Loglabel.Name = "Loglabel";
            this.Loglabel.Size = new System.Drawing.Size(43, 22);
            this.Loglabel.TabIndex = 21;
            this.Loglabel.Text = "Log";
            // 
            // ClearLogbutton
            // 
            this.ClearLogbutton.Location = new System.Drawing.Point(356, 221);
            this.ClearLogbutton.Name = "ClearLogbutton";
            this.ClearLogbutton.Size = new System.Drawing.Size(75, 23);
            this.ClearLogbutton.TabIndex = 22;
            this.ClearLogbutton.Text = "Clear Log";
            this.ClearLogbutton.UseVisualStyleBackColor = true;
            this.ClearLogbutton.Click += new System.EventHandler(this.ClearLogbuttonClick);
            // 
            // Versiontext
            // 
            this.Versiontext.Location = new System.Drawing.Point(100, 14);
            this.Versiontext.Name = "Versiontext";
            this.Versiontext.Size = new System.Drawing.Size(100, 15);
            this.Versiontext.TabIndex = 23;
            this.Versiontext.Text = "version";
            // 
            // SNtext
            // 
            this.SNtext.Location = new System.Drawing.Point(100, 40);
            this.SNtext.Name = "SNtext";
            this.SNtext.Size = new System.Drawing.Size(100, 19);
            this.SNtext.TabIndex = 24;
            this.SNtext.Text = "serial_no";
            // 
            // CamNoUpDown
            // 
            this.CamNoUpDown.AllowDrop = true;
            this.CamNoUpDown.InterceptArrowKeys = false;
            this.CamNoUpDown.Location = new System.Drawing.Point(365, 38);
            this.CamNoUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CamNoUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CamNoUpDown.Name = "CamNoUpDown";
            this.CamNoUpDown.Size = new System.Drawing.Size(66, 20);
            this.CamNoUpDown.TabIndex = 25;
            this.CamNoUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CamNolabel
            // 
            this.CamNolabel.Location = new System.Drawing.Point(365, 14);
            this.CamNolabel.Name = "CamNolabel";
            this.CamNolabel.Size = new System.Drawing.Size(52, 18);
            this.CamNolabel.TabIndex = 26;
            this.CamNolabel.Text = "Camera";
            // 
            // Abortbutton
            // 
            this.Abortbutton.Location = new System.Drawing.Point(356, 94);
            this.Abortbutton.Name = "Abortbutton";
            this.Abortbutton.Size = new System.Drawing.Size(75, 42);
            this.Abortbutton.TabIndex = 27;
            this.Abortbutton.Text = "Abort";
            this.Abortbutton.UseVisualStyleBackColor = true;
            this.Abortbutton.Click += new System.EventHandler(this.AbortbuttonClick);
            // 
            // ResetMemorybutton
            // 
            this.ResetMemorybutton.Location = new System.Drawing.Point(356, 143);
            this.ResetMemorybutton.Name = "ResetMemorybutton";
            this.ResetMemorybutton.Size = new System.Drawing.Size(75, 33);
            this.ResetMemorybutton.TabIndex = 28;
            this.ResetMemorybutton.Text = "reset mem";
            this.ResetMemorybutton.UseVisualStyleBackColor = true;
            this.ResetMemorybutton.Click += new System.EventHandler(this.ResetMemorybuttonClick);
            // 
            // tC_Main
            // 
            this.tC_Main.Controls.Add(this.camControl);
            this.tC_Main.Controls.Add(this.tabPage1);
            this.tC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_Main.Location = new System.Drawing.Point(0, 24);
            this.tC_Main.Name = "tC_Main";
            this.tC_Main.SelectedIndex = 0;
            this.tC_Main.Size = new System.Drawing.Size(1659, 905);
            this.tC_Main.TabIndex = 29;
            // 
            // camControl
            // 
            this.camControl.Controls.Add(this.tC_Control);
            this.camControl.Location = new System.Drawing.Point(4, 22);
            this.camControl.Name = "camControl";
            this.camControl.Padding = new System.Windows.Forms.Padding(3);
            this.camControl.Size = new System.Drawing.Size(1651, 879);
            this.camControl.TabIndex = 1;
            this.camControl.Text = "Control";
            this.camControl.UseVisualStyleBackColor = true;
            // 
            // tC_Control
            // 
            this.tC_Control.Controls.Add(this.tP_CameraCon);
            this.tC_Control.Controls.Add(this.tP_Settings);
            this.tC_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_Control.Location = new System.Drawing.Point(3, 3);
            this.tC_Control.Name = "tC_Control";
            this.tC_Control.SelectedIndex = 0;
            this.tC_Control.Size = new System.Drawing.Size(1645, 873);
            this.tC_Control.TabIndex = 6;
            // 
            // tP_CameraCon
            // 
            this.tP_CameraCon.Controls.Add(this.l_Version);
            this.tP_CameraCon.Location = new System.Drawing.Point(4, 22);
            this.tP_CameraCon.Name = "tP_CameraCon";
            this.tP_CameraCon.Padding = new System.Windows.Forms.Padding(3);
            this.tP_CameraCon.Size = new System.Drawing.Size(1637, 847);
            this.tP_CameraCon.TabIndex = 0;
            this.tP_CameraCon.Text = "Camera Control";
            this.tP_CameraCon.UseVisualStyleBackColor = true;
            // 
            // l_Version
            // 
            this.l_Version.AutoSize = true;
            this.l_Version.Location = new System.Drawing.Point(1539, 858);
            this.l_Version.Name = "l_Version";
            this.l_Version.Size = new System.Drawing.Size(48, 13);
            this.l_Version.TabIndex = 41;
            this.l_Version.Text = "Version: ";
            // 
            // tP_Settings
            // 
            this.tP_Settings.Controls.Add(this.groupBox2);
            this.tP_Settings.Controls.Add(this.groupBox1);
            this.tP_Settings.Controls.Add(this.gB_Paths);
            this.tP_Settings.Controls.Add(this.b_Settings_Default);
            this.tP_Settings.Controls.Add(this.b_Settings_Apply);
            this.tP_Settings.Location = new System.Drawing.Point(4, 22);
            this.tP_Settings.Name = "tP_Settings";
            this.tP_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Settings.Size = new System.Drawing.Size(1637, 871);
            this.tP_Settings.TabIndex = 1;
            this.tP_Settings.Text = "Settings";
            this.tP_Settings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.l_Other);
            this.groupBox2.Controls.Add(this.check_Other_AutoPlay);
            this.groupBox2.Controls.Add(this.check_Not_Config);
            this.groupBox2.Controls.Add(this.check_Not_Subnet);
            this.groupBox2.Controls.Add(this.l_Notifs);
            this.groupBox2.Location = new System.Drawing.Point(885, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 194);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // l_Other
            // 
            this.l_Other.AutoSize = true;
            this.l_Other.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Other.Location = new System.Drawing.Point(9, 95);
            this.l_Other.Name = "l_Other";
            this.l_Other.Size = new System.Drawing.Size(126, 20);
            this.l_Other.TabIndex = 31;
            this.l_Other.Text = "Other Settings";
            // 
            // check_Other_AutoPlay
            // 
            this.check_Other_AutoPlay.Location = new System.Drawing.Point(13, 125);
            this.check_Other_AutoPlay.Name = "check_Other_AutoPlay";
            this.check_Other_AutoPlay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_AutoPlay.Size = new System.Drawing.Size(174, 17);
            this.check_Other_AutoPlay.TabIndex = 30;
            this.check_Other_AutoPlay.Text = "Autoplay Videos on Launch";
            this.check_Other_AutoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Other_AutoPlay.UseVisualStyleBackColor = true;
            this.check_Other_AutoPlay.CheckedChanged += new System.EventHandler(this.check_Other_AutoPlay_CheckChanged);
            // 
            // check_Not_Config
            // 
            this.check_Not_Config.Location = new System.Drawing.Point(13, 72);
            this.check_Not_Config.Name = "check_Not_Config";
            this.check_Not_Config.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Not_Config.Size = new System.Drawing.Size(174, 17);
            this.check_Not_Config.TabIndex = 29;
            this.check_Not_Config.Text = "Hide Bad Config Notification";
            this.check_Not_Config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Not_Config.UseVisualStyleBackColor = true;
            this.check_Not_Config.CheckedChanged += new System.EventHandler(this.check_Not_Config_CheckedChanged);
            // 
            // check_Not_Subnet
            // 
            this.check_Not_Subnet.Location = new System.Drawing.Point(13, 47);
            this.check_Not_Subnet.Name = "check_Not_Subnet";
            this.check_Not_Subnet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Not_Subnet.Size = new System.Drawing.Size(174, 17);
            this.check_Not_Subnet.TabIndex = 0;
            this.check_Not_Subnet.Text = "Hide Subnet Notification";
            this.check_Not_Subnet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Not_Subnet.UseVisualStyleBackColor = true;
            this.check_Not_Subnet.CheckedChanged += new System.EventHandler(this.check_Not_Subnet_CheckedChanged);
            // 
            // l_Notifs
            // 
            this.l_Notifs.AutoSize = true;
            this.l_Notifs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Notifs.Location = new System.Drawing.Point(9, 16);
            this.l_Notifs.Name = "l_Notifs";
            this.l_Notifs.Size = new System.Drawing.Size(109, 20);
            this.l_Notifs.TabIndex = 12;
            this.l_Notifs.Text = "Notifications";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cB_Rec_Quality);
            this.groupBox1.Controls.Add(this.l_Rec_Quality);
            this.groupBox1.Controls.Add(this.tB_Rec_scFileN);
            this.groupBox1.Controls.Add(this.l_Rec_sCFileN);
            this.groupBox1.Controls.Add(this.cB_Rec_FPS);
            this.groupBox1.Controls.Add(this.tB_Rec_vFileN);
            this.groupBox1.Controls.Add(this.l_Rec_vFileN);
            this.groupBox1.Controls.Add(this.l_Rec);
            this.groupBox1.Controls.Add(this.l_Rec_FPS);
            this.groupBox1.Location = new System.Drawing.Point(451, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 194);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // cB_Rec_Quality
            // 
            this.cB_Rec_Quality.FormattingEnabled = true;
            this.cB_Rec_Quality.Items.AddRange(new object[] {
            "50",
            "70",
            "100"});
            this.cB_Rec_Quality.Location = new System.Drawing.Point(126, 69);
            this.cB_Rec_Quality.Name = "cB_Rec_Quality";
            this.cB_Rec_Quality.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_Quality.TabIndex = 26;
            this.cB_Rec_Quality.TextChanged += new System.EventHandler(this.cB_Rec_Quality_TextChanged);
            // 
            // l_Rec_Quality
            // 
            this.l_Rec_Quality.AutoSize = true;
            this.l_Rec_Quality.Location = new System.Drawing.Point(11, 72);
            this.l_Rec_Quality.Name = "l_Rec_Quality";
            this.l_Rec_Quality.Size = new System.Drawing.Size(72, 13);
            this.l_Rec_Quality.TabIndex = 25;
            this.l_Rec_Quality.Text = "Quality(1-100)";
            // 
            // tB_Rec_scFileN
            // 
            this.tB_Rec_scFileN.Enabled = false;
            this.tB_Rec_scFileN.Location = new System.Drawing.Point(126, 126);
            this.tB_Rec_scFileN.Name = "tB_Rec_scFileN";
            this.tB_Rec_scFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_scFileN.TabIndex = 24;
            this.tB_Rec_scFileN.TextChanged += new System.EventHandler(this.tB_Rec_sCFileN_TextChanged);
            // 
            // l_Rec_sCFileN
            // 
            this.l_Rec_sCFileN.AutoSize = true;
            this.l_Rec_sCFileN.Location = new System.Drawing.Point(11, 129);
            this.l_Rec_sCFileN.Name = "l_Rec_sCFileN";
            this.l_Rec_sCFileN.Size = new System.Drawing.Size(111, 13);
            this.l_Rec_sCFileN.TabIndex = 23;
            this.l_Rec_sCFileN.Text = "Screenshot File Name";
            // 
            // cB_Rec_FPS
            // 
            this.cB_Rec_FPS.FormattingEnabled = true;
            this.cB_Rec_FPS.Items.AddRange(new object[] {
            "15",
            "24",
            "30",
            "45",
            "60"});
            this.cB_Rec_FPS.Location = new System.Drawing.Point(126, 42);
            this.cB_Rec_FPS.Name = "cB_Rec_FPS";
            this.cB_Rec_FPS.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_FPS.TabIndex = 16;
            this.cB_Rec_FPS.TextChanged += new System.EventHandler(this.cB_Rec_FPS_TextChanged);
            // 
            // tB_Rec_vFileN
            // 
            this.tB_Rec_vFileN.Enabled = false;
            this.tB_Rec_vFileN.Location = new System.Drawing.Point(126, 97);
            this.tB_Rec_vFileN.Name = "tB_Rec_vFileN";
            this.tB_Rec_vFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_vFileN.TabIndex = 22;
            this.tB_Rec_vFileN.TextChanged += new System.EventHandler(this.tB_Rec_vFileN_TextChanged);
            // 
            // l_Rec_vFileN
            // 
            this.l_Rec_vFileN.AutoSize = true;
            this.l_Rec_vFileN.Location = new System.Drawing.Point(11, 100);
            this.l_Rec_vFileN.Name = "l_Rec_vFileN";
            this.l_Rec_vFileN.Size = new System.Drawing.Size(84, 13);
            this.l_Rec_vFileN.TabIndex = 21;
            this.l_Rec_vFileN.Text = "Video File Name";
            // 
            // l_Rec
            // 
            this.l_Rec.AutoSize = true;
            this.l_Rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Rec.Location = new System.Drawing.Point(9, 16);
            this.l_Rec.Name = "l_Rec";
            this.l_Rec.Size = new System.Drawing.Size(91, 20);
            this.l_Rec.TabIndex = 12;
            this.l_Rec.Text = "Recording";
            // 
            // l_Rec_FPS
            // 
            this.l_Rec_FPS.AutoSize = true;
            this.l_Rec_FPS.Location = new System.Drawing.Point(10, 47);
            this.l_Rec_FPS.Name = "l_Rec_FPS";
            this.l_Rec_FPS.Size = new System.Drawing.Size(54, 13);
            this.l_Rec_FPS.TabIndex = 2;
            this.l_Rec_FPS.Text = "Framerate";
            // 
            // gB_Paths
            // 
            this.gB_Paths.Controls.Add(this.label1);
            this.gB_Paths.Controls.Add(this.check_Paths_Manual);
            this.gB_Paths.Controls.Add(this.l_Paths_sCCheck);
            this.gB_Paths.Controls.Add(this.l_Paths_vCheck);
            this.gB_Paths.Controls.Add(this.b_Paths_vBrowse);
            this.gB_Paths.Controls.Add(this.tB_Paths_vFolder);
            this.gB_Paths.Controls.Add(this.l_Paths_vFolder);
            this.gB_Paths.Controls.Add(this.tB_Paths_sCFolder);
            this.gB_Paths.Controls.Add(this.b_Paths_sCBrowse);
            this.gB_Paths.Controls.Add(this.l_Paths);
            this.gB_Paths.Controls.Add(this.l_Paths_sCFolder);
            this.gB_Paths.Location = new System.Drawing.Point(17, 6);
            this.gB_Paths.Name = "gB_Paths";
            this.gB_Paths.Size = new System.Drawing.Size(428, 194);
            this.gB_Paths.TabIndex = 27;
            this.gB_Paths.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Automatic paths are Documents/SSUtility/Saved/[CAMERA IP]";
            // 
            // check_Paths_Manual
            // 
            this.check_Paths_Manual.Checked = true;
            this.check_Paths_Manual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Paths_Manual.Location = new System.Drawing.Point(13, 45);
            this.check_Paths_Manual.Name = "check_Paths_Manual";
            this.check_Paths_Manual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Paths_Manual.Size = new System.Drawing.Size(119, 21);
            this.check_Paths_Manual.TabIndex = 32;
            this.check_Paths_Manual.Text = "Automatic Paths";
            this.check_Paths_Manual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Paths_Manual.UseVisualStyleBackColor = true;
            this.check_Paths_Manual.CheckedChanged += new System.EventHandler(this.check_Paths_Manual_CheckedChanged);
            // 
            // l_Paths_sCCheck
            // 
            this.l_Paths_sCCheck.AutoSize = true;
            this.l_Paths_sCCheck.Location = new System.Drawing.Point(380, 80);
            this.l_Paths_sCCheck.Name = "l_Paths_sCCheck";
            this.l_Paths_sCCheck.Size = new System.Drawing.Size(0, 13);
            this.l_Paths_sCCheck.TabIndex = 16;
            // 
            // l_Paths_vCheck
            // 
            this.l_Paths_vCheck.AutoSize = true;
            this.l_Paths_vCheck.Location = new System.Drawing.Point(380, 113);
            this.l_Paths_vCheck.Name = "l_Paths_vCheck";
            this.l_Paths_vCheck.Size = new System.Drawing.Size(0, 13);
            this.l_Paths_vCheck.TabIndex = 20;
            // 
            // b_Paths_vBrowse
            // 
            this.b_Paths_vBrowse.Enabled = false;
            this.b_Paths_vBrowse.Location = new System.Drawing.Point(313, 108);
            this.b_Paths_vBrowse.Name = "b_Paths_vBrowse";
            this.b_Paths_vBrowse.Size = new System.Drawing.Size(61, 22);
            this.b_Paths_vBrowse.TabIndex = 19;
            this.b_Paths_vBrowse.Text = "Browse";
            this.b_Paths_vBrowse.UseVisualStyleBackColor = true;
            this.b_Paths_vBrowse.Click += new System.EventHandler(this.b_Paths_vBrowse_Click);
            // 
            // tB_Paths_vFolder
            // 
            this.tB_Paths_vFolder.Enabled = false;
            this.tB_Paths_vFolder.Location = new System.Drawing.Point(119, 110);
            this.tB_Paths_vFolder.Name = "tB_Paths_vFolder";
            this.tB_Paths_vFolder.Size = new System.Drawing.Size(188, 20);
            this.tB_Paths_vFolder.TabIndex = 18;
            this.tB_Paths_vFolder.TextChanged += new System.EventHandler(this.OnFinishedTypingVFolder);
            // 
            // l_Paths_vFolder
            // 
            this.l_Paths_vFolder.AutoSize = true;
            this.l_Paths_vFolder.Location = new System.Drawing.Point(12, 113);
            this.l_Paths_vFolder.Name = "l_Paths_vFolder";
            this.l_Paths_vFolder.Size = new System.Drawing.Size(101, 13);
            this.l_Paths_vFolder.TabIndex = 17;
            this.l_Paths_vFolder.Text = "Video Output Folder";
            // 
            // tB_Paths_sCFolder
            // 
            this.tB_Paths_sCFolder.Enabled = false;
            this.tB_Paths_sCFolder.Location = new System.Drawing.Point(119, 77);
            this.tB_Paths_sCFolder.Name = "tB_Paths_sCFolder";
            this.tB_Paths_sCFolder.Size = new System.Drawing.Size(188, 20);
            this.tB_Paths_sCFolder.TabIndex = 16;
            this.tB_Paths_sCFolder.TextChanged += new System.EventHandler(this.OnFinishedTypingScFolder);
            // 
            // b_Paths_sCBrowse
            // 
            this.b_Paths_sCBrowse.Enabled = false;
            this.b_Paths_sCBrowse.Location = new System.Drawing.Point(313, 75);
            this.b_Paths_sCBrowse.Name = "b_Paths_sCBrowse";
            this.b_Paths_sCBrowse.Size = new System.Drawing.Size(61, 22);
            this.b_Paths_sCBrowse.TabIndex = 13;
            this.b_Paths_sCBrowse.Text = "Browse";
            this.b_Paths_sCBrowse.UseVisualStyleBackColor = true;
            this.b_Paths_sCBrowse.Click += new System.EventHandler(this.b_Paths_sCBrowse_Click);
            // 
            // l_Paths
            // 
            this.l_Paths.AutoSize = true;
            this.l_Paths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Paths.Location = new System.Drawing.Point(9, 16);
            this.l_Paths.Name = "l_Paths";
            this.l_Paths.Size = new System.Drawing.Size(55, 20);
            this.l_Paths.TabIndex = 12;
            this.l_Paths.Text = "Paths";
            // 
            // l_Paths_sCFolder
            // 
            this.l_Paths_sCFolder.AutoSize = true;
            this.l_Paths_sCFolder.Location = new System.Drawing.Point(12, 80);
            this.l_Paths_sCFolder.Name = "l_Paths_sCFolder";
            this.l_Paths_sCFolder.Size = new System.Drawing.Size(93, 13);
            this.l_Paths_sCFolder.TabIndex = 2;
            this.l_Paths_sCFolder.Text = "Screenshot Folder";
            // 
            // b_Settings_Default
            // 
            this.b_Settings_Default.Location = new System.Drawing.Point(1156, 206);
            this.b_Settings_Default.Name = "b_Settings_Default";
            this.b_Settings_Default.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Default.TabIndex = 14;
            this.b_Settings_Default.Text = "Default All";
            this.b_Settings_Default.UseVisualStyleBackColor = true;
            this.b_Settings_Default.Click += new System.EventHandler(this.b_Settings_Default_Click);
            // 
            // b_Settings_Apply
            // 
            this.b_Settings_Apply.Location = new System.Drawing.Point(1237, 206);
            this.b_Settings_Apply.Name = "b_Settings_Apply";
            this.b_Settings_Apply.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Apply.TabIndex = 15;
            this.b_Settings_Apply.Text = "Save All";
            this.b_Settings_Apply.UseVisualStyleBackColor = true;
            this.b_Settings_Apply.Click += new System.EventHandler(this.b_Settings_Apply_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Versionlabel);
            this.tabPage1.Controls.Add(this.ResetMemorybutton);
            this.tabPage1.Controls.Add(this.GetSNbutton);
            this.tabPage1.Controls.Add(this.Abortbutton);
            this.tabPage1.Controls.Add(this.Writebutton);
            this.tabPage1.Controls.Add(this.CamNolabel);
            this.tabPage1.Controls.Add(this.Erasebutton);
            this.tabPage1.Controls.Add(this.CamNoUpDown);
            this.tabPage1.Controls.Add(this.Checksumbutton);
            this.tabPage1.Controls.Add(this.SNtext);
            this.tabPage1.Controls.Add(this.LoadHexbutton);
            this.tabPage1.Controls.Add(this.Versiontext);
            this.tabPage1.Controls.Add(this.Activatebutton);
            this.tabPage1.Controls.Add(this.ClearLogbutton);
            this.tabPage1.Controls.Add(this.DeActivatebutton);
            this.tabPage1.Controls.Add(this.Loglabel);
            this.tabPage1.Controls.Add(this.Gobutton);
            this.tabPage1.Controls.Add(this.LogtextBox);
            this.tabPage1.Controls.Add(this.Speedlabel);
            this.tabPage1.Controls.Add(this.LoadSpeedlabel);
            this.tabPage1.Controls.Add(this.Portbutton);
            this.tabPage1.Controls.Add(this.SpeedcomboBox);
            this.tabPage1.Controls.Add(this.PortcomboBox);
            this.tabPage1.Controls.Add(this.LoadSpeedcomboBox);
            this.tabPage1.Controls.Add(this.Portlabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1651, 903);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Firmware Upgrade";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1022);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1924, 39);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(140, 34);
            this.toolStripStatusLabel1.Text = "  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 34);
            this.toolStripStatusLabel2.Text = "  ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(80, 34);
            this.toolStripStatusLabel3.Text = "  ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(50, 34);
            this.toolStripStatusLabel4.Text = "  ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(200, 34);
            this.toolStripStatusLabel5.Text = "  ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(1339, 34);
            this.toolStripStatusLabel6.Spring = true;
            this.toolStripStatusLabel6.Text = "  ";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowToolStripMenuItem,
            this.finalTestModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1659, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detachedPlayerToolStripMenuItem,
            this.pelcoDScriptingToolStripMenuItem,
            this.responseLogToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.liteModeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // finalTestModeToolStripMenuItem
            // 
            this.finalTestModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.finalTestModeToolStripMenuItem.Name = "finalTestModeToolStripMenuItem";
            this.finalTestModeToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.finalTestModeToolStripMenuItem.Text = "Final Test Mode";
            // 
            // detachedPlayerToolStripMenuItem
            // 
            this.detachedPlayerToolStripMenuItem.Name = "detachedPlayerToolStripMenuItem";
            this.detachedPlayerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detachedPlayerToolStripMenuItem.Text = "Detached Player";
            // 
            // pelcoDScriptingToolStripMenuItem
            // 
            this.pelcoDScriptingToolStripMenuItem.Name = "pelcoDScriptingToolStripMenuItem";
            this.pelcoDScriptingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pelcoDScriptingToolStripMenuItem.Text = "Pelco D Scripting";
            // 
            // responseLogToolStripMenuItem
            // 
            this.responseLogToolStripMenuItem.Name = "responseLogToolStripMenuItem";
            this.responseLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.responseLogToolStripMenuItem.Text = "Response Log";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // liteModeToolStripMenuItem
            // 
            this.liteModeToolStripMenuItem.Name = "liteModeToolStripMenuItem";
            this.liteModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.liteModeToolStripMenuItem.Text = "Lite Mode";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1659, 929);
            this.Controls.Add(this.tC_Main);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SSUtility V2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CamNoUpDown)).EndInit();
            this.tC_Main.ResumeLayout(false);
            this.camControl.ResumeLayout(false);
            this.tC_Control.ResumeLayout(false);
            this.tP_CameraCon.ResumeLayout(false);
            this.tP_CameraCon.PerformLayout();
            this.tP_Settings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gB_Paths.ResumeLayout(false);
            this.gB_Paths.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button ResetMemorybutton;
		private System.Windows.Forms.Button Abortbutton;
		private System.Windows.Forms.Label CamNolabel;
		private System.Windows.Forms.NumericUpDown CamNoUpDown;
		private System.Windows.Forms.Label SNtext;
		private System.Windows.Forms.Label Versiontext;
		private System.Windows.Forms.Button ClearLogbutton;
		private System.Windows.Forms.Label Loglabel;
		private System.Windows.Forms.TextBox LogtextBox;
		private System.Windows.Forms.Button Portbutton;
		private System.Windows.Forms.ComboBox PortcomboBox;
		private System.Windows.Forms.Label Portlabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.ComboBox LoadSpeedcomboBox;
		private System.Windows.Forms.ComboBox SpeedcomboBox;
		private System.Windows.Forms.Label LoadSpeedlabel;
		private System.Windows.Forms.Label Speedlabel;
		private System.Windows.Forms.Button Gobutton;
		private System.Windows.Forms.Button DeActivatebutton;
		private System.Windows.Forms.Button Activatebutton;
		private System.Windows.Forms.Button LoadHexbutton;
		private System.Windows.Forms.Button Checksumbutton;
		private System.Windows.Forms.Button Erasebutton;
		private System.Windows.Forms.Button Writebutton;
		private System.Windows.Forms.Label Versionlabel;
		private System.Windows.Forms.Button GetSNbutton;



        #region Firmware Stuff
        public static byte Address;
        public static byte CheckSum;
        public static byte Command1, Command2, Data1, Data2;
        //private readonly byte STX = 0xFF;
        public int camno = 1;   // Default camera number (1 for now)
        public bool camisthere = false; // True if camera has replied to SSCP query
        public int waitval = 0; // Wait n millisecs before sending next protocol packet
        public int waitresponseval = 0; // Wait for n bytes of response packet
        public int readtimeout = 1000;  // Standard read timeout of 1000 millisecs (see #Port.ReadTimeout:n)
        public int[] rawbuf = new int[80];  // Buffer for current protocol line
        public int rawlen;  // Length of current protocol line
        public long whencmdsent;    // Stopwatch value when last command was sent
        public int replylen = 0;    // Length of last serial port reply (in bytes)
        public byte[] replybuf = new byte[128]; // Buffer for serial port replies
        public string replyerrmsg;  // Last reply error
        public string hexfilefilename;  // Filename of current hex file
        public string hexfilesafefilename;  // Safe filename of current hex file
        public string hexfilepath;  // Path to current hex file
        public string hexfilefilter;    // Filter for current hex file types
        public string[] hexfilelines;   // Content of hex file
        public int hexfileformat = 1;   // Expected is encrypted (1); alternative is unencrypted (0)
        public int hexfilestartaddress = 0x8000;    // Expected start address
        public int hexfileendaddress = 0x8000;  // Expected much bigger than this
        public int hexfilelength = 0;   // Expected non-zero
        public int hexfilenblocks = 0;  // Number of blocks in hex file
        public int currentblock = 0;    // Current block being transferred
        public uint hexfiledatachecksum = 0;    // Gets checksum of hex file data (assuming unencrypted)
        public string hexfilechecksum;
        public bool loadit = false; // Firmware upload is not running
        public bool pauseit = false;     //Pause upload
        public bool EscapeWasPressed = false;   // Whether Escape was pressed during firmware upload
        public Stopwatch mystopwatch1;  //Run Script Stopwatch
        public Stopwatch mystopwatch2;  //Pause Script Sto
        public string cts;      //CurrentTimeStamp
        public bool debugSSCP = false;
        public bool isactive = false;   // true if we have an active main firmware, false if not
                                        //string oldroline; 		// Temp buffer saver
        static readonly uint[] crc_table = new uint[256] {
            0x00, 0x25, 0x4A, 0x6F, 0x94, 0xB1, 0xDE, 0xFB,
            0x0D, 0x28, 0x47, 0x62, 0x99, 0xBC, 0xD3, 0xF6,
            0x1A, 0x3F, 0x50, 0x75, 0x8E, 0xAB, 0xC4, 0xE1,
            0x17, 0x32, 0x5D, 0x78, 0x83, 0xA6, 0xC9, 0xEC,
            0x34, 0x11, 0x7E, 0x5B, 0xA0, 0x85, 0xEA, 0xCF,
            0x39, 0x1C, 0x73, 0x56, 0xAD, 0x88, 0xE7, 0xC2,
            0x2E, 0x0B, 0x64, 0x41, 0xBA, 0x9F, 0xF0, 0xD5,
            0x23, 0x06, 0x69, 0x4C, 0xB7, 0x92, 0xFD, 0xD8,
            0x68, 0x4D, 0x22, 0x07, 0xFC, 0xD9, 0xB6, 0x93,
            0x65, 0x40, 0x2F, 0x0A, 0xF1, 0xD4, 0xBB, 0x9E,
            0x72, 0x57, 0x38, 0x1D, 0xE6, 0xC3, 0xAC, 0x89,
            0x7F, 0x5A, 0x35, 0x10, 0xEB, 0xCE, 0xA1, 0x84,
            0x5C, 0x79, 0x16, 0x33, 0xC8, 0xED, 0x82, 0xA7,
            0x51, 0x74, 0x1B, 0x3E, 0xC5, 0xE0, 0x8F, 0xAA,
            0x46, 0x63, 0x0C, 0x29, 0xD2, 0xF7, 0x98, 0xBD,
            0x4B, 0x6E, 0x01, 0x24, 0xDF, 0xFA, 0x95, 0xB0,
            0xD0, 0xF5, 0x9A, 0xBF, 0x44, 0x61, 0x0E, 0x2B,
            0xDD, 0xF8, 0x97, 0xB2, 0x49, 0x6C, 0x03, 0x26,
            0xCA, 0xEF, 0x80, 0xA5, 0x5E, 0x7B, 0x14, 0x31,
            0xC7, 0xE2, 0x8D, 0xA8, 0x53, 0x76, 0x19, 0x3C,
            0xE4, 0xC1, 0xAE, 0x8B, 0x70, 0x55, 0x3A, 0x1F,
            0xE9, 0xCC, 0xA3, 0x86, 0x7D, 0x58, 0x37, 0x12,
            0xFE, 0xDB, 0xB4, 0x91, 0x6A, 0x4F, 0x20, 0x05,
            0xF3, 0xD6, 0xB9, 0x9C, 0x67, 0x42, 0x2D, 0x08,
            0xB8, 0x9D, 0xF2, 0xD7, 0x2C, 0x09, 0x66, 0x43,
            0xB5, 0x90, 0xFF, 0xDA, 0x21, 0x04, 0x6B, 0x4E,
            0xA2, 0x87, 0xE8, 0xCD, 0x36, 0x13, 0x7C, 0x59,
            0xAF, 0x8A, 0xE5, 0xC0, 0x3B, 0x1E, 0x71, 0x54,
            0x8C, 0xA9, 0xC6, 0xE3, 0x18, 0x3D, 0x52, 0x77,
            0x81, 0xA4, 0xCB, 0xEE, 0x15, 0x30, 0x5F, 0x7A,
            0x96, 0xB3, 0xDC, 0xF9, 0x02, 0x27, 0x48, 0x6D,
            0x9B, 0xBE, 0xD1, 0xF4, 0x0F, 0x2A, 0x45, 0x60
            };



        public MainForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            // Catch MainForm closing event to close Serial Port if it is Open
            this.FormClosing += new FormClosingEventHandler(MainForm_Closing);


            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            string[] stdspeeds = { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            string[] loadspeeds = { "9600", "19200", "38400", "57600", "115200", "230400" };


            int i;
            for (i = 0; i < 7; i++) {
                this.SpeedcomboBox.Items.Add(stdspeeds[i]);
            }
            this.SpeedcomboBox.SelectedIndex = 2;   // Default contact speed is 9600
            for (i = 0; i < 6; i++) {
                this.LoadSpeedcomboBox.Items.Add(loadspeeds[i]);
            }
            this.LoadSpeedcomboBox.SelectedIndex = 3;   // Default load speed is 57600
                                                        //foreach (String portName in System.IO.Ports.SerialPort.GetPortNames()) {
                                                        //	this.PortcomboBox.Items.Add(portName);
                                                        //}
                                                        //this.PortcomboBox.SelectedIndex = 0;
            mystopwatch1 = System.Diagnostics.Stopwatch.StartNew(); // Get stopwatch object and init and start
            StartupStuff();
        } // end of MainForm()

        private void MainForm_Closing(Object sender, FormClosingEventArgs e) {
            if (this.serialPort1.IsOpen) {
                this.serialPort1.Close();
                //System.Windows.Forms.MessageBox.Show("Closed Serial Port on Application Finish");
            }
        } // end of MainForm_Closing()

        private int SSCPChecksum(byte[] cmd, int len) {
            int i;
            int rv = 0;
            if (len < 3 || cmd[0] != 0x02 || cmd[len - 1] != 0x03)
                return rv;
            for (i = 1; i < len - 1; i++) {
                rv = (int)crc_table[rv ^ (int)cmd[i]];
            }
            return rv;
        } // end of SSCPChecksum()

        private int Char2Hex(char c) {
            int rv;
            rv = "0123456789ABCDEF".IndexOf(Char.ToUpper(c));
            return rv;
        }

        private int HexByte(char c1, char c2) {
            int rv;
            rv = Char2Hex(c1) * 16 + Char2Hex(c2);
            return rv;
        } // end of HexByte()

        private int SSCPHexValue(int start, int length) {
            int rv = 0;
            int i;
            length += start;
            for (i = start; i < length; i++)
                rv = (rv << 4) + Char2Hex((char)replybuf[i]);
            return rv;
        } // end of SSCPHexValue()

        private void escapeProtocol() {
            var tmpbytearray = new byte[] { Convert.ToByte(27) };
            this.serialPort1.Write(tmpbytearray, 0, 1); // Write Esc
            System.Threading.Thread.Sleep(1000);
        } // end of escapeProtocol()

        private int sendSSCP(byte cmd1, byte cmd2, string data, bool expectreply, int discardto, int sendto, int ackto, int replyto) {
            string tpkt;
            string tcmd1;
            string tcksum;
            int tpktlen;
            int ms2send;
            int rv = -1;    // Default result is Fail code
            int i;
            int j;
            int timeout = 0;    // variable timeout wherever needed
            int retries = 5;    // 5 retries
            int ret = 0;
            int tnb = 0;
            int nb = 0;
            long tt;        // Total ms that this stage took
            if (cmd1 != 0)
                tcmd1 = cmd1.ToString("X2");
            else
                tcmd1 = "";
            camno = (int)this.CamNoUpDown.Value;    // Remember current camera number
                                                    // *** 27-Apr-2018 We now implement 300ms timeout and 5 retries
            if (!this.serialPort1.IsOpen)
                return rv;
            // Format SSCP packet and calc checksum
            tpkt = "\x02" + camno.ToString("X2") + tcmd1 + cmd2.ToString("X2") + data + "\x03";
            byte[] btpkt = System.Text.Encoding.UTF8.GetBytes(tpkt);
            tpktlen = btpkt.Length + 2; // How many bytes in packet
            tcksum = SSCPChecksum(btpkt, btpkt.Length).ToString("X2");
            ms2send = (tpktlen * 9600) / this.serialPort1.BaudRate + 1; // Estimate how many ms to send packet
                                                                        // For first attempt just discard for 5 ms; for remaining tries discard for discardto ms
            timeout = 5;
            for (ret = 0; ret < retries; ret++) {
                // Discard anything in port receive buffer for up to discardto ms
                if (debugSSCP) {
                    nb = ret + 1;
                    this.LogtextBox.AppendText("SSCP attempt " + nb.ToString() + Environment.NewLine);
                }
                this.mystopwatch1.Restart();
                tnb = 0;    // How many bytes were discarded
                while (this.mystopwatch1.ElapsedMilliseconds < timeout) {
                    nb = this.serialPort1.BytesToRead;
                    if (nb > 0) {
                        tnb = tnb + nb; // Count bytes discarded
                        this.serialPort1.ReadExisting();
                    }
                }
                this.mystopwatch1.Stop();
                if (debugSSCP && tnb > 0) {
                    this.LogtextBox.AppendText(ret.ToString() + ": SSCP discarded " + tnb.ToString() + " bytes" + Environment.NewLine);
                }
                // Write SSCP packet
                this.serialPort1.Write(tpkt);
                // Show SSCP sent packet in Log pane
                if (debugSSCP) {
                    this.LogtextBox.AppendText("SSCP sent ");
                    for (i = 0; i < btpkt.Length; i++) {
                        j = btpkt[i];
                        if (j < 33 || j > 126)
                            this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
                        else
                            this.LogtextBox.AppendText(((char)j).ToString());
                    }
                    //this.serialPort1.Write(SSCPChecksum(btpkt,btpkt.Length).ToString("X2"));
                    this.LogtextBox.AppendText(tcksum + Environment.NewLine);
                }
                this.serialPort1.Write(tcksum);
                // Wait for ms2send ms for packet to go
                this.mystopwatch1.Restart();
                while (this.mystopwatch1.ElapsedMilliseconds < ms2send) {
                }
                tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
                this.mystopwatch1.Stop();
                this.mystopwatch1.Restart();
                while (this.mystopwatch1.ElapsedMilliseconds < sendto) {
                    if (this.serialPort1.BytesToWrite < 2)
                        break;
                }
                tt = tt + this.mystopwatch1.ElapsedMilliseconds;    // How long it took overall
                this.mystopwatch1.Stop();
                nb = this.serialPort1.BytesToWrite;
                if (nb > 1) { // Failed to write packet within allowed time
                    if (debugSSCP) {
                        this.LogtextBox.AppendText("Write not finished after " + sendto.ToString() + "ms; " + nb.ToString() + " bytes to go" + Environment.NewLine);
                    }
                    continue;   // Failed to write the packet within sendto ms
                } else {
                    if (debugSSCP) {
                        this.LogtextBox.AppendText("Write took " + tt.ToString() + "ms" + Environment.NewLine);
                    }
                }
                // Now we need to wait for a reply (maybe)
                // If we do not get a protocol packet we should get Ack or Nak
                replylen = 0;   // Clear reply buffer
                replyerrmsg = null; // Clear reply error message
                                    //while (replylen < 1) {
                                    //	try {
                                    //		replylen = this.serialPort1.Read(replybuf,0,1);
                                    //	}
                                    //	catch (TimeoutException ex)
                                    //	{
                                    //		replyerrmsg = ex.Message;
                                    //		break;
                                    //	}
                                    //} // end of while waiting for 1st reply char
                                    // We now use a stopwatch and expect a byte to return within ackto ms
                this.mystopwatch1.Restart();
                replybuf[0] = 0;    // Init 1st byte of replybuf to 0 meaning no reply
                while (this.mystopwatch1.ElapsedMilliseconds < ackto) {
                    if (this.serialPort1.BytesToRead > 0) {
                        replybuf[0] = (byte)this.serialPort1.ReadByte();
                        replylen = 1;
                        break;
                    }
                }
                tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
                this.mystopwatch1.Stop();
                // Fake reply
                //if (cmd2==0)
                //{ // Fake Boot Loader version response
                //	tpkt = "\x02" + camno.ToString("X2") + "FF00no boot loader" + "\x03" + "AB";
                //}
                //else
                //{ // Fake Serial Number response
                //	tpkt = "\x02" + camno.ToString("X2") + "FF" + cmd2.ToString("X2") + "01023456" + "\x03" + "CD";
                //}
                //replybuf = System.Text.Encoding.UTF8.GetBytes(tpkt);
                //replylen = replybuf.Length;
                if (debugSSCP) { // We either have nothing or 1 byte
                    this.LogtextBox.AppendText("SSCP rcvd ");
                    if (replylen < 1)
                        this.LogtextBox.AppendText("nothing after " + tt.ToString() + "ms" + Environment.NewLine);
                    else {
                        j = replybuf[0];
                        if (j < 33 || j > 126)
                            this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
                        else
                            this.LogtextBox.AppendText(((char)j).ToString());
                        this.LogtextBox.AppendText(" after " + tt.ToString() + "ms" + Environment.NewLine);
                    }
                }
                //return 0;
                // Did we get a reply or did we time out??
                //if (replylen < 1)	return rv;	// Failed to get reply
                if (replylen < 1)
                    continue; // Failed to get reply
                rv = replybuf[0];
                if (rv == 2) {
                    rv = 0; // No Ack or Nak but got reply packet - leave Stx at start
                } else {
                    replylen = 0;   // Lose Ack or Nak from buffer but we will return its code
                }
                // If we saw a Stx we try to read a reply packet (whether or not we were expecting one
                if (replylen == 0 && !expectreply)
                    return rv;
                //while (replylen < 128) {
                //	try {
                //		replylen = replylen + this.serialPort1.Read(replybuf,replylen,128-replylen);
                //		// We now call a halt if we have Etx as 3rd last char in replybuf[]
                //		if (replylen>7 && replybuf[replylen-3]==0x03)	break;
                //	}
                //	catch (TimeoutException ex)
                //	{
                //		replyerrmsg = ex.Message;
                //		break;
                //	}
                //}
                // We now use a stopwatch and expect a reply to return within replyto ms
                this.mystopwatch1.Restart();
                while (this.mystopwatch1.ElapsedMilliseconds < replyto) {
                    if (this.serialPort1.BytesToRead > 0) {
                        replybuf[replylen] = (byte)this.serialPort1.ReadByte(); // Read 1 byte at a time
                        replylen++;
                        // We now call a halt if we have Etx as 3rd last char in replybuf[]
                        if (replylen > 7 && replybuf[replylen - 3] == 0x03)
                            break;
                    }
                }
                tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
                this.mystopwatch1.Stop();
                if (debugSSCP) {
                    this.LogtextBox.AppendText("SSCP rcvd ");
                    if (replylen < 1)
                        this.LogtextBox.AppendText("nothing after " + tt.ToString() + "ms" + Environment.NewLine);
                    else {
                        for (i = 0; i < replylen; i++) {
                            j = replybuf[i];
                            if (j < 33 || j > 126)
                                this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
                            else
                                this.LogtextBox.AppendText(((char)j).ToString());
                        }
                        this.LogtextBox.AppendText(Environment.NewLine);
                        this.LogtextBox.AppendText(" Reply took " + tt.ToString() + "ms" + Environment.NewLine);
                    }
                }
                if (replylen < 8 || replybuf[replylen - 3] != 0x03)
                    rv = -1;
                if (rv == 6 || (expectreply && rv == 0))
                    return rv;
                timeout = discardto;    // We will use this timeout for discard next time
            } // end of for (ret=0;... trying up to 5 times
            return rv;
        } // end of sendSSCP()

        private int ClassifyFWLine(string roline) { // Return line type byte value (0-3 or 9) or -1 if not recognised
                                                    //string sline;
            int rv = -1;
            int datalen;
            int linetype;
            if (String.IsNullOrWhiteSpace(roline))
                return (rv); // Blank line
            if (roline[0] != ':')
                return (rv);      // Bad start
            if (roline.Length < 11)
                return (rv);    // Too short
            datalen = HexByte(roline[1], roline[2]);
            linetype = HexByte(roline[7], roline[8]);
            //if (roline.Length != (datalen + datalen + 11))	return(rv);	// Wrong length
            rv = linetype;
            return (rv);    // Return line type
        } // end of ClassifyFWLine()

        private string gethexfilelinedata(int addr) { // Given code address of start of line, return substring of code line that contains code
                                                      // If we reach a non-code line at end of file, return an empty string
            int n;  // This will be the index in hexfilelines[] of the relevant code line
            string s;   // This will get the return substring
            n = (addr >> 4) + (addr >> 16) - 0x800;
            if (hexfilelines[n].Substring(0, 3) == ":10")
                s = hexfilelines[n].Substring(9, 32);
            else
                s = "";
            return s;
        } // end of gethexfilelinedata()

        private bool WriteFromBuffer(int addr, int length, int destaddr) {
            string s;
            int rv = -1;
            int i = 0;
            bool brv;
            statusStrip1.Show();
            // Keep buttons refreshed
            Application.DoEvents();
            while (i < length && !EscapeWasPressed) { // Transfer another 16 bytes of the current 4096 byte block
                                                      // Build next 16-byte line
                s = gethexfilelinedata(addr + i);
                if (s.Length == 0) { // Reached end of file - fake that last block was sent OK
                                     // Update status bar with progress
                    this.toolStripStatusLabel5.Text = "Off end of file";
                    this.statusStrip1.Refresh();
                    i = length;
                    rv = 0;
                    break;
                }
                s = destaddr.ToString("X4") + "10" + gethexfilelinedata(addr + i);
                // Update status bar with progress
                this.toolStripStatusLabel3.Text = i.ToString() + "/" + length.ToString();
                this.statusStrip1.Refresh();
                rv = sendSSCP((byte)0x7F, (byte)2, s, true, 300, 40, 50, 100);
                i += 16;
                destaddr += 16;
                // Break out if not Ack or just reply
                if (rv != 0 && rv != 6)
                    break;
                // Keep buttons refreshed
                Application.DoEvents();
            } // end of while (i<length && ...
              // Now, if Abort button was pressed, just say Upload aborted
            if (EscapeWasPressed) {
                this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + "Upload aborted." + Environment.NewLine);
                brv = false;
            } else if (i >= length && (rv == 0 || rv == 6)) {
                this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + i.ToString() + " bytes transferred." + Environment.NewLine);
                brv = true;
            } else {
                this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + "Failed after " + i.ToString() + " bytes of " + length.ToString() + Environment.NewLine);
                brv = false;
            }
            this.toolStripStatusLabel3.Text = "";
            this.statusStrip1.Refresh();
            return brv;
        } // end of WriteFromBuffer()

        private int WriteToFlash(int addr, int length) {
            string s;
            int rv;
            this.LogtextBox.AppendText("Flashed at " + addr.ToString("X5"));
            addr = addr >> 3;
            s = addr.ToString("X4") + length.ToString("X4");
            // Send Write To Flash message
            rv = sendSSCP((byte)0x7F, (byte)3, s, true, 100, 20, 500, 500);
            if ((rv == 0 || rv == 6) && replylen > 9)
                rv = HexByte((char)replybuf[7], (char)replybuf[8]);
            else
                rv = -1;
            this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
            return rv;
        } // end of WriteToFlash()

        private int EraseFlash(int addr, int length) {
            string s;
            int rv;
            length = addr + length;
            this.LogtextBox.AppendText("Erased " + addr.ToString("X5") + " to " + length.ToString("X5"));
            addr = addr >> 3;
            length = length >> 3;
            s = addr.ToString("X4") + length.ToString("X4");
            // Send Erase Flash message
            rv = sendSSCP((byte)0x7F, (byte)4, s, true, 100, 20, 50, 1000);
            if ((rv == 0 || rv == 6) && replylen > 9)
                rv = HexByte((char)replybuf[7], (char)replybuf[8]);
            else
                rv = -1;
            this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
            isactive = false;
            return rv;
        } // end of EraseFlash()

        private int ActivateFlash(int length) {
            string s;
            int rv;
            this.LogtextBox.AppendText("Activated " + length.ToString("X5"));
            length = length >> 3;
            s = length.ToString("X4");
            // Send Activate Flash message
            //rv = sendSSCP((byte)0x7F,(byte)5,s,true,100,20,1000,20);
            // It seems that BootLoader does not send a reply, only Ack
            rv = sendSSCP((byte)0x7F, (byte)5, s, false, 100, 20, 20, 0);
            //if ((rv==0 || rv==6) && replylen>9)
            //	rv = HexByte((char)replybuf[7],(char)replybuf[8]);
            if (rv != 0 && rv != 6)
                rv = -1;
            this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
            if (rv < 0)
                isactive = false;
            else
                isactive = true;
            return rv;
        } // end of ActivateFlash()

        private int ReadChecksum(int addr, int length) {
            string s;
            int rv;
            rv = addr + length;
            this.LogtextBox.AppendText("Checksum of " + addr.ToString("X5") + " to " + rv.ToString("X5"));
            addr = addr >> 3;
            length = length >> 3;
            s = addr.ToString("X4") + length.ToString("X4");
            // Send Do Checksum message - takes about 250 ms to get reply back for 112 block firmware
            rv = sendSSCP((byte)0x7F, (byte)7, s, true, 100, 20, 50, 300);
            if ((rv == 0 || rv == 6) && replylen > 15)
                rv = SSCPHexValue(7, 8);    // Get value of hex number at replybuf[7] 8 bytes long
            else
                rv = -1;
            this.LogtextBox.AppendText(", result=0x" + rv.ToString("X8") + Environment.NewLine);
            return rv;
        } // end of ReadChecksum()

        private void AnalyseFirmwareFile() { // Parse the firmware file contents in Textbox1 and setup stats vars
            int lastaddr = 0;
            int last64kblock = 0;
            int lno = 0;
            int val;
            int i;
            // Firmware file lines will be in one of the following formats:
            // Each line has ':' 2-dig-length 4-dig-addr 2-dig-type length_2-dig-bytes 2-dig-checksum
            // Type 00 content line 16 bytes at addr 8000 unencrypted (starts 18F09FE5)
            // :1080000018F09FE518F09FE518F09FE518F09FE540
            // Type 02 block address line 2 bytes new block at 1000 (i.e. 10000 on)
            // :020000021000EC
            // Type 03 start address line 4 bytes SA is 00008000
            // :040000030000800079
            // Type 01 end of file line 0 bytes
            // :00000001FF
            //
            // Encrypted files have first data line like so: (not starting 18F09FE5)
            // :108000004BE81483E262890370E503D7FB3A96419B
            // But Type 02 records are the same
            // At the end of the file, the Type 03 start address line is replaced by
            // Type 09 checksum line 4 bytes Checksum is 02A9C148
            // :0400000902A9C1483F
            // And Type 01 end of file line is the same
            // Start address is implied to be 00008000

            hexfiledatachecksum = 0;
            foreach (String roline in hexfilelines) {
                lno++;
                val = ClassifyFWLine(roline);
                if (val == 0) { // Data line
                    if (lno == 1 && roline.StartsWith(":1080000018F09FE5"))
                        hexfileformat = 0;  // Unencrypted
                    lastaddr = HexByte(roline[3], roline[4]) * 256 + HexByte(roline[5], roline[6]); // Last addr value seen on data line
                    for (i = 9; i < 41; i = i + 2)
                        hexfiledatachecksum = hexfiledatachecksum + (uint)HexByte(roline[i], roline[i + 1]);
                } else if (val == 2) { // Next 64K block line
                    last64kblock = Char2Hex(roline[9]); // Last 64K block number seen
                } else if (val == 9) {
                    hexfilechecksum = roline.Substring(9, 8);
                } else { // Anything else is bad or record at end of file
                    break;
                }
            } // end of for each line in textBox1
              //System.Windows.Forms.MessageBox.Show("Stopped Setup lno: " + lno.ToString() + " Val: " + val.ToString());
              // Update useful info vars from values gleaned from file
            hexfilestartaddress = 0x8000;
            hexfileendaddress = last64kblock * 65536 + lastaddr + 16;
            hexfilelength = hexfileendaddress - hexfilestartaddress;
        } // end of AnalyseFirmwareFile()
        #endregion

        void GetSNbuttonClick(object sender, System.EventArgs e)
		{
			int i;
			this.Versiontext.Text = "";
			this.SNtext.Text = "";
			// Clear any No Hope message
			this.toolStripStatusLabel5.Text = "";
			this.statusStrip1.Refresh();
			// Keep buttons refreshed
			Application.DoEvents();
			if (!this.serialPort1.IsOpen)
			{
				PortbuttonClick(sender,e);	// Open port
			}
			if (this.serialPort1.IsOpen) 
			{ // Port now OUGHT to be open - if not, the Open failed
				// First send Esc and wait for a sec
				escapeProtocol();
				// Now send SSCP Read BootLoader Version
				// If camera is switching protocols we may lose 1st query so be prepared to send it again
				// If camera replies it may not Ack because this is a query! BootLoader always Acks queries
				int rv = sendSSCP(0x7F,0,"",true,300,20,20,50);
				if (rv < 0)
				{
					rv = sendSSCP(0x7F,0,"",true,300,20,20,50);	// Repeat the query because we got no answer to the first one
				}
				// Analyse what happened. If no answer we failed. If answer was Nak we failed.
				// If answer was Ack or zero, refresh Versiontext
				if (rv==0 || rv==6)
				{
					char[] content = new char[replylen-10];
					for (i=0; i<content.Length; i++)	content[i] = (char)(replybuf[i+7]);
					camisthere = true;	// Camera has replied
					//System.Array.Copy(replybuf,7,content,0,replylen-10);
					this.Versiontext.Text = new string (content);
					rv = sendSSCP(0x7F,40,"",true,300,20,20,100);	// Now query for Serial No
					if (rv==0 || rv==6)
					{
						char[] content2 = new char[replylen-10];
						for (i=0; i<content2.Length; i++)	content2[i] = (char)(replybuf[i+7]);
						//System.Array.Copy(replybuf,7,content2,0,replylen-10);
						this.SNtext.Text = new string (content2);
					}
					else
					{
						this.SNtext.Text = "NA";
					}
				}
				else
				{
					this.Versiontext.Text = "NA";
					this.SNtext.Text = "NA";
					this.toolStripStatusLabel5.Text = "No hope!! Camera not replying!!";
					this.statusStrip1.Refresh();
				}
			}
		} // end of GetSNbuttonClick()
		
		void ChangePortSpeed(string newspeed)
		{
			// We need the Port Open, and then to ask to change port speed
			if (!this.serialPort1.IsOpen)	this.serialPort1.Open();
			sendSSCP(0x7F,6,newspeed,false,300,20,100,0);	// Ask other end to change speed
			if (this.serialPort1.IsOpen)	this.serialPort1.Close();
			// We now need to wait around for a bit to let the speed change
			System.Threading.Thread.Sleep(1000);	// We now sleep for 1 sec
			this.serialPort1.BaudRate = System.Convert.ToInt32(newspeed);
			this.serialPort1.Open();
		} // end of ChangePortSpeed()
		
		void PortbuttonClick(object sender, System.EventArgs e)
		{
			string sline;
			if (this.serialPort1.IsOpen) 
			{
				this.serialPort1.Close();
				this.Portbutton.Text = "Open Port";
				statusStrip1.Text = "Port Closed";
			}
			else 
			{
                if (PortcomboBox.Text == "" || this.PortcomboBox.SelectedItem == null) {
                    MessageBox.Show("Port invalid!");
                    return;
                }
				sline = "8N1";
				this.serialPort1 = new System.IO.Ports.SerialPort(this.PortcomboBox.SelectedItem.ToString());
				this.serialPort1.BaudRate = System.Convert.ToInt32(this.SpeedcomboBox.SelectedItem.ToString());
				this.serialPort1.DataBits = System.Convert.ToInt32(sline.Substring(0,1));
				switch (sline[1]) 
				{
					case 'N':	this.serialPort1.Parity = System.IO.Ports.Parity.None; break;
					case 'E':	this.serialPort1.Parity = System.IO.Ports.Parity.Even; break;
					case 'O':	this.serialPort1.Parity = System.IO.Ports.Parity.Odd; break;
				}
				switch (sline[2]) 
				{
					case '1':	this.serialPort1.StopBits = System.IO.Ports.StopBits.One; break;
					case '2':	this.serialPort1.StopBits = System.IO.Ports.StopBits.Two; break;
				}
				this.serialPort1.ReadTimeout=1000;	// 1 sec read timeout
				this.serialPort1.ReadBufferSize=128;	// 128 byte Read buffer
				try 
				{
					this.serialPort1.Open();
					this.Portbutton.Text = "Close Port";
					this.toolStripStatusLabel2.Text = "Port Opened";
					this.statusStrip1.Refresh();
				}
				catch (System.SystemException ex)
				{
					//System.Windows.Forms.MessageBox.Show("Port Open Fail: " + ex.Message);
					this.LogtextBox.AppendText("Port Open Fail: " + ex.Message + Environment.NewLine);
				}
			}
		} // end of PortbuttonClick()

		void WritebuttonClick(object sender, System.EventArgs e)
		{
			if (hexfilesafefilename != null && hexfilelength>0)
			{
				if (!camisthere)
				{
					GetSNbuttonClick(sender,e);	// GetSN checks that camera is replying
				}
				bool trywriting = true;
				// Alert if we do not have correct BootLoader
				if (camisthere && hexfilenblocks>=112 && this.Versiontext.Text.StartsWith("V1.013"))
				{
					trywriting = false;
					if (hexfilenblocks>112 && (this.Versiontext.Text.Length<7 || this.Versiontext.Text[6]!='y'))
						this.LogtextBox.AppendText("*** Needs BootLoader v1.013y to load ***" + System.Environment.NewLine);
					else if (this.Versiontext.Text.Length<7)
						this.LogtextBox.AppendText("*** Needs BootLoader v1.013a or x or y to load ***" + System.Environment.NewLine);
					else
						trywriting = true;
				}
				if (camisthere && trywriting)
				{ // Camera is there - it is worth trying the write
					int i;
					int n;
					int r;
					int c;
					int tnb = (hexfilelength + 4095)/4096;	// Total number of 4096 byte blocks
					int retries = 0;
					bool bw = false;	// Buffer written successfully
					EscapeWasPressed = false;	// No Abort yet
					this.Abortbutton.Text = "Abort";
					// Say if this is an excrypted file or not
					// Boot Loader echoes back same setting
					sendSSCP(0x7F,8,(hexfilechecksum==null?"00":"01"),true,300,20,20,50);
					i = hexfilestartaddress;
					n = 4096;
					r = 0;	// Current result flag
					c = 0;	// Current block
					// Show busy dialogue window
					while (i<hexfileendaddress && r==0 && !EscapeWasPressed)
					{
						c++;	// Bump current block number
						// Maintain global currentblock
						currentblock = c;
						this.toolStripStatusLabel5.Text = "Writing... block " + c.ToString() + " of " + tnb.ToString();
						this.statusStrip1.Refresh();
						bw = false;	// Start a new buffer write attempt
						retries = 0;	// No retries yet
						while (!bw && retries<10 && !EscapeWasPressed)
						{
							bw = WriteFromBuffer(i,n,0);
							retries++;	// One more retry
						} // end of while (!bw && ...
						if (bw)		r = WriteToFlash(i,n);
						else		r = -1;
						i += n;		// Bump address on to next block
					} // end of while (i<hexfileendaddress && ...
					// Hide busy dialogue window
					if (EscapeWasPressed)
					{ // Clear Aborting message
						this.Abortbutton.Text = "Abort";
						// Keep buttons refreshed
						Application.DoEvents();
						this.toolStripStatusLabel1.Text = "";
						EscapeWasPressed = false;
					}
					//this.toolStripStatusLabel6.Text = "";
					if (r == 0)
						this.toolStripStatusLabel5.Text = "";
					else
						this.toolStripStatusLabel5.Text = "Failed on block" + c.ToString() + " of " + tnb.ToString();
					statusStrip1.Refresh();
				} // end of camera is there
				else
				{
					this.LogtextBox.AppendText("No hope!! Camera is not replying!!" + Environment.NewLine);
					toolStripStatusLabel5.Text = "No hope!! Camera is not replying!!";
					statusStrip1.Refresh();
				}
			}
			else
			{
				this.LogtextBox.AppendText("Load .hex file first!" + Environment.NewLine);
				toolStripStatusLabel5.Text = "Load .hex file first!";
				statusStrip1.Refresh();
			}
		} // end of WritebuttonClick()
		
		void ErasebuttonClick(object sender, System.EventArgs e)
		{
			if (hexfilesafefilename != null && hexfilelength>0)
			{
				EraseFlash(hexfilestartaddress,hexfilelength);
			}
			else
			{
				this.LogtextBox.AppendText("Load .hex file first!" + Environment.NewLine);
				toolStripStatusLabel5.Text = "Load .hex file first!";
				statusStrip1.Refresh();
			}
		} // end of ErasebuttonClick()
		
		void ChecksumbuttonClick(object sender, System.EventArgs e)
		{
			if (hexfilesafefilename != null && hexfilelength>0)
			{
				ReadChecksum(hexfilestartaddress,hexfilelength);
			}
			else
			{
				toolStripStatusLabel5.Text = "Load .hex file first!";
				statusStrip1.Refresh();
			}
		} // end of ChecksumbuttonClick()
		
		void LoadHexbuttonClick(object sender, System.EventArgs e)
		{
			if (hexfilepath != null)	this.openFileDialog1.InitialDirectory = hexfilepath;
			if (hexfilesafefilename != null)	this.openFileDialog1.FileName = hexfilesafefilename;
			if (hexfilefilter != null)	this.openFileDialog1.Filter = hexfilefilter;
			// Clear any last filename from status label6
			toolStripStatusLabel6.Text = "";
			statusStrip1.Refresh();
			if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				//hexfilepath = this.openFileDialog1.InitialDirectory;
				//System.Windows.Forms.MessageBox.Show("Initial Dir: <" + hexfilepath + ">");
				hexfilefilename = this.openFileDialog1.FileName;
				//System.Windows.Forms.MessageBox.Show("File: <" + hexfilefilename + ">");
				hexfilefilter = this.openFileDialog1.Filter;
				//System.Windows.Forms.MessageBox.Show("Filter: <" + hexfilefilter + ">");
				hexfilesafefilename = this.openFileDialog1.SafeFileName;
				//System.Windows.Forms.MessageBox.Show("SafeFN: <" + hexfilesafefilename + ">");
				int pathlen = hexfilefilename.Length - hexfilesafefilename.Length;
				hexfilepath = hexfilefilename.Substring(0,pathlen);
				//System.Windows.Forms.MessageBox.Show("Current Dir: <" + hexfilepath + ">");
				try
				{
					// File.ReadAllLines() will return an array of strings, ones string per line
					// File.ReadAllText() will return a single string containing the whole file
					// Read whole firmware file into array of strings
					hexfilechecksum = null;
					hexfilelines = System.IO.File.ReadAllLines(hexfilefilename);
					// Analyse firmware file and populate some handy vars
					AnalyseFirmwareFile();	// In MainForm.cs ???
					// Show summary in Log pane
					this.LogtextBox.AppendText("Loaded " + hexfilesafefilename + System.Environment.NewLine);
					hexfilenblocks = (hexfilelength + 4095)/4096;
					this.LogtextBox.AppendText(" range " + hexfilestartaddress.ToString("X5") + ":" + hexfileendaddress.ToString("X5") + "  size " + hexfilenblocks.ToString() + " blocks" + System.Environment.NewLine);
					// Show checksum
					if (hexfilechecksum!=null)	this.LogtextBox.AppendText(" echecksum " + hexfilechecksum + System.Environment.NewLine);
					else						this.LogtextBox.AppendText(" dchecksum " + hexfiledatachecksum.ToString("X8") + System.Environment.NewLine);
					// Alert if we do not have correct BootLoader
					if (camisthere && hexfilenblocks>=112 && this.Versiontext.Text.StartsWith("V1.013"))
					{
						if (hexfilenblocks>112 && (this.Versiontext.Text.Length<7 || this.Versiontext.Text[6]!='y'))
							this.LogtextBox.AppendText("*** Needs BootLoader V1.013y to load ***" + System.Environment.NewLine);
						else if (this.Versiontext.Text.Length<7)
							this.LogtextBox.AppendText("*** Needs BootLoader V1.013a or x or y to load ***" + System.Environment.NewLine);
					}
					//panel1.Show();
					toolStripStatusLabel5.Text = "";
					toolStripStatusLabel6.Text = hexfilesafefilename;
					statusStrip1.Refresh();
				}
				catch (System.IO.IOException ex)
				{
					//System.Windows.Forms.MessageBox.Show("File Open Fail: " + ex.Message);
					toolStripStatusLabel6.Text = "File Open Fail: " + ex.Message;
					statusStrip1.Refresh();
				}
			} // end of firmware file opened OK
		} // end of LoadHexbuttonClick
		
		void ActivatebuttonClick(object sender, System.EventArgs e)
		{
			if (hexfilesafefilename != null && hexfilelength>0)
			{
				int cs1;
				int cs2;
				cs1 = 1;
				cs1 = ReadChecksum(hexfilestartaddress,hexfilelength);	// Returns int checksum value
				if (hexfilechecksum!=null)
					cs2 = Int32.Parse(hexfilechecksum, System.Globalization.NumberStyles.HexNumber);
				else
					cs2 = (int)hexfiledatachecksum;
				if (cs1 == cs2)
				{
					ActivateFlash(hexfilelength);
					this.LogtextBox.AppendText("Activated" + System.Environment.NewLine);
					toolStripStatusLabel2.Text = "Activated";
					statusStrip1.Refresh();
     				isactive=true;
					//ApdComPort1.Baud=9600;
					//ShowSerial;
				}
				else
				{
					this.LogtextBox.AppendText("Not activated. Checksum mismatch" + System.Environment.NewLine);
					toolStripStatusLabel5.Text = "Not activated. Checksum mismatch";
					isactive = false;
					statusStrip1.Refresh();
				}
			}
			else
			{
				this.LogtextBox.AppendText("Load .hex file first!" + System.Environment.NewLine);
				toolStripStatusLabel5.Text = "Load .hex file first!";
				statusStrip1.Refresh();
			}
		} // end of ActivatebuttonClick()
		
		void DeActivatebuttonClick(object sender, System.EventArgs e)
		{
			// Send Deactivate command (even if no .hex file loaded)
			sendSSCP(0x7F,0x7F,"CDE0CDE0",false,300,20,300,0);
			this.LogtextBox.AppendText("DeActivate request sent" + System.Environment.NewLine);
			toolStripStatusLabel2.Text = "DeActivated";
			statusStrip1.Refresh();
			isactive=false;
		} // end of DeActivatebuttonClick()
		
		void GobuttonClick(object sender, System.EventArgs e)
		{
			loadit = false;
			ClearLogbuttonClick(sender,e);
			if (hexfilesafefilename != null && hexfilelength>0)
			{ // We must have firmware file loaded to press Go
				if (!camisthere)
				{
					GetSNbuttonClick(sender,e);	// GetSN checks that camera is replying
				}
				if (camisthere)
				{ // Camera is there - it is worth proceeding
					bool tryloading = true;
					if (this.Versiontext.Text.Length<1 || this.Versiontext.Text[0] != 'V')
					{ // We are NOT talking to the BootLoader, so deactivate current program
						DeActivatebuttonClick(sender,e);
						System.Threading.Thread.Sleep(2000);	// We now sleep for 2 secs
					}
					// Alert if we do not have correct BootLoader
					if (hexfilenblocks>=112 && (this.Versiontext.Text.Length<1 || this.Versiontext.Text.StartsWith("V1.013")))
					{
						tryloading = false;	// Be pessimistic
						if (hexfilenblocks>112 && (this.Versiontext.Text.Length<7 || this.Versiontext.Text[6]!='y'))
							this.LogtextBox.AppendText("*** Needs BootLoader v1.013y to load ***" + System.Environment.NewLine);
						else if (this.Versiontext.Text.Length<7)
							this.LogtextBox.AppendText("*** Needs BootLoader v1.013a or x or y to load ***" + System.Environment.NewLine);
						else
							tryloading = true;
					}
					// If OK to try loading, proceed
					if (tryloading)
					{
						// Now try to Activate current program, if it matches firmware file that is loaded
						ActivatebuttonClick(sender,e);
						if (!isactive)
						{ // Not got active program - load new one
							ErasebuttonClick(sender,e);
							ChangePortSpeed(this.LoadSpeedcomboBox.SelectedItem.ToString());
							WritebuttonClick(sender,e);
							ChangePortSpeed(this.SpeedcomboBox.SelectedItem.ToString());
							ActivatebuttonClick(sender,e);
						}
					}
				}
				else
				{
					this.LogtextBox.AppendText("No hope!! Camera is not replying!!" + Environment.NewLine);
					toolStripStatusLabel5.Text = "No hope!! Camera is not replying!!";
					statusStrip1.Refresh();
				}
			}
			else
			{
				this.LogtextBox.AppendText("Load .hex file first!" + Environment.NewLine);
				toolStripStatusLabel5.Text = "Load .hex file first!";
				statusStrip1.Refresh();
			}
		} // end of GobuttonClick()
		
		void ClearLogbuttonClick(object sender, System.EventArgs e)
		{
			if (!loadit)
			{
				LogtextBox.Clear();
				toolStripStatusLabel1.Text = "Log Cleared";
				statusStrip1.Refresh();
			} //else System.Windows.Forms.MessageBox.Show("Cannot clear Log whilst running.");
		} // end of ClearLogbuttonClick()

		void AbortbuttonClick(object sender, System.EventArgs e)
		{
			EscapeWasPressed = true;
			this.Abortbutton.Text = "Aborting...";
			toolStripStatusLabel1.Text = "Aborting";
			statusStrip1.Refresh();
		} // end of AbortbuttonClick()

		void ResetMemorybuttonClick(object sender, System.EventArgs e)
		{
			int rv;
			DialogResult result = MessageBox.Show("Reset BatRAM on next reboot? THIS CANNOT BE UNDONE!!","ResetMemoryOnReboot",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				rv = sendSSCP(0x7F,60,"",false,300,20,300,0);
				if (rv != 6)	rv = sendSSCP(0x7F,60,"",false,300,20,300,0);
				if (rv == 6)	this.LogtextBox.AppendText("Memory reset." + Environment.NewLine);
				else			this.LogtextBox.AppendText("Memory reset failed!!" + Environment.NewLine);
			}
		} // end of ResetMemorybuttonClick()

        public TabControl tC_Main;
        public TabPage tabPage1;
        public StatusStrip statusStrip1;
        public ToolStripStatusLabel toolStripStatusLabel2;
        public ToolStripStatusLabel toolStripStatusLabel3;
        public ToolStripStatusLabel toolStripStatusLabel4;
        public ToolStripStatusLabel toolStripStatusLabel5;
        public ToolStripStatusLabel toolStripStatusLabel6;
        public ToolStripStatusLabel toolStripStatusLabel1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public TabPage camControl;
        public TabControl tC_Control;
        public TabPage tP_CameraCon;
        public TabPage tP_Settings;
        public GroupBox groupBox1;
        public ComboBox cB_Rec_Quality;
        public Label l_Rec_Quality;
        public TextBox tB_Rec_scFileN;
        public Label l_Rec_sCFileN;
        public ComboBox cB_Rec_FPS;
        public TextBox tB_Rec_vFileN;
        public Label l_Rec_vFileN;
        public Label l_Rec;
        public Label l_Rec_FPS;
        public Label l_Paths_sCCheck;
        public GroupBox gB_Paths;
        public Label l_Paths_vCheck;
        public Button b_Paths_vBrowse;
        public TextBox tB_Paths_vFolder;
        public Label l_Paths_vFolder;
        public TextBox tB_Paths_sCFolder;
        public Button b_Paths_sCBrowse;
        public Label l_Paths;
        public Label l_Paths_sCFolder;
        public Button b_Settings_Default;
        public Button b_Settings_Apply;
        public GroupBox groupBox2;
        public Label l_Notifs;
        private CheckBox check_Not_Config;
        private CheckBox check_Not_Subnet;
        private Label l_Version;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox check_Other_AutoPlay;
        public Label l_Other;
        private CheckBox check_Paths_Manual;
        public Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem detachedPlayerToolStripMenuItem;
        private ToolStripMenuItem pelcoDScriptingToolStripMenuItem;
        private ToolStripMenuItem responseLogToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem liteModeToolStripMenuItem;
        private ToolStripMenuItem finalTestModeToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
    } // end of partial class MainForm
} // end of namespace SSLUtility2
