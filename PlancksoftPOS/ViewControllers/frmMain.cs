using Dependencies;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.TeamFoundation.Common;
using PlancksoftPOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WMPLib;

namespace PlancksoftPOS
{
    public partial class frmMain : MaterialForm
    {
        public bool menuSalesSubExpand = false, menuInventorySubExpand = false, menuTaxesSubExpand = false
            , menuExpensesSubExpand = false, menuSettingsSubExpand = false, menuEmployeesAffairsSubExpand = false
            , menuClientAffairsSubExpand = false;
        public Form openedForm = null;
        public Connection Connection = new Connection();
        public int ID = 0, CurrentBillNumber = 0, CurrentVendorBillNumber = 0, ClientItemID = 0, heldBillsCount = 0, EmployeeID = 0, AbsenceID = 0;
        public static int Authority = 0;
        public string CurrentItemBarcode = "", BarCode = "", cashierName = "Developer Mode", UID, PWD, PlancksoftPOSName, PlancksoftPOSPhone, PlancksoftPOSAddress;
        public Tuple<List<Item>, DataTable> FavoriteItems;
        public Stack<Bill> previousSharedUnpaidBillsList = new Stack<Bill>();
        public Stack<Bill> nextSharedUnpaidBillsList = new Stack<Bill>();
        public Stack<Bill> previousBillsList = new Stack<Bill>();
        public Stack<Bill> nextBillsList = new Stack<Bill>();
        public decimal totalAmount = 0, totalVendorAmount = 0, paidAmount = 0, remainderAmount = 0, moneyInRegister = 0, moneyInRegisterInitial = 0;
        public List<Item> saleItems = new List<Item>();
        public List<Item> ClientsaleItems = new List<Item>();
        public List<Item> DISCOUNT_ITEMS = new List<Item>();
        public List<Item> ItemsList, retrievedFavoriteItems;
        public List<Account> Users;
        public static List<Printer> PrintersList = new List<Printer>();
        public List<Category> Categories = new List<Category>();
        public List<ItemType> ItemTypesList = new List<ItemType>();
        public List<Warehouse> WarehousesList = new List<Warehouse>();
        public Client currentClient;
        public decimal CapitalAmount, TaxRate;
        public int PrintBillNumber = 0;
        public SortedList<int, string> itemtypes = new SortedList<int, string>();
        public SortedList<int, string> warehouses = new SortedList<int, string>();
        public SortedList<int, string> favorites = new SortedList<int, string>();
        public SortedList<int, Tuple<string, Tuple<int, string>>> printers = new SortedList<int, Tuple<string, Tuple<int, string>>>();
        public string ScannedBarCode = "";
        public bool timerstarted = false, registerOpen = false, IncludeLogoInReceipt = false;
        decimal capital, taxRate;
        TextBox AddItemType;
        List<Label> ItemTypeNamestxt = new List<Label>();
        PictureBox plusItemTypePB, minusItemTypePB;
        System.Windows.Forms.Label plusItemTypeLbl, ItemTypeLbl;
        TextBox AddWarehouse;
        List<Label> WarehouseNamestxt = new List<Label>();
        PictureBox plusWarehousePB, minusWarehousePB;
        Label plusWarehouseLbl, WarehouseLbl;
        TextBox AddFavorite;
        TextBox AddPrinter;
        List<Label> FavoriteNamestxt = new List<Label>();
        List<TreeView> PrintersNamesTV = new List<TreeView>();
        PictureBox plusFavoritePB, minusFavoritePB;
        PictureBox plusPrinterPB, minusPrinterPB;
        Label plusFavoriteLbl, FavoriteLbl;
        Label plusPrinterLbl, PrinterLbl;
        List<FlowLayoutPanel> flowLayoutPanels = new List<FlowLayoutPanel>();
        MaterialButton saveItemTypesBtn;
        MaterialButton saveWarehousesBtn;
        MaterialButton saveFavoritesBtn;
        MaterialButton savePrintersBtn, editPrintersBtn;
        byte[] StoreLogo = null;
        List<ContextMenu> PrintersMenus = null;

        TabPage AgentsTab = null, InventoryTab = null, ExpensesTab = null, posUsersTab = null, SettingsTab = null, EmployeesTab = null, EditInvoicesTab = null,
            TravelingUntravelingSalesTab = null, SoldItemsTab = null, IncomingOutgoingTab = null, SalesTab = null, TaxesTab = null;

        public Account userPermissions;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public int CurrentClientID = -1, CurrentVendorID = -1;

        static int width = 384;  // or 284
        static int padding = 10;
        static int cellPadding = 6;
        static int lineHeight = 30;
        static Font fontRegular = new Font("Arial", 10);
        static Font fontBold = new Font("Arial", 12, FontStyle.Bold);

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
            Program.materialSkinManager.EnforceBackcolorOnAllComponents = false; ;

            if (Properties.Settings.Default.pickedThemeScheme == (int)ThemeSchemeChoice.ThemeScheme.Dark)
            {
                switchThemeScheme.Checked = Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark));
                Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                if (Properties.Settings.Default.darkTextShade.ToUpper() == "BLACK")
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.BLACK);
                else
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.WHITE);
                مظلمToolStripMenuItem.Checked = true;
                فاتحToolStripMenuItem.Checked = false;
            }
            else
            {
                switchThemeScheme.Checked = Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Light));
                Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                if (Properties.Settings.Default.TextShade.ToUpper() == "BLACK")
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.BLACK);
                else
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.WHITE);
                مظلمToolStripMenuItem.Checked = false;
                فاتحToolStripMenuItem.Checked = true;
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
            nudTaxRate.Value = Convert.ToDecimal(taxRate);
            TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);

            this.PlancksoftPOSName = dt.Rows[0]["SystemName"].ToString();
            this.txtStoreName.Text = dt.Rows[0]["SystemName"].ToString();
            this.PlancksoftPOSPhone = dt.Rows[0]["SystemPhone"].ToString();
            this.txtStorePhone.Text = dt.Rows[0]["SystemPhone"].ToString();
            this.PlancksoftPOSAddress = dt.Rows[0]["SystemAddress"].ToString();
            this.txtStoreAddress.Text = dt.Rows[0]["SystemAddress"].ToString();
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

            Client_card_edit.Checked = this.userPermissions.Client_card_edit;
            discount_edit.Checked = this.userPermissions.discount_edit;
            price_edit.Checked = this.userPermissions.price_edit;
            receipt_edit.Checked = this.userPermissions.receipt_edit;
            inventory_edit.Checked = this.userPermissions.inventory_edit;
            expenses_edit.Checked = this.userPermissions.expenses_add;
            users_edit.Checked = this.userPermissions.users_edit;
            settings_edit.Checked = this.userPermissions.settings_edit;
            personnel_edit.Checked = this.userPermissions.personnel_edit;
            openclose_edit.Checked = this.userPermissions.openclose_edit;
            sell_edit.Checked = this.userPermissions.sell_edit;

            if (!this.userPermissions.Client_card_edit)
            {
                btnClientCard.Enabled = false;
            }

            if (!this.userPermissions.discount_edit)
            {
                btnDiscounts.Enabled = false;
            }

            if (!this.userPermissions.price_edit)
            {
                btnEditTotalPrice.Enabled = false;
            }

            if (tabControl1.Contains(tabControl1.TabPages["Agents"]))
            {
                AgentsTab = tabControl1.TabPages["Agents"];
            }
            if (!this.userPermissions.Client_card_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Agents"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Agents"]);
                    btnMenuClientsVendors.Enabled = false;
                }
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Agents"]))
                {
                    tabControl1.TabPages.Add(AgentsTab);
                    btnMenuClientsVendors.Enabled = true;
                }
            }

            if (tabControl1.Contains(tabControl1.TabPages["Inventory"]))
            {
                InventoryTab = tabControl1.TabPages["Inventory"];
            }
            if (!this.userPermissions.inventory_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Inventory"]);
                    btnMenuInventory.Enabled = false;
                }
                ادارةالمستودعToolStripMenuItem.Visible = false;
                ادارةالمستودعToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Inventory"]))
                {
                    tabControl1.TabPages.Add(InventoryTab);
                    btnMenuInventory.Enabled = true;
                }
                ادارةالمستودعToolStripMenuItem.Visible = true;
                ادارةالمستودعToolStripMenuItem.Enabled = true;
            }

            if (tabControl1.Contains(tabControl1.TabPages["Expenses"]))
            {
                ExpensesTab = tabControl1.TabPages["Expenses"];
            }
            if (!this.userPermissions.expenses_add)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Expenses"]);
                    btnMenuExpenses.Enabled = false;
                }
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Expenses"]))
                {
                    tabControl1.TabPages.Add(ExpensesTab);
                    btnMenuExpenses.Enabled = false;
                }
            }

            if (tabControl1.Contains(tabControl1.TabPages["posUsers"]))
            {
                posUsersTab = tabControl1.TabPages["posUsers"];
            }
            if (!this.userPermissions.users_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["posUsers"]);
                    btnMenuUsers.Enabled = false;
                }
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["posUsers"]))
                {
                    tabControl1.TabPages.Add(posUsersTab);
                    btnMenuExpenses.Enabled = true;
                }
            }

            if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
            {
                SettingsTab = tabControl1.TabPages["Settings"];
            }
            if (!this.userPermissions.settings_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Settings"]);
                    btnMenuSettings.Enabled = false;
                }
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Settings"]))
                {
                    tabControl1.TabPages.Add(SettingsTab);
                    btnMenuSettings.Enabled = true;
                }
            }

            if (tabControl1.Contains(tabControl1.TabPages["Employees"]))
            {
                EmployeesTab = tabControl1.TabPages["Employees"];
            }
            if (!this.userPermissions.personnel_edit)
            {
                if (tabControl1.Contains(tabControl1.TabPages["Employees"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Employees"]);
                    btnMenuEmployeesAffairs.Enabled = false;
                }
            }
            else
            {
                if (!tabControl1.Contains(tabControl1.TabPages["Employees"]))
                {
                    tabControl1.TabPages.Add(EmployeesTab);
                    btnMenuEmployeesAffairs.Enabled = true;
                }
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
                {
                    tabControl4.TabPages.Remove(tabControl4.TabPages["EditInvoices"]);
                    btnMenuSalesSubEditInvoices.Enabled = false;
                }
                if (tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                {
                    tabControl4.TabPages.Remove(tabControl4.TabPages["TravelingUntravelingSales"]);
                    btnMenuSalesSubTravelingUntravelingSales.Enabled = false;
                }
                if (tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                {
                    tabControl4.TabPages.Remove(tabControl4.TabPages["SoldItems"]);
                    btnMenuSalesSubSoldItems.Enabled = false;
                }
                if (tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["IncomingOutgoing"]);
                    btnMenuIncomingOutgoing.Enabled = false;
                }
                if (tabControl1.Contains(tabControl1.TabPages["Sales"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Sales"]);
                    btnMenuSales.Enabled = false;
                }
                if (tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Taxes"]);
                    btnMenuTaxes.Enabled = false;
                }
            }
            else
            {
                if (!tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                {
                    tabControl4.TabPages.Add(EditInvoicesTab);
                    btnMenuSalesSubEditInvoices.Enabled = true;
                }
                if (!tabControl4.Contains(tabControl4.TabPages["TravelingUntravelingSales"]))
                {
                    tabControl4.TabPages.Add(TravelingUntravelingSalesTab);
                    btnMenuSalesSubTravelingUntravelingSales.Enabled = true;
                }
                if (!tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                {
                    tabControl4.TabPages.Add(SoldItemsTab);
                    btnMenuSalesSubSoldItems.Enabled = true;
                }
                if (!tabControl1.Contains(tabControl1.TabPages["IncomingOutgoing"]))
                {
                    tabControl1.TabPages.Add(IncomingOutgoingTab);
                    btnMenuIncomingOutgoing.Enabled = true;
                }
                if (!tabControl1.Contains(tabControl1.TabPages["Sales"]))
                {
                    tabControl1.TabPages.Add(SalesTab);
                    btnMenuSales.Enabled = true;
                }
                if (!tabControl1.Contains(tabControl1.TabPages["Taxes"]))
                {
                    tabControl1.TabPages.Add(TaxesTab);
                    btnMenuTaxes.Enabled = true;
                }
            }

            if (!this.userPermissions.sell_edit)
            {
                //label67.Enabled = false;
                //label93.Enabled = false;
                //label69.Enabled = false;
                //label68.Enabled = false;
                //label89.Enabled = false;
                //label2.Enabled = false;
                //label24.Enabled = false;
                //label70.Enabled = false;
                btnPay.Enabled = false;
                btnClientCard.Enabled = false;
                btnNewInvoice.Enabled = false;
                btnDiscounts.Enabled = false;
                btnOpenCashDrawer.Enabled = false;
                btnEditTotalPrice.Enabled = false;
                btnItemLookup.Enabled = false;
                btnNextBill.Enabled = false;
                btnPreviousBill.Enabled = false;
                tabControl2.Enabled = false;
                ItemsPendingPurchase.Enabled = false;
                button17.Enabled = false;
                button24.Enabled = false;
                pendingPurchaseRemovalQuantity.Enabled = false;
                pendingPurchaseNewQuantity.Enabled = false;
            } else
            {
                //label67.Enabled = true;
                //label93.Enabled = true;
                //label69.Enabled = true;
                //label68.Enabled = true;
                //label89.Enabled = true;
                //label2.Enabled = true;
                //label24.Enabled = true;
                //label70.Enabled = true;
                btnPay.Enabled = true;
                btnClientCard.Enabled = true;
                btnNewInvoice.Enabled = true;
                btnDiscounts.Enabled = true;
                btnOpenCashDrawer.Enabled = true;
                btnEditTotalPrice.Enabled = true;
                btnItemLookup.Enabled = true;
                btnNextBill.Enabled = true;
                btnPreviousBill.Enabled = true;
                tabControl2.Enabled = true;
                ItemsPendingPurchase.Enabled = true;
                button17.Enabled = true;
                button24.Enabled = true;
                pendingPurchaseRemovalQuantity.Enabled = true;
                pendingPurchaseNewQuantity.Enabled = true;
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
                openRegisterBtn.Enabled = true;
                closeRegisterBtn.Enabled = true;
                label65.Enabled = true;
                label66.Enabled = true;

                if (registerOpen)
                {
                    openRegisterBtn.Enabled = false;
                    closeRegisterBtn.Enabled = true;
                }
                else
                {
                    openRegisterBtn.Enabled = true;
                    closeRegisterBtn.Enabled = false;
                }
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

                // Dark Theme Color Scheme

                DarkPrimaryColor.Text = Properties.Settings.Default.darkPrimary;
                DarkPrimaryDarkColor.Text = Properties.Settings.Default.darkPrimaryDark;
                DarkPrimaryLightColor.Text = Properties.Settings.Default.darkLightPrimary;
                DarkAccentColor.Text = Properties.Settings.Default.darkAccent;

                if (Properties.Settings.Default.darkTextShade.ToUpper() == "BLACK")
                {
                    switchDarkBlackTextShade.Checked = true;
                } else
                {
                    switchDarkBlackTextShade.Checked = false;
                }

                // Light Theme Color Scheme

                PrimaryColor.Text = Properties.Settings.Default.Primary;
                PrimaryDarkColor.Text = Properties.Settings.Default.PrimaryDark;
                PrimaryLightColor.Text = Properties.Settings.Default.LightPrimary;
                AccentColor.Text = Properties.Settings.Default.Accent;

                if (Properties.Settings.Default.TextShade.ToUpper() == "BLACK")
                {
                    switchBlackTextShade.Checked = true;
                } else
                {
                    switchBlackTextShade.Checked = false;
                }

                Program.materialSkinManager = MaterialSkinManager.Instance;
                Program.materialSkinManager.EnforceBackcolorOnAllComponents = false;

                if (Properties.Settings.Default.pickedThemeScheme == (int)ThemeSchemeChoice.ThemeScheme.Dark)
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    if (Properties.Settings.Default.darkTextShade.ToUpper() == "BLACK")
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.BLACK);
                    else
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.WHITE);
                    switchThemeScheme.Checked = true;
                    مظلمToolStripMenuItem.Checked = true;
                    فاتحToolStripMenuItem.Checked = false;
                } else
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    if (Properties.Settings.Default.TextShade.ToUpper() == "BLACK")
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.BLACK);
                    else
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.WHITE);
                    switchThemeScheme.Checked = false;
                    مظلمToolStripMenuItem.Checked = false;
                    فاتحToolStripMenuItem.Checked = true;
                }

                LoadMenu();
                LoadActionMenu();

                pnlMenuSalesSub.Size = new Size(220, 10);

                tabControl1.Appearance = TabAppearance.FlatButtons;
                tabControl1.ItemSize = new Size(0, 1);
                tabControl1.SizeMode = TabSizeMode.Fixed;

                tabControl3.Appearance = TabAppearance.FlatButtons;
                tabControl3.ItemSize = new Size(0, 1);
                tabControl3.SizeMode = TabSizeMode.Fixed;

                tabControl4.Appearance = TabAppearance.FlatButtons;
                tabControl4.ItemSize = new Size(0, 1);
                tabControl4.SizeMode = TabSizeMode.Fixed;

                tabControl5.Appearance = TabAppearance.FlatButtons;
                tabControl5.ItemSize = new Size(0, 1);
                tabControl5.SizeMode = TabSizeMode.Fixed;

                tabControl6.Appearance = TabAppearance.FlatButtons;
                tabControl6.ItemSize = new Size(0, 1);
                tabControl6.SizeMode = TabSizeMode.Fixed;

                tabControl7.Appearance = TabAppearance.FlatButtons;
                tabControl7.ItemSize = new Size(0, 1);
                tabControl7.SizeMode = TabSizeMode.Fixed;

                tabControl8.Appearance = TabAppearance.FlatButtons;
                tabControl8.ItemSize = new Size(0, 1);
                tabControl8.SizeMode = TabSizeMode.Fixed;

                tabControl9.Appearance = TabAppearance.FlatButtons;
                tabControl9.ItemSize = new Size(0, 1);
                tabControl9.SizeMode = TabSizeMode.Fixed;

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
                } catch (Exception err)
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
                nudTaxRate.Value = Convert.ToDecimal(taxRate);
                capital = Connection.server.GetCapitalAmount();
                CapitalAmountnud.Value = capital;
                CapitalAmount = capital;
                TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);

                this.saleItems = Connection.server.RetrieveSaleToday(DateTime.Now, 10);

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.Text = ("Current Bill ID: " + this.CurrentBillNumber);
                }

                DataTable retrievedClients = Connection.server.GetRetrieveClients();

                dgvClients.DataSource = retrievedClients;

                this.PlancksoftPOSName = dt.Rows[0]["SystemName"].ToString();
                this.txtStoreName.Text = dt.Rows[0]["SystemName"].ToString();
                this.PlancksoftPOSPhone = dt.Rows[0]["SystemPhone"].ToString();
                this.txtStorePhone.Text = dt.Rows[0]["SystemPhone"].ToString();
                this.PlancksoftPOSAddress = dt.Rows[0]["SystemAddress"].ToString();
                this.txtStoreAddress.Text = dt.Rows[0]["SystemAddress"].ToString();
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
                    pnlActionMenu.Enabled = true;
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
                        richTextBox4.Text = " :المجموع الكامل " + this.totalAmount;
                        richTextBox5.Text = " :رقم الفاتورة الحالية " + this.CurrentBillNumber;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.Text = "Total Amount: " + this.totalAmount;
                        richTextBox5.Text = "Current Bill ID: " + this.CurrentBillNumber;
                    }
                }
                else
                {
                    this.registerOpen = false;
                    tabControl2.Enabled = false;
                    pnlActionMenu.Enabled = false;
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

                if (dt.Rows[0]["SystemName"].ToString() == "" || dt.Rows[0]["SystemPhone"].ToString() == "")
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        DialogResult settingsDialog = FlexibleMaterialForm.Show(this, ".بعض الاعدادات بدون قيم, الرجاء وضع قيمه لها في الاعدادات ", " اضافة ماده؟ ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                        if (settingsDialog == DialogResult.Yes)
                        {
                            if (!Properties.Settings.Default.sideMenuExpanded)
                                CollapseSideMenu();
                            hamburger_menu_settings_sub_timer.Start();
                            tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
                            return;
                        }
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        DialogResult settingsDialog = FlexibleMaterialForm.Show(this, "Some system preferences are not set. Please set the proper values in the settings area.", " Add Item? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                        if (settingsDialog == DialogResult.Yes)
                        {
                            if (!Properties.Settings.Default.sideMenuExpanded)
                                CollapseSideMenu();
                            hamburger_menu_settings_sub_timer.Start();
                            tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
                            return;
                        }
                    }

                }
            }
            catch (Exception e)
            { MaterialMessageBox.Show(e.ToString()); }
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "PlancksoftPOS - الشاشه الرئيسيه";
                if (tabControl1.Contains(tabControl1.TabPages["Cash"]))
                {
                    tabControl1.TabPages["Cash"].Text = "الكاش";
                    //label93.Text = "بطاقة عميل F2";
                    //label67.Text = "الدفع F1";
                    //label68.Text = "الخصومات F4";
                    //label69.Text = "فاتوره جديده F3";
                    //label2.Text = "فتح الكاش F6";
                    //label89.Text = "تعديل السعر F5";
                    //label24.Text = "البحث عن المواد F9";
                    //label70.Text = "F8 الفواتير السابقه F7";

                    btnPay.Text = "الدفع";
                    btnClientCard.Text = "بطاقة العميل";
                    btnNewInvoice.Text = "فاتوره جديده";
                    btnDiscounts.Text = "الخصومات";
                    btnOpenCashDrawer.Text = "فتح درج الكاش";
                    btnEditTotalPrice.Text = "تعديل سعر الفاتوره";
                    btnItemLookup.Text = "البحث عن ماده";
                    btnPreviousBill.Text = "فاتوره سابقه";
                    btnNextBill.Text = "فاتوره تاليه";

                    btnMenuCash.Text = "الكاش";

                    btnMenuSales.Text = "المبيعات";
                    btnMenuSalesSubSales.Text = "المبيعات";
                    btnMenuSalesSubEditInvoices.Text = "التعديل على الفواتير";
                    btnMenuSalesSubTravelingUntravelingSales.Text = "المبيعات المرحله و الغير مرحله";
                    btnMenuSalesSubSoldItems.Text = "جرد الكميات المباعه";

                    btnMenuInventory.Text = "المستودع";
                    btnMenuInventorySubInventory.Text = "المستودع";
                    btnMenuInventorySubItemsQuantify.Text = "جرد المستودعات";
                    btnMenuInventorySubIncomingOutgoingItems.Text = "سند إدخال و إخراج";
                    btnMenuInventorySubAddItemTypes.Text = "إضافة صنف";
                    btnMenuInventorySubAddFavorites.Text = "إضافة مجلد مفضلات";
                    btnMenuInventorySubAddWarehouses.Text = "إضافة مستودع";

                    btnMenuExpenses.Text = "المصاريف";
                    btnMenuExpensesSubSearchExpenses.Text = "البحث عن المصروفات";
                    btnMenuExpensesSubAddExpense.Text = "إضافة مصروف";

                    btnMenuIncomingOutgoing.Text = "الصادر و الوارد و رأس المال";

                    btnMenuEmployeesAffairs.Text = "شؤون الموظفين";

                    btnMenuEmployeesAffairsSubEmployeesManagement.Text = "إدارة الموظفين";
                    btnMenuEmployeesAffairsSubDaysOff.Text = "الإجازات";

                    btnMenuClientsVendors.Text = "شؤون العملاء";
                    btnMenuClientsVendorsSubClientsDefinitions.Text = "تعريف العملاء";
                    btnMenuClientsVendorsSubClientsBalanceCheck.Text = "كشف حساب العميل";
                    btnMenuClientsVendorsSubVendorsDefinitions.Text = "تعريف مورد";
                    btnMenuClientsVendorsSubVendorBalanceCheck.Text = "كشف حساب مورد";
                    btnMenuClientsVendorsSubVendorItemsDefinitions.Text = "تعريف مواد العميل";

                    btnMenuAlerts.Text = "التنبيهات";

                    btnMenuTaxes.Text = "الضريبه";
                    btnMenuTaxesSubTaxZReport.Text = "تقرير الضريبه Z";

                    btnMenuUsers.Text = "المستخدمين";

                    btnMenuSettings.Text = "الإعدادات";
                    btnMenuSettingsSubPOSSettings.Text = "إعدادات البرمجية";
                    btnMenuSettingsSubPrinterSettings.Text = "إعدادات الطابعات";

                    btnMenuRefunds.Text = "المرجعات";

                    label71.Text = "إسم الكاشير:";
                    label45.Text = "هذه النسخه مرخصه ل";
                    groupBox3.Text = "قائمة المشتريات الحاليه";
                    label112.Text = "0 :عدد الفواتير المعلقه";
                    richTextBox4.Text = " :المجموع الكامل " + this.totalAmount;
                    richTextBox5.Text = ("رقم الفاتورة الحالية");
                    richTextBox6.Text = (" :الباركود ") + this.BarCode;
                    richTextBox1.Text = ("الباقي السابق");
                    richTextBox2.Text = ("المدفوع السابق");
                    richTextBox3.Text = ("المجموع السابق");
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
                        dgvBills.Columns["Column16"].HeaderText = "إسم الكاشير";
                        dgvBills.Columns["Column12"].HeaderText = "إسم العميل";
                        dgvBills.Columns["Column17"].HeaderText = "المبلغ قبل الخصم";
                        dgvBills.Columns["Column74"].HeaderText = "قبمة الخصم";
                        dgvBills.Columns["Column73"].HeaderText = "المبلغ الصافي";
                        dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                        dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                        dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                        dgvBills.Columns["Column64"].HeaderText = "التاريخ";
                        groupBox14.Text = "المواد المباعه بالفاتوره";
                        button25.Text = "أقل 100 المواد مباعه";
                        button18.Text = "أكثر 100 المواد مباعه";
                        dgvBillItems.Columns["Column20"].HeaderText = "إسم الماده";
                        dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                        dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                        dgvBillItems.Columns["Column63"].HeaderText = "العدد المرجع";
                        dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                        dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
                        dgvBillItems.Columns["Column69"].HeaderText = "سعر الشراء";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["EditInvoices"]))
                    {
                        tabControl4.TabPages["EditInvoices"].Text = "التعديل على الفواتير";
                        groupBox30.Text = "لائحة الفواتير";
                        label13.Text = "رقم الفاتوره";
                        label11.Text = "إسم الكاشير";
                        label9.Text = "المبلغ الصافي";
                        label10.Text = "المبلغ المدفوع";
                        label12.Text = "المبلغ الباقي";
                        BillsEditButton.Text = "التعديل على الفاتوره";
                        dgvBillsEdit.Columns["BillNumber"].HeaderText = "رقم الفاتوره";
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "إسم الكاشير";
                        dgvBillsEdit.Columns["Column40"].HeaderText = "إسم العميل";
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
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "المبلغ قبل الخصم";
                        dgvUnPortedSales.Columns["Column77"].HeaderText = "المبلغ الصافي";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "المبلغ المدفوغ";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "المبلغ الباقي";
                        dgvUnPortedSales.Columns["Column75"].HeaderText = "قيمة الخصم";
                        dgvUnPortedSales.Columns["Column7"].HeaderText = "طريقة الدفع";
                        dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "المجموع";
                        groupBox26.Text = "المبيعات المرحله";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "رقم الغاتورة";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "إسم الكاشير";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "المبلغ قبل الخصم";
                        dgvPortedSales.Columns["Column78"].HeaderText = "المبلغ الصافي";
                        dgvPortedSales.Columns["Column76"].HeaderText = "قيمة الخصم";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "المبلغ المدفوغ";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "المبلغ الباقي";
                        dgvPortedSales.Columns["Column76"].HeaderText = "قيمة الخصم";
                        dgvPortedSales.Columns["Column28"].HeaderText = "طريقة الدفع";
                        dgvPortedSales.Columns["TotalPorted"].HeaderText = "المجموع";
                    }
                    if (tabControl4.Contains(tabControl4.TabPages["SoldItems"]))
                    {
                        tabControl4.TabPages["SoldItems"].Text = "جرد الكميات المباعه";
                        groupBox28.Text = "البحث";
                        label37.Text = "إسم الكاشير";
                        label38.Text = "الصنف";
                        label5.Text = "تاريخ البحث من";
                        label3.Text = "تاريخ البحث الى";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "إسم السلعه";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "الباركود";
                        dgvItemProfit.Columns["Column48"].HeaderText = "صنف الماده";
                        dgvItemProfit.Columns["Column49"].HeaderText = "إسم الكاشير";
                        dgvItemProfit.Columns["Column70"].HeaderText = "سعر الشراء";
                        dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "سعر القطعة بعد الضريبة";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "الكميه المباعه";
                        dgvItemProfit.Columns["Column71"].HeaderText = "الكميه المسترجعه";
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
                        btnPickClientForImportExport.Text = "إختيار العميل";
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
                        label19.Text = "إسم المصروف";
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
                        lblEmail.Text = "البريد الإلكتروني";
                        btnClientAdd.Text = "حفظ العميل";
                        groupBox15.Text = "جدول العملاء";
                        selectAllClients.Text = "إختيار الجميع";
                        dgvClients.Columns["Column27"].HeaderText = "إسم العميل";
                        dgvClients.Columns["ClientIDDelete"].HeaderText = "رمز العميل";
                        dgvClients.Columns["Column38"].HeaderText = "رقم العميل";
                        dgvClients.Columns["Column39"].HeaderText = "عنوان العميل";
                        dgvClients.Columns["Column10"].HeaderText = "البريد الإلكتروني";
                        btnClientDelete.Text = "حذف العميل";
                        btnClientBalanceCheck.Text = "كشف حساب";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["AgentsItemsDefinitions"]))
                    {
                        tabControl3.TabPages.Remove(tabControl3.TabPages["AgentsItemsDefinitions"]);
                        //tabControl3.TabPages["AgentsItemsDefinitions"].Text = "تعريف مواد العميل";
                        //groupBox23.Text = "جدول المواد";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "إسم القطعة";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعه";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعه";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر الشراء";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "سعر القطعه بالضريبه";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "المصنف المفضل";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "المستودع";
                        //DGVClientItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "تصنيف الماده";
                        //groupBox34.Text = "تعريف مواد العميل";
                        //label32.Text = "إسم العميل";
                        //label31.Text = "رمز العميل";
                        //label81.Text = "سعر الشراء";
                        //label86.Text = "سعر البيع قبل الضريبه";
                        //label88.Text = "سعر البيع بعد الضريبه";
                        //label90.Text = "سعر بيع العميل";
                        //button5.Text = "إختيار العميل";
                        //button4.Text = "إضافة الماده للعميل";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterDefinitions"]))
                    {
                        tabControl3.TabPages["ImporterDefinitions"].Text = "تعريف مورد";
                        groupBox40.Text = "تسجيل الموردين";
                        label41.Text = "إسم المورد";
                        label42.Text = "رمز المورد";
                        label40.Text = "رقم تلفون";
                        label39.Text = "العنوان";
                        lblVendorEmail.Text = "البريد الإلكتروني";
                        button7.Text = "حفظ المورد";
                        groupBox39.Text = "جدول الموردين";
                        selectAllVendors.Text = "إختيار الجميع";
                        dgvVendors.Columns["VendorClientName"].HeaderText = "إسم المورد";
                        dgvVendors.Columns["VendorClientID"].HeaderText = "رمز المورد";
                        dgvVendors.Columns["VendorClientPhone"].HeaderText = "رقم المورد";
                        dgvVendors.Columns["VendorClientAddress"].HeaderText = "عنوان المورد";
                        dgvVendors.Columns["Column11"].HeaderText = "البريد الإلكتروني";
                        button6.Text = "حذف المورد";
                        button9.Text = "كشف حساب";
                        button8.Text = "إضافة فاتوره";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ClientBalanceCheck"]))
                    {
                        tabControl3.TabPages["ClientBalanceCheck"].Text = "كشف حساب العميل";
                        btnPayDebtBill.Text = "دفع الفاتوره";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn24"].HeaderText = "رقم الغاتوره";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn29"].HeaderText = "إسم الكاشير";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn30"].HeaderText = "المبلغ قبل الخصم";
                        dgvClientBills.Columns["Column72"].HeaderText = "قيمة الخصم";
                        dgvClientBills.Columns["DiscountedAmount"].HeaderText = "المبلغ الصافي";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn31"].HeaderText = "التاريخ";
                        dgvClientBills.Columns["Column4"].HeaderText = "الحاله";
                        dgvClientBills.Columns["Column6"].HeaderText = "رقم العميل";
                        dgvClientBills.Columns["Column8"].HeaderText = "إسم العميل";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn20"].HeaderText = "إسم المادة";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn21"].HeaderText = "باركود الماده";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn22"].HeaderText = "عدد البيع";
                        dgvClientBillItems.Columns["Column66"].HeaderText = "عدد المرجعات";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn23"].HeaderText = "سعر البيع بعد الضريبه";
                        dgvClientBillItems.Columns["Column68"].HeaderText = "سعر الشراء ";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterBalanceChecks"]))
                    {
                        tabControl3.TabPages["ImporterBalanceChecks"].Text = "كشف حساب مورد";
                        groupBox43.Text = "لائحة الفواتير";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "رقم الغاتورة";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "إسم الكاشير";
                        dgvVendorBills.Columns["Column65"].HeaderText = "إسم المورد";
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
                    Client_card_edit.Text = "إضافة بطاقة عميل و تعديل المواد";
                    discount_edit.Text = "إضافة الخصومات";
                    price_edit.Text = "تعديل السعر";
                    receipt_edit.Text = "تعديل الفواتير و جرد المبيعات";
                    inventory_edit.Text = "تعديل المستودع";
                    expenses_edit.Text = "إضافة مصاريف";
                    users_edit.Text = "تعديل المستخدمين";
                    settings_edit.Text = "تعديل الإعدادات";
                    personnel_edit.Text = "تعديل الموظفين";
                    openclose_edit.Text = "فتح و إغلاق الكاش";
                    sell_edit.Text = "مبيعات الكاش";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                {
                    tabControl1.TabPages["Settings"].Text = "الإعدادات";
                    if (tabControl9.Contains(tabControl9.TabPages["posSettings"]))
                    {
                        tabControl9.TabPages["posSettings"].Text = "إعدادات البرمجية";
                        groupBox24.Text = "إعدادات البرمجيه";
                        groupBox9.Text = "الإعدادات الأساسية";
                        lblStoreName.Text = "إسم المتجر";
                        lblStorePhone.Text = "رقم الهاتف";
                        groupBox18.Text = "الضرائب";
                        label78.Text = "% نسبة الضريبه بالمئه";
                        groupBox2.Text = "صورة المتجر";
                        button29.Text = "إعادة الصورة الأصلية";
                        groupBox5.Text = "الطابعات";
                        label114.Text = "عدد فراغ الفاتوره";
                        IncludeLogoReceipt.Text = "تضمين الشعار في الفاتوره";
                        switchThemeScheme.Text = "الشكل المظلم";
                        lblDarkColorScheme.Text = "الألوان للشكل المظلم";
                        lblDarkPrimaryColor.Text = "الأساسي";
                        lblDarkPrimaryDark.Text = "الأساسي المظلم";
                        lblDarkPrimaryLight.Text = "الأساسي الفاتح";
                        lblDarkAccent.Text = "التمييز";
                        lblDarkTextShade.Text = "ظل النصوص";
                        lblLightColorScheme.Text = "الألوان للشكل الفاتج";
                        lblPrimaryColor.Text = "الأساسي";
                        lblPrimaryDark.Text = "الأساسي المظلم";
                        lblPrimaryLight.Text = "الأساسي الفاتح";
                        lblAccent.Text = "التمييز";
                        lblTextShade.Text = "ظل النصوص";
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
                    dgvReturnedItems.Columns["Column9"].HeaderText = "رقم الفاتورة";
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
                المظهرToolStripMenuItem.Text = "المظهر";
                فاتحToolStripMenuItem.Text = "فاتح";
                مظلمToolStripMenuItem.Text = "مظلم";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
                flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
                flowLayoutPanel2.RightToLeft = RightToLeft.Yes;
                flowLayoutPanel3.RightToLeft = RightToLeft.Yes;
                flowLayoutPanel4.RightToLeft = RightToLeft.Yes;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Main Window - PlancksoftPOS";
                if (tabControl1.Contains(tabControl1.TabPages["Cash"]))
                {
                    tabControl1.TabPages["Cash"].Text = "Cash";
                    //label93.Text = "Client Card F2";
                    //label67.Text = "Pay F1";
                    //label68.Text = "Discounts F4";
                    //label69.Text = "New Bill F3";
                    //label2.Text = "Drawer F6";
                    //label89.Text = "Edit Price F5";
                    //label24.Text = "Items Lookup F9";
                    //label70.Text = "F8 Previous Bills F7";

                    btnPay.Text = "Pay";
                    btnClientCard.Text = "Client Card";
                    btnNewInvoice.Text = "New Invoice";
                    btnDiscounts.Text = "Discounts";
                    btnOpenCashDrawer.Text = "Open Cash Drawer";
                    btnEditTotalPrice.Text = "Edit Total Price";
                    btnItemLookup.Text = "Item Lookup";
                    btnPreviousBill.Text = "Previous Bill";
                    btnNextBill.Text = "Next Bill";

                    btnMenuCash.Text = "Cash";

                    btnMenuSales.Text = "Sales";
                    btnMenuSalesSubSales.Text = "Sales";
                    btnMenuSalesSubEditInvoices.Text = "Edit Invoices";
                    btnMenuSalesSubTravelingUntravelingSales.Text = "Incoming & Outgoing Sales";
                    btnMenuSalesSubSoldItems.Text = "Sold Items Quantification";

                    btnMenuInventory.Text = "Inventory";
                    btnMenuInventorySubInventory.Text = "Inventory";
                    btnMenuInventorySubItemsQuantify.Text = "Warehouses Quantification";
                    btnMenuInventorySubIncomingOutgoingItems.Text = "Import & Export Form";
                    btnMenuInventorySubAddItemTypes.Text = "Add an Item Type";
                    btnMenuInventorySubAddFavorites.Text = "Add a Favorite Category";
                    btnMenuInventorySubAddWarehouses.Text = "Add a Warehouse";

                    btnMenuExpenses.Text = "Expenses";
                    btnMenuExpensesSubSearchExpenses.Text = "Expenses Lookup";
                    btnMenuExpensesSubAddExpense.Text = "Add an Expense";

                    btnMenuIncomingOutgoing.Text = "Import & Export & Capital";

                    btnMenuEmployeesAffairs.Text = "Employees' Affairs";

                    btnMenuEmployeesAffairsSubEmployeesManagement.Text = "Employees Management";
                    btnMenuEmployeesAffairsSubDaysOff.Text = "Days Off";

                    btnMenuClientsVendors.Text = "Clients' Affairs";
                    btnMenuClientsVendorsSubClientsDefinitions.Text = "Clients' Definitions";
                    btnMenuClientsVendorsSubClientsBalanceCheck.Text = "Client Balance Check";
                    btnMenuClientsVendorsSubVendorsDefinitions.Text = "Vendors' Definitions";
                    btnMenuClientsVendorsSubVendorBalanceCheck.Text = "Vendor Balance Check";
                    btnMenuClientsVendorsSubVendorItemsDefinitions.Text = "Vendor Items Definitions";

                    btnMenuAlerts.Text = "Alarms";

                    btnMenuTaxes.Text = "Taxes";
                    btnMenuTaxesSubTaxZReport.Text = "Tax Z Report";

                    btnMenuUsers.Text = "Users";

                    btnMenuSettings.Text = "Settings";
                    btnMenuSettingsSubPOSSettings.Text = "POS Settings";
                    btnMenuSettingsSubPrinterSettings.Text = "Printers' Settings";

                    btnMenuRefunds.Text = "Refunds";

                    label71.Text = "Cashier Name:";
                    label45.Text = "This copy is licensed for ";
                    groupBox3.Text = "List of currently pending items";
                    label112.Text = "Number of pending bills: 0";
                    richTextBox4.Text = "Total: " + this.totalAmount;
                    richTextBox5.Text = ("Current Bill Number");
                    richTextBox6.Text = ("Barcode: ") + this.BarCode;
                    richTextBox1.Text = ("Previous Remainder");
                    richTextBox2.Text = ("Previous Paid");
                    richTextBox3.Text = ("Previous Total");
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
                        dgvBills.Columns["Column12"].HeaderText = "Client Name";
                        dgvBills.Columns["Column17"].HeaderText = "Total Before Discount";
                        dgvBills.Columns["Column74"].HeaderText = "Discount Amount";
                        dgvBills.Columns["Column73"].HeaderText = "Net Total";
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
                        dgvBillItems.Columns["Column63"].HeaderText = "Returned Quantity";
                        dgvBillItems.Columns["Column24"].HeaderText = "Price";
                        dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
                        dgvBillItems.Columns["Column69"].HeaderText = "Buy Price";
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
                        dgvBillsEdit.Columns["Column40"].HeaderText = "Client Name";
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
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "Total Amount";
                        dgvUnPortedSales.Columns["Column77"].HeaderText = "Net Amount";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "Paid Amount";
                        dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "Remainder Amount";
                        dgvUnPortedSales.Columns["Column75"].HeaderText = "Discount Amount";
                        dgvUnPortedSales.Columns["Column7"].HeaderText = "Payment Method";
                        dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "Total";
                        groupBox26.Text = "Traveling Sales";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "Bill ID";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "Cashier Name";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Total Amount";
                        dgvPortedSales.Columns["Column78"].HeaderText = "Net Total";
                        dgvPortedSales.Columns["Column76"].HeaderText = "Discount Amount";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Paid Amount";
                        dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "Remainder Amount";
                        dgvPortedSales.Columns["Column76"].HeaderText = "Discount Amount";
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
                        dgvItemProfit.Columns["Column70"].HeaderText = "Buy Price";
                        dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                        dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "Sold Quantity";
                        dgvItemProfit.Columns["Column71"].HeaderText = "Refunded Quantity";
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
                        btnPickClientForImportExport.Text = "Pick Client";
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
                        lblEmail.Text = "Email Address";
                        btnClientAdd.Text = "Save Client";
                        groupBox15.Text = "Clients Grid";
                        selectAllClients.Text = "Select Everyone";
                        dgvClients.Columns["Column27"].HeaderText = "Client Name";
                        dgvClients.Columns["ClientIDDelete"].HeaderText = "Client ID";
                        dgvClients.Columns["Column38"].HeaderText = "Phone Number";
                        dgvClients.Columns["Column39"].HeaderText = "Client Address";
                        dgvClients.Columns["Column10"].HeaderText = "Client Email";
                        btnClientDelete.Text = "Delete Client";
                        btnClientBalanceCheck.Text = "Balance Summary";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["AgentsItemsDefinitions"]))
                    {
                        tabControl3.TabPages.Remove(tabControl3.TabPages["AgentsItemsDefinitions"]);
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ClientBalanceCheck"]))
                    {
                        tabControl3.TabPages["ClientBalanceCheck"].Text = "Client Balance Summary";
                        btnPayDebtBill.Text = "Pay Bill";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn24"].HeaderText = "Bill Number";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn29"].HeaderText = "Cashier Name";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn30"].HeaderText = "Total Before Discount";
                        dgvClientBills.Columns["Column72"].HeaderText = "Discount Amount";
                        dgvClientBills.Columns["DiscountedAmount"].HeaderText = "Net Total";
                        dgvClientBills.Columns["dataGridViewTextBoxColumn31"].HeaderText = "Date";
                        dgvClientBills.Columns["Column4"].HeaderText = "Status";
                        dgvClientBills.Columns["Column6"].HeaderText = "Client ID";
                        dgvClientBills.Columns["Column8"].HeaderText = "Client Name";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn20"].HeaderText = "Item Name";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn21"].HeaderText = "Item Barcode";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn22"].HeaderText = "Sold Quantity";
                        dgvClientBillItems.Columns["Column66"].HeaderText = "Returned Quantity";
                        dgvClientBillItems.Columns["dataGridViewTextBoxColumn23"].HeaderText = "Item Price after Tax";
                        dgvClientBillItems.Columns["Column68"].HeaderText = "Buy Price";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterDefinitions"]))
                    {
                        tabControl3.TabPages["ImporterDefinitions"].Text = "Importer Definition";
                        groupBox40.Text = "Importers Registration";
                        label41.Text = "Importer Name";
                        label42.Text = "Importer ID";
                        label40.Text = "Phone Number";
                        label39.Text = "Address";
                        lblVendorEmail.Text = "Email Address";
                        button7.Text = "Save Importer";
                        groupBox39.Text = "Importers Grid";
                        selectAllVendors.Text = "Select Everyone";
                        dgvVendors.Columns["VendorClientName"].HeaderText = "Importer Name";
                        dgvVendors.Columns["VendorClientID"].HeaderText = "Importer ID";
                        dgvVendors.Columns["VendorClientPhone"].HeaderText = "Importer Phone Number";
                        dgvVendors.Columns["VendorClientAddress"].HeaderText = "Importer Address";
                        dgvVendors.Columns["Column11"].HeaderText = "Importer Email";
                        button6.Text = "Importer Delete";
                        button9.Text = "Account Summary";
                        button8.Text = "Add Bill";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ClientBalanceCheck"]))
                    {
                        //tabControl3.TabPages["ClientBalanceCheck"].Text = "Add Importer Bill";
                        //groupBox41.Text = "Add Importer Bill";
                        //label43.Text = "Importer Name";
                        //label44.Text = "Importer ID";
                        //button12.Text = "Add Bill";
                        //button10.Text = "Pick Item";
                        //button11.Text = "Delete Item";
                        //dgvVendorItemsPick.Columns["VendorItemName"].HeaderText = "Item Name";
                        //dgvVendorItemsPick.Columns["VendorItemBarCode"].HeaderText = "Item Barcode";
                        //dgvVendorItemsPick.Columns["VendorItemType"].HeaderText = "Item Type";
                        //dgvVendorItemsPick.Columns["VendorItemQuantity"].HeaderText = "Item Quantity";
                        //dgvVendorItemsPick.Columns["VendorItemBuyPrice"].HeaderText = "Buy Price";
                        //dgvVendorItemsPick.Columns["VendorItemSellPrice"].HeaderText = "Sell Price";
                        //dgvVendorItemsPick.Columns["VendorItemSellPriceTax"].HeaderText = "Sell Price Tax";
                    }
                    if (tabControl3.Contains(tabControl3.TabPages["ImporterBalanceChecks"]))
                    {
                        tabControl3.TabPages["ImporterBalanceChecks"].Text = "Importer Account Summary";
                        groupBox43.Text = "List of Bills";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "Bill ID";
                        dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "Cashier Name";
                        dgvVendorBills.Columns["Column65"].HeaderText = "Importer Name";
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
                    Client_card_edit.Text = "Add Client Card & Client Items";
                    discount_edit.Text = "Add Discounts";
                    price_edit.Text = "Edit Bill Prices";
                    receipt_edit.Text = "Edit Invoices & Quantify Sales";
                    inventory_edit.Text = "Edit Inventory";
                    expenses_edit.Text = "Add Expenses";
                    users_edit.Text = "Edit Users";
                    settings_edit.Text = "Edit Settings";
                    personnel_edit.Text = "Edit Employees";
                    openclose_edit.Text = "Close & Open Cash Register";
                    sell_edit.Text = "Cash Sales";
                }
                if (tabControl1.Contains(tabControl1.TabPages["Settings"]))
                {
                    tabControl1.TabPages["Settings"].Text = "Settings";
                    if (tabControl9.Contains(tabControl9.TabPages["posSettings"]))
                    {
                        tabControl9.TabPages["posSettings"].Text = "System Preferences";
                        groupBox24.Text = "System Preferences";
                        groupBox9.Text = "Fundamental Settings";
                        lblStoreName.Text = "Store Name";
                        lblStorePhone.Text = "Phone Number";
                        groupBox18.Text = "Taxes";
                        label78.Text = "Percentage of Taxes %";
                        groupBox2.Text = "Store Logo";
                        button29.Text = "Reset Default Logo";
                        groupBox5.Text = "Printers";
                        label114.Text = "Blank Spaces in Receipt";
                        IncludeLogoReceipt.Text = "Include Logo in Receipt";
                        switchThemeScheme.Text = "Dark Mode";
                        lblDarkColorScheme.Text = "Dark Color Scheme";
                        lblDarkPrimaryColor.Text = "Basic";
                        lblDarkPrimaryDark.Text = "Basic Dark";
                        lblDarkPrimaryLight.Text = "Basic Light";
                        lblDarkAccent.Text = "Accent";
                        lblDarkTextShade.Text = "Text Shade";
                        lblLightColorScheme.Text = "Light Color Scheme";
                        lblPrimaryColor.Text = "Basic";
                        lblPrimaryDark.Text = "Basic Dark";
                        lblPrimaryLight.Text = "Basic Light";
                        lblAccent.Text = "Accent";
                        lblTextShade.Text = "Text Shade";
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
                    dgvReturnedItems.Columns["Column9"].HeaderText = "Bill ID";
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
                المظهرToolStripMenuItem.Text = "Theme";
                فاتحToolStripMenuItem.Text = "Light";
                مظلمToolStripMenuItem.Text = "Dark";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
                flowLayoutPanel1.RightToLeft = RightToLeft.No;
                flowLayoutPanel2.RightToLeft = RightToLeft.No;
                flowLayoutPanel3.RightToLeft = RightToLeft.No;
                flowLayoutPanel4.RightToLeft = RightToLeft.No;
            }
        }

        public void DisplayCashierNames()
        {
            List<string> CashierNames = Connection.server.RetrieveCashierNames();
            foreach (string CashierName in CashierNames)
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
            plusItemTypeLbl.Dock = DockStyle.Fill;
            plusItemTypeLbl.ForeColor = Color.Black;
            plusItemTypeLbl.Font = new Font(plusItemTypeLbl.Font.FontFamily, 14);
            flowLayoutPanel3.Controls.Add(plusItemTypeLbl);

            AddItemType = new TextBox();
            AddItemType.Text = "";
            AddItemType.Size = new Size(351, 20);
            AddItemType.KeyPress += (sender, e) => { if (e.KeyChar == (char)Keys.Enter) { AddItemTypeHandler(sender, e); } };
            flowLayoutPanel3.Controls.Add(AddItemType);

            plusItemTypePB = new PictureBox();
            plusItemTypePB.Image = Resources.plus;
            plusItemTypePB.BorderStyle = BorderStyle.Fixed3D;
            plusItemTypePB.Cursor = Cursors.Hand;
            if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                plusItemTypePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
            else plusItemTypePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
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
            ItemTypeLbl.Dock = DockStyle.Fill;
            flowLayoutPanel3.Controls.Add(ItemTypeLbl);

            saveItemTypesBtn = new MaterialButton();
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
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    minusItemTypePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkLightPrimary);
                else minusItemTypePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.LightPrimary);
                minusItemTypePB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusItemTypePB.Click += (sender, e) => { DeleteItemTypeHandler(sender, e, itemtype.Key); };
                flowLayoutPanel3.Controls.Add(minusItemTypePB);

                Label tempItemtypetxt = new Label();
                tempItemtypetxt.Name = itemtype.Value;
                tempItemtypetxt.Text = itemtype.Value;
                tempItemtypetxt.Tag = itemtype.Key;
                tempItemtypetxt.Size = new Size(340, 20);
                tempItemtypetxt.Dock = DockStyle.Fill;
                tempItemtypetxt.ForeColor = Color.Black;
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
            plusWarehouseLbl.Dock = DockStyle.Fill;
            plusWarehouseLbl.ForeColor = Color.Black;
            plusWarehouseLbl.Font = new Font(plusWarehouseLbl.Font.FontFamily, 14);
            flowLayoutPanel2.Controls.Add(plusWarehouseLbl);

            AddWarehouse = new TextBox();
            AddWarehouse.Text = "";
            AddWarehouse.Size = new Size(351, 20);
            AddWarehouse.KeyPress += (sender, e) => { if (e.KeyChar == (char)Keys.Enter) { AddWarehouseHandler(sender, e); } };
            flowLayoutPanel2.Controls.Add(AddWarehouse);

            plusWarehousePB = new PictureBox();
            plusWarehousePB.Image = Resources.plus;
            plusWarehousePB.BorderStyle = BorderStyle.Fixed3D;
            plusWarehousePB.Cursor = Cursors.Hand;
            if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                plusWarehousePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
            else plusWarehousePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
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
            WarehouseLbl.Dock = DockStyle.Fill;
            WarehouseLbl.ForeColor = Color.Black;
            WarehouseLbl.Font = new Font(plusWarehouseLbl.Font.FontFamily, 14);
            flowLayoutPanel2.Controls.Add(WarehouseLbl);

            saveWarehousesBtn = new MaterialButton();
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
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    minusWarehousePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkLightPrimary);
                else minusWarehousePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.LightPrimary);
                minusWarehousePB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusWarehousePB.Click += (sender, e) => { DeleteWarehouseHandler(sender, e, warehouse.Key); };
                flowLayoutPanel2.Controls.Add(minusWarehousePB);

                Label tempWarehousetxt = new Label();
                tempWarehousetxt.Name = warehouse.Value;
                tempWarehousetxt.Text = warehouse.Value;
                tempWarehousetxt.Tag = warehouse.Key;
                tempWarehousetxt.Size = new Size(340, 20);
                tempWarehousetxt.Dock = DockStyle.Fill;
                tempWarehousetxt.ForeColor = Color.Black;
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
            plusFavoriteLbl.Dock = DockStyle.Fill;
            plusFavoriteLbl.ForeColor = Color.Black;
            plusFavoriteLbl.Font = new Font(plusFavoriteLbl.Font.FontFamily, 14);
            flowLayoutPanel1.Controls.Add(plusFavoriteLbl);

            AddFavorite = new TextBox();
            AddFavorite.Text = "";
            AddFavorite.Size = new Size(351, 20);
            AddFavorite.KeyPress += (sender, e) => { if (e.KeyChar == (char)Keys.Enter) { AddFavoritesHandler(sender, e); } };
            flowLayoutPanel1.Controls.Add(AddFavorite);

            plusFavoritePB = new PictureBox();
            plusFavoritePB.Image = Resources.plus;
            plusFavoritePB.BorderStyle = BorderStyle.Fixed3D;
            plusFavoritePB.Cursor = Cursors.Hand;
            if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                plusFavoritePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
            else plusFavoritePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
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
            FavoriteLbl.Dock = DockStyle.Fill;
            FavoriteLbl.ForeColor = Color.Black;
            FavoriteLbl.Font = new Font(plusFavoriteLbl.Font.FontFamily, 14);
            flowLayoutPanel1.Controls.Add(FavoriteLbl);

            saveFavoritesBtn = new MaterialButton();
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
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    minusFavoritePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkLightPrimary);
                else minusFavoritePB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.LightPrimary);
                minusFavoritePB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusFavoritePB.Click += (sender, e) => { DeleteFavoritesHandler(sender, e, favorite.Key); };
                flowLayoutPanel1.Controls.Add(minusFavoritePB);

                Label tempFavoritetxt = new Label();
                tempFavoritetxt.Name = favorite.Value;
                tempFavoritetxt.Text = favorite.Value;
                tempFavoritetxt.Tag = favorite.Key;
                tempFavoritetxt.Size = new Size(340, 20);
                tempFavoritetxt.Dock = DockStyle.Fill;
                tempFavoritetxt.ForeColor = Color.Black;
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
                flowLayoutPanels[i].Dock = DockStyle.Fill;
                flowLayoutPanels[i].Location = new Point(0, 1);
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    flowLayoutPanels[i].FlowDirection = FlowDirection.LeftToRight;
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    flowLayoutPanels[i].FlowDirection = FlowDirection.RightToLeft;
                }
                flowLayoutPanels[i].AutoScroll = true;
                flowLayoutPanels[i].WrapContents = true;
                flowLayoutPanels[i].BackColor = Color.White;
                tabControl2.TabPages[i].Controls.Add(flowLayoutPanels[i]);
                tabControl2.TabPages[i++].BackColor = Color.White;

                for (int y = 0; y < tabControl2.TabPages.Count; y++)
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
                            try
                            {
                                byte[] picture = Connection.server.RetrieveItemPictureFromBarCode(favoriteItem.GetItemBarCode()).PictureUpload;
                                var stream = new MemoryStream(picture);
                                btn.BackgroundImage = Image.FromStream(stream);
                            } catch (Exception exc) { }
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
                        MaterialMessageBox.Show(".تم حذف صنف المواد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Item Type was deleted.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حذف صنف المواد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Item Type.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تمت اضافة أصناف المواد الجديده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Item Type was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ أصناف المواد الجديده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to add new Item Type.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تم حفظ أصناف المواد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Item Types were saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ أصناف المواد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save Item Types.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تم حذف المستودع", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Warehouse was deleted.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حذف المستودع", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Warehouse.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تمت اضافة المستودع الجديد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Warehouse was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ المستودع الجديد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to add new Warehouse.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تم حفظ المستودعات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Werehouses was saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ المستودعات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save warehouses.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

                    if (ClientsaleItems.Count > 0)
                    {
                        for (int i = 0; i < ClientsaleItems.Count; i++)
                        {
                            if (ClientsaleItems[i].GetItemBarCode() == item.GetItemBarCode())
                            {
                                priceAfterSales = ClientsaleItems[i].ClientPrice;
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
                        richTextBox6.Text = " :الباركود " + item.GetItemBarCode();
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox6.Text = " Barcode: " + item.GetItemBarCode();
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
                    MaterialMessageBox.Show(".لا يمكن اضافة الماده المفضله", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to add Favorite Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تم حذف مجلد المفضلات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Favorite Category was deleted.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حذف المفضلات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Favorite Category.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تم حذف الطابعة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Printer was deleted.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayPrinters();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حذف الطابعة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Printer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تمت اضافة مجلد المفضلات الجديده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Favorite Category was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ مجلدات المفضلات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save Favorite Categories.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تمت اضافة الطابعة الجديده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Printer was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ مجلدات المفضلات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save Favorite Categories.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        void SaveFavoritesHandler(object sender, EventArgs e)
        {
            try
            {
                bool updatedFavoriteCategories = false;
                int i = 0;
                foreach (KeyValuePair<int, string> favorite in favorites)
                {
                    updatedFavoriteCategories = Connection.server.UpdateFavoriteCategories(Convert.ToInt32(FavoriteNamestxt[i].Tag), FavoriteNamestxt[i++].Text);
                }
                if (updatedFavoriteCategories)
                {
                    DisplayFavorites();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حفظ مجلد المفضلات الجديد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Favorite Category was saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ مجلدات المفضلات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save Favorite Categories.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }
        void EditPrintersHandler(object sender, EventArgs e, int index, string printerName, string machineName, bool isMainPrinter)
        {
            try
            {
                frmEditPrinter frmEditPrinter = new frmEditPrinter(index, printerName, machineName, isMainPrinter);
                frmEditPrinter.ShowDialog();
                DisplayPrinters();
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من تعديل الطابعه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to edit Printer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }
        void SavePrintersHandler(object sender, EventArgs e)
        {
            try
            {
                bool updatedPrinters = false;
                int i = 0;
                foreach (KeyValuePair<int, Tuple<string, Tuple<int, string>>> printer in printers)
                {
                    updatedPrinters = Connection.server.UpdatePrinters(Convert.ToInt32(PrintersNamesTV[i].Tag), PrintersNamesTV[i++].Text, Environment.MachineName, 0);
                }
                if (updatedPrinters)
                {
                    DisplayPrinters();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حفظ الطابعات الجديدة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("All new Printers were saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حفظ الطابعات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save Printers.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".لم نستطع حذف القطعه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Items.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                richTextBox5.Text = " :رقم الفاتورة الحالية " + this.CurrentBillNumber;
                richTextBox4.Text = " :المجموع الكامل " + this.totalAmount;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                richTextBox5.Text = "Current Bill ID: " + this.CurrentBillNumber;
                richTextBox4.Text = "Total: " + this.totalAmount;
            }
        }

        public void DisplayPrinters()
        {
            printers.Clear();
            PrintersNamesTV.Clear();

            frmMain.PrintersList = Connection.server.RetrievePrinters(Environment.MachineName);

            foreach (Printer printer in frmMain.PrintersList)
            {
                this.printers.Add(printer.ID, Tuple.Create(printer.Name, Tuple.Create(printer.IsMainPrinter, printer.MachineName)));
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
            plusPrinterLbl.Dock = DockStyle.Fill;
            plusPrinterLbl.ForeColor = Color.Black;
            plusPrinterLbl.Font = new Font(plusPrinterLbl.Font.FontFamily, 14);
            flowLayoutPanel4.Controls.Add(plusPrinterLbl);

            AddPrinter = new TextBox();
            AddPrinter.Text = "";
            AddPrinter.Size = new Size(351, 20);
            AddPrinter.KeyPress += (sender, e) => { if (e.KeyChar == (char)Keys.Enter) { AddPrintersHandler(sender, e); } };
            flowLayoutPanel4.Controls.Add(AddPrinter);

            plusPrinterPB = new PictureBox();
            plusPrinterPB.Image = Resources.plus;
            plusPrinterPB.BorderStyle = BorderStyle.Fixed3D;
            plusPrinterPB.Cursor = Cursors.Hand;
            if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                plusPrinterPB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
            else plusPrinterPB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
            plusPrinterPB.SizeMode = PictureBoxSizeMode.StretchImage;
            plusPrinterPB.Click += (sender, e) => { AddPrintersHandler(sender, e); };
            flowLayoutPanel4.Controls.Add(plusPrinterPB);

            PrinterLbl = new MaterialLabel();
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                PrinterLbl.Text = "الطابعات المضافه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                PrinterLbl.Text = "Added Printers";
            }
            PrinterLbl.Dock = DockStyle.Fill;
            PrinterLbl.ForeColor = Color.Black;
            PrinterLbl.Font = new Font(plusPrinterLbl.Font.FontFamily, 14);
            flowLayoutPanel4.Controls.Add(PrinterLbl);

            savePrintersBtn = new MaterialButton();
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


            foreach (KeyValuePair<int, Tuple<string, Tuple<int, string>>> printer in this.printers)
            {
                minusPrinterPB = new PictureBox();
                minusPrinterPB.Image = Resources.minus;
                minusPrinterPB.Size = new Size(50, 50);
                minusPrinterPB.BorderStyle = BorderStyle.Fixed3D;
                minusPrinterPB.Cursor = Cursors.Hand;
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    minusPrinterPB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkLightPrimary);
                else minusPrinterPB.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.LightPrimary);
                minusPrinterPB.SizeMode = PictureBoxSizeMode.StretchImage;
                minusPrinterPB.Click += (sender, e) => { DeletePrintersHandler(sender, e, printer.Key); };
                flowLayoutPanel4.Controls.Add(minusPrinterPB);

                Label tempLabel = new Label();
                tempLabel.Text = printer.Value.Item1;
                tempLabel.ForeColor = Color.Black;
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    tempLabel.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
                else tempLabel.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
                tempLabel.Font = new Font(tempLabel.Font.FontFamily, 14, FontStyle.Bold);
                tempLabel.Dock = DockStyle.Fill;
                Label tempLabel2 = new Label();
                tempLabel2.Text = printer.Value.Item2.Item2;
                tempLabel2.ForeColor = Color.Black;
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    tempLabel2.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
                else tempLabel2.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
                tempLabel2.Font = new Font(tempLabel2.Font.FontFamily, 14, FontStyle.Bold);
                tempLabel2.Dock = DockStyle.Fill;
                Label tempLabel3 = new Label();
                tempLabel3.Text = printer.Value.Item2.Item1 == 1 ? frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic ? "طابعه رئيسيه" : "Main Printer" : frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic ? "طابعه غير رئيسيه" : "Not Main Printer";
                tempLabel3.ForeColor = Color.Black;
                if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    tempLabel3.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.darkPrimary);
                else tempLabel3.BackColor = ColorTranslator.FromHtml(Properties.Settings.Default.PrimaryDark);
                tempLabel3.Font = new Font(tempLabel3.Font.FontFamily, 14, FontStyle.Bold);
                tempLabel3.Dock = DockStyle.Fill;
                TreeView tempTreeView = new TreeView();
                tempTreeView.Name = printer.Value.Item1;
                tempTreeView.Text = printer.Value.Item1;
                tempTreeView.Tag = printer.Key;

                editPrintersBtn = new MaterialButton();
                editPrintersBtn.Name = "editPrintersBtn";
                editPrintersBtn.Tag = printer.Key;
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    editPrintersBtn.Text = "تعديل الطابعه";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    editPrintersBtn.Text = "Edit Printer";
                }
                editPrintersBtn.Size = new Size(340, 45);
                editPrintersBtn.ForeColor = Color.White;
                editPrintersBtn.BackColor = Color.FromArgb(59, 89, 152);
                editPrintersBtn.Font = new Font(editPrintersBtn.Font.FontFamily, 14, FontStyle.Bold);
                editPrintersBtn.Click += (sender, e) => { EditPrintersHandler(sender, e, printer.Key, printer.Value.Item1, printer.Value.Item2.Item2, Convert.ToBoolean(printer.Value.Item2.Item1)); };

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
                    addItemTypeToPrinter = new MenuItem();
                    addItemTypeToPrinter.Text = "إضافة صنف مواد للطابعة";
                    deleteItemTypeFromPrinter = new MenuItem();
                    deleteItemTypeFromPrinter.Text = "حذف صنف مواد من الطابعة";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    addItemTypeToPrinter = new MenuItem();
                    addItemTypeToPrinter.Text = "Add Item Type to Printer";
                    deleteItemTypeFromPrinter = new MenuItem();
                    deleteItemTypeFromPrinter.Text = "Delete Item Type from Printer";
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
                flowLayoutPanel4.Controls.Add(tempLabel2);
                flowLayoutPanel4.Controls.Add(tempLabel3);
                flowLayoutPanel4.Controls.Add(editPrintersBtn);
                flowLayoutPanel4.Controls.Add(PrintersNamesTV[PrinterCount]);
                PrinterCount++;
            }

            flowLayoutPanel4.Controls.Add(savePrintersBtn);
        }

        void addItemTypePrinter_Click(object sender, EventArgs e, int PrinterIndex)
        {
            PrinterIndex = 0;
            foreach (TreeView tv in PrintersNamesTV)
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
            try
            {
                Application.Exit();
            } catch (Exception exc)
            {

            }
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
                    MaterialMessageBox.Show(".لم نستطع تعديل أسعار القطعه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to edit Item price.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".لم نستطع تعديل أسعار القطعه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to edit Item price.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        newItem.PictureUpload = a;
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
                            MaterialMessageBox.Show(".لم نتمكن من اضافة الماده الجديده بسبب مشكله في المعلومات المدخلة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Unable to add new Item because of an issue with filled data.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                    ClearInput();
                    DisplayFavorites();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show("!الرجاء أدخل المعلومات المطلوبه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Please fill required fields!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    ClearInput();
                }
            } catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show("!الرجاء أدخل المعلومات المطلوبه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please fill required fields!", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
            string dateFrom = dateTimePicker12.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker11.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrievePortedBills(dateFrom, dateTo);
            dgvPortedSales.DataSource = RetrievedBills.Item2;
            return RetrievedBills.Item1;
        }

        public List<Bill> DisplayBillsEdit()
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveBills();
            dgvBillsEdit.DataSource = RetrievedBills.Item2;
            return RetrievedBills.Item1;
        }

        public void DisplayClientBills(int ClientID)
        {
            DataTable RetrievedBills = Connection.server.RetrieveClientBills(ClientID);
            dgvClientBills.DataSource = RetrievedBills;
        }

        public List<Bill> DisplayVendorBills(int VendorID)
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveVendorBills(VendorID);
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
            DataTable RetrievedEmployees = Connection.server.RetrieveEmployees(Convert.ToDateTime(DateEmployeeFrom.Value), Convert.ToDateTime(DateEmployeeTo.Value));
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
                        if (Dependencies.MD5Encryption.Encrypt(Dependencies.MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
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
                                    newItem.PictureUpload = a;
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
                                        MaterialMessageBox.Show(".لم نتمكن من تحديث معلومات الماده بسبب مشكله في المعلومات المدخله", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        MaterialMessageBox.Show("Unable to update Item details because of an issue with filled data.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                    }
                                }
                                ClearInput();
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".الرجاء اختيار سطر ماده من الجدول", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Please pick an Item Row from the Grid.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                return;
                            }
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MaterialMessageBox.Show(".كلمة السر خطأ", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Incorrect Password.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".فقط حساب إداري بامكانه تحديث المواد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Only Administrators may update Items.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من تحديث معلومات الماده بسبب مشكله في إدخال كلمة السر", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to update Item details because of an issue with Password entry.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        if (Dependencies.MD5Encryption.Encrypt(Dependencies.MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
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
                                MaterialMessageBox.Show(".كلمة السر خطأ", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Incorrect Password.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".فقط حساب إداري بامكانه حذف المواد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Only Administrators may delete Items.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من حذف الماده بسبب مشكله في إدخال كلمة السر", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Item because of an issue with Password entry.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
            processPayment();
        }

        public void pictureBox12_Click(object sender, EventArgs e)
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to add a new Bill before filling the current Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
            else
            {
                List<Item> items = new List<Item>();
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
                        Item item = new Item();
                        item.SetName(itemName);
                        item.SetBarCode(itemBarCode);
                        item.SetQuantity(itemQuantity);
                        item.SetPrice(itemPrice);
                        item.SetPriceTax(itemPriceTax);
                        items.Add(item);
                    }
                }

                this.paidAmount = 0;
                this.moneyInRegister += 0;
                Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                Properties.Settings.Default.Save();
                this.remainderAmount = this.totalAmount - this.paidAmount;

                Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                previousBillsList.Push(billToAdd);

                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox3.Text = (" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.Text = (" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.Text = (" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox3.Text = (" Previous Total: " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.Text = (" Previous Paid: " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.Text = (" Previous Remainder: " + previousBillsList.Peek().getRemainderAmount().ToString());
                }

                ItemsPendingPurchase.Rows.Clear();
                this.ClientsaleItems.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;
                items = null;
                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
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
                    List<Item> itemsBought = new List<Item>();
                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                            string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                            int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                            decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                            decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                            itemsBought.Add(new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                        }
                    }

                    nextBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                    ItemsPendingPurchase.Rows.Clear();
                    Bill bill = previousBillsList.Pop();
                    if (bill.BillNumber < 1)
                    {
                        this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    }
                    else
                    {
                        this.CurrentBillNumber = bill.getBillNumber();
                    }
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
                        MaterialMessageBox.Show(".لا بوجد شراء غير مكتمل سابق", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("There is no previous pending Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

                bill.Postponed = true;

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
                    List<Item> itemsBought = new List<Item>();
                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                            string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                            int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                            decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                            decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                            itemsBought.Add(new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                            richTextBox1.ResetText();
                            richTextBox2.ResetText();
                            richTextBox3.ResetText();
                        }
                    }

                    previousBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                    ItemsPendingPurchase.Rows.Clear();
                    Bill bill = nextBillsList.Pop();

                    if (bill.getBillNumber() < 1)
                    {
                        this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                    }
                    else
                    {
                        this.CurrentBillNumber = bill.getBillNumber();
                    }

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
                        MaterialMessageBox.Show(".لا بوجد شراء غير مكتمل تالي", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("There is no next pending Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

                bill.Postponed = true;

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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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

                Client_card_edit.Checked = this.userPermissions.Client_card_edit;
                discount_edit.Checked = this.userPermissions.discount_edit;
                price_edit.Checked = this.userPermissions.price_edit;
                receipt_edit.Checked = this.userPermissions.receipt_edit;
                inventory_edit.Checked = this.userPermissions.inventory_edit;
                expenses_edit.Checked = this.userPermissions.expenses_add;
                users_edit.Checked = this.userPermissions.users_edit;
                settings_edit.Checked = this.userPermissions.settings_edit;
                personnel_edit.Checked = this.userPermissions.personnel_edit;
                openclose_edit.Checked = this.userPermissions.openclose_edit;
                sell_edit.Checked = this.userPermissions.sell_edit;
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
                    if (Dependencies.MD5Encryption.Encrypt(Dependencies.MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                    {
                        if (txtUserNameAdd.Text != "" && txtUserIDAdd.Text != "" && txtUserPasswordAdd.Text != "")
                        {
                            if (txtUserIDAdd.Text.ToLower().Trim() == "admin")
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لا يمكن تسجيل رمز المستخدم admin", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Unable Register User ID admin.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                ClearInput();
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountName(txtUserNameAdd.Text);
                            newAccount.SetAccountUID(txtUserIDAdd.Text);
                            newAccount.SetAccountPWD(Dependencies.MD5Encryption.Encrypt(txtUserPasswordAdd.Text, "PlancksoftPOS"));
                            newAccount.SetAccountAuthority(Convert.ToInt32(cbAdminOrNotAdd.Checked));
                            newAccount.Client_card_edit = Client_card_edit.Checked;
                            newAccount.discount_edit = discount_edit.Checked;
                            newAccount.price_edit = price_edit.Checked;
                            newAccount.receipt_edit = receipt_edit.Checked;
                            newAccount.inventory_edit = inventory_edit.Checked;
                            newAccount.expenses_add = expenses_edit.Checked;
                            newAccount.users_edit = users_edit.Checked;
                            newAccount.settings_edit = settings_edit.Checked;
                            newAccount.personnel_edit = personnel_edit.Checked;
                            newAccount.openclose_edit = openclose_edit.Checked;
                            newAccount.sell_edit = sell_edit.Checked;

                            if (Connection.server.Register(newAccount, this.UID, newAccount.GetAccountAuthority()))
                            {
                                Users = DisplayUsers();
                                DisplayCashierNames();
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لم نتمكن من اضافة المستخدم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Unable to add new User.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                            }
                            ClearInput();
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MaterialMessageBox.Show(".الرجاء ادخال جميع البيانات!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Please fill all required data!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            ClearInput();
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".كلمة السر خطأ", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Incorrect Password.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".فقط حساب إداري بامكانه إضافة المستخدمين", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Only Administrators may add new User Accounts.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    if (Dependencies.MD5Encryption.Encrypt(Dependencies.MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                    {
                        if (txtUserNameAdd.Text != "" && txtUserIDAdd.Text != "")
                        {
                            if (txtUserIDAdd.Text.ToLower().Trim() == "admin" && this.UID != "admin")
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لا يمكن تسجيل رمز المستخدم لأنه محجوز للحساب الإداري الرئيسي", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("admin User ID is reserved for the main Administrator Account.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                ClearInput();
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountName(txtUserNameAdd.Text);
                            newAccount.SetAccountUID(txtUserIDAdd.Text);
                            if (txtUserPasswordAdd.Text != "")
                                newAccount.SetAccountPWD(Dependencies.MD5Encryption.Encrypt(txtUserPasswordAdd.Text, "PlancksoftPOS"));
                            newAccount.SetAccountAuthority(Convert.ToInt32(cbAdminOrNotAdd.Checked));
                            newAccount.Client_card_edit = Client_card_edit.Checked;
                            newAccount.discount_edit = discount_edit.Checked;
                            newAccount.price_edit = price_edit.Checked;
                            newAccount.receipt_edit = receipt_edit.Checked;
                            newAccount.inventory_edit = inventory_edit.Checked;
                            newAccount.expenses_add = expenses_edit.Checked;
                            newAccount.users_edit = users_edit.Checked;
                            newAccount.settings_edit = settings_edit.Checked;
                            newAccount.personnel_edit = personnel_edit.Checked;
                            newAccount.openclose_edit = openclose_edit.Checked;
                            newAccount.sell_edit = sell_edit.Checked;

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
                                    MaterialMessageBox.Show(".لا يمكن تحديث المستخدم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Cannot update User Account.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                MaterialMessageBox.Show(".الرجاء ادخال جميع البيانات!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Please fill all required data!", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                            MaterialMessageBox.Show(".كلمة السر خطأ", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Incorrect Password.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".فقط حساب إداري بامكانه تعديل المستخدمين", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Only Administrator Accounts may alter User Accounts.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    if (Dependencies.MD5Encryption.Encrypt(Dependencies.MD5Encryption.Encrypt(frmAuth.password, "PlancksoftPOS"), "PlancksoftPOS") == PWD)
                    {
                        if (txtUserIDAdd.Text != "")
                        {
                            if (dgvUsers.SelectedRows[0].Cells["UserID"].Value.ToString().ToLower().Trim() == "admin")
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لا يمكن حذف الحساب الإداري", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Unable to delete Administrator Account.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                return;
                            }
                            if (txtUserIDAdd.Text.ToLower().Trim() == this.UID.ToLower().Trim())
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لا يمكن حذف الحساب المدخول به حاليا, الرجاء الحذف من حساب إداري أخر", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Unable to delete User Account as it is currently logged in. Please delete it from another Administrator Account.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                    MaterialMessageBox.Show(".لم نتمكن من حذف المستخدم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Unable to delete User Account.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                MaterialMessageBox.Show(".الرجاء ادخال جميع البيانات!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Please fill all required data!", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                            MaterialMessageBox.Show(".كلمة السر خطأ", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Incorrect Password.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".فقط حساب إداري بامكانه تعديل المستخدمين", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Only Administrator Accounts are able to alter User Accounts.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                dgvBills.Columns["Column16"].HeaderText = "إسم الكاشير";
                dgvBills.Columns["Column12"].HeaderText = "إسم العميل";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ قبل الخصم";
                dgvBills.Columns["Column74"].HeaderText = "قبمة الخصم";
                dgvBills.Columns["Column73"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column12"].HeaderText = "Client Name";
                dgvBills.Columns["Column17"].HeaderText = "Total Before Discount";
                dgvBills.Columns["Column74"].HeaderText = "Discount Amount";
                dgvBills.Columns["Column73"].HeaderText = "Net Total";
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
                    int BillNumber = Convert.ToInt32(dgvBills.Rows[dgvBills.CurrentCell.RowIndex].Cells["Column15"].Value.ToString());
                    Bill billPaid = Connection.server.SearchBills("", "", BillNumber).Item1[0];
                    List<Item> itemsInBill = new List<Item>();

                    for (int i = 0; i < dgvBillItems.Rows.Count; i++)
                    {
                        Item SearchedItem = Connection.server.SearchItems("", dgvBillItems.Rows[i].Cells["Column21"].Value.ToString(), 0).Item1[0];
                        SearchedItem.SetQuantity(Connection.server.RetrieveBillSoldBItemQuantity(BillNumber, SearchedItem.GetItemBarCode()));
                        itemsInBill.Add(SearchedItem);
                    }
                    billPaid.ItemsBought = itemsInBill;

                    printCertainReceipt(billPaid, true);
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show("الرجاء إختيار فاتورة.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Please pick a Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
        }

        public void dgvBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvBillItems.DataSource = RetrieveBillItems(e.RowIndex);

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "إسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد المرجع";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
                dgvBillItems.Columns["Column69"].HeaderText = "سعر الشراء";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English) {
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Returned Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
                dgvBillItems.Columns["Column69"].HeaderText = "Buy Price";
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
        }

        public void button18_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> mostBoughtItems = Connection.server.RetrieveMostBoughtItems();
            dgvBillItems.DataSource = mostBoughtItems.Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "إسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد المرجع";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
                dgvBillItems.Columns["Column69"].HeaderText = "سعر الشراء";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Returned Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
                dgvBillItems.Columns["Column69"].HeaderText = "Buy Price";
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
                dgvBills.Columns["Column16"].HeaderText = "إسم الكاشير";
                dgvBills.Columns["Column12"].HeaderText = "إسم العميل";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ قبل الخصم";
                dgvBills.Columns["Column74"].HeaderText = "قبمة الخصم";
                dgvBills.Columns["Column73"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column12"].HeaderText = "Client Name";
                dgvBills.Columns["Column17"].HeaderText = "Total Before Discount";
                dgvBills.Columns["Column74"].HeaderText = "Discount Amount";
                dgvBills.Columns["Column73"].HeaderText = "Net Total";
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
                    dgvBills.Columns["Column16"].HeaderText = "إسم الكاشير";
                    dgvBills.Columns["Column12"].HeaderText = "إسم العميل";
                    dgvBills.Columns["Column17"].HeaderText = "المبلغ قبل الخصم";
                    dgvBills.Columns["Column74"].HeaderText = "قبمة الخصم";
                    dgvBills.Columns["Column73"].HeaderText = "المبلغ الصافي";
                    dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                    dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                    dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                    dgvBills.Columns["Column64"].HeaderText = "التاريخ";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                    dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                    dgvBills.Columns["Column12"].HeaderText = "Client Name";
                    dgvBills.Columns["Column17"].HeaderText = "Total Before Discount";
                    dgvBills.Columns["Column74"].HeaderText = "Discount Amount";
                    dgvBills.Columns["Column73"].HeaderText = "Net Total";
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
                dgvBillItems.Columns["Column20"].HeaderText = "إسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد المرجع";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
                dgvBillItems.Columns["Column69"].HeaderText = "سعر الشراء";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Returned Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
                dgvBillItems.Columns["Column69"].HeaderText = "Buy Price";
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
                dgvBills.Columns["Column16"].HeaderText = "إسم الكاشير";
                dgvBills.Columns["Column12"].HeaderText = "إسم العميل";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ قبل الخصم";
                dgvBills.Columns["Column74"].HeaderText = "قبمة الخصم";
                dgvBills.Columns["Column73"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column12"].HeaderText = "Client Name";
                dgvBills.Columns["Column17"].HeaderText = "Total Before Discount";
                dgvBills.Columns["Column74"].HeaderText = "Discount Amount";
                dgvBills.Columns["Column73"].HeaderText = "Net Total";
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
            string dateFrom = dateTimePicker14.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker13.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveUnPortedBills(dateFrom, dateTo);
            dgvUnPortedSales.DataSource = RetrievedBills.Item2;
            for (int i = 0; i < dgvUnPortedSales.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUnPortedSales.DataSource];
                currencyManager1.SuspendBinding();
                dgvUnPortedSales.Rows[i].Selected = true;
                dgvUnPortedSales.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
                total += Convert.ToDecimal(dgvUnPortedSales.Rows[i].Cells["Column77"].Value);
            }
            RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, 0, 0, "", total);
            dgvUnPortedSales.DataSource = RetrievedBills.Item2;
            dgvUnPortedSales.Refresh();

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn6"].HeaderText = "رقم الغاتورة";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn7"].HeaderText = "إسم الكاشير";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "المبلغ قبل الخصم";
                dgvUnPortedSales.Columns["Column77"].HeaderText = "المبلغ الصافي";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "المبلغ المدفوغ";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "المبلغ الباقي";
                dgvUnPortedSales.Columns["Column75"].HeaderText = "قيمة الخصم";
                dgvUnPortedSales.Columns["Column7"].HeaderText = "طريقة الدفع";
                dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "المجموع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn6"].HeaderText = "Bill ID";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn7"].HeaderText = "Cashier Name";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn8"].HeaderText = "Total Amount";
                dgvUnPortedSales.Columns["Column77"].HeaderText = "Net Total";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn9"].HeaderText = "Paid Amount";
                dgvUnPortedSales.Columns["dataGridViewTextBoxColumn10"].HeaderText = "Remainder Amount";
                dgvUnPortedSales.Columns["Column75"].HeaderText = "Discount Amount";
                dgvUnPortedSales.Columns["Column7"].HeaderText = "Payment Method";
                dgvUnPortedSales.Columns["TotalUnPorted"].HeaderText = "Total";
            }
        }

        public void pictureBox6_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            DataTable dt = new DataTable();
            dt.Clear();
            string dateFrom = dateTimePicker12.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker11.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrievePortedBills(dateFrom, dateTo);
            dgvPortedSales.DataSource = RetrievedBills.Item2;
            for (int i = 0; i < dgvPortedSales.Rows.Count; i++)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvPortedSales.DataSource];
                currencyManager1.SuspendBinding();
                dgvPortedSales.Rows[i].Selected = true;
                dgvPortedSales.Rows[i].Visible = true;
                currencyManager1.ResumeBinding();
                total += Convert.ToDecimal(dgvPortedSales.Rows[i].Cells["Column78"].Value);
            }
            RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, 0, 0, "", total);
            dgvPortedSales.DataSource = RetrievedBills.Item2;
            dgvPortedSales.Refresh();

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "رقم الغاتورة";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "إسم الكاشير";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "المبلغ قبل الخصم";
                dgvPortedSales.Columns["Column78"].HeaderText = "المبلغ الصافي";
                dgvPortedSales.Columns["Column76"].HeaderText = "قيمة الخصم";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "المبلغ المدفوغ";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "المبلغ الباقي";
                dgvPortedSales.Columns["Column76"].HeaderText = "قيمة الخصم";
                dgvPortedSales.Columns["Column28"].HeaderText = "طريقة الدفع";
                dgvPortedSales.Columns["TotalPorted"].HeaderText = "المجموع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvPortedSales.Columns["dataGridViewTextBoxColumn11"].HeaderText = "Bill ID";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn12"].HeaderText = "Cashier Name";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn13"].HeaderText = "Total Amount";
                dgvPortedSales.Columns["Column78"].HeaderText = "Net Total";
                dgvPortedSales.Columns["Column76"].HeaderText = "Discount Amount";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn14"].HeaderText = "Paid Amount";
                dgvPortedSales.Columns["dataGridViewTextBoxColumn15"].HeaderText = "Remainder Amount";
                dgvPortedSales.Columns["Column76"].HeaderText = "Discount Amount";
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                        richTextBox6.Text = " :الباركود " + item.GetItemBarCode();
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        richTextBox6.Text = " Barcode: " + item.GetItemBarCode();
                                    }
                                    this.ScannedBarCode = "";
                                    found = true;
                                    richTextBox6.ResetText();
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
                            richTextBox6.Text = " :الباركود " + item.GetItemBarCode();
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox6.Text = " Barcode: " + item.GetItemBarCode();
                        }
                        richTextBox6.ResetText();
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
                        DialogResult addItemDialog = FlexibleMaterialForm.Show(this, " لا يوجد تعريف للماده في المستودع, هل تريد اضافة الماده؟ ", " إضافة ماده؟ ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                        if (addItemDialog == DialogResult.Yes)
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
                        DialogResult addItemDialog = FlexibleMaterialForm.Show(this, "Item is not defined in the inventory, would you like to add it?", " Add Item? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                        if (addItemDialog == DialogResult.Yes)
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
                MaterialMessageBox.Show(String.Format(".+962 79 294 2040 .{0} الرجاء مخاطبة للدعم الفني", Application.CompanyName));
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                MaterialMessageBox.Show(String.Format("Please contact Technical Support. {0}. +962 79 14 077 36", Application.CompanyName));
            }
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

        public void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                //printDocument2.Print();
                string printerName = "";
                frmMain.PrintersList = Connection.server.RetrievePrinters(Environment.MachineName);
                foreach (Printer printer in PrintersList)
                {
                    if (printer.MachineName == Environment.MachineName && printer.IsMainPrinter == 1)
                    {
                        printerName = printer.Name;
                        break;
                    }
                }

                // ESC/POS Command: Open drawer 1, 200ms pulse
                byte[] openDrawer = new byte[] { 0x1B, 0x70, 0x00, 0x40, 0x50 };

                if (SendBytesToPrinter(printerName, openDrawer))
                    Console.WriteLine("Cash drawer opened.");
                else
                    Console.WriteLine("Failed to open cash drawer.");
            } catch (Exception error)
            {
                MaterialMessageBox.Show(e.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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

            DataTable dtSoldItemsQuantification = Connection.server.RetrieveBillItemsProfit(dateFrom, dateTo, ItemTypeID, CashierName);
            dtSoldItemsQuantification.Rows.Add();
            dgvItemProfit.DataSource = dtSoldItemsQuantification;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "إسم السلعه";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "الباركود";
                dgvItemProfit.Columns["Column48"].HeaderText = "صنف الماده";
                dgvItemProfit.Columns["Column49"].HeaderText = "إسم الكاشير";
                dgvItemProfit.Columns["Column70"].HeaderText = "سعر الشراء";
                dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "سعر القطعة بعد الضريبة";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "الكميه المباعه";
                dgvItemProfit.Columns["Column71"].HeaderText = "الكميه المسترجعه";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn19"].HeaderText = "المجموع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvItemProfit.Columns["dataGridViewTextBoxColumn16"].HeaderText = "Item Name";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn17"].HeaderText = "Item Barcode";
                dgvItemProfit.Columns["Column48"].HeaderText = "Item Type";
                dgvItemProfit.Columns["Column49"].HeaderText = "Cashier Name";
                dgvItemProfit.Columns["Column70"].HeaderText = "Buy Price";
                dgvItemProfit.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn18"].HeaderText = "Sold Quantity";
                dgvItemProfit.Columns["Column71"].HeaderText = "Refunded Quantity";
                dgvItemProfit.Columns["dataGridViewTextBoxColumn19"].HeaderText = "Total";
            }
            Decimal total = 0;

            foreach (DataGridViewRow row in dgvItemProfit.Rows)
            {
                try
                {
                    total += Convert.ToDecimal(row.Cells["dataGridViewTextBoxColumn19"].Value.ToString());
                } catch (Exception exc)
                {
                }
            }

            dgvItemProfit.Rows[dgvItemProfit.Rows.Count - 1].Cells["dataGridViewTextBoxColumn19"].Value = total;
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

            DataTable dtSoldItemsQuantification = Connection.server.RetrieveBillItemsProfit(dateFrom, dateTo, ItemTypeID, CashierName);
            dtSoldItemsQuantification.Rows.Add();
            dgvItemProfit.DataSource = dtSoldItemsQuantification;


            Decimal total = 0;

            foreach (DataGridViewRow row in dgvItemProfit.Rows)
            {
                try
                {
                    total += Convert.ToDecimal(row.Cells["dataGridViewTextBoxColumn19"].Value.ToString());
                }
                catch (Exception exc)
                {
                }
            }

            dgvItemProfit.Rows[dgvItemProfit.Rows.Count - 1].Cells["dataGridViewTextBoxColumn19"].Value = total;
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
                dgvBillsEdit.Columns["BillCashierName"].HeaderText = "إسم الكاشير";
                dgvBillsEdit.Columns["Column40"].HeaderText = "إسم العميل";
                dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "المبلغ الصافي";
                dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "المبلغ المدفوع";
                dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "المبلغ الباقي";
                dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "طريقة الدفع";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvBillsEdit.Columns["BillNumber"].HeaderText = "Bill ID";
                dgvBillsEdit.Columns["BillCashierName"].HeaderText = "Bill Cashier Name";
                dgvBillsEdit.Columns["Column40"].HeaderText = "Client Name";
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
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "إسم الكاشير";
                        dgvBillsEdit.Columns["Column40"].HeaderText = "إسم العميل";
                        dgvBillsEdit.Columns["BillTotalAmount"].HeaderText = "المبلغ الصافي";
                        dgvBillsEdit.Columns["BillPaidAmount"].HeaderText = "المبلغ المدفوع";
                        dgvBillsEdit.Columns["BillRemainderAmount"].HeaderText = "المبلغ الباقي";
                        dgvBillsEdit.Columns["BillPaymentType"].HeaderText = "طريقة الدفع";
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        dgvBillsEdit.Columns["BillNumber"].HeaderText = "Bill ID";
                        dgvBillsEdit.Columns["BillCashierName"].HeaderText = "Bill Cashier Name";
                        dgvBillsEdit.Columns["Column40"].HeaderText = "Client Name";
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
            } catch (Exception error)
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تمت اضافة المصروف", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {

                        MaterialMessageBox.Show("A new expense was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            } catch (Exception error) {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من اضافة المصروف", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to add new expense.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

        public void ClientID_Enter(object sender, EventArgs e)
        {
            ClientID.Select(0, 1);
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

        public void ClientPrice_Enter(object sender, EventArgs e)
        {
            ClientPrice.Select(0, 1);
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
                        {
                            return;
                        }
                        else if (e.KeyChar == (Char)Keys.Enter)
                        {
                            if (!this.timerstarted)
                            {
                                itemBarCodeEntryTimer.Start();
                                this.timerstarted = true;
                            }
                        }
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
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox6.Text = "Barcode: " + ScannedBarCode;
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                richTextBox6.Text = ": الباركود" + ScannedBarCode;
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
            bool changedUI = false;
            try
            {
                if (Connection.server.UpdateSystemSettings(this.txtStoreName.Text, StoreLogo, this.txtStorePhone.Text,
                    txtStoreAddress.Text,
                    Convert.ToInt32(this.receiptSpacingnud.Value),
                    Convert.ToInt32(this.IncludeLogoReceipt.Checked), nudTaxRate.Value))
                {
                    this.PlancksoftPOSName = this.txtStoreName.Text;
                    this.PlancksoftPOSPhone = this.txtStorePhone.Text;
                    this.PlancksoftPOSAddress = this.txtStorePhone.Text;
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
                    Program.materialSkinManager.EnforceBackcolorOnAllComponents = false;

                    // Dark Theme Color Scheme

                    Properties.Settings.Default.darkPrimary = DarkPrimaryColor.Text;
                    Properties.Settings.Default.darkPrimaryDark = DarkPrimaryDarkColor.Text;
                    Properties.Settings.Default.darkLightPrimary = DarkPrimaryLightColor.Text;
                    Properties.Settings.Default.darkAccent = DarkAccentColor.Text;

                    if (switchDarkBlackTextShade.Checked)
                        Properties.Settings.Default.darkTextShade = "BLACK";
                    else
                        Properties.Settings.Default.darkTextShade = "WHITE";

                    // Light Theme Color Scheme

                    Properties.Settings.Default.Primary = PrimaryColor.Text;
                    Properties.Settings.Default.PrimaryDark = PrimaryDarkColor.Text;
                    Properties.Settings.Default.LightPrimary = PrimaryLightColor.Text;
                    Properties.Settings.Default.Accent = AccentColor.Text;

                    if (switchBlackTextShade.Checked)
                        Properties.Settings.Default.TextShade = "BLACK";
                    else
                        Properties.Settings.Default.TextShade = "WHITE";

                    if (switchThemeScheme.Checked == (Convert.ToBoolean(Convert.ToInt32(ThemeSchemeChoice.ThemeScheme.Dark))))
                    {
                        Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                        if (Properties.Settings.Default.darkTextShade == "BLACK")
                            Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.BLACK);
                        else
                            Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.WHITE);
                        Properties.Settings.Default.pickedThemeScheme = 1;
                        Properties.Settings.Default.Save();
                        changedUI = true;
                        مظلمToolStripMenuItem.Checked = true;
                        فاتحToolStripMenuItem.Checked = false;
                    }
                    else
                    {
                        Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        if (Properties.Settings.Default.TextShade == "BLACK")
                            Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.BLACK);
                        else
                            Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.WHITE);
                        Properties.Settings.Default.pickedThemeScheme = 0;
                        Properties.Settings.Default.Save();
                        changedUI = true;
                        مظلمToolStripMenuItem.Checked = false;
                        فاتحToolStripMenuItem.Checked = true;
                    }

                    this.Refresh();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حفظ الاعدادات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("System preferences were saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    Application.Restart();
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم يتم حفظ جميع الاعدادات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to save all new System preferences.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم يتم حفظ جميع الاعدادات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to save all new System preferences.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                if (changedUI)
                {
                    Application.Restart();
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
                    string dateFrom = "";
                    string dateTo = "";
                    Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveUnPortedBills(dateFrom, dateTo);
                    dgvUnPortedSales.DataSource = RetrievedBills.Item2;
                    for (int i = 0; i < dgvUnPortedSales.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvUnPortedSales.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvUnPortedSales.Rows[i].Selected = true;
                        dgvUnPortedSales.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                        total += Convert.ToDecimal(dgvUnPortedSales.Rows[i].Cells["Column77"].Value);
                    }
                    RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, 0, 0, "", total);
                    dgvUnPortedSales.DataSource = RetrievedBills.Item2;
                    dgvUnPortedSales.Refresh();

                    total = 0;
                    dt = new DataTable();
                    dt.Clear();
                    dateFrom = dateTimePicker12.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
                    dateTo = dateTimePicker11.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
                    RetrievedBills = Connection.server.RetrievePortedBills(dateFrom, dateTo);
                    dgvPortedSales.DataSource = RetrievedBills.Item2;
                    for (int i = 0; i < dgvPortedSales.Rows.Count; i++)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvPortedSales.DataSource];
                        currencyManager1.SuspendBinding();
                        dgvPortedSales.Rows[i].Selected = true;
                        dgvPortedSales.Rows[i].Visible = true;
                        currencyManager1.ResumeBinding();
                        total += Convert.ToDecimal(dgvPortedSales.Rows[i].Cells["Column78"].Value);
                    }
                    RetrievedBills.Item2.Rows.Add(0, "", 0, 0, 0, 0, 0, "", total);
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
                    dateFrom = dateTimePicker4.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
                    dateTo = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";

                    DataTable dtSoldItemsQuantification = Connection.server.RetrieveBillItemsProfit(dateFrom, dateTo, ItemTypeID, CashierName);
                    dtSoldItemsQuantification.Rows.Add();
                    dgvItemProfit.DataSource = dtSoldItemsQuantification;

                    Decimal totalProfit = 0;

                    foreach (DataGridViewRow row in dgvItemProfit.Rows)
                    {
                        try
                        {
                            totalProfit += Convert.ToDecimal(row.Cells["dataGridViewTextBoxColumn19"].Value.ToString());
                        }
                        catch (Exception exc)
                        {
                        }
                    }

                    dgvItemProfit.Rows[dgvItemProfit.Rows.Count - 1].Cells["dataGridViewTextBoxColumn19"].Value = totalProfit;
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
                    DataTable retrievedClients = Connection.server.GetRetrieveClients();

                    dgvClients.DataSource = retrievedClients;

                    DataTable retrievedVendors = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedVendors;
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
                    Tuple<List<Item>, DataTable> retreivedClientItems = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage);
                    DGVClientItems.DataSource = retreivedClientItems.Item2;
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Taxes"])
                {
                    string dateFrom = dateTimePicker10.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
                    string dateTo = dateTimePicker9.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
                    decimal totalTax = 0;
                    DataTable TaxZReport = Connection.server.RetrieveTaxZReport(dateFrom, dateTo);
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
                        dgvReturnedItems.Columns["Column9"].HeaderText = "رقم الفاتورة";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn52"].HeaderText = "إسم الماده";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn51"].HeaderText = "باركود الماده";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn57"].HeaderText = "عدد القطع المرجعه";
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn54"].HeaderText = "Return ID";
                        dgvReturnedItems.Columns["dataGridViewTextBoxColumn55"].HeaderText = "Cashier Name";
                        dgvReturnedItems.Columns["Column9"].HeaderText = "Bill ID";
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

            foreach (DataGridViewRow row in dvgCapital.Rows)
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
                case CloseReason.TaskManagerClosing:
                case CloseReason.WindowsShutDown:
                case CloseReason.MdiFormClosing:
                case CloseReason.None:
                    Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                    Properties.Settings.Default.Save();
                    Connection.server.LogLogout(this.UID, DateTime.Now);
                    break;
                case CloseReason.FormOwnerClosing:
                case CloseReason.UserClosing:
                case CloseReason.ApplicationExitCall:
                    try
                    {
                        Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                        Properties.Settings.Default.Save();
                        Connection.server.LogLogout(this.UID, DateTime.Now);

                        if (!Program.exited)
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                DialogResult exitDialog = FlexibleMaterialForm.Show(this, "هل أنت متأكد من رغبتك بالخروج؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                                if (exitDialog == DialogResult.Yes)
                                {
                                    Program.exited = true;
                                    Environment.Exit(0);
                                }
                                else if (exitDialog == DialogResult.No)
                                {
                                    e.Cancel = true;
                                }
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                DialogResult exitDialog = FlexibleMaterialForm.Show(this, "Are you sure you would like to quit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                                if (exitDialog == DialogResult.Yes)
                                {
                                    Program.exited = true;
                                    Environment.Exit(0);
                                }
                                else if (exitDialog == DialogResult.No)
                                {
                                    e.Cancel = true;
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    { }
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
            if (userPermissions.Client_card_edit)
            {
                frmClientCard ClientCard = new frmClientCard();
                openedForm = ClientCard;
                ClientCard.ShowDialog();
                if (ClientCard.dialogResult == DialogResult.OK)
                {
                    this.currentClient = ClientCard.Client;
                    ClientName.Text = ClientCard.Client.ClientName;
                    ClientID.Value = ClientCard.Client.ClientID;

                    bool replaced = false;
                    foreach (Item item in ClientCard.saleItems)
                    {
                        for (int i = 0; i < this.ClientsaleItems.Count; i++)
                        {
                            if (ClientsaleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                            {
                                int index = ClientCard.saleItems.IndexOf(item);
                                this.ClientsaleItems[index] = item;
                                replaced = true;
                            }
                        }

                        if (!replaced)
                        {
                            this.ClientsaleItems.Add(item);
                        }
                    }

                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if (ClientsaleItems.Count > 0)
                            {
                                for (int i = 0; i < ClientsaleItems.Count; i++)
                                {
                                    if (ClientsaleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                    {
                                        decimal priceAfterSales;
                                        decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                        if (ClientsaleItems[i].saleRate != 0)
                                            priceAfterSales = Convert.ToDecimal((ClientsaleItems[i].ClientPrice) * (ClientsaleItems[i].saleRate / 100));
                                        else priceAfterSales = Convert.ToDecimal(ClientsaleItems[i].ClientPrice);
                                        decimal marginPrice = previousPrice - priceAfterSales;
                                        this.totalAmount = this.totalAmount - marginPrice;
                                        item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                        richTextBox4.ResetText();
                                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                        {
                                            richTextBox4.Text = " :المجموع الكامل " + this.totalAmount;
                                        }
                                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                        {
                                            richTextBox4.Text = " Total: " + this.totalAmount;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    ClientCard.Dispose();
                    if (replaced)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("The Discount percentage for Client Items was altered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".تم اضافة خصم العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("A Client Discount was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }


                }
            }
        }

        public void btnClientAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.RegisterClient(new Client(ClientName.Text, 0, ClientPhone.Text, ClientAddress.Text, ClientEmail.Text)))
                {
                    ClientName.Text = "";
                    ClientID.Value = 0;
                    ClientPhone.Text = "";
                    ClientAddress.Text = "";
                    ClientEmail.Text = "";


                    DataTable retrievedClients = Connection.server.GetRetrieveClients();

                    dgvClients.DataSource = retrievedClients;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تمت اضافة العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Client was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من اضافة العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to add new Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                DataTable retrievedClients = Connection.server.GetRetrieveClients();

                dgvClients.DataSource = retrievedClients;

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvClients.Columns["Column27"].HeaderText = "إسم العميل";
                    dgvClients.Columns["ClientIDDelete"].HeaderText = "رمز العميل";
                    dgvClients.Columns["Column38"].HeaderText = "رقم العميل";
                    dgvClients.Columns["Column39"].HeaderText = "عنوان العميل";
                    dgvClients.Columns["Column10"].HeaderText = "البريد الإلكتروني";
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvClients.Columns["Column27"].HeaderText = "Client Name";
                    dgvClients.Columns["ClientIDDelete"].HeaderText = "Client ID";
                    dgvClients.Columns["Column38"].HeaderText = "Phone Number";
                    dgvClients.Columns["Column39"].HeaderText = "Client Address";
                    dgvClients.Columns["Column10"].HeaderText = "Client Email";
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
                        richTextBox4.Text = " :المجموع الكامل " + this.totalAmount;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.Text = " Total: " + this.totalAmount;
                    }
                    if (!this.totalAmount.ToString().Contains("."))
                        richTextBox4.Text = ".00";
                    if (this.totalAmount.ToString().Contains("."))
                    {
                        if (this.totalAmount.ToString().EndsWith("."))
                        {
                            richTextBox4.Text = "00";
                        } else
                        {
                            if (this.totalAmount.ToString().Split('.')[1].Length == 1)
                            {
                                richTextBox4.Text = "0";
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

        public void pictureBox40_Click(object sender, EventArgs e)
        {
            DGVClientItems.DataSource = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage).Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClientItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "إسم القطعة";
                DGVClientItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعه";
                DGVClientItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعه";
                DGVClientItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر الشراء";
                DGVClientItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه";
                DGVClientItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "سعر القطعه بالضريبه";
                DGVClientItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "المصنف المفضل";
                DGVClientItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "المستودع";
                DGVClientItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "تصنيف الماده";
            } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClientItems.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                DGVClientItems.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                DGVClientItems.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                DGVClientItems.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Buy Price";
                DGVClientItems.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Sell Price";
                DGVClientItems.Columns["dataGridViewTextBoxColumn25"].HeaderText = "Sell Price Tax";
                DGVClientItems.Columns["dataGridViewTextBoxColumn26"].HeaderText = "Favorite Category";
                DGVClientItems.Columns["dataGridViewTextBoxColumn27"].HeaderText = "Warehouse";
                DGVClientItems.Columns["dataGridViewTextBoxColumn28"].HeaderText = "Item Type";
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

        public void ClientPrice_Enter_1(object sender, EventArgs e)
        {
            ClientPrice.Select(0, 1);
        }

        public void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (!this.userPermissions.Client_card_edit)
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
                Tuple<List<Item>, DataTable> retreivedClientItems = Connection.server.RetrieveItems((int)frmLogin.pickedLanguage);
                DGVClientItems.DataSource = retreivedClientItems.Item2;
            }
            //else if (tabControl3.SelectedTab == tabControl3.TabPages["AgentsItemsDefinitions"])
            //{
            //    DataTable retrievedVendors = Connection.server.GetRetrieveVendors();

            //    dgvVendors.DataSource = retrievedVendors;
            //}
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
                tabControl3.SelectedTab = tabControl3.TabPages["ClientBalanceCheck"];
                int Index = dgvVendors.CurrentCell.RowIndex;
                string vendorName = dgvVendors.Rows[Index].Cells["VendorClientName"].Value.ToString();
                int vendorID = Convert.ToInt32(dgvVendors.Rows[Index].Cells["VendorClientID"].Value.ToString());
            } catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".الرجاء اختيار مورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please pick an Importer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        public void button9_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl3.SelectedTab = tabControl3.TabPages["ImporterBalanceChecks"];
                int Index = dgvVendors.CurrentCell.RowIndex;
                string vendorName = dgvVendors.Rows[Index].Cells["VendorClientName"].Value.ToString();
                int vendorID = Convert.ToInt32(dgvVendors.Rows[Index].Cells["VendorClientID"].Value.ToString());

                List<Bill> Bills = DisplayVendorBills(vendorID);
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
                    dgvVendorBills.Columns["Column65"].HeaderText = "إسم المورد";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn41"].HeaderText = "المبلغ الصافي";
                    dgvVendorBills.Columns["VendorBillDate"].HeaderText = "التاريخ";
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn39"].HeaderText = "Bill ID";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn40"].HeaderText = "Cashier Name";
                    dgvVendorBills.Columns["Column65"].HeaderText = "Importer Name";
                    dgvVendorBills.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Net Total";
                    dgvVendorBills.Columns["VendorBillDate"].HeaderText = "Date";
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".الرجاء اختيار مورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please pick an Importer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        public void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection.server.RegisterVendor(new Client(VendorName.Text, 0, VendorPhone.Text, VendorAddress.Text, VendorEmail.Text)))
                {
                    VendorName.Text = "";
                    VendorID.Value = 0;
                    VendorPhone.Text = "";
                    VendorAddress.Text = "";
                    VendorEmail.Text = "";

                    DataTable retrievedVendors = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedVendors;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تمت اضافة المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Importer was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من اضافة المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to add a new Importer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                if (Connection.server.DeleteClient(dgvVendors.CurrentRow.Cells["VendorClientID"].Value.ToString()))
                {
                    DataTable retrievedClients = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedClients;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حذف العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Client was deleted.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نستطع حذف العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to delete Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                DataTable retrievedVendors = Connection.server.GetRetrieveVendors();

                dgvVendors.DataSource = retrievedVendors;

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvVendors.Columns["VendorClientName"].HeaderText = "إسم المورد";
                    dgvVendors.Columns["VendorClientID"].HeaderText = "رمز المورد";
                    dgvVendors.Columns["VendorClientPhone"].HeaderText = "رقم المورد";
                    dgvVendors.Columns["VendorClientAddress"].HeaderText = "عنوان المورد";
                    dgvVendors.Columns["Column11"].HeaderText = "البريد الإلكتروني";
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvVendors.Columns["VendorClientName"].HeaderText = "Importer Name";
                    dgvVendors.Columns["VendorClientID"].HeaderText = "Importer ID";
                    dgvVendors.Columns["VendorClientPhone"].HeaderText = "Importer Phone Number";
                    dgvVendors.Columns["VendorClientAddress"].HeaderText = "Importer Address";
                    dgvVendors.Columns["Column11"].HeaderText = "Importer Email";
                }
            } catch (Exception error)
            {

            }
        }

        //public void button12_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<Item> itemsToAdd = new List<Item>();
        //        int row = 0;
        //        foreach (DataGridViewRow currentBillRow in dgvVendorItemsPick.Rows)
        //        {
        //            if (currentBillRow.Cells[0].Value != null && currentBillRow.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(currentBillRow.Cells[0].Value.ToString()))
        //            {
        //                string itemName = currentBillRow.Cells[0].Value.ToString();
        //                string itemBarCode = currentBillRow.Cells[1].Value.ToString();
        //                int itemQuantity = Convert.ToInt32(currentBillRow.Cells[3].Value.ToString());
        //                decimal itemBuyPrice = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
        //                decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[5].Value.ToString());
        //                decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[6].Value.ToString());
        //                Item itemToAdd = new Item();
        //                itemToAdd.SetName(itemName);
        //                itemToAdd.SetBarCode(itemBarCode);
        //                itemToAdd.SetQuantity(itemQuantity);
        //                itemToAdd.SetBuyPrice(itemBuyPrice);
        //                itemToAdd.SetPrice(itemPrice);
        //                itemToAdd.SetPriceTax(itemPriceTax);
        //                Connection.server.UpdateItemQuantity(itemsToAdd[row++]);
        //                itemsToAdd.Add(itemToAdd);
        //                this.totalVendorAmount += itemBuyPrice * itemQuantity;
        //            }
        //        }

        //        Bill billToAdd = new Bill(this.CurrentVendorBillNumber, this.totalVendorAmount, itemsToAdd, DateTime.Now);
        //        int BillNumber = Connection.server.AddVendorBill(billToAdd, this.cashierName);
        //        if (BillNumber > -1)
        //        {
        //            this.totalVendorAmount = Connection.server.RetrieveLastVendorBillNumberToday(DateTime.Now).getBillNumber() + 1;
        //            this.CurrentVendorBillNumber++;
        //            this.ItemsList = DisplayData();
        //            DisplayFavorites();
        //            dgvVendorItemsPick.DataSource = new DataTable();
        //            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
        //            {
        //                MaterialMessageBox.Show(".تمت اضافة الفاتوره للمورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //            }
        //            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
        //            {
        //                MaterialMessageBox.Show("A new Importer Bill was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //            }
        //        }
        //        else
        //        {
        //            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
        //            {
        //                MaterialMessageBox.Show(".الرجاء إختيار مورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //            }
        //            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
        //            {
        //                MaterialMessageBox.Show("Please pick an Importer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //            }
        //        }
        //    }
        //    catch (Exception error)
        //    {

        //    }
        //}

        public void tabControl3_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        public void dgvVendorBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvVendorBillItems.DataSource = Connection.server.RetrieveVendorBillItems(Convert.ToInt32(dgvVendorBills.Rows[e.RowIndex].Cells[0].Value.ToString()));

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
            string dateFrom = dateTimePicker10.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string dateTo = dateTimePicker9.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            decimal totalTax = 0;
            DataTable TaxZReport = Connection.server.RetrieveTaxZReport(dateFrom, dateTo);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            MaterialMessageBox.Show(1.ToString());
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
                    MaterialMessageBox.Show(".الرجاء اختيار سطر لماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please pick a row of an Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

        public void ClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnClientAdd.PerformClick();
        }

        public void ClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnClientAdd.PerformClick();
        }

        public void ClientPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnClientAdd.PerformClick();
        }

        public void ClientAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnClientAdd.PerformClick();
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

        public void processPayment()
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لا بمكتك دفع فاتوره فارغه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("You cannot pay an empty Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
            else
            {
                frmPay frmPayCash = new frmPay(this.totalAmount);
                openedForm = frmPayCash;
                frmPayCash.ShowDialog(this);
                this.totalAmount = frmPayCash.totalAmount;
                this.paidAmount = frmPayCash.moneyPaid;
                if (this.paidAmount <= this.totalAmount)
                {
                    this.moneyInRegister += this.paidAmount;
                } else
                {
                    this.moneyInRegister += this.totalAmount;
                }
                Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                Properties.Settings.Default.Save();
                this.remainderAmount = (frmPayCash.totalAmount - frmPayCash.discountedAmount) - this.paidAmount;

                if (frmPayCash.dialogResult == DialogResult.OK)
                {
                    frmPayCash.Dispose();
                    List<Item> itemsToAdd = new List<Item>();
                    foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                    {
                        if (!currentBillRow.IsNewRow)
                        {
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            Item itemRetrieved = Connection.server.SearchItems("", itemBarCode, 0).Item1[0];
                            string itemName = itemRetrieved.ItemName1;
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                            decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                            decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            Item itemToAdd = new Item();
                            itemToAdd.SetName(itemName);
                            itemToAdd.SetBarCode(itemBarCode);
                            itemToAdd.SetQuantity(itemQuantity);
                            itemToAdd.SetPrice(itemPrice);
                            itemToAdd.SetPriceTax(itemPriceTax);
                            itemToAdd.SetBuyPrice(Connection.server.SearchItems("", itemBarCode, 0).Item1[0].GetBuyPrice());
                            itemToAdd.SetItemTypeID(itemRetrieved.GetItemTypeeID());
                            itemsToAdd.Add(itemToAdd);
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
                                                MaterialMessageBox.Show("قطعه باركود " + item.ItemBarCode + " انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                            }
                                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                            {
                                                MaterialMessageBox.Show("Item Barcode " + item.ItemBarCode + " is either expired or has less quantity in inventory than defined warning limit.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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


                    Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, frmPayCash.discountedAmount, "Tax ID", itemsToAdd, frmPayCash.paybycash, DateTime.Now, this.cashierName);
                    if (Connection.server.PayBill(billToAdd, this.cashierName))
                    {
                        // paid bill

                        //printCertainReceipt(billToAdd);
                        CapitalAmountnud.Value = Connection.server.GetCapitalAmount();
                        label91.Text = this.CapitalAmount.ToString();
                        this.ClientsaleItems.Clear();
                    }
                }
                else if (frmPayCash.dialogResult == DialogResult.Retry)
                {
                    List<Item> items = new List<Item>();

                    frmPickClientLookup frmPickClientLookup = new frmPickClientLookup();
                    if (frmPickClientLookup != null && !frmPickClientLookup.IsDisposed)
                    {
                        frmPickClientLookup.ShowDialog();

                        if (frmPickClientLookup.dialogResult == DialogResult.OK)
                        {
                            foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                            {
                                if (!currentBillRow.IsNewRow)
                                {
                                    Item item = Connection.server.SearchItems("", currentBillRow.Cells["pendingPurchaseItemBarCode"].Value.ToString(), 0).Item1[0];
                                    string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                                    Item itemRetrieved = Connection.server.SearchItems("", itemBarCode, 0).Item1[0];
                                    string itemName = itemRetrieved.ItemName1;
                                    int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                                    decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                                    decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                                    Item itemToAdd = new Item();
                                    itemToAdd.SetName(itemName);
                                    itemToAdd.SetBarCode(itemBarCode);
                                    itemToAdd.SetQuantity(itemQuantity);
                                    itemToAdd.SetPrice(itemPrice);
                                    itemToAdd.SetPriceTax(itemPriceTax);
                                    itemToAdd.SetItemTypeID(itemRetrieved.GetItemTypeeID());
                                    item.SetQuantity(itemQuantity);
                                    items.Add(item);
                                    int newItemQuantity = Convert.ToInt32(Convert.ToInt32(Connection.server.GetItemQuantity(currentBillRow.Cells["pendingPurchaseItemBarCode"].Value.ToString())) - Convert.ToInt32(currentBillRow.Cells["pendingPurchaseItemQuantity"].Value.ToString()));
                                    bool updatedQuantity = Connection.server.UpdateItemQuantity(new Item(currentBillRow.Cells["pendingPurchaseItemName"].Value.ToString(),
                                        currentBillRow.Cells["pendingPurchaseItemBarCode"].Value.ToString(), newItemQuantity, Convert.ToDecimal(currentBillRow.Cells["pendingPurchaseItemPrice"].Value.ToString()),
                                        Convert.ToDecimal(currentBillRow.Cells["pendingPurchaseItemPriceTax"].Value.ToString()), DateTime.Now));
                                }
                            }

                            Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, frmPayCash.discountedAmount, "Tax ID", items, frmPayCash.paybycash, DateTime.Now, this.cashierName);

                            billToAdd.ClientID = frmPickClientLookup.pickedClient.ClientID;
                            billToAdd.ClientName = frmPickClientLookup.pickedClient.ClientName;
                            billToAdd.ClientPhone = frmPickClientLookup.pickedClient.ClientPhone;
                            billToAdd.ClientAddress = frmPickClientLookup.pickedClient.ClientAddress;
                            billToAdd.ClientEmail = frmPickClientLookup.pickedClient.ClientEmail;
                            ;
                            if (Connection.server.PayBill(billToAdd, this.cashierName))
                            {
                                // paid bill

                                //printCertainReceipt(billToAdd);
                                CapitalAmountnud.Value = Connection.server.GetCapitalAmount();
                                label91.Text = this.CapitalAmount.ToString();

                                frmPayCash.Dispose();
                                this.ClientsaleItems.Clear();
                            }
                        }
                    }
                    else
                    {
                        processPayment();
                    }
                }
                else if (frmPayCash.dialogResult == DialogResult.Ignore)
                {
                    List<Item> items = new List<Item>();

                    frmPickClientLookup frmPickClientLookup = new frmPickClientLookup();
                    frmPickClientLookup.ShowDialog();

                    if (frmPickClientLookup.dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow currentBillRow in ItemsPendingPurchase.Rows)
                        {
                            if (!currentBillRow.IsNewRow)
                            {
                                string itemName = currentBillRow.Cells[0].Value.ToString();
                                string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                                int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                                decimal itemPrice = Convert.ToDecimal(currentBillRow.Cells[3].Value.ToString());
                                decimal itemPriceTax = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                                Item item = new Item();
                                item.SetName(itemName);
                                item.SetBarCode(itemBarCode);
                                item.SetQuantity(itemQuantity);
                                item.SetPrice(itemPrice);
                                item.SetPriceTax(itemPriceTax);
                                item.SetBuyPrice(Connection.server.SearchItems("", itemBarCode, 0).Item1[0].GetBuyPrice());
                                items.Add(item);
                            }
                        }

                        Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, frmPayCash.discountedAmount, "Tax ID", items, DateTime.Now);
                        billToAdd.ClientID = frmPickClientLookup.pickedClient.ClientID;
                        int UnpaidBillNumber = Connection.server.AddUnpaidBill(billToAdd, this.cashierName);
                        if (UnpaidBillNumber > -1)
                        {
                            this.CurrentBillNumber = Connection.server.RetrieveLastVendorBillNumberToday(DateTime.Now).getBillNumber() + 1;
                            this.ItemsList = DisplayData();
                            DisplayFavorites();
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MaterialMessageBox.Show(".تمت إضافة الفاتوره غير مدفوعه كدين على العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("A new unpaid bill was added as debt to the client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                        }
                        billToAdd.BillNumber = UnpaidBillNumber;
                    }

                    frmPayCash.Dispose();
                    this.ClientsaleItems.Clear();
                }

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;

                richTextBox5.ResetText();
                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                    richTextBox3.Text = (" :المجموع السابق " + this.totalAmount);
                    richTextBox2.Text = (" :المدفوع السابق " + this.paidAmount);
                    richTextBox1.Text = (" :الباقي السابق " + this.remainderAmount);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
                    richTextBox3.Text = (" Previous Total: " + this.totalAmount);
                    richTextBox2.Text = (" Previous Paid: " + this.paidAmount);
                    richTextBox1.Text = (" Previous Remainder: " + this.remainderAmount);
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

                int heldDebtBillsCount = Connection.server.RetrieveUnpaidBills().Item1.Count;

                if (heldDebtBillsCount > 0)
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

        public void label67_MouseClick(object sender, MouseEventArgs e)
        {
            processPayment();
        }

        public void label93_MouseClick(object sender, MouseEventArgs e)
        {
            if (userPermissions.Client_card_edit)
            {
                frmClientCard ClientCard = new frmClientCard();
                openedForm = ClientCard;
                ClientCard.ShowDialog();
                if (ClientCard.dialogResult == DialogResult.OK)
                {
                    this.currentClient = ClientCard.Client;
                    ClientName.Text = ClientCard.Client.ClientName;
                    ClientID.Value = ClientCard.Client.ClientID;

                    bool replaced = false;
                    foreach (Item item in ClientCard.saleItems)
                    {
                        for (int i = 0; i < this.ClientsaleItems.Count; i++)
                        {
                            if (ClientsaleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                            {
                                int index = ClientCard.saleItems.IndexOf(item);
                                this.ClientsaleItems[index] = item;
                                replaced = true;
                            }
                        }

                        if (!replaced)
                        {
                            this.ClientsaleItems.Add(item);
                        }
                    }

                    foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            if (ClientsaleItems.Count > 0)
                            {
                                for (int i = 0; i < ClientsaleItems.Count; i++)
                                {
                                    if (ClientsaleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                    {
                                        decimal priceAfterSales;
                                        decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                        if (ClientsaleItems[i].saleRate != 0)
                                            priceAfterSales = Convert.ToDecimal((ClientsaleItems[i].ClientPrice) * (ClientsaleItems[i].saleRate / 100));
                                        else priceAfterSales = Convert.ToDecimal(ClientsaleItems[i].ClientPrice);
                                        decimal marginPrice = previousPrice - priceAfterSales;
                                        this.totalAmount = this.totalAmount - marginPrice;
                                        item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                        richTextBox4.ResetText();
                                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                        {
                                            richTextBox4.Text = " :المجموع الكامل " + this.totalAmount;
                                        }
                                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                        {
                                            richTextBox4.Text = " Total: " + this.totalAmount;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    ClientCard.Dispose();
                    if (replaced)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Client Discount percentage was altered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".تم اضافة خصم العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Client Discount was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }


                }
                else if (ClientCard.dialogResult == DialogResult.None)
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
                    MaterialMessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("You cannot add a new Bill before filling the current Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
            else
            {
                List<Item> items = new List<Item>();
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
                        Item item = new Item();
                        item.SetName(itemName);
                        item.SetBarCode(itemBarCode);
                        item.SetQuantity(itemQuantity);
                        item.SetPrice(itemPrice);
                        item.SetPriceTax(itemPriceTax);
                        items.Add(item);
                    }
                }

                this.paidAmount = 0;
                this.moneyInRegister += 0;
                Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                Properties.Settings.Default.Save();
                this.remainderAmount = this.totalAmount - this.paidAmount;

                Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                previousBillsList.Push(billToAdd);

                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox2.ResetText();
                richTextBox1.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox3.Text = (" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.Text = (" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.Text = (" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox3.Text = (" Previous Total: " + previousBillsList.Peek().getTotalAmount().ToString());
                    richTextBox2.Text = (" Previous Paid: " + previousBillsList.Peek().getPaidAmount().ToString());
                    richTextBox1.Text = (" Previous Remainder: " + previousBillsList.Peek().getRemainderAmount().ToString());
                }

                ItemsPendingPurchase.Rows.Clear();
                this.ClientsaleItems.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;
                items = null;
                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
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
                                                richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                                            }
                                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                            {
                                                richTextBox4.Text = (" Total: " + this.totalAmount);
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
                                MaterialMessageBox.Show(".تعدلت نسبة خصم الأغراض", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Items Discount percentage was altered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MaterialMessageBox.Show(".تم اضافة الخصم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Discount was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".لم نتمكن من اضافة الخصم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to add a Discount.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.Text = (" Total: " + this.totalAmount);
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
                MaterialMessageBox.Show(e.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                    if (MaterialMessageBox.Show(" .لا يمكن شراء الماده بسبب نفاذ الكميه " + " اضافة ماده؟ ", false, FlexibleMaterialForm.ButtonsPosition.Center, MessageBoxButtons.OKCancel) == DialogResult.OK)
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

                            if (ClientsaleItems.Count > 0)
                            {
                                for (int i = 0; i < ClientsaleItems.Count; i++)
                                {
                                    if (ClientsaleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                    {
                                        priceAfterSales = ClientsaleItems[i].ClientPrice;
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
                                richTextBox6.Text = (" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox6.Text = (" Barcode: " + itemLookup.selectedItem.GetItemBarCode());
                            }
                        }
                        calculateStatistics();
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".لا يمكن اضافة الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Unable to add Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                this.moneyInRegister = Properties.Settings.Default.moneyInRegister;
                capital = Connection.server.GetCapitalAmount();
                CapitalAmountnud.Value = capital;
                CapitalAmount = capital;
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    processPayment();
                    break;

                case Keys.F2:
                    if (userPermissions.Client_card_edit)
                    {
                        frmClientCard ClientCard = new frmClientCard();
                        openedForm = ClientCard;
                        ClientCard.ShowDialog();
                        if (ClientCard.dialogResult == DialogResult.OK)
                        {
                            this.currentClient = ClientCard.Client;
                            ClientName.Text = ClientCard.Client.ClientName;
                            ClientID.Value = ClientCard.Client.ClientID;

                            bool replaced = false;
                            foreach (Item item in ClientCard.saleItems)
                            {
                                for (int i = 0; i < this.ClientsaleItems.Count; i++)
                                {
                                    if (ClientsaleItems[i].GetItemBarCode().Equals(item.GetItemBarCode()))
                                    {
                                        int index = ClientCard.saleItems.IndexOf(item);
                                        this.ClientsaleItems[index] = item;
                                        replaced = true;
                                    }
                                }

                                if (!replaced)
                                {
                                    this.ClientsaleItems.Add(item);
                                }
                            }

                            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                            {
                                if (!item.IsNewRow)
                                {
                                    if (ClientsaleItems.Count > 0)
                                    {
                                        for (int i = 0; i < ClientsaleItems.Count; i++)
                                        {
                                            if (ClientsaleItems[i].GetItemBarCode() == item.Cells["pendingPurchaseItemBarCode"].Value.ToString())
                                            {
                                                decimal priceAfterSales;
                                                decimal previousPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value.ToString());
                                                if (ClientsaleItems[i].saleRate != 0)
                                                    priceAfterSales = Convert.ToDecimal((ClientsaleItems[i].ClientPrice) * (ClientsaleItems[i].saleRate / 100));
                                                else priceAfterSales = Convert.ToDecimal(ClientsaleItems[i].ClientPrice);
                                                decimal marginPrice = previousPrice - priceAfterSales;
                                                this.totalAmount = this.totalAmount - marginPrice;
                                                item.Cells["pendingPurchaseItemPriceTax"].Value = priceAfterSales;
                                                richTextBox4.ResetText();
                                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                                {
                                                    richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                                                }
                                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                                {
                                                    richTextBox4.Text = (" Total: " + this.totalAmount);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            ClientCard.Dispose();
                            if (replaced)
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Client Items Discount was altered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                            }
                            else
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".تم اضافة خصم العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Client Discount was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                            }


                        }
                        else if (ClientCard.dialogResult == DialogResult.None)
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
                            MaterialMessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("You cannot add a new Bill before filling the current Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                    else
                    {
                        List<Item> items = new List<Item>();
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
                                Item item = new Item();
                                item.SetName(itemName);
                                item.SetBarCode(itemBarCode);
                                item.SetQuantity(itemQuantity);
                                item.SetPrice(itemPrice);
                                item.SetPriceTax(itemPriceTax);
                                items.Add(item);
                            }
                        }

                        this.paidAmount = 0;
                        this.moneyInRegister += 0;
                        Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                        Properties.Settings.Default.Save();
                        this.remainderAmount = this.totalAmount - this.paidAmount;

                        Bill billToAdd = new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, items, DateTime.Now);
                        previousBillsList.Push(billToAdd);

                        richTextBox4.ResetText();
                        richTextBox3.ResetText();
                        richTextBox2.ResetText();
                        richTextBox1.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox3.Text = (" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                            richTextBox2.Text = (" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                            richTextBox1.Text = (" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox3.Text = (" Previous Total: " + previousBillsList.Peek().getTotalAmount().ToString());
                            richTextBox2.Text = (" Previous Paid: " + previousBillsList.Peek().getPaidAmount().ToString());
                            richTextBox1.Text = (" Previous Remainder: " + previousBillsList.Peek().getRemainderAmount().ToString());
                        }

                        ItemsPendingPurchase.Rows.Clear();
                        this.ClientsaleItems.Clear();
                        this.totalAmount = 0;
                        this.paidAmount = 0;
                        this.remainderAmount = 0;
                        items = null;
                        this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                        richTextBox5.ResetText();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
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
                                                        richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                                                    }
                                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                                    {
                                                        richTextBox4.Text = (" Total: " + this.totalAmount);
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
                                        MaterialMessageBox.Show(".تعدلت نسبة خصم الأغراض", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        MaterialMessageBox.Show("Discount percentage was altered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                    }
                                }
                                else
                                {
                                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                    {
                                        MaterialMessageBox.Show(".تم اضافة الخصم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        MaterialMessageBox.Show("Discount was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                MaterialMessageBox.Show(".لم نتمكن من اضافة الخصم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Unable to add Discount.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox4.Text = (" Total: " + this.totalAmount);
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
                        MaterialMessageBox.Show(e.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    break;

                case Keys.F7:
                    try
                    {
                        if (previousBillsList.Count > 0)
                        {
                            List<Item> itemsBought = new List<Item>();
                            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                            {
                                if (!item.IsNewRow)
                                {
                                    string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                                    string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                                    int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                                    decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                                    decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                                    itemsBought.Add(new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                                    richTextBox1.ResetText();
                                    richTextBox2.ResetText();
                                    richTextBox3.ResetText();
                                }
                            }

                            nextBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                            ItemsPendingPurchase.Rows.Clear();
                            Bill bill = previousBillsList.Pop();
                            if (bill.BillNumber < 1)
                            {
                                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                            }
                            else
                            {
                                this.CurrentBillNumber = bill.getBillNumber();
                            }
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
                                MaterialMessageBox.Show(".لا بوجد شراء غير مكتمل سابق", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("There is no previous pending Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                            List<Item> itemsBought = new List<Item>();
                            foreach (DataGridViewRow item in ItemsPendingPurchase.Rows)
                            {
                                if (!item.IsNewRow)
                                {
                                    string itemName = item.Cells["pendingPurchaseItemName"].Value.ToString();
                                    string itemBarCode = item.Cells["pendingPurchaseItemBarCode"].Value.ToString();
                                    int itemQuantity = Convert.ToInt32(item.Cells["pendingPurchaseItemQuantity"].Value);
                                    decimal itemPrice = Convert.ToDecimal(item.Cells["pendingPurchaseItemPrice"].Value);
                                    decimal itemPriceTax = Convert.ToDecimal(item.Cells["pendingPurchaseItemPriceTax"].Value);

                                    itemsBought.Add(new Item(itemName, itemBarCode, itemQuantity, itemPrice, itemPriceTax, DateTime.Now));

                                    richTextBox1.ResetText();
                                    richTextBox2.ResetText();
                                    richTextBox3.ResetText();
                                }
                            }

                            previousBillsList.Push(new Bill(this.CurrentBillNumber, this.totalAmount, this.paidAmount, this.remainderAmount, itemsBought, DateTime.Now));
                            ItemsPendingPurchase.Rows.Clear();
                            Bill bill = nextBillsList.Pop();

                            if (bill.getBillNumber() < 1)
                            {
                                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                            }
                            else
                            {
                                this.CurrentBillNumber = bill.getBillNumber();
                            }

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
                                MaterialMessageBox.Show(".لا بوجد شراء غير مكتمل تالي", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("There is no next pending Bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                            if (MaterialMessageBox.Show(" .لا يمكن شراء الماده بسبب نفاذ الكميه " + " اضافة ماده؟ ", false, FlexibleMaterialForm.ButtonsPosition.Center, MessageBoxButtons.OKCancel) == DialogResult.OK)
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

                                    if (ClientsaleItems.Count > 0)
                                    {
                                        for (int i = 0; i < ClientsaleItems.Count; i++)
                                        {
                                            if (ClientsaleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                            {
                                                priceAfterSales = ClientsaleItems[i].ClientPrice;
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
                                        richTextBox6.Text = (" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                                    }
                                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                    {
                                        richTextBox6.Text = (" Barcode: " + itemLookup.selectedItem.GetItemBarCode());
                                    }

                                }
                                calculateStatistics();
                            }
                            catch (Exception ex)
                            {
                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لا يمكن اضافة الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("Unable to add Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                            pnlActionMenu.Enabled = true;
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
                                richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                                richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                                MaterialMessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox4.Text = (" Total: " + this.totalAmount);
                                richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
                                MaterialMessageBox.Show(String.Format("You have opened the cash register with an amount of {0} JOD.", moneyInRegister), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                pnlActionMenu.Enabled = false;
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
                                    MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }

                                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                                {
                                    MaterialMessageBox.Show(".لفد قمت باغلاق الصندوق", false, FlexibleMaterialForm.ButtonsPosition.Center);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    MaterialMessageBox.Show("You have closed the cash register.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        pnlActionMenu.Enabled = false;
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
                            MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".لفد قمت باغلاق الصندوق", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("You have closed the cash register.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    pnlActionMenu.Enabled = true;
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
                        richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                        richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        MaterialMessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), false, FlexibleMaterialForm.ButtonsPosition.Center);
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.Text = (" Total: " + this.totalAmount);
                        richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
                        MaterialMessageBox.Show(String.Format("You have opened the cash register with the amount {0} JOD.", moneyInRegister), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                            if (WarehouseEntryExitList.Text == "")
                            {
                                WarehouseEntryExitList.SelectedIndex = 0;
                            }
                            EntryExitItemBuyPrice.Value = itemLookup.selectedItem.ItemBuyPrice;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".لا يمكن اختيار الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Unable to pick Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                if (nudClientIDImportExport.Value == 0 || txtClientNameImportExport.Text.IsNullOrEmpty())
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialSkin.Controls.MaterialMessageBox.Show(".الرجاء إختيار العميل لإتمام الفاتوره الحاليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialSkin.Controls.MaterialMessageBox.Show("Please pick a client to commit the current bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    return;
                }
                List<Item> itemsToAdd = new List<Item>();

                this.totalVendorAmount = 0;

                foreach (DataGridViewRow currentBillRow in dvgEntryExitItems.Rows)
                {
                    if (!currentBillRow.IsNewRow)
                    {
                        if (currentBillRow.Cells[0].Value != null && currentBillRow.Cells[0].Value != DBNull.Value && !String.IsNullOrWhiteSpace(currentBillRow.Cells[0].Value.ToString()))
                        {
                            Item newItem = new Item();

                            string itemName = currentBillRow.Cells[0].Value.ToString();
                            string itemBarCode = currentBillRow.Cells[1].Value.ToString();
                            int itemQuantity = Convert.ToInt32(currentBillRow.Cells[2].Value.ToString());
                            decimal itemBuyPrice = Convert.ToDecimal(currentBillRow.Cells[4].Value.ToString());
                            int quantityWarning = Convert.ToInt32(currentBillRow.Cells[5].Value.ToString());
                            DateTime productionDate = Convert.ToDateTime(currentBillRow.Cells[6].Value.ToString());
                            DateTime expirationDate = Convert.ToDateTime(currentBillRow.Cells[7].Value.ToString());
                            DateTime entryDate = Convert.ToDateTime(currentBillRow.Cells[8].Value.ToString());

                            newItem.SetName(itemName);
                            newItem.SetBarCode(itemBarCode);
                            newItem.SetQuantity(itemQuantity);
                            newItem.SetBuyPrice(itemBuyPrice);
                            newItem.QuantityWarning = quantityWarning;
                            newItem.ProductionDate = productionDate;
                            newItem.ExpirationDate = expirationDate;
                            newItem.EntryDate = entryDate;

                            if (WarehouseEntryExitList.SelectedItem != null)
                            {
                                int WarehouseID = Connection.server.RetrieveWarehouseID(currentBillRow.Cells[3].Value.ToString());
                                newItem.SetWarehouseID(WarehouseID);
                            }
                            else newItem.SetWarehouseID(0);
                            this.totalVendorAmount += newItem.GetBuyPrice() * newItem.GetQuantity();
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
                        MaterialMessageBox.Show(".تم ادخال العمليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Transaction was submitted.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من ادخال العمليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to submit Transaction.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }

                if (nudClientIDImportExport.Value != 0 && txtClientNameImportExport.Text != "")
                {
                    Bill billToAdd = new Bill(this.CurrentVendorBillNumber, this.totalVendorAmount, itemsToAdd, DateTime.Now);
                    billToAdd.IsVendor = true;
                    billToAdd.ClientID = Convert.ToInt32(nudClientIDImportExport.Value);
                    if (Connection.server.AddVendorBill(billToAdd, this.cashierName) > -1)
                    {
                        this.totalVendorAmount = Connection.server.RetrieveLastVendorBillNumberToday(DateTime.Now).getBillNumber() + 1;
                        this.CurrentVendorBillNumber++;
                        this.ItemsList = DisplayData();
                        DisplayFavorites();
                        //dgvVendorItemsPick.DataSource = new DataTable();
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".تمت اضافة الفاتوره للمورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            dvgEntryExitItems.Rows.Clear();
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("A new Importer Bill was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            dvgEntryExitItems.Rows.Clear();
                        }
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".الرجاء إختيار مورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Please pick an Importer.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من اتمام العمليه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to commit Transaction.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".الاضافه فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Management can only be done by Administrator Accounts.", this.ProductName);
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
                        MaterialMessageBox.Show(".تم تسجيل الموظف", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Employee was registered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }

                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تسجيل الموظف", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to register Employee.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Management can only be done through Administrator Accounts.", this.ProductName);
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
                        MaterialMessageBox.Show(".لا يمكن حذف الموظف", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to delete Employee.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".الرجاء ادخال جميع البيانات!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please fill all required data!", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".الإضافه فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Management can only be done through Administrator Accounts.", this.ProductName);
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
                            MaterialMessageBox.Show(".تم تسجيل الغياب", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("An absence was recorded.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }

                    }
                    else
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".لم نتمكن من تسجيل الغياب", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Unable to record Absence.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".تم تسجيل الغياب", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("An Absence was recorded.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Management can only be done through Administrator Accounts.", this.ProductName);
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
                        MaterialMessageBox.Show(".لا يمكن حذف الغياب", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to delete Absence.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Management can only be done through Administrative Accounts.", this.ProductName);
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
                        MaterialMessageBox.Show(".لا يمكن حذف الغياب", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to delete Absence.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".لم نستطيع حذف الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to delete Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

        private void فاتحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.materialSkinManager = MaterialSkinManager.Instance;
            Program.materialSkinManager.EnforceBackcolorOnAllComponents = false; ;

            Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            if (Properties.Settings.Default.TextShade == "BLACK")
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.BLACK);
            else
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.WHITE);
            Properties.Settings.Default.pickedThemeScheme = 0;
            Properties.Settings.Default.Save();
            مظلمToolStripMenuItem.Checked = false;
            فاتحToolStripMenuItem.Checked = true;
            switchThemeScheme.Checked = false;
            Application.Restart();
        }

        private void مظلمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.materialSkinManager = MaterialSkinManager.Instance;
            Program.materialSkinManager.EnforceBackcolorOnAllComponents = false; ;

            Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            if (Properties.Settings.Default.darkTextShade == "BLACK")
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.BLACK);
            else
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.WHITE);
            Properties.Settings.Default.pickedThemeScheme = 1;
            Properties.Settings.Default.Save();
            مظلمToolStripMenuItem.Checked = true;
            فاتحToolStripMenuItem.Checked = false;
            switchThemeScheme.Checked = true;
            Application.Restart();
        }

        private void DarkPrimaryColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(DarkPrimaryColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                DarkPrimaryColor.Text = frmColorPicker.hexColor;
            }
        }

        private void DarkPrimaryDarkColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(DarkPrimaryDarkColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                DarkPrimaryDarkColor.Text = frmColorPicker.hexColor;
            }
        }

        private void DarkPrimaryLightColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(DarkPrimaryLightColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                DarkPrimaryLightColor.Text = frmColorPicker.hexColor;
            }
        }

        private void DarkAccentColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(DarkAccentColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                DarkAccentColor.Text = frmColorPicker.hexColor;
            }
        }

        private void PrimaryColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(PrimaryColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                PrimaryColor.Text = frmColorPicker.hexColor;
            }
        }

        private void PrimaryDarkColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(PrimaryDarkColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                PrimaryDarkColor.Text = frmColorPicker.hexColor;
            }
        }

        private void PrimaryLightColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(PrimaryLightColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                PrimaryLightColor.Text = frmColorPicker.hexColor;
            }
        }

        private void AccentColor_Click(object sender, EventArgs e)
        {
            frmColorPicker frmColorPicker = new frmColorPicker(AccentColor.Text);
            frmColorPicker.ShowDialog();
            if (frmColorPicker.colorDialogResult == DialogResult.OK)
            {
                AccentColor.Text = frmColorPicker.hexColor;
            }
        }

        private void DarkPrimaryColor_TextChanged(object sender, EventArgs e)
        {
            DarkPrimaryColorPanel.BackColor = ColorTranslator.FromHtml(DarkPrimaryColor.Text);
        }

        private void DarkPrimaryDarkColor_TextChanged(object sender, EventArgs e)
        {
            DarkPrimaryDarkColorPanel.BackColor = ColorTranslator.FromHtml(DarkPrimaryDarkColor.Text);
        }

        private void DarkPrimaryLightColor_TextChanged(object sender, EventArgs e)
        {
            DarkPrimaryLightColorPanel.BackColor = ColorTranslator.FromHtml(DarkPrimaryLightColor.Text);
        }

        private void DarkAccentColor_TextChanged(object sender, EventArgs e)
        {
            DarkAccentColorPanel.BackColor = ColorTranslator.FromHtml(DarkAccentColor.Text);
        }

        private void PrimaryColor_TextChanged(object sender, EventArgs e)
        {
            PrimaryColorPanel.BackColor = ColorTranslator.FromHtml(PrimaryColor.Text);
        }

        private void PrimaryDarkColor_TextChanged(object sender, EventArgs e)
        {
            PrimaryDarkColorPanel.BackColor = ColorTranslator.FromHtml(PrimaryDarkColor.Text);
        }

        private void PrimaryLightColor_TextChanged(object sender, EventArgs e)
        {
            PrimaryLightColorPanel.BackColor = ColorTranslator.FromHtml(PrimaryLightColor.Text);
        }

        private void AccentColor_TextChanged(object sender, EventArgs e)
        {
            AccentColorPanel.BackColor = ColorTranslator.FromHtml(AccentColor.Text);
        }

        private void btnPickClientForImportExport_Click(object sender, EventArgs e)
        {
            try
            {
                frmPickClientLookup pickClient = new frmPickClientLookup();
                openedForm = pickClient;
                pickClient.ShowDialog();

                if (pickClient.pickedClient.ClientName != null)
                {
                    DataTable pickedClient = Connection.server.SearchClientsInfo(pickClient.pickedClient.ClientName, Convert.ToString(pickClient.pickedClient.ClientID));
                    txtClientNameImportExport.Text = pickedClient.Rows[0]["Client Name"].ToString();
                    nudClientIDImportExport.Value = Convert.ToInt32(pickedClient.Rows[0]["Client ID"].ToString());
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نستطع اختيار العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to pick Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        private void selectAllClients_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllClients.Checked)
            {
                dgvClients.SelectAll();
            } else
            {
                dgvClients.ClearSelection();
            }
        }

        private void btnPayDebtBill_Click(object sender, EventArgs e)
        {
            if (!registerOpen)
            {
                if(frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".يجب أن يكون الصندوق مفتوح لدفع فاتورة دين", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    return;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Cash register must be open to pay a debt bill.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    return;
                }
            }

            if (dgvClientBills.SelectedRows.Count > 0)
            {
                var selectedRows = dgvClientBills.SelectedRows
                    .OfType<DataGridViewRow>()
                    .Where(row => !row.IsNewRow)
                    .ToArray();

                foreach (var row in selectedRows)
                {
                    if (row.Cells["Column4"].Value.ToString() == "Paid")
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".هذه الفاتوره مدفوعه مسبقا", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            continue;
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("This Bill is already paid.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            continue;
                        }
                    }
                    if (row.Cells["Column4"].Value.ToString() == "Completely Refunded")
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".هذه الفاتوره مرجوعه بالكامل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            continue;
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("This Bill is completely refunded.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            continue;
                        }
                    }
                    Bill billPaid = Connection.server.SearchBills("", "", Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn24"].Value.ToString())).Item1[0];
                    frmPay frmPayCash = new frmPay(((billPaid.TotalAmount - billPaid.DiscountAmount) - billPaid.PaidAmount), Convert.ToDecimal(row.Cells["ClientBillsPaidAmount"].Value.ToString()), Convert.ToDecimal(row.Cells["ClientBillsRemainderAmount"].Value.ToString()), true, true);
                    openedForm = frmPayCash;
                    frmPayCash.ShowDialog();

                    List<Item> itemsInBill = new List<Item>();

                    for (int i = 0; i < dgvClientBillItems.Rows.Count; i++)
                    {
                        Item SearchedItem = Connection.server.SearchItems("", dgvClientBillItems.Rows[i].Cells["dataGridViewTextBoxColumn21"].Value.ToString(), 0).Item1[0];
                        SearchedItem.SetQuantity(Connection.server.RetrieveBillSoldBItemQuantity(billPaid.getBillNumber(), SearchedItem.GetItemBarCode()));
                        itemsInBill.Add(SearchedItem);
                    }
                    billPaid.ItemsBought = itemsInBill;

                    if (frmPayCash.dialogResult == DialogResult.OK)
                    {
                        if (Connection.server.PayUnpaidBill(Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn24"].Value.ToString()), frmPayCash.paidAmount))
                        {
                            billPaid = Connection.server.SearchBills("", "", Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn24"].Value.ToString())).Item1[0];
                            billPaid.ItemsBought = itemsInBill;
                            if (frmPayCash.paidAmount <= frmPayCash.totalAmount)
                            {
                                this.moneyInRegister += frmPayCash.paidAmount;
                            } else
                            {
                                this.moneyInRegister += frmPayCash.totalAmount;
                            }

                            Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                            Properties.Settings.Default.Save();
                            printCertainReceipt(billPaid);

                            CapitalAmountnud.Value = Connection.server.GetCapitalAmount();
                            label91.Text = this.CapitalAmount.ToString();

                            this.ClientsaleItems.Clear();

                            ItemsPendingPurchase.Rows.Clear();
                            this.totalAmount = 0;
                            this.paidAmount = 0;
                            this.remainderAmount = 0;
                        }
                    }
                    else if (frmPayCash.dialogResult == DialogResult.Cancel)
                    {

                    }
                }
            }

            int Index = dgvClients.CurrentCell.RowIndex;
            string clientName = dgvClients.Rows[Index].Cells["Column27"].Value.ToString();
            int clientID = Convert.ToInt32(dgvClients.Rows[Index].Cells["ClientIDDelete"].Value.ToString());

            DisplayClientBills(clientID);
            dgvClientBills.ClearSelection();
        }

        private void dgvClientBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvClientBillItems.DataSource = Connection.server.RetrieveBillItems(Convert.ToInt32(dgvClientBills.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn24"].Value.ToString())).Item2;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn20"].HeaderText = "إسم المادة";
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn21"].HeaderText = "باركود الماده";
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn22"].HeaderText = "عدد البيع";
                dgvClientBillItems.Columns["Column66"].HeaderText = "عدد المرجعات";
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn23"].HeaderText = "سعر البيع بعد الضريبه";
                dgvClientBillItems.Columns["Column68"].HeaderText = "سعر الشراء ";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn20"].HeaderText = "Item Name";
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn21"].HeaderText = "Item Barcode";
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn22"].HeaderText = "Sold Quantity";
                dgvClientBillItems.Columns["Column66"].HeaderText = "Returned Quantity";
                dgvClientBillItems.Columns["dataGridViewTextBoxColumn23"].HeaderText = "Sell Price Tax";
                dgvClientBillItems.Columns["Column68"].HeaderText = "Buy Price";
            }
        }

        private void lblHamburger_Click(object sender, EventArgs e)
        {
            CollapseSideMenu();
        }

        private void btnMenuCash_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Cash"];
        }

        private void btnMenuSales_Click(object sender, EventArgs e)
        {
            hamburger_menu_sales_sub_timer.Start();
        }

        private void btnClientBalanceCheck_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl3.SelectedTab = tabControl3.TabPages["ClientBalanceCheck"];
                int Index = dgvClients.CurrentCell.RowIndex;
                string clientName = dgvClients.Rows[Index].Cells["Column27"].Value.ToString();
                int clientID = Convert.ToInt32(dgvClients.Rows[Index].Cells["ClientIDDelete"].Value.ToString());

                DisplayClientBills(clientID);
                for (int i = 0; i < dgvVendorBills.Rows.Count; i++)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvClientBills.DataSource];
                    currencyManager1.SuspendBinding();
                    dgvClientBills.Rows[i].Selected = true;
                    dgvClientBills.Rows[i].Visible = true;
                    currencyManager1.ResumeBinding();
                }
                dgvClientBills.Refresh();

                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    dgvClientBills.Columns["dataGridViewTextBoxColumn24"].HeaderText = "رقم الغاتوره";
                    dgvClientBills.Columns["dataGridViewTextBoxColumn29"].HeaderText = "إسم الكاشير";
                    dgvClientBills.Columns["dataGridViewTextBoxColumn30"].HeaderText = "المبلغ قبل الخصم";
                    dgvClientBills.Columns["Column72"].HeaderText = "قيمة الخصم";
                    dgvClientBills.Columns["DiscountedAmount"].HeaderText = "المبلغ الصافي";
                    dgvClientBills.Columns["dataGridViewTextBoxColumn31"].HeaderText = "التاريخ";
                    dgvClientBills.Columns["Column4"].HeaderText = "الحاله";
                    dgvClientBills.Columns["Column6"].HeaderText = "رقم العميل";
                    dgvClientBills.Columns["Column8"].HeaderText = "إسم العميل";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    dgvClientBills.Columns["dataGridViewTextBoxColumn24"].HeaderText = "Bill ID";
                    dgvClientBills.Columns["dataGridViewTextBoxColumn29"].HeaderText = "Cashier Name";
                    dgvClientBills.Columns["dataGridViewTextBoxColumn30"].HeaderText = "Total Before Discount";
                    dgvClientBills.Columns["Column72"].HeaderText = "Discount Amount";
                    dgvClientBills.Columns["DiscountedAmount"].HeaderText = "Net Total";
                    dgvClientBills.Columns["dataGridViewTextBoxColumn31"].HeaderText = "Date";
                    dgvClientBills.Columns["Column4"].HeaderText = "Status";
                    dgvClientBills.Columns["Column6"].HeaderText = "Client ID";
                    dgvClientBills.Columns["Column8"].HeaderText = "Client Name";
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".الرجاء إختيار عميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please pick a Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        public void FavoriteCategoryInsert()
        {
            if (FavoriteCategoryEntry.Text.Trim().Length > 0)
            {
                bool addedFavoriteCategory = Connection.server.InsertFavoriteCategory(FavoriteCategoryEntry.Text);
                if (addedFavoriteCategory)
                {
                    DisplayFavorites();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حفظ مجلد المفضلات الجديد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Favorite Category was saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
        }

        private void pnlMenu_Click(object sender, EventArgs e)
        {
            CollapseSideMenu();
        }

        private void LoadMenu()
        {
            if (Properties.Settings.Default.sideMenuExpanded == false)
            {
                pnlMenu.Width = 15;

            }
            else
            {
                pnlMenu.Width = 250;
            }
        }

        private void CollapseSideMenu()
        {
            if (Properties.Settings.Default.sideMenuExpanded == true)
            {
                Properties.Settings.Default.sideMenuExpanded = false;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.sideMenuExpanded = true;
                Properties.Settings.Default.Save();
            }
            LoadMenu();
        }

        private void CollapseActionMenu()
        {
            if (Properties.Settings.Default.actionMenuExpanded == true)
            {
                Properties.Settings.Default.actionMenuExpanded = false;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.actionMenuExpanded = true;
                Properties.Settings.Default.Save();
            }
            LoadActionMenu();
        }

        private void LoadActionMenu()
        {
            if (Properties.Settings.Default.actionMenuExpanded == false)
            {
                pnlActionMenu.Width = 10;
                // pnlActionMenu.FlowDirection = FlowDirection.TopDown;

            }
            else
            {
                //pnlActionMenu.FlowDirection = FlowDirection.RightToLeft;
                pnlActionMenu.Width = 270;
            }
        }

        private void btnMenuSalesSubEditInvoices_Click(object sender, EventArgs e)
        {
            tabControl4.SelectedTab = tabControl4.TabPages["EditInvoices"];
            tabControl1.SelectedTab = tabControl1.TabPages["Sales"];
        }

        private void btnMenuSalesSubTravelingUntravelingSales_Click(object sender, EventArgs e)
        {
            tabControl4.SelectedTab = tabControl4.TabPages["TravelingUntravelingSales"];
            tabControl1.SelectedTab = tabControl1.TabPages["Sales"];
        }

        private void btnMenuSalesSubSoldItems_Click(object sender, EventArgs e)
        {
            tabControl4.SelectedTab = tabControl4.TabPages["SoldItems"];
            tabControl1.SelectedTab = tabControl1.TabPages["Sales"];
        }

        private void btnMenuInventory_Click(object sender, EventArgs e)
        {
            hamburger_menu_inventory_sub_timer.Start();
        }

        private void btnMenuInventorySubInventory_Click(object sender, EventArgs e)
        {
            tabControl6.SelectedTab = tabControl6.TabPages["posInventory"];
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
        }

        private void btnMenuInventorySubItemsQuantify_Click(object sender, EventArgs e)
        {
            tabControl6.SelectedTab = tabControl6.TabPages["InventoryQuantify"];
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
        }

        private void btnMenuInventorySubIncomingOutgoingItems_Click(object sender, EventArgs e)
        {
            tabControl6.SelectedTab = tabControl6.TabPages["IncomingOutgoingItems"];
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
        }

        private void btnMenuInventorySubAddItemTypes_Click(object sender, EventArgs e)
        {
            tabControl6.SelectedTab = tabControl6.TabPages["AddTypes"];
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
        }

        private void btnMenuInventorySubAddFavorites_Click(object sender, EventArgs e)
        {
            tabControl6.SelectedTab = tabControl6.TabPages["AddFavorites"];
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
        }

        private void btnMenuInventorySubAddWarehouses_Click(object sender, EventArgs e)
        {
            tabControl6.SelectedTab = tabControl6.TabPages["AddWarehouses"];
            tabControl1.SelectedTab = tabControl1.TabPages["Inventory"];
        }

        private void btnMenuExpenses_Click(object sender, EventArgs e)
        {
            hamburger_menu_expenses_sub_timer.Start();
        }

        private void btnMenuExpensesSubSearchExpenses_Click(object sender, EventArgs e)
        {
            tabControl5.SelectedTab = tabControl5.TabPages["SearchExpenses"];
            tabControl1.SelectedTab = tabControl1.TabPages["Expenses"];
        }

        private void btnMenuExpensesSubAddExpense_Click(object sender, EventArgs e)
        {
            tabControl5.SelectedTab = tabControl5.TabPages["AddExpenses"];
            tabControl1.SelectedTab = tabControl1.TabPages["Expenses"];
        }

        private void btnMenuIncomingOutgoing_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["IncomingOutgoing"];
        }

        private void btnMenuEmployeesAffairs_Click(object sender, EventArgs e)
        {
            hamburger_menu_employees_affairs_sub_timer.Start();
        }

        private void btnMenuEmployeesAffairsSubEmployeesManagement_Click(object sender, EventArgs e)
        {
            tabControl8.SelectedTab = tabControl8.TabPages["EmployeesManagement"];
            tabControl1.SelectedTab = tabControl1.TabPages["Employees"];
        }

        private void btnMenuEmployeesAffairsSubDaysOff_Click(object sender, EventArgs e)
        {
            tabControl8.SelectedTab = tabControl8.TabPages["DaysOff"];
            tabControl1.SelectedTab = tabControl1.TabPages["Employees"];
        }

        private void btnMenuClientsVendors_Click(object sender, EventArgs e)
        {
            hamburger_menu_clients_affairs_sub_timer.Start();
        }

        private void btnMenuClientsVendorsSubClientsDefinitions_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabControl3.TabPages["AgentsDefinitions"];
            tabControl1.SelectedTab = tabControl1.TabPages["Agents"];
        }

        private void btnMenuClientsVendorsSubClientsBalanceCheck_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabControl3.TabPages["ClientBalanceCheck"];
            tabControl1.SelectedTab = tabControl1.TabPages["Agents"];
        }

        private void btnMenuClientsVendorsSubVendorsDefinitions_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabControl3.TabPages["ImporterDefinitions"];
            tabControl1.SelectedTab = tabControl1.TabPages["Agents"];
        }

        private void btnMenuAlerts_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Alerts"];
        }

        private void btnMenuTaxes_Click(object sender, EventArgs e)
        {
            hamburger_menu_taxes_sub_timer.Start();
        }

        private void btnMenuTaxesSubTaxZReport_Click(object sender, EventArgs e)
        {
            tabControl7.SelectedTab = tabControl7.TabPages["TaxZReport"];
            tabControl1.SelectedTab = tabControl1.TabPages["Taxes"];
        }

        private void btnMenuUsers_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["posUsers"];
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            hamburger_menu_settings_sub_timer.Start();
        }

        private void btnMenuSettingsSubPOSSettings_Click(object sender, EventArgs e)
        {
            tabControl9.SelectedTab = tabControl9.TabPages["posSettings"];
            tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
        }

        private void hamburger_menu_clients_affairs_sub_timer_Tick_1(object sender, EventArgs e)
        {
            if (menuClientAffairsSubExpand)
            {
                pnlMenuClientAffairsSub.Height -= 10;

                if (pnlMenuClientAffairsSub.Height == pnlMenuClientAffairsSub.MinimumSize.Height)
                {
                    menuClientAffairsSubExpand = false;
                    hamburger_menu_clients_affairs_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuClientAffairsSub.Height += 10;
                if (pnlMenuClientAffairsSub.Height == pnlMenuClientAffairsSub.MaximumSize.Height)
                {
                    menuClientAffairsSubExpand = true;
                    hamburger_menu_clients_affairs_sub_timer.Stop();
                }
            }
        }

        private void hamburger_menu_taxes_sub_timer_Tick_1(object sender, EventArgs e)
        {
            if (menuTaxesSubExpand)
            {
                pnlMenuTaxesSub.Height -= 10;

                if (pnlMenuTaxesSub.Height == pnlMenuTaxesSub.MinimumSize.Height)
                {
                    menuTaxesSubExpand = false;
                    hamburger_menu_taxes_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuTaxesSub.Height += 10;
                if (pnlMenuTaxesSub.Height == pnlMenuTaxesSub.MaximumSize.Height)
                {
                    menuTaxesSubExpand = true;
                    hamburger_menu_taxes_sub_timer.Stop();
                }
            }
        }

        private void hamburger_menu_settings_sub_timer_Tick_1(object sender, EventArgs e)
        {
            if (menuSettingsSubExpand)
            {
                pnlMenuSettingsSub.Height -= 10;

                if (pnlMenuSettingsSub.Height == pnlMenuSettingsSub.MinimumSize.Height)
                {
                    menuSettingsSubExpand = false;
                    hamburger_menu_settings_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuSettingsSub.Height += 10;
                if (pnlMenuSettingsSub.Height == pnlMenuSettingsSub.MaximumSize.Height)
                {
                    menuSettingsSubExpand = true;
                    hamburger_menu_settings_sub_timer.Stop();
                }
            }
        }

        private void btnMenuSettingsSubPrinterSettings_Click(object sender, EventArgs e)
        {
            tabControl9.SelectedTab = tabControl9.TabPages["printersSettings"];
            tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
        }

        private void btnMenuRefunds_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Retrievals"];
        }

        private void selectAllVendors_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllVendors.Checked)
            {
                dgvVendors.SelectAll();
            }
            else
            {
                dgvVendors.ClearSelection();
            }
        }

        private void btnClientVendorItemsPriceClient_Click(object sender, EventArgs e)
        {
            try
            {
                frmPickClientLookup pickClient = new frmPickClientLookup();
                openedForm = pickClient;
                pickClient.ShowDialog();

                if (pickClient.pickedClient.ClientName != null)
                {
                    DataTable pickedClient = Connection.server.SearchClientsInfo(pickClient.pickedClient.ClientName, Convert.ToString(pickClient.pickedClient.ClientID));
                    txtClientNameImportExport.Text = pickedClient.Rows[0]["Client Name"].ToString();
                    nudClientIDImportExport.Value = Convert.ToInt32(pickedClient.Rows[0]["Client ID"].ToString());
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نستطع اختيار العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to pick Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        private void btnClientVendorItemsPickClientItem_Click(object sender, EventArgs e)
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
                            MaterialMessageBox.Show(".لا يمكن اختيار الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Unable to pick Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        private void pnlActionMenu_Click(object sender, EventArgs e)
        {
            CollapseActionMenu();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClientDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl3.SelectedTab = tabControl3.TabPages["ClientBalanceCheck"];
                int Index = dgvClients.CurrentCell.RowIndex;
                string clientName = dgvClients.Rows[Index].Cells["Column27"].Value.ToString();
                int clientID = Convert.ToInt32(dgvClients.Rows[Index].Cells["ClientIDDelete"].Value.ToString());

                if (Connection.server.DeleteClient(clientID.ToString()))
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حذف العميل بنجاح", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Client was deleted successfully.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception exc)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نستطع حذف العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("We were unable to delete the client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        private void hamburger_menu_employees_affairs_sub_timer_Tick(object sender, EventArgs e)
        {
            if (menuEmployeesAffairsSubExpand)
            {
                pnlMenuEmployeesAffairsSub.Height -= 10;

                if (pnlMenuEmployeesAffairsSub.Height == pnlMenuEmployeesAffairsSub.MinimumSize.Height)
                {
                    menuEmployeesAffairsSubExpand = false;
                    hamburger_menu_employees_affairs_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuEmployeesAffairsSub.Height += 10;
                if (pnlMenuEmployeesAffairsSub.Height == pnlMenuEmployeesAffairsSub.MaximumSize.Height)
                {
                    menuEmployeesAffairsSubExpand = true;
                    hamburger_menu_employees_affairs_sub_timer.Stop();
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.materialSkinManager.RemoveFormToManage(this);
        }

        private void ItemTypeAddButton_Click(object sender, EventArgs e)
        {
            ItemTypeInsert();
        }

        private void FavoriteCategoryAddButton_Click(object sender, EventArgs e)
        {
            FavoriteCategoryInsert();
        }

        private void WarehouseAddButton_Click(object sender, EventArgs e)
        {
            WarehouseInsert();
        }

        private void WarehouseInsertKeyPress(object sender, KeyPressEventArgs e)
        {
            WarehouseInsert();
        }

        private void hamburger_menu_expenses_sub_timer_Tick(object sender, EventArgs e)
        {
            if (menuExpensesSubExpand)
            {
                pnlMenuExpensesSub.Height -= 10;

                if (pnlMenuExpensesSub.Height == pnlMenuExpensesSub.MinimumSize.Height)
                {
                    menuExpensesSubExpand = false;
                    hamburger_menu_expenses_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuExpensesSub.Height += 10;
                if (pnlMenuExpensesSub.Height == pnlMenuExpensesSub.MaximumSize.Height)
                {
                    menuExpensesSubExpand = true;
                    hamburger_menu_expenses_sub_timer.Stop();
                }
            }
        }

        private void btnPrintClientBills_Click(object sender, EventArgs e)
        {
            Bill billPaid = Connection.server.SearchBills("", "", Convert.ToInt32(dgvClientBills.SelectedRows[0].Cells["dataGridViewTextBoxColumn24"].Value.ToString())).Item1[0];
            List<Item> itemsInBill = new List<Item>();

            for (int i = 0; i < dgvClientBillItems.Rows.Count; i++)
            {
                Item SearchedItem = Connection.server.SearchItems("", dgvClientBillItems.Rows[i].Cells["dataGridViewTextBoxColumn21"].Value.ToString(), 0).Item1[0];
                SearchedItem.SetQuantity(Connection.server.RetrieveBillSoldBItemQuantity(billPaid.getBillNumber(), SearchedItem.GetItemBarCode()));
                itemsInBill.Add(SearchedItem);
            }
            billPaid.ItemsBought = itemsInBill;
            printCertainReceipt(billPaid, true);
        }

        private void printCloseCashReport_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                DataTable dt = Connection.server.RetrieveSystemSettings();

                Font minifont = new Font("Arial", 5);
                Font itemfont = new Font("Arial", 6);
                Font smallfont = new Font("Arial", 8);
                Font mediumfont = new Font("Arial", 10);
                Font largefont = new Font("Arial", 12);

                Font fontRegular = new Font("Arial", 10);
                Font fontBold = new Font("Arial", 12, FontStyle.Bold);

                int imgHeight = 1200; // generous height, we'll crop later   
                imgHeight += picLogo.Height;
                imgHeight += lineHeight;

                using (Bitmap bmp = new Bitmap(width, imgHeight))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    int y = padding;

                    if (this.IncludeLogoInReceipt)
                    {
                        y = DrawImage(g, picLogo.Image, y);
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, "تقرير اغلاق الصندوق", y, fontBold);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Cash Close Report", y, fontBold);
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y += DrawRightAndLeftUnbordered(g, Connection.server.GetLastOpenRegisterDate() + " تاريخ الفتح ", Connection.server.GetLastOpenRegisterDate() + " تاريخ الإغلاق ", y, fontRegular);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y += DrawRightAndLeftUnbordered(g, "Open Date: " + Connection.server.GetLastOpenRegisterDate(), "Close Date: " + DateTime.Now.ToShortDateString(), y, fontRegular);
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, this.cashierName + " إسم الكاشير: ", y, fontRegular);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, " Cashier Name: " + this.cashierName, y, fontRegular);
                    }

                    decimal openRegisterAmount = Connection.server.GetOpenRegisterAmount();
                    decimal totalSalesAmount = Connection.server.GetTotalSalesAmount();

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, openRegisterAmount.ToString() + " أرضية الكاش ", y, fontRegular);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Cash Opening Value: " + openRegisterAmount.ToString(), y, fontRegular);
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, moneyInRegister.ToString() + " المبلغ المحصل ", y, fontRegular);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Amount Collected: " + moneyInRegister.ToString(), y, fontRegular);
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, totalSalesAmount.ToString() + " صافي مبلغ المبيعات ", y, fontRegular);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Net Sales Amount: " + totalSalesAmount.ToString(), y, fontRegular);
                    }

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        y = DrawCenteredText(g, Convert.ToDecimal(openRegisterAmount + totalSalesAmount).ToString() + " المجموع الكلي ", y, fontBold);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        y = DrawCenteredText(g, "Total Cash in Register: " + Convert.ToDecimal(openRegisterAmount + totalSalesAmount).ToString(), y, fontBold);
                    }

                    // Crop and save
                    int cropHeight = Math.Min(y + padding, imgHeight);
                    using (Bitmap cropped = bmp.Clone(new Rectangle(0, 0, width, cropHeight), bmp.PixelFormat))
                    {
                        try
                        {
                            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Cash Close Reports");
                        }
                        catch (Exception error) { }
                        try
                        {
                            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Cash Close Reports\\" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day);
                        }
                        catch (Exception error) { }

                        // Draw the bitmap onto the printer graphics at the top-left corner
                        e.Graphics.DrawImage(cropped, 0, 0, width, cropHeight);
                        
                        cropped.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Cash Close Reports\\"  + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "\\" + "Cash Close Report " + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " " + DateTime.Today.Hour +
                                "-" + DateTime.Today.Minute + "-" + DateTime.Today.Second + "-" + DateTime.Today.Millisecond + ".png", ImageFormat.Png);
                    }
                }
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من طباعة تقرير غلق الكاش", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to print Cash Close Report.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        private void btnClientEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentClientID == -1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (ClientName.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update new Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (ClientPhone.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update new Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (ClientAddress.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update new Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (ClientEmail.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update new Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }

                if (Connection.server.UpdateClientVendor(new Client(ClientName.Text, CurrentClientID, ClientPhone.Text, ClientAddress.Text, ClientEmail.Text)))
                {
                    CurrentClientID = -1;
                    ClientName.Text = "";
                    ClientID.Value = 0;
                    ClientPhone.Text = "";
                    ClientAddress.Text = "";
                    ClientEmail.Text = "";


                    DataTable retrievedClients = Connection.server.GetRetrieveClients();

                    dgvClients.DataSource = retrievedClients;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تمت اضافة العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("The Client was updated.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل العميل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update new Client.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception error)
            { }
        }

        private void dgvClients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                CurrentClientID = Convert.ToInt32(dgvClients.Rows[e.RowIndex].Cells["ClientIDDelete"].Value.ToString());
                ClientName.Text = dgvClients.Rows[e.RowIndex].Cells["Column27"].Value.ToString();
                ClientPhone.Text = dgvClients.Rows[e.RowIndex].Cells["Column38"].Value.ToString();
                ClientAddress.Text = dgvClients.Rows[e.RowIndex].Cells["Column39"].Value.ToString();
                ClientEmail.Text = dgvClients.Rows[e.RowIndex].Cells["Column10"].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void dgvVendors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                CurrentVendorID = Convert.ToInt32(dgvVendors.Rows[e.RowIndex].Cells["VendorClientID"].Value.ToString());
                VendorName.Text = dgvVendors.Rows[e.RowIndex].Cells["VendorClientName"].Value.ToString();
                VendorPhone.Text = dgvVendors.Rows[e.RowIndex].Cells["VendorClientPhone"].Value.ToString();
                VendorAddress.Text = dgvVendors.Rows[e.RowIndex].Cells["VendorClientAddress"].Value.ToString();
                VendorEmail.Text = dgvVendors.Rows[e.RowIndex].Cells["Column11"].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentVendorID == -1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Vendor.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (VendorName.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Vendor.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (VendorPhone.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Vendor.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (VendorAddress.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Vendor.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }
                if (VendorEmail.Text.Trim().Length < 1)
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Vendor.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        return;
                    }
                }

                if (Connection.server.UpdateClientVendor(new Client(VendorName.Text, CurrentVendorID, VendorPhone.Text, VendorAddress.Text, VendorEmail.Text)))
                {
                    CurrentVendorID = -1;
                    VendorName.Text = "";
                    VendorID.Value = 0;
                    VendorPhone.Text = "";
                    VendorAddress.Text = "";
                    VendorEmail.Text = "";


                    DataTable retrievedVendors = Connection.server.GetRetrieveVendors();

                    dgvVendors.DataSource = retrievedVendors;

                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("The Vendor was updated.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تعديل المورد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to update Vendor.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception error)
            { }
        }

        private void btnMenuClientsVendorsSubVendoItemsDefinitions_Click(object sender, EventArgs e)
        {
            //tabControl3.SelectedTab = tabControl3.TabPages["AgentsItemsDefinitions"];
            //tabControl1.SelectedTab = tabControl1.TabPages["Agents"];
        }

        private void btnMenuClientsVendorsSubVendorBalanceCheck_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabControl3.TabPages["ImporterBalanceChecks"];
            tabControl1.SelectedTab = tabControl1.TabPages["Agents"];
        }

        private void hamburger_menu_inventory_sub_timer_Tick(object sender, EventArgs e)
        {
            if (menuInventorySubExpand)
            {
                pnlMenuInventorySub.Height -= 10;

                if (pnlMenuInventorySub.Height == pnlMenuInventorySub.MinimumSize.Height)
                {
                    menuInventorySubExpand = false;
                    hamburger_menu_inventory_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuInventorySub.Height += 10;
                if (pnlMenuInventorySub.Height == pnlMenuInventorySub.MaximumSize.Height)
                {
                    menuInventorySubExpand = true;
                    hamburger_menu_inventory_sub_timer.Stop();
                }
            }
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    this.SuspendDrawing();
        //    base.OnResize(e);
        //    this.ResumeDrawing();
        //}

        //protected override void OnResizeBegin(EventArgs e)
        //{
        //    this.SuspendDrawing();
        //    base.OnResizeBegin(e);
        //}

        //protected override void OnResizeEnd(EventArgs e)
        //{
        //    base.OnResizeEnd(e);
        //    this.ResumeDrawing();
        //}

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    this.SuspendDrawing();
        //    base.OnClosing(e);
        //    this.ResumeDrawing();
        //}

        private void btnMenuSalesSubSales_Click(object sender, EventArgs e)
        {
            tabControl4.SelectedTab = tabControl4.TabPages["InvoicesSales"];
            tabControl1.SelectedTab = tabControl1.TabPages["Sales"];
        }

        private void btnMenuSalesSubInvoiceEdit_Click(object sender, EventArgs e)
        {
            tabControl4.SelectedTab = tabControl4.TabPages["EditInvoices"];
            tabControl1.SelectedTab = tabControl1.TabPages["Sales"];
        }

        private void hamburger_menu_sales_sub_timer_Tick(object sender, EventArgs e)
        {
            if (menuSalesSubExpand)
            {
                pnlMenuSalesSub.Height -= 10;

                if (pnlMenuSalesSub.Height == pnlMenuSalesSub.MinimumSize.Height)
                {
                    menuSalesSubExpand = false;
                    hamburger_menu_sales_sub_timer.Stop();
                }
            }
            else
            {
                pnlMenuSalesSub.Height += 10;
                if (pnlMenuSalesSub.Height == pnlMenuSalesSub.MaximumSize.Height)
                {
                    menuSalesSubExpand = true;
                    hamburger_menu_sales_sub_timer.Stop();
                }
            }
        }

        private void WarehouseInsert(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                bool addedWarehouse = Connection.server.InsertWarehouse(WarehouseEntry.Text);
                if (addedWarehouse)
                {
                    DisplayWarehouses();
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم حفظ المستودع الجديد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("A new Warehouse was saved.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                if (openedForm != null)
                {
                    openedForm.Close();
                    openedForm.ShowDialog();
                }
            }
            catch (Exception err) { }
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
                if (openedForm != null)
                {
                    openedForm.Close();
                    openedForm.ShowDialog();
                }
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
            catch (Exception err)
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
                richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
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

        public void ItemTypeInsert()
        {
            if (ItemTypeEntry.Text.Trim().Length > 0)
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
                    MaterialMessageBox.Show(".التعديل فقط من حساب إداري", this.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Management could only be done through Administrative Accounts.", this.ProductName);
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
                        MaterialMessageBox.Show(".لا يمكن تحديث الموظف", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Could not update Employee.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                    MaterialMessageBox.Show(".الرجاء ادخال جميع البيانات!", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please fill all required data!", false, FlexibleMaterialForm.ButtonsPosition.Center);
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

        //public void button11_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int Index = dgvVendorItemsPick.CurrentCell.RowIndex;
        //        DataGridViewRow row = dgvVendorItemsPick.Rows[Index];
        //        if (row.Selected)
        //        {
        //            if (!row.IsNewRow)
        //            {
        //                int quantity = Convert.ToInt32(row.Cells["VendorItemQuantity"].Value);
        //                int deletionquantity = Convert.ToInt32(quantity);
        //                if (quantity > 1 && quantity - deletionquantity > 0)
        //                    row.Cells["VendorItemQuantity"].Value = quantity - deletionquantity;
        //                else if (quantity - deletionquantity <= 0)
        //                    dgvVendorItemsPick.Rows.RemoveAt(Index);
        //            }
        //        }
        //    } catch (Exception error)
        //    {
        //        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
        //        {
        //            MaterialMessageBox.Show(".لم نستطيع حذف الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //        }
        //        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
        //        {
        //            MaterialMessageBox.Show("Unable to delete Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //        }
        //    }
        //}

        //public void button10_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);
        //        openedForm = itemLookup;
        //        itemLookup.ShowDialog(this);
        //        if (itemLookup.dialogResult == DialogResult.OK)
        //        {
        //            try
        //            {

        //                bool exists = false;
        //                foreach (DataGridViewRow row in dgvVendorItemsPick.Rows)
        //                {
        //                    if (row != null && !row.IsNewRow)
        //                    {
        //                        if (row.Cells[1].Value.ToString().Equals(itemLookup.selectedItem.GetItemBarCode()))
        //                        {
        //                            row.Cells["VendorItemQuantity"].Value = Convert.ToInt32(row.Cells["VendorItemQuantity"].Value) + itemLookup.selectedItem.vendorQuantity;
        //                            exists = true;
        //                        }
        //                    }
        //                }
        //                if (!exists && itemLookup.selectedItem != null)
        //                {
        //                    var index = dgvVendorItemsPick.Rows.Add();
        //                    dgvVendorItemsPick.Rows[index].Cells["VendorItemName"].Value = itemLookup.selectedItem.GetName();
        //                    dgvVendorItemsPick.Rows[index].Cells["VendorItemBarCode"].Value = itemLookup.selectedItem.GetItemBarCode();
        //                    if (itemLookup.selectedItem.GetItemTypeeID() != 0)
        //                    {
        //                        dgvVendorItemsPick.Rows[index].Cells["VendorItemType"].Value = Connection.server.RetrieveItemTypeName(itemLookup.selectedItem.GetItemTypeeID(), (int)frmLogin.pickedLanguage);
        //                    }
        //                    else
        //                    {
        //                        dgvVendorItemsPick.Rows[index].Cells["VendorItemType"].Value = itemLookup.selectedItem.GetItemTypeeID().ToString();
        //                    }
        //                    dgvVendorItemsPick.Rows[index].Cells["VendorItemQuantity"].Value = Convert.ToInt32(itemLookup.selectedItem.vendorQuantity);
        //                    dgvVendorItemsPick.Rows[index].Cells["VendorItemBuyPrice"].Value = Convert.ToDecimal(itemLookup.selectedItem.GetBuyPrice());
        //                    dgvVendorItemsPick.Rows[index].Cells["VendorItemSellPrice"].Value = Convert.ToDecimal(itemLookup.selectedItem.GetPrice());
        //                    dgvVendorItemsPick.Rows[index].Cells["VendorItemSellPriceTax"].Value = Convert.ToDecimal(itemLookup.selectedItem.GetPriceTax());
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
        //                {
        //                    MaterialMessageBox.Show(".لا يمكن اختيار الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //                }
        //                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
        //                {
        //                    MaterialMessageBox.Show("Unable to pick Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //    }
        //}

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
                MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
        }

        public void DGVClientItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClientItemID = e.RowIndex;
            BuyPrice.Value = Convert.ToDecimal(DGVClientItems.Rows[e.RowIndex].Cells[3].Value.ToString());
            SellPrice.Value = Convert.ToDecimal(DGVClientItems.Rows[e.RowIndex].Cells[4].Value.ToString());
            SellPriceTax.Value = Convert.ToDecimal(DGVClientItems.Rows[e.RowIndex].Cells[5].Value.ToString());
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
                    MaterialMessageBox.Show(".الرجاء إدخال إسم عنوان صحيح", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please enter a valid Address name.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                    if (MaterialMessageBox.Show(" .لا يمكن شراء الماده بسبب نفاذ الكميه " + " اضافة ماده؟ ", false, FlexibleMaterialForm.ButtonsPosition.Center, MessageBoxButtons.OKCancel) == DialogResult.OK)
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

                            if (ClientsaleItems.Count > 0)
                            {
                                for (int i = 0; i < ClientsaleItems.Count; i++)
                                {
                                    if (ClientsaleItems[i].GetItemBarCode() == itemLookup.selectedItem.GetItemBarCode())
                                    {
                                        priceAfterSales = ClientsaleItems[i].ClientPrice;
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
                                richTextBox6.Text = (" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                richTextBox6.Text = (" Barcode: " + itemLookup.selectedItem.GetItemBarCode());
                            }
                        }
                        calculateStatistics();
                    }
                    catch (Exception ex)
                    {
                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".لا يمكن اضافة الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("Unable to add Item.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void WarehouseInsert()
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
                        MaterialMessageBox.Show(".الرجاء إدخال إسم عنوان صحيح", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Please enter a valid Address name.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                frmCloseRegister closeRegister = new frmCloseRegister(this.cashierName, this.moneyInRegister);
                openedForm = closeRegister;
                closeRegister.ShowDialog(this);
                if (closeRegister.dialogResult == DialogResult.OK)
                {
                    printCloseRegister();
                    bool closedRegister = Connection.server.SaveRegisterClose(cashierName, moneyInRegister);
                    if (closedRegister)
                    {
                        this.moneyInRegister = 0;
                        this.moneyInRegisterInitial = 0;

                        Properties.Settings.Default.moneyInRegister = this.moneyInRegister;
                        Properties.Settings.Default.moneyInRegisterInitial = this.moneyInRegisterInitial;
                        Properties.Settings.Default.RegisterOpen = false;
                        Properties.Settings.Default.Save();
                        this.registerOpen = false;
                        tabControl2.Enabled = false;
                        pnlActionMenu.Enabled = false;
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
                            MaterialMessageBox.Show(ex.Message.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }

                        if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                        {
                            MaterialMessageBox.Show(".لفد قمت باغلاق الصندوق", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MaterialMessageBox.Show("You have closed the cash register.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        }
                    }
                }
            } catch (Exception error)
            {

            }
        }

        public void pictureBox36_Click(object sender, EventArgs e)
        {
            FavoriteCategoryInsert();
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
                    pnlActionMenu.Enabled = true;
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
                        richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                        richTextBox5.Text = (" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        MaterialMessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        richTextBox4.Text = (" Total: " + this.totalAmount);
                        richTextBox5.Text = (" Current Bill ID: " + this.CurrentBillNumber);
                        MaterialMessageBox.Show(String.Format("You have opened the cash register with the amount of {0} JOD.", moneyInRegister), false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                MaterialMessageBox.Show(".تعدلت نسبة خصم الأغراض", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Items Discount percentage was altered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                        }
                        else
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MaterialMessageBox.Show(".تم اضافة الخصم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                            }
                            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                            {
                                MaterialMessageBox.Show("Discount was added.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                        MaterialMessageBox.Show(".لم نتمكن من اضافة الخصم", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Unable to add Discount.", false, FlexibleMaterialForm.ButtonsPosition.Center);
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
                                    richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                                }
                                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                                {
                                    richTextBox4.Text = (" Total: " + this.totalAmount);
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
                            richTextBox4.Text = (" :المجموع الكامل " + this.totalAmount);
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            richTextBox4.Text = (" Total: " + this.totalAmount);
                        }
                    }
                }
            }
        }

        public void printCertainReceipt(Bill bill, bool rePrint = false)
        {
            try
            {
                decimal gross = Convert.ToDecimal(totalAmount);
                decimal net = Convert.ToDecimal(totalAmount);
                decimal discount = gross - net;
                decimal amountPaid = paidAmount;
                decimal remainder = remainderAmount;
                string InvoiceDate = bill.getDate().ToString();

                frmReceipt receipt = new frmReceipt(bill, txtStoreName.Text, txtStoreAddress.Text, txtStorePhone.Text, picLogo.Image, IncludeLogoInReceipt, rePrint);
                openedForm = receipt;
                receipt.ShowDialog();
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من طباعة الفاتوره", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Unable to print Invoice.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        public void printCloseRegister()
        {
            string printerName = "";
            frmMain.PrintersList = Connection.server.RetrievePrinters(Environment.MachineName);
            foreach (Dependencies.Printer printer in frmMain.PrintersList)
            {
                if (printer.MachineName == Environment.MachineName && Convert.ToBoolean(printer.IsMainPrinter))
                {
                    printerName = printer.Name;
                }
            }
            printCloseCashReport.PrinterSettings.PrinterName = printerName;
            printCloseCashReport.Print();
        }
        static int DrawCenteredText(Graphics g, string text, int y, Font font)
        {
            RectangleF rect = new RectangleF(0, y, width, lineHeight);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
            g.DrawString(text, font, Brushes.Black, rect, sf);
            return y + lineHeight;
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
