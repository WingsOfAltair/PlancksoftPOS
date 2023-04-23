namespace PlancksoftPOS
{
    partial class frmLicense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLicenseKey = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnActivate = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.AnimateReadOnly = false;
            this.txtLicenseKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLicenseKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLicenseKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtLicenseKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLicenseKey.Depth = 0;
            this.txtLicenseKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLicenseKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLicenseKey.HideSelection = true;
            this.txtLicenseKey.LeadingIcon = global::PlancksoftPOS.Properties.Resources.password;
            this.txtLicenseKey.Location = new System.Drawing.Point(3, 64);
            this.txtLicenseKey.MaxLength = 32767;
            this.txtLicenseKey.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.PasswordChar = '●';
            this.txtLicenseKey.PrefixSuffixText = null;
            this.txtLicenseKey.ReadOnly = false;
            this.txtLicenseKey.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLicenseKey.SelectedText = "";
            this.txtLicenseKey.SelectionLength = 0;
            this.txtLicenseKey.SelectionStart = 0;
            this.txtLicenseKey.ShortcutsEnabled = true;
            this.txtLicenseKey.Size = new System.Drawing.Size(689, 48);
            this.txtLicenseKey.TabIndex = 49;
            this.txtLicenseKey.TabStop = false;
            this.txtLicenseKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLicenseKey.TrailingIcon = null;
            this.txtLicenseKey.UseSystemPasswordChar = true;
            this.txtLicenseKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseKey_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(3, 199);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(689, 36);
            this.btnClose.TabIndex = 50;
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
            this.btnClear.Location = new System.Drawing.Point(3, 163);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(689, 36);
            this.btnClear.TabIndex = 51;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActivate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActivate.Depth = 0;
            this.btnActivate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnActivate.HighEmphasis = true;
            this.btnActivate.Icon = null;
            this.btnActivate.Location = new System.Drawing.Point(3, 127);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActivate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActivate.Size = new System.Drawing.Size(689, 36);
            this.btnActivate.TabIndex = 52;
            this.btnActivate.Text = "التفعيل";
            this.btnActivate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActivate.UseAccentColor = false;
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // frmLicense
            // 
            this.ClientSize = new System.Drawing.Size(695, 238);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtLicenseKey);
            this.Name = "frmLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MaterialSkin.Controls.MaterialTextBox2 txtLicenseKey;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnActivate;
    }
}