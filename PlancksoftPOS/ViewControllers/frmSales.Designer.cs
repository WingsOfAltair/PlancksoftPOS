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
            this.lblItemName = new MaterialSkin.Controls.MaterialLabel();
            this.txtItemBarcode = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblItemBarcode = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.txtItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.searchItemDGV = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleRate = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountPercentage = new MaterialSkin.Controls.MaterialLabel();
            this.lblDiscountedItemQuantity = new MaterialSkin.Controls.MaterialLabel();
            this.nudDiscountItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnDiscountConfirm = new MaterialSkin.Controls.MaterialButton();
            this.lblDiscountStart = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDiscountStart = new System.Windows.Forms.DateTimePicker();
            this.lblDiscountEnd = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDiscountEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.searchItemDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountItemQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemName.Location = new System.Drawing.Point(2, 468);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemName.Size = new System.Drawing.Size(72, 17);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "إسم القطعه";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemBarcode
            // 
            this.txtItemBarcode.AnimateReadOnly = false;
            this.txtItemBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemBarcode.Depth = 0;
            this.txtItemBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtItemBarcode.HideSelection = true;
            this.txtItemBarcode.LeadingIcon = null;
            this.txtItemBarcode.Location = new System.Drawing.Point(3, 560);
            this.txtItemBarcode.MaxLength = 32767;
            this.txtItemBarcode.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemBarcode.Name = "txtItemBarcode";
            this.txtItemBarcode.PasswordChar = '\0';
            this.txtItemBarcode.PrefixSuffixText = null;
            this.txtItemBarcode.ReadOnly = false;
            this.txtItemBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemBarcode.SelectedText = "";
            this.txtItemBarcode.SelectionLength = 0;
            this.txtItemBarcode.SelectionStart = 0;
            this.txtItemBarcode.ShortcutsEnabled = true;
            this.txtItemBarcode.Size = new System.Drawing.Size(756, 48);
            this.txtItemBarcode.TabIndex = 6;
            this.txtItemBarcode.TabStop = false;
            this.txtItemBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemBarcode.TrailingIcon = null;
            this.txtItemBarcode.UseSystemPasswordChar = false;
            this.txtItemBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemBarcode_KeyPress);
            this.txtItemBarcode.TextChanged += new System.EventHandler(this.txtItemBarcode_TextChanged);
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Depth = 0;
            this.lblItemBarcode.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemBarcode.Location = new System.Drawing.Point(0, 540);
            this.lblItemBarcode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemBarcode.Size = new System.Drawing.Size(79, 17);
            this.lblItemBarcode.TabIndex = 5;
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
            this.btnClose.Location = new System.Drawing.Point(3, 774);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(759, 36);
            this.btnClose.TabIndex = 73;
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
            this.btnClear.Location = new System.Drawing.Point(3, 738);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(759, 36);
            this.btnClear.TabIndex = 74;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.txtItemName.Location = new System.Drawing.Point(1, 488);
            this.txtItemName.MaxLength = 32767;
            this.txtItemName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.PasswordChar = '\0';
            this.txtItemName.PrefixSuffixText = null;
            this.txtItemName.ReadOnly = false;
            this.txtItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemName.SelectedText = "";
            this.txtItemName.SelectionLength = 0;
            this.txtItemName.SelectionStart = 0;
            this.txtItemName.ShortcutsEnabled = true;
            this.txtItemName.Size = new System.Drawing.Size(758, 48);
            this.txtItemName.TabIndex = 75;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemName.TrailingIcon = null;
            this.txtItemName.UseSystemPasswordChar = false;
            this.txtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemName_KeyPress);
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
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
            this.searchItemDGV.Location = new System.Drawing.Point(1, 67);
            this.searchItemDGV.Name = "searchItemDGV";
            this.searchItemDGV.ReadOnly = true;
            this.searchItemDGV.Size = new System.Drawing.Size(758, 397);
            this.searchItemDGV.TabIndex = 77;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Item ID";
            this.dataGridViewTextBoxColumn41.HeaderText = "رقم القطعه";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // ItemBuyPrice
            // 
            this.ItemBuyPrice.DataPropertyName = "Item Buy Price";
            this.ItemBuyPrice.HeaderText = "Item Buy Price";
            this.ItemBuyPrice.Name = "ItemBuyPrice";
            this.ItemBuyPrice.ReadOnly = true;
            this.ItemBuyPrice.Visible = false;
            // 
            // FavoriteCategoryName
            // 
            this.FavoriteCategoryName.DataPropertyName = "Favorite Category";
            this.FavoriteCategoryName.HeaderText = "FavoriteCategoryName";
            this.FavoriteCategoryName.Name = "FavoriteCategoryName";
            this.FavoriteCategoryName.ReadOnly = true;
            this.FavoriteCategoryName.Visible = false;
            // 
            // WarehouseName
            // 
            this.WarehouseName.DataPropertyName = "InventoryItemWarehouse";
            this.WarehouseName.HeaderText = "WarehouseName";
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.ReadOnly = true;
            this.WarehouseName.Visible = false;
            // 
            // ItemTypeName
            // 
            this.ItemTypeName.DataPropertyName = "InventoryItemType";
            this.ItemTypeName.HeaderText = "ItemTypeName";
            this.ItemTypeName.Name = "ItemTypeName";
            this.ItemTypeName.ReadOnly = true;
            this.ItemTypeName.Visible = false;
            // 
            // FavoriteCategory
            // 
            this.FavoriteCategory.DataPropertyName = "Favorite Category Number";
            this.FavoriteCategory.HeaderText = "Favorite Category";
            this.FavoriteCategory.Name = "FavoriteCategory";
            this.FavoriteCategory.ReadOnly = true;
            this.FavoriteCategory.Visible = false;
            // 
            // WarehouseID
            // 
            this.WarehouseID.DataPropertyName = "Warehouse ID";
            this.WarehouseID.HeaderText = "Warehouse ID";
            this.WarehouseID.Name = "WarehouseID";
            this.WarehouseID.ReadOnly = true;
            this.WarehouseID.Visible = false;
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "Item Type";
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            this.ItemType.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "القطعه";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "بار كود";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item Quantity";
            this.dataGridViewTextBoxColumn3.HeaderText = "عدد القطعه";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item Price";
            this.dataGridViewTextBoxColumn4.HeaderText = "سعر القطعه";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Item Price Tax";
            this.dataGridViewTextBoxColumn5.HeaderText = "سعر القطعه بعد الضريبه";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // saleRate
            // 
            this.saleRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.saleRate.Location = new System.Drawing.Point(9, 631);
            this.saleRate.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.saleRate.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.saleRate.Name = "saleRate";
            this.saleRate.Size = new System.Drawing.Size(148, 20);
            this.saleRate.TabIndex = 78;
            this.saleRate.Enter += new System.EventHandler(this.saleRate_Enter);
            this.saleRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saleRate_KeyPress);
            // 
            // lblDiscountPercentage
            // 
            this.lblDiscountPercentage.AutoSize = true;
            this.lblDiscountPercentage.Depth = 0;
            this.lblDiscountPercentage.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountPercentage.Location = new System.Drawing.Point(6, 611);
            this.lblDiscountPercentage.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountPercentage.Name = "lblDiscountPercentage";
            this.lblDiscountPercentage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscountPercentage.Size = new System.Drawing.Size(151, 17);
            this.lblDiscountPercentage.TabIndex = 79;
            this.lblDiscountPercentage.Text = "نسبة الخصم بالمئه (رقم)";
            this.lblDiscountPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiscountedItemQuantity
            // 
            this.lblDiscountedItemQuantity.AutoSize = true;
            this.lblDiscountedItemQuantity.Depth = 0;
            this.lblDiscountedItemQuantity.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountedItemQuantity.Location = new System.Drawing.Point(6, 656);
            this.lblDiscountedItemQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountedItemQuantity.Name = "lblDiscountedItemQuantity";
            this.lblDiscountedItemQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscountedItemQuantity.Size = new System.Drawing.Size(100, 17);
            this.lblDiscountedItemQuantity.TabIndex = 81;
            this.lblDiscountedItemQuantity.Text = "عدد قطع الخصم";
            this.lblDiscountedItemQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDiscountItemQuantity
            // 
            this.nudDiscountItemQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDiscountItemQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudDiscountItemQuantity.Location = new System.Drawing.Point(9, 676);
            this.nudDiscountItemQuantity.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nudDiscountItemQuantity.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.nudDiscountItemQuantity.Name = "nudDiscountItemQuantity";
            this.nudDiscountItemQuantity.Size = new System.Drawing.Size(148, 20);
            this.nudDiscountItemQuantity.TabIndex = 80;
            // 
            // btnDiscountConfirm
            // 
            this.btnDiscountConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDiscountConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDiscountConfirm.Depth = 0;
            this.btnDiscountConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDiscountConfirm.HighEmphasis = true;
            this.btnDiscountConfirm.Icon = null;
            this.btnDiscountConfirm.Location = new System.Drawing.Point(3, 702);
            this.btnDiscountConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDiscountConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDiscountConfirm.Name = "btnDiscountConfirm";
            this.btnDiscountConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDiscountConfirm.Size = new System.Drawing.Size(759, 36);
            this.btnDiscountConfirm.TabIndex = 82;
            this.btnDiscountConfirm.Text = "تأكيد الخصم";
            this.btnDiscountConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDiscountConfirm.UseAccentColor = false;
            this.btnDiscountConfirm.UseVisualStyleBackColor = true;
            this.btnDiscountConfirm.Click += new System.EventHandler(this.btnDiscountConfirm_Click);
            // 
            // lblDiscountStart
            // 
            this.lblDiscountStart.AutoSize = true;
            this.lblDiscountStart.Depth = 0;
            this.lblDiscountStart.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountStart.Location = new System.Drawing.Point(213, 611);
            this.lblDiscountStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountStart.Name = "lblDiscountStart";
            this.lblDiscountStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscountStart.Size = new System.Drawing.Size(101, 17);
            this.lblDiscountStart.TabIndex = 83;
            this.lblDiscountStart.Text = "تاريخ بدء الخصم";
            this.lblDiscountStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDiscountStart
            // 
            this.dtpDiscountStart.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpDiscountStart.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpDiscountStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDiscountStart.Location = new System.Drawing.Point(163, 631);
            this.dtpDiscountStart.Name = "dtpDiscountStart";
            this.dtpDiscountStart.Size = new System.Drawing.Size(250, 20);
            this.dtpDiscountStart.TabIndex = 84;
            // 
            // lblDiscountEnd
            // 
            this.lblDiscountEnd.AutoSize = true;
            this.lblDiscountEnd.Depth = 0;
            this.lblDiscountEnd.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountEnd.Location = new System.Drawing.Point(490, 611);
            this.lblDiscountEnd.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountEnd.Name = "lblDiscountEnd";
            this.lblDiscountEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscountEnd.Size = new System.Drawing.Size(115, 17);
            this.lblDiscountEnd.TabIndex = 85;
            this.lblDiscountEnd.Text = "تاريخ إنتهاء الخصم";
            this.lblDiscountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDiscountEnd
            // 
            this.dtpDiscountEnd.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpDiscountEnd.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpDiscountEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDiscountEnd.Location = new System.Drawing.Point(437, 631);
            this.dtpDiscountEnd.Name = "dtpDiscountEnd";
            this.dtpDiscountEnd.Size = new System.Drawing.Size(250, 20);
            this.dtpDiscountEnd.TabIndex = 86;
            // 
            // frmSales
            // 
            this.ClientSize = new System.Drawing.Size(765, 813);
            this.Controls.Add(this.dtpDiscountEnd);
            this.Controls.Add(this.lblDiscountEnd);
            this.Controls.Add(this.dtpDiscountStart);
            this.Controls.Add(this.lblDiscountStart);
            this.Controls.Add(this.btnDiscountConfirm);
            this.Controls.Add(this.lblDiscountedItemQuantity);
            this.Controls.Add(this.nudDiscountItemQuantity);
            this.Controls.Add(this.lblDiscountPercentage);
            this.Controls.Add(this.saleRate);
            this.Controls.Add(this.searchItemDGV);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtItemBarcode);
            this.Controls.Add(this.lblItemBarcode);
            this.Controls.Add(this.lblItemName);
            this.Name = "frmSales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSales_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.searchItemDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountItemQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemBarcode;
        private MaterialSkin.Controls.MaterialLabel lblItemBarcode;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemName;
        public System.Windows.Forms.DataGridView searchItemDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        public System.Windows.Forms.NumericUpDown saleRate;
        private MaterialSkin.Controls.MaterialLabel lblDiscountPercentage;
        private MaterialSkin.Controls.MaterialLabel lblDiscountedItemQuantity;
        public System.Windows.Forms.NumericUpDown nudDiscountItemQuantity;
        private MaterialSkin.Controls.MaterialButton btnDiscountConfirm;
        private MaterialSkin.Controls.MaterialLabel lblDiscountStart;
        public System.Windows.Forms.DateTimePicker dtpDiscountStart;
        private MaterialSkin.Controls.MaterialLabel lblDiscountEnd;
        public System.Windows.Forms.DateTimePicker dtpDiscountEnd;
    }
}