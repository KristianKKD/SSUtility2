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
            this.Menu_Window_Presets = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_ConnectionSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Lite = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Keyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Panels = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Panels_QF = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Panels_IP = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Panels_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Panels_CP = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Config_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Settings_Config_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_StopRecording = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Video = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Video_SSUtility = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Video_MainPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Video_Global = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Snapshot_Single = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Snapshot_Panoramic = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Snapshot_All = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Recording_Collection = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_PanZero = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Pan = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Tilt = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_QC_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Final = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Final_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_RecordIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Legacy = new System.Windows.Forms.Panel();
            this.p_Legacy_Player2 = new System.Windows.Forms.Panel();
            this.p_Legacy_Player1 = new System.Windows.Forms.Panel();
            this.p_Player1 = new System.Windows.Forms.Panel();
            this.l_Name = new System.Windows.Forms.Label();
            this.tB_Player1_Name = new System.Windows.Forms.TextBox();
            this.p_Player1_Simple = new System.Windows.Forms.Panel();
            this.tB_Player1_SimpleAdr = new System.Windows.Forms.TextBox();
            this.l_Player1_SimpleAdr = new System.Windows.Forms.Label();
            this.p_Player1_Extended = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.l_Player1_Type = new System.Windows.Forms.Label();
            this.cB_Player1_Type = new System.Windows.Forms.ComboBox();
            this.l_Player1_RTSP = new System.Windows.Forms.Label();
            this.tB_Player1_Password = new System.Windows.Forms.TextBox();
            this.tB_Player1_Adr = new System.Windows.Forms.TextBox();
            this.l_Player1_Buffering = new System.Windows.Forms.Label();
            this.l_Player1_Password = new System.Windows.Forms.Label();
            this.l_Player1_Username = new System.Windows.Forms.Label();
            this.tB_Player1_Port = new System.Windows.Forms.TextBox();
            this.tB_Player1_Buffering = new System.Windows.Forms.TextBox();
            this.l_Player1_Port = new System.Windows.Forms.Label();
            this.tB_Player1_Username = new System.Windows.Forms.TextBox();
            this.tB_Player1_RTSP = new System.Windows.Forms.TextBox();
            this.l_Player1_Adr = new System.Windows.Forms.Label();
            this.b_Player1_Stop = new System.Windows.Forms.Button();
            this.checkB_Player1_Manual = new System.Windows.Forms.CheckBox();
            this.b_Player1_Play = new System.Windows.Forms.Button();
            this.l_Legacy_CP = new System.Windows.Forms.Panel();
            this.b_Legacy_Connect = new System.Windows.Forms.Button();
            this.l_Legacy_PelcoID = new System.Windows.Forms.Label();
            this.tB_Legacy_PelcoID = new System.Windows.Forms.TextBox();
            this.l_legacy_Port = new System.Windows.Forms.Label();
            this.tB_Legacy_Port = new System.Windows.Forms.TextBox();
            this.l_Legacy_IP = new System.Windows.Forms.Label();
            this.l_Legacy_IPCon = new System.Windows.Forms.Label();
            this.tB_Legacy_IP = new System.Windows.Forms.TextBox();
            this.l_Legacy_PTZ = new System.Windows.Forms.Label();
            this.b_Legacy_Up = new System.Windows.Forms.Button();
            this.Legacy_JoyBack = new Kaiser.JoyBack();
            this.b_Legacy_FocusNeg = new System.Windows.Forms.Button();
            this.b_Legacy_ZoomPos = new System.Windows.Forms.Button();
            this.b_Legacy_Down = new System.Windows.Forms.Button();
            this.b_Legacy_Left = new System.Windows.Forms.Button();
            this.b_Legacy_ZoomNeg = new System.Windows.Forms.Button();
            this.b_Legacy_FocusPos = new System.Windows.Forms.Button();
            this.b_Legacy_Right = new System.Windows.Forms.Button();
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.b_PTZ_Thermal = new System.Windows.Forms.Button();
            this.b_Open = new System.Windows.Forms.Button();
            this.b_PTZ_Daylight = new System.Windows.Forms.Button();
            this.JoyBack = new Kaiser.JoyBack();
            this.pB_Panoramic = new System.Windows.Forms.PictureBox();
            this.p_PTZ_Sliders = new System.Windows.Forms.Panel();
            this.l_PTZ_SlidersFPercent = new System.Windows.Forms.Label();
            this.tB_PTZ_SlidersFText = new System.Windows.Forms.TextBox();
            this.l_PTZ_SlidersFocus = new System.Windows.Forms.Label();
            this.slider_PTZ_AbsFocus = new System.Windows.Forms.TrackBar();
            this.l_PTZ_SliderZPercent = new System.Windows.Forms.Label();
            this.tB_PTZ_SlidersZText = new System.Windows.Forms.TextBox();
            this.l_PTZ_SliderZoom = new System.Windows.Forms.Label();
            this.slider_PTZ_AbsZoom = new System.Windows.Forms.TrackBar();
            this.p_PlayerPanel = new System.Windows.Forms.Panel();
            this.MenuBar.SuspendLayout();
            this.p_Legacy.SuspendLayout();
            this.p_Legacy_Player1.SuspendLayout();
            this.p_Player1_Simple.SuspendLayout();
            this.p_Player1_Extended.SuspendLayout();
            this.l_Legacy_CP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Legacy_JoyBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JoyBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Panoramic)).BeginInit();
            this.p_PTZ_Sliders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_PTZ_AbsFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_PTZ_AbsZoom)).BeginInit();
            this.p_PlayerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Window,
            this.Menu_Settings,
            this.Menu_Recording,
            this.Menu_QC,
            this.Menu_Final,
            this.Menu_RecordIndicator});
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
            this.Menu_Window_Presets});
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
            // Menu_Window_Presets
            // 
            this.Menu_Window_Presets.Name = "Menu_Window_Presets";
            this.Menu_Window_Presets.Size = new System.Drawing.Size(168, 22);
            this.Menu_Window_Presets.Text = "Quick Functions";
            this.Menu_Window_Presets.Click += new System.EventHandler(this.Menu_Window_Presets_Click);
            // 
            // Menu_Settings
            // 
            this.Menu_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings_ConnectionSettings,
            this.Menu_Settings_Open,
            this.Menu_Settings_Lite,
            this.Menu_Settings_Keyboard,
            this.Menu_Settings_Panels,
            this.Menu_Settings_Config});
            this.Menu_Settings.Name = "Menu_Settings";
            this.Menu_Settings.Size = new System.Drawing.Size(63, 20);
            this.Menu_Settings.Text = "Settings";
            // 
            // Menu_Settings_ConnectionSettings
            // 
            this.Menu_Settings_ConnectionSettings.Name = "Menu_Settings_ConnectionSettings";
            this.Menu_Settings_ConnectionSettings.Size = new System.Drawing.Size(193, 22);
            this.Menu_Settings_ConnectionSettings.Text = "Connection Settings";
            this.Menu_Settings_ConnectionSettings.Click += new System.EventHandler(this.Menu_Settings_ConnectionSettings_Click);
            // 
            // Menu_Settings_Open
            // 
            this.Menu_Settings_Open.Name = "Menu_Settings_Open";
            this.Menu_Settings_Open.Size = new System.Drawing.Size(193, 22);
            this.Menu_Settings_Open.Text = "SSUtility Settings";
            this.Menu_Settings_Open.Click += new System.EventHandler(this.Menu_Settings_Open_Click);
            // 
            // Menu_Settings_Lite
            // 
            this.Menu_Settings_Lite.Name = "Menu_Settings_Lite";
            this.Menu_Settings_Lite.Size = new System.Drawing.Size(193, 22);
            this.Menu_Settings_Lite.Text = "Lite Mode";
            this.Menu_Settings_Lite.Click += new System.EventHandler(this.Menu_Settings_Lite_Click);
            // 
            // Menu_Settings_Keyboard
            // 
            this.Menu_Settings_Keyboard.Name = "Menu_Settings_Keyboard";
            this.Menu_Settings_Keyboard.Size = new System.Drawing.Size(193, 22);
            this.Menu_Settings_Keyboard.Text = "Enable PTZ Keyboard";
            this.Menu_Settings_Keyboard.Click += new System.EventHandler(this.Menu_Settings_Keyboard_Click);
            // 
            // Menu_Settings_Panels
            // 
            this.Menu_Settings_Panels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings_Panels_QF,
            this.Menu_Settings_Panels_IP,
            this.Menu_Settings_Panels_Custom,
            this.Menu_Settings_Panels_CP});
            this.Menu_Settings_Panels.Name = "Menu_Settings_Panels";
            this.Menu_Settings_Panels.Size = new System.Drawing.Size(193, 22);
            this.Menu_Settings_Panels.Text = "Panels";
            // 
            // Menu_Settings_Panels_QF
            // 
            this.Menu_Settings_Panels_QF.Name = "Menu_Settings_Panels_QF";
            this.Menu_Settings_Panels_QF.Size = new System.Drawing.Size(173, 22);
            this.Menu_Settings_Panels_QF.Text = "Quick Functions";
            this.Menu_Settings_Panels_QF.Click += new System.EventHandler(this.Menu_Settings_Panels_QF_Click);
            // 
            // Menu_Settings_Panels_IP
            // 
            this.Menu_Settings_Panels_IP.Name = "Menu_Settings_Panels_IP";
            this.Menu_Settings_Panels_IP.Size = new System.Drawing.Size(173, 22);
            this.Menu_Settings_Panels_IP.Text = "Info Panel";
            this.Menu_Settings_Panels_IP.Click += new System.EventHandler(this.Menu_Settings_Panels_IP_Click);
            // 
            // Menu_Settings_Panels_Custom
            // 
            this.Menu_Settings_Panels_Custom.Name = "Menu_Settings_Panels_Custom";
            this.Menu_Settings_Panels_Custom.Size = new System.Drawing.Size(173, 22);
            this.Menu_Settings_Panels_Custom.Text = "Custom Panel";
            this.Menu_Settings_Panels_Custom.Click += new System.EventHandler(this.Menu_Settings_Panels_Custom_Click);
            // 
            // Menu_Settings_Panels_CP
            // 
            this.Menu_Settings_Panels_CP.Name = "Menu_Settings_Panels_CP";
            this.Menu_Settings_Panels_CP.Size = new System.Drawing.Size(173, 22);
            this.Menu_Settings_Panels_CP.Text = "PTZ Control Panel";
            this.Menu_Settings_Panels_CP.Click += new System.EventHandler(this.Menu_Settings_Panels_CP_Click);
            // 
            // Menu_Settings_Config
            // 
            this.Menu_Settings_Config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings_Config_Import,
            this.Menu_Settings_Config_Export});
            this.Menu_Settings_Config.Name = "Menu_Settings_Config";
            this.Menu_Settings_Config.Size = new System.Drawing.Size(193, 22);
            this.Menu_Settings_Config.Text = "Config";
            // 
            // Menu_Settings_Config_Import
            // 
            this.Menu_Settings_Config_Import.Name = "Menu_Settings_Config_Import";
            this.Menu_Settings_Config_Import.Size = new System.Drawing.Size(118, 22);
            this.Menu_Settings_Config_Import.Text = "Import...";
            this.Menu_Settings_Config_Import.Click += new System.EventHandler(this.Menu_Settings_Config_Import_Click);
            // 
            // Menu_Settings_Config_Export
            // 
            this.Menu_Settings_Config_Export.Name = "Menu_Settings_Config_Export";
            this.Menu_Settings_Config_Export.Size = new System.Drawing.Size(118, 22);
            this.Menu_Settings_Config_Export.Text = "Export...";
            this.Menu_Settings_Config_Export.Click += new System.EventHandler(this.Menu_Settings_Config_Export_Click);
            // 
            // Menu_Recording
            // 
            this.Menu_Recording.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Recording_StopRecording,
            this.Menu_Recording_Video,
            this.Menu_Recording_Snapshot,
            this.Menu_Recording_Collection});
            this.Menu_Recording.Name = "Menu_Recording";
            this.Menu_Recording.Size = new System.Drawing.Size(76, 20);
            this.Menu_Recording.Text = "Recording";
            // 
            // Menu_Recording_StopRecording
            // 
            this.Menu_Recording_StopRecording.Name = "Menu_Recording_StopRecording";
            this.Menu_Recording_StopRecording.Size = new System.Drawing.Size(159, 22);
            this.Menu_Recording_StopRecording.Text = "Stop Recording";
            this.Menu_Recording_StopRecording.Visible = false;
            this.Menu_Recording_StopRecording.Click += new System.EventHandler(this.Menu_Recording_StopRecording_Click);
            // 
            // Menu_Recording_Video
            // 
            this.Menu_Recording_Video.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Recording_Video_SSUtility,
            this.Menu_Recording_Video_MainPlayer,
            this.Menu_Recording_Video_Global});
            this.Menu_Recording_Video.Name = "Menu_Recording_Video";
            this.Menu_Recording_Video.Size = new System.Drawing.Size(159, 22);
            this.Menu_Recording_Video.Text = "Video";
            // 
            // Menu_Recording_Video_SSUtility
            // 
            this.Menu_Recording_Video_SSUtility.Name = "Menu_Recording_Video_SSUtility";
            this.Menu_Recording_Video_SSUtility.Size = new System.Drawing.Size(166, 22);
            this.Menu_Recording_Video_SSUtility.Text = "SSUtility";
            this.Menu_Recording_Video_SSUtility.Click += new System.EventHandler(this.Menu_Recording_Video_SSUtility_Click);
            // 
            // Menu_Recording_Video_MainPlayer
            // 
            this.Menu_Recording_Video_MainPlayer.Name = "Menu_Recording_Video_MainPlayer";
            this.Menu_Recording_Video_MainPlayer.Size = new System.Drawing.Size(166, 22);
            this.Menu_Recording_Video_MainPlayer.Text = "Main Player Only";
            this.Menu_Recording_Video_MainPlayer.Click += new System.EventHandler(this.Menu_Recording_Video_MainPlayer_Click);
            // 
            // Menu_Recording_Video_Global
            // 
            this.Menu_Recording_Video_Global.Name = "Menu_Recording_Video_Global";
            this.Menu_Recording_Video_Global.Size = new System.Drawing.Size(166, 22);
            this.Menu_Recording_Video_Global.Text = "Global";
            this.Menu_Recording_Video_Global.Click += new System.EventHandler(this.Menu_Recording_Global_Click);
            // 
            // Menu_Recording_Snapshot
            // 
            this.Menu_Recording_Snapshot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Recording_Snapshot_Single,
            this.Menu_Recording_Snapshot_Panoramic,
            this.Menu_Recording_Snapshot_All});
            this.Menu_Recording_Snapshot.Name = "Menu_Recording_Snapshot";
            this.Menu_Recording_Snapshot.Size = new System.Drawing.Size(159, 22);
            this.Menu_Recording_Snapshot.Text = "Snapshot";
            // 
            // Menu_Recording_Snapshot_Single
            // 
            this.Menu_Recording_Snapshot_Single.Name = "Menu_Recording_Snapshot_Single";
            this.Menu_Recording_Snapshot_Single.Size = new System.Drawing.Size(180, 22);
            this.Menu_Recording_Snapshot_Single.Text = "Full Single";
            this.Menu_Recording_Snapshot_Single.Click += new System.EventHandler(this.Menu_Recording_Snapshot_Single_Click);
            // 
            // Menu_Recording_Snapshot_Panoramic
            // 
            this.Menu_Recording_Snapshot_Panoramic.Name = "Menu_Recording_Snapshot_Panoramic";
            this.Menu_Recording_Snapshot_Panoramic.Size = new System.Drawing.Size(180, 22);
            this.Menu_Recording_Snapshot_Panoramic.Text = "Panoramic";
            this.Menu_Recording_Snapshot_Panoramic.Click += new System.EventHandler(this.Menu_Recording_Snapshot_Panoramic_Click);
            // 
            // Menu_Recording_Snapshot_All
            // 
            this.Menu_Recording_Snapshot_All.Name = "Menu_Recording_Snapshot_All";
            this.Menu_Recording_Snapshot_All.Size = new System.Drawing.Size(180, 22);
            this.Menu_Recording_Snapshot_All.Text = "All Attached Players";
            this.Menu_Recording_Snapshot_All.Click += new System.EventHandler(this.Menu_Recording_Snapshot_All_Click);
            // 
            // Menu_Recording_Collection
            // 
            this.Menu_Recording_Collection.Name = "Menu_Recording_Collection";
            this.Menu_Recording_Collection.Size = new System.Drawing.Size(159, 22);
            this.Menu_Recording_Collection.Text = "Collection...";
            this.Menu_Recording_Collection.Click += new System.EventHandler(this.Menu_Recording_Collection_Click);
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
            // Menu_RecordIndicator
            // 
            this.Menu_RecordIndicator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Menu_RecordIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_RecordIndicator.ForeColor = System.Drawing.Color.Red;
            this.Menu_RecordIndicator.Name = "Menu_RecordIndicator";
            this.Menu_RecordIndicator.Size = new System.Drawing.Size(12, 20);
            this.Menu_RecordIndicator.Visible = false;
            this.Menu_RecordIndicator.Click += new System.EventHandler(this.Menu_RecordIndicator_Click);
            // 
            // p_Legacy
            // 
            this.p_Legacy.Controls.Add(this.p_Legacy_Player2);
            this.p_Legacy.Controls.Add(this.p_Legacy_Player1);
            this.p_Legacy.Controls.Add(this.l_Legacy_CP);
            this.p_Legacy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Legacy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.p_Legacy.Location = new System.Drawing.Point(0, 0);
            this.p_Legacy.Name = "p_Legacy";
            this.p_Legacy.Size = new System.Drawing.Size(1264, 681);
            this.p_Legacy.TabIndex = 32;
            // 
            // p_Legacy_Player2
            // 
            this.p_Legacy_Player2.BackColor = System.Drawing.SystemColors.Menu;
            this.p_Legacy_Player2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Legacy_Player2.Location = new System.Drawing.Point(727, 30);
            this.p_Legacy_Player2.Name = "p_Legacy_Player2";
            this.p_Legacy_Player2.Size = new System.Drawing.Size(530, 643);
            this.p_Legacy_Player2.TabIndex = 123;
            // 
            // p_Legacy_Player1
            // 
            this.p_Legacy_Player1.BackColor = System.Drawing.SystemColors.Menu;
            this.p_Legacy_Player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Legacy_Player1.Controls.Add(this.p_Player1);
            this.p_Legacy_Player1.Controls.Add(this.l_Name);
            this.p_Legacy_Player1.Controls.Add(this.tB_Player1_Name);
            this.p_Legacy_Player1.Controls.Add(this.p_Player1_Simple);
            this.p_Legacy_Player1.Controls.Add(this.p_Player1_Extended);
            this.p_Legacy_Player1.Controls.Add(this.b_Player1_Stop);
            this.p_Legacy_Player1.Controls.Add(this.checkB_Player1_Manual);
            this.p_Legacy_Player1.Controls.Add(this.b_Player1_Play);
            this.p_Legacy_Player1.Location = new System.Drawing.Point(185, 30);
            this.p_Legacy_Player1.Name = "p_Legacy_Player1";
            this.p_Legacy_Player1.Size = new System.Drawing.Size(530, 643);
            this.p_Legacy_Player1.TabIndex = 122;
            // 
            // p_Player1
            // 
            this.p_Player1.BackColor = System.Drawing.SystemColors.WindowText;
            this.p_Player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Player1.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Player1.Location = new System.Drawing.Point(0, 0);
            this.p_Player1.Name = "p_Player1";
            this.p_Player1.Size = new System.Drawing.Size(528, 407);
            this.p_Player1.TabIndex = 63;
            // 
            // l_Name
            // 
            this.l_Name.AutoSize = true;
            this.l_Name.Location = new System.Drawing.Point(297, 417);
            this.l_Name.Name = "l_Name";
            this.l_Name.Size = new System.Drawing.Size(70, 13);
            this.l_Name.TabIndex = 62;
            this.l_Name.Text = "Player Name:";
            // 
            // tB_Player1_Name
            // 
            this.tB_Player1_Name.Location = new System.Drawing.Point(373, 414);
            this.tB_Player1_Name.Name = "tB_Player1_Name";
            this.tB_Player1_Name.Size = new System.Drawing.Size(149, 20);
            this.tB_Player1_Name.TabIndex = 55;
            this.tB_Player1_Name.Text = "LegacyPlayer 1";
            // 
            // p_Player1_Simple
            // 
            this.p_Player1_Simple.Controls.Add(this.tB_Player1_SimpleAdr);
            this.p_Player1_Simple.Controls.Add(this.l_Player1_SimpleAdr);
            this.p_Player1_Simple.Location = new System.Drawing.Point(3, 413);
            this.p_Player1_Simple.Name = "p_Player1_Simple";
            this.p_Player1_Simple.Size = new System.Drawing.Size(288, 225);
            this.p_Player1_Simple.TabIndex = 61;
            // 
            // tB_Player1_SimpleAdr
            // 
            this.tB_Player1_SimpleAdr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_SimpleAdr.Location = new System.Drawing.Point(86, 13);
            this.tB_Player1_SimpleAdr.Name = "tB_Player1_SimpleAdr";
            this.tB_Player1_SimpleAdr.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_SimpleAdr.TabIndex = 28;
            // 
            // l_Player1_SimpleAdr
            // 
            this.l_Player1_SimpleAdr.AutoSize = true;
            this.l_Player1_SimpleAdr.Location = new System.Drawing.Point(3, 16);
            this.l_Player1_SimpleAdr.Name = "l_Player1_SimpleAdr";
            this.l_Player1_SimpleAdr.Size = new System.Drawing.Size(80, 13);
            this.l_Player1_SimpleAdr.TabIndex = 27;
            this.l_Player1_SimpleAdr.Text = "RTSP Address:";
            // 
            // p_Player1_Extended
            // 
            this.p_Player1_Extended.Controls.Add(this.label1);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_Type);
            this.p_Player1_Extended.Controls.Add(this.cB_Player1_Type);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_RTSP);
            this.p_Player1_Extended.Controls.Add(this.tB_Player1_Password);
            this.p_Player1_Extended.Controls.Add(this.tB_Player1_Adr);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_Buffering);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_Password);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_Username);
            this.p_Player1_Extended.Controls.Add(this.tB_Player1_Port);
            this.p_Player1_Extended.Controls.Add(this.tB_Player1_Buffering);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_Port);
            this.p_Player1_Extended.Controls.Add(this.tB_Player1_Username);
            this.p_Player1_Extended.Controls.Add(this.tB_Player1_RTSP);
            this.p_Player1_Extended.Controls.Add(this.l_Player1_Adr);
            this.p_Player1_Extended.Location = new System.Drawing.Point(3, 413);
            this.p_Player1_Extended.Name = "p_Player1_Extended";
            this.p_Player1_Extended.Size = new System.Drawing.Size(288, 225);
            this.p_Player1_Extended.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "*Changed fields will not apply until the stream is replayed*";
            // 
            // l_Player1_Type
            // 
            this.l_Player1_Type.AutoSize = true;
            this.l_Player1_Type.Location = new System.Drawing.Point(3, 17);
            this.l_Player1_Type.Name = "l_Player1_Type";
            this.l_Player1_Type.Size = new System.Drawing.Size(77, 13);
            this.l_Player1_Type.TabIndex = 2;
            this.l_Player1_Type.Text = "Encoder Type:";
            // 
            // cB_Player1_Type
            // 
            this.cB_Player1_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_Player1_Type.FormattingEnabled = true;
            this.cB_Player1_Type.Items.AddRange(new object[] {
            "IONodes - Daylight",
            "IONodes - Thermal",
            "VIVOTEK",
            "BOSCH"});
            this.cB_Player1_Type.Location = new System.Drawing.Point(86, 14);
            this.cB_Player1_Type.Name = "cB_Player1_Type";
            this.cB_Player1_Type.Size = new System.Drawing.Size(191, 21);
            this.cB_Player1_Type.TabIndex = 5;
            this.cB_Player1_Type.Text = "Daylight";
            // 
            // l_Player1_RTSP
            // 
            this.l_Player1_RTSP.AutoSize = true;
            this.l_Player1_RTSP.Location = new System.Drawing.Point(3, 91);
            this.l_Player1_RTSP.Name = "l_Player1_RTSP";
            this.l_Player1_RTSP.Size = new System.Drawing.Size(69, 13);
            this.l_Player1_RTSP.TabIndex = 2;
            this.l_Player1_RTSP.Text = "RTSP String:";
            // 
            // tB_Player1_Password
            // 
            this.tB_Player1_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_Password.Location = new System.Drawing.Point(86, 170);
            this.tB_Player1_Password.Name = "tB_Player1_Password";
            this.tB_Player1_Password.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_Password.TabIndex = 4;
            this.tB_Player1_Password.Text = "admin";
            // 
            // tB_Player1_Adr
            // 
            this.tB_Player1_Adr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_Adr.Location = new System.Drawing.Point(86, 41);
            this.tB_Player1_Adr.Name = "tB_Player1_Adr";
            this.tB_Player1_Adr.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_Adr.TabIndex = 4;
            this.tB_Player1_Adr.Text = "192.168.1.71";
            // 
            // l_Player1_Buffering
            // 
            this.l_Player1_Buffering.AutoSize = true;
            this.l_Player1_Buffering.Location = new System.Drawing.Point(3, 117);
            this.l_Player1_Buffering.Name = "l_Player1_Buffering";
            this.l_Player1_Buffering.Size = new System.Drawing.Size(77, 13);
            this.l_Player1_Buffering.TabIndex = 2;
            this.l_Player1_Buffering.Text = "Buffering (ms): ";
            // 
            // l_Player1_Password
            // 
            this.l_Player1_Password.AutoSize = true;
            this.l_Player1_Password.Location = new System.Drawing.Point(3, 168);
            this.l_Player1_Password.Name = "l_Player1_Password";
            this.l_Player1_Password.Size = new System.Drawing.Size(56, 13);
            this.l_Player1_Password.TabIndex = 2;
            this.l_Player1_Password.Text = "Password:";
            // 
            // l_Player1_Username
            // 
            this.l_Player1_Username.AutoSize = true;
            this.l_Player1_Username.Location = new System.Drawing.Point(3, 143);
            this.l_Player1_Username.Name = "l_Player1_Username";
            this.l_Player1_Username.Size = new System.Drawing.Size(58, 13);
            this.l_Player1_Username.TabIndex = 2;
            this.l_Player1_Username.Text = "Username:";
            // 
            // tB_Player1_Port
            // 
            this.tB_Player1_Port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_Port.Location = new System.Drawing.Point(86, 67);
            this.tB_Player1_Port.Name = "tB_Player1_Port";
            this.tB_Player1_Port.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_Port.TabIndex = 4;
            this.tB_Player1_Port.Text = "554";
            // 
            // tB_Player1_Buffering
            // 
            this.tB_Player1_Buffering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_Buffering.Location = new System.Drawing.Point(86, 118);
            this.tB_Player1_Buffering.Name = "tB_Player1_Buffering";
            this.tB_Player1_Buffering.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_Buffering.TabIndex = 4;
            this.tB_Player1_Buffering.Text = "200";
            // 
            // l_Player1_Port
            // 
            this.l_Player1_Port.AutoSize = true;
            this.l_Player1_Port.Location = new System.Drawing.Point(3, 68);
            this.l_Player1_Port.Name = "l_Player1_Port";
            this.l_Player1_Port.Size = new System.Drawing.Size(29, 13);
            this.l_Player1_Port.TabIndex = 2;
            this.l_Player1_Port.Text = "Port:";
            // 
            // tB_Player1_Username
            // 
            this.tB_Player1_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_Username.Location = new System.Drawing.Point(86, 144);
            this.tB_Player1_Username.Name = "tB_Player1_Username";
            this.tB_Player1_Username.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_Username.TabIndex = 4;
            this.tB_Player1_Username.Text = "admin";
            // 
            // tB_Player1_RTSP
            // 
            this.tB_Player1_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Player1_RTSP.Location = new System.Drawing.Point(86, 92);
            this.tB_Player1_RTSP.Name = "tB_Player1_RTSP";
            this.tB_Player1_RTSP.Size = new System.Drawing.Size(191, 20);
            this.tB_Player1_RTSP.TabIndex = 4;
            this.tB_Player1_RTSP.Text = "videoinput_1:0/h264_1/onvif.stm";
            // 
            // l_Player1_Adr
            // 
            this.l_Player1_Adr.AutoSize = true;
            this.l_Player1_Adr.Location = new System.Drawing.Point(3, 43);
            this.l_Player1_Adr.Name = "l_Player1_Adr";
            this.l_Player1_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_Player1_Adr.TabIndex = 2;
            this.l_Player1_Adr.Text = "IP Address:";
            // 
            // b_Player1_Stop
            // 
            this.b_Player1_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.b_Player1_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Player1_Stop.Location = new System.Drawing.Point(429, 557);
            this.b_Player1_Stop.Name = "b_Player1_Stop";
            this.b_Player1_Stop.Size = new System.Drawing.Size(93, 25);
            this.b_Player1_Stop.TabIndex = 59;
            this.b_Player1_Stop.Text = "Stop Video Playback";
            this.b_Player1_Stop.UseVisualStyleBackColor = false;
            this.b_Player1_Stop.Visible = false;
            this.b_Player1_Stop.Click += new System.EventHandler(this.b_Player1_Stop_Click);
            // 
            // checkB_Player1_Manual
            // 
            this.checkB_Player1_Manual.AutoSize = true;
            this.checkB_Player1_Manual.Location = new System.Drawing.Point(300, 440);
            this.checkB_Player1_Manual.Name = "checkB_Player1_Manual";
            this.checkB_Player1_Manual.Size = new System.Drawing.Size(144, 17);
            this.checkB_Player1_Manual.TabIndex = 57;
            this.checkB_Player1_Manual.Text = "Extended RTSP Controls";
            this.checkB_Player1_Manual.UseVisualStyleBackColor = true;
            this.checkB_Player1_Manual.CheckedChanged += new System.EventHandler(this.checkB_Player1_Manual_CheckedChanged);
            // 
            // b_Player1_Play
            // 
            this.b_Player1_Play.BackColor = System.Drawing.SystemColors.Control;
            this.b_Player1_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Player1_Play.Location = new System.Drawing.Point(297, 587);
            this.b_Player1_Play.Name = "b_Player1_Play";
            this.b_Player1_Play.Size = new System.Drawing.Size(225, 50);
            this.b_Player1_Play.TabIndex = 56;
            this.b_Player1_Play.Text = "Play";
            this.b_Player1_Play.UseVisualStyleBackColor = false;
            this.b_Player1_Play.Click += new System.EventHandler(this.b_Player1_Play_Click);
            // 
            // l_Legacy_CP
            // 
            this.l_Legacy_CP.BackColor = System.Drawing.SystemColors.Menu;
            this.l_Legacy_CP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_Connect);
            this.l_Legacy_CP.Controls.Add(this.l_Legacy_PelcoID);
            this.l_Legacy_CP.Controls.Add(this.tB_Legacy_PelcoID);
            this.l_Legacy_CP.Controls.Add(this.l_legacy_Port);
            this.l_Legacy_CP.Controls.Add(this.tB_Legacy_Port);
            this.l_Legacy_CP.Controls.Add(this.l_Legacy_IP);
            this.l_Legacy_CP.Controls.Add(this.l_Legacy_IPCon);
            this.l_Legacy_CP.Controls.Add(this.tB_Legacy_IP);
            this.l_Legacy_CP.Controls.Add(this.l_Legacy_PTZ);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_Up);
            this.l_Legacy_CP.Controls.Add(this.Legacy_JoyBack);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_FocusNeg);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_ZoomPos);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_Down);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_Left);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_ZoomNeg);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_FocusPos);
            this.l_Legacy_CP.Controls.Add(this.b_Legacy_Right);
            this.l_Legacy_CP.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_Legacy_CP.Location = new System.Drawing.Point(0, 0);
            this.l_Legacy_CP.Name = "l_Legacy_CP";
            this.l_Legacy_CP.Size = new System.Drawing.Size(179, 681);
            this.l_Legacy_CP.TabIndex = 114;
            // 
            // b_Legacy_Connect
            // 
            this.b_Legacy_Connect.BackColor = System.Drawing.SystemColors.Control;
            this.b_Legacy_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_Connect.Location = new System.Drawing.Point(105, 135);
            this.b_Legacy_Connect.Name = "b_Legacy_Connect";
            this.b_Legacy_Connect.Size = new System.Drawing.Size(57, 29);
            this.b_Legacy_Connect.TabIndex = 121;
            this.b_Legacy_Connect.Text = "Connect";
            this.b_Legacy_Connect.UseVisualStyleBackColor = false;
            this.b_Legacy_Connect.Click += new System.EventHandler(this.b_Legacy_Connect_Click);
            // 
            // l_Legacy_PelcoID
            // 
            this.l_Legacy_PelcoID.AutoSize = true;
            this.l_Legacy_PelcoID.Location = new System.Drawing.Point(11, 112);
            this.l_Legacy_PelcoID.Name = "l_Legacy_PelcoID";
            this.l_Legacy_PelcoID.Size = new System.Drawing.Size(45, 13);
            this.l_Legacy_PelcoID.TabIndex = 120;
            this.l_Legacy_PelcoID.Text = "PelcoID";
            // 
            // tB_Legacy_PelcoID
            // 
            this.tB_Legacy_PelcoID.Location = new System.Drawing.Point(68, 109);
            this.tB_Legacy_PelcoID.Name = "tB_Legacy_PelcoID";
            this.tB_Legacy_PelcoID.Size = new System.Drawing.Size(94, 20);
            this.tB_Legacy_PelcoID.TabIndex = 119;
            this.tB_Legacy_PelcoID.TextChanged += new System.EventHandler(this.tB_Legacy_PelcoID_TextChanged);
            // 
            // l_legacy_Port
            // 
            this.l_legacy_Port.AutoSize = true;
            this.l_legacy_Port.Location = new System.Drawing.Point(11, 86);
            this.l_legacy_Port.Name = "l_legacy_Port";
            this.l_legacy_Port.Size = new System.Drawing.Size(26, 13);
            this.l_legacy_Port.TabIndex = 118;
            this.l_legacy_Port.Text = "Port";
            // 
            // tB_Legacy_Port
            // 
            this.tB_Legacy_Port.Location = new System.Drawing.Point(68, 83);
            this.tB_Legacy_Port.Name = "tB_Legacy_Port";
            this.tB_Legacy_Port.Size = new System.Drawing.Size(94, 20);
            this.tB_Legacy_Port.TabIndex = 117;
            // 
            // l_Legacy_IP
            // 
            this.l_Legacy_IP.AutoSize = true;
            this.l_Legacy_IP.Location = new System.Drawing.Point(11, 60);
            this.l_Legacy_IP.Name = "l_Legacy_IP";
            this.l_Legacy_IP.Size = new System.Drawing.Size(17, 13);
            this.l_Legacy_IP.TabIndex = 116;
            this.l_Legacy_IP.Text = "IP";
            // 
            // l_Legacy_IPCon
            // 
            this.l_Legacy_IPCon.AutoSize = true;
            this.l_Legacy_IPCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Legacy_IPCon.Location = new System.Drawing.Point(8, 29);
            this.l_Legacy_IPCon.Name = "l_Legacy_IPCon";
            this.l_Legacy_IPCon.Size = new System.Drawing.Size(101, 24);
            this.l_Legacy_IPCon.TabIndex = 115;
            this.l_Legacy_IPCon.Text = "IP Control";
            // 
            // tB_Legacy_IP
            // 
            this.tB_Legacy_IP.Location = new System.Drawing.Point(68, 57);
            this.tB_Legacy_IP.Name = "tB_Legacy_IP";
            this.tB_Legacy_IP.Size = new System.Drawing.Size(94, 20);
            this.tB_Legacy_IP.TabIndex = 114;
            // 
            // l_Legacy_PTZ
            // 
            this.l_Legacy_PTZ.AutoSize = true;
            this.l_Legacy_PTZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.l_Legacy_PTZ.Location = new System.Drawing.Point(11, 175);
            this.l_Legacy_PTZ.Name = "l_Legacy_PTZ";
            this.l_Legacy_PTZ.Size = new System.Drawing.Size(49, 24);
            this.l_Legacy_PTZ.TabIndex = 113;
            this.l_Legacy_PTZ.Text = "PTZ";
            this.l_Legacy_PTZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // b_Legacy_Up
            // 
            this.b_Legacy_Up.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_Legacy_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_Up.Location = new System.Drawing.Point(63, 358);
            this.b_Legacy_Up.Name = "b_Legacy_Up";
            this.b_Legacy_Up.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_Up.TabIndex = 106;
            this.b_Legacy_Up.Text = "Up";
            this.b_Legacy_Up.UseVisualStyleBackColor = false;
            this.b_Legacy_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Up_MouseDown);
            this.b_Legacy_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // Legacy_JoyBack
            // 
            this.Legacy_JoyBack.BackColor = System.Drawing.Color.Transparent;
            this.Legacy_JoyBack.Location = new System.Drawing.Point(13, 202);
            this.Legacy_JoyBack.MaximumSize = new System.Drawing.Size(150, 150);
            this.Legacy_JoyBack.MinimumSize = new System.Drawing.Size(150, 150);
            this.Legacy_JoyBack.Name = "Legacy_JoyBack";
            this.Legacy_JoyBack.Size = new System.Drawing.Size(150, 150);
            this.Legacy_JoyBack.TabIndex = 112;
            this.Legacy_JoyBack.TabStop = false;
            this.Legacy_JoyBack.JoyReleased += new System.EventHandler(this.JoyBack_JoyReleased);
            // 
            // b_Legacy_FocusNeg
            // 
            this.b_Legacy_FocusNeg.BackColor = System.Drawing.Color.YellowGreen;
            this.b_Legacy_FocusNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_FocusNeg.Location = new System.Drawing.Point(10, 422);
            this.b_Legacy_FocusNeg.Name = "b_Legacy_FocusNeg";
            this.b_Legacy_FocusNeg.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_FocusNeg.TabIndex = 105;
            this.b_Legacy_FocusNeg.Text = "F-";
            this.b_Legacy_FocusNeg.UseVisualStyleBackColor = false;
            this.b_Legacy_FocusNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomNeg_MouseDown);
            this.b_Legacy_FocusNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_Legacy_ZoomPos
            // 
            this.b_Legacy_ZoomPos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_Legacy_ZoomPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_ZoomPos.Location = new System.Drawing.Point(116, 358);
            this.b_Legacy_ZoomPos.Name = "b_Legacy_ZoomPos";
            this.b_Legacy_ZoomPos.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_ZoomPos.TabIndex = 102;
            this.b_Legacy_ZoomPos.Text = "Z+";
            this.b_Legacy_ZoomPos.UseVisualStyleBackColor = false;
            this.b_Legacy_ZoomPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusPos_MouseDown);
            this.b_Legacy_ZoomPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_Legacy_Down
            // 
            this.b_Legacy_Down.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_Legacy_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_Down.Location = new System.Drawing.Point(63, 422);
            this.b_Legacy_Down.Name = "b_Legacy_Down";
            this.b_Legacy_Down.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_Down.TabIndex = 107;
            this.b_Legacy_Down.Text = "Down";
            this.b_Legacy_Down.UseVisualStyleBackColor = false;
            this.b_Legacy_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Down_MouseDown);
            this.b_Legacy_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_Legacy_Left
            // 
            this.b_Legacy_Left.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_Legacy_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_Left.Location = new System.Drawing.Point(10, 390);
            this.b_Legacy_Left.Name = "b_Legacy_Left";
            this.b_Legacy_Left.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_Left.TabIndex = 109;
            this.b_Legacy_Left.Text = "Left";
            this.b_Legacy_Left.UseVisualStyleBackColor = false;
            this.b_Legacy_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Left_MouseDown);
            this.b_Legacy_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_Legacy_ZoomNeg
            // 
            this.b_Legacy_ZoomNeg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_Legacy_ZoomNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_ZoomNeg.Location = new System.Drawing.Point(116, 422);
            this.b_Legacy_ZoomNeg.Name = "b_Legacy_ZoomNeg";
            this.b_Legacy_ZoomNeg.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_ZoomNeg.TabIndex = 104;
            this.b_Legacy_ZoomNeg.Text = "Z-";
            this.b_Legacy_ZoomNeg.UseVisualStyleBackColor = false;
            this.b_Legacy_ZoomNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomNeg_MouseDown);
            this.b_Legacy_ZoomNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_Legacy_FocusPos
            // 
            this.b_Legacy_FocusPos.BackColor = System.Drawing.Color.YellowGreen;
            this.b_Legacy_FocusPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_FocusPos.Location = new System.Drawing.Point(10, 358);
            this.b_Legacy_FocusPos.Name = "b_Legacy_FocusPos";
            this.b_Legacy_FocusPos.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_FocusPos.TabIndex = 103;
            this.b_Legacy_FocusPos.Text = "F+";
            this.b_Legacy_FocusPos.UseVisualStyleBackColor = false;
            this.b_Legacy_FocusPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomPos_MouseDown);
            this.b_Legacy_FocusPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_Legacy_Right
            // 
            this.b_Legacy_Right.BackColor = System.Drawing.Color.LightSkyBlue;
            this.b_Legacy_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Legacy_Right.Location = new System.Drawing.Point(116, 390);
            this.b_Legacy_Right.Name = "b_Legacy_Right";
            this.b_Legacy_Right.Size = new System.Drawing.Size(50, 30);
            this.b_Legacy_Right.TabIndex = 108;
            this.b_Legacy_Right.Text = "Right";
            this.b_Legacy_Right.UseVisualStyleBackColor = false;
            this.b_Legacy_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Right_MouseDown);
            this.b_Legacy_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
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
            // p_PTZ_Sliders
            // 
            this.p_PTZ_Sliders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.p_PTZ_Sliders.Controls.Add(this.l_PTZ_SlidersFPercent);
            this.p_PTZ_Sliders.Controls.Add(this.tB_PTZ_SlidersFText);
            this.p_PTZ_Sliders.Controls.Add(this.l_PTZ_SlidersFocus);
            this.p_PTZ_Sliders.Controls.Add(this.slider_PTZ_AbsFocus);
            this.p_PTZ_Sliders.Controls.Add(this.l_PTZ_SliderZPercent);
            this.p_PTZ_Sliders.Controls.Add(this.tB_PTZ_SlidersZText);
            this.p_PTZ_Sliders.Controls.Add(this.l_PTZ_SliderZoom);
            this.p_PTZ_Sliders.Controls.Add(this.slider_PTZ_AbsZoom);
            this.p_PTZ_Sliders.Location = new System.Drawing.Point(43, 320);
            this.p_PTZ_Sliders.Name = "p_PTZ_Sliders";
            this.p_PTZ_Sliders.Size = new System.Drawing.Size(200, 68);
            this.p_PTZ_Sliders.TabIndex = 101;
            // 
            // l_PTZ_SlidersFPercent
            // 
            this.l_PTZ_SlidersFPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_PTZ_SlidersFPercent.AutoSize = true;
            this.l_PTZ_SlidersFPercent.Location = new System.Drawing.Point(166, 50);
            this.l_PTZ_SlidersFPercent.Name = "l_PTZ_SlidersFPercent";
            this.l_PTZ_SlidersFPercent.Size = new System.Drawing.Size(15, 13);
            this.l_PTZ_SlidersFPercent.TabIndex = 7;
            this.l_PTZ_SlidersFPercent.Text = "%";
            // 
            // tB_PTZ_SlidersFText
            // 
            this.tB_PTZ_SlidersFText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tB_PTZ_SlidersFText.Location = new System.Drawing.Point(127, 47);
            this.tB_PTZ_SlidersFText.Name = "tB_PTZ_SlidersFText";
            this.tB_PTZ_SlidersFText.Size = new System.Drawing.Size(39, 20);
            this.tB_PTZ_SlidersFText.TabIndex = 6;
            this.tB_PTZ_SlidersFText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_PTZ_SlidersFText_KeyPress);
            this.tB_PTZ_SlidersFText.Leave += new System.EventHandler(this.tB_PTZ_SlidersFText_Leave);
            // 
            // l_PTZ_SlidersFocus
            // 
            this.l_PTZ_SlidersFocus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_PTZ_SlidersFocus.AutoSize = true;
            this.l_PTZ_SlidersFocus.Location = new System.Drawing.Point(129, 31);
            this.l_PTZ_SlidersFocus.Name = "l_PTZ_SlidersFocus";
            this.l_PTZ_SlidersFocus.Size = new System.Drawing.Size(36, 13);
            this.l_PTZ_SlidersFocus.TabIndex = 4;
            this.l_PTZ_SlidersFocus.Text = "Focus";
            // 
            // slider_PTZ_AbsFocus
            // 
            this.slider_PTZ_AbsFocus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.slider_PTZ_AbsFocus.Location = new System.Drawing.Point(103, 4);
            this.slider_PTZ_AbsFocus.Maximum = 100;
            this.slider_PTZ_AbsFocus.Name = "slider_PTZ_AbsFocus";
            this.slider_PTZ_AbsFocus.Size = new System.Drawing.Size(94, 45);
            this.slider_PTZ_AbsFocus.TabIndex = 5;
            this.slider_PTZ_AbsFocus.TickFrequency = 0;
            this.slider_PTZ_AbsFocus.Scroll += new System.EventHandler(this.slider_PTZ_AbsFocus_Scroll);
            this.slider_PTZ_AbsFocus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_PTZ_AbsFocus_MouseDown);
            this.slider_PTZ_AbsFocus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_PTZ_AbsFocus_MouseUp);
            // 
            // l_PTZ_SliderZPercent
            // 
            this.l_PTZ_SliderZPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_PTZ_SliderZPercent.AutoSize = true;
            this.l_PTZ_SliderZPercent.Location = new System.Drawing.Point(63, 49);
            this.l_PTZ_SliderZPercent.Name = "l_PTZ_SliderZPercent";
            this.l_PTZ_SliderZPercent.Size = new System.Drawing.Size(15, 13);
            this.l_PTZ_SliderZPercent.TabIndex = 3;
            this.l_PTZ_SliderZPercent.Text = "%";
            // 
            // tB_PTZ_SlidersZText
            // 
            this.tB_PTZ_SlidersZText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tB_PTZ_SlidersZText.Location = new System.Drawing.Point(24, 46);
            this.tB_PTZ_SlidersZText.Name = "tB_PTZ_SlidersZText";
            this.tB_PTZ_SlidersZText.Size = new System.Drawing.Size(39, 20);
            this.tB_PTZ_SlidersZText.TabIndex = 2;
            this.tB_PTZ_SlidersZText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_PTZ_SlidersZText_KeyPress);
            this.tB_PTZ_SlidersZText.Leave += new System.EventHandler(this.tB_PTZ_SlidersZText_Leave);
            // 
            // l_PTZ_SliderZoom
            // 
            this.l_PTZ_SliderZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_PTZ_SliderZoom.AutoSize = true;
            this.l_PTZ_SliderZoom.Location = new System.Drawing.Point(26, 30);
            this.l_PTZ_SliderZoom.Name = "l_PTZ_SliderZoom";
            this.l_PTZ_SliderZoom.Size = new System.Drawing.Size(34, 13);
            this.l_PTZ_SliderZoom.TabIndex = 0;
            this.l_PTZ_SliderZoom.Text = "Zoom";
            // 
            // slider_PTZ_AbsZoom
            // 
            this.slider_PTZ_AbsZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.slider_PTZ_AbsZoom.Location = new System.Drawing.Point(0, 3);
            this.slider_PTZ_AbsZoom.Maximum = 100;
            this.slider_PTZ_AbsZoom.Name = "slider_PTZ_AbsZoom";
            this.slider_PTZ_AbsZoom.Size = new System.Drawing.Size(94, 45);
            this.slider_PTZ_AbsZoom.TabIndex = 1;
            this.slider_PTZ_AbsZoom.TickFrequency = 0;
            this.slider_PTZ_AbsZoom.Scroll += new System.EventHandler(this.slider_PTZ_AbsZoom_Scroll);
            this.slider_PTZ_AbsZoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_PTZ_AbsZoom_MouseDown);
            this.slider_PTZ_AbsZoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_PTZ_AbsZoom_MouseUp);
            // 
            // p_PlayerPanel
            // 
            this.p_PlayerPanel.AllowDrop = true;
            this.p_PlayerPanel.BackColor = System.Drawing.Color.Black;
            this.p_PlayerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_PlayerPanel.Controls.Add(this.p_PTZ_Sliders);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.p_PlayerPanel);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.p_Legacy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSUtility2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.p_Legacy.ResumeLayout(false);
            this.p_Legacy_Player1.ResumeLayout(false);
            this.p_Legacy_Player1.PerformLayout();
            this.p_Player1_Simple.ResumeLayout(false);
            this.p_Player1_Simple.PerformLayout();
            this.p_Player1_Extended.ResumeLayout(false);
            this.p_Player1_Extended.PerformLayout();
            this.l_Legacy_CP.ResumeLayout(false);
            this.l_Legacy_CP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Legacy_JoyBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JoyBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Panoramic)).EndInit();
            this.p_PTZ_Sliders.ResumeLayout(false);
            this.p_PTZ_Sliders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_PTZ_AbsFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_PTZ_AbsZoom)).EndInit();
            this.p_PlayerPanel.ResumeLayout(false);
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
        public ToolStripMenuItem Menu_QC_Pan;
        public ToolStripMenuItem Menu_QC_Tilt;
        public ToolStripMenuItem Menu_Window_Presets;
        public ToolStripMenuItem Menu_Settings;
        public ToolStripMenuItem Menu_Settings_Open;
        public ToolStripMenuItem Menu_Settings_Keyboard;
        public ToolStripMenuItem Menu_Settings_Lite;
        public ToolStripMenuItem Menu_QC_Custom;
        private ToolStripMenuItem Menu_QC_Zoom;
        public ToolStripMenuItem Menu_Settings_Config;
        public ToolStripMenuItem Menu_Settings_Config_Import;
        public ToolStripMenuItem Menu_Settings_Config_Export;
        public ToolStripMenuItem Menu_Settings_Panels;
        public ToolStripMenuItem Menu_Settings_Panels_QF;
        public ToolStripMenuItem Menu_Settings_Panels_IP;
        public ToolStripMenuItem Menu_Settings_Panels_Custom;
        public ToolStripMenuItem Menu_Settings_Panels_CP;
        private ToolStripMenuItem Menu_Recording;
        public ToolStripMenuItem Menu_Recording_Video;
        private ToolStripMenuItem Menu_Recording_Video_SSUtility;
        private ToolStripMenuItem Menu_Recording_Video_MainPlayer;
        private ToolStripMenuItem Menu_Recording_Snapshot;
        private ToolStripMenuItem Menu_Recording_Snapshot_Single;
        private ToolStripMenuItem Menu_Recording_Snapshot_Panoramic;
        private ToolStripMenuItem Menu_Recording_Collection;
        public ToolStripMenuItem Menu_Recording_StopRecording;
        private ToolStripMenuItem Menu_Settings_ConnectionSettings;
        private ToolStripMenuItem Menu_Recording_Snapshot_All;
        public ToolStripMenuItem Menu_Recording_Video_Global;
        public ToolStripMenuItem Menu_RecordIndicator;
        public Panel p_Legacy;
        private Label l_Legacy_PTZ;
        public JoyBack Legacy_JoyBack;
        public Button b_Legacy_ZoomPos;
        public Button b_Legacy_Left;
        public Button b_Legacy_FocusPos;
        public Button b_Legacy_Right;
        public Button b_Legacy_ZoomNeg;
        public Button b_Legacy_Down;
        public Button b_Legacy_FocusNeg;
        public Button b_Legacy_Up;
        private Panel l_Legacy_CP;
        private Label l_Legacy_PelcoID;
        public TextBox tB_Legacy_PelcoID;
        private Label l_legacy_Port;
        public TextBox tB_Legacy_Port;
        private Label l_Legacy_IP;
        private Label l_Legacy_IPCon;
        public TextBox tB_Legacy_IP;
        public Button b_Legacy_Connect;
        public Panel p_Legacy_Player1;
        public Panel p_Legacy_Player2;
        public Panel p_Player1;
        private Label l_Name;
        public TextBox tB_Player1_Name;
        public Panel p_Player1_Simple;
        public TextBox tB_Player1_SimpleAdr;
        private Label l_Player1_SimpleAdr;
        public Panel p_Player1_Extended;
        public Label label1;
        private Label l_Player1_Type;
        public ComboBox cB_Player1_Type;
        private Label l_Player1_RTSP;
        public TextBox tB_Player1_Password;
        public TextBox tB_Player1_Adr;
        private Label l_Player1_Buffering;
        private Label l_Player1_Password;
        private Label l_Player1_Username;
        public TextBox tB_Player1_Port;
        public TextBox tB_Player1_Buffering;
        private Label l_Player1_Port;
        public TextBox tB_Player1_Username;
        public TextBox tB_Player1_RTSP;
        private Label l_Player1_Adr;
        public Button b_Player1_Stop;
        public CheckBox checkB_Player1_Manual;
        public Button b_Player1_Play;
        public Button b_PTZ_Up;
        public Button b_PTZ_FocusNeg;
        public Button b_PTZ_Down;
        public Button b_PTZ_ZoomNeg;
        public Button b_PTZ_Right;
        public Button b_PTZ_FocusPos;
        public Button b_PTZ_Left;
        public Button b_PTZ_ZoomPos;
        public Button b_PTZ_Thermal;
        public Button b_Open;
        public Button b_PTZ_Daylight;
        public JoyBack JoyBack;
        public PictureBox pB_Panoramic;
        private Panel p_PTZ_Sliders;
        private Label l_PTZ_SlidersFPercent;
        private TextBox tB_PTZ_SlidersFText;
        private Label l_PTZ_SlidersFocus;
        private TrackBar slider_PTZ_AbsFocus;
        private Label l_PTZ_SliderZPercent;
        private TextBox tB_PTZ_SlidersZText;
        private Label l_PTZ_SliderZoom;
        private TrackBar slider_PTZ_AbsZoom;
        public Panel p_PlayerPanel;
    } // end of partial class MainForm
} // end of namespace SSLUtility2
