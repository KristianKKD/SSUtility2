
namespace SSLUtility2
{
    partial class CommandListWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Coms = new System.Windows.Forms.DataGridView();
            this.Commands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Coms)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Coms
            // 
            this.dgv_Coms.AllowUserToDeleteRows = false;
            this.dgv_Coms.AllowUserToResizeRows = false;
            this.dgv_Coms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Coms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Coms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Coms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Coms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Commands,
            this.Message,
            this.h_Description});
            this.dgv_Coms.Location = new System.Drawing.Point(0, 0);
            this.dgv_Coms.Name = "dgv_Coms";
            this.dgv_Coms.RowHeadersVisible = false;
            this.dgv_Coms.Size = new System.Drawing.Size(683, 450);
            this.dgv_Coms.TabIndex = 0;
            this.dgv_Coms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Coms_CellDoubleClick);
            // 
            // Commands
            // 
            this.Commands.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Commands.HeaderText = "Command Name(s)";
            this.Commands.Name = "Commands";
            this.Commands.ReadOnly = true;
            this.Commands.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Commands.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Commands.Width = 200;
            // 
            // Message
            // 
            this.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // h_Description
            // 
            this.h_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.h_Description.HeaderText = "Command Description";
            this.h_Description.MinimumWidth = 100;
            this.h_Description.Name = "h_Description";
            this.h_Description.ReadOnly = true;
            this.h_Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CommandListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 450);
            this.Controls.Add(this.dgv_Coms);
            this.Name = "CommandListWindow";
            this.Text = "CommandListWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Coms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Coms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commands;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn h_Description;
    }
}