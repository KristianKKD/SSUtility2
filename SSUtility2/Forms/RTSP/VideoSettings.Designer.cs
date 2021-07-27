
namespace SSUtility2
{
    partial class VideoSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoSettings));
            this.b_Play = new System.Windows.Forms.Button();
            this.b_Stop = new System.Windows.Forms.Button();
            this.tC_PlayerSettings = new System.Windows.Forms.TabControl();
            this.tP_Main = new System.Windows.Forms.TabPage();
            this.p_Control = new System.Windows.Forms.Panel();
            this.l_Port = new System.Windows.Forms.Label();
            this.tB_Port = new System.Windows.Forms.TextBox();
            this.tB_IP = new System.Windows.Forms.TextBox();
            this.l_IP = new System.Windows.Forms.Label();
            this.l_PelcoID = new System.Windows.Forms.Label();
            this.cB_ID = new System.Windows.Forms.ComboBox();
            this.check_Manual = new System.Windows.Forms.CheckBox();
            this.l_Control = new System.Windows.Forms.Label();
            this.b_Edit = new System.Windows.Forms.Button();
            this.l_RTSP = new System.Windows.Forms.Label();
            this.cB_RTSP = new System.Windows.Forms.ComboBox();
            this.tC_PlayerSettings.SuspendLayout();
            this.tP_Main.SuspendLayout();
            this.p_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_Play
            // 
            this.b_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Play.BackColor = System.Drawing.SystemColors.Control;
            this.b_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Play.Location = new System.Drawing.Point(347, 25);
            this.b_Play.Name = "b_Play";
            this.b_Play.Size = new System.Drawing.Size(23, 23);
            this.b_Play.TabIndex = 59;
            this.b_Play.Text = "▶";
            this.b_Play.UseVisualStyleBackColor = false;
            this.b_Play.Click += new System.EventHandler(this.b_Play_Click);
            // 
            // b_Stop
            // 
            this.b_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.b_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Stop.Location = new System.Drawing.Point(318, 25);
            this.b_Stop.Name = "b_Stop";
            this.b_Stop.Size = new System.Drawing.Size(23, 23);
            this.b_Stop.TabIndex = 61;
            this.b_Stop.Text = "⬛";
            this.b_Stop.UseVisualStyleBackColor = false;
            this.b_Stop.Click += new System.EventHandler(this.b_Stop_Click);
            // 
            // tC_PlayerSettings
            // 
            this.tC_PlayerSettings.Controls.Add(this.tP_Main);
            this.tC_PlayerSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC_PlayerSettings.Location = new System.Drawing.Point(0, 0);
            this.tC_PlayerSettings.MaximumSize = new System.Drawing.Size(9999, 160);
            this.tC_PlayerSettings.Name = "tC_PlayerSettings";
            this.tC_PlayerSettings.SelectedIndex = 0;
            this.tC_PlayerSettings.Size = new System.Drawing.Size(384, 156);
            this.tC_PlayerSettings.TabIndex = 62;
            // 
            // tP_Main
            // 
            this.tP_Main.BackColor = System.Drawing.Color.White;
            this.tP_Main.Controls.Add(this.p_Control);
            this.tP_Main.Controls.Add(this.check_Manual);
            this.tP_Main.Controls.Add(this.l_Control);
            this.tP_Main.Controls.Add(this.b_Edit);
            this.tP_Main.Controls.Add(this.l_RTSP);
            this.tP_Main.Controls.Add(this.cB_RTSP);
            this.tP_Main.Controls.Add(this.b_Play);
            this.tP_Main.Controls.Add(this.b_Stop);
            this.tP_Main.Location = new System.Drawing.Point(4, 22);
            this.tP_Main.Name = "tP_Main";
            this.tP_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tP_Main.Size = new System.Drawing.Size(376, 130);
            this.tP_Main.TabIndex = 0;
            this.tP_Main.Text = "Main Player";
            // 
            // p_Control
            // 
            this.p_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Control.Controls.Add(this.l_Port);
            this.p_Control.Controls.Add(this.tB_Port);
            this.p_Control.Controls.Add(this.tB_IP);
            this.p_Control.Controls.Add(this.l_IP);
            this.p_Control.Controls.Add(this.l_PelcoID);
            this.p_Control.Controls.Add(this.cB_ID);
            this.p_Control.Enabled = false;
            this.p_Control.Location = new System.Drawing.Point(79, 57);
            this.p_Control.Name = "p_Control";
            this.p_Control.Size = new System.Drawing.Size(297, 336);
            this.p_Control.TabIndex = 69;
            // 
            // l_Port
            // 
            this.l_Port.AutoSize = true;
            this.l_Port.Location = new System.Drawing.Point(3, 53);
            this.l_Port.Name = "l_Port";
            this.l_Port.Size = new System.Drawing.Size(70, 13);
            this.l_Port.TabIndex = 72;
            this.l_Port.Text = "Address Port:";
            // 
            // tB_Port
            // 
            this.tB_Port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Port.Location = new System.Drawing.Point(79, 50);
            this.tB_Port.Name = "tB_Port";
            this.tB_Port.Size = new System.Drawing.Size(212, 20);
            this.tB_Port.TabIndex = 73;
            // 
            // tB_IP
            // 
            this.tB_IP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_IP.Location = new System.Drawing.Point(79, 28);
            this.tB_IP.Name = "tB_IP";
            this.tB_IP.Size = new System.Drawing.Size(212, 20);
            this.tB_IP.TabIndex = 71;
            // 
            // l_IP
            // 
            this.l_IP.AutoSize = true;
            this.l_IP.Location = new System.Drawing.Point(3, 31);
            this.l_IP.Name = "l_IP";
            this.l_IP.Size = new System.Drawing.Size(61, 13);
            this.l_IP.TabIndex = 70;
            this.l_IP.Text = "IP Address:";
            // 
            // l_PelcoID
            // 
            this.l_PelcoID.AutoSize = true;
            this.l_PelcoID.Location = new System.Drawing.Point(3, 7);
            this.l_PelcoID.Name = "l_PelcoID";
            this.l_PelcoID.Size = new System.Drawing.Size(51, 13);
            this.l_PelcoID.TabIndex = 69;
            this.l_PelcoID.Text = "Pelco ID:";
            // 
            // cB_ID
            // 
            this.cB_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_ID.FormattingEnabled = true;
            this.cB_ID.Location = new System.Drawing.Point(79, 4);
            this.cB_ID.Name = "cB_ID";
            this.cB_ID.Size = new System.Drawing.Size(120, 21);
            this.cB_ID.TabIndex = 68;
            // 
            // check_Manual
            // 
            this.check_Manual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.check_Manual.AutoSize = true;
            this.check_Manual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_Manual.Location = new System.Drawing.Point(10, 110);
            this.check_Manual.Name = "check_Manual";
            this.check_Manual.Size = new System.Drawing.Size(58, 17);
            this.check_Manual.TabIndex = 63;
            this.check_Manual.Text = "Manual";
            this.check_Manual.UseVisualStyleBackColor = true;
            // 
            // l_Control
            // 
            this.l_Control.AutoSize = true;
            this.l_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Control.Location = new System.Drawing.Point(6, 59);
            this.l_Control.Name = "l_Control";
            this.l_Control.Size = new System.Drawing.Size(67, 20);
            this.l_Control.TabIndex = 67;
            this.l_Control.Text = "Control";
            // 
            // b_Edit
            // 
            this.b_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Edit.BackColor = System.Drawing.SystemColors.Control;
            this.b_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Edit.Location = new System.Drawing.Point(289, 25);
            this.b_Edit.Name = "b_Edit";
            this.b_Edit.Size = new System.Drawing.Size(23, 23);
            this.b_Edit.TabIndex = 66;
            this.b_Edit.Text = "⛭";
            this.b_Edit.UseVisualStyleBackColor = false;
            // 
            // l_RTSP
            // 
            this.l_RTSP.AutoSize = true;
            this.l_RTSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_RTSP.Location = new System.Drawing.Point(6, 3);
            this.l_RTSP.Name = "l_RTSP";
            this.l_RTSP.Size = new System.Drawing.Size(159, 20);
            this.l_RTSP.TabIndex = 65;
            this.l_RTSP.Text = "RTSP Stream URL";
            // 
            // cB_RTSP
            // 
            this.cB_RTSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_RTSP.FormattingEnabled = true;
            this.cB_RTSP.Location = new System.Drawing.Point(10, 26);
            this.cB_RTSP.Name = "cB_RTSP";
            this.cB_RTSP.Size = new System.Drawing.Size(273, 21);
            this.cB_RTSP.TabIndex = 64;
            // 
            // VideoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(384, 156);
            this.Controls.Add(this.tC_PlayerSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoSettings_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.VideoSettings_VisibleChanged);
            this.tC_PlayerSettings.ResumeLayout(false);
            this.tP_Main.ResumeLayout(false);
            this.tP_Main.PerformLayout();
            this.p_Control.ResumeLayout(false);
            this.p_Control.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button b_Play;
        public System.Windows.Forms.Button b_Stop;
        public System.Windows.Forms.TabControl tC_PlayerSettings;
        public System.Windows.Forms.TabPage tP_Main;
        public System.Windows.Forms.Button b_Edit;
        private System.Windows.Forms.Label l_RTSP;
        private System.Windows.Forms.ComboBox cB_RTSP;
        private System.Windows.Forms.Label l_Control;
        private System.Windows.Forms.Panel p_Control;
        private System.Windows.Forms.Label l_Port;
        private System.Windows.Forms.TextBox tB_Port;
        private System.Windows.Forms.TextBox tB_IP;
        private System.Windows.Forms.Label l_IP;
        private System.Windows.Forms.Label l_PelcoID;
        private System.Windows.Forms.ComboBox cB_ID;
        private System.Windows.Forms.CheckBox check_Manual;
    }
}