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
            this.track_PTZ_PTSpeed = new System.Windows.Forms.TrackBar();
            this.cB_IPCon_KeyboardCon = new System.Windows.Forms.CheckBox();
            this.l_IPCon_PTSpeed = new System.Windows.Forms.Label();
            this.l_PTZCon = new System.Windows.Forms.Label();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            this.track_IPCon_Zoom = new System.Windows.Forms.TrackBar();
            this.l_IPCon_Zoom = new System.Windows.Forms.Label();
            this.centreStick1 = new Joystick.CentreStick();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.track_PTZ_PTSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_IPCon_Zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centreStick1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // track_PTZ_PTSpeed
            // 
            this.track_PTZ_PTSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.track_PTZ_PTSpeed.Location = new System.Drawing.Point(98, 198);
            this.track_PTZ_PTSpeed.Maximum = 63;
            this.track_PTZ_PTSpeed.Name = "track_PTZ_PTSpeed";
            this.track_PTZ_PTSpeed.Size = new System.Drawing.Size(132, 45);
            this.track_PTZ_PTSpeed.TabIndex = 70;
            this.track_PTZ_PTSpeed.Value = 63;
            // 
            // cB_IPCon_KeyboardCon
            // 
            this.cB_IPCon_KeyboardCon.AutoSize = true;
            this.cB_IPCon_KeyboardCon.Location = new System.Drawing.Point(12, 175);
            this.cB_IPCon_KeyboardCon.Name = "cB_IPCon_KeyboardCon";
            this.cB_IPCon_KeyboardCon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cB_IPCon_KeyboardCon.Size = new System.Drawing.Size(110, 17);
            this.cB_IPCon_KeyboardCon.TabIndex = 67;
            this.cB_IPCon_KeyboardCon.Text = " Keyboard Control";
            this.cB_IPCon_KeyboardCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cB_IPCon_KeyboardCon.UseVisualStyleBackColor = true;
            // 
            // l_IPCon_PTSpeed
            // 
            this.l_IPCon_PTSpeed.AutoSize = true;
            this.l_IPCon_PTSpeed.Location = new System.Drawing.Point(13, 207);
            this.l_IPCon_PTSpeed.Name = "l_IPCon_PTSpeed";
            this.l_IPCon_PTSpeed.Size = new System.Drawing.Size(88, 13);
            this.l_IPCon_PTSpeed.TabIndex = 59;
            this.l_IPCon_PTSpeed.Text = "Pan / Tilt Speed:";
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
            // b_PTZ_Down
            // 
            this.b_PTZ_Down.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_PTZ_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Down.Location = new System.Drawing.Point(92, 120);
            this.b_PTZ_Down.Name = "b_PTZ_Down";
            this.b_PTZ_Down.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Down.TabIndex = 49;
            this.b_PTZ_Down.Text = "Down";
            this.b_PTZ_Down.UseVisualStyleBackColor = false;
            this.b_PTZ_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Down_MouseDown);
            this.b_PTZ_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Up
            // 
            this.b_PTZ_Up.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_PTZ_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Up.Location = new System.Drawing.Point(92, 36);
            this.b_PTZ_Up.Name = "b_PTZ_Up";
            this.b_PTZ_Up.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Up.TabIndex = 48;
            this.b_PTZ_Up.Text = "Up";
            this.b_PTZ_Up.UseVisualStyleBackColor = false;
            this.b_PTZ_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Up_MouseDown);
            this.b_PTZ_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusNeg
            // 
            this.b_PTZ_FocusNeg.BackColor = System.Drawing.Color.YellowGreen;
            this.b_PTZ_FocusNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_FocusNeg.Location = new System.Drawing.Point(14, 122);
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
            this.b_PTZ_ZoomNeg.Location = new System.Drawing.Point(14, 35);
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
            this.b_PTZ_FocusPos.Location = new System.Drawing.Point(169, 122);
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
            this.b_PTZ_ZoomPos.Location = new System.Drawing.Point(169, 36);
            this.b_PTZ_ZoomPos.Name = "b_PTZ_ZoomPos";
            this.b_PTZ_ZoomPos.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_ZoomPos.TabIndex = 44;
            this.b_PTZ_ZoomPos.Text = "Z+";
            this.b_PTZ_ZoomPos.UseVisualStyleBackColor = false;
            this.b_PTZ_ZoomPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_ZoomPos_MouseDown);
            this.b_PTZ_ZoomPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Right
            // 
            this.b_PTZ_Right.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_PTZ_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Right.Location = new System.Drawing.Point(150, 78);
            this.b_PTZ_Right.Name = "b_PTZ_Right";
            this.b_PTZ_Right.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Right.TabIndex = 52;
            this.b_PTZ_Right.Text = "Right";
            this.b_PTZ_Right.UseVisualStyleBackColor = false;
            this.b_PTZ_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Right_MouseDown);
            this.b_PTZ_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Left
            // 
            this.b_PTZ_Left.BackColor = System.Drawing.SystemColors.ControlLight;
            this.b_PTZ_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PTZ_Left.Location = new System.Drawing.Point(34, 78);
            this.b_PTZ_Left.Name = "b_PTZ_Left";
            this.b_PTZ_Left.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Left.TabIndex = 43;
            this.b_PTZ_Left.Text = "Left";
            this.b_PTZ_Left.UseVisualStyleBackColor = false;
            this.b_PTZ_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Left_MouseDown);
            this.b_PTZ_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // track_IPCon_Zoom
            // 
            this.track_IPCon_Zoom.BackColor = System.Drawing.SystemColors.Window;
            this.track_IPCon_Zoom.Location = new System.Drawing.Point(98, 240);
            this.track_IPCon_Zoom.Maximum = 3;
            this.track_IPCon_Zoom.Name = "track_IPCon_Zoom";
            this.track_IPCon_Zoom.Size = new System.Drawing.Size(132, 45);
            this.track_IPCon_Zoom.TabIndex = 73;
            this.track_IPCon_Zoom.Value = 3;
            this.track_IPCon_Zoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.track_IPCon_Zoom_MouseUp);
            // 
            // l_IPCon_Zoom
            // 
            this.l_IPCon_Zoom.AutoSize = true;
            this.l_IPCon_Zoom.Location = new System.Drawing.Point(13, 248);
            this.l_IPCon_Zoom.Name = "l_IPCon_Zoom";
            this.l_IPCon_Zoom.Size = new System.Drawing.Size(68, 13);
            this.l_IPCon_Zoom.TabIndex = 72;
            this.l_IPCon_Zoom.Text = "Zoom Speed";
            // 
            // centreStick1
            // 
            this.centreStick1.BackColor = System.Drawing.Color.Black;
            this.centreStick1.Location = new System.Drawing.Point(84, 416);
            this.centreStick1.Name = "centreStick1";
            this.centreStick1.Size = new System.Drawing.Size(50, 50);
            this.centreStick1.TabIndex = 74;
            this.centreStick1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(34, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(254, 561);
            this.Controls.Add(this.centreStick1);
            this.Controls.Add(this.track_IPCon_Zoom);
            this.Controls.Add(this.l_IPCon_Zoom);
            this.Controls.Add(this.cB_IPCon_KeyboardCon);
            this.Controls.Add(this.l_IPCon_PTSpeed);
            this.Controls.Add(this.l_PTZCon);
            this.Controls.Add(this.b_PTZ_Down);
            this.Controls.Add(this.b_PTZ_Up);
            this.Controls.Add(this.b_PTZ_FocusNeg);
            this.Controls.Add(this.b_PTZ_ZoomNeg);
            this.Controls.Add(this.b_PTZ_FocusPos);
            this.Controls.Add(this.b_PTZ_ZoomPos);
            this.Controls.Add(this.b_PTZ_Right);
            this.Controls.Add(this.b_PTZ_Left);
            this.Controls.Add(this.track_PTZ_PTSpeed);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.track_PTZ_PTSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_IPCon_Zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centreStick1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TrackBar track_PTZ_PTSpeed;
        public System.Windows.Forms.CheckBox cB_IPCon_KeyboardCon;
        public System.Windows.Forms.Label l_IPCon_PTSpeed;
        public System.Windows.Forms.Label l_PTZCon;
        public System.Windows.Forms.Button b_PTZ_Down;
        public System.Windows.Forms.Button b_PTZ_Up;
        public System.Windows.Forms.Button b_PTZ_FocusNeg;
        public System.Windows.Forms.Button b_PTZ_ZoomNeg;
        public System.Windows.Forms.Button b_PTZ_FocusPos;
        public System.Windows.Forms.Button b_PTZ_ZoomPos;
        public System.Windows.Forms.Button b_PTZ_Right;
        public System.Windows.Forms.Button b_PTZ_Left;
        public System.Windows.Forms.TrackBar track_IPCon_Zoom;
        public System.Windows.Forms.Label l_IPCon_Zoom;
        private Joystick.CentreStick centreStick1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}