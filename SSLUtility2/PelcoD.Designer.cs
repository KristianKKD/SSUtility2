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
            this.b_PD_Load = new System.Windows.Forms.Button();
            this.b_PD_Save = new System.Windows.Forms.Button();
            this.b_PD_Fire = new System.Windows.Forms.Button();
            this.rtb_PD_Commands = new System.Windows.Forms.RichTextBox();
            this.l_PD_Scripting = new System.Windows.Forms.Label();
            this.l_PD_Single = new System.Windows.Forms.Label();
            this.b_PD_FireSingle = new System.Windows.Forms.Button();
            this.tB_PD_Single = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_PD_Load
            // 
            this.b_PD_Load.Location = new System.Drawing.Point(348, 110);
            this.b_PD_Load.Name = "b_PD_Load";
            this.b_PD_Load.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Load.TabIndex = 9;
            this.b_PD_Load.Text = "Load Script";
            this.b_PD_Load.UseVisualStyleBackColor = true;
            this.b_PD_Load.Click += new System.EventHandler(this.b_PD_Load_Click);
            // 
            // b_PD_Save
            // 
            this.b_PD_Save.Location = new System.Drawing.Point(348, 71);
            this.b_PD_Save.Name = "b_PD_Save";
            this.b_PD_Save.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Save.TabIndex = 8;
            this.b_PD_Save.Text = "Save Script";
            this.b_PD_Save.UseVisualStyleBackColor = true;
            this.b_PD_Save.Click += new System.EventHandler(this.b_PD_Save_Click);
            // 
            // b_PD_Fire
            // 
            this.b_PD_Fire.Location = new System.Drawing.Point(348, 32);
            this.b_PD_Fire.Name = "b_PD_Fire";
            this.b_PD_Fire.Size = new System.Drawing.Size(111, 33);
            this.b_PD_Fire.TabIndex = 7;
            this.b_PD_Fire.Text = "Fire Commands";
            this.b_PD_Fire.UseVisualStyleBackColor = true;
            this.b_PD_Fire.Click += new System.EventHandler(this.b_PD_Fire_Click);
            // 
            // rtb_PD_Commands
            // 
            this.rtb_PD_Commands.Location = new System.Drawing.Point(12, 32);
            this.rtb_PD_Commands.Name = "rtb_PD_Commands";
            this.rtb_PD_Commands.Size = new System.Drawing.Size(330, 385);
            this.rtb_PD_Commands.TabIndex = 6;
            this.rtb_PD_Commands.Text = "";
            // 
            // l_PD_Scripting
            // 
            this.l_PD_Scripting.AutoSize = true;
            this.l_PD_Scripting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_PD_Scripting.Location = new System.Drawing.Point(12, 9);
            this.l_PD_Scripting.Name = "l_PD_Scripting";
            this.l_PD_Scripting.Size = new System.Drawing.Size(142, 20);
            this.l_PD_Scripting.TabIndex = 13;
            this.l_PD_Scripting.Text = "PelcoD Scripting";
            // 
            // l_PD_Single
            // 
            this.l_PD_Single.AutoSize = true;
            this.l_PD_Single.Location = new System.Drawing.Point(13, 437);
            this.l_PD_Single.Name = "l_PD_Single";
            this.l_PD_Single.Size = new System.Drawing.Size(127, 13);
            this.l_PD_Single.TabIndex = 16;
            this.l_PD_Single.Text = "Single PelcoD Command:";
            // 
            // b_PD_FireSingle
            // 
            this.b_PD_FireSingle.Location = new System.Drawing.Point(271, 434);
            this.b_PD_FireSingle.Name = "b_PD_FireSingle";
            this.b_PD_FireSingle.Size = new System.Drawing.Size(75, 23);
            this.b_PD_FireSingle.TabIndex = 15;
            this.b_PD_FireSingle.Text = "Fire";
            this.b_PD_FireSingle.UseVisualStyleBackColor = true;
            // 
            // tB_PD_Single
            // 
            this.tB_PD_Single.Location = new System.Drawing.Point(146, 434);
            this.tB_PD_Single.Name = "tB_PD_Single";
            this.tB_PD_Single.Size = new System.Drawing.Size(119, 20);
            this.tB_PD_Single.TabIndex = 14;
            // 
            // PelcoD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 481);
            this.Controls.Add(this.l_PD_Single);
            this.Controls.Add(this.b_PD_FireSingle);
            this.Controls.Add(this.tB_PD_Single);
            this.Controls.Add(this.l_PD_Scripting);
            this.Controls.Add(this.b_PD_Load);
            this.Controls.Add(this.b_PD_Save);
            this.Controls.Add(this.b_PD_Fire);
            this.Controls.Add(this.rtb_PD_Commands);
            this.Name = "PelcoD";
            this.Text = "PelcoD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_PD_Load;
        private System.Windows.Forms.Button b_PD_Save;
        private System.Windows.Forms.Button b_PD_Fire;
        private System.Windows.Forms.RichTextBox rtb_PD_Commands;
        public System.Windows.Forms.Label l_PD_Scripting;
        private System.Windows.Forms.Label l_PD_Single;
        private System.Windows.Forms.Button b_PD_FireSingle;
        private System.Windows.Forms.TextBox tB_PD_Single;
    }
}