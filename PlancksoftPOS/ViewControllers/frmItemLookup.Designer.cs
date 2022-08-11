namespace PlancksoftPOS
{
    partial class frmItemLookup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemLookup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnPrint = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVItemsLookup = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ItemBarCodetxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemNametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemsLookup)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnPrint);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DGVItemsLookup);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ItemBarCodetxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ItemNametxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnPrint
            // 
            this.BtnPrint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrint.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.BtnPrint.Location = new System.Drawing.Point(242, 394);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(97, 47);
            this.BtnPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnPrint.TabIndex = 25;
            this.BtnPrint.TabStop = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.numericUpDown1.Location = new System.Drawing.Point(436, 417);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(115, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label4.Location = new System.Drawing.Point(493, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "عدد القطع";
            this.label4.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(557, 417);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label3.Location = new System.Drawing.Point(666, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "تصنيف الماده";
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
            this.DGVItemsLookup.Location = new System.Drawing.Point(133, 9);
            this.DGVItemsLookup.Name = "DGVItemsLookup";
            this.DGVItemsLookup.Size = new System.Drawing.Size(1077, 372);
            this.DGVItemsLookup.TabIndex = 7;
            this.DGVItemsLookup.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVItemsLookup_RowHeaderMouseClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(133, 394);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "الخروج";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(345, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 48);
            this.button2.TabIndex = 5;
            this.button2.Text = "مسح";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(451, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "البحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItemBarCodetxt
            // 
            this.ItemBarCodetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBarCodetxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemBarCodetxt.Location = new System.Drawing.Point(747, 418);
            this.ItemBarCodetxt.Name = "ItemBarCodetxt";
            this.ItemBarCodetxt.Size = new System.Drawing.Size(226, 20);
            this.ItemBarCodetxt.TabIndex = 1;
            this.ItemBarCodetxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemBarCodetxt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label2.Location = new System.Drawing.Point(896, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "باركود الماده";
            // 
            // ItemNametxt
            // 
            this.ItemNametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNametxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemNametxt.Location = new System.Drawing.Point(979, 418);
            this.ItemNametxt.Name = "ItemNametxt";
            this.ItemNametxt.Size = new System.Drawing.Size(226, 20);
            this.ItemNametxt.TabIndex = 0;
            this.ItemNametxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemNametxt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(1142, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم الماده";
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "Item ID";
            this.ItemID.HeaderText = "رقم القطعه";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Item Name";
            this.ItemName.HeaderText = "اسم القطعه";
            this.ItemName.Name = "ItemName";
            // 
            // ItemBarCode
            // 
            this.ItemBarCode.DataPropertyName = "Item BarCode";
            this.ItemBarCode.HeaderText = "باركود القطعه";
            this.ItemBarCode.Name = "ItemBarCode";
            // 
            // ItemQuantity
            // 
            this.ItemQuantity.DataPropertyName = "Item Quantity";
            this.ItemQuantity.HeaderText = "عدد القطعه";
            this.ItemQuantity.Name = "ItemQuantity";
            // 
            // ItemBuyPrice
            // 
            this.ItemBuyPrice.DataPropertyName = "Item Buy Price";
            this.ItemBuyPrice.HeaderText = "سعر الشراء";
            this.ItemBuyPrice.Name = "ItemBuyPrice";
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "Item Price";
            this.ItemPrice.HeaderText = "سعر البيع";
            this.ItemPrice.Name = "ItemPrice";
            // 
            // ItemPriceTax
            // 
            this.ItemPriceTax.DataPropertyName = "Item Price Tax";
            this.ItemPriceTax.HeaderText = "سعر البيع مع الضريبه";
            this.ItemPriceTax.Name = "ItemPriceTax";
            // 
            // WarehouseID
            // 
            this.WarehouseID.DataPropertyName = "Warehouse ID";
            this.WarehouseID.HeaderText = "رقم المستودع";
            this.WarehouseID.Name = "WarehouseID";
            this.WarehouseID.Visible = false;
            // 
            // Warehouse
            // 
            this.Warehouse.DataPropertyName = "InventoryItemWarehouse";
            this.Warehouse.HeaderText = "المستودع";
            this.Warehouse.Name = "Warehouse";
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "Item Type";
            this.ItemType.HeaderText = "رقم تصنيف الماده";
            this.ItemType.Name = "ItemType";
            this.ItemType.Visible = false;
            // 
            // ItemTypeName
            // 
            this.ItemTypeName.DataPropertyName = "InventoryItemType";
            this.ItemTypeName.HeaderText = "تصنيف الماده";
            this.ItemTypeName.Name = "ItemTypeName";
            // 
            // FavoriteCategory
            // 
            this.FavoriteCategory.DataPropertyName = "Favorite Category Number";
            this.FavoriteCategory.HeaderText = "رقم المجلد المفضل";
            this.FavoriteCategory.Name = "FavoriteCategory";
            this.FavoriteCategory.Visible = false;
            // 
            // FavoriteCategoryName
            // 
            this.FavoriteCategoryName.DataPropertyName = "Favorite Category";
            this.FavoriteCategoryName.HeaderText = "المجلد المفضل";
            this.FavoriteCategoryName.Name = "FavoriteCategoryName";
            // 
            // frmItemLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1079, 450);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemLookup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "البحث عن المواد";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemsLookup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox ItemBarCodetxt;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox ItemNametxt;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView DGVItemsLookup;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.PictureBox BtnPrint;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.Label label4;
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