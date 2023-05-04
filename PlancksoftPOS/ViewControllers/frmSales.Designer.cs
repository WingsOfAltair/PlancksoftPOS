namespace PlancksoftPOS
{
    partial class frmSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchItemDGV = new System.Windows.Forms.DataGridView();
            this.lblItemName = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.lblDiscountEnd = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDiscountEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDiscountStart = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDiscountStart = new System.Windows.Forms.DateTimePicker();
            this.nudDiscountItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountedItemQuantity = new MaterialSkin.Controls.MaterialLabel();
            this.nudDiscountPercentage = new System.Windows.Forms.NumericUpDown();
            this.txtItemBarcode = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblDiscountPercentage = new MaterialSkin.Controls.MaterialLabel();
            this.lblItemBarcode = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnDiscountConfirm = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.searchItemDGV)).BeginInit();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountItemQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Item Price Tax";
            this.dataGridViewTextBoxColumn5.HeaderText = "سعر القطعه بعد الضريبه";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item Price";
            this.dataGridViewTextBoxColumn4.HeaderText = "سعر القطعه";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item Quantity";
            this.dataGridViewTextBoxColumn3.HeaderText = "عدد القطعه";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "بار كود";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "القطعه";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // WarehouseID
            // 
            this.WarehouseID.DataPropertyName = "Warehouse ID";
            this.WarehouseID.HeaderText = "Warehouse ID";
            this.WarehouseID.Name = "WarehouseID";
            this.WarehouseID.ReadOnly = true;
            this.WarehouseID.Visible = false;
            // 
            // FavoriteCategory
            // 
            this.FavoriteCategory.DataPropertyName = "Favorite Category Number";
            this.FavoriteCategory.HeaderText = "Favorite Category";
            this.FavoriteCategory.Name = "FavoriteCategory";
            this.FavoriteCategory.ReadOnly = true;
            this.FavoriteCategory.Visible = false;
            // 
            // ItemTypeName
            // 
            this.ItemTypeName.DataPropertyName = "InventoryItemType";
            this.ItemTypeName.HeaderText = "ItemTypeName";
            this.ItemTypeName.Name = "ItemTypeName";
            this.ItemTypeName.ReadOnly = true;
            this.ItemTypeName.Visible = false;
            // 
            // WarehouseName
            // 
            this.WarehouseName.DataPropertyName = "InventoryItemWarehouse";
            this.WarehouseName.HeaderText = "WarehouseName";
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.ReadOnly = true;
            this.WarehouseName.Visible = false;
            // 
            // FavoriteCategoryName
            // 
            this.FavoriteCategoryName.DataPropertyName = "Favorite Category";
            this.FavoriteCategoryName.HeaderText = "FavoriteCategoryName";
            this.FavoriteCategoryName.Name = "FavoriteCategoryName";
            this.FavoriteCategoryName.ReadOnly = true;
            this.FavoriteCategoryName.Visible = false;
            // 
            // ItemBuyPrice
            // 
            this.ItemBuyPrice.DataPropertyName = "Item Buy Price";
            this.ItemBuyPrice.HeaderText = "Item Buy Price";
            this.ItemBuyPrice.Name = "ItemBuyPrice";
            this.ItemBuyPrice.ReadOnly = true;
            this.ItemBuyPrice.Visible = false;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Item ID";
            this.dataGridViewTextBoxColumn41.HeaderText = "رقم القطعه";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "Item Type";
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            this.ItemType.Visible = false;
            // 
            // searchItemDGV
            // 
            this.searchItemDGV.BackgroundColor = System.Drawing.Color.White;
            this.searchItemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchItemDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn41,
            this.ItemBuyPrice,
            this.FavoriteCategoryName,
            this.WarehouseName,
            this.ItemTypeName,
            this.FavoriteCategory,
            this.WarehouseID,
            this.ItemType,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.searchItemDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchItemDGV.Location = new System.Drawing.Point(3, 64);
            this.searchItemDGV.Name = "searchItemDGV";
            this.searchItemDGV.ReadOnly = true;
            this.searchItemDGV.Size = new System.Drawing.Size(789, 397);
            this.searchItemDGV.TabIndex = 93;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemName.Location = new System.Drawing.Point(390, 14);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(45, 19);
            this.lblItemName.TabIndex = 103;
            this.lblItemName.Text = "إسم القطعه";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.lblDiscountEnd);
            this.materialCard1.Controls.Add(this.dtpDiscountEnd);
            this.materialCard1.Controls.Add(this.lblDiscountStart);
            this.materialCard1.Controls.Add(this.dtpDiscountStart);
            this.materialCard1.Controls.Add(this.nudDiscountItemQuantity);
            this.materialCard1.Controls.Add(this.lblDiscountedItemQuantity);
            this.materialCard1.Controls.Add(this.nudDiscountPercentage);
            this.materialCard1.Controls.Add(this.txtItemBarcode);
            this.materialCard1.Controls.Add(this.txtItemName);
            this.materialCard1.Controls.Add(this.lblDiscountPercentage);
            this.materialCard1.Controls.Add(this.lblItemBarcode);
            this.materialCard1.Controls.Add(this.lblItemName);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 461);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(789, 369);
            this.materialCard1.TabIndex = 104;
            // 
            // lblDiscountEnd
            // 
            this.lblDiscountEnd.AutoSize = true;
            this.lblDiscountEnd.Depth = 0;
            this.lblDiscountEnd.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountEnd.Location = new System.Drawing.Point(161, 219);
            this.lblDiscountEnd.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountEnd.Name = "lblDiscountEnd";
            this.lblDiscountEnd.Size = new System.Drawing.Size(78, 19);
            this.lblDiscountEnd.TabIndex = 114;
            this.lblDiscountEnd.Text = "تاريخ إنتهاء الخصم";
            this.lblDiscountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDiscountEnd
            // 
            this.dtpDiscountEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDiscountEnd.Location = new System.Drawing.Point(434, 241);
            this.dtpDiscountEnd.Name = "dtpDiscountEnd";
            this.dtpDiscountEnd.Size = new System.Drawing.Size(338, 20);
            this.dtpDiscountEnd.TabIndex = 113;
            // 
            // lblDiscountStart
            // 
            this.lblDiscountStart.AutoSize = true;
            this.lblDiscountStart.Depth = 0;
            this.lblDiscountStart.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountStart.Location = new System.Drawing.Point(589, 219);
            this.lblDiscountStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountStart.Name = "lblDiscountStart";
            this.lblDiscountStart.Size = new System.Drawing.Size(68, 19);
            this.lblDiscountStart.TabIndex = 112;
            this.lblDiscountStart.Text = "تاريخ بدء الخصم";
            this.lblDiscountStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDiscountStart
            // 
            this.dtpDiscountStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDiscountStart.Location = new System.Drawing.Point(17, 241);
            this.dtpDiscountStart.Name = "dtpDiscountStart";
            this.dtpDiscountStart.Size = new System.Drawing.Size(338, 20);
            this.dtpDiscountStart.TabIndex = 111;
            // 
            // nudDiscountItemQuantity
            // 
            this.nudDiscountItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiscountItemQuantity.Location = new System.Drawing.Point(17, 182);
            this.nudDiscountItemQuantity.Name = "nudDiscountItemQuantity";
            this.nudDiscountItemQuantity.Size = new System.Drawing.Size(338, 20);
            this.nudDiscountItemQuantity.TabIndex = 110;
            // 
            // lblDiscountedItemQuantity
            // 
            this.lblDiscountedItemQuantity.AutoSize = true;
            this.lblDiscountedItemQuantity.Depth = 0;
            this.lblDiscountedItemQuantity.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountedItemQuantity.Location = new System.Drawing.Point(161, 160);
            this.lblDiscountedItemQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountedItemQuantity.Name = "lblDiscountedItemQuantity";
            this.lblDiscountedItemQuantity.Size = new System.Drawing.Size(64, 19);
            this.lblDiscountedItemQuantity.TabIndex = 109;
            this.lblDiscountedItemQuantity.Text = "عدد قطع الخصم";
            this.lblDiscountedItemQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDiscountPercentage
            // 
            this.nudDiscountPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiscountPercentage.Location = new System.Drawing.Point(434, 182);
            this.nudDiscountPercentage.Name = "nudDiscountPercentage";
            this.nudDiscountPercentage.Size = new System.Drawing.Size(338, 20);
            this.nudDiscountPercentage.TabIndex = 108;
            this.nudDiscountPercentage.Enter += new System.EventHandler(this.nudDiscountPercentage_Enter);
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
            this.txtItemBarcode.Location = new System.Drawing.Point(17, 109);
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
            this.txtItemBarcode.Size = new System.Drawing.Size(755, 48);
            this.txtItemBarcode.TabIndex = 107;
            this.txtItemBarcode.TabStop = false;
            this.txtItemBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemBarcode.TrailingIcon = null;
            this.txtItemBarcode.UseSystemPasswordChar = false;
            this.txtItemBarcode.TextChanged += new System.EventHandler(this.txtItemBarcode_TextChanged);
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
            this.txtItemName.Location = new System.Drawing.Point(17, 36);
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
            this.txtItemName.Size = new System.Drawing.Size(755, 48);
            this.txtItemName.TabIndex = 106;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemName.TrailingIcon = null;
            this.txtItemName.UseSystemPasswordChar = false;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // lblDiscountPercentage
            // 
            this.lblDiscountPercentage.AutoSize = true;
            this.lblDiscountPercentage.Depth = 0;
            this.lblDiscountPercentage.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountPercentage.Location = new System.Drawing.Point(579, 160);
            this.lblDiscountPercentage.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountPercentage.Name = "lblDiscountPercentage";
            this.lblDiscountPercentage.Size = new System.Drawing.Size(98, 19);
            this.lblDiscountPercentage.TabIndex = 105;
            this.lblDiscountPercentage.Text = "نسبة الخصم بالمئه (رقم)";
            this.lblDiscountPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Depth = 0;
            this.lblItemBarcode.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemBarcode.Location = new System.Drawing.Point(390, 87);
            this.lblItemBarcode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(57, 19);
            this.lblItemBarcode.TabIndex = 104;
            this.lblItemBarcode.Text = "باركود القطعه";
            this.lblItemBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(3, 830);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(789, 36);
            this.btnClose.TabIndex = 115;
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
            this.btnClear.Location = new System.Drawing.Point(3, 794);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(789, 36);
            this.btnClear.TabIndex = 116;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDiscountConfirm
            // 
            this.btnDiscountConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDiscountConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDiscountConfirm.Depth = 0;
            this.btnDiscountConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDiscountConfirm.HighEmphasis = true;
            this.btnDiscountConfirm.Icon = null;
            this.btnDiscountConfirm.Location = new System.Drawing.Point(3, 758);
            this.btnDiscountConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDiscountConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDiscountConfirm.Name = "btnDiscountConfirm";
            this.btnDiscountConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDiscountConfirm.Size = new System.Drawing.Size(789, 36);
            this.btnDiscountConfirm.TabIndex = 117;
            this.btnDiscountConfirm.Text = "تأكيد الخصم";
            this.btnDiscountConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDiscountConfirm.UseAccentColor = false;
            this.btnDiscountConfirm.UseVisualStyleBackColor = true;
            this.btnDiscountConfirm.Click += new System.EventHandler(this.btnDiscountConfirm_Click);
            // 
            // frmSales
            // 
            this.ClientSize = new System.Drawing.Size(795, 869);
            this.Controls.Add(this.btnDiscountConfirm);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.searchItemDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الخصومات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSales_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSales_FormClosed);
            this.Load += new System.EventHandler(this.frmSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchItemDGV)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountItemQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        public System.Windows.Forms.DataGridView searchItemDGV;
        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel lblItemBarcode;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemName;
        private MaterialSkin.Controls.MaterialLabel lblDiscountPercentage;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemBarcode;
        private System.Windows.Forms.NumericUpDown nudDiscountPercentage;
        private System.Windows.Forms.NumericUpDown nudDiscountItemQuantity;
        private MaterialSkin.Controls.MaterialLabel lblDiscountedItemQuantity;
        private System.Windows.Forms.DateTimePicker dtpDiscountStart;
        private MaterialSkin.Controls.MaterialLabel lblDiscountStart;
        private MaterialSkin.Controls.MaterialLabel lblDiscountEnd;
        private System.Windows.Forms.DateTimePicker dtpDiscountEnd;
        private MaterialSkin.Controls.MaterialButton btnDiscountConfirm;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnClose;
    }
}