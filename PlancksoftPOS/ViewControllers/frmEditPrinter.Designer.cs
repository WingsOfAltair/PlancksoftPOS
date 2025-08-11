namespace PlancksoftPOS
{
    partial class frmEditPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPrinter));
            this.lblPrinterName = new MaterialSkin.Controls.MaterialLabel();
            this.txtPrinterName = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnEditPrinter = new MaterialSkin.Controls.MaterialButton();
            this.txtMachineName = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblMachineName = new MaterialSkin.Controls.MaterialLabel();
            this.cbIsMainPrinter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Depth = 0;
            this.lblPrinterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrinterName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPrinterName.Location = new System.Drawing.Point(3, 64);
            this.lblPrinterName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(47, 19);
            this.lblPrinterName.TabIndex = 26;
            this.lblPrinterName.Text = "إسم الطابعه";
            this.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.AnimateReadOnly = false;
            this.txtPrinterName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPrinterName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPrinterName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPrinterName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPrinterName.Depth = 0;
            this.txtPrinterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrinterName.HideSelection = true;
            this.txtPrinterName.LeadingIcon = null;
            this.txtPrinterName.Location = new System.Drawing.Point(3, 83);
            this.txtPrinterName.MaxLength = 32767;
            this.txtPrinterName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.PasswordChar = '\0';
            this.txtPrinterName.PrefixSuffixText = null;
            this.txtPrinterName.ReadOnly = false;
            this.txtPrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrinterName.SelectedText = "";
            this.txtPrinterName.SelectionLength = 0;
            this.txtPrinterName.SelectionStart = 0;
            this.txtPrinterName.ShortcutsEnabled = true;
            this.txtPrinterName.Size = new System.Drawing.Size(572, 48);
            this.txtPrinterName.TabIndex = 41;
            this.txtPrinterName.TabStop = false;
            this.txtPrinterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrinterName.TrailingIcon = null;
            this.txtPrinterName.UseSystemPasswordChar = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(373, 286);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(64, 36);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "إغلاق";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEditPrinter
            // 
            this.btnEditPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPrinter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditPrinter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditPrinter.Depth = 0;
            this.btnEditPrinter.HighEmphasis = true;
            this.btnEditPrinter.Icon = null;
            this.btnEditPrinter.Location = new System.Drawing.Point(114, 286);
            this.btnEditPrinter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditPrinter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditPrinter.Name = "btnEditPrinter";
            this.btnEditPrinter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditPrinter.Size = new System.Drawing.Size(90, 36);
            this.btnEditPrinter.TabIndex = 53;
            this.btnEditPrinter.Text = "تعديل الطابعه";
            this.btnEditPrinter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditPrinter.UseAccentColor = false;
            this.btnEditPrinter.UseVisualStyleBackColor = true;
            this.btnEditPrinter.Click += new System.EventHandler(this.btnEditPrinter_Click);
            // 
            // txtMachineName
            // 
            this.txtMachineName.AnimateReadOnly = false;
            this.txtMachineName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtMachineName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtMachineName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMachineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMachineName.Depth = 0;
            this.txtMachineName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMachineName.HideSelection = true;
            this.txtMachineName.LeadingIcon = null;
            this.txtMachineName.Location = new System.Drawing.Point(3, 150);
            this.txtMachineName.MaxLength = 32767;
            this.txtMachineName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.PasswordChar = '\0';
            this.txtMachineName.PrefixSuffixText = null;
            this.txtMachineName.ReadOnly = false;
            this.txtMachineName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMachineName.SelectedText = "";
            this.txtMachineName.SelectionLength = 0;
            this.txtMachineName.SelectionStart = 0;
            this.txtMachineName.ShortcutsEnabled = true;
            this.txtMachineName.Size = new System.Drawing.Size(572, 48);
            this.txtMachineName.TabIndex = 55;
            this.txtMachineName.TabStop = false;
            this.txtMachineName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMachineName.TrailingIcon = null;
            this.txtMachineName.UseSystemPasswordChar = false;
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Depth = 0;
            this.lblMachineName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMachineName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMachineName.Location = new System.Drawing.Point(3, 131);
            this.lblMachineName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(45, 19);
            this.lblMachineName.TabIndex = 54;
            this.lblMachineName.Text = "إسم الجهاز";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbIsMainPrinter
            // 
            this.cbIsMainPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIsMainPrinter.AutoSize = true;
            this.cbIsMainPrinter.Location = new System.Drawing.Point(114, 220);
            this.cbIsMainPrinter.Name = "cbIsMainPrinter";
            this.cbIsMainPrinter.Size = new System.Drawing.Size(93, 17);
            this.cbIsMainPrinter.TabIndex = 56;
            this.cbIsMainPrinter.Text = "طابعه رئيسيه؟";
            this.cbIsMainPrinter.UseVisualStyleBackColor = true;
            // 
            // frmEditPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 331);
            this.Controls.Add(this.cbIsMainPrinter);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.btnEditPrinter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPrinterName);
            this.Controls.Add(this.lblPrinterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPrinter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعديل طابعه";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditPrice_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblPrinterName;
        private MaterialSkin.Controls.MaterialTextBox2 txtPrinterName;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnEditPrinter;
        private MaterialSkin.Controls.MaterialTextBox2 txtMachineName;
        private MaterialSkin.Controls.MaterialLabel lblMachineName;
        private System.Windows.Forms.CheckBox cbIsMainPrinter;
    }
}