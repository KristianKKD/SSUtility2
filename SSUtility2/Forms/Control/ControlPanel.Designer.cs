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
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Joystick)).BeginInit();
            this.SuspendLayout();
            // 
            // check_IPCon_KeyboardCon
            // 
            this.check_IPCon_KeyboardCon.AutoSize = true;
            this.check_IPCon_KeyboardCon.Location = new System.Drawing.Point(2, 289);
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
            this.b_PTZ_FocusNeg.Location = new System.Drawing.Point(-8, 239);
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
            this.b_PTZ_ZoomNeg.Location = new System.Drawing.Point(213, 238);
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
            this.b_PTZ_FocusPos.Location = new System.Drawing.Point(-8, 41);
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
            this.b_PTZ_ZoomPos.Location = new System.Drawing.Point(213, 39);
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
            this.pictureBox1.Location = new System.Drawing.Point(57, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // Joystick
            // 
            this.Joystick.BackColor = System.Drawing.Color.Black;
            this.Joystick.Location = new System.Drawing.Point(107, 131);
            this.Joystick.Name = "Joystick";
            this.Joystick.Size = new System.Drawing.Size(50, 50);
            this.Joystick.TabIndex = 74;
            this.Joystick.TabStop = false;
            this.Joystick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Joystick_MouseUp);
            // 
            // b_PTZ_Up
            // 
            this.b_PTZ_Up.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Up.Location = new System.Drawing.Point(107, 39);
            this.b_PTZ_Up.Name = "b_PTZ_Up";
            this.b_PTZ_Up.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Up.TabIndex = 82;
            this.b_PTZ_Up.Text = "Up";
            this.b_PTZ_Up.UseVisualStyleBackColor = false;
            // 
            // b_PTZ_Down
            // 
            this.b_PTZ_Down.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Down.Location = new System.Drawing.Point(107, 237);
            this.b_PTZ_Down.Name = "b_PTZ_Down";
            this.b_PTZ_Down.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Down.TabIndex = 83;
            this.b_PTZ_Down.Text = "Down";
            this.b_PTZ_Down.UseVisualStyleBackColor = false;
            // 
            // b_PTZ_Right
            // 
            this.b_PTZ_Right.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Right.Location = new System.Drawing.Point(213, 131);
            this.b_PTZ_Right.Name = "b_PTZ_Right";
            this.b_PTZ_Right.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Right.TabIndex = 84;
            this.b_PTZ_Right.Text = "Right";
            this.b_PTZ_Right.UseVisualStyleBackColor = false;
            // 
            // b_PTZ_Left
            // 
            this.b_PTZ_Left.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.b_PTZ_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Left.Location = new System.Drawing.Point(-8, 131);
            this.b_PTZ_Left.Name = "b_PTZ_Left";
            this.b_PTZ_Left.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Left.TabIndex = 85;
            this.b_PTZ_Left.Text = "Left";
            this.b_PTZ_Left.UseVisualStyleBackColor = false;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(254, 431);
            this.Controls.Add(this.b_PTZ_Left);
            this.Controls.Add(this.b_PTZ_Right);
            this.Controls.Add(this.b_PTZ_Down);
            this.Controls.Add(this.b_PTZ_Up);
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
        public System.Windows.Forms.Button b_PTZ_Up;
        public System.Windows.Forms.Button b_PTZ_Down;
        public System.Windows.Forms.Button b_PTZ_Right;
        public System.Windows.Forms.Button b_PTZ_Left;
    }
}