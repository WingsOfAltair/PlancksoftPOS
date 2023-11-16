namespace PlancksoftPOS
{
    partial class frmPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPay));
            this.lblRequiredAmount = new MaterialSkin.Controls.MaterialLabel();
            this.lblRemainderAmount = new MaterialSkin.Controls.MaterialLabel();
            this.lblPaidAmount = new MaterialSkin.Controls.MaterialLabel();
            this.txtRequiredAmount = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtRemainderAmount = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtPaidAmount = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnDecimal = new MaterialSkin.Controls.MaterialButton();
            this.btn0 = new MaterialSkin.Controls.MaterialButton();
            this.btn1 = new MaterialSkin.Controls.MaterialButton();
            this.btn2 = new MaterialSkin.Controls.MaterialButton();
            this.btn3 = new MaterialSkin.Controls.MaterialButton();
            this.btn4 = new MaterialSkin.Controls.MaterialButton();
            this.btn5 = new MaterialSkin.Controls.MaterialButton();
            this.btn6 = new MaterialSkin.Controls.MaterialButton();
            this.btn7 = new MaterialSkin.Controls.MaterialButton();
            this.btn8 = new MaterialSkin.Controls.MaterialButton();
            this.btn9 = new MaterialSkin.Controls.MaterialButton();
            this.cbWithDiscount = new MaterialSkin.Controls.MaterialCheckbox();
            this.nudDiscountRate = new System.Windows.Forms.NumericUpDown();
            this.lblPercentage = new MaterialSkin.Controls.MaterialLabel();
            this.rbCash = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbVisa = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnPay = new MaterialSkin.Controls.MaterialButton();
            this.btnDelayPayment = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnClientPay = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRequiredAmount
            // 
            this.lblRequiredAmount.AutoSize = true;
            this.lblRequiredAmount.Depth = 0;
            this.lblRequiredAmount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRequiredAmount.Location = new System.Drawing.Point(138, 73);
            this.lblRequiredAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRequiredAmount.Name = "lblRequiredAmount";
            this.lblRequiredAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRequiredAmount.Size = new System.Drawing.Size(61, 19);
            this.lblRequiredAmount.TabIndex = 0;
            this.lblRequiredAmount.Text = "المبلغ المطلوب";
            // 
            // lblRemainderAmount
            // 
            this.lblRemainderAmount.AutoSize = true;
            this.lblRemainderAmount.Depth = 0;
            this.lblRemainderAmount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRemainderAmount.Location = new System.Drawing.Point(746, 73);
            this.lblRemainderAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRemainderAmount.Name = "lblRemainderAmount";
            this.lblRemainderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRemainderAmount.Size = new System.Drawing.Size(23, 19);
            this.lblRemainderAmount.TabIndex = 1;
            this.lblRemainderAmount.Text = "الباقي";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Depth = 0;
            this.lblPaidAmount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPaidAmount.Location = new System.Drawing.Point(356, 144);
            this.lblPaidAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaidAmount.Size = new System.Drawing.Size(56, 19);
            this.lblPaidAmount.TabIndex = 2;
            this.lblPaidAmount.Text = "المبلغ المدفوع";
            // 
            // txtRequiredAmount
            // 
            this.txtRequiredAmount.AnimateReadOnly = false;
            this.txtRequiredAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRequiredAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRequiredAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRequiredAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRequiredAmount.Depth = 0;
            this.txtRequiredAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRequiredAmount.HideSelection = true;
            this.txtRequiredAmount.LeadingIcon = null;
            this.txtRequiredAmount.Location = new System.Drawing.Point(6, 93);
            this.txtRequiredAmount.MaxLength = 32767;
            this.txtRequiredAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRequiredAmount.Name = "txtRequiredAmount";
            this.txtRequiredAmount.PasswordChar = '\0';
            this.txtRequiredAmount.PrefixSuffixText = null;
            this.txtRequiredAmount.ReadOnly = false;
            this.txtRequiredAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRequiredAmount.SelectedText = "";
            this.txtRequiredAmount.SelectionLength = 0;
            this.txtRequiredAmount.SelectionStart = 0;
            this.txtRequiredAmount.ShortcutsEnabled = true;
            this.txtRequiredAmount.Size = new System.Drawing.Size(360, 48);
            this.txtRequiredAmount.TabIndex = 3;
            this.txtRequiredAmount.TabStop = false;
            this.txtRequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRequiredAmount.TrailingIcon = null;
            this.txtRequiredAmount.UseSystemPasswordChar = false;
            this.txtRequiredAmount.TextChanged += new System.EventHandler(this.txtRequiredAmount_TextChanged);
            // 
            // txtRemainderAmount
            // 
            this.txtRemainderAmount.AnimateReadOnly = false;
            this.txtRemainderAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRemainderAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRemainderAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRemainderAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRemainderAmount.Depth = 0;
            this.txtRemainderAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRemainderAmount.HideSelection = true;
            this.txtRemainderAmount.LeadingIcon = null;
            this.txtRemainderAmount.Location = new System.Drawing.Point(581, 93);
            this.txtRemainderAmount.MaxLength = 32767;
            this.txtRemainderAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRemainderAmount.Name = "txtRemainderAmount";
            this.txtRemainderAmount.PasswordChar = '\0';
            this.txtRemainderAmount.PrefixSuffixText = null;
            this.txtRemainderAmount.ReadOnly = false;
            this.txtRemainderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemainderAmount.SelectedText = "";
            this.txtRemainderAmount.SelectionLength = 0;
            this.txtRemainderAmount.SelectionStart = 0;
            this.txtRemainderAmount.ShortcutsEnabled = true;
            this.txtRemainderAmount.Size = new System.Drawing.Size(360, 48);
            this.txtRemainderAmount.TabIndex = 4;
            this.txtRemainderAmount.TabStop = false;
            this.txtRemainderAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRemainderAmount.TrailingIcon = null;
            this.txtRemainderAmount.UseSystemPasswordChar = false;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.AnimateReadOnly = false;
            this.txtPaidAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPaidAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPaidAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPaidAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPaidAmount.Depth = 0;
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPaidAmount.HideSelection = true;
            this.txtPaidAmount.LeadingIcon = null;
            this.txtPaidAmount.Location = new System.Drawing.Point(6, 164);
            this.txtPaidAmount.MaxLength = 32767;
            this.txtPaidAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.PasswordChar = '\0';
            this.txtPaidAmount.PrefixSuffixText = null;
            this.txtPaidAmount.ReadOnly = false;
            this.txtPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaidAmount.SelectedText = "";
            this.txtPaidAmount.SelectionLength = 0;
            this.txtPaidAmount.SelectionStart = 0;
            this.txtPaidAmount.ShortcutsEnabled = true;
            this.txtPaidAmount.Size = new System.Drawing.Size(935, 48);
            this.txtPaidAmount.TabIndex = 5;
            this.txtPaidAmount.TabStop = false;
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPaidAmount.TrailingIcon = null;
            this.txtPaidAmount.UseSystemPasswordChar = false;
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaidAmount_KeyPress);
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            // 
            // btnDecimal
            // 
            this.btnDecimal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDecimal.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDecimal.Depth = 0;
            this.btnDecimal.HighEmphasis = true;
            this.btnDecimal.Icon = null;
            this.btnDecimal.Location = new System.Drawing.Point(20, 371);
            this.btnDecimal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDecimal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDecimal.Size = new System.Drawing.Size(64, 36);
            this.btnDecimal.TabIndex = 65;
            this.btnDecimal.Text = ".";
            this.btnDecimal.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDecimal.UseAccentColor = false;
            this.btnDecimal.UseVisualStyleBackColor = true;
            this.btnDecimal.Click += new System.EventHandler(this.btnDecimal_Click);
            // 
            // btn0
            // 
            this.btn0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn0.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn0.Depth = 0;
            this.btn0.HighEmphasis = true;
            this.btn0.Icon = null;
            this.btn0.Location = new System.Drawing.Point(141, 371);
            this.btn0.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn0.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn0.Name = "btn0";
            this.btn0.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn0.Size = new System.Drawing.Size(64, 36);
            this.btn0.TabIndex = 64;
            this.btn0.Text = "0";
            this.btn0.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn0.UseAccentColor = false;
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn1
            // 
            this.btn1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn1.Depth = 0;
            this.btn1.HighEmphasis = true;
            this.btn1.Icon = null;
            this.btn1.Location = new System.Drawing.Point(261, 326);
            this.btn1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn1.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn1.Name = "btn1";
            this.btn1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn1.Size = new System.Drawing.Size(64, 36);
            this.btn1.TabIndex = 63;
            this.btn1.Text = "1";
            this.btn1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn1.UseAccentColor = false;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn2.Depth = 0;
            this.btn2.HighEmphasis = true;
            this.btn2.Icon = null;
            this.btn2.Location = new System.Drawing.Point(141, 326);
            this.btn2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn2.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn2.Name = "btn2";
            this.btn2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn2.Size = new System.Drawing.Size(64, 36);
            this.btn2.TabIndex = 62;
            this.btn2.Text = "2";
            this.btn2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn2.UseAccentColor = false;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn3.Depth = 0;
            this.btn3.HighEmphasis = true;
            this.btn3.Icon = null;
            this.btn3.Location = new System.Drawing.Point(20, 326);
            this.btn3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn3.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn3.Name = "btn3";
            this.btn3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn3.Size = new System.Drawing.Size(64, 36);
            this.btn3.TabIndex = 61;
            this.btn3.Text = "3";
            this.btn3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn3.UseAccentColor = false;
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn4
            // 
            this.btn4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn4.Depth = 0;
            this.btn4.HighEmphasis = true;
            this.btn4.Icon = null;
            this.btn4.Location = new System.Drawing.Point(261, 278);
            this.btn4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn4.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn4.Name = "btn4";
            this.btn4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn4.Size = new System.Drawing.Size(64, 36);
            this.btn4.TabIndex = 60;
            this.btn4.Text = "4";
            this.btn4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn4.UseAccentColor = false;
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn5.Depth = 0;
            this.btn5.HighEmphasis = true;
            this.btn5.Icon = null;
            this.btn5.Location = new System.Drawing.Point(141, 278);
            this.btn5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn5.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn5.Name = "btn5";
            this.btn5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn5.Size = new System.Drawing.Size(64, 36);
            this.btn5.TabIndex = 59;
            this.btn5.Text = "5";
            this.btn5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn5.UseAccentColor = false;
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn6.Depth = 0;
            this.btn6.HighEmphasis = true;
            this.btn6.Icon = null;
            this.btn6.Location = new System.Drawing.Point(20, 278);
            this.btn6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn6.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn6.Name = "btn6";
            this.btn6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn6.Size = new System.Drawing.Size(64, 36);
            this.btn6.TabIndex = 58;
            this.btn6.Text = "6";
            this.btn6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn6.UseAccentColor = false;
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn7
            // 
            this.btn7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn7.Depth = 0;
            this.btn7.HighEmphasis = true;
            this.btn7.Icon = null;
            this.btn7.Location = new System.Drawing.Point(261, 230);
            this.btn7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn7.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn7.Name = "btn7";
            this.btn7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn7.Size = new System.Drawing.Size(64, 36);
            this.btn7.TabIndex = 57;
            this.btn7.Text = "7";
            this.btn7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn7.UseAccentColor = false;
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn8
            // 
            this.btn8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn8.Depth = 0;
            this.btn8.HighEmphasis = true;
            this.btn8.Icon = null;
            this.btn8.Location = new System.Drawing.Point(141, 230);
            this.btn8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn8.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn8.Name = "btn8";
            this.btn8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn8.Size = new System.Drawing.Size(64, 36);
            this.btn8.TabIndex = 56;
            this.btn8.Text = "8";
            this.btn8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn8.UseAccentColor = false;
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn9
            // 
            this.btn9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn9.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn9.Depth = 0;
            this.btn9.HighEmphasis = true;
            this.btn9.Icon = null;
            this.btn9.Location = new System.Drawing.Point(20, 230);
            this.btn9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn9.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn9.Name = "btn9";
            this.btn9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn9.Size = new System.Drawing.Size(64, 36);
            this.btn9.TabIndex = 55;
            this.btn9.Text = "9";
            this.btn9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn9.UseAccentColor = false;
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // cbWithDiscount
            // 
            this.cbWithDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWithDiscount.AutoSize = true;
            this.cbWithDiscount.Depth = 0;
            this.cbWithDiscount.Location = new System.Drawing.Point(980, 290);
            this.cbWithDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.cbWithDiscount.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbWithDiscount.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbWithDiscount.Name = "cbWithDiscount";
            this.cbWithDiscount.ReadOnly = false;
            this.cbWithDiscount.Ripple = true;
            this.cbWithDiscount.Size = new System.Drawing.Size(69, 37);
            this.cbWithDiscount.TabIndex = 66;
            this.cbWithDiscount.Text = "مع خصم";
            this.cbWithDiscount.UseVisualStyleBackColor = true;
            this.cbWithDiscount.CheckedChanged += new System.EventHandler(this.cbWithDiscount_CheckedChanged);
            // 
            // nudDiscountRate
            // 
            this.nudDiscountRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiscountRate.Enabled = false;
            this.nudDiscountRate.Location = new System.Drawing.Point(967, 326);
            this.nudDiscountRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDiscountRate.Name = "nudDiscountRate";
            this.nudDiscountRate.Size = new System.Drawing.Size(54, 20);
            this.nudDiscountRate.TabIndex = 67;
            this.nudDiscountRate.ValueChanged += new System.EventHandler(this.nudDiscountRate_ValueChanged);
            // 
            // lblPercentage
            // 
            this.lblPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Depth = 0;
            this.lblPercentage.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPercentage.Location = new System.Drawing.Point(1032, 326);
            this.lblPercentage.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPercentage.Size = new System.Drawing.Size(13, 19);
            this.lblPercentage.TabIndex = 68;
            this.lblPercentage.Text = "%";
            // 
            // rbCash
            // 
            this.rbCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCash.AutoSize = true;
            this.rbCash.Depth = 0;
            this.rbCash.Location = new System.Drawing.Point(981, 216);
            this.rbCash.Margin = new System.Windows.Forms.Padding(0);
            this.rbCash.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbCash.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbCash.Name = "rbCash";
            this.rbCash.Ripple = true;
            this.rbCash.Size = new System.Drawing.Size(68, 37);
            this.rbCash.TabIndex = 69;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "دفع كاش";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // rbVisa
            // 
            this.rbVisa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbVisa.AutoSize = true;
            this.rbVisa.Depth = 0;
            this.rbVisa.Location = new System.Drawing.Point(967, 253);
            this.rbVisa.Margin = new System.Windows.Forms.Padding(0);
            this.rbVisa.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbVisa.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbVisa.Name = "rbVisa";
            this.rbVisa.Ripple = true;
            this.rbVisa.Size = new System.Drawing.Size(82, 37);
            this.rbVisa.TabIndex = 70;
            this.rbVisa.TabStop = true;
            this.rbVisa.Text = "دفع Visa";
            this.rbVisa.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPay.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPay.Depth = 0;
            this.btnPay.HighEmphasis = true;
            this.btnPay.Icon = null;
            this.btnPay.Location = new System.Drawing.Point(783, 228);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPay.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPay.Name = "btnPay";
            this.btnPay.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPay.Size = new System.Drawing.Size(64, 36);
            this.btnPay.TabIndex = 71;
            this.btnPay.Text = "دفع";
            this.btnPay.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPay.UseAccentColor = false;
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnDelayPayment
            // 
            this.btnDelayPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelayPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelayPayment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDelayPayment.Depth = 0;
            this.btnDelayPayment.HighEmphasis = true;
            this.btnDelayPayment.Icon = null;
            this.btnDelayPayment.Location = new System.Drawing.Point(769, 269);
            this.btnDelayPayment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelayPayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelayPayment.Name = "btnDelayPayment";
            this.btnDelayPayment.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDelayPayment.Size = new System.Drawing.Size(78, 36);
            this.btnDelayPayment.TabIndex = 72;
            this.btnDelayPayment.Text = "تأجيل الدفع";
            this.btnDelayPayment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelayPayment.UseAccentColor = false;
            this.btnDelayPayment.UseVisualStyleBackColor = true;
            this.btnDelayPayment.Click += new System.EventHandler(this.btnDelayPayment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(783, 310);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 73;
            this.btnCancel.Text = "اغلاق";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClear.Depth = 0;
            this.btnClear.HighEmphasis = true;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(261, 371);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(64, 36);
            this.btnClear.TabIndex = 74;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClientPay
            // 
            this.btnClientPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientPay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientPay.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientPay.Depth = 0;
            this.btnClientPay.HighEmphasis = true;
            this.btnClientPay.Icon = null;
            this.btnClientPay.Location = new System.Drawing.Point(622, 228);
            this.btnClientPay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientPay.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientPay.Name = "btnClientPay";
            this.btnClientPay.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientPay.Size = new System.Drawing.Size(69, 36);
            this.btnClientPay.TabIndex = 75;
            this.btnClientPay.Text = "دفع عميل";
            this.btnClientPay.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientPay.UseAccentColor = false;
            this.btnClientPay.UseVisualStyleBackColor = true;
            this.btnClientPay.Click += new System.EventHandler(this.btnClientPay_Click);
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 468);
            this.Controls.Add(this.btnClientPay);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelayPayment);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.rbVisa);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.nudDiscountRate);
            this.Controls.Add(this.cbWithDiscount);
            this.Controls.Add(this.btnDecimal);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.txtRemainderAmount);
            this.Controls.Add(this.txtRequiredAmount);
            this.Controls.Add(this.lblPaidAmount);
            this.Controls.Add(this.lblRemainderAmount);
            this.Controls.Add(this.lblRequiredAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إغلاق الكاش";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPay_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblRequiredAmount;
        private MaterialSkin.Controls.MaterialLabel lblRemainderAmount;
        private MaterialSkin.Controls.MaterialLabel lblPaidAmount;
        private MaterialSkin.Controls.MaterialTextBox2 txtRequiredAmount;
        private MaterialSkin.Controls.MaterialTextBox2 txtRemainderAmount;
        private MaterialSkin.Controls.MaterialTextBox2 txtPaidAmount;
        private MaterialSkin.Controls.MaterialButton btnDecimal;
        private MaterialSkin.Controls.MaterialButton btn0;
        private MaterialSkin.Controls.MaterialButton btn1;
        private MaterialSkin.Controls.MaterialButton btn2;
        private MaterialSkin.Controls.MaterialButton btn3;
        private MaterialSkin.Controls.MaterialButton btn4;
        private MaterialSkin.Controls.MaterialButton btn5;
        private MaterialSkin.Controls.MaterialButton btn6;
        private MaterialSkin.Controls.MaterialButton btn7;
        private MaterialSkin.Controls.MaterialButton btn8;
        private MaterialSkin.Controls.MaterialButton btn9;
        private MaterialSkin.Controls.MaterialCheckbox cbWithDiscount;
        public System.Windows.Forms.NumericUpDown nudDiscountRate;
        private MaterialSkin.Controls.MaterialLabel lblPercentage;
        private MaterialSkin.Controls.MaterialRadioButton rbCash;
        private MaterialSkin.Controls.MaterialRadioButton rbVisa;
        private MaterialSkin.Controls.MaterialButton btnPay;
        private MaterialSkin.Controls.MaterialButton btnDelayPayment;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnClientPay;
    }
}