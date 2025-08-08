namespace PlancksoftPOS_Receipt_Print_Server
{
    partial class ReceiptPrintServer
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
            this.NewReceiptsFetcher = new System.ComponentModel.BackgroundWorker();
            this.cycleTimer = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pbReceipt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // NewReceiptsFetcher
            // 
            this.NewReceiptsFetcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NewReceiptsFetcher_DoWork);
            // 
            // cycleTimer
            // 
            this.cycleTimer.Enabled = true;
            this.cycleTimer.Interval = 5000;
            this.cycleTimer.Tick += new System.EventHandler(this.cycleTimer_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pbReceipt
            // 
            this.pbReceipt.Location = new System.Drawing.Point(0, 0);
            this.pbReceipt.Name = "pbReceipt";
            this.pbReceipt.Size = new System.Drawing.Size(0, 0);
            this.pbReceipt.TabIndex = 0;
            this.pbReceipt.TabStop = false;
            this.pbReceipt.UseWaitCursor = true;
            // 
            // ReceiptPrintServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.ControlBox = false;
            this.Controls.Add(this.pbReceipt);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptPrintServer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PlancksoftPOS Receipt Print Server";
            this.UseWaitCursor = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker NewReceiptsFetcher;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox pbReceipt;
    }
}

