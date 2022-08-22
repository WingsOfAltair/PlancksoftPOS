using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlancksoftPOS
{
    public partial class frmReceipt : Form
    {
        Connection connection = null;
        public frmReceipt(Bitmap receiptImage)
        {
            InitializeComponent();
            connection = new Connection();
            this.Height = receiptImage.Height;
            this.Width = receiptImage.Width;
            this.pbReceipt.Image = receiptImage;
            this.pbReceipt.Height = receiptImage.Height;
            this.pbReceipt.Width = receiptImage.Width;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pbReceipt.Image, 0, 0);
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            //frmMain.PrintersList = connection.server.RetrievePrinters();
            
            //foreach (Dependencies.Printer printer in frmMain.PrintersList)
            //{
            //    printDocument1.PrinterSettings.PrinterName = printer.Name;
            //    printDocument1.Print();
            //}
        }
    }
}
