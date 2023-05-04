namespace PlancksoftPOS
{
    partial class frmAddPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPrinter));
            this.cbItemTypes = new System.Windows.Forms.ComboBox();
            this.btnAddItemType = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.lblItemTypes = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // cbItemTypes
            // 
            this.cbItemTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbItemTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemTypes.FormattingEnabled = true;
            this.cbItemTypes.Location = new System.Drawing.Point(102, 67);
            this.cbItemTypes.MaxDropDownItems = 100;
            this.cbItemTypes.Name = "cbItemTypes";
            this.cbItemTypes.Size = new System.Drawing.Size(564, 21);
            this.cbItemTypes.TabIndex = 0;
            // 
            // btnAddItemType
            // 
            this.btnAddItemType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddItemType.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddItemType.Depth = 0;
            this.btnAddItemType.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddItemType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddItemType.HighEmphasis = true;
            this.btnAddItemType.Icon = null;
            this.btnAddItemType.Location = new System.Drawing.Point(3, 131);
            this.btnAddItemType.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddItemType.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddItemType.Name = "btnAddItemType";
            this.btnAddItemType.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddItemType.Size = new System.Drawing.Size(666, 36);
            this.btnAddItemType.TabIndex = 1;
            this.btnAddItemType.Text = "إضافة صتف";
            this.btnAddItemType.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddItemType.UseAccentColor = false;
            this.btnAddItemType.UseVisualStyleBackColor = true;
            this.btnAddItemType.Click += new System.EventHandler(this.btnAddItemType_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(3, 167);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(666, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblItemTypes
            // 
            this.lblItemTypes.AutoSize = true;
            this.lblItemTypes.Depth = 0;
            this.lblItemTypes.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblItemTypes.Location = new System.Drawing.Point(6, 71);
            this.lblItemTypes.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblItemTypes.Name = "lblItemTypes";
            this.lblItemTypes.Size = new System.Drawing.Size(55, 19);
            this.lblItemTypes.TabIndex = 26;
            this.lblItemTypes.Text = "أصناف المواد";
            // 
            // frmAddPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 206);
            this.Controls.Add(this.cbItemTypes);
            this.Controls.Add(this.btnAddItemType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblItemTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddPrinter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة صنف مواد لطابعة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddPrinter_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddPrinter_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbItemTypes;
        private MaterialSkin.Controls.MaterialButton btnAddItemType;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialLabel lblItemTypes;
    }
}