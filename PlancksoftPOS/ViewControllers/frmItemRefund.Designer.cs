namespace PlancksoftPOS
{
    partial class frmItemRefund
    {

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemRefund));
            this.button1 = new System.Windows.Forms.Button();
            this.ItemQuantitynud = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ItemBarCodetxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemNametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.اللغةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.العربيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الخروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlancksoftPOS = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantitynud)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(16, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "اختيار الماده";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItemQuantitynud
            // 
            this.ItemQuantitynud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemQuantitynud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemQuantitynud.Location = new System.Drawing.Point(257, 26);
            this.ItemQuantitynud.Name = "ItemQuantitynud";
            this.ItemQuantitynud.Size = new System.Drawing.Size(115, 20);
            this.ItemQuantitynud.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label4.Location = new System.Drawing.Point(254, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "عدد القطع";
            // 
            // ItemBarCodetxt
            // 
            this.ItemBarCodetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBarCodetxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemBarCodetxt.Location = new System.Drawing.Point(16, 72);
            this.ItemBarCodetxt.Name = "ItemBarCodetxt";
            this.ItemBarCodetxt.Size = new System.Drawing.Size(226, 20);
            this.ItemBarCodetxt.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "باركود الماده";
            // 
            // ItemNametxt
            // 
            this.ItemNametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNametxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemNametxt.Location = new System.Drawing.Point(16, 25);
            this.ItemNametxt.Name = "ItemNametxt";
            this.ItemNametxt.Size = new System.Drawing.Size(226, 20);
            this.ItemNametxt.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "اسم الماده";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(142, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 48);
            this.button2.TabIndex = 18;
            this.button2.Text = "ارجاع الماده";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(272, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 48);
            this.button3.TabIndex = 19;
            this.button3.Text = "الغاء";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اللغةToolStripMenuItem,
            this.الخروجToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu.Size = new System.Drawing.Size(107, 48);
            // 
            // اللغةToolStripMenuItem
            // 
            this.اللغةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.العربيةToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.اللغةToolStripMenuItem.Name = "اللغةToolStripMenuItem";
            this.اللغةToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.اللغةToolStripMenuItem.Text = "اللغة";
            // 
            // العربيةToolStripMenuItem
            // 
            this.العربيةToolStripMenuItem.CheckOnClick = true;
            this.العربيةToolStripMenuItem.Name = "العربيةToolStripMenuItem";
            this.العربيةToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.العربيةToolStripMenuItem.Text = "العربية";
            this.العربيةToolStripMenuItem.Click += new System.EventHandler(this.العربيةToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // الخروجToolStripMenuItem
            // 
            this.الخروجToolStripMenuItem.Name = "الخروجToolStripMenuItem";
            this.الخروجToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.الخروجToolStripMenuItem.Text = "الخروج";
            this.الخروجToolStripMenuItem.Click += new System.EventHandler(this.الخروجToolStripMenuItem_Click);
            // 
            // PlancksoftPOS
            // 
            this.PlancksoftPOS.ContextMenuStrip = this.Menu;
            this.PlancksoftPOS.Icon = ((System.Drawing.Icon)(resources.GetObject("PlancksoftPOS.Icon")));
            this.PlancksoftPOS.Text = "PlancksoftPOS";
            this.PlancksoftPOS.Visible = true;
            // 
            // frmItemRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 170);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ItemQuantitynud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ItemBarCodetxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemNametxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemRefund";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارجاع المواد";
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantitynud)).EndInit();
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.NumericUpDown ItemQuantitynud;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox ItemBarCodetxt;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox ItemNametxt;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem اللغةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem العربيةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem الخروجToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon PlancksoftPOS;
        private System.ComponentModel.IContainer components;
    }
}