namespace SSLUtility2
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
            this.tB_Presets_Number = new System.Windows.Forms.TextBox();
            this.tB_IPCon_Port = new System.Windows.Forms.TextBox();
            this.tB_IPCon_Adr = new System.Windows.Forms.TextBox();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.track_PTZ_PTSpeed = new System.Windows.Forms.TrackBar();
            this.cB_IPCon_Type = new System.Windows.Forms.ComboBox();
            this.cB_IPCon_KeyboardCon = new System.Windows.Forms.CheckBox();
            this.cB_IPCon_Selected = new System.Windows.Forms.ComboBox();
            this.l_IPCon_KeyControl = new System.Windows.Forms.Label();
            this.l_IPCon_SelectedCam = new System.Windows.Forms.Label();
            this.l_IPCon_Port = new System.Windows.Forms.Label();
            this.l_IPCon_PTSpeed = new System.Windows.Forms.Label();
            this.l_Presets_Number = new System.Windows.Forms.Label();
            this.l_IPCon_ConType = new System.Windows.Forms.Label();
            this.l_IPCon_Adr = new System.Windows.Forms.Label();
            this.l_Presets = new System.Windows.Forms.Label();
            this.l_PTZCon = new System.Windows.Forms.Label();
            this.l_IPCon = new System.Windows.Forms.Label();
            this.b_PlayerL_Detach = new System.Windows.Forms.Button();
            this.b_Presets_Learn = new System.Windows.Forms.Button();
            this.b_Presets_GoTo = new System.Windows.Forms.Button();
            this.b_PTZ_Down = new System.Windows.Forms.Button();
            this.b_PTZ_Up = new System.Windows.Forms.Button();
            this.b_PTZ_FocusNeg = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomNeg = new System.Windows.Forms.Button();
            this.b_PTZ_FocusPos = new System.Windows.Forms.Button();
            this.b_PTZ_ZoomPos = new System.Windows.Forms.Button();
            this.b_PTZ_Right = new System.Windows.Forms.Button();
            this.b_PTZ_Left = new System.Windows.Forms.Button();
            this.b_IPCon_LayoutMode = new System.Windows.Forms.Button();
            this.b_IPCon_CustomD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.track_PTZ_PTSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_Presets_Number
            // 
            this.tB_Presets_Number.Location = new System.Drawing.Point(117, 536);
            this.tB_Presets_Number.Name = "tB_Presets_Number";
            this.tB_Presets_Number.Size = new System.Drawing.Size(123, 20);
            this.tB_Presets_Number.TabIndex = 68;
            // 
            // tB_IPCon_Port
            // 
            this.tB_IPCon_Port.Location = new System.Drawing.Point(108, 91);
            this.tB_IPCon_Port.Name = "tB_IPCon_Port";
            this.tB_IPCon_Port.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Port.TabIndex = 65;
            this.tB_IPCon_Port.Text = "6791";
            // 
            // tB_IPCon_Adr
            // 
            this.tB_IPCon_Adr.Location = new System.Drawing.Point(108, 65);
            this.tB_IPCon_Adr.Name = "tB_IPCon_Adr";
            this.tB_IPCon_Adr.Size = new System.Drawing.Size(123, 20);
            this.tB_IPCon_Adr.TabIndex = 64;
            this.tB_IPCon_Adr.Text = "192.168.1.71";
            this.tB_IPCon_Adr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_IPCon_Adr_KeyDown);
            this.tB_IPCon_Adr.Leave += new System.EventHandler(this.tB_IPCon_Adr_Leave);
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(237, 65);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Connected.TabIndex = 71;
            // 
            // track_PTZ_PTSpeed
            // 
            this.track_PTZ_PTSpeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.track_PTZ_PTSpeed.Location = new System.Drawing.Point(98, 359);
            this.track_PTZ_PTSpeed.Maximum = 63;
            this.track_PTZ_PTSpeed.Name = "track_PTZ_PTSpeed";
            this.track_PTZ_PTSpeed.Size = new System.Drawing.Size(132, 45);
            this.track_PTZ_PTSpeed.TabIndex = 70;
            this.track_PTZ_PTSpeed.Value = 63;
            // 
            // cB_IPCon_Type
            // 
            this.cB_IPCon_Type.FormattingEnabled = true;
            this.cB_IPCon_Type.Items.AddRange(new object[] {
            "Encoder",
            "MOXA nPort"});
            this.cB_IPCon_Type.Location = new System.Drawing.Point(108, 38);
            this.cB_IPCon_Type.Name = "cB_IPCon_Type";
            this.cB_IPCon_Type.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_Type.TabIndex = 69;
            this.cB_IPCon_Type.Text = "Encoder";
            this.cB_IPCon_Type.SelectedIndexChanged += new System.EventHandler(this.cB_IPCon_Type_SelectedIndexChanged);
            // 
            // cB_IPCon_KeyboardCon
            // 
            this.cB_IPCon_KeyboardCon.AutoSize = true;
            this.cB_IPCon_KeyboardCon.Location = new System.Drawing.Point(108, 153);
            this.cB_IPCon_KeyboardCon.Name = "cB_IPCon_KeyboardCon";
            this.cB_IPCon_KeyboardCon.Size = new System.Drawing.Size(15, 14);
            this.cB_IPCon_KeyboardCon.TabIndex = 67;
            this.cB_IPCon_KeyboardCon.UseVisualStyleBackColor = true;
            this.cB_IPCon_KeyboardCon.CheckedChanged += new System.EventHandler(this.cB_IPCon_KeyboardCon_CheckedChanged);
            // 
            // cB_IPCon_Selected
            // 
            this.cB_IPCon_Selected.FormattingEnabled = true;
            this.cB_IPCon_Selected.Items.AddRange(new object[] {
            "Daylight",
            "Thermal"});
            this.cB_IPCon_Selected.Location = new System.Drawing.Point(108, 118);
            this.cB_IPCon_Selected.Name = "cB_IPCon_Selected";
            this.cB_IPCon_Selected.Size = new System.Drawing.Size(123, 21);
            this.cB_IPCon_Selected.TabIndex = 66;
            this.cB_IPCon_Selected.Text = "Daylight";
            // 
            // l_IPCon_KeyControl
            // 
            this.l_IPCon_KeyControl.AutoSize = true;
            this.l_IPCon_KeyControl.Location = new System.Drawing.Point(13, 153);
            this.l_IPCon_KeyControl.Name = "l_IPCon_KeyControl";
            this.l_IPCon_KeyControl.Size = new System.Drawing.Size(91, 13);
            this.l_IPCon_KeyControl.TabIndex = 63;
            this.l_IPCon_KeyControl.Text = "Keyboard Control:";
            // 
            // l_IPCon_SelectedCam
            // 
            this.l_IPCon_SelectedCam.AutoSize = true;
            this.l_IPCon_SelectedCam.Location = new System.Drawing.Point(13, 121);
            this.l_IPCon_SelectedCam.Name = "l_IPCon_SelectedCam";
            this.l_IPCon_SelectedCam.Size = new System.Drawing.Size(91, 13);
            this.l_IPCon_SelectedCam.TabIndex = 62;
            this.l_IPCon_SelectedCam.Text = "Selected Camera:";
            // 
            // l_IPCon_Port
            // 
            this.l_IPCon_Port.AutoSize = true;
            this.l_IPCon_Port.Location = new System.Drawing.Point(13, 91);
            this.l_IPCon_Port.Name = "l_IPCon_Port";
            this.l_IPCon_Port.Size = new System.Drawing.Size(29, 13);
            this.l_IPCon_Port.TabIndex = 61;
            this.l_IPCon_Port.Text = "Port:";
            // 
            // l_IPCon_PTSpeed
            // 
            this.l_IPCon_PTSpeed.AutoSize = true;
            this.l_IPCon_PTSpeed.Location = new System.Drawing.Point(12, 370);
            this.l_IPCon_PTSpeed.Name = "l_IPCon_PTSpeed";
            this.l_IPCon_PTSpeed.Size = new System.Drawing.Size(88, 13);
            this.l_IPCon_PTSpeed.TabIndex = 59;
            this.l_IPCon_PTSpeed.Text = "Pan / Tilt Speed:";
            // 
            // l_Presets_Number
            // 
            this.l_Presets_Number.AutoSize = true;
            this.l_Presets_Number.Location = new System.Drawing.Point(19, 539);
            this.l_Presets_Number.Name = "l_Presets_Number";
            this.l_Presets_Number.Size = new System.Drawing.Size(47, 13);
            this.l_Presets_Number.TabIndex = 60;
            this.l_Presets_Number.Text = "Number:";
            // 
            // l_IPCon_ConType
            // 
            this.l_IPCon_ConType.AutoSize = true;
            this.l_IPCon_ConType.Location = new System.Drawing.Point(13, 41);
            this.l_IPCon_ConType.Name = "l_IPCon_ConType";
            this.l_IPCon_ConType.Size = new System.Drawing.Size(70, 13);
            this.l_IPCon_ConType.TabIndex = 58;
            this.l_IPCon_ConType.Text = "Control Type:";
            // 
            // l_IPCon_Adr
            // 
            this.l_IPCon_Adr.AutoSize = true;
            this.l_IPCon_Adr.Location = new System.Drawing.Point(13, 65);
            this.l_IPCon_Adr.Name = "l_IPCon_Adr";
            this.l_IPCon_Adr.Size = new System.Drawing.Size(61, 13);
            this.l_IPCon_Adr.TabIndex = 57;
            this.l_IPCon_Adr.Text = "IP Address:";
            // 
            // l_Presets
            // 
            this.l_Presets.AutoSize = true;
            this.l_Presets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Presets.Location = new System.Drawing.Point(12, 503);
            this.l_Presets.Name = "l_Presets";
            this.l_Presets.Size = new System.Drawing.Size(70, 20);
            this.l_Presets.TabIndex = 56;
            this.l_Presets.Text = "Presets";
            // 
            // l_PTZCon
            // 
            this.l_PTZCon.AutoSize = true;
            this.l_PTZCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PTZCon.Location = new System.Drawing.Point(12, 182);
            this.l_PTZCon.Name = "l_PTZCon";
            this.l_PTZCon.Size = new System.Drawing.Size(104, 20);
            this.l_PTZCon.TabIndex = 55;
            this.l_PTZCon.Text = "PTZ Control";
            // 
            // l_IPCon
            // 
            this.l_IPCon.AutoSize = true;
            this.l_IPCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_IPCon.Location = new System.Drawing.Point(12, 9);
            this.l_IPCon.Name = "l_IPCon";
            this.l_IPCon.Size = new System.Drawing.Size(89, 20);
            this.l_IPCon.TabIndex = 54;
            this.l_IPCon.Text = "IP Control";
            // 
            // b_PlayerL_Detach
            // 
            this.b_PlayerL_Detach.Location = new System.Drawing.Point(89, 410);
            this.b_PlayerL_Detach.Name = "b_PlayerL_Detach";
            this.b_PlayerL_Detach.Size = new System.Drawing.Size(75, 87);
            this.b_PlayerL_Detach.TabIndex = 53;
            this.b_PlayerL_Detach.Text = "Spawn Detached Video Player";
            this.b_PlayerL_Detach.UseVisualStyleBackColor = true;
            this.b_PlayerL_Detach.Click += new System.EventHandler(this.b_Detach);
            // 
            // b_Presets_Learn
            // 
            this.b_Presets_Learn.Location = new System.Drawing.Point(146, 562);
            this.b_Presets_Learn.Name = "b_Presets_Learn";
            this.b_Presets_Learn.Size = new System.Drawing.Size(94, 22);
            this.b_Presets_Learn.TabIndex = 51;
            this.b_Presets_Learn.Text = "Learn";
            this.b_Presets_Learn.UseVisualStyleBackColor = true;
            this.b_Presets_Learn.Click += new System.EventHandler(this.b_Presets_Learn_Click);
            // 
            // b_Presets_GoTo
            // 
            this.b_Presets_GoTo.Location = new System.Drawing.Point(22, 563);
            this.b_Presets_GoTo.Name = "b_Presets_GoTo";
            this.b_Presets_GoTo.Size = new System.Drawing.Size(94, 22);
            this.b_Presets_GoTo.TabIndex = 50;
            this.b_Presets_GoTo.Text = "Go To";
            this.b_Presets_GoTo.UseVisualStyleBackColor = true;
            this.b_Presets_GoTo.Click += new System.EventHandler(this.b_Presets_GoTo_Click);
            // 
            // b_PTZ_Down
            // 
            this.b_PTZ_Down.Location = new System.Drawing.Point(94, 304);
            this.b_PTZ_Down.Name = "b_PTZ_Down";
            this.b_PTZ_Down.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Down.TabIndex = 49;
            this.b_PTZ_Down.Text = "Down";
            this.b_PTZ_Down.UseVisualStyleBackColor = true;
            this.b_PTZ_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Down_MouseDown);
            this.b_PTZ_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Up
            // 
            this.b_PTZ_Up.Location = new System.Drawing.Point(94, 220);
            this.b_PTZ_Up.Name = "b_PTZ_Up";
            this.b_PTZ_Up.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Up.TabIndex = 48;
            this.b_PTZ_Up.Text = "Up";
            this.b_PTZ_Up.UseVisualStyleBackColor = true;
            this.b_PTZ_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Up_MouseDown);
            this.b_PTZ_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_FocusNeg
            // 
            this.b_PTZ_FocusNeg.BackColor = System.Drawing.Color.Aqua;
            this.b_PTZ_FocusNeg.Location = new System.Drawing.Point(16, 306);
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
            this.b_PTZ_ZoomNeg.BackColor = System.Drawing.Color.GreenYellow;
            this.b_PTZ_ZoomNeg.Location = new System.Drawing.Point(16, 219);
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
            this.b_PTZ_FocusPos.BackColor = System.Drawing.Color.Aqua;
            this.b_PTZ_FocusPos.Location = new System.Drawing.Point(171, 306);
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
            this.b_PTZ_ZoomPos.BackColor = System.Drawing.Color.GreenYellow;
            this.b_PTZ_ZoomPos.Location = new System.Drawing.Point(171, 220);
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
            this.b_PTZ_Right.Location = new System.Drawing.Point(152, 262);
            this.b_PTZ_Right.Name = "b_PTZ_Right";
            this.b_PTZ_Right.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Right.TabIndex = 52;
            this.b_PTZ_Right.Text = "Right";
            this.b_PTZ_Right.UseVisualStyleBackColor = true;
            this.b_PTZ_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Right_MouseDown);
            this.b_PTZ_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_PTZ_Left
            // 
            this.b_PTZ_Left.Location = new System.Drawing.Point(36, 262);
            this.b_PTZ_Left.Name = "b_PTZ_Left";
            this.b_PTZ_Left.Size = new System.Drawing.Size(59, 36);
            this.b_PTZ_Left.TabIndex = 43;
            this.b_PTZ_Left.Text = "Left";
            this.b_PTZ_Left.UseVisualStyleBackColor = true;
            this.b_PTZ_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Left_MouseDown);
            this.b_PTZ_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.b_PTZ_Any_MouseUp);
            // 
            // b_IPCon_LayoutMode
            // 
            this.b_IPCon_LayoutMode.Location = new System.Drawing.Point(167, 410);
            this.b_IPCon_LayoutMode.Name = "b_IPCon_LayoutMode";
            this.b_IPCon_LayoutMode.Size = new System.Drawing.Size(75, 87);
            this.b_IPCon_LayoutMode.TabIndex = 75;
            this.b_IPCon_LayoutMode.Text = "Swap To: Lite Mode";
            this.b_IPCon_LayoutMode.UseVisualStyleBackColor = true;
            this.b_IPCon_LayoutMode.Click += new System.EventHandler(this.b_IPCon_LayoutMode_Click);
            // 
            // b_IPCon_CustomD
            // 
            this.b_IPCon_CustomD.Location = new System.Drawing.Point(11, 410);
            this.b_IPCon_CustomD.Name = "b_IPCon_CustomD";
            this.b_IPCon_CustomD.Size = new System.Drawing.Size(75, 87);
            this.b_IPCon_CustomD.TabIndex = 76;
            this.b_IPCon_CustomD.Text = "Custom PelcoD";
            this.b_IPCon_CustomD.UseVisualStyleBackColor = true;
            this.b_IPCon_CustomD.Click += new System.EventHandler(this.b_IPCon_CustomD_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 586);
            this.Controls.Add(this.b_IPCon_CustomD);
            this.Controls.Add(this.b_IPCon_LayoutMode);
            this.Controls.Add(this.tB_Presets_Number);
            this.Controls.Add(this.tB_IPCon_Port);
            this.Controls.Add(this.tB_IPCon_Adr);
            this.Controls.Add(this.l_IPCon_Connected);
            this.Controls.Add(this.track_PTZ_PTSpeed);
            this.Controls.Add(this.cB_IPCon_Type);
            this.Controls.Add(this.cB_IPCon_KeyboardCon);
            this.Controls.Add(this.cB_IPCon_Selected);
            this.Controls.Add(this.l_IPCon_KeyControl);
            this.Controls.Add(this.l_IPCon_SelectedCam);
            this.Controls.Add(this.l_IPCon_Port);
            this.Controls.Add(this.l_IPCon_PTSpeed);
            this.Controls.Add(this.l_Presets_Number);
            this.Controls.Add(this.l_IPCon_ConType);
            this.Controls.Add(this.l_IPCon_Adr);
            this.Controls.Add(this.l_Presets);
            this.Controls.Add(this.l_PTZCon);
            this.Controls.Add(this.l_IPCon);
            this.Controls.Add(this.b_PlayerL_Detach);
            this.Controls.Add(this.b_Presets_Learn);
            this.Controls.Add(this.b_Presets_GoTo);
            this.Controls.Add(this.b_PTZ_Down);
            this.Controls.Add(this.b_PTZ_Up);
            this.Controls.Add(this.b_PTZ_FocusNeg);
            this.Controls.Add(this.b_PTZ_ZoomNeg);
            this.Controls.Add(this.b_PTZ_FocusPos);
            this.Controls.Add(this.b_PTZ_ZoomPos);
            this.Controls.Add(this.b_PTZ_Right);
            this.Controls.Add(this.b_PTZ_Left);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.track_PTZ_PTSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tB_Presets_Number;
        public System.Windows.Forms.TextBox tB_IPCon_Port;
        public System.Windows.Forms.TextBox tB_IPCon_Adr;
        public System.Windows.Forms.Label l_IPCon_Connected;
        public System.Windows.Forms.TrackBar track_PTZ_PTSpeed;
        public System.Windows.Forms.ComboBox cB_IPCon_Type;
        public System.Windows.Forms.CheckBox cB_IPCon_KeyboardCon;
        public System.Windows.Forms.ComboBox cB_IPCon_Selected;
        public System.Windows.Forms.Label l_IPCon_KeyControl;
        public System.Windows.Forms.Label l_IPCon_SelectedCam;
        public System.Windows.Forms.Label l_IPCon_Port;
        public System.Windows.Forms.Label l_IPCon_PTSpeed;
        public System.Windows.Forms.Label l_Presets_Number;
        public System.Windows.Forms.Label l_IPCon_ConType;
        public System.Windows.Forms.Label l_IPCon_Adr;
        public System.Windows.Forms.Label l_Presets;
        public System.Windows.Forms.Label l_PTZCon;
        public System.Windows.Forms.Label l_IPCon;
        public System.Windows.Forms.Button b_PlayerL_Detach;
        public System.Windows.Forms.Button b_Presets_Learn;
        public System.Windows.Forms.Button b_Presets_GoTo;
        public System.Windows.Forms.Button b_PTZ_Down;
        public System.Windows.Forms.Button b_PTZ_Up;
        public System.Windows.Forms.Button b_PTZ_FocusNeg;
        public System.Windows.Forms.Button b_PTZ_ZoomNeg;
        public System.Windows.Forms.Button b_PTZ_FocusPos;
        public System.Windows.Forms.Button b_PTZ_ZoomPos;
        public System.Windows.Forms.Button b_PTZ_Right;
        public System.Windows.Forms.Button b_PTZ_Left;
        public System.Windows.Forms.Button b_IPCon_LayoutMode;
        public System.Windows.Forms.Button b_IPCon_CustomD;
    }
}