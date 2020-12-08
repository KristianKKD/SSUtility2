
namespace SSLUtility2
{
    partial class SettingsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.p_Main = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cB_Other_RefreshRate = new System.Windows.Forms.ComboBox();
            this.l_Other = new System.Windows.Forms.Label();
            this.check_Other_AutoPlay = new System.Windows.Forms.CheckBox();
            this.l_Other_Rate = new System.Windows.Forms.Label();
            this.check_Other_Subnet = new System.Windows.Forms.CheckBox();
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
            this.b_Settings_Apply = new System.Windows.Forms.Button();
            this.b_Settings_Default = new System.Windows.Forms.Button();
            this.p_Main.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gB_Paths.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Main
            // 
            this.p_Main.BackColor = System.Drawing.SystemColors.Window;
            this.p_Main.Controls.Add(this.groupBox2);
            this.p_Main.Controls.Add(this.gB_Paths);
            this.p_Main.Controls.Add(this.groupBox1);
            this.p_Main.Controls.Add(this.b_Settings_Apply);
            this.p_Main.Controls.Add(this.b_Settings_Default);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(1342, 261);
            this.p_Main.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cB_Other_RefreshRate);
            this.groupBox2.Controls.Add(this.l_Other);
            this.groupBox2.Controls.Add(this.check_Other_AutoPlay);
            this.groupBox2.Controls.Add(this.l_Other_Rate);
            this.groupBox2.Controls.Add(this.check_Other_Subnet);
            this.groupBox2.Location = new System.Drawing.Point(883, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 194);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // cB_Other_RefreshRate
            // 
            this.cB_Other_RefreshRate.BackColor = System.Drawing.SystemColors.Window;
            this.cB_Other_RefreshRate.FormattingEnabled = true;
            this.cB_Other_RefreshRate.Items.AddRange(new object[] {
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            this.cB_Other_RefreshRate.Location = new System.Drawing.Point(166, 94);
            this.cB_Other_RefreshRate.Name = "cB_Other_RefreshRate";
            this.cB_Other_RefreshRate.Size = new System.Drawing.Size(114, 21);
            this.cB_Other_RefreshRate.TabIndex = 28;
            this.cB_Other_RefreshRate.TextChanged += new System.EventHandler(this.cB_Other_RefreshRate_TextChanged);
            // 
            // l_Other
            // 
            this.l_Other.AutoSize = true;
            this.l_Other.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Other.Location = new System.Drawing.Point(6, 16);
            this.l_Other.Name = "l_Other";
            this.l_Other.Size = new System.Drawing.Size(126, 20);
            this.l_Other.TabIndex = 31;
            this.l_Other.Text = "Other Settings";
            // 
            // check_Other_AutoPlay
            // 
            this.check_Other_AutoPlay.Location = new System.Drawing.Point(6, 45);
            this.check_Other_AutoPlay.Name = "check_Other_AutoPlay";
            this.check_Other_AutoPlay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_AutoPlay.Size = new System.Drawing.Size(174, 17);
            this.check_Other_AutoPlay.TabIndex = 30;
            this.check_Other_AutoPlay.Text = "Autoplay Videos on Launch";
            this.check_Other_AutoPlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Other_AutoPlay.UseVisualStyleBackColor = true;
            this.check_Other_AutoPlay.CheckedChanged += new System.EventHandler(this.check_Other_AutoPlay_CheckedChanged);
            // 
            // l_Other_Rate
            // 
            this.l_Other_Rate.AutoSize = true;
            this.l_Other_Rate.Location = new System.Drawing.Point(7, 97);
            this.l_Other_Rate.Name = "l_Other_Rate";
            this.l_Other_Rate.Size = new System.Drawing.Size(113, 13);
            this.l_Other_Rate.TabIndex = 27;
            this.l_Other_Rate.Text = "Info Refresh Rate (ms)";
            // 
            // check_Other_Subnet
            // 
            this.check_Other_Subnet.Location = new System.Drawing.Point(6, 68);
            this.check_Other_Subnet.Name = "check_Other_Subnet";
            this.check_Other_Subnet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Other_Subnet.Size = new System.Drawing.Size(174, 17);
            this.check_Other_Subnet.TabIndex = 0;
            this.check_Other_Subnet.Text = "Hide Subnet Notification";
            this.check_Other_Subnet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Other_Subnet.UseVisualStyleBackColor = true;
            this.check_Other_Subnet.CheckedChanged += new System.EventHandler(this.check_Other_Subnet_CheckedChanged);
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
            this.gB_Paths.Location = new System.Drawing.Point(15, 11);
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
            this.tB_Paths_vFolder.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Paths_vFolder.Enabled = false;
            this.tB_Paths_vFolder.Location = new System.Drawing.Point(119, 110);
            this.tB_Paths_vFolder.Name = "tB_Paths_vFolder";
            this.tB_Paths_vFolder.Size = new System.Drawing.Size(188, 20);
            this.tB_Paths_vFolder.TabIndex = 18;
            this.tB_Paths_vFolder.TextChanged += new System.EventHandler(this.tB_Paths_vFolder_TextChanged);
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
            this.tB_Paths_sCFolder.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Paths_sCFolder.Enabled = false;
            this.tB_Paths_sCFolder.Location = new System.Drawing.Point(119, 77);
            this.tB_Paths_sCFolder.Name = "tB_Paths_sCFolder";
            this.tB_Paths_sCFolder.Size = new System.Drawing.Size(188, 20);
            this.tB_Paths_sCFolder.TabIndex = 16;
            this.tB_Paths_sCFolder.TextChanged += new System.EventHandler(this.tB_Paths_sCFolder_TextChanged);
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
            this.l_Paths.Location = new System.Drawing.Point(6, 16);
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
            this.l_Paths_sCFolder.Size = new System.Drawing.Size(84, 13);
            this.l_Paths_sCFolder.TabIndex = 2;
            this.l_Paths_sCFolder.Text = "Snapshot Folder";
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
            this.groupBox1.Location = new System.Drawing.Point(449, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 194);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
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
            this.cB_Rec_Quality.Location = new System.Drawing.Point(123, 69);
            this.cB_Rec_Quality.Name = "cB_Rec_Quality";
            this.cB_Rec_Quality.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_Quality.TabIndex = 26;
            this.cB_Rec_Quality.TextChanged += new System.EventHandler(this.cB_Rec_Quality_TextChanged);
            // 
            // l_Rec_Quality
            // 
            this.l_Rec_Quality.AutoSize = true;
            this.l_Rec_Quality.Location = new System.Drawing.Point(7, 73);
            this.l_Rec_Quality.Name = "l_Rec_Quality";
            this.l_Rec_Quality.Size = new System.Drawing.Size(72, 13);
            this.l_Rec_Quality.TabIndex = 25;
            this.l_Rec_Quality.Text = "Quality(1-100)";
            // 
            // tB_Rec_scFileN
            // 
            this.tB_Rec_scFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Rec_scFileN.Enabled = false;
            this.tB_Rec_scFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Rec_scFileN.Location = new System.Drawing.Point(123, 126);
            this.tB_Rec_scFileN.Name = "tB_Rec_scFileN";
            this.tB_Rec_scFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_scFileN.TabIndex = 24;
            this.tB_Rec_scFileN.TextChanged += new System.EventHandler(this.tB_Rec_scFileN_TextChanged);
            // 
            // l_Rec_sCFileN
            // 
            this.l_Rec_sCFileN.AutoSize = true;
            this.l_Rec_sCFileN.Location = new System.Drawing.Point(7, 129);
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
            this.cB_Rec_FPS.Location = new System.Drawing.Point(123, 42);
            this.cB_Rec_FPS.Name = "cB_Rec_FPS";
            this.cB_Rec_FPS.Size = new System.Drawing.Size(114, 21);
            this.cB_Rec_FPS.TabIndex = 16;
            this.cB_Rec_FPS.TextChanged += new System.EventHandler(this.cB_Rec_FPS_TextChanged);
            // 
            // tB_Rec_vFileN
            // 
            this.tB_Rec_vFileN.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Rec_vFileN.Enabled = false;
            this.tB_Rec_vFileN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tB_Rec_vFileN.Location = new System.Drawing.Point(123, 97);
            this.tB_Rec_vFileN.Name = "tB_Rec_vFileN";
            this.tB_Rec_vFileN.Size = new System.Drawing.Size(188, 20);
            this.tB_Rec_vFileN.TabIndex = 22;
            this.tB_Rec_vFileN.TextChanged += new System.EventHandler(this.tB_Rec_vFileN_TextChanged);
            // 
            // l_Rec_vFileN
            // 
            this.l_Rec_vFileN.AutoSize = true;
            this.l_Rec_vFileN.Location = new System.Drawing.Point(7, 100);
            this.l_Rec_vFileN.Name = "l_Rec_vFileN";
            this.l_Rec_vFileN.Size = new System.Drawing.Size(84, 13);
            this.l_Rec_vFileN.TabIndex = 21;
            this.l_Rec_vFileN.Text = "Video File Name";
            // 
            // l_Rec
            // 
            this.l_Rec.AutoSize = true;
            this.l_Rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Rec.Location = new System.Drawing.Point(6, 16);
            this.l_Rec.Name = "l_Rec";
            this.l_Rec.Size = new System.Drawing.Size(91, 20);
            this.l_Rec.TabIndex = 12;
            this.l_Rec.Text = "Recording";
            // 
            // l_Rec_FPS
            // 
            this.l_Rec_FPS.AutoSize = true;
            this.l_Rec_FPS.Location = new System.Drawing.Point(7, 47);
            this.l_Rec_FPS.Name = "l_Rec_FPS";
            this.l_Rec_FPS.Size = new System.Drawing.Size(54, 13);
            this.l_Rec_FPS.TabIndex = 2;
            this.l_Rec_FPS.Text = "Framerate";
            // 
            // b_Settings_Apply
            // 
            this.b_Settings_Apply.Location = new System.Drawing.Point(1235, 211);
            this.b_Settings_Apply.Name = "b_Settings_Apply";
            this.b_Settings_Apply.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Apply.TabIndex = 15;
            this.b_Settings_Apply.Text = "Save All";
            this.b_Settings_Apply.UseVisualStyleBackColor = true;
            this.b_Settings_Apply.Click += new System.EventHandler(this.b_Settings_Apply_Click);
            // 
            // b_Settings_Default
            // 
            this.b_Settings_Default.Location = new System.Drawing.Point(1154, 211);
            this.b_Settings_Default.Name = "b_Settings_Default";
            this.b_Settings_Default.Size = new System.Drawing.Size(75, 23);
            this.b_Settings_Default.TabIndex = 14;
            this.b_Settings_Default.Text = "Default All";
            this.b_Settings_Default.UseVisualStyleBackColor = true;
            this.b_Settings_Default.Click += new System.EventHandler(this.b_Settings_Default_Click);
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 261);
            this.Controls.Add(this.p_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsPage";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsPage_FormClosing);
            this.p_Main.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gB_Paths.ResumeLayout(false);
            this.gB_Paths.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cB_Other_RefreshRate;
        public System.Windows.Forms.Label l_Other;
        private System.Windows.Forms.CheckBox check_Other_AutoPlay;
        public System.Windows.Forms.Label l_Other_Rate;
        private System.Windows.Forms.CheckBox check_Other_Subnet;
        public System.Windows.Forms.GroupBox gB_Paths;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_Paths_Manual;
        public System.Windows.Forms.Label l_Paths_sCCheck;
        public System.Windows.Forms.Label l_Paths_vCheck;
        public System.Windows.Forms.Button b_Paths_vBrowse;
        public System.Windows.Forms.TextBox tB_Paths_vFolder;
        public System.Windows.Forms.Label l_Paths_vFolder;
        public System.Windows.Forms.TextBox tB_Paths_sCFolder;
        public System.Windows.Forms.Button b_Paths_sCBrowse;
        public System.Windows.Forms.Label l_Paths;
        public System.Windows.Forms.Label l_Paths_sCFolder;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cB_Rec_Quality;
        public System.Windows.Forms.Label l_Rec_Quality;
        public System.Windows.Forms.TextBox tB_Rec_scFileN;
        public System.Windows.Forms.Label l_Rec_sCFileN;
        public System.Windows.Forms.ComboBox cB_Rec_FPS;
        public System.Windows.Forms.TextBox tB_Rec_vFileN;
        public System.Windows.Forms.Label l_Rec_vFileN;
        public System.Windows.Forms.Label l_Rec;
        public System.Windows.Forms.Label l_Rec_FPS;
        public System.Windows.Forms.Button b_Settings_Apply;
        public System.Windows.Forms.Button b_Settings_Default;
    }
}