using System;

namespace SSLUtility2
{
    partial class PresetPanel
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
            this.tC_Presets_Default = new System.Windows.Forms.TabControl();
            this.adminPage = new System.Windows.Forms.TabPage();
            this.b_Presets_Admin_DefaultMen = new System.Windows.Forms.Button();
            this.b_Presets_Admin_DebugToggle = new System.Windows.Forms.Button();
            this.b_Presets_Admin_MechMen = new System.Windows.Forms.Button();
            this.b_Presets_Admin_SetupMen = new System.Windows.Forms.Button();
            this.daylightPage = new System.Windows.Forms.TabPage();
            this.b_Presets_Daylight_Stabilizer = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_WDR = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_Wiper = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_AF = new System.Windows.Forms.Button();
            this.b_Presets_Daylight_ColMono = new System.Windows.Forms.Button();
            this.thermalPage = new System.Windows.Forms.TabPage();
            this.b_Presets_ContrastPos = new System.Windows.Forms.Button();
            this.b_Presets_ContrastNeg = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_BrightPos = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_BrightNeg = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_ICEPos = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_ICENeg = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_ICE = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_WhiteBlack = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_NUC = new System.Windows.Forms.Button();
            this.b_Presets_Thermal_AF = new System.Windows.Forms.Button();
            this.slgPage = new System.Windows.Forms.TabPage();
            this.b_Presets_SLG_AllLightsOff = new System.Windows.Forms.Button();
            this.b_Presets_SLG_SteadyGreen = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingRG = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingWhite = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingRed = new System.Windows.Forms.Button();
            this.b_Presets_SLG_SteadyRed = new System.Windows.Forms.Button();
            this.b_Presets_SLG_FlashingGreen = new System.Windows.Forms.Button();
            this.peakbeamPage = new System.Windows.Forms.TabPage();
            this.b_Presets_Peak_SteadyLamp = new System.Windows.Forms.Button();
            this.b_Presets_Peak_StopZoom = new System.Windows.Forms.Button();
            this.b_Presets_Peak_ZoomOut = new System.Windows.Forms.Button();
            this.b_Presets_Peak_ZoomIn = new System.Windows.Forms.Button();
            this.b_Presets_Peak_LampOff = new System.Windows.Forms.Button();
            this.b_Presets_Peak_StrobeLamp = new System.Windows.Forms.Button();
            this.charmPage = new System.Windows.Forms.TabPage();
            this.b_Presets_CHARM_Aquire = new System.Windows.Forms.Button();
            this.b_Presets_CHARM_Standby = new System.Windows.Forms.Button();
            this.l_Presets_Default = new System.Windows.Forms.Label();
            this.tC_Presets_Default.SuspendLayout();
            this.adminPage.SuspendLayout();
            this.daylightPage.SuspendLayout();
            this.thermalPage.SuspendLayout();
            this.slgPage.SuspendLayout();
            this.peakbeamPage.SuspendLayout();
            this.charmPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tC_Presets_Default
            // 
            this.tC_Presets_Default.Controls.Add(this.adminPage);
            this.tC_Presets_Default.Controls.Add(this.daylightPage);
            this.tC_Presets_Default.Controls.Add(this.thermalPage);
            this.tC_Presets_Default.Controls.Add(this.slgPage);
            this.tC_Presets_Default.Controls.Add(this.peakbeamPage);
            this.tC_Presets_Default.Controls.Add(this.charmPage);
            this.tC_Presets_Default.Location = new System.Drawing.Point(12, 61);
            this.tC_Presets_Default.Name = "tC_Presets_Default";
            this.tC_Presets_Default.SelectedIndex = 0;
            this.tC_Presets_Default.Size = new System.Drawing.Size(239, 257);
            this.tC_Presets_Default.TabIndex = 77;
            // 
            // adminPage
            // 
            this.adminPage.Controls.Add(this.b_Presets_Admin_DefaultMen);
            this.adminPage.Controls.Add(this.b_Presets_Admin_DebugToggle);
            this.adminPage.Controls.Add(this.b_Presets_Admin_MechMen);
            this.adminPage.Controls.Add(this.b_Presets_Admin_SetupMen);
            this.adminPage.Location = new System.Drawing.Point(4, 22);
            this.adminPage.Name = "adminPage";
            this.adminPage.Size = new System.Drawing.Size(231, 231);
            this.adminPage.TabIndex = 3;
            this.adminPage.Text = "Admin";
            this.adminPage.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Admin_DefaultMen
            // 
            this.b_Presets_Admin_DefaultMen.Location = new System.Drawing.Point(7, 71);
            this.b_Presets_Admin_DefaultMen.Name = "b_Presets_Admin_DefaultMen";
            this.b_Presets_Admin_DefaultMen.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_DefaultMen.TabIndex = 10;
            this.b_Presets_Admin_DefaultMen.Text = "Default Menu";
            this.b_Presets_Admin_DefaultMen.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Admin_DebugToggle
            // 
            this.b_Presets_Admin_DebugToggle.Location = new System.Drawing.Point(7, 100);
            this.b_Presets_Admin_DebugToggle.Name = "b_Presets_Admin_DebugToggle";
            this.b_Presets_Admin_DebugToggle.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_DebugToggle.TabIndex = 10;
            this.b_Presets_Admin_DebugToggle.Text = "Debug Toggle";
            this.b_Presets_Admin_DebugToggle.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Admin_MechMen
            // 
            this.b_Presets_Admin_MechMen.Location = new System.Drawing.Point(7, 12);
            this.b_Presets_Admin_MechMen.Name = "b_Presets_Admin_MechMen";
            this.b_Presets_Admin_MechMen.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_MechMen.TabIndex = 9;
            this.b_Presets_Admin_MechMen.Text = "Mechanical Menu";
            this.b_Presets_Admin_MechMen.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Admin_SetupMen
            // 
            this.b_Presets_Admin_SetupMen.Location = new System.Drawing.Point(7, 41);
            this.b_Presets_Admin_SetupMen.Name = "b_Presets_Admin_SetupMen";
            this.b_Presets_Admin_SetupMen.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Admin_SetupMen.TabIndex = 9;
            this.b_Presets_Admin_SetupMen.Text = "Setup Menu";
            this.b_Presets_Admin_SetupMen.UseVisualStyleBackColor = true;
            // 
            // daylightPage
            // 
            this.daylightPage.Controls.Add(this.b_Presets_Daylight_Stabilizer);
            this.daylightPage.Controls.Add(this.b_Presets_Daylight_WDR);
            this.daylightPage.Controls.Add(this.b_Presets_Daylight_Wiper);
            this.daylightPage.Controls.Add(this.b_Presets_Daylight_AF);
            this.daylightPage.Controls.Add(this.b_Presets_Daylight_ColMono);
            this.daylightPage.Location = new System.Drawing.Point(4, 22);
            this.daylightPage.Name = "daylightPage";
            this.daylightPage.Padding = new System.Windows.Forms.Padding(3);
            this.daylightPage.Size = new System.Drawing.Size(231, 231);
            this.daylightPage.TabIndex = 0;
            this.daylightPage.Text = "Daylight";
            this.daylightPage.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Daylight_Stabilizer
            // 
            this.b_Presets_Daylight_Stabilizer.Location = new System.Drawing.Point(7, 133);
            this.b_Presets_Daylight_Stabilizer.Name = "b_Presets_Daylight_Stabilizer";
            this.b_Presets_Daylight_Stabilizer.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_Stabilizer.TabIndex = 6;
            this.b_Presets_Daylight_Stabilizer.Text = "Toggle Stabiliser";
            this.b_Presets_Daylight_Stabilizer.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Daylight_WDR
            // 
            this.b_Presets_Daylight_WDR.Location = new System.Drawing.Point(7, 100);
            this.b_Presets_Daylight_WDR.Name = "b_Presets_Daylight_WDR";
            this.b_Presets_Daylight_WDR.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_WDR.TabIndex = 6;
            this.b_Presets_Daylight_WDR.Text = "WDR On / Off (Sony Only)";
            this.b_Presets_Daylight_WDR.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Daylight_Wiper
            // 
            this.b_Presets_Daylight_Wiper.Location = new System.Drawing.Point(7, 69);
            this.b_Presets_Daylight_Wiper.Name = "b_Presets_Daylight_Wiper";
            this.b_Presets_Daylight_Wiper.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_Wiper.TabIndex = 6;
            this.b_Presets_Daylight_Wiper.Text = "Wiper";
            this.b_Presets_Daylight_Wiper.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Daylight_AF
            // 
            this.b_Presets_Daylight_AF.Location = new System.Drawing.Point(7, 4);
            this.b_Presets_Daylight_AF.Name = "b_Presets_Daylight_AF";
            this.b_Presets_Daylight_AF.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_AF.TabIndex = 6;
            this.b_Presets_Daylight_AF.Text = "AutoFocus ";
            this.b_Presets_Daylight_AF.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Daylight_ColMono
            // 
            this.b_Presets_Daylight_ColMono.Location = new System.Drawing.Point(7, 37);
            this.b_Presets_Daylight_ColMono.Name = "b_Presets_Daylight_ColMono";
            this.b_Presets_Daylight_ColMono.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_Daylight_ColMono.TabIndex = 6;
            this.b_Presets_Daylight_ColMono.Text = "Colour / Mono";
            this.b_Presets_Daylight_ColMono.UseVisualStyleBackColor = true;
            // 
            // thermalPage
            // 
            this.thermalPage.Controls.Add(this.b_Presets_ContrastPos);
            this.thermalPage.Controls.Add(this.b_Presets_ContrastNeg);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_BrightPos);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_BrightNeg);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_ICEPos);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_ICENeg);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_ICE);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_WhiteBlack);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_NUC);
            this.thermalPage.Controls.Add(this.b_Presets_Thermal_AF);
            this.thermalPage.Location = new System.Drawing.Point(4, 22);
            this.thermalPage.Name = "thermalPage";
            this.thermalPage.Padding = new System.Windows.Forms.Padding(3);
            this.thermalPage.Size = new System.Drawing.Size(231, 231);
            this.thermalPage.TabIndex = 1;
            this.thermalPage.Text = "Thermal";
            this.thermalPage.UseVisualStyleBackColor = true;
            // 
            // b_Presets_ContrastPos
            // 
            this.b_Presets_ContrastPos.Location = new System.Drawing.Point(127, 198);
            this.b_Presets_ContrastPos.Name = "b_Presets_ContrastPos";
            this.b_Presets_ContrastPos.Size = new System.Drawing.Size(91, 27);
            this.b_Presets_ContrastPos.TabIndex = 6;
            this.b_Presets_ContrastPos.Text = "Contrast +";
            this.b_Presets_ContrastPos.UseVisualStyleBackColor = true;
            this.b_Presets_ContrastPos.Click += new System.EventHandler(this.b_Presets_ContrastPos_Click);
            // 
            // b_Presets_ContrastNeg
            // 
            this.b_Presets_ContrastNeg.Location = new System.Drawing.Point(6, 198);
            this.b_Presets_ContrastNeg.Name = "b_Presets_ContrastNeg";
            this.b_Presets_ContrastNeg.Size = new System.Drawing.Size(91, 27);
            this.b_Presets_ContrastNeg.TabIndex = 6;
            this.b_Presets_ContrastNeg.Text = "Contrast -";
            this.b_Presets_ContrastNeg.UseVisualStyleBackColor = true;
            this.b_Presets_ContrastNeg.Click += new System.EventHandler(this.b_Presets_ContrastNeg_Click);
            // 
            // b_Presets_Thermal_BrightPos
            // 
            this.b_Presets_Thermal_BrightPos.Location = new System.Drawing.Point(118, 168);
            this.b_Presets_Thermal_BrightPos.Name = "b_Presets_Thermal_BrightPos";
            this.b_Presets_Thermal_BrightPos.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Thermal_BrightPos.TabIndex = 6;
            this.b_Presets_Thermal_BrightPos.Text = "Brightness +";
            this.b_Presets_Thermal_BrightPos.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_BrightNeg
            // 
            this.b_Presets_Thermal_BrightNeg.Location = new System.Drawing.Point(6, 168);
            this.b_Presets_Thermal_BrightNeg.Name = "b_Presets_Thermal_BrightNeg";
            this.b_Presets_Thermal_BrightNeg.Size = new System.Drawing.Size(101, 27);
            this.b_Presets_Thermal_BrightNeg.TabIndex = 6;
            this.b_Presets_Thermal_BrightNeg.Text = "Brightness -";
            this.b_Presets_Thermal_BrightNeg.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_ICEPos
            // 
            this.b_Presets_Thermal_ICEPos.Location = new System.Drawing.Point(118, 135);
            this.b_Presets_Thermal_ICEPos.Name = "b_Presets_Thermal_ICEPos";
            this.b_Presets_Thermal_ICEPos.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Thermal_ICEPos.TabIndex = 6;
            this.b_Presets_Thermal_ICEPos.Text = "ICE / CLAHE +";
            this.b_Presets_Thermal_ICEPos.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_ICENeg
            // 
            this.b_Presets_Thermal_ICENeg.Location = new System.Drawing.Point(6, 135);
            this.b_Presets_Thermal_ICENeg.Name = "b_Presets_Thermal_ICENeg";
            this.b_Presets_Thermal_ICENeg.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Thermal_ICENeg.TabIndex = 6;
            this.b_Presets_Thermal_ICENeg.Text = "ICE / CLAHE -";
            this.b_Presets_Thermal_ICENeg.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_ICE
            // 
            this.b_Presets_Thermal_ICE.Location = new System.Drawing.Point(6, 102);
            this.b_Presets_Thermal_ICE.Name = "b_Presets_Thermal_ICE";
            this.b_Presets_Thermal_ICE.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_ICE.TabIndex = 6;
            this.b_Presets_Thermal_ICE.Text = "Toggle ICE / CLAHE";
            this.b_Presets_Thermal_ICE.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_WhiteBlack
            // 
            this.b_Presets_Thermal_WhiteBlack.Location = new System.Drawing.Point(6, 69);
            this.b_Presets_Thermal_WhiteBlack.Name = "b_Presets_Thermal_WhiteBlack";
            this.b_Presets_Thermal_WhiteBlack.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_WhiteBlack.TabIndex = 6;
            this.b_Presets_Thermal_WhiteBlack.Text = "White Hot / Black Hot";
            this.b_Presets_Thermal_WhiteBlack.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_NUC
            // 
            this.b_Presets_Thermal_NUC.Location = new System.Drawing.Point(6, 38);
            this.b_Presets_Thermal_NUC.Name = "b_Presets_Thermal_NUC";
            this.b_Presets_Thermal_NUC.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_NUC.TabIndex = 6;
            this.b_Presets_Thermal_NUC.Text = "Do NUC";
            this.b_Presets_Thermal_NUC.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Thermal_AF
            // 
            this.b_Presets_Thermal_AF.Location = new System.Drawing.Point(6, 6);
            this.b_Presets_Thermal_AF.Name = "b_Presets_Thermal_AF";
            this.b_Presets_Thermal_AF.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Thermal_AF.TabIndex = 6;
            this.b_Presets_Thermal_AF.Text = "AutoFocus";
            this.b_Presets_Thermal_AF.UseVisualStyleBackColor = true;
            // 
            // slgPage
            // 
            this.slgPage.Controls.Add(this.b_Presets_SLG_AllLightsOff);
            this.slgPage.Controls.Add(this.b_Presets_SLG_SteadyGreen);
            this.slgPage.Controls.Add(this.b_Presets_SLG_FlashingRG);
            this.slgPage.Controls.Add(this.b_Presets_SLG_FlashingWhite);
            this.slgPage.Controls.Add(this.b_Presets_SLG_FlashingRed);
            this.slgPage.Controls.Add(this.b_Presets_SLG_SteadyRed);
            this.slgPage.Controls.Add(this.b_Presets_SLG_FlashingGreen);
            this.slgPage.Location = new System.Drawing.Point(4, 22);
            this.slgPage.Name = "slgPage";
            this.slgPage.Size = new System.Drawing.Size(231, 231);
            this.slgPage.TabIndex = 2;
            this.slgPage.Text = "SLG";
            this.slgPage.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_AllLightsOff
            // 
            this.b_Presets_SLG_AllLightsOff.Location = new System.Drawing.Point(7, 149);
            this.b_Presets_SLG_AllLightsOff.Name = "b_Presets_SLG_AllLightsOff";
            this.b_Presets_SLG_AllLightsOff.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_AllLightsOff.TabIndex = 12;
            this.b_Presets_SLG_AllLightsOff.Text = "All Lights Off";
            this.b_Presets_SLG_AllLightsOff.UseVisualStyleBackColor = true;
            this.b_Presets_SLG_AllLightsOff.Click += new System.EventHandler(this.b_Presets_SLG_AllLightsOff_Click);
            // 
            // b_Presets_SLG_SteadyGreen
            // 
            this.b_Presets_SLG_SteadyGreen.Location = new System.Drawing.Point(7, 12);
            this.b_Presets_SLG_SteadyGreen.Name = "b_Presets_SLG_SteadyGreen";
            this.b_Presets_SLG_SteadyGreen.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_SLG_SteadyGreen.TabIndex = 8;
            this.b_Presets_SLG_SteadyGreen.Text = "Steady Green On";
            this.b_Presets_SLG_SteadyGreen.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_FlashingRG
            // 
            this.b_Presets_SLG_FlashingRG.Location = new System.Drawing.Point(6, 83);
            this.b_Presets_SLG_FlashingRG.Name = "b_Presets_SLG_FlashingRG";
            this.b_Presets_SLG_FlashingRG.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_FlashingRG.TabIndex = 7;
            this.b_Presets_SLG_FlashingRG.Text = "Flashing Red / Green";
            this.b_Presets_SLG_FlashingRG.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_FlashingWhite
            // 
            this.b_Presets_SLG_FlashingWhite.Location = new System.Drawing.Point(6, 116);
            this.b_Presets_SLG_FlashingWhite.Name = "b_Presets_SLG_FlashingWhite";
            this.b_Presets_SLG_FlashingWhite.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_SLG_FlashingWhite.TabIndex = 7;
            this.b_Presets_SLG_FlashingWhite.Text = "Flashing White On";
            this.b_Presets_SLG_FlashingWhite.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_FlashingRed
            // 
            this.b_Presets_SLG_FlashingRed.Location = new System.Drawing.Point(118, 44);
            this.b_Presets_SLG_FlashingRed.Name = "b_Presets_SLG_FlashingRed";
            this.b_Presets_SLG_FlashingRed.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_SLG_FlashingRed.TabIndex = 7;
            this.b_Presets_SLG_FlashingRed.Text = "Flashing Red On";
            this.b_Presets_SLG_FlashingRed.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_SteadyRed
            // 
            this.b_Presets_SLG_SteadyRed.Location = new System.Drawing.Point(117, 12);
            this.b_Presets_SLG_SteadyRed.Name = "b_Presets_SLG_SteadyRed";
            this.b_Presets_SLG_SteadyRed.Size = new System.Drawing.Size(101, 27);
            this.b_Presets_SLG_SteadyRed.TabIndex = 7;
            this.b_Presets_SLG_SteadyRed.Text = "Steady Red On";
            this.b_Presets_SLG_SteadyRed.UseVisualStyleBackColor = true;
            // 
            // b_Presets_SLG_FlashingGreen
            // 
            this.b_Presets_SLG_FlashingGreen.Location = new System.Drawing.Point(7, 46);
            this.b_Presets_SLG_FlashingGreen.Name = "b_Presets_SLG_FlashingGreen";
            this.b_Presets_SLG_FlashingGreen.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_SLG_FlashingGreen.TabIndex = 7;
            this.b_Presets_SLG_FlashingGreen.Text = "Flashing Green On";
            this.b_Presets_SLG_FlashingGreen.UseVisualStyleBackColor = true;
            // 
            // peakbeamPage
            // 
            this.peakbeamPage.Controls.Add(this.b_Presets_Peak_SteadyLamp);
            this.peakbeamPage.Controls.Add(this.b_Presets_Peak_StopZoom);
            this.peakbeamPage.Controls.Add(this.b_Presets_Peak_ZoomOut);
            this.peakbeamPage.Controls.Add(this.b_Presets_Peak_ZoomIn);
            this.peakbeamPage.Controls.Add(this.b_Presets_Peak_LampOff);
            this.peakbeamPage.Controls.Add(this.b_Presets_Peak_StrobeLamp);
            this.peakbeamPage.Location = new System.Drawing.Point(4, 22);
            this.peakbeamPage.Name = "peakbeamPage";
            this.peakbeamPage.Size = new System.Drawing.Size(231, 231);
            this.peakbeamPage.TabIndex = 4;
            this.peakbeamPage.Text = "Peak Beam";
            this.peakbeamPage.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_SteadyLamp
            // 
            this.b_Presets_Peak_SteadyLamp.Location = new System.Drawing.Point(119, 23);
            this.b_Presets_Peak_SteadyLamp.Name = "b_Presets_Peak_SteadyLamp";
            this.b_Presets_Peak_SteadyLamp.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Peak_SteadyLamp.TabIndex = 14;
            this.b_Presets_Peak_SteadyLamp.Text = "Lamp On Steady";
            this.b_Presets_Peak_SteadyLamp.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_StopZoom
            // 
            this.b_Presets_Peak_StopZoom.Location = new System.Drawing.Point(7, 142);
            this.b_Presets_Peak_StopZoom.Name = "b_Presets_Peak_StopZoom";
            this.b_Presets_Peak_StopZoom.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_StopZoom.TabIndex = 9;
            this.b_Presets_Peak_StopZoom.Text = "Stop Zooming";
            this.b_Presets_Peak_StopZoom.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_ZoomOut
            // 
            this.b_Presets_Peak_ZoomOut.Location = new System.Drawing.Point(7, 109);
            this.b_Presets_Peak_ZoomOut.Name = "b_Presets_Peak_ZoomOut";
            this.b_Presets_Peak_ZoomOut.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Peak_ZoomOut.TabIndex = 10;
            this.b_Presets_Peak_ZoomOut.Text = "Start Zoom Out";
            this.b_Presets_Peak_ZoomOut.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_ZoomIn
            // 
            this.b_Presets_Peak_ZoomIn.Location = new System.Drawing.Point(119, 109);
            this.b_Presets_Peak_ZoomIn.Name = "b_Presets_Peak_ZoomIn";
            this.b_Presets_Peak_ZoomIn.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Peak_ZoomIn.TabIndex = 11;
            this.b_Presets_Peak_ZoomIn.Text = "Start Zoom In";
            this.b_Presets_Peak_ZoomIn.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_LampOff
            // 
            this.b_Presets_Peak_LampOff.Location = new System.Drawing.Point(7, 56);
            this.b_Presets_Peak_LampOff.Name = "b_Presets_Peak_LampOff";
            this.b_Presets_Peak_LampOff.Size = new System.Drawing.Size(212, 27);
            this.b_Presets_Peak_LampOff.TabIndex = 12;
            this.b_Presets_Peak_LampOff.Text = "Lamp Off";
            this.b_Presets_Peak_LampOff.UseVisualStyleBackColor = true;
            // 
            // b_Presets_Peak_StrobeLamp
            // 
            this.b_Presets_Peak_StrobeLamp.Location = new System.Drawing.Point(7, 23);
            this.b_Presets_Peak_StrobeLamp.Name = "b_Presets_Peak_StrobeLamp";
            this.b_Presets_Peak_StrobeLamp.Size = new System.Drawing.Size(100, 27);
            this.b_Presets_Peak_StrobeLamp.TabIndex = 13;
            this.b_Presets_Peak_StrobeLamp.Text = "Lamp on Strobe";
            this.b_Presets_Peak_StrobeLamp.UseVisualStyleBackColor = true;
            // 
            // charmPage
            // 
            this.charmPage.Controls.Add(this.b_Presets_CHARM_Aquire);
            this.charmPage.Controls.Add(this.b_Presets_CHARM_Standby);
            this.charmPage.Location = new System.Drawing.Point(4, 22);
            this.charmPage.Name = "charmPage";
            this.charmPage.Size = new System.Drawing.Size(231, 231);
            this.charmPage.TabIndex = 5;
            this.charmPage.Text = "CHARM";
            this.charmPage.UseVisualStyleBackColor = true;
            // 
            // b_Presets_CHARM_Aquire
            // 
            this.b_Presets_CHARM_Aquire.Location = new System.Drawing.Point(7, 45);
            this.b_Presets_CHARM_Aquire.Name = "b_Presets_CHARM_Aquire";
            this.b_Presets_CHARM_Aquire.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_CHARM_Aquire.TabIndex = 10;
            this.b_Presets_CHARM_Aquire.Text = "Aquire";
            this.b_Presets_CHARM_Aquire.UseVisualStyleBackColor = true;
            // 
            // b_Presets_CHARM_Standby
            // 
            this.b_Presets_CHARM_Standby.Location = new System.Drawing.Point(7, 12);
            this.b_Presets_CHARM_Standby.Name = "b_Presets_CHARM_Standby";
            this.b_Presets_CHARM_Standby.Size = new System.Drawing.Size(214, 27);
            this.b_Presets_CHARM_Standby.TabIndex = 10;
            this.b_Presets_CHARM_Standby.Text = "Standby";
            this.b_Presets_CHARM_Standby.UseVisualStyleBackColor = true;
            // 
            // l_Presets_Default
            // 
            this.l_Presets_Default.AutoSize = true;
            this.l_Presets_Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Presets_Default.Location = new System.Drawing.Point(12, 38);
            this.l_Presets_Default.Name = "l_Presets_Default";
            this.l_Presets_Default.Size = new System.Drawing.Size(134, 20);
            this.l_Presets_Default.TabIndex = 76;
            this.l_Presets_Default.Text = "Default Presets";
            // 
            // PresetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 342);
            this.Controls.Add(this.tC_Presets_Default);
            this.Controls.Add(this.l_Presets_Default);
            this.Name = "PresetPanel";
            this.Text = "PresetPanel";
            this.tC_Presets_Default.ResumeLayout(false);
            this.adminPage.ResumeLayout(false);
            this.daylightPage.ResumeLayout(false);
            this.thermalPage.ResumeLayout(false);
            this.slgPage.ResumeLayout(false);
            this.peakbeamPage.ResumeLayout(false);
            this.charmPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void b_Presets_CHARM_Standby_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void b_Presets_CHARM_Aquire_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void b_Presets_Peak_LampOff_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        #endregion

        public System.Windows.Forms.TabControl tC_Presets_Default;
        public System.Windows.Forms.TabPage adminPage;
        public System.Windows.Forms.Button b_Presets_Admin_DefaultMen;
        public System.Windows.Forms.Button b_Presets_Admin_DebugToggle;
        public System.Windows.Forms.Button b_Presets_Admin_MechMen;
        public System.Windows.Forms.Button b_Presets_Admin_SetupMen;
        public System.Windows.Forms.TabPage daylightPage;
        public System.Windows.Forms.Button b_Presets_Daylight_Stabilizer;
        public System.Windows.Forms.Button b_Presets_Daylight_WDR;
        public System.Windows.Forms.Button b_Presets_Daylight_Wiper;
        public System.Windows.Forms.Button b_Presets_Daylight_AF;
        public System.Windows.Forms.Button b_Presets_Daylight_ColMono;
        public System.Windows.Forms.TabPage thermalPage;
        public System.Windows.Forms.Button b_Presets_ContrastPos;
        public System.Windows.Forms.Button b_Presets_ContrastNeg;
        public System.Windows.Forms.Button b_Presets_Thermal_BrightPos;
        public System.Windows.Forms.Button b_Presets_Thermal_BrightNeg;
        public System.Windows.Forms.Button b_Presets_Thermal_ICEPos;
        public System.Windows.Forms.Button b_Presets_Thermal_ICENeg;
        public System.Windows.Forms.Button b_Presets_Thermal_ICE;
        public System.Windows.Forms.Button b_Presets_Thermal_WhiteBlack;
        public System.Windows.Forms.Button b_Presets_Thermal_NUC;
        public System.Windows.Forms.Button b_Presets_Thermal_AF;
        public System.Windows.Forms.TabPage slgPage;
        public System.Windows.Forms.Button b_Presets_SLG_SteadyGreen;
        public System.Windows.Forms.Button b_Presets_SLG_FlashingRG;
        public System.Windows.Forms.Button b_Presets_SLG_FlashingWhite;
        public System.Windows.Forms.Button b_Presets_SLG_FlashingRed;
        public System.Windows.Forms.Button b_Presets_SLG_SteadyRed;
        public System.Windows.Forms.Button b_Presets_SLG_FlashingGreen;
        public System.Windows.Forms.TabPage peakbeamPage;
        public System.Windows.Forms.Button b_Presets_Peak_SteadyLamp;
        public System.Windows.Forms.Button b_Presets_Peak_StopZoom;
        public System.Windows.Forms.Button b_Presets_Peak_ZoomOut;
        public System.Windows.Forms.Button b_Presets_Peak_ZoomIn;
        public System.Windows.Forms.Button b_Presets_Peak_LampOff;
        public System.Windows.Forms.Button b_Presets_Peak_StrobeLamp;
        public System.Windows.Forms.TabPage charmPage;
        public System.Windows.Forms.Button b_Presets_CHARM_Aquire;
        public System.Windows.Forms.Button b_Presets_CHARM_Standby;
        public System.Windows.Forms.Label l_Presets_Default;
        public System.Windows.Forms.Button b_Presets_SLG_AllLightsOff;
    }
}