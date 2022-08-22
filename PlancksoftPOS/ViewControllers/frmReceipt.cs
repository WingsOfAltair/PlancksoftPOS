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
            this.pbReceipt.Image = receiptImage;
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
            DataTable printerNames = connection.server.RetrieveSystemSettings();
            string printer1 = printerNames.Rows[0]["SystemPrinterName"].ToString();
            string printer2 = printerNames.Rows[0]["SystemPrinterName2"].ToString();
            string printer3 = printerNames.Rows[0]["SystemPrinterName3"].ToString();
            if (printer1 != "")
            {
                printDocument1.PrinterSettings.PrinterName = printerNames.Rows[0]["SystemPrinterName"].ToString();
                printDocument1.Print();
            }
            if (printer2 != "")
            {
                printDocument1.PrinterSettings.PrinterName = printerNames.Rows[0]["SystemPrinterName2"].ToString();
                printDocument1.Print();
            }
            if (printer3 != "")
            {
                printDocument1.PrinterSettings.PrinterName = printerNames.Rows[0]["SystemPrinterName3"].ToString();
                printDocument1.Print();
            }
        }
    }
}
