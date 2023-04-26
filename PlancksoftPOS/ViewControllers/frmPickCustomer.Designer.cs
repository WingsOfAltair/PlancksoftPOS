namespace PlancksoftPOS
{
    partial class frmPickCustomer
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
            this.DGVCustomers = new System.Windows.Forms.DataGridView();
            this.lblCustomerName = new MaterialSkin.Controls.MaterialLabel();
            this.txtCustomerName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtCustomerID = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblCustomerID = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnPickCustomer = new MaterialSkin.Controls.MaterialButton();
            this.CustomerPickCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPickCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPickItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPickItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPickCustomerPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCustomers
            // 
            this.DGVCustomers.BackgroundColor = System.Drawing.Color.White;
            this.DGVCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerPickCustomerName,
            this.CustomerPickCustomerID,
            this.CustomerPickItemName,
            this.CustomerPickItemBarCode,
            this.CustomerPickCustomerPrice});
            this.DGVCustomers.Location = new System.Drawing.Point(6, 67);
            this.DGVCustomers.Name = "DGVCustomers";
            this.DGVCustomers.Size = new System.Drawing.Size(764, 362);
            this.DGVCustomers.TabIndex = 1;
            this.DGVCustomers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVCustomers_RowHeaderMouseClick);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Depth = 0;
            this.lblCustomerName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomerName.Location = new System.Drawing.Point(4, 432);
            this.lblCustomerName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCustomerName.Size = new System.Drawing.Size(44, 19);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "إسم الزبون";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AnimateReadOnly = false;
            this.txtCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCustomerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCustomerName.Depth = 0;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerName.HideSelection = true;
            this.txtCustomerName.LeadingIcon = null;
            this.txtCustomerName.Location = new System.Drawing.Point(7, 452);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.PrefixSuffixText = null;
            this.txtCustomerName.ReadOnly = false;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(360, 48);
            this.txtCustomerName.TabIndex = 4;
            this.txtCustomerName.TabStop = false;
            this.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCustomerName.TrailingIcon = null;
            this.txtCustomerName.UseSystemPasswordChar = false;
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AnimateReadOnly = false;
            this.txtCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCustomerID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCustomerID.Depth = 0;
            this.txtCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerID.HideSelection = true;
            this.txtCustomerID.LeadingIcon = null;
            this.txtCustomerID.Location = new System.Drawing.Point(409, 452);
            this.txtCustomerID.MaxLength = 32767;
            this.txtCustomerID.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.PasswordChar = '\0';
            this.txtCustomerID.PrefixSuffixText = null;
            this.txtCustomerID.ReadOnly = false;
            this.txtCustomerID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerID.SelectedText = "";
            this.txtCustomerID.SelectionLength = 0;
            this.txtCustomerID.SelectionStart = 0;
            this.txtCustomerID.ShortcutsEnabled = true;
            this.txtCustomerID.Size = new System.Drawing.Size(360, 48);
            this.txtCustomerID.TabIndex = 6;
            this.txtCustomerID.TabStop = false;
            this.txtCustomerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCustomerID.TrailingIcon = null;
            this.txtCustomerID.UseSystemPasswordChar = false;
            this.txtCustomerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerID_KeyPress);
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Depth = 0;
            this.lblCustomerID.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomerID.Location = new System.Drawing.Point(406, 432);
            this.lblCustomerID.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCustomerID.Size = new System.Drawing.Size(47, 19);
            this.lblCustomerID.TabIndex = 5;
            this.lblCustomerID.Text = "رمز الزبون";
            this.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // btnPickCustomer
            // 
            this.btnPickCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPickCustomer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPickCustomer.Depth = 0;
            this.btnPickCustomer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPickCustomer.HighEmphasis = true;
            this.btnPickCustomer.Icon = null;
            this.btnPickCustomer.Location = new System.Drawing.Point(3, 508);
            this.btnPickCustomer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPickCustomer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPickCustomer.Name = "btnPickCustomer";
            this.btnPickCustomer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPickCustomer.Size = new System.Drawing.Size(769, 36);
            this.btnPickCustomer.TabIndex = 74;
            this.btnPickCustomer.Text = "إختيار الزبون";
            this.btnPickCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPickCustomer.UseAccentColor = false;
            this.btnPickCustomer.UseVisualStyleBackColor = true;
            this.btnPickCustomer.Click += new System.EventHandler(this.btnPickCustomer_Click);
            // 
            // CustomerPickCustomerName
            // 
            this.CustomerPickCustomerName.DataPropertyName = "Customer Name";
            this.CustomerPickCustomerName.HeaderText = "اسم الزبون";
            this.CustomerPickCustomerName.Name = "CustomerPickCustomerName";
            // 
            // CustomerPickCustomerID
            // 
            this.CustomerPickCustomerID.DataPropertyName = "Customer ID";
            this.CustomerPickCustomerID.HeaderText = "رقم الزبون";
            this.CustomerPickCustomerID.Name = "CustomerPickCustomerID";
            // 
            // CustomerPickItemName
            // 
            this.CustomerPickItemName.DataPropertyName = "Item Name";
            this.CustomerPickItemName.HeaderText = "اسم الماده";
            this.CustomerPickItemName.Name = "CustomerPickItemName";
            this.CustomerPickItemName.Visible = false;
            // 
            // CustomerPickItemBarCode
            // 
            this.CustomerPickItemBarCode.DataPropertyName = "Item BarCode";
            this.CustomerPickItemBarCode.HeaderText = "باركود الماده";
            this.CustomerPickItemBarCode.Name = "CustomerPickItemBarCode";
            this.CustomerPickItemBarCode.Visible = false;
            // 
            // CustomerPickCustomerPrice
            // 
            this.CustomerPickCustomerPrice.DataPropertyName = "Customer Price";
            this.CustomerPickCustomerPrice.HeaderText = "سعر العميل";
            this.CustomerPickCustomerPrice.Name = "CustomerPickCustomerPrice";
            this.CustomerPickCustomerPrice.Visible = false;
            // 
            // frmPickCustomer
            // 
            this.ClientSize = new System.Drawing.Size(775, 619);
            this.Controls.Add(this.btnPickCustomer);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.DGVCustomers);
            this.Name = "frmPickCustomer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.DGVCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DGVCustomers;
        private MaterialSkin.Controls.MaterialLabel lblCustomerName;
        private MaterialSkin.Controls.MaterialTextBox2 txtCustomerName;
        private MaterialSkin.Controls.MaterialTextBox2 txtCustomerID;
        private MaterialSkin.Controls.MaterialLabel lblCustomerID;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnPickCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPickCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPickCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPickItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPickItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPickCustomerPrice;
    }
}