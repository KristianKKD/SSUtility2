
namespace SSUtility2.Other.Other_Scripts
{
    partial class FirmwareUpgrade
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
            this.Versionlabel = new System.Windows.Forms.Label();
            this.ResetMemorybutton = new System.Windows.Forms.Button();
            this.GetSNbutton = new System.Windows.Forms.Button();
            this.Abortbutton = new System.Windows.Forms.Button();
            this.Writebutton = new System.Windows.Forms.Button();
            this.CamNolabel = new System.Windows.Forms.Label();
            this.Erasebutton = new System.Windows.Forms.Button();
            this.CamNoUpDown = new System.Windows.Forms.NumericUpDown();
            this.Checksumbutton = new System.Windows.Forms.Button();
            this.SNtext = new System.Windows.Forms.Label();
            this.LoadHexbutton = new System.Windows.Forms.Button();
            this.Versiontext = new System.Windows.Forms.Label();
            this.Activatebutton = new System.Windows.Forms.Button();
            this.ClearLogbutton = new System.Windows.Forms.Button();
            this.DeActivatebutton = new System.Windows.Forms.Button();
            this.Loglabel = new System.Windows.Forms.Label();
            this.Gobutton = new System.Windows.Forms.Button();
            this.LogtextBox = new System.Windows.Forms.TextBox();
            this.Speedlabel = new System.Windows.Forms.Label();
            this.LoadSpeedlabel = new System.Windows.Forms.Label();
            this.Portbutton = new System.Windows.Forms.Button();
            this.SpeedcomboBox = new System.Windows.Forms.ComboBox();
            this.PortcomboBox = new System.Windows.Forms.ComboBox();
            this.LoadSpeedcomboBox = new System.Windows.Forms.ComboBox();
            this.Portlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CamNoUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Versionlabel
            // 
            this.Versionlabel.Location = new System.Drawing.Point(27, 40);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(75, 19);
            this.Versionlabel.TabIndex = 30;
            this.Versionlabel.Text = "BootLoader:";
            // 
            // ResetMemorybutton
            // 
            this.ResetMemorybutton.Location = new System.Drawing.Point(377, 169);
            this.ResetMemorybutton.Name = "ResetMemorybutton";
            this.ResetMemorybutton.Size = new System.Drawing.Size(75, 33);
            this.ResetMemorybutton.TabIndex = 53;
            this.ResetMemorybutton.Text = "reset mem";
            this.ResetMemorybutton.UseVisualStyleBackColor = true;
            // 
            // GetSNbutton
            // 
            this.GetSNbutton.Location = new System.Drawing.Point(27, 62);
            this.GetSNbutton.Name = "GetSNbutton";
            this.GetSNbutton.Size = new System.Drawing.Size(75, 23);
            this.GetSNbutton.TabIndex = 29;
            this.GetSNbutton.Text = "GetSN";
            this.GetSNbutton.UseVisualStyleBackColor = true;
            // 
            // Abortbutton
            // 
            this.Abortbutton.Location = new System.Drawing.Point(377, 120);
            this.Abortbutton.Name = "Abortbutton";
            this.Abortbutton.Size = new System.Drawing.Size(75, 42);
            this.Abortbutton.TabIndex = 52;
            this.Abortbutton.Text = "Abort";
            this.Abortbutton.UseVisualStyleBackColor = true;
            // 
            // Writebutton
            // 
            this.Writebutton.Location = new System.Drawing.Point(27, 120);
            this.Writebutton.Name = "Writebutton";
            this.Writebutton.Size = new System.Drawing.Size(75, 23);
            this.Writebutton.TabIndex = 31;
            this.Writebutton.Text = "Write";
            this.Writebutton.UseVisualStyleBackColor = true;
            // 
            // CamNolabel
            // 
            this.CamNolabel.Location = new System.Drawing.Point(386, 40);
            this.CamNolabel.Name = "CamNolabel";
            this.CamNolabel.Size = new System.Drawing.Size(52, 18);
            this.CamNolabel.TabIndex = 51;
            this.CamNolabel.Text = "Camera";
            // 
            // Erasebutton
            // 
            this.Erasebutton.Location = new System.Drawing.Point(27, 150);
            this.Erasebutton.Name = "Erasebutton";
            this.Erasebutton.Size = new System.Drawing.Size(75, 23);
            this.Erasebutton.TabIndex = 32;
            this.Erasebutton.Text = "Erase";
            this.Erasebutton.UseVisualStyleBackColor = true;
            // 
            // CamNoUpDown
            // 
            this.CamNoUpDown.AllowDrop = true;
            this.CamNoUpDown.InterceptArrowKeys = false;
            this.CamNoUpDown.Location = new System.Drawing.Point(386, 64);
            this.CamNoUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CamNoUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CamNoUpDown.Name = "CamNoUpDown";
            this.CamNoUpDown.Size = new System.Drawing.Size(66, 20);
            this.CamNoUpDown.TabIndex = 50;
            this.CamNoUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Checksumbutton
            // 
            this.Checksumbutton.Location = new System.Drawing.Point(27, 180);
            this.Checksumbutton.Name = "Checksumbutton";
            this.Checksumbutton.Size = new System.Drawing.Size(75, 23);
            this.Checksumbutton.TabIndex = 33;
            this.Checksumbutton.Text = "Checksum";
            this.Checksumbutton.UseVisualStyleBackColor = true;
            // 
            // SNtext
            // 
            this.SNtext.Location = new System.Drawing.Point(121, 66);
            this.SNtext.Name = "SNtext";
            this.SNtext.Size = new System.Drawing.Size(100, 19);
            this.SNtext.TabIndex = 49;
            this.SNtext.Text = "serial_no";
            // 
            // LoadHexbutton
            // 
            this.LoadHexbutton.Location = new System.Drawing.Point(160, 119);
            this.LoadHexbutton.Name = "LoadHexbutton";
            this.LoadHexbutton.Size = new System.Drawing.Size(75, 23);
            this.LoadHexbutton.TabIndex = 34;
            this.LoadHexbutton.Text = "LoadHex";
            this.LoadHexbutton.UseVisualStyleBackColor = true;
            // 
            // Versiontext
            // 
            this.Versiontext.Location = new System.Drawing.Point(121, 40);
            this.Versiontext.Name = "Versiontext";
            this.Versiontext.Size = new System.Drawing.Size(100, 15);
            this.Versiontext.TabIndex = 48;
            this.Versiontext.Text = "version";
            // 
            // Activatebutton
            // 
            this.Activatebutton.Location = new System.Drawing.Point(160, 150);
            this.Activatebutton.Name = "Activatebutton";
            this.Activatebutton.Size = new System.Drawing.Size(75, 23);
            this.Activatebutton.TabIndex = 35;
            this.Activatebutton.Text = "Activate";
            this.Activatebutton.UseVisualStyleBackColor = true;
            // 
            // ClearLogbutton
            // 
            this.ClearLogbutton.Location = new System.Drawing.Point(377, 247);
            this.ClearLogbutton.Name = "ClearLogbutton";
            this.ClearLogbutton.Size = new System.Drawing.Size(75, 23);
            this.ClearLogbutton.TabIndex = 47;
            this.ClearLogbutton.Text = "Clear Log";
            this.ClearLogbutton.UseVisualStyleBackColor = true;
            // 
            // DeActivatebutton
            // 
            this.DeActivatebutton.Location = new System.Drawing.Point(160, 179);
            this.DeActivatebutton.Name = "DeActivatebutton";
            this.DeActivatebutton.Size = new System.Drawing.Size(75, 23);
            this.DeActivatebutton.TabIndex = 36;
            this.DeActivatebutton.Text = "DeActivate";
            this.DeActivatebutton.UseVisualStyleBackColor = true;
            // 
            // Loglabel
            // 
            this.Loglabel.Location = new System.Drawing.Point(27, 274);
            this.Loglabel.Name = "Loglabel";
            this.Loglabel.Size = new System.Drawing.Size(43, 22);
            this.Loglabel.TabIndex = 46;
            this.Loglabel.Text = "Log";
            // 
            // Gobutton
            // 
            this.Gobutton.Location = new System.Drawing.Point(266, 120);
            this.Gobutton.Name = "Gobutton";
            this.Gobutton.Size = new System.Drawing.Size(75, 82);
            this.Gobutton.TabIndex = 37;
            this.Gobutton.Text = "GO";
            this.Gobutton.UseVisualStyleBackColor = true;
            // 
            // LogtextBox
            // 
            this.LogtextBox.Location = new System.Drawing.Point(26, 299);
            this.LogtextBox.Multiline = true;
            this.LogtextBox.Name = "LogtextBox";
            this.LogtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogtextBox.Size = new System.Drawing.Size(1157, 218);
            this.LogtextBox.TabIndex = 45;
            this.LogtextBox.WordWrap = false;
            // 
            // Speedlabel
            // 
            this.Speedlabel.Location = new System.Drawing.Point(55, 224);
            this.Speedlabel.Name = "Speedlabel";
            this.Speedlabel.Size = new System.Drawing.Size(47, 23);
            this.Speedlabel.TabIndex = 38;
            this.Speedlabel.Text = "Speed";
            // 
            // LoadSpeedlabel
            // 
            this.LoadSpeedlabel.Location = new System.Drawing.Point(160, 224);
            this.LoadSpeedlabel.Name = "LoadSpeedlabel";
            this.LoadSpeedlabel.Size = new System.Drawing.Size(75, 23);
            this.LoadSpeedlabel.TabIndex = 39;
            this.LoadSpeedlabel.Text = "Load Speed";
            // 
            // Portbutton
            // 
            this.Portbutton.Location = new System.Drawing.Point(266, 61);
            this.Portbutton.Name = "Portbutton";
            this.Portbutton.Size = new System.Drawing.Size(75, 23);
            this.Portbutton.TabIndex = 44;
            this.Portbutton.Text = "Open Port";
            this.Portbutton.UseVisualStyleBackColor = true;
            // 
            // SpeedcomboBox
            // 
            this.SpeedcomboBox.FormattingEnabled = true;
            this.SpeedcomboBox.Location = new System.Drawing.Point(27, 250);
            this.SpeedcomboBox.Name = "SpeedcomboBox";
            this.SpeedcomboBox.Size = new System.Drawing.Size(90, 21);
            this.SpeedcomboBox.TabIndex = 40;
            // 
            // PortcomboBox
            // 
            this.PortcomboBox.FormattingEnabled = true;
            this.PortcomboBox.Location = new System.Drawing.Point(266, 249);
            this.PortcomboBox.Name = "PortcomboBox";
            this.PortcomboBox.Size = new System.Drawing.Size(75, 21);
            this.PortcomboBox.TabIndex = 43;
            // 
            // LoadSpeedcomboBox
            // 
            this.LoadSpeedcomboBox.FormattingEnabled = true;
            this.LoadSpeedcomboBox.Location = new System.Drawing.Point(135, 249);
            this.LoadSpeedcomboBox.Name = "LoadSpeedcomboBox";
            this.LoadSpeedcomboBox.Size = new System.Drawing.Size(100, 21);
            this.LoadSpeedcomboBox.TabIndex = 41;
            // 
            // Portlabel
            // 
            this.Portlabel.Location = new System.Drawing.Point(289, 224);
            this.Portlabel.Name = "Portlabel";
            this.Portlabel.Size = new System.Drawing.Size(31, 13);
            this.Portlabel.TabIndex = 42;
            this.Portlabel.Text = "Port";
            // 
            // FirmwareUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 598);
            this.Controls.Add(this.Versionlabel);
            this.Controls.Add(this.ResetMemorybutton);
            this.Controls.Add(this.GetSNbutton);
            this.Controls.Add(this.Abortbutton);
            this.Controls.Add(this.Writebutton);
            this.Controls.Add(this.CamNolabel);
            this.Controls.Add(this.Erasebutton);
            this.Controls.Add(this.CamNoUpDown);
            this.Controls.Add(this.Checksumbutton);
            this.Controls.Add(this.SNtext);
            this.Controls.Add(this.LoadHexbutton);
            this.Controls.Add(this.Versiontext);
            this.Controls.Add(this.Activatebutton);
            this.Controls.Add(this.ClearLogbutton);
            this.Controls.Add(this.DeActivatebutton);
            this.Controls.Add(this.Loglabel);
            this.Controls.Add(this.Gobutton);
            this.Controls.Add(this.LogtextBox);
            this.Controls.Add(this.Speedlabel);
            this.Controls.Add(this.LoadSpeedlabel);
            this.Controls.Add(this.Portbutton);
            this.Controls.Add(this.SpeedcomboBox);
            this.Controls.Add(this.PortcomboBox);
            this.Controls.Add(this.LoadSpeedcomboBox);
            this.Controls.Add(this.Portlabel);
            this.Name = "FirmwareUpgrade";
            this.Text = "FirmwareUpgrade";
            ((System.ComponentModel.ISupportInitialize)(this.CamNoUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Versionlabel;
        private System.Windows.Forms.Button ResetMemorybutton;
        private System.Windows.Forms.Button GetSNbutton;
        private System.Windows.Forms.Button Abortbutton;
        private System.Windows.Forms.Button Writebutton;
        private System.Windows.Forms.Label CamNolabel;
        private System.Windows.Forms.Button Erasebutton;
        private System.Windows.Forms.NumericUpDown CamNoUpDown;
        private System.Windows.Forms.Button Checksumbutton;
        private System.Windows.Forms.Label SNtext;
        private System.Windows.Forms.Button LoadHexbutton;
        private System.Windows.Forms.Label Versiontext;
        private System.Windows.Forms.Button Activatebutton;
        private System.Windows.Forms.Button ClearLogbutton;
        private System.Windows.Forms.Button DeActivatebutton;
        private System.Windows.Forms.Label Loglabel;
        private System.Windows.Forms.Button Gobutton;
        private System.Windows.Forms.TextBox LogtextBox;
        private System.Windows.Forms.Label Speedlabel;
        private System.Windows.Forms.Label LoadSpeedlabel;
        private System.Windows.Forms.Button Portbutton;
        private System.Windows.Forms.ComboBox SpeedcomboBox;
        private System.Windows.Forms.ComboBox PortcomboBox;
        private System.Windows.Forms.ComboBox LoadSpeedcomboBox;
        private System.Windows.Forms.Label Portlabel;
    }
}