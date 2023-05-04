namespace PlancksoftPOS
{
    partial class frmRegisterAdmin
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
            this.lblUID = new MaterialSkin.Controls.MaterialLabel();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtAdminName = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblAdminName = new MaterialSkin.Controls.MaterialLabel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.txtUID = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblPassword = new MaterialSkin.Controls.MaterialLabel();
            this.btnRegisterAdmin = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Depth = 0;
            this.lblUID.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUID.Location = new System.Drawing.Point(4, 73);
            this.lblUID.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUID.Name = "lblUID";
            this.lblUID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUID.Size = new System.Drawing.Size(91, 19);
            this.lblUID.TabIndex = 2;
            this.lblUID.Text = "رمز المستخدم الإداري";
            this.lblUID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.HideSelection = true;
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(3, 164);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PrefixSuffixText = null;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(360, 48);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TabStop = false;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.TrailingIcon = null;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtAdminName
            // 
            this.txtAdminName.AnimateReadOnly = false;
            this.txtAdminName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtAdminName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtAdminName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAdminName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdminName.Depth = 0;
            this.txtAdminName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdminName.HideSelection = true;
            this.txtAdminName.LeadingIcon = null;
            this.txtAdminName.Location = new System.Drawing.Point(3, 235);
            this.txtAdminName.MaxLength = 32767;
            this.txtAdminName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.PasswordChar = '\0';
            this.txtAdminName.PrefixSuffixText = null;
            this.txtAdminName.ReadOnly = false;
            this.txtAdminName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAdminName.SelectedText = "";
            this.txtAdminName.SelectionLength = 0;
            this.txtAdminName.SelectionStart = 0;
            this.txtAdminName.ShortcutsEnabled = true;
            this.txtAdminName.Size = new System.Drawing.Size(360, 48);
            this.txtAdminName.TabIndex = 6;
            this.txtAdminName.TabStop = false;
            this.txtAdminName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAdminName.TrailingIcon = null;
            this.txtAdminName.UseSystemPasswordChar = false;
            this.txtAdminName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdminName_KeyPress);
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Depth = 0;
            this.lblAdminName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdminName.Location = new System.Drawing.Point(4, 215);
            this.lblAdminName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAdminName.Size = new System.Drawing.Size(137, 19);
            this.lblAdminName.TabIndex = 5;
            this.lblAdminName.Text = "اسم المستخدم (رئيس قسم الصيانه)";
            this.lblAdminName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(3, 364);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(363, 36);
            this.btnClose.TabIndex = 73;
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
            this.btnClear.Location = new System.Drawing.Point(3, 328);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(363, 36);
            this.btnClear.TabIndex = 74;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtUID
            // 
            this.txtUID.AnimateReadOnly = false;
            this.txtUID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUID.Depth = 0;
            this.txtUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUID.HideSelection = true;
            this.txtUID.LeadingIcon = null;
            this.txtUID.Location = new System.Drawing.Point(3, 93);
            this.txtUID.MaxLength = 32767;
            this.txtUID.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUID.Name = "txtUID";
            this.txtUID.PasswordChar = '\0';
            this.txtUID.PrefixSuffixText = null;
            this.txtUID.ReadOnly = false;
            this.txtUID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUID.SelectedText = "";
            this.txtUID.SelectionLength = 0;
            this.txtUID.SelectionStart = 0;
            this.txtUID.ShortcutsEnabled = true;
            this.txtUID.Size = new System.Drawing.Size(360, 48);
            this.txtUID.TabIndex = 75;
            this.txtUID.TabStop = false;
            this.txtUID.Text = "admin";
            this.txtUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUID.TrailingIcon = null;
            this.txtUID.UseSystemPasswordChar = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Depth = 0;
            this.lblPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPassword.Location = new System.Drawing.Point(4, 144);
            this.lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPassword.Size = new System.Drawing.Size(55, 19);
            this.lblPassword.TabIndex = 76;
            this.lblPassword.Text = "الكلمه السريه";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegisterAdmin
            // 
            this.btnRegisterAdmin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegisterAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegisterAdmin.Depth = 0;
            this.btnRegisterAdmin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegisterAdmin.HighEmphasis = true;
            this.btnRegisterAdmin.Icon = null;
            this.btnRegisterAdmin.Location = new System.Drawing.Point(3, 292);
            this.btnRegisterAdmin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRegisterAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegisterAdmin.Name = "btnRegisterAdmin";
            this.btnRegisterAdmin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegisterAdmin.Size = new System.Drawing.Size(363, 36);
            this.btnRegisterAdmin.TabIndex = 78;
            this.btnRegisterAdmin.Text = "التسجيل";
            this.btnRegisterAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegisterAdmin.UseAccentColor = false;
            this.btnRegisterAdmin.UseVisualStyleBackColor = true;
            this.btnRegisterAdmin.Click += new System.EventHandler(this.btnRegisterAdmin_Click);
            // 
            // frmRegisterAdmin
            // 
            this.ClientSize = new System.Drawing.Size(369, 403);
            this.Controls.Add(this.btnRegisterAdmin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtAdminName);
            this.Controls.Add(this.lblAdminName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUID);
            this.Name = "frmRegisterAdmin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegisterAdmin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lblUID;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private MaterialSkin.Controls.MaterialTextBox2 txtAdminName;
        private MaterialSkin.Controls.MaterialLabel lblAdminName;
        private MaterialSkin.Controls.MaterialButton btnClose;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialTextBox2 txtUID;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialButton btnRegisterAdmin;
    }
}