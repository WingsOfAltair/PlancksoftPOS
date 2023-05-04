using Dependencies;
using MaterialSkin.Controls;
using MaterialSkin.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PlancksoftPOS
{
    public partial class frmReceipt : MaterialForm
    {
        Connection connection = null;
        List<Item> ItemsInBill;
        bool rePrint = false;
        bool MultiPrint = false;
        Bitmap bitmap = null;

        private PrintDocument PrintDocument;
        private Graphics graphics;
        private Graphics bitmapGraphic;
        private int InitialHeight = 360;
        Bill Bill;
        string shopName;
        string shopAddress;
        string shopPhone;
        public frmReceipt(Bill bill, string shopName, string shopAddress, string shopPhone, bool multiPrint, bool rePrint = false)
        {
            InitializeComponent();
            connection = new Connection();
            this.Bill = bill;
            this.ItemsInBill = bill.ItemsBought;
            this.MultiPrint = multiPrint;
            this.shopName = shopName;
            this.shopAddress = shopAddress;
            this.shopPhone = shopPhone;
            this.rePrint = rePrint;
            AdjustHeight();
            bitmap = new Bitmap(342, InitialHeight + 865, PixelFormat.Format32bppArgb);
            bitmapGraphic = Graphics.FromImage(bitmap);
            bitmapGraphic.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
        }
        private void AdjustHeight()
        {
            var capacity = 5 * ItemsInBill.Capacity;
            InitialHeight += capacity;

            capacity = 5 * ItemsInBill.Capacity;
            InitialHeight += capacity;
        }
        void DrawAtStart(string text, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font minifont = new Font("Arial", 5);

            graphics.DrawString(text, minifont,
                     new SolidBrush(Color.Black), startX + 5, startY + Offset);
            bitmapGraphic.DrawString(text, minifont,
                     new SolidBrush(Color.Black), startX + 5, startY + Offset);
        }
        void InsertItem(string key, string value, int Offset)
        {
            Font minifont = new Font("Arial", 5);
            int startX = 10;
            int startY = 5;

            graphics.DrawString(key, minifont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            bitmapGraphic.DrawString(key, minifont,
                     new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, minifont,
                 new SolidBrush(Color.Black), startX + 130, startY + Offset);

            bitmapGraphic.DrawString(value, minifont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void InsertHeaderStyleItem(string key, string value, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font itemfont = new Font("Arial", 6, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            bitmapGraphic.DrawString(key, itemfont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, itemfont,
                 new SolidBrush(Color.Black), startX + 130, startY + Offset);

            bitmapGraphic.DrawString(value, itemfont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void DrawLine(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
            bitmapGraphic.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        void DrawSimpleString(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
            bitmapGraphic.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            System.Drawing.Image image = Properties.Resources.plancksoft_b_t;
            e.Graphics.DrawImage(image, 0 + 80, 0 + Offset, 100, 30);
            bitmapGraphic.DrawImage(image, 0 + 80, 0 + Offset, 100, 30);

            Offset = Offset + largeinc + 40;

            graphics.DrawString("Welcome to " + shopName, largefont,
                  new SolidBrush(Color.Black), 0 + 22, 0 + Offset);

            bitmapGraphic.DrawString("Welcome to " + shopName, largefont,
                  new SolidBrush(Color.Black), 0 + 22, 0 + Offset);

            Offset = Offset + largeinc + 10;

            String underLine = "---------------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + largeinc + 10;
            Offset = Offset + largeinc + 10;
            if (rePrint)
            {
                DrawAtStart("Reprint of Invoice Number: " + Bill.BillNumber, Offset);
            }
            else
            {
                DrawAtStart("Invoice Number: " + Bill.BillNumber, Offset);
            }

            if (!String.Equals(Bill.ClientName, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Name: " + Bill.ClientName, Offset);
            }

            if (!String.Equals(Bill.ClientAddress, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Address: " + Bill.ClientAddress, Offset);
            }

            if (!String.Equals(Bill.ClientPhone, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Phone # : " + Bill.ClientPhone, Offset);
            }

            Offset = Offset + mediuminc;
            DrawAtStart("Date: " + Bill.getDate(), Offset);

            Offset = Offset + smallinc;
            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            Offset = Offset + largeinc;
            foreach (var item in Bill.ItemsBought)
            {
                InsertItem(item.ItemName1 + " x " + item.ItemQuantity1, item.ItemPriceTax1.ToString(), Offset);
                Offset = Offset + smallinc;
            }
            //foreach (var dtran in bill.ItemsBought)
            //{
            //    InsertItem(dtran.Deal.Name, dtran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;

            //    foreach (var di in dtran.Deal.DealItems)
            //    {
            //        InsertItem(di.Item.Name + " x " + (dtran.Quantity * di.Quantity), "", Offset);
            //        Offset = Offset + smallinc;
            //    }
            //}

            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;
            InsertItem(" Net. Total: ", Bill.getTotalAmount().ToString(), Offset);//getTotalAmount().CValue

            //if (!order.Cash.Discount.IsZero())
            //{
            //    Offset = Offset + smallinc;
            //    InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
            //}

            Offset = Offset + smallinc;
            InsertItem(" Paid Amount: ", Bill.getPaidAmount().ToString(), Offset);
            Offset = Offset + smallinc;
            InsertHeaderStyleItem(" Remainder Amount: ", Bill.getRemainderAmount().ToString(), Offset); // GrossTotal.CValue

            Offset = Offset + largeinc;
            //String address = Bill.ClientAddress;
            //DrawSimpleString("Address: " + address, minifont, Offset, 15);

            Offset = Offset + smallinc;
            //String number = "Tel: " + Bill.ClientPhone;// + " - OR - " + shop.Phone2;
            //DrawSimpleString(number, minifont, Offset, 35);

            Offset = Offset + 7;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            String greetings = "Thanks for visiting us.";
            DrawSimpleString(greetings, largefont, Offset, 28);

            Offset = Offset + mediuminc;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            //Offset += (2 * mediuminc);
            //string tip = "TIP: -----------------------------";
            //InsertItem(tip, "", Offset);
            Offset += (2 * mediuminc);
            string cashier = "Cashier: " + Bill.getCashierName(); ;
            InsertItem(cashier, "", Offset);

            Offset = Offset + largeinc;
            string DrawnBy = shopName + ": " + shopPhone + " - " + shopAddress;//"Plancksoft: +962 77 64 72 166 - Deir Al Asal Street, Khalda, Amman, Jordan.";
            DrawSimpleString(DrawnBy, minifont, Offset, 15);


            pbReceipt.Image = bitmap;
            using (MemoryStream Mmst = new MemoryStream())
            {
                try
                {
                    try
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts");
                    }
                    catch (Exception error) { }
                    try
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day);
                    }
                    catch (Exception error) { }

                    bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\Receipt\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour +
                        "-" + DateTime.Today.Minute + "-" + DateTime.Today.Second + "-" + DateTime.Today.Millisecond + " Transparent Receipt " +
                        Bill.getBillNumber() + ".png", ImageFormat.Png);

                    bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\Receipt\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour +
                        "-" + DateTime.Today.Minute + "-" + DateTime.Today.Second + "-" + DateTime.Today.Millisecond + " Receipt " +
                        Bill.getBillNumber() + ".jpeg", ImageFormat.Jpeg);
                }
                catch (Exception error)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        FlexibleMaterialForm.Show(this, ".لم نستطع حفظ نسخه من الفاتورة في مخزن الفواتير داخل سطح المكتب", "خطأ في حفظ  نسخه من الفاتوره", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        FlexibleMaterialForm.Show(this, "We were unable to save a copy of the receipt in the receipt storage inside the Desktop.", "A problem has occured while saving the receipt.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
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

        private void frmReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
