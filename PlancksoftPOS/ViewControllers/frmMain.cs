using PlancksoftPOS.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using WMPLib;
using System.Text;
using System.IO.Ports;
using Dependencies;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PlancksoftPOS
{

    public partial class frmMain : MaterialForm
    {
        public Form openedForm = null;
        public Connection Connection = new Connection();
        public int ID = 0, CurrentBillNumber = 0, CurrentVendorBillNumber = 0, customerItemID = 0, heldBillsCount = 0, EmployeeID = 0, AbsenceID = 0;
        public static int Authority = 0;
        public string CurrentItemBarcode = "", BarCode = "", cashierName = "Developer Mode", UID, PWD, PlancksoftPOSName, PlancksoftPOSPhone, printerName, printerName2, printerName3;
        public Tuple<List<Item>, DataTable> FavoriteItems;
        public Stack<Bill> previousBillsList = new Stack<Bill>();
        public Stack<Bill> nextBillsList = new Stack<Bill>();
        public decimal totalAmount = 0, totalVendorAmount = 0, paidAmount = 0, remainderAmount = 0, moneyInRegister = 0, moneyInRegisterInitial = 0;
        public List<Item> saleItems = new List<Item>();
        public List<Item> customersaleItems = new List<Item>();
        public List<Item> DISCOUNT_ITEMS = new List<Item>();
        public List<Item> ItemsList, retrievedFavoriteItems;
        public List<Account> Users;
        public static List<Printer> PrintersList = new List<Printer>();
        public List<Category> Categories = new List<Category>();
        public List<ItemType> ItemTypesList = new List<ItemType>();
        public List<Warehouse> WarehousesList = new List<Warehouse>();
        public Customer currentCustomer;
        public decimal CapitalAmount, TaxRate;
        public int PrintBillNumber = 0;
        public SortedList<int, string> itemtypes = new SortedList<int, string>();
        public SortedList<int, string> warehouses = new SortedList<int, string>();
        public SortedList<int, string> favorites = new SortedList<int, string>();
        public SortedList<int, string> printers = new SortedList<int, string>();
        public string ScannedBarCode = "";
        public bool timerstarted = false, registerOpen = false, IncludeLogoInReceipt = false;
        decimal capital, taxRate;
        TextBox AddItemType;
        List<TextBox> ItemTypeNamestxt = new List<TextBox>();
        PictureBox plusItemTypePB, minusItemTypePB;
        System.Windows.Forms.Label plusItemTypeLbl, ItemTypeLbl;
        TextBox AddWarehouse;
        List<TextBox> WarehouseNamestxt = new List<TextBox>();
        PictureBox plusWarehousePB, minusWarehousePB;
        Label plusWarehouseLbl, WarehouseLbl;
        TextBox AddFavorite;
        TextBox AddPrinter;
        List<TextBox> FavoriteNamestxt = new List<TextBox>();
        List<TreeView> PrintersNamesTV = new List<TreeView>();
        PictureBox plusFavoritePB, minusFavoritePB;
        PictureBox plusPrinterPB, minusPrinterPB;
        Label plusFavoriteLbl, FavoriteLbl;
        Label plusPrinterLbl, PrinterLbl;
        List<FlowLayoutPanel> flowLayoutPanels = new List<FlowLayoutPanel>();
        Button saveItemTypesBtn;
        Button saveWarehousesBtn;
        Button saveFavoritesBtn;
        Button savePrintersBtn;
        byte[] StoreLogo = null;
        List<ContextMenu> PrintersMenus = null;

        TabPage AgentsTab = null, InventoryTab = null, ExpensesTab = null, posUsersTab = null, SettingsTab = null, EmployeesTab = null, EditInvoicesTab = null,
            TravelingUntravelingSalesTab = null, SoldItemsTab = null, IncomingOutgoingTab = null, SalesTab = null, TaxesTab = null;

        public Account userPermissions;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public class Items
        {
            public string Name;
            public Items(string Name)
            {
                this.Name = Name;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public class ItemTypeCategory
        {
            public string Name;
            public ItemTypeCategory(string Name)
            {
                this.Name = Name;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public class WarehouseCategory
        {
            public string Name;
            public WarehouseCategory(string Name)
            {
                this.Name = Name;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public class FavoriteCategory
        {
            public string Name;
            public FavoriteCategory(string Name)
            {
                this.Name = Name;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public void refreshSettings()
        {
            Program.materialSkinManager = MaterialSkinManager.Instance;
            Program.materialSkinManager.EnforceBackcolorOnAllComponents = true;

            if (Properties.Settings.Default.pickedThemeScheme == (int)ThemeSchemeChoice.ThemeScheme.Dark)
            {
                switchThemeScheme.Checked = Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark));
                Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.DeepOrange400, Primary.Orange100, Accent.Orange100, TextShade.BLACK);
            }
            else
            {
                switchThemeScheme.Checked = Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Light));
                Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.BLACK);
            }
            DataTable dt = Connection.server.RetrieveSystemSettings();

            try
            {
                if (!Convert.IsDBNull(dt.Rows[0]["SystemLogo"]))
                {
                    StoreLogo = (Byte[])(dt.Rows[0]["SystemLogo"]);
                    var stream = new MemoryStream(StoreLogo);
                    picLogoStore.Image = Image.FromStream(stream);
                    picLogo.Image = Image.FromStream(stream);
                }
                else
                {
                    picLogoStore.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                    picLogo.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                }
            }
            catch (Exception err)
            {
                picLogoStore.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                picLogo.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
            }


            taxRate = Convert.ToDecimal(dt.Rows[0]["SystemTax"].ToString());
            nudTaxRate.Value = Convert.ToDecimal(taxRate * 100);
            TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);

            this.PlancksoftPOSName = dt.Rows[0]["SystemName"].ToString();
            this.shopName.Text = dt.Rows[0]["SystemName"].ToString();
            this.shopPhone.Text = dt.Rows[0]["SystemPhone"].ToString();
            this.Text = this.PlancksoftPOSName + " - الشاشه الرئيسيه";
            label45.Text = " هذه النسخه مرخصه لمتجر " + this.PlancksoftPOSName;
            this.receiptSpacingnud.Value = Convert.ToInt32(dt.Rows[0]["SystemReceiptBlankSpaces"].ToString());
            this.registerOpen = Properties.Settings.Default.RegisterOpen;
            this.IncludeLogoReceipt.Checked = Convert.ToBoolean(Convert.ToInt32(dt.Rows[0]["SystemIncludeLogoInReceipt"].ToString()));
            if (Convert.ToBoolean(Convert.ToInt32(dt.Rows[0]["SystemIncludeLogoInReceipt"].ToString())))
            {
                IncludeLogoInReceipt = true;
            }
            else
            {
                IncludeLogoInReceipt = false;
            }

            capital = Connection.server.GetCapitalAmount();
            CapitalAmountnud.Value = capital;
            CapitalAmount = capital;
        }

        public void applyAuthorityPermissions()
        {
            frmMain.Authority = Connection.server.RetrieveAccountAuthority(this.UID);
            this.userPermissions = Connection.server.RetrieveUserPermissions(this.UID);

            customer_card_edit.Checked = this.userPermissions.customer_card_edit;
            discount_edit.Checked = this.userPermissions.discount_edit;
            price_edit.Checked = this.userPermissions.price_edit;
            receipt_edit.Checked = this.userPermissions.receipt_edit;
            inventory_edit.Checked = this.userPermissions.inventory_edit;
            expenses_edit.Checked = this.userPermissions.expenses_add;
            users_edit.Checked = this.userPermissions.users_edit;
            settings_edit.Checked = this.userPermissions.settings_edit;
            personnel_edit.Checked = this.userPermissions.personnel_edit;
            openclose_edit.Checked = this.userPermissions.openclose_edit;

            if (!this.userPermissions.customer_card_edit)
            {
                pictureBox25.Enabled = false;
            }

            if (!this.userPermissions.discount_edit)
            {
                pictureBox11.Enabled = false;
            }

            if (!this.userPermissions.price_edit)
            {
                pictureBox26.Enabled = false;
            }

            if (tabControl1.Contains(tabControl1.TabPages["Agents"]))
                AgentsTab = tabControl1.TabPages["Agents"];
            if (!this.userPermissions.customer_card_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Agents"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Agents"]);
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Agents"]))
                    tabControl1.TabPages.Add(AgentsTab);
            }

            if (tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                InventoryTab = tabControl1.TabPages["Inventory"];
            if (!this.userPermissions.inventory_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Inventory"]);
                ادارةالمستودعToolStripMenuItem.Visible = false;
                ادارةالمستودعToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                    tabControl1.TabPages.Add(InventoryTab);
                ادارةالمستودعToolStripMenuItem.Visible = true;
                ادارةالمستودعToolStripMenuItem.Enabled = true;
            }

            if (tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                ExpensesTab = tabControl1.TabPages["Expenses"];
            if (!this.userPermissions.expenses_add)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Expenses"]);
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                    tabControl1.TabPages.Add(ExpensesTab);
            }

            if (tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                posUsersTab = tabControl1.TabPages["posUsers"];
            if (!this.userPermissions.users_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["posUsers"]);
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                    tabControl1.TabPages.Add(posUsersTab);
            }

            if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                SettingsTab = tabControl1.TabPages["Settings"];
            if (!this.userPermissions.settings_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Settings"]);
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Settings"]))
                    tabControl1.TabPages.Add(SettingsTab);
            }

            if (tabControl1.Contains(tabControl1.TabPages["Employees"]))
                EmployeesTab = tabControl1.TabPages["Employees"];
            if (!this.userPermissions.personnel_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Employees"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Employees"]);
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Employees"]))
                    tabControl1.TabPages.Add(EmployeesTab);
            }

            if (tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                EditInvoicesTab = tabControl4.TabPages["EditInvoices"];
            if (tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                TravelingUntravelingSalesTab = tabControl4.TabPages["TravelingUntravelingSales"];
            if (tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                SoldItemsTab = tabControl4.TabPages["SoldItems"];
            if (tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                IncomingOutgoingTab = tabControl4.TabPages["IncomingOutgoing"];
            if (tabControl1.Contains(tabControl1.TabPages["Sales"]))
                SalesTab = tabControl1.TabPages["Sales"];
            if (tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                TaxesTab = tabControl1.TabPages["Taxes"];
            if (!this.userPermissions.receipt_edit)
            {
                if (tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                    tabControl4.TabPages.Remove(tabControl4.TabPages["EditInvoices"]);
                if (tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                    tabControl4.TabPages.Remove(tabControl4.TabPages["TravelingUntravelingSales"]);
                if (tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                    tabControl4.TabPages.Remove(tabControl4.TabPages["SoldItems"]);
                if (tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["IncomingOutgoing"]);
                if (tabControl1.Contains(tabControl1.TabPages["Sales"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Sales"]);
                if (tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Taxes"]);
            }
            else
            {
                if (!tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                    tabControl4.TabPages.Add(EditInvoicesTab);
                if (!tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                    tabControl4.TabPages.Add(TravelingUntravelingSalesTab);
                if (!tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                    tabControl4.TabPages.Add(SoldItemsTab);
                if (!tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                    tabControl1.TabPages.Add(IncomingOutgoingTab);
                if (!tabControl1.Contains(tabControl1.TabPages["Sales"]))
                    tabControl1.TabPages.Add(SalesTab);
                if (!tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                    tabControl1.TabPages.Add(TaxesTab);
            }

            if (!this.userPermissions.openclose_edit)
            {
                openRegisterBtn.Enabled = false;
                closeRegisterBtn.Enabled = false;
                label65.Enabled = false;
                label66.Enabled = false;
            }
            else
            {
                if (registerOpen)
                {
                    openRegisterBtn.Enabled = false;
                    closeRegisterBtn.Enabled = true;
                } else
                {
                    openRegisterBtn.Enabled = true;
                    closeRegisterBtn.Enabled = false;
                }
                label65.Enabled = true;
                label66.Enabled = true;
            }
        }

        public frmMain(Account Account)
        {
            try
            {
                InitializeComponent();

                frmLogin.pickedLanguage = (LanguageChoice.Languages)Properties.Settings.Default.pickedLanguage;

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    العربيةToolStripMenuItem.Checked = true;
                    RightToLeft = RightToLeft.Yes;
                    RightToLeftLayout = true;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    englishToolStripMenuItem.Checked = true;
                    RightToLeft = RightToLeft.No;
                    RightToLeftLayout = false;
                }

                applyLocalizationOnUI();


                Program.materialSkinManager = MaterialSkinManager.Instance;
                Program.materialSkinManager.EnforceBackcolorOnAllComponents = true;

                if (Properties.Settings.Default.pickedThemeScheme == (int)ThemeSchemeChoice.ThemeScheme.Dark)
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.DeepOrange400, Primary.Orange100, Accent.Orange100, TextShade.BLACK);
                    switchThemeScheme.Checked = true;
                } else
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.BLACK);
                    switchThemeScheme.Checked = false;
                }

                DataTable dt = Connection.server.RetrieveSystemSettings();

                try
                {
                    if (!Convert.IsDBNull(dt.Rows[0]["SystemLogo"]))
                    {
                        StoreLogo = (Byte[])(dt.Rows[0]["SystemLogo"]);
                        var stream = new MemoryStream(StoreLogo);
                        picLogoStore.Image = Image.FromStream(stream);
                        picLogo.Image = Image.FromStream(stream);
                    } else
                    {
                        picLogoStore.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                        picLogo.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                    }
                } catch(Exception err)
                {
                    picLogoStore.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                    picLogo.Image = new Bitmap(Properties.Resources.plancksoft_b_t);
                }

                this.cashierName = Account.GetAccountName();
                this.cashierNameLbl.Text = this.cashierName;
                this.UID = Account.GetAccountUID();
                this.PWD = Account.GetAccountPWD();
                frmMain.Authority = Connection.server.RetrieveAccountAuthority(this.UID);

                applyAuthorityPermissions();

                taxRate = Convert.ToDecimal(dt.Rows[0]["SystemTax"].ToString());
                this.moneyInRegister = Properties.Settings.Default.moneyInRegister;
                this.moneyInRegisterInitial = Properties.Settings.Default.moneyInRegisterInitial;
                nudTaxRate.Value = Convert.ToDecimal(taxRate * 100);
                capital = Connection.server.GetCapitalAmount();
                CapitalAmountnud.Value = capital;
                CapitalAmount = capital;
                TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);

                this.saleItems = Connection.server.RetrieveSaleToday(DateTime.Now, 10);

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.AppendText("Current Bill ID: " + this.CurrentBillNumber);
                }

                Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveCustomers();

                dgvCustomers.DataSource = retrievedCustomers.Item2;
                
                this.PlancksoftPOSName = dt.Rows[0]["SystemName"].ToString();
                this.shopName.Text = dt.Rows[0]["SystemName"].ToString();
                this.shopPhone.Text = dt.Rows[0]["SystemPhone"].ToString();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    this.Text = this.PlancksoftPOSName + " - الشاشه الرئيسيه";
                    label45.Text = " هذه النسخه مرخصه لمتجر " + this.PlancksoftPOSName;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    this.Text = this.PlancksoftPOSName + " - Main Window";
                    label45.Text = "This copy is licensed for " + this.PlancksoftPOSName;
                }
                this.receiptSpacingnud.Value = Convert.ToInt32(dt.Rows[0]["SystemReceiptBlankSpaces"].ToString());
                this.registerOpen = Properties.Settings.Default.RegisterOpen;
                this.IncludeLogoReceipt.Checked = Convert.ToBoolean(Convert.ToInt32(dt.Rows[0]["SystemIncludeLogoInReceipt"].ToString()));
                if (Convert.ToBoolean(Convert.ToInt32(dt.Rows[0]["SystemIncludeLogoInReceipt"].ToString())))
                {
                    IncludeLogoInReceipt = true;
                } else
                {
                    IncludeLogoInReceipt = false;
                }
                
                if (registerOpen)
                {
                    tabControl2.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox3.Enabled = true;
                    closeRegisterBtn.Enabled = true;
                    label66.Enabled = true;
                    openRegisterBtn.Enabled = false;
                    label65.Enabled = false;
                    // get last bill number of today
                    this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    richTextBox4.ResetText();
                    richTextBox5.ResetText();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                        richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.AppendText("Total Amount: " + this.totalAmount);
                        richTextBox5.AppendText("Current Bill ID: " + this.CurrentBillNumber);
                    }
                }
                else
                {
                    this.registerOpen = false;
                    tabControl2.Enabled = false;
                    groupBox4.Enabled = false;
                    groupBox3.Enabled = false;
                    closeRegisterBtn.Enabled = false;
                    label66.Enabled = false;
                    openRegisterBtn.Enabled = true;
                    label65.Enabled = true;
                }

                DisplayCashierNames();
                DisplayItemTypes();
                DisplayWarehouses();
                try
                {
                    WarehouseEntryExitList.SelectedIndex = 0;
                }
                catch
                {

                }
                DisplayFavorites();

                DisplayPrinters();

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;

                if (dt.Rows[0]["SystemPhone"].ToString() == "")
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        if (MessageBox.Show(".بعض الاعدادات بدون قيم, الرجاء وضع قيمه لها في الاعدادات " + " اضافة ماده؟ ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
                            return;
                        }
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        if (MessageBox.Show("Some system preferences are not set. Please set the proper values in the settings area." + " Add Item? ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
                            return;
                        }
                    }
                    
                }
            }
            catch(Exception e)
            { MessageBox.Show(e.ToString()); }
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "PlancksoftPOS - الشاشه الرئيسيه";
                if (tabControl1.Contains(tabControl1.TabPages["Cash"]))
                {
                    tabControl1.TabPages["Cash"].Text = "الكاش";
                    label93.Text = "بطاقة عميل F2";
                    label67.Text = "الدفع F1";
                    label68.Text = "الخصومات F4";
                    label69.Text = "فاتوره جديده F3";
                    label2.Text = "فتح الكاش F6";
                    label89.Text = "تعديل السعر F5";
                    label24.Text = "البحث عن المواد F9";
                    label70.Text = "F8 الفواتير السابقه F7";
                    label71.Text = "اسم الكاشير:";
                    label45.Text = "هذه النسخه مرخصه ل";
                    groupBox3.Text = "قائمة المشتريات الحاليه";
                    label112.Text = "0 :عدد الفواتير المعلقه";
                    richTextBox5.Clear();
                    richTextBox5.AppendText("رقم الفاتورة الحالية");
                    richTextBox1.Clear();
                    richTextBox1.AppendText("الباقي السابق");
                    richTextBox2.Clear();
                    richTextBox2.AppendText("المدفوع السابق");
                    richTextBox3.Clear();
                    richTextBox3.AppendText("المجموع السابق");
                    ItemsPendingPurchase.Columns["pendingPurchaseItemName"].HeaderText = "القطعة";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemBarCode"].HeaderText = "الباركود";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemQuantity"].HeaderText = "عدد القطعة";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemPrice"].HeaderText = "سعر القطعة";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemPriceTax"].HeaderText = "سعر القطعة بعد الضريبة";
                    label49.Text = "عدد الحذف";
                    label52.Text = "عدد القطع الجديد";
                    button17.Text = "حذف القطعه من الشراء";
                    button24.Text = "تعديل عدد القطع";
                    label66.Text = "اغلاق الصندوق F12";
                    label65.Text = "فتح الصندوق F11";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Sales"]))
                {
                    tabControl1.TabPages["Sales"].Text = "المبيعات";
                    if (tabControl4.Contains(tabControl4.TabPages["InvoicesSales"]))
                    {
                        tabControl4.TabPages["InvoicesSales"].Text = "المبيعات";
                        label85.Text = "رقم الغاتورة";
                        label87.Text = "تاريخ البحث من";
                        label84.Text = "تاريخ البحث الى";
                        cbSalesDateSearch.Text = "بحث تاريخ";
                        groupBox12.Text = "لائحة الفواتير";
                        button26.Text = "مبيعات اليوم";
                        dgvBills.Columns["Column15"].HeaderText = "رقم الفاتوره";
                        dgvBills.Columns["Column16"].HeaderText = "اسم الكاشير";
                        dgvBills.Columns["Column17"].HeaderText = "المبلغ الصافي";
                        dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                        dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                        dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                        dgvBills.Columns["Column64"].HeaderText = "التاريخ";
                        groupBox14.Text = "المواد المباعه بالفاتوره";
                        button25.Text = "أقل 100 المواد مباعه";
                        button18.Text = "أكثر 100 المواد مباعه";
                        dgvBillItems.Columns["Column20"].HeaderText = "اسم الماده";
                        dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                        dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                        dgvBillItems.Columns["Column63"].HeaderText = "العدد من أصل";
                        dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                        dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                    {
                        tabControl4.TabPages["EditInvoices"].Text = "التعديل على الفواتير";
                        groupBox30.Text = "لائحة الفواتير";
                        label13.Text = "رقم الفاتوره";
                        label11.Text = "اسم الكاشير";
                        label9.Text = "المبلغ الصافي";
                        label10.Text = "المبلغ المدفوع";
                        label12.Text = "المبلغ الباقي";
                        BillsEditButton.Text = "التعديل على الفاتوره";
                        dgvBillsEdit.Columns["BillNumber"].HeaderText = "رقم الفاتوره";
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "اسم الكاشير";
                        dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "المبلغ الصافي";
                        dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "المبلغ المدفوع";
                        dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "المبلغ الباقي";
                        dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "طريقة الدفع";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                    {
                        tabControl4.TabPages["TravelingUntravelingSales"].Text = "المبيعات المرحله و الغير مرحله";
                        groupBox25.Text = "المبيعات الغير المرحله";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn6"].HeaderText = "رقم الغاتورة";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn7"].HeaderText = "إسم الكاشير";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "المبلغ الصافي";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "المبلغ المدفوغ";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "المبلغ الباقي";
                        dgvUnPortedSales.Columns["Column7"].HeaderText = "طريقة الدفع";
                        dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "المجموع";
                        groupBox26.Text = "المبيعات المرحله";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "رقم الغاتورة";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "إسم الكاشير";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "المبلغ الصافي";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "المبلغ المدفوغ";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "المبلغ الباقي";
                        dgvPortedSales.Columns["Column28"].HeaderText = "طريقة الدفع";
                        dgvPortedSales.Columns["TotalPorted"].HeaderText = "المجموع";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                    {
                        tabControl4.TabPages["SoldItems"].Text = "جرد الكميات المباعه";
                        groupBox28.Text = "البحث";
                        label37.Text = "اسم الكاشير";
                        label38.Text = "الصنف";
                        label5.Text = "تاريخ البحث من";
                        label3.Text = "تاريخ البحث الى";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "إسم السلعه";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "الباركود";
                        dgvItemProfit.Columns["Column48"].HeaderText = "صنف الماده";
                        dgvItemProfit.Columns["Column49"].HeaderText = "اسم الكاشير";
                        dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "سعر القطعة بعد الضريبة";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "الكميه المباعه";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn19"].HeaderText = "المجموع";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                {
                    tabControl1.TabPages["Inventory"].Text = "المستودع";
                    if (tabControl6.Contains(tabControl6.TabPages["posInventory"]))
                    {
                        tabControl6.TabPages["posInventory"].Text = "المستودع";
                        groupBox7.Text = "البحث عن القطع";
                        BtnSearchItem.Text = "البحث";
                        label57.Text = "باركود القطعه";
                        label58.Text = "إسم القطعه";
                        label59.Text = "تاريخ البحث من";
                        label56.Text = "تاريخ البحث إلى";
                        groupBox8.Text = "مخزون البضائع";
                        groupBox36.Text = "اضافة و تعديل المواد";
                        label62.Text = "إسم القطعه";
                        label61.Text = "باركود القطعه";
                        label60.Text = "عدد القطعه";
                        label4.Text = "سعر الشراء";
                        label55.Text = "سعر بيع القطعه";
                        label63.Text = "سعر البيع بالضريبه";
                        label64.Text = "المصنف المفضل";
                        label35.Text = "تنبيه الكميه";
                        label36.Text = "تاريخ الإنتاج";
                        label34.Text = "تاريخ إنتهاء الصلاحيه";
                        label33.Text = "تاريخ الإدخال";
                        label28.Text = "تصنيف الماده";
                        label25.Text = "المستودع";
                        BtnAddItem.Text = "إضافه قطعه";
                        BtnUpdateItem.Text = "تحديث قطعه";
                        BtnDeleteItem.Text = "حذف قطعه";
                        DgvInventory.Columns["InventoryItemName"].HeaderText = "إسم القطعة";
                        DgvInventory.Columns["ItemID"].HeaderText = "رقم القطعه";
                        DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "باركود القطعه";
                        DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "عدد القطعه";
                        DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "سعر الشراء";
                        DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "سعر القطعة";
                        DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "سعر القطعة بالضريبة";
                        DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "المصنف المفضل";
                        DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "المستودع";
                        DgvInventory.Columns["InventoryItemType"].HeaderText = "تصنيف المادة";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["posInventory"]))
                    {
                        tabControl6.TabPages["InventoryQuantify"].Text = "جرد المستودعات";
                        groupBox45.Text = "البحث عن المستودع";
                        button13.Text = "البحث";
                        label47.Text = "المستودع";
                        groupBox46.Text = "مخزون البضائع في المستودع";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn32"].HeaderText = "إسم القطعة";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn37"].HeaderText = "باركود القطعه";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn38"].HeaderText = "عدد القطعه";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn42"].HeaderText = "سعر الشراء";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn45"].HeaderText = "سعر القطعة";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn46"].HeaderText = "سعر القطعة بالضريبة";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn47"].HeaderText = "المصنف المفضل";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn48"].HeaderText = "المستودع";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn49"].HeaderText = "تصنيف المادة";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["IncomingOutgoingItems"]))
                    {
                        tabControl6.TabPages["IncomingOutgoingItems"].Text = "سند إدخال وإخراج";
                        groupBox48.Text = "اضافة سند إدخال و إخراج";
                        label53.Text = "إسم القطعه";
                        label48.Text = "باركود القطعه";
                        label97.Text = "عدد القطعه";
                        label103.Text = "المستودع";
                        label101.Text = "نوع السند";
                        label94.Text = "تنبيه الكميه";
                        label79.Text = "تاريخ الإنتاج";
                        label96.Text = "تاريخ إنتهاء الصلاحيه";
                        label98.Text = "تاريخ الإدخال";
                        label46.Text = "سعر الشراء";
                        button14.Text = "إختيار ماده";
                        button38.Text = "إضافة ماده";
                        button36.Text = "حذف ماده";
                        button15.Text = "اتمام العمليه";
                        dvgEntryExitItems.Columns["EntryExitItemName"].HeaderText = "إسم المادة";
                        dvgEntryExitItems.Columns["EntryExitItemBarCode"].HeaderText = "باركود المادة";
                        dvgEntryExitItems.Columns["EntryExitItemQuantity2"].HeaderText = "عدد القطع";
                        dvgEntryExitItems.Columns["EntryExitItemWarehouse"].HeaderText = "المستودع";
                        dvgEntryExitItems.Columns["EntryExitItemVendorItemBuyPrice"].HeaderText = "سعر الشراء";
                        dvgEntryExitItems.Columns["EntryExitItemWarningQuantity"].HeaderText = "تنبيه الكمية";
                        dvgEntryExitItems.Columns["EntryExitItemProductionDate"].HeaderText = "تاريخ الإنتاج";
                        dvgEntryExitItems.Columns["EntryExitItemEndDate"].HeaderText = "تاريخ إنتهاء الصلاحية";
                        dvgEntryExitItems.Columns["EntryExitItemEntryDate"].HeaderText = "تاريخ الإدخال";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["AddTypes"]))
                    {
                        tabControl6.TabPages["AddTypes"].Text = "إضافة صنف";
                        label29.Text = "إضافة تصنيف مواد جديد";
                        label30.Text = "أصناف المواد المضافه";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["AddFavorites"]))
                    {
                        tabControl6.TabPages["AddFavorites"].Text = "إضافة مجلد مفضلات";
                        label22.Text = "اضافة مجلد مفضل جديد";
                        label23.Text = "المفضلات المضافه";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["AddWarehouses"]))
                    {
                        tabControl6.TabPages["AddWarehouses"].Text = "إضافة مستودع";
                        label26.Text = "إضافة مستودع جديد";
                        label27.Text = "المستودعات المضافه";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                {
                    tabControl1.TabPages["Expenses"].Text = "المصروفات";
                    if (tabControl5.Contains(tabControl5.TabPages["SearchExpenses"]))
                    {
                        tabControl5.TabPages["SearchExpenses"].Text = "البحث عن المصروفات";
                        label16.Text = "إسم المصروف";
                        label17.Text = "إسم الموظف";
                        label15.Text = "تاريخ البحث من";
                        label14.Text = "تاريخ البحث إلى";
                        groupBox22.Text = "رأس المال";
                        dgvExpenses.Columns["Column29"].HeaderText = "رقم المصروف";
                        dgvExpenses.Columns["Column30"].HeaderText = "إسم المصروف";
                        dgvExpenses.Columns["Column31"].HeaderText = "تكلفة المصروف";
                        dgvExpenses.Columns["Column37"].HeaderText = "رمز المستخدم";
                        dgvExpenses.Columns["Column32"].HeaderText = "تاريخ المصروف";
                    }
                    if (tabControl5.Contains(tabControl5.TabPages["AddExpenses"]))
                    {
                        tabControl5.TabPages["AddExpenses"].Text = "إضافة مصروف";
                        label19.Text = "اسم المصروف";
                        label20.Text = "كمية المصروف";
                        button2.Text = "إضافة المصروف";
                        button3.Text = "مسح";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                {
                    tabControl1.TabPages["IncomingOutgoing"].Text = "الصادر والوارد ورأس المال";
                    groupBox19.Text = "الصادر";
                    groupBox20.Text = "الوارد";
                    groupBox21.Text = "الأرباح";
                    dgvExports.Columns["Column33"].HeaderText = "التاريخ";
                    dgvExports.Columns["Column34"].HeaderText = "التكلفه الكامله";
                    dgvImports.Columns["Column35"].HeaderText = "التاريخ";
                    dgvImports.Columns["Column36"].HeaderText = "التكلفه الكامله";
                    dvgCapital.Columns["Column22"].HeaderText = "التاريخ";
                    dvgCapital.Columns["Column26"].HeaderText = "الربح الصافي";
                    label115.Text = "صافي الربح";
                    label116.Text = "رأس المال";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Employees"]))
                {
                    tabControl1.TabPages["Employees"].Text = "شؤون الموظفين";
                    if (tabControl8.Contains(tabControl8.TabPages["EmployeesManagement"]))
                    {
                        tabControl8.TabPages["EmployeesManagement"].Text = "إدارة الموظفين";
                        groupBox52.Text = "تسجيل الموظفين";
                        label102.Text = "إسم الموظف";
                        label100.Text = "الراتب";
                        label104.Text = "رقم هاتف الموظف";
                        label105.Text = "عنوان الموظف";
                        button34.Text = "التسجيل";
                        groupBox49.Text = "جدول الموظفين";
                        dgvEmployees.Columns["Column54"].HeaderText = "رقم الموظف";
                        dgvEmployees.Columns["dataGridViewTextBoxColumn50"].HeaderText = "إسم الموظف";
                        dgvEmployees.Columns["dataGridViewTextBoxColumn53"].HeaderText = "الراتب";
                        dgvEmployees.Columns["Column62"].HeaderText = "الراتب مع الخصم";
                        dgvEmployees.Columns["Column56"].HeaderText = "رقم الهاتف";
                        dgvEmployees.Columns["Column57"].HeaderText = "العنوان";
                        groupBox50.Text = "االتعديل على الموظفين و الإجازات";
                        label54.Text = "إسم الموظف";
                        label92.Text = "الراتب";
                        label95.Text = "رقم هاتف الموظف";
                        label99.Text = "عنوان الموظف";
                        button32.Text = "تحديث  موظف";
                        button16.Text = "حذف  موظف";
                        label109.Text = "إسم الموظف";
                        label106.Text = "عدد الساعات";
                        label107.Text = "التاريخ";
                        button37.Text = "إضافة إجازه";
                        label111.Text = "حسم الراتب";
                        button35.Text = "إضافة الحسم";
                    }
                    if (tabControl8.Contains(tabControl8.TabPages["DaysOff"]))
                    {
                        tabControl8.TabPages["DaysOff"].Text = "الإجازات";
                        groupBox51.Text = "جدول الاجازات اليوميه";
                        label108.Text = "التاريخ من";
                        label110.Text = "التاريخ إلى";
                        button33.Text = "حذف  غياب";
                        dgvAbsence.Columns["Column58"].HeaderText = "رقم الغياب";
                        dgvAbsence.Columns["Column59"].HeaderText = "إسم الموظف";
                        dgvAbsence.Columns["Column60"].HeaderText = "تاريخ الغياب";
                        dgvAbsence.Columns["Column61"].HeaderText = "ساعات الغياب";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Agents"]))
                {
                    tabControl1.TabPages["Agents"].Text = "شؤون العملاء";
                    if (tabControl3.Contains(tabControl3.TabPages["AgentsDefinitions"]))
                    {
                        tabControl3.TabPages["AgentsDefinitions"].Text = "تعريف العملاء";
                        groupBox17.Text = "تسجيل العملاء";
                        label82.Text = "إسم العميل";
                        label83.Text = "رمز العميل";
                        label18.Text = "رقم تلفون";
                        label21.Text = "العنوان";
                        button31.Text = "حفظ العميل";
                        groupBox15.Text = "جدول العملاء";
                        dgvCustomers.Columns["Column27"].HeaderText = "إسم العميل";
                        dgvCustomers.Columns["CustomerIDDelete"].HeaderText = "رمز العميل";
                        dgvCustomers.Columns["Column38"].HeaderText = "رقم الزبون";
                        dgvCustomers.Columns["Column39"].HeaderText = "عنوان الزبون";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["AgentsItemsDefinitions"]))
                    {
                        tabControl3.TabPages["AgentsItemsDefinitions"].Text = "تعريف مواد العميل";
                        groupBox23.Text = "جدول المواد";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "إسم القطعة";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعه";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعه";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر الشراء";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "سعر القطعه بالضريبه";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "المصنف المفضل";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "المستودع";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "تصنيف الماده";
                        groupBox34.Text = "تعريف مواد العميل";
                        label32.Text = "إسم العميل";
                        label31.Text = "رمز العميل";
                        label81.Text = "سعر الشراء";
                        label86.Text = "سعر البيع قبل الضريبه";
                        label88.Text = "سعر البيع بعد الضريبه";
                        label90.Text = "سعر بيع العميل";
                        button5.Text = "إختيار العميل";
                        button4.Text = "إضافة الماده للعميل";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterDefinitions"]))
                    {
                        tabControl3.TabPages["ImporterDefinitions"].Text = "تعريف مورد";
                        groupBox40.Text = "تسجيل الموردين";
                        label41.Text = "إسم المورد";
                        label42.Text = "رمز المورد";
                        label40.Text = "رقم تلفون";
                        label39.Text = "العنوان";
                        button7.Text = "حفظ المورد";
                        groupBox39.Text = "جدول الموردين";
                        dgvVendors.Columns["VendorCustomerName"].HeaderText = "إسم المورد";
                        dgvVendors.Columns["VendorCustomerID"].HeaderText = "رمز المورد";
                        dgvVendors.Columns["VendorCustomerPhone"].HeaderText = "رقم المورد";
                        dgvVendors.Columns["VendorCustomerAddress"].HeaderText = "عنوان المورد";
                        button6.Text = "حذف المورد";
                        button9.Text = "كشف حساب";
                        button8.Text = "إضافة فاتوره";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["AddImporterInvoices"]))
                    {
                        tabControl3.TabPages["AddImporterInvoices"].Text = "إضافة فاتورة مورد";
                        groupBox41.Text = "إضافة فاتورة مورد";
                        label43.Text = "إسم المورد";
                        label44.Text = "رقم المورد";
                        button12.Text = "إضافة الفاتورة";
                        button10.Text = "إختيار ماده";
                        button11.Text = "حذف ماده";
                        dgvVendorItemsPick.Columns["VendorItemName"].HeaderText = "إسم المادة";
                        dgvVendorItemsPick.Columns["VendorItemBarCode"].HeaderText = "باركود المادة";
                        dgvVendorItemsPick.Columns["VendorItemType"].HeaderText = "صنف المادة";
                        dgvVendorItemsPick.Columns["VendorItemQuantity"].HeaderText = "عدد الفطع";
                        dgvVendorItemsPick.Columns["VendorItemBuyPrice"].HeaderText = "سعر الشراء";
                        dgvVendorItemsPick.Columns["VendorItemSellPrice"].HeaderText = "سعر البيع";
                        dgvVendorItemsPick.Columns["VendorItemSellPriceTax"].HeaderText = "سعر البيع مع الضريبة";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterBalanceChecks"]))
                    {
                        tabControl3.TabPages["ImporterBalanceChecks"].Text = "كشف حساب مورد";
                        groupBox43.Text = "لائحة الفواتير";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "رقم الغاتورة";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "إسم الكاشير";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn41"].HeaderText = "المبلغ الصافي";
                        dgvVendorBills.Columns["VendorBillDate"].HeaderText = "التاريخ";
                        groupBox42.Text = "المواد المشتراه بالفاتوره";
                        dgvVendorBillItems.Columns["dataGridViewTextBoxColumn34"].HeaderText = "إسم المادة";
                        dgvVendorBillItems.Columns["dataGridViewTextBoxColumn35"].HeaderText = "باركود الماده";
                        dgvVendorBillItems.Columns["dataGridViewTextBoxColumn36"].HeaderText = "عدد البيع الشراء";
                        dgvVendorBillItems.Columns["VendorBillItemBuyPrice"].HeaderText = "سعر الشراء";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Alerts"]))
                {
                    tabControl1.TabPages["Alerts"].Text = "التنبيهات";
                    groupBox37.Text = "التنبيهات";
                    dgvAlerts.Columns["Column42"].HeaderText = "باركود الماده";
                    dgvAlerts.Columns["Column43"].HeaderText = "إسم الماده";
                    dgvAlerts.Columns["Column44"].HeaderText = "تاريخ الإنتاج";
                    dgvAlerts.Columns["Column45"].HeaderText = "تاريخ إنتهاء الصلاحيه";
                    dgvAlerts.Columns["Column46"].HeaderText = "كمية التحذير";
                    dgvAlerts.Columns["Column47"].HeaderText = "الكميه الحاليه";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                {
                    tabControl1.TabPages["Taxes"].Text = "الضريبه";
                    if (tabControl7.Contains(tabControl7.TabPages["TAXZReport"]))
                    {
                        tabControl7.TabPages["TAXZReport"].Text = "تقرير الضريبه Z";
                        dgvTaxZReport.Columns["Column50"].HeaderText = "رقم الفاتتوره";
                        dgvTaxZReport.Columns["Column52"].HeaderText = "قيمة الفاتوره";
                        dgvTaxZReport.Columns["Column53"].HeaderText = "قيمة الضريبه";
                        dgvTaxZReport.Columns["Column55"].HeaderText = "إسم الكاشير";
                        dgvTaxZReport.Columns["Column51"].HeaderText = "التاريخ";
                        dgvTaxZReport.Columns["TaxTotal"].HeaderText = "مجموع الضريبه";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                {
                    tabControl1.TabPages["posUsers"].Text = "المستخدمين";
                    groupBox10.Text = "جدول المستخدمين";
                    dgvUsers.Columns["UserName"].HeaderText = "إسم المستخدم";
                    dgvUsers.Columns["UserID"].HeaderText = "رمز المستخدم";
                    dgvUsers.Columns["UserPassword"].HeaderText = "كلمة السر";
                    dgvUsers.Columns["UserAuthority"].HeaderText = "الصلاحيه";
                    groupBox11.Text = "االتعديل على المستخدمين";
                    label77.Text = "إسم المستخدم";
                    label76.Text = "رمز المستخدم";
                    label75.Text = "كلمة السر الجديده";
                    cbAdminOrNotAdd.Text = "حساب إداري؟";
                    button22.Text = "إضافه مستخدم";
                    button20.Text = "تحديث مستخدم";
                    button19.Text = "حذف مستخدم";
                    groupBox35.Text = "الصلاحيات";
                    customer_card_edit.Text = "إضافة بطاقة عميل و تعديل المواد";
                    discount_edit.Text = "إضافة الخصومات";
                    price_edit.Text = "تعديل السعر";
                    receipt_edit.Text = "تعديل الفواتير و جرد المبيعات";
                    inventory_edit.Text = "تعديل المستودع";
                    expenses_edit.Text = "إضافة مصاريف";
                    users_edit.Text = "تعديل المستخدمين";
                    settings_edit.Text = "تعديل الإعدادات";
                    personnel_edit.Text = "تعديل الموظفين";
                    openclose_edit.Text = "فتح و إغلاق الكاش";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                {
                    tabControl1.TabPages["Settings"].Text = "الإعدادات";
                    if (tabControl9.Contains(tabControl9.TabPages["posSettings"]))
                    {
                        tabControl9.TabPages["posSettings"].Text = "إعدادات البرمجية";
                        groupBox24.Text = "إعدادات البرمجيه";
                        groupBox9.Text = "الإعدادات الأساسية";
                        A.Text = "إسم المتجر";
                        label113.Text = "رقم الهاتف";
                        groupBox18.Text = "الضرائب";
                        label78.Text = "% نسبة الضريبه بالمئه";
                        groupBox2.Text = "صورة المتجر";
                        button29.Text = "إعادة الصورة الأصلية";
                        groupBox5.Text = "الطابعات";
                        label114.Text = "عدد فراغ الفاتوره";
                        IncludeLogoReceipt.Text = "تضمين الشعار في الفاتوره";
                        button1.Text = "حفظ الإعدادات";
                    }
                    if (tabControl9.Contains(tabControl9.TabPages["printersSettings"]))
                    {
                        tabControl9.TabPages["printersSettings"].Text = "الطابعات";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Retrievals"]))
                {
                    tabControl1.TabPages["Retrievals"].Text = "المرجعات";
                    groupBox47.Text = "جدول المرجعات";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn54"].HeaderText = "رقم السند";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn55"].HeaderText = "إسم الكاشير";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn52"].HeaderText = "إسم الماده";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn51"].HeaderText = "باركود الماده";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn57"].HeaderText = "عدد القطع المرجعه";
                }
                DisplayPrinters();
                خروجToolStripMenuItem1.Text = "خروج";
                aToolStripMenuItem.Text = "طلب الصيانة";
                ادارةالمستودعToolStripMenuItem.Text = "إدارة المستودع";
                اضافةصنفToolStripMenuItem.Text = "إضافة صنف";
                اضافةمستودعToolStripMenuItem.Text = "إضافة مجلد مفضلات";
                اضافةمستودعToolStripMenuItem1.Text = "إضافة مستودع";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Main Window - PlancksoftPOS";
                if (tabControl1.Contains(tabControl1.TabPages["Cash"]))
                {
                    tabControl1.TabPages["Cash"].Text = "Cash";
                    label93.Text = "Client Card F2";
                    label67.Text = "Pay F1";
                    label68.Text = "Discounts F4";
                    label69.Text = "New Bill F3";
                    label2.Text = "Drawer F6";
                    label89.Text = "Edit Price F5";
                    label24.Text = "Items Lookup F9";
                    label70.Text = "F8 Previous Bills F7";
                    label71.Text = "Cashier Name:";
                    label45.Text = "This copy is licensed for ";
                    groupBox3.Text = "List of currently pending items";
                    label112.Text = "Number of pending bills: 0";
                    richTextBox5.Clear();
                    richTextBox5.AppendText("Current Bill Number");
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Previous Remainder");
                    richTextBox2.Clear();
                    richTextBox2.AppendText("Previous Paid");
                    richTextBox3.Clear();
                    richTextBox3.AppendText("Previous Total");
                    ItemsPendingPurchase.Columns["pendingPurchaseItemName"].HeaderText = "Item Name";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemBarCode"].HeaderText = "Item Barcode";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemQuantity"].HeaderText = "Item Quantity";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemPrice"].HeaderText = "Item Price";
                    ItemsPendingPurchase.Columns["pendingPurchaseItemPriceTax"].HeaderText = "Item Price after Tax";
                    label49.Text = "Removal Quantity";
                    label52.Text = "New Item Quantity";
                    button17.Text = "Remove item from bill";
                    button24.Text = "Edit Item Quantity";
                    label66.Text = "Close Register F12";
                    label65.Text = "Open Register F11";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Sales"]))
                {
                    tabControl1.TabPages["Sales"].Text = "Sales";
                    if (tabControl4.Contains(tabControl4.TabPages["InvoicesSales"]))
                    {
                        tabControl4.TabPages["InvoicesSales"].Text = "Sales";
                        label85.Text = "Bill ID";
                        label87.Text = "Search date from";
                        label84.Text = "Search date to";
                        cbSalesDateSearch.Text = "Date Search";
                        groupBox12.Text = "List of Bills";
                        button26.Text = "Today's Sales";
                        dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                        dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                        dgvBills.Columns["Column17"].HeaderText = "Net Total";
                        dgvBills.Columns["Column18"].HeaderText = "Paid Amount";
                        dgvBills.Columns["Column19"].HeaderText = "Remainder";
                        dgvBills.Columns["Column5"].HeaderText = "Payment Method";
                        dgvBills.Columns["Column64"].HeaderText = "Date";
                        groupBox14.Text = "Items sold in Bill";
                        button25.Text = "Least 100 Items Sold";
                        button18.Text = "Most 100 Items Sold";
                        dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                        dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                        dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                        dgvBillItems.Columns["Column63"].HeaderText = "Original Quantity";
                        dgvBillItems.Columns["Column24"].HeaderText = "Price";
                        dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                    {
                        tabControl4.TabPages["EditInvoices"].Text = "Edit Invoices";
                        groupBox30.Text = "List of Bills";
                        label13.Text = "Bill ID";
                        label11.Text = "Cashier Name";
                        label9.Text = "Net Amount";
                        label10.Text = "Paid Amount";
                        label12.Text = "Remainder";
                        BillsEditButton.Text = "Edit Bill";
                        dgvBillsEdit.Columns["BillNumber"].HeaderText = "Bill ID";
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "Bill Cashier Name";
                        dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "Net Amount";
                        dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "Paid Amount";
                        dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "Remainder";
                        dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "Payment Type";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                    {
                        tabControl4.TabPages["TravelingUntravelingSales"].Text = "Traveling | Untraveling Sales";
                        groupBox25.Text = "Untraveling Sales";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn6"].HeaderText = "Bill ID";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn7"].HeaderText = "Cashier Name";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "Net Amount";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "Paid Amount";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "Remainder";
                        dgvUnPortedSales.Columns["Column7"].HeaderText = "Payment Method";
                        dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "Total";
                        groupBox26.Text = "Traveling Sales";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "Bill ID";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "Cashier Name";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Net Amount";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Paid Amount";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "Remainder";
                        dgvPortedSales.Columns["Column28"].HeaderText = "Payment Method";
                        dgvPortedSales.Columns["TotalPorted"].HeaderText = "Total";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                    {
                        tabControl4.TabPages["SoldItems"].Text = "Sold Items Review";
                        groupBox28.Text = "Search";
                        label37.Text = "Cashier Name";
                        label38.Text = "Item Type";
                        label5.Text = "Search Date from";
                        label3.Text = "Search Date to";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "Item Name";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "Item Barcode";
                        dgvItemProfit.Columns["Column48"].HeaderText = "Item Type";
                        dgvItemProfit.Columns["Column49"].HeaderText = "Cashier Name";
                        dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "Sold Quantity";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn19"].HeaderText = "Total";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                {
                    tabControl1.TabPages["Inventory"].Text = "Warehouse";
                    if (tabControl6.Contains(tabControl6.TabPages["posInventory"]))
                    {
                        tabControl6.TabPages["posInventory"].Text = "Warehouse";
                        groupBox7.Text = "Search for Items";
                        BtnSearchItem.Text = "Search";
                        label57.Text = "Item Barcode";
                        label58.Text = "Item Name";
                        label59.Text = "Search Date from";
                        label56.Text = "Search Date to";
                        groupBox8.Text = "Items Storage";
                        groupBox36.Text = "Add & Edit Items";
                        label62.Text = "Item Name";
                        label61.Text = "Item Barcode";
                        label60.Text = "Item Quantity";
                        label4.Text = "Buy Price";
                        label55.Text = "Sell Price";
                        label63.Text = "Sell Price Tax";
                        label64.Text = "Favorite Category";
                        label35.Text = "Warning Limit";
                        label36.Text = "Production Date";
                        label34.Text = "Expiration Date";
                        label33.Text = "Entry Date";
                        label28.Text = "Item Type";
                        label25.Text = "Warehouse";
                        BtnAddItem.Text = "Add Item";
                        BtnUpdateItem.Text = "Update Item";
                        BtnDeleteItem.Text = "Delete Item";
                        DgvInventory.Columns["InventoryItemName"].HeaderText = "Item Name";
                        DgvInventory.Columns["ItemID"].HeaderText = "Item ID";
                        DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "Item Barcode";
                        DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "Item Quantity";
                        DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "Item Buy Price";
                        DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "Sell Price";
                        DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "Sell Price Tax";
                        DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "Favorite Category";
                        DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "Warehouse";
                        DgvInventory.Columns["InventoryItemType"].HeaderText = "Item Type";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["posInventory"]))
                    {
                        tabControl6.TabPages["InventoryQuantify"].Text = "Inventory Quantify";
                        groupBox45.Text = "Search in Warehouse";
                        button13.Text = "Search";
                        label47.Text = "Warehouse";
                        groupBox46.Text = "Items stored in Warehouse";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn32"].HeaderText = "Item Name";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn37"].HeaderText = "Item Barcode";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn38"].HeaderText = "Item Quantity";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn42"].HeaderText = "Buy Price";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn45"].HeaderText = "Sell Price";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn46"].HeaderText = "Sell Price Tax";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn47"].HeaderText = "Favorite Category";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn48"].HeaderText = "Warehouse";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn49"].HeaderText = "Item Type";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["IncomingOutgoingItems"]))
                    {
                        tabControl6.TabPages["IncomingOutgoingItems"].Text = "Import Export Form";
                        groupBox48.Text = "Submit Import Export Form";
                        label53.Text = "Item Name";
                        label48.Text = "Item Barcode";
                        label97.Text = "Item Quantity";
                        label103.Text = "Warehouse";
                        label101.Text = "Form Type";
                        label94.Text = "Warning Limit";
                        label79.Text = "Production Date";
                        label96.Text = "Expiration Date";
                        label98.Text = "Entry Date";
                        label46.Text = "Buy Price";
                        button14.Text = "Pick Item";
                        button38.Text = "Add Item";
                        button36.Text = "Delete Item";
                        button15.Text = "Commit Form";
                        dvgEntryExitItems.Columns["EntryExitItemName"].HeaderText = "Item Name";
                        dvgEntryExitItems.Columns["EntryExitItemBarCode"].HeaderText = "Item Barcode";
                        dvgEntryExitItems.Columns["EntryExitItemQuantity2"].HeaderText = "Item Quantity";
                        dvgEntryExitItems.Columns["EntryExitItemWarehouse"].HeaderText = "Warehouse";
                        dvgEntryExitItems.Columns["EntryExitItemVendorItemBuyPrice"].HeaderText = "Buy Price";
                        dvgEntryExitItems.Columns["EntryExitItemWarningQuantity"].HeaderText = "Warning Limit";
                        dvgEntryExitItems.Columns["EntryExitItemProductionDate"].HeaderText = "Production Date";
                        dvgEntryExitItems.Columns["EntryExitItemEndDate"].HeaderText = "Expiration Date";
                        dvgEntryExitItems.Columns["EntryExitItemEntryDate"].HeaderText = "Entry Date";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["AddTypes"]))
                    {
                        tabControl6.TabPages["AddTypes"].Text = "Add an Item Type";
                        label29.Text = "Add new Item Type";
                        label30.Text = "Added Item Types";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["AddFavorites"]))
                    {
                        tabControl6.TabPages["AddFavorites"].Text = "Add a Favorite Category";
                        label22.Text = "Add a new Favorite Category";
                        label23.Text = "Added Favorite Categories";
                    }
                    if (tabControl6.Contains(tabControl6.TabPages["AddWarehouses"]))
                    {
                        tabControl6.TabPages["AddWarehouses"].Text = "Add a Warehouse";
                        label26.Text = "Add a new Warehouse";
                        label27.Text = "Added Warehouses";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                {
                    tabControl1.TabPages["Expenses"].Text = "Expenses";
                    if (tabControl5.Contains(tabControl5.TabPages["SearchExpenses"]))
                    {
                        tabControl5.TabPages["SearchExpenses"].Text = "Expenses Search";
                        label16.Text = "Expense Name";
                        label17.Text = "Employee Name";
                        label15.Text = "Search Date from";
                        label14.Text = "Search Date to";
                        groupBox22.Text = "Capital Amount";
                        dgvExpenses.Columns["Column29"].HeaderText = "Expense ID";
                        dgvExpenses.Columns["Column30"].HeaderText = "Expense Name";
                        dgvExpenses.Columns["Column31"].HeaderText = "Expense Cost";
                        dgvExpenses.Columns["Column37"].HeaderText = "User ID";
                        dgvExpenses.Columns["Column32"].HeaderText = "Expense Date";
                    }
                    if (tabControl5.Contains(tabControl5.TabPages["AddExpenses"]))
                    {
                        tabControl5.TabPages["AddExpenses"].Text = "Add an Expense";
                        label19.Text = "Expense Name";
                        label20.Text = "Expense Amount";
                        button2.Text = "Add Expense";
                        button3.Text = "Clear";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                {
                    tabControl1.TabPages["IncomingOutgoing"].Text = "Imports & Exports & Capital";
                    groupBox19.Text = "Exports";
                    groupBox20.Text = "Imports";
                    groupBox21.Text = "Capital Gains";
                    dgvExports.Columns["Column33"].HeaderText = "Date";
                    dgvExports.Columns["Column34"].HeaderText = "Total Cost";
                    dgvImports.Columns["Column35"].HeaderText = "Date";
                    dgvImports.Columns["Column36"].HeaderText = "Total Cost";
                    dvgCapital.Columns["Column22"].HeaderText = "Date";
                    dvgCapital.Columns["Column26"].HeaderText = "Net Profit";
                    label115.Text = "Net Profit";
                    label116.Text = "Capital Amount";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Employees"]))
                {
                    tabControl1.TabPages["Employees"].Text = "Employees' Affairs";
                    if (tabControl8.Contains(tabControl8.TabPages["EmployeesManagement"]))
                    {
                        tabControl8.TabPages["EmployeesManagement"].Text = "Employees Management";
                        groupBox52.Text = "Employees Registration";
                        label102.Text = "Employee Name";
                        label100.Text = "Salary";
                        label104.Text = "Employee Phone";
                        label105.Text = "Employee Address";
                        button34.Text = "Register";
                        groupBox49.Text = "Employees Grid";
                        dgvEmployees.Columns["Column54"].HeaderText = "Employee ID";
                        dgvEmployees.Columns["dataGridViewTextBoxColumn50"].HeaderText = "Employee Name";
                        dgvEmployees.Columns["dataGridViewTextBoxColumn53"].HeaderText = "Salary";
                        dgvEmployees.Columns["Column62"].HeaderText = "Salary with Deductions";
                        dgvEmployees.Columns["Column56"].HeaderText = "Phone Number";
                        dgvEmployees.Columns["Column57"].HeaderText = "Address";
                        groupBox50.Text = "Employees & Absences Management";
                        label54.Text = "Employee Name";
                        label92.Text = "Salary";
                        label95.Text = "Employee Phone";
                        label99.Text = "Employee Address";
                        button32.Text = "Update Employee";
                        button16.Text = "Delete Employee";
                        label109.Text = "Employee Name";
                        label106.Text = "Number of Hours";
                        label107.Text = "Date";
                        button37.Text = "Add Absence";
                        label111.Text = "Deduct from Salary";
                        button35.Text = "Add Deduction";
                    }
                    if (tabControl8.Contains(tabControl8.TabPages["DaysOff"]))
                    {
                        tabControl8.TabPages["DaysOff"].Text = "Absences";
                        groupBox51.Text = "Daily Absences Grid";
                        label108.Text = "Date from";
                        label110.Text = "Date to";
                        button33.Text = "Delete Absence";
                        dgvAbsence.Columns["Column58"].HeaderText = "Absence ID";
                        dgvAbsence.Columns["Column59"].HeaderText = "Employee Name";
                        dgvAbsence.Columns["Column60"].HeaderText = "Absence Date";
                        dgvAbsence.Columns["Column61"].HeaderText = "Absence Hours";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Agents"]))
                {
                    tabControl1.TabPages["Agents"].Text = "Clients' Affairs";
                    if (tabControl3.Contains(tabControl3.TabPages["AgentsDefinitions"]))
                    {
                        tabControl3.TabPages["AgentsDefinitions"].Text = "Clients' Definitions";
                        groupBox17.Text = "Clients Registration";
                        label82.Text = "Client Name";
                        label83.Text = "Client ID";
                        label18.Text = "Phone Number";
                        label21.Text = "Address";
                        button31.Text = "Save Client";
                        groupBox15.Text = "Clients Grid";
                        dgvCustomers.Columns["Column27"].HeaderText = "Client Name";
                        dgvCustomers.Columns["CustomerIDDelete"].HeaderText = "Client ID";
                        dgvCustomers.Columns["Column38"].HeaderText = "Phone Number";
                        dgvCustomers.Columns["Column39"].HeaderText = "Client Address";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["AgentsItemsDefinitions"]))
                    {
                        tabControl3.TabPages["AgentsItemsDefinitions"].Text = "Client Items Definitions";
                        groupBox23.Text = "Items Grid";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Buy Price";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Sell Price";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "Sell Price Tax";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "Favorite Category";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "Warehouse";
                        DGVCustomerItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "Item Type";
                        groupBox34.Text = "Client Items Definition";
                        label32.Text = "Client Name";
                        label31.Text = "Client ID";
                        label81.Text = "Buy Price";
                        label86.Text = "Sell Price";
                        label88.Text = "Sell Price Tax";
                        label90.Text = "Client Sell Price";
                        button5.Text = "Pick Client";
                        button4.Text = "Add Item to Client";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterDefinitions"]))
                    {
                        tabControl3.TabPages["ImporterDefinitions"].Text = "Importer Definition";
                        groupBox40.Text = "Importers Registration";
                        label41.Text = "Importer Name";
                        label42.Text = "Importer ID";
                        label40.Text = "Phone Number";
                        label39.Text = "Address";
                        button7.Text = "Save Importer";
                        groupBox39.Text = "Importers Grid";
                        dgvVendors.Columns["VendorCustomerName"].HeaderText = "Importer Name";
                        dgvVendors.Columns["VendorCustomerID"].HeaderText = "Importer ID";
                        dgvVendors.Columns["VendorCustomerPhone"].HeaderText = "Importer Phone Number";
                        dgvVendors.Columns["VendorCustomerAddress"].HeaderText = "Importer Address";
                        button6.Text = "Importer Delete";
                        button9.Text = "Account Summary";
                        button8.Text = "Add Bill";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["AddImporterInvoices"]))
                    {
                        tabControl3.TabPages["AddImporterInvoices"].Text = "Add Importer Bill";
                        groupBox41.Text = "Add Importer Bill";
                        label43.Text = "Importer Name";
                        label44.Text = "Importer ID";
                        button12.Text = "Add Bill";
                        button10.Text = "Pick Item";
                        button11.Text = "Delete Item";
                        dgvVendorItemsPick.Columns["VendorItemName"].HeaderText = "Item Name";
                        dgvVendorItemsPick.Columns["VendorItemBarCode"].HeaderText = "Item Barcode";
                        dgvVendorItemsPick.Columns["VendorItemType"].HeaderText = "Item Type";
                        dgvVendorItemsPick.Columns["VendorItemQuantity"].HeaderText = "Item Quantity";
                        dgvVendorItemsPick.Columns["VendorItemBuyPrice"].HeaderText = "Buy Price";
                        dgvVendorItemsPick.Columns["VendorItemSellPrice"].HeaderText = "Sell Price";
                        dgvVendorItemsPick.Columns["VendorItemSellPriceTax"].HeaderText = "Sell Price Tax";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterBalanceChecks"]))
                    {
                        tabControl3.TabPages["ImporterBalanceChecks"].Text = "Importer Account Summary";
                        groupBox43.Text = "List of Bills";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "Bill ID";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "Cashier Name";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Net Total";
                        dgvVendorBills.Columns["VendorBillDate"].HeaderText = "Date";
                        groupBox42.Text = "Items Included in Bill";
                        dgvVendorBillItems.Columns["dataGridViewTextBoxColumn34"].HeaderText = "Item Name";
                        dgvVendorBillItems.Columns["dataGridViewTextBoxColumn35"].HeaderText = "Item Barcode";
                        dgvVendorBillItems.Columns["dataGridViewTextBoxColumn36"].HeaderText = "Item Buy Sell Quantity";
                        dgvVendorBillItems.Columns["VendorBillItemBuyPrice"].HeaderText = "Buy Price";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Alerts"]))
                {
                    tabControl1.TabPages["Alerts"].Text = "Alerts";
                    groupBox37.Text = "Alerts";
                    dgvAlerts.Columns["Column42"].HeaderText = "Item Barcode";
                    dgvAlerts.Columns["Column43"].HeaderText = "Item Name";
                    dgvAlerts.Columns["Column44"].HeaderText = "Production Date";
                    dgvAlerts.Columns["Column45"].HeaderText = "Expiration Date";
                    dgvAlerts.Columns["Column46"].HeaderText = "Warning Limit";
                    dgvAlerts.Columns["Column47"].HeaderText = "Current Quantity";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                {
                    tabControl1.TabPages["Taxes"].Text = "Taxes";
                    if (tabControl7.Contains(tabControl7.TabPages["TAXZReport"]))
                    {
                        tabControl7.TabPages["TAXZReport"].Text = "Tax Z Report";
                        dgvTaxZReport.Columns["Column50"].HeaderText = "Bill ID";
                        dgvTaxZReport.Columns["Column52"].HeaderText = "Bill Total";
                        dgvTaxZReport.Columns["Column53"].HeaderText = "Tax Amount";
                        dgvTaxZReport.Columns["Column55"].HeaderText = "Cashier Name";
                        dgvTaxZReport.Columns["Column51"].HeaderText = "Date";
                        dgvTaxZReport.Columns["TaxTotal"].HeaderText = "Tax Total";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                {
                    tabControl1.TabPages["posUsers"].Text = "Users";
                    groupBox10.Text = "Users Grid";
                    dgvUsers.Columns["UserName"].HeaderText = "User Name";
                    dgvUsers.Columns["UserID"].HeaderText = "User ID";
                    dgvUsers.Columns["UserPassword"].HeaderText = "Password";
                    dgvUsers.Columns["UserAuthority"].HeaderText = "Permissions";
                    groupBox11.Text = "Edit User Accounts";
                    label77.Text = "User Name";
                    label76.Text = "User ID";
                    label75.Text = "New Password";
                    cbAdminOrNotAdd.Text = "Admin Account?";
                    button22.Text = "Add User";
                    button20.Text = "Update User";
                    button19.Text = "Delete User";
                    groupBox35.Text = "Permissions";
                    customer_card_edit.Text = "Add Client Card & Client Items";
                    discount_edit.Text = "Add Discounts";
                    price_edit.Text = "Edit Bill Prices";
                    receipt_edit.Text = "Edit Invoices & Quantify Sales";
                    inventory_edit.Text = "Edit Inventory";
                    expenses_edit.Text = "Add Expenses";
                    users_edit.Text = "Edit Users";
                    settings_edit.Text = "Edit Settings";
                    personnel_edit.Text = "Edit Employees";
                    openclose_edit.Text = "Close & Open Cash Register";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                {
                    tabControl1.TabPages["Settings"].Text = "Settings";
                    if (tabControl9.Contains(tabControl9.TabPages["posSettings"]))
                    {
                        tabControl9.TabPages["posSettings"].Text = "System Preferences";
                        groupBox24.Text = "System Preferences";
                        groupBox9.Text = "Fundamental Settings";
                        A.Text = "Store Name";
                        label113.Text = "Phone Number";
                        groupBox18.Text = "Taxes";
                        label78.Text = "Percentage of Taxes %";
                        groupBox2.Text = "Store Logo";
                        button29.Text = "Reset Default Logo";
                        groupBox5.Text = "Printers";
                        label114.Text = "Blank Spaces in Receipt";
                        IncludeLogoReceipt.Text = "Include Logo in Receipt";
                        button1.Text = "Save Preferences";
                    }
                    if (tabControl9.Contains(tabControl9.TabPages["printersSettings"]))
                    {
                        tabControl9.TabPages["printersSettings"].Text = "Printers";
                    }
                }
                if (tabControl1.Contains(tabControl1.TabPages["Retrievals"]))
                {
                    tabControl1.TabPages["Retrievals"].Text = "Returned Items";
                    groupBox47.Text = "Returned Items Grid";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn54"].HeaderText = "Return ID";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn55"].HeaderText = "Cashier Name";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn52"].HeaderText = "Item Name";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn51"].HeaderText = "Item Barcode";
                    dgvReturnedItems.Columns["dataGridViewTextBoxColumn57"].HeaderText = "Returned Items Quantity";
                }
                DisplayPrinters();
                خروجToolStripMenuItem1.Text = "Quit";
                aToolStripMenuItem.Text = "Maintenance Request";
                ادارةالمستودعToolStripMenuItem.Text = "Warehouse Management";
                اضافةصنفToolStripMenuItem.Text = "Add Item Type";
                اضافةمستودعToolStripMenuItem.Text = "Add Favorite Category";
                اضافةمستودعToolStripMenuItem1.Text = "Add Warehouse";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void DisplayCashierNames()
        {
            List<string> CashierNames = Connection.server.RetrieveCashierNames();
            foreach(string CashierName in CashierNames)
            {
                comboBox2.Items.Add(CashierName);
            }
        }

        public void DisplayItemTypes()
        {
            ItemType.Items.Clear();
            comboBox1.Items.Clear();
            itemtypes.Clear();

            this.ItemTypesList = Connection.server.RetrieveItemTypes();

            foreach (ItemType Itemtype in this.ItemTypesList)
            {
                this.itemtypes.Add(Itemtype.ID, Itemtype.Name);
            }

            flowLayoutPanel3.Controls.Clear();

            plusItemTypeLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                plusItemTypeLbl.Text = "إضافة صنف مواد جديد";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                plusItemTypeLbl.Text = "Add a new Item Type";
            }
            plusItemTypeLbl.ForeColor = Color.Black;
            plusItemTypeLbl.Font = new Font(plusItemTypeLbl.Font.FontFamily, 14);
            flowLayoutPanel3.Controls.Add(plusItemTypeLbl);

            AddItemType = new TextBox();
            AddItemType.Text = "";
            AddItemType.Size = new Size(351, 20);
            flowLayoutPanel3.Controls.Add(AddItemType);

            plusItemTypePB = new PictureBox();
            plusItemTypePB.Image = Resources.plus;
            plusItemTypePB.BorderStyle = BorderStyle.Fixed3D;
            plusItemTypePB.Cursor = Cursors.Hand;
            plusItemTypePB.BackColor = Color.FromArgb(59, 89, 152);
            plusItemTypePB.SizeMode = PictureBoxSizeMode.StretchImage;
            plusItemTypePB.Click += (sender, e) => { AddItemTypeHandler(sender, e); };
            flowLayoutPanel3.Controls.Add(plusItemTypePB);

            ItemTypeLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                ItemTypeLbl.Text = "أصناف المواد المضافه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                ItemTypeLbl.Text = "Added Item Types";
            }
            ItemTypeLbl.ForeColor = Color.Black;
            ItemTypeLbl.Font = new Font(plusItemTypeLbl.Font.FontFamily, 14);
            flowLayoutPanel3.Controls.Add(ItemTypeLbl);

            saveItemTypesBtn = new Button();
            saveItemTypesBtn.Name = "SaveItemTypesButton";
            saveItemTypesBtn.Tag = "SaveItemTypesButton";
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                saveItemTypesBtn.Text = "حفظ التصانيف";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                saveItemTypesBtn.Text = "Save Item Type";
            }
            saveItemTypesBtn.Size = new Size(340, 45);
            saveItemTypesBtn.ForeColor = Color.White;
            saveItemTypesBtn.BackColor = Color.FromArgb(59, 89, 152);
            saveItemTypesBtn.Font = new Font(saveItemTypesBtn.Font.FontFamily, 14, FontStyle.Bold);
            saveItemTypesBtn.Click += (sender, e) => { SaveItemTypesHandler(sender, e); };

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                ItemType.Items.Add(new ItemTypeCategory("غير مصنف"));
                comboBox1.Items.Add(new ItemTypeCategory("غير مصنف"));
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                ItemType.Items.Add(new ItemTypeCategory("Unclassified"));
                comboBox1.Items.Add(new ItemTypeCategory("Unclassified"));
            }

            int i = 0;

            foreach (KeyValuePair<int, string> itemtype in this.itemtypes)
            {
                minusItemTypePB = new PictureBox();
                minusItemTypePB.Image = Resources.minus;
                minusItemTypePB.Size = new Size(50, 50);
                minusItemTypePB.BorderStyle = BorderStyle.Fixed3D;
                minusItemTypePB.Cursor = Cursors.Hand;
                minusItemTypePB.BackColor = Color.FromArgb(59, 89, 152);
                minusItemTypePB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusItemTypePB.Click += (sender, e) => { DeleteItemTypeHandler(sender, e, itemtype.Key); };
                flowLayoutPanel3.Controls.Add(minusItemTypePB);

                TextBox tempItemtypetxt = new TextBox();
                tempItemtypetxt.Name = itemtype.Value;
                tempItemtypetxt.Text = itemtype.Value;
                tempItemtypetxt.Tag = itemtype.Key;
                tempItemtypetxt.Size = new Size(340, 20);
                ItemTypeNamestxt.Add(tempItemtypetxt);
                flowLayoutPanel3.Controls.Add(tempItemtypetxt);
                tabControl2.TabPages.Add(itemtype.Value);
                ItemType.Items.Add(new ItemTypeCategory(itemtype.Value));
                comboBox1.Items.Add(new ItemTypeCategory(itemtype.Value));
            }
            ItemType.SelectedIndex = 0;

            flowLayoutPanel3.Controls.Add(saveItemTypesBtn);
        }

        public void DisplayWarehouses()
        {
            Warehouse.Items.Clear();
            WarehousesQuantityList.Items.Clear();
            WarehouseEntryExitList.Items.Clear();
            warehouses.Clear();

            this.WarehousesList = Connection.server.RetrieveWarehouses();

            foreach (Warehouse Warehouse in this.WarehousesList)
            {
                this.warehouses.Add(Warehouse.ID, Warehouse.Name);
            }

            flowLayoutPanel2.Controls.Clear();

            plusWarehouseLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                plusWarehouseLbl.Text = "اضافة مستودع جديد";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                plusWarehouseLbl.Text = "Add a new Warehouse";
            }
            plusWarehouseLbl.ForeColor = Color.Black;
            plusWarehouseLbl.Font = new Font(plusWarehouseLbl.Font.FontFamily, 14);
            flowLayoutPanel2.Controls.Add(plusWarehouseLbl);

            AddWarehouse = new TextBox();
            AddWarehouse.Text = "";
            AddWarehouse.Size = new Size(351, 20);
            flowLayoutPanel2.Controls.Add(AddWarehouse);

            plusWarehousePB = new PictureBox();
            plusWarehousePB.Image = Resources.plus;
            plusWarehousePB.BorderStyle = BorderStyle.Fixed3D;
            plusWarehousePB.Cursor = Cursors.Hand;
            plusWarehousePB.BackColor = Color.FromArgb(59, 89, 152);
            plusWarehousePB.SizeMode = PictureBoxSizeMode.StretchImage;
            plusWarehousePB.Click += (sender, e) => { AddWarehouseHandler(sender, e); };
            flowLayoutPanel2.Controls.Add(plusWarehousePB);

            WarehouseLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                WarehouseLbl.Text = "المستودعات المضافه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                WarehouseLbl.Text = "Added Warehouses";
            }
            WarehouseLbl.ForeColor = Color.Black;
            WarehouseLbl.Font = new Font(plusWarehouseLbl.Font.FontFamily, 14);
            flowLayoutPanel2.Controls.Add(WarehouseLbl);

            saveWarehousesBtn = new Button();
            saveWarehousesBtn.Name = "SaveWarehousesButton";
            saveWarehousesBtn.Tag = "SaveWarehousesButton";
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                saveWarehousesBtn.Text = "حفظ المستودعات";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                saveWarehousesBtn.Text = "Save Warehouse";
            }
            saveWarehousesBtn.Size = new Size(340, 45);
            saveWarehousesBtn.ForeColor = Color.White;
            saveWarehousesBtn.BackColor = Color.FromArgb(59, 89, 152);
            saveWarehousesBtn.Font = new Font(saveWarehousesBtn.Font.FontFamily, 14, FontStyle.Bold);
            saveWarehousesBtn.Click += (sender, e) => { SaveWarehousesHandler(sender, e); };
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Warehouse.Items.Add(new WarehouseCategory("غير موجود"));
                WarehouseEntryExitList.Items.Add(new WarehouseCategory("غير موجود"));
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Warehouse.Items.Add(new WarehouseCategory("Inexistent"));
                WarehouseEntryExitList.Items.Add(new WarehouseCategory("Inexistent"));
            }
            //WarehousesQuantityList.Items.Add(new WarehouseCategory("غير موجود"));
            //WarehouseEntryExitList.Items.Add(new WarehouseCategory("غير موجود"));

            int i = 0;

            foreach (KeyValuePair<int, string> warehouse in this.warehouses)
            {
                minusWarehousePB = new PictureBox();
                minusWarehousePB.Image = Resources.minus;
                minusWarehousePB.Size = new Size(50, 50);
                minusWarehousePB.BorderStyle = BorderStyle.Fixed3D;
                minusWarehousePB.Cursor = Cursors.Hand;
                minusWarehousePB.BackColor = Color.FromArgb(59, 89, 152);
                minusWarehousePB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusWarehousePB.Click += (sender, e) => { DeleteWarehouseHandler(sender, e, warehouse.Key); };
                flowLayoutPanel2.Controls.Add(minusWarehousePB);

                TextBox tempWarehousetxt = new TextBox();
                tempWarehousetxt.Name = warehouse.Value;
                tempWarehousetxt.Text = warehouse.Value;
                tempWarehousetxt.Tag = warehouse.Key;
                tempWarehousetxt.Size = new Size(340, 20);
                WarehouseNamestxt.Add(tempWarehousetxt);
                flowLayoutPanel2.Controls.Add(tempWarehousetxt);
                tabControl2.TabPages.Add(warehouse.Value);
                Warehouse.Items.Add(new WarehouseCategory(warehouse.Value));
                WarehousesQuantityList.Items.Add(new WarehouseCategory(warehouse.Value));
                WarehouseEntryExitList.Items.Add(new WarehouseCategory(warehouse.Value));
            }
            Warehouse.SelectedIndex = 0;

            flowLayoutPanel2.Controls.Add(saveWarehousesBtn);
        }

        public void DisplayFavorites()
        {
            tabControl2.TabPages.Clear();
            FavoriteCategories.Items.Clear();
            this.favorites.Clear();

            this.Categories = Connection.server.RetrieveFavoriteCategories();

            foreach (Category Category in this.Categories)
            {
                this.favorites.Add(Category.ID, Category.Name);
            }

            flowLayoutPanel1.Controls.Clear();
            for (int z = 0; z < flowLayoutPanels.Count; z++)
                flowLayoutPanels[z].Controls.Clear();

            plusFavoriteLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                plusFavoriteLbl.Text = "إضافة مجلد مفضل جديد";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                plusFavoriteLbl.Text = "Add a new Favorite Category";
            }
            plusFavoriteLbl.ForeColor = Color.Black;
            plusFavoriteLbl.Font = new Font(plusFavoriteLbl.Font.FontFamily, 14);
            flowLayoutPanel1.Controls.Add(plusFavoriteLbl);

            AddFavorite = new TextBox();
            AddFavorite.Text = "";
            AddFavorite.Size = new Size(351, 20);
            flowLayoutPanel1.Controls.Add(AddFavorite);

            plusFavoritePB = new PictureBox();
            plusFavoritePB.Image = Resources.plus;
            plusFavoritePB.BorderStyle = BorderStyle.Fixed3D;
            plusFavoritePB.Cursor = Cursors.Hand;
            plusFavoritePB.BackColor = Color.FromArgb(59, 89, 152);
            plusFavoritePB.SizeMode = PictureBoxSizeMode.StretchImage;
            plusFavoritePB.Click += (sender, e) => { AddFavoritesHandler(sender, e); };
            flowLayoutPanel1.Controls.Add(plusFavoritePB);

            FavoriteLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                FavoriteLbl.Text = "مجلدات المفضلات المضافه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                FavoriteLbl.Text = "Added Favorite Categories";
            }
            FavoriteLbl.ForeColor = Color.Black;
            FavoriteLbl.Font = new Font(plusFavoriteLbl.Font.FontFamily, 14);
            flowLayoutPanel1.Controls.Add(FavoriteLbl);
            
            saveFavoritesBtn = new Button();
            saveFavoritesBtn.Name = "SaveFavoritesButton";
            saveFavoritesBtn.Tag = "SaveFavoritesButton";
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                saveFavoritesBtn.Text = "حفظ مجلد المفضلات";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                saveFavoritesBtn.Text = "Save Favorite Category";
            }
            saveFavoritesBtn.Size = new Size(340, 45);
            saveFavoritesBtn.ForeColor = Color.White;
            saveFavoritesBtn.BackColor = Color.FromArgb(59, 89, 152);
            saveFavoritesBtn.Font = new Font(saveFavoritesBtn.Font.FontFamily, 14, FontStyle.Bold);
            saveFavoritesBtn.Click += (sender, e) => { SaveFavoritesHandler(sender, e); };
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                FavoriteCategories.Items.Add(new FavoriteCategory("غير مفضله"));
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                FavoriteCategories.Items.Add(new FavoriteCategory("Not Favorited"));
            }

            int i = 0;

            foreach (KeyValuePair<int, string> favorite in this.favorites)
            {
                minusFavoritePB = new PictureBox();
                minusFavoritePB.Image = Resources.minus;
                minusFavoritePB.Size = new Size(50, 50);
                minusFavoritePB.BorderStyle = BorderStyle.Fixed3D;
                minusFavoritePB.Cursor = Cursors.Hand;
                minusFavoritePB.BackColor = Color.FromArgb(59, 89, 152);
                minusFavoritePB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusFavoritePB.Click += (sender, e) => { DeleteFavoritesHandler(sender, e, favorite.Key); };
                flowLayoutPanel1.Controls.Add(minusFavoritePB);

                TextBox tempFavoritetxt = new TextBox();
                tempFavoritetxt.Name = favorite.Value;
                tempFavoritetxt.Text = favorite.Value;
                tempFavoritetxt.Tag = favorite.Key;
                tempFavoritetxt.Size = new Size(340, 20);
                FavoriteNamestxt.Add(tempFavoritetxt);
                flowLayoutPanel1.Controls.Add(tempFavoritetxt);
                tabControl2.TabPages.Add(favorite.Value);
                FavoriteCategories.Items.Add(new FavoriteCategory(favorite.Value));
            }
            FavoriteCategories.SelectedIndex = 0;

            flowLayoutPanel1.Controls.Add(saveFavoritesBtn);
            
            DisplayFavoriteItems();
        }

        public void DisplayFavoriteItems()
        {
            int i = 0;
            foreach (KeyValuePair<int, string> favorite in this.favorites)
            {
                int key = favorite.Key;
                flowLayoutPanels.Add(new FlowLayoutPanel());
                flowLayoutPanels[i].Size = new Size(481, 524);
                flowLayoutPanels[i].Location = new Point(0, 1);
                flowLayoutPanels[i].FlowDirection = FlowDirection.TopDown;
                flowLayoutPanels[i].AutoScroll = true;
                flowLayoutPanels[i].WrapContents = true;
                flowLayoutPanels[i].BackColor = Color.White;
                tabControl2.TabPages[i].Controls.Add(flowLayoutPanels[i]);
                tabControl2.TabPages[i++].BackColor = Color.White;

                for(int y = 0; y < tabControl2.TabPages.Count; y++)
                {
                    string favoriteName = tabControl2.TabPages[y].Text;
                    if (favoriteName == favorite.Value)
                    {
                        retrievedFavoriteItems = Connection.server.RetrieveFavoriteItems(favorite.Key).Item1;
                        foreach (Item favoriteItem in retrievedFavoriteItems)
                        {
                            Button btn = new Button();
                            btn.Name = favoriteItem.GetName();
                            btn.Tag = favoriteItem.GetItemBarCode();
                            byte[] picture = Connection.server.RetrieveItemPictureFromBarCode(favoriteItem.GetItemBarCode()).picture;
                            var stream = new MemoryStream(picture);
                            btn.BackgroundImage = Image.FromStream(stream);
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Text = favoriteItem.GetName();
                            btn.Font = new Font("Arial", 14f, FontStyle.Bold);
                            btn.UseCompatibleTextRendering = true;
                            btn.BackColor = Color.FromArgb(59, 89, 152); ;
                            btn.ForeColor = Color.White;
                            btn.Height = 100;
                            btn.Width = 100;
                            btn.Click += (sender, e) => { AddFavoriteItemHandler(sender, e, favoriteItem); };
                            flowLayoutPanels[y].Controls.Add(btn);
                        }
                    }
                }
            }
        }

        void DeleteItemTypeHandler(object sender, EventArgs e, int Index)
        {
            try
            {
                bool deletedItemType = false;
                deletedItemType = Connection.server.DeleteItemType(Index);
                if (deletedItemType)
                {
                    DisplayItemTypes();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حذف صنف المواد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Item Type was deleted.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حذف صنف المواد", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Item Type.", Application.ProductName);
                }
            }
        }

        void AddItemTypeHandler(object sender, EventArgs e)
        {
            try
            {
                bool addedItemType = false;
                addedItemType = Connection.server.InsertItemType(AddItemType.Text);
                if (addedItemType)
                {
                    DisplayItemTypes();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة أصناف المواد الجديده", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Item Type was added.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ أصناف المواد الجديده", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to add new Item Type.", Application.ProductName);
                }
            }
        }

        void SaveItemTypesHandler(object sender, EventArgs e)
        {
            try
            {
                bool updatedItemTypes = false;
                int i = 0;
                foreach (KeyValuePair<int, string> itemtype in itemtypes)
                {
                    updatedItemTypes = Connection.server.UpdateItemTypes(Convert.ToInt32(ItemTypeNamestxt[i].Tag), ItemTypeNamestxt[i++].Text);
                }
                if (updatedItemTypes)
                {
                    DisplayItemTypes();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ أصناف المواد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Item Types were saved.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ أصناف المواد", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save Item Types.", Application.ProductName);
                }
            }
        }

        void DeleteWarehouseHandler(object sender, EventArgs e, int Index)
        {
            try
            {
                bool deletedWarehouse = false;
                deletedWarehouse = Connection.server.DeleteWarehouse(Index);
                if (deletedWarehouse)
                {
                    DisplayWarehouses();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حذف المستودع", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Warehouse was deleted.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حذف المستودع", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Warehouse.", Application.ProductName);
                }
            }
        }

        void AddWarehouseHandler(object sender, EventArgs e)
        {
            try
            {
                bool addedWarehouse = false;
                addedWarehouse = Connection.server.InsertWarehouse(AddWarehouse.Text);
                if (addedWarehouse)
                {
                    DisplayWarehouses();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة المستودع الجديد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Warehouse was added.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ المستودع الجديد", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to add new Warehouse.", Application.ProductName);
                }
            }
        }

        void SaveWarehousesHandler(object sender, EventArgs e)
        {
            try
            {
                bool updatedWarehouses = false;
                int i = 0;
                foreach (KeyValuePair<int, string> warehouse in warehouses)
                {
                    updatedWarehouses = Connection.server.UpdateWarehouses(Convert.ToInt32(WarehouseNamestxt[i].Tag), WarehouseNamestxt[i++].Text);
                }
                if (updatedWarehouses)
                {
                    DisplayWarehouses();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ المستودعات", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Werehouses was saved.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ المستودعات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save warehouses.", Application.ProductName);
                }
            }
        }

        void AddFavoriteItemHandler(object sender, EventArgs e, Item item)
        {
            try
            {
                int y = 0;
                bool exists = false;
                foreach (DataGridViewRow row in ItemsPendingPurchase.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                    {
                        if (row.Cells[1].Value.ToString().Equals(item.GetItemBarCode()))
                        {
                            row.Cells["pendingPurchaseItemQuantity"].Value = Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value) + 1;
                            exists = true;
                        }
                    }
                }
                if (!exists && item != null)
                {
                    var index = ItemsPendingPurchase.Rows.Add();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = "1";
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                    decimal priceAfterSales = Convert.ToDecimal(item.GetPriceTax());

                    if (customersaleItems.Count > 0)
                    {
                        for (int i = 0; i < customersaleItems.Count; i++)
                        {
                            if (customersaleItems[i].GetItemBarCode() == item.GetItemBarCode())
                            {
                                priceAfterSales = customersaleItems[i].customerPrice;
                            }
                        }
                    }

                    if (saleItems.Count > 0)
                    {
                        for (int i = 0; i < saleItems.Count; i++)
                        {
                            if (saleItems[i].GetItemBarCode() == item.GetItemBarCode())
                            {
                                priceAfterSales = (Convert.ToDecimal(item.GetPriceTax()) * saleItems[i].saleRate / 100);
                                priceAfterSales = Convert.ToDecimal(item.GetPriceTax()) - priceAfterSales;
                            }
                        }
                    }

                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                    richTextBox6.ResetText();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        richTextBox6.AppendText(" :الباركود " + item.GetItemBarCode());
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox6.AppendText(" Barcode: " + item.GetItemBarCode());
                    }
                }
                calculateStatistics();
                ApplyDiscountsToPendingItems();
                tabControl1.Select();
                tabControl1.Focus();
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لا يمكن اضافة الماده المفضله", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to add Favorite Item.", Application.ProductName);
                }
            }
        }

        void DeleteFavoritesHandler(object sender, EventArgs e, int Index)
        {
            try
            {
                bool deletedFavoriteCategory = false;
                deletedFavoriteCategory = Connection.server.DeleteFavoriteCategory(Index);
                if (deletedFavoriteCategory)
                {
                    DisplayFavorites();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حذف مجلد المفضلات", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Favorite Category was deleted.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حذف المفضلات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Favorite Category.", Application.ProductName);
                }
            }
        }
        void DeletePrintersHandler(object sender, EventArgs e, int Index)
        {
            try
            {
                bool deletedPrinter = false;
                deletedPrinter = Connection.server.DeletePrinter(Environment.MachineName, Index);
                if (deletedPrinter)
                {
                    DisplayPrinters();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حذف الطابعة", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Printer was deleted.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayPrinters();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حذف الطابعة", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Printer.", Application.ProductName);
                }
            }
        }

        void AddFavoritesHandler(object sender, EventArgs e)
        {
            try
            {
                bool addedFavoriteCategory = false;
                addedFavoriteCategory = Connection.server.InsertFavoriteCategory(AddFavorite.Text);
                if (addedFavoriteCategory)
                {
                    DisplayFavorites();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة مجلد المفضلات الجديده", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Favorite Category was added.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ مجلدات المفضلات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save Favorite Categories.", Application.ProductName);
                }
            }
        }

        void AddPrintersHandler(object sender, EventArgs e)
        {
            try
            {
                bool addedPrinter = false;
                addedPrinter = Connection.server.InsertPrinter(Environment.MachineName, AddPrinter.Text);
                if (addedPrinter)
                {
                    DisplayPrinters();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة الطابعة الجديده", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Printer was added.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ مجلدات المفضلات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save Favorite Categories.", Application.ProductName);
                }
            }
        }

        void SaveFavoritesHandler(object sender, EventArgs e)
        {
            try
            {
                bool updatedFavoriteCategories = false;
                int i = 0;
                foreach(KeyValuePair<int, string> favorite in favorites)
                {
                    updatedFavoriteCategories = Connection.server.UpdateFavoriteCategories(Convert.ToInt32(FavoriteNamestxt[i].Tag), FavoriteNamestxt[i++].Text);
                }
                if (updatedFavoriteCategories)
                {
                    DisplayFavorites();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ مجلد المفضلات الجديد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Favorite Category was saved.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ مجلدات المفضلات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save Favorite Categories.", Application.ProductName);
                }
            }
        }
        void SavePrintersHandler(object sender, EventArgs e)
        {
            try
            {
                bool updatedPrinters = false;
                int i = 0;
                foreach(KeyValuePair<int, string> printer in printers)
                {
                    updatedPrinters = Connection.server.UpdatePrinters(Convert.ToInt32(PrintersNamesTV[i].Tag), PrintersNamesTV[i++].Text);
                }
                if (updatedPrinters)
                {
                    DisplayPrinters();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ الطابعات الجديدة", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("All new Printers were saved.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حفظ الطابعات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save Printers.", Application.ProductName);
                }
            }
        }

        public void button17_Click(object sender, EventArgs e)
        {
            try
            {
                int Index = ItemsPendingPurchase.CurrentCell.RowIndex;
                DataGridViewRow row = ItemsPendingPurchase.Rows[Index];
                if (row.Selected)
                {
                    if (!row.IsNewRow)
                    {
                        int quantity = Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value);
                        int deletionquantity = Convert.ToInt32(pendingPurchaseRemovalQuantity.Value);
                        if (quantity > 1 && quantity - deletionquantity > 0)
                            row.Cells["pendingPurchaseItemQuantity"].Value = quantity - deletionquantity;
                        else if (quantity - deletionquantity <= 0)
                            ItemsPendingPurchase.Rows.RemoveAt(Index);
                    }
                }
                calculateStatistics();
                BarCode = "";
                pendingPurchaseRemovalQuantity.Value = 0;
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطع حذف القطعه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Items.", Application.ProductName);
                }
            }
        }

        public void calculateStatistics()
        {
            this.totalAmount = 0;
            foreach (DataGridViewRow itemToCalculate in ItemsPendingPurchase.Rows)
            {
                if (!itemToCalculate.IsNewRow)
                {
                    this.totalAmount += Convert.ToDecimal(Connection.server.SearchInventoryItemsWithBarCode(itemToCalculate.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax()) * Convert.ToInt32(itemToCalculate.Cells["pendingPurchaseItemQuantity"].Value);
                }
            }
            
            richTextBox5.ResetText();
            richTextBox4.ResetText();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                richTextBox5.AppendText("Current Bill ID: " + this.CurrentBillNumber);
                richTextBox4.AppendText("Total: " + this.totalAmount);
            }
        }

        public void DisplayPrinters()
        {
            printers.Clear();
            PrintersNamesTV.Clear();

            frmMain.PrintersList = Connection.server.RetrievePrinters(Environment.MachineName);

            foreach (Printer printer in frmMain.PrintersList)
            {
                this.printers.Add(printer.ID, printer.Name);
            }

            flowLayoutPanel4.Controls.Clear();

            plusPrinterLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                plusPrinterLbl.Text = "إضافة طابعة جديدة";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                plusPrinterLbl.Text = "Add a new Printer";
            }
            plusPrinterLbl.ForeColor = Color.Black;
            plusPrinterLbl.Font = new Font(plusPrinterLbl.Font.FontFamily, 14);
            flowLayoutPanel4.Controls.Add(plusPrinterLbl);

            AddPrinter = new TextBox();
            AddPrinter.Text = "";
            AddPrinter.Size = new Size(351, 20);
            flowLayoutPanel4.Controls.Add(AddPrinter);

            plusPrinterPB = new PictureBox();
            plusPrinterPB.Image = Resources.plus;
            plusPrinterPB.BorderStyle = BorderStyle.Fixed3D;
            plusPrinterPB.Cursor = Cursors.Hand;
            plusPrinterPB.BackColor = Color.FromArgb(59, 89, 152);
            plusPrinterPB.SizeMode = PictureBoxSizeMode.StretchImage;
            plusPrinterPB.Click += (sender, e) => { AddPrintersHandler(sender, e); };
            flowLayoutPanel4.Controls.Add(plusPrinterPB);

            PrinterLbl = new Label();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                PrinterLbl.Text = "الطابعات المضافه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                PrinterLbl.Text = "Added Printers";
            }
            PrinterLbl.ForeColor = Color.Black;
            PrinterLbl.Font = new Font(plusPrinterLbl.Font.FontFamily, 14);
            flowLayoutPanel4.Controls.Add(PrinterLbl);

            savePrintersBtn = new Button();
            savePrintersBtn.Name = "SavePrintersButton";
            savePrintersBtn.Tag = "SavePrintersButton";
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                savePrintersBtn.Text = "حفظ الطابعات";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                savePrintersBtn.Text = "Save Printers";
            }
            savePrintersBtn.Size = new Size(340, 45);
            savePrintersBtn.ForeColor = Color.White;
            savePrintersBtn.BackColor = Color.FromArgb(59, 89, 152);
            savePrintersBtn.Font = new Font(savePrintersBtn.Font.FontFamily, 14, FontStyle.Bold);
            savePrintersBtn.Click += (sender, e) => { SavePrintersHandler(sender, e); };

            int PrinterCount = 0;

            List<MenuItem> addItemTypeToPrinterList = new List<MenuItem>();
            List<MenuItem> deleteItemTypeFromPrinterList = new List<MenuItem>();
            List<TreeView> printerListTree = new List<TreeView>();
            PrintersMenus = new List<ContextMenu>();


            foreach (KeyValuePair<int, string> printer in this.printers)
            {
                minusPrinterPB = new PictureBox();
                minusPrinterPB.Image = Resources.minus;
                minusPrinterPB.Size = new Size(50, 50);
                minusPrinterPB.BorderStyle = BorderStyle.Fixed3D;
                minusPrinterPB.Cursor = Cursors.Hand;
                minusPrinterPB.BackColor = Color.FromArgb(59, 89, 152);
                minusPrinterPB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusPrinterPB.Click += (sender, e) => { DeletePrintersHandler(sender, e, printer.Key); };
                flowLayoutPanel4.Controls.Add(minusPrinterPB);

                Label tempLabel = new Label();
                tempLabel.Text = printer.Value;
                tempLabel.ForeColor = Color.White;
                tempLabel.BackColor = Color.FromArgb(59, 89, 152);
                tempLabel.Font = new Font(tempLabel.Font.FontFamily, 14, FontStyle.Bold);
                TreeView tempTreeView = new TreeView();
                tempTreeView.Name = printer.Value;
                tempTreeView.Text = printer.Value;
                tempTreeView.Tag = printer.Key;
                List<ItemType> itemTypes = Connection.server.RetrievePrinterItemTypes(printer.Key);
                foreach (ItemType itemType in itemTypes)
                {
                    TreeNode tNode = new TreeNode();
                    tNode.Name = itemType.Name;
                    tNode.Text = itemType.Name;
                    tNode.Tag = itemType.ID;
                    tempTreeView.Nodes.Add(tNode);
                }
                ContextMenu printerMenu = new ContextMenu();

                MenuItem addItemTypeToPrinter = null;
                MenuItem deleteItemTypeFromPrinter = null;
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    addItemTypeToPrinter = new MenuItem("إضافة صنف مواد للطابعة");
                    deleteItemTypeFromPrinter = new MenuItem("حذف صنف مواد من الطابعة");
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    addItemTypeToPrinter = new MenuItem("Add Item Type to Printer");
                    deleteItemTypeFromPrinter = new MenuItem("Delete Item Type from Printer");
                }
                addItemTypeToPrinter.Click += (sender, e) => { addItemTypePrinter_Click(sender, e, PrinterCount); };
                deleteItemTypeFromPrinter.Click += (sender, e) => { deleteItemTypePrinter_Click(sender, e, PrinterCount); };
                addItemTypeToPrinterList.Add(addItemTypeToPrinter);
                deleteItemTypeFromPrinterList.Add(deleteItemTypeFromPrinter);
                printerMenu.MenuItems.Add(addItemTypeToPrinterList[PrinterCount]);
                printerMenu.MenuItems.Add(deleteItemTypeFromPrinterList[PrinterCount]);
                PrintersMenus.Add(printerMenu);
                tempTreeView.ContextMenu = PrintersMenus[PrinterCount];
                printerListTree.Add(tempTreeView);
                PrintersNamesTV.Add(printerListTree[PrinterCount]);
                flowLayoutPanel4.Controls.Add(tempLabel);
                flowLayoutPanel4.Controls.Add(PrintersNamesTV[PrinterCount]);
                PrinterCount++;
            }

            flowLayoutPanel4.Controls.Add(savePrintersBtn);
        }

        void addItemTypePrinter_Click(object sender, EventArgs e, int PrinterIndex)
        {
            PrinterIndex = 0;
            foreach(TreeView tv in PrintersNamesTV)
            {
                if (tv.Focused)
                {
                    frmAddPrinter addPrinter = new frmAddPrinter(this.itemtypes);
                    openedForm = addPrinter;
                    DialogResult result = addPrinter.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string itemTypeName = addPrinter.itemTypeName;
                        addPrinter.Dispose();
                        int printerID = (int)PrintersNamesTV[PrinterIndex].Tag;
                        int itemTypeID = Connection.server.RetrieveItemTypeID(itemTypeName);
                        if (Connection.server.AddPrinterItemType(printerID, itemTypeID))
                        {
                            DisplayPrinters();
                        }
                    }
                    break;
                }
                else
                {
                    PrinterIndex++;
                }
            }
        }

        void deleteItemTypePrinter_Click(object sender, EventArgs e, int PrinterIndex)
        {
            for (int PI = 0; PI < PrintersNamesTV.Count; PI++)
            {
                if (PrintersNamesTV[PI].Focused)
                {
                    foreach (TreeNode tn in PrintersNamesTV[PI].Nodes)
                    {
                        if (PrintersNamesTV[PI].SelectedNode != null)
                        {
                            if (Connection.server.DeletePrinterItemType((int)PrintersNamesTV[PI].Tag, (int)PrintersNamesTV[PI].SelectedNode.Tag))
                            {
                                DisplayPrinters();
                            }
                            break;
                        }
                    }
                }
            }
        }

        public void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void button23_Click(object sender, EventArgs e)
        {
            try
            {
                int Index = ItemsPendingPurchase.CurrentCell.RowIndex;
                DataGridViewRow row = ItemsPendingPurchase.Rows[Index];
                if (row.Selected)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells["pendingPurchaseItemPrice"].Value = pendingPurchaseNewPrice.Value;
                        row.Cells["pendingPurchaseItemPriceTax"].Value = pendingPurchaseNewPriceTax.Value;
                    }
                }
                calculateStatistics();
                BarCode = "";
                pendingPurchaseNewPrice.Value = 0;
                pendingPurchaseNewPriceTax.Value = 0;
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطع تعديل أسعار القطعه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to edit Item price.", Application.ProductName);
                }
            }
        }

        public void button24_Click(object sender, EventArgs e)
        {
            try
            {
                int Index = ItemsPendingPurchase.CurrentCell.RowIndex;
                DataGridViewRow row = ItemsPendingPurchase.Rows[Index];
                if (row.Selected)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells["pendingPurchaseItemQuantity"].Value = pendingPurchaseNewQuantity.Value;
                        if (Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value) == 0)
                            ItemsPendingPurchase.Rows.RemoveAt(Index);
                    }
                }
                calculateStatistics();
                BarCode = "";
                pendingPurchaseNewPrice.Value = 0;
                pendingPurchaseNewPriceTax.Value = 0;
                pendingPurchaseNewQuantity.Value = 0;
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطع تعديل أسعار القطعه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to edit Item price.", Application.ProductName);
                }
            }
        }

        public void searchItemDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        public void BtnSearchItem_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchInventoryItems(txtItemNameSearch.Text, nudItemBarCodeSearch.Text, (int)frmLogin.pickedLanguage);
            DgvInventory.DataSource = RetrievedItems.Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DgvInventory.Columns["InventoryItemName"].HeaderText = "إسم القطعة";
                DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "باركود القطعه";
                DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "عدد القطعه";
                DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "سعر الشراء";
                DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "سعر القطعة";
                DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "سعر القطعة بالضريبة";
                DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "المصنف المفضل";
                DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "المستودع";
                DgvInventory.Columns["InventoryItemType"].HeaderText = "تصنيف المادة";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DgvInventory.Columns["InventoryItemName"].HeaderText = "Item Name";
                DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "Item Barcode";
                DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "Item Quantity";
                DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "Item Buy Price";
                DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "Sell Price";
                DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "Sell Price Tax";
                DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "Favorite Category";
                DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "Warehouse";
                DgvInventory.Columns["InventoryItemType"].HeaderText = "Item Type";
            }
        }

        public void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemName.Text != "" && FavoriteCategories.SelectedItem.ToString() != "" && ItemType.SelectedItem.ToString() != "" && Warehouse.SelectedItem.ToString() != "")
                {
                    Item newItem = new Item();
                    newItem.SetName(txtItemName.Text);
                    newItem.SetBarCode(txtItemBarCode.Text);
                    newItem.SetQuantity(Convert.ToInt32(nudItemQuantity.Value));
                    newItem.SetBuyPrice(nudItemBuyPrice.Value);
                    newItem.SetPrice(nuditemPrice.Value);
                    newItem.SetPriceTax(nuditemPriceTax.Value);
                    if (ItemType.SelectedItem != null)
                    {
                        int ItemTypeID = Connection.server.RetrieveItemTypeID(ItemType.SelectedItem.ToString());
                        newItem.SetItemTypeID(ItemTypeID);
                    }
                    else newItem.SetItemTypeID(0);
                    if (Warehouse.SelectedItem != null)
                    {
                        int WarehouseID = Connection.server.RetrieveWarehouseID(Warehouse.SelectedItem.ToString());
                        newItem.SetWarehouseID(WarehouseID);
                    }
                    else newItem.SetWarehouseID(0);
                    if (FavoriteCategories.SelectedItem != null)
                    {
                        int Category = Connection.server.RetrieveFavoriteCategoryID(FavoriteCategories.SelectedItem.ToString());
                        newItem.SetFavoriteCategory(Category);
                    }
                    else newItem.SetFavoriteCategory(0);
                    newItem.SetDate(DateTime.Now);
                    newItem.QuantityWarning = Convert.ToInt32(QuantityWarning.Value);
                    newItem.ProductionDate = ProductionDate.Value;
                    newItem.ExpirationDate = ExpirationDate.Value;
                    newItem.EntryDate = EntryDate.Value;

                    if (PBAddProfilePicture.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        PBAddProfilePicture.Image.Save(ms, PBAddProfilePicture.Image.RawFormat);
                        byte[] a = ms.GetBuffer();
                        ms.Close();
                        newItem.SetPicture(a);
                    }

                    if (Connection.server.InsertItem(newItem))
                    {
                        this.ItemsList = DisplayData();
                        this.CapitalAmount = Convert.ToDecimal(Connection.server.GetCapitalAmount());
                        CapitalAmountnud.Value = CapitalAmount;
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لم نتمكن من اضافة الماده الجديده بسبب مشكله في المعلومات المدخلة", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Unable to add new Item because of an issue with filled data.", Application.ProductName);
                        }
                    }
                    ClearInput();
                    DisplayFavorites();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show("!الرجاء أدخل المعلومات المطلوبه", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Please fill required fields!", Application.ProductName);
                    }
                    ClearInput();
                }
            } catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show("!الرجاء أدخل المعلومات المطلوبه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please fill required fields!", Application.ProductName);
                }
                ClearInput();
            }
        }



        public void ClearInput()
        {
            txtItemName.Text = "";
            txtItemBarCode.Text = "";
            nudItemQuantity.Value = 0;
            nudItemBuyPrice.Value = 0;
            nuditemPrice.Value = 0;
            nuditemPriceTax.Value = 0;
            ItemType.SelectedIndex = 0;
            try
            {
                Warehouse.SelectedIndex = 0;
            }
            catch { }
            try
            {
                FavoriteCategories.SelectedIndex = 0;
            }
            catch { }
            QuantityWarning.Value = 0;
            ProductionDate.Value = DateTime.Now;
            ExpirationDate.Value = DateTime.Now;
            EntryDate.Value = DateTime.Now;
            ID = 0;
            BtnUpdateItem.Enabled = false;
            BtnDeleteItem.Enabled = false;
        }

        public void DataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            DgvInventory.Refresh();
        }

        public List<Bill> DisplayPortedBills()
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrievePortedBills();
            dgvPortedSales.DataSource = RetrievedBills.Item2;
            return RetrievedBills.Item1;
        }

        public List<Bill> DisplayBillsEdit()
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveBills();
            dgvBillsEdit.DataSource = RetrievedBills.Item2;
            return RetrievedBills.Item1;
        }

        public List<Bill> DisplayVendorBills()
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveVendorBills();
            dgvVendorBills.DataSource = RetrievedBills.Item2;
            return RetrievedBills.Item1;
        }

        public List<Bill> DisplayBills()
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveBills();
            dgvBills.DataSource = RetrievedBills.Item2;
            return RetrievedBills.Item1;
        }

        public List<Item> DisplayData()
        {
            Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage);
            DgvInventory.DataSource = RetrievedItems.Item2;


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DgvInventory.Columns["InventoryItemName"].HeaderText = "إسم القطعة";
                DgvInventory.Columns["ItemID"].HeaderText = "رقم القطعه";
                DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "باركود القطعه";
                DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "عدد القطعه";
                DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "سعر الشراء";
                DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "سعر القطعة";
                DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "سعر القطعة بالضريبة";
                DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "المصنف المفضل";
                DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "المستودع";
                DgvInventory.Columns["InventoryItemType"].HeaderText = "تصنيف المادة";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DgvInventory.Columns["InventoryItemName"].HeaderText = "Item Name";
                DgvInventory.Columns["ItemID"].HeaderText = "Item ID";
                DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "Item Barcode";
                DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "Item Quantity";
                DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "Item Buy Price";
                DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "Sell Price";
                DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "Sell Price Tax";
                DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "Favorite Category";
                DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "Warehouse";
                DgvInventory.Columns["InventoryItemType"].HeaderText = "Item Type";
            }

            for (int i = 0; i < DgvInventory.Columns.Count; i++)
            {
                if (DgvInventory.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)DgvInventory.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            }

            return RetrievedItems.Item1;
        }

        public void DisplayAbsence()
        {
            DataTable RetrievedAbsences = Connection.server.RetrieveAbsence(DateTime.Now, DateTime.Now);
            dgvAbsence.DataSource = RetrievedAbsences;
        }

        public void DisplayEmployees()
        {
            DataTable RetrievedEmployees = Connection.server.RetrieveEmployees();
            dgvEmployees.DataSource = RetrievedEmployees;
        }

        public List<Account> DisplayUsers()
        {
            Tuple<List<Account>, DataTable> RetrievedUsers = Connection.server.RetrieveUsers();
            dgvUsers.DataSource = RetrievedUsers.Item2;
            return RetrievedUsers.Item1;
        }

        public void BtnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authority == 1)
                {
                    frmAuth frmAuth = new frmAuth();
                    openedForm = frmAuth;
                    frmAuth.ShowDialog();
                    if (frmAuth.dialogResult == DialogResult.OK)
                    {
                        if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                        {
                            if (txtItemName.Text != "" && txtItemBarCode.Text != "")
                            {
                                Item newItem = new Item();

                                newItem.SetName(txtItemName.Text);
                                newItem.SetBarCode(CurrentItemBarcode);
                                newItem.ItemNewBarCode = txtItemBarCode.Text;
                                newItem.SetQuantity(Convert.ToInt32(nudItemQuantity.Value));
                                newItem.SetBuyPrice(Convert.ToDecimal(nudItemBuyPrice.Value));
                                newItem.SetPrice(Convert.ToDecimal(nuditemPrice.Value));
                                newItem.SetPriceTax(Convert.ToDecimal(nuditemPriceTax.Value));
                                if (ItemType.SelectedItem != null)
                                {
                                    int ItemTypeID = Connection.server.RetrieveItemTypeID(ItemType.SelectedItem.ToString());
                                    newItem.SetItemTypeID(ItemTypeID);
                                }
                                else newItem.SetItemTypeID(0);
                                if (Warehouse.SelectedItem != null)
                                {
                                    int WarehouseID = Connection.server.RetrieveWarehouseID(Warehouse.SelectedItem.ToString());
                                    newItem.SetWarehouseID(WarehouseID);
                                }
                                else newItem.SetWarehouseID(0);
                                if (FavoriteCategories.SelectedItem != null)
                                {
                                    int Category = Connection.server.RetrieveFavoriteCategoryID(FavoriteCategories.SelectedItem.ToString());
                                    newItem.SetFavoriteCategory(Category);
                                }
                                else newItem.SetFavoriteCategory(0);
                                newItem.QuantityWarning = Convert.ToInt32(QuantityWarning.Value);
                                newItem.ProductionDate = ProductionDate.Value;
                                newItem.ExpirationDate = ExpirationDate.Value;
                                newItem.EntryDate = EntryDate.Value;

                                if (PBAddProfilePicture.Image != null)
                                {
                                    MemoryStream ms = new MemoryStream();
                                    PBAddProfilePicture.Image.Save(ms, PBAddProfilePicture.Image.RawFormat);
                                    byte[] a = ms.GetBuffer();
                                    ms.Close();
                                    newItem.SetPicture(a);
                                }

                                if (Connection.server.UpdateItem(newItem))
                                {
                                    this.ItemsList = DisplayData();
                                    DisplayFavorites();
                                }
                                else
                                {
                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        MessageBox.Show(".لم نتمكن من تحديث معلومات الماده بسبب مشكله في المعلومات المدخله", Application.ProductName);
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        MessageBox.Show("Unable to update Item details because of an issue with filled data.", Application.ProductName);
                                    }
                                }
                                ClearInput();
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".الرجاء اختيار سطر ماده من الجدول", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Please pick an Item Row from the Grid.", Application.ProductName);
                                }
                                return;
                            }
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Incorrect Password.", Application.ProductName);
                            }
                            return;
                        }
                    }
                    else return;
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".فقط حساب إداري بامكانه تحديث المواد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Only Administrators may update Items.", Application.ProductName);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من تحديث معلومات الماده بسبب مشكله في إدخال كلمة السر", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to update Item details because of an issue with Password entry.", Application.ProductName);
                }
                return;
            }
        }

        public void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authority == 1)
                {
                    frmAuth frmAuth = new frmAuth();
                    openedForm = frmAuth;
                    frmAuth.ShowDialog();
                    if (frmAuth.dialogResult == DialogResult.OK)
                    {
                        if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                        {
                            int deletedCount = 0;
                            foreach (DataGridViewRow row in DgvInventory.Rows)
                            {
                                if (row.Selected == true)
                                {
                                    if (Connection.server.DeleteItem(row.Cells[2].Value.ToString()))
                                    {
                                        deletedCount++;
                                    }
                                }
                            }
                            this.ItemsList = DisplayData();
                            DisplayFavorites();
                            ClearInput();
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Incorrect Password.", Application.ProductName);
                            }
                            return;
                        }
                    } else
                    {
                        return;
                    }
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".فقط حساب إداري بامكانه حذف المواد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Only Administrators may delete Items.", Application.ProductName);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من حذف الماده بسبب مشكله في إدخال كلمة السر", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Item because of an issue with Password entry.", Application.ProductName);
                }
            }
        }

        public void nudItemBarCodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSearchItem.PerformClick();
            }
        }

        public void txtItemNameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSearchItem.PerformClick();
            }
        }

        public void DgvInventory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtItemName.Text = DgvInventory.Rows[e.RowIndex].Cells["InventoryItemName"].Value.ToString();
                txtItemBarCode.Text = DgvInventory.Rows[e.RowIndex].Cells["InventoryItemBarCode"].Value.ToString();
                CurrentItemBarcode = DgvInventory.Rows[e.RowIndex].Cells["InventoryItemBarCode"].Value.ToString();
                nudItemQuantity.Value = Int32.Parse(DgvInventory.Rows[e.RowIndex].Cells["InventoryItemQuantity"].Value.ToString());
                nudItemBuyPrice.Value = Convert.ToDecimal(DgvInventory.Rows[e.RowIndex].Cells["InventoryItemBuyPrice"].Value.ToString());
                nuditemPrice.Value = Convert.ToDecimal(DgvInventory.Rows[e.RowIndex].Cells["InventoryItemSellPrice"].Value.ToString());
                decimal Tax = TaxRate * nuditemPrice.Value;
                nuditemPriceTax.Value = nuditemPrice.Value + Tax;
                FavoriteCategories.SelectedIndex = FavoriteCategories.FindStringExact(Connection.server.RetrieveFavoriteCategoryName(Convert.ToInt32(DgvInventory.Rows[e.RowIndex].Cells["FavoriteCategoryNumber"].Value.ToString()), (int)frmLogin.pickedLanguage));
                Warehouse.SelectedIndex = Warehouse.FindStringExact(Connection.server.RetrieveWarehouseName(Convert.ToInt32(DgvInventory.Rows[e.RowIndex].Cells["InventoryWarehouseID"].Value.ToString()), (int)frmLogin.pickedLanguage));
                ItemType.SelectedIndex = ItemType.FindStringExact(Connection.server.RetrieveItemTypeName(Convert.ToInt32(DgvInventory.Rows[e.RowIndex].Cells["InventoryItemTypeNumber"].Value.ToString()), (int)frmLogin.pickedLanguage));


                if (!Convert.IsDBNull(DgvInventory.Rows[e.RowIndex].Cells["ItemPicture"].Value))
                {
                    var data = (Byte[])(DgvInventory.Rows[e.RowIndex].Cells["ItemPicture"].Value);
                    var stream = new MemoryStream(data);
                    PBAddProfilePicture.Image = Image.FromStream(stream);
                }

                Item itemInfo = Connection.server.RetrieveItemsQuantityDates(txtItemBarCode.Text);

                QuantityWarning.Value = itemInfo.QuantityWarning;
                ProductionDate.Value = itemInfo.ProductionDate;
                ExpirationDate.Value = itemInfo.ExpirationDate;
                EntryDate.Value = itemInfo.EntryDate;

                BtnUpdateItem.Enabled = true;
                BtnDeleteItem.Enabled = true;
            }
            catch (Exception ex) { }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            dateTimeLbl.Text = String.Format("{0}", DateTime.Now.ToString("dddd, dd MMMM yyyy MM/dd h:mm:ss tt"));
        }

        public void nudItemQuantity_Enter(object sender, EventArgs e)
        {
            nudItemQuantity.Select(1, 1);
        }

        public void nuditemPrice_Enter(object sender, EventArgs e)
        {
            nuditemPrice.Select(0, 1);
        }

        public void nuditemPriceTax_Enter(object sender, EventArgs e)
        {
            decimal Tax = TaxRate * nuditemPrice.Value;
            nuditemPriceTax.Value = nuditemPrice.Value + Tax;
            nuditemPriceTax.Select(0, 1);
        }

        public void nuditemFavoriteCategory_Enter(object sender, EventArgs e)
        {

        }

        public void pendingPurchaseNewPrice_ValueChanged(object sender, EventArgs e)
        {
            pendingPurchaseNewPriceTax.Value = Convert.ToDecimal(pendingPurchaseNewPrice.Value * Convert.ToDecimal(TaxRate));
        }

        public void pictureBox10_Click(object sender, EventArgs e)
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لا بمكتك دفع فاتوره فارغه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Cannot pay a blank bill.", Application.ProductName);
                }
            }
            else
            {
                frmPay frmPayCash = new frmPay(this.totalAmount);
                openedForm = frmPayCash;
                frmPayCash.ShowDialog(this);

                if (frmPayCash.dialogResult == DialogResult.OK)
                {
                    this.paidAmount = frmPayCash.moneyPaid;
                    this.moneyInRegister += this.paidAmount;
                    this.remainderAmount = this.paidAmount - this.totalAmount;
                    frmPayCash.Dispose();

                    Item[] itemsToAdd = new Item[0];
                    int row = 0;
                    foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                    {
                        if (!currentBillRow.IsNewRow)
                        {
                            string itemName = currentBillRow.Cells[0].Value.ToString();
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                            decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                            decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            Array.Resize(ref itemsToAdd, itemsToAdd.Length + 1);
                            itemsToAdd[row] = new Item();
                            itemsToAdd[row].SetName(itemName);
                            itemsToAdd[row].SetBarCode(itemBarCode);
                            itemsToAdd[row].SetQuantity(itemQuantity);
                            itemsToAdd[row].SetPrice(itemPrice);
                            itemsToAdd[row++].SetPriceTax(itemPriceTax);
                            int newItemQuantity = Connection.server.GetItemQuantity(itemBarCode) - itemQuantity;
                            bool updatedQuantity = Connection.server.UpdateItemQuantity(new Item(itemName, itemBarCode, newItemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                            Tuple<List<Item>, DataTable> itemsExpirationStock = Connection.server.RetrieveExpireStockToday(DateTime.Now);
                            if (itemsExpirationStock != null)
                            {
                                if (itemsExpirationStock.Item1.Count > 0)
                                {
                                    foreach (Item item in itemsExpirationStock.Item1)
                                    {
                                        if (item.ItemBarCode == itemBarCode)
                                        {
                                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                            {
                                                MessageBox.Show("قطعه إسم " + item.ItemName + "باركود " + item.ItemBarCode + "  انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف به للتحذير.");
                                            }
                                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                            {
                                                MessageBox.Show("Item Name " + item.ItemName + "Barcode " + item.ItemBarCode + " is either expired or has less quantity in storage than defined warning limit.");
                                            }
                                        }
                                    }
                                    dgvAlerts.DataSource = itemsExpirationStock.Item2;

                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        dgvAlerts.Columns["Column42"].HeaderText = "باركود الماده";
                                        dgvAlerts.Columns["Column43"].HeaderText = "إسم الماده";
                                        dgvAlerts.Columns["Column44"].HeaderText = "تاريخ الإنتاج";
                                        dgvAlerts.Columns["Column45"].HeaderText = "تاريخ إنتهاء الصلاحيه";
                                        dgvAlerts.Columns["Column46"].HeaderText = "كمية التحذير";
                                        dgvAlerts.Columns["Column47"].HeaderText = "الكميه الحاليه";
                                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        dgvAlerts.Columns["Column42"].HeaderText = "Item Barcode";
                                        dgvAlerts.Columns["Column43"].HeaderText = "Item Name";
                                        dgvAlerts.Columns["Column44"].HeaderText = "Production Date";
                                        dgvAlerts.Columns["Column45"].HeaderText = "Expiration Date";
                                        dgvAlerts.Columns["Column46"].HeaderText = "Warning Limit";
                                        dgvAlerts.Columns["Column47"].HeaderText = "Current Quantity";
                                    }
                                }
                            }
                        }
                    }

                    Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsToAdd, frmPayCash.paybycash, DateTime.Now);
                    if (Connection.server.PayBill(billToAdd, this.cashierName))
                    {
                        // paid bill

                        printReceipt();
                        this.CapitalAmount = Connection.server.GetCapitalAmount();
                        CapitalAmountnud.Value = this.CapitalAmount;
                        label91.Text = this.CapitalAmount.ToString();
                        this.customersaleItems.Clear();
                    }
                }
                else if (frmPayCash.dialogResult == DialogResult.Ignore)
                {
                    Item[] items = new Item[0];
                    int row = 0;
                    this.paidAmount = 0;
                    this.moneyInRegister += 0;
                    this.remainderAmount = this.paidAmount - this.totalAmount;

                    foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                    {
                        if (!currentBillRow.IsNewRow)
                        {
                            string itemName = currentBillRow.Cells[0].Value.ToString();
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                            decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                            decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            Array.Resize(ref items, items.Length + 1);
                            items[row] = new Item();
                            items[row].SetName(itemName);
                            items[row].SetBarCode(itemBarCode);
                            items[row].SetQuantity(itemQuantity);
                            items[row].SetPrice(itemPrice);
                            items[row++].SetPriceTax(itemPriceTax);
                        }
                    }

                    Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                    previousBillsList.Push(billToAdd);

                    frmPayCash.Dispose();
                    this.customersaleItems.Clear();
                }

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;

                richTextBox5.ResetText();
                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                    richTextBox3.AppendText(" :المجموع السابق " + this.totalAmount);
                    richTextBox2.AppendText(" :المدفوع السابق " + this.paidAmount);
                    richTextBox1.AppendText(" :الباقي السابق " + this.remainderAmount);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                    richTextBox3.AppendText(" Previous Total: " + this.totalAmount);
                    richTextBox2.AppendText(" Previous Paid: " + this.paidAmount);
                    richTextBox1.AppendText(" Previous Remainder: " + this.remainderAmount);
                }

                this.saleItems = Connection.server.RetrieveSaleToday(DateTime.Now, 10);
                ApplyDiscountsToPendingItems();

                if (frmPayCash.dialogResult == DialogResult.Cancel)
                {
                    richTextBox1.ResetText();
                    richTextBox2.ResetText();
                    richTextBox3.ResetText();
                    richTextBox4.ResetText();
                }

                ItemsPendingPurchase.Rows.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;

                if (heldBillsCount > 0)
                {
                    heldBillsCount -= 1;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        label112.Text = " Number of pending Bills: " + heldBillsCount.ToString();
                    }
                }
            }
        }

        public void pictureBox12_Click(object sender, EventArgs e)
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to add a new Bill before filling the current Bill.", Application.ProductName);
                }
            }
            else
            {
                Item[] items = new Item[0];
                int row = 0;
                foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                {
                    if (!currentBillRow.IsNewRow)
                    {
                        string itemName = currentBillRow.Cells[0].Value.ToString();
                        string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                        int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                        decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                        decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                        Array.Resize(ref items, items.Length + 1);
                        items[row] = new Item();
                        items[row].SetName(itemName);
                        items[row].SetBarCode(itemBarCode);
                        items[row].SetQuantity(itemQuantity);
                        items[row].SetPrice(itemPrice);
                        items[row++].SetPriceTax(itemPriceTax);
                    }
                }

                this.paidAmount = 0;
                this.moneyInRegister += 0;
                this.remainderAmount = this.paidAmount - this.totalAmount;

                Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                previousBillsList.Push(billToAdd);

                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox3.AppendText(" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.AppendText(" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.AppendText(" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox3.AppendText(" Previous Total: " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.AppendText(" Previous Paid: " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.AppendText(" Previous Remainder: " + previousBillsList.Peek().getRemainderAmount().ToString());
                }

                ItemsPendingPurchase.Rows.Clear();
                this.customersaleItems.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;
                items = null;
                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                }
                heldBillsCount += 1;
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    label112.Text = " Number of Pending Bills: " + heldBillsCount.ToString();
                }
            }
        }

        public void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                if (previousBillsList.Count > 0)
                {
                    Item[] itemsBought = new Item[0];
                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            Array.Resize(ref itemsBought, itemsBought.Length + 1);
                            string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                            string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                            int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                            decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                            decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                            itemsBought[itemsBought.Length - 1] = new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now);

                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                        }
                    }
                    nextBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                    ItemsPendingPurchase.Rows.Clear();
                    Bill bill = previousBillsList.Pop();
                    //this.CurrentBillNumber = bill.getBillNumber();
                    this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    foreach (Item item in bill.getItemsList())
                    {
                        var index = ItemsPendingPurchase.Rows.Add();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                        richTextBox1.ResetText();
                        richTextBox2.ResetText();
                        richTextBox3.ResetText();
                    }

                    calculateStatistics();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("There is no previous pending Bill.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                ItemsPendingPurchase.Rows.Clear();
                Bill bill = previousBillsList.Pop();
                foreach (Item item in bill.getItemsList())
                {
                    var index = ItemsPendingPurchase.Rows.Add();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                    richTextBox1.ResetText();
                    richTextBox2.ResetText();
                    richTextBox3.ResetText();
                }

                calculateStatistics();
            }
        }

        public void pictureBox14_Click(object sender, EventArgs e)
        {
            try
            {
                if (nextBillsList.Count > 0)
                {
                    //this.CurrentBillNumber += 1;
                    Item[] itemsBought = new Item[0];
                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            Array.Resize(ref itemsBought, itemsBought.Length + 1);
                            string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                            string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                            int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                            decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                            decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                            itemsBought[itemsBought.Length - 1] = new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now);

                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                        }
                    }

                    previousBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                    ItemsPendingPurchase.Rows.Clear();
                    Bill bill = nextBillsList.Pop();
                    this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    //this.CurrentBillNumber = bill.getBillNumber();

                    foreach (Item item in bill.getItemsList())
                    {
                        var index = ItemsPendingPurchase.Rows.Add();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                        richTextBox1.ResetText();
                        richTextBox2.ResetText();
                        richTextBox3.ResetText();
                    }

                    calculateStatistics();
                }
                else {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("There is no previous pending Bill.", Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                Bill bill = nextBillsList.Pop();

                foreach (Item item in bill.getItemsList())
                {
                    ItemsPendingPurchase.Rows.Clear();
                    var index = ItemsPendingPurchase.Rows.Add();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                    richTextBox1.ResetText();
                    richTextBox2.ResetText();
                    richTextBox3.ResetText();
                }

                calculateStatistics();
            }
        }

        public void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = "تقرير المستودع";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Inventory Report";
                }
                printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Footer = "The Report was generated from User: " + this.UID;
                }
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(DgvInventory);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox15_Click_1(object sender, EventArgs e)
        {
            this.ItemsList = DisplayData();
            for (int i = 0; i < DgvInventory.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvInventory.DataSource];
                currencyManager1.SuspendBinding();
                DgvInventory.Rows[i].Selected = true;
                DgvInventory.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            DgvInventory.Refresh();


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DgvInventory.Columns["InventoryItemName"].HeaderText = "إسم القطعة";
                DgvInventory.Columns["ItemID"].HeaderText = "رقم القطعه";
                DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "باركود القطعه";
                DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "عدد القطعه";
                DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "سعر الشراء";
                DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "سعر القطعة";
                DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "سعر القطعة بالضريبة";
                DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "المصنف المفضل";
                DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "المستودع";
                DgvInventory.Columns["InventoryItemType"].HeaderText = "تصنيف المادة";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DgvInventory.Columns["InventoryItemName"].HeaderText = "Item Name";
                DgvInventory.Columns["ItemID"].HeaderText = "Item ID";
                DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "Item Barcode";
                DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "Item Quantity";
                DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "Item Buy Price";
                DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "Sell Price";
                DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "Sell Price Tax";
                DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "Favorite Category";
                DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "Warehouse";
                DgvInventory.Columns["InventoryItemType"].HeaderText = "Item Type";
            }

            nudItemBarCodeSearch.Text = "";
            txtItemNameSearch.Text = "";
        }

        public void pictureBox16_Click_1(object sender, EventArgs e)
        {
            Users = DisplayUsers();
            for (int i = 0; i < dgvUsers.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUsers.DataSource];
                currencyManager1.SuspendBinding();
                dgvUsers.Rows[i].Selected = true;
                dgvUsers.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            dgvUsers.Refresh();
        }

        public void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string UserID = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUserNameAdd.Text = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUserIDAdd.Text = UserID;
                cbAdminOrNotAdd.Checked = Convert.ToBoolean(Convert.ToDecimal(dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString()));
                button20.Enabled = true;
                button19.Enabled = true;

                this.userPermissions = Connection.server.RetrieveUserPermissions(UserID);

                customer_card_edit.Checked = this.userPermissions.customer_card_edit;
                discount_edit.Checked = this.userPermissions.discount_edit;
                price_edit.Checked = this.userPermissions.price_edit;
                receipt_edit.Checked = this.userPermissions.receipt_edit;
                inventory_edit.Checked = this.userPermissions.inventory_edit;
                expenses_edit.Checked = this.userPermissions.expenses_add;
                users_edit.Checked = this.userPermissions.users_edit;
                settings_edit.Checked = this.userPermissions.settings_edit;
                personnel_edit.Checked = this.userPermissions.personnel_edit;
                openclose_edit.Checked = this.userPermissions.openclose_edit;
            }
            catch (Exception ex) { }
        }

        public void button22_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                frmAuth frmAuth = new frmAuth();
                openedForm = frmAuth;
                frmAuth.ShowDialog();
                if (frmAuth.dialogResult == DialogResult.OK)
                {
                    if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                    {
                        if (txtUserNameAdd.Text != "" && txtUserIDAdd.Text != "" && txtUserPasswordAdd.Text != "")
                        {
                            if (txtUserIDAdd.Text.ToLower().Trim() == "admin")
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لا يمكن تسجيل رمز المستخدم admin", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Unable Register User ID admin.", Application.ProductName);
                                }
                                ClearInput();
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountName(txtUserNameAdd.Text);
                            newAccount.SetAccountUID(txtUserIDAdd.Text);
                            newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtUserPasswordAdd.Text, "PlancksoftPOS"));
                            newAccount.SetAccountAuthority(Convert.ToInt32(cbAdminOrNotAdd.Checked));
                            newAccount.customer_card_edit = customer_card_edit.Checked;
                            newAccount.discount_edit = discount_edit.Checked;
                            newAccount.price_edit = price_edit.Checked;
                            newAccount.receipt_edit = receipt_edit.Checked;
                            newAccount.inventory_edit = inventory_edit.Checked;
                            newAccount.expenses_add = expenses_edit.Checked;
                            newAccount.users_edit = users_edit.Checked;
                            newAccount.settings_edit = settings_edit.Checked;
                            newAccount.personnel_edit = personnel_edit.Checked;
                            newAccount.openclose_edit = openclose_edit.Checked;

                            if (Connection.server.Register(newAccount, this.UID, newAccount.GetAccountAuthority()))
                            {
                                Users = DisplayUsers();
                                DisplayCashierNames();
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لم نتمكن من اضافة المستخدم", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Unable to add new User.", Application.ProductName);
                                }
                            }
                            ClearInput();
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Please fill all required data!", Application.ProductName);
                            }
                            ClearInput();
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Incorrect Password.", Application.ProductName);
                        }
                        return;
                    }
                }
                else return;
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".فقط حساب إداري بامكانه إضافة المستخدمين", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Only Administrators may add new User Accounts.", Application.ProductName);
                }
                return;
            }
        }

        public void button20_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                frmAuth frmAuth = new frmAuth();
                openedForm = frmAuth;
                frmAuth.ShowDialog();
                if (frmAuth.dialogResult == DialogResult.OK)
                {
                    if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                    {
                        if (txtUserNameAdd.Text != "" && txtUserIDAdd.Text != "")
                        {
                            if (txtUserIDAdd.Text.ToLower().Trim() == "admin" && this.UID != "admin")
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لا يمكن تسجيل رمز المستخدم لأنه محجوز للحساب الإداري الرئيسي", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("admin User ID is reserved for the main Administrator Account.", Application.ProductName);
                                }
                                ClearInput();
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountName(txtUserNameAdd.Text);
                            newAccount.SetAccountUID(txtUserIDAdd.Text);
                            if (txtUserPasswordAdd.Text != "")
                                newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtUserPasswordAdd.Text, "PlancksoftPOS"));
                            newAccount.SetAccountAuthority(Convert.ToInt32(cbAdminOrNotAdd.Checked));
                            newAccount.customer_card_edit = customer_card_edit.Checked;
                            newAccount.discount_edit = discount_edit.Checked;
                            newAccount.price_edit = price_edit.Checked;
                            newAccount.receipt_edit = receipt_edit.Checked;
                            newAccount.inventory_edit = inventory_edit.Checked;
                            newAccount.expenses_add = expenses_edit.Checked;
                            newAccount.users_edit = users_edit.Checked;
                            newAccount.settings_edit = settings_edit.Checked;
                            newAccount.personnel_edit = personnel_edit.Checked;
                            newAccount.openclose_edit = openclose_edit.Checked;

                            if (Connection.server.UpdateUser(newAccount, this.UID, newAccount.GetAccountAuthority()))
                            {
                                Users = DisplayUsers();
                                DisplayCashierNames();
                                cashierNameLbl.Text = txtUserNameAdd.Text;
                                
                                applyAuthorityPermissions();
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لا يمكن تحديث المستخدم", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Cannot update User Account.", Application.ProductName);
                                }
                            }
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Please fill all required data!", Application.ProductName);
                            }
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Incorrect Password.", Application.ProductName);
                        }
                        return;
                    }
                }
                else return;
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".فقط حساب إداري بامكانه تعديل المستخدمين", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Only Administrator Accounts may alter User Accounts.", Application.ProductName);
                }
                return;
            }
        }

        public void button19_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                frmAuth frmAuth = new frmAuth();
                openedForm = frmAuth;
                frmAuth.ShowDialog();
                if (frmAuth.dialogResult == DialogResult.OK)
                {
                    if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                    {
                        if (txtUserIDAdd.Text != "")
                        {
                            if (dgvUsers.SelectedRows[0].Cells["UserID"].Value.ToString().ToLower().Trim() == "admin")
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لا يمكن حذف الحساب الإداري", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Unable to delete Administrator Account.", Application.ProductName);
                                }
                                return;
                            }
                            if (txtUserIDAdd.Text.ToLower().Trim() == this.UID.ToLower().Trim())
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لا يمكن حذف الحساب المدخول به حاليا, الرجاء الحذف من حساب إداري أخر", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Unable to delete User Account as it is currently logged in. Please delete it from another Administrator Account.", Application.ProductName);
                                }
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountUID(txtUserIDAdd.Text);

                            if (Connection.server.DeleteUser(newAccount, this.UID))
                            {
                                Users = DisplayUsers();
                                DisplayCashierNames();
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لم نتمكن من حذف المستخدم", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Unable to delete User Account.", Application.ProductName);
                                }
                            }
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Please fill all required data!", Application.ProductName);
                            }
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Incorrect Password.", Application.ProductName);
                        }
                        return;
                    }
                }
                else return;
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".فقط حساب إداري بامكانه تعديل المستخدمين", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Only Administrator Accounts are able to alter User Accounts.", Application.ProductName);
                }
                return;
            }
        }

        public void nudBillNumberSearch_Enter(object sender, EventArgs e)
        {
            nudBillNumberSearch.Select(1, 1);
        }

        public void pictureBox17_Click(object sender, EventArgs e)
        {
            List<Bill> Bills = DisplayBills();
            for (int i = 0; i < dgvBills.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvBills.DataSource];
                currencyManager1.SuspendBinding();
                dgvBills.Rows[i].Selected = true;
                dgvBills.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            dgvBills.Refresh();

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBills.Columns["Column15"].HeaderText = "رقم الفاتوره";
                dgvBills.Columns["Column16"].HeaderText = "اسم الكاشير";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column17"].HeaderText = "Net Total";
                dgvBills.Columns["Column18"].HeaderText = "Paid Amount";
                dgvBills.Columns["Column19"].HeaderText = "Remainder";
                dgvBills.Columns["Column5"].HeaderText = "Payment Method";
                dgvBills.Columns["Column64"].HeaderText = "Date";
            }
        }

        public void pictureBox18_Click(object sender, EventArgs e)
        {
            try
            {
                /*DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = "تقرير الفواتير";
                printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(DgvInventory);
                this.WindowState = FormWindowState.Maximized;
                */

                if (dgvBills.CurrentCell != null)
                {
                    int BillNumber = Convert.ToInt32(dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    string cashierName = dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    decimal totalAmount = Convert.ToDecimal(dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    decimal paidAmount = Convert.ToDecimal(dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    decimal remainderAmount = Convert.ToDecimal(dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    DateTime invoiceDate = Convert.ToDateTime(dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells[6].Value.ToString());

                    printCertainReceipt(BillNumber, cashierName, totalAmount, paidAmount, remainderAmount, invoiceDate);
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show("الرجاء إختيار فاتورة.", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Please pick a Bill.", Application.ProductName);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void dgvBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvBillItems.DataSource = RetrieveBillItems(e.RowIndex);

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "اسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد من أصل";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English) {
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Original Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
            }
        }

        public DataTable RetrieveBillItems(int Index)
        {
            try
            {
                int BillNumber = Convert.ToInt32(dgvBills.Rows[Index].Cells[0].Value.ToString());
                PrintBillNumber = BillNumber;
                Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveBillItems(BillNumber);
                return RetrievedItems.Item2;
            }
            catch (Exception ex)
            {
                DataTable Item = new DataTable();
                return Item;
            }
        }

        public void pictureBox20_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = String.Format("{0} تقرير الفاتوره رقم", PrintBillNumber);
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = String.Format("Invoice Report ID {0}", PrintBillNumber);
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvBillItems);
                this.WindowState = FormWindowState.Maximized;
                PrintBillNumber = 0;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void button18_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> mostBoughtItems = Connection.server.RetrieveMostBoughtItems();
            dgvBillItems.DataSource = mostBoughtItems.Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "اسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد من أصل";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Original Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
            }
        }

        public void nudBillNumberSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            string dateFrom = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            if (cbSalesDateSearch.Checked)
                RetrievedItems = Connection.server.SearchBills(dateFrom, dateTo, Convert.ToInt32(nudBillNumberSearch.Value));
            else
                RetrievedItems = Connection.server.SearchBills("", "", Convert.ToInt32(nudBillNumberSearch.Value));
            dgvBills.DataSource = RetrievedItems.Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBills.Columns["Column15"].HeaderText = "رقم الفاتوره";
                dgvBills.Columns["Column16"].HeaderText = "اسم الكاشير";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column17"].HeaderText = "Net Total";
                dgvBills.Columns["Column18"].HeaderText = "Paid Amount";
                dgvBills.Columns["Column19"].HeaderText = "Remainder";
                dgvBills.Columns["Column5"].HeaderText = "Payment Method";
                dgvBills.Columns["Column64"].HeaderText = "Date";
            }
        }

        public void pictureBox19_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            string dateFrom = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            if (cbSalesDateSearch.Checked)
                RetrievedItems = Connection.server.SearchBills(dateFrom, dateTo, Convert.ToInt32(nudBillNumberSearch.Value));
            else
                RetrievedItems = Connection.server.SearchBills("", "", Convert.ToInt32(nudBillNumberSearch.Value));
            dgvBills.DataSource = RetrievedItems.Item2;

            if (RetrievedItems.Item1.Count > 0)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvBills.Columns["Column15"].HeaderText = "رقم الفاتوره";
                    dgvBills.Columns["Column16"].HeaderText = "اسم الكاشير";
                    dgvBills.Columns["Column17"].HeaderText = "المبلغ الصافي";
                    dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                    dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                    dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                    dgvBills.Columns["Column64"].HeaderText = "التاريخ";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                    dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                    dgvBills.Columns["Column17"].HeaderText = "Net Total";
                    dgvBills.Columns["Column18"].HeaderText = "Paid Amount";
                    dgvBills.Columns["Column19"].HeaderText = "Remainder";
                    dgvBills.Columns["Column5"].HeaderText = "Payment Method";
                    dgvBills.Columns["Column64"].HeaderText = "Date";
                }
            }
        }

        public void button25_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> leastBoughtItems = Connection.server.RetrieveLeastBoughtItems();
            dgvBillItems.DataSource = leastBoughtItems.Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "اسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد من أصل";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Original Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
            }
        }

        public void button26_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchTodayBills(DateTime.Today);
            dgvBills.DataSource = RetrievedItems.Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBills.Columns["Column15"].HeaderText = "رقم الفاتوره";
                dgvBills.Columns["Column16"].HeaderText = "اسم الكاشير";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column17"].HeaderText = "Net Total";
                dgvBills.Columns["Column18"].HeaderText = "Paid Amount";
                dgvBills.Columns["Column19"].HeaderText = "Remainder";
                dgvBills.Columns["Column5"].HeaderText = "Payment Method";
                dgvBills.Columns["Column64"].HeaderText = "Date";
            }
        }

        public void pictureBox22_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> exports = Connection.server.RetrieveExports();
            dgvExports.DataSource = exports.Item2;
        }

        public void PBAddProfilePicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog loadImage = new OpenFileDialog())
            {
                loadImage.Title = "Select Profile Picture";
                loadImage.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
       + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

                if (loadImage.ShowDialog() == DialogResult.OK)
                {
                    PBAddProfilePicture.Image = new Bitmap(loadImage.FileName);
                }
            }
        }

        public void pictureBox4_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            DataTable dt = new DataTable();
            dt.Clear();
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveUnPortedBills();
            dgvUnPortedSales.DataSource = RetrievedBills.Item2;
            for (int i = 0; i < dgvUnPortedSales.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUnPortedSales.DataSource];
                currencyManager1.SuspendBinding();
                dgvUnPortedSales.Rows[i].Selected = true;
                dgvUnPortedSales.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
                total += Convert.ToDecimal(dgvUnPortedSales.Rows[i].Cells[2].Value);
            }
            RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, "", total);
            dgvUnPortedSales.DataSource = RetrievedBills.Item2;
            dgvUnPortedSales.Refresh();

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn6"].HeaderText = "رقم الغاتورة";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn7"].HeaderText = "إسم الكاشير";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "المبلغ الصافي";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "المبلغ المدفوغ";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "المبلغ الباقي";
                dgvUnPortedSales.Columns["Column7"].HeaderText = "طريقة الدفع";
                dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "المجموع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn6"].HeaderText = "Bill ID";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn7"].HeaderText = "Cashier Name";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "Net Amount";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "Paid Amount";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "Remainder";
                dgvUnPortedSales.Columns["Column7"].HeaderText = "Payment Method";
                dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "Total";
            }
        }

        public void pictureBox6_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            DataTable dt = new DataTable();
            dt.Clear();
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrievePortedBills();
            dgvUnPortedSales.DataSource = RetrievedBills.Item2;
            for (int i = 0; i < dgvPortedSales.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvPortedSales.DataSource];
                currencyManager1.SuspendBinding();
                dgvPortedSales.Rows[i].Selected = true;
                dgvPortedSales.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
                total += Convert.ToDecimal(dgvPortedSales.Rows[i].Cells[2].Value);
            }
            RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, "", total);
            dgvPortedSales.DataSource = RetrievedBills.Item2;
            dgvPortedSales.Refresh();

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "رقم الغاتورة";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "إسم الكاشير";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "المبلغ الصافي";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "المبلغ المدفوغ";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "المبلغ الباقي";
                dgvPortedSales.Columns["Column28"].HeaderText = "طريقة الدفع";
                dgvPortedSales.Columns["TotalPorted"].HeaderText = "المجموع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "Bill ID";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Cashier Name";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Net Amount";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Paid Amount";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "Remainder";
                dgvPortedSales.Columns["Column28"].HeaderText = "Payment Method";
                dgvPortedSales.Columns["TotalPorted"].HeaderText = "Total";
            }
        }

        public void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير المبيعات الغير مرحله";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Untraveling Sales Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvUnPortedSales);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير المبيعات المرحله";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Traveling Sales Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvPortedSales);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                bool exists = false, found = false;

                ScannedBarCode = ScannedBarCode.Replace("\r", "");

                if (ScannedBarCode != "")
                {
                    Item item = Connection.server.SearchInventoryItemsWithBarCode(ScannedBarCode);

                    /*if (item.GetQuantity() < 1)
                    {
                        var file = $"{Path.GetTempPath()}temp.mp3";
                        if (!File.Exists(file))
                        {
                            using (Stream output = new FileStream(file, FileMode.Create))
                            {
                                output.Write(Properties.Resources.beep, 0, Properties.Resources.beep.Length);
                            }
                        }
                        var wmp = new WindowsMediaPlayer { URL = file };
                        wmp.controls.play();
                    }*/
                    
                    foreach (DataGridViewRow row in ItemsPendingPurchase.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (item != null)
                            {
                                if (row.Cells[1].Value.ToString() == item.GetItemBarCode())
                                {
                                    row.Cells["pendingPurchaseItemQuantity"].Value = Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value) + 1;
                                    exists = true;
                                    richTextBox6.ResetText();
                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        richTextBox6.AppendText(" :الباركود " + item.GetItemBarCode());
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        richTextBox6.AppendText(" Barcode: " + item.GetItemBarCode());
                                    }
                                    this.ScannedBarCode = "";
                                    found = true;
                                }
                            }
                        }
                    }
                    if (!exists && item != null)
                    {
                        var index = ItemsPendingPurchase.Rows.Add();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = "1";
                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                        decimal priceAfterSales = Convert.ToDecimal(item.GetPriceTax());

                        if (saleItems.Count > 0)
                        {
                            for (int i = 0; i < saleItems.Count; i++)
                            {
                                if (saleItems[i].GetItemBarCode() == item.GetItemBarCode())
                                {
                                    priceAfterSales = (Convert.ToDecimal(item.GetPriceTax()) * saleItems[i].saleRate / 100);
                                    priceAfterSales = Convert.ToDecimal(item.GetPriceTax()) - priceAfterSales;
                                }
                            }
                        }

                        ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                        richTextBox6.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox6.AppendText(" :الباركود " + item.GetItemBarCode());
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox6.AppendText(" Barcode: " + item.GetItemBarCode());
                        }
                        this.ScannedBarCode = "";
                        found = true;
                    }
                    calculateStatistics();
                }
                this.timerstarted = false;
                this.itemBarCodeEntryTimer.Stop();
                if (!found)
                {
                    var file = $"{Path.GetTempPath()}temp.mp3";
                    if (!File.Exists(file))
                    {
                        using (Stream output = new FileStream(file, FileMode.Create))
                        {
                            output.Write(Properties.Resources.beep, 0, Properties.Resources.beep.Length);
                        }
                    }
                    var wmp = new WindowsMediaPlayer { URL = file };
                    wmp.controls.play();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        if (MessageBox.Show(" لا يوجد تعريف للماده في المستودع, هل تريد اضافة الماده؟ " + " اضافة ماده؟ ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
                            txtItemBarCode.Text = ScannedBarCode;
                            ScannedBarCode = "";
                            found = false;
                            return;
                        }
                        else
                        {
                            found = false;  
                            return;
                        }
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        if (MessageBox.Show("Item is not defined in the inventory, would you like to add it?" + " Add Item? ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
                            txtItemBarCode.Text = ScannedBarCode;
                            ScannedBarCode = "";
                            found = false;
                            return;
                        }
                        else
                        {
                            found = false;  
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.itemBarCodeEntryTimer.Stop();
                this.timerstarted = false;
            }
        }

        public void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                MessageBox.Show(String.Format(".+962 79 294 2040 .{0} الرجاء مخاطبة للدعم الفني", Application.CompanyName));
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                MessageBox.Show(String.Format("Please contact Technical Support. {0}. +962 79 14 077 36", Application.CompanyName));
            }
        }

        public void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument2.Print();
            } catch(Exception error)
            {
                MessageBox.Show(e.ToString(), Application.ProductName);
            }
        }

        public void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير الصادر";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Exports Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvExports);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير الوارد";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Imports Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvImports);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox27_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير الأرباح";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Profits Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dvgCapital);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox30_Click(object sender, EventArgs e)
        {
            int ItemTypeID = 0;
            string CashierName = null;
            if (comboBox1.SelectedItem != null)
            {
                ItemTypeID = Connection.server.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
            }
            else ItemTypeID = 0;
            if (comboBox2.SelectedItem != null)
            {
                CashierName = comboBox2.SelectedItem.ToString();
            }
            else CashierName = "";

            string dateFrom = dateTimePicker4.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";

            dgvItemProfit.DataSource = Connection.server.RetrieveBillItemsProfit(dateFrom, dateTo, ItemTypeID, CashierName);

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "إسم السلعه";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "الباركود";
                dgvItemProfit.Columns["Column48"].HeaderText = "صنف الماده";
                dgvItemProfit.Columns["Column49"].HeaderText = "اسم الكاشير";
                dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "سعر القطعة بعد الضريبة";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "الكميه المباعه";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn19"].HeaderText = "المجموع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "Item Name";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "Item Barcode";
                dgvItemProfit.Columns["Column48"].HeaderText = "Item Type";
                dgvItemProfit.Columns["Column49"].HeaderText = "Cashier Name";
                dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "Sold Quantity";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn19"].HeaderText = "Total";
            }
        }

        public void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Bill> Bills = DisplayBillsEdit();
            for (int i = 0; i < dgvBillsEdit.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvBillsEdit.DataSource];
                currencyManager1.SuspendBinding();
                dgvBillsEdit.Rows[i].Selected = true;
                dgvBillsEdit.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            dgvBillsEdit.Refresh();

            int ItemTypeID = 0;
            string CashierName = "";
            if (comboBox1.SelectedItem != null)
            {
                ItemTypeID = Connection.server.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
            }
            if (comboBox2.SelectedItem != null)
            {
                CashierName = comboBox1.SelectedItem.ToString();
            }
            string dateFrom = dateTimePicker4.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";

            dgvItemProfit.DataSource = Connection.server.RetrieveBillItemsProfit(dateFrom, dateTo, ItemTypeID, CashierName);
        }

        public void pictureBox31_Click(object sender, EventArgs e)
        {
            List<Bill> Bills = DisplayBillsEdit();
            for (int i = 0; i < dgvBillsEdit.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvBillsEdit.DataSource];
                currencyManager1.SuspendBinding();
                dgvBillsEdit.Rows[i].Selected = true;
                dgvBillsEdit.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            dgvBillsEdit.Refresh();

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBillsEdit.Columns["BillNumber"].HeaderText = "رقم الفاتوره";
                dgvBillsEdit.Columns["BillCashierName"].HeaderText = "اسم الكاشير";
                dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "المبلغ الصافي";
                dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "المبلغ المدفوع";
                dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "المبلغ الباقي";
                dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "طريقة الدفع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBillsEdit.Columns["BillNumber"].HeaderText = "Bill ID";
                dgvBillsEdit.Columns["BillCashierName"].HeaderText = "Bill Cashier Name";
                dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "Net Amount";
                dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "Paid Amount";
                dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "Remainder";
                dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "Payment Type";
            }
        }

        public void pictureBox28_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchBills("", "", Convert.ToInt32(nudBillNumberEdit.Value));
            dgvBillsEdit.DataSource = RetrievedItems.Item2;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (BillEditNumber.Value != 0 && BillsCashierName.Text != "" && BillsTotalAmount.Value != 0 && BillsPaidAmount.Value != 0 && BillsRemainderAmount.Value != 0)
                {
                    Connection.server.UpdateBill(Convert.ToInt32(BillEditNumber.Value), BillsCashierName.Text, BillsTotalAmount.Value, BillsPaidAmount.Value, BillsRemainderAmount.Value);
                    BillEditNumber.Value = 0;
                    BillsCashierName.Text = "";
                    BillsTotalAmount.Value = 0;
                    BillsPaidAmount.Value = 0;
                    BillsRemainderAmount.Value = 0;
                    BillsEditButton.Enabled = false;
                    List<Bill> Bills = DisplayBillsEdit();
                    for (int i = 0; i < dgvBillsEdit.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvBillsEdit.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvBillsEdit.Rows[i].Selected = true;
                        dgvBillsEdit.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvBillsEdit.Refresh();

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        dgvBillsEdit.Columns["BillNumber"].HeaderText = "رقم الفاتوره";
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "اسم الكاشير";
                        dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "المبلغ الصافي";
                        dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "المبلغ المدفوع";
                        dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "المبلغ الباقي";
                        dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "طريقة الدفع";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        dgvBillsEdit.Columns["BillNumber"].HeaderText = "Bill ID";
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "Bill Cashier Name";
                        dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "Net Amount";
                        dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "Paid Amount";
                        dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "Remainder";
                        dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "Payment Type";
                    }
                }
            } catch (Exception error)
            {
                BillsEditButton.Enabled = false;
                BillEditNumber.Value = 0;
                BillsCashierName.Text = "";
                BillsTotalAmount.Value = 0;
                BillsPaidAmount.Value = 0;
                BillsRemainderAmount.Value = 0;
            }
        }

        public void dgvBillsEdit_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                BillEditNumber.Value = Convert.ToInt32(dgvBillsEdit.Rows[e.RowIndex].Cells["BillNumber"].Value.ToString());
                BillsCashierName.Text = dgvBillsEdit.Rows[e.RowIndex].Cells["BillCashierName"].Value.ToString();
                BillsTotalAmount.Value = Convert.ToDecimal(dgvBillsEdit.Rows[e.RowIndex].Cells["BillTotalAmount"].Value.ToString());
                BillsPaidAmount.Value = Convert.ToDecimal(dgvBillsEdit.Rows[e.RowIndex].Cells["BillPaidAmount"].Value.ToString());
                BillsRemainderAmount.Value = Convert.ToDecimal(dgvBillsEdit.Rows[e.RowIndex].Cells["BillRemainderAmount"].Value.ToString());
                BillsEditButton.Enabled = true;
            } catch(Exception error)
            {

            }
        }

        public void button3_Click_1(object sender, EventArgs e)
        {
            textBox4.Text = "";
            numericUpDown1.Value = 0;
        }

        public void pictureBox33_Click(object sender, EventArgs e)
        {
            DataTable RetrievedExpenses;
            string dateFrom = dateTimePicker8.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker7.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            RetrievedExpenses = Connection.server.SearchExpenses(dateFrom, dateTo, textBox1.Text, textBox2.Text);
            dgvExpenses.DataSource = RetrievedExpenses;
            CapitalAmountnud.Value = Connection.server.GetCapitalAmount();
        }

        public void pictureBox34_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير المصروفات";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Expenses Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvExpenses);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.InsertExpense(textBox4.Text, numericUpDown1.Value, this.UID, DateTime.Now))
                {
                    textBox4.Text = "";
                    numericUpDown1.Value = 0;
                    decimal newCapitalAmount = Connection.server.GetCapitalAmount() - CapitalAmountnud.Value;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة المصروف", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {

                        MessageBox.Show("A new expense was added.", Application.ProductName);
                    }
                }
            } catch(Exception error) {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من اضافة المصروف", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to add new expense.", Application.ProductName);
                }
            }
        }

        public void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(0, 1);
        }

        public void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        public void ItemsPendingPurchase_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.ScannedBarCode = "";
        }

        public void pictureBox35_Click(object sender, EventArgs e)
        {
            frmMaintenance frmMaintenance = new frmMaintenance();
            openedForm = frmMaintenance;
            frmMaintenance.ShowDialog();
        }

        public void customerID_Enter(object sender, EventArgs e)
        {
            customerID.Select(0, 1);
        }

        public void BuyPrice_Enter(object sender, EventArgs e)
        {
            BuyPrice.Select(0, 1);
        }

        public void SellPrice_Enter(object sender, EventArgs e)
        {
            SellPrice.Select(0, 1);
        }

        public void SellPriceTax_Enter(object sender, EventArgs e)
        {
            SellPriceTax.Select(0, 1);
        }

        public void CustomerPrice_Enter(object sender, EventArgs e)
        {
            CustomerPrice.Select(0, 1);
        }

        public void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (registerOpen)
                {
                    if (tabControl1.SelectedTab == tabControl1.TabPages["Cash"] && (!pendingPurchaseNewQuantity.Focused && !pendingPurchaseRemovalQuantity.Focused))
                    {
                        if (e.KeyChar == (Char)Keys.Tab)
                            return;
                        else if (e.KeyChar == (Char)Keys.Enter)
                            return;
                        else if (e.KeyChar == (Char)'\u001b')
                        {
                            ScannedBarCode = "";
                            richTextBox6.ResetText();
                            this.timerstarted = false;
                        }
                        else if (e.KeyChar != (Char)'\u001b')
                        {
                            ScannedBarCode += e.KeyChar;
                            richTextBox6.ResetText();
                            richTextBox6.AppendText(ScannedBarCode);

                            if (!this.timerstarted)
                            {
                                itemBarCodeEntryTimer.Start();
                                this.timerstarted = true;
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {

            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.UpdateSystemSettings(this.shopName.Text, StoreLogo, this.shopPhone.Text,
                    Convert.ToInt32(this.receiptSpacingnud.Value),
                    Convert.ToInt32(this.IncludeLogoReceipt.Checked), nudTaxRate.Value))
                {
                    this.PlancksoftPOSName = this.shopName.Text;
                    this.PlancksoftPOSPhone = this.shopPhone.Text;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        label45.Text = " هذه النسخه مرخصه لمتجر " + this.PlancksoftPOSName;
                    this.Text = this.PlancksoftPOSName + " - الشاشه الرئيسيه";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        label45.Text = "This copy was licensed for " + this.PlancksoftPOSName;
                    this.Text = this.PlancksoftPOSName + " - Main Window";
                    }
                    if (this.IncludeLogoReceipt.Checked)
                    {
                        IncludeLogoInReceipt = true;
                    }
                    else
                    {
                        IncludeLogoInReceipt = false;
                    }
                    TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);

                    Program.materialSkinManager = MaterialSkinManager.Instance;
                    Program.materialSkinManager.EnforceBackcolorOnAllComponents = true;

                    if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    {
                        Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.DeepOrange400, Primary.Orange100, Accent.Orange100, TextShade.BLACK);
                        Properties.Settings.Default.pickedThemeScheme = 1;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.BLACK);
                        Properties.Settings.Default.pickedThemeScheme = 0;
                        Properties.Settings.Default.Save();
                    }

                    this.Refresh();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ الاعدادات", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("System preferences were saved.", Application.ProductName);
                    }
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم يتم حفظ الاعدادات", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to save new System preferences.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم يتم حفظ الاعدادات", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to save new System preferences.", Application.ProductName);
                }
            }
        }

        public void pictureBox23_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> imports = Connection.server.RetrieveImports();
            dgvImports.DataSource = imports.Item2;
        }

        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["Sales"])
                {
                    List<Bill> Bills = DisplayBills();
                    for (int i = 0; i < dgvBills.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvBills.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvBills.Rows[i].Selected = true;
                        dgvBills.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvBills.Refresh();
                    
                    decimal total = 0;
                    DataTable dt = new DataTable();
                    dt.Clear();
                    Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveUnPortedBills();
                    dgvUnPortedSales.DataSource = RetrievedBills.Item2;
                    for (int i = 0; i < dgvUnPortedSales.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUnPortedSales.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvUnPortedSales.Rows[i].Selected = true;
                        dgvUnPortedSales.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                        total += Convert.ToDecimal(dgvUnPortedSales.Rows[i].Cells[2].Value);
                    }
                    RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, "", total);
                    dgvUnPortedSales.DataSource = RetrievedBills.Item2;
                    dgvUnPortedSales.Refresh();

                    total = 0;
                    dt = new DataTable();
                    dt.Clear();
                    RetrievedBills = Connection.server.RetrievePortedBills();
                    dgvPortedSales.DataSource = RetrievedBills.Item2;
                    for (int i = 0; i < dgvPortedSales.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvPortedSales.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvPortedSales.Rows[i].Selected = true;
                        dgvPortedSales.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                        total += Convert.ToDecimal(dgvPortedSales.Rows[i].Cells[2].Value);
                    }
                    RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, "", total);
                    dgvPortedSales.DataSource = RetrievedBills.Item2;
                    dgvPortedSales.Refresh();

                    int ItemTypeID = 0;
                    string CashierName = null;
                    if (comboBox1.SelectedItem != null)
                    {
                        ItemTypeID = Connection.server.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
                    }
                    if (comboBox2.SelectedItem != null)
                    {
                        CashierName = comboBox2.SelectedItem.ToString();
                    }
                    string dateFrom = dateTimePicker4.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
                    string dateTo = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";

                    dgvItemProfit.DataSource = Connection.server.RetrieveBillItemsProfit(dateFrom, dateTo, ItemTypeID, CashierName);
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Inventory"])
                {
                    this.ItemsList = DisplayData();
                    for (int i = 0; i < DgvInventory.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvInventory.DataSource];
                        currencyManager1.SuspendBinding();
                        DgvInventory.Rows[i].Selected = true;
                        DgvInventory.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    DgvInventory.Refresh();

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        DgvInventory.Columns["InventoryItemName"].HeaderText = "إسم القطعة";
                        DgvInventory.Columns["ItemID"].HeaderText = "رقم القطعه";
                        DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "باركود القطعه";
                        DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "عدد القطعه";
                        DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "سعر الشراء";
                        DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "سعر القطعة";
                        DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "سعر القطعة بالضريبة";
                        DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "المصنف المفضل";
                        DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "المستودع";
                        DgvInventory.Columns["InventoryItemType"].HeaderText = "تصنيف المادة";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        DgvInventory.Columns["InventoryItemName"].HeaderText = "Item Name";
                        DgvInventory.Columns["ItemID"].HeaderText = "Item ID";
                        DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "Item Barcode";
                        DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "Item Quantity";
                        DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "Item Buy Price";
                        DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "Sell Price";
                        DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "Sell Price Tax";
                        DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "Favorite Category";
                        DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "Warehouse";
                        DgvInventory.Columns["InventoryItemType"].HeaderText = "Item Type";
                    }

                    nudItemBarCodeSearch.Text = "";
                    txtItemNameSearch.Text = "";
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Expenses"])
                {
                    DataTable RetrievedExpenses;
                    string dateFrom = dateTimePicker8.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
                    string dateTo = dateTimePicker7.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
                    RetrievedExpenses = Connection.server.SearchExpenses(dateFrom, dateTo, textBox1.Text, textBox2.Text);
                    dgvExpenses.DataSource = RetrievedExpenses;
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["IncomingOutgoing"])
                {
                    Tuple<List<Item>, DataTable> exports = Connection.server.RetrieveExports();
                    dgvExports.DataSource = exports.Item2;

                    Tuple<List<Item>, DataTable> imports = Connection.server.RetrieveImports();
                    dgvImports.DataSource = imports.Item2;

                    Tuple<List<Item>, DataTable> capitalWinnings = Connection.server.RetrieveCapitalRevenue();
                    dvgCapital.DataSource = capitalWinnings.Item2;

                    decimal SumOfRevenue = 0;

                    foreach (DataGridViewRow row in dvgCapital.Rows)
                    {
                        if (!row.IsNewRow)
                            SumOfRevenue += Convert.ToDecimal(row.Cells[1].Value.ToString());
                    }

                    label80.Text = SumOfRevenue.ToString();
                    label91.Text = CapitalAmount.ToString();
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Employees"])
                {
                    DisplayEmployees();
                    for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvEmployees.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvEmployees.Rows[i].Selected = true;
                        dgvEmployees.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvEmployees.Refresh();
                    DisplayAbsence();
                    for (int i = 0; i < dgvAbsence.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAbsence.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvAbsence.Rows[i].Selected = true;
                        dgvAbsence.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvAbsence.Refresh();
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Agents"])
                {
                    Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveCustomers();

                    dgvCustomers.DataSource = retrievedCustomers.Item2;

                    customerName.Items.Clear();
                    foreach (Customer customer in retrievedCustomers.Item1)
                    {
                        customerName.Items.Add(new Items(customer.CustomerName));
                    }

                    Tuple<List<Customer>, DataTable> retrievedVendors = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedVendors.Item2;

                    VendorName.Items.Clear();
                    foreach (Customer customer in retrievedVendors.Item1)
                    {
                        VendorName.Items.Add(new Items(customer.CustomerName));
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Alerts"])
                {
                    Tuple<List<Item>, DataTable> itemsExpirationStock = Connection.server.RetrieveExpireStockToday(DateTime.Now);
                    if (itemsExpirationStock.Item1 != null)
                    {
                        if (itemsExpirationStock.Item1.Count > 0)
                        {
                            if (itemsExpirationStock.Item2 != null)
                            {
                                dgvAlerts.DataSource = itemsExpirationStock.Item2;

                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    dgvAlerts.Columns["Column42"].HeaderText = "باركود الماده";
                                    dgvAlerts.Columns["Column43"].HeaderText = "إسم الماده";
                                    dgvAlerts.Columns["Column44"].HeaderText = "تاريخ الإنتاج";
                                    dgvAlerts.Columns["Column45"].HeaderText = "تاريخ إنتهاء الصلاحيه";
                                    dgvAlerts.Columns["Column46"].HeaderText = "كمية التحذير";
                                    dgvAlerts.Columns["Column47"].HeaderText = "الكميه الحاليه";
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    dgvAlerts.Columns["Column42"].HeaderText = "Item Barcode";
                                    dgvAlerts.Columns["Column43"].HeaderText = "Item Name";
                                    dgvAlerts.Columns["Column44"].HeaderText = "Production Date";
                                    dgvAlerts.Columns["Column45"].HeaderText = "Expiration Date";
                                    dgvAlerts.Columns["Column46"].HeaderText = "Warning Limit";
                                    dgvAlerts.Columns["Column47"].HeaderText = "Current Quantity";
                                }
                            }
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            dgvAlerts.DataSource = dt;

                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                dgvAlerts.Columns["Column42"].HeaderText = "باركود الماده";
                                dgvAlerts.Columns["Column43"].HeaderText = "إسم الماده";
                                dgvAlerts.Columns["Column44"].HeaderText = "تاريخ الإنتاج";
                                dgvAlerts.Columns["Column45"].HeaderText = "تاريخ إنتهاء الصلاحيه";
                                dgvAlerts.Columns["Column46"].HeaderText = "كمية التحذير";
                                dgvAlerts.Columns["Column47"].HeaderText = "الكميه الحاليه";
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                dgvAlerts.Columns["Column42"].HeaderText = "Item Barcode";
                                dgvAlerts.Columns["Column43"].HeaderText = "Item Name";
                                dgvAlerts.Columns["Column44"].HeaderText = "Production Date";
                                dgvAlerts.Columns["Column45"].HeaderText = "Expiration Date";
                                dgvAlerts.Columns["Column46"].HeaderText = "Warning Limit";
                                dgvAlerts.Columns["Column47"].HeaderText = "Current Quantity";
                            }
                        }
                    }
                    Tuple<List<Item>, DataTable> retreivedCustomerItems = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage);
                    DGVCustomerItems.DataSource = retreivedCustomerItems.Item2;
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Taxes"])
                {
                    decimal totalTax = 0;
                    DataTable TaxZReport = Connection.server.RetrieveTaxZReport();
                    foreach (DataRow row in TaxZReport.Rows)
                    {
                        if (row["Bill Number"] != null && row["Bill Number"] != DBNull.Value && !String.IsNullOrWhiteSpace(row["Bill Number"].ToString()))
                        {
                            decimal x = Convert.ToDecimal(row["Total Amount"].ToString()) / TaxRate;
                            decimal Tax = x * (Convert.ToDecimal(nudTaxRate.Value) / Convert.ToDecimal(100));
                            totalTax += Tax;
                            row["Tax"] = Tax;
                        }
                    }
                    TaxZReport.Rows.Add(0, 0, 0, "", DateTime.Now, totalTax);
                    dgvTaxZReport.DataSource = TaxZReport;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        dgvTaxZReport.Columns["Column50"].HeaderText = "رقم الفاتتوره";
                        dgvTaxZReport.Columns["Column52"].HeaderText = "قيمة الفاتوره";
                        dgvTaxZReport.Columns["Column53"].HeaderText = "قيمة الضريبه";
                        dgvTaxZReport.Columns["Column55"].HeaderText = "إسم الكاشير";
                        dgvTaxZReport.Columns["Column51"].HeaderText = "التاريخ";
                        dgvTaxZReport.Columns["TaxTotal"].HeaderText = "مجموع الضريبه";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        dgvTaxZReport.Columns["Column50"].HeaderText = "Bill ID";
                        dgvTaxZReport.Columns["Column52"].HeaderText = "Bill Total";
                        dgvTaxZReport.Columns["Column53"].HeaderText = "Tax Amount";
                        dgvTaxZReport.Columns["Column55"].HeaderText = "Cashier Name";
                        dgvTaxZReport.Columns["Column51"].HeaderText = "Date";
                        dgvTaxZReport.Columns["TaxTotal"].HeaderText = "Tax Total";
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["posUsers"])
                {
                    Users = DisplayUsers();
                    for (int i = 0; i < dgvUsers.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUsers.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvUsers.Rows[i].Selected = true;
                        dgvUsers.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvUsers.Refresh();
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Retrievals"])
                {
                    dgvReturnedItems.DataSource = Connection.server.RetrieveReturnedItems();

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn54"].HeaderText = "رقم السند";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn55"].HeaderText = "إسم الكاشير";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn52"].HeaderText = "إسم الماده";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn51"].HeaderText = "باركود الماده";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn57"].HeaderText = "عدد القطع المرجعه";
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn54"].HeaderText = "Return ID";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn55"].HeaderText = "Cashier Name";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn52"].HeaderText = "Item Name";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn51"].HeaderText = "Item Barcode";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn57"].HeaderText = "Returned Items Quantity";
                    }
                }
            } catch (Exception error)
            { }
        }

        public void pictureBox24_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> capitalWinnings = Connection.server.RetrieveCapitalRevenue();
            dvgCapital.DataSource = capitalWinnings.Item2;

            decimal SumOfRevenue = 0;

            foreach(DataGridViewRow row in dvgCapital.Rows)
            {
                if (!row.IsNewRow)
                    SumOfRevenue += Convert.ToDecimal(row.Cells[1].Value.ToString());
            }

            label80.Text = SumOfRevenue.ToString();
            label91.Text = CapitalAmount.ToString();
        }

        public void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                case CloseReason.TaskManagerClosing:
                case CloseReason.WindowsShutDown:
                case CloseReason.MdiFormClosing:
                case CloseReason.ApplicationExitCall:
                case CloseReason.FormOwnerClosing:
                case CloseReason.None:
                    Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                    Properties.Settings.Default.Save();
                    Connection.server.LogLogout(this.UID, DateTime.Now);
                    break;
            }
        }

        public void txtUserPasswordAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
                button22.PerformClick();
        }

        public void pictureBox25_Click(object sender, EventArgs e)
        {
            if (userPermissions.customer_card_edit)
            {
                frmClientCard customerCard = new frmClientCard();
                openedForm = customerCard;
                customerCard.ShowDialog();
                if (customerCard.dialogResult == DialogResult.OK)
                {
                    this.currentCustomer = customerCard.customer;
                    customerName.Text = customerCard.customer.CustomerName;
                    customerID.Value = customerCard.customer.CustomerID;

                    bool replaced = false;
                    foreach (Item item in customerCard.saleItems)
                    {
                        for (int i = 0; i < this.customersaleItems.Count; i++)
                        {
                            if (customersaleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                            {
                                int index = customerCard.saleItems.IndexOf(item);
                                this.customersaleItems[index] = item;
                                replaced = true;
                            }
                        }

                        if (!replaced)
                        {
                            this.customersaleItems.Add(item);
                        }
                    }

                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if (customersaleItems.Count > 0)
                            {
                                for (int i = 0; i < customersaleItems.Count; i++)
                                {
                                    if (customersaleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                    {
                                        decimal priceAfterSales;
                                        decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                        if (customersaleItems[i].saleRate != 0)
                                            priceAfterSales = Convert.ToDecimal((customersaleItems[i].customerPrice) * (customersaleItems[i].saleRate / 100));
                                        else priceAfterSales = Convert.ToDecimal(customersaleItems[i].customerPrice);
                                        decimal marginPrice = previousPrice - priceAfterSales;
                                        this.totalAmount = this.totalAmount - marginPrice;
                                        item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                        richTextBox4.ResetText();
                                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                        {
                                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                        }
                                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                        {
                                            richTextBox4.AppendText(" Total: " + this.totalAmount);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    customerCard.Dispose();
                    if (replaced)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("The Discount percentage for Client Items was altered.", Application.ProductName);
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".تم اضافة خصم العميل", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("A Client Discount was added.", Application.ProductName);
                        }
                    }


                }
            }
        }

        public void button31_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.RegisterCustomer(new Customer(customerName.Text, Convert.ToInt32(customerID.Value), CustomerPhone.Text, CustomerAddress.Text)))
                {
                    customerName.Text = "";
                    customerID.Value = 0;
                    CustomerPhone.Text = "";
                    CustomerAddress.Text = "";

                    Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveCustomers();

                    dgvCustomers.DataSource = retrievedCustomers.Item2;

                    foreach (Customer customer in retrievedCustomers.Item1)
                    {
                        customerName.Items.Add(new Items(customer.CustomerName));
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة الزبون", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Client was added.", Application.ProductName);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نتمكن من اضافة الزبون", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to add new Client.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            { }
        }

        public void pictureBox21_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveCustomers();

                dgvCustomers.DataSource = retrievedCustomers.Item2;

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvCustomers.Columns["Column27"].HeaderText = "إسم العميل";
                    dgvCustomers.Columns["CustomerIDDelete"].HeaderText = "رمز العميل";
                    dgvCustomers.Columns["Column38"].HeaderText = "رقم الزبون";
                    dgvCustomers.Columns["Column39"].HeaderText = "عنوان الزبون";
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvCustomers.Columns["Column27"].HeaderText = "Client Name";
                    dgvCustomers.Columns["CustomerIDDelete"].HeaderText = "Client ID";
                    dgvCustomers.Columns["Column38"].HeaderText = "Phone Number";
                    dgvCustomers.Columns["Column39"].HeaderText = "Client Address";
                }

                foreach (Customer customer in retrievedCustomers.Item1)
                {
                    customerName.Items.Add(new Items(customer.CustomerName));
                }
            }
            catch(Exception error)
            { }
        }

        public void button30_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.DeletesCustomer(dgvCustomers.CurrentRow.Cells["CustomerIDDelete"].Value.ToString()))
                {
                    Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveCustomers();

                    dgvCustomers.DataSource = retrievedCustomers.Item2;

                    foreach (Customer customer in retrievedCustomers.Item1)
                    {
                        customerName.Items.Remove(new Items(customer.CustomerName));
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حذف العميل", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Client was deleted.", Application.ProductName);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نستطع حذف العميل", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to delete Client.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            { }
        }

        public void pictureBox26_Click(object sender, EventArgs e)
        {
            if (userPermissions.price_edit)
            {
                frmEditPrice editPrice = new frmEditPrice();
                openedForm = editPrice;
                editPrice.ShowDialog();
                if (editPrice.dialogResult == DialogResult.OK)
                {
                    this.totalAmount = editPrice.moneyDeduction;
                    richTextBox4.ResetText();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.AppendText(" Total: " + this.totalAmount);
                    }
                    if (!this.totalAmount.ToString().Contains("."))
                        richTextBox4.AppendText(".00");
                    if (this.totalAmount.ToString().Contains("."))
                    {
                        if (this.totalAmount.ToString().EndsWith("."))
                        {
                            richTextBox4.AppendText("00");
                        } else
                        {
                            if (this.totalAmount.ToString().Split('.')[1].Length == 1)
                            {
                                richTextBox4.AppendText("0");
                            }
                        }
                    }
                }
            }
        }

        public void nudItemBuyPrice_Enter(object sender, EventArgs e)
        {
            nudItemBuyPrice.Select(0, 1);
        }

        public void button5_Click(object sender, EventArgs e)
        {
            try
            {
                frmPickCustomerLookup pickCustomer = new frmPickCustomerLookup();
                openedForm = pickCustomer;
                pickCustomer.ShowDialog();

                if (pickCustomer.pickedCustomer.CustomerName != null)
                {
                    Customer pickedCustomer = Connection.server.SearchCustomersInfo(pickCustomer.pickedCustomer.CustomerName, Convert.ToString(pickCustomer.pickedCustomer.CustomerID)).Item1;
                    textBox7.Text = pickedCustomer.CustomerName;
                    numericUpDown2.Value = pickedCustomer.CustomerID;
                    CustomerPrice.Value = pickedCustomer.CustomerPrice;
                }
            } catch(Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطع اختيار الزبون", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to pick Client.", Application.ProductName);
                }
            }
        }

        public void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Item pickedItem = new Item();
                pickedItem.SetBarCode(DGVCustomerItems.Rows[customerItemID].Cells[1].Value.ToString());
                bool addedItemToCustomer = Connection.server.AddItemToCustomer(pickedItem.GetItemBarCode(), Convert.ToInt32(numericUpDown2.Value), CustomerPrice.Value);

                if (addedItemToCustomer)
                {
                    textBox7.Text = "";
                    numericUpDown2.Value = 0;
                    BuyPrice.Value = 0;
                    SellPrice.Value = 0;
                    SellPriceTax.Value = 0;
                    CustomerPrice.Value = 0;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة الماده للزبون", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Client Item was added.", Application.ProductName);
                    }
                }
                else
                {
                    textBox7.Text = "";
                    numericUpDown2.Value = 0;
                    BuyPrice.Value = 0;
                    SellPrice.Value = 0;
                    SellPriceTax.Value = 0;
                    CustomerPrice.Value = 0;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم تتم اضافة الماده للزبون", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Client Item was not added.", Application.ProductName);
                    }
                }
            } catch(Exception error)
            {
                textBox7.Text = "";
                numericUpDown2.Value = 0;
                BuyPrice.Value = 0;
                SellPrice.Value = 0;
                SellPriceTax.Value = 0;
                CustomerPrice.Value = 0;
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم تتم اضافة الماده للزبون", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Client Item was not added.", Application.ProductName);
                }
            }
        }

        public void pictureBox40_Click(object sender, EventArgs e)
        {
            DGVCustomerItems.DataSource = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage).Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "إسم القطعة";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعه";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعه";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر الشراء";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "سعر القطعه بالضريبه";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "المصنف المفضل";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "المستودع";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "تصنيف الماده";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Buy Price";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Sell Price";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "Sell Price Tax";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "Favorite Category";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "Warehouse";
                DGVCustomerItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "Item Type";
            }
        }

        public void BuyPrice_Enter_1(object sender, EventArgs e)
        {
            BuyPrice.Select(0, 1);
        }

        public void SellPrice_Enter_1(object sender, EventArgs e)
        {
            SellPrice.Select(0, 1);
        }

        public void SellPriceTax_Enter_1(object sender, EventArgs e)
        {
            SellPriceTax.Select(0, 1);
        }

        public void CustomerPrice_Enter_1(object sender, EventArgs e)
        {
            CustomerPrice.Select(0, 1);
        }

        public void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (!this.userPermissions.customer_card_edit)
                if (e.TabPage == Agents)
                    e.Cancel = true;

            if (!this.userPermissions.inventory_edit)
                if (e.TabPage == Inventory)
                    e.Cancel = true;

            if (!this.userPermissions.expenses_add)
                if (e.TabPage == Expenses)
                    e.Cancel = true;

            if (!this.userPermissions.users_edit)
                if (e.TabPage == posUsers)
                    e.Cancel = true;

            if (!this.userPermissions.settings_edit)
                if (e.TabPage == Settings)
                    e.Cancel = true;

            if (!this.userPermissions.personnel_edit)
                if (e.TabPage == Employees)
                    e.Cancel = true;
        }

        public void tabControl4_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!this.userPermissions.receipt_edit)
            {
                if (e.TabPage == EditInvoices)
                    e.Cancel = true;
                if (e.TabPage == TravelingUntravelingSales)
                    e.Cancel = true;
                if (e.TabPage == SoldItems)
                    e.Cancel = true;
            }
        }

        public void QuantityWarning_Enter(object sender, EventArgs e)
        {
            QuantityWarning.Select(0, 1);
        }

        public void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tabControl3.TabPages["AgentsDefinitions"])
            {
                Tuple<List<Item>, DataTable> retreivedCustomerItems = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage);
                DGVCustomerItems.DataSource = retreivedCustomerItems.Item2;
            } else if (tabControl3.SelectedTab == tabControl3.TabPages["AgentsItemsDefinitions"])
            {
                VendorName.Items.Clear();
                Tuple<List<Customer>, DataTable> retrievedVendors = Connection.server.GetRetrieveVendors();

                dgvVendors.DataSource = retrievedVendors.Item2;

                foreach (Customer customer in retrievedVendors.Item1)
                {
                    VendorName.Items.Add(new Items(customer.CustomerName));
                }
            }
        }

        public void اضافةصنفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
            tabControl6.SelectedTab = tabControl6.TabPages["AddTypes"];
        }

        public void اضافةمستودعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
            tabControl6.SelectedTab = tabControl6.TabPages["AddFavorites"];
        }

        public void اضافةمستودعToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
            tabControl6.SelectedTab = tabControl6.TabPages["AddWarehouses"];
        }

        public void اضافةمادهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
            tabControl6.SelectedTab = tabControl6.TabPages["posInventory"];
        }

        public void button8_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl3.SelectedTab = tabControl3.TabPages["AddImporterInvoices"];
                int Index = dgvVendors.CurrentCell.RowIndex;
                string vendorName = dgvVendors.Rows[Index].Cells["VendorCustomerName"].Value.ToString();
                int vendorID = Convert.ToInt32(dgvVendors.Rows[Index].Cells["VendorCustomerID"].Value.ToString());
                textBox8.Text = vendorName;
                numericUpDown3.Value = vendorID;
            } catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء اختيار مورد", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please pick an Importer.", Application.ProductName);
                }
            }
        }

        public void button9_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl3.SelectedTab = tabControl3.TabPages["ImporterBalanceChecks"];
                int Index = dgvVendors.CurrentCell.RowIndex;
                string vendorName = dgvVendors.Rows[Index].Cells["VendorCustomerName"].Value.ToString();
                int vendorID = Convert.ToInt32(dgvVendors.Rows[Index].Cells["VendorCustomerID"].Value.ToString());
                textBox8.Text = vendorName;
                numericUpDown3.Value = vendorID;

                List<Bill> Bills = DisplayVendorBills();
                for (int i = 0; i < dgvVendorBills.Rows.Count; i++)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvVendorBills.DataSource];
                    currencyManager1.SuspendBinding();
                    dgvVendorBills.Rows[i].Selected = true;
                    dgvVendorBills.Rows[i].Visible = true;
                    currencyManager1.ResumeBinding();
                }
                dgvVendorBills.Refresh();

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "رقم الغاتورة";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "إسم الكاشير";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn41"].HeaderText = "المبلغ الصافي";
                    dgvVendorBills.Columns["VendorBillDate"].HeaderText = "التاريخ";
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "Bill ID";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "Cashier Name";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Net Total";
                    dgvVendorBills.Columns["VendorBillDate"].HeaderText = "Date";
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء اختيار مورد", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please pick an Importer.", Application.ProductName);
                }
            }
        }

        public void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.RegisterVendor(new Customer(VendorName.Text, Convert.ToInt32(VendorID.Value), VendorPhone.Text, VendorAddress.Text)))
                {
                    VendorName.Text = "";
                    VendorName.Items.Clear();
                    VendorID.Value = 0;
                    VendorPhone.Text = "";
                    VendorAddress.Text = "";

                    Tuple<List<Customer>, DataTable> retrievedVendors = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedVendors.Item2;

                    foreach (Customer customer in retrievedVendors.Item1)
                    {
                        VendorName.Items.Add(new Items(customer.CustomerName));
                    }
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تمت اضافة المورد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Importer was added.", Application.ProductName);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نتمكن من اضافة المورد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to add a new Importer.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            { }
        }

        public void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.DeletesCustomer(dgvVendors.CurrentRow.Cells["CustomerIDDelete"].Value.ToString()))
                {
                    Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedCustomers.Item2;

                    foreach (Customer customer in retrievedCustomers.Item1)
                    {
                        VendorName.Items.Remove(new Items(customer.CustomerName));
                    }
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حذف العميل", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Client was deleted.", Application.ProductName);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نستطع حذف العميل", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to delete Client.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            { }
        }

        public void VendorID_Enter(object sender, EventArgs e)
        {
            VendorID.Select(0, 1);
        }

        public void pictureBox42_Click(object sender, EventArgs e)
        {
            try
            {
                VendorName.Items.Clear();
                Tuple<List<Customer>, DataTable> retrievedVendors = Connection.server.GetRetrieveVendors();

                dgvVendors.DataSource = retrievedVendors.Item2;

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvVendors.Columns["VendorCustomerName"].HeaderText = "إسم المورد";
                    dgvVendors.Columns["VendorCustomerID"].HeaderText = "رمز المورد";
                    dgvVendors.Columns["VendorCustomerPhone"].HeaderText = "رقم المورد";
                    dgvVendors.Columns["VendorCustomerAddress"].HeaderText = "عنوان المورد";
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvVendors.Columns["VendorCustomerName"].HeaderText = "Importer Name";
                    dgvVendors.Columns["VendorCustomerID"].HeaderText = "Importer ID";
                    dgvVendors.Columns["VendorCustomerPhone"].HeaderText = "Importer Phone Number";
                    dgvVendors.Columns["VendorCustomerAddress"].HeaderText = "Importer Address";
                }

                foreach (Customer customer in retrievedVendors.Item1)
                {
                    VendorName.Items.Add(new Items(customer.CustomerName));
                }
            } catch (Exception error)
            {

            }
        }

        public void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown3.Value != 0 && textBox8.Text != "")
                {
                    Item[] itemsToAdd = new Item[0];
                    int row = 0;
                    foreach (DataGridViewRow currentBillRow in dgvVendorItemsPick.Rows)
                    {
                        if (currentBillRow.Cells[0].Value != null && currentBillRow.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(currentBillRow.Cells[0].Value.ToString()))
                        {
                            string itemName = currentBillRow.Cells[0].Value.ToString();
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[3].Value.ToString());
                            decimal itemBuyPrice = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[5].Value.ToString());
                            decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[6].Value.ToString());
                            Array.Resize(ref itemsToAdd, itemsToAdd.Length + 1);
                            itemsToAdd[row] = new Item();
                            itemsToAdd[row].SetName(itemName);
                            itemsToAdd[row].SetBarCode(itemBarCode);
                            itemsToAdd[row].SetQuantity(itemQuantity);
                            itemsToAdd[row].SetBuyPrice(itemBuyPrice);
                            itemsToAdd[row].SetPrice(itemPrice);
                            itemsToAdd[row].SetPriceTax(itemPriceTax);
                            Connection.server.UpdateItemQuantity(itemsToAdd[row++]);
                            this.totalVendorAmount += itemBuyPrice * itemQuantity;
                        }
                    }

                    Bill billToAdd = new Bill(this.CurrentVendorBillNumber, this.totalVendorAmount, itemsToAdd, DateTime.Now);
                    if (Connection.server.AddVendorBill(billToAdd, this.cashierName))
                    {
                        this.totalVendorAmount = Connection.server.RetrieveLastVendorBillNumberToday(DateTime.Now).getBillNumber() + 1;
                        this.CurrentVendorBillNumber++;
                        this.ItemsList = DisplayData();
                        DisplayFavorites();
                        dgvVendorItemsPick.DataSource = new DataTable();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".تمت اضافة الفاتوره للمورد", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("A new Importer Bill was added.", Application.ProductName);
                        }
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".الرجاء إختيار مورد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Please pick an Importer.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void tabControl3_Selecting(object sender, TabControlCancelEventArgs e)
        {
            /*if (e.TabPage == tabPage17)
                e.Cancel = true;
                */
        }

        public void dgvVendorBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvVendorBillItems.DataSource = Connection.server.RetrieveVendorBillItems(Convert.ToInt32(dgvVendorBills.Rows[e.RowIndex].Cells[0].Value.ToString())).Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvVendorBillItems.Columns["dataGridViewTextBoxColumn34"].HeaderText = "إسم المادة";
                dgvVendorBillItems.Columns["dataGridViewTextBoxColumn35"].HeaderText = "باركود الماده";
                dgvVendorBillItems.Columns["dataGridViewTextBoxColumn36"].HeaderText = "عدد البيع الشراء";
                dgvVendorBillItems.Columns["VendorBillItemBuyPrice"].HeaderText = "سعر الشراء";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvVendorBillItems.Columns["dataGridViewTextBoxColumn34"].HeaderText = "Item Name";
                dgvVendorBillItems.Columns["dataGridViewTextBoxColumn35"].HeaderText = "Item Barcode";
                dgvVendorBillItems.Columns["dataGridViewTextBoxColumn36"].HeaderText = "Item Buy Sell Quantity";
                dgvVendorBillItems.Columns["VendorBillItemBuyPrice"].HeaderText = "Buy Price";
            }
        }

        public void pictureBox44_Click(object sender, EventArgs e)
        {
            decimal totalTax = 0;
            DataTable TaxZReport = Connection.server.RetrieveTaxZReport();
            foreach (DataRow row in TaxZReport.Rows)
            {
                if (row["Bill Number"] != null && row["Bill Number"] != DBNull.Value && !String.IsNullOrWhiteSpace(row["Bill Number"].ToString()))
                {
                    decimal tax = Convert.ToDecimal(row["Tax"].ToString());
                    totalTax += tax;
                }
            }
            TaxZReport.Rows.Add(0, 0, 0, 0, DateTime.Now, totalTax);
            dgvTaxZReport.DataSource = TaxZReport;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvTaxZReport.Columns["Column50"].HeaderText = "رقم الفاتتوره";
                dgvTaxZReport.Columns["Column52"].HeaderText = "قيمة الفاتوره";
                dgvTaxZReport.Columns["Column53"].HeaderText = "قيمة الضريبه";
                dgvTaxZReport.Columns["Column55"].HeaderText = "إسم الكاشير";
                dgvTaxZReport.Columns["Column51"].HeaderText = "التاريخ";
                dgvTaxZReport.Columns["TaxTotal"].HeaderText = "مجموع الضريبه";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvTaxZReport.Columns["Column50"].HeaderText = "Bill ID";
                dgvTaxZReport.Columns["Column52"].HeaderText = "Bill Total";
                dgvTaxZReport.Columns["Column53"].HeaderText = "Tax Amount";
                dgvTaxZReport.Columns["Column55"].HeaderText = "Cashier Name";
                dgvTaxZReport.Columns["Column51"].HeaderText = "Date";
                dgvTaxZReport.Columns["TaxTotal"].HeaderText = "Tax Total";
            }
        }

        public void pictureBox46_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".Z تقرير الضريبه";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Tax Z Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvTaxZReport);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox45_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير الفواتير";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Bills Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvVendorBills);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(1.ToString());
        }

        public void ItemsPendingPurchase_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                pendingPurchaseRemovalQuantity.Value = Convert.ToInt32(ItemsPendingPurchase.Rows[e.RowIndex].Cells[2].Value.ToString());
                pendingPurchaseNewQuantity.Value = Convert.ToInt32(ItemsPendingPurchase.Rows[e.RowIndex].Cells[2].Value.ToString());
            } catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء اختيار سطر لماده", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please pick a row of an Item.", Application.ProductName);
                }
            }
        }

        public void pendingPurchaseRemovalQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                button17.PerformClick();
                button17.Select();
                button17.Focus();
            }
        }

        public void pendingPurchaseNewQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                button24.PerformClick();
                button24.Select();
                button24.Focus();
            }
        }

        public void customerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button31.PerformClick();
        }

        public void customerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button31.PerformClick();
        }

        public void CustomerPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button31.PerformClick();
        }

        public void CustomerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button31.PerformClick();
        }

        public void VendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button7.PerformClick();
        }

        public void VendorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button7.PerformClick();
        }

        public void VendorPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button7.PerformClick();
        }

        public void VendorAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button7.PerformClick();
        }

        public void label67_MouseClick(object sender, MouseEventArgs e)
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لا بمكتك دفع فاتوره فارغه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("You cannot pay an empty Bill.", Application.ProductName);
                }
            }
            else
            {
                frmPay frmPayCash = new frmPay(this.totalAmount);
                openedForm = frmPayCash;
                frmPayCash.ShowDialog(this);

                if (frmPayCash.dialogResult == DialogResult.OK)
                {
                    this.paidAmount = frmPayCash.moneyPaid;
                    this.moneyInRegister += this.paidAmount;
                    this.remainderAmount = this.paidAmount - this.totalAmount;
                    frmPayCash.Dispose();

                    Item[] itemsToAdd = new Item[0];
                    int row = 0;
                    foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                    {
                        if (!currentBillRow.IsNewRow)
                        {
                            string itemName = currentBillRow.Cells[0].Value.ToString();
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                            decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                            decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            Array.Resize(ref itemsToAdd, itemsToAdd.Length + 1);
                            itemsToAdd[row] = new Item();
                            itemsToAdd[row].SetName(itemName);
                            itemsToAdd[row].SetBarCode(itemBarCode);
                            itemsToAdd[row].SetQuantity(itemQuantity);
                            itemsToAdd[row].SetPrice(itemPrice);
                            itemsToAdd[row++].SetPriceTax(itemPriceTax);
                            int newItemQuantity = Connection.server.GetItemQuantity(itemBarCode) - itemQuantity;
                            bool updatedQuantity = Connection.server.UpdateItemQuantity(new Item(itemName, itemBarCode, newItemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                            Tuple<List<Item>, DataTable> itemsExpirationStock = Connection.server.RetrieveExpireStockToday(DateTime.Now);
                            if (itemsExpirationStock != null)
                            {
                                if (itemsExpirationStock.Item1.Count > 0)
                                {
                                    foreach (Item item in itemsExpirationStock.Item1)
                                    {
                                        if (item.ItemBarCode == itemBarCode)
                                        {
                                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                            {
                                                MessageBox.Show("قطعه باركود " + item.ItemBarCode + " انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف.", Application.ProductName);
                                            }
                                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                            {
                                                MessageBox.Show("Item Barcode " + item.ItemBarCode + " is either expired or has less quantity in inventory than defined warning limit.", Application.ProductName);
                                            }
                                        }
                                    }
                                    dgvAlerts.DataSource = itemsExpirationStock.Item2;

                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        dgvAlerts.Columns["Column42"].HeaderText = "باركود الماده";
                                        dgvAlerts.Columns["Column43"].HeaderText = "إسم الماده";
                                        dgvAlerts.Columns["Column44"].HeaderText = "تاريخ الإنتاج";
                                        dgvAlerts.Columns["Column45"].HeaderText = "تاريخ إنتهاء الصلاحيه";
                                        dgvAlerts.Columns["Column46"].HeaderText = "كمية التحذير";
                                        dgvAlerts.Columns["Column47"].HeaderText = "الكميه الحاليه";
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        dgvAlerts.Columns["Column42"].HeaderText = "Item Barcode";
                                        dgvAlerts.Columns["Column43"].HeaderText = "Item Name";
                                        dgvAlerts.Columns["Column44"].HeaderText = "Production Date";
                                        dgvAlerts.Columns["Column45"].HeaderText = "Expiration Date";
                                        dgvAlerts.Columns["Column46"].HeaderText = "Warning Limit";
                                        dgvAlerts.Columns["Column47"].HeaderText = "Current Quantity";
                                    }
                                }
                            }
                        }
                    }

                    Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsToAdd, frmPayCash.paybycash, DateTime.Now);
                    if (Connection.server.PayBill(billToAdd, this.cashierName))
                    {
                        // paid bill

                        printReceipt();
                        CapitalAmountnud.Value = Connection.server.GetCapitalAmount();
                        label91.Text = this.CapitalAmount.ToString();
                        this.customersaleItems.Clear();
                    }
                }
                else if (frmPayCash.dialogResult == DialogResult.Ignore)
                {
                    Item[] items = new Item[0];
                    int row = 0;
                    this.paidAmount = 0;
                    this.moneyInRegister += 0;
                    this.remainderAmount = this.paidAmount - this.totalAmount;

                    foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                    {
                        if (!currentBillRow.IsNewRow)
                        {
                            string itemName = currentBillRow.Cells[0].Value.ToString();
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                            decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                            decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            Array.Resize(ref items, items.Length + 1);
                            items[row] = new Item();
                            items[row].SetName(itemName);
                            items[row].SetBarCode(itemBarCode);
                            items[row].SetQuantity(itemQuantity);
                            items[row].SetPrice(itemPrice);
                            items[row++].SetPriceTax(itemPriceTax);
                        }
                    }

                    Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                    previousBillsList.Push(billToAdd);

                    frmPayCash.Dispose();
                    this.customersaleItems.Clear();
                }

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;

                richTextBox5.ResetText();
                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                    richTextBox3.AppendText(" :المجموع السابق " + this.totalAmount);
                    richTextBox2.AppendText(" :المدفوع السابق " + this.paidAmount);
                    richTextBox1.AppendText(" :الباقي السابق " + this.remainderAmount);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                    richTextBox3.AppendText(" Previous Total: " + this.totalAmount);
                    richTextBox2.AppendText(" Previous Paid: " + this.paidAmount);
                    richTextBox1.AppendText(" Previous Remainder: " + this.remainderAmount);
                }

                this.saleItems = Connection.server.RetrieveSaleToday(DateTime.Now, 10);
                ApplyDiscountsToPendingItems();

                if (frmPayCash.dialogResult == DialogResult.Cancel)
                {
                    richTextBox1.ResetText();
                    richTextBox2.ResetText();
                    richTextBox3.ResetText();
                    richTextBox4.ResetText();
                }

                ItemsPendingPurchase.Rows.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;

                if (heldBillsCount > 0)
                {
                    heldBillsCount -= 1;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        label112.Text = " Number of Pending Bills: " + heldBillsCount.ToString();
                    }
                }
            }
        }

        public void label93_MouseClick(object sender, MouseEventArgs e)
        {
            if (userPermissions.customer_card_edit)
            {
                frmClientCard customerCard = new frmClientCard();
                openedForm = customerCard;
                customerCard.ShowDialog();
                if (customerCard.dialogResult == DialogResult.OK)
                {
                    this.currentCustomer = customerCard.customer;
                    customerName.Text = customerCard.customer.CustomerName;
                    customerID.Value = customerCard.customer.CustomerID;

                    bool replaced = false;
                    foreach (Item item in customerCard.saleItems)
                    {
                        for (int i = 0; i < this.customersaleItems.Count; i++)
                        {
                            if (customersaleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                            {
                                int index = customerCard.saleItems.IndexOf(item);
                                this.customersaleItems[index] = item;
                                replaced = true;
                            }
                        }

                        if (!replaced)
                        {
                            this.customersaleItems.Add(item);
                        }
                    }

                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if (customersaleItems.Count > 0)
                            {
                                for (int i = 0; i < customersaleItems.Count; i++)
                                {
                                    if (customersaleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                    {
                                        decimal priceAfterSales;
                                        decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                        if (customersaleItems[i].saleRate != 0)
                                            priceAfterSales = Convert.ToDecimal((customersaleItems[i].customerPrice) * (customersaleItems[i].saleRate / 100));
                                        else priceAfterSales = Convert.ToDecimal(customersaleItems[i].customerPrice);
                                        decimal marginPrice = previousPrice - priceAfterSales;
                                        this.totalAmount = this.totalAmount - marginPrice;
                                        item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                        richTextBox4.ResetText();
                                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                        {
                                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                        }
                                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                        {
                                            richTextBox4.AppendText(" Total: " + this.totalAmount);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    customerCard.Dispose();
                    if (replaced)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Client Discount percentage was altered.", Application.ProductName);
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".تم اضافة خصم العميل", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Client Discount was added.", Application.ProductName);
                        }
                    }


                }
                else if (customerCard.dialogResult == DialogResult.None)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["Employees"];
                }
            }
        }

        public void label69_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void label68_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void label89_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void label2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void label24_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void label69_Click(object sender, EventArgs e)
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("You cannot add a new Bill before filling the current Bill.", Application.ProductName);
                }
            }
            else
            {
                Item[] items = new Item[0];
                int row = 0;
                foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                {
                    if (!currentBillRow.IsNewRow)
                    {
                        string itemName = currentBillRow.Cells[0].Value.ToString();
                        string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                        int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                        decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                        decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                        Array.Resize(ref items, items.Length + 1);
                        items[row] = new Item();
                        items[row].SetName(itemName);
                        items[row].SetBarCode(itemBarCode);
                        items[row].SetQuantity(itemQuantity);
                        items[row].SetPrice(itemPrice);
                        items[row++].SetPriceTax(itemPriceTax);
                    }
                }

                this.paidAmount = 0;
                this.moneyInRegister += 0;
                this.remainderAmount = this.paidAmount - this.totalAmount;

                Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                previousBillsList.Push(billToAdd);

                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox3.AppendText(" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.AppendText(" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.AppendText(" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox3.AppendText(" Previous Total: " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.AppendText(" Previous Paid: " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.AppendText(" Previous Remainder: " + previousBillsList.Peek().getRemainderAmount().ToString());
                }

                ItemsPendingPurchase.Rows.Clear();
                this.customersaleItems.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;
                items = null;
                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                }
                heldBillsCount += 1;
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    label112.Text = " Number of Pending Bills: " + heldBillsCount.ToString();
                }
            }
        }

        public void label68_Click(object sender, EventArgs e)
        {
            if (userPermissions.discount_edit)
            {
                try
                {
                    frmSales frmSales = new frmSales();
                    openedForm = frmSales;
                    frmSales.ShowDialog(this);

                    if (frmSales.dialogResult == DialogResult.OK)
                    {
                        bool replaced = false;
                        foreach (Item item in frmSales.saleItems)
                        {
                            for (int i = 0; i < this.saleItems.Count; i++)
                            {
                                if (saleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                                {
                                    int index = frmSales.saleItems.IndexOf(item);
                                    this.saleItems[index] = item;
                                    replaced = true;
                                }
                            }

                            if (!replaced)
                            {
                                this.saleItems.Add(item);
                            }
                        }

                        Connection.server.AddSaleOnItems(saleItems);

                        foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                        {
                            if (!item.IsNewRow)
                            {
                                if (saleItems.Count > 0)
                                {
                                    for (int i = 0; i < saleItems.Count; i++)
                                    {
                                        if (saleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                        {
                                            decimal priceAfterSales = 0;
                                            decimal tax = Convert.ToDecimal(saleItems[i].saleRate) / 100;
                                            decimal discount = (Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString()) * tax);
                                            decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                            if (saleItems[i].saleRate != 0)
                                                priceAfterSales = (Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString()) - discount);
                                            else priceAfterSales = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                            decimal marginPrice = previousPrice - priceAfterSales;
                                            this.totalAmount = this.totalAmount - marginPrice;
                                            item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                            richTextBox4.ResetText();
                                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                            {
                                                richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                            }
                                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                            {
                                                richTextBox4.AppendText(" Total: " + this.totalAmount);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        frmSales.Dispose();
                        if (replaced)
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".تعدلت نسبة خصم الأغراض", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Items Discount percentage was altered.", Application.ProductName);
                            }
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".تم اضافة الخصم", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Discount was added.", Application.ProductName);
                            }
                        }
                    }
                    else if (frmSales.dialogResult == DialogResult.Cancel)
                    {
                        frmSales.Dispose();
                    }
                }
                catch (Exception error)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نتمكن من اضافة الخصم", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to add a Discount.", Application.ProductName);
                    }
                }
            }
        }

        public void label89_Click(object sender, EventArgs e)
        {
            if (userPermissions.price_edit)
            {
                frmEditPrice editPrice = new frmEditPrice();
                openedForm = editPrice;
                editPrice.ShowDialog();
                if (editPrice.dialogResult == DialogResult.OK)
                {
                    this.totalAmount = editPrice.moneyDeduction;
                    richTextBox4.ResetText();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.AppendText(" Total: " + this.totalAmount);
                    }
                }
            }
        }

        public void label2_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument2.Print();
            }
            catch (Exception error)
            {
                MessageBox.Show(e.ToString(), Application.ProductName);
            }
        }

        public void label24_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);
                openedForm = itemLookup;
                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        List<Item> quantity_items = Connection.server.RetrieveItemsQuantity(itemLookup.selectedItem.GetItemBarCode());

                        /*foreach (Item item in quantity_items)
                        {
                            if (item.GetItemBarCode() == itemLookup.selectedItem.ItemBarCode)
                            {
                                if (item.GetQuantity() < 1)
                                {
                                    var file = $"{Path.GetTempPath()}temp.mp3";
                                    if (!File.Exists(file))
                                    {
                                        using (Stream output = new FileStream(file, FileMode.Create))
                                        {
                                            output.Write(Properties.Resources.beep, 0, Properties.Resources.beep.Length);
                                        }
                                    }
                                    var wmp = new WindowsMediaPlayer { URL = file };
                                    wmp.controls.play();
                                    if (MessageBox.Show(" .لا يمكن شراء الماده بسبب نفاذ الكميه " + " اضافة ماده؟ ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                                    {
                                        tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
                                        return;
                                    }
                                    //else return;
                                }
                            }
                        }*/

                        bool exists = false;
                        foreach (DataGridViewRow row in ItemsPendingPurchase.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                            {
                                if (row.Cells[1].Value.ToString().Equals(itemLookup.selectedItem.GetItemBarCode()))
                                {
                                    row.Cells["pendingPurchaseItemQuantity"].Value = Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value) + itemLookup.selectedItem.vendorQuantity;
                                    exists = true;
                                }
                            }
                        }

                        if (!exists && itemLookup.selectedItem != null)
                        {
                            var index = ItemsPendingPurchase.Rows.Add();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = itemLookup.selectedItem.GetName();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = itemLookup.selectedItem.GetItemBarCode();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = itemLookup.selectedItem.vendorQuantity;
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = itemLookup.selectedItem.GetPrice();
                            decimal priceAfterSales = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax());

                            if (customersaleItems.Count > 0)
                            {
                                for (int i = 0; i < customersaleItems.Count; i++)
                                {
                                    if (customersaleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                    {
                                        priceAfterSales = customersaleItems[i].customerPrice;
                                    }
                                }
                            }

                            if (saleItems.Count > 0)
                            {
                                for (int i = 0; i < saleItems.Count; i++)
                                {
                                    if (saleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                    {
                                        priceAfterSales = (Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax()) * saleItems[i].saleRate / 100);
                                        priceAfterSales = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax()) - priceAfterSales;
                                    }
                                }
                            }

                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                            richTextBox6.ResetText();
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                richTextBox6.AppendText(" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox6.AppendText(" Barcode: " + itemLookup.selectedItem.GetItemBarCode());
                            }
                        }
                        calculateStatistics();
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لا يمكن اضافة الماده", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Unable to add Item.", Application.ProductName);
                        }
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F1)
            {
                frmItemRefund frmItemRefund = new frmItemRefund(itemtypes, this.UID);
                openedForm = frmItemRefund;
                frmItemRefund.ShowDialog();
                capital = Connection.server.GetCapitalAmount();
                CapitalAmountnud.Value = capital;
                CapitalAmount = capital;
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    if (ItemsPendingPurchase.Rows[0].IsNewRow)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لا بمكتك دفع فاتوره فارغه", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("You cannot pay an empty Bill.", Application.ProductName);
                        }
                    }
                    else
                    {
                        frmPay frmPayCash = new frmPay(this.totalAmount);
                        openedForm = frmPayCash;
                        frmPayCash.ShowDialog(this);

                        if (frmPayCash.dialogResult == DialogResult.OK)
                        {
                            this.paidAmount = Convert.ToDecimal(frmPayCash.moneyPaid);
                            this.moneyInRegister += this.paidAmount;
                            this.remainderAmount = this.paidAmount - this.totalAmount;
                            frmPayCash.Dispose();

                            Item[] itemsToAdd = new Item[0];
                            int row = 0;
                            foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                            {
                                if (!currentBillRow.IsNewRow)
                                {
                                    string itemName = currentBillRow.Cells[0].Value.ToString();
                                    string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                                    int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                                    decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                                    decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                                    Array.Resize(ref itemsToAdd, itemsToAdd.Length + 1);
                                    itemsToAdd[row] = new Item();
                                    itemsToAdd[row].SetName(itemName);
                                    itemsToAdd[row].SetBarCode(itemBarCode);
                                    itemsToAdd[row].SetQuantity(itemQuantity);
                                    itemsToAdd[row].SetPrice(itemPrice);
                                    itemsToAdd[row++].SetPriceTax(itemPriceTax);
                                    int newItemQuantity = Connection.server.GetItemQuantity(itemBarCode) - itemQuantity;
                                    bool updatedQuantity = Connection.server.UpdateItemQuantity(new Item(itemName, itemBarCode, newItemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                                    Tuple<List<Item>, DataTable> itemsExpirationStock = Connection.server.RetrieveExpireStockToday(DateTime.Now);
                                    if (itemsExpirationStock != null)
                                    {
                                        if (itemsExpirationStock.Item1.Count > 0)
                                        {
                                            foreach (Item item in itemsExpirationStock.Item1)
                                            {
                                                if (item.ItemBarCode == itemBarCode)
                                                {
                                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                                    {
                                                        MessageBox.Show("قطعه باركود " + item.ItemBarCode + " انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف.");
                                                    }
                                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                                    {
                                                        MessageBox.Show("Item Barcode " + item.ItemBarCode + " is expired or has less quantity in inventory than defined warning limit.");
                                                    }
                                                }
                                            }
                                            dgvAlerts.DataSource = itemsExpirationStock.Item2;

                                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                            {
                                                dgvAlerts.Columns["Column42"].HeaderText = "باركود الماده";
                                                dgvAlerts.Columns["Column43"].HeaderText = "إسم الماده";
                                                dgvAlerts.Columns["Column44"].HeaderText = "تاريخ الإنتاج";
                                                dgvAlerts.Columns["Column45"].HeaderText = "تاريخ إنتهاء الصلاحيه";
                                                dgvAlerts.Columns["Column46"].HeaderText = "كمية التحذير";
                                                dgvAlerts.Columns["Column47"].HeaderText = "الكميه الحاليه";
                                            }
                                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                            {
                                                dgvAlerts.Columns["Column42"].HeaderText = "Item Barcode";
                                                dgvAlerts.Columns["Column43"].HeaderText = "Item Name";
                                                dgvAlerts.Columns["Column44"].HeaderText = "Production Date";
                                                dgvAlerts.Columns["Column45"].HeaderText = "Expiration Date";
                                                dgvAlerts.Columns["Column46"].HeaderText = "Warning Limit";
                                                dgvAlerts.Columns["Column47"].HeaderText = "Current Quantity";
                                            }
                                        }
                                    }
                                }
                            }

                            Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsToAdd, frmPayCash.paybycash, DateTime.Now);
                            if (Connection.server.PayBill(billToAdd, this.cashierName))
                            {
                                // paid bill

                                printReceipt();
                                capital = Connection.server.GetCapitalAmount();
                                CapitalAmountnud.Value = capital;
                                CapitalAmount = capital;
                                label91.Text = this.CapitalAmount.ToString();
                                this.customersaleItems.Clear();
                            }
                        }
                        else if (frmPayCash.dialogResult == DialogResult.Ignore)
                        {
                            Item[] items = new Item[0];
                            int row = 0;
                            this.paidAmount = 0;
                            this.moneyInRegister += 0;
                            this.remainderAmount = this.paidAmount - this.totalAmount;

                            foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                            {
                                if (!currentBillRow.IsNewRow)
                                {
                                    string itemName = currentBillRow.Cells[0].Value.ToString();
                                    string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                                    int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                                    decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                                    decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                                    Array.Resize(ref items, items.Length + 1);
                                    items[row] = new Item();
                                    items[row].SetName(itemName);
                                    items[row].SetBarCode(itemBarCode);
                                    items[row].SetQuantity(itemQuantity);
                                    items[row].SetPrice(itemPrice);
                                    items[row++].SetPriceTax(itemPriceTax);
                                }
                            }

                            Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                            previousBillsList.Push(billToAdd);

                            frmPayCash.Dispose();
                            this.customersaleItems.Clear();
                        }

                        this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;

                        richTextBox5.ResetText();
                        richTextBox4.ResetText();
                        richTextBox3.ResetText();
                        richTextBox2.ResetText();
                        richTextBox1.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                            richTextBox3.AppendText(" :المجموع السابق " + this.totalAmount);
                            richTextBox2.AppendText(" :المدفوع السابق " + this.paidAmount);
                            richTextBox1.AppendText(" :الباقي السابق " + this.remainderAmount);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                            richTextBox3.AppendText(" Previous Total: " + this.totalAmount);
                            richTextBox2.AppendText(" Previous Paid: " + this.paidAmount);
                            richTextBox1.AppendText(" Previous Remainder: " + this.remainderAmount);
                        }

                        this.saleItems = Connection.server.RetrieveSaleToday(DateTime.Now, 10);
                        ApplyDiscountsToPendingItems();

                        if (frmPayCash.dialogResult == DialogResult.Cancel)
                        {
                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                            richTextBox4.ResetText();
                        }

                        ItemsPendingPurchase.Rows.Clear();
                        this.totalAmount = 0;
                        this.paidAmount = 0;
                        this.remainderAmount = 0;

                        if (heldBillsCount > 0)
                        {
                            heldBillsCount -= 1;
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                label112.Text = " Number of Pending Bills: " + heldBillsCount.ToString();
                            }
                        }
                    }
                    break;

                case Keys.F2:
                    if (userPermissions.customer_card_edit)
                    {
                        frmClientCard customerCard = new frmClientCard();
                        openedForm = customerCard;
                        customerCard.ShowDialog();
                        if (customerCard.dialogResult == DialogResult.OK)
                        {
                            this.currentCustomer = customerCard.customer;
                            customerName.Text = customerCard.customer.CustomerName;
                            customerID.Value = customerCard.customer.CustomerID;

                            bool replaced = false;
                            foreach (Item item in customerCard.saleItems)
                            {
                                for (int i = 0; i < this.customersaleItems.Count; i++)
                                {
                                    if (customersaleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                                    {
                                        int index = customerCard.saleItems.IndexOf(item);
                                        this.customersaleItems[index] = item;
                                        replaced = true;
                                    }
                                }

                                if (!replaced)
                                {
                                    this.customersaleItems.Add(item);
                                }
                            }

                            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                            {
                                if (!item.IsNewRow)
                                {
                                    if (customersaleItems.Count > 0)
                                    {
                                        for (int i = 0; i < customersaleItems.Count; i++)
                                        {
                                            if (customersaleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                            {
                                                decimal priceAfterSales;
                                                decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                                if (customersaleItems[i].saleRate != 0)
                                                    priceAfterSales = Convert.ToDecimal((customersaleItems[i].customerPrice) * (customersaleItems[i].saleRate / 100));
                                                else priceAfterSales = Convert.ToDecimal(customersaleItems[i].customerPrice);
                                                decimal marginPrice = previousPrice - priceAfterSales;
                                                this.totalAmount = this.totalAmount - marginPrice;
                                                item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                                richTextBox4.ResetText();
                                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                                {
                                                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                                }
                                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                                {
                                                    richTextBox4.AppendText(" Total: " + this.totalAmount);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            customerCard.Dispose();
                            if (replaced)
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Client Items Discount was altered.", Application.ProductName);
                                }
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".تم اضافة خصم العميل", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Client Discount was added.", Application.ProductName);
                                }
                            }


                        }
                        else if (customerCard.dialogResult == DialogResult.None)
                        {
                            tabControl1.SelectedTab = tabControl1.TabPages["Employees"];
                        }
                    }
                        break;

                case Keys.F3:
                    if (ItemsPendingPurchase.Rows[0].IsNewRow)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("You cannot add a new Bill before filling the current Bill.", Application.ProductName);
                        }
                    }
                    else
                    {
                        Item[] items = new Item[0];
                        int row = 0;
                        foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                        {
                            if (!currentBillRow.IsNewRow)
                            {
                                string itemName = currentBillRow.Cells[0].Value.ToString();
                                string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                                int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                                decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                                decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                                Array.Resize(ref items, items.Length + 1);
                                items[row] = new Item();
                                items[row].SetName(itemName);
                                items[row].SetBarCode(itemBarCode);
                                items[row].SetQuantity(itemQuantity);
                                items[row].SetPrice(itemPrice);
                                items[row++].SetPriceTax(itemPriceTax);
                            }
                        }

                        this.paidAmount = 0;
                        this.moneyInRegister += 0;
                        this.remainderAmount = this.paidAmount - this.totalAmount;

                        Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                        previousBillsList.Push(billToAdd);

                        richTextBox4.ResetText();
                        richTextBox3.ResetText();
                        richTextBox2.ResetText();
                        richTextBox1.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox3.AppendText(" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                            richTextBox2.AppendText(" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                            richTextBox1.AppendText(" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox3.AppendText(" Previous Total: " + previousBillsList.Peek().getTotalAmount().ToString());
                            richTextBox2.AppendText(" Previous Paid: " + previousBillsList.Peek().getPaidAmount().ToString());
                            richTextBox1.AppendText(" Previous Remainder: " + previousBillsList.Peek().getRemainderAmount().ToString());
                        }

                        ItemsPendingPurchase.Rows.Clear();
                        this.customersaleItems.Clear();
                        this.totalAmount = 0;
                        this.paidAmount = 0;
                        this.remainderAmount = 0;
                        items = null;
                        this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                        richTextBox5.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                        }
                        heldBillsCount += 1;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            label112.Text = " Number of Pending Bills: " + heldBillsCount.ToString();
                        }
                    }
                    break;

                case Keys.F4:
                    if (userPermissions.discount_edit)
                    {
                        try
                        {
                            frmSales frmSales = new frmSales();
                            openedForm = frmSales;
                            frmSales.ShowDialog(this);

                            if (frmSales.dialogResult == DialogResult.OK)
                            {
                                bool replaced = false;
                                foreach (Item item in frmSales.saleItems)
                                {
                                    for (int i = 0; i < this.saleItems.Count; i++)
                                    {
                                        if (saleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                                        {
                                            int index = frmSales.saleItems.IndexOf(item);
                                            this.saleItems[index] = item;
                                            replaced = true;
                                        }
                                    }

                                    if (!replaced)
                                    {
                                        this.saleItems.Add(item);
                                    }
                                }

                                Connection.server.AddSaleOnItems(saleItems);


                                foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                                {
                                    if (!item.IsNewRow)
                                    {
                                        if (saleItems.Count > 0)
                                        {
                                            for (int i = 0; i < saleItems.Count; i++)
                                            {
                                                if (saleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                                {
                                                    decimal priceAfterSales = 0;
                                                    decimal tax = Convert.ToDecimal(saleItems[i].saleRate) / 100;
                                                    decimal discount = (Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString()) * tax);
                                                    decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                                    if (saleItems[i].saleRate != 0)
                                                        priceAfterSales = (Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString()) - discount);
                                                    else priceAfterSales = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                                    decimal marginPrice = previousPrice - priceAfterSales;
                                                    this.totalAmount = this.totalAmount - marginPrice;
                                                    item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                                    richTextBox4.ResetText();
                                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                                    {
                                                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                                    }
                                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                                    {
                                                        richTextBox4.AppendText(" Total: " + this.totalAmount);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                frmSales.Dispose();
                                if (replaced)
                                {
                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        MessageBox.Show(".تعدلت نسبة خصم الأغراض", Application.ProductName);
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        MessageBox.Show("Discount percentage was altered.", Application.ProductName);
                                    }
                                }
                                else
                                {
                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        MessageBox.Show(".تم اضافة الخصم", Application.ProductName);
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        MessageBox.Show("Discount was added.", Application.ProductName);
                                    }
                                }
                            }
                            else if (frmSales.dialogResult == DialogResult.Cancel)
                            {
                                frmSales.Dispose();
                            }
                        }
                        catch (Exception error)
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".لم نتمكن من اضافة الخصم", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Unable to add Discount.", Application.ProductName);
                            }
                        }
                    }
                    break;

                case Keys.F5:
                    if (userPermissions.price_edit)
                    {
                        frmEditPrice editPrice = new frmEditPrice();
                        openedForm = editPrice;
                        editPrice.ShowDialog();
                        if (editPrice.dialogResult == DialogResult.OK)
                        {
                            this.totalAmount = editPrice.moneyDeduction;
                            richTextBox4.ResetText();
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox4.AppendText(" Total: " + this.totalAmount);
                            }
                        }
                    }
                    break;

                case Keys.F6:
                    try
                    {
                        printDocument2.Print();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(e.ToString(), Application.ProductName);
                    }
                    break;

                case Keys.F7:
                    try
                    {
                        if (previousBillsList.Count > 0)
                        {
                            Item[] itemsBought = new Item[0];
                            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                            {
                                if (!item.IsNewRow)
                                {
                                    Array.Resize(ref itemsBought, itemsBought.Length + 1);
                                    string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                                    string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                                    int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                                    decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                                    decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                                    itemsBought[itemsBought.Length - 1] = new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now);

                                    richTextBox1.ResetText();
                                    richTextBox2.ResetText();
                                    richTextBox3.ResetText();
                                }
                            }
                            nextBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                            ItemsPendingPurchase.Rows.Clear();
                            Bill bill = previousBillsList.Pop();
                            //this.CurrentBillNumber = bill.getBillNumber();
                            this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                            foreach (Item item in bill.getItemsList())
                            {
                                var index = ItemsPendingPurchase.Rows.Add();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                                richTextBox1.ResetText();
                                richTextBox2.ResetText();
                                richTextBox3.ResetText();
                            }

                            calculateStatistics();
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("There are no pending Bills.", Application.ProductName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ItemsPendingPurchase.Rows.Clear();
                        Bill bill = previousBillsList.Pop();
                        foreach (Item item in bill.getItemsList())
                        {
                            var index = ItemsPendingPurchase.Rows.Add();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                        }

                        calculateStatistics();
                    }
                    break;

                case Keys.F8:
                    try
                    {
                        if (nextBillsList.Count > 0)
                        {
                            //this.CurrentBillNumber += 1;
                            Item[] itemsBought = new Item[0];
                            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                            {
                                if (!item.IsNewRow)
                                {
                                    Array.Resize(ref itemsBought, itemsBought.Length + 1);
                                    string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                                    string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                                    int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                                    decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                                    decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                                    itemsBought[itemsBought.Length - 1] = new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now);

                                    richTextBox1.ResetText();
                                    richTextBox2.ResetText();
                                    richTextBox3.ResetText();
                                }
                            }

                            previousBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                            ItemsPendingPurchase.Rows.Clear();
                            Bill bill = nextBillsList.Pop();
                            this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                            //this.CurrentBillNumber = bill.getBillNumber();

                            foreach (Item item in bill.getItemsList())
                            {
                                var index = ItemsPendingPurchase.Rows.Add();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                                ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                                richTextBox1.ResetText();
                                richTextBox2.ResetText();
                                richTextBox3.ResetText();
                            }

                            calculateStatistics();
                        }
                        else {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("There are no pending Bills.", Application.ProductName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Bill bill = nextBillsList.Pop();

                        foreach (Item item in bill.getItemsList())
                        {
                            ItemsPendingPurchase.Rows.Clear();
                            var index = ItemsPendingPurchase.Rows.Add();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = item.GetName();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = item.GetItemBarCode();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = item.GetQuantity();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = item.GetPrice();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = item.GetPriceTax();

                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                        }

                        calculateStatistics();
                    }
                    break;

                case Keys.F9:
                    try
                    {
                        frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);
                        openedForm = itemLookup;
                        itemLookup.ShowDialog(this);
                        if (itemLookup.dialogResult == DialogResult.OK)
                        {
                            try
                            {
                                List<Item> quantity_items = Connection.server.RetrieveItemsQuantity(itemLookup.selectedItem.GetItemBarCode());

                                /*foreach (Item item in quantity_items)
                                {
                                    if (item.GetItemBarCode() == itemLookup.selectedItem.ItemBarCode)
                                    {
                                        if (item.GetQuantity() < 1)
                                        {
                                            var file = $"{Path.GetTempPath()}temp.mp3";
                                            if (!File.Exists(file))
                                            {
                                                using (Stream output = new FileStream(file, FileMode.Create))
                                                {
                                                    output.Write(Properties.Resources.beep, 0, Properties.Resources.beep.Length);
                                                }
                                            }
                                            var wmp = new WindowsMediaPlayer { URL = file };
                                            wmp.controls.play();
                                            if (MessageBox.Show(" .لا يمكن شراء الماده بسبب نفاذ الكميه " + " اضافة ماده؟ ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                                            {
                                                tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
                                                return;
                                            }
                                            //else return;
                                        }
                                    }
                                }*/

                                bool exists = false;
                                foreach (DataGridViewRow row in ItemsPendingPurchase.Rows)
                                {
                                    if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                                    {
                                        if (row.Cells[1].Value.ToString().Equals(itemLookup.selectedItem.GetItemBarCode()))
                                        {
                                            row.Cells["pendingPurchaseItemQuantity"].Value = Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value) + itemLookup.selectedItem.vendorQuantity;
                                            exists = true;
                                        }
                                    }
                                }

                                if (!exists && itemLookup.selectedItem != null)
                                {
                                    var index = ItemsPendingPurchase.Rows.Add();
                                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = itemLookup.selectedItem.GetName();
                                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = itemLookup.selectedItem.GetItemBarCode();
                                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = itemLookup.selectedItem.vendorQuantity;
                                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = itemLookup.selectedItem.GetPrice();
                                    decimal priceAfterSales = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax());

                                    if (customersaleItems.Count > 0)
                                    {
                                        for (int i = 0; i < customersaleItems.Count; i++)
                                        {
                                            if (customersaleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                            {
                                                priceAfterSales = customersaleItems[i].customerPrice;
                                            }
                                        }
                                    }

                                    if (saleItems.Count > 0)
                                    {
                                        for (int i = 0; i < saleItems.Count; i++)
                                        {
                                            if (saleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                            {
                                                priceAfterSales = (Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax()) * saleItems[i].saleRate / 100);
                                                priceAfterSales = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax()) - priceAfterSales;
                                            }
                                        }
                                    }

                                    ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                    richTextBox6.ResetText();
                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        richTextBox6.AppendText(" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        richTextBox6.AppendText(" Barcode: " + itemLookup.selectedItem.GetItemBarCode());
                                    }

                                }
                                calculateStatistics();
                            }
                            catch (Exception ex)
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لا يمكن اضافة الماده", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("Unable to add Item.", Application.ProductName);
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                    }
                    break;
                case Keys.F11:
                    if (!userPermissions.openclose_edit)
                        return;

                    frmOpenRegister openRegister = new frmOpenRegister(this.cashierName);
                    openedForm = openRegister;
                    openRegister.ShowDialog(this);
                    if (openRegister.dialogResult == DialogResult.OK)
                    {
                        this.registerOpen = true;
                        this.moneyInRegisterInitial = this.moneyInRegister = openRegister.moneyInRegister;
                        openRegister.Dispose();
                        bool openedRegister = Connection.server.SaveRegisterOpen(cashierName, moneyInRegister);
                        if (openedRegister)
                        {
                            Properties.Settings.Default.RegisterOpen = true;
                            Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                            Properties.Settings.Default.moneyInRegisterInitial = this.moneyInRegisterInitial;
                            Properties.Settings.Default.Save();
                            tabControl2.Enabled = true;
                            groupBox4.Enabled = true;
                            groupBox3.Enabled = true;
                            closeRegisterBtn.Enabled = true;
                            label66.Enabled = true;
                            openRegisterBtn.Enabled = false;
                            label65.Enabled = false;
                            // get last bill number of today
                            this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                            richTextBox4.ResetText();
                            richTextBox5.ResetText();

                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                                MessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox4.AppendText(" Total: " + this.totalAmount);
                                richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                                MessageBox.Show(String.Format("You have opened the cash register with an amount of {0} JOD.", moneyInRegister), Application.ProductName);
                            }
                            this.Select();
                        }
                    }
                    break;

                case Keys.F12:
                    try
                    {
                        if (!userPermissions.openclose_edit)
                            return;

                        if (!registerOpen)
                            return;

                        frmCloseRegister closeRegister = new frmCloseRegister(this.cashierName, Connection.server.GetOpenRegisterAmount());
                        openedForm = closeRegister;
                        closeRegister.ShowDialog(this);
                        if (closeRegister.dialogResult == DialogResult.OK)
                        {
                            bool closedRegister = Connection.server.SaveRegisterClose(cashierName, moneyInRegister);
                            if (closedRegister)
                            {
                                Properties.Settings.Default.RegisterOpen = false;
                                Properties.Settings.Default.Save();
                                this.registerOpen = false;
                                tabControl2.Enabled = false;
                                groupBox4.Enabled = false;
                                groupBox3.Enabled = false;
                                closeRegisterBtn.Enabled = false;
                                label66.Enabled = false;
                                openRegisterBtn.Enabled = true;
                                label65.Enabled = true;

                                printCloseRegister();

                                try
                                {

                                    DataTable retrievedLoginLogoutData = Connection.server.RetrieveLoginLogoutInfo(DateTime.Now);

                                    dgvLoginLogout.DataSource = retrievedLoginLogoutData;
                                    for (int i = 0; i < dgvLoginLogout.Rows.Count; i++)
                                    {
                                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvLoginLogout.DataSource];
                                        currencyManager1.SuspendBinding();
                                        dgvLoginLogout.Rows[i].Selected = true;
                                        dgvLoginLogout.Rows[i].Visible = true;
                                        currencyManager1.ResumeBinding();
                                    }
                                    dgvLoginLogout.Refresh();

                                    DGVPrinter printer = new DGVPrinter();
                                    DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                                    {
                                        ImageAlignment = DGVPrinter.Alignment.Left,
                                        ImageLocation = DGVPrinter.Location.Absolute,
                                        ImageX = 0,
                                        ImageY = 0,
                                        theImage = Properties.Resources.plancksoft_b_t
                                    };
                                    printer.ImbeddedImageList.Add(logo);

                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        printer.Title = ".تقرير اغلاق الصندوف";
                                        printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                                        printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        printer.Title = "Register Close Report.";
                                        printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                                        printer.Footer = "Report was generated from User: " + this.UID + ".";
                                    }
                                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                                    printer.PageNumbers = true;
                                    printer.PageNumberInHeader = false;
                                    printer.PorportionalColumns = true;
                                    printer.HeaderCellAlignment = StringAlignment.Near;
                                    printer.FooterSpacing = 15;
                                    printer.printDocument.DefaultPageSettings.Landscape = false;
                                    this.WindowState = FormWindowState.Normal;
                                    this.Size = new Size(800, 600);
                                    printer.PrintDataGridView(dgvLoginLogout);
                                    this.WindowState = FormWindowState.Maximized;
                                }
                                catch (Exception ex)
                                {
                                    this.WindowState = FormWindowState.Maximized;
                                    MessageBox.Show(ex.Message.ToString(), Application.ProductName);
                                }

                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MessageBox.Show(".لفد قمت باغلاق الصندوق", Application.ProductName);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MessageBox.Show("You have closed the cash register.", Application.ProductName);
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {

                    }
                    break;
            }
        }

        public void label66_Click(object sender, EventArgs e)
        {
            if (!userPermissions.openclose_edit)
                return;

            try
            {
                frmCloseRegister closeRegister = new frmCloseRegister(this.cashierName, Connection.server.GetOpenRegisterAmount());
                openedForm = closeRegister;
                closeRegister.ShowDialog(this);
                if (closeRegister.dialogResult == DialogResult.OK)
                {
                    bool closedRegister = Connection.server.SaveRegisterClose(cashierName, moneyInRegister);
                    if (closedRegister)
                    {
                        Properties.Settings.Default.RegisterOpen = false;
                        Properties.Settings.Default.Save();
                        this.registerOpen = false;
                        tabControl2.Enabled = false;
                        groupBox4.Enabled = false;
                        groupBox3.Enabled = false;
                        closeRegisterBtn.Enabled = false;
                        label66.Enabled = false;
                        openRegisterBtn.Enabled = true;
                        label65.Enabled = true;

                        printCloseRegister();

                        try
                        {
                            DataTable retrievedLoginLogoutData = Connection.server.RetrieveLoginLogoutInfo(DateTime.Now);

                            dgvLoginLogout.DataSource = retrievedLoginLogoutData;
                            for (int i = 0; i < dgvLoginLogout.Rows.Count; i++)
                            {
                                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvLoginLogout.DataSource];
                                currencyManager1.SuspendBinding();
                                dgvLoginLogout.Rows[i].Selected = true;
                                dgvLoginLogout.Rows[i].Visible = true;
                                currencyManager1.ResumeBinding();
                            }
                            dgvLoginLogout.Refresh();

                            DGVPrinter printer = new DGVPrinter();
                            DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                            {
                                ImageAlignment = DGVPrinter.Alignment.Left,
                                ImageLocation = DGVPrinter.Location.Absolute,
                                ImageX = 0,
                                ImageY = 0,
                                theImage = Properties.Resources.plancksoft_b_t
                            };
                            printer.ImbeddedImageList.Add(logo);
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                printer.Title = ".تقرير اغلاق الصندوف";
                                printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                                printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                printer.Title = "Register Close Report.";
                                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                                printer.Footer = "Report was generated from User: " + this.UID + ".";
                            }
                            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                            printer.PageNumbers = true;
                            printer.PageNumberInHeader = false;
                            printer.PorportionalColumns = true;
                            printer.HeaderCellAlignment = StringAlignment.Near;
                            printer.FooterSpacing = 15;
                            printer.printDocument.DefaultPageSettings.Landscape = false;
                            this.WindowState = FormWindowState.Normal;
                            this.Size = new Size(800, 600);
                            printer.PrintDataGridView(dgvLoginLogout);
                            this.WindowState = FormWindowState.Maximized;
                        }
                        catch (Exception ex)
                        {
                            this.WindowState = FormWindowState.Maximized;
                            MessageBox.Show(ex.Message.ToString(), Application.ProductName);
                        }

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لفد قمت باغلاق الصندوق", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("You have closed the cash register.", Application.ProductName);
                        }
                    }
                }
            }
            catch (Exception error)
            {

            }
        }

        public void label65_Click(object sender, EventArgs e)
        {
            if (!userPermissions.openclose_edit)
                return;

            frmOpenRegister openRegister = new frmOpenRegister(this.cashierName);
            openedForm = openRegister;
            openRegister.ShowDialog(this);
            if (openRegister.dialogResult == DialogResult.OK)
            {
                this.registerOpen = true;
                this.moneyInRegisterInitial = this.moneyInRegister = openRegister.moneyInRegister;
                openRegister.Dispose();
                bool openedRegister = Connection.server.SaveRegisterOpen(cashierName, moneyInRegister);
                if (openedRegister)
                {
                    Properties.Settings.Default.RegisterOpen = true;
                    Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                    Properties.Settings.Default.moneyInRegisterInitial = this.moneyInRegisterInitial;
                    Properties.Settings.Default.Save();
                    tabControl2.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox3.Enabled = true;
                    closeRegisterBtn.Enabled = true;
                    label66.Enabled = true;
                    openRegisterBtn.Enabled = false;
                    label65.Enabled = false;
                    // get last bill number of today
                    this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    richTextBox4.ResetText();
                    richTextBox5.ResetText();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                        richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        MessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), Application.ProductName);
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.AppendText(" Total: " + this.totalAmount);
                        richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                        MessageBox.Show(String.Format("You have opened the cash register with the amount {0} JOD.", moneyInRegister), Application.ProductName);
                    }
                    this.Select();
                }
            }
        }

        public void txtUserNameAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button22.PerformClick();
        }

        public void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (WarehousesQuantityList.Text != "")
                {
                    Tuple<List<Item>, DataTable> RetrievedItems;
                    int WarehouseID = Connection.server.RetrieveWarehouseID(WarehousesQuantityList.SelectedItem.ToString());
                    RetrievedItems = Connection.server.SearchWarehouseInventoryItems(WarehouseID);
                    dgvWarehouseInventory.DataSource = RetrievedItems.Item2;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn32"].HeaderText = "إسم القطعة";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn37"].HeaderText = "باركود القطعه";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn38"].HeaderText = "عدد القطعه";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn42"].HeaderText = "سعر الشراء";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn45"].HeaderText = "سعر القطعة";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn46"].HeaderText = "سعر القطعة بالضريبة";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn47"].HeaderText = "المصنف المفضل";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn48"].HeaderText = "المستودع";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn49"].HeaderText = "تصنيف المادة";
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn32"].HeaderText = "Item Name";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn37"].HeaderText = "Item Barcode";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn38"].HeaderText = "Item Quantity";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn42"].HeaderText = "Buy Price";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn45"].HeaderText = "Sell Price";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn46"].HeaderText = "Sell Price Tax";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn47"].HeaderText = "Favorite Category";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn48"].HeaderText = "Warehouse";
                        dgvWarehouseInventory.Columns["dataGridViewTextBoxColumn49"].HeaderText = "Item Type";
                    }
                }
            }
            catch { }
        }

        public void pictureBox47_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = WarehousesQuantityList.SelectedItem.ToString() + " تقرير جرد المستودع ";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Warehouse Quantify Report: " + WarehousesQuantityList.SelectedItem.ToString();
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvWarehouseInventory);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void button14_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);
                openedForm = itemLookup;
                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (itemLookup.selectedItem != null)
                        {
                            WarehouseEntryExitItemBarCode.Text = itemLookup.selectedItem.GetItemBarCode();
                            WarehouseEntryExitItemName.Text = itemLookup.selectedItem.GetName();
                            WarehouseEntryExitList.SelectedIndex = WarehouseEntryExitList.FindStringExact(Connection.server.RetrieveWarehouseName(Convert.ToInt32(itemLookup.selectedItem.Warehouse_ID), (int)frmLogin.pickedLanguage));
                            EntryExitItemBuyPrice.Value = itemLookup.selectedItem.ItemBuyPrice;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لا يمكن اختيار الماده", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Unable to pick Item.", Application.ProductName);
                        }
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void button15_Click(object sender, EventArgs e)
        {
            try
            {
                List<Item> itemsToAdd = new List<Item>();

                foreach (DataGridViewRow currentBillRow in dvgEntryExitItems.Rows)
                {
                    if (!currentBillRow.IsNewRow)
                    {
                        if (currentBillRow.Cells[0].Value != null && currentBillRow.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(currentBillRow.Cells[0].Value.ToString()))
                        {
                            Item newItem = new Item();

                            newItem.SetName(currentBillRow.Cells[0].Value.ToString());
                            newItem.SetBarCode(currentBillRow.Cells[1].Value.ToString());
                            newItem.SetQuantity(Convert.ToInt32(currentBillRow.Cells[2].Value.ToString()));
                            newItem.SetBuyPrice(Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString()));
                            newItem.QuantityWarning = Convert.ToInt32(currentBillRow.Cells[5].Value.ToString());
                            newItem.ProductionDate = Convert.ToDateTime(currentBillRow.Cells[6].Value.ToString());
                            newItem.ExpirationDate = Convert.ToDateTime(currentBillRow.Cells[7].Value.ToString());
                            newItem.EntryDate = Convert.ToDateTime(currentBillRow.Cells[8].Value.ToString());

                            if (WarehouseEntryExitList.SelectedItem != null)
                            {
                                int WarehouseID = Connection.server.RetrieveWarehouseID(currentBillRow.Cells[3].Value.ToString());
                                newItem.SetWarehouseID(WarehouseID);
                            }
                            else newItem.SetWarehouseID(0);
                            itemsToAdd.Add(newItem);
                        }
                        
                    }
                }
                dvgEntryExitItems.Rows.Clear();

                if (Connection.server.UpdateItemWarehouse(itemsToAdd, this.UID, EntryExitType.SelectedIndex))
                {
                    this.ItemsList = DisplayData();
                    DisplayFavorites();

                    capital = Connection.server.GetCapitalAmount();
                    CapitalAmountnud.Value = capital;
                    CapitalAmount = capital;
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم ادخال العمليه", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Transaction was submitted.", Application.ProductName);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نتمكن من ادخال العمليه", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to submit Transaction.", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من اتمام العمليه", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to commit Transaction.", Application.ProductName);
                }
            }
        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {
            DisplayEmployees();
            for (int i = 0; i < dgvEmployees.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvEmployees.DataSource];
                currencyManager1.SuspendBinding();
                dgvEmployees.Rows[i].Selected = true;
                dgvEmployees.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            dgvEmployees.Refresh();
        }

        public void button34_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الاضافه فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Management can only be done by Administrator Accounts.", this.ProductName);
                }
                return;
            }
            if (AddEmployeeName.Text != "" && AddEmployeeSalary.Value != 0)
            {
                if (Connection.server.InsertEmployee(AddEmployeeName.Text, AddEmployeeSalary.Value, AddEmployeePhone.Text, AddEmployeeAddress.Text))
                {
                    AddEmployeeName.Text = "";
                    AddEmployeeSalary.Value = 0;
                    AddEmployeePhone.Text = "";
                    AddEmployeeAddress.Text = "";

                    DisplayEmployees();
                    for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvEmployees.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvEmployees.Rows[i].Selected = true;
                        dgvEmployees.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvEmployees.Refresh();

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم تسجيل الموظف", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Employee was registered.", Application.ProductName);
                    }

                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نتمكن من تسجيل الموظف", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to register Employee.", Application.ProductName);
                    }
                }
            }
        }

        public void dgvEmployees_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                EmployeeID = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString());
                EditEmployeeName.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                AbsenceEmpName.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                EditEmployeeSalary.Value = Convert.ToDecimal(dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString());
                EditEmployeePhone.Text = dgvEmployees.Rows[e.RowIndex].Cells[3].Value.ToString();
                EditEmployeeAddress.Text = dgvEmployees.Rows[e.RowIndex].Cells[4].Value.ToString();
                button32.Enabled = true;
                button16.Enabled = true;
                button35.Enabled = true;
                button37.Enabled = true;
            }
            catch (Exception ex) { }
        }

        public void button16_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Management can only be done through Administrator Accounts.", this.ProductName);
                }
                return;
            }
            if (EmployeeID != 0)
            {
                if (Connection.server.DeleteEmployee(EmployeeID))
                {
                    DisplayEmployees();
                    for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvEmployees.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvEmployees.Rows[i].Selected = true;
                        dgvEmployees.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvEmployees.Refresh();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لا يمكن حذف الموظف", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to delete Employee.", Application.ProductName);
                    }
                }
                EditEmployeeName.Text = "";
                EditEmployeeSalary.Value = 0;
                EditEmployeePhone.Text = "";
                EditEmployeeAddress.Text = "";
                EmployeeID = 0;
                button32.Enabled = false;
                button16.Enabled = false;
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please fill all required data!", Application.ProductName);
                }
                EditEmployeeName.Text = "";
                EditEmployeeSalary.Value = 0;
                EditEmployeePhone.Text = "";
                EditEmployeeAddress.Text = "";
                EmployeeID = 0;
                button32.Enabled = false;
                button16.Enabled = false;
            }
        }

        public void pictureBox43_Click(object sender, EventArgs e)
        {
            DisplayAbsence();
            for (int i = 0; i < dgvAbsence.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAbsence.DataSource];
                currencyManager1.SuspendBinding();
                dgvAbsence.Rows[i].Selected = true;
                dgvAbsence.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
            }
            dgvAbsence.Refresh();
        }

        public void pictureBox48_Click(object sender, EventArgs e)
        {
            DataTable RetrievedAbsences = Connection.server.RetrieveAbsence(AbsenceFrom.Value, AbsenceTo.Value);
            dgvAbsence.DataSource = RetrievedAbsences;
        }

        public void button37_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الإضافه فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Management can only be done through Administrator Accounts.", this.ProductName);
                }
                return;
            }
            if (EmployeeID != 0 && AbsenceEmpName.Text != "")
            {
                if (AbsenceHours.SelectedItem.ToString() != "يوم اجازه")
                {
                    if (Connection.server.InsertAbsence(EmployeeID, AbsenceDate.Value, Convert.ToInt32(AbsenceHours.SelectedItem.ToString())))
                    {
                        AbsenceEmpName.Text = "";
                        AbsenceDate.Value = DateTime.Now;
                        AbsenceHours.SelectedIndex = 0;
                        button37.Enabled = false;

                        DisplayAbsence();
                        for (int i = 0; i < dgvAbsence.Rows.Count; i++)
                        {
                            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAbsence.DataSource];
                            currencyManager1.SuspendBinding();
                            dgvAbsence.Rows[i].Selected = true;
                            dgvAbsence.Rows[i].Visible = true;
                            currencyManager1.ResumeBinding();
                        }
                        dgvAbsence.Refresh();

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".تم تسجيل الغياب", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("An absence was recorded.", Application.ProductName);
                        }

                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لم نتمكن من تسجيل الغياب", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Unable to record Absence.", Application.ProductName);
                        }
                    }
                } else if (Connection.server.InsertDayOff(EmployeeID, AbsenceDate.Value))
                    {
                    AbsenceEmpName.Text = "";
                    AbsenceDate.Value = DateTime.Now;
                    AbsenceHours.SelectedIndex = 0;
                    button37.Enabled = false;

                    DisplayAbsence();
                    for (int i = 0; i < dgvAbsence.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAbsence.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvAbsence.Rows[i].Selected = true;
                        dgvAbsence.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvAbsence.Refresh();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم تسجيل الغياب", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("An Absence was recorded.", Application.ProductName);
                    }
                }
            }
        }

        public void button33_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Management can only be done through Administrator Accounts.", this.ProductName);
                }
                return;
            }
            if (AbsenceID != 0)
            {
                if (Connection.server.DeleteAbsence(AbsenceID))
                {
                    DisplayAbsence();
                    for (int i = 0; i < dgvAbsence.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAbsence.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvAbsence.Rows[i].Selected = true;
                        dgvAbsence.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvAbsence.Refresh();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لا يمكن حذف الغياب", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to delete Absence.", Application.ProductName);
                    }
                }
                AbsenceID = 0;
                button33.Enabled = false;
            }
        }

        public void button35_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Management can only be done through Administrative Accounts.", this.ProductName);
                }
                return;
            }
            if (EmployeeID != 0)
            {
                if (Connection.server.InsertDeduction(EmployeeID, DateTime.Now, SalaryDeduction.Value))
                {
                    DisplayAbsence();
                    for (int i = 0; i < dgvAbsence.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvAbsence.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvAbsence.Rows[i].Selected = true;
                        dgvAbsence.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvAbsence.Refresh();
                    DisplayEmployees();
                    for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvEmployees.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvEmployees.Rows[i].Selected = true;
                        dgvEmployees.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvEmployees.Refresh();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لا يمكن حذف الغياب", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to delete Absence.", Application.ProductName);
                    }
                }
                AbsenceID = 0;
                SalaryDeduction.Value = 0;
                button35.Enabled = false;
            }
        }

        public void button38_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dvgEntryExitItems.Rows.Add();
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemName"].Value = WarehouseEntryExitItemName.Text;
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemBarCode"].Value = WarehouseEntryExitItemBarCode.Text;
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemQuantity2"].Value = Convert.ToInt32(EntryExitItemQuantity.Value);
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemVendorItemBuyPrice"].Value = Convert.ToDecimal(EntryExitItemBuyPrice.Value);
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemWarehouse"].Value = WarehouseEntryExitList.SelectedItem.ToString();
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemWarningQuantity"].Value = Convert.ToInt32(EntryExitWarningQuantity.Value);
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemProductionDate"].Value = Convert.ToDateTime(EntryExitProductionDate.Value);
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemEndDate"].Value = Convert.ToDateTime(EntryExitExpirationDate.Value);
                dvgEntryExitItems.Rows[index].Cells["EntryExitItemEntryDate"].Value = Convert.ToDateTime(EntryExitEntryDate.Value);

                WarehouseEntryExitItemName.Text = "";
                WarehouseEntryExitItemBarCode.Text = "";
                EntryExitItemQuantity.Value = 0;
                EntryExitItemBuyPrice.Value = 0;
                EntryExitWarningQuantity.Value = 0;
                EntryExitProductionDate.Value = DateTime.Now;
                EntryExitExpirationDate.Value = DateTime.Now;
                EntryExitEntryDate.Value = DateTime.Now;
            } catch (Exception error)
            {

            }
        }

        public void dvgEntryExitItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                button36.Enabled = true;
            } catch (Exception error)
            {

            }
        }

        public void button36_Click(object sender, EventArgs e)
        {
            try
            {
                int Index = dvgEntryExitItems.CurrentCell.RowIndex;
                DataGridViewRow row = dvgEntryExitItems.Rows[Index];
                if (row.Selected)
                {
                    if (!row.IsNewRow)
                    {
                        int quantity = Convert.ToInt32(row.Cells["EntryExitItemQuantity2"].Value);
                        int deletionquantity = Convert.ToInt32(quantity);
                        if (quantity > 1 && quantity - deletionquantity > 0)
                            row.Cells["EntryExitItemQuantity2"].Value = quantity - deletionquantity;
                        else if (quantity - deletionquantity <= 0)
                            dvgEntryExitItems.Rows.RemoveAt(Index);
                    } else
                    {
                        dvgEntryExitItems.Rows.RemoveAt(Index);
                    }
                }
                button36.Enabled = false;
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطيع حذف الماده", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Item.", Application.ProductName);
                }
            }
        }

        public void pendingPurchaseRemovalQuantity_Enter(object sender, EventArgs e)
        {
            pendingPurchaseRemovalQuantity.Select(0, pendingPurchaseRemovalQuantity.Value.ToString().Length);
            pendingPurchaseRemovalQuantity.Focus();
        }

        public void pendingPurchaseNewQuantity_Enter(object sender, EventArgs e)
        {
            pendingPurchaseNewQuantity.Select(0, pendingPurchaseNewQuantity.Value.ToString().Length);
            pendingPurchaseNewQuantity.Focus();
        }

        public void nudBillNumberSearch_Enter_1(object sender, EventArgs e)
        {
            nudBillNumberSearch.Select(0, nudBillNumberSearch.Value.ToString().Length);
            pendingPurchaseRemovalQuantity.Focus();
        }

        public void nudBillNumberEdit_Enter(object sender, EventArgs e)
        {
            nudBillNumberEdit.Select(0, nudBillNumberEdit.Value.ToString().Length);
            pendingPurchaseRemovalQuantity.Focus();
        }

        public void BillsCashierName_Enter(object sender, EventArgs e)
        {

        }

        public void QuantityWarning_Enter_1(object sender, EventArgs e)
        {
            QuantityWarning.Select(0, QuantityWarning.Value.ToString().Length);
            pendingPurchaseRemovalQuantity.Focus();
        }

        private void switchThemeScheme_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                bool addedFavoriteCategory = Connection.server.InsertFavoriteCategory(FavoriteCategoryEntry.Text);
                if (addedFavoriteCategory)
                {
                    DisplayFavorites();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ مجلد المفضلات الجديد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Favorite Category was saved.", Application.ProductName);
                    }
                }
            }
        }

        public void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                bool addedWarehouse = Connection.server.InsertWarehouse(WarehouseEntry.Text);
                if (addedWarehouse)
                {
                    DisplayWarehouses();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم حفظ المستودع الجديد", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("A new Warehouse was saved.", Application.ProductName);
                    }
                }
            }
        }

        public void CapitalAmountnud_Enter(object sender, EventArgs e)
        {
            CapitalAmountnud.Select(0, 1);
        }

        public void pictureBox49_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير المواد المرجعه";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Returned Items Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvReturnedItems);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void العربيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin.pickedLanguage = LanguageChoice.Languages.Arabic;
                Properties.Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.Arabic;
                Properties.Settings.Default.Save();
                englishToolStripMenuItem.Checked = false;
                العربيةToolStripMenuItem.Checked = true;
                applyLocalizationOnUI();
                openedForm.Close();
                openedForm.ShowDialog();
            }
            catch(Exception err) { }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin.pickedLanguage = LanguageChoice.Languages.English;
                Properties.Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.English;
                Properties.Settings.Default.Save();
                englishToolStripMenuItem.Checked = true;
                العربيةToolStripMenuItem.Checked = false;
                applyLocalizationOnUI();
                openedForm.Close();
                openedForm.ShowDialog();
            }
            catch (Exception err) { }
        }

        public void pictureBox29_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير جرد الكميات المباعة";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Sold Items Quantification Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvItemProfit);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox32_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير لائحة الفواتير";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID + ".";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Bills List Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvBillsEdit);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void pictureBox35_Click_1(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير الفواتير";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Bills Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvVendorBillItems);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void frmMain_Load(object sender, EventArgs e)
        {

        }

        public void pictureBox99_Click(object sender, EventArgs e)
        {
            refreshInventoryItems();
        }

        public void refreshInventoryItems()
        {
            try
            {
                this.ItemsList = DisplayData();
                for (int i = 0; i < DgvInventory.Rows.Count; i++)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DgvInventory.DataSource];
                    currencyManager1.SuspendBinding();
                    DgvInventory.Rows[i].Selected = true;
                    DgvInventory.Rows[i].Visible = true;
                    currencyManager1.ResumeBinding();
                }
                DgvInventory.Refresh();

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    DgvInventory.Columns["InventoryItemName"].HeaderText = "إسم القطعة";
                    DgvInventory.Columns["ItemID"].HeaderText = "رقم القطعه";
                    DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "باركود القطعه";
                    DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "عدد القطعه";
                    DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "سعر الشراء";
                    DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "سعر القطعة";
                    DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "سعر القطعة بالضريبة";
                    DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "المصنف المفضل";
                    DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "المستودع";
                    DgvInventory.Columns["InventoryItemType"].HeaderText = "تصنيف المادة";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    DgvInventory.Columns["InventoryItemName"].HeaderText = "Item Name";
                    DgvInventory.Columns["ItemID"].HeaderText = "Item ID";
                    DgvInventory.Columns["InventoryItemBarCode"].HeaderText = "Item Barcode";
                    DgvInventory.Columns["InventoryItemQuantity"].HeaderText = "Item Quantity";
                    DgvInventory.Columns["InventoryItemBuyPrice"].HeaderText = "Item Buy Price";
                    DgvInventory.Columns["InventoryItemSellPrice"].HeaderText = "Sell Price";
                    DgvInventory.Columns["InventoryItemSellPriceTax"].HeaderText = "Sell Price Tax";
                    DgvInventory.Columns["InventoryItemFavoriteCategory"].HeaderText = "Favorite Category";
                    DgvInventory.Columns["InventoryItemWarehouse"].HeaderText = "Warehouse";
                    DgvInventory.Columns["InventoryItemType"].HeaderText = "Item Type";
                }

                nudItemBarCodeSearch.Text = "";
                txtItemNameSearch.Text = "";
            }
            catch { }
        }

        public void picLogoStore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    picLogoStore.Image = new Bitmap(open.FileName);
                    picLogo.Image = new Bitmap(open.FileName);
                    if (picLogoStore.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        picLogoStore.Image.Save(ms, picLogoStore.Image.RawFormat);
                        byte[] a = ms.GetBuffer();
                        ms.Close();
                        StoreLogo = a;
                    }
                }
            }
            catch(Exception err)
            {
                StoreLogo = null;
                picLogoStore.Image = Resources.plancksoft_b_t;
                picLogo.Image = Resources.plancksoft_b_t;
            }
        }

        public void button29_Click(object sender, EventArgs e)
        {
            try
            {
                StoreLogo = null;
                picLogoStore.Image = Resources.plancksoft_b_t;
                picLogo.Image = Resources.plancksoft_b_t;
            }
            catch (Exception err)
            { }
        }

        private void lastBillNumberUpdaterTimer_Tick(object sender, EventArgs e)
        {
            this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
            richTextBox5.ResetText();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
            }
        }

        private void updateSystem_Tick(object sender, EventArgs e)
        {
            applyAuthorityPermissions();
            refreshSettings();
            DisplayPrinters();
            DisplayItemTypes();
            DisplayFavoriteItems();
            DisplayWarehouses();
            DisplayFavorites();
            refreshInventoryItems();

            this.saleItems = Connection.server.RetrieveSaleToday(DateTime.Now, 10);
            ApplyDiscountsToPendingItems();
        }

        public void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                bool addedItemType = Connection.server.InsertItemType(ItemTypeEntry.Text);
                if (addedItemType)
                {
                    DisplayItemTypes();
                }
            }
        }

        public void dgvAbsence_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AbsenceID = Convert.ToInt32(dgvAbsence.Rows[e.RowIndex].Cells[0].Value);
                button33.Enabled = true;
            } catch { }
        }

        public void button32_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Management could only be done through Administrative Accounts.", this.ProductName);
                }
                return;
            }
            if (EmployeeID != 0 && EditEmployeeName.Text != "" && EditEmployeeSalary.Value != 0)
            {
                if (Connection.server.UpdateEmployee(EmployeeID, EditEmployeeName.Text, EditEmployeeSalary.Value, EditEmployeePhone.Text, EditEmployeeAddress.Text))
                {
                    DisplayEmployees();
                    for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvEmployees.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvEmployees.Rows[i].Selected = true;
                        dgvEmployees.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                    dgvEmployees.Refresh();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لا يمكن تحديث الموظف", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Could not update Employee.", Application.ProductName);
                    }
                }
                EditEmployeeName.Text = "";
                EditEmployeeSalary.Value = 0;
                EditEmployeePhone.Text = "";
                EditEmployeeAddress.Text = "";
                EmployeeID = 0;
                button32.Enabled = false;
                button16.Enabled = false;
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please fill all required data!", Application.ProductName);
                }
                EditEmployeeName.Text = "";
                EditEmployeeSalary.Value = 0;
                EditEmployeePhone.Text = "";
                EditEmployeeAddress.Text = "";
                EmployeeID = 0;
                button32.Enabled = false;
                button16.Enabled = false;
            }
        }

        public void txtUserIDAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button22.PerformClick();
        }

        public void nuditemPrice_ValueChanged(object sender, EventArgs e)
        {
            decimal Tax = TaxRate * nuditemPrice.Value;
            nuditemPriceTax.Value = nuditemPrice.Value + Tax;
        }

        public void pendingPurchaseRemovalQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
        }

        public void pendingPurchaseNewQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            //e.SuppressKeyPress = true;
        }

        public void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int Index = dgvVendorItemsPick.CurrentCell.RowIndex;
                DataGridViewRow row = dgvVendorItemsPick.Rows[Index];
                if (row.Selected)
                {
                    if (!row.IsNewRow)
                    {
                        int quantity = Convert.ToInt32(row.Cells["VendorItemQuantity"].Value);
                        int deletionquantity = Convert.ToInt32(quantity);
                        if (quantity > 1 && quantity - deletionquantity > 0)
                            row.Cells["VendorItemQuantity"].Value = quantity - deletionquantity;
                        else if (quantity - deletionquantity <= 0)
                            dgvVendorItemsPick.Rows.RemoveAt(Index);
                    }
                }
            } catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطيع حذف الماده", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to delete Item.", Application.ProductName);
                }
            }
        }

        public void button10_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);
                openedForm = itemLookup;
                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {

                        bool exists = false;
                        foreach (DataGridViewRow row in dgvVendorItemsPick.Rows)
                        {
                            if (row != null && !row.IsNewRow)
                            {
                                if (row.Cells[1].Value.ToString().Equals(itemLookup.selectedItem.GetItemBarCode()))
                                {
                                    row.Cells["VendorItemQuantity"].Value = Convert.ToInt32(row.Cells["VendorItemQuantity"].Value) + itemLookup.selectedItem.vendorQuantity;
                                    exists = true;
                                }
                            }
                        }
                        if (!exists && itemLookup.selectedItem != null)
                        {
                            var index = dgvVendorItemsPick.Rows.Add();
                            dgvVendorItemsPick.Rows[index].Cells["VendorItemName"].Value = itemLookup.selectedItem.GetName();
                            dgvVendorItemsPick.Rows[index].Cells["VendorItemBarCode"].Value = itemLookup.selectedItem.GetItemBarCode();
                            if (itemLookup.selectedItem.GetItemTypeeID() != 0)
                            {
                                dgvVendorItemsPick.Rows[index].Cells["VendorItemType"].Value = Connection.server.RetrieveItemTypeName(itemLookup.selectedItem.GetItemTypeeID(), (int)frmLogin.pickedLanguage);
                            }
                            else
                            {
                                dgvVendorItemsPick.Rows[index].Cells["VendorItemType"].Value = itemLookup.selectedItem.GetItemTypeeID().ToString();
                            }
                            dgvVendorItemsPick.Rows[index].Cells["VendorItemQuantity"].Value = Convert.ToInt32(itemLookup.selectedItem.vendorQuantity);
                            dgvVendorItemsPick.Rows[index].Cells["VendorItemBuyPrice"].Value = Convert.ToDecimal(itemLookup.selectedItem.GetBuyPrice());
                            dgvVendorItemsPick.Rows[index].Cells["VendorItemSellPrice"].Value = Convert.ToDecimal(itemLookup.selectedItem.GetPrice());
                            dgvVendorItemsPick.Rows[index].Cells["VendorItemSellPriceTax"].Value = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax());
                        }
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لا يمكن اختيار الماده", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Unable to pick Item.", Application.ProductName);
                        }
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void pictureBox41_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.plancksoft_b_t
                };
                printer.ImbeddedImageList.Add(logo);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    printer.Title = ".تقرير التنبيهات";
                    printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    printer.Title = "Warnings Report.";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                    printer.Footer = "Report was generated from User: " + this.UID + ".";
                }
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(dgvAlerts);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void DGVCustomerItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            customerItemID = e.RowIndex;
            BuyPrice.Value = Convert.ToDecimal(DGVCustomerItems.Rows[e.RowIndex].Cells[3].Value.ToString());
            SellPrice.Value = Convert.ToDecimal(DGVCustomerItems.Rows[e.RowIndex].Cells[4].Value.ToString());
            SellPriceTax.Value = Convert.ToDecimal(DGVCustomerItems.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        public void pictureBox39_Click(object sender, EventArgs e)
        {
            if (ItemTypeEntry.Text.Trim().Length > 0)
            {
                bool addedItemType = Connection.server.InsertItemType(ItemTypeEntry.Text);
                if (addedItemType)
                {
                    DisplayItemTypes();
                }
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء إدخال إسم عنوان صحيح", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please enter a valid Address name.", Application.ProductName);
                }
            }
        }

        public void pictureBox37_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);
                openedForm = itemLookup;
                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        List<Item> quantity_items = Connection.server.RetrieveItemsQuantity(itemLookup.selectedItem.GetItemBarCode());

                        /*foreach(Item item in quantity_items)
                        {
                            if (item.GetItemBarCode() == itemLookup.selectedItem.ItemBarCode)
                            {
                                if (item.GetQuantity() < 1)
                                {
                                    var file = $"{Path.GetTempPath()}temp.mp3";
                                    if (!File.Exists(file))
                                    {
                                        using (Stream output = new FileStream(file, FileMode.Create))
                                        {
                                            output.Write(Properties.Resources.beep, 0, Properties.Resources.beep.Length);
                                        }
                                    }
                                    var wmp = new WindowsMediaPlayer { URL = file };
                                    wmp.controls.play();
                                    if (MessageBox.Show(" .لا يمكن شراء الماده بسبب نفاذ الكميه " + " اضافة ماده؟ ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                                    {
                                        tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
                                        return;
                                    }
                                    //else return;
                                }
                            }
                        }*/

                        bool exists = false;
                        foreach (DataGridViewRow row in ItemsPendingPurchase.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                            {
                                if (row.Cells[1].Value.ToString().Equals(itemLookup.selectedItem.GetItemBarCode()))
                                {
                                    row.Cells["pendingPurchaseItemQuantity"].Value = Convert.ToInt32(row.Cells["pendingPurchaseItemQuantity"].Value) + 1;
                                    exists = true;
                                }
                            }
                        }

                        if (!exists && itemLookup.selectedItem != null)
                        {
                            var index = ItemsPendingPurchase.Rows.Add();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemName"].Value = itemLookup.selectedItem.GetName();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemBarCode"].Value = itemLookup.selectedItem.GetItemBarCode();
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemQuantity"].Value = "1";
                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPrice"].Value = itemLookup.selectedItem.GetPrice();
                            decimal priceAfterSales = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax());

                            if (customersaleItems.Count > 0)
                            {
                                for (int i = 0; i < customersaleItems.Count; i++)
                                {
                                    if (customersaleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                    {
                                        priceAfterSales = customersaleItems[i].customerPrice;
                                    }
                                }
                            }

                            if (saleItems.Count > 0)
                            {
                                for (int i = 0; i < saleItems.Count; i++)
                                {
                                    if (saleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                    {
                                        priceAfterSales = (Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax()) * saleItems[i].saleRate / 100);
                                        priceAfterSales = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax()) - priceAfterSales;
                                    }
                                }
                            }

                            ItemsPendingPurchase.Rows[index].Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                            richTextBox6.ResetText();
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                richTextBox6.AppendText(" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox6.AppendText(" Barcode: " + itemLookup.selectedItem.GetItemBarCode());
                            }
                        }
                        calculateStatistics();
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لا يمكن اضافة الماده", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Unable to add Item.", Application.ProductName);
                        }
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void pictureBox38_Click(object sender, EventArgs e)
        {
            if (WarehouseEntry.Text.Trim().Length > 0)
            {
                bool addedWarehouse = Connection.server.InsertWarehouse(WarehouseEntry.Text);
                if (addedWarehouse)
                {
                    DisplayWarehouses();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".الرجاء إدخال إسم عنوان صحيح", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Please enter a valid Address name.", Application.ProductName);
                    }
                }
            }
        }

        public void pictureBox16_Click(object sender, EventArgs e)
        {
            if (!userPermissions.openclose_edit)
                return;

            try
            {
                frmCloseRegister closeRegister = new frmCloseRegister(this.cashierName, Connection.server.GetOpenRegisterAmount());
                openedForm = closeRegister;
                closeRegister.ShowDialog(this);
                if (closeRegister.dialogResult == DialogResult.OK)
                {
                    printCloseRegister();
                    bool closedRegister = Connection.server.SaveRegisterClose(cashierName, moneyInRegister);
                    if (closedRegister)
                    {
                        Properties.Settings.Default.RegisterOpen = false;
                        Properties.Settings.Default.Save();
                        this.registerOpen = false;
                        tabControl2.Enabled = false;
                        groupBox4.Enabled = false;
                        groupBox3.Enabled = false;
                        closeRegisterBtn.Enabled = false;
                        label66.Enabled = false;
                        openRegisterBtn.Enabled = true;
                        label65.Enabled = true;
                        
                        try
                        {

                            DataTable retrievedLoginLogoutData = Connection.server.RetrieveLoginLogoutInfo(DateTime.Now);

                            dgvLoginLogout.DataSource = retrievedLoginLogoutData;
                            for (int i = 0; i < dgvLoginLogout.Rows.Count; i++)
                            {
                                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvLoginLogout.DataSource];
                                currencyManager1.SuspendBinding();
                                dgvLoginLogout.Rows[i].Selected = true;
                                dgvLoginLogout.Rows[i].Visible = true;
                                currencyManager1.ResumeBinding();
                            }
                            dgvLoginLogout.Refresh();

                            DGVPrinter printer = new DGVPrinter();
                            DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                            {
                                ImageAlignment = DGVPrinter.Alignment.Left,
                                ImageLocation = DGVPrinter.Location.Absolute,
                                ImageX = 0,
                                ImageY = 0,
                                theImage = Properties.Resources.plancksoft_b_t
                            };
                            printer.ImbeddedImageList.Add(logo);
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                printer.Title = ".تقرير اغلاق الصندوف";
                                printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                                printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                printer.Title = "Cash Register Close Report.";
                                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                                printer.Footer = "Report was generated from User: " + this.UID + ".";
                            }
                            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                            printer.PageNumbers = true;
                            printer.PageNumberInHeader = false;
                            printer.PorportionalColumns = true;
                            printer.HeaderCellAlignment = StringAlignment.Near;
                            printer.FooterSpacing = 15;
                            printer.printDocument.DefaultPageSettings.Landscape = false;
                            this.WindowState = FormWindowState.Normal;
                            this.Size = new Size(800, 600);
                            printer.PrintDataGridView(dgvLoginLogout);
                            this.WindowState = FormWindowState.Maximized;
                        }
                        catch (Exception ex)
                        {
                            this.WindowState = FormWindowState.Maximized;
                            MessageBox.Show(ex.Message.ToString(), Application.ProductName);
                        }

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MessageBox.Show(".لفد قمت باغلاق الصندوق", Application.ProductName);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("You have closed the cash register.", Application.ProductName);
                        }
                    }
                }
            } catch (Exception error)
            {

            }
        }

        public void pictureBox36_Click(object sender, EventArgs e)
        {
            if (FavoriteCategoryEntry.Text.Trim().Length > 0)
            {
                bool addedFavoriteCategory = Connection.server.InsertFavoriteCategory(FavoriteCategoryEntry.Text);
                if (addedFavoriteCategory)
                {
                    DisplayFavorites();
                }
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".الرجاء إدخال إسم عنوان صحيح", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Please enter a valid Address name.", Application.ProductName);
                }
            }
        }

        public void pictureBox15_Click(object sender, EventArgs e)
        {
            if (!userPermissions.openclose_edit)
                return;

            frmOpenRegister openRegister = new frmOpenRegister(this.cashierName);
            openedForm = openRegister;
            openRegister.ShowDialog(this);
            if (openRegister.dialogResult == DialogResult.OK)
            {
                this.registerOpen = true;
                this.moneyInRegisterInitial = this.moneyInRegister = openRegister.moneyInRegister;
                openRegister.Dispose();
                bool openedRegister = Connection.server.SaveRegisterOpen(cashierName, moneyInRegister);
                if (openedRegister)
                {
                    Properties.Settings.Default.RegisterOpen = true;
                    Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                    Properties.Settings.Default.moneyInRegisterInitial = this.moneyInRegisterInitial;
                    Properties.Settings.Default.Save();
                    tabControl2.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox3.Enabled = true;
                    closeRegisterBtn.Enabled = true;
                    label66.Enabled = true;
                    openRegisterBtn.Enabled = false;
                    label65.Enabled = false;
                    // get last bill number of today
                    this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    richTextBox4.ResetText();
                    richTextBox5.ResetText();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                        richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        MessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.AppendText(" Total: " + this.totalAmount);
                        richTextBox5.AppendText(" Current Bill ID: " + this.CurrentBillNumber);
                        MessageBox.Show(String.Format("You have opened the cash register with the amount of {0} JOD.", moneyInRegister), Application.ProductName);
                    }
                    this.Select();
                }
            }
        }

        public void pictureBox11_Click(object sender, EventArgs e)
        {
            if (userPermissions.discount_edit)
            {
                try
                {
                    frmSales frmSales = new frmSales();
                    openedForm = frmSales;
                    frmSales.ShowDialog(this);

                    if (frmSales.dialogResult == DialogResult.OK)
                    {
                        bool replaced = false;
                        foreach (Item item in frmSales.saleItems)
                        {
                            for (int i = 0; i < this.saleItems.Count; i++)
                            {
                                if (saleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                                {
                                    int index = frmSales.saleItems.IndexOf(item);
                                    this.saleItems[index] = item;
                                    replaced = true;
                                }
                            }

                            if (!replaced)
                            {
                                this.saleItems.Add(item);
                            }
                        }

                        Connection.server.AddSaleOnItems(saleItems);

                        frmSales.Dispose();
                        if (replaced)
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".تعدلت نسبة خصم الأغراض", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Items Discount percentage was altered.", Application.ProductName);
                            }
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".تم اضافة الخصم", Application.ProductName);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MessageBox.Show("Discount was added.", Application.ProductName);
                            }
                        }
                    }
                    else if (frmSales.dialogResult == DialogResult.Cancel)
                    {
                        frmSales.Dispose();
                    }
                }
                catch (Exception error)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم نتمكن من اضافة الخصم", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("Unable to add Discount.", Application.ProductName);
                    }
                }
            }
        }

        public void ApplyDiscountsToPendingItems()
        {
            calculateStatistics();
            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (saleItems.Count > 0)
                    {
                        for (int i = 0; i < saleItems.Count; i++)
                        {
                            if (saleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                            {
                                decimal priceAfterSales = 0;
                                decimal saleRate = Convert.ToDecimal(saleItems[i].saleRate) / 100;
                                decimal discount = (Convert.ToDecimal(Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax()) * saleRate);
                                decimal previousPrice = Convert.ToDecimal(Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax());
                                if (saleItems[i].saleRate != 0)
                                    priceAfterSales = (Convert.ToDecimal(Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax()) - discount);
                                else
                                    priceAfterSales = Convert.ToDecimal(Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax());
                                decimal marginPrice = previousPrice - priceAfterSales;
                                if (priceAfterSales != Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax())
                                {
                                    this.totalAmount = this.totalAmount - marginPrice;
                                }
                                item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                richTextBox4.ResetText();
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    richTextBox4.AppendText(" Total: " + this.totalAmount);
                                }
                            }
                        }
                    } else
                    {
                        decimal priceAfterSales = 0;
                        decimal discount = (Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax());
                        priceAfterSales = Convert.ToDecimal(Connection.server.SearchInventoryItemsWithBarCode(item.Cells["pendingPurchaseItemBarCode"].Value.ToString()).GetPriceTax());
                        item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                        richTextBox4.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox4.AppendText(" Total: " + this.totalAmount);
                        }
                    }
                }
            }
        }

        public void printCertainReceipt(int BillNumber, string cashierName, decimal totalAmount, decimal paidAmount, decimal remainderAmount, DateTime invoiceDate)
        {
            try
            {
                DataTable dt = Connection.server.RetrieveSystemSettings();

                string welcome2 = this.PlancksoftPOSName;
                string welcome = "";
                string InvoiceNo = "";
                string cashierNamePrint = "";
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    welcome = "شكرا لزيارتك متجرنا ";
                    InvoiceNo = "" + BillNumber.ToString() + "رقم الفاتورة الحالية ";
                    cashierNamePrint = cashierName + " :اسم الكاشير";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    welcome = "Thank you for visiting our store ";
                    InvoiceNo = "Current Bill Number: " + BillNumber.ToString();
                    cashierNamePrint = " Cashier Name:" + cashierName;
                }
                decimal gross = Convert.ToDecimal(totalAmount);
                decimal net = Convert.ToDecimal(totalAmount);
                decimal discount = gross - net;
                decimal amountPaid = paidAmount;
                decimal remainder = remainderAmount;
                string InvoiceDate = invoiceDate.ToString();

                int lineHeight = 20;
                int height = 220;

                for (int i = 0; i < dgvBillItems.Rows.Count; i++)
                {
                    if (!dgvBillItems.Rows[i].IsNewRow)
                    {
                        height += lineHeight;
                    }
                }

                Bitmap bitm = new Bitmap(354, height + 350);
                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                using (Graphics graphic = Graphics.FromImage(bitm))
                {
                    int startX = 0;
                    int startY = 0;
                    int offsetY = 0;
                    Font newfont2 = null;
                    Font itemFont = null;
                    SolidBrush black = null;
                    SolidBrush white = null;

                    try
                    {
                        //Font newfont = new Font("Arial Black", 8);
                        newfont2 = new Font("Calibri", 9, FontStyle.Bold);
                        itemFont = new Font("Calibri", 9, FontStyle.Bold);

                        black = new SolidBrush(Color.Black);
                        white = new SolidBrush(Color.White);

                        //PointF point = new PointF(40f, 2f);


                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                        graphic.DrawString(this.shopPhone.Text, newfont2, black, (bitm.Width / 2) - Convert.ToInt32(dt.Rows[0]["SystemReceiptBlankSpaces"].ToString()), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome2, newfont2, black, (bitm.Width / 2) - (welcome2.Length + 5), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome, newfont2, black, (bitm.Width / 2) - (welcome.Length + 10), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        if (IncludeLogoInReceipt)
                        {
                            try
                            {
                                if (!Convert.IsDBNull(dt.Rows[0]["SystemLogo"]))
                                {
                                    StoreLogo = (Byte[])(dt.Rows[0]["SystemLogo"]);
                                    var stream = new MemoryStream(StoreLogo);
                                    graphic.DrawImage(ResizeImage(new Bitmap(stream), 150, 150), (bitm.Width / 2) - 75, 0);
                                }
                                else
                                {
                                    graphic.DrawImage(ResizeImage(Resources.plancksoft_b_t, 150, 150), (bitm.Width / 2) - 75, 0);
                                }
                            }
                            catch (Exception err)
                            {
                                graphic.DrawImage(ResizeImage(Resources.plancksoft_b_t, 150, 150), (bitm.Width / 2) - 75, 0);
                            }

                            offsetY = offsetY + lineHeight;
                        }
                        graphic.DrawString(InvoiceNo, newfont2, black, (bitm.Width / 2) - InvoiceNo.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;

                        //PointF pointPrice = new PointF(15f, 45f);
                        graphic.DrawString("" + InvoiceDate + "", newfont2, black, (bitm.Width / 2) - (InvoiceDate.Length + 7), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(cashierNamePrint, newfont2, black, (bitm.Width / 2) - cashierNamePrint.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("  إسم المنتج      " + "               الكمية      " + "          السعر ", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("  Price      " + "               Quantity      " + "          Item Name ", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        //PointF pointPname = new PointF(10f, 65f);
                        //PointF pointBar = new PointF(10f, 65f);

                        offsetY = offsetY + lineHeight;


                        List<Item> itemsInBill = new List<Item>();

                        for (int i = 0; i < dgvBillItems.Rows.Count; i++)
                        {
                            if (!dgvBillItems.Rows[i].IsNewRow)
                            {
                                int ii = 1;
                                ii++;
                                Item SearchedItem = Connection.server.SearchItems(dgvBillItems.Rows[i].Cells[0].Value.ToString(), "", 0).Item1[0];
                                itemsInBill.Add(SearchedItem);
                                string itemString = " " + dgvBillItems.Rows[i].Cells[0].Value + "               " + dgvBillItems.Rows[i].Cells[2].Value + "                    " + dgvBillItems.Rows[i].Cells[5].Value + "";
                                if (IsRtl(itemString))
                                {
                                    graphic.DrawString(itemString, itemFont,
                                                black, startX + 15, startY + offsetY);
                                }
                                else
                                {
                                    itemString = " " + dgvBillItems.Rows[i].Cells[5].Value + "                    " + dgvBillItems.Rows[i].Cells[2].Value + "               " + dgvBillItems.Rows[i].Cells[0].Value + "";
                                    graphic.DrawString(itemString, itemFont,
                                                black, startX + 15, startY + offsetY);
                                }
                                offsetY = offsetY + lineHeight;
                            }
                        }
                        graphic.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("الإجمالي :" + gross + "" + "                           " + "الخصم :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Gross :" + gross + "" + "                           " + "Discount :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("الصافي :" + net + "" + "                         " + "المدفوع :" + amountPaid + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Net :" + net + "" + "                         " + "Paid :" + amountPaid + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("الباقي :" + remainder + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Remainder :" + remainder + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        frmReceipt receipt = new frmReceipt(bitm, itemsInBill, true);
                        openedForm = receipt;
                        receipt.ShowDialog();
                    }
                    finally
                    {
                        black.Dispose();
                        white.Dispose();
                        itemFont.Dispose();
                        newfont2.Dispose();
                    }
                }

                using (MemoryStream Mmst = new MemoryStream())
                {
                    try
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts");
                        }
                        catch (Exception error) { }
                        bitm.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\Receipt " + this.CurrentBillNumber.ToString() + ".jpeg", ImageFormat.Jpeg);
                    }
                    catch (Exception error)
                    {
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من طباعة الفاتوره", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to print Invoice.", Application.ProductName);
                }
            }
        }

        public void printReceipt()
        {
            try
            {
                DataTable dt = Connection.server.RetrieveSystemSettings();

                string welcome2 = this.PlancksoftPOSName;
                string welcome = "";
                string InvoiceNo = "";
                string cashierNamePrint = "";
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    welcome = "شكرا لزيارتك متجرنا ";
                    InvoiceNo = "" + CurrentBillNumber.ToString() + "رقم الفاتورة الحالية ";
                    cashierNamePrint = cashierName + " :اسم الكاشير";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    welcome = "Thank you for visiting our store ";
                    InvoiceNo = "Current Bill Number: " + CurrentBillNumber.ToString();
                    cashierNamePrint = " Cashier Name:" + cashierName;
                }
                decimal gross = Convert.ToDecimal(this.totalAmount);
                decimal net = Convert.ToDecimal(this.totalAmount);
                decimal discount = gross - net;
                decimal amountPaid = this.paidAmount;
                decimal remainder = this.remainderAmount;
                string InvoiceDate = DateTime.Now.ToString();

                int lineHeight = 20;
                int height = 220;

                for (int i = 0; i < ItemsPendingPurchase.Rows.Count; i++)
                {
                    if (!ItemsPendingPurchase.Rows[i].IsNewRow)
                    {
                        height += lineHeight;
                    }
                }

                Bitmap bitm = new Bitmap(354, height + 350);
                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                using (Graphics graphic = Graphics.FromImage(bitm))
                {
                    int startX = 0;
                    int startY = 0;
                    int offsetY = 0;
                    Font newfont2 = null;
                    Font itemFont = null;
                    SolidBrush black = null;
                    SolidBrush white = null;

                    try
                    {
                        //Font newfont = new Font("Arial Black", 8);
                        newfont2 = new Font("Calibri", 9, FontStyle.Bold);
                        itemFont = new Font("Calibri", 9, FontStyle.Bold);

                        black = new SolidBrush(Color.Black);
                        white = new SolidBrush(Color.White);

                        //PointF point = new PointF(40f, 2f);


                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                        graphic.DrawString(this.shopPhone.Text, newfont2, black, (bitm.Width / 2) - Convert.ToInt32(dt.Rows[0]["SystemReceiptBlankSpaces"].ToString()), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome2, newfont2, black, (bitm.Width / 2) - (welcome2.Length + 5), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome, newfont2, black, (bitm.Width / 2) - (welcome.Length + 10), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        if (IncludeLogoInReceipt)
                        {
                            try
                            {
                                if (!Convert.IsDBNull(dt.Rows[0]["SystemLogo"]))
                                {
                                    StoreLogo = (Byte[])(dt.Rows[0]["SystemLogo"]);
                                    var stream = new MemoryStream(StoreLogo);
                                    graphic.DrawImage(ResizeImage(new Bitmap(stream), 150, 150), (bitm.Width / 2) - 75, 0);
                                }
                                else
                                {
                                    graphic.DrawImage(ResizeImage(Resources.plancksoft_b_t, 150, 150), (bitm.Width / 2) - 75, 0);
                                }
                            }
                            catch (Exception err)
                            {
                                graphic.DrawImage(ResizeImage(Resources.plancksoft_b_t, 150, 150), (bitm.Width / 2) - 75, 0);
                            }

                            offsetY = offsetY + lineHeight;
                        }
                        graphic.DrawString(InvoiceNo, newfont2, black, (bitm.Width / 2) - InvoiceNo.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;

                        //PointF pointPrice = new PointF(15f, 45f);
                        graphic.DrawString("" + InvoiceDate + "", newfont2, black, (bitm.Width / 2) - (InvoiceDate.Length + 7), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(cashierNamePrint, newfont2, black, (bitm.Width / 2) - cashierNamePrint.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;
                        offsetY = offsetY + lineHeight;

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("  إسم المنتج      " + "               الكمية      " + "          السعر ", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("  Price      " + "               Quantity      " + "          Item Name ", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        //PointF pointPname = new PointF(10f, 65f);
                        //PointF pointBar = new PointF(10f, 65f);

                        offsetY = offsetY + lineHeight;

                        List<Item> itemsInBill = new List<Item>();
                        for (int i = 0; i < ItemsPendingPurchase.Rows.Count; i++)
                        {
                            if (!ItemsPendingPurchase.Rows[i].IsNewRow)
                            {
                                int ii = 1;
                                ii++;
                                Item SearchedItem = Connection.server.SearchItems(ItemsPendingPurchase.Rows[i].Cells[0].Value.ToString(), "", 0).Item1[0];
                                itemsInBill.Add(SearchedItem);
                                string itemString = " " + ItemsPendingPurchase.Rows[i].Cells[0].Value + "               " + ItemsPendingPurchase.Rows[i].Cells[2].Value + "                    " + ItemsPendingPurchase.Rows[i].Cells[4].Value + "";
                                if (IsRtl(itemString))
                                {
                                    graphic.DrawString(itemString, itemFont,
                                                black, startX + 15, startY + offsetY);
                                }
                                else
                                {
                                    itemString = " " + ItemsPendingPurchase.Rows[i].Cells[4].Value + "                    " + ItemsPendingPurchase.Rows[i].Cells[2].Value + "               " + ItemsPendingPurchase.Rows[i].Cells[0].Value + "";
                                    graphic.DrawString(itemString, itemFont,
                                                black, startX + 15, startY + offsetY);
                                }
                                offsetY = offsetY + lineHeight;
                            }
                        }
                        graphic.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("الإجمالي :" + gross + "" + "                           " + "الخصم :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Gross :" + gross + "" + "                           " + "Discount :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("الصافي :" + net + "" + "                         " + "المدفوع :" + amountPaid + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Net :" + net + "" + "                         " + "Paid :" + amountPaid + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString("الباقي :" + remainder + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Remainder :" + remainder + "", newfont2, black, startX + 15, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        frmReceipt receipt = new frmReceipt(bitm, itemsInBill, true);
                        openedForm = receipt;
                        receipt.ShowDialog();
                    }
                    finally
                    {
                        black.Dispose();
                        white.Dispose();
                        itemFont.Dispose();
                        newfont2.Dispose();
                    }
                }

                using (MemoryStream Mmst = new MemoryStream())
                {
                    try
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts");
                        } catch(Exception error) { }
                        bitm.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts\\Receipt " + this.CurrentBillNumber.ToString() + ".jpeg", ImageFormat.Jpeg);
                    }
                    catch (Exception error)
                    {
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من طباعة الفاتوره", Application.ProductName);
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to print Invoice.", Application.ProductName);
                }
            }
        }

        public void printCloseRegister()
        {
            try
            {
                DataTable dt = Connection.server.RetrieveSystemSettings();

                int lineHeight = 20;
                int height = 20;


                for (int i = 0; i < 7; i++)
                {
                    height += lineHeight;
                }

                Bitmap bitm = new Bitmap(354, height + 350);

                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                using (Graphics graphic = Graphics.FromImage(bitm))
                {
                    int startX = 0;
                    int startY = 0;
                    int offsetY = 0;
                    Font newfont2 = null;
                    Font itemFont = null;
                    SolidBrush black = null;
                    SolidBrush white = null;

                    try
                    {
                        //Font newfont = new Font("Arial Black", 8);
                        newfont2 = new Font("Calibri", 11, FontStyle.Bold);
                        itemFont = new Font("Calibri", 11, FontStyle.Bold);

                        black = new SolidBrush(Color.Black);
                        white = new SolidBrush(Color.White);
                        graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);

                        //PointF point = new PointF(40f, 2f);

                        if (IncludeLogoInReceipt)
                        {
                            try
                            {
                                if (!Convert.IsDBNull(dt.Rows[0]["SystemLogo"]))
                                {
                                    StoreLogo = (Byte[])(dt.Rows[0]["SystemLogo"]);
                                    var stream = new MemoryStream(StoreLogo);
                                    graphic.DrawImage(ResizeImage(new Bitmap(stream), 150, 150), (bitm.Width / 2) - 150, 0);
                                }
                                else
                                {
                                    graphic.DrawImage(ResizeImage(Resources.plancksoft_b_t, 150, 150), (bitm.Width / 2) - 150, 0);
                                }
                            }
                            catch (Exception err)
                            {
                                graphic.DrawImage(ResizeImage(Resources.plancksoft_b_t, 150, 150), (bitm.Width / 2) - 150, 0);
                            }

                            offsetY = offsetY + lineHeight;
                            offsetY = offsetY + lineHeight;
                            offsetY = offsetY + lineHeight;
                            offsetY = offsetY + lineHeight;
                            offsetY = offsetY + lineHeight;
                        }
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(".تقرير اغلاق الصندوق", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Cash Close Report.", newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(this.cashierName + " اسم الكاشير: ", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString(" Cashier Name: " + this.cashierName, newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(Connection.server.GetLastOpenRegisterDate() + " تاريخ فتح الصندوق ", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Register Open Date: " + Connection.server.GetLastOpenRegisterDate(), newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(DateTime.Now.ToShortDateString() + " تاريخ اغلاق الصندوق ", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Register Close Date: " + DateTime.Now.ToShortDateString(), newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        decimal openRegisterAmount = Connection.server.GetOpenRegisterAmount();
                        decimal totalSalesAmount = Connection.server.GetTotalSalesAmount();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(openRegisterAmount.ToString() + " أرضية الكاش ", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Cash Opening Value: " + openRegisterAmount.ToString(), newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(totalSalesAmount.ToString() + " مبلغ المبيعات ", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Total Sales Amount: " + totalSalesAmount.ToString(), newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            graphic.DrawString(Convert.ToDecimal(openRegisterAmount + totalSalesAmount).ToString() + " المجموع الكلي ", newfont2, black, 0, startY + offsetY);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            graphic.DrawString("Total Cash in Register: " + Convert.ToDecimal(openRegisterAmount + totalSalesAmount).ToString(), newfont2, black, 0, startY + offsetY);
                        }
                        offsetY = offsetY + lineHeight;
                        frmReceipt receipt = new frmReceipt(bitm, new List<Item>(), false);
                        openedForm = receipt;
                        receipt.ShowDialog();
                    }
                    finally
                    {
                        black.Dispose();
                        white.Dispose();
                        itemFont.Dispose();
                        newfont2.Dispose();
                    }
                }

                using (MemoryStream Mmst = new MemoryStream())
                {
                    bitm.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Cash Close Report.jpeg", ImageFormat.Jpeg);
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نتمكن من طباعة تقرير غلق الكاش", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to print Cash Close Report.", Application.ProductName);
                }
            }
        }

        public bool IsRtl(string input)
        {
            return Regex.IsMatch(input, @"\p{IsArabic}");
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaintenance frmMaintenance = new frmMaintenance();
            openedForm = frmMaintenance;
            frmMaintenance.ShowDialog();
        }

        public Tuple<List<Item>, DataTable> DisplayEditedBills(int Category)
        {
            Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveFavoriteItems(Category);
            return RetrievedItems;
        }

        public Tuple<List<Item>, DataTable> DisplayFavoriteData(int Category)
        {
            Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveFavoriteItems(Category);
            return RetrievedItems;
        }
    }
}
