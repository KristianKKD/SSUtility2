namespace SSUtility2
{
    partial class PelcoD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PelcoD));
            this.b_PD_Load = new System.Windows.Forms.Button();
            this.b_PD_Save = new System.Windows.Forms.Button();
            this.b_PD_Fire = new System.Windows.Forms.Button();
            this.l_PD_Scripting = new System.Windows.Forms.Label();
            this.l_IPCon_Connected = new System.Windows.Forms.Label();
            this.b_PD_Stop = new System.Windows.Forms.Button();
            this.b_PD_RL = new System.Windows.Forms.Button();
            this.tt_CommandFormat = new System.Windows.Forms.ToolTip(this.components);
            this.b_PD_ComList = new System.Windows.Forms.Button();
            this.cB_Mode = new System.Windows.Forms.ComboBox();
            this.l_Mode = new System.Windows.Forms.Label();
            this.tB_Commands = new System.Windows.Forms.TextBox();
            this.p_Serial = new System.Windows.Forms.Panel();
            this.l_Serial_Baud = new System.Windows.Forms.Label();
            this.l_Port = new System.Windows.Forms.Label();
            this.tB_Serial_Baud = new System.Windows.Forms.TextBox();
            this.tB_Serial_Port = new System.Windows.Forms.TextBox();
            this.p_Serial.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_PD_Load
            // 
            this.b_PD_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PD_Load.BackColor = System.Drawing.SystemColors.Control;
            this.b_PD_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PD_Load.Location = new System.Drawing.Point(349, 118);
            this.b_PD_Load.Name = "b_PD_Load";
            this.b_PD_Load.Size = new System.Drawing.Size(111, 38);
            this.b_PD_Load.TabIndex = 9;
            this.b_PD_Load.Text = "Load Script";
            this.b_PD_Load.UseVisualStyleBackColor = false;
            this.b_PD_Load.Click += new System.EventHandler(this.b_PD_Load_Click);
            // 
            // b_PD_Save
            // 
            this.b_PD_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PD_Save.BackColor = System.Drawing.SystemColors.Control;
            this.b_PD_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PD_Save.Location = new System.Drawing.Point(349, 76);
            this.b_PD_Save.Name = "b_PD_Save";
            this.b_PD_Save.Size = new System.Drawing.Size(111, 38);
            this.b_PD_Save.TabIndex = 8;
            this.b_PD_Save.Text = "Save Script";
            this.b_PD_Save.UseVisualStyleBackColor = false;
            this.b_PD_Save.Click += new System.EventHandler(this.b_PD_Save_Click);
            // 
            // b_PD_Fire
            // 
            this.b_PD_Fire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PD_Fire.BackColor = System.Drawing.SystemColors.Control;
            this.b_PD_Fire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PD_Fire.Location = new System.Drawing.Point(349, 32);
            this.b_PD_Fire.Name = "b_PD_Fire";
            this.b_PD_Fire.Size = new System.Drawing.Size(111, 38);
            this.b_PD_Fire.TabIndex = 7;
            this.b_PD_Fire.Text = "Fire Commands";
            this.b_PD_Fire.UseVisualStyleBackColor = false;
            this.b_PD_Fire.Click += new System.EventHandler(this.b_PD_Fire_Click);
            // 
            // l_PD_Scripting
            // 
            this.l_PD_Scripting.AutoSize = true;
            this.l_PD_Scripting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PD_Scripting.Location = new System.Drawing.Point(8, 9);
            this.l_PD_Scripting.Name = "l_PD_Scripting";
            this.l_PD_Scripting.Size = new System.Drawing.Size(142, 20);
            this.l_PD_Scripting.TabIndex = 13;
            this.l_PD_Scripting.Text = "PelcoD Scripting";
            // 
            // l_IPCon_Connected
            // 
            this.l_IPCon_Connected.AutoSize = true;
            this.l_IPCon_Connected.Location = new System.Drawing.Point(572, 176);
            this.l_IPCon_Connected.Name = "l_IPCon_Connected";
            this.l_IPCon_Connected.Size = new System.Drawing.Size(0, 13);
            this.l_IPCon_Connected.TabIndex = 79;
            // 
            // b_PD_Stop
            // 
            this.b_PD_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PD_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.b_PD_Stop.Enabled = false;
            this.b_PD_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PD_Stop.Location = new System.Drawing.Point(348, 399);
            this.b_PD_Stop.Name = "b_PD_Stop";
            this.b_PD_Stop.Size = new System.Drawing.Size(111, 39);
            this.b_PD_Stop.TabIndex = 89;
            this.b_PD_Stop.Text = "Stop Script Execution";
            this.b_PD_Stop.UseVisualStyleBackColor = false;
            this.b_PD_Stop.Click += new System.EventHandler(this.b_PD_Stop_Click);
            // 
            // b_PD_RL
            // 
            this.b_PD_RL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PD_RL.BackColor = System.Drawing.SystemColors.Control;
            this.b_PD_RL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PD_RL.Location = new System.Drawing.Point(349, 311);
            this.b_PD_RL.Name = "b_PD_RL";
            this.b_PD_RL.Size = new System.Drawing.Size(111, 38);
            this.b_PD_RL.TabIndex = 90;
            this.b_PD_RL.Text = "Open Response Log";
            this.b_PD_RL.UseVisualStyleBackColor = false;
            this.b_PD_RL.Click += new System.EventHandler(this.b_PD_RL_Click);
            // 
            // b_PD_ComList
            // 
            this.b_PD_ComList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PD_ComList.BackColor = System.Drawing.SystemColors.Control;
            this.b_PD_ComList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_PD_ComList.Location = new System.Drawing.Point(349, 355);
            this.b_PD_ComList.Name = "b_PD_ComList";
            this.b_PD_ComList.Size = new System.Drawing.Size(111, 38);
            this.b_PD_ComList.TabIndex = 93;
            this.b_PD_ComList.Text = "Open Command List";
            this.b_PD_ComList.UseVisualStyleBackColor = false;
            this.b_PD_ComList.Click += new System.EventHandler(this.b_PD_ComList_Click);
            // 
            // cB_Mode
            // 
            this.cB_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cB_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Mode.FormattingEnabled = true;
            this.cB_Mode.Items.AddRange(new object[] {
            "IP",
            "Serial"});
            this.cB_Mode.Location = new System.Drawing.Point(349, 6);
            this.cB_Mode.Name = "cB_Mode";
            this.cB_Mode.Size = new System.Drawing.Size(111, 21);
            this.cB_Mode.TabIndex = 95;
            this.cB_Mode.SelectedIndexChanged += new System.EventHandler(this.cB_Mode_SelectedIndexChanged);
            // 
            // l_Mode
            // 
            this.l_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Mode.AutoSize = true;
            this.l_Mode.Location = new System.Drawing.Point(230, 9);
            this.l_Mode.Name = "l_Mode";
            this.l_Mode.Size = new System.Drawing.Size(112, 13);
            this.l_Mode.TabIndex = 94;
            this.l_Mode.Text = "Communication Mode:";
            // 
            // tB_Commands
            // 
            this.tB_Commands.AllowDrop = true;
            this.tB_Commands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Commands.BackColor = System.Drawing.SystemColors.Control;
            this.tB_Commands.Location = new System.Drawing.Point(12, 32);
            this.tB_Commands.Multiline = true;
            this.tB_Commands.Name = "tB_Commands";
            this.tB_Commands.Size = new System.Drawing.Size(331, 406);
            this.tB_Commands.TabIndex = 96;
            this.tB_Commands.DragDrop += new System.Windows.Forms.DragEventHandler(this.tB_Commands_DragDrop);
            this.tB_Commands.DragEnter += new System.Windows.Forms.DragEventHandler(this.tB_Commands_DragEnter);
            // 
            // p_Serial
            // 
            this.p_Serial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Serial.Controls.Add(this.l_Serial_Baud);
            this.p_Serial.Controls.Add(this.l_Port);
            this.p_Serial.Controls.Add(this.tB_Serial_Baud);
            this.p_Serial.Controls.Add(this.tB_Serial_Port);
            this.p_Serial.Location = new System.Drawing.Point(348, 162);
            this.p_Serial.Name = "p_Serial";
            this.p_Serial.Size = new System.Drawing.Size(125, 123);
            this.p_Serial.TabIndex = 98;
            this.p_Serial.Visible = false;
            // 
            // l_Serial_Baud
            // 
            this.l_Serial_Baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Serial_Baud.AutoSize = true;
            this.l_Serial_Baud.Location = new System.Drawing.Point(1, 5);
            this.l_Serial_Baud.Name = "l_Serial_Baud";
            this.l_Serial_Baud.Size = new System.Drawing.Size(58, 13);
            this.l_Serial_Baud.TabIndex = 80;
            this.l_Serial_Baud.Text = "Baud Rate";
            // 
            // l_Port
            // 
            this.l_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Port.AutoSize = true;
            this.l_Port.Location = new System.Drawing.Point(0, 44);
            this.l_Port.Name = "l_Port";
            this.l_Port.Size = new System.Drawing.Size(29, 13);
            this.l_Port.TabIndex = 82;
            this.l_Port.Text = "Port:";
            // 
            // tB_Serial_Baud
            // 
            this.tB_Serial_Baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Serial_Baud.Location = new System.Drawing.Point(4, 21);
            this.tB_Serial_Baud.Name = "tB_Serial_Baud";
            this.tB_Serial_Baud.Size = new System.Drawing.Size(111, 20);
            this.tB_Serial_Baud.TabIndex = 1;
            this.tB_Serial_Baud.Text = "9600";
            // 
            // tB_Serial_Port
            // 
            this.tB_Serial_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Serial_Port.Location = new System.Drawing.Point(4, 60);
            this.tB_Serial_Port.Name = "tB_Serial_Port";
            this.tB_Serial_Port.Size = new System.Drawing.Size(111, 20);
            this.tB_Serial_Port.TabIndex = 2;
            // 
            // PelcoD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(470, 450);
            this.Controls.Add(this.tB_Commands);
            this.Controls.Add(this.cB_Mode);
            this.Controls.Add(this.l_Mode);
            this.Controls.Add(this.b_PD_ComList);
            this.Controls.Add(this.b_PD_RL);
            this.Controls.Add(this.b_PD_Stop);
            this.Controls.Add(this.l_IPCon_Connected);
            this.Controls.Add(this.l_PD_Scripting);
            this.Controls.Add(this.b_PD_Load);
            this.Controls.Add(this.b_PD_Save);
            this.Controls.Add(this.b_PD_Fire);
            this.Controls.Add(this.p_Serial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PelcoD";
            this.Text = "PelcoD Scripting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PelcoD_FormClosing);
            this.p_Serial.ResumeLayout(false);
            this.p_Serial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_PD_Load;
        private System.Windows.Forms.Button b_PD_Save;
        private System.Windows.Forms.Button b_PD_Fire;
        public System.Windows.Forms.Label l_PD_Scripting;
        public System.Windows.Forms.Label l_IPCon_Connected;
        private System.Windows.Forms.Button b_PD_Stop;
        private System.Windows.Forms.Button b_PD_RL;
        private System.Windows.Forms.ToolTip tt_CommandFormat;
        private System.Windows.Forms.Button b_PD_ComList;
        public System.Windows.Forms.ComboBox cB_Mode;
        public System.Windows.Forms.Label l_Mode;
        public System.Windows.Forms.TextBox tB_Commands;
        private System.Windows.Forms.Panel p_Serial;
        public System.Windows.Forms.Label l_Serial_Baud;
        public System.Windows.Forms.Label l_Port;
        public System.Windows.Forms.TextBox tB_Serial_Baud;
        public System.Windows.Forms.TextBox tB_Serial_Port;
    }
}