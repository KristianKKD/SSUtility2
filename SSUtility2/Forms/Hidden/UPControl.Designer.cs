﻿
namespace SSUtility2.Hidden
{
    partial class UPControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UPControl));
            this.tB_Text = new System.Windows.Forms.TextBox();
            this.b_Send = new System.Windows.Forms.Button();
            this.l_Send = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tB_Text
            // 
            this.tB_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Text.Location = new System.Drawing.Point(15, 12);
            this.tB_Text.Name = "tB_Text";
            this.tB_Text.Size = new System.Drawing.Size(1309, 20);
            this.tB_Text.TabIndex = 0;
            // 
            // b_Send
            // 
            this.b_Send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Send.Location = new System.Drawing.Point(1249, 38);
            this.b_Send.Name = "b_Send";
            this.b_Send.Size = new System.Drawing.Size(75, 409);
            this.b_Send.TabIndex = 1;
            this.b_Send.Text = "Send";
            this.b_Send.UseVisualStyleBackColor = true;
            this.b_Send.Click += new System.EventHandler(this.b_Send_Click);
            // 
            // l_Send
            // 
            this.l_Send.Location = new System.Drawing.Point(0, 38);
            this.l_Send.Name = "l_Send";
            this.l_Send.Size = new System.Drawing.Size(1243, 409);
            this.l_Send.TabIndex = 2;
            // 
            // UPControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 456);
            this.Controls.Add(this.l_Send);
            this.Controls.Add(this.b_Send);
            this.Controls.Add(this.tB_Text);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UPControl";
            this.Text = "UPControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_Text;
        private System.Windows.Forms.Button b_Send;
        private System.Windows.Forms.Label l_Send;
    }
}