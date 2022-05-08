using NeatVibezPOS.Properties;
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
using RawDataPrint;
using WMPLib;
using System.Text;
using System.IO.Ports;
using DataAccessLayer;

namespace NeatVibezPOS
{

    public partial class frmMain : Form
    {
        public Connection Connection = new Connection();
        public int ID = 0, CurrentBillNumber = 0, CurrentVendorBillNumber = 0, customerItemID = 0, heldBillsCount = 0, EmployeeID = 0, AbsenceID = 0;
        public static int Authority = 0;
        public string CurrentItemBarcode = "", BarCode = "", cashierName = "Developer Mode", UID, PWD, NeatVibezPOSName, NeatVibezPOSPhone, printerName;
        public Tuple<List<Item>, DataTable> FavoriteItems;
        public Stack<Bill> previousBillsList = new Stack<Bill>();
        public Stack<Bill> nextBillsList = new Stack<Bill>();
        public decimal totalAmount = 0, totalVendorAmount = 0, paidAmount = 0, remainderAmount = 0, moneyInRegister = 0, moneyInRegisterInitial = 0;
        public List<Item> saleItems = new List<Item>();
        public List<Item> customersaleItems = new List<Item>();
        public List<Item> DISCOUNT_ITEMS = new List<Item>();
        public List<Item> ItemsList, retrievedFavoriteItems;
        public List<Account> Users;
        public List<Category> Categories = new List<Category>();
        public List<ItemType> ItemTypesList = new List<ItemType>();
        public List<Warehouse> WarehousesList = new List<Warehouse>();
        public Customer currentCustomer;
        public decimal CapitalAmount, TaxRate;
        public int PrintBillNumber = 0;
        public SortedList<int, string> itemtypes = new SortedList<int, string>();
        public SortedList<int, string> warehouses = new SortedList<int, string>();
        public SortedList<int, string> favorites = new SortedList<int, string>();
        public string ScannedBarCode = "";
        public bool timerstarted = false, registerOpen = false;
        decimal capital, taxRate;
        TextBox AddItemType;
        List<TextBox> ItemTypeNamestxt = new List<TextBox>();
        PictureBox plusItemTypePB, minusItemTypePB;
        Label plusItemTypeLbl, ItemTypeLbl;
        TextBox AddWarehouse;
        List<TextBox> WarehouseNamestxt = new List<TextBox>();
        PictureBox plusWarehousePB, minusWarehousePB;
        Label plusWarehouseLbl, WarehouseLbl;
        TextBox AddFavorite;
        List<TextBox> FavoriteNamestxt = new List<TextBox>();
        PictureBox plusFavoritePB, minusFavoritePB;
        Label plusFavoriteLbl, FavoriteLbl;
        List<FlowLayoutPanel> flowLayoutPanels = new List<FlowLayoutPanel>();
        Button saveItemTypesBtn;
        Button saveWarehousesBtn;
        Button saveFavoritesBtn;

        public Account userPermissions;

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

        public frmMain(Account Account)
        {
            try
            {
                InitializeComponent();

                try
                {
                    string imagePath = Properties.Settings.Default.Logo;

                    picLogoStore.Image = new Bitmap(imagePath);
                    picLogo.Image = new Bitmap(imagePath);
                } catch(Exception err)
                {
                    picLogoStore.Image = new Bitmap(Properties.Resources.neat_vibez);
                    picLogo.Image = new Bitmap(Properties.Resources.neat_vibez);
                }

                this.cashierName = Account.GetAccountName();
                this.cashierNameLbl.Text = this.cashierName;
                this.UID = Account.GetAccountUID();
                this.PWD = Account.GetAccountPWD();
                frmMain.Authority = Account.GetAccountAuthority();

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

                if (!this.userPermissions.customer_card_edit)
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Agents"]);

                if (!this.userPermissions.inventory_edit)
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Inventory"]);
                    ادارةالمستودعToolStripMenuItem.Visible = false;
                    ادارةالمستودعToolStripMenuItem.Enabled = false;
                }

                if (!this.userPermissions.expenses_add)
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Expenses"]);

                if (!this.userPermissions.users_edit)
                    tabControl1.TabPages.Remove(tabControl1.TabPages["posUsers"]);

                if (!this.userPermissions.settings_edit)
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Settings"]);

                if (!this.userPermissions.personnel_edit)
                    tabControl1.TabPages.Remove(tabControl1.TabPages["Employees"]);

                if (!this.userPermissions.receipt_edit)
                {
                    tabControl4.TabPages.Remove(tabControl4.TabPages["EditInvoices"]);
                    tabControl4.TabPages.Remove(tabControl4.TabPages["TravelingUntravelingSales"]);
                    tabControl4.TabPages.Remove(tabControl4.TabPages["SoldItems"]);
                }

                if (!this.userPermissions.openclose_edit)
                {
                    openRegisterBtn.Enabled = false;
                    closeRegisterBtn.Enabled = false;
                    label65.Enabled = false;
                    label66.Enabled = false;
                }

                taxRate = Properties.Settings.Default.TaxRate;
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
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);

                Tuple<List<Customer>, DataTable> retrievedCustomers = Connection.server.GetRetrieveCustomers();

                dgvCustomers.DataSource = retrievedCustomers.Item2;
                
                this.NeatVibezPOSName = Properties.Settings.Default.ShopName;
                this.shopName.Text = Properties.Settings.Default.ShopName;
                this.shopPhone.Text = Properties.Settings.Default.ShopPhone;
                this.Text = this.NeatVibezPOSName + " - الشاشه الرئيسيه";
                label45.Text = " هذه النسخه مرخصه لمتجر " + this.NeatVibezPOSName;
                this.PrinterName.Text = Properties.Settings.Default.PrinterName;
                this.receiptSpacingnud.Value = Properties.Settings.Default.receiptSpacing;
                this.registerOpen = Properties.Settings.Default.RegisterOpen;
                
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
                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                    richTextBox5.ResetText();
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
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

                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;

                if (Properties.Settings.Default.PrinterName == "")
                {
                    if (MessageBox.Show(" .بعض الاعدادات بدون قيم, الرجاء وضع قيمه لها في الاعدادات " + " اضافة ماده؟ ", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages["Settings"];
                        return;
                    }
                    //else return;
                }
            }
            catch(Exception e)
            { MessageBox.Show(e.ToString()); }
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
            plusItemTypeLbl.Text = "اضافة صنف مواد جديد";
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
            ItemTypeLbl.Text = "أصناف المواد المضافه";
            ItemTypeLbl.ForeColor = Color.Black;
            ItemTypeLbl.Font = new Font(plusItemTypeLbl.Font.FontFamily, 14);
            flowLayoutPanel3.Controls.Add(ItemTypeLbl);

            saveItemTypesBtn = new Button();
            saveItemTypesBtn.Name = "SaveItemTypesButton";
            saveItemTypesBtn.Tag = "SaveItemTypesButton";
            saveItemTypesBtn.Text = "حفظ التصانيف";
            saveItemTypesBtn.Size = new Size(340, 45);
            saveItemTypesBtn.ForeColor = Color.White;
            saveItemTypesBtn.BackColor = Color.FromArgb(59, 89, 152);
            saveItemTypesBtn.Font = new Font(saveItemTypesBtn.Font.FontFamily, 14, FontStyle.Bold);
            saveItemTypesBtn.Click += (sender, e) => { SaveItemTypesHandler(sender, e); };

            ItemType.Items.Add(new ItemTypeCategory("غير مصنف"));
            comboBox1.Items.Add(new ItemTypeCategory("غير مصنف"));

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
            plusWarehouseLbl.Text = "اضافة مستودع جديد";
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
            WarehouseLbl.Text = "المستودعات المضافه";
            WarehouseLbl.ForeColor = Color.Black;
            WarehouseLbl.Font = new Font(plusWarehouseLbl.Font.FontFamily, 14);
            flowLayoutPanel2.Controls.Add(WarehouseLbl);

            saveWarehousesBtn = new Button();
            saveWarehousesBtn.Name = "SaveWarehousesButton";
            saveWarehousesBtn.Tag = "SaveWarehousesButton";
            saveWarehousesBtn.Text = "حفظ المستودعات";
            saveWarehousesBtn.Size = new Size(340, 45);
            saveWarehousesBtn.ForeColor = Color.White;
            saveWarehousesBtn.BackColor = Color.FromArgb(59, 89, 152);
            saveWarehousesBtn.Font = new Font(saveWarehousesBtn.Font.FontFamily, 14, FontStyle.Bold);
            saveWarehousesBtn.Click += (sender, e) => { SaveWarehousesHandler(sender, e); };

            //Warehouse.Items.Add(new WarehouseCategory("غير موجود"));
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
            plusFavoriteLbl.Text = "اضافة مجلد مفضل جديد";
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
            FavoriteLbl.Text = "لمفضلات المضافه";
            FavoriteLbl.ForeColor = Color.Black;
            FavoriteLbl.Font = new Font(plusFavoriteLbl.Font.FontFamily, 14);
            flowLayoutPanel1.Controls.Add(FavoriteLbl);
            
            saveFavoritesBtn = new Button();
            saveFavoritesBtn.Name = "SaveFavoritesButton";
            saveFavoritesBtn.Tag = "SaveFavoritesButton";
            saveFavoritesBtn.Text = "حفظ المفضلات";
            saveFavoritesBtn.Size = new Size(340, 45);
            saveFavoritesBtn.ForeColor = Color.White;
            saveFavoritesBtn.BackColor = Color.FromArgb(59, 89, 152);
            saveFavoritesBtn.Font = new Font(saveFavoritesBtn.Font.FontFamily, 14, FontStyle.Bold);
            saveFavoritesBtn.Click += (sender, e) => { SaveFavoritesHandler(sender, e); };

            FavoriteCategories.Items.Add(new FavoriteCategory("غير مفضله"));

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
                flowLayoutPanels[i].Size = new Size(460, 407);
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
                            btn.Height = 135;
                            btn.Width = 135;
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
                    MessageBox.Show(".تم حذف صنف المواد");
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                MessageBox.Show(".لم نتمكن من حذف صنف المواد", Application.ProductName);
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
                    MessageBox.Show(".تمت اضافة أصناف المواد الجديده");
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                MessageBox.Show(".لم نتمكن من حفظ أصناف المواد الجديده", Application.ProductName);
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
                    MessageBox.Show(".تم حفظ أصناف المواد");
                }
            }
            catch (Exception ex)
            {
                DisplayItemTypes();
                MessageBox.Show(".لم نتمكن من حفظ أصناف المواد", Application.ProductName);
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
                    MessageBox.Show(".تم حذف المستودع");
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                MessageBox.Show(".لم نتمكن من حذف المستودع", Application.ProductName);
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
                    MessageBox.Show(".تمت اضافة المستودع الجديد");
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                MessageBox.Show(".لم نتمكن من حفظ المستودع الجديد", Application.ProductName);
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
                    MessageBox.Show(".تم حفظ المستودعات");
                }
            }
            catch (Exception ex)
            {
                DisplayWarehouses();
                MessageBox.Show(".لم نتمكن من حفظ المستودعات", Application.ProductName);
            }
        }

        void AddFavoriteItemHandler(object sender, EventArgs e, Item item)
        {
            try
            {
                //List<Item> quantity_items = Connection.server.RetrieveItemsQuantity(item.GetItemBarCode());

                /*foreach (Item quantity_item in quantity_items)
                {
                    if (quantity_item.GetItemBarCode() == item.ItemBarCode)
                    {
                        if (quantity_item.GetQuantity() < 1)
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
                    richTextBox6.AppendText(" :الباركود " + item.GetItemBarCode());
                }
                calculateStatistics();
                tabControl1.Select();
                tabControl1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(".لا يمكن اضافة الماده المفضله", Application.ProductName);
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
                    MessageBox.Show(".تم حذف مجلد المفضلات");
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                MessageBox.Show(".لم نتمكن من حذف المفضلات", Application.ProductName);
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
                    MessageBox.Show(".تمت اضافة مجلد المفضلات الجديده");
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                MessageBox.Show(".لم نتمكن من حفظ المفضلات", Application.ProductName);
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
                    MessageBox.Show(".تم حفظ المفضلات الجديده");
                }
            }
            catch (Exception ex)
            {
                DisplayFavorites();
                MessageBox.Show(".لم نتمكن من حفظ المفضلات", Application.ProductName);
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
                MessageBox.Show(".لم نستطع حذف القطعه", Application.ProductName);
            }
        }

        public void calculateStatistics()
        {
            this.totalAmount = 0;
            foreach (DataGridViewRow itemToCalculate in ItemsPendingPurchase.Rows)
            {
                if (!itemToCalculate.IsNewRow)
                {
                    this.totalAmount += Convert.ToDecimal(itemToCalculate.Cells["pendingPurchaseItemPriceTax"].Value) * Convert.ToInt32(itemToCalculate.Cells["pendingPurchaseItemQuantity"].Value);
                }
            }
            
            richTextBox5.ResetText();
            richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
            richTextBox4.ResetText();
            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
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
                MessageBox.Show(".لم نستطع تعديل أسعار القطعه", Application.ProductName);
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
                MessageBox.Show(".لم نستطع تعديل أسعار القطعه", Application.ProductName);
            }
        }

        public void button21_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            try
            {

                LPrinter MyPrinter = new LPrinter(); // creates the printer object
                MyPrinter.PrinterName = "\\\\" + Environment.MachineName + "\\" + Properties.Settings.Default.PrinterName;
                MyPrinter.Print("");
                printDocument2.Print();


                try
                {
                    System.IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts", true);
                }
                catch (Exception error) { }

                /*string output = Convert.ToChar(29) + "V" + Convert.ToChar(65) + Convert.ToChar(0);
                RawPrinterHelper.SendStringToPrinter(this.printerName, output);
                */

            }
            catch (Exception error)
            {
                MessageBox.Show(e.ToString(), Application.ProductName);
            }

            tabControl1.Select();
            tabControl1.Focus();
            this.ActiveControl = tabControl1;
        }

        public void searchItemDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        public void button27_Click(object sender, EventArgs e)
        {
            /*
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
            */
            
            /*string welcome = "شكرا لزيارتك متجرنا " + NeatVibezPOSName + ".";
            string InvoiceNo = this.CurrentBillNumber.ToString();
            decimal gross = Convert.ToInt32(this.totalAmount);
            decimal net = Convert.ToInt32(this.totalAmount);
            decimal discount = gross - net;
            decimal amountPaid = this.paidAmount;
            decimal remainder = this.remainderAmount;
            string InvoiceDate = DateTime.Now.ToString();

            LPrinter MyPrinter = new LPrinter(); // creates the printer object
                                                 //MyPrinter.ChoosePrinter();// let user choose the printer device

            // alternatively:
            MyPrinter.PrinterName = "\\\\" + Environment.MachineName + "\\" + Settings.Default.PrinterName;
            // uses a specific named printer

            MyPrinter.Open("Receipt"); // opens and tells the spooler the document title
            MyPrinter.Print("" + InvoiceNo + "رقم الفاتورة الحالية ");
            MyPrinter.Print("" + InvoiceDate + "");
            MyPrinter.Print("إسم المنتج                " + "              السعر " + "               الكمية      ");
            MyPrinter.Print("----------------------------------------------------------");
            for (int i = 0; i < ItemsPendingPurchase.Rows.Count; i++)
            {
                if (!ItemsPendingPurchase.Rows[i].IsNewRow)
                {
                    int ii = 1;
                    ii++;

                    MyPrinter.Print(" " + ItemsPendingPurchase.Rows[i].Cells[2].Value + "              " + ItemsPendingPurchase.Rows[i].Cells[4].Value + "" + ItemsPendingPurchase.Rows[i].Cells[0].Value + "");
                }
            }
            MyPrinter.Print("--------------------------------------------------------");
            MyPrinter.Print("الإجمالي :" + gross + "");
            MyPrinter.Print("الخصم :" + discount + "");
            MyPrinter.Print("الصافي :" + net + "");
            MyPrinter.Print("المدفوع :" + amountPaid + "");
            MyPrinter.Print("الباقي :" + remainder + "");
            MyPrinter.Print("---------------------------------------------------------");
            MyPrinter.Print("" + welcome + "");
            */

            groupBox5.Hide();
            groupBox5.Location = new Point(1400, 1400);
            printDocument1.Print();


            try
            {
                System.IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts", true);
            }
            catch (Exception error) { }

            tabControl1.Select();
            tabControl1.Focus();
            this.ActiveControl = tabControl1;

        }

        public void BtnSearchItem_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchInventoryItems(txtItemNameSearch.Text, nudItemBarCodeSearch.Text);
            DgvInventory.DataSource = RetrievedItems.Item2;
        }

        public void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemName.Text != "" && Warehouse.SelectedItem.ToString() != "")
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
                        MessageBox.Show(".لم نتمكن من اضافة الماده الجديده بسبب مشكله في الادخال", Application.ProductName);
                    }
                    ClearInput();
                    DisplayFavorites();
                }
                else
                {
                    MessageBox.Show("!الرجاء أدخل المعلومات المطلوبه", Application.ProductName);
                    ClearInput();
                }
            } catch (Exception error)
            {
                MessageBox.Show("!الرجاء أدخل المعلومات المطلوبه", Application.ProductName);
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
            Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveItems();
            DgvInventory.DataSource = RetrievedItems.Item2;

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
                    frmAuth.ShowDialog();
                    if (frmAuth.dialogResult == DialogResult.OK)
                    {
                        if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "NeatVibezPOS"), "NeatVibezPOS") == PWD)
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
                                    MessageBox.Show(".لم نتمكن من تحديث معلومات الماده بسبب مشكله في المعلومات المدخله", Application.ProductName);
                                }
                                ClearInput();
                            }
                            else
                            {
                                MessageBox.Show(".الرجاء اختيار سطر ماده", Application.ProductName);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                            return;
                        }
                    }
                    else return;
                }
                else
                {
                    MessageBox.Show(".فقط حساب إداري بامكانه حذف المواد", Application.ProductName);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(".لم نتمكن من تحديث معلومات الماده بسبب مشكله", Application.ProductName);
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
                    frmAuth.ShowDialog();
                    if (frmAuth.dialogResult == DialogResult.OK)
                    {
                        if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "NeatVibezPOS"), "NeatVibezPOS") == PWD)
                        {
                            int deletedCount = 0;
                            foreach (DataGridViewRow row in DgvInventory.Rows)
                            {
                                if (row.Selected == true)
                                {
                                    if (Connection.server.DeleteItem(row.Cells[1].Value.ToString()))
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
                            MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                            return;
                        }
                    } else
                    {
                        return;
                    }
                } else
                {
                    MessageBox.Show(".فقط حساب إداري بامكانه حذف المواد", Application.ProductName);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(".لم نتمكن من حذف الماده بسبب مشكله في ادخال كلمة السر", Application.ProductName);
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
                FavoriteCategories.SelectedIndex = FavoriteCategories.FindStringExact(Connection.server.RetrieveFavoriteCategoryName(Convert.ToInt32(DgvInventory.Rows[e.RowIndex].Cells["FavoriteCategoryNumber"].Value.ToString())));
                Warehouse.SelectedIndex = Warehouse.FindStringExact(Connection.server.RetrieveWarehouseName(Convert.ToInt32(DgvInventory.Rows[e.RowIndex].Cells["InventoryWarehouseID"].Value.ToString())));
                ItemType.SelectedIndex = ItemType.FindStringExact(Connection.server.RetrieveItemTypeName(Convert.ToInt32(DgvInventory.Rows[e.RowIndex].Cells["InventoryItemTypeNumber"].Value.ToString())));


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
                MessageBox.Show(".لا بمكتك دفع فاتوره فارغه", Application.ProductName);
            }
            else
            {
                frmPay frmPayCash = new frmPay(this.totalAmount);
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
                                            MessageBox.Show("قطعه إسم " + item.ItemName + "باركود " + item.ItemBarCode + " انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف.");
                                    }
                                    dgvAlerts.DataSource = itemsExpirationStock.Item2;
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
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox3.AppendText(" :المجموع السابق " + this.totalAmount);
                richTextBox2.ResetText();
                richTextBox2.AppendText(" :المدفوع السابق " + this.paidAmount);
                richTextBox1.ResetText();
                richTextBox1.AppendText(" :الباقي السابق " + this.remainderAmount);

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
                    label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                }
            }
        }

        public void pictureBox12_Click(object sender, EventArgs e)
        {
            if (ItemsPendingPurchase.Rows[0].IsNewRow)
            {
                MessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", Application.ProductName);
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
                richTextBox3.AppendText(" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                richTextBox2.ResetText();
                richTextBox2.AppendText(" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                richTextBox1.ResetText();
                richTextBox1.AppendText(" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());

                ItemsPendingPurchase.Rows.Clear();
                this.customersaleItems.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;
                items = null;
                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                heldBillsCount += 1;
                label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
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
                    MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName);
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
                else { MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName); }
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = "تقرير المستودع";
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
                frmAuth.ShowDialog();
                if (frmAuth.dialogResult == DialogResult.OK)
                {
                    if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "NeatVibezPOS"), "NeatVibezPOS") == PWD)
                    {
                        if (txtUserNameAdd.Text != "" && txtUserIDAdd.Text != "" && txtUserPasswordAdd.Text != "")
                        {
                            if (txtUserIDAdd.Text.ToLower().Trim() == "admin")
                            {
                                MessageBox.Show(".لا يمكن تسجيل رمز المستخدم admin", Application.ProductName);
                                ClearInput();
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountName(txtUserNameAdd.Text);
                            newAccount.SetAccountUID(txtUserIDAdd.Text);
                            newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtUserPasswordAdd.Text, "NeatVibezPOS"));
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
                                MessageBox.Show(".لم نتمكن من اضافة المستخدم", Application.ProductName);
                            }
                            ClearInput();
                        }
                        else
                        {
                            MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                            ClearInput();
                        }
                    }
                    else
                    {
                        MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                        return;
                    }
                }
                else return;
            }
            else
            {
                MessageBox.Show(".فقط حساب إداري بامكانه إضافة المستخدمين", Application.ProductName);
                return;
            }
        }

        public void button20_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                frmAuth frmAuth = new frmAuth();
                frmAuth.ShowDialog();
                if (frmAuth.dialogResult == DialogResult.OK)
                {
                    if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "NeatVibezPOS"), "NeatVibezPOS") == PWD)
                    {
                        if (txtUserNameAdd.Text != "" && txtUserIDAdd.Text != "")
                        {
                            if (txtUserIDAdd.Text.ToLower().Trim() == "admin" && this.UID != "admin" || dgvUsers.SelectedRows[0].Cells["UserID"].Value.ToString().ToLower().Trim() != "admin")
                            {
                                MessageBox.Show(".لا يمكن تسجيل رمز المستخدم للحساب الإداري الرئيسي", Application.ProductName);
                                ClearInput();
                                return;
                            }
                            Account newAccount = new Account();
                            newAccount.SetAccountName(txtUserNameAdd.Text);
                            newAccount.SetAccountUID(txtUserIDAdd.Text);
                            if (txtUserPasswordAdd.Text != "")
                                newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtUserPasswordAdd.Text, "NeatVibezPOS"));
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
                                frmMain.Authority = newAccount.GetAccountAuthority();

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

                                if (!this.userPermissions.customer_card_edit)
                                    tabControl1.TabPages.Remove(tabControl1.TabPages["Agents"]);

                                if (!this.userPermissions.inventory_edit)
                                {
                                    tabControl1.TabPages.Remove(tabControl1.TabPages["Inventory"]);
                                    ادارةالمستودعToolStripMenuItem.Visible = false;
                                    ادارةالمستودعToolStripMenuItem.Enabled = false;
                                }

                                if (!this.userPermissions.expenses_add)
                                    tabControl1.TabPages.Remove(tabControl1.TabPages["Expenses"]);

                                if (!this.userPermissions.users_edit)
                                    tabControl1.TabPages.Remove(tabControl1.TabPages["posUsers"]);

                                if (!this.userPermissions.settings_edit)
                                    tabControl1.TabPages.Remove(tabControl1.TabPages["Settings"]);

                                if (!this.userPermissions.personnel_edit)
                                    tabControl1.TabPages.Remove(tabControl1.TabPages["Employees"]);

                                if (!this.userPermissions.receipt_edit)
                                {
                                    tabControl4.TabPages.Remove(tabControl4.TabPages["EditInvoices"]);
                                    tabControl4.TabPages.Remove(tabControl4.TabPages["TravelingUntravelingSales"]);
                                    tabControl4.TabPages.Remove(tabControl4.TabPages["SoldItems"]);
                                }

                                if (!this.userPermissions.openclose_edit)
                                {
                                    openRegisterBtn.Enabled = false;
                                    closeRegisterBtn.Enabled = false;
                                    label65.Enabled = false;
                                    label66.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show(".لا يمكن تحديث المستخدم", Application.ProductName);
                            }
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                        return;
                    }
                }
                else return;
            }
            else
            {
                MessageBox.Show(".فقط حساب إداري بامكانه تعديل المستخدمين", Application.ProductName);
                return;
            }
        }

        public void button19_Click(object sender, EventArgs e)
        {
            if (Authority == 1)
            {
                frmAuth frmAuth = new frmAuth();
                frmAuth.ShowDialog();
                if (frmAuth.dialogResult == DialogResult.OK)
                {
                    if (MD5Encryption.Encrypt(MD5Encryption.Encrypt(frmAuth.password, "NeatVibezPOS"), "NeatVibezPOS") == PWD)
                    {
                        if (txtUserIDAdd.Text != "")
                        {
                            if (dgvUsers.SelectedRows[0].Cells["UserID"].Value.ToString().ToLower().Trim() == "admin")
                            {
                                MessageBox.Show(".لا يمكن حذف الحساب الإداري", Application.ProductName);
                                return;
                            }
                            if (txtUserIDAdd.Text.ToLower().Trim() == this.UID.ToLower().Trim())
                            {
                                MessageBox.Show(".لا يمكن حذف الحساب المدخول به حاليا, الرجاء الحذف من حساب إداري أخر", Application.ProductName);
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
                                MessageBox.Show(".لم نتمكن من حذف المستخدم", Application.ProductName);
                            }
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
                            txtUserNameAdd.Text = "";
                            txtUserIDAdd.Text = "";
                            txtUserPasswordAdd.Text = "";
                            button20.Enabled = false;
                            button19.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(".كلمة السر خطأ", Application.ProductName);
                        return;
                    }
                }
                else return;
            }
            else
            {
                MessageBox.Show(".فقط حساب إداري بامكانه تعديل المستخدمين", Application.ProductName);
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
                    theImage = Properties.Resources.neat_vibez
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
                    MessageBox.Show("الرجاء إختيار فاتورة.", Application.ProductName);
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = String.Format("{0} تقرير الفاتوره رقم", PrintBillNumber);
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
        }

        public void nudBillNumberSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchBills(Convert.ToInt32(nudBillNumberSearch.Value));
            dgvBills.DataSource = RetrievedItems.Item2;
        }

        public void pictureBox19_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchBills(Convert.ToInt32(nudBillNumberSearch.Value));
            dgvBills.DataSource = RetrievedItems.Item2;
        }

        public void button25_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> leastBoughtItems = Connection.server.RetrieveLeastBoughtItems();
            dgvBillItems.DataSource = leastBoughtItems.Item2;
        }

        public void button26_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchTodayBills(DateTime.Today);
            RetrievedItems = Connection.server.SearchTodayBills(DateTime.Today);
            RetrievedItems = Connection.server.SearchTodayBills(DateTime.Today);
            dgvBills.DataSource = RetrievedItems.Item2;
        }

        public void button28_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);
                Properties.Settings.Default.Save();
                TaxRate = Convert.ToDecimal(nudTaxRate.Value / 100);
                MessageBox.Show(".تم حفظ الاعدادات", Application.ProductName);
            }
            catch(Exception error)
            { }
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير المبيعات الغير مرحله";
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير المبيعات المرحله";
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
                                    richTextBox6.AppendText(" :الباركود " + item.GetItemBarCode());
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
                        richTextBox6.AppendText(" :الباركود " + item.GetItemBarCode());
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
            }
            catch (Exception ex)
            {
                this.itemBarCodeEntryTimer.Stop();
                this.timerstarted = false;
            }
        }

        public void pictureBox2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format(".+962 79 294 2040 .{0} الرجاء مخاطبة للدعم الفني", Application.CompanyName));
        }

        public void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                
                /*LPrinter MyPrinter = new LPrinter(); // creates the printer object
                MyPrinter.PrinterName = "\\\\" + Environment.MachineName + "\\" + Properties.Settings.Default.PrinterName;
                MyPrinter.Print("");
                printDocument2.Print();*/

                Encoding enc = Encoding.Unicode;
                SerialPort sp = new SerialPort();
                sp.PortName = "COM2";

                sp.Encoding = enc;
                sp.BaudRate = 38400;
                sp.Parity = System.IO.Ports.Parity.None;
                sp.DataBits = 8;
                sp.StopBits = System.IO.Ports.StopBits.One;
                sp.DtrEnable = true;
                sp.Open();
                sp.Write(char.ConvertFromUtf32(28699) + char.ConvertFromUtf32(9472) + char.ConvertFromUtf32(3365));
                sp.Close();

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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير الصادر";
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير الوارد";
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير الأرباح";
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
            dgvItemProfit.DataSource = Connection.server.RetrieveBillItemsProfit(Convert.ToDateTime(dateTimePicker4.Text), Convert.ToDateTime(dateTimePicker3.Text), ItemTypeID, CashierName);
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
            dgvItemProfit.DataSource = Connection.server.RetrieveBillItemsProfit(Convert.ToDateTime(dateTimePicker4.Value), Convert.ToDateTime(dateTimePicker3.Value), ItemTypeID, CashierName);
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
        }

        public void pictureBox28_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedItems;
            RetrievedItems = Connection.server.SearchBills(Convert.ToInt32(nudBillNumberEdit.Value));
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
            RetrievedExpenses = Connection.server.SearchExpenses(dateTimePicker8.Value, dateTimePicker7.Value, textBox1.Text, textBox2.Text);
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = "تقرير المصروفات";
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
                    MessageBox.Show(".تمت اضافة المصروف");
                }
            } catch(Exception error) { MessageBox.Show(".لم نتمكن من اضافة المصروف"); }
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
                Properties.Settings.Default.ShopName = this.shopName.Text;
                Properties.Settings.Default.ShopPhone = this.shopPhone.Text;
                Properties.Settings.Default.PrinterName = this.PrinterName.Text;
                Properties.Settings.Default.receiptSpacing = Convert.ToInt32(this.receiptSpacingnud.Value);
                Properties.Settings.Default.Save();
                this.NeatVibezPOSName = this.shopName.Text;
                this.NeatVibezPOSPhone = this.shopPhone.Text;
                this.printerName = this.PrinterName.Text;
                label45.Text = " هذه النسخه مرخصه لمتجر " + this.NeatVibezPOSName;
                this.Text = this.NeatVibezPOSName + " - الشاشه الرئيسيه";
                this.Refresh();
                MessageBox.Show(".تم حفظ الاعدادات", Application.ProductName);
            }
            catch (Exception error)
            { }
        }

        public void pictureBox23_Click(object sender, EventArgs e)
        {
            Tuple<List<Item>, DataTable> imports = Connection.server.RetrieveImports();
            dgvImports.DataSource = imports.Item2;
        }

        public void adminCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (adminCheckBox.Checked)
                if (frmMain.Authority != 1)
                {
                    adminCheckBox.Checked = false;
                    MessageBox.Show(".المستخدم الإداري الرئيسي هو الوحيد الذي يمكنه اضافة مستخدم إداري", Application.ProductName);
                }
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
                    dgvItemProfit.DataSource = Connection.server.RetrieveBillItemsProfit(Convert.ToDateTime(dateTimePicker4.Text), Convert.ToDateTime(dateTimePicker3.Text), ItemTypeID, CashierName);
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
                    nudItemBarCodeSearch.Text = "";
                    txtItemNameSearch.Text = "";
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Expenses"])
                {
                    DataTable RetrievedExpenses;
                    RetrievedExpenses = Connection.server.SearchExpenses(dateTimePicker8.Value, dateTimePicker7.Value, textBox1.Text, textBox2.Text);
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
                            }
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            dgvAlerts.DataSource = dt;
                        }
                    }
                    Tuple<List<Item>, DataTable> retreivedCustomerItems = Connection.server.RetrieveItems();
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

        public void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
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
                frmCustomerCard customerCard = new frmCustomerCard();
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
                                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                    }
                                }
                            }
                        }
                    }

                    customerCard.Dispose();
                    if (replaced)
                        MessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", Application.ProductName);
                    else MessageBox.Show(".تم اضافة خصم العميل", Application.ProductName);


                }
                else if (customerCard.dialogResult == DialogResult.None)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["Employees"];
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

                    MessageBox.Show(".تمت اضافة الزبون", Application.ProductName);
                }
                else
                {
                    MessageBox.Show(".لم نتمكن من اضافة الزبون", Application.ProductName);
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
                    MessageBox.Show(".تم حذف العميل", Application.ProductName);
                }
                else
                {
                    MessageBox.Show(".لم نستطع حذف العميل", Application.ProductName);
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
                editPrice.ShowDialog();
                if (editPrice.dialogResult == DialogResult.OK)
                {
                    this.totalAmount = editPrice.moneyDeduction;
                    richTextBox4.ResetText();
                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
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
                MessageBox.Show(".لم نستطع اختيار الزبون", Application.ProductName);
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
                    MessageBox.Show(".تمت اضافة الماده للزبون", Application.ProductName);
                }
                else
                {
                    textBox7.Text = "";
                    numericUpDown2.Value = 0;
                    BuyPrice.Value = 0;
                    SellPrice.Value = 0;
                    SellPriceTax.Value = 0;
                    CustomerPrice.Value = 0;
                    MessageBox.Show(".لم تتم اضافة الماده للزبون", Application.ProductName);
                }
            } catch(Exception error)
            {
                textBox7.Text = "";
                numericUpDown2.Value = 0;
                BuyPrice.Value = 0;
                SellPrice.Value = 0;
                SellPriceTax.Value = 0;
                CustomerPrice.Value = 0;
                MessageBox.Show(".لم تتم اضافة الماده للزبون", Application.ProductName);
            }
        }

        public void pictureBox40_Click(object sender, EventArgs e)
        {
            DGVCustomerItems.DataSource = Connection.server.RetrieveItems().Item2;
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

        public void cbAdminOrNotAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (adminCheckBox.Checked)
                if (frmMain.Authority != 1)
                {
                    adminCheckBox.Checked = false;
                    MessageBox.Show(".المستخدم الإداري الرئيسي هو الوحيد الذي يمكنه اضافة مستخدم إداري", Application.ProductName);
                }
            if (cbAdminOrNotAdd.Checked == true)
            {
                customer_card_edit.Checked = true;
                discount_edit.Checked = true;
                price_edit.Checked = true;
                receipt_edit.Checked = true;
                inventory_edit.Checked = true;
                expenses_edit.Checked = true;
                users_edit.Checked = true;
                settings_edit.Checked = true;
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
                Tuple<List<Item>, DataTable> retreivedCustomerItems = Connection.server.RetrieveItems();
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
                MessageBox.Show(".الرجاء اختيار مورد", Application.ProductName);
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
            }
            catch (Exception error)
            {
                MessageBox.Show(".الرجاء اختيار مورد", Application.ProductName);
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

                    MessageBox.Show(".تمت اضافة المورد", Application.ProductName);
                }
                else
                {
                    MessageBox.Show(".لم نتمكن من اضافة المورد", Application.ProductName);
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
                    MessageBox.Show(".تم حذف العميل", Application.ProductName);
                }
                else
                {
                    MessageBox.Show(".لم نستطع حذف العميل", Application.ProductName);
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
                        MessageBox.Show(".تمت اضافة الفاتوره للمورد", Application.ProductName);
                    }
                }
                else
                {
                    MessageBox.Show(".الرجاء إختيار مورد", Application.ProductName);
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".Z تقرير الضريبه";
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير الفواتير";
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
                MessageBox.Show(".الرجاء اختيار سطر فيه ماده", Application.ProductName);
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
                MessageBox.Show(".لا بمكتك دفع فاتوره فارغه", Application.ProductName);
            }
            else
            {
                frmPay frmPayCash = new frmPay(this.totalAmount);
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
                                            MessageBox.Show("قطعه باركود " + item.ItemBarCode + " انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف.");
                                    }
                                    dgvAlerts.DataSource = itemsExpirationStock.Item2;
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
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                richTextBox4.ResetText();
                richTextBox3.ResetText();
                richTextBox3.AppendText(" :المجموع السابق " + this.totalAmount);
                richTextBox2.ResetText();
                richTextBox2.AppendText(" :المدفوع السابق " + this.paidAmount);
                richTextBox1.ResetText();
                richTextBox1.AppendText(" :الباقي السابق " + this.remainderAmount);

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
                    label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                }
            }
        }

        public void label93_MouseClick(object sender, MouseEventArgs e)
        {
            if (userPermissions.customer_card_edit)
            {
                frmCustomerCard customerCard = new frmCustomerCard();
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
                                        richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                    }
                                }
                            }
                        }
                    }

                    customerCard.Dispose();
                    if (replaced)
                        MessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", Application.ProductName);
                    else MessageBox.Show(".تم اضافة خصم العميل", Application.ProductName);


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
                MessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", Application.ProductName);
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
                richTextBox3.AppendText(" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                richTextBox2.ResetText();
                richTextBox2.AppendText(" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                richTextBox1.ResetText();
                richTextBox1.AppendText(" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());

                ItemsPendingPurchase.Rows.Clear();
                this.customersaleItems.Clear();
                this.totalAmount = 0;
                this.paidAmount = 0;
                this.remainderAmount = 0;
                items = null;
                this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                richTextBox5.ResetText();
                richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                heldBillsCount += 1;
                label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
            }
        }

        public void label68_Click(object sender, EventArgs e)
        {
            if (userPermissions.discount_edit)
            {
                try
                {
                    frmSales frmSales = new frmSales();
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
                                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                        }
                                    }
                                }
                            }
                        }

                        frmSales.Dispose();
                        if (replaced)
                            MessageBox.Show(".تعدلت نسبة خصم الأغراض", Application.ProductName);
                        else MessageBox.Show(".تم اضافة الخصم", Application.ProductName);
                    }
                    else if (frmSales.dialogResult == DialogResult.Cancel)
                    {
                        frmSales.Dispose();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(".لم نتمكن من اضافة الخصم", Application.ProductName);
                }
            }
        }

        public void label89_Click(object sender, EventArgs e)
        {
            if (userPermissions.price_edit)
            {
                frmEditPrice editPrice = new frmEditPrice();
                editPrice.ShowDialog();
                if (editPrice.dialogResult == DialogResult.OK)
                {
                    this.totalAmount = editPrice.moneyDeduction;
                    richTextBox4.ResetText();
                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                }
            }
        }

        public void label2_Click(object sender, EventArgs e)
        {
            try
            {

                /*LPrinter MyPrinter = new LPrinter(); // creates the printer object
                MyPrinter.PrinterName = "\\\\" + Environment.MachineName + "\\" + Properties.Settings.Default.PrinterName;
                MyPrinter.Print("");
                printDocument2.Print();*/

                Encoding enc = Encoding.Unicode;
                SerialPort sp = new SerialPort();
                sp.PortName = "COM2";

                sp.Encoding = enc;
                sp.BaudRate = 38400;
                sp.Parity = System.IO.Ports.Parity.None;
                sp.DataBits = 8;
                sp.StopBits = System.IO.Ports.StopBits.One;
                sp.DtrEnable = true;
                sp.Open();
                sp.Write(char.ConvertFromUtf32(28699) + char.ConvertFromUtf32(9472) + char.ConvertFromUtf32(3365));
                sp.Close();

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
                            richTextBox6.AppendText(" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                        }
                        calculateStatistics();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(".لا يمكن اضافة الماده", Application.ProductName);
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
                        MessageBox.Show(".لا بمكتك دفع فاتوره فارغه", Application.ProductName);
                    }
                    else
                    {
                        frmPay frmPayCash = new frmPay(this.totalAmount);
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
                                                    MessageBox.Show("قطعه باركود " + item.ItemBarCode + " انتهت الصلاحيه أو عدد القطع في المخزون وصل الحد المعرف.");
                                            }
                                            dgvAlerts.DataSource = itemsExpirationStock.Item2;
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
                        richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        richTextBox4.ResetText();
                        richTextBox3.ResetText();
                        richTextBox3.AppendText(" :المجموع السابق " + this.totalAmount);
                        richTextBox2.ResetText();
                        richTextBox2.AppendText(" :المدفوع السابق " + this.paidAmount);
                        richTextBox1.ResetText();
                        richTextBox1.AppendText(" :الباقي السابق " + this.remainderAmount);

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
                            label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                        }
                    }
                    break;

                case Keys.F2:
                    if (userPermissions.customer_card_edit)
                    {
                        frmCustomerCard customerCard = new frmCustomerCard();
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
                                                richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                            }
                                        }
                                    }
                                }
                            }

                            customerCard.Dispose();
                            if (replaced)
                                MessageBox.Show(".تعدلت نسبة خصم الأغراض للعميل", Application.ProductName);
                            else MessageBox.Show(".تم اضافة خصم العميل", Application.ProductName);


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
                        MessageBox.Show(".لا بمكتك اضافة فاتوره أخرى قبل تعبئة الفاتوره الحاليه", Application.ProductName);
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
                        richTextBox3.AppendText(" :المجموع السابق " + previousBillsList.Peek().getTotalAmount().ToString());
                        richTextBox2.ResetText();
                        richTextBox2.AppendText(" :المدفوع السابق " + previousBillsList.Peek().getPaidAmount().ToString());
                        richTextBox1.ResetText();
                        richTextBox1.AppendText(" :الباقي السابق " + previousBillsList.Peek().getRemainderAmount().ToString());

                        ItemsPendingPurchase.Rows.Clear();
                        this.customersaleItems.Clear();
                        this.totalAmount = 0;
                        this.paidAmount = 0;
                        this.remainderAmount = 0;
                        items = null;
                        this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
                        richTextBox5.ResetText();
                        richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                        heldBillsCount += 1;
                        label112.Text = heldBillsCount.ToString() + " :عدد الفواتير المعلقه ";
                    }
                    break;

                case Keys.F4:
                    if (userPermissions.discount_edit)
                    {
                        try
                        {
                            frmSales frmSales = new frmSales();
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
                                                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                                }
                                            }
                                        }
                                    }
                                }

                                frmSales.Dispose();
                                if (replaced)
                                    MessageBox.Show(".تعدلت نسبة خصم الأغراض", Application.ProductName);
                                else MessageBox.Show(".تم اضافة الخصم", Application.ProductName);
                            }
                            else if (frmSales.dialogResult == DialogResult.Cancel)
                            {
                                frmSales.Dispose();
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(".لم نتمكن من اضافة الخصم", Application.ProductName);
                        }
                    }
                    break;

                case Keys.F5:
                    if (userPermissions.price_edit)
                    {
                        frmEditPrice editPrice = new frmEditPrice();
                        editPrice.ShowDialog();
                        if (editPrice.dialogResult == DialogResult.OK)
                        {
                            this.totalAmount = editPrice.moneyDeduction;
                            richTextBox4.ResetText();
                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                        }
                    }
                    break;

                case Keys.F6:
                    try
                    {

                        /*LPrinter MyPrinter = new LPrinter(); // creates the printer object
                        MyPrinter.PrinterName = "\\\\" + Environment.MachineName + "\\" + Properties.Settings.Default.PrinterName;
                        MyPrinter.Print("");
                        printDocument2.Print();*/

                        Encoding enc = Encoding.Unicode;
                        SerialPort sp = new SerialPort();
                        sp.PortName = "COM2";

                        sp.Encoding = enc;
                        sp.BaudRate = 38400;
                        sp.Parity = System.IO.Ports.Parity.None;
                        sp.DataBits = 8;
                        sp.StopBits = System.IO.Ports.StopBits.One;
                        sp.DtrEnable = true;
                        sp.Open();
                        sp.Write(char.ConvertFromUtf32(28699) + char.ConvertFromUtf32(9472) + char.ConvertFromUtf32(3365));
                        sp.Close();

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
                            MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName);
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
                        else { MessageBox.Show(".لا بوجد شراء غير مكتمل سابق", Application.ProductName); }
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
                                    richTextBox6.AppendText(" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                                }
                                calculateStatistics();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(".لا يمكن اضافة الماده", Application.ProductName);
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
                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                            richTextBox5.ResetText();
                            richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                            MessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), Application.ProductName);
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
                                        theImage = Properties.Resources.neat_vibez
                                    };
                                    printer.ImbeddedImageList.Add(logo);
                                    printer.Title = ".تقرير اغلاق الصندوف";
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
                                    printer.PrintDataGridView(dgvLoginLogout);
                                    this.WindowState = FormWindowState.Maximized;
                                }
                                catch (Exception ex)
                                {
                                    this.WindowState = FormWindowState.Maximized;
                                    MessageBox.Show(ex.Message.ToString(), Application.ProductName);
                                }

                                MessageBox.Show(".لفد قمت باغلاق الصندوق", Application.ProductName);
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
                                theImage = Properties.Resources.neat_vibez
                            };
                            printer.ImbeddedImageList.Add(logo);
                            printer.Title = ".تقرير اغلاق الصندوف";
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
                            printer.PrintDataGridView(dgvLoginLogout);
                            this.WindowState = FormWindowState.Maximized;
                        }
                        catch (Exception ex)
                        {
                            this.WindowState = FormWindowState.Maximized;
                            MessageBox.Show(ex.Message.ToString(), Application.ProductName);
                        }

                        MessageBox.Show(".لفد قمت باغلاق الصندوق", Application.ProductName);
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
                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                    richTextBox5.ResetText();
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                    MessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), Application.ProductName);
                    this.Select();
                }
            }
        }

        public void txtUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
        }

        public void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = WarehousesQuantityList.SelectedItem.ToString() + " تقرير جرد المستودع ";
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

                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (itemLookup.selectedItem != null)
                        {
                            WarehouseEntryExitItemBarCode.Text = itemLookup.selectedItem.GetItemBarCode();
                            WarehouseEntryExitItemName.Text = itemLookup.selectedItem.GetName();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(".لا يمكن اختيار الماده", Application.ProductName);
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
                    MessageBox.Show(".تم ادخال العمليه", Application.ProductName);
                }
                else
                {
                    MessageBox.Show(".لم نتمكن من ادخال العمليه", Application.ProductName);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(".لم نتمكن من اتمام العمليه", Application.ProductName);
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
                MessageBox.Show(".الاضافه فقط من حساب اداري إداري", this.ProductName);
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
                    MessageBox.Show(".تم تسجيل الموظف", Application.ProductName);

                }
                else MessageBox.Show(".لم نتمكن من تسجيل الموظف", Application.ProductName);
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
                MessageBox.Show(".التعديل فقط من حساب اداري إداري", this.ProductName);
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
                    MessageBox.Show(".لا يمكن حذف الموظف", Application.ProductName);
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
                MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
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
                MessageBox.Show(".الاضافه فقط من حساب اداري إداري", this.ProductName);
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
                        MessageBox.Show(".تم تسجيل الغياب", Application.ProductName);

                    }
                    else MessageBox.Show(".لم نتمكن من تسجيل الغياب", Application.ProductName);
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
                    MessageBox.Show(".تم تسجيل الغياب", Application.ProductName);
                }
            }
        }

        public void button33_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                MessageBox.Show(".التعديل فقط من حساب اداري إداري", this.ProductName);
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
                    MessageBox.Show(".لا يمكن حذف الغياب", Application.ProductName);
                }
                AbsenceID = 0;
                button33.Enabled = false;
            }
        }

        public void button35_Click(object sender, EventArgs e)
        {
            if (frmMain.Authority != 1)
            {
                MessageBox.Show(".التعديل فقط من حساب اداري إداري", this.ProductName);
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
                    MessageBox.Show(".لا يمكن حذف الغياب", Application.ProductName);
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
                MessageBox.Show(".لم نستطيع حذف الماده", Application.ProductName);
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
            BillsCashierName.Select(0, BillsCashierName.Text.Length);
            pendingPurchaseRemovalQuantity.Focus();
        }

        public void QuantityWarning_Enter_1(object sender, EventArgs e)
        {
            QuantityWarning.Select(0, QuantityWarning.Value.ToString().Length);
            pendingPurchaseRemovalQuantity.Focus();
        }

        public void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                bool addedFavoriteCategory = Connection.server.InsertFavoriteCategory(FavoriteCategoryEntry.Text);
                if (addedFavoriteCategory)
                {
                    DisplayFavorites();
                    MessageBox.Show(".تم حفظ المفضلات الجديده");
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
                    MessageBox.Show(".تم حفظ المفضلات الجديده");
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير المواد المرجعه";
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
                printer.PrintDataGridView(dgvReturnedItems);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        public void groupBox30_Enter(object sender, EventArgs e)
        {
             
        }

        public void groupBox26_Enter(object sender, EventArgs e)
        {

        }

        public void groupBox36_Enter(object sender, EventArgs e)
        {

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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = "تقرير جرد الكميات المباعة";
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = "تقرير لائحة الفواتير";
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير الفواتير";
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
                    Properties.Settings.Default["Logo"] = open.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            catch(Exception err)
            {
                Properties.Settings.Default["Logo"] = "";
                Properties.Settings.Default.Save();
                picLogoStore.Image = Resources.neat_vibez;
                picLogo.Image = Resources.neat_vibez;
            }
        }

        public void button29_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["Logo"] = "";
                Properties.Settings.Default.Save();
                picLogoStore.Image = Resources.neat_vibez;
                picLogo.Image = Resources.neat_vibez;
            }
            catch (Exception err)
            { }
        }

        private void lastBillNumberUpdaterTimer_Tick(object sender, EventArgs e)
        {
            this.CurrentBillNumber = Connection.server.RetrieveLastBillNumberToday().getBillNumber() + 1;
            richTextBox5.ResetText();
            richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
        }

        private void updateWarehouses_Tick(object sender, EventArgs e)
        {
            DisplayItemTypes();
            DisplayFavoriteItems();
            DisplayWarehouses();
            DisplayFavorites();
            refreshInventoryItems();
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
                MessageBox.Show(".التعديل فقط من حساب اداري إداري", this.ProductName);
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
                    MessageBox.Show(".لا يمكن تحديث الموظف", Application.ProductName);
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
                MessageBox.Show(".الرجاء ادخال جميع البيانات!", Application.ProductName);
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
                MessageBox.Show(".لم نستطيع حذف الماده", Application.ProductName);
            }
        }

        public void button10_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);

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
                                dgvVendorItemsPick.Rows[index].Cells["VendorItemType"].Value = Connection.server.RetrieveItemTypeName(itemLookup.selectedItem.GetItemTypeeID());
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
                        MessageBox.Show(".لا يمكن اختيار الماده", Application.ProductName);
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
                    theImage = Properties.Resources.neat_vibez
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = ".تقرير التنبيهات";
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

        public void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtUID.Text != "" && txtPWD.Text != "" && txtFname.Text != "")
            {
                Account newAccount = new Account();
                newAccount.SetAccountUID(txtUID.Text);
                newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPWD.Text, "NeatVibezPOS"));
                newAccount.SetAccountName(txtFname.Text);
                newAccount.customer_card_edit = customer_card_edit.Checked;
                newAccount.discount_edit = discount_edit.Checked;
                newAccount.price_edit = price_edit.Checked;
                newAccount.receipt_edit = receipt_edit.Checked;
                newAccount.inventory_edit = inventory_edit.Checked;
                newAccount.expenses_add = expenses_edit.Checked;
                newAccount.users_edit = users_edit.Checked;
                newAccount.settings_edit = settings_edit.Checked;

                int AdminOrNot = Convert.ToInt32(adminCheckBox.Checked);

                if (Connection.server.Register(newAccount,  this.UID, AdminOrNot))
                {
                    MessageBox.Show(".تم تسجيل حساب المستخدم", Application.ProductName);
                    txtUID.Text = "";
                    txtPWD.Text = "";
                    txtFname.Text = "";
                    adminCheckBox.Checked = false;
                    DisplayCashierNames();
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
                else MessageBox.Show(".لم نتمكن من تسجيل حساب المستخدم", Application.ProductName);
            }
        }

        public void pictureBox39_Click(object sender, EventArgs e)
        {
            bool addedItemType = Connection.server.InsertItemType(ItemTypeEntry.Text);
            if (addedItemType)
            {
                DisplayItemTypes();
            }
        }

        public void pictureBox37_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);

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
                            richTextBox6.AppendText(" :الباركود " + itemLookup.selectedItem.GetItemBarCode());
                        }
                        calculateStatistics();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(".لا يمكن اضافة الماده", Application.ProductName);
                    }
                }
            }
            catch (Exception error)
            {
            }
        }

        public void pictureBox38_Click(object sender, EventArgs e)
        {
            bool addedWarehouse = Connection.server.InsertWarehouse(WarehouseEntry.Text);
            if (addedWarehouse)
            {
                DisplayWarehouses();
            }
        }

        public void pictureBox16_Click(object sender, EventArgs e)
        {
            if (!userPermissions.openclose_edit)
                return;

            try
            {
                frmCloseRegister closeRegister = new frmCloseRegister(this.cashierName, Connection.server.GetOpenRegisterAmount());

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
                                theImage = Properties.Resources.neat_vibez
                            };
                            printer.ImbeddedImageList.Add(logo);
                            printer.Title = ".تقرير اغلاق الصندوف";
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
                            printer.PrintDataGridView(dgvLoginLogout);
                            this.WindowState = FormWindowState.Maximized;
                        }
                        catch (Exception ex)
                        {
                            this.WindowState = FormWindowState.Maximized;
                            MessageBox.Show(ex.Message.ToString(), Application.ProductName);
                        }

                        MessageBox.Show(".لفد قمت باغلاق الصندوق", Application.ProductName);
                    }
                }
            } catch (Exception error)
            {

            }
        }

        public void pictureBox36_Click(object sender, EventArgs e)
        {
            bool addedFavoriteCategory = Connection.server.InsertFavoriteCategory(FavoriteCategoryEntry.Text);
            if (addedFavoriteCategory)
            {
                DisplayFavorites();
            }
        }

        public void pictureBox15_Click(object sender, EventArgs e)
        {
            if (!userPermissions.openclose_edit)
                return;

            frmOpenRegister openRegister = new frmOpenRegister(this.cashierName);

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
                    richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                    richTextBox5.ResetText();
                    richTextBox5.AppendText(" :رقم الفاتورة الحالية " + this.CurrentBillNumber);
                    MessageBox.Show(String.Format(".لفد قمت بفتح الصندوق بمبلغ قدره {0} دينار", moneyInRegister), Application.ProductName);
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
                                            richTextBox4.AppendText(" :المجموع كامل " + this.totalAmount);
                                        }
                                    }
                                }
                            }
                        }

                        frmSales.Dispose();
                        if (replaced)
                            MessageBox.Show(".تعدلت نسبة خصم الأغراض", Application.ProductName);
                        else MessageBox.Show(".تم اضافة الخصم", Application.ProductName);
                    }
                    else if (frmSales.dialogResult == DialogResult.Cancel)
                    {
                        frmSales.Dispose();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(".لم نتمكن من اضافة الخصم", Application.ProductName);
                }
            }
        }

        public void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
            try
            {
                System.IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Receipts", true);
            } catch(Exception error) { }
        }

        public void printCertainReceipt(int BillNumber, string cashierName, decimal totalAmount, decimal paidAmount, decimal remainderAmount, DateTime invoiceDate)
        {
            try
            {
                string welcome = "شكرا لزيارتك متجرنا ";
                string welcome2 = this.NeatVibezPOSName;
                string InvoiceNo = "" + BillNumber.ToString() + "رقم الفاتورة الحالية ";
                string cashierNamePrint = cashierName + " :اسم الكاشير";
                decimal gross = Convert.ToDecimal(totalAmount);
                decimal net = Convert.ToDecimal(totalAmount);
                decimal discount = gross - net;
                decimal amountPaid = paidAmount;
                decimal remainder = remainderAmount;
                string InvoiceDate = invoiceDate.ToString();

                int lineHeight = 20;
                int height = 20;

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
                        newfont2 = new Font("Calibri", 11, FontStyle.Bold);
                        itemFont = new Font("Calibri", 11, FontStyle.Bold);

                        black = new SolidBrush(Color.Black);
                        white = new SolidBrush(Color.White);

                        //PointF point = new PointF(40f, 2f);


                        offsetY = offsetY + lineHeight;
                        graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                        graphic.DrawString(this.shopPhone.Text, newfont2, black, (bitm.Width / 2) - Properties.Settings.Default.receiptSpacing, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome2, newfont2, black, (bitm.Width / 3) - (welcome.Length + 5), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome, newfont2, black, (bitm.Width / 3) - (welcome.Length + 10), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        //graphic.DrawImage(ResizeImage(Resources.neat_vibez, 150, 150), (bitm.Width / 2) - 150, 0);
                        graphic.DrawString(InvoiceNo, newfont2, black, (bitm.Width / 3) - InvoiceNo.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;

                        //PointF pointPrice = new PointF(15f, 45f);
                        graphic.DrawString("" + InvoiceDate + "", newfont2, black, (bitm.Width / 3) - (InvoiceDate.Length + 7), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(cashierNamePrint, newfont2, black, (bitm.Width / 3) - cashierNamePrint.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;

                        graphic.DrawString("  إسم المنتج      " + "               الكمية      " + "          السعر ", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("----------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        //PointF pointPname = new PointF(10f, 65f);
                        //PointF pointBar = new PointF(10f, 65f);

                        offsetY = offsetY + lineHeight;

                        for (int i = 0; i < dgvBillItems.Rows.Count; i++)
                        {
                            if (!dgvBillItems.Rows[i].IsNewRow)
                            {
                                int ii = 1;
                                ii++;
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
                        graphic.DrawString("----------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("الإجمالي :" + gross + "" + "                           " + "الخصم :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("الصافي :" + net + "" + "                         " + "المدفوع :" + amountPaid + "", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("الباقي :" + remainder + "", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("----------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                    }
                    finally
                    {
                        black.Dispose();
                        white.Dispose();
                        itemFont.Dispose();
                        newfont2.Dispose();
                        button21.Select();
                        button21.Focus();
                        this.ActiveControl = button21;
                        groupBox5.Location = new Point(this.Width / 3, 0);
                        groupBox5.Visible = true;
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
                        pictureBox1.Image = bitm;
                    }
                    catch (Exception error)
                    {
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(".لم نتمكن من طباعة الفاتوره", Application.ProductName);
            }
        }

        public void printReceipt()
        {
            try
            {
                string welcome = "شكرا لزيارتك متجرنا ";
                string welcome2 = this.NeatVibezPOSName;
                string InvoiceNo = "" + this.CurrentBillNumber.ToString() + "رقم الفاتورة الحالية ";
                string cashierNamePrint = this.cashierName + " :اسم الكاشير";
                decimal gross = Convert.ToDecimal(this.totalAmount);
                decimal net = Convert.ToDecimal(this.totalAmount);
                decimal discount = gross - net;
                decimal amountPaid = this.paidAmount;
                decimal remainder = this.remainderAmount;
                string InvoiceDate = DateTime.Now.ToString();

                int lineHeight = 20;
                int height = 20;

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
                        newfont2 = new Font("Calibri", 11, FontStyle.Bold);
                        itemFont = new Font("Calibri", 11, FontStyle.Bold);

                        black = new SolidBrush(Color.Black);
                        white = new SolidBrush(Color.White);

                        //PointF point = new PointF(40f, 2f);


                        offsetY = offsetY + lineHeight;
                        graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                        graphic.DrawString(this.shopPhone.Text, newfont2, black, (bitm.Width / 2) - Properties.Settings.Default.receiptSpacing, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome2, newfont2, black, (bitm.Width / 3) - (welcome.Length + 5), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(welcome, newfont2, black, (bitm.Width / 3) - (welcome.Length + 10), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        //graphic.DrawImage(ResizeImage(Resources.neat_vibez, 150, 150), (bitm.Width / 2) - 150, 0);
                        graphic.DrawString(InvoiceNo, newfont2, black, (bitm.Width / 3) - InvoiceNo.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;

                        //PointF pointPrice = new PointF(15f, 45f);
                        graphic.DrawString("" + InvoiceDate + "", newfont2, black, (bitm.Width / 3) - (InvoiceDate.Length + 7), startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(cashierNamePrint, newfont2, black, (bitm.Width / 3) - cashierNamePrint.Length, startY + offsetY);
                        offsetY = offsetY + lineHeight;

                        graphic.DrawString("  إسم المنتج      " + "               الكمية      " + "          السعر ", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("----------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        //PointF pointPname = new PointF(10f, 65f);
                        //PointF pointBar = new PointF(10f, 65f);

                        offsetY = offsetY + lineHeight;

                        for (int i = 0; i < ItemsPendingPurchase.Rows.Count; i++)
                        {
                            if (!ItemsPendingPurchase.Rows[i].IsNewRow)
                            {
                                int ii = 1;
                                ii++;
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
                        graphic.DrawString("----------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("الإجمالي :" + gross + "" + "                           " + "الخصم :" + discount + "", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("الصافي :" + net + "" + "                         " + "المدفوع :" + amountPaid + "", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("الباقي :" + remainder + "", newfont2, black, startX + 15, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString("----------------------------------------------------------", newfont2, black, startX, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                    }
                    finally
                    {
                        black.Dispose();
                        white.Dispose();
                        itemFont.Dispose();
                        newfont2.Dispose();
                        button21.Select();
                        button21.Focus();
                        this.ActiveControl = button21;
                        groupBox5.Location = new Point(this.Width / 3, 0);
                        groupBox5.Visible = true;
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
                        pictureBox1.Image = bitm;
                    }
                    catch (Exception error)
                    {
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(".لم نتمكن من طباعة الفاتوره", Application.ProductName);
            }
        }

        public void printCloseRegister()
        {
            try
            {
                int lineHeight = 20;
                int height = 30;

                Bitmap bitm = new Bitmap(354, height + 140);
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

                        //PointF point = new PointF(40f, 2f);
                        
                        offsetY = offsetY + lineHeight;
                        graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                        graphic.DrawString("تقرير اغلاق الصندوق", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(this.cashierName + " اسم الكاشير: ", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(Connection.server.GetLastOpenRegisterDate() + " تاريخ فتح الصندوق ", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(DateTime.Now.ToShortDateString() + " تاريخ اغلاق الصندوق ", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        decimal openRegisterAmount = Connection.server.GetOpenRegisterAmount();
                        decimal totalSalesAmount = Connection.server.GetTotalSalesAmount();
                        graphic.DrawString(openRegisterAmount.ToString() + " أرضية الكاش ", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(totalSalesAmount.ToString() + " مبلغ المبيعات ", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
                        graphic.DrawString(Convert.ToDecimal(openRegisterAmount + totalSalesAmount).ToString() + " المجموع الكلي ", newfont2, black, 0, startY + offsetY);
                        offsetY = offsetY + lineHeight;
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
                    pictureBox1.Image = bitm;
                    printDocument1.Print();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(".لم نتمكن من طباعة الفاتوره", Application.ProductName);
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
