namespace SSUtility2
{
    partial class Final
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Final));
            this.b_Final_Next = new System.Windows.Forms.Button();
            this.l_Destination = new System.Windows.Forms.Label();
            this.l_Source = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.l_SO = new System.Windows.Forms.Label();
            this.l_Customer = new System.Windows.Forms.Label();
            this.check_Default = new System.Windows.Forms.CheckBox();
            this.b_BrowseSource = new System.Windows.Forms.Button();
            this.b_BrowseDest = new System.Windows.Forms.Button();
            this.tB_Customer = new System.Windows.Forms.TextBox();
            this.tB_SO = new System.Windows.Forms.TextBox();
            this.tB_Destination = new System.Windows.Forms.TextBox();
            this.tB_Source = new System.Windows.Forms.TextBox();
            this.check_Old = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // b_Final_Next
            // 
            this.b_Final_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Final_Next.BackColor = System.Drawing.SystemColors.Control;
            this.b_Final_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_Final_Next.Location = new System.Drawing.Point(263, 138);
            this.b_Final_Next.Name = "b_Final_Next";
            this.b_Final_Next.Size = new System.Drawing.Size(146, 40);
            this.b_Final_Next.TabIndex = 0;
            this.b_Final_Next.Text = "Start";
            this.b_Final_Next.UseVisualStyleBackColor = false;
            this.b_Final_Next.Click += new System.EventHandler(this.b_Final_Next_Click);
            // 
            // l_Destination
            // 
            this.l_Destination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Destination.AutoSize = true;
            this.l_Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.l_Destination.Location = new System.Drawing.Point(12, 43);
            this.l_Destination.Name = "l_Destination";
            this.l_Destination.Size = new System.Drawing.Size(95, 13);
            this.l_Destination.TabIndex = 19;
            this.l_Destination.Text = "Destination Folder:";
            // 
            // l_Source
            // 
            this.l_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Source.AutoSize = true;
            this.l_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.l_Source.Location = new System.Drawing.Point(12, 17);
            this.l_Source.Name = "l_Source";
            this.l_Source.Size = new System.Drawing.Size(76, 13);
            this.l_Source.TabIndex = 22;
            this.l_Source.Text = "Source Folder:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // l_SO
            // 
            this.l_SO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SO.AutoSize = true;
            this.l_SO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.l_SO.Location = new System.Drawing.Point(12, 83);
            this.l_SO.Name = "l_SO";
            this.l_SO.Size = new System.Drawing.Size(65, 13);
            this.l_SO.TabIndex = 27;
            this.l_SO.Text = "SO Number:";
            // 
            // l_Customer
            // 
            this.l_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Customer.AutoSize = true;
            this.l_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.l_Customer.Location = new System.Drawing.Point(12, 113);
            this.l_Customer.Name = "l_Customer";
            this.l_Customer.Size = new System.Drawing.Size(85, 13);
            this.l_Customer.TabIndex = 30;
            this.l_Customer.Text = "Customer Name:";
            // 
            // check_Default
            // 
            this.check_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.check_Default.AutoSize = true;
            this.check_Default.Location = new System.Drawing.Point(12, 138);
            this.check_Default.Name = "check_Default";
            this.check_Default.Size = new System.Drawing.Size(107, 17);
            this.check_Default.TabIndex = 31;
            this.check_Default.Text = "Save as Defaults";
            this.check_Default.UseVisualStyleBackColor = true;
            // 
            // b_BrowseSource
            // 
            this.b_BrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_BrowseSource.BackColor = System.Drawing.SystemColors.Control;
            this.b_BrowseSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_BrowseSource.Location = new System.Drawing.Point(415, 12);
            this.b_BrowseSource.Name = "b_BrowseSource";
            this.b_BrowseSource.Size = new System.Drawing.Size(66, 22);
            this.b_BrowseSource.TabIndex = 32;
            this.b_BrowseSource.Text = "Browse";
            this.b_BrowseSource.UseVisualStyleBackColor = false;
            this.b_BrowseSource.Click += new System.EventHandler(this.b_BrowseSource_Click);
            // 
            // b_BrowseDest
            // 
            this.b_BrowseDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_BrowseDest.BackColor = System.Drawing.SystemColors.Control;
            this.b_BrowseDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_BrowseDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.b_BrowseDest.Location = new System.Drawing.Point(415, 40);
            this.b_BrowseDest.Name = "b_BrowseDest";
            this.b_BrowseDest.Size = new System.Drawing.Size(66, 22);
            this.b_BrowseDest.TabIndex = 33;
            this.b_BrowseDest.Text = "Browse";
            this.b_BrowseDest.UseVisualStyleBackColor = false;
            this.b_BrowseDest.Click += new System.EventHandler(this.b_BrowseDest_Click);
            // 
            // tB_Customer
            // 
            this.tB_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Customer.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tB_Customer.Location = new System.Drawing.Point(117, 108);
            this.tB_Customer.Name = "tB_Customer";
            this.tB_Customer.Size = new System.Drawing.Size(292, 20);
            this.tB_Customer.TabIndex = 29;
            // 
            // tB_SO
            // 
            this.tB_SO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_SO.BackColor = System.Drawing.SystemColors.Window;
            this.tB_SO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tB_SO.Location = new System.Drawing.Point(117, 80);
            this.tB_SO.Name = "tB_SO";
            this.tB_SO.Size = new System.Drawing.Size(292, 20);
            this.tB_SO.TabIndex = 26;
            // 
            // tB_Destination
            // 
            this.tB_Destination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Destination.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tB_Destination.Location = new System.Drawing.Point(117, 40);
            this.tB_Destination.Name = "tB_Destination";
            this.tB_Destination.Size = new System.Drawing.Size(292, 20);
            this.tB_Destination.TabIndex = 17;
            // 
            // tB_Source
            // 
            this.tB_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Source.BackColor = System.Drawing.SystemColors.Window;
            this.tB_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tB_Source.Location = new System.Drawing.Point(117, 12);
            this.tB_Source.Name = "tB_Source";
            this.tB_Source.Size = new System.Drawing.Size(292, 20);
            this.tB_Source.TabIndex = 21;
            // 
            // check_Old
            // 
            this.check_Old.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.check_Old.AutoSize = true;
            this.check_Old.Location = new System.Drawing.Point(12, 161);
            this.check_Old.Name = "check_Old";
            this.check_Old.Size = new System.Drawing.Size(93, 17);
            this.check_Old.TabIndex = 34;
            this.check_Old.Text = "Copy Old Files";
            this.check_Old.UseVisualStyleBackColor = true;
            // 
            // Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(493, 190);
            this.Controls.Add(this.check_Old);
            this.Controls.Add(this.b_BrowseDest);
            this.Controls.Add(this.b_BrowseSource);
            this.Controls.Add(this.check_Default);
            this.Controls.Add(this.l_Customer);
            this.Controls.Add(this.tB_Customer);
            this.Controls.Add(this.l_SO);
            this.Controls.Add(this.tB_SO);
            this.Controls.Add(this.l_Source);
            this.Controls.Add(this.tB_Source);
            this.Controls.Add(this.l_Destination);
            this.Controls.Add(this.tB_Destination);
            this.Controls.Add(this.b_Final_Next);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Final";
            this.Text = "Final Test Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Final_Next;
        private System.Windows.Forms.Label l_Destination;
        private System.Windows.Forms.Label l_Source;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label l_SO;
        private System.Windows.Forms.Label l_Customer;
        private System.Windows.Forms.CheckBox check_Default;
        private System.Windows.Forms.Button b_BrowseSource;
        private System.Windows.Forms.Button b_BrowseDest;
        private System.Windows.Forms.TextBox tB_Customer;
        private System.Windows.Forms.TextBox tB_SO;
        private System.Windows.Forms.TextBox tB_Destination;
        private System.Windows.Forms.TextBox tB_Source;
        private System.Windows.Forms.CheckBox check_Old;
    }
}