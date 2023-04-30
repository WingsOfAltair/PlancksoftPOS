namespace PlancksoftPOS
{
    partial class frmClientCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientCard));
            this.lblClientName = new MaterialSkin.Controls.MaterialLabel();
            this.txtClientName = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblItemName = new MaterialSkin.Controls.MaterialLabel();
            this.txtItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtClientID = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblClientID = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Depth = 0;
            this.lblClientName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientName.Location = new System.Drawing.Point(6, 105);
            this.lblClientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(43, 19);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "إسم العميل";
            // 
            // txtClientName
            // 
            this.txtClientName.AnimateReadOnly = false;
            this.txtClientName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtClientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtClientName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtClientName.Depth = 0;
            this.txtClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtClientName.HideSelection = true;
            this.txtClientName.LeadingIcon = null;
            this.txtClientName.Location = new System.Drawing.Point(187, 74);
            this.txtClientName.MaxLength = 32767;
            this.txtClientName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.PasswordChar = '\0';
            this.txtClientName.PrefixSuffixText = null;
            this.txtClientName.ReadOnly = false;
            this.txtClientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtClientName.SelectedText = "";
            this.txtClientName.SelectionLength = 0;
            this.txtClientName.SelectionStart = 0;
            this.txtClientName.ShortcutsEnabled = true;
            this.txtClientName.Size = new System.Drawing.Size(401, 48);
            this.txtClientName.TabIndex = 1;
            this.txtClientName.TabStop = false;
            this.txtClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClientName.TrailingIcon = null;
            this.txtClientName.UseSystemPasswordChar = false;
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemName.Location = new System.Drawing.Point(11, 213);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(40, 19);
            this.lblItemName.TabIndex = 4;
            this.lblItemName.Text = "إسم الماده";
            // 
            // txtItemName
            // 
            this.txtItemName.AnimateReadOnly = false;
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemName.Depth = 0;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtItemName.HideSelection = true;
            this.txtItemName.LeadingIcon = null;
            this.txtItemName.Location = new System.Drawing.Point(187, 182);
            this.txtItemName.MaxLength = 32767;
            this.txtItemName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.PasswordChar = '\0';
            this.txtItemName.PrefixSuffixText = null;
            this.txtItemName.ReadOnly = false;
            this.txtItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemName.SelectedText = "";
            this.txtItemName.SelectionLength = 0;
            this.txtItemName.SelectionStart = 0;
            this.txtItemName.ShortcutsEnabled = true;
            this.txtItemName.Size = new System.Drawing.Size(401, 48);
            this.txtItemName.TabIndex = 5;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemName.TrailingIcon = null;
            this.txtItemName.UseSystemPasswordChar = false;
            // 
            // dgvClients
            // 
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.dgvClients.Location = new System.Drawing.Point(9, 236);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.Size = new System.Drawing.Size(579, 341);
            this.dgvClients.TabIndex = 5;
            this.dgvClients.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClients_RowHeaderMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Client Name";
            this.Column1.HeaderText = "اسم العميل";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Client ID";
            this.Column2.HeaderText = "رمز العميل";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Item Name";
            this.Column3.HeaderText = "اسم الماده";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Item BarCode";
            this.Column5.HeaderText = "باركود الماده";
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Client Price";
            this.Column4.HeaderText = "سعر العميل";
            this.Column4.Name = "Column4";
            // 
            // txtClientID
            // 
            this.txtClientID.AnimateReadOnly = false;
            this.txtClientID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtClientID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtClientID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtClientID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtClientID.Depth = 0;
            this.txtClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtClientID.HideSelection = true;
            this.txtClientID.LeadingIcon = null;
            this.txtClientID.Location = new System.Drawing.Point(187, 128);
            this.txtClientID.MaxLength = 32767;
            this.txtClientID.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.PasswordChar = '\0';
            this.txtClientID.PrefixSuffixText = null;
            this.txtClientID.ReadOnly = false;
            this.txtClientID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtClientID.SelectedText = "";
            this.txtClientID.SelectionLength = 0;
            this.txtClientID.SelectionStart = 0;
            this.txtClientID.ShortcutsEnabled = true;
            this.txtClientID.Size = new System.Drawing.Size(401, 48);
            this.txtClientID.TabIndex = 3;
            this.txtClientID.TabStop = false;
            this.txtClientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClientID.TrailingIcon = null;
            this.txtClientID.UseSystemPasswordChar = false;
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Depth = 0;
            this.lblClientID.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientID.Location = new System.Drawing.Point(11, 159);
            this.lblClientID.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(40, 19);
            this.lblClientID.TabIndex = 2;
            this.lblClientID.Text = "إسم الماده";
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(3, 699);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(669, 36);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "الخروج";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClear.Depth = 0;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClear.HighEmphasis = true;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(3, 663);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(669, 36);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(3, 627);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSearch.Size = new System.Drawing.Size(669, 36);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "البحث";
            this.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSearch.UseAccentColor = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmClientCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 738);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.lblClientID);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblClientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة بطاقة العميل";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblClientName;
        private MaterialSkin.Controls.MaterialTextBox2 txtClientName;
        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemName;
        public System.Windows.Forms.DataGridView dgvClients;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private MaterialSkin.Controls.MaterialTextBox2 txtClientID;
        private MaterialSkin.Controls.MaterialLabel lblClientID;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnSearch;
    }
}