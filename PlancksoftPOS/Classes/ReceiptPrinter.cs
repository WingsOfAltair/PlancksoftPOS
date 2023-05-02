using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependencies;
using Newtonsoft.Json.Linq;

namespace PlancksoftPOS
{
    internal class ReceiptPrinter
    {
        private PrintDocument PrintDocument;
        private Graphics graphics;
        private int InitialHeight = 360;
        Bill bill;
        string shopName;
        string shopAddress;
        string shopPhone;
        public ReceiptPrinter(Bill bill, string shopName, string shopAddress, string shopPhone)
        {
            this.bill = bill;
            this.shopName = shopName;
            this.shopAddress = shopAddress;
            this.shopPhone = shopPhone;
            AdjustHeight();
        }
        private void AdjustHeight()
        {
            var capacity = 5 * bill.ItemsBought.Capacity;
            InitialHeight += capacity;

            capacity = 5 * bill.ItemsBought.Capacity;
            InitialHeight += capacity;
        }
        public void Print(string printername)
        {
            PrintDocument = new PrintDocument();
            PrintDocument.PrinterSettings.PrinterName = printername;

            PrintDocument.PrintPage += new PrintPageEventHandler(FormatPage);
            PrintDocument.Print();
        }
        void DrawAtStart(string text, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font minifont = new Font("Arial", 5);

            graphics.DrawString(text, minifont,
                     new SolidBrush(Color.Black), startX + 5, startY + Offset);
        }
        void InsertItem(string key, string value, int Offset)
        {
            Font minifont = new Font("Arial", 5);
            int startX = 10;
            int startY = 5;

            graphics.DrawString(key, minifont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, minifont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void InsertHeaderStyleItem(string key, string value, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font itemfont = new Font("Arial", 6, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, itemfont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void DrawLine(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        void DrawSimpleString(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        private void FormatPage(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            //Image image = Resources.logo;
            //e.Graphics.DrawImage(image, startX + 50, startY + Offset, 100, 30);

            //graphics.DrawString("Welcome to HOT AND CRISPY", smallfont,
            //      new SolidBrush(Color.Black), startX + 22, startY + Offset);

            Offset = Offset + largeinc + 10;

            String underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            DrawAtStart("Invoice Number: " + bill.BillNumber, Offset);

            if (!String.Equals(this.shopAddress, "N/A"))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Address: " + this.shopAddress, Offset);
            }

            if (!String.Equals(this.shopPhone, "N/A"))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Phone # : " + this.shopPhone, Offset);
            }

            Offset = Offset + mediuminc;
            DrawAtStart("Date: " + bill.getDate(), Offset);

            Offset = Offset + smallinc;
            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            Offset = Offset + largeinc;
            foreach (var item in bill.ItemsBought)
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
            InsertItem(" Net. Total: ", bill.getTotalAmount().ToString(), Offset);//getTotalAmount().CValue

            //if (!order.Cash.Discount.IsZero())
            //{
            //    Offset = Offset + smallinc;
            //    InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
            //}

            Offset = Offset + smallinc;
            InsertHeaderStyleItem(" Amount Payable: ", bill.getTotalAmount().ToString(), Offset); // GrossTotal.CValue

            Offset = Offset + largeinc;
            String address = shopAddress;
            DrawSimpleString("Address: " + address, minifont, Offset, 15);

            Offset = Offset + smallinc;
            String number = "Tel: " + shopPhone;// + " - OR - " + shop.Phone2;
            DrawSimpleString(number, minifont, Offset, 35);

            Offset = Offset + 7;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            String greetings = "Thanks for visiting us.";
            DrawSimpleString(greetings, mediumfont, Offset, 28);

            Offset = Offset + mediuminc;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset += (2 * mediuminc);
            string tip = "TIP: -----------------------------";
            InsertItem(tip, "", Offset);

            Offset = Offset + largeinc;
            string DrawnBy = shopName + ": " + shopPhone;//"Meganos Softwares: 0312-0459491 - OR - 0321-6228321";
            DrawSimpleString(DrawnBy, minifont, Offset, 15);
        }
    }
}
