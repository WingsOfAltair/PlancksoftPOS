namespace PlancksoftPOS
{
    partial class frmPickClientLookup
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
            this.lblClientName = new MaterialSkin.Controls.MaterialLabel();
            this.txtClientName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtClientID = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblClientID = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnPickClient = new MaterialSkin.Controls.MaterialButton();
            this.DGVClients = new System.Windows.Forms.DataGridView();
            this.ClientPickClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPickClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Depth = 0;
            this.lblClientName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientName.Location = new System.Drawing.Point(4, 432);
            this.lblClientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblClientName.Size = new System.Drawing.Size(43, 19);
            this.lblClientName.TabIndex = 2;
            this.lblClientName.Text = "إسم العميل";
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtClientName.Location = new System.Drawing.Point(7, 452);
            this.txtClientName.MaxLength = 32767;
            this.txtClientName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.PasswordChar = '\0';
            this.txtClientName.PrefixSuffixText = null;
            this.txtClientName.ReadOnly = false;
            this.txtClientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtClientName.SelectedText = "";
            this.txtClientName.SelectionLength = 0;
            this.txtClientName.SelectionStart = 0;
            this.txtClientName.ShortcutsEnabled = true;
            this.txtClientName.Size = new System.Drawing.Size(360, 48);
            this.txtClientName.TabIndex = 4;
            this.txtClientName.TabStop = false;
            this.txtClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtClientName.TrailingIcon = null;
            this.txtClientName.UseSystemPasswordChar = false;
            this.txtClientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientName_KeyPress);
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged);
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
            this.txtClientID.Location = new System.Drawing.Point(409, 452);
            this.txtClientID.MaxLength = 32767;
            this.txtClientID.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.PasswordChar = '\0';
            this.txtClientID.PrefixSuffixText = null;
            this.txtClientID.ReadOnly = false;
            this.txtClientID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtClientID.SelectedText = "";
            this.txtClientID.SelectionLength = 0;
            this.txtClientID.SelectionStart = 0;
            this.txtClientID.ShortcutsEnabled = true;
            this.txtClientID.Size = new System.Drawing.Size(360, 48);
            this.txtClientID.TabIndex = 6;
            this.txtClientID.TabStop = false;
            this.txtClientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtClientID.TrailingIcon = null;
            this.txtClientID.UseSystemPasswordChar = false;
            this.txtClientID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientID_KeyPress);
            this.txtClientID.TextChanged += new System.EventHandler(this.txtClientID_TextChanged);
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Depth = 0;
            this.lblClientID.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientID.Location = new System.Drawing.Point(406, 432);
            this.lblClientID.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblClientID.Size = new System.Drawing.Size(46, 19);
            this.lblClientID.TabIndex = 5;
            this.lblClientID.Text = "رمز العميل";
            this.lblClientID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(3, 580);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(769, 36);
            this.btnClose.TabIndex = 72;
            this.btnClose.Text = "إغلاق";
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
            this.btnClear.Location = new System.Drawing.Point(3, 544);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(769, 36);
            this.btnClear.TabIndex = 73;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPickClient
            // 
            this.btnPickClient.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPickClient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPickClient.Depth = 0;
            this.btnPickClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPickClient.HighEmphasis = true;
            this.btnPickClient.Icon = null;
            this.btnPickClient.Location = new System.Drawing.Point(3, 508);
            this.btnPickClient.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPickClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPickClient.Name = "btnPickClient";
            this.btnPickClient.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPickClient.Size = new System.Drawing.Size(769, 36);
            this.btnPickClient.TabIndex = 74;
            this.btnPickClient.Text = "إختيار العميل";
            this.btnPickClient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPickClient.UseAccentColor = false;
            this.btnPickClient.UseVisualStyleBackColor = true;
            this.btnPickClient.Click += new System.EventHandler(this.btnPickClient_Click);
            // 
            // DGVClients
            // 
            this.DGVClients.BackgroundColor = System.Drawing.Color.White;
            this.DGVClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientPickClientName,
            this.ClientPickClientID});
            this.DGVClients.Location = new System.Drawing.Point(3, 67);
            this.DGVClients.Name = "DGVClients";
            this.DGVClients.Size = new System.Drawing.Size(764, 362);
            this.DGVClients.TabIndex = 75;
            this.DGVClients.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVClients_RowHeaderMouseClick);
            // 
            // ClientPickClientName
            // 
            this.ClientPickClientName.DataPropertyName = "Client Name";
            this.ClientPickClientName.HeaderText = "اسم العميل";
            this.ClientPickClientName.Name = "ClientPickClientName";
            // 
            // ClientPickClientID
            // 
            this.ClientPickClientID.DataPropertyName = "Client ID";
            this.ClientPickClientID.HeaderText = "رقم العميل";
            this.ClientPickClientID.Name = "ClientPickClientID";
            // 
            // frmPickClientLookup
            // 
            this.ClientSize = new System.Drawing.Size(775, 619);
            this.Controls.Add(this.DGVClients);
            this.Controls.Add(this.btnPickClient);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.lblClientID);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblClientName);
            this.Name = "frmPickClientLookup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إختيار العميل";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPickClientLookup_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPickClientLookup_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DGVClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lblClientName;
        private MaterialSkin.Controls.MaterialTextBox2 txtClientName;
        private MaterialSkin.Controls.MaterialTextBox2 txtClientID;
        private MaterialSkin.Controls.MaterialLabel lblClientID;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnPickClient;
        public System.Windows.Forms.DataGridView DGVClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPickClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPickClientID;
    }
}