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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPickClient = new MaterialSkin.Controls.MaterialButton();
            this.pbReceipt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPickClient
            // 
            this.btnPickClient.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPickClient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPickClient.Depth = 0;
            this.btnPickClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPickClient.HighEmphasis = true;
            this.btnPickClient.Icon = null;
            this.btnPickClient.Location = new System.Drawing.Point(3, 64);
            this.btnPickClient.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPickClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPickClient.Name = "btnPickClient";
            this.btnPickClient.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPickClient.Size = new System.Drawing.Size(342, 36);
            this.btnPickClient.TabIndex = 75;
            this.btnPickClient.Text = "X";
            this.btnPickClient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPickClient.UseAccentColor = false;
            this.btnPickClient.UseVisualStyleBackColor = true;
            this.btnPickClient.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbReceipt
            // 
            this.pbReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbReceipt.Location = new System.Drawing.Point(3, 100);
            this.pbReceipt.Name = "pbReceipt";
            this.pbReceipt.Size = new System.Drawing.Size(342, 865);
            this.pbReceipt.TabIndex = 76;
            this.pbReceipt.TabStop = false;
            // 
            // frmReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 1050);
            this.ControlBox = false;
            this.Controls.Add(this.pbReceipt);
            this.Controls.Add(this.btnPickClient);
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
        private System.Drawing.Printing.PrintDocument printDocument1;
        private MaterialSkin.Controls.MaterialButton btnPickClient;
        internal System.Windows.Forms.PictureBox pbReceipt;
    }
}