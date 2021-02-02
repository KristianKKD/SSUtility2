namespace SSUtility2
{
    partial class Osiris
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
            this.tB_Port = new System.Windows.Forms.TextBox();
            this.tB_IP = new System.Windows.Forms.TextBox();
            this.l_IP = new System.Windows.Forms.Label();
            this.l_Port = new System.Windows.Forms.Label();
            this.l_FilterActuator = new System.Windows.Forms.Label();
            this.l_Focus = new System.Windows.Forms.Label();
            this.l_Mode = new System.Windows.Forms.Label();
            this.l_Beam = new System.Windows.Forms.Label();
            this.cB_Focus = new System.Windows.Forms.ComboBox();
            this.cB_Filter = new System.Windows.Forms.ComboBox();
            this.cB_Mode = new System.Windows.Forms.ComboBox();
            this.cB_Beam = new System.Windows.Forms.ComboBox();
            this.b_Connect = new System.Windows.Forms.Button();
            this.l_LampType = new System.Windows.Forms.Label();
            this.l_Series = new System.Windows.Forms.Label();
            this.cB_Actuator = new System.Windows.Forms.ComboBox();
            this.l_Status = new System.Windows.Forms.Label();
            this.l_Health = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tB_Port
            // 
            this.tB_Port.Location = new System.Drawing.Point(325, 38);
            this.tB_Port.Name = "tB_Port";
            this.tB_Port.Size = new System.Drawing.Size(100, 20);
            this.tB_Port.TabIndex = 10;
            // 
            // tB_IP
            // 
            this.tB_IP.Location = new System.Drawing.Point(325, 12);
            this.tB_IP.Name = "tB_IP";
            this.tB_IP.Size = new System.Drawing.Size(100, 20);
            this.tB_IP.TabIndex = 9;
            // 
            // l_IP
            // 
            this.l_IP.AutoSize = true;
            this.l_IP.Location = new System.Drawing.Point(261, 15);
            this.l_IP.Name = "l_IP";
            this.l_IP.Size = new System.Drawing.Size(58, 13);
            this.l_IP.TabIndex = 16;
            this.l_IP.Text = "IP Address";
            // 
            // l_Port
            // 
            this.l_Port.AutoSize = true;
            this.l_Port.Location = new System.Drawing.Point(293, 41);
            this.l_Port.Name = "l_Port";
            this.l_Port.Size = new System.Drawing.Size(26, 13);
            this.l_Port.TabIndex = 17;
            this.l_Port.Text = "Port";
            // 
            // l_FilterActuator
            // 
            this.l_FilterActuator.AutoSize = true;
            this.l_FilterActuator.Location = new System.Drawing.Point(128, 9);
            this.l_FilterActuator.Name = "l_FilterActuator";
            this.l_FilterActuator.Size = new System.Drawing.Size(74, 13);
            this.l_FilterActuator.TabIndex = 18;
            this.l_FilterActuator.Text = "Filter/Actuator";
            // 
            // l_Focus
            // 
            this.l_Focus.AutoSize = true;
            this.l_Focus.Location = new System.Drawing.Point(12, 9);
            this.l_Focus.Name = "l_Focus";
            this.l_Focus.Size = new System.Drawing.Size(36, 13);
            this.l_Focus.TabIndex = 19;
            this.l_Focus.Text = "Focus";
            // 
            // l_Mode
            // 
            this.l_Mode.AutoSize = true;
            this.l_Mode.Location = new System.Drawing.Point(12, 49);
            this.l_Mode.Name = "l_Mode";
            this.l_Mode.Size = new System.Drawing.Size(34, 13);
            this.l_Mode.TabIndex = 20;
            this.l_Mode.Text = "Mode";
            // 
            // l_Beam
            // 
            this.l_Beam.AutoSize = true;
            this.l_Beam.Location = new System.Drawing.Point(128, 49);
            this.l_Beam.Name = "l_Beam";
            this.l_Beam.Size = new System.Drawing.Size(34, 13);
            this.l_Beam.TabIndex = 21;
            this.l_Beam.Text = "Beam";
            // 
            // cB_Focus
            // 
            this.cB_Focus.FormattingEnabled = true;
            this.cB_Focus.Items.AddRange(new object[] {
            "WIDE",
            "SPOT",
            "MID"});
            this.cB_Focus.Location = new System.Drawing.Point(15, 25);
            this.cB_Focus.Name = "cB_Focus";
            this.cB_Focus.Size = new System.Drawing.Size(86, 21);
            this.cB_Focus.TabIndex = 27;
            this.cB_Focus.SelectedIndexChanged += new System.EventHandler(this.cB_Focus_SelectedIndexChanged);
            // 
            // cB_Filter
            // 
            this.cB_Filter.FormattingEnabled = true;
            this.cB_Filter.Items.AddRange(new object[] {
            "Right CLOSED",
            "Left CLOSED",
            "All OPEN"});
            this.cB_Filter.Location = new System.Drawing.Point(131, 25);
            this.cB_Filter.Name = "cB_Filter";
            this.cB_Filter.Size = new System.Drawing.Size(89, 21);
            this.cB_Filter.TabIndex = 28;
            this.cB_Filter.SelectedIndexChanged += new System.EventHandler(this.cB_Filter_SelectedIndexChanged);
            // 
            // cB_Mode
            // 
            this.cB_Mode.FormattingEnabled = true;
            this.cB_Mode.Items.AddRange(new object[] {
            "PULSE",
            "STROBE",
            "CONTINUOUS"});
            this.cB_Mode.Location = new System.Drawing.Point(15, 65);
            this.cB_Mode.Name = "cB_Mode";
            this.cB_Mode.Size = new System.Drawing.Size(89, 21);
            this.cB_Mode.TabIndex = 29;
            this.cB_Mode.SelectedIndexChanged += new System.EventHandler(this.cB_Mode_SelectedIndexChanged);
            // 
            // cB_Beam
            // 
            this.cB_Beam.FormattingEnabled = true;
            this.cB_Beam.Items.AddRange(new object[] {
            "LOW",
            "HIGH",
            "OFF"});
            this.cB_Beam.Location = new System.Drawing.Point(131, 65);
            this.cB_Beam.Name = "cB_Beam";
            this.cB_Beam.Size = new System.Drawing.Size(89, 21);
            this.cB_Beam.TabIndex = 30;
            this.cB_Beam.SelectedIndexChanged += new System.EventHandler(this.cB_Beam_SelectedIndexChanged);
            // 
            // b_Connect
            // 
            this.b_Connect.Location = new System.Drawing.Point(264, 70);
            this.b_Connect.Name = "b_Connect";
            this.b_Connect.Size = new System.Drawing.Size(161, 23);
            this.b_Connect.TabIndex = 32;
            this.b_Connect.Text = "Connect";
            this.b_Connect.UseVisualStyleBackColor = true;
            this.b_Connect.Click += new System.EventHandler(this.b_Connect_Click);
            // 
            // l_LampType
            // 
            this.l_LampType.AutoSize = true;
            this.l_LampType.Location = new System.Drawing.Point(12, 96);
            this.l_LampType.Name = "l_LampType";
            this.l_LampType.Size = new System.Drawing.Size(63, 13);
            this.l_LampType.TabIndex = 31;
            this.l_LampType.Text = "Lamp Type:";
            this.l_LampType.Visible = false;
            // 
            // l_Series
            // 
            this.l_Series.AutoSize = true;
            this.l_Series.Location = new System.Drawing.Point(128, 96);
            this.l_Series.Name = "l_Series";
            this.l_Series.Size = new System.Drawing.Size(39, 13);
            this.l_Series.TabIndex = 33;
            this.l_Series.Text = "Series:";
            this.l_Series.Visible = false;
            // 
            // cB_Actuator
            // 
            this.cB_Actuator.FormattingEnabled = true;
            this.cB_Actuator.Items.AddRange(new object[] {
            "Actuator OPEN",
            "Actuator CLOSED"});
            this.cB_Actuator.Location = new System.Drawing.Point(131, 25);
            this.cB_Actuator.Name = "cB_Actuator";
            this.cB_Actuator.Size = new System.Drawing.Size(89, 21);
            this.cB_Actuator.TabIndex = 34;
            this.cB_Actuator.Visible = false;
            this.cB_Actuator.SelectedIndexChanged += new System.EventHandler(this.cB_Actuator_SelectedIndexChanged);
            // 
            // l_Status
            // 
            this.l_Status.AutoSize = true;
            this.l_Status.Location = new System.Drawing.Point(205, 96);
            this.l_Status.Name = "l_Status";
            this.l_Status.Size = new System.Drawing.Size(69, 13);
            this.l_Status.TabIndex = 35;
            this.l_Status.Text = "Lamp Status:";
            this.l_Status.Visible = false;
            // 
            // l_Health
            // 
            this.l_Health.AutoSize = true;
            this.l_Health.Location = new System.Drawing.Point(322, 96);
            this.l_Health.Name = "l_Health";
            this.l_Health.Size = new System.Drawing.Size(41, 13);
            this.l_Health.TabIndex = 36;
            this.l_Health.Text = "Health:";
            this.l_Health.Visible = false;
            // 
            // Osiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(437, 117);
            this.Controls.Add(this.l_Health);
            this.Controls.Add(this.l_Status);
            this.Controls.Add(this.l_Series);
            this.Controls.Add(this.b_Connect);
            this.Controls.Add(this.l_LampType);
            this.Controls.Add(this.cB_Beam);
            this.Controls.Add(this.cB_Mode);
            this.Controls.Add(this.cB_Filter);
            this.Controls.Add(this.cB_Focus);
            this.Controls.Add(this.l_Beam);
            this.Controls.Add(this.l_Mode);
            this.Controls.Add(this.l_Focus);
            this.Controls.Add(this.l_FilterActuator);
            this.Controls.Add(this.l_Port);
            this.Controls.Add(this.l_IP);
            this.Controls.Add(this.tB_Port);
            this.Controls.Add(this.tB_IP);
            this.Controls.Add(this.cB_Actuator);
            this.Name = "Osiris";
            this.Text = "Osiris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tB_Port;
        private System.Windows.Forms.TextBox tB_IP;
        private System.Windows.Forms.Label l_IP;
        private System.Windows.Forms.Label l_Port;
        private System.Windows.Forms.Label l_FilterActuator;
        private System.Windows.Forms.Label l_Focus;
        private System.Windows.Forms.Label l_Mode;
        private System.Windows.Forms.Label l_Beam;
        private System.Windows.Forms.ComboBox cB_Focus;
        private System.Windows.Forms.ComboBox cB_Filter;
        private System.Windows.Forms.ComboBox cB_Mode;
        private System.Windows.Forms.ComboBox cB_Beam;
        private System.Windows.Forms.Button b_Connect;
        private System.Windows.Forms.Label l_LampType;
        private System.Windows.Forms.Label l_Series;
        private System.Windows.Forms.ComboBox cB_Actuator;
        private System.Windows.Forms.Label l_Status;
        private System.Windows.Forms.Label l_Health;
    }
}