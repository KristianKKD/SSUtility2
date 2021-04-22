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

namespace SSUtility2 {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.Menu_Window = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window_Detached = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window_PelcoD = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window_Response = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window_Osiris = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window_Presets = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Presets = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_CP = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Lite = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Keyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_ImportConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_ExportConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_StartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_Snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_EnableSecondary = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_PanZero = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Pan = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Tilt = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Final = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Final_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Main = new System.Windows.Forms.Panel();
            this.p_Control = new System.Windows.Forms.Panel();
            this.b_PTZ_Daylight = new System.Windows.Forms.Button();
            this.b_Open = new System.Windows.Forms.Button();
            this.b_PTZ_Thermal = new System.Windows.Forms.Button();
            this.Joystick = new Joystick.CentreStick();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.pB_Background = new System.Windows.Forms.PictureBox();
            this.sP_Player = new SPanel.SizeablePanel();
            this.MenuBar.SuspendLayout();
            this.p_Main.SuspendLayout();
            this.p_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Joystick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Background)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Window,
            this.Menu_Settings,
            this.Menu_Video,
            this.Menu_QC,
            this.Menu_Final});
            this.MenuBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1264, 24);
            this.MenuBar.TabIndex = 30;
            this.MenuBar.Text = "Menu";
            // 
            // Menu_Window
            // 
            this.Menu_Window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Window_Detached,
            this.Menu_Window_PelcoD,
            this.Menu_Window_Response,
            this.Menu_Window_Osiris,
            this.Menu_Window_Presets,
            this.Menu_Window_Settings});
            this.Menu_Window.Name = "Menu_Window";
            this.Menu_Window.Size = new System.Drawing.Size(63, 20);
            this.Menu_Window.Text = "Window";
            // 
            // Menu_Window_Detached
            // 
            this.Menu_Window_Detached.Name = "Menu_Window_Detached";
            this.Menu_Window_Detached.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_Detached.Text = "Detached Player";
            this.Menu_Window_Detached.Click += new System.EventHandler(this.Menu_Window_Detached_Click);
            // 
            // Menu_Window_PelcoD
            // 
            this.Menu_Window_PelcoD.Name = "Menu_Window_PelcoD";
            this.Menu_Window_PelcoD.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_PelcoD.Text = "Pelco D Scripting";
            this.Menu_Window_PelcoD.Click += new System.EventHandler(this.Menu_Window_PelcoD_Click);
            // 
            // Menu_Window_Response
            // 
            this.Menu_Window_Response.Name = "Menu_Window_Response";
            this.Menu_Window_Response.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_Response.Text = "Response Log";
            this.Menu_Window_Response.Click += new System.EventHandler(this.Menu_Window_Response_Click);
            // 
            // Menu_Window_Osiris
            // 
            this.Menu_Window_Osiris.Name = "Menu_Window_Osiris";
            this.Menu_Window_Osiris.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_Osiris.Text = "Osiris Control";
            this.Menu_Window_Osiris.Click += new System.EventHandler(this.Menu_Window_Osiris_Click);
            // 
            // Menu_Window_Presets
            // 
            this.Menu_Window_Presets.Name = "Menu_Window_Presets";
            this.Menu_Window_Presets.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_Presets.Text = "Preset Panel";
            this.Menu_Window_Presets.Click += new System.EventHandler(this.Menu_Window_Presets_Click);
            // 
            // Menu_Window_Settings
            // 
            this.Menu_Window_Settings.Name = "Menu_Window_Settings";
            this.Menu_Window_Settings.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_Settings.Text = "Open Settings";
            this.Menu_Window_Settings.Click += new System.EventHandler(this.Menu_Window_Settings_Click);
            // 
            // Menu_Settings
            // 
            this.Menu_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings_Open,
            this.Menu_Settings_Presets,
            this.Menu_Settings_Info,
            this.Menu_Settings_Custom,
            this.Menu_Settings_CP,
            this.Menu_Settings_Lite,
            this.Menu_Settings_Keyboard,
            this.Menu_Settings_ImportConfig,
            this.Menu_Settings_ExportConfig});
            this.Menu_Settings.Name = "Menu_Settings";
            this.Menu_Settings.Size = new System.Drawing.Size(63, 20);
            this.Menu_Settings.Text = "Settings";
            // 
            // Menu_Settings_Open
            // 
            this.Menu_Settings_Open.Name = "Menu_Settings_Open";
            this.Menu_Settings_Open.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_Open.Text = "Open Settings";
            this.Menu_Settings_Open.Click += new System.EventHandler(this.Menu_Settings_Open_Click);
            // 
            // Menu_Settings_Presets
            // 
            this.Menu_Settings_Presets.Name = "Menu_Settings_Presets";
            this.Menu_Settings_Presets.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_Presets.Text = "Enable Preset Panel";
            this.Menu_Settings_Presets.Click += new System.EventHandler(this.Menu_Settings_Presets_Click);
            // 
            // Menu_Settings_Info
            // 
            this.Menu_Settings_Info.Name = "Menu_Settings_Info";
            this.Menu_Settings_Info.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_Info.Text = "Enable Info Panel";
            this.Menu_Settings_Info.Visible = false;
            this.Menu_Settings_Info.Click += new System.EventHandler(this.Menu_Settings_Info_Click);
            // 
            // Menu_Settings_Custom
            // 
            this.Menu_Settings_Custom.Name = "Menu_Settings_Custom";
            this.Menu_Settings_Custom.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_Custom.Text = "Enable Custom Panel";
            this.Menu_Settings_Custom.Click += new System.EventHandler(this.Menu_Settings_Custom_Click);
            // 
            // Menu_Settings_CP
            // 
            this.Menu_Settings_CP.Name = "Menu_Settings_CP";
            this.Menu_Settings_CP.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_CP.Text = "Show PTZ Control Panel";
            this.Menu_Settings_CP.Click += new System.EventHandler(this.Menu_Settings_CP_Click);
            // 
            // Menu_Settings_Lite
            // 
            this.Menu_Settings_Lite.Name = "Menu_Settings_Lite";
            this.Menu_Settings_Lite.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_Lite.Text = "Lite Mode";
            this.Menu_Settings_Lite.Click += new System.EventHandler(this.Menu_Settings_Lite_Click);
            // 
            // Menu_Settings_Keyboard
            // 
            this.Menu_Settings_Keyboard.Name = "Menu_Settings_Keyboard";
            this.Menu_Settings_Keyboard.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_Keyboard.Text = "Enable PTZ Keyboard";
            this.Menu_Settings_Keyboard.Click += new System.EventHandler(this.Menu_Settings_Keyboard_Click);
            // 
            // Menu_Settings_ImportConfig
            // 
            this.Menu_Settings_ImportConfig.Name = "Menu_Settings_ImportConfig";
            this.Menu_Settings_ImportConfig.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_ImportConfig.Text = "Import Config File";
            this.Menu_Settings_ImportConfig.Click += new System.EventHandler(this.Menu_Settings_ImportConfig_Click);
            // 
            // Menu_Settings_ExportConfig
            // 
            this.Menu_Settings_ExportConfig.Name = "Menu_Settings_ExportConfig";
            this.Menu_Settings_ExportConfig.Size = new System.Drawing.Size(207, 22);
            this.Menu_Settings_ExportConfig.Text = "Export Config File";
            this.Menu_Settings_ExportConfig.Click += new System.EventHandler(this.Menu_Settings_ExportConfig_Click);
            // 
            // Menu_Video
            // 
            this.Menu_Video.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Video_Settings,
            this.Menu_Video_StartStop,
            this.Menu_Video_Snapshot,
            this.Menu_Video_Record,
            this.Menu_Video_EnableSecondary});
            this.Menu_Video.Name = "Menu_Video";
            this.Menu_Video.Size = new System.Drawing.Size(93, 20);
            this.Menu_Video.Text = "Video Stream";
            // 
            // Menu_Video_Settings
            // 
            this.Menu_Video_Settings.Name = "Menu_Video_Settings";
            this.Menu_Video_Settings.Size = new System.Drawing.Size(211, 22);
            this.Menu_Video_Settings.Text = "Connection Settings";
            this.Menu_Video_Settings.Click += new System.EventHandler(this.Menu_Video_Settings_Click);
            // 
            // Menu_Video_StartStop
            // 
            this.Menu_Video_StartStop.Name = "Menu_Video_StartStop";
            this.Menu_Video_StartStop.Size = new System.Drawing.Size(211, 22);
            this.Menu_Video_StartStop.Text = "Start Video Playback";
            this.Menu_Video_StartStop.Click += new System.EventHandler(this.Menu_Video_Stop_Click);
            // 
            // Menu_Video_Snapshot
            // 
            this.Menu_Video_Snapshot.Name = "Menu_Video_Snapshot";
            this.Menu_Video_Snapshot.Size = new System.Drawing.Size(211, 22);
            this.Menu_Video_Snapshot.Text = "Save Snapshot";
            this.Menu_Video_Snapshot.Click += new System.EventHandler(this.Menu_Video_Snapshot_Click);
            // 
            // Menu_Video_Record
            // 
            this.Menu_Video_Record.Name = "Menu_Video_Record";
            this.Menu_Video_Record.Size = new System.Drawing.Size(211, 22);
            this.Menu_Video_Record.Text = "Start Recording";
            this.Menu_Video_Record.Click += new System.EventHandler(this.Menu_Video_Record_Click);
            // 
            // Menu_Video_EnableSecondary
            // 
            this.Menu_Video_EnableSecondary.Name = "Menu_Video_EnableSecondary";
            this.Menu_Video_EnableSecondary.Size = new System.Drawing.Size(211, 22);
            this.Menu_Video_EnableSecondary.Text = "Enable Secondary Player";
            this.Menu_Video_EnableSecondary.Visible = false;
            this.Menu_Video_EnableSecondary.Click += new System.EventHandler(this.Menu_Video_EnableSecondary_Click);
            // 
            // Menu_QC
            // 
            this.Menu_QC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_QC_Custom,
            this.Menu_QC_PanZero,
            this.Menu_QC_Pan,
            this.Menu_QC_Tilt});
            this.Menu_QC.Name = "Menu_QC";
            this.Menu_QC.Size = new System.Drawing.Size(117, 20);
            this.Menu_QC.Text = "Quick Commands";
            // 
            // Menu_QC_Custom
            // 
            this.Menu_QC_Custom.Name = "Menu_QC_Custom";
            this.Menu_QC_Custom.Size = new System.Drawing.Size(209, 22);
            this.Menu_QC_Custom.Text = "Enter Custom Command";
            this.Menu_QC_Custom.Click += new System.EventHandler(this.Menu_QC_Custom_Click);
            // 
            // Menu_QC_PanZero
            // 
            this.Menu_QC_PanZero.Name = "Menu_QC_PanZero";
            this.Menu_QC_PanZero.Size = new System.Drawing.Size(209, 22);
            this.Menu_QC_PanZero.Text = "Set Pan = 0";
            this.Menu_QC_PanZero.Click += new System.EventHandler(this.Menu_QC_PanZero_Click);
            // 
            // Menu_QC_Pan
            // 
            this.Menu_QC_Pan.Name = "Menu_QC_Pan";
            this.Menu_QC_Pan.Size = new System.Drawing.Size(209, 22);
            this.Menu_QC_Pan.Text = "Quick Pan";
            this.Menu_QC_Pan.Click += new System.EventHandler(this.Menu_QC_Pan_Click);
            // 
            // Menu_QC_Tilt
            // 
            this.Menu_QC_Tilt.Name = "Menu_QC_Tilt";
            this.Menu_QC_Tilt.Size = new System.Drawing.Size(209, 22);
            this.Menu_QC_Tilt.Text = "Quick TIlt";
            this.Menu_QC_Tilt.Click += new System.EventHandler(this.Menu_QC_Tilt_Click);
            // 
            // Menu_Final
            // 
            this.Menu_Final.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Final_Open});
            this.Menu_Final.Name = "Menu_Final";
            this.Menu_Final.Size = new System.Drawing.Size(107, 20);
            this.Menu_Final.Text = "Final Test Mode";
            // 
            // Menu_Final_Open
            // 
            this.Menu_Final_Open.Name = "Menu_Final_Open";
            this.Menu_Final_Open.Size = new System.Drawing.Size(113, 22);
            this.Menu_Final_Open.Text = "Open...";
            this.Menu_Final_Open.Click += new System.EventHandler(this.Menu_Final_Open_Click);
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.p_Control);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 24);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(1264, 657);
            this.p_Main.TabIndex = 31;
            // 
            // p_Control
            // 
            this.p_Control.BackColor = System.Drawing.Color.Black;
            this.p_Control.Controls.Add(this.b_PTZ_Daylight);
            this.p_Control.Controls.Add(this.b_Open);
            this.p_Control.Controls.Add(this.b_PTZ_Thermal);
            this.p_Control.Controls.Add(this.Joystick);
            this.p_Control.Controls.Add(this.b_PTZ_Left);
            this.p_Control.Controls.Add(this.b_PTZ_Right);
            this.p_Control.Controls.Add(this.b_PTZ_Down);
            this.p_Control.Controls.Add(this.b_PTZ_Up);
            this.p_Control.Controls.Add(this.b_PTZ_FocusNeg);
            this.p_Control.Controls.Add(this.b_PTZ_ZoomNeg);
            this.p_Control.Controls.Add(this.b_PTZ_FocusPos);
            this.p_Control.Controls.Add(this.b_PTZ_ZoomPos);
            this.p_Control.Controls.Add(this.pB_Background);
            this.p_Control.Controls.Add(this.sP_Player);
            this.p_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Control.Location = new System.Drawing.Point(0, 0);
            this.p_Control.Name = "p_Control";
            this.p_Control.Size = new System.Drawing.Size(1264, 657);
            this.p_Control.TabIndex = 1;
            // 
            // b_PTZ_Daylight
            // 
            this.b_PTZ_Daylight.BackColor = System.Drawing.Color.Silver;
            this.b_PTZ_Daylight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Daylight.Location = new System.Drawing.Point(160, 284);
            this.b_PTZ_Daylight.Name = "b_PTZ_Daylight";
            this.b_PTZ_Daylight.Size = new System.Drawing.Size(58, 30);
            this.b_PTZ_Daylight.TabIndex = 98;
            this.b_PTZ_Daylight.Text = "Daylight";
            this.b_PTZ_Daylight.UseVisualStyleBackColor = false;
            this.b_PTZ_Daylight.Visible = false;
            this.b_PTZ_Daylight.Click += new System.EventHandler(this.b_PTZ_Daylight_Click);
            // 
            // b_Open
            // 
            this.b_Open.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.b_Open.ForeColor = System.Drawing.SystemColors.Control;
            this.b_Open.Location = new System.Drawing.Point(0, 0);
            this.b_Open.Name = "b_Open";
            this.b_Open.Size = new System.Drawing.Size(50, 50);
            this.b_Open.TabIndex = 1;
            this.b_Open.Text = ">>";
            this.b_Open.UseVisualStyleBackColor = false;
            this.b_Open.Visible = false;
            this.b_Open.Click += new System.EventHandler(this.b_Open_Click);
            // 
            // b_PTZ_Thermal
            // 
            this.b_PTZ_Thermal.BackColor = System.Drawing.Color.Silver;
            this.b_PTZ_Thermal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Thermal.Location = new System.Drawing.Point(68, 284);
            this.b_PTZ_Thermal.Name = "b_PTZ_Thermal";
            this.b_PTZ_Thermal.Size = new System.Drawing.Size(58, 30);
            this.b_PTZ_Thermal.TabIndex = 97;
            this.b_PTZ_Thermal.Text = "Thermal";
            this.b_PTZ_Thermal.UseVisualStyleBackColor = false;
            this.b_PTZ_Thermal.Visible = false;
            this.b_PTZ_Thermal.Click += new System.EventHandler(this.b_PTZ_Thermal_Click);
            // 
            // Joystick
            // 
            this.Joystick.BackColor = System.Drawing.Color.Black;
            this.Joystick.Location = new System.Drawing.Point(118, 142);
            this.Joystick.Name = "Joystick";
            this.Joystick.Size = new System.Drawing.Size(50, 50);
            this.Joystick.TabIndex = 90;
            this.Joystick.TabStop = false;
            this.Joystick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Joystick_MouseUp);
            // 
            // b_PTZ_Left
            // 
            this.b_PTZ_Left.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_PTZ_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Left.Location = new System.Drawing.Point(12, 151);
            this.b_PTZ_Left.Name = "b_PTZ_Left";
            this.b_PTZ_Left.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_Left.TabIndex = 95;
            this.b_PTZ_Left.Text = "Left";
            this.b_PTZ_Left.UseVisualStyleBackColor = false;
            this.b_PTZ_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Left_MouseDown);
            this.b_PTZ_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Right
            // 
            this.b_PTZ_Right.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_PTZ_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Right.Location = new System.Drawing.Point(224, 151);
            this.b_PTZ_Right.Name = "b_PTZ_Right";
            this.b_PTZ_Right.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_Right.TabIndex = 94;
            this.b_PTZ_Right.Text = "Right";
            this.b_PTZ_Right.UseVisualStyleBackColor = false;
            this.b_PTZ_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Right_MouseDown);
            this.b_PTZ_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Down
            // 
            this.b_PTZ_Down.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_PTZ_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Down.Location = new System.Drawing.Point(118, 248);
            this.b_PTZ_Down.Name = "b_PTZ_Down";
            this.b_PTZ_Down.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_Down.TabIndex = 93;
            this.b_PTZ_Down.Text = "Down";
            this.b_PTZ_Down.UseVisualStyleBackColor = false;
            this.b_PTZ_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Down_MouseDown);
            this.b_PTZ_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Up
            // 
            this.b_PTZ_Up.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_PTZ_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Up.Location = new System.Drawing.Point(118, 56);
            this.b_PTZ_Up.Name = "b_PTZ_Up";
            this.b_PTZ_Up.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_Up.TabIndex = 92;
            this.b_PTZ_Up.Text = "Up";
            this.b_PTZ_Up.UseVisualStyleBackColor = false;
            this.b_PTZ_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Up_MouseDown);
            this.b_PTZ_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusNeg
            // 
            this.b_PTZ_FocusNeg.BackColor = System.Drawing.Color.YellowGreen;
            this.b_PTZ_FocusNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_FocusNeg.Location = new System.Drawing.Point(12, 248);
            this.b_PTZ_FocusNeg.Name = "b_PTZ_FocusNeg";
            this.b_PTZ_FocusNeg.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_FocusNeg.TabIndex = 89;
            this.b_PTZ_FocusNeg.Text = "F-";
            this.b_PTZ_FocusNeg.UseVisualStyleBackColor = false;
            this.b_PTZ_FocusNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusNeg_MouseDown);
            this.b_PTZ_FocusNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_ZoomNeg
            // 
            this.b_PTZ_ZoomNeg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_ZoomNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_ZoomNeg.Location = new System.Drawing.Point(224, 248);
            this.b_PTZ_ZoomNeg.Name = "b_PTZ_ZoomNeg";
            this.b_PTZ_ZoomNeg.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_ZoomNeg.TabIndex = 88;
            this.b_PTZ_ZoomNeg.Text = "Z-";
            this.b_PTZ_ZoomNeg.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomNeg_MouseDown);
            this.b_PTZ_ZoomNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusPos
            // 
            this.b_PTZ_FocusPos.BackColor = System.Drawing.Color.YellowGreen;
            this.b_PTZ_FocusPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_FocusPos.Location = new System.Drawing.Point(12, 56);
            this.b_PTZ_FocusPos.Name = "b_PTZ_FocusPos";
            this.b_PTZ_FocusPos.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_FocusPos.TabIndex = 87;
            this.b_PTZ_FocusPos.Text = "F+";
            this.b_PTZ_FocusPos.UseVisualStyleBackColor = false;
            this.b_PTZ_FocusPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusPos_MouseDown);
            this.b_PTZ_FocusPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_ZoomPos
            // 
            this.b_PTZ_ZoomPos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_ZoomPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_ZoomPos.Location = new System.Drawing.Point(224, 56);
            this.b_PTZ_ZoomPos.Name = "b_PTZ_ZoomPos";
            this.b_PTZ_ZoomPos.Size = new System.Drawing.Size(50, 30);
            this.b_PTZ_ZoomPos.TabIndex = 86;
            this.b_PTZ_ZoomPos.Text = "Z+";
            this.b_PTZ_ZoomPos.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomPos_MouseDown);
            this.b_PTZ_ZoomPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // pB_Background
            // 
            this.pB_Background.BackColor = System.Drawing.SystemColors.Highlight;
            this.pB_Background.Location = new System.Drawing.Point(68, 92);
            this.pB_Background.Name = "pB_Background";
            this.pB_Background.Size = new System.Drawing.Size(150, 150);
            this.pB_Background.TabIndex = 91;
            this.pB_Background.TabStop = false;
            // 
            // sP_Player
            // 
            this.sP_Player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sP_Player.BackColor = System.Drawing.Color.Black;
            this.sP_Player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sP_Player.Location = new System.Drawing.Point(850, 15);
            this.sP_Player.Name = "sP_Player";
            this.sP_Player.Size = new System.Drawing.Size(400, 250);
            this.sP_Player.TabIndex = 2;
            this.sP_Player.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSUtility V2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.p_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Joystick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //this.tC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
        //this.tC_Main.Size = new System.Drawing.Size(1659, 905);

        //      /*
        //       * Created by SharpDevelop.
        //       * User: Alistair
        //       * Date: 17/03/2018
        //       * Time: 16:58
        //       * 
        //       * To change this template use Tools | Options | Coding | Edit Standard Headers.
        //       */
        //      /*
        //       * Based on ManagePTZ2 by Alistair Windram, with amendments by Filip Ionita
        //       * Form layout modelled on SSUTILITY Firmware tab for continuity
        //       */
        //      #region Firmware Stuff
        //      public static byte Address;
        //      public static byte CheckSum;
        //      public static byte Command1, Command2, Data1, Data2;
        //      //private readonly byte STX = 0xFF;
        //      public int camno = 1;   // Default camera number (1 for now)
        //      public bool camisthere = false; // True if camera has replied to SSCP query
        //      public int waitval = 0; // Wait n millisecs before sending next protocol packet
        //      public int waitresponseval = 0; // Wait for n bytes of response packet
        //      public int readtimeout = 1000;  // Standard read timeout of 1000 millisecs (see #Port.ReadTimeout:n)
        //      public int[] rawbuf = new int[80];  // Buffer for current protocol line
        //      public int rawlen;  // Length of current protocol line
        //      public long whencmdsent;    // Stopwatch value when last command was sent
        //      public int replylen = 0;    // Length of last serial port reply (in bytes)
        //      public byte[] replybuf = new byte[128]; // Buffer for serial port replies
        //      public string replyerrmsg;  // Last reply error
        //      public string hexfilefilename;  // Filename of current hex file
        //      public string hexfilesafefilename;  // Safe filename of current hex file
        //      public string hexfilepath;  // Path to current hex file
        //      public string hexfilefilter;    // Filter for current hex file types
        //      public string[] hexfilelines;   // Content of hex file
        //      public int hexfileformat = 1;   // Expected is encrypted (1); alternative is unencrypted (0)
        //      public int hexfilestartaddress = 0x8000;    // Expected start address
        //      public int hexfileendaddress = 0x8000;  // Expected much bigger than this
        //      public int hexfilelength = 0;   // Expected non-zero
        //      public int hexfilenblocks = 0;  // Number of blocks in hex file
        //      public int currentblock = 0;    // Current block being transferred
        //      public uint hexfiledatachecksum = 0;    // Gets checksum of hex file data (assuming unencrypted)
        //      public string hexfilechecksum;
        //      public bool loadit = false; // Firmware upload is not running
        //      public bool pauseit = false;     //Pause upload
        //      public bool EscapeWasPressed = false;   // Whether Escape was pressed during firmware upload
        //      public Stopwatch mystopwatch1;  //Run Script Stopwatch
        //      public Stopwatch mystopwatch2;  //Pause Script Sto
        //      public string cts;      //CurrentTimeStamp
        //      public bool debugSSCP = false;
        //      public bool isactive = false;   // true if we have an active main firmware, false if not
        //                                      //string oldroline; 		// Temp buffer saver
        //      static readonly uint[] crc_table = new uint[256] {
        //          0x00, 0x25, 0x4A, 0x6F, 0x94, 0xB1, 0xDE, 0xFB,
        //          0x0D, 0x28, 0x47, 0x62, 0x99, 0xBC, 0xD3, 0xF6,
        //          0x1A, 0x3F, 0x50, 0x75, 0x8E, 0xAB, 0xC4, 0xE1,
        //          0x17, 0x32, 0x5D, 0x78, 0x83, 0xA6, 0xC9, 0xEC,
        //          0x34, 0x11, 0x7E, 0x5B, 0xA0, 0x85, 0xEA, 0xCF,
        //          0x39, 0x1C, 0x73, 0x56, 0xAD, 0x88, 0xE7, 0xC2,
        //          0x2E, 0x0B, 0x64, 0x41, 0xBA, 0x9F, 0xF0, 0xD5,
        //          0x23, 0x06, 0x69, 0x4C, 0xB7, 0x92, 0xFD, 0xD8,
        //          0x68, 0x4D, 0x22, 0x07, 0xFC, 0xD9, 0xB6, 0x93,
        //          0x65, 0x40, 0x2F, 0x0A, 0xF1, 0xD4, 0xBB, 0x9E,
        //          0x72, 0x57, 0x38, 0x1D, 0xE6, 0xC3, 0xAC, 0x89,
        //          0x7F, 0x5A, 0x35, 0x10, 0xEB, 0xCE, 0xA1, 0x84,
        //          0x5C, 0x79, 0x16, 0x33, 0xC8, 0xED, 0x82, 0xA7,
        //          0x51, 0x74, 0x1B, 0x3E, 0xC5, 0xE0, 0x8F, 0xAA,
        //          0x46, 0x63, 0x0C, 0x29, 0xD2, 0xF7, 0x98, 0xBD,
        //          0x4B, 0x6E, 0x01, 0x24, 0xDF, 0xFA, 0x95, 0xB0,
        //          0xD0, 0xF5, 0x9A, 0xBF, 0x44, 0x61, 0x0E, 0x2B,
        //          0xDD, 0xF8, 0x97, 0xB2, 0x49, 0x6C, 0x03, 0x26,
        //          0xCA, 0xEF, 0x80, 0xA5, 0x5E, 0x7B, 0x14, 0x31,
        //          0xC7, 0xE2, 0x8D, 0xA8, 0x53, 0x76, 0x19, 0x3C,
        //          0xE4, 0xC1, 0xAE, 0x8B, 0x70, 0x55, 0x3A, 0x1F,
        //          0xE9, 0xCC, 0xA3, 0x86, 0x7D, 0x58, 0x37, 0x12,
        //          0xFE, 0xDB, 0xB4, 0x91, 0x6A, 0x4F, 0x20, 0x05,
        //          0xF3, 0xD6, 0xB9, 0x9C, 0x67, 0x42, 0x2D, 0x08,
        //          0xB8, 0x9D, 0xF2, 0xD7, 0x2C, 0x09, 0x66, 0x43,
        //          0xB5, 0x90, 0xFF, 0xDA, 0x21, 0x04, 0x6B, 0x4E,
        //          0xA2, 0x87, 0xE8, 0xCD, 0x36, 0x13, 0x7C, 0x59,
        //          0xAF, 0x8A, 0xE5, 0xC0, 0x3B, 0x1E, 0x71, 0x54,
        //          0x8C, 0xA9, 0xC6, 0xE3, 0x18, 0x3D, 0x52, 0x77,
        //          0x81, 0xA4, 0xCB, 0xEE, 0x15, 0x30, 0x5F, 0x7A,
        //          0x96, 0xB3, 0xDC, 0xF9, 0x02, 0x27, 0x48, 0x6D,
        //          0x9B, 0xBE, 0xD1, 0xF4, 0x0F, 0x2A, 0x45, 0x60
        //          };



        public MainForm() {
            InitializeComponent();
            StartupStuff();

            ////
            //// TODO: Add constructor code after the InitializeComponent() call.
            ////
            //string[] stdspeeds = { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            //string[] loadspeeds = { "9600", "19200", "38400", "57600", "115200", "230400" };

            //int i;
            //for (i = 0; i < 7; i++) {
            //    this.SpeedcomboBox.Items.Add(stdspeeds[i]);
            //}
            //this.SpeedcomboBox.SelectedIndex = 2;   // Default contact speed is 9600
            //for (i = 0; i < 6; i++) {
            //    this.LoadSpeedcomboBox.Items.Add(loadspeeds[i]);
            //}
            //this.LoadSpeedcomboBox.SelectedIndex = 3;   // Default load speed is 57600
            //                                            //foreach (String portName in System.IO.Ports.SerialPort.GetPortNames()) {
            //                                            //	this.PortcomboBox.Items.Add(portName);
            //                                            //}
            //                                            //this.PortcomboBox.SelectedIndex = 0;
            //mystopwatch1 = System.Diagnostics.Stopwatch.StartNew(); // Get stopwatch object and init and start
        }

        private void MainForm_Closing(Object sender, FormClosingEventArgs e) {
            //if (this.serialPort1.IsOpen) {
            //    this.serialPort1.Close();
            //    //System.Windows.Forms.MessageBox.Show("Closed Serial Port on Application Finish");
            //}
        }

        //      private int SSCPChecksum(byte[] cmd, int len) {
        //          int i;
        //          int rv = 0;
        //          if (len < 3 || cmd[0] != 0x02 || cmd[len - 1] != 0x03)
        //              return rv;
        //          for (i = 1; i < len - 1; i++) {
        //              rv = (int)crc_table[rv ^ (int)cmd[i]];
        //          }
        //          return rv;
        //      } // end of SSCPChecksum()

        //      private int Char2Hex(char c) {
        //          int rv;
        //          rv = "0123456789ABCDEF".IndexOf(Char.ToUpper(c));
        //          return rv;
        //      }

        //      private int HexByte(char c1, char c2) {
        //          int rv;
        //          rv = Char2Hex(c1) * 16 + Char2Hex(c2);
        //          return rv;
        //      } // end of HexByte()

        //      private int SSCPHexValue(int start, int length) {
        //          int rv = 0;
        //          int i;
        //          length += start;
        //          for (i = start; i < length; i++)
        //              rv = (rv << 4) + Char2Hex((char)replybuf[i]);
        //          return rv;
        //      } // end of SSCPHexValue()

        //      private void escapeProtocol() {
        //          var tmpbytearray = new byte[] { Convert.ToByte(27) };
        //          this.serialPort1.Write(tmpbytearray, 0, 1); // Write Esc
        //          System.Threading.Thread.Sleep(1000);
        //      } // end of escapeProtocol()

        //      private int sendSSCP(byte cmd1, byte cmd2, string data, bool expectreply, int discardto, int sendto, int ackto, int replyto) {
        //          string tpkt;
        //          string tcmd1;
        //          string tcksum;
        //          int tpktlen;
        //          int ms2send;
        //          int rv = -1;    // Default result is Fail code
        //          int i;
        //          int j;
        //          int timeout = 0;    // variable timeout wherever needed
        //          int retries = 5;    // 5 retries
        //          int ret = 0;
        //          int tnb = 0;
        //          int nb = 0;
        //          long tt;        // Total ms that this stage took
        //          if (cmd1 != 0)
        //              tcmd1 = cmd1.ToString("X2");
        //          else
        //              tcmd1 = "";
        //          camno = (int)this.CamNoUpDown.Value;    // Remember current camera number
        //                                                  // *** 27-Apr-2018 We now implement 300ms timeout and 5 retries
        //          if (!this.serialPort1.IsOpen)
        //              return rv;
        //          // Format SSCP packet and calc checksum
        //          tpkt = "\x02" + camno.ToString("X2") + tcmd1 + cmd2.ToString("X2") + data + "\x03";
        //          byte[] btpkt = System.Text.Encoding.UTF8.GetBytes(tpkt);
        //          tpktlen = btpkt.Length + 2; // How many bytes in packet
        //          tcksum = SSCPChecksum(btpkt, btpkt.Length).ToString("X2");
        //          ms2send = (tpktlen * 9600) / this.serialPort1.BaudRate + 1; // Estimate how many ms to send packet
        //                                                                      // For first attempt just discard for 5 ms; for remaining tries discard for discardto ms
        //          timeout = 5;
        //          for (ret = 0; ret < retries; ret++) {
        //              // Discard anything in port receive buffer for up to discardto ms
        //              if (debugSSCP) {
        //                  nb = ret + 1;
        //                  this.LogtextBox.AppendText("SSCP attempt " + nb.ToString() + Environment.NewLine);
        //              }
        //              this.mystopwatch1.Restart();
        //              tnb = 0;    // How many bytes were discarded
        //              while (this.mystopwatch1.ElapsedMilliseconds < timeout) {
        //                  nb = this.serialPort1.BytesToRead;
        //                  if (nb > 0) {
        //                      tnb = tnb + nb; // Count bytes discarded
        //                      this.serialPort1.ReadExisting();
        //                  }
        //              }
        //              this.mystopwatch1.Stop();
        //              if (debugSSCP && tnb > 0) {
        //                  this.LogtextBox.AppendText(ret.ToString() + ": SSCP discarded " + tnb.ToString() + " bytes" + Environment.NewLine);
        //              }
        //              // Write SSCP packet
        //              this.serialPort1.Write(tpkt);
        //              // Show SSCP sent packet in Log pane
        //              if (debugSSCP) {
        //                  this.LogtextBox.AppendText("SSCP sent ");
        //                  for (i = 0; i < btpkt.Length; i++) {
        //                      j = btpkt[i];
        //                      if (j < 33 || j > 126)
        //                          this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
        //                      else
        //                          this.LogtextBox.AppendText(((char)j).ToString());
        //                  }
        //                  //this.serialPort1.Write(SSCPChecksum(btpkt,btpkt.Length).ToString("X2"));
        //                  this.LogtextBox.AppendText(tcksum + Environment.NewLine);
        //              }
        //              this.serialPort1.Write(tcksum);
        //              // Wait for ms2send ms for packet to go
        //              this.mystopwatch1.Restart();
        //              while (this.mystopwatch1.ElapsedMilliseconds < ms2send) {
        //              }
        //              tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
        //              this.mystopwatch1.Stop();
        //              this.mystopwatch1.Restart();
        //              while (this.mystopwatch1.ElapsedMilliseconds < sendto) {
        //                  if (this.serialPort1.BytesToWrite < 2)
        //                      break;
        //              }
        //              tt = tt + this.mystopwatch1.ElapsedMilliseconds;    // How long it took overall
        //              this.mystopwatch1.Stop();
        //              nb = this.serialPort1.BytesToWrite;
        //              if (nb > 1) { // Failed to write packet within allowed time
        //                  if (debugSSCP) {
        //                      this.LogtextBox.AppendText("Write not finished after " + sendto.ToString() + "ms; " + nb.ToString() + " bytes to go" + Environment.NewLine);
        //                  }
        //                  continue;   // Failed to write the packet within sendto ms
        //              } else {
        //                  if (debugSSCP) {
        //                      this.LogtextBox.AppendText("Write took " + tt.ToString() + "ms" + Environment.NewLine);
        //                  }
        //              }
        //              // Now we need to wait for a reply (maybe)
        //              // If we do not get a protocol packet we should get Ack or Nak
        //              replylen = 0;   // Clear reply buffer
        //              replyerrmsg = null; // Clear reply error message
        //                                  //while (replylen < 1) {
        //                                  //	try {
        //                                  //		replylen = this.serialPort1.Read(replybuf,0,1);
        //                                  //	}
        //                                  //	catch (TimeoutException ex)
        //                                  //	{
        //                                  //		replyerrmsg = ex.Message;
        //                                  //		break;
        //                                  //	}
        //                                  //} // end of while waiting for 1st reply char
        //                                  // We now use a stopwatch and expect a byte to return within ackto ms
        //              this.mystopwatch1.Restart();
        //              replybuf[0] = 0;    // Init 1st byte of replybuf to 0 meaning no reply
        //              while (this.mystopwatch1.ElapsedMilliseconds < ackto) {
        //                  if (this.serialPort1.BytesToRead > 0) {
        //                      replybuf[0] = (byte)this.serialPort1.ReadByte();
        //                      replylen = 1;
        //                      break;
        //                  }
        //              }
        //              tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
        //              this.mystopwatch1.Stop();
        //              // Fake reply
        //              //if (cmd2==0)
        //              //{ // Fake Boot Loader version response
        //              //	tpkt = "\x02" + camno.ToString("X2") + "FF00no boot loader" + "\x03" + "AB";
        //              //}
        //              //else
        //              //{ // Fake Serial Number response
        //              //	tpkt = "\x02" + camno.ToString("X2") + "FF" + cmd2.ToString("X2") + "01023456" + "\x03" + "CD";
        //              //}
        //              //replybuf = System.Text.Encoding.UTF8.GetBytes(tpkt);
        //              //replylen = replybuf.Length;
        //              if (debugSSCP) { // We either have nothing or 1 byte
        //                  this.LogtextBox.AppendText("SSCP rcvd ");
        //                  if (replylen < 1)
        //                      this.LogtextBox.AppendText("nothing after " + tt.ToString() + "ms" + Environment.NewLine);
        //                  else {
        //                      j = replybuf[0];
        //                      if (j < 33 || j > 126)
        //                          this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
        //                      else
        //                          this.LogtextBox.AppendText(((char)j).ToString());
        //                      this.LogtextBox.AppendText(" after " + tt.ToString() + "ms" + Environment.NewLine);
        //                  }
        //              }
        //              //return 0;
        //              // Did we get a reply or did we time out??
        //              //if (replylen < 1)	return rv;	// Failed to get reply
        //              if (replylen < 1)
        //                  continue; // Failed to get reply
        //              rv = replybuf[0];
        //              if (rv == 2) {
        //                  rv = 0; // No Ack or Nak but got reply packet - leave Stx at start
        //              } else {
        //                  replylen = 0;   // Lose Ack or Nak from buffer but we will return its code
        //              }
        //              // If we saw a Stx we try to read a reply packet (whether or not we were expecting one
        //              if (replylen == 0 && !expectreply)
        //                  return rv;
        //              //while (replylen < 128) {
        //              //	try {
        //              //		replylen = replylen + this.serialPort1.Read(replybuf,replylen,128-replylen);
        //              //		// We now call a halt if we have Etx as 3rd last char in replybuf[]
        //              //		if (replylen>7 && replybuf[replylen-3]==0x03)	break;
        //              //	}
        //              //	catch (TimeoutException ex)
        //              //	{
        //              //		replyerrmsg = ex.Message;
        //              //		break;
        //              //	}
        //              //}
        //              // We now use a stopwatch and expect a reply to return within replyto ms
        //              this.mystopwatch1.Restart();
        //              while (this.mystopwatch1.ElapsedMilliseconds < replyto) {
        //                  if (this.serialPort1.BytesToRead > 0) {
        //                      replybuf[replylen] = (byte)this.serialPort1.ReadByte(); // Read 1 byte at a time
        //                      replylen++;
        //                      // We now call a halt if we have Etx as 3rd last char in replybuf[]
        //                      if (replylen > 7 && replybuf[replylen - 3] == 0x03)
        //                          break;
        //                  }
        //              }
        //              tt = this.mystopwatch1.ElapsedMilliseconds; // How long it took
        //              this.mystopwatch1.Stop();
        //              if (debugSSCP) {
        //                  this.LogtextBox.AppendText("SSCP rcvd ");
        //                  if (replylen < 1)
        //                      this.LogtextBox.AppendText("nothing after " + tt.ToString() + "ms" + Environment.NewLine);
        //                  else {
        //                      for (i = 0; i < replylen; i++) {
        //                          j = replybuf[i];
        //                          if (j < 33 || j > 126)
        //                              this.LogtextBox.AppendText("<" + j.ToString("X2") + ">");
        //                          else
        //                              this.LogtextBox.AppendText(((char)j).ToString());
        //                      }
        //                      this.LogtextBox.AppendText(Environment.NewLine);
        //                      this.LogtextBox.AppendText(" Reply took " + tt.ToString() + "ms" + Environment.NewLine);
        //                  }
        //              }
        //              if (replylen < 8 || replybuf[replylen - 3] != 0x03)
        //                  rv = -1;
        //              if (rv == 6 || (expectreply && rv == 0))
        //                  return rv;
        //              timeout = discardto;    // We will use this timeout for discard next time
        //          } // end of for (ret=0;... trying up to 5 times
        //          return rv;
        //      } // end of sendSSCP()

        //      private int ClassifyFWLine(string roline) { // Return line type byte value (0-3 or 9) or -1 if not recognised
        //                                                  //string sline;
        //          int rv = -1;
        //          int datalen;
        //          int linetype;
        //          if (String.IsNullOrWhiteSpace(roline))
        //              return (rv); // Blank line
        //          if (roline[0] != ':')
        //              return (rv);      // Bad start
        //          if (roline.Length < 11)
        //              return (rv);    // Too short
        //          datalen = HexByte(roline[1], roline[2]);
        //          linetype = HexByte(roline[7], roline[8]);
        //          //if (roline.Length != (datalen + datalen + 11))	return(rv);	// Wrong length
        //          rv = linetype;
        //          return (rv);    // Return line type
        //      } // end of ClassifyFWLine()

        //      private string gethexfilelinedata(int addr) { // Given code address of start of line, return substring of code line that contains code
        //                                                    // If we reach a non-code line at end of file, return an empty string
        //          int n;  // This will be the index in hexfilelines[] of the relevant code line
        //          string s;   // This will get the return substring
        //          n = (addr >> 4) + (addr >> 16) - 0x800;
        //          if (hexfilelines[n].Substring(0, 3) == ":10")
        //              s = hexfilelines[n].Substring(9, 32);
        //          else
        //              s = "";
        //          return s;
        //      } // end of gethexfilelinedata()

        //      private bool WriteFromBuffer(int addr, int length, int destaddr) {
        //          string s;
        //          int rv = -1;
        //          int i = 0;
        //          bool brv;
        //          statusStrip1.Show();
        //          // Keep buttons refreshed
        //          Application.DoEvents();
        //          while (i < length && !EscapeWasPressed) { // Transfer another 16 bytes of the current 4096 byte block
        //                                                    // Build next 16-byte line
        //              s = gethexfilelinedata(addr + i);
        //              if (s.Length == 0) { // Reached end of file - fake that last block was sent OK
        //                                   // Update status bar with progress
        //                  this.toolStripStatusLabel5.Text = "Off end of file";
        //                  this.statusStrip1.Refresh();
        //                  i = length;
        //                  rv = 0;
        //                  break;
        //              }
        //              s = destaddr.ToString("X4") + "10" + gethexfilelinedata(addr + i);
        //              // Update status bar with progress
        //              this.toolStripStatusLabel3.Text = i.ToString() + "/" + length.ToString();
        //              this.statusStrip1.Refresh();
        //              rv = sendSSCP((byte)0x7F, (byte)2, s, true, 300, 40, 50, 100);
        //              i += 16;
        //              destaddr += 16;
        //              // Break out if not Ack or just reply
        //              if (rv != 0 && rv != 6)
        //                  break;
        //              // Keep buttons refreshed
        //              Application.DoEvents();
        //          } // end of while (i<length && ...
        //            // Now, if Abort button was pressed, just say Upload aborted
        //          if (EscapeWasPressed) {
        //              this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + "Upload aborted." + Environment.NewLine);
        //              brv = false;
        //          } else if (i >= length && (rv == 0 || rv == 6)) {
        //              this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + i.ToString() + " bytes transferred." + Environment.NewLine);
        //              brv = true;
        //          } else {
        //              this.LogtextBox.AppendText("Block " + currentblock.ToString() + ": " + "Failed after " + i.ToString() + " bytes of " + length.ToString() + Environment.NewLine);
        //              brv = false;
        //          }
        //          this.toolStripStatusLabel3.Text = "";
        //          this.statusStrip1.Refresh();
        //          return brv;
        //      } // end of WriteFromBuffer()

        //      private int WriteToFlash(int addr, int length) {
        //          string s;
        //          int rv;
        //          this.LogtextBox.AppendText("Flashed at " + addr.ToString("X5"));
        //          addr = addr >> 3;
        //          s = addr.ToString("X4") + length.ToString("X4");
        //          // Send Write To Flash message
        //          rv = sendSSCP((byte)0x7F, (byte)3, s, true, 100, 20, 500, 500);
        //          if ((rv == 0 || rv == 6) && replylen > 9)
        //              rv = HexByte((char)replybuf[7], (char)replybuf[8]);
        //          else
        //              rv = -1;
        //          this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
        //          return rv;
        //      } // end of WriteToFlash()

        //      private int EraseFlash(int addr, int length) {
        //          string s;
        //          int rv;
        //          length = addr + length;
        //          this.LogtextBox.AppendText("Erased " + addr.ToString("X5") + " to " + length.ToString("X5"));
        //          addr = addr >> 3;
        //          length = length >> 3;
        //          s = addr.ToString("X4") + length.ToString("X4");
        //          // Send Erase Flash message
        //          rv = sendSSCP((byte)0x7F, (byte)4, s, true, 100, 20, 50, 1000);
        //          if ((rv == 0 || rv == 6) && replylen > 9)
        //              rv = HexByte((char)replybuf[7], (char)replybuf[8]);
        //          else
        //              rv = -1;
        //          this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
        //          isactive = false;
        //          return rv;
        //      } // end of EraseFlash()

        //      private int ActivateFlash(int length) {
        //          string s;
        //          int rv;
        //          this.LogtextBox.AppendText("Activated " + length.ToString("X5"));
        //          length = length >> 3;
        //          s = length.ToString("X4");
        //          // Send Activate Flash message
        //          //rv = sendSSCP((byte)0x7F,(byte)5,s,true,100,20,1000,20);
        //          // It seems that BootLoader does not send a reply, only Ack
        //          rv = sendSSCP((byte)0x7F, (byte)5, s, false, 100, 20, 20, 0);
        //          //if ((rv==0 || rv==6) && replylen>9)
        //          //	rv = HexByte((char)replybuf[7],(char)replybuf[8]);
        //          if (rv != 0 && rv != 6)
        //              rv = -1;
        //          this.LogtextBox.AppendText(", result=" + rv.ToString() + Environment.NewLine);
        //          if (rv < 0)
        //              isactive = false;
        //          else
        //              isactive = true;
        //          return rv;
        //      } // end of ActivateFlash()

        //      private int ReadChecksum(int addr, int length) {
        //          string s;
        //          int rv;
        //          rv = addr + length;
        //          this.LogtextBox.AppendText("Checksum of " + addr.ToString("X5") + " to " + rv.ToString("X5"));
        //          addr = addr >> 3;
        //          length = length >> 3;
        //          s = addr.ToString("X4") + length.ToString("X4");
        //          // Send Do Checksum message - takes about 250 ms to get reply back for 112 block firmware
        //          rv = sendSSCP((byte)0x7F, (byte)7, s, true, 100, 20, 50, 300);
        //          if ((rv == 0 || rv == 6) && replylen > 15)
        //              rv = SSCPHexValue(7, 8);    // Get value of hex number at replybuf[7] 8 bytes long
        //          else
        //              rv = -1;
        //          this.LogtextBox.AppendText(", result=0x" + rv.ToString("X8") + Environment.NewLine);
        //          return rv;
        //      } // end of ReadChecksum()

        //      private void AnalyseFirmwareFile() { // Parse the firmware file contents in Textbox1 and setup stats vars
        //          int lastaddr = 0;
        //          int last64kblock = 0;
        //          int lno = 0;
        //          int val;
        //          int i;
        //          // Firmware file lines will be in one of the following formats:
        //          // Each line has ':' 2-dig-length 4-dig-addr 2-dig-type length_2-dig-bytes 2-dig-checksum
        //          // Type 00 content line 16 bytes at addr 8000 unencrypted (starts 18F09FE5)
        //          // :1080000018F09FE518F09FE518F09FE518F09FE540
        //          // Type 02 block address line 2 bytes new block at 1000 (i.e. 10000 on)
        //          // :020000021000EC
        //          // Type 03 start address line 4 bytes SA is 00008000
        //          // :040000030000800079
        //          // Type 01 end of file line 0 bytes
        //          // :00000001FF
        //          //
        //          // Encrypted files have first data line like so: (not starting 18F09FE5)
        //          // :108000004BE81483E262890370E503D7FB3A96419B
        //          // But Type 02 records are the same
        //          // At the end of the file, the Type 03 start address line is replaced by
        //          // Type 09 checksum line 4 bytes Checksum is 02A9C148
        //          // :0400000902A9C1483F
        //          // And Type 01 end of file line is the same
        //          // Start address is implied to be 00008000

        //          hexfiledatachecksum = 0;
        //          foreach (String roline in hexfilelines) {
        //              lno++;
        //              val = ClassifyFWLine(roline);
        //              if (val == 0) { // Data line
        //                  if (lno == 1 && roline.StartsWith(":1080000018F09FE5"))
        //                      hexfileformat = 0;  // Unencrypted
        //                  lastaddr = HexByte(roline[3], roline[4]) * 256 + HexByte(roline[5], roline[6]); // Last addr value seen on data line
        //                  for (i = 9; i < 41; i = i + 2)
        //                      hexfiledatachecksum = hexfiledatachecksum + (uint)HexByte(roline[i], roline[i + 1]);
        //              } else if (val == 2) { // Next 64K block line
        //                  last64kblock = Char2Hex(roline[9]); // Last 64K block number seen
        //              } else if (val == 9) {
        //                  hexfilechecksum = roline.Substring(9, 8);
        //              } else { // Anything else is bad or record at end of file
        //                  break;
        //              }
        //          } // end of for each line in textBox1
        //            //System.Windows.Forms.MessageBox.Show("Stopped Setup lno: " + lno.ToString() + " Val: " + val.ToString());
        //            // Update useful info vars from values gleaned from file
        //          hexfilestartaddress = 0x8000;
        //          hexfileendaddress = last64kblock * 65536 + lastaddr + 16;
        //          hexfilelength = hexfileendaddress - hexfilestartaddress;
        //      } // end of AnalyseFirmwareFile()
        //      #endregion

        //      void GetSNbuttonClick(object sender, System.EventArgs e)
        //{
        //	int i;
        //	this.Versiontext.Text = "";
        //	this.SNtext.Text = "";
        //	// Clear any No Hope message
        //	this.toolStripStatusLabel5.Text = "";
        //	this.statusStrip1.Refresh();
        //	// Keep buttons refreshed
        //	Application.DoEvents();
        //	if (!this.serialPort1.IsOpen)
        //	{
        //		PortbuttonClick(sender,e);	// Open port
        //	}
        //	if (this.serialPort1.IsOpen) 
        //	{ // Port now OUGHT to be open - if not, the Open failed
        //		// First send Esc and wait for a sec
        //		escapeProtocol();
        //		// Now send SSCP Read BootLoader Version
        //		// If camera is switching protocols we may lose 1st query so be prepared to send it again
        //		// If camera replies it may not Ack because this is a query! BootLoader always Acks queries
        //		int rv = sendSSCP(0x7F,0,"",true,300,20,20,50);
        //		if (rv < 0)
        //		{
        //			rv = sendSSCP(0x7F,0,"",true,300,20,20,50);	// Repeat the query because we got no answer to the first one
        //		}
        //		// Analyse what happened. If no answer we failed. If answer was Nak we failed.
        //		// If answer was Ack or zero, refresh Versiontext
        //		if (rv==0 || rv==6)
        //		{
        //			char[] content = new char[replylen-10];
        //			for (i=0; i<content.Length; i++)	content[i] = (char)(replybuf[i+7]);
        //			camisthere = true;	// Camera has replied
        //			//System.Array.Copy(replybuf,7,content,0,replylen-10);
        //			this.Versiontext.Text = new string (content);
        //			rv = sendSSCP(0x7F,40,"",true,300,20,20,100);	// Now query for Serial No
        //			if (rv==0 || rv==6)
        //			{
        //				char[] content2 = new char[replylen-10];
        //				for (i=0; i<content2.Length; i++)	content2[i] = (char)(replybuf[i+7]);
        //				//System.Array.Copy(replybuf,7,content2,0,replylen-10);
        //				this.SNtext.Text = new string (content2);
        //			}
        //			else
        //			{
        //				this.SNtext.Text = "NA";
        //			}
        //		}
        //		else
        //		{
        //			this.Versiontext.Text = "NA";
        //			this.SNtext.Text = "NA";
        //			this.toolStripStatusLabel5.Text = "No hope!! Camera not replying!!";
        //			this.statusStrip1.Refresh();
        //		}
        //	}
        //} // end of GetSNbuttonClick()

        //void ChangePortSpeed(string newspeed)
        //{
        //	// We need the Port Open, and then to ask to change port speed
        //	if (!this.serialPort1.IsOpen)	this.serialPort1.Open();
        //	sendSSCP(0x7F,6,newspeed,false,300,20,100,0);	// Ask other end to change speed
        //	if (this.serialPort1.IsOpen)	this.serialPort1.Close();
        //	// We now need to wait around for a bit to let the speed change
        //	System.Threading.Thread.Sleep(1000);	// We now sleep for 1 sec
        //	this.serialPort1.BaudRate = System.Convert.ToInt32(newspeed);
        //	this.serialPort1.Open();
        //} // end of ChangePortSpeed()

        //void PortbuttonClick(object sender, System.EventArgs e)
        //{
        //	string sline;
        //	if (this.serialPort1.IsOpen) 
        //	{
        //		this.serialPort1.Close();
        //		this.Portbutton.Text = "Open Port";
        //		statusStrip1.Text = "Port Closed";
        //	}
        //	else 
        //	{
        //              if (PortcomboBox.Text == "" || this.PortcomboBox.SelectedItem == null) {
        //                  MessageBox.Show("Port invalid!");
        //                  return;
        //              }
        //		sline = "8N1";
        //		this.serialPort1 = new System.IO.Ports.SerialPort(this.PortcomboBox.SelectedItem.ToString());
        //		this.serialPort1.BaudRate = System.Convert.ToInt32(this.SpeedcomboBox.SelectedItem.ToString());
        //		this.serialPort1.DataBits = System.Convert.ToInt32(sline.Substring(0,1));
        //		switch (sline[1]) 
        //		{
        //			case 'N':	this.serialPort1.Parity = System.IO.Ports.Parity.None; break;
        //			case 'E':	this.serialPort1.Parity = System.IO.Ports.Parity.Even; break;
        //			case 'O':	this.serialPort1.Parity = System.IO.Ports.Parity.Odd; break;
        //		}
        //		switch (sline[2]) 
        //		{
        //			case '1':	this.serialPort1.StopBits = System.IO.Ports.StopBits.One; break;
        //			case '2':	this.serialPort1.StopBits = System.IO.Ports.StopBits.Two; break;
        //		}
        //		this.serialPort1.ReadTimeout=1000;	// 1 sec read timeout
        //		this.serialPort1.ReadBufferSize=128;	// 128 byte Read buffer
        //		try 
        //		{
        //			this.serialPort1.Open();
        //			this.Portbutton.Text = "Close Port";
        //			this.toolStripStatusLabel2.Text = "Port Opened";
        //			this.statusStrip1.Refresh();
        //		}
        //		catch (System.SystemException ex)
        //		{
        //			//System.Windows.Forms.MessageBox.Show("Port Open Fail: " + ex.Message);
        //			this.LogtextBox.AppendText("Port Open Fail: " + ex.Message + Environment.NewLine);
        //		}
        //	}
        //} // end of PortbuttonClick()

        //void WritebuttonClick(object sender, System.EventArgs e)
        //{
        //	if (hexfilesafefilename != null && hexfilelength>0)
        //	{
        //		if (!camisthere)
        //		{
        //			GetSNbuttonClick(sender,e);	// GetSN checks that camera is replying
        //		}
        //		bool trywriting = true;
        //		// Alert if we do not have correct BootLoader
        //		if (camisthere && hexfilenblocks>=112 && this.Versiontext.Text.StartsWith("V1.013"))
        //		{
        //			trywriting = false;
        //			if (hexfilenblocks>112 && (this.Versiontext.Text.Length<7 || this.Versiontext.Text[6]!='y'))
        //				this.LogtextBox.AppendText("*** Needs BootLoader v1.013y to load ***" + System.Environment.NewLine);
        //			else if (this.Versiontext.Text.Length<7)
        //				this.LogtextBox.AppendText("*** Needs BootLoader v1.013a or x or y to load ***" + System.Environment.NewLine);
        //			else
        //				trywriting = true;
        //		}
        //		if (camisthere && trywriting)
        //		{ // Camera is there - it is worth trying the write
        //			int i;
        //			int n;
        //			int r;
        //			int c;
        //			int tnb = (hexfilelength + 4095)/4096;	// Total number of 4096 byte blocks
        //			int retries = 0;
        //			bool bw = false;	// Buffer written successfully
        //			EscapeWasPressed = false;	// No Abort yet
        //			this.Abortbutton.Text = "Abort";
        //			// Say if this is an excrypted file or not
        //			// Boot Loader echoes back same setting
        //			sendSSCP(0x7F,8,(hexfilechecksum==null?"00":"01"),true,300,20,20,50);
        //			i = hexfilestartaddress;
        //			n = 4096;
        //			r = 0;	// Current result flag
        //			c = 0;	// Current block
        //			// Show busy dialogue window
        //			while (i<hexfileendaddress && r==0 && !EscapeWasPressed)
        //			{
        //				c++;	// Bump current block number
        //				// Maintain global currentblock
        //				currentblock = c;
        //				this.toolStripStatusLabel5.Text = "Writing... block " + c.ToString() + " of " + tnb.ToString();
        //				this.statusStrip1.Refresh();
        //				bw = false;	// Start a new buffer write attempt
        //				retries = 0;	// No retries yet
        //				while (!bw && retries<10 && !EscapeWasPressed)
        //				{
        //					bw = WriteFromBuffer(i,n,0);
        //					retries++;	// One more retry
        //				} // end of while (!bw && ...
        //				if (bw)		r = WriteToFlash(i,n);
        //				else		r = -1;
        //				i += n;		// Bump address on to next block
        //			} // end of while (i<hexfileendaddress && ...
        //			// Hide busy dialogue window
        //			if (EscapeWasPressed)
        //			{ // Clear Aborting message
        //				this.Abortbutton.Text = "Abort";
        //				// Keep buttons refreshed
        //				Application.DoEvents();
        //				this.toolStripStatusLabel1.Text = "";
        //				EscapeWasPressed = false;
        //			}
        //			//this.toolStripStatusLabel6.Text = "";
        //			if (r == 0)
        //				this.toolStripStatusLabel5.Text = "";
        //			else
        //				this.toolStripStatusLabel5.Text = "Failed on block" + c.ToString() + " of " + tnb.ToString();
        //			statusStrip1.Refresh();
        //		} // end of camera is there
        //		else
        //		{
        //			this.LogtextBox.AppendText("No hope!! Camera is not replying!!" + Environment.NewLine);
        //			toolStripStatusLabel5.Text = "No hope!! Camera is not replying!!";
        //			statusStrip1.Refresh();
        //		}
        //	}
        //	else
        //	{
        //		this.LogtextBox.AppendText("Load .hex file first!" + Environment.NewLine);
        //		toolStripStatusLabel5.Text = "Load .hex file first!";
        //		statusStrip1.Refresh();
        //	}
        //} // end of WritebuttonClick()

        //void ErasebuttonClick(object sender, System.EventArgs e)
        //{
        //	if (hexfilesafefilename != null && hexfilelength>0)
        //	{
        //		EraseFlash(hexfilestartaddress,hexfilelength);
        //	}
        //	else
        //	{
        //		this.LogtextBox.AppendText("Load .hex file first!" + Environment.NewLine);
        //		toolStripStatusLabel5.Text = "Load .hex file first!";
        //		statusStrip1.Refresh();
        //	}
        //} // end of ErasebuttonClick()

        public MenuStrip MenuBar;
        public ToolStripMenuItem Menu_Window;
        public ToolStripMenuItem Menu_Window_Detached;
        public ToolStripMenuItem Menu_Window_PelcoD;
        public ToolStripMenuItem Menu_Final;
        public ToolStripMenuItem Menu_Final_Open;
        public ToolStripMenuItem Menu_Window_Response;
        public ToolStripMenuItem Menu_QC;
        public ToolStripMenuItem Menu_QC_PanZero;
        public Panel p_Main;
        public Panel p_Control;
        public ToolStripMenuItem Menu_QC_Pan;
        public ToolStripMenuItem Menu_QC_Tilt;
        public ToolStripMenuItem Menu_Window_Osiris;
        public ToolStripMenuItem Menu_Video;
        public ToolStripMenuItem Menu_Video_Settings;
        public ToolStripMenuItem Menu_Video_Snapshot;
        public ToolStripMenuItem Menu_Video_Record;
        public ToolStripMenuItem Menu_Video_StartStop;
        public ToolStripMenuItem Menu_Window_Presets;
        public Button b_Open;
        public ToolStripMenuItem Menu_Video_EnableSecondary;
        public SPanel.SizeablePanel sP_Player;
        public ToolStripMenuItem Menu_Settings;
        public ToolStripMenuItem Menu_Settings_Open;
        public ToolStripMenuItem Menu_Settings_Info;
        public Joystick.CentreStick Joystick;
        public Button b_PTZ_Left;
        public Button b_PTZ_Right;
        public Button b_PTZ_Down;
        public Button b_PTZ_Up;
        public Button b_PTZ_FocusNeg;
        public Button b_PTZ_ZoomNeg;
        public Button b_PTZ_FocusPos;
        public Button b_PTZ_ZoomPos;
        public PictureBox pB_Background;
        public ToolStripMenuItem Menu_Settings_Keyboard;
        public ToolStripMenuItem Menu_Settings_CP;
        public ToolStripMenuItem Menu_Window_Settings;
        public ToolStripMenuItem Menu_Settings_Lite;
        private ToolStripMenuItem Menu_QC_Custom;
        private ToolStripMenuItem Menu_Settings_Presets;
        private ToolStripMenuItem Menu_Settings_Custom;
        private ToolStripMenuItem Menu_Settings_ImportConfig;
        private ToolStripMenuItem Menu_Settings_ExportConfig;
        public Button b_PTZ_Daylight;
        public Button b_PTZ_Thermal;
    } // end of partial class MainForm
} // end of namespace SSLUtility2
