namespace PlancksoftPOS
{
    partial class frmItemLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemLookup));
            this.DGVItemsLookup = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPriceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItemName = new MaterialSkin.Controls.MaterialLabel();
            this.txtItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtItemBarcode = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblItemBarcode = new MaterialSkin.Controls.MaterialLabel();
            this.lblItemQuantity = new MaterialSkin.Controls.MaterialLabel();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.BtnPrint = new System.Windows.Forms.PictureBox();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.lblItemType = new MaterialSkin.Controls.MaterialLabel();
            this.nudItemQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemsLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVItemsLookup
            // 
            this.DGVItemsLookup.BackgroundColor = System.Drawing.Color.White;
            this.DGVItemsLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVItemsLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.ItemBarCode,
            this.ItemQuantity,
            this.ItemBuyPrice,
            this.ItemPrice,
            this.ItemPriceTax,
            this.WarehouseID,
            this.Warehouse,
            this.ItemType,
            this.ItemTypeName,
            this.FavoriteCategory,
            this.FavoriteCategoryName});
            this.DGVItemsLookup.Location = new System.Drawing.Point(6, 67);
            this.DGVItemsLookup.Name = "DGVItemsLookup";
            this.DGVItemsLookup.Size = new System.Drawing.Size(1218, 378);
            this.DGVItemsLookup.TabIndex = 8;
            this.DGVItemsLookup.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVItemsLookup_RowHeaderMouseDoubleClick);
            // 
            // ItemID
            // 
            this.ItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemID.DataPropertyName = "Item ID";
            this.ItemID.HeaderText = "رقم القطعه";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "Item Name";
            this.ItemName.HeaderText = "اسم القطعه";
            this.ItemName.Name = "ItemName";
            // 
            // ItemBarCode
            // 
            this.ItemBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemBarCode.DataPropertyName = "Item BarCode";
            this.ItemBarCode.HeaderText = "باركود القطعه";
            this.ItemBarCode.Name = "ItemBarCode";
            // 
            // ItemQuantity
            // 
            this.ItemQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemQuantity.DataPropertyName = "Item Quantity";
            this.ItemQuantity.HeaderText = "عدد القطعه";
            this.ItemQuantity.Name = "ItemQuantity";
            // 
            // ItemBuyPrice
            // 
            this.ItemBuyPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemBuyPrice.DataPropertyName = "Item Buy Price";
            this.ItemBuyPrice.HeaderText = "سعر الشراء";
            this.ItemBuyPrice.Name = "ItemBuyPrice";
            // 
            // ItemPrice
            // 
            this.ItemPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemPrice.DataPropertyName = "Item Price";
            this.ItemPrice.HeaderText = "سعر البيع";
            this.ItemPrice.Name = "ItemPrice";
            // 
            // ItemPriceTax
            // 
            this.ItemPriceTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemPriceTax.DataPropertyName = "Item Price Tax";
            this.ItemPriceTax.HeaderText = "سعر البيع مع الضريبه";
            this.ItemPriceTax.Name = "ItemPriceTax";
            // 
            // WarehouseID
            // 
            this.WarehouseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WarehouseID.DataPropertyName = "Warehouse ID";
            this.WarehouseID.HeaderText = "رقم المستودع";
            this.WarehouseID.Name = "WarehouseID";
            this.WarehouseID.Visible = false;
            // 
            // Warehouse
            // 
            this.Warehouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Warehouse.DataPropertyName = "InventoryItemWarehouse";
            this.Warehouse.HeaderText = "المستودع";
            this.Warehouse.Name = "Warehouse";
            // 
            // ItemType
            // 
            this.ItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemType.DataPropertyName = "Item Type";
            this.ItemType.HeaderText = "رقم تصنيف الماده";
            this.ItemType.Name = "ItemType";
            this.ItemType.Visible = false;
            // 
            // ItemTypeName
            // 
            this.ItemTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemTypeName.DataPropertyName = "InventoryItemType";
            this.ItemTypeName.HeaderText = "تصنيف الماده";
            this.ItemTypeName.Name = "ItemTypeName";
            // 
            // FavoriteCategory
            // 
            this.FavoriteCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FavoriteCategory.DataPropertyName = "Favorite Category Number";
            this.FavoriteCategory.HeaderText = "رقم المجلد المفضل";
            this.FavoriteCategory.Name = "FavoriteCategory";
            this.FavoriteCategory.Visible = false;
            // 
            // FavoriteCategoryName
            // 
            this.FavoriteCategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FavoriteCategoryName.DataPropertyName = "Favorite Category";
            this.FavoriteCategoryName.HeaderText = "المجلد المفضل";
            this.FavoriteCategoryName.Name = "FavoriteCategoryName";
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemName.Location = new System.Drawing.Point(107, 448);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(40, 19);
            this.lblItemName.TabIndex = 9;
            this.lblItemName.Text = "اسم الماده";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.AnimateReadOnly = false;
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemName.Depth = 0;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtItemName.HideSelection = true;
            this.txtItemName.LeadingIcon = null;
            this.txtItemName.Location = new System.Drawing.Point(22, 468);
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
            this.txtItemName.Size = new System.Drawing.Size(252, 48);
            this.txtItemName.TabIndex = 10;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemName.TrailingIcon = null;
            this.txtItemName.UseSystemPasswordChar = false;
            this.txtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemName_KeyPress);
            // 
            // txtItemBarcode
            // 
            this.txtItemBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemBarcode.AnimateReadOnly = false;
            this.txtItemBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemBarcode.Depth = 0;
            this.txtItemBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtItemBarcode.HideSelection = true;
            this.txtItemBarcode.LeadingIcon = null;
            this.txtItemBarcode.Location = new System.Drawing.Point(278, 468);
            this.txtItemBarcode.MaxLength = 32767;
            this.txtItemBarcode.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemBarcode.Name = "txtItemBarcode";
            this.txtItemBarcode.PasswordChar = '\0';
            this.txtItemBarcode.PrefixSuffixText = null;
            this.txtItemBarcode.ReadOnly = false;
            this.txtItemBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemBarcode.SelectedText = "";
            this.txtItemBarcode.SelectionLength = 0;
            this.txtItemBarcode.SelectionStart = 0;
            this.txtItemBarcode.ShortcutsEnabled = true;
            this.txtItemBarcode.Size = new System.Drawing.Size(252, 48);
            this.txtItemBarcode.TabIndex = 12;
            this.txtItemBarcode.TabStop = false;
            this.txtItemBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemBarcode.TrailingIcon = null;
            this.txtItemBarcode.UseSystemPasswordChar = false;
            this.txtItemBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemBarcode_KeyPress);
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Depth = 0;
            this.lblItemBarcode.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemBarcode.Location = new System.Drawing.Point(363, 448);
            this.lblItemBarcode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(52, 19);
            this.lblItemBarcode.TabIndex = 11;
            this.lblItemBarcode.Text = "باركود الماده";
            this.lblItemBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemQuantity
            // 
            this.lblItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemQuantity.AutoSize = true;
            this.lblItemQuantity.Depth = 0;
            this.lblItemQuantity.Enabled = false;
            this.lblItemQuantity.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemQuantity.Location = new System.Drawing.Point(779, 450);
            this.lblItemQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemQuantity.Name = "lblItemQuantity";
            this.lblItemQuantity.Size = new System.Drawing.Size(41, 19);
            this.lblItemQuantity.TabIndex = 14;
            this.lblItemQuantity.Text = "عدد القطع";
            this.lblItemQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblItemQuantity.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(881, 478);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSearch.Size = new System.Drawing.Size(64, 36);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "البحث";
            this.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSearch.UseAccentColor = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClear.Depth = 0;
            this.btnClear.HighEmphasis = true;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(953, 478);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(64, 36);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrint.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.BtnPrint.Location = new System.Drawing.Point(1024, 478);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(63, 35);
            this.BtnPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnPrint.TabIndex = 26;
            this.BtnPrint.TabStop = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(1094, 477);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(64, 36);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "الخروج";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbItemType
            // 
            this.cbItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItemType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Location = new System.Drawing.Point(536, 492);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(184, 21);
            this.cbItemType.TabIndex = 28;
            this.cbItemType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbItemType_KeyPress);
            // 
            // lblItemType
            // 
            this.lblItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemType.AutoSize = true;
            this.lblItemType.Depth = 0;
            this.lblItemType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemType.Location = new System.Drawing.Point(594, 450);
            this.lblItemType.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(54, 19);
            this.lblItemType.TabIndex = 29;
            this.lblItemType.Text = "تصنيف الماده";
            this.lblItemType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudItemQuantity
            // 
            this.nudItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudItemQuantity.Enabled = false;
            this.nudItemQuantity.Location = new System.Drawing.Point(752, 493);
            this.nudItemQuantity.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.nudItemQuantity.Name = "nudItemQuantity";
            this.nudItemQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudItemQuantity.TabIndex = 30;
            this.nudItemQuantity.Visible = false;
            this.nudItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudItemQuantity_KeyPress);
            // 
            // frmItemLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 524);
            this.Controls.Add(this.nudItemQuantity);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblItemQuantity);
            this.Controls.Add(this.txtItemBarcode);
            this.Controls.Add(this.lblItemBarcode);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.DGVItemsLookup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemLookup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "البحث عن المواد";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmItemLookup_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmItemLookup_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemsLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DGVItemsLookup;
        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemName;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemBarcode;
        private MaterialSkin.Controls.MaterialLabel lblItemBarcode;
        private MaterialSkin.Controls.MaterialLabel lblItemQuantity;
        private MaterialSkin.Controls.MaterialButton btnSearch;
        private MaterialSkin.Controls.MaterialButton btnClear;
        public System.Windows.Forms.PictureBox BtnPrint;
        private MaterialSkin.Controls.MaterialButton btnClose;
        public System.Windows.Forms.ComboBox cbItemType;
        private MaterialSkin.Controls.MaterialLabel lblItemType;
        private System.Windows.Forms.NumericUpDown nudItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPriceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategoryName;
    }
}