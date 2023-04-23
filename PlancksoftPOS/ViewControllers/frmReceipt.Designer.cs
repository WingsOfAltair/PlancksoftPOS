namespace PlancksoftPOS
{
    partial class frmReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceipt));
            this.pbReceipt = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPickCustomer = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // pbReceipt
            // 
            this.pbReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbReceipt.Location = new System.Drawing.Point(0, 0);
            this.pbReceipt.Name = "pbReceipt";
            this.pbReceipt.Size = new System.Drawing.Size(348, 1050);
            this.pbReceipt.TabIndex = 0;
            this.pbReceipt.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPickCustomer
            // 
            this.btnPickCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPickCustomer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPickCustomer.Depth = 0;
            this.btnPickCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPickCustomer.HighEmphasis = true;
            this.btnPickCustomer.Icon = null;
            this.btnPickCustomer.Location = new System.Drawing.Point(0, 0);
            this.btnPickCustomer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPickCustomer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPickCustomer.Name = "btnPickCustomer";
            this.btnPickCustomer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPickCustomer.Size = new System.Drawing.Size(348, 36);
            this.btnPickCustomer.TabIndex = 75;
            this.btnPickCustomer.Text = "X";
            this.btnPickCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPickCustomer.UseAccentColor = false;
            this.btnPickCustomer.UseVisualStyleBackColor = true;
            this.btnPickCustomer.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 1050);
            this.ControlBox = false;
            this.Controls.Add(this.btnPickCustomer);
            this.Controls.Add(this.pbReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReceipt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReceipt";
            this.Load += new System.EventHandler(this.frmReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.PictureBox pbReceipt;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private MaterialSkin.Controls.MaterialButton btnPickCustomer;
    }
}