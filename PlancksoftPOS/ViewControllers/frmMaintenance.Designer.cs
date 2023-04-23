namespace PlancksoftPOS
{
    partial class frmMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintenance));
            this.lblPlancksoft1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPlancksoft2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblContactNumber = new MaterialSkin.Controls.MaterialLabel();
            this.pbPlancksoft = new System.Windows.Forms.PictureBox();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlancksoft)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlancksoft1
            // 
            this.lblPlancksoft1.AutoSize = true;
            this.lblPlancksoft1.Depth = 0;
            this.lblPlancksoft1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlancksoft1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPlancksoft1.Location = new System.Drawing.Point(3, 64);
            this.lblPlancksoft1.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPlancksoft1.Name = "lblPlancksoft1";
            this.lblPlancksoft1.Size = new System.Drawing.Size(362, 17);
            this.lblPlancksoft1.TabIndex = 0;
            this.lblPlancksoft1.Text = " Plancksoft تم تصميم و برمجة هذا النظام من قبل مؤسسة";
            // 
            // lblPlancksoft2
            // 
            this.lblPlancksoft2.AutoSize = true;
            this.lblPlancksoft2.Depth = 0;
            this.lblPlancksoft2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlancksoft2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPlancksoft2.Location = new System.Drawing.Point(3, 81);
            this.lblPlancksoft2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPlancksoft2.Name = "lblPlancksoft2";
            this.lblPlancksoft2.Size = new System.Drawing.Size(308, 17);
            this.lblPlancksoft2.TabIndex = 1;
            this.lblPlancksoft2.Text = " :للإستفسارات والصيانة, الرجاء الإتصال بالرقم التالي";
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Depth = 0;
            this.lblContactNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContactNumber.Font = new System.Drawing.Font("IRANYekanMobileFN", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblContactNumber.Location = new System.Drawing.Point(3, 98);
            this.lblContactNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblContactNumber.Size = new System.Drawing.Size(119, 17);
            this.lblContactNumber.TabIndex = 2;
            this.lblContactNumber.Text = "+962 77 64 721 66";
            // 
            // pbPlancksoft
            // 
            this.pbPlancksoft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbPlancksoft.Image = global::PlancksoftPOS.Properties.Resources.plancksoft_b_t;
            this.pbPlancksoft.Location = new System.Drawing.Point(3, 237);
            this.pbPlancksoft.Name = "pbPlancksoft";
            this.pbPlancksoft.Size = new System.Drawing.Size(674, 328);
            this.pbPlancksoft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlancksoft.TabIndex = 4;
            this.pbPlancksoft.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(3, 201);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(674, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "إغلاق";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 568);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbPlancksoft);
            this.Controls.Add(this.lblContactNumber);
            this.Controls.Add(this.lblPlancksoft2);
            this.Controls.Add(this.lblPlancksoft1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaintenance";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "عن البرمجية";
            ((System.ComponentModel.ISupportInitialize)(this.pbPlancksoft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblPlancksoft1;
        private MaterialSkin.Controls.MaterialLabel lblPlancksoft2;
        private MaterialSkin.Controls.MaterialLabel lblContactNumber;
        public System.Windows.Forms.PictureBox pbPlancksoft;
        private MaterialSkin.Controls.MaterialButton btnClose;
    }
}