using Dependencies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlancksoftPOS_Receipt_Print_Server
{
    public partial class ReceiptPrintServer : Form
    {
        public Connection Connection = new Connection();

        Bill Bill;
        List<Bill> UnprintedBills = new List<Bill>();

        List<Item> ItemsInBill;

        public static List<Printer> PrintersList = new List<Printer>();

        bool rePrint = false;

        Bitmap bitmap = null;

        private PrintDocument PrintDocument;
        private Graphics graphics;
        private Graphics bitmapGraphic;
        private int InitialHeight = 360;

        Image StoreLogo;
        byte[] storeLogo;
        string shopName;
        string shopAddress;
        string shopPhone;

        public ReceiptPrintServer()
        {
            InitializeComponent();
        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {
            if (!NewReceiptsFetcher.IsBusy)
                NewReceiptsFetcher.RunWorkerAsync();
        }

        private void NewReceiptsFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable SystemSettings = Connection.server.RetrieveSystemSettings();

            DataTable dt = Connection.server.RetrieveSystemSettings();

            try
            {
                if (!Convert.IsDBNull(dt.Rows[0]["SystemLogo"]))
                {
                    this.storeLogo = (Byte[])(dt.Rows[0]["SystemLogo"]);
                    var stream = new MemoryStream(this.storeLogo);
                    StoreLogo = Image.FromStream(stream);
                }
                else
                {
                    StoreLogo = new Bitmap(Properties.Resources.plancksoft_b_t);
                }
            }
            catch (Exception err)
            {
                StoreLogo = new Bitmap(Properties.Resources.plancksoft_b_t);
            }

            this.shopName = dt.Rows[0]["SystemName"].ToString();
            this.shopPhone = dt.Rows[0]["SystemPhone"].ToString();
            this.shopAddress = dt.Rows[0]["SystemAddress"].ToString();

            UnprintedBills = Connection.server.RetrieveUnprintedBills().Item1;

            foreach(Bill UnprintedBill in UnprintedBills)
            {
                List<Item> itemsInBill = new List<Item>();

                foreach (Item UnprintedBillItem in UnprintedBill.ItemsBought)
                {
                    Item SearchedItem = Connection.server.SearchItems("", UnprintedBillItem.GetItemBarCode(), 0).Item1[0];
                    SearchedItem.SetQuantity(Connection.server.RetrieveBillSoldBItemQuantity(UnprintedBill.BillNumber, SearchedItem.GetItemBarCode()));
                    itemsInBill.Add(SearchedItem);
                }
                UnprintedBill.ItemsBought = itemsInBill;
                ItemsInBill = UnprintedBill.ItemsBought;
                Bill = UnprintedBill;

                List<Printer> PrintersToPrint = new List<Printer>();

                PrintersList = Connection.server.RetrievePrinters(Environment.MachineName);

                foreach (Item item in ItemsInBill)
                {
                    AdjustHeight();
                    bitmap = new Bitmap(342, InitialHeight + 865, PixelFormat.Format32bppArgb);
                    bitmapGraphic = Graphics.FromImage(bitmap);
                    bitmapGraphic.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);


                    foreach (Printer printer in PrintersList)
                    {
                        List<ItemType> ItemTypesInPrinterList = Connection.server.RetrievePrinterItemTypes(printer.ID);

                        foreach (ItemType itemTypeInPrinterList in ItemTypesInPrinterList)
                        {
                            if (item.GetItemTypeeID() == itemTypeInPrinterList.ID && !PrintersToPrint.Contains(printer))
                            {
                                PrintersToPrint.Add(printer);
                            }
                        }
                    }
                }

                if (PrintersToPrint.Count <= 0)
                {
                    break;
                }

                foreach (Dependencies.Printer printer in PrintersToPrint)
                {
                    printDocument1.PrinterSettings.PrinterName = printer.Name;
                    printDocument1.Print();
                }
            }
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            e.Graphics.DrawImage(StoreLogo, 0 + 80, 0 + Offset, 100, 30);
            bitmapGraphic.DrawImage(StoreLogo, 0 + 80, 0 + Offset, 100, 30);

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

            if (!String.Equals(Bill.ClientName, null) && !String.Equals(Bill.ClientName, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Client Name: " + Bill.ClientName, Offset);
            }

            if (!String.Equals(Bill.ClientAddress, null) && !String.Equals(Bill.ClientAddress, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Client Address: " + Bill.ClientAddress, Offset);
            }

            if (!String.Equals(Bill.ClientPhone, null) && !String.Equals(Bill.ClientPhone, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Client Phone #: " + Bill.ClientPhone, Offset);
            }

            if (!String.Equals(Bill.ClientEmail, null) && !String.Equals(Bill.ClientEmail, ""))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Client Email: " + Bill.ClientEmail, Offset);
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

                    bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour +
                        "-" + DateTime.Today.Minute + "-" + DateTime.Today.Second + "-" + DateTime.Today.Millisecond + " Receipt " +
                        Bill.getBillNumber() + ".png", ImageFormat.Png);

                    //bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour +
                    //    "-" + DateTime.Today.Minute + "-" + DateTime.Today.Second + "-" + DateTime.Today.Millisecond + " Receipt " +
                    //    Bill.getBillNumber() + ".jpeg", ImageFormat.Jpeg);
                }
                catch (Exception error)
                {

                }
            }
        }
    }
}
