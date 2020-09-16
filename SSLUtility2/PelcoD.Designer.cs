namespace SSLUtility2
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.b_PD_Fire = new System.Windows.Forms.Button();
            this.rtb_PD_Commands = new System.Windows.Forms.RichTextBox();
            this.l_PD_Scripted = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(348, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "Load Script";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save Script";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // b_PD_Fire
            // 
            this.b_PD_Fire.Location = new System.Drawing.Point(348, 26);
            this.b_PD_Fire.Name = "b_PD_Fire";
            this.b_PD_Fire.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Fire.TabIndex = 7;
            this.b_PD_Fire.Text = "Fire Commands";
            this.b_PD_Fire.UseVisualStyleBackColor = true;
            this.b_PD_Fire.Click += new System.EventHandler(this.b_PD_Fire_Click);
            // 
            // rtb_PD_Commands
            // 
            this.rtb_PD_Commands.Location = new System.Drawing.Point(12, 26);
            this.rtb_PD_Commands.Name = "rtb_PD_Commands";
            this.rtb_PD_Commands.Size = new System.Drawing.Size(330, 391);
            this.rtb_PD_Commands.TabIndex = 6;
            this.rtb_PD_Commands.Text = "";
            // 
            // l_PD_Scripted
            // 
            this.l_PD_Scripted.AutoSize = true;
            this.l_PD_Scripted.Location = new System.Drawing.Point(12, 10);
            this.l_PD_Scripted.Name = "l_PD_Scripted";
            this.l_PD_Scripted.Size = new System.Drawing.Size(84, 13);
            this.l_PD_Scripted.TabIndex = 5;
            this.l_PD_Scripted.Text = "Scripted PelcoD";
            // 
            // PelcoD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_PD_Fire);
            this.Controls.Add(this.rtb_PD_Commands);
            this.Controls.Add(this.l_PD_Scripted);
            this.Name = "PelcoD";
            this.Text = "PelcoD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_PD_Fire;
        private System.Windows.Forms.RichTextBox rtb_PD_Commands;
        private System.Windows.Forms.Label l_PD_Scripted;
    }
}