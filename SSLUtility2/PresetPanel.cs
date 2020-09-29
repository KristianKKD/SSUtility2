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
        public ControlPanel cp;

        public PresetPanel() {
            InitializeComponent();
        }

        private void b_Presets_Admin_MechMen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFF, 0x07 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
        }

        private void b_Presets_Admin_SetupMen_Click(object sender, EventArgs e) {
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFB, 0x03 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFD, 0x05 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFC, 0x04 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
            CameraCommunicate.sendtoIPAsync(new byte[] { 0xFF, 0x01, 0x00, 0x07, 0x00, 0xFE, 0x06 }, cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
        }

        private void b_Presets_Admin_DebugToggle_Click(object sender, EventArgs e) {
            DoPreset(mainRef.MakeAdr(cp.l), 196);
        }

        private void b_Presets_Admin_DefaultMen_Click(object sender, EventArgs e) {
            DoPreset(mainRef.MakeAdr(cp.l), 2);
        }

        private void b_Presets_Daylight_Wiper_Click(object sender, EventArgs e) {
            DoPreset(1, 4);
        }

        private void b_Presets_Daylight_ColMono_Click(object sender, EventArgs e) {
            DoPreset(1, 3);
        }

        private void b_Presets_Daylight_AF_Click(object sender, EventArgs e) {
            DoPreset(1, 12);
        }

        private void b_Presets_Daylight_WDR_Click(object sender, EventArgs e) {
            DoPreset(1, 11);
        }

        private void b_Presets_Daylight_Stabilizer_Click(object sender, EventArgs e) {
            DoPreset(1, 19);
        }

        private void b_Presets_SLG_SteadyGreen_Click(object sender, EventArgs e) {
            DoPreset(1, 30);
        }

        private void b_Presets_SLG_FlashingGreen_Click(object sender, EventArgs e) {
            DoPreset(1, 31);
        }

        private void b_Presets_SLG_SteadyRed_Click(object sender, EventArgs e) {
            DoPreset(1, 32);
        }

        private void b_Presets_SLG_FlashingRed_Click(object sender, EventArgs e) {
            DoPreset(1, 33);
        }

        private void b_Presets_SLG_FlashingWhite_Click(object sender, EventArgs e) {
            DoPreset(1, 34);
        }

        private void b_Presets_SLG_FlashingRG_Click(object sender, EventArgs e) {
            DoPreset(1, 35);
        }

        private void b_Presets_SLG_AllLightsOff_Click(object sender, EventArgs e) {
            DoPreset(1, 36);
        }

        private void b_Presets_Thermal_WhiteBlack_Click(object sender, EventArgs e) {
            DoPreset(2, 8);
        }

        private void b_Presets_Thermal_AF_Click(object sender, EventArgs e) {
            DoPreset(2, 12);
        }

        private void b_Presets_Thermal_ICE_Click(object sender, EventArgs e) {
            DoPreset(2, 16);
        }

        private void b_Presets_Thermal_ICENeg_Click(object sender, EventArgs e) {
            DoPreset(2, 17);
        }

        private void b_Presets_Thermal_ICEPos_Click(object sender, EventArgs e) {
            DoPreset(2, 18);
        }

        private void b_Presets_ContrastPos_Click(object sender, EventArgs e) {
            DoPreset(2, 179);
        }

        private void b_Presets_ContrastNeg_Click(object sender, EventArgs e) {
            DoPreset(2, 178);
        }

        private void b_Presets_Thermal_BrightPos_Click(object sender, EventArgs e) {
            DoPreset(2, 177);
        }

        private void b_Presets_Thermal_BrightNeg_Click(object sender, EventArgs e) {
            DoPreset(2, 176);
        }

        private void b_Presets_Peak_StrobeLamp_Click(object sender, EventArgs e) {
            DoPreset(2, 189);
        }

        private void b_Presets_Peak_SteadyLamp_Click(object sender, EventArgs e) {
            DoPreset(2, 188);
        }

        private void Presets_Peak_LampOff_Click(object sender, EventArgs e) { 
            DoPreset(2, 187);
        }

        private void b_Presets_Peak_ZoomIn_Click(object sender, EventArgs e) {
            DoPreset(2, 185);
        }

        private void b_Presets_Peak_ZoomOut_Click(object sender, EventArgs e) {
            DoPreset(2, 186);
        }

        private void b_Presets_Peak_StopZoom_Click(object sender, EventArgs e) {
            DoPreset(2, 184);
        }

        private void b_Presets_Thermal_NUC_Click(object sender, EventArgs e) {
            DoPreset(2, 175);
        }

        private void b_Presets_Daylight_Extender_Click(object sender, EventArgs e) {
            DoPreset(2, 205);
        }

        private void b_Presets_Thermal_Stabi_Click(object sender, EventArgs e) {
            DoPreset(2, 19);
        }

        private void b_Presets_Thermal_Cycle_Click(object sender, EventArgs e) {
            DoPreset(2, 181);
        }

        private void b_Presets_Thermal_DigiPos_Click(object sender, EventArgs e) {
            DoPreset(2, 183);
        }

        private void b_Presets_Thermal_DigiNeg_Click(object sender, EventArgs e) {
            DoPreset(2, 182);
        }

        void DoPreset(uint adr, byte p) {
            CameraCommunicate.sendtoIPAsync(protocol.Preset(adr, p, D.PresetAction.Goto), cp.l, cp.tB_IPCon_Adr.Text, cp.tB_IPCon_Port.Text);
        }

    }
}
