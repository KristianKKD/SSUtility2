namespace SSUtility2
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.check_IPCon_KeyboardCon = new System.Windows.Forms.CheckBox();
            this.l_PTZCon = new System.Windows.Forms.Label();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Joystick = new Joystick.CentreStick();
            this.l_Debug1 = new System.Windows.Forms.Label();
            this.l_Debug2 = new System.Windows.Forms.Label();
            this.l_Debug3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Joystick)).BeginInit();
            this.SuspendLayout();
            // 
            // check_IPCon_KeyboardCon
            // 
            this.check_IPCon_KeyboardCon.AutoSize = true;
            this.check_IPCon_KeyboardCon.Location = new System.Drawing.Point(14, 113);
            this.check_IPCon_KeyboardCon.Name = "check_IPCon_KeyboardCon";
            this.check_IPCon_KeyboardCon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_IPCon_KeyboardCon.Size = new System.Drawing.Size(110, 17);
            this.check_IPCon_KeyboardCon.TabIndex = 67;
            this.check_IPCon_KeyboardCon.Text = " Keyboard Control";
            this.check_IPCon_KeyboardCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_IPCon_KeyboardCon.UseVisualStyleBackColor = true;
            // 
            // l_PTZCon
            // 
            this.l_PTZCon.AutoSize = true;
            this.l_PTZCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PTZCon.Location = new System.Drawing.Point(8, 9);
            this.l_PTZCon.Name = "l_PTZCon";
            this.l_PTZCon.Size = new System.Drawing.Size(104, 20);
            this.l_PTZCon.TabIndex = 55;
            this.l_PTZCon.Text = "PTZ Control";
            // 
            // b_PTZ_FocusNeg
            // 
            this.b_PTZ_FocusNeg.BackColor = System.Drawing.Color.YellowGreen;
            this.b_PTZ_FocusNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_FocusNeg.Location = new System.Drawing.Point(14, 72);
            this.b_PTZ_FocusNeg.Name = "b_PTZ_FocusNeg";
            this.b_PTZ_FocusNeg.Size = new System.Drawing.Size(59, 34);
            this.b_PTZ_FocusNeg.TabIndex = 47;
            this.b_PTZ_FocusNeg.Text = "F-";
            this.b_PTZ_FocusNeg.UseVisualStyleBackColor = false;
            this.b_PTZ_FocusNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusNeg_MouseDown);
            this.b_PTZ_FocusNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_ZoomNeg
            // 
            this.b_PTZ_ZoomNeg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_ZoomNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_ZoomNeg.Location = new System.Drawing.Point(85, 72);
            this.b_PTZ_ZoomNeg.Name = "b_PTZ_ZoomNeg";
            this.b_PTZ_ZoomNeg.Size = new System.Drawing.Size(59, 35);
            this.b_PTZ_ZoomNeg.TabIndex = 46;
            this.b_PTZ_ZoomNeg.Text = "Z-";
            this.b_PTZ_ZoomNeg.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomNeg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomNeg_MouseDown);
            this.b_PTZ_ZoomNeg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusPos
            // 
            this.b_PTZ_FocusPos.BackColor = System.Drawing.Color.YellowGreen;
            this.b_PTZ_FocusPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_FocusPos.Location = new System.Drawing.Point(14, 32);
            this.b_PTZ_FocusPos.Name = "b_PTZ_FocusPos";
            this.b_PTZ_FocusPos.Size = new System.Drawing.Size(59, 34);
            this.b_PTZ_FocusPos.TabIndex = 45;
            this.b_PTZ_FocusPos.Text = "F+";
            this.b_PTZ_FocusPos.UseVisualStyleBackColor = false;
            this.b_PTZ_FocusPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_FocusPos_MouseDown);
            this.b_PTZ_FocusPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_ZoomPos
            // 
            this.b_PTZ_ZoomPos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_ZoomPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_ZoomPos.Location = new System.Drawing.Point(85, 32);
            this.b_PTZ_ZoomPos.Name = "b_PTZ_ZoomPos";
            this.b_PTZ_ZoomPos.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_ZoomPos.TabIndex = 44;
            this.b_PTZ_ZoomPos.Text = "Z+";
            this.b_PTZ_ZoomPos.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomPos_MouseDown);
            this.b_PTZ_ZoomPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(35, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // Joystick
            // 
            this.Joystick.BackColor = System.Drawing.Color.Black;
            this.Joystick.Location = new System.Drawing.Point(85, 200);
            this.Joystick.Name = "Joystick";
            this.Joystick.Size = new System.Drawing.Size(50, 50);
            this.Joystick.TabIndex = 74;
            this.Joystick.TabStop = false;
            this.Joystick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Joystick_MouseUp);
            // 
            // l_Debug1
            // 
            this.l_Debug1.AutoSize = true;
            this.l_Debug1.Location = new System.Drawing.Point(12, 323);
            this.l_Debug1.Name = "l_Debug1";
            this.l_Debug1.Size = new System.Drawing.Size(45, 13);
            this.l_Debug1.TabIndex = 79;
            this.l_Debug1.Text = "DEBUG";
            // 
            // l_Debug2
            // 
            this.l_Debug2.AutoSize = true;
            this.l_Debug2.Location = new System.Drawing.Point(12, 356);
            this.l_Debug2.Name = "l_Debug2";
            this.l_Debug2.Size = new System.Drawing.Size(45, 13);
            this.l_Debug2.TabIndex = 80;
            this.l_Debug2.Text = "DEBUG";
            // 
            // l_Debug3
            // 
            this.l_Debug3.AutoSize = true;
            this.l_Debug3.Location = new System.Drawing.Point(14, 390);
            this.l_Debug3.Name = "l_Debug3";
            this.l_Debug3.Size = new System.Drawing.Size(45, 13);
            this.l_Debug3.TabIndex = 81;
            this.l_Debug3.Text = "DEBUG";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(254, 431);
            this.Controls.Add(this.l_Debug3);
            this.Controls.Add(this.l_Debug2);
            this.Controls.Add(this.l_Debug1);
            this.Controls.Add(this.Joystick);
            this.Controls.Add(this.check_IPCon_KeyboardCon);
            this.Controls.Add(this.l_PTZCon);
            this.Controls.Add(this.b_PTZ_FocusNeg);
            this.Controls.Add(this.b_PTZ_ZoomNeg);
            this.Controls.Add(this.b_PTZ_FocusPos);
            this.Controls.Add(this.b_PTZ_ZoomPos);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Joystick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.CheckBox check_IPCon_KeyboardCon;
        public System.Windows.Forms.Label l_PTZCon;
        public System.Windows.Forms.Button b_PTZ_FocusNeg;
        public System.Windows.Forms.Button b_PTZ_ZoomNeg;
        public System.Windows.Forms.Button b_PTZ_FocusPos;
        public System.Windows.Forms.Button b_PTZ_ZoomPos;
        public Joystick.CentreStick Joystick;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label l_Debug1;
        public System.Windows.Forms.Label l_Debug2;
        public System.Windows.Forms.Label l_Debug3;
    }
}