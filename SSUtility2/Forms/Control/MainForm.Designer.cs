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
using Kaiser;

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
        /// 
        public MainForm() {
            InitializeComponent();
            StartupStuff();
        }
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
        private void InitializeComponent() {
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
            this.Menu_Video_Snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_Snap_Single = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_Snap_Panoramic = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Video_Record = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_PanZero = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Pan = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Tilt = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Final = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Final_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.p_PlayerPanel = new System.Windows.Forms.Panel();
            this.pB_Panoramic = new System.Windows.Forms.PictureBox();
            this.b_PTZ_Daylight = new System.Windows.Forms.Button();
            this.b_Open = new System.Windows.Forms.Button();
            this.b_PTZ_Thermal = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.JoyBack = new Kaiser.JoyBack();
            this.MenuBar.SuspendLayout();
            this.p_PlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Panoramic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JoyBack)).BeginInit();
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
            this.Menu_Video_Snapshot,
            this.Menu_Video_Record});
            this.Menu_Video.Name = "Menu_Video";
            this.Menu_Video.Size = new System.Drawing.Size(93, 20);
            this.Menu_Video.Text = "Video Stream";
            // 
            // Menu_Video_Settings
            // 
            this.Menu_Video_Settings.Name = "Menu_Video_Settings";
            this.Menu_Video_Settings.Size = new System.Drawing.Size(183, 22);
            this.Menu_Video_Settings.Text = "Connection Settings";
            this.Menu_Video_Settings.Click += new System.EventHandler(this.Menu_Video_Settings_Click);
            // 
            // Menu_Video_Snapshot
            // 
            this.Menu_Video_Snapshot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Video_Snap_Single,
            this.Menu_Video_Snap_Panoramic});
            this.Menu_Video_Snapshot.Name = "Menu_Video_Snapshot";
            this.Menu_Video_Snapshot.Size = new System.Drawing.Size(183, 22);
            this.Menu_Video_Snapshot.Text = "Save Snapshot";
            // 
            // Menu_Video_Snap_Single
            // 
            this.Menu_Video_Snap_Single.Name = "Menu_Video_Snap_Single";
            this.Menu_Video_Snap_Single.Size = new System.Drawing.Size(134, 22);
            this.Menu_Video_Snap_Single.Text = "Single";
            this.Menu_Video_Snap_Single.Click += new System.EventHandler(this.Menu_Video_Snap_Single_Click);
            // 
            // Menu_Video_Snap_Panoramic
            // 
            this.Menu_Video_Snap_Panoramic.Name = "Menu_Video_Snap_Panoramic";
            this.Menu_Video_Snap_Panoramic.Size = new System.Drawing.Size(134, 22);
            this.Menu_Video_Snap_Panoramic.Text = "Panoramic";
            this.Menu_Video_Snap_Panoramic.Click += new System.EventHandler(this.Menu_Video_Snap_Panoramic_Click);
            // 
            // Menu_Video_Record
            // 
            this.Menu_Video_Record.Name = "Menu_Video_Record";
            this.Menu_Video_Record.Size = new System.Drawing.Size(183, 22);
            this.Menu_Video_Record.Text = "Start Recording";
            this.Menu_Video_Record.Click += new System.EventHandler(this.Menu_Video_Record_Click);
            // 
            // Menu_QC
            // 
            this.Menu_QC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_QC_Custom,
            this.Menu_QC_PanZero,
            this.Menu_QC_Pan,
            this.Menu_QC_Tilt,
            this.Menu_QC_Zoom});
            this.Menu_QC.Name = "Menu_QC";
            this.Menu_QC.Size = new System.Drawing.Size(117, 20);
            this.Menu_QC.Text = "Quick Commands";
            // 
            // Menu_QC_Custom
            // 
            this.Menu_QC_Custom.Name = "Menu_QC_Custom";
            this.Menu_QC_Custom.Size = new System.Drawing.Size(198, 22);
            this.Menu_QC_Custom.Text = "Enter Quick Command";
            this.Menu_QC_Custom.Click += new System.EventHandler(this.Menu_QC_Custom_Click);
            // 
            // Menu_QC_PanZero
            // 
            this.Menu_QC_PanZero.Name = "Menu_QC_PanZero";
            this.Menu_QC_PanZero.Size = new System.Drawing.Size(198, 22);
            this.Menu_QC_PanZero.Text = "Set Pan = 0";
            this.Menu_QC_PanZero.Click += new System.EventHandler(this.Menu_QC_PanZero_Click);
            // 
            // Menu_QC_Pan
            // 
            this.Menu_QC_Pan.Name = "Menu_QC_Pan";
            this.Menu_QC_Pan.Size = new System.Drawing.Size(198, 22);
            this.Menu_QC_Pan.Text = "Quick Pan";
            this.Menu_QC_Pan.Click += new System.EventHandler(this.Menu_QC_Pan_Click);
            // 
            // Menu_QC_Tilt
            // 
            this.Menu_QC_Tilt.Name = "Menu_QC_Tilt";
            this.Menu_QC_Tilt.Size = new System.Drawing.Size(198, 22);
            this.Menu_QC_Tilt.Text = "Quick TIlt";
            this.Menu_QC_Tilt.Click += new System.EventHandler(this.Menu_QC_Tilt_Click);
            // 
            // Menu_QC_Zoom
            // 
            this.Menu_QC_Zoom.Name = "Menu_QC_Zoom";
            this.Menu_QC_Zoom.Size = new System.Drawing.Size(198, 22);
            this.Menu_QC_Zoom.Text = "Quick Zoom";
            this.Menu_QC_Zoom.Click += new System.EventHandler(this.Menu_QC_Zoom_Click);
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
            // p_PlayerPanel
            // 
            this.p_PlayerPanel.AllowDrop = true;
            this.p_PlayerPanel.BackColor = System.Drawing.Color.Black;
            this.p_PlayerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_PlayerPanel.Controls.Add(this.pB_Panoramic);
            this.p_PlayerPanel.Controls.Add(this.JoyBack);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_Daylight);
            this.p_PlayerPanel.Controls.Add(this.b_Open);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_Thermal);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_ZoomPos);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_Left);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_FocusPos);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_Right);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_ZoomNeg);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_Down);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_FocusNeg);
            this.p_PlayerPanel.Controls.Add(this.b_PTZ_Up);
            this.p_PlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_PlayerPanel.Location = new System.Drawing.Point(0, 24);
            this.p_PlayerPanel.Name = "p_PlayerPanel";
            this.p_PlayerPanel.Size = new System.Drawing.Size(1264, 657);
            this.p_PlayerPanel.TabIndex = 31;
            this.p_PlayerPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.p_PlayerPanel_DragDrop);
            this.p_PlayerPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.p_PlayerPanel_DragOver);
            this.p_PlayerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.p_PlayerPanel_MouseMove);
            // 
            // pB_Panoramic
            // 
            this.pB_Panoramic.BackColor = System.Drawing.Color.Transparent;
            this.pB_Panoramic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pB_Panoramic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pB_Panoramic.Location = new System.Drawing.Point(0, 645);
            this.pB_Panoramic.Name = "pB_Panoramic";
            this.pB_Panoramic.Size = new System.Drawing.Size(1262, 10);
            this.pB_Panoramic.TabIndex = 100;
            this.pB_Panoramic.TabStop = false;
            this.pB_Panoramic.Visible = false;
            this.pB_Panoramic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pB_Panoramic_MouseClick);
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
            // JoyBack
            // 
            this.JoyBack.BackColor = System.Drawing.Color.Transparent;
            this.JoyBack.Location = new System.Drawing.Point(68, 92);
            this.JoyBack.MaximumSize = new System.Drawing.Size(150, 150);
            this.JoyBack.MinimumSize = new System.Drawing.Size(150, 150);
            this.JoyBack.Name = "JoyBack";
            this.JoyBack.Size = new System.Drawing.Size(150, 150);
            this.JoyBack.TabIndex = 99;
            this.JoyBack.TabStop = false;
            this.JoyBack.JoyReleased += new System.EventHandler(this.JoyBack_JoyReleased);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.p_PlayerPanel);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSUtility V2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.p_PlayerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Panoramic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JoyBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public MenuStrip MenuBar;
        public ToolStripMenuItem Menu_Window;
        public ToolStripMenuItem Menu_Window_Detached;
        public ToolStripMenuItem Menu_Window_PelcoD;
        public ToolStripMenuItem Menu_Final;
        public ToolStripMenuItem Menu_Final_Open;
        public ToolStripMenuItem Menu_Window_Response;
        public ToolStripMenuItem Menu_QC;
        public ToolStripMenuItem Menu_QC_PanZero;
        public Panel p_PlayerPanel;
        public ToolStripMenuItem Menu_QC_Pan;
        public ToolStripMenuItem Menu_QC_Tilt;
        public ToolStripMenuItem Menu_Window_Osiris;
        public ToolStripMenuItem Menu_Video;
        public ToolStripMenuItem Menu_Video_Settings;
        public ToolStripMenuItem Menu_Video_Snapshot;
        public ToolStripMenuItem Menu_Video_Record;
        public ToolStripMenuItem Menu_Window_Presets;
        public Button b_Open;
        public ToolStripMenuItem Menu_Settings;
        public ToolStripMenuItem Menu_Settings_Open;
        public ToolStripMenuItem Menu_Settings_Info;
        public Button b_PTZ_Left;
        public Button b_PTZ_Right;
        public Button b_PTZ_Down;
        public Button b_PTZ_Up;
        public Button b_PTZ_FocusNeg;
        public Button b_PTZ_ZoomNeg;
        public Button b_PTZ_FocusPos;
        public Button b_PTZ_ZoomPos;
        public ToolStripMenuItem Menu_Settings_Keyboard;
        public ToolStripMenuItem Menu_Settings_CP;
        public ToolStripMenuItem Menu_Window_Settings;
        public ToolStripMenuItem Menu_Settings_Lite;
        public ToolStripMenuItem Menu_QC_Custom;
        public ToolStripMenuItem Menu_Settings_Presets;
        public ToolStripMenuItem Menu_Settings_Custom;
        public ToolStripMenuItem Menu_Settings_ImportConfig;
        public ToolStripMenuItem Menu_Settings_ExportConfig;
        public Button b_PTZ_Daylight;
        public Button b_PTZ_Thermal;
        public ToolStripMenuItem Menu_Video_Snap_Single;
        public ToolStripMenuItem Menu_Video_Snap_Panoramic;
        public Kaiser.JoyBack JoyBack;
        public PictureBox pB_Panoramic;
        private ToolStripMenuItem Menu_QC_Zoom;
    } // end of partial class MainForm
} // end of namespace SSLUtility2
