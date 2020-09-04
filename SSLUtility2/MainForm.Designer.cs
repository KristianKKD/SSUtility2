/*
 * Created by SharpDevelop.
 * User: Alistair
 * Date: 17/03/2018
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tC_Control = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gB_PlayerR_Extended = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_PlayerR_Adr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tB_PlayerR_Port = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tB_PlayerR_RTSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tB_PlayerR_Username = new System.Windows.Forms.TextBox();
            this.tB_PlayerR_Buffering = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tB_PlayerR_Password = new System.Windows.Forms.TextBox();
            this.cB_PlayerR_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.gB_PlayerR_Simple = new System.Windows.Forms.GroupBox();
            this.tB_PlayerR_SimpleAdr = new System.Windows.Forms.TextBox();
            this.l_PlayerR_SimpleAdr = new System.Windows.Forms.Label();
            this.gB_PlayerL_Simple = new System.Windows.Forms.GroupBox();
            this.tB_PlayerL_SimpleAdr = new System.Windows.Forms.TextBox();
            this.l_PlayerL_SimpleAdr = new System.Windows.Forms.Label();
            this.VLCPlayer_R = new AxAXVLC.AxVLCPlugin2();
            this.checkB_PlayerR_Manual = new System.Windows.Forms.CheckBox();
            this.b_PlayerR_PauseRec = new System.Windows.Forms.Button();
            this.b_PlayerR_StartRec = new System.Windows.Forms.Button();
            this.b_PlayerR_SaveSnap = new System.Windows.Forms.Button();
            this.b_PlayerR_Play = new System.Windows.Forms.Button();
            this.VLCPlayer_L = new AxAXVLC.AxVLCPlugin2();
            this.checkB_PlayerL_Manual = new System.Windows.Forms.CheckBox();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.tB_PTZ_Speed = new System.Windows.Forms.TrackBar();
            this.cB_IPCon_Type = new System.Windows.Forms.ComboBox();
            this.tB_Presets_Number = new System.Windows.Forms.TextBox();
            this.tC_Presets_Default = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.b_Presets_Daylight_Stabilizer = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_WDR = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_Wiper = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_AF = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_ColMono = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_BrightPos = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_BrightNeg = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_ICEPos = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_ICENeg = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_ICE = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_WhiteBlack = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_NUC = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_AF = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.b_Presets_SLG_SteadyGreen = new System.Windows.Forms.Button();
            this.b_Presets_SLG_AllLightsOff = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingRG = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingWhite = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingRed = new System.Windows.Forms.Button();
            this.b_Presets_SLG_SteadyRed = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingGreen = new System.Windows.Forms.Button();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.b_Presets_Peak_SteadyLamp = new System.Windows.Forms.Button();
            this.b_Presets_Peak_StopZoom = new System.Windows.Forms.Button();
            this.b_Presets_Peak_ZoomOut = new System.Windows.Forms.Button();
            this.b_Presets_Peak_ZoomIn = new System.Windows.Forms.Button();
            this.b_Presets_Peak_LampOff = new System.Windows.Forms.Button();
            this.b_Presets_Peak_StrobeLamp = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.b_Presets_Admin_DefaultMen = new System.Windows.Forms.Button();
            this.b_Presets_Admin_DebugToggle = new System.Windows.Forms.Button();
            this.b_Presets_Admin_MechMen = new System.Windows.Forms.Button();
            this.b_Presets_Admin_SetupMen = new System.Windows.Forms.Button();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.b_Presets_CHARM_Aquire = new System.Windows.Forms.Button();
            this.b_Presets_CHARM_Standby = new System.Windows.Forms.Button();
            this.cB_IPCon_KeyboardCon = new System.Windows.Forms.CheckBox();
            this.cB_IPCon_Selected = new System.Windows.Forms.ComboBox();
            this.tB_IPCon_Port = new System.Windows.Forms.TextBox();
            this.tB_IPCon_Adr = new System.Windows.Forms.TextBox();
            this.l_IPCon_KeyControl = new System.Windows.Forms.Label();
            this.l_IPCon_SelectedCam = new System.Windows.Forms.Label();
            this.l_IPCon_Port = new System.Windows.Forms.Label();
            this.l_IPCon_Speed = new System.Windows.Forms.Label();
            this.l_Presets_Number = new System.Windows.Forms.Label();
            this.l_IPCon_ConType = new System.Windows.Forms.Label();
            this.l_IPCon_Adr = new System.Windows.Forms.Label();
            this.l_Presets_Default = new System.Windows.Forms.Label();
            this.l_Presets = new System.Windows.Forms.Label();
            this.l_PTZCon = new System.Windows.Forms.Label();
            this.l_IPCon = new System.Windows.Forms.Label();
            this.b_PlayerL_Detach = new System.Windows.Forms.Button();
            this.b_PlayerL_PauseRec = new System.Windows.Forms.Button();
            this.b_PlayerL_StartRec = new System.Windows.Forms.Button();
            this.b_PlayerL_SaveSnap = new System.Windows.Forms.Button();
            this.b_Presets_Learn = new System.Windows.Forms.Button();
            this.b_Presets_GoTo = new System.Windows.Forms.Button();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            this.b_PlayerL_Play = new System.Windows.Forms.Button();
            this.tP_Settings = new System.Windows.Forms.TabPage();
            this.l_Paths_sCCheck = new System.Windows.Forms.Label();
            this.gB_Paths = new System.Windows.Forms.GroupBox();
            this.tB_Paths_sCFolder = new System.Windows.Forms.TextBox();
            this.b_Settings_Apply = new System.Windows.Forms.Button();
            this.b_Settings_Default = new System.Windows.Forms.Button();
            this.b_Paths_sCBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.l_Paths_sCFolder = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.CamNoUpDown)).BeginInit();
            this.tC_Main.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tC_Control.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gB_PlayerR_Extended.SuspendLayout();
            this.gB_PlayerL_Extended.SuspendLayout();
            this.gB_PlayerR_Simple.SuspendLayout();
            this.gB_PlayerL_Simple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_PTZ_Speed)).BeginInit();
            this.tC_Presets_Default.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tP_Settings.SuspendLayout();
            this.gB_Paths.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.tC_Main.Controls.Add(this.tabPage2);
            this.tC_Main.Controls.Add(this.tabPage1);
            this.tC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_Main.Location = new System.Drawing.Point(0, 0);
            this.tC_Main.Name = "tC_Main";
            this.tC_Main.SelectedIndex = 0;
            this.tC_Main.Size = new System.Drawing.Size(1659, 929);
            this.tC_Main.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tC_Control);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1651, 903);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tC_Control
            // 
            this.tC_Control.Controls.Add(this.tabPage3);
            this.tC_Control.Controls.Add(this.tP_Settings);
            this.tC_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_Control.Location = new System.Drawing.Point(3, 3);
            this.tC_Control.Name = "tC_Control";
            this.tC_Control.SelectedIndex = 0;
            this.tC_Control.Size = new System.Drawing.Size(1645, 897);
            this.tC_Control.TabIndex = 6;
            this.tC_Control.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tC_Control_KeyDown);
            this.tC_Control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tC_Control_KeyUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gB_PlayerR_Extended);
            this.tabPage3.Controls.Add(this.gB_PlayerL_Extended);
            this.tabPage3.Controls.Add(this.gB_PlayerR_Simple);
            this.tabPage3.Controls.Add(this.gB_PlayerL_Simple);
            this.tabPage3.Controls.Add(this.VLCPlayer_R);
            this.tabPage3.Controls.Add(this.checkB_PlayerR_Manual);
            this.tabPage3.Controls.Add(this.b_PlayerR_PauseRec);
            this.tabPage3.Controls.Add(this.b_PlayerR_StartRec);
            this.tabPage3.Controls.Add(this.b_PlayerR_SaveSnap);
            this.tabPage3.Controls.Add(this.b_PlayerR_Play);
            this.tabPage3.Controls.Add(this.VLCPlayer_L);
            this.tabPage3.Controls.Add(this.checkB_PlayerL_Manual);
            this.tabPage3.Controls.Add(this.l_IPCon_Connected);
            this.tabPage3.Controls.Add(this.tB_PTZ_Speed);
            this.tabPage3.Controls.Add(this.cB_IPCon_Type);
            this.tabPage3.Controls.Add(this.tB_Presets_Number);
            this.tabPage3.Controls.Add(this.tC_Presets_Default);
            this.tabPage3.Controls.Add(this.cB_IPCon_KeyboardCon);
            this.tabPage3.Controls.Add(this.cB_IPCon_Selected);
            this.tabPage3.Controls.Add(this.tB_IPCon_Port);
            this.tabPage3.Controls.Add(this.tB_IPCon_Adr);
            this.tabPage3.Controls.Add(this.l_IPCon_KeyControl);
            this.tabPage3.Controls.Add(this.l_IPCon_SelectedCam);
            this.tabPage3.Controls.Add(this.l_IPCon_Port);
            this.tabPage3.Controls.Add(this.l_IPCon_Speed);
            this.tabPage3.Controls.Add(this.l_Presets_Number);
            this.tabPage3.Controls.Add(this.l_IPCon_ConType);
            this.tabPage3.Controls.Add(this.l_IPCon_Adr);
            this.tabPage3.Controls.Add(this.l_Presets_Default);
            this.tabPage3.Controls.Add(this.l_Presets);
            this.tabPage3.Controls.Add(this.l_PTZCon);
            this.tabPage3.Controls.Add(this.l_IPCon);
            this.tabPage3.Controls.Add(this.b_PlayerL_Detach);
            this.tabPage3.Controls.Add(this.b_PlayerL_PauseRec);
            this.tabPage3.Controls.Add(this.b_PlayerL_StartRec);
            this.tabPage3.Controls.Add(this.b_PlayerL_SaveSnap);
            this.tabPage3.Controls.Add(this.b_Presets_Learn);
            this.tabPage3.Controls.Add(this.b_Presets_GoTo);
            this.tabPage3.Controls.Add(this.b_PTZ_Down);
            this.tabPage3.Controls.Add(this.b_PTZ_Up);
            this.tabPage3.Controls.Add(this.b_PTZ_FocusNeg);
            this.tabPage3.Controls.Add(this.b_PTZ_ZoomNeg);
            this.tabPage3.Controls.Add(this.b_PTZ_FocusPos);
            this.tabPage3.Controls.Add(this.b_PTZ_ZoomPos);
            this.tabPage3.Controls.Add(this.b_PTZ_Right);
            this.tabPage3.Controls.Add(this.b_PTZ_Left);
            this.tabPage3.Controls.Add(this.b_PlayerL_Play);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1637, 871);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Camera Control";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gB_PlayerR_Extended
            // 
            this.gB_PlayerR_Extended.Controls.Add(this.label4);
            this.gB_PlayerR_Extended.Controls.Add(this.tB_PlayerR_Adr);
            this.gB_PlayerR_Extended.Controls.Add(this.label5);
            this.gB_PlayerR_Extended.Controls.Add(this.tB_PlayerR_Port);
            this.gB_PlayerR_Extended.Controls.Add(this.label6);
            this.gB_PlayerR_Extended.Controls.Add(this.tB_PlayerR_RTSP);
            this.gB_PlayerR_Extended.Controls.Add(this.label7);
            this.gB_PlayerR_Extended.Controls.Add(this.tB_PlayerR_Username);
            this.gB_PlayerR_Extended.Controls.Add(this.tB_PlayerR_Buffering);
            this.gB_PlayerR_Extended.Controls.Add(this.label8);
            this.gB_PlayerR_Extended.Controls.Add(this.label9);
            this.gB_PlayerR_Extended.Controls.Add(this.tB_PlayerR_Password);
            this.gB_PlayerR_Extended.Controls.Add(this.cB_PlayerR_Type);
            this.gB_PlayerR_Extended.Controls.Add(this.label3);
            this.gB_PlayerR_Extended.Location = new System.Drawing.Point(962, 537);
            this.gB_PlayerR_Extended.Name = "gB_PlayerR_Extended";
            this.gB_PlayerR_Extended.Size = new System.Drawing.Size(313, 239);
            this.gB_PlayerR_Extended.TabIndex = 36;
            this.gB_PlayerR_Extended.TabStop = false;
            this.gB_PlayerR_Extended.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "RTSP String:";
            // 
            // tB_PlayerR_Adr
            // 
            this.tB_PlayerR_Adr.Location = new System.Drawing.Point(89, 41);
            this.tB_PlayerR_Adr.Name = "tB_PlayerR_Adr";
            this.tB_PlayerR_Adr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_Adr.TabIndex = 4;
            this.tB_PlayerR_Adr.Text = "192.168.1.71";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password:";
            // 
            // tB_PlayerR_Port
            // 
            this.tB_PlayerR_Port.Location = new System.Drawing.Point(89, 67);
            this.tB_PlayerR_Port.Name = "tB_PlayerR_Port";
            this.tB_PlayerR_Port.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_Port.TabIndex = 4;
            this.tB_PlayerR_Port.Text = "554";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Port:";
            // 
            // tB_PlayerR_RTSP
            // 
            this.tB_PlayerR_RTSP.Location = new System.Drawing.Point(89, 92);
            this.tB_PlayerR_RTSP.Name = "tB_PlayerR_RTSP";
            this.tB_PlayerR_RTSP.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_RTSP.TabIndex = 4;
            this.tB_PlayerR_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "IP Address:";
            // 
            // tB_PlayerR_Username
            // 
            this.tB_PlayerR_Username.Location = new System.Drawing.Point(89, 144);
            this.tB_PlayerR_Username.Name = "tB_PlayerR_Username";
            this.tB_PlayerR_Username.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_Username.TabIndex = 4;
            this.tB_PlayerR_Username.Text = "admin";
            // 
            // tB_PlayerR_Buffering
            // 
            this.tB_PlayerR_Buffering.Location = new System.Drawing.Point(89, 118);
            this.tB_PlayerR_Buffering.Name = "tB_PlayerR_Buffering";
            this.tB_PlayerR_Buffering.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_Buffering.TabIndex = 4;
            this.tB_PlayerR_Buffering.Text = "200";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Username:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Buffering (ms): ";
            // 
            // tB_PlayerR_Password
            // 
            this.tB_PlayerR_Password.Location = new System.Drawing.Point(89, 170);
            this.tB_PlayerR_Password.Name = "tB_PlayerR_Password";
            this.tB_PlayerR_Password.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_Password.TabIndex = 4;
            this.tB_PlayerR_Password.Text = "admin";
            // 
            // cB_PlayerR_Type
            // 
            this.cB_PlayerR_Type.FormattingEnabled = true;
            this.cB_PlayerR_Type.Items.AddRange(new object[] {
            "IONodes - Daylight",
            "IONodes - Thermal",
            "VIVOTEK",
            "BOSCH"});
            this.cB_PlayerR_Type.Location = new System.Drawing.Point(89, 14);
            this.cB_PlayerR_Type.Name = "cB_PlayerR_Type";
            this.cB_PlayerR_Type.Size = new System.Drawing.Size(214, 21);
            this.cB_PlayerR_Type.TabIndex = 5;
            this.cB_PlayerR_Type.SelectedIndexChanged += new System.EventHandler(this.cB_PlayerR_Type_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Encoder Type:";
            // 
            // gB_PlayerL_Extended
            // 
            this.gB_PlayerL_Extended.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.gB_PlayerL_Extended.Location = new System.Drawing.Point(288, 537);
            this.gB_PlayerL_Extended.Name = "gB_PlayerL_Extended";
            this.gB_PlayerL_Extended.Size = new System.Drawing.Size(313, 239);
            this.gB_PlayerL_Extended.TabIndex = 26;
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
            this.cB_PlayerL_Type.SelectedIndexChanged += new System.EventHandler(this.cB_PlayerL_Type_SelectedIndexChanged);
            // 
            // gB_PlayerR_Simple
            // 
            this.gB_PlayerR_Simple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gB_PlayerR_Simple.Controls.Add(this.tB_PlayerR_SimpleAdr);
            this.gB_PlayerR_Simple.Controls.Add(this.l_PlayerR_SimpleAdr);
            this.gB_PlayerR_Simple.Location = new System.Drawing.Point(962, 537);
            this.gB_PlayerR_Simple.Name = "gB_PlayerR_Simple";
            this.gB_PlayerR_Simple.Size = new System.Drawing.Size(313, 239);
            this.gB_PlayerR_Simple.TabIndex = 40;
            this.gB_PlayerR_Simple.TabStop = false;
            // 
            // tB_PlayerR_SimpleAdr
            // 
            this.tB_PlayerR_SimpleAdr.Location = new System.Drawing.Point(89, 26);
            this.tB_PlayerR_SimpleAdr.Name = "tB_PlayerR_SimpleAdr";
            this.tB_PlayerR_SimpleAdr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerR_SimpleAdr.TabIndex = 28;
            // 
            // l_PlayerR_SimpleAdr
            // 
            this.l_PlayerR_SimpleAdr.AutoSize = true;
            this.l_PlayerR_SimpleAdr.Location = new System.Drawing.Point(3, 27);
            this.l_PlayerR_SimpleAdr.Name = "l_PlayerR_SimpleAdr";
            this.l_PlayerR_SimpleAdr.Size = new System.Drawing.Size(80, 13);
            this.l_PlayerR_SimpleAdr.TabIndex = 27;
            this.l_PlayerR_SimpleAdr.Text = "RTSP Address:";
            // 
            // gB_PlayerL_Simple
            // 
            this.gB_PlayerL_Simple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gB_PlayerL_Simple.Controls.Add(this.tB_PlayerL_SimpleAdr);
            this.gB_PlayerL_Simple.Controls.Add(this.l_PlayerL_SimpleAdr);
            this.gB_PlayerL_Simple.Location = new System.Drawing.Point(288, 537);
            this.gB_PlayerL_Simple.Name = "gB_PlayerL_Simple";
            this.gB_PlayerL_Simple.Size = new System.Drawing.Size(313, 239);
            this.gB_PlayerL_Simple.TabIndex = 39;
            this.gB_PlayerL_Simple.TabStop = false;
            // 
            // tB_PlayerL_SimpleAdr
            // 
            this.tB_PlayerL_SimpleAdr.Location = new System.Drawing.Point(89, 26);
            this.tB_PlayerL_SimpleAdr.Name = "tB_PlayerL_SimpleAdr";
            this.tB_PlayerL_SimpleAdr.Size = new System.Drawing.Size(214, 20);
            this.tB_PlayerL_SimpleAdr.TabIndex = 28;
            // 
            // l_PlayerL_SimpleAdr
            // 
            this.l_PlayerL_SimpleAdr.AutoSize = true;
            this.l_PlayerL_SimpleAdr.Location = new System.Drawing.Point(3, 27);
            this.l_PlayerL_SimpleAdr.Name = "l_PlayerL_SimpleAdr";
            this.l_PlayerL_SimpleAdr.Size = new System.Drawing.Size(80, 13);
            this.l_PlayerL_SimpleAdr.TabIndex = 27;
            this.l_PlayerL_SimpleAdr.Text = "RTSP Address:";
            // 
            // VLCPlayer_R
            // 
            this.VLCPlayer_R.Enabled = true;
            this.VLCPlayer_R.Location = new System.Drawing.Point(962, 19);
            this.VLCPlayer_R.Name = "VLCPlayer_R";
            this.VLCPlayer_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VLCPlayer_R.OcxState")));
            this.VLCPlayer_R.Size = new System.Drawing.Size(639, 512);
            this.VLCPlayer_R.TabIndex = 29;
            // 
            // checkB_PlayerR_Manual
            // 
            this.checkB_PlayerR_Manual.AutoSize = true;
            this.checkB_PlayerR_Manual.Location = new System.Drawing.Point(1281, 547);
            this.checkB_PlayerR_Manual.Name = "checkB_PlayerR_Manual";
            this.checkB_PlayerR_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_PlayerR_Manual.TabIndex = 35;
            this.checkB_PlayerR_Manual.Text = "Extended RTSP Controls";
            this.checkB_PlayerR_Manual.UseVisualStyleBackColor = true;
            this.checkB_PlayerR_Manual.CheckedChanged += new System.EventHandler(this.checkB_PlayerR_Manual_CheckedChanged);
            // 
            // b_PlayerR_PauseRec
            // 
            this.b_PlayerR_PauseRec.Location = new System.Drawing.Point(1281, 644);
            this.b_PlayerR_PauseRec.Name = "b_PlayerR_PauseRec";
            this.b_PlayerR_PauseRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerR_PauseRec.TabIndex = 32;
            this.b_PlayerR_PauseRec.Text = "PAUSE Recording";
            this.b_PlayerR_PauseRec.UseVisualStyleBackColor = true;
            this.b_PlayerR_PauseRec.Click += new System.EventHandler(this.b_PlayerR_PauseRec_Click);
            // 
            // b_PlayerR_StartRec
            // 
            this.b_PlayerR_StartRec.Location = new System.Drawing.Point(1281, 615);
            this.b_PlayerR_StartRec.Name = "b_PlayerR_StartRec";
            this.b_PlayerR_StartRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerR_StartRec.TabIndex = 33;
            this.b_PlayerR_StartRec.Text = "START Recording";
            this.b_PlayerR_StartRec.UseVisualStyleBackColor = true;
            this.b_PlayerR_StartRec.Click += new System.EventHandler(this.b_PlayerR_StartRec_Click);
            // 
            // b_PlayerR_SaveSnap
            // 
            this.b_PlayerR_SaveSnap.Location = new System.Drawing.Point(1281, 576);
            this.b_PlayerR_SaveSnap.Name = "b_PlayerR_SaveSnap";
            this.b_PlayerR_SaveSnap.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerR_SaveSnap.TabIndex = 34;
            this.b_PlayerR_SaveSnap.Text = "Save Snapshot";
            this.b_PlayerR_SaveSnap.UseVisualStyleBackColor = true;
            this.b_PlayerR_SaveSnap.Click += new System.EventHandler(this.b_PlayerR_SaveSnap_Click);
            // 
            // b_PlayerR_Play
            // 
            this.b_PlayerR_Play.Location = new System.Drawing.Point(1281, 683);
            this.b_PlayerR_Play.Name = "b_PlayerR_Play";
            this.b_PlayerR_Play.Size = new System.Drawing.Size(320, 93);
            this.b_PlayerR_Play.TabIndex = 30;
            this.b_PlayerR_Play.Text = "Play";
            this.b_PlayerR_Play.UseVisualStyleBackColor = true;
            this.b_PlayerR_Play.Click += new System.EventHandler(this.b_PlayerR_Play_Click);
            // 
            // VLCPlayer_L
            // 
            this.VLCPlayer_L.Enabled = true;
            this.VLCPlayer_L.Location = new System.Drawing.Point(288, 19);
            this.VLCPlayer_L.Name = "VLCPlayer_L";
            this.VLCPlayer_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VLCPlayer_L.OcxState")));
            this.VLCPlayer_L.Size = new System.Drawing.Size(639, 512);
            this.VLCPlayer_L.TabIndex = 0;
            // 
            // checkB_PlayerL_Manual
            // 
            this.checkB_PlayerL_Manual.AutoSize = true;
            this.checkB_PlayerL_Manual.Location = new System.Drawing.Point(607, 547);
            this.checkB_PlayerL_Manual.Name = "checkB_PlayerL_Manual";
            this.checkB_PlayerL_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_PlayerL_Manual.TabIndex = 25;
            this.checkB_PlayerL_Manual.Text = "Extended RTSP Controls";
            this.checkB_PlayerL_Manual.UseVisualStyleBackColor = true;
            this.checkB_PlayerL_Manual.CheckedChanged += new System.EventHandler(this.checkB_PlayerL_Manual_CheckedChanged);
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(238, 62);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Connected.TabIndex = 23;
            // 
            // tB_PTZ_Speed
            // 
            this.tB_PTZ_Speed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tB_PTZ_Speed.Location = new System.Drawing.Point(109, 354);
            this.tB_PTZ_Speed.Maximum = 63;
            this.tB_PTZ_Speed.Name = "tB_PTZ_Speed";
            this.tB_PTZ_Speed.Size = new System.Drawing.Size(132, 45);
            this.tB_PTZ_Speed.TabIndex = 22;
            this.tB_PTZ_Speed.Value = 63;
            // 
            // cB_IPCon_Type
            // 
            this.cB_IPCon_Type.FormattingEnabled = true;
            this.cB_IPCon_Type.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_IPCon_Type.Location = new System.Drawing.Point(109, 35);
            this.cB_IPCon_Type.Name = "cB_IPCon_Type";
            this.cB_IPCon_Type.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_Type.TabIndex = 21;
            this.cB_IPCon_Type.Text = "Encoder";
            this.cB_IPCon_Type.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_Type_SelectedIndexChanged);
            // 
            // tB_Presets_Number
            // 
            this.tB_Presets_Number.Location = new System.Drawing.Point(118, 533);
            this.tB_Presets_Number.Name = "tB_Presets_Number";
            this.tB_Presets_Number.Size = new System.Drawing.Size(123, 20);
            this.tB_Presets_Number.TabIndex = 20;
            // 
            // tC_Presets_Default
            // 
            this.tC_Presets_Default.Controls.Add(this.tabPage5);
            this.tC_Presets_Default.Controls.Add(this.tabPage6);
            this.tC_Presets_Default.Controls.Add(this.tabPage7);
            this.tC_Presets_Default.Controls.Add(this.tabPage9);
            this.tC_Presets_Default.Controls.Add(this.tabPage8);
            this.tC_Presets_Default.Controls.Add(this.tabPage10);
            this.tC_Presets_Default.Location = new System.Drawing.Point(13, 632);
            this.tC_Presets_Default.Name = "tC_Presets_Default";
            this.tC_Presets_Default.SelectedIndex = 0;
            this.tC_Presets_Default.Size = new System.Drawing.Size(239, 222);
            this.tC_Presets_Default.TabIndex = 19;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.b_Presets_Daylight_Stabilizer);
            this.tabPage5.Controls.Add(this.b_Presets_Daylight_WDR);
            this.tabPage5.Controls.Add(this.b_Presets_Daylight_Wiper);
            this.tabPage5.Controls.Add(this.b_Presets_Daylight_AF);
            this.tabPage5.Controls.Add(this.b_Presets_Daylight_ColMono);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(231, 196);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Daylight";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Daylight_Stabilizer
            // 
            this.b_Presets_Daylight_Stabilizer.Location = new System.Drawing.Point(7, 133);
            this.b_Presets_Daylight_Stabilizer.Name = "b_Presets_Daylight_Stabilizer";
            this.b_Presets_Daylight_Stabilizer.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_Stabilizer.TabIndex = 6;
            this.b_Presets_Daylight_Stabilizer.Text = "Toggle Stabiliser";
            this.b_Presets_Daylight_Stabilizer.UseVisualStyleBackColor = true;
            this.b_Presets_Daylight_Stabilizer.Click += new System.EventHandler(this.b_Presets_Daylight_Stabilizer_Click);
            // 
            // b_Presets_Daylight_WDR
            // 
            this.b_Presets_Daylight_WDR.Location = new System.Drawing.Point(7, 100);
            this.b_Presets_Daylight_WDR.Name = "b_Presets_Daylight_WDR";
            this.b_Presets_Daylight_WDR.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_WDR.TabIndex = 6;
            this.b_Presets_Daylight_WDR.Text = "WDR On / Off (Sony Only)";
            this.b_Presets_Daylight_WDR.UseVisualStyleBackColor = true;
            this.b_Presets_Daylight_WDR.Click += new System.EventHandler(this.b_Presets_Daylight_WDR_Click);
            // 
            // b_Presets_Daylight_Wiper
            // 
            this.b_Presets_Daylight_Wiper.Location = new System.Drawing.Point(7, 69);
            this.b_Presets_Daylight_Wiper.Name = "b_Presets_Daylight_Wiper";
            this.b_Presets_Daylight_Wiper.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_Wiper.TabIndex = 6;
            this.b_Presets_Daylight_Wiper.Text = "Wiper";
            this.b_Presets_Daylight_Wiper.UseVisualStyleBackColor = true;
            this.b_Presets_Daylight_Wiper.Click += new System.EventHandler(this.b_Presets_Daylight_Wiper_Click);
            // 
            // b_Presets_Daylight_AF
            // 
            this.b_Presets_Daylight_AF.Location = new System.Drawing.Point(7, 4);
            this.b_Presets_Daylight_AF.Name = "b_Presets_Daylight_AF";
            this.b_Presets_Daylight_AF.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_AF.TabIndex = 6;
            this.b_Presets_Daylight_AF.Text = "AutoFocus ";
            this.b_Presets_Daylight_AF.UseVisualStyleBackColor = true;
            this.b_Presets_Daylight_AF.Click += new System.EventHandler(this.b_Presets_Daylight_AF_Click);
            // 
            // b_Presets_Daylight_ColMono
            // 
            this.b_Presets_Daylight_ColMono.Location = new System.Drawing.Point(7, 37);
            this.b_Presets_Daylight_ColMono.Name = "b_Presets_Daylight_ColMono";
            this.b_Presets_Daylight_ColMono.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_ColMono.TabIndex = 6;
            this.b_Presets_Daylight_ColMono.Text = "Colour / Mono";
            this.b_Presets_Daylight_ColMono.UseVisualStyleBackColor = true;
            this.b_Presets_Daylight_ColMono.Click += new System.EventHandler(this.b_Presets_Daylight_ColMono_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button32);
            this.tabPage6.Controls.Add(this.button31);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_BrightPos);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_BrightNeg);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_ICEPos);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_ICENeg);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_ICE);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_WhiteBlack);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_NUC);
            this.tabPage6.Controls.Add(this.b_Presets_Thermal_AF);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(231, 196);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Thermal";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(127, 198);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(91, 27);
            this.button32.TabIndex = 6;
            this.button32.Text = "Contrast +";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(6, 198);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(91, 27);
            this.button31.TabIndex = 6;
            this.button31.Text = "Contrast -";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // b_Presets_Thermal_BrightPos
            // 
            this.b_Presets_Thermal_BrightPos.Location = new System.Drawing.Point(127, 168);
            this.b_Presets_Thermal_BrightPos.Name = "b_Presets_Thermal_BrightPos";
            this.b_Presets_Thermal_BrightPos.Size = new System.Drawing.Size(91, 27);
            this.b_Presets_Thermal_BrightPos.TabIndex = 6;
            this.b_Presets_Thermal_BrightPos.Text = "Brightness +";
            this.b_Presets_Thermal_BrightPos.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_BrightPos.Click += new System.EventHandler(this.b_Presets_Thermal_BrightPos_Click);
            // 
            // b_Presets_Thermal_BrightNeg
            // 
            this.b_Presets_Thermal_BrightNeg.Location = new System.Drawing.Point(6, 168);
            this.b_Presets_Thermal_BrightNeg.Name = "b_Presets_Thermal_BrightNeg";
            this.b_Presets_Thermal_BrightNeg.Size = new System.Drawing.Size(91, 27);
            this.b_Presets_Thermal_BrightNeg.TabIndex = 6;
            this.b_Presets_Thermal_BrightNeg.Text = "Brightness -";
            this.b_Presets_Thermal_BrightNeg.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_BrightNeg.Click += new System.EventHandler(this.b_Presets_Thermal_BrightNeg_Click);
            // 
            // b_Presets_Thermal_ICEPos
            // 
            this.b_Presets_Thermal_ICEPos.Location = new System.Drawing.Point(127, 135);
            this.b_Presets_Thermal_ICEPos.Name = "b_Presets_Thermal_ICEPos";
            this.b_Presets_Thermal_ICEPos.Size = new System.Drawing.Size(91, 27);
            this.b_Presets_Thermal_ICEPos.TabIndex = 6;
            this.b_Presets_Thermal_ICEPos.Text = "ICE / CLAHE +";
            this.b_Presets_Thermal_ICEPos.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_ICEPos.Click += new System.EventHandler(this.b_Presets_Thermal_ICEPos_Click);
            // 
            // b_Presets_Thermal_ICENeg
            // 
            this.b_Presets_Thermal_ICENeg.Location = new System.Drawing.Point(6, 135);
            this.b_Presets_Thermal_ICENeg.Name = "b_Presets_Thermal_ICENeg";
            this.b_Presets_Thermal_ICENeg.Size = new System.Drawing.Size(91, 27);
            this.b_Presets_Thermal_ICENeg.TabIndex = 6;
            this.b_Presets_Thermal_ICENeg.Text = "ICE / CLAHE -";
            this.b_Presets_Thermal_ICENeg.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_ICENeg.Click += new System.EventHandler(this.b_Presets_Thermal_ICENeg_Click);
            // 
            // b_Presets_Thermal_ICE
            // 
            this.b_Presets_Thermal_ICE.Location = new System.Drawing.Point(6, 102);
            this.b_Presets_Thermal_ICE.Name = "b_Presets_Thermal_ICE";
            this.b_Presets_Thermal_ICE.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_ICE.TabIndex = 6;
            this.b_Presets_Thermal_ICE.Text = "Toggle ICE / CLAHE";
            this.b_Presets_Thermal_ICE.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_ICE.Click += new System.EventHandler(this.b_Presets_Thermal_ICE_Click);
            // 
            // b_Presets_Thermal_WhiteBlack
            // 
            this.b_Presets_Thermal_WhiteBlack.Location = new System.Drawing.Point(6, 69);
            this.b_Presets_Thermal_WhiteBlack.Name = "b_Presets_Thermal_WhiteBlack";
            this.b_Presets_Thermal_WhiteBlack.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_WhiteBlack.TabIndex = 6;
            this.b_Presets_Thermal_WhiteBlack.Text = "White Hot / Black Hot";
            this.b_Presets_Thermal_WhiteBlack.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_WhiteBlack.Click += new System.EventHandler(this.b_Presets_Thermal_WhiteBlack_Click);
            // 
            // b_Presets_Thermal_NUC
            // 
            this.b_Presets_Thermal_NUC.Location = new System.Drawing.Point(6, 38);
            this.b_Presets_Thermal_NUC.Name = "b_Presets_Thermal_NUC";
            this.b_Presets_Thermal_NUC.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_NUC.TabIndex = 6;
            this.b_Presets_Thermal_NUC.Text = "Do NUC";
            this.b_Presets_Thermal_NUC.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_NUC.Click += new System.EventHandler(this.b_Presets_Thermal_NUC_Click);
            // 
            // b_Presets_Thermal_AF
            // 
            this.b_Presets_Thermal_AF.Location = new System.Drawing.Point(6, 6);
            this.b_Presets_Thermal_AF.Name = "b_Presets_Thermal_AF";
            this.b_Presets_Thermal_AF.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_AF.TabIndex = 6;
            this.b_Presets_Thermal_AF.Text = "AutoFocus";
            this.b_Presets_Thermal_AF.UseVisualStyleBackColor = true;
            this.b_Presets_Thermal_AF.Click += new System.EventHandler(this.b_Presets_Thermal_AF_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.b_Presets_SLG_SteadyGreen);
            this.tabPage7.Controls.Add(this.b_Presets_SLG_AllLightsOff);
            this.tabPage7.Controls.Add(this.b_Presets_SLG_FlashingRG);
            this.tabPage7.Controls.Add(this.b_Presets_SLG_FlashingWhite);
            this.tabPage7.Controls.Add(this.b_Presets_SLG_FlashingRed);
            this.tabPage7.Controls.Add(this.b_Presets_SLG_SteadyRed);
            this.tabPage7.Controls.Add(this.b_Presets_SLG_FlashingGreen);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(231, 196);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "SLG";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_SteadyGreen
            // 
            this.b_Presets_SLG_SteadyGreen.Location = new System.Drawing.Point(6, 3);
            this.b_Presets_SLG_SteadyGreen.Name = "b_Presets_SLG_SteadyGreen";
            this.b_Presets_SLG_SteadyGreen.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_SteadyGreen.TabIndex = 8;
            this.b_Presets_SLG_SteadyGreen.Text = "Steady Green On";
            this.b_Presets_SLG_SteadyGreen.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_SteadyGreen.Click += new System.EventHandler(this.b_Presets_SLG_SteadyGreen_Click);
            // 
            // b_Presets_SLG_AllLightsOff
            // 
            this.b_Presets_SLG_AllLightsOff.Location = new System.Drawing.Point(6, 198);
            this.b_Presets_SLG_AllLightsOff.Name = "b_Presets_SLG_AllLightsOff";
            this.b_Presets_SLG_AllLightsOff.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_AllLightsOff.TabIndex = 7;
            this.b_Presets_SLG_AllLightsOff.Text = "All Lights Off";
            this.b_Presets_SLG_AllLightsOff.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_AllLightsOff.Click += new System.EventHandler(this.b_Presets_SLG_AllLightsOff_Click);
            // 
            // b_Presets_SLG_FlashingRG
            // 
            this.b_Presets_SLG_FlashingRG.Location = new System.Drawing.Point(6, 167);
            this.b_Presets_SLG_FlashingRG.Name = "b_Presets_SLG_FlashingRG";
            this.b_Presets_SLG_FlashingRG.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_FlashingRG.TabIndex = 7;
            this.b_Presets_SLG_FlashingRG.Text = "Flashing Red / Green";
            this.b_Presets_SLG_FlashingRG.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_FlashingRG.Click += new System.EventHandler(this.b_Presets_SLG_FlashingRG_Click);
            // 
            // b_Presets_SLG_FlashingWhite
            // 
            this.b_Presets_SLG_FlashingWhite.Location = new System.Drawing.Point(6, 135);
            this.b_Presets_SLG_FlashingWhite.Name = "b_Presets_SLG_FlashingWhite";
            this.b_Presets_SLG_FlashingWhite.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_FlashingWhite.TabIndex = 7;
            this.b_Presets_SLG_FlashingWhite.Text = "Flashing White On";
            this.b_Presets_SLG_FlashingWhite.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_FlashingWhite.Click += new System.EventHandler(this.b_Presets_SLG_FlashingWhite_Click);
            // 
            // b_Presets_SLG_FlashingRed
            // 
            this.b_Presets_SLG_FlashingRed.Location = new System.Drawing.Point(6, 102);
            this.b_Presets_SLG_FlashingRed.Name = "b_Presets_SLG_FlashingRed";
            this.b_Presets_SLG_FlashingRed.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_FlashingRed.TabIndex = 7;
            this.b_Presets_SLG_FlashingRed.Text = "Flashing Red On";
            this.b_Presets_SLG_FlashingRed.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_FlashingRed.Click += new System.EventHandler(this.b_Presets_SLG_FlashingRed_Click);
            // 
            // b_Presets_SLG_SteadyRed
            // 
            this.b_Presets_SLG_SteadyRed.Location = new System.Drawing.Point(6, 69);
            this.b_Presets_SLG_SteadyRed.Name = "b_Presets_SLG_SteadyRed";
            this.b_Presets_SLG_SteadyRed.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_SteadyRed.TabIndex = 7;
            this.b_Presets_SLG_SteadyRed.Text = "Steady Red On";
            this.b_Presets_SLG_SteadyRed.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_SteadyRed.Click += new System.EventHandler(this.b_Presets_SLG_SteadyRed_Click);
            // 
            // b_Presets_SLG_FlashingGreen
            // 
            this.b_Presets_SLG_FlashingGreen.Location = new System.Drawing.Point(6, 36);
            this.b_Presets_SLG_FlashingGreen.Name = "b_Presets_SLG_FlashingGreen";
            this.b_Presets_SLG_FlashingGreen.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_FlashingGreen.TabIndex = 7;
            this.b_Presets_SLG_FlashingGreen.Text = "Flashing Green On";
            this.b_Presets_SLG_FlashingGreen.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_FlashingGreen.Click += new System.EventHandler(this.b_Presets_SLG_FlashingGreen_Click);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.b_Presets_Peak_SteadyLamp);
            this.tabPage9.Controls.Add(this.b_Presets_Peak_StopZoom);
            this.tabPage9.Controls.Add(this.b_Presets_Peak_ZoomOut);
            this.tabPage9.Controls.Add(this.b_Presets_Peak_ZoomIn);
            this.tabPage9.Controls.Add(this.b_Presets_Peak_LampOff);
            this.tabPage9.Controls.Add(this.b_Presets_Peak_StrobeLamp);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(231, 196);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "Peak Beam";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_SteadyLamp
            // 
            this.b_Presets_Peak_SteadyLamp.Location = new System.Drawing.Point(7, 3);
            this.b_Presets_Peak_SteadyLamp.Name = "b_Presets_Peak_SteadyLamp";
            this.b_Presets_Peak_SteadyLamp.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_SteadyLamp.TabIndex = 14;
            this.b_Presets_Peak_SteadyLamp.Text = "Lamp On Steady";
            this.b_Presets_Peak_SteadyLamp.UseVisualStyleBackColor = true;
            this.b_Presets_Peak_SteadyLamp.Click += new System.EventHandler(this.b_Presets_Peak_SteadyLamp_Click);
            // 
            // b_Presets_Peak_StopZoom
            // 
            this.b_Presets_Peak_StopZoom.Location = new System.Drawing.Point(7, 167);
            this.b_Presets_Peak_StopZoom.Name = "b_Presets_Peak_StopZoom";
            this.b_Presets_Peak_StopZoom.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_StopZoom.TabIndex = 9;
            this.b_Presets_Peak_StopZoom.Text = "Stop Zooming";
            this.b_Presets_Peak_StopZoom.UseVisualStyleBackColor = true;
            this.b_Presets_Peak_StopZoom.Click += new System.EventHandler(this.b_Presets_Peak_StopZoom_Click);
            // 
            // b_Presets_Peak_ZoomOut
            // 
            this.b_Presets_Peak_ZoomOut.Location = new System.Drawing.Point(7, 135);
            this.b_Presets_Peak_ZoomOut.Name = "b_Presets_Peak_ZoomOut";
            this.b_Presets_Peak_ZoomOut.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_ZoomOut.TabIndex = 10;
            this.b_Presets_Peak_ZoomOut.Text = "Start Zoom Out";
            this.b_Presets_Peak_ZoomOut.UseVisualStyleBackColor = true;
            this.b_Presets_Peak_ZoomOut.Click += new System.EventHandler(this.b_Presets_Peak_ZoomOut_Click);
            // 
            // b_Presets_Peak_ZoomIn
            // 
            this.b_Presets_Peak_ZoomIn.Location = new System.Drawing.Point(7, 102);
            this.b_Presets_Peak_ZoomIn.Name = "b_Presets_Peak_ZoomIn";
            this.b_Presets_Peak_ZoomIn.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_ZoomIn.TabIndex = 11;
            this.b_Presets_Peak_ZoomIn.Text = "Start Zoom In";
            this.b_Presets_Peak_ZoomIn.UseVisualStyleBackColor = true;
            this.b_Presets_Peak_ZoomIn.Click += new System.EventHandler(this.b_Presets_Peak_ZoomIn_Click);
            // 
            // b_Presets_Peak_LampOff
            // 
            this.b_Presets_Peak_LampOff.Location = new System.Drawing.Point(7, 69);
            this.b_Presets_Peak_LampOff.Name = "b_Presets_Peak_LampOff";
            this.b_Presets_Peak_LampOff.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_LampOff.TabIndex = 12;
            this.b_Presets_Peak_LampOff.Text = "Lamp Off";
            this.b_Presets_Peak_LampOff.UseVisualStyleBackColor = true;
            this.b_Presets_Peak_LampOff.Click += new System.EventHandler(this.Presets_Peak_LampOff_Click);
            // 
            // b_Presets_Peak_StrobeLamp
            // 
            this.b_Presets_Peak_StrobeLamp.Location = new System.Drawing.Point(7, 36);
            this.b_Presets_Peak_StrobeLamp.Name = "b_Presets_Peak_StrobeLamp";
            this.b_Presets_Peak_StrobeLamp.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_StrobeLamp.TabIndex = 13;
            this.b_Presets_Peak_StrobeLamp.Text = "Lamp on Strobe";
            this.b_Presets_Peak_StrobeLamp.UseVisualStyleBackColor = true;
            this.b_Presets_Peak_StrobeLamp.Click += new System.EventHandler(this.b_Presets_Peak_StrobeLamp_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.b_Presets_Admin_DefaultMen);
            this.tabPage8.Controls.Add(this.b_Presets_Admin_DebugToggle);
            this.tabPage8.Controls.Add(this.b_Presets_Admin_MechMen);
            this.tabPage8.Controls.Add(this.b_Presets_Admin_SetupMen);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(231, 196);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Admin";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Admin_DefaultMen
            // 
            this.b_Presets_Admin_DefaultMen.Location = new System.Drawing.Point(3, 64);
            this.b_Presets_Admin_DefaultMen.Name = "b_Presets_Admin_DefaultMen";
            this.b_Presets_Admin_DefaultMen.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_DefaultMen.TabIndex = 10;
            this.b_Presets_Admin_DefaultMen.Text = "Default Menu";
            this.b_Presets_Admin_DefaultMen.UseVisualStyleBackColor = true;
            this.b_Presets_Admin_DefaultMen.Click += new System.EventHandler(this.b_Presets_Admin_DebugToggle_Click);
            // 
            // b_Presets_Admin_DebugToggle
            // 
            this.b_Presets_Admin_DebugToggle.Location = new System.Drawing.Point(3, 93);
            this.b_Presets_Admin_DebugToggle.Name = "b_Presets_Admin_DebugToggle";
            this.b_Presets_Admin_DebugToggle.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_DebugToggle.TabIndex = 10;
            this.b_Presets_Admin_DebugToggle.Text = "Debug Toggle";
            this.b_Presets_Admin_DebugToggle.UseVisualStyleBackColor = true;
            this.b_Presets_Admin_DebugToggle.Click += new System.EventHandler(this.b_Presets_Admin_DebugToggle_Click);
            // 
            // b_Presets_Admin_MechMen
            // 
            this.b_Presets_Admin_MechMen.Location = new System.Drawing.Point(3, 5);
            this.b_Presets_Admin_MechMen.Name = "b_Presets_Admin_MechMen";
            this.b_Presets_Admin_MechMen.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_MechMen.TabIndex = 9;
            this.b_Presets_Admin_MechMen.Text = "Mechanical Menu";
            this.b_Presets_Admin_MechMen.UseVisualStyleBackColor = true;
            this.b_Presets_Admin_MechMen.Click += new System.EventHandler(this.b_Presets_Admin_MechMen_Click);
            // 
            // b_Presets_Admin_SetupMen
            // 
            this.b_Presets_Admin_SetupMen.Location = new System.Drawing.Point(3, 34);
            this.b_Presets_Admin_SetupMen.Name = "b_Presets_Admin_SetupMen";
            this.b_Presets_Admin_SetupMen.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_SetupMen.TabIndex = 9;
            this.b_Presets_Admin_SetupMen.Text = "Setup Menu";
            this.b_Presets_Admin_SetupMen.UseVisualStyleBackColor = true;
            this.b_Presets_Admin_SetupMen.Click += new System.EventHandler(this.b_Presets_Admin_SetupMen_Click);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.b_Presets_CHARM_Aquire);
            this.tabPage10.Controls.Add(this.b_Presets_CHARM_Standby);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(231, 196);
            this.tabPage10.TabIndex = 5;
            this.tabPage10.Text = "CHARM";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // b_Presets_CHARM_Aquire
            // 
            this.b_Presets_CHARM_Aquire.Location = new System.Drawing.Point(4, 37);
            this.b_Presets_CHARM_Aquire.Name = "b_Presets_CHARM_Aquire";
            this.b_Presets_CHARM_Aquire.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_CHARM_Aquire.TabIndex = 10;
            this.b_Presets_CHARM_Aquire.Text = "Aquire";
            this.b_Presets_CHARM_Aquire.UseVisualStyleBackColor = true;
            // 
            // b_Presets_CHARM_Standby
            // 
            this.b_Presets_CHARM_Standby.Location = new System.Drawing.Point(4, 4);
            this.b_Presets_CHARM_Standby.Name = "b_Presets_CHARM_Standby";
            this.b_Presets_CHARM_Standby.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_CHARM_Standby.TabIndex = 10;
            this.b_Presets_CHARM_Standby.Text = "Standby";
            this.b_Presets_CHARM_Standby.UseVisualStyleBackColor = true;
            // 
            // cB_IPCon_KeyboardCon
            // 
            this.cB_IPCon_KeyboardCon.AutoSize = true;
            this.cB_IPCon_KeyboardCon.Location = new System.Drawing.Point(109, 150);
            this.cB_IPCon_KeyboardCon.Name = "cB_IPCon_KeyboardCon";
            this.cB_IPCon_KeyboardCon.Size = new System.Drawing.Size(15, 14);
            this.cB_IPCon_KeyboardCon.TabIndex = 18;
            this.cB_IPCon_KeyboardCon.UseVisualStyleBackColor = true;
            // 
            // cB_IPCon_Selected
            // 
            this.cB_IPCon_Selected.FormattingEnabled = true;
            this.cB_IPCon_Selected.Items.AddRange(new object[] {
            "Daylight",
            "Thermal"});
            this.cB_IPCon_Selected.Location = new System.Drawing.Point(109, 115);
            this.cB_IPCon_Selected.Name = "cB_IPCon_Selected";
            this.cB_IPCon_Selected.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_Selected.TabIndex = 15;
            this.cB_IPCon_Selected.Text = "Daylight";
            // 
            // tB_IPCon_Port
            // 
            this.tB_IPCon_Port.Location = new System.Drawing.Point(109, 88);
            this.tB_IPCon_Port.Name = "tB_IPCon_Port";
            this.tB_IPCon_Port.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Port.TabIndex = 14;
            this.tB_IPCon_Port.Text = "6791";
            // 
            // tB_IPCon_Adr
            // 
            this.tB_IPCon_Adr.Location = new System.Drawing.Point(109, 62);
            this.tB_IPCon_Adr.Name = "tB_IPCon_Adr";
            this.tB_IPCon_Adr.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Adr.TabIndex = 14;
            this.tB_IPCon_Adr.Text = "192.168.1.71";
            this.tB_IPCon_Adr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_IPCon_Adr_PreviewKeyDown);
            this.tB_IPCon_Adr.Leave += new System.EventHandler(this.OnFinishedTypingAdr);
            // 
            // l_IPCon_KeyControl
            // 
            this.l_IPCon_KeyControl.AutoSize = true;
            this.l_IPCon_KeyControl.Location = new System.Drawing.Point(14, 150);
            this.l_IPCon_KeyControl.Name = "l_IPCon_KeyControl";
            this.l_IPCon_KeyControl.Size = new System.Drawing.Size(91, 13);
            this.l_IPCon_KeyControl.TabIndex = 13;
            this.l_IPCon_KeyControl.Text = "Keyboard Control:";
            // 
            // l_IPCon_SelectedCam
            // 
            this.l_IPCon_SelectedCam.AutoSize = true;
            this.l_IPCon_SelectedCam.Location = new System.Drawing.Point(14, 118);
            this.l_IPCon_SelectedCam.Name = "l_IPCon_SelectedCam";
            this.l_IPCon_SelectedCam.Size = new System.Drawing.Size(91, 13);
            this.l_IPCon_SelectedCam.TabIndex = 13;
            this.l_IPCon_SelectedCam.Text = "Selected Camera:";
            // 
            // l_IPCon_Port
            // 
            this.l_IPCon_Port.AutoSize = true;
            this.l_IPCon_Port.Location = new System.Drawing.Point(14, 88);
            this.l_IPCon_Port.Name = "l_IPCon_Port";
            this.l_IPCon_Port.Size = new System.Drawing.Size(29, 13);
            this.l_IPCon_Port.TabIndex = 13;
            this.l_IPCon_Port.Text = "Port:";
            // 
            // l_IPCon_Speed
            // 
            this.l_IPCon_Speed.AutoSize = true;
            this.l_IPCon_Speed.Location = new System.Drawing.Point(14, 357);
            this.l_IPCon_Speed.Name = "l_IPCon_Speed";
            this.l_IPCon_Speed.Size = new System.Drawing.Size(88, 13);
            this.l_IPCon_Speed.TabIndex = 12;
            this.l_IPCon_Speed.Text = "Pan / Tilt Speed:";
            // 
            // l_Presets_Number
            // 
            this.l_Presets_Number.AutoSize = true;
            this.l_Presets_Number.Location = new System.Drawing.Point(20, 536);
            this.l_Presets_Number.Name = "l_Presets_Number";
            this.l_Presets_Number.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_Number.TabIndex = 12;
            this.l_Presets_Number.Text = "Number:";
            // 
            // l_IPCon_ConType
            // 
            this.l_IPCon_ConType.AutoSize = true;
            this.l_IPCon_ConType.Location = new System.Drawing.Point(14, 38);
            this.l_IPCon_ConType.Name = "l_IPCon_ConType";
            this.l_IPCon_ConType.Size = new System.Drawing.Size(70, 13);
            this.l_IPCon_ConType.TabIndex = 12;
            this.l_IPCon_ConType.Text = "Control Type:";
            // 
            // l_IPCon_Adr
            // 
            this.l_IPCon_Adr.AutoSize = true;
            this.l_IPCon_Adr.Location = new System.Drawing.Point(14, 62);
            this.l_IPCon_Adr.Name = "l_IPCon_Adr";
            this.l_IPCon_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_IPCon_Adr.TabIndex = 12;
            this.l_IPCon_Adr.Text = "IP Address:";
            // 
            // l_Presets_Default
            // 
            this.l_Presets_Default.AutoSize = true;
            this.l_Presets_Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Presets_Default.Location = new System.Drawing.Point(13, 601);
            this.l_Presets_Default.Name = "l_Presets_Default";
            this.l_Presets_Default.Size = new System.Drawing.Size(134, 20);
            this.l_Presets_Default.TabIndex = 11;
            this.l_Presets_Default.Text = "Default Presets";
            // 
            // l_Presets
            // 
            this.l_Presets.AutoSize = true;
            this.l_Presets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Presets.Location = new System.Drawing.Point(13, 500);
            this.l_Presets.Name = "l_Presets";
            this.l_Presets.Size = new System.Drawing.Size(70, 20);
            this.l_Presets.TabIndex = 11;
            this.l_Presets.Text = "Presets";
            // 
            // l_PTZCon
            // 
            this.l_PTZCon.AutoSize = true;
            this.l_PTZCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PTZCon.Location = new System.Drawing.Point(17, 175);
            this.l_PTZCon.Name = "l_PTZCon";
            this.l_PTZCon.Size = new System.Drawing.Size(104, 20);
            this.l_PTZCon.TabIndex = 11;
            this.l_PTZCon.Text = "PTZ Control";
            // 
            // l_IPCon
            // 
            this.l_IPCon.AutoSize = true;
            this.l_IPCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IPCon.Location = new System.Drawing.Point(13, 6);
            this.l_IPCon.Name = "l_IPCon";
            this.l_IPCon.Size = new System.Drawing.Size(89, 20);
            this.l_IPCon.TabIndex = 11;
            this.l_IPCon.Text = "IP Control";
            // 
            // b_PlayerL_Detach
            // 
            this.b_PlayerL_Detach.Location = new System.Drawing.Point(17, 390);
            this.b_PlayerL_Detach.Name = "b_PlayerL_Detach";
            this.b_PlayerL_Detach.Size = new System.Drawing.Size(239, 92);
            this.b_PlayerL_Detach.TabIndex = 8;
            this.b_PlayerL_Detach.Text = "Detach Video";
            this.b_PlayerL_Detach.UseVisualStyleBackColor = true;
            this.b_PlayerL_Detach.Click += new System.EventHandler(this.b_PlayerL_Detach_Click);
            // 
            // b_PlayerL_PauseRec
            // 
            this.b_PlayerL_PauseRec.Location = new System.Drawing.Point(607, 647);
            this.b_PlayerL_PauseRec.Name = "b_PlayerL_PauseRec";
            this.b_PlayerL_PauseRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_PauseRec.TabIndex = 8;
            this.b_PlayerL_PauseRec.Text = "PAUSE Recording";
            this.b_PlayerL_PauseRec.UseVisualStyleBackColor = true;
            this.b_PlayerL_PauseRec.Click += new System.EventHandler(this.b_PlayerL_PauseRec_Click);
            // 
            // b_PlayerL_StartRec
            // 
            this.b_PlayerL_StartRec.Location = new System.Drawing.Point(607, 618);
            this.b_PlayerL_StartRec.Name = "b_PlayerL_StartRec";
            this.b_PlayerL_StartRec.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_StartRec.TabIndex = 8;
            this.b_PlayerL_StartRec.Text = "START Recording";
            this.b_PlayerL_StartRec.UseVisualStyleBackColor = true;
            this.b_PlayerL_StartRec.Click += new System.EventHandler(this.b_PlayerL_StartRec_Click);
            // 
            // b_PlayerL_SaveSnap
            // 
            this.b_PlayerL_SaveSnap.Location = new System.Drawing.Point(607, 576);
            this.b_PlayerL_SaveSnap.Name = "b_PlayerL_SaveSnap";
            this.b_PlayerL_SaveSnap.Size = new System.Drawing.Size(172, 23);
            this.b_PlayerL_SaveSnap.TabIndex = 8;
            this.b_PlayerL_SaveSnap.Text = "Save Snapshot";
            this.b_PlayerL_SaveSnap.UseVisualStyleBackColor = true;
            this.b_PlayerL_SaveSnap.Click += new System.EventHandler(this.b_PlayerL_SaveSnap_Click);
            // 
            // b_Presets_Learn
            // 
            this.b_Presets_Learn.Location = new System.Drawing.Point(147, 559);
            this.b_Presets_Learn.Name = "b_Presets_Learn";
            this.b_Presets_Learn.Size = new System.Drawing.Size(94, 22);
            this.b_Presets_Learn.TabIndex = 6;
            this.b_Presets_Learn.Text = "Learn";
            this.b_Presets_Learn.UseVisualStyleBackColor = true;
            this.b_Presets_Learn.Click += new System.EventHandler(this.b_Presets_Learn_Click);
            // 
            // b_Presets_GoTo
            // 
            this.b_Presets_GoTo.Location = new System.Drawing.Point(23, 560);
            this.b_Presets_GoTo.Name = "b_Presets_GoTo";
            this.b_Presets_GoTo.Size = new System.Drawing.Size(94, 22);
            this.b_Presets_GoTo.TabIndex = 6;
            this.b_Presets_GoTo.Text = "Go To";
            this.b_Presets_GoTo.UseVisualStyleBackColor = true;
            this.b_Presets_GoTo.Click += new System.EventHandler(this.b_Presets_GoTo_Click);
            // 
            // b_PTZ_Down
            // 
            this.b_PTZ_Down.Location = new System.Drawing.Point(109, 303);
            this.b_PTZ_Down.Name = "b_PTZ_Down";
            this.b_PTZ_Down.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Down.TabIndex = 6;
            this.b_PTZ_Down.Text = "Down";
            this.b_PTZ_Down.UseVisualStyleBackColor = true;
            this.b_PTZ_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Down_MouseDown);
            this.b_PTZ_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Up
            // 
            this.b_PTZ_Up.Location = new System.Drawing.Point(109, 219);
            this.b_PTZ_Up.Name = "b_PTZ_Up";
            this.b_PTZ_Up.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Up.TabIndex = 6;
            this.b_PTZ_Up.Text = "Up";
            this.b_PTZ_Up.UseVisualStyleBackColor = true;
            this.b_PTZ_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Up_MouseDown);
            this.b_PTZ_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusNeg
            // 
            this.b_PTZ_FocusNeg.BackColor = System.Drawing.Color.Aqua;
            this.b_PTZ_FocusNeg.Location = new System.Drawing.Point(31, 305);
            this.b_PTZ_FocusNeg.Name = "b_PTZ_FocusNeg";
            this.b_PTZ_FocusNeg.Size = new System.Drawing.Size(59, 34);
            this.b_PTZ_FocusNeg.TabIndex = 6;
            this.b_PTZ_FocusNeg.Text = "F-";
            this.b_PTZ_FocusNeg.UseVisualStyleBackColor = false;
            this.b_PTZ_FocusNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusNeg_MouseDown);
            this.b_PTZ_FocusNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_ZoomNeg
            // 
            this.b_PTZ_ZoomNeg.BackColor = System.Drawing.Color.GreenYellow;
            this.b_PTZ_ZoomNeg.Location = new System.Drawing.Point(31, 218);
            this.b_PTZ_ZoomNeg.Name = "b_PTZ_ZoomNeg";
            this.b_PTZ_ZoomNeg.Size = new System.Drawing.Size(59, 35);
            this.b_PTZ_ZoomNeg.TabIndex = 6;
            this.b_PTZ_ZoomNeg.Text = "Z-";
            this.b_PTZ_ZoomNeg.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomNeg_MouseDown);
            this.b_PTZ_ZoomNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusPos
            // 
            this.b_PTZ_FocusPos.BackColor = System.Drawing.Color.Aqua;
            this.b_PTZ_FocusPos.Location = new System.Drawing.Point(186, 305);
            this.b_PTZ_FocusPos.Name = "b_PTZ_FocusPos";
            this.b_PTZ_FocusPos.Size = new System.Drawing.Size(59, 34);
            this.b_PTZ_FocusPos.TabIndex = 6;
            this.b_PTZ_FocusPos.Text = "F+";
            this.b_PTZ_FocusPos.UseVisualStyleBackColor = false;
            this.b_PTZ_FocusPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusPos_MouseDown);
            this.b_PTZ_FocusPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_ZoomPos
            // 
            this.b_PTZ_ZoomPos.BackColor = System.Drawing.Color.GreenYellow;
            this.b_PTZ_ZoomPos.Location = new System.Drawing.Point(186, 219);
            this.b_PTZ_ZoomPos.Name = "b_PTZ_ZoomPos";
            this.b_PTZ_ZoomPos.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_ZoomPos.TabIndex = 6;
            this.b_PTZ_ZoomPos.Text = "Z+";
            this.b_PTZ_ZoomPos.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomPos_MouseDown);
            this.b_PTZ_ZoomPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Right
            // 
            this.b_PTZ_Right.Location = new System.Drawing.Point(167, 261);
            this.b_PTZ_Right.Name = "b_PTZ_Right";
            this.b_PTZ_Right.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Right.TabIndex = 6;
            this.b_PTZ_Right.Text = "Right";
            this.b_PTZ_Right.UseVisualStyleBackColor = true;
            this.b_PTZ_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Right_MouseDown);
            this.b_PTZ_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Left
            // 
            this.b_PTZ_Left.Location = new System.Drawing.Point(51, 261);
            this.b_PTZ_Left.Name = "b_PTZ_Left";
            this.b_PTZ_Left.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Left.TabIndex = 6;
            this.b_PTZ_Left.Text = "Left";
            this.b_PTZ_Left.UseVisualStyleBackColor = true;
            this.b_PTZ_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Left_MouseDown);
            this.b_PTZ_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PlayerL_Play
            // 
            this.b_PlayerL_Play.Location = new System.Drawing.Point(607, 683);
            this.b_PlayerL_Play.Name = "b_PlayerL_Play";
            this.b_PlayerL_Play.Size = new System.Drawing.Size(320, 93);
            this.b_PlayerL_Play.TabIndex = 1;
            this.b_PlayerL_Play.Text = "Play";
            this.b_PlayerL_Play.UseVisualStyleBackColor = true;
            this.b_PlayerL_Play.Click += new System.EventHandler(this.b_PlayerL_Play_Click);
            // 
            // tP_Settings
            // 
            this.tP_Settings.Controls.Add(this.l_Paths_sCCheck);
            this.tP_Settings.Controls.Add(this.gB_Paths);
            this.tP_Settings.Location = new System.Drawing.Point(4, 22);
            this.tP_Settings.Name = "tP_Settings";
            this.tP_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Settings.Size = new System.Drawing.Size(1637, 871);
            this.tP_Settings.TabIndex = 1;
            this.tP_Settings.Text = "Settings";
            this.tP_Settings.UseVisualStyleBackColor = true;
            // 
            // l_Paths_sCCheck
            // 
            this.l_Paths_sCCheck.AutoSize = true;
            this.l_Paths_sCCheck.Location = new System.Drawing.Point(397, 53);
            this.l_Paths_sCCheck.Name = "l_Paths_sCCheck";
            this.l_Paths_sCCheck.Size = new System.Drawing.Size(0, 13);
            this.l_Paths_sCCheck.TabIndex = 16;
            // 
            // gB_Paths
            // 
            this.gB_Paths.Controls.Add(this.tB_Paths_sCFolder);
            this.gB_Paths.Controls.Add(this.b_Settings_Apply);
            this.gB_Paths.Controls.Add(this.b_Settings_Default);
            this.gB_Paths.Controls.Add(this.b_Paths_sCBrowse);
            this.gB_Paths.Controls.Add(this.label1);
            this.gB_Paths.Controls.Add(this.l_Paths_sCFolder);
            this.gB_Paths.Location = new System.Drawing.Point(17, 6);
            this.gB_Paths.Name = "gB_Paths";
            this.gB_Paths.Size = new System.Drawing.Size(428, 194);
            this.gB_Paths.TabIndex = 27;
            this.gB_Paths.TabStop = false;
            // 
            // tB_Paths_sCFolder
            // 
            this.tB_Paths_sCFolder.Location = new System.Drawing.Point(109, 45);
            this.tB_Paths_sCFolder.Name = "tB_Paths_sCFolder";
            this.tB_Paths_sCFolder.Size = new System.Drawing.Size(198, 20);
            this.tB_Paths_sCFolder.TabIndex = 16;
            // 
            // b_Settings_Apply
            // 
            this.b_Settings_Apply.Location = new System.Drawing.Point(347, 165);
            this.b_Settings_Apply.Name = "b_Settings_Apply";
            this.b_Settings_Apply.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Apply.TabIndex = 15;
            this.b_Settings_Apply.Text = "Apply";
            this.b_Settings_Apply.UseVisualStyleBackColor = true;
            this.b_Settings_Apply.Click += new System.EventHandler(this.b_Settings_Apply_Click);
            // 
            // b_Settings_Default
            // 
            this.b_Settings_Default.Location = new System.Drawing.Point(266, 165);
            this.b_Settings_Default.Name = "b_Settings_Default";
            this.b_Settings_Default.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Default.TabIndex = 14;
            this.b_Settings_Default.Text = "Default";
            this.b_Settings_Default.UseVisualStyleBackColor = true;
            this.b_Settings_Default.Click += new System.EventHandler(this.b_Settings_Default_Click);
            // 
            // b_Paths_sCBrowse
            // 
            this.b_Paths_sCBrowse.Location = new System.Drawing.Point(313, 43);
            this.b_Paths_sCBrowse.Name = "b_Paths_sCBrowse";
            this.b_Paths_sCBrowse.Size = new System.Drawing.Size(61, 22);
            this.b_Paths_sCBrowse.TabIndex = 13;
            this.b_Paths_sCBrowse.Text = "Browse";
            this.b_Paths_sCBrowse.UseVisualStyleBackColor = true;
            this.b_Paths_sCBrowse.Click += new System.EventHandler(this.b_Paths_sCBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Paths";
            // 
            // l_Paths_sCFolder
            // 
            this.l_Paths_sCFolder.AutoSize = true;
            this.l_Paths_sCFolder.Location = new System.Drawing.Point(10, 47);
            this.l_Paths_sCFolder.Name = "l_Paths_sCFolder";
            this.l_Paths_sCFolder.Size = new System.Drawing.Size(93, 13);
            this.l_Paths_sCFolder.TabIndex = 2;
            this.l_Paths_sCFolder.Text = "Screenshot Folder";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1659, 929);
            this.Controls.Add(this.tC_Main);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "SSUtility V2.0";
            ((System.ComponentModel.ISupportInitialize)(this.CamNoUpDown)).EndInit();
            this.tC_Main.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tC_Control.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gB_PlayerR_Extended.ResumeLayout(false);
            this.gB_PlayerR_Extended.PerformLayout();
            this.gB_PlayerL_Extended.ResumeLayout(false);
            this.gB_PlayerL_Extended.PerformLayout();
            this.gB_PlayerR_Simple.ResumeLayout(false);
            this.gB_PlayerR_Simple.PerformLayout();
            this.gB_PlayerL_Simple.ResumeLayout(false);
            this.gB_PlayerL_Simple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_PTZ_Speed)).EndInit();
            this.tC_Presets_Default.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tP_Settings.ResumeLayout(false);
            this.tP_Settings.PerformLayout();
            this.gB_Paths.ResumeLayout(false);
            this.gB_Paths.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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

        private TabControl tC_Main;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button b_PlayerL_Play;
        private TabControl tC_Control;
        private TabPage tabPage3;
        private TabPage tP_Settings;
        private Button b_PlayerL_PauseRec;
        private Button b_PlayerL_StartRec;
        private Button b_PlayerL_SaveSnap;
        private Button b_PTZ_Down;
        private Button b_PTZ_Up;
        private Button b_Presets_Daylight_AF;
        private Button b_PTZ_FocusNeg;
        private Button b_PTZ_ZoomNeg;
        private Button b_PTZ_FocusPos;
        private Button b_PTZ_ZoomPos;
        private Button b_PTZ_Right;
        private Button b_PTZ_Left;
        private Button b_Presets_Admin_SetupMen;
        private Button b_Presets_Admin_MechMen;
        private Button b_Presets_Admin_DebugToggle;
        private ComboBox cB_IPCon_Selected;
        public TextBox tB_IPCon_Port;
        public TextBox tB_IPCon_Adr;
        private Label l_IPCon_SelectedCam;
        private Label l_IPCon_Port;
        private Label l_IPCon_Adr;
        private Label l_IPCon;
        private CheckBox cB_IPCon_KeyboardCon;
        private Label l_IPCon_KeyControl;
        private Button b_Presets_Daylight_ColMono;
        private Button b_Presets_Daylight_Wiper;
        private Button b_Presets_Thermal_AF;
        private TabControl tC_Presets_Default;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private Button b_Presets_Thermal_ICENeg;
        private Button b_Presets_Thermal_ICE;
        private Button b_Presets_Thermal_WhiteBlack;
        private Button b_Presets_Daylight_Stabilizer;
        private Button b_Presets_Daylight_WDR;
        private Button b_Presets_Thermal_ICEPos;
        private Button button32;
        private Button button31;
        private Button b_Presets_Thermal_BrightPos;
        private Button b_Presets_Thermal_BrightNeg;
        private Button b_Presets_SLG_SteadyGreen;
        private Button b_Presets_SLG_FlashingWhite;
        private Button b_Presets_SLG_FlashingRed;
        private Button b_Presets_SLG_SteadyRed;
        private Button b_Presets_SLG_FlashingGreen;
        private Button b_Presets_SLG_AllLightsOff;
        private Button b_Presets_SLG_FlashingRG;
        private TabPage tabPage9;
        private Button b_Presets_Peak_SteadyLamp;
        private Button b_Presets_Peak_StopZoom;
        private Button b_Presets_Peak_ZoomOut;
        private Button b_Presets_Peak_ZoomIn;
        private Button b_Presets_Peak_LampOff;
        private Button b_Presets_Peak_StrobeLamp;
        private Button b_Presets_Thermal_NUC;
        private TextBox tB_Presets_Number;
        private Label l_Presets_Number;
        private Label l_Presets;
        private Label l_PTZCon;
        private Button b_Presets_Learn;
        private Button b_Presets_GoTo;
        private Label l_Presets_Default;
        private Button b_PlayerL_Detach;
        private ComboBox cB_IPCon_Type;
        private Label l_IPCon_ConType;
        private Button b_Presets_Admin_DefaultMen;
        private TrackBar tB_PTZ_Speed;
        private Label l_IPCon_Speed;
        private TabPage tabPage10;
        private Button b_Presets_CHARM_Standby;
        private Button b_Presets_CHARM_Aquire;
        public Label l_IPCon_Connected;
        private CheckBox checkB_PlayerL_Manual;
        private GroupBox gB_Paths;
        private Label l_Paths_sCFolder;
        private Label label1;
        private Button b_Paths_sCBrowse;
        private Button b_Settings_Apply;
        private Button b_Settings_Default;
        private Label l_Paths_sCCheck;
        private AxAXVLC.AxVLCPlugin2 VLCPlayer_L;
        private AxAXVLC.AxVLCPlugin2 VLCPlayer_R;
        private GroupBox gB_PlayerR_Extended;
        private Label label3;
        private Label label4;
        private TextBox tB_PlayerR_Adr;
        private Label label5;
        private TextBox tB_PlayerR_Port;
        private Label label6;
        private TextBox tB_PlayerR_RTSP;
        private Label label7;
        private TextBox tB_PlayerR_Username;
        private TextBox tB_PlayerR_Buffering;
        private Label label8;
        private Label label9;
        private TextBox tB_PlayerR_Password;
        private ComboBox cB_PlayerR_Type;
        private CheckBox checkB_PlayerR_Manual;
        private Button b_PlayerR_PauseRec;
        private Button b_PlayerR_StartRec;
        private Button b_PlayerR_SaveSnap;
        private Button b_PlayerR_Play;
        private GroupBox gB_PlayerR_Simple;
        private TextBox tB_PlayerR_SimpleAdr;
        private Label l_PlayerR_SimpleAdr;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private GroupBox gB_PlayerL_Simple;
        private TextBox tB_PlayerL_SimpleAdr;
        private Label l_PlayerL_SimpleAdr;
        public GroupBox gB_PlayerL_Extended;
        private Label l_PlayerL_Type;
        private Label l_PlayerL_RTSP;
        private TextBox tB_PlayerL_Adr;
        private Label l_PlayerL_Password;
        private TextBox tB_PlayerL_Port;
        private Label l_PlayerL_Port;
        private TextBox tB_PlayerL_RTSP;
        private Label l_PlayerL_Adr;
        private TextBox tB_PlayerL_Username;
        private TextBox tB_PlayerL_Buffering;
        private Label l_PlayerL_Username;
        private Label l_PlayerL_Buffering;
        private TextBox tB_PlayerL_Password;
        private ComboBox cB_PlayerL_Type;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public TextBox tB_Paths_sCFolder;
    } // end of partial class MainForm
} // end of namespace SSLUtility2
