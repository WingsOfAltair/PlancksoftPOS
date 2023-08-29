using MaterialSkin.Controls;

namespace PlancksoftPOS
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtUID = new System.Windows.Forms.ComboBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
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
            this.btnClear = new MaterialSkin.Controls.MaterialButton();
            this.btnExit = new MaterialSkin.Controls.MaterialButton();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.PlancksoftPOS = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.اللغةToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            this.العربيةToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            this.englishToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            this.المظهرToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            this.فاتحToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            this.مظلمToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            this.الخروجToolStripMenuItem = new MaterialSkin.Controls.MaterialToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Image = global::PlancksoftPOS.Properties.Resources.plancksoft_b_t;
            this.picLogo.Location = new System.Drawing.Point(3, 64);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(663, 158);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 42;
            this.picLogo.TabStop = false;
            // 
            // txtUID
            // 
            this.txtUID.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.txtUID.FormattingEnabled = true;
            this.txtUID.Location = new System.Drawing.Point(3, 222);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(663, 21);
            this.txtUID.TabIndex = 44;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Depth = 0;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.HideSelection = true;
            this.txtPassword.LeadingIcon = global::PlancksoftPOS.Properties.Resources.password;
            this.txtPassword.Location = new System.Drawing.Point(3, 243);
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
            this.txtPassword.Size = new System.Drawing.Size(663, 48);
            this.txtPassword.TabIndex = 48;
            this.txtPassword.TabStop = false;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.TrailingIcon = null;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // btn0
            // 
            this.btn0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn0.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btn0.Depth = 0;
            this.btn0.HighEmphasis = true;
            this.btn0.Icon = null;
            this.btn0.Location = new System.Drawing.Point(270, 524);
            this.btn0.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn0.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn0.Name = "btn0";
            this.btn0.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn0.Size = new System.Drawing.Size(64, 36);
            this.btn0.TabIndex = 61;
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
            this.btn1.Location = new System.Drawing.Point(390, 479);
            this.btn1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn1.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn1.Name = "btn1";
            this.btn1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn1.Size = new System.Drawing.Size(64, 36);
            this.btn1.TabIndex = 60;
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
            this.btn2.Location = new System.Drawing.Point(270, 479);
            this.btn2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn2.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn2.Name = "btn2";
            this.btn2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn2.Size = new System.Drawing.Size(64, 36);
            this.btn2.TabIndex = 59;
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
            this.btn3.Location = new System.Drawing.Point(149, 479);
            this.btn3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn3.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn3.Name = "btn3";
            this.btn3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn3.Size = new System.Drawing.Size(64, 36);
            this.btn3.TabIndex = 58;
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
            this.btn4.Location = new System.Drawing.Point(390, 431);
            this.btn4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn4.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn4.Name = "btn4";
            this.btn4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn4.Size = new System.Drawing.Size(64, 36);
            this.btn4.TabIndex = 57;
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
            this.btn5.Location = new System.Drawing.Point(270, 431);
            this.btn5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn5.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn5.Name = "btn5";
            this.btn5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn5.Size = new System.Drawing.Size(64, 36);
            this.btn5.TabIndex = 56;
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
            this.btn6.Location = new System.Drawing.Point(149, 431);
            this.btn6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn6.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn6.Name = "btn6";
            this.btn6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn6.Size = new System.Drawing.Size(64, 36);
            this.btn6.TabIndex = 55;
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
            this.btn7.Location = new System.Drawing.Point(390, 383);
            this.btn7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn7.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn7.Name = "btn7";
            this.btn7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn7.Size = new System.Drawing.Size(64, 36);
            this.btn7.TabIndex = 54;
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
            this.btn8.Location = new System.Drawing.Point(270, 383);
            this.btn8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn8.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn8.Name = "btn8";
            this.btn8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn8.Size = new System.Drawing.Size(64, 36);
            this.btn8.TabIndex = 53;
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
            this.btn9.Location = new System.Drawing.Point(149, 383);
            this.btn9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn9.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn9.Name = "btn9";
            this.btn9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btn9.Size = new System.Drawing.Size(64, 36);
            this.btn9.TabIndex = 52;
            this.btn9.Text = "9";
            this.btn9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn9.UseAccentColor = false;
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClear.Depth = 0;
            this.btnClear.HighEmphasis = true;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(148, 524);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClear.Size = new System.Drawing.Size(64, 36);
            this.btnClear.TabIndex = 62;
            this.btnClear.Text = "مسح";
            this.btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClear.UseAccentColor = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExit.Depth = 0;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.HighEmphasis = true;
            this.btnExit.Icon = null;
            this.btnExit.Location = new System.Drawing.Point(3, 650);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExit.Name = "btnExit";
            this.btnExit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExit.Size = new System.Drawing.Size(663, 36);
            this.btnExit.TabIndex = 63;
            this.btnExit.Text = "الخروج";
            this.btnExit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExit.UseAccentColor = false;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(3, 614);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(663, 36);
            this.btnLogin.TabIndex = 64;
            this.btnLogin.Text = "تسجيل الدخول";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // PlancksoftPOS
            // 
            this.PlancksoftPOS.BalloonTipText = "PlancksoftPOS";
            this.PlancksoftPOS.ContextMenuStrip = this.Menu;
            this.PlancksoftPOS.Icon = ((System.Drawing.Icon)(resources.GetObject("PlancksoftPOS.Icon")));
            this.PlancksoftPOS.Text = "PlancksoftPOS";
            this.PlancksoftPOS.Visible = true;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Menu.Depth = 0;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اللغةToolStripMenuItem,
            this.المظهرToolStripMenuItem,
            this.الخروجToolStripMenuItem});
            this.Menu.MouseState = MaterialSkin.MouseState.HOVER;
            this.Menu.Name = "Menu";
            this.Menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu.Size = new System.Drawing.Size(110, 70);
            // 
            // اللغةToolStripMenuItem
            // 
            this.اللغةToolStripMenuItem.AutoSize = false;
            this.اللغةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.العربيةToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.اللغةToolStripMenuItem.Name = "اللغةToolStripMenuItem";
            this.اللغةToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.اللغةToolStripMenuItem.Text = "اللغة";
            // 
            // العربيةToolStripMenuItem
            // 
            this.العربيةToolStripMenuItem.AutoSize = false;
            this.العربيةToolStripMenuItem.CheckOnClick = true;
            this.العربيةToolStripMenuItem.Name = "العربيةToolStripMenuItem";
            this.العربيةToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.العربيةToolStripMenuItem.Text = "العربية";
            this.العربيةToolStripMenuItem.Click += new System.EventHandler(this.العربيةToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.AutoSize = false;
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // المظهرToolStripMenuItem
            // 
            this.المظهرToolStripMenuItem.AutoSize = false;
            this.المظهرToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.فاتحToolStripMenuItem,
            this.مظلمToolStripMenuItem});
            this.المظهرToolStripMenuItem.Name = "المظهرToolStripMenuItem";
            this.المظهرToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.المظهرToolStripMenuItem.Text = "المظهر";
            // 
            // فاتحToolStripMenuItem
            // 
            this.فاتحToolStripMenuItem.AutoSize = false;
            this.فاتحToolStripMenuItem.Name = "فاتحToolStripMenuItem";
            this.فاتحToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.فاتحToolStripMenuItem.Text = "فاتح";
            this.فاتحToolStripMenuItem.Click += new System.EventHandler(this.فاتحToolStripMenuItem_Click);
            // 
            // مظلمToolStripMenuItem
            // 
            this.مظلمToolStripMenuItem.AutoSize = false;
            this.مظلمToolStripMenuItem.Name = "مظلمToolStripMenuItem";
            this.مظلمToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.مظلمToolStripMenuItem.Text = "مظلم";
            this.مظلمToolStripMenuItem.Click += new System.EventHandler(this.مظلمToolStripMenuItem_Click);
            // 
            // الخروجToolStripMenuItem
            // 
            this.الخروجToolStripMenuItem.AutoSize = false;
            this.الخروجToolStripMenuItem.Name = "الخروجToolStripMenuItem";
            this.الخروجToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.الخروجToolStripMenuItem.Text = "الخروج";
            this.الخروجToolStripMenuItem.Click += new System.EventHandler(this.الخروجToolStripMenuItem_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 689);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
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
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الترخيص و التفعيل";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picLogo;
        public System.Windows.Forms.ComboBox txtUID;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
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
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialButton btnExit;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private System.Windows.Forms.NotifyIcon PlancksoftPOS;
        private MaterialToolStripMenuItem اللغةToolStripMenuItem;
        private MaterialToolStripMenuItem العربيةToolStripMenuItem;
        private MaterialToolStripMenuItem englishToolStripMenuItem;
        private MaterialToolStripMenuItem المظهرToolStripMenuItem;
        private MaterialToolStripMenuItem فاتحToolStripMenuItem;
        private MaterialToolStripMenuItem مظلمToolStripMenuItem;
        private MaterialToolStripMenuItem الخروجToolStripMenuItem;
        private MaterialContextMenuStrip Menu;
    }
}