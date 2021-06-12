
namespace SSUtility2.Forms.Other
{
    partial class DebugWindow
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
            this.tB_Debug = new System.Windows.Forms.TextBox();
            this.b_DebugReadCom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tB_Debug
            // 
            this.tB_Debug.Location = new System.Drawing.Point(12, 12);
            this.tB_Debug.Name = "tB_Debug";
            this.tB_Debug.Size = new System.Drawing.Size(443, 20);
            this.tB_Debug.TabIndex = 0;
            // 
            // b_DebugReadCom
            // 
            this.b_DebugReadCom.Location = new System.Drawing.Point(281, 38);
            this.b_DebugReadCom.Name = "b_DebugReadCom";
            this.b_DebugReadCom.Size = new System.Drawing.Size(174, 25);
            this.b_DebugReadCom.TabIndex = 1;
            this.b_DebugReadCom.Text = "Read Out ScriptCommand";
            this.b_DebugReadCom.UseVisualStyleBackColor = true;
            this.b_DebugReadCom.Click += new System.EventHandler(this.b_Debug_Click);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 76);
            this.Controls.Add(this.b_DebugReadCom);
            this.Controls.Add(this.tB_Debug);
            this.Name = "DebugWindow";
            this.Text = "DebugWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_Debug;
        private System.Windows.Forms.Button b_DebugReadCom;
    }
}