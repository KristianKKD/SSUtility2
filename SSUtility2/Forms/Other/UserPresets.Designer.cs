
namespace SSUtility2 {
    partial class UserPresets {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPresets));
            this.dgv_Presets = new System.Windows.Forms.DataGridView();
            this.PresetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PelcoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RTSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteRow = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Presets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Presets
            // 
            this.dgv_Presets.AllowUserToResizeRows = false;
            this.dgv_Presets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_Presets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Presets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PresetName,
            this.PelcoID,
            this.IPAdr,
            this.Port,
            this.RTSP,
            this.Username,
            this.Password,
            this.DeleteRow});
            this.dgv_Presets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Presets.Location = new System.Drawing.Point(0, 0);
            this.dgv_Presets.Name = "dgv_Presets";
            this.dgv_Presets.RowHeadersVisible = false;
            this.dgv_Presets.Size = new System.Drawing.Size(800, 450);
            this.dgv_Presets.TabIndex = 0;
            this.dgv_Presets.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_Presets_CellBeginEdit);
            this.dgv_Presets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Presets_CellContentClick);
            this.dgv_Presets.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Presets_CellEndEdit);
            this.dgv_Presets.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Presets_CellValueChanged);
            this.dgv_Presets.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Presets_RowsAdded);
            // 
            // PresetName
            // 
            this.PresetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PresetName.FillWeight = 130F;
            this.PresetName.HeaderText = "Preset Name";
            this.PresetName.Name = "PresetName";
            // 
            // PelcoID
            // 
            this.PelcoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PelcoID.FillWeight = 85F;
            this.PelcoID.HeaderText = "Pelco ID";
            this.PelcoID.Name = "PelcoID";
            // 
            // IPAdr
            // 
            this.IPAdr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IPAdr.FillWeight = 150F;
            this.IPAdr.HeaderText = "IP Address";
            this.IPAdr.Name = "IPAdr";
            // 
            // Port
            // 
            this.Port.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Port.FillWeight = 95.4632F;
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            // 
            // RTSP
            // 
            this.RTSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RTSP.FillWeight = 180F;
            this.RTSP.HeaderText = "RTSP";
            this.RTSP.Name = "RTSP";
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.FillWeight = 95.4632F;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // Password
            // 
            this.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Password.FillWeight = 95.4632F;
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // DeleteRow
            // 
            this.DeleteRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeleteRow.FillWeight = 95.4632F;
            this.DeleteRow.HeaderText = "Delete";
            this.DeleteRow.Name = "DeleteRow";
            this.DeleteRow.ReadOnly = true;
            this.DeleteRow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteRow.Width = 60;
            // 
            // UserPresets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Presets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserPresets";
            this.Text = "UserPresets";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserPresets_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Presets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_Presets;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PelcoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAdr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn RTSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteRow;
    }
}