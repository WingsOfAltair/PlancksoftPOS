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
        List<Dependencies.Item> ItemsInBill;
        bool MultiPrint = false;
        public frmReceipt(Bitmap receiptImage, List<Dependencies.Item> itemsInBill, bool multiPrint)
        {
            InitializeComponent();
            connection = new Connection();
            this.ItemsInBill = itemsInBill;
            this.MultiPrint = multiPrint;
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
            if (!MultiPrint)
            {
                frmMain.PrintersList = connection.server.RetrievePrinters(Environment.MachineName);

                foreach (Dependencies.Printer printer in frmMain.PrintersList)
                {
                    printDocument1.PrinterSettings.PrinterName = printer.Name;
                    if (printDocument1.PrinterSettings.IsDefaultPrinter)
                    {
                        printDocument1.PrinterSettings.PrinterName = printer.Name;
                        printDocument1.Print();
                    }
                }
            }
            else
            {
                List<Dependencies.Printer> PrintersToPrint = new List<Dependencies.Printer>();

                frmMain.PrintersList = connection.server.RetrievePrinters(Environment.MachineName);

                foreach (Dependencies.Item item in ItemsInBill)
                {
                    foreach (Dependencies.Printer printer in frmMain.PrintersList)
                    {
                        List<Dependencies.ItemType> ItemTypesInPrinterList = connection.server.RetrievePrinterItemTypes(printer.ID);

                        foreach (Dependencies.ItemType itemTypeInPrinterList in ItemTypesInPrinterList)
                        {
                            if (item.GetItemTypeeID() == itemTypeInPrinterList.ID && !PrintersToPrint.Contains(printer))
                            {
                                PrintersToPrint.Add(printer);
                            }
                        }
                    }
                }

                foreach (Dependencies.Printer printer in PrintersToPrint)
                {
                    printDocument1.PrinterSettings.PrinterName = printer.Name;
                    printDocument1.Print();
                }
            }
        }
    }
}
