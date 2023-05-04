namespace PlancksoftPOS
{
    partial class frmItemRefund
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemRefund));
            this.lblItemName = new MaterialSkin.Controls.MaterialLabel();
            this.txtItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtItemBarcode = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblItemBarcode = new MaterialSkin.Controls.MaterialLabel();
            this.lblItemQuantity = new MaterialSkin.Controls.MaterialLabel();
            this.ItemQuantitynud = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnItemReturn = new MaterialSkin.Controls.MaterialButton();
            this.btnItemSelect = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantitynud)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Depth = 0;
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemName.Location = new System.Drawing.Point(3, 64);
            this.lblItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(40, 19);
            this.lblItemName.TabIndex = 26;
            this.lblItemName.Text = "إسم الماده";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemName
            // 
            this.txtItemName.AnimateReadOnly = false;
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemName.Depth = 0;
            this.txtItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtItemName.HideSelection = true;
            this.txtItemName.LeadingIcon = null;
            this.txtItemName.Location = new System.Drawing.Point(3, 83);
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
            this.txtItemName.Size = new System.Drawing.Size(497, 48);
            this.txtItemName.TabIndex = 27;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemName.TrailingIcon = null;
            this.txtItemName.UseSystemPasswordChar = false;
            // 
            // txtItemBarcode
            // 
            this.txtItemBarcode.AnimateReadOnly = false;
            this.txtItemBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemBarcode.Depth = 0;
            this.txtItemBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtItemBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtItemBarcode.HideSelection = true;
            this.txtItemBarcode.LeadingIcon = null;
            this.txtItemBarcode.Location = new System.Drawing.Point(3, 150);
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
            this.txtItemBarcode.Size = new System.Drawing.Size(497, 48);
            this.txtItemBarcode.TabIndex = 29;
            this.txtItemBarcode.TabStop = false;
            this.txtItemBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemBarcode.TrailingIcon = null;
            this.txtItemBarcode.UseSystemPasswordChar = false;
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Depth = 0;
            this.lblItemBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemBarcode.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemBarcode.Location = new System.Drawing.Point(3, 131);
            this.lblItemBarcode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(52, 19);
            this.lblItemBarcode.TabIndex = 28;
            this.lblItemBarcode.Text = "باركود الماده";
            this.lblItemBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemQuantity
            // 
            this.lblItemQuantity.AutoSize = true;
            this.lblItemQuantity.Depth = 0;
            this.lblItemQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemQuantity.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemQuantity.Location = new System.Drawing.Point(3, 198);
            this.lblItemQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemQuantity.Name = "lblItemQuantity";
            this.lblItemQuantity.Size = new System.Drawing.Size(41, 19);
            this.lblItemQuantity.TabIndex = 30;
            this.lblItemQuantity.Text = "عدد القطع";
            this.lblItemQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemQuantitynud
            // 
            this.ItemQuantitynud.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemQuantitynud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemQuantitynud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemQuantitynud.Location = new System.Drawing.Point(3, 217);
            this.ItemQuantitynud.Name = "ItemQuantitynud";
            this.ItemQuantitynud.Size = new System.Drawing.Size(497, 20);
            this.ItemQuantitynud.TabIndex = 31;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(3, 363);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(497, 36);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnItemReturn
            // 
            this.btnItemReturn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItemReturn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnItemReturn.Depth = 0;
            this.btnItemReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnItemReturn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnItemReturn.HighEmphasis = true;
            this.btnItemReturn.Icon = null;
            this.btnItemReturn.Location = new System.Drawing.Point(3, 327);
            this.btnItemReturn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnItemReturn.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItemReturn.Name = "btnItemReturn";
            this.btnItemReturn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnItemReturn.Size = new System.Drawing.Size(497, 36);
            this.btnItemReturn.TabIndex = 33;
            this.btnItemReturn.Text = "إرجاع الماده";
            this.btnItemReturn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnItemReturn.UseAccentColor = false;
            this.btnItemReturn.UseVisualStyleBackColor = true;
            this.btnItemReturn.Click += new System.EventHandler(this.btnItemReturn_Click);
            // 
            // btnItemSelect
            // 
            this.btnItemSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItemSelect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnItemSelect.Depth = 0;
            this.btnItemSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnItemSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnItemSelect.HighEmphasis = true;
            this.btnItemSelect.Icon = null;
            this.btnItemSelect.Location = new System.Drawing.Point(3, 291);
            this.btnItemSelect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnItemSelect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItemSelect.Name = "btnItemSelect";
            this.btnItemSelect.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnItemSelect.Size = new System.Drawing.Size(497, 36);
            this.btnItemSelect.TabIndex = 34;
            this.btnItemSelect.Text = "إختيار الماده";
            this.btnItemSelect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnItemSelect.UseAccentColor = false;
            this.btnItemSelect.UseVisualStyleBackColor = true;
            this.btnItemSelect.Click += new System.EventHandler(this.btnItemSelect_Click);
            // 
            // frmItemRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 402);
            this.Controls.Add(this.btnItemSelect);
            this.Controls.Add(this.btnItemReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ItemQuantitynud);
            this.Controls.Add(this.lblItemQuantity);
            this.Controls.Add(this.txtItemBarcode);
            this.Controls.Add(this.lblItemBarcode);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemRefund";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إرجاع المواد";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmItemRefund_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmItemRefund_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantitynud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblItemName;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemName;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemBarcode;
        private MaterialSkin.Controls.MaterialLabel lblItemBarcode;
        private MaterialSkin.Controls.MaterialLabel lblItemQuantity;
        public System.Windows.Forms.NumericUpDown ItemQuantitynud;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnItemReturn;
        private MaterialSkin.Controls.MaterialButton btnItemSelect;
    }
}