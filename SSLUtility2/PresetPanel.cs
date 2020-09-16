using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLUtility2 {

    public partial class PresetPanel : Form {

        public MainForm mainRef;
        D protocol = new D();

        public PresetPanel() {
            InitializeComponent();
        }

        private void b_Presets_Admin_MechMen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 }, null);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 }, null);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 }, null);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFF, 0x07 }, null);
        }

        private void b_Presets_Admin_SetupMen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 }, null);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 }, null);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 }, null);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFE, 0x06 }, null);
        }


        //private void b_Presets_Admin_DebugToggle_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(mainRef.MakeAdr(), 196, D.PresetAction.Goto));
        //}

        //private void b_Presets_Admin_DefaultMen_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(mainRef.MakeAdr(), 2, D.PresetAction.Goto));
        //}

        //private void b_Presets_Daylight_Wiper_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 4, D.PresetAction.Goto));
        //}

        //private void b_Presets_Daylight_ColMono_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 3, D.PresetAction.Goto));
        //}

        //private void b_Presets_Daylight_AF_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 12, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_WhiteBlack_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 8, D.PresetAction.Goto));
        //}

        //private void b_Presets_Daylight_WDR_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 11, D.PresetAction.Goto));
        //}

        //private void b_Presets_Daylight_Stabilizer_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 19, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_AF_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 12, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_ICE_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 16, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_ICENeg_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 17, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_ICEPos_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 18, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_BrightNeg_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 176, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_BrightPos_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 177, D.PresetAction.Goto));
        //}

        //private void button31_Click(object sender, EventArgs e) { //"Contrast -"; {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 178, D.PresetAction.Goto));
        //}

        //private void button32_Click(object sender, EventArgs e) { //"Contrast +";
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 179, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_SteadyGreen_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 30, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_FlashingGreen_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 31, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_SteadyRed_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 32, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_FlashingRed_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 33, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_FlashingWhite_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 34, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_FlashingRG_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 35, D.PresetAction.Goto));
        //}

        //private void b_Presets_SLG_AllLightsOff_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(1, 36, D.PresetAction.Goto));
        //}

        //private void b_Presets_Peak_SteadyLamp_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 188, D.PresetAction.Goto));
        //}

        //private void b_Presets_Peak_StrobeLamp_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 189, D.PresetAction.Goto));
        //}

        //private void Presets_Peak_LampOff_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 187, D.PresetAction.Goto));
        //}

        //private void b_Presets_Peak_ZoomIn_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 185, D.PresetAction.Goto));
        //}

        //private void b_Presets_Peak_ZoomOut_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 186, D.PresetAction.Goto));
        //}

        //private void b_Presets_Peak_StopZoom_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 184, D.PresetAction.Goto));
        //}

        //private void b_Presets_Thermal_NUC_Click(object sender, EventArgs e) {
        //    CameraCommunicate.sendtoIPAsync(protocol.Preset(2, 175, D.PresetAction.Goto));
        //}


    }
}
