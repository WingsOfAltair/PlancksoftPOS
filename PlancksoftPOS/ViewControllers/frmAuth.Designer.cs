namespace PlancksoftPOS
{
    partial class frmAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuth));
            this.btnSubmit = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtAccountPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSubmit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSubmit.Depth = 0;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmit.HighEmphasis = true;
            this.btnSubmit.Icon = null;
            this.btnSubmit.Location = new System.Drawing.Point(3, 158);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSubmit.Size = new System.Drawing.Size(867, 36);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "إتمام";
            this.btnSubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSubmit.UseAccentColor = false;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(3, 194);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(867, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "إغلاق";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountPassword.AnimateReadOnly = false;
            this.txtAccountPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtAccountPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtAccountPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAccountPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAccountPassword.Depth = 0;
            this.txtAccountPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAccountPassword.HideSelection = true;
            this.txtAccountPassword.Hint = "****";
            this.txtAccountPassword.LeadingIcon = global::PlancksoftPOS.Properties.Resources.password;
            this.txtAccountPassword.Location = new System.Drawing.Point(6, 67);
            this.txtAccountPassword.MaxLength = 32767;
            this.txtAccountPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.PasswordChar = '●';
            this.txtAccountPassword.PrefixSuffixText = null;
            this.txtAccountPassword.ReadOnly = false;
            this.txtAccountPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountPassword.SelectedText = "";
            this.txtAccountPassword.SelectionLength = 0;
            this.txtAccountPassword.SelectionStart = 0;
            this.txtAccountPassword.ShortcutsEnabled = true;
            this.txtAccountPassword.Size = new System.Drawing.Size(861, 48);
            this.txtAccountPassword.TabIndex = 0;
            this.txtAccountPassword.TabStop = false;
            this.txtAccountPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccountPassword.TrailingIcon = null;
            this.txtAccountPassword.UseSystemPasswordChar = true;
            this.txtAccountPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountPassword_KeyPress);
            // 
            // frmAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 233);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtAccountPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuth";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أدخل كلمة السر للحساب";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuth_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAuth_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSubmit;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox2 txtAccountPassword;
    }
}