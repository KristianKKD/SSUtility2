namespace SSLUtility2
{
    partial class InfoPanel
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
            this.l_Pan = new System.Windows.Forms.Label();
            this.l_Tilt = new System.Windows.Forms.Label();
            this.l_FOV = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_Pan
            // 
            this.l_Pan.AutoSize = true;
            this.l_Pan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.l_Pan.Location = new System.Drawing.Point(12, 9);
            this.l_Pan.Name = "l_Pan";
            this.l_Pan.Size = new System.Drawing.Size(40, 17);
            this.l_Pan.TabIndex = 0;
            this.l_Pan.Text = "PAN:";
            // 
            // l_Tilt
            // 
            this.l_Tilt.AutoSize = true;
            this.l_Tilt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.l_Tilt.Location = new System.Drawing.Point(287, 9);
            this.l_Tilt.Name = "l_Tilt";
            this.l_Tilt.Size = new System.Drawing.Size(41, 17);
            this.l_Tilt.TabIndex = 1;
            this.l_Tilt.Text = "TILT:";
            // 
            // l_FOV
            // 
            this.l_FOV.AutoSize = true;
            this.l_FOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.l_FOV.Location = new System.Drawing.Point(12, 35);
            this.l_FOV.Name = "l_FOV";
            this.l_FOV.Size = new System.Drawing.Size(44, 17);
            this.l_FOV.TabIndex = 2;
            this.l_FOV.Text = "FOV: ";
            // 
            // InfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 61);
            this.Controls.Add(this.l_FOV);
            this.Controls.Add(this.l_Tilt);
            this.Controls.Add(this.l_Pan);
            this.Name = "InfoPanel";
            this.Text = "InfoPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Pan;
        private System.Windows.Forms.Label l_Tilt;
        private System.Windows.Forms.Label l_FOV;
    }
}