using Dependencies;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PlancksoftPOS_Receipt_Print_Server
{
    public partial class ReceiptPrintServer : Form
    {
        public Connection Connection = new Connection();

        Bill Bill;
        Bill ReBill;
        List<Bill> UnprintedBills = new List<Bill>();
        List<Bill> ReprintedBills = new List<Bill>();

        List<Item> ItemsInBill;
        List<Item> ReprintedItemsInBill;

        public static List<Printer> PrintersList = new List<Printer>();
        public static List<Printer> RePrintersList = new List<Printer>();

        private PrintDocument PrintDocument;
        private PrintDocument RePrintDocument;

        Image StoreLogo;
        byte[] storeLogo;
        string shopName;
        string shopAddress;
        string shopPhone;

        static int width = 284; // or 284
        static int padding = 10;
        static int cellPadding = 6;
        static int lineHeight = 30;
        static Font fontRegular = new Font("Arial", 10);
        static Font fontBold = new Font("Arial", 12, FontStyle.Bold);

        int totalquantity = 0;
        int Retotalquantity = 0;
        int item_quantity = 0;
        int Reitem_quantity = 0;
        int currentRowIndex = 0;
        int RecurrentRowIndex = 0;

        string[] headers = new string[] { };
        string[] Reheaders = new string[] { };
        List<string[]> rows = new List<string[]>();
        List<string[]> Rerows = new List<string[]>();

        int y = 0;
        int Rey = 0;

        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public ReceiptPrintServer()
        {
            InitializeComponent();

            pickedLanguage = (LanguageChoice.Languages)Properties.Settings.Default.pickedLanguage;

            if (pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Checked = true;
                englishToolStripMenuItem.Checked = false;
                الخروجToolStripMenuItem.Text = "الخروج";
            } else if (pickedLanguage == LanguageChoice.Languages.English)
            {
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Checked = false;
                الخروجToolStripMenuItem.Text = "Quit";
                englishToolStripMenuItem.Checked = true;
            }
        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {
            if (!NewReceiptsFetcher.IsBusy)
                NewReceiptsFetcher.RunWorkerAsync();
            if (!reprintReceiptsFetcher.IsBusy)
                reprintReceiptsFetcher.RunWorkerAsync();
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

            UnprintedBills = Connection.server.RetrieveUnprintedBills(Environment.MachineName + "").Item1;

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
                    foreach (Printer printer in PrintersList)
                    {
                        if (printer.MachineName == Environment.MachineName)
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
                }

                string mainPrinterName = "";

                foreach (Printer printer in PrintersList)
                {
                    if (printer.MachineName == Environment.MachineName && printer.IsMainPrinter == 1)
                    {
                        mainPrinterName = printer.Name;
                        break;
                    }
                }

                try
                {

                    // ESC/POS Command: Open drawer 1, 200ms pulse
                    byte[] openDrawer = new byte[] { 0x1B, 0x70, 0x00, 0x40, 0x50 };

                    if (SendBytesToPrinter(mainPrinterName, openDrawer))
                        Console.WriteLine("Cash drawer opened.");
                    else
                        Console.WriteLine("Failed to open cash drawer.");
                }
                catch (Exception error)
                {
                    MaterialMessageBox.Show(e.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
                }

            if (PrintersToPrint.Count <= 0)
                {
                    break;
                }

                totalquantity = 0;
                item_quantity = 0;

                rows.Clear();

                foreach (Dependencies.Printer printer in PrintersToPrint)
                {
                    printDocument1.PrinterSettings.PrinterName = printer.Name;

                    // Use printer’s width in hundredths of an inch
                    int printerWidth = width; // ~72mm printer (adjust if needed)         
                                            // Table data (you can replace/add rows)
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        headers = new string[] { "اسم السلعة", "السعر", "الكمية"
                            //,"الخصم"
                            , "المجموع" };
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        headers = new string[] { "Item Name", "Price", "Quantity"
                            //, "Discount"
                            , "Total" };
                    }

                    foreach (var item in Bill.ItemsBought)
                    {
                        rows.Add(new string[] { item.ItemName, item.ItemPriceTax.ToString(), item.ItemQuantity.ToString()
                            //, "0.00"
                            , (item.ItemPriceTax * item.ItemQuantity).ToString() });

                        totalquantity += item.ItemQuantity;
                        item_quantity += 1;
                    }

                    using (Graphics g = this.CreateGraphics()) // Temporary graphics just for measuring
                    {
                        int height = MeasureReceiptHeight(
                            g,
                            fontRegular,
                            fontBold,
                            rows,
                            headers
                        );

                        // Set paper size dynamically
                        PaperSize ps = new PaperSize("CustomReceipt", 284, 1000000000);
                        printDocument1.DefaultPageSettings.PaperSize = ps;

                        // No margins, no origin shift
                        printDocument1.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        printDocument1.OriginAtMargins = false;
                        printDocument1.Print();
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);

            int imgHeight = 1200; // generous height, we'll crop later       

            imgHeight += StoreLogo.Height;
            imgHeight += lineHeight;

            foreach (var item in rows)
            {
                imgHeight +=  + lineHeight;
            }

            using (Bitmap bmp = new Bitmap(width, imgHeight))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                y = padding;

                y = DrawImage(g, ResizeImage(StoreLogo, 128, 128), y);

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y += DrawRightAndLeftUnbordered(g, "0776472166", "Plancksoft برمجة شركة", y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y += DrawRightAndLeftUnbordered(g, "0776472166", "Powered by Plancksoft", y, fontRegular);
                }

                // Header (centered, RTL-aware)    
                string storeName = shopName;
                y = DrawCenteredBlackFilledWhiteText(g, y, storeName);
                //y = DrawCenteredText(g, "رقم الدور: 6200", y, fontBold);
                y += 10;

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    if (Bill.TaxID == "Tax ID")
                    {
                        y = DrawLeftAlignedUnborderedText(g, "الرقم الضريبي: لا يوجد", y, fontRegular);
                    } else
                    {
                        y = DrawLeftAlignedUnborderedText(g, "الرقم الضريبي: " + Bill.TaxID, y, fontRegular);
                    }
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    if (Bill.TaxID == "Tax ID")
                    {
                        y = DrawLeftAlignedUnborderedText(g, "Tax ID: Not Available", y, fontRegular);
                    }
                    else
                    {
                        y = DrawLeftAlignedUnborderedText(g, "Tax ID: " + Bill.TaxID, y, fontRegular);
                    }
                }

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y += DrawRightAndLeftUnbordered(g, "عنوان المتجر", "رقم المتجر", y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y += DrawRightAndLeftUnbordered(g, "Store Address", "Store Phone Number", y, fontRegular);
                }
                y += DrawRightAndLeftUnbordered(g, shopAddress, shopPhone, y, fontRegular);

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y = DrawCenteredBorderedText(g, y, "فانوره رقم: " + Bill.BillNumber);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y = DrawCenteredBorderedText(g, y, "Invoice Number: " + Bill.BillNumber);
                }

                y += DrawRightAndLeftUnbordered(g, DateTime.Now.DayOfWeek.ToString(), String.Format("{0}", DateTime.Now.ToString("dd MMMM yyyy MM/dd h:mm:ss tt")), y, fontRegular);
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y = DrawCenteredText(g, "إسم الكاشير: " + Bill.CashierName, y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y = DrawCenteredText(g, "Cashier Name: " + Bill.CashierName, y, fontRegular);
                }

                if (Bill.ClientName.Trim().Length > 0 && Bill.ClientAddress.Trim().Length > 0)
                {
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftUnbordered(g, "إسم العميل: ", "عنوان العميل", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftUnbordered(g, "Client Name: ", "Client Address: ", y, fontRegular);
                    }
                    y = DrawCenteredText(g, Bill.ClientName, y, fontRegular);
                    y = DrawCenteredText(g, Bill.ClientAddress, y, fontRegular);
                }

                if (Bill.ClientPhone.Trim().Length > 0 && Bill.ClientEmail.Trim().Length > 0)
                {
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftUnbordered(g, "رقم العميل: ", ": بريد العميل", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftUnbordered(g, "Client Number: ", "Client Email: ", y, fontRegular);
                    }
                    y += DrawRightAndLeftUnbordered(g, Bill.ClientPhone, Bill.ClientEmail, y, fontRegular);
                }

                {

                    int availableWidth = width - 2 * padding;
                    int cols = headers.Length;
                    int[] colWidths = new int[cols];

                    // Measure required widths per column (based on headers + all row cells)
                    for (int c = 0; c < cols; c++)
                    {
                        float maxW = g.MeasureString(headers[c], fontRegular).Width;
                        foreach (var r in rows)
                        {
                            float w = g.MeasureString(r[c], fontRegular).Width;
                            if (w > maxW) maxW = w;
                        }
                        colWidths[c] = (int)Math.Ceiling(maxW) + 2 * cellPadding;
                    }

                    // If the table is wider than available width, scale columns down proportionally
                    int totalWidth = 0;
                    foreach (var w in colWidths) totalWidth += w;
                    int minColWidth = 40;
                    if (totalWidth > availableWidth)
                    {
                        float scale = (float)availableWidth / totalWidth;
                        totalWidth = 0;
                        for (int c = 0; c < cols; c++)
                        {
                            colWidths[c] = Math.Max(minColWidth, (int)(colWidths[c] * scale));
                            totalWidth += colWidths[c];
                        }
                    }
                    else
                    {
                        // recompute totalWidth in case it wasn't set above
                        totalWidth = 0;
                        foreach (var w in colWidths) totalWidth += w;
                    }

                    // Center the table horizontally
                    int startX = padding + (availableWidth - totalWidth) / 2;
                    int availableHeight = e.MarginBounds.Height;
                    int cellHeight = lineHeight;

                    // StringFormats
                    StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    StringFormat centerFormatRTL = new StringFormat(centerFormat) { FormatFlags = StringFormatFlags.DirectionRightToLeft };
                    StringFormat rightFormatRTL = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };

                    // Draw header row (with borders)
                    int x = startX;
                    for (int c = 0; c < cols; c++)
                    {
                        Rectangle rect = new Rectangle(x, y, colWidths[c], cellHeight);
                        g.DrawRectangle(Pens.Black, rect);
                        g.DrawString(headers[c], fontRegular, Brushes.Black, rect, centerFormatRTL);
                        x += colWidths[c];
                    }
                    y += cellHeight;

                    // Draw (items) rows (with borders)
                    foreach (var row in rows)
                    {
                        x = startX;
                        for (int c = 0; c < cols; c++)
                        {
                            Rectangle rect = new Rectangle(x, y, colWidths[c], cellHeight);
                            g.DrawRectangle(Pens.Black, rect);

                            string cellText = row[c] ?? string.Empty;
                            bool isNumeric = IsMostlyNumeric(cellText);

                            g.DrawString(cellText, fontRegular, Brushes.Black, rect,
                                isNumeric ? rightFormatRTL : centerFormatRTL);
                            x += colWidths[c];
                        }
                        y += cellHeight; 
                        
                        /*
                        // Check if we’ve reached the bottom of the page
                        if (y + cellHeight > availableHeight)
                        {
                            e.HasMorePages = true;
                            return; // stop and let PrintPage get called again
                        }
                        */
                    }

                    // Done printing items

                    y += 10;

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftCentered(g, "المدفوع: " + Bill.PaidAmount, "الباقي: " + ((Bill.getTotalAmount() - Bill.DiscountAmount) - Bill.paidAmount).ToString(), y, fontBold);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftCentered(g, "Paid: " + Bill.PaidAmount, "Remainder: " + ((Bill.getTotalAmount() - Bill.DiscountAmount) - Bill.paidAmount).ToString(), y, fontBold);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftCentered(g, "عدد الأصناف: " + item_quantity, "الكميات: " + totalquantity, y, fontBold);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftCentered(g, "Item Types Quantity: " + item_quantity, "Quantity: " + totalquantity, y, fontBold);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftCentered(g, "الخصم: " + Bill.DiscountAmount, "المجموع: " + Bill.getTotalAmount().ToString(), y, fontBold);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftCentered(g, "Discount: " + Bill.DiscountAmount, "Total: " + Bill.getTotalAmount().ToString(), y, fontBold);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredBorderedText(g, y, "الصافي: " + (Bill.getTotalAmount() - Bill.DiscountAmount).ToString());
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredBorderedText(g, y, "Net Total: " + (Bill.getTotalAmount() - Bill.DiscountAmount).ToString());
                    }

                    y += 10;

                    g.DrawLine(Pens.Black, 0, y, width, y);

                    y += 5;  // Optional spacing after line if needed

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, "شكرا لكم لزيارتكم", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Thank you for visiting", y, fontRegular);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, "الغاتورة شامله الضريبه", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Tax included in prices", y, fontRegular);
                    }

                    // Crop and save
                    int cropHeight = Math.Min(y + padding, imgHeight);
                    using (Bitmap cropped = bmp.Clone(new Rectangle(0, 0, width, cropHeight), bmp.PixelFormat))
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

                            // Draw the bitmap onto the printer graphics at the top-left corner
                            e.Graphics.DrawImage(cropped, 0, 0, width, cropHeight);

                            /*if (this.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    pbReceipt.Image = cropped;
                                    this.Height = imgHeight;
                                    this.Width = cropped.Width;
                                    pbReceipt.Height = imgHeight;
                                    pbReceipt.Width = cropped.Width;
                                }));
                            }
                            else
                            {
                                pbReceipt.Image = cropped;
                                this.Height = imgHeight;
                                this.Width = cropped.Width;
                                pbReceipt.Height = imgHeight;
                                pbReceipt.Width = cropped.Width;
                            }*/

                            cropped.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour +
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

        private int MeasureReceiptHeight(Graphics g, Font fontRegular, Font fontBold, List<string[]> rows, string[] headers)
        {
            int y = 0;
            int cellHeight = lineHeight;

            // Header row
            y += cellHeight;

            // Rows
            y += rows.Count * cellHeight;

            // Add any extra space for logos, store info, totals, etc.
            y += 200; // Adjust this if needed for top/bottom margins

            return y;
        }

        static bool IsMostlyNumeric(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            int digits = 0, chars = 0;
            foreach (char ch in s)
            {
                if (char.IsDigit(ch) || ch == '.' || ch == ',') digits++;
                if (!char.IsWhiteSpace(ch)) chars++;
            }
            return chars > 0 && ((double)digits / chars) > 0.5;
        }

        static int DrawCenteredBlackFilledWhiteText(Graphics g, int y, string storeName)
        {
            Font storeFont = new Font("Tahoma", 18, FontStyle.Bold);
            SizeF storeSize = g.MeasureString(storeName, storeFont);
            g.FillRectangle(Brushes.Black, 0, y, width, storeSize.Height + 10);
            g.DrawString(storeName, storeFont, Brushes.White, new PointF((width - storeSize.Width) / 2, y + 5));
            return y + (int)storeSize.Height + 10;
        }

        static int DrawCenteredBorderedText(Graphics g, int y, string text)
        {
            Font storeFont = new Font("Tahoma", 12, FontStyle.Bold);
            // Measure text
            SizeF textSize = g.MeasureString(text, storeFont);

            // Calculate rectangle size (text + padding)
            float rectWidth = textSize.Width + padding * 2;
            float rectHeight = textSize.Height + padding * 2;

            // Calculate X so that the rectangle is centered
            float rectX = (width - rectWidth) / 2;

            // Draw rectangle around text
            g.DrawRectangle(Pens.Black, rectX, y, rectWidth, rectHeight);

            // Draw centered text inside the rectangle
            g.DrawString(
                text,
                storeFont,
                Brushes.Black,
                new RectangleF(rectX, y, rectWidth, rectHeight),
                new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                }
            );

            // Return the new Y position after the rectangle
            return (int)(y + rectHeight);
        }

        static int DrawCenteredText(Graphics g, string text, int y, Font font)
        {
            RectangleF rect = new RectangleF(0, y, width, lineHeight);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            g.DrawString(text, font, Brushes.Black, rect, sf);
            return y + lineHeight;
        }

        static int DrawRightAlignedText(Graphics g, string text, int y, Font font)
        {
            RectangleF rect = new RectangleF(padding, y, width - 2 * padding, lineHeight);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            g.DrawString(text, font, Brushes.Black, rect, sf);
            return y + lineHeight;
        }

        static int DrawRightAndLeftCentered(Graphics g, string rightText, string leftText, int y, Font font)
        {
            int rowHeight = lineHeight;
            int horizontalPadding = padding;

            // Measure text sizes + padding for rectangles
            SizeF leftSize = g.MeasureString(leftText, font);
            float leftRectWidth = leftSize.Width + horizontalPadding * 2;

            SizeF rightSize = g.MeasureString(rightText, font);
            float rightRectWidth = rightSize.Width + horizontalPadding * 2;

            // Define gap between rectangles (you can adjust this)
            int gap = 10;

            // Total width of both rectangles + gap
            float totalWidth = leftRectWidth + rightRectWidth + gap;

            // Start X to horizontally center both rectangles as a group
            float startX = (width - totalWidth) / 2f;

            // Left rectangle position
            float leftRectX = startX;

            // Right rectangle position (right after left rect + gap)
            float rightRectX = startX + leftRectWidth + gap;

            // Draw left rectangle and centered text
            RectangleF leftRect = new RectangleF(leftRectX, y, leftRectWidth, rowHeight);
            g.DrawRectangle(Pens.Black, Rectangle.Round(leftRect));
            g.DrawString(
                leftText,
                font,
                Brushes.Black,
                leftRect,
                new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                }
            );

            // Draw right rectangle and centered text (RTL)
            RectangleF rightRect = new RectangleF(rightRectX, y, rightRectWidth, rowHeight);
            g.DrawRectangle(Pens.Black, Rectangle.Round(rightRect));
            g.DrawString(
                rightText,
                font,
                Brushes.Black,
                rightRect,
                new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                }
            );

            return rowHeight;
        }
        public static Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resized;
        }

        static int DrawImage(Graphics g, System.Drawing.Image img, int y)
        {
            // Get actual image size
            float logoWidth = img.Width;
            float logoHeight = img.Height;

            // Calculate centered X position
            float x = (width - logoWidth) / 2f;

            // Draw image at the given y
            g.DrawImage(img, x, y, logoWidth, logoHeight);

            // Return the new y position after the image
            return y + (int)logoHeight;
        }

        static int DrawRightAndLeftUnbordered(Graphics g, string rightText, string leftText, int y, Font font)
        {
            int rowHeight = lineHeight;

            // Measure text sizes (not really needed if no rectangles, but can keep for alignment)
            SizeF rightSize = g.MeasureString(rightText, font);
            float rightRectWidth = rightSize.Width + padding * 2;
            float rightRectX = width - rightRectWidth;

            SizeF leftSize = g.MeasureString(leftText, font);
            float leftRectWidth = leftSize.Width + padding * 2;
            float leftRectX = 0;

            // Draw right text aligned to the right side inside its area
            RectangleF rightRect = new RectangleF(rightRectX, y, rightRectWidth, rowHeight);
            g.DrawString(
                rightText,
                font,
                Brushes.Black,
                rightRect,
                new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                }
            );

            // Draw left text aligned to the left side inside its area
            RectangleF leftRect = new RectangleF(leftRectX, y, leftRectWidth, rowHeight);
            g.DrawString(
                leftText,
                font,
                Brushes.Black,
                leftRect,
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                }
            );

            // Return the vertical space consumed
            return rowHeight;
        }

        static int DrawRightAndLeft(Graphics g, string rightText, string leftText, int y, Font font)
        {
            int verticalPadding = 4; // smaller padding for vertical space

            // Fixed height for row
            int rowHeight = lineHeight;

            // Measure right text width
            SizeF rightSize = g.MeasureString(rightText, font);
            float rightRectWidth = rightSize.Width + padding * 2;
            float rightRectX = width - rightRectWidth;

            // Measure left text width
            SizeF leftSize = g.MeasureString(leftText, font);
            float leftRectWidth = leftSize.Width + padding * 2;
            float leftRectX = 0;

            // Draw right rectangle and text
            RectangleF rightRect = new RectangleF(rightRectX, y, rightRectWidth, rowHeight);
            g.DrawRectangle(Pens.Black, Rectangle.Round(rightRect));
            g.DrawString(
                rightText,
                font,
                Brushes.Black,
                rightRect,
                new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                }
            );

            // Draw left rectangle and text
            RectangleF leftRect = new RectangleF(leftRectX, y, leftRectWidth, rowHeight);
            g.DrawRectangle(Pens.Black, Rectangle.Round(leftRect));
            g.DrawString(
                leftText,
                font,
                Brushes.Black,
                leftRect,
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                }
            );

            // Return the new y position after this row
            return rowHeight;
        }

        static int DrawRightAlignedBorderedText(Graphics g, string text, int y, Font font)
        {
            // Measure text
            SizeF textSize = g.MeasureString(text, font);

            // Rectangle size (text + padding)
            float rectWidth = textSize.Width + padding * 2;
            float rectHeight = textSize.Height + padding * 2;

            // Position rectangle so its right edge is at the receipt's right edge
            float rectX = width - rectWidth;

            // Draw rectangle
            g.DrawRectangle(Pens.Black, rectX, y, rectWidth, rectHeight);

            // Draw right-aligned text inside the rectangle
            g.DrawString(
                text,
                font,
                Brushes.Black,
                new RectangleF(rectX, y, rectWidth, rectHeight),
                new StringFormat
                {
                    Alignment = StringAlignment.Far, // Right-align text
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft // Helps with Arabic text
                }
            );

            return (int)(y + rectHeight);
        }

        static int DrawLeftAlignedBorderedText(Graphics g, string text, int y, Font font)
        {
            // Measure text
            SizeF textSize = g.MeasureString(text, font);

            // Rectangle size (text + padding)
            float rectWidth = textSize.Width + padding * 2;
            float rectHeight = textSize.Height + padding * 2;

            // Position rectangle at the left side
            float rectX = 0;

            // Draw rectangle
            g.DrawRectangle(Pens.Black, rectX, y, rectWidth, rectHeight);

            // Draw left-aligned text inside the rectangle
            g.DrawString(
                text,
                font,
                Brushes.Black,
                new RectangleF(rectX, y, rectWidth, rectHeight),
                new StringFormat
                {
                    Alignment = StringAlignment.Near, // Left align text
                    LineAlignment = StringAlignment.Center
                }
            );

            return (int)(y + rectHeight);
        }

        static int DrawLeftAlignedUnborderedText(Graphics g, string text, int y, Font font)
        {
            // Measure text
            SizeF textSize = g.MeasureString(text, font);

            // Rectangle size (text + padding)
            float rectWidth = textSize.Width + padding * 2;
            float rectHeight = textSize.Height + padding * 2;

            // Position rectangle at the left side
            float rectX = 0;

            // Draw left-aligned text inside the rectangle
            g.DrawString(
                text,
                font,
                Brushes.Black,
                new RectangleF(rectX, y, rectWidth, rectHeight),
                new StringFormat
                {
                    Alignment = StringAlignment.Near, // Left align text
                    LineAlignment = StringAlignment.Center
                }
            );

            return (int)(y + rectHeight);
        }

        private void العربيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اللغةToolStripMenuItem.Text = "اللغة";
            pickedLanguage = LanguageChoice.Languages.Arabic;
            Properties.Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.Arabic;
            Properties.Settings.Default.Save();
            العربيةToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Checked = false;
            الخروجToolStripMenuItem.Text = "الخروج";
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اللغةToolStripMenuItem.Text = "Language";
            pickedLanguage = LanguageChoice.Languages.English;
            Properties.Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.English;
            Properties.Settings.Default.Save();
            العربيةToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
            الخروجToolStripMenuItem.Text = "Quit";
        }

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        public static bool SendBytesToPrinter(string szPrinterName, byte[] bytes)
        {
            IntPtr hPrinter;
            DOCINFOA di = new DOCINFOA();
            di.pDocName = "Open Cash Drawer";
            di.pDataType = "RAW";

            bool success = false;
            if (OpenPrinter(szPrinterName, out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(bytes.Length);
                        Marshal.Copy(bytes, 0, pUnmanagedBytes, bytes.Length);
                        success = WritePrinter(hPrinter, pUnmanagedBytes, bytes.Length, out _);
                        Marshal.FreeCoTaskMem(pUnmanagedBytes);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            return success;
        }

        private void reprintReceiptsFetcher_DoWork(object sender, DoWorkEventArgs e)
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

            ReprintedBills = Connection.server.RetrieveReprintedBills(Environment.MachineName).Item1;

            foreach (Bill ReprintedBill in ReprintedBills)
            {
                List<Item> itemsInBill = new List<Item>();

                foreach (Item ReprintedBillItem in ReprintedBill.ItemsBought)
                {
                    Item SearchedItem = Connection.server.SearchItems("", ReprintedBillItem.GetItemBarCode(), 0).Item1[0];
                    SearchedItem.SetQuantity(Connection.server.RetrieveBillSoldBItemQuantity(ReprintedBill.BillNumber, SearchedItem.GetItemBarCode()));
                    itemsInBill.Add(SearchedItem);
                }
                ReprintedBill.ItemsBought = itemsInBill;
                ItemsInBill = ReprintedBill.ItemsBought;
                ReBill = ReprintedBill;

                List<Printer> PrintersToPrint = new List<Printer>();

                RePrintersList = Connection.server.RetrievePrinters(Environment.MachineName);

                foreach (Item item in ItemsInBill)
                {
                    foreach (Printer printer in RePrintersList)
                    {
                        if (printer.MachineName == Environment.MachineName)
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
                }

                string mainPrinterName = "";

                foreach (Printer printer in RePrintersList)
                {
                    if (printer.MachineName == Environment.MachineName && printer.IsMainPrinter == 1)
                    {
                        mainPrinterName = printer.Name;
                        break;
                    }
                }

                if (PrintersToPrint.Count <= 0)
                {
                    break;
                }

                Retotalquantity = 0;
                Reitem_quantity = 0;

                Rerows.Clear();

                foreach (Dependencies.Printer printer in PrintersToPrint)
                {
                    printDocument1.PrinterSettings.PrinterName = printer.Name;

                    // Use printer’s width in hundredths of an inch
                    int printerWidth = width; // ~72mm printer (adjust if needed)         
                                              // Table data (you can replace/add rows)
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        Reheaders = new string[] { "اسم السلعة", "السعر", "الكمية"
                            //,"الخصم"
                            , "المجموع" };
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        Reheaders = new string[] { "Item Name", "Price", "Quantity"
                            //, "Discount"
                            , "Total" };
                    }

                    foreach (var item in ReBill.ItemsBought)
                    {
                        Rerows.Add(new string[] { item.ItemName, item.ItemPriceTax.ToString(), item.ItemQuantity.ToString()
                            //, "0.00"
                            , (item.ItemPriceTax * item.ItemQuantity).ToString() });

                        Retotalquantity += item.ItemQuantity;
                        Reitem_quantity += 1;
                    }

                    using (Graphics g = this.CreateGraphics()) // Temporary graphics just for measuring
                    {
                        int height = MeasureReceiptHeight(
                            g,
                            fontRegular,
                            fontBold,
                            rows,
                            headers
                        );

                        // Set paper size dynamically
                        PaperSize ps = new PaperSize("CustomReceipt", 284, 1000000000);
                        printDocument2.DefaultPageSettings.PaperSize = ps;

                        // No margins, no origin shift
                        printDocument2.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        printDocument2.OriginAtMargins = false;
                        printDocument2.Print();
                    }
                }
            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);

            int imgHeight = 1200; // generous height, we'll crop later       

            imgHeight += StoreLogo.Height;
            imgHeight += lineHeight;

            foreach (var item in rows)
            {
                imgHeight += +lineHeight;
            }

            using (Bitmap bmp = new Bitmap(width, imgHeight))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                y = padding;

                y = DrawImage(g, ResizeImage(StoreLogo, 128, 128), y);

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y += DrawRightAndLeftUnbordered(g, "0776472166", "Plancksoft برمجة شركة", y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y += DrawRightAndLeftUnbordered(g, "0776472166", "Powered by Plancksoft", y, fontRegular);
                }

                // Header (centered, RTL-aware)    
                string storeName = shopName;
                y = DrawCenteredBlackFilledWhiteText(g, y, storeName);
                //y = DrawCenteredText(g, "رقم الدور: 6200", y, fontBold);
                y += 10;

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    if (ReBill.TaxID == "Tax ID")
                    {
                        y = DrawLeftAlignedUnborderedText(g, "الرقم الضريبي: لا يوجد", y, fontRegular);
                    }
                    else
                    {
                        y = DrawLeftAlignedUnborderedText(g, "الرقم الضريبي: " + Bill.TaxID, y, fontRegular);
                    }
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    if (ReBill.TaxID == "Tax ID")
                    {
                        y = DrawLeftAlignedUnborderedText(g, "Tax ID: Not Available", y, fontRegular);
                    }
                    else
                    {
                        y = DrawLeftAlignedUnborderedText(g, "Tax ID: " + Bill.TaxID, y, fontRegular);
                    }
                }

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y += DrawRightAndLeftUnbordered(g, "عنوان المتجر", "رقم المتجر", y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y += DrawRightAndLeftUnbordered(g, "Store Address", "Store Phone Number", y, fontRegular);
                }
                y += DrawRightAndLeftUnbordered(g, shopAddress, shopPhone, y, fontRegular);

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y = DrawCenteredText(g, "إعادة طباعة فانوره رقم " + ReBill.BillNumber, y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y = DrawCenteredText(g, "Reprint of Invoice Number: " + ReBill.BillNumber, y, fontRegular);
                }

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y = DrawCenteredBorderedText(g, y, "فانوره رقم: " + ReBill.BillNumber);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y = DrawCenteredBorderedText(g, y, "Invoice Number: " + ReBill.BillNumber);
                }

                y += DrawRightAndLeftUnbordered(g, DateTime.Now.DayOfWeek.ToString(), String.Format("{0}", DateTime.Now.ToString("dd MMMM yyyy MM/dd h:mm:ss tt")), y, fontRegular);
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    y = DrawCenteredText(g, "إسم الكاشير: " + ReBill.CashierName, y, fontRegular);
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    y = DrawCenteredText(g, "Cashier Name: " + ReBill.CashierName, y, fontRegular);
                }

                if (ReBill.ClientName.Trim().Length > 0 && ReBill.ClientAddress.Trim().Length > 0)
                {
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftUnbordered(g, "إسم العميل: ", "عنوان العميل", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftUnbordered(g, "Client Name: ", "Client Address: ", y, fontRegular);
                    }
                    y = DrawCenteredText(g, ReBill.ClientName, y, fontRegular);
                    y = DrawCenteredText(g, ReBill.ClientAddress, y, fontRegular);
                }

                if (ReBill.ClientPhone.Trim().Length > 0 && ReBill.ClientEmail.Trim().Length > 0)
                {
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftUnbordered(g, "رقم العميل: ", ": بريد العميل", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftUnbordered(g, "Client Number: ", "Client Email: ", y, fontRegular);
                    }
                    y += DrawRightAndLeftUnbordered(g, ReBill.ClientPhone, ReBill.ClientEmail, y, fontRegular);
                }

                {

                    int availableWidth = width - 2 * padding;
                    int cols = Reheaders.Length;
                    int[] colWidths = new int[cols];

                    // Measure required widths per column (based on headers + all row cells)
                    for (int c = 0; c < cols; c++)
                    {
                        float maxW = g.MeasureString(Reheaders[c], fontRegular).Width;
                        foreach (var r in rows)
                        {
                            float w = g.MeasureString(r[c], fontRegular).Width;
                            if (w > maxW) maxW = w;
                        }
                        colWidths[c] = (int)Math.Ceiling(maxW) + 2 * cellPadding;
                    }

                    // If the table is wider than available width, scale columns down proportionally
                    int totalWidth = 0;
                    foreach (var w in colWidths) totalWidth += w;
                    int minColWidth = 40;
                    if (totalWidth > availableWidth)
                    {
                        float scale = (float)availableWidth / totalWidth;
                        totalWidth = 0;
                        for (int c = 0; c < cols; c++)
                        {
                            colWidths[c] = Math.Max(minColWidth, (int)(colWidths[c] * scale));
                            totalWidth += colWidths[c];
                        }
                    }
                    else
                    {
                        // recompute totalWidth in case it wasn't set above
                        totalWidth = 0;
                        foreach (var w in colWidths) totalWidth += w;
                    }

                    // Center the table horizontally
                    int startX = padding + (availableWidth - totalWidth) / 2;
                    int availableHeight = e.MarginBounds.Height;
                    int cellHeight = lineHeight;

                    // StringFormats
                    StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    StringFormat centerFormatRTL = new StringFormat(centerFormat) { FormatFlags = StringFormatFlags.DirectionRightToLeft };
                    StringFormat rightFormatRTL = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };

                    // Draw header row (with borders)
                    int x = startX;
                    for (int c = 0; c < cols; c++)
                    {
                        Rectangle rect = new Rectangle(x, y, colWidths[c], cellHeight);
                        g.DrawRectangle(Pens.Black, rect);
                        g.DrawString(Reheaders[c], fontRegular, Brushes.Black, rect, centerFormatRTL);
                        x += colWidths[c];
                    }
                    y += cellHeight;

                    // Draw (items) rows (with borders)
                    foreach (var row in Rerows)
                    {
                        x = startX;
                        for (int c = 0; c < cols; c++)
                        {
                            Rectangle rect = new Rectangle(x, y, colWidths[c], cellHeight);
                            g.DrawRectangle(Pens.Black, rect);

                            string cellText = row[c] ?? string.Empty;
                            bool isNumeric = IsMostlyNumeric(cellText);

                            g.DrawString(cellText, fontRegular, Brushes.Black, rect,
                                isNumeric ? rightFormatRTL : centerFormatRTL);
                            x += colWidths[c];
                        }
                        y += cellHeight;

                        /*
                        // Check if we’ve reached the bottom of the page
                        if (y + cellHeight > availableHeight)
                        {
                            e.HasMorePages = true;
                            return; // stop and let PrintPage get called again
                        }
                        */
                    }

                    // Done printing items

                    y += 10;

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftCentered(g, "المدفوع: " + ReBill.PaidAmount, "الباقي: " + ((ReBill.getTotalAmount() - ReBill.DiscountAmount) - ReBill.paidAmount).ToString(), y, fontBold);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftCentered(g, "Paid: " + ReBill.PaidAmount, "Remainder: " + ((ReBill.getTotalAmount() - ReBill.DiscountAmount) - ReBill.paidAmount).ToString(), y, fontBold);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftCentered(g, "عدد الأصناف: " + Reitem_quantity, "الكميات: " + Retotalquantity, y, fontBold);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftCentered(g, "Item Types Quantity: " + Reitem_quantity, "Quantity: " + Retotalquantity, y, fontBold);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftCentered(g, "الخصم: " + ReBill.DiscountAmount, "المجموع: " + ReBill.getTotalAmount().ToString(), y, fontBold);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftCentered(g, "Discount: " + ReBill.DiscountAmount, "Total: " + ReBill.getTotalAmount().ToString(), y, fontBold);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredBorderedText(g, y, "الصافي: " + (ReBill.getTotalAmount() - ReBill.DiscountAmount).ToString());
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredBorderedText(g, y, "Net Total: " + (ReBill.getTotalAmount() - ReBill.DiscountAmount).ToString());
                    }

                    y += 10;

                    g.DrawLine(Pens.Black, 0, y, width, y);

                    y += 5;  // Optional spacing after line if needed

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, "شكرا لكم لزيارتكم", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Thank you for visiting", y, fontRegular);
                    }

                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, "الغاتورة شامله الضريبه", y, fontRegular);
                    }
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Tax included in prices", y, fontRegular);
                    }

                    // Crop and save
                    int cropHeight = Math.Min(y + padding, imgHeight);
                    using (Bitmap cropped = bmp.Clone(new Rectangle(0, 0, width, cropHeight), bmp.PixelFormat))
                    {
                        try
                        {

                            // Draw the bitmap onto the printer graphics at the top-left corner
                            e.Graphics.DrawImage(cropped, 0, 0, width, cropHeight);
                        }
                        catch (Exception error)
                        {

                        }
                    }
                }

            }
        }
    }
}
