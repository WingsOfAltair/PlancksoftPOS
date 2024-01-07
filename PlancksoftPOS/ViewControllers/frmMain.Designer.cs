using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace PlancksoftPOS
{
    partial class frmMain
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ادارةالمستودعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةمادهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةصنفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةمستودعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةمستودعToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.Cash = new System.Windows.Forms.TabPage();
            this.groupBox1 = new MaterialSkin.Controls.MaterialCard();
            this.pnlOpenCloseCash = new MaterialSkin.Controls.MaterialCard();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.panel3 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label65 = new MaterialSkin.Controls.MaterialLabel();
            this.label66 = new MaterialSkin.Controls.MaterialLabel();
            this.openRegisterBtn = new System.Windows.Forms.PictureBox();
            this.closeRegisterBtn = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new MaterialSkin.Controls.MaterialCard();
            this.ItemsPendingPurchase = new System.Windows.Forms.DataGridView();
            this.pendingPurchaseItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPurchaseItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPurchaseItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPurchaseItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPurchaseItemPriceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new MaterialSkin.Controls.MaterialCard();
            this.dgvLoginLogout = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendingPurchaseNewPriceTax = new System.Windows.Forms.NumericUpDown();
            this.label51 = new MaterialSkin.Controls.MaterialLabel();
            this.label50 = new MaterialSkin.Controls.MaterialLabel();
            this.label52 = new MaterialSkin.Controls.MaterialLabel();
            this.label49 = new MaterialSkin.Controls.MaterialLabel();
            this.button24 = new MaterialSkin.Controls.MaterialButton();
            this.button23 = new MaterialSkin.Controls.MaterialButton();
            this.pendingPurchaseNewPrice = new System.Windows.Forms.NumericUpDown();
            this.button17 = new MaterialSkin.Controls.MaterialButton();
            this.richTextBox4 = new MaterialSkin.Controls.MaterialLabel();
            this.richTextBox6 = new MaterialSkin.Controls.MaterialLabel();
            this.pendingPurchaseRemovalQuantity = new System.Windows.Forms.NumericUpDown();
            this.pendingPurchaseNewQuantity = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new MaterialSkin.Controls.MaterialCard();
            this.richTextBox3 = new MaterialSkin.Controls.MaterialLabel();
            this.richTextBox2 = new MaterialSkin.Controls.MaterialLabel();
            this.richTextBox1 = new MaterialSkin.Controls.MaterialLabel();
            this.richTextBox5 = new MaterialSkin.Controls.MaterialLabel();
            this.label112 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cashierNameLbl = new MaterialSkin.Controls.MaterialLabel();
            this.label71 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimeLbl = new MaterialSkin.Controls.MaterialLabel();
            this.label45 = new MaterialSkin.Controls.MaterialLabel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.Sales = new System.Windows.Forms.TabPage();
            this.tabControl4 = new MaterialSkin.Controls.MaterialTabControl();
            this.InvoicesSales = new System.Windows.Forms.TabPage();
            this.groupBox14 = new MaterialSkin.Controls.MaterialCard();
            this.panel9 = new MaterialSkin.Controls.MaterialCard();
            this.dgvBillItems = new System.Windows.Forms.DataGridView();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new MaterialSkin.Controls.MaterialCard();
            this.button18 = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.button25 = new MaterialSkin.Controls.MaterialButton();
            this.groupBox12 = new MaterialSkin.Controls.MaterialCard();
            this.panel7 = new MaterialSkin.Controls.MaterialCard();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new MaterialSkin.Controls.MaterialCard();
            this.button26 = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.groupBox13 = new MaterialSkin.Controls.MaterialCard();
            this.cbSalesDateSearch = new MaterialSkin.Controls.MaterialCheckbox();
            this.nudBillNumberSearch = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label84 = new MaterialSkin.Controls.MaterialLabel();
            this.label85 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label87 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.EditInvoices = new System.Windows.Forms.TabPage();
            this.groupBox30 = new MaterialSkin.Controls.MaterialCard();
            this.panel12 = new MaterialSkin.Controls.MaterialCard();
            this.dgvBillsEdit = new System.Windows.Forms.DataGridView();
            this.BillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillCashierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillRemainderAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillPaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new MaterialSkin.Controls.MaterialCard();
            this.BillsEditButton = new MaterialSkin.Controls.MaterialButton();
            this.BillsCashierName = new MaterialSkin.Controls.MaterialTextBox2();
            this.BillEditNumber = new System.Windows.Forms.NumericUpDown();
            this.label11 = new MaterialSkin.Controls.MaterialLabel();
            this.label13 = new MaterialSkin.Controls.MaterialLabel();
            this.label9 = new MaterialSkin.Controls.MaterialLabel();
            this.BillsRemainderAmount = new System.Windows.Forms.NumericUpDown();
            this.BillsTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.label12 = new MaterialSkin.Controls.MaterialLabel();
            this.label10 = new MaterialSkin.Controls.MaterialLabel();
            this.BillsPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.panel10 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox32 = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            this.groupBox29 = new MaterialSkin.Controls.MaterialCard();
            this.nudBillNumberEdit = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new MaterialSkin.Controls.MaterialLabel();
            this.label7 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            this.TravelingUntravelingSales = new System.Windows.Forms.TabPage();
            this.groupBox26 = new MaterialSkin.Controls.MaterialCard();
            this.panel16 = new MaterialSkin.Controls.MaterialCard();
            this.dgvPortedSales = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPorted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel15 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.groupBox25 = new MaterialSkin.Controls.MaterialCard();
            this.panel14 = new MaterialSkin.Controls.MaterialCard();
            this.dgvUnPortedSales = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalUnPorted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel13 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.SoldItems = new System.Windows.Forms.TabPage();
            this.groupBox28 = new MaterialSkin.Controls.MaterialCard();
            this.label38 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label37 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox30 = new System.Windows.Forms.PictureBox();
            this.groupBox27 = new MaterialSkin.Controls.MaterialCard();
            this.dgvItemProfit = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPriceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox29 = new System.Windows.Forms.PictureBox();
            this.Inventory = new System.Windows.Forms.TabPage();
            this.tabControl6 = new MaterialSkin.Controls.MaterialTabControl();
            this.posInventory = new System.Windows.Forms.TabPage();
            this.groupBox8 = new MaterialSkin.Controls.MaterialCard();
            this.panel17 = new MaterialSkin.Controls.MaterialCard();
            this.DgvInventory = new System.Windows.Forms.DataGridView();
            this.InventoryItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemSellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemSellPriceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FavoriteCategoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemFavoriteCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemTypeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel18 = new MaterialSkin.Controls.MaterialCard();
            this.BtnDeleteItem = new MaterialSkin.Controls.MaterialButton();
            this.BtnPrint = new System.Windows.Forms.PictureBox();
            this.BtnUpdateItem = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox99 = new System.Windows.Forms.PictureBox();
            this.BtnAddItem = new MaterialSkin.Controls.MaterialButton();
            this.groupBox36 = new MaterialSkin.Controls.MaterialCard();
            this.label55 = new MaterialSkin.Controls.MaterialLabel();
            this.nuditemPrice = new System.Windows.Forms.NumericUpDown();
            this.label63 = new MaterialSkin.Controls.MaterialLabel();
            this.nuditemPriceTax = new System.Windows.Forms.NumericUpDown();
            this.label64 = new MaterialSkin.Controls.MaterialLabel();
            this.FavoriteCategories = new System.Windows.Forms.ComboBox();
            this.nudItemBuyPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new MaterialSkin.Controls.MaterialLabel();
            this.ItemType = new System.Windows.Forms.ComboBox();
            this.ProductionDate = new System.Windows.Forms.DateTimePicker();
            this.label36 = new MaterialSkin.Controls.MaterialLabel();
            this.QuantityWarning = new System.Windows.Forms.NumericUpDown();
            this.ExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.txtItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.EntryDate = new System.Windows.Forms.DateTimePicker();
            this.label62 = new MaterialSkin.Controls.MaterialLabel();
            this.txtItemBarCode = new MaterialSkin.Controls.MaterialTextBox2();
            this.label35 = new MaterialSkin.Controls.MaterialLabel();
            this.label61 = new MaterialSkin.Controls.MaterialLabel();
            this.label34 = new MaterialSkin.Controls.MaterialLabel();
            this.label60 = new MaterialSkin.Controls.MaterialLabel();
            this.nudItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.label33 = new MaterialSkin.Controls.MaterialLabel();
            this.label28 = new MaterialSkin.Controls.MaterialLabel();
            this.Warehouse = new System.Windows.Forms.ComboBox();
            this.label25 = new MaterialSkin.Controls.MaterialLabel();
            this.PBAddProfilePicture = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new MaterialSkin.Controls.MaterialCard();
            this.BtnSearchItem = new MaterialSkin.Controls.MaterialButton();
            this.nudItemBarCodeSearch = new MaterialSkin.Controls.MaterialTextBox2();
            this.dtpSearch2 = new System.Windows.Forms.DateTimePicker();
            this.label56 = new MaterialSkin.Controls.MaterialLabel();
            this.label57 = new MaterialSkin.Controls.MaterialLabel();
            this.label58 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpSearch1 = new System.Windows.Forms.DateTimePicker();
            this.txtItemNameSearch = new MaterialSkin.Controls.MaterialTextBox2();
            this.label59 = new MaterialSkin.Controls.MaterialLabel();
            this.InventoryQuantify = new System.Windows.Forms.TabPage();
            this.groupBox45 = new MaterialSkin.Controls.MaterialCard();
            this.button13 = new MaterialSkin.Controls.MaterialButton();
            this.WarehousesQuantityList = new System.Windows.Forms.ComboBox();
            this.label47 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox46 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox47 = new System.Windows.Forms.PictureBox();
            this.dgvWarehouseInventory = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomingOutgoingItems = new System.Windows.Forms.TabPage();
            this.groupBox48 = new MaterialSkin.Controls.MaterialCard();
            this.btnPickClientForImportExport = new MaterialSkin.Controls.MaterialButton();
            this.txtClientNameImportExport = new MaterialSkin.Controls.MaterialTextBox2();
            this.nudClientIDImportExport = new System.Windows.Forms.NumericUpDown();
            this.lblClientIDImportExport = new MaterialSkin.Controls.MaterialLabel();
            this.lblClientNameImportExport = new MaterialSkin.Controls.MaterialLabel();
            this.button15 = new MaterialSkin.Controls.MaterialButton();
            this.button36 = new MaterialSkin.Controls.MaterialButton();
            this.button38 = new MaterialSkin.Controls.MaterialButton();
            this.button14 = new MaterialSkin.Controls.MaterialButton();
            this.label46 = new MaterialSkin.Controls.MaterialLabel();
            this.EntryExitItemBuyPrice = new System.Windows.Forms.NumericUpDown();
            this.dvgEntryExitItems = new System.Windows.Forms.DataGridView();
            this.EntryExitItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemQuantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemVendorItemBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemWarningQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryExitItemEntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseEntryExitList = new System.Windows.Forms.ComboBox();
            this.label103 = new MaterialSkin.Controls.MaterialLabel();
            this.EntryExitType = new System.Windows.Forms.ComboBox();
            this.label53 = new MaterialSkin.Controls.MaterialLabel();
            this.WarehouseEntryExitItemBarCode = new MaterialSkin.Controls.MaterialTextBox2();
            this.WarehouseEntryExitItemName = new MaterialSkin.Controls.MaterialTextBox2();
            this.EntryExitProductionDate = new System.Windows.Forms.DateTimePicker();
            this.label48 = new MaterialSkin.Controls.MaterialLabel();
            this.label79 = new MaterialSkin.Controls.MaterialLabel();
            this.EntryExitWarningQuantity = new System.Windows.Forms.NumericUpDown();
            this.EntryExitExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.EntryExitEntryDate = new System.Windows.Forms.DateTimePicker();
            this.label94 = new MaterialSkin.Controls.MaterialLabel();
            this.label96 = new MaterialSkin.Controls.MaterialLabel();
            this.label97 = new MaterialSkin.Controls.MaterialLabel();
            this.EntryExitItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.label98 = new MaterialSkin.Controls.MaterialLabel();
            this.label101 = new MaterialSkin.Controls.MaterialLabel();
            this.AddTypes = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label29 = new MaterialSkin.Controls.MaterialLabel();
            this.ItemTypeEntry = new MaterialSkin.Controls.MaterialTextBox2();
            this.label30 = new MaterialSkin.Controls.MaterialLabel();
            this.ItemTypeAddButton = new System.Windows.Forms.PictureBox();
            this.AddFavorites = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label22 = new MaterialSkin.Controls.MaterialLabel();
            this.FavoriteCategoryEntry = new MaterialSkin.Controls.MaterialTextBox2();
            this.label23 = new MaterialSkin.Controls.MaterialLabel();
            this.FavoriteCategoryAddButton = new System.Windows.Forms.PictureBox();
            this.AddWarehouses = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label26 = new MaterialSkin.Controls.MaterialLabel();
            this.WarehouseEntry = new MaterialSkin.Controls.MaterialTextBox2();
            this.label27 = new MaterialSkin.Controls.MaterialLabel();
            this.WarehouseAddButton = new System.Windows.Forms.PictureBox();
            this.Expenses = new System.Windows.Forms.TabPage();
            this.tabControl5 = new MaterialSkin.Controls.MaterialTabControl();
            this.SearchExpenses = new System.Windows.Forms.TabPage();
            this.groupBox31 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox34 = new System.Windows.Forms.PictureBox();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox22 = new MaterialSkin.Controls.MaterialCard();
            this.CapitalAmountnud = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label17 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox1 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label16 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker7 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker8 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox33 = new System.Windows.Forms.PictureBox();
            this.AddExpenses = new System.Windows.Forms.TabPage();
            this.groupBox33 = new MaterialSkin.Controls.MaterialCard();
            this.button3 = new MaterialSkin.Controls.MaterialButton();
            this.button2 = new MaterialSkin.Controls.MaterialButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label20 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox4 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label19 = new MaterialSkin.Controls.MaterialLabel();
            this.IncomingOutgoing = new System.Windows.Forms.TabPage();
            this.groupBox21 = new MaterialSkin.Controls.MaterialCard();
            this.label116 = new MaterialSkin.Controls.MaterialLabel();
            this.label115 = new MaterialSkin.Controls.MaterialLabel();
            this.label91 = new MaterialSkin.Controls.MaterialLabel();
            this.label80 = new MaterialSkin.Controls.MaterialLabel();
            this.dvgCapital = new System.Windows.Forms.DataGridView();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.groupBox20 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.dgvImports = new System.Windows.Forms.DataGridView();
            this.Column35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox19 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.dgvExports = new System.Windows.Forms.DataGridView();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employees = new System.Windows.Forms.TabPage();
            this.tabControl8 = new MaterialSkin.Controls.MaterialTabControl();
            this.EmployeesManagement = new System.Windows.Forms.TabPage();
            this.groupBox49 = new MaterialSkin.Controls.MaterialCard();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateEmployeeTo = new System.Windows.Forms.DateTimePicker();
            this.DateEmployeeFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox50 = new MaterialSkin.Controls.MaterialCard();
            this.button35 = new MaterialSkin.Controls.MaterialButton();
            this.button37 = new MaterialSkin.Controls.MaterialButton();
            this.button16 = new MaterialSkin.Controls.MaterialButton();
            this.button32 = new MaterialSkin.Controls.MaterialButton();
            this.SalaryDeduction = new System.Windows.Forms.NumericUpDown();
            this.label111 = new MaterialSkin.Controls.MaterialLabel();
            this.AbsenceHours = new System.Windows.Forms.ComboBox();
            this.AbsenceDate = new System.Windows.Forms.DateTimePicker();
            this.label107 = new MaterialSkin.Controls.MaterialLabel();
            this.label106 = new MaterialSkin.Controls.MaterialLabel();
            this.label109 = new MaterialSkin.Controls.MaterialLabel();
            this.AbsenceEmpName = new MaterialSkin.Controls.MaterialTextBox2();
            this.label99 = new MaterialSkin.Controls.MaterialLabel();
            this.EditEmployeeAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.label95 = new MaterialSkin.Controls.MaterialLabel();
            this.EditEmployeePhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.EditEmployeeSalary = new System.Windows.Forms.NumericUpDown();
            this.label92 = new MaterialSkin.Controls.MaterialLabel();
            this.label54 = new MaterialSkin.Controls.MaterialLabel();
            this.EditEmployeeName = new MaterialSkin.Controls.MaterialTextBox2();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.Column54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox52 = new MaterialSkin.Controls.MaterialCard();
            this.button34 = new MaterialSkin.Controls.MaterialButton();
            this.label105 = new MaterialSkin.Controls.MaterialLabel();
            this.AddEmployeeAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.label104 = new MaterialSkin.Controls.MaterialLabel();
            this.AddEmployeePhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.AddEmployeeSalary = new System.Windows.Forms.NumericUpDown();
            this.label100 = new MaterialSkin.Controls.MaterialLabel();
            this.label102 = new MaterialSkin.Controls.MaterialLabel();
            this.AddEmployeeName = new MaterialSkin.Controls.MaterialTextBox2();
            this.DaysOff = new System.Windows.Forms.TabPage();
            this.groupBox51 = new MaterialSkin.Controls.MaterialCard();
            this.button33 = new MaterialSkin.Controls.MaterialButton();
            this.AbsenceTo = new System.Windows.Forms.DateTimePicker();
            this.label110 = new MaterialSkin.Controls.MaterialLabel();
            this.AbsenceFrom = new System.Windows.Forms.DateTimePicker();
            this.label108 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvAbsence = new System.Windows.Forms.DataGridView();
            this.Column58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox48 = new System.Windows.Forms.PictureBox();
            this.pictureBox43 = new System.Windows.Forms.PictureBox();
            this.Agents = new System.Windows.Forms.TabPage();
            this.tabControl3 = new MaterialSkin.Controls.MaterialTabControl();
            this.AgentsDefinitions = new System.Windows.Forms.TabPage();
            this.groupBox15 = new MaterialSkin.Controls.MaterialCard();
            this.selectAllClients = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new MaterialSkin.Controls.MaterialCard();
            this.btnClientBalanceCheck = new MaterialSkin.Controls.MaterialButton();
            this.btnClientDelete = new MaterialSkin.Controls.MaterialButton();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientIDDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.groupBox17 = new MaterialSkin.Controls.MaterialCard();
            this.ClientEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            this.ClientName = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnClientAdd = new MaterialSkin.Controls.MaterialButton();
            this.ClientAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.ClientPhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.label21 = new MaterialSkin.Controls.MaterialLabel();
            this.label18 = new MaterialSkin.Controls.MaterialLabel();
            this.ClientID = new System.Windows.Forms.NumericUpDown();
            this.label82 = new MaterialSkin.Controls.MaterialLabel();
            this.label83 = new MaterialSkin.Controls.MaterialLabel();
            this.ClientBalanceCheck = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.btnPrintClientBillItems = new System.Windows.Forms.PictureBox();
            this.dgvClientBillItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.btnPayDebtBill = new MaterialSkin.Controls.MaterialButton();
            this.dgvClientBills = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientBillsPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientBillsRemainderAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintClientBills = new System.Windows.Forms.PictureBox();
            this.ImporterDefinitions = new System.Windows.Forms.TabPage();
            this.groupBox39 = new MaterialSkin.Controls.MaterialCard();
            this.selectAllVendors = new System.Windows.Forms.CheckBox();
            this.groupBox38 = new MaterialSkin.Controls.MaterialCard();
            this.button8 = new MaterialSkin.Controls.MaterialButton();
            this.button9 = new MaterialSkin.Controls.MaterialButton();
            this.button6 = new MaterialSkin.Controls.MaterialButton();
            this.dgvVendors = new System.Windows.Forms.DataGridView();
            this.VendorClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox42 = new System.Windows.Forms.PictureBox();
            this.groupBox40 = new MaterialSkin.Controls.MaterialCard();
            this.VendorEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblVendorEmail = new MaterialSkin.Controls.MaterialLabel();
            this.VendorName = new MaterialSkin.Controls.MaterialTextBox2();
            this.button7 = new MaterialSkin.Controls.MaterialButton();
            this.VendorAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.VendorPhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.label39 = new MaterialSkin.Controls.MaterialLabel();
            this.label40 = new MaterialSkin.Controls.MaterialLabel();
            this.VendorID = new System.Windows.Forms.NumericUpDown();
            this.label41 = new MaterialSkin.Controls.MaterialLabel();
            this.label42 = new MaterialSkin.Controls.MaterialLabel();
            this.ImporterBalanceChecks = new System.Windows.Forms.TabPage();
            this.groupBox42 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox35 = new System.Windows.Forms.PictureBox();
            this.dgvVendorBillItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorBillItemBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox43 = new MaterialSkin.Controls.MaterialCard();
            this.dgvVendorBills = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorBillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox45 = new System.Windows.Forms.PictureBox();
            this.AgentsItemsDefinitions = new System.Windows.Forms.TabPage();
            this.groupBox34 = new MaterialSkin.Controls.MaterialCard();
            this.btnClientVendorItemsPickClientItem = new MaterialSkin.Controls.MaterialButton();
            this.btnClientVendorItemsPriceClient = new MaterialSkin.Controls.MaterialButton();
            this.textBox7 = new MaterialSkin.Controls.MaterialTextBox2();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lblClientVendorItemsClientID = new MaterialSkin.Controls.MaterialLabel();
            this.lblClientVendorItemsClientName = new MaterialSkin.Controls.MaterialLabel();
            this.ClientPrice = new System.Windows.Forms.NumericUpDown();
            this.lblClientVendorItemsClientSellPrice = new MaterialSkin.Controls.MaterialLabel();
            this.SellPriceTax = new System.Windows.Forms.NumericUpDown();
            this.lblClientVendorItemsSellPriceTax = new MaterialSkin.Controls.MaterialLabel();
            this.SellPrice = new System.Windows.Forms.NumericUpDown();
            this.BuyPrice = new System.Windows.Forms.NumericUpDown();
            this.lblClientVendorItemsSellPrice = new MaterialSkin.Controls.MaterialLabel();
            this.lblClientVendorItemsBuyPrice = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox23 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox40 = new System.Windows.Forms.PictureBox();
            this.DGVClientItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alerts = new System.Windows.Forms.TabPage();
            this.groupBox37 = new MaterialSkin.Controls.MaterialCard();
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.Column42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            this.Taxes = new System.Windows.Forms.TabPage();
            this.tabControl7 = new MaterialSkin.Controls.MaterialTabControl();
            this.TaxZReport = new System.Windows.Forms.TabPage();
            this.groupBox44 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox46 = new System.Windows.Forms.PictureBox();
            this.pictureBox44 = new System.Windows.Forms.PictureBox();
            this.dgvTaxZReport = new System.Windows.Forms.DataGridView();
            this.Column50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posUsers = new System.Windows.Forms.TabPage();
            this.groupBox10 = new MaterialSkin.Controls.MaterialCard();
            this.groupBox11 = new MaterialSkin.Controls.MaterialCard();
            this.button19 = new MaterialSkin.Controls.MaterialButton();
            this.button20 = new MaterialSkin.Controls.MaterialButton();
            this.button22 = new MaterialSkin.Controls.MaterialButton();
            this.groupBox35 = new MaterialSkin.Controls.MaterialCard();
            this.sell_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.openclose_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.personnel_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.settings_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.users_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.expenses_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.inventory_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.receipt_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.price_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.discount_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.Client_card_edit = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbAdminOrNotAdd = new MaterialSkin.Controls.MaterialCheckbox();
            this.label75 = new MaterialSkin.Controls.MaterialLabel();
            this.txtUserPasswordAdd = new MaterialSkin.Controls.MaterialTextBox2();
            this.label76 = new MaterialSkin.Controls.MaterialLabel();
            this.txtUserIDAdd = new MaterialSkin.Controls.MaterialTextBox2();
            this.label77 = new MaterialSkin.Controls.MaterialLabel();
            this.txtUserNameAdd = new MaterialSkin.Controls.MaterialTextBox2();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAuthority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.Settings = new System.Windows.Forms.TabPage();
            this.tabControl9 = new MaterialSkin.Controls.MaterialTabControl();
            this.posSettings = new System.Windows.Forms.TabPage();
            this.groupBox24 = new MaterialSkin.Controls.MaterialCard();
            this.switchDarkTheme = new MaterialSkin.Controls.MaterialCard();
            this.AccentColorPanel = new System.Windows.Forms.PictureBox();
            this.PrimaryLightColorPanel = new System.Windows.Forms.PictureBox();
            this.PrimaryDarkColorPanel = new System.Windows.Forms.PictureBox();
            this.PrimaryColorPanel = new System.Windows.Forms.PictureBox();
            this.DarkAccentColorPanel = new System.Windows.Forms.PictureBox();
            this.DarkPrimaryLightColorPanel = new System.Windows.Forms.PictureBox();
            this.DarkPrimaryDarkColorPanel = new System.Windows.Forms.PictureBox();
            this.DarkPrimaryColorPanel = new System.Windows.Forms.PictureBox();
            this.lblLightColorScheme = new MaterialSkin.Controls.MaterialLabel();
            this.lblDarkColorScheme = new MaterialSkin.Controls.MaterialLabel();
            this.switchDarkBlackTextShade = new MaterialSkin.Controls.MaterialSwitch();
            this.switchBlackTextShade = new MaterialSkin.Controls.MaterialSwitch();
            this.lblColorSeperator1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTextShade = new MaterialSkin.Controls.MaterialLabel();
            this.lblAccent = new MaterialSkin.Controls.MaterialLabel();
            this.AccentColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblPrimaryLight = new MaterialSkin.Controls.MaterialLabel();
            this.PrimaryLightColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblPrimaryDark = new MaterialSkin.Controls.MaterialLabel();
            this.PrimaryDarkColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblPrimaryColor = new MaterialSkin.Controls.MaterialLabel();
            this.PrimaryColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblColorSeperator2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblDarkTextShade = new MaterialSkin.Controls.MaterialLabel();
            this.lblDarkAccent = new MaterialSkin.Controls.MaterialLabel();
            this.DarkAccentColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblDarkPrimaryLight = new MaterialSkin.Controls.MaterialLabel();
            this.DarkPrimaryLightColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblDarkPrimaryDark = new MaterialSkin.Controls.MaterialLabel();
            this.DarkPrimaryDarkColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblDarkPrimaryColor = new MaterialSkin.Controls.MaterialLabel();
            this.DarkPrimaryColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.switchThemeScheme = new MaterialSkin.Controls.MaterialSwitch();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.groupBox9 = new MaterialSkin.Controls.MaterialCard();
            this.txtStoreAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblStoreAddress = new MaterialSkin.Controls.MaterialLabel();
            this.txtStorePhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblStoreName = new MaterialSkin.Controls.MaterialLabel();
            this.txtStoreName = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblStorePhone = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox2 = new MaterialSkin.Controls.MaterialCard();
            this.button29 = new MaterialSkin.Controls.MaterialButton();
            this.picLogoStore = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new MaterialSkin.Controls.MaterialCard();
            this.label114 = new MaterialSkin.Controls.MaterialLabel();
            this.receiptSpacingnud = new System.Windows.Forms.NumericUpDown();
            this.IncludeLogoReceipt = new MaterialSkin.Controls.MaterialCheckbox();
            this.groupBox18 = new MaterialSkin.Controls.MaterialCard();
            this.nudTaxRate = new System.Windows.Forms.NumericUpDown();
            this.label78 = new MaterialSkin.Controls.MaterialLabel();
            this.printersSettings = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.Retrievals = new System.Windows.Forms.TabPage();
            this.groupBox47 = new MaterialSkin.Controls.MaterialCard();
            this.dgvReturnedItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox49 = new System.Windows.Forms.PictureBox();
            this.pnlActionMenu = new MaterialSkin.Controls.MaterialCard();
            this.btnPay = new MaterialSkin.Controls.MaterialButton();
            this.btnClientCard = new MaterialSkin.Controls.MaterialButton();
            this.btnNewInvoice = new MaterialSkin.Controls.MaterialButton();
            this.btnDiscounts = new MaterialSkin.Controls.MaterialButton();
            this.btnOpenCashDrawer = new MaterialSkin.Controls.MaterialButton();
            this.btnEditTotalPrice = new MaterialSkin.Controls.MaterialButton();
            this.btnItemLookup = new MaterialSkin.Controls.MaterialButton();
            this.btnPreviousBill = new MaterialSkin.Controls.MaterialButton();
            this.btnNextBill = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenu = new MaterialSkin.Controls.MaterialCard();
            this.materialDivider4 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.btnMenuRefunds = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuSettingsSub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuSettingsSubPrinterSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuSettingsSubPOSSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuUsers = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuTaxesSub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuTaxesSubTaxZReport = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuTaxes = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuAlerts = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuClientAffairsSub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuClientsVendorsSubVendorItemsDefinitions = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuClientsVendorsSubVendorBalanceCheck = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuClientsVendorsSubVendorsDefinitions = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuClientsVendorsSubClientsBalanceCheck = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuClientsVendorsSubClientsDefinitions = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuClientsVendors = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuEmployeesAffairsSub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuEmployeesAffairsSubDaysOff = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuEmployeesAffairsSubEmployeesManagement = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuEmployeesAffairs = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuIncomingOutgoing = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuExpensesSub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuExpensesSubAddExpense = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuExpensesSubSearchExpenses = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuExpenses = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuInventorySub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuInventorySubAddWarehouses = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuInventorySubAddFavorites = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuInventorySubAddItemTypes = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuInventorySubIncomingOutgoingItems = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuInventorySubItemsQuantify = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuInventorySubInventory = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuInventory = new MaterialSkin.Controls.MaterialButton();
            this.pnlMenuSalesSub = new MaterialSkin.Controls.MaterialCard();
            this.btnMenuSalesSubSoldItems = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuSalesSubTravelingUntravelingSales = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuSalesSubEditInvoices = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuSalesSubSales = new MaterialSkin.Controls.MaterialButton();
            this.btnHamburger = new MaterialSkin.Controls.MaterialLabel();
            this.btnMenuSales = new MaterialSkin.Controls.MaterialButton();
            this.btnMenuCash = new MaterialSkin.Controls.MaterialButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.timeDateTimer = new System.Windows.Forms.Timer(this.components);
            this.itemBarCodeEntryTimer = new System.Windows.Forms.Timer(this.components);
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.lastBillNumberUpdaterTimer = new System.Windows.Forms.Timer(this.components);
            this.updateSystem = new System.Windows.Forms.Timer(this.components);
            this.PlancksoftPOS = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.اللغةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.العربيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المظهرToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.فاتحToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مظلمToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الخروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hamburger_menu_sales_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.hamburger_menu_inventory_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.hamburger_menu_expenses_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.hamburger_menu_employees_affairs_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.hamburger_menu_clients_affairs_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.hamburger_menu_taxes_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.hamburger_menu_settings_sub_timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Cash.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlOpenCloseCash.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openRegisterBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeRegisterBtn)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsPendingPurchase)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseNewPriceTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseNewPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseRemovalQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseNewQuantity)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.Sales.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.InvoicesSales.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBillNumberSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            this.EditInvoices.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillsEdit)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillEditNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsRemainderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsPaidAmount)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            this.groupBox29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBillNumberEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            this.TravelingUntravelingSales.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortedSales)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox25.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnPortedSales)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SoldItems.SuspendLayout();
            this.groupBox28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).BeginInit();
            this.groupBox27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).BeginInit();
            this.Inventory.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.posInventory.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInventory)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox99)).BeginInit();
            this.groupBox36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuditemPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuditemPriceTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBAddProfilePicture)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.InventoryQuantify.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.groupBox46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseInventory)).BeginInit();
            this.IncomingOutgoingItems.SuspendLayout();
            this.groupBox48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClientIDImportExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryExitItemBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEntryExitItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryExitWarningQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryExitItemQuantity)).BeginInit();
            this.AddTypes.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTypeAddButton)).BeginInit();
            this.AddFavorites.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FavoriteCategoryAddButton)).BeginInit();
            this.AddWarehouses.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseAddButton)).BeginInit();
            this.Expenses.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.SearchExpenses.SuspendLayout();
            this.groupBox31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CapitalAmountnud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox33)).BeginInit();
            this.AddExpenses.SuspendLayout();
            this.groupBox33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.IncomingOutgoing.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCapital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExports)).BeginInit();
            this.Employees.SuspendLayout();
            this.tabControl8.SuspendLayout();
            this.EmployeesManagement.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.groupBox50.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryDeduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditEmployeeSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddEmployeeSalary)).BeginInit();
            this.DaysOff.SuspendLayout();
            this.groupBox51.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).BeginInit();
            this.Agents.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.AgentsDefinitions.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientID)).BeginInit();
            this.ClientBalanceCheck.SuspendLayout();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintClientBillItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientBillItems)).BeginInit();
            this.materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintClientBills)).BeginInit();
            this.ImporterDefinitions.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).BeginInit();
            this.groupBox40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VendorID)).BeginInit();
            this.ImporterBalanceChecks.SuspendLayout();
            this.groupBox42.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorBillItems)).BeginInit();
            this.groupBox43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox45)).BeginInit();
            this.AgentsItemsDefinitions.SuspendLayout();
            this.groupBox34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellPriceTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyPrice)).BeginInit();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientItems)).BeginInit();
            this.Alerts.SuspendLayout();
            this.groupBox37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            this.Taxes.SuspendLayout();
            this.tabControl7.SuspendLayout();
            this.TaxZReport.SuspendLayout();
            this.groupBox44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxZReport)).BeginInit();
            this.posUsers.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            this.Settings.SuspendLayout();
            this.tabControl9.SuspendLayout();
            this.posSettings.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.switchDarkTheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccentColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryLightColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryDarkColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkAccentColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkPrimaryLightColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkPrimaryDarkColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkPrimaryColorPanel)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoStore)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptSpacingnud)).BeginInit();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxRate)).BeginInit();
            this.printersSettings.SuspendLayout();
            this.Retrievals.SuspendLayout();
            this.groupBox47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).BeginInit();
            this.pnlActionMenu.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuSettingsSub.SuspendLayout();
            this.pnlMenuTaxesSub.SuspendLayout();
            this.pnlMenuClientAffairsSub.SuspendLayout();
            this.pnlMenuEmployeesAffairsSub.SuspendLayout();
            this.pnlMenuExpensesSub.SuspendLayout();
            this.pnlMenuInventorySub.SuspendLayout();
            this.pnlMenuSalesSub.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ادارةالمستودعToolStripMenuItem,
            this.aToolStripMenuItem,
            this.خروجToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(3, 64);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1914, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ادارةالمستودعToolStripMenuItem
            // 
            this.ادارةالمستودعToolStripMenuItem.AutoSize = false;
            this.ادارةالمستودعToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اضافةمادهToolStripMenuItem,
            this.اضافةصنفToolStripMenuItem,
            this.اضافةمستودعToolStripMenuItem,
            this.اضافةمستودعToolStripMenuItem1});
            this.ادارةالمستودعToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ادارةالمستودعToolStripMenuItem.ForeColor = System.Drawing.Color.Tomato;
            this.ادارةالمستودعToolStripMenuItem.Name = "ادارةالمستودعToolStripMenuItem";
            this.ادارةالمستودعToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.ادارةالمستودعToolStripMenuItem.Text = "إدارة المستودع";
            // 
            // اضافةمادهToolStripMenuItem
            // 
            this.اضافةمادهToolStripMenuItem.AutoSize = false;
            this.اضافةمادهToolStripMenuItem.ForeColor = System.Drawing.Color.Salmon;
            this.اضافةمادهToolStripMenuItem.Name = "اضافةمادهToolStripMenuItem";
            this.اضافةمادهToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.اضافةمادهToolStripMenuItem.Text = "إضافة ماده";
            this.اضافةمادهToolStripMenuItem.Click += new System.EventHandler(this.اضافةمادهToolStripMenuItem_Click);
            // 
            // اضافةصنفToolStripMenuItem
            // 
            this.اضافةصنفToolStripMenuItem.AutoSize = false;
            this.اضافةصنفToolStripMenuItem.ForeColor = System.Drawing.Color.Salmon;
            this.اضافةصنفToolStripMenuItem.Name = "اضافةصنفToolStripMenuItem";
            this.اضافةصنفToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.اضافةصنفToolStripMenuItem.Text = "إضافة صنف";
            this.اضافةصنفToolStripMenuItem.Click += new System.EventHandler(this.اضافةصنفToolStripMenuItem_Click);
            // 
            // اضافةمستودعToolStripMenuItem
            // 
            this.اضافةمستودعToolStripMenuItem.AutoSize = false;
            this.اضافةمستودعToolStripMenuItem.ForeColor = System.Drawing.Color.Coral;
            this.اضافةمستودعToolStripMenuItem.Name = "اضافةمستودعToolStripMenuItem";
            this.اضافةمستودعToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.اضافةمستودعToolStripMenuItem.Text = "إضافة مجلد مفضلات";
            this.اضافةمستودعToolStripMenuItem.Click += new System.EventHandler(this.اضافةمستودعToolStripMenuItem_Click);
            // 
            // اضافةمستودعToolStripMenuItem1
            // 
            this.اضافةمستودعToolStripMenuItem1.AutoSize = false;
            this.اضافةمستودعToolStripMenuItem1.ForeColor = System.Drawing.Color.Salmon;
            this.اضافةمستودعToolStripMenuItem1.Name = "اضافةمستودعToolStripMenuItem1";
            this.اضافةمستودعToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.اضافةمستودعToolStripMenuItem1.Text = "إضافة مستودع";
            this.اضافةمستودعToolStripMenuItem1.Click += new System.EventHandler(this.اضافةمستودعToolStripMenuItem1_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.AutoSize = false;
            this.aToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aToolStripMenuItem.ForeColor = System.Drawing.Color.Tomato;
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.aToolStripMenuItem.Text = "طلب الصيانه";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // خروجToolStripMenuItem1
            // 
            this.خروجToolStripMenuItem1.AutoSize = false;
            this.خروجToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.خروجToolStripMenuItem1.ForeColor = System.Drawing.Color.OrangeRed;
            this.خروجToolStripMenuItem1.Name = "خروجToolStripMenuItem1";
            this.خروجToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.خروجToolStripMenuItem1.Text = "خروج";
            this.خروجToolStripMenuItem1.Click += new System.EventHandler(this.خروجToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Cash);
            this.tabControl1.Controls.Add(this.Sales);
            this.tabControl1.Controls.Add(this.Inventory);
            this.tabControl1.Controls.Add(this.Expenses);
            this.tabControl1.Controls.Add(this.IncomingOutgoing);
            this.tabControl1.Controls.Add(this.Employees);
            this.tabControl1.Controls.Add(this.Agents);
            this.tabControl1.Controls.Add(this.Alerts);
            this.tabControl1.Controls.Add(this.Taxes);
            this.tabControl1.Controls.Add(this.posUsers);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Controls.Add(this.Retrievals);
            this.tabControl1.Depth = 0;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(54, 30);
            this.tabControl1.Location = new System.Drawing.Point(13, 88);
            this.tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1889, 989);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabControl1_KeyPress);
            // 
            // Cash
            // 
            this.Cash.BackColor = System.Drawing.Color.White;
            this.Cash.Controls.Add(this.groupBox1);
            this.Cash.Location = new System.Drawing.Point(4, 34);
            this.Cash.Name = "Cash";
            this.Cash.Padding = new System.Windows.Forms.Padding(3);
            this.Cash.Size = new System.Drawing.Size(1881, 951);
            this.Cash.TabIndex = 0;
            this.Cash.Text = "الكاش";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupBox1.Controls.Add(this.pnlOpenCloseCash);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Depth = 0;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox1.Size = new System.Drawing.Size(1875, 945);
            this.groupBox1.TabIndex = 1;
            // 
            // pnlOpenCloseCash
            // 
            this.pnlOpenCloseCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlOpenCloseCash.Controls.Add(this.tabControl2);
            this.pnlOpenCloseCash.Controls.Add(this.panel3);
            this.pnlOpenCloseCash.Depth = 0;
            this.pnlOpenCloseCash.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOpenCloseCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlOpenCloseCash.Location = new System.Drawing.Point(14, 119);
            this.pnlOpenCloseCash.Margin = new System.Windows.Forms.Padding(14);
            this.pnlOpenCloseCash.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlOpenCloseCash.Name = "pnlOpenCloseCash";
            this.pnlOpenCloseCash.Padding = new System.Windows.Forms.Padding(14);
            this.pnlOpenCloseCash.Size = new System.Drawing.Size(878, 810);
            this.pnlOpenCloseCash.TabIndex = 45;
            // 
            // tabControl2
            // 
            this.tabControl2.Location = new System.Drawing.Point(3, 122);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeftLayout = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(861, 685);
            this.tabControl2.TabIndex = 39;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label65);
            this.panel3.Controls.Add(this.label66);
            this.panel3.Controls.Add(this.openRegisterBtn);
            this.panel3.Controls.Add(this.closeRegisterBtn);
            this.panel3.Depth = 0;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(5, 14);
            this.panel3.Margin = new System.Windows.Forms.Padding(14);
            this.panel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(14);
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(859, 99);
            this.panel3.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::PlancksoftPOS.Properties.Resources.leftarrow;
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Depth = 0;
            this.label65.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label65.Location = new System.Drawing.Point(103, 76);
            this.label65.MouseState = MaterialSkin.MouseState.HOVER;
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(83, 19);
            this.label65.TabIndex = 39;
            this.label65.Text = "فتح الصندوق F11";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Depth = 0;
            this.label66.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label66.Location = new System.Drawing.Point(295, 76);
            this.label66.MouseState = MaterialSkin.MouseState.HOVER;
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(94, 19);
            this.label66.TabIndex = 38;
            this.label66.Text = "اغلاق الصندوق F12";
            // 
            // openRegisterBtn
            // 
            this.openRegisterBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.openRegisterBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.openRegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openRegisterBtn.Image = ((System.Drawing.Image)(resources.GetObject("openRegisterBtn.Image")));
            this.openRegisterBtn.Location = new System.Drawing.Point(103, 4);
            this.openRegisterBtn.Name = "openRegisterBtn";
            this.openRegisterBtn.Size = new System.Drawing.Size(100, 69);
            this.openRegisterBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.openRegisterBtn.TabIndex = 34;
            this.openRegisterBtn.TabStop = false;
            this.openRegisterBtn.Click += new System.EventHandler(this.pictureBox15_Click);
            // 
            // closeRegisterBtn
            // 
            this.closeRegisterBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeRegisterBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.closeRegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeRegisterBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeRegisterBtn.Image")));
            this.closeRegisterBtn.Location = new System.Drawing.Point(293, 4);
            this.closeRegisterBtn.Name = "closeRegisterBtn";
            this.closeRegisterBtn.Size = new System.Drawing.Size(100, 69);
            this.closeRegisterBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeRegisterBtn.TabIndex = 35;
            this.closeRegisterBtn.TabStop = false;
            this.closeRegisterBtn.Click += new System.EventHandler(this.pictureBox16_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.ItemsPendingPurchase);
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Depth = 0;
            this.groupBox3.Enabled = false;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(892, 117);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox3.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox3.Size = new System.Drawing.Size(968, 827);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.Text = "قائمة المشتريات الحاليه";
            // 
            // ItemsPendingPurchase
            // 
            this.ItemsPendingPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemsPendingPurchase.BackgroundColor = System.Drawing.Color.White;
            this.ItemsPendingPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsPendingPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pendingPurchaseItemName,
            this.pendingPurchaseItemBarCode,
            this.pendingPurchaseItemQuantity,
            this.pendingPurchaseItemPrice,
            this.pendingPurchaseItemPriceTax});
            this.ItemsPendingPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsPendingPurchase.Location = new System.Drawing.Point(14, 124);
            this.ItemsPendingPurchase.Name = "ItemsPendingPurchase";
            this.ItemsPendingPurchase.ReadOnly = true;
            this.ItemsPendingPurchase.Size = new System.Drawing.Size(940, 567);
            this.ItemsPendingPurchase.TabIndex = 20;
            this.ItemsPendingPurchase.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ItemsPendingPurchase_RowHeaderMouseClick);
            this.ItemsPendingPurchase.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ItemsPendingPurchase_RowsAdded);
            // 
            // pendingPurchaseItemName
            // 
            this.pendingPurchaseItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pendingPurchaseItemName.HeaderText = "القطعه";
            this.pendingPurchaseItemName.Name = "pendingPurchaseItemName";
            this.pendingPurchaseItemName.ReadOnly = true;
            // 
            // pendingPurchaseItemBarCode
            // 
            this.pendingPurchaseItemBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pendingPurchaseItemBarCode.HeaderText = "بار كود";
            this.pendingPurchaseItemBarCode.Name = "pendingPurchaseItemBarCode";
            this.pendingPurchaseItemBarCode.ReadOnly = true;
            // 
            // pendingPurchaseItemQuantity
            // 
            this.pendingPurchaseItemQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pendingPurchaseItemQuantity.HeaderText = "عدد القطعه";
            this.pendingPurchaseItemQuantity.Name = "pendingPurchaseItemQuantity";
            this.pendingPurchaseItemQuantity.ReadOnly = true;
            this.pendingPurchaseItemQuantity.Width = 84;
            // 
            // pendingPurchaseItemPrice
            // 
            this.pendingPurchaseItemPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pendingPurchaseItemPrice.HeaderText = "سعر القطعه";
            this.pendingPurchaseItemPrice.Name = "pendingPurchaseItemPrice";
            this.pendingPurchaseItemPrice.ReadOnly = true;
            // 
            // pendingPurchaseItemPriceTax
            // 
            this.pendingPurchaseItemPriceTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pendingPurchaseItemPriceTax.HeaderText = "سعر القطعه بعد الضريبه";
            this.pendingPurchaseItemPriceTax.Name = "pendingPurchaseItemPriceTax";
            this.pendingPurchaseItemPriceTax.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.dgvLoginLogout);
            this.panel5.Controls.Add(this.pendingPurchaseNewPriceTax);
            this.panel5.Controls.Add(this.label51);
            this.panel5.Controls.Add(this.label50);
            this.panel5.Controls.Add(this.label52);
            this.panel5.Controls.Add(this.label49);
            this.panel5.Controls.Add(this.button24);
            this.panel5.Controls.Add(this.button23);
            this.panel5.Controls.Add(this.pendingPurchaseNewPrice);
            this.panel5.Controls.Add(this.button17);
            this.panel5.Controls.Add(this.richTextBox4);
            this.panel5.Controls.Add(this.richTextBox6);
            this.panel5.Controls.Add(this.pendingPurchaseRemovalQuantity);
            this.panel5.Controls.Add(this.pendingPurchaseNewQuantity);
            this.panel5.Depth = 0;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel5.Location = new System.Drawing.Point(14, 691);
            this.panel5.Margin = new System.Windows.Forms.Padding(14);
            this.panel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(14);
            this.panel5.Size = new System.Drawing.Size(940, 122);
            this.panel5.TabIndex = 45;
            // 
            // dgvLoginLogout
            // 
            this.dgvLoginLogout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginLogout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvLoginLogout.Location = new System.Drawing.Point(925, 108);
            this.dgvLoginLogout.Name = "dgvLoginLogout";
            this.dgvLoginLogout.ReadOnly = true;
            this.dgvLoginLogout.Size = new System.Drawing.Size(546, 423);
            this.dgvLoginLogout.TabIndex = 39;
            this.dgvLoginLogout.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Cashier Name";
            this.Column1.HeaderText = "اسم الكاشير";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Date";
            this.Column2.HeaderText = "التاريخ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Action";
            this.Column3.HeaderText = "الحركه";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // pendingPurchaseNewPriceTax
            // 
            this.pendingPurchaseNewPriceTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pendingPurchaseNewPriceTax.DecimalPlaces = 2;
            this.pendingPurchaseNewPriceTax.Location = new System.Drawing.Point(375, 78);
            this.pendingPurchaseNewPriceTax.Name = "pendingPurchaseNewPriceTax";
            this.pendingPurchaseNewPriceTax.ReadOnly = true;
            this.pendingPurchaseNewPriceTax.Size = new System.Drawing.Size(120, 22);
            this.pendingPurchaseNewPriceTax.TabIndex = 32;
            this.pendingPurchaseNewPriceTax.Visible = false;
            // 
            // label51
            // 
            this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label51.AutoSize = true;
            this.label51.Depth = 0;
            this.label51.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label51.Location = new System.Drawing.Point(395, 58);
            this.label51.MouseState = MaterialSkin.MouseState.HOVER;
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(103, 19);
            this.label51.TabIndex = 33;
            this.label51.Text = "السعر الجديد بعد الضريبه";
            this.label51.Visible = false;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label50.AutoSize = true;
            this.label50.Depth = 0;
            this.label50.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label50.Location = new System.Drawing.Point(446, 14);
            this.label50.MouseState = MaterialSkin.MouseState.HOVER;
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(52, 19);
            this.label50.TabIndex = 30;
            this.label50.Text = "السعر الجديد";
            this.label50.Visible = false;
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.AutoSize = true;
            this.label52.Depth = 0;
            this.label52.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label52.Location = new System.Drawing.Point(803, 80);
            this.label52.MouseState = MaterialSkin.MouseState.HOVER;
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(68, 19);
            this.label52.TabIndex = 74;
            this.label52.Text = "عدد القطع الجديد";
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label49.AutoSize = true;
            this.label49.Depth = 0;
            this.label49.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label49.Location = new System.Drawing.Point(803, 35);
            this.label49.MouseState = MaterialSkin.MouseState.HOVER;
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(45, 19);
            this.label49.TabIndex = 47;
            this.label49.Text = "عدد الحذف";
            // 
            // button24
            // 
            this.button24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button24.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button24.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button24.Depth = 0;
            this.button24.HighEmphasis = true;
            this.button24.Icon = null;
            this.button24.Location = new System.Drawing.Point(551, 70);
            this.button24.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button24.MouseState = MaterialSkin.MouseState.HOVER;
            this.button24.Name = "button24";
            this.button24.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button24.Size = new System.Drawing.Size(105, 36);
            this.button24.TabIndex = 73;
            this.button24.Text = "تعديل عدد القطع";
            this.button24.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button24.UseAccentColor = false;
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button23
            // 
            this.button23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button23.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button23.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button23.Depth = 0;
            this.button23.HighEmphasis = true;
            this.button23.Icon = null;
            this.button23.Location = new System.Drawing.Point(285, 45);
            this.button23.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button23.MouseState = MaterialSkin.MouseState.HOVER;
            this.button23.Name = "button23";
            this.button23.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button23.Size = new System.Drawing.Size(84, 36);
            this.button23.TabIndex = 28;
            this.button23.Text = "تعديل السعر";
            this.button23.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button23.UseAccentColor = false;
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Visible = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // pendingPurchaseNewPrice
            // 
            this.pendingPurchaseNewPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pendingPurchaseNewPrice.DecimalPlaces = 2;
            this.pendingPurchaseNewPrice.Location = new System.Drawing.Point(375, 33);
            this.pendingPurchaseNewPrice.Name = "pendingPurchaseNewPrice";
            this.pendingPurchaseNewPrice.Size = new System.Drawing.Size(120, 22);
            this.pendingPurchaseNewPrice.TabIndex = 29;
            this.pendingPurchaseNewPrice.Visible = false;
            this.pendingPurchaseNewPrice.ValueChanged += new System.EventHandler(this.pendingPurchaseNewPrice_ValueChanged);
            // 
            // button17
            // 
            this.button17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button17.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button17.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button17.Depth = 0;
            this.button17.HighEmphasis = true;
            this.button17.Icon = null;
            this.button17.Location = new System.Drawing.Point(514, 29);
            this.button17.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button17.MouseState = MaterialSkin.MouseState.HOVER;
            this.button17.Name = "button17";
            this.button17.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button17.Size = new System.Drawing.Size(142, 36);
            this.button17.TabIndex = 72;
            this.button17.Text = "حذف القطعه من الشراء";
            this.button17.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button17.UseAccentColor = false;
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.richTextBox4.Depth = 0;
            this.richTextBox4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.richTextBox4.Location = new System.Drawing.Point(3, 58);
            this.richTextBox4.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(158, 60);
            this.richTextBox4.TabIndex = 27;
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.Color.Transparent;
            this.richTextBox6.Depth = 0;
            this.richTextBox6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.richTextBox6.Location = new System.Drawing.Point(3, 6);
            this.richTextBox6.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(158, 47);
            this.richTextBox6.TabIndex = 38;
            // 
            // pendingPurchaseRemovalQuantity
            // 
            this.pendingPurchaseRemovalQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pendingPurchaseRemovalQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingPurchaseRemovalQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.pendingPurchaseRemovalQuantity.Location = new System.Drawing.Point(667, 32);
            this.pendingPurchaseRemovalQuantity.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.pendingPurchaseRemovalQuantity.Name = "pendingPurchaseRemovalQuantity";
            this.pendingPurchaseRemovalQuantity.Size = new System.Drawing.Size(120, 20);
            this.pendingPurchaseRemovalQuantity.TabIndex = 0;
            this.pendingPurchaseRemovalQuantity.Enter += new System.EventHandler(this.pendingPurchaseRemovalQuantity_Enter);
            this.pendingPurchaseRemovalQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pendingPurchaseRemovalQuantity_KeyDown);
            this.pendingPurchaseRemovalQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pendingPurchaseRemovalQuantity_KeyPress);
            // 
            // pendingPurchaseNewQuantity
            // 
            this.pendingPurchaseNewQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pendingPurchaseNewQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingPurchaseNewQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.pendingPurchaseNewQuantity.Location = new System.Drawing.Point(667, 77);
            this.pendingPurchaseNewQuantity.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.pendingPurchaseNewQuantity.Name = "pendingPurchaseNewQuantity";
            this.pendingPurchaseNewQuantity.Size = new System.Drawing.Size(120, 20);
            this.pendingPurchaseNewQuantity.TabIndex = 1;
            this.pendingPurchaseNewQuantity.Enter += new System.EventHandler(this.pendingPurchaseNewQuantity_Enter);
            this.pendingPurchaseNewQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pendingPurchaseNewQuantity_KeyDown);
            this.pendingPurchaseNewQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pendingPurchaseNewQuantity_KeyPress);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.richTextBox3);
            this.panel4.Controls.Add(this.richTextBox2);
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Controls.Add(this.richTextBox5);
            this.panel4.Controls.Add(this.label112);
            this.panel4.Depth = 0;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel4.Location = new System.Drawing.Point(14, 14);
            this.panel4.Margin = new System.Windows.Forms.Padding(14);
            this.panel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(14);
            this.panel4.Size = new System.Drawing.Size(940, 110);
            this.panel4.TabIndex = 44;
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBox3.Depth = 0;
            this.richTextBox3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox3.Location = new System.Drawing.Point(15, 36);
            this.richTextBox3.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(132, 61);
            this.richTextBox3.TabIndex = 49;
            this.richTextBox3.Text = "المجموع السابق";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBox2.Depth = 0;
            this.richTextBox2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox2.Location = new System.Drawing.Point(164, 36);
            this.richTextBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(132, 61);
            this.richTextBox2.TabIndex = 48;
            this.richTextBox2.Text = "المدفوع السابق";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBox1.Depth = 0;
            this.richTextBox1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox1.Location = new System.Drawing.Point(302, 36);
            this.richTextBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(132, 61);
            this.richTextBox1.TabIndex = 47;
            this.richTextBox1.Text = "الباقي السابق";
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBox5.Depth = 0;
            this.richTextBox5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.richTextBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox5.Location = new System.Drawing.Point(440, 36);
            this.richTextBox5.MouseState = MaterialSkin.MouseState.HOVER;
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(132, 61);
            this.richTextBox5.TabIndex = 46;
            this.richTextBox5.Text = "رقم الفاتورة الحالية";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Depth = 0;
            this.label112.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label112.Location = new System.Drawing.Point(238, 14);
            this.label112.MouseState = MaterialSkin.MouseState.HOVER;
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(97, 19);
            this.label112.TabIndex = 45;
            this.label112.Text = "0 :عدد الفواتير المعلقه";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.cashierNameLbl);
            this.panel2.Controls.Add(this.label71);
            this.panel2.Controls.Add(this.dateTimeLbl);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.picLogo);
            this.panel2.Depth = 0;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(14, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(14);
            this.panel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(14);
            this.panel2.Size = new System.Drawing.Size(1845, 105);
            this.panel2.TabIndex = 46;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = global::PlancksoftPOS.Properties.Resources.rightarrow;
            this.pictureBox3.Location = new System.Drawing.Point(1763, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(66, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // cashierNameLbl
            // 
            this.cashierNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierNameLbl.AutoSize = true;
            this.cashierNameLbl.Depth = 0;
            this.cashierNameLbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cashierNameLbl.Location = new System.Drawing.Point(1266, 51);
            this.cashierNameLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.cashierNameLbl.Name = "cashierNameLbl";
            this.cashierNameLbl.Size = new System.Drawing.Size(118, 19);
            this.cashierNameLbl.TabIndex = 44;
            this.cashierNameLbl.Text = "%cashierName%";
            // 
            // label71
            // 
            this.label71.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label71.AutoSize = true;
            this.label71.Depth = 0;
            this.label71.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label71.Location = new System.Drawing.Point(1266, 18);
            this.label71.MouseState = MaterialSkin.MouseState.HOVER;
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(52, 19);
            this.label71.TabIndex = 43;
            this.label71.Text = "اسم الكاشير:";
            // 
            // dateTimeLbl
            // 
            this.dateTimeLbl.AutoSize = true;
            this.dateTimeLbl.Depth = 0;
            this.dateTimeLbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimeLbl.Location = new System.Drawing.Point(29, 65);
            this.dateTimeLbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.dateTimeLbl.Name = "dateTimeLbl";
            this.dateTimeLbl.Size = new System.Drawing.Size(91, 19);
            this.dateTimeLbl.TabIndex = 42;
            this.dateTimeLbl.Text = "%date time%";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Depth = 0;
            this.label45.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label45.Location = new System.Drawing.Point(28, 13);
            this.label45.MouseState = MaterialSkin.MouseState.HOVER;
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(90, 19);
            this.label45.TabIndex = 40;
            this.label45.Text = "هذه النسخه مرخصه ل";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::PlancksoftPOS.Properties.Resources.plancksoft_b_t;
            this.picLogo.Location = new System.Drawing.Point(822, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(190, 98);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 41;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.pictureBox35_Click);
            // 
            // Sales
            // 
            this.Sales.BackColor = System.Drawing.Color.White;
            this.Sales.Controls.Add(this.tabControl4);
            this.Sales.Location = new System.Drawing.Point(4, 34);
            this.Sales.Name = "Sales";
            this.Sales.Padding = new System.Windows.Forms.Padding(3);
            this.Sales.Size = new System.Drawing.Size(1881, 951);
            this.Sales.TabIndex = 1;
            this.Sales.Text = "المبيعات";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.InvoicesSales);
            this.tabControl4.Controls.Add(this.EditInvoices);
            this.tabControl4.Controls.Add(this.TravelingUntravelingSales);
            this.tabControl4.Controls.Add(this.SoldItems);
            this.tabControl4.Depth = 0;
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.ItemSize = new System.Drawing.Size(60, 30);
            this.tabControl4.Location = new System.Drawing.Point(3, 3);
            this.tabControl4.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl4.Multiline = true;
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.RightToLeftLayout = true;
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(1875, 945);
            this.tabControl4.TabIndex = 0;
            this.tabControl4.SelectedIndexChanged += new System.EventHandler(this.tabControl4_SelectedIndexChanged);
            this.tabControl4.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl4_Selecting);
            // 
            // InvoicesSales
            // 
            this.InvoicesSales.BackColor = System.Drawing.Color.White;
            this.InvoicesSales.Controls.Add(this.groupBox14);
            this.InvoicesSales.Controls.Add(this.groupBox12);
            this.InvoicesSales.Controls.Add(this.groupBox13);
            this.InvoicesSales.Location = new System.Drawing.Point(4, 34);
            this.InvoicesSales.Name = "InvoicesSales";
            this.InvoicesSales.Padding = new System.Windows.Forms.Padding(3);
            this.InvoicesSales.Size = new System.Drawing.Size(1867, 907);
            this.InvoicesSales.TabIndex = 0;
            this.InvoicesSales.Text = "المبيعات";
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox14.Controls.Add(this.panel9);
            this.groupBox14.Controls.Add(this.panel8);
            this.groupBox14.Depth = 0;
            this.groupBox14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox14.Location = new System.Drawing.Point(3, 365);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox14.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox14.Size = new System.Drawing.Size(1860, 546);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.Text = "المواد المباعه بالفاتوره";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel9.Controls.Add(this.dgvBillItems);
            this.panel9.Depth = 0;
            this.panel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel9.Location = new System.Drawing.Point(3, 18);
            this.panel9.Margin = new System.Windows.Forms.Padding(14);
            this.panel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(14);
            this.panel9.Size = new System.Drawing.Size(1696, 507);
            this.panel9.TabIndex = 32;
            // 
            // dgvBillItems
            // 
            this.dgvBillItems.AllowUserToAddRows = false;
            this.dgvBillItems.AllowUserToDeleteRows = false;
            this.dgvBillItems.AllowUserToOrderColumns = true;
            this.dgvBillItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column20,
            this.Column21,
            this.Column23,
            this.Column63,
            this.Column24,
            this.Column25});
            this.dgvBillItems.Location = new System.Drawing.Point(0, 0);
            this.dgvBillItems.Name = "dgvBillItems";
            this.dgvBillItems.ReadOnly = true;
            this.dgvBillItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvBillItems.Size = new System.Drawing.Size(1693, 500);
            this.dgvBillItems.TabIndex = 29;
            // 
            // Column20
            // 
            this.Column20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column20.DataPropertyName = "Item Name";
            this.Column20.HeaderText = "اسم الماده";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // Column21
            // 
            this.Column21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column21.DataPropertyName = "Item BarCode";
            this.Column21.HeaderText = "باركود الماده";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column23
            // 
            this.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column23.DataPropertyName = "Times Sold";
            this.Column23.HeaderText = "عدد البيع";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // Column63
            // 
            this.Column63.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column63.DataPropertyName = "Returned Quantity";
            this.Column63.HeaderText = "العدد المرجع";
            this.Column63.Name = "Column63";
            this.Column63.ReadOnly = true;
            // 
            // Column24
            // 
            this.Column24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column24.DataPropertyName = "Item Price";
            this.Column24.HeaderText = "السعر";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // Column25
            // 
            this.Column25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column25.DataPropertyName = "Item Price Tax";
            this.Column25.HeaderText = "السعر بعد الضريبه";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.button18);
            this.panel8.Controls.Add(this.pictureBox20);
            this.panel8.Controls.Add(this.button25);
            this.panel8.Depth = 0;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel8.Location = new System.Drawing.Point(1699, 14);
            this.panel8.Margin = new System.Windows.Forms.Padding(14);
            this.panel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(14);
            this.panel8.Size = new System.Drawing.Size(147, 518);
            this.panel8.TabIndex = 31;
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button18.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button18.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button18.Depth = 0;
            this.button18.HighEmphasis = true;
            this.button18.Icon = null;
            this.button18.Location = new System.Drawing.Point(5, 148);
            this.button18.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button18.MouseState = MaterialSkin.MouseState.HOVER;
            this.button18.Name = "button18";
            this.button18.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button18.Size = new System.Drawing.Size(138, 36);
            this.button18.TabIndex = 75;
            this.button18.Text = "أكثر 100 المواد مباعه";
            this.button18.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button18.UseAccentColor = false;
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox20.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox20.Location = new System.Drawing.Point(51, 17);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(86, 66);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 30;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
            // 
            // button25
            // 
            this.button25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button25.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button25.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button25.Depth = 0;
            this.button25.HighEmphasis = true;
            this.button25.Icon = null;
            this.button25.Location = new System.Drawing.Point(9, 100);
            this.button25.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button25.MouseState = MaterialSkin.MouseState.HOVER;
            this.button25.Name = "button25";
            this.button25.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button25.Size = new System.Drawing.Size(133, 36);
            this.button25.TabIndex = 74;
            this.button25.Text = "أقل 100 المواد مباعه";
            this.button25.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button25.UseAccentColor = false;
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox12.Controls.Add(this.panel7);
            this.groupBox12.Controls.Add(this.panel6);
            this.groupBox12.Depth = 0;
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox12.Location = new System.Drawing.Point(3, 90);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox12.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox12.Size = new System.Drawing.Size(1861, 275);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.Text = "لائحة الفواتير";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel7.Controls.Add(this.dgvBills);
            this.panel7.Depth = 0;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel7.Location = new System.Drawing.Point(14, 14);
            this.panel7.Margin = new System.Windows.Forms.Padding(14);
            this.panel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(14);
            this.panel7.Size = new System.Drawing.Size(1722, 247);
            this.panel7.TabIndex = 32;
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToOrderColumns = true;
            this.dgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column5,
            this.Column64});
            this.dgvBills.Location = new System.Drawing.Point(0, 0);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvBills.Size = new System.Drawing.Size(1721, 244);
            this.dgvBills.TabIndex = 28;
            this.dgvBills.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBills_RowHeaderMouseClick);
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column15.DataPropertyName = "Bill Number";
            this.Column15.HeaderText = "رقم الفاتوره";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column16.DataPropertyName = "Cashier Name";
            this.Column16.HeaderText = "اسم الكاشير";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column17.DataPropertyName = "Total Amount";
            this.Column17.HeaderText = "المبلغ الصافي";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column18.DataPropertyName = "Paid Amount";
            this.Column18.HeaderText = "المبلغ المدفوع";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // Column19
            // 
            this.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column19.DataPropertyName = "Remainder Amount";
            this.Column19.HeaderText = "المبلغ الباقي";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Payment Type";
            this.Column5.HeaderText = "طريقة الدفع";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column64
            // 
            this.Column64.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column64.DataPropertyName = "Invoice Date";
            this.Column64.HeaderText = "التاريخ";
            this.Column64.Name = "Column64";
            this.Column64.ReadOnly = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel6.Controls.Add(this.button26);
            this.panel6.Controls.Add(this.pictureBox17);
            this.panel6.Controls.Add(this.pictureBox18);
            this.panel6.Depth = 0;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel6.Location = new System.Drawing.Point(1736, 14);
            this.panel6.Margin = new System.Windows.Forms.Padding(14);
            this.panel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(14);
            this.panel6.Size = new System.Drawing.Size(111, 247);
            this.panel6.TabIndex = 31;
            // 
            // button26
            // 
            this.button26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button26.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button26.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button26.Depth = 0;
            this.button26.HighEmphasis = true;
            this.button26.Icon = null;
            this.button26.Location = new System.Drawing.Point(11, 174);
            this.button26.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button26.MouseState = MaterialSkin.MouseState.HOVER;
            this.button26.Name = "button26";
            this.button26.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button26.Size = new System.Drawing.Size(84, 36);
            this.button26.TabIndex = 73;
            this.button26.Text = "مبيعات اليوم";
            this.button26.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button26.UseAccentColor = false;
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // pictureBox17
            // 
            this.pictureBox17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox17.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox17.Location = new System.Drawing.Point(18, 8);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(68, 51);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox17.TabIndex = 30;
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Click += new System.EventHandler(this.pictureBox17_Click);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox18.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox18.Location = new System.Drawing.Point(15, 65);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(75, 76);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox18.TabIndex = 29;
            this.pictureBox18.TabStop = false;
            this.pictureBox18.Click += new System.EventHandler(this.pictureBox18_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox13.Controls.Add(this.cbSalesDateSearch);
            this.groupBox13.Controls.Add(this.nudBillNumberSearch);
            this.groupBox13.Controls.Add(this.dateTimePicker1);
            this.groupBox13.Controls.Add(this.label84);
            this.groupBox13.Controls.Add(this.label85);
            this.groupBox13.Controls.Add(this.dateTimePicker2);
            this.groupBox13.Controls.Add(this.label87);
            this.groupBox13.Controls.Add(this.pictureBox19);
            this.groupBox13.Depth = 0;
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox13.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox13.Size = new System.Drawing.Size(1861, 87);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.Text = "بحث الفواتير";
            // 
            // cbSalesDateSearch
            // 
            this.cbSalesDateSearch.AutoSize = true;
            this.cbSalesDateSearch.Depth = 0;
            this.cbSalesDateSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.cbSalesDateSearch.Location = new System.Drawing.Point(1122, 30);
            this.cbSalesDateSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cbSalesDateSearch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbSalesDateSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbSalesDateSearch.Name = "cbSalesDateSearch";
            this.cbSalesDateSearch.ReadOnly = false;
            this.cbSalesDateSearch.Ripple = true;
            this.cbSalesDateSearch.Size = new System.Drawing.Size(79, 37);
            this.cbSalesDateSearch.TabIndex = 32;
            this.cbSalesDateSearch.Text = "بحث تاريخ";
            this.cbSalesDateSearch.UseVisualStyleBackColor = true;
            // 
            // nudBillNumberSearch
            // 
            this.nudBillNumberSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBillNumberSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBillNumberSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudBillNumberSearch.Location = new System.Drawing.Point(1621, 47);
            this.nudBillNumberSearch.Name = "nudBillNumberSearch";
            this.nudBillNumberSearch.Size = new System.Drawing.Size(167, 20);
            this.nudBillNumberSearch.TabIndex = 0;
            this.nudBillNumberSearch.Enter += new System.EventHandler(this.nudBillNumberSearch_Enter_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(1209, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label84
            // 
            this.label84.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label84.AutoSize = true;
            this.label84.Depth = 0;
            this.label84.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label84.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label84.Location = new System.Drawing.Point(1247, 16);
            this.label84.MouseState = MaterialSkin.MouseState.HOVER;
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(67, 19);
            this.label84.TabIndex = 30;
            this.label84.Text = "تاريخ البحث الى";
            // 
            // label85
            // 
            this.label85.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label85.AutoSize = true;
            this.label85.Depth = 0;
            this.label85.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label85.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label85.Location = new System.Drawing.Point(1670, 16);
            this.label85.MouseState = MaterialSkin.MouseState.HOVER;
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(48, 19);
            this.label85.TabIndex = 28;
            this.label85.Text = "رقم الفاتوره";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(1415, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label87
            // 
            this.label87.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label87.AutoSize = true;
            this.label87.Depth = 0;
            this.label87.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label87.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label87.Location = new System.Drawing.Point(1455, 16);
            this.label87.MouseState = MaterialSkin.MouseState.HOVER;
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(65, 19);
            this.label87.TabIndex = 29;
            this.label87.Text = "تاريخ البحث من";
            // 
            // pictureBox19
            // 
            this.pictureBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox19.Image = global::PlancksoftPOS.Properties.Resources.search;
            this.pictureBox19.Location = new System.Drawing.Point(1794, 28);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(47, 39);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox19.TabIndex = 31;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
            // 
            // EditInvoices
            // 
            this.EditInvoices.BackColor = System.Drawing.Color.White;
            this.EditInvoices.Controls.Add(this.groupBox30);
            this.EditInvoices.Controls.Add(this.groupBox29);
            this.EditInvoices.Location = new System.Drawing.Point(4, 34);
            this.EditInvoices.Name = "EditInvoices";
            this.EditInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.EditInvoices.Size = new System.Drawing.Size(1867, 907);
            this.EditInvoices.TabIndex = 3;
            this.EditInvoices.Text = "التعديل على الفواتير";
            // 
            // groupBox30
            // 
            this.groupBox30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox30.Controls.Add(this.panel12);
            this.groupBox30.Controls.Add(this.panel11);
            this.groupBox30.Controls.Add(this.panel10);
            this.groupBox30.Depth = 0;
            this.groupBox30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox30.Location = new System.Drawing.Point(3, 3);
            this.groupBox30.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox30.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox30.Size = new System.Drawing.Size(1861, 901);
            this.groupBox30.TabIndex = 0;
            this.groupBox30.Text = "لائحة الفواتير";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel12.Controls.Add(this.dgvBillsEdit);
            this.panel12.Depth = 0;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel12.Location = new System.Drawing.Point(14, 99);
            this.panel12.Margin = new System.Windows.Forms.Padding(14);
            this.panel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(14);
            this.panel12.Size = new System.Drawing.Size(1742, 788);
            this.panel12.TabIndex = 49;
            // 
            // dgvBillsEdit
            // 
            this.dgvBillsEdit.AllowUserToAddRows = false;
            this.dgvBillsEdit.AllowUserToDeleteRows = false;
            this.dgvBillsEdit.AllowUserToOrderColumns = true;
            this.dgvBillsEdit.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillsEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillsEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillNumber,
            this.BillCashierName,
            this.BillTotalAmount,
            this.BillPaidAmount,
            this.BillRemainderAmount,
            this.BillPaymentType});
            this.dgvBillsEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillsEdit.Location = new System.Drawing.Point(14, 14);
            this.dgvBillsEdit.Name = "dgvBillsEdit";
            this.dgvBillsEdit.ReadOnly = true;
            this.dgvBillsEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvBillsEdit.Size = new System.Drawing.Size(1714, 760);
            this.dgvBillsEdit.TabIndex = 28;
            this.dgvBillsEdit.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBillsEdit_RowHeaderMouseClick);
            // 
            // BillNumber
            // 
            this.BillNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillNumber.DataPropertyName = "Bill Number";
            this.BillNumber.HeaderText = "رقم الفاتوره";
            this.BillNumber.Name = "BillNumber";
            this.BillNumber.ReadOnly = true;
            // 
            // BillCashierName
            // 
            this.BillCashierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillCashierName.DataPropertyName = "Cashier Name";
            this.BillCashierName.HeaderText = "اسم الكاشير";
            this.BillCashierName.Name = "BillCashierName";
            this.BillCashierName.ReadOnly = true;
            // 
            // BillTotalAmount
            // 
            this.BillTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillTotalAmount.DataPropertyName = "Total Amount";
            this.BillTotalAmount.HeaderText = "المبلغ الصافي";
            this.BillTotalAmount.Name = "BillTotalAmount";
            this.BillTotalAmount.ReadOnly = true;
            // 
            // BillPaidAmount
            // 
            this.BillPaidAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillPaidAmount.DataPropertyName = "Paid Amount";
            this.BillPaidAmount.HeaderText = "المبلغ المدفوع";
            this.BillPaidAmount.Name = "BillPaidAmount";
            this.BillPaidAmount.ReadOnly = true;
            // 
            // BillRemainderAmount
            // 
            this.BillRemainderAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillRemainderAmount.DataPropertyName = "Remainder Amount";
            this.BillRemainderAmount.HeaderText = "المبلغ الباقي";
            this.BillRemainderAmount.Name = "BillRemainderAmount";
            this.BillRemainderAmount.ReadOnly = true;
            // 
            // BillPaymentType
            // 
            this.BillPaymentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillPaymentType.DataPropertyName = "Payment Type";
            this.BillPaymentType.HeaderText = "طريقة الدفع";
            this.BillPaymentType.Name = "BillPaymentType";
            this.BillPaymentType.ReadOnly = true;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel11.Controls.Add(this.BillsEditButton);
            this.panel11.Controls.Add(this.BillsCashierName);
            this.panel11.Controls.Add(this.BillEditNumber);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Controls.Add(this.label13);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Controls.Add(this.BillsRemainderAmount);
            this.panel11.Controls.Add(this.BillsTotalAmount);
            this.panel11.Controls.Add(this.label12);
            this.panel11.Controls.Add(this.label10);
            this.panel11.Controls.Add(this.BillsPaidAmount);
            this.panel11.Depth = 0;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel11.Location = new System.Drawing.Point(14, 14);
            this.panel11.Margin = new System.Windows.Forms.Padding(14);
            this.panel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(14);
            this.panel11.Size = new System.Drawing.Size(1742, 85);
            this.panel11.TabIndex = 48;
            // 
            // BillsEditButton
            // 
            this.BillsEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BillsEditButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BillsEditButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BillsEditButton.Depth = 0;
            this.BillsEditButton.HighEmphasis = true;
            this.BillsEditButton.Icon = null;
            this.BillsEditButton.Location = new System.Drawing.Point(833, 30);
            this.BillsEditButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BillsEditButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.BillsEditButton.Name = "BillsEditButton";
            this.BillsEditButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BillsEditButton.Size = new System.Drawing.Size(125, 36);
            this.BillsEditButton.TabIndex = 74;
            this.BillsEditButton.Text = "التعديل على الفاتوره";
            this.BillsEditButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BillsEditButton.UseAccentColor = false;
            this.BillsEditButton.UseVisualStyleBackColor = true;
            this.BillsEditButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // BillsCashierName
            // 
            this.BillsCashierName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BillsCashierName.AnimateReadOnly = false;
            this.BillsCashierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.BillsCashierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.BillsCashierName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BillsCashierName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.BillsCashierName.Depth = 0;
            this.BillsCashierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillsCashierName.HideSelection = true;
            this.BillsCashierName.LeadingIcon = null;
            this.BillsCashierName.Location = new System.Drawing.Point(1391, 46);
            this.BillsCashierName.MaxLength = 32767;
            this.BillsCashierName.MouseState = MaterialSkin.MouseState.OUT;
            this.BillsCashierName.Name = "BillsCashierName";
            this.BillsCashierName.PasswordChar = '\0';
            this.BillsCashierName.PrefixSuffixText = null;
            this.BillsCashierName.ReadOnly = false;
            this.BillsCashierName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BillsCashierName.SelectedText = "";
            this.BillsCashierName.SelectionLength = 0;
            this.BillsCashierName.SelectionStart = 0;
            this.BillsCashierName.ShortcutsEnabled = true;
            this.BillsCashierName.Size = new System.Drawing.Size(202, 48);
            this.BillsCashierName.TabIndex = 1;
            this.BillsCashierName.TabStop = false;
            this.BillsCashierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BillsCashierName.TrailingIcon = null;
            this.BillsCashierName.UseSystemPasswordChar = false;
            this.BillsCashierName.Enter += new System.EventHandler(this.BillsCashierName_Enter);
            // 
            // BillEditNumber
            // 
            this.BillEditNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BillEditNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillEditNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.BillEditNumber.Location = new System.Drawing.Point(1599, 46);
            this.BillEditNumber.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.BillEditNumber.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.BillEditNumber.Name = "BillEditNumber";
            this.BillEditNumber.ReadOnly = true;
            this.BillEditNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BillEditNumber.Size = new System.Drawing.Size(136, 20);
            this.BillEditNumber.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Depth = 0;
            this.label11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label11.Location = new System.Drawing.Point(1448, 8);
            this.label11.MouseState = MaterialSkin.MouseState.HOVER;
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 19);
            this.label11.TabIndex = 36;
            this.label11.Text = "اسم الكاشير";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Depth = 0;
            this.label13.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label13.Location = new System.Drawing.Point(1622, 8);
            this.label13.MouseState = MaterialSkin.MouseState.HOVER;
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 19);
            this.label13.TabIndex = 46;
            this.label13.Text = "رقم الفاتوره";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Depth = 0;
            this.label9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label9.Location = new System.Drawing.Point(1265, 8);
            this.label9.MouseState = MaterialSkin.MouseState.HOVER;
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 19);
            this.label9.TabIndex = 39;
            this.label9.Text = "المبلغ الصافي";
            // 
            // BillsRemainderAmount
            // 
            this.BillsRemainderAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BillsRemainderAmount.DecimalPlaces = 2;
            this.BillsRemainderAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillsRemainderAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.BillsRemainderAmount.Location = new System.Drawing.Point(965, 46);
            this.BillsRemainderAmount.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.BillsRemainderAmount.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.BillsRemainderAmount.Name = "BillsRemainderAmount";
            this.BillsRemainderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BillsRemainderAmount.Size = new System.Drawing.Size(136, 20);
            this.BillsRemainderAmount.TabIndex = 4;
            // 
            // BillsTotalAmount
            // 
            this.BillsTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BillsTotalAmount.DecimalPlaces = 2;
            this.BillsTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillsTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.BillsTotalAmount.Location = new System.Drawing.Point(1249, 46);
            this.BillsTotalAmount.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.BillsTotalAmount.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.BillsTotalAmount.Name = "BillsTotalAmount";
            this.BillsTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BillsTotalAmount.Size = new System.Drawing.Size(136, 20);
            this.BillsTotalAmount.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Depth = 0;
            this.label12.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label12.Location = new System.Drawing.Point(986, 8);
            this.label12.MouseState = MaterialSkin.MouseState.HOVER;
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 19);
            this.label12.TabIndex = 44;
            this.label12.Text = "المبلغ الباقي";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Depth = 0;
            this.label10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label10.Location = new System.Drawing.Point(1122, 8);
            this.label10.MouseState = MaterialSkin.MouseState.HOVER;
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 19);
            this.label10.TabIndex = 42;
            this.label10.Text = "المبلغ المدفوع";
            // 
            // BillsPaidAmount
            // 
            this.BillsPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BillsPaidAmount.DecimalPlaces = 2;
            this.BillsPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillsPaidAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.BillsPaidAmount.Location = new System.Drawing.Point(1107, 46);
            this.BillsPaidAmount.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.BillsPaidAmount.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.BillsPaidAmount.Name = "BillsPaidAmount";
            this.BillsPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BillsPaidAmount.Size = new System.Drawing.Size(136, 20);
            this.BillsPaidAmount.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel10.Controls.Add(this.pictureBox32);
            this.panel10.Controls.Add(this.pictureBox31);
            this.panel10.Depth = 0;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel10.Location = new System.Drawing.Point(1756, 14);
            this.panel10.Margin = new System.Windows.Forms.Padding(14);
            this.panel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(14);
            this.panel10.Size = new System.Drawing.Size(91, 873);
            this.panel10.TabIndex = 47;
            // 
            // pictureBox32
            // 
            this.pictureBox32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox32.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox32.Location = new System.Drawing.Point(4, 150);
            this.pictureBox32.Name = "pictureBox32";
            this.pictureBox32.Size = new System.Drawing.Size(84, 79);
            this.pictureBox32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox32.TabIndex = 29;
            this.pictureBox32.TabStop = false;
            this.pictureBox32.Click += new System.EventHandler(this.pictureBox32_Click);
            // 
            // pictureBox31
            // 
            this.pictureBox31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox31.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox31.Location = new System.Drawing.Point(4, 85);
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.Size = new System.Drawing.Size(84, 59);
            this.pictureBox31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox31.TabIndex = 30;
            this.pictureBox31.TabStop = false;
            this.pictureBox31.Click += new System.EventHandler(this.pictureBox31_Click);
            // 
            // groupBox29
            // 
            this.groupBox29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox29.Controls.Add(this.nudBillNumberEdit);
            this.groupBox29.Controls.Add(this.dateTimePicker5);
            this.groupBox29.Controls.Add(this.label6);
            this.groupBox29.Controls.Add(this.label7);
            this.groupBox29.Controls.Add(this.dateTimePicker6);
            this.groupBox29.Controls.Add(this.label8);
            this.groupBox29.Controls.Add(this.pictureBox28);
            this.groupBox29.Depth = 0;
            this.groupBox29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox29.Location = new System.Drawing.Point(505, 3);
            this.groupBox29.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox29.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox29.Size = new System.Drawing.Size(1366, 70);
            this.groupBox29.TabIndex = 0;
            this.groupBox29.Text = "بحث الفواتير";
            // 
            // nudBillNumberEdit
            // 
            this.nudBillNumberEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBillNumberEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudBillNumberEdit.Location = new System.Drawing.Point(1146, 38);
            this.nudBillNumberEdit.Name = "nudBillNumberEdit";
            this.nudBillNumberEdit.Size = new System.Drawing.Size(167, 20);
            this.nudBillNumberEdit.TabIndex = 0;
            this.nudBillNumberEdit.Enter += new System.EventHandler(this.nudBillNumberEdit_Enter);
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker5.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker5.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker5.Location = new System.Drawing.Point(727, 38);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker5.RightToLeftLayout = true;
            this.dateTimePicker5.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker5.TabIndex = 2;
            this.dateTimePicker5.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Depth = 0;
            this.label6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label6.Location = new System.Drawing.Point(765, 12);
            this.label6.MouseState = MaterialSkin.MouseState.HOVER;
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "تاريخ البحث الى";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Depth = 0;
            this.label7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label7.Location = new System.Drawing.Point(1184, 12);
            this.label7.MouseState = MaterialSkin.MouseState.HOVER;
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "رقم الفاتوره";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker6.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker6.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker6.Location = new System.Drawing.Point(933, 38);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker6.RightToLeftLayout = true;
            this.dateTimePicker6.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker6.TabIndex = 1;
            this.dateTimePicker6.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Depth = 0;
            this.label8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label8.Location = new System.Drawing.Point(973, 12);
            this.label8.MouseState = MaterialSkin.MouseState.HOVER;
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 29;
            this.label8.Text = "تاريخ البحث من";
            this.label8.Visible = false;
            // 
            // pictureBox28
            // 
            this.pictureBox28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox28.Image = global::PlancksoftPOS.Properties.Resources.search;
            this.pictureBox28.Location = new System.Drawing.Point(674, 19);
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.Size = new System.Drawing.Size(47, 39);
            this.pictureBox28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox28.TabIndex = 31;
            this.pictureBox28.TabStop = false;
            this.pictureBox28.Click += new System.EventHandler(this.pictureBox28_Click);
            // 
            // TravelingUntravelingSales
            // 
            this.TravelingUntravelingSales.BackColor = System.Drawing.Color.White;
            this.TravelingUntravelingSales.Controls.Add(this.groupBox26);
            this.TravelingUntravelingSales.Controls.Add(this.groupBox25);
            this.TravelingUntravelingSales.Location = new System.Drawing.Point(4, 34);
            this.TravelingUntravelingSales.Name = "TravelingUntravelingSales";
            this.TravelingUntravelingSales.Size = new System.Drawing.Size(1867, 907);
            this.TravelingUntravelingSales.TabIndex = 1;
            this.TravelingUntravelingSales.Text = "المبيعات المرحله و الغير مرحله";
            // 
            // groupBox26
            // 
            this.groupBox26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox26.Controls.Add(this.panel16);
            this.groupBox26.Controls.Add(this.panel15);
            this.groupBox26.Depth = 0;
            this.groupBox26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox26.Location = new System.Drawing.Point(0, 366);
            this.groupBox26.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox26.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox26.Size = new System.Drawing.Size(2134, 626);
            this.groupBox26.TabIndex = 1;
            this.groupBox26.Text = "المبيعات المرحله";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel16.Controls.Add(this.dgvPortedSales);
            this.panel16.Depth = 0;
            this.panel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel16.Location = new System.Drawing.Point(3, 18);
            this.panel16.Margin = new System.Windows.Forms.Padding(14);
            this.panel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(14);
            this.panel16.Size = new System.Drawing.Size(2024, 605);
            this.panel16.TabIndex = 35;
            // 
            // dgvPortedSales
            // 
            this.dgvPortedSales.AllowUserToAddRows = false;
            this.dgvPortedSales.AllowUserToDeleteRows = false;
            this.dgvPortedSales.AllowUserToOrderColumns = true;
            this.dgvPortedSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPortedSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvPortedSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPortedSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.Column28,
            this.TotalPorted});
            this.dgvPortedSales.Location = new System.Drawing.Point(0, 3);
            this.dgvPortedSales.Name = "dgvPortedSales";
            this.dgvPortedSales.ReadOnly = true;
            this.dgvPortedSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPortedSales.Size = new System.Drawing.Size(2024, 491);
            this.dgvPortedSales.TabIndex = 31;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Bill Number";
            this.dataGridViewTextBoxColumn11.HeaderText = "رقم الفاتوره";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Cashier Name";
            this.dataGridViewTextBoxColumn12.HeaderText = "اسم الكاشير";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Total Amount";
            this.dataGridViewTextBoxColumn13.HeaderText = "المبلغ الصافي";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Paid Amount";
            this.dataGridViewTextBoxColumn14.HeaderText = "المبلغ المدفوع";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Remainder Amount";
            this.dataGridViewTextBoxColumn15.HeaderText = "المبلغ الباقي";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // Column28
            // 
            this.Column28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column28.DataPropertyName = "Payment Type";
            this.Column28.HeaderText = "طريقة الدفع";
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            // 
            // TotalPorted
            // 
            this.TotalPorted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalPorted.DataPropertyName = "TotalPorted";
            this.TotalPorted.HeaderText = "المجموع";
            this.TotalPorted.Name = "TotalPorted";
            this.TotalPorted.ReadOnly = true;
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel15.Controls.Add(this.pictureBox6);
            this.panel15.Controls.Add(this.pictureBox7);
            this.panel15.Depth = 0;
            this.panel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel15.Location = new System.Drawing.Point(2027, 18);
            this.panel15.Margin = new System.Windows.Forms.Padding(14);
            this.panel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(14);
            this.panel15.Size = new System.Drawing.Size(104, 605);
            this.panel15.TabIndex = 34;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox6.Location = new System.Drawing.Point(9, 18);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(83, 72);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 33;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox7.Location = new System.Drawing.Point(9, 96);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(83, 72);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 32;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox25.Controls.Add(this.panel14);
            this.groupBox25.Controls.Add(this.panel13);
            this.groupBox25.Depth = 0;
            this.groupBox25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox25.Location = new System.Drawing.Point(0, 0);
            this.groupBox25.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox25.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox25.Size = new System.Drawing.Size(2134, 734);
            this.groupBox25.TabIndex = 1;
            this.groupBox25.Text = "المبيعات الغير المرحله";
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel14.Controls.Add(this.dgvUnPortedSales);
            this.panel14.Depth = 0;
            this.panel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel14.Location = new System.Drawing.Point(3, 18);
            this.panel14.Margin = new System.Windows.Forms.Padding(14);
            this.panel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(14);
            this.panel14.Size = new System.Drawing.Size(2021, 572);
            this.panel14.TabIndex = 35;
            // 
            // dgvUnPortedSales
            // 
            this.dgvUnPortedSales.AllowUserToAddRows = false;
            this.dgvUnPortedSales.AllowUserToDeleteRows = false;
            this.dgvUnPortedSales.AllowUserToOrderColumns = true;
            this.dgvUnPortedSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnPortedSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnPortedSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnPortedSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.Column7,
            this.TotalUnPorted});
            this.dgvUnPortedSales.Location = new System.Drawing.Point(0, 0);
            this.dgvUnPortedSales.Name = "dgvUnPortedSales";
            this.dgvUnPortedSales.ReadOnly = true;
            this.dgvUnPortedSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvUnPortedSales.Size = new System.Drawing.Size(2021, 569);
            this.dgvUnPortedSales.TabIndex = 31;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Bill Number";
            this.dataGridViewTextBoxColumn6.HeaderText = "رقم الفاتوره";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Cashier Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "اسم الكاشير";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Total Amount";
            this.dataGridViewTextBoxColumn8.HeaderText = "المبلغ الصافي";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Paid Amount";
            this.dataGridViewTextBoxColumn9.HeaderText = "المبلغ المدفوع";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Remainder Amount";
            this.dataGridViewTextBoxColumn10.HeaderText = "المبلغ الباقي";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "Payment Type";
            this.Column7.HeaderText = "طريقة الدفع";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // TotalUnPorted
            // 
            this.TotalUnPorted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalUnPorted.DataPropertyName = "TotalUnPorted";
            this.TotalUnPorted.HeaderText = "المجموع";
            this.TotalUnPorted.Name = "TotalUnPorted";
            this.TotalUnPorted.ReadOnly = true;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel13.Controls.Add(this.pictureBox5);
            this.panel13.Controls.Add(this.pictureBox4);
            this.panel13.Depth = 0;
            this.panel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel13.Location = new System.Drawing.Point(2024, 18);
            this.panel13.Margin = new System.Windows.Forms.Padding(14);
            this.panel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(14);
            this.panel13.Size = new System.Drawing.Size(107, 572);
            this.panel13.TabIndex = 34;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox5.Location = new System.Drawing.Point(12, 104);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(83, 76);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 32;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox4.Location = new System.Drawing.Point(12, 26);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(83, 72);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // SoldItems
            // 
            this.SoldItems.BackColor = System.Drawing.Color.White;
            this.SoldItems.Controls.Add(this.groupBox28);
            this.SoldItems.Controls.Add(this.groupBox27);
            this.SoldItems.Location = new System.Drawing.Point(4, 34);
            this.SoldItems.Name = "SoldItems";
            this.SoldItems.Padding = new System.Windows.Forms.Padding(3);
            this.SoldItems.Size = new System.Drawing.Size(1867, 907);
            this.SoldItems.TabIndex = 2;
            this.SoldItems.Text = "جرد الكميات المباعه";
            // 
            // groupBox28
            // 
            this.groupBox28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox28.Controls.Add(this.label38);
            this.groupBox28.Controls.Add(this.comboBox2);
            this.groupBox28.Controls.Add(this.label37);
            this.groupBox28.Controls.Add(this.comboBox1);
            this.groupBox28.Controls.Add(this.dateTimePicker3);
            this.groupBox28.Controls.Add(this.label3);
            this.groupBox28.Controls.Add(this.dateTimePicker4);
            this.groupBox28.Controls.Add(this.label5);
            this.groupBox28.Controls.Add(this.pictureBox30);
            this.groupBox28.Depth = 0;
            this.groupBox28.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox28.Location = new System.Drawing.Point(3, 3);
            this.groupBox28.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox28.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox28.Size = new System.Drawing.Size(1861, 87);
            this.groupBox28.TabIndex = 0;
            this.groupBox28.Text = "البحث";
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.Depth = 0;
            this.label38.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label38.Location = new System.Drawing.Point(1432, 8);
            this.label38.MouseState = MaterialSkin.MouseState.HOVER;
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 19);
            this.label38.TabIndex = 36;
            this.label38.Text = "الصنف";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1567, 35);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(213, 21);
            this.comboBox2.TabIndex = 35;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.Depth = 0;
            this.label37.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label37.Location = new System.Drawing.Point(1640, 8);
            this.label37.MouseState = MaterialSkin.MouseState.HOVER;
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(48, 19);
            this.label37.TabIndex = 34;
            this.label37.Text = "اسم الكاشير";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1348, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 21);
            this.comboBox1.TabIndex = 33;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker3.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker3.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Location = new System.Drawing.Point(936, 36);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker3.RightToLeftLayout = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label3.Location = new System.Drawing.Point(975, 9);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 30;
            this.label3.Text = "تاريخ البحث الى";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker4.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker4.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker4.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.Location = new System.Drawing.Point(1142, 36);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker4.RightToLeftLayout = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label5.Location = new System.Drawing.Point(1183, 9);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "تاريخ البحث من";
            // 
            // pictureBox30
            // 
            this.pictureBox30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox30.Image = global::PlancksoftPOS.Properties.Resources.search;
            this.pictureBox30.Location = new System.Drawing.Point(1797, 19);
            this.pictureBox30.Name = "pictureBox30";
            this.pictureBox30.Size = new System.Drawing.Size(47, 39);
            this.pictureBox30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox30.TabIndex = 31;
            this.pictureBox30.TabStop = false;
            this.pictureBox30.Click += new System.EventHandler(this.pictureBox30_Click);
            // 
            // groupBox27
            // 
            this.groupBox27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox27.Controls.Add(this.dgvItemProfit);
            this.groupBox27.Controls.Add(this.pictureBox29);
            this.groupBox27.Depth = 0;
            this.groupBox27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox27.Location = new System.Drawing.Point(1, 93);
            this.groupBox27.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox27.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox27.Size = new System.Drawing.Size(2122, 807);
            this.groupBox27.TabIndex = 1;
            // 
            // dgvItemProfit
            // 
            this.dgvItemProfit.AllowUserToAddRows = false;
            this.dgvItemProfit.AllowUserToDeleteRows = false;
            this.dgvItemProfit.AllowUserToOrderColumns = true;
            this.dgvItemProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemProfit.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemProfit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemProfit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.Column48,
            this.Column49,
            this.ItemPriceTax,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            this.dgvItemProfit.Location = new System.Drawing.Point(10, 0);
            this.dgvItemProfit.Name = "dgvItemProfit";
            this.dgvItemProfit.ReadOnly = true;
            this.dgvItemProfit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvItemProfit.Size = new System.Drawing.Size(1856, 807);
            this.dgvItemProfit.TabIndex = 34;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn16.HeaderText = "إسم السلعه";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn17.HeaderText = "الباركود";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // Column48
            // 
            this.Column48.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column48.DataPropertyName = "Item Type";
            this.Column48.HeaderText = "صنف الماده";
            this.Column48.Name = "Column48";
            this.Column48.ReadOnly = true;
            // 
            // Column49
            // 
            this.Column49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column49.DataPropertyName = "Cashier Name";
            this.Column49.HeaderText = "اسم الكاشير";
            this.Column49.Name = "Column49";
            this.Column49.ReadOnly = true;
            // 
            // ItemPriceTax
            // 
            this.ItemPriceTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemPriceTax.DataPropertyName = "Item Price Tax";
            this.ItemPriceTax.HeaderText = "سعر القطعة بعد الضريبة";
            this.ItemPriceTax.Name = "ItemPriceTax";
            this.ItemPriceTax.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Times Sold";
            this.dataGridViewTextBoxColumn18.HeaderText = "الكميه المباعه";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Item Profit";
            this.dataGridViewTextBoxColumn19.HeaderText = "المجموع";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // pictureBox29
            // 
            this.pictureBox29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox29.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox29.Location = new System.Drawing.Point(2024, 20);
            this.pictureBox29.Name = "pictureBox29";
            this.pictureBox29.Size = new System.Drawing.Size(101, 102);
            this.pictureBox29.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox29.TabIndex = 32;
            this.pictureBox29.TabStop = false;
            this.pictureBox29.Click += new System.EventHandler(this.pictureBox29_Click);
            // 
            // Inventory
            // 
            this.Inventory.BackColor = System.Drawing.Color.White;
            this.Inventory.Controls.Add(this.tabControl6);
            this.Inventory.Location = new System.Drawing.Point(4, 34);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(1881, 951);
            this.Inventory.TabIndex = 2;
            this.Inventory.Text = "المستودع";
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.posInventory);
            this.tabControl6.Controls.Add(this.InventoryQuantify);
            this.tabControl6.Controls.Add(this.IncomingOutgoingItems);
            this.tabControl6.Controls.Add(this.AddTypes);
            this.tabControl6.Controls.Add(this.AddFavorites);
            this.tabControl6.Controls.Add(this.AddWarehouses);
            this.tabControl6.Depth = 0;
            this.tabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl6.ItemSize = new System.Drawing.Size(64, 30);
            this.tabControl6.Location = new System.Drawing.Point(0, 0);
            this.tabControl6.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl6.Multiline = true;
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl6.RightToLeftLayout = true;
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(1881, 951);
            this.tabControl6.TabIndex = 0;
            // 
            // posInventory
            // 
            this.posInventory.BackColor = System.Drawing.Color.White;
            this.posInventory.Controls.Add(this.groupBox8);
            this.posInventory.Controls.Add(this.groupBox7);
            this.posInventory.Location = new System.Drawing.Point(4, 34);
            this.posInventory.Name = "posInventory";
            this.posInventory.Padding = new System.Windows.Forms.Padding(3);
            this.posInventory.Size = new System.Drawing.Size(1873, 913);
            this.posInventory.TabIndex = 0;
            this.posInventory.Text = "المستودع";
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox8.Controls.Add(this.panel17);
            this.groupBox8.Controls.Add(this.panel18);
            this.groupBox8.Controls.Add(this.groupBox36);
            this.groupBox8.Depth = 0;
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox8.Location = new System.Drawing.Point(3, 95);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox8.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox8.Size = new System.Drawing.Size(1867, 815);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.Text = "مخزون البضائع";
            // 
            // panel17
            // 
            this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel17.Controls.Add(this.DgvInventory);
            this.panel17.Depth = 0;
            this.panel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel17.Location = new System.Drawing.Point(3, 181);
            this.panel17.Margin = new System.Windows.Forms.Padding(14);
            this.panel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(14);
            this.panel17.Size = new System.Drawing.Size(1735, 628);
            this.panel17.TabIndex = 47;
            // 
            // DgvInventory
            // 
            this.DgvInventory.AllowUserToAddRows = false;
            this.DgvInventory.AllowUserToDeleteRows = false;
            this.DgvInventory.AllowUserToOrderColumns = true;
            this.DgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.DgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryItemName,
            this.ItemID,
            this.InventoryItemBarCode,
            this.InventoryItemQuantity,
            this.InventoryItemBuyPrice,
            this.InventoryItemSellPrice,
            this.InventoryItemSellPriceTax,
            this.FavoriteCategoryNumber,
            this.InventoryItemFavoriteCategory,
            this.InventoryWarehouseID,
            this.InventoryItemWarehouse,
            this.InventoryItemTypeNumber,
            this.InventoryItemType,
            this.ItemPicture});
            this.DgvInventory.Location = new System.Drawing.Point(0, 0);
            this.DgvInventory.Name = "DgvInventory";
            this.DgvInventory.ReadOnly = true;
            this.DgvInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DgvInventory.Size = new System.Drawing.Size(1732, 620);
            this.DgvInventory.TabIndex = 0;
            this.DgvInventory.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInventory_RowHeaderMouseClick);
            // 
            // InventoryItemName
            // 
            this.InventoryItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemName.DataPropertyName = "Item Name";
            this.InventoryItemName.HeaderText = "إسم القطعه";
            this.InventoryItemName.Name = "InventoryItemName";
            this.InventoryItemName.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "Item ID";
            this.ItemID.HeaderText = "رقم القطعه";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            // 
            // InventoryItemBarCode
            // 
            this.InventoryItemBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemBarCode.DataPropertyName = "Item BarCode";
            this.InventoryItemBarCode.HeaderText = "باركود القطعه";
            this.InventoryItemBarCode.Name = "InventoryItemBarCode";
            this.InventoryItemBarCode.ReadOnly = true;
            // 
            // InventoryItemQuantity
            // 
            this.InventoryItemQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemQuantity.DataPropertyName = "Item Quantity";
            this.InventoryItemQuantity.HeaderText = "عدد القطعه";
            this.InventoryItemQuantity.Name = "InventoryItemQuantity";
            this.InventoryItemQuantity.ReadOnly = true;
            // 
            // InventoryItemBuyPrice
            // 
            this.InventoryItemBuyPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemBuyPrice.DataPropertyName = "Item Buy Price";
            this.InventoryItemBuyPrice.HeaderText = "سعر الشراء";
            this.InventoryItemBuyPrice.Name = "InventoryItemBuyPrice";
            this.InventoryItemBuyPrice.ReadOnly = true;
            // 
            // InventoryItemSellPrice
            // 
            this.InventoryItemSellPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemSellPrice.DataPropertyName = "Item Price";
            this.InventoryItemSellPrice.HeaderText = "سعر القطعه";
            this.InventoryItemSellPrice.Name = "InventoryItemSellPrice";
            this.InventoryItemSellPrice.ReadOnly = true;
            // 
            // InventoryItemSellPriceTax
            // 
            this.InventoryItemSellPriceTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemSellPriceTax.DataPropertyName = "Item Price Tax";
            this.InventoryItemSellPriceTax.HeaderText = "سعر القطعه بالضريبه";
            this.InventoryItemSellPriceTax.Name = "InventoryItemSellPriceTax";
            this.InventoryItemSellPriceTax.ReadOnly = true;
            // 
            // FavoriteCategoryNumber
            // 
            this.FavoriteCategoryNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FavoriteCategoryNumber.DataPropertyName = "Favorite Category Number";
            this.FavoriteCategoryNumber.HeaderText = "المصنف المفضل رقم";
            this.FavoriteCategoryNumber.Name = "FavoriteCategoryNumber";
            this.FavoriteCategoryNumber.ReadOnly = true;
            this.FavoriteCategoryNumber.Visible = false;
            // 
            // InventoryItemFavoriteCategory
            // 
            this.InventoryItemFavoriteCategory.DataPropertyName = "Favorite Category";
            this.InventoryItemFavoriteCategory.HeaderText = "المصنف المفضل";
            this.InventoryItemFavoriteCategory.Name = "InventoryItemFavoriteCategory";
            this.InventoryItemFavoriteCategory.ReadOnly = true;
            // 
            // InventoryWarehouseID
            // 
            this.InventoryWarehouseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryWarehouseID.DataPropertyName = "Warehouse ID";
            this.InventoryWarehouseID.HeaderText = "المستودع رقم";
            this.InventoryWarehouseID.Name = "InventoryWarehouseID";
            this.InventoryWarehouseID.ReadOnly = true;
            this.InventoryWarehouseID.Visible = false;
            // 
            // InventoryItemWarehouse
            // 
            this.InventoryItemWarehouse.DataPropertyName = "InventoryItemWarehouse";
            this.InventoryItemWarehouse.HeaderText = "المستودع";
            this.InventoryItemWarehouse.Name = "InventoryItemWarehouse";
            this.InventoryItemWarehouse.ReadOnly = true;
            // 
            // InventoryItemTypeNumber
            // 
            this.InventoryItemTypeNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InventoryItemTypeNumber.DataPropertyName = "Item Type";
            this.InventoryItemTypeNumber.HeaderText = "تصنيف الماده رقم";
            this.InventoryItemTypeNumber.Name = "InventoryItemTypeNumber";
            this.InventoryItemTypeNumber.ReadOnly = true;
            this.InventoryItemTypeNumber.Visible = false;
            // 
            // InventoryItemType
            // 
            this.InventoryItemType.DataPropertyName = "InventoryItemType";
            this.InventoryItemType.HeaderText = "تصنيف الماده";
            this.InventoryItemType.Name = "InventoryItemType";
            this.InventoryItemType.ReadOnly = true;
            // 
            // ItemPicture
            // 
            this.ItemPicture.DataPropertyName = "Item Picture";
            this.ItemPicture.HeaderText = "Item Picture";
            this.ItemPicture.Name = "ItemPicture";
            this.ItemPicture.ReadOnly = true;
            this.ItemPicture.Visible = false;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel18.Controls.Add(this.BtnDeleteItem);
            this.panel18.Controls.Add(this.BtnPrint);
            this.panel18.Controls.Add(this.BtnUpdateItem);
            this.panel18.Controls.Add(this.pictureBox99);
            this.panel18.Controls.Add(this.BtnAddItem);
            this.panel18.Depth = 0;
            this.panel18.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel18.Location = new System.Drawing.Point(1734, 177);
            this.panel18.Margin = new System.Windows.Forms.Padding(14);
            this.panel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(14);
            this.panel18.Size = new System.Drawing.Size(119, 624);
            this.panel18.TabIndex = 48;
            // 
            // BtnDeleteItem
            // 
            this.BtnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDeleteItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDeleteItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnDeleteItem.Depth = 0;
            this.BtnDeleteItem.HighEmphasis = true;
            this.BtnDeleteItem.Icon = null;
            this.BtnDeleteItem.Location = new System.Drawing.Point(19, 105);
            this.BtnDeleteItem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnDeleteItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnDeleteItem.Name = "BtnDeleteItem";
            this.BtnDeleteItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnDeleteItem.Size = new System.Drawing.Size(78, 36);
            this.BtnDeleteItem.TabIndex = 78;
            this.BtnDeleteItem.Text = "حذف قطعه";
            this.BtnDeleteItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnDeleteItem.UseAccentColor = false;
            this.BtnDeleteItem.UseVisualStyleBackColor = true;
            this.BtnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrint.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.BtnPrint.Location = new System.Drawing.Point(25, 275);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(72, 62);
            this.BtnPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnPrint.TabIndex = 24;
            this.BtnPrint.TabStop = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnUpdateItem
            // 
            this.BtnUpdateItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdateItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnUpdateItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnUpdateItem.Depth = 0;
            this.BtnUpdateItem.HighEmphasis = true;
            this.BtnUpdateItem.Icon = null;
            this.BtnUpdateItem.Location = new System.Drawing.Point(13, 57);
            this.BtnUpdateItem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnUpdateItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnUpdateItem.Name = "BtnUpdateItem";
            this.BtnUpdateItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnUpdateItem.Size = new System.Drawing.Size(85, 36);
            this.BtnUpdateItem.TabIndex = 77;
            this.BtnUpdateItem.Text = "تحديث قطعه";
            this.BtnUpdateItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnUpdateItem.UseAccentColor = false;
            this.BtnUpdateItem.UseVisualStyleBackColor = true;
            this.BtnUpdateItem.Click += new System.EventHandler(this.BtnUpdateItem_Click);
            // 
            // pictureBox99
            // 
            this.pictureBox99.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox99.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox99.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox99.Location = new System.Drawing.Point(25, 207);
            this.pictureBox99.Name = "pictureBox99";
            this.pictureBox99.Size = new System.Drawing.Size(72, 62);
            this.pictureBox99.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox99.TabIndex = 25;
            this.pictureBox99.TabStop = false;
            this.pictureBox99.Click += new System.EventHandler(this.pictureBox99_Click);
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnAddItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnAddItem.Depth = 0;
            this.BtnAddItem.HighEmphasis = true;
            this.BtnAddItem.Icon = null;
            this.BtnAddItem.Location = new System.Drawing.Point(14, 9);
            this.BtnAddItem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnAddItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnAddItem.Size = new System.Drawing.Size(83, 36);
            this.BtnAddItem.TabIndex = 76;
            this.BtnAddItem.Text = "إضافه قطعه";
            this.BtnAddItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnAddItem.UseAccentColor = false;
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // groupBox36
            // 
            this.groupBox36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox36.Controls.Add(this.label55);
            this.groupBox36.Controls.Add(this.nuditemPrice);
            this.groupBox36.Controls.Add(this.label63);
            this.groupBox36.Controls.Add(this.nuditemPriceTax);
            this.groupBox36.Controls.Add(this.label64);
            this.groupBox36.Controls.Add(this.FavoriteCategories);
            this.groupBox36.Controls.Add(this.nudItemBuyPrice);
            this.groupBox36.Controls.Add(this.label4);
            this.groupBox36.Controls.Add(this.ItemType);
            this.groupBox36.Controls.Add(this.ProductionDate);
            this.groupBox36.Controls.Add(this.label36);
            this.groupBox36.Controls.Add(this.QuantityWarning);
            this.groupBox36.Controls.Add(this.ExpirationDate);
            this.groupBox36.Controls.Add(this.txtItemName);
            this.groupBox36.Controls.Add(this.EntryDate);
            this.groupBox36.Controls.Add(this.label62);
            this.groupBox36.Controls.Add(this.txtItemBarCode);
            this.groupBox36.Controls.Add(this.label35);
            this.groupBox36.Controls.Add(this.label61);
            this.groupBox36.Controls.Add(this.label34);
            this.groupBox36.Controls.Add(this.label60);
            this.groupBox36.Controls.Add(this.nudItemQuantity);
            this.groupBox36.Controls.Add(this.label33);
            this.groupBox36.Controls.Add(this.label28);
            this.groupBox36.Controls.Add(this.Warehouse);
            this.groupBox36.Controls.Add(this.label25);
            this.groupBox36.Controls.Add(this.PBAddProfilePicture);
            this.groupBox36.Depth = 0;
            this.groupBox36.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox36.Location = new System.Drawing.Point(14, 14);
            this.groupBox36.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox36.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox36.Size = new System.Drawing.Size(1839, 163);
            this.groupBox36.TabIndex = 46;
            this.groupBox36.Text = "اضافة و تعديل المواد";
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Depth = 0;
            this.label55.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label55.Location = new System.Drawing.Point(1198, 10);
            this.label55.MouseState = MaterialSkin.MouseState.HOVER;
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(63, 19);
            this.label55.TabIndex = 18;
            this.label55.Text = "سعر بيع القطعه";
            // 
            // nuditemPrice
            // 
            this.nuditemPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuditemPrice.DecimalPlaces = 2;
            this.nuditemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuditemPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nuditemPrice.Location = new System.Drawing.Point(1187, 37);
            this.nuditemPrice.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nuditemPrice.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.nuditemPrice.Name = "nuditemPrice";
            this.nuditemPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nuditemPrice.Size = new System.Drawing.Size(130, 20);
            this.nuditemPrice.TabIndex = 4;
            this.nuditemPrice.ValueChanged += new System.EventHandler(this.nuditemPrice_ValueChanged);
            this.nuditemPrice.Enter += new System.EventHandler(this.nuditemPrice_Enter);
            // 
            // label63
            // 
            this.label63.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label63.AutoSize = true;
            this.label63.Depth = 0;
            this.label63.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label63.Location = new System.Drawing.Point(1046, 9);
            this.label63.MouseState = MaterialSkin.MouseState.HOVER;
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(78, 19);
            this.label63.TabIndex = 20;
            this.label63.Text = "سعر البيع بالضريبه";
            // 
            // nuditemPriceTax
            // 
            this.nuditemPriceTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nuditemPriceTax.DecimalPlaces = 2;
            this.nuditemPriceTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuditemPriceTax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nuditemPriceTax.Location = new System.Drawing.Point(1051, 37);
            this.nuditemPriceTax.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nuditemPriceTax.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.nuditemPriceTax.Name = "nuditemPriceTax";
            this.nuditemPriceTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nuditemPriceTax.Size = new System.Drawing.Size(130, 20);
            this.nuditemPriceTax.TabIndex = 5;
            this.nuditemPriceTax.Enter += new System.EventHandler(this.nuditemPriceTax_Enter);
            // 
            // label64
            // 
            this.label64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label64.AutoSize = true;
            this.label64.Depth = 0;
            this.label64.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label64.Location = new System.Drawing.Point(915, 11);
            this.label64.MouseState = MaterialSkin.MouseState.HOVER;
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(68, 19);
            this.label64.TabIndex = 23;
            this.label64.Text = "المصنف المفضل";
            // 
            // FavoriteCategories
            // 
            this.FavoriteCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FavoriteCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FavoriteCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.FavoriteCategories.FormattingEnabled = true;
            this.FavoriteCategories.Location = new System.Drawing.Point(906, 37);
            this.FavoriteCategories.Name = "FavoriteCategories";
            this.FavoriteCategories.Size = new System.Drawing.Size(137, 21);
            this.FavoriteCategories.TabIndex = 6;
            // 
            // nudItemBuyPrice
            // 
            this.nudItemBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudItemBuyPrice.DecimalPlaces = 2;
            this.nudItemBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudItemBuyPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudItemBuyPrice.Location = new System.Drawing.Point(1323, 37);
            this.nudItemBuyPrice.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nudItemBuyPrice.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.nudItemBuyPrice.Name = "nudItemBuyPrice";
            this.nudItemBuyPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nudItemBuyPrice.Size = new System.Drawing.Size(130, 20);
            this.nudItemBuyPrice.TabIndex = 3;
            this.nudItemBuyPrice.Enter += new System.EventHandler(this.nudItemBuyPrice_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label4.Location = new System.Drawing.Point(1352, 11);
            this.label4.MouseState = MaterialSkin.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "سعر الشراء";
            // 
            // ItemType
            // 
            this.ItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ItemType.FormattingEnabled = true;
            this.ItemType.Location = new System.Drawing.Point(763, 38);
            this.ItemType.Name = "ItemType";
            this.ItemType.Size = new System.Drawing.Size(137, 21);
            this.ItemType.TabIndex = 11;
            // 
            // ProductionDate
            // 
            this.ProductionDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ProductionDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ProductionDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ProductionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductionDate.Location = new System.Drawing.Point(1445, 129);
            this.ProductionDate.Name = "ProductionDate";
            this.ProductionDate.Size = new System.Drawing.Size(172, 20);
            this.ProductionDate.TabIndex = 8;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Depth = 0;
            this.label36.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label36.Location = new System.Drawing.Point(1495, 101);
            this.label36.MouseState = MaterialSkin.MouseState.HOVER;
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(52, 19);
            this.label36.TabIndex = 45;
            this.label36.Text = "تاريخ الإنتاج";
            // 
            // QuantityWarning
            // 
            this.QuantityWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuantityWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.QuantityWarning.Location = new System.Drawing.Point(1635, 129);
            this.QuantityWarning.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.QuantityWarning.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.QuantityWarning.Name = "QuantityWarning";
            this.QuantityWarning.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.QuantityWarning.Size = new System.Drawing.Size(189, 20);
            this.QuantityWarning.TabIndex = 7;
            this.QuantityWarning.Enter += new System.EventHandler(this.QuantityWarning_Enter_1);
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpirationDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ExpirationDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ExpirationDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpirationDate.Location = new System.Drawing.Point(1265, 129);
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.Size = new System.Drawing.Size(174, 20);
            this.ExpirationDate.TabIndex = 9;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.AnimateReadOnly = false;
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemName.Depth = 0;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.HideSelection = true;
            this.txtItemName.LeadingIcon = null;
            this.txtItemName.Location = new System.Drawing.Point(1635, 37);
            this.txtItemName.MaxLength = 32767;
            this.txtItemName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.PasswordChar = '\0';
            this.txtItemName.PrefixSuffixText = null;
            this.txtItemName.ReadOnly = false;
            this.txtItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemName.SelectedText = "";
            this.txtItemName.SelectionLength = 0;
            this.txtItemName.SelectionStart = 0;
            this.txtItemName.ShortcutsEnabled = true;
            this.txtItemName.Size = new System.Drawing.Size(192, 48);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemName.TrailingIcon = null;
            this.txtItemName.UseSystemPasswordChar = false;
            // 
            // EntryDate
            // 
            this.EntryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EntryDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryDate.Location = new System.Drawing.Point(1086, 128);
            this.EntryDate.Name = "EntryDate";
            this.EntryDate.Size = new System.Drawing.Size(173, 20);
            this.EntryDate.TabIndex = 10;
            // 
            // label62
            // 
            this.label62.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label62.AutoSize = true;
            this.label62.Depth = 0;
            this.label62.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label62.Location = new System.Drawing.Point(1697, 10);
            this.label62.MouseState = MaterialSkin.MouseState.HOVER;
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(45, 19);
            this.label62.TabIndex = 7;
            this.label62.Text = "إسم القطعه";
            // 
            // txtItemBarCode
            // 
            this.txtItemBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemBarCode.AnimateReadOnly = false;
            this.txtItemBarCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemBarCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemBarCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemBarCode.Depth = 0;
            this.txtItemBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemBarCode.HideSelection = true;
            this.txtItemBarCode.LeadingIcon = null;
            this.txtItemBarCode.Location = new System.Drawing.Point(1468, 37);
            this.txtItemBarCode.MaxLength = 32767;
            this.txtItemBarCode.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemBarCode.Name = "txtItemBarCode";
            this.txtItemBarCode.PasswordChar = '\0';
            this.txtItemBarCode.PrefixSuffixText = null;
            this.txtItemBarCode.ReadOnly = false;
            this.txtItemBarCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemBarCode.SelectedText = "";
            this.txtItemBarCode.SelectionLength = 0;
            this.txtItemBarCode.SelectionStart = 0;
            this.txtItemBarCode.ShortcutsEnabled = true;
            this.txtItemBarCode.Size = new System.Drawing.Size(149, 48);
            this.txtItemBarCode.TabIndex = 1;
            this.txtItemBarCode.TabStop = false;
            this.txtItemBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemBarCode.TrailingIcon = null;
            this.txtItemBarCode.UseSystemPasswordChar = false;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Depth = 0;
            this.label35.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label35.Location = new System.Drawing.Point(1692, 102);
            this.label35.MouseState = MaterialSkin.MouseState.HOVER;
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(45, 19);
            this.label35.TabIndex = 43;
            this.label35.Text = "تنبيه الكميه";
            // 
            // label61
            // 
            this.label61.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label61.AutoSize = true;
            this.label61.Depth = 0;
            this.label61.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label61.Location = new System.Drawing.Point(1494, 9);
            this.label61.MouseState = MaterialSkin.MouseState.HOVER;
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(57, 19);
            this.label61.TabIndex = 9;
            this.label61.Text = "باركود القطعه";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Depth = 0;
            this.label34.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label34.Location = new System.Drawing.Point(1271, 101);
            this.label34.MouseState = MaterialSkin.MouseState.HOVER;
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(89, 19);
            this.label34.TabIndex = 41;
            this.label34.Text = "تاريخ إنتهاء الصلاحيه";
            // 
            // label60
            // 
            this.label60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label60.AutoSize = true;
            this.label60.Depth = 0;
            this.label60.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label60.Location = new System.Drawing.Point(1368, 9);
            this.label60.MouseState = MaterialSkin.MouseState.HOVER;
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(46, 19);
            this.label60.TabIndex = 11;
            this.label60.Text = "عدد القطعه";
            this.label60.Visible = false;
            // 
            // nudItemQuantity
            // 
            this.nudItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudItemQuantity.Enabled = false;
            this.nudItemQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudItemQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudItemQuantity.Location = new System.Drawing.Point(1339, 38);
            this.nudItemQuantity.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nudItemQuantity.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.nudItemQuantity.Name = "nudItemQuantity";
            this.nudItemQuantity.ReadOnly = true;
            this.nudItemQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nudItemQuantity.Size = new System.Drawing.Size(110, 20);
            this.nudItemQuantity.TabIndex = 2;
            this.nudItemQuantity.Visible = false;
            this.nudItemQuantity.Enter += new System.EventHandler(this.nudItemQuantity_Enter);
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Depth = 0;
            this.label33.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label33.Location = new System.Drawing.Point(1120, 101);
            this.label33.MouseState = MaterialSkin.MouseState.HOVER;
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(56, 19);
            this.label33.TabIndex = 39;
            this.label33.Text = "تاريخ الإدخال";
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Depth = 0;
            this.label28.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label28.Location = new System.Drawing.Point(797, 13);
            this.label28.MouseState = MaterialSkin.MouseState.HOVER;
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(54, 19);
            this.label28.TabIndex = 37;
            this.label28.Text = "تصنيف الماده";
            // 
            // Warehouse
            // 
            this.Warehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Warehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Warehouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.Warehouse.FormattingEnabled = true;
            this.Warehouse.Location = new System.Drawing.Point(943, 127);
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.Size = new System.Drawing.Size(137, 21);
            this.Warehouse.TabIndex = 12;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Depth = 0;
            this.label25.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label25.Location = new System.Drawing.Point(976, 101);
            this.label25.MouseState = MaterialSkin.MouseState.HOVER;
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 19);
            this.label25.TabIndex = 35;
            this.label25.Text = "المستودع";
            // 
            // PBAddProfilePicture
            // 
            this.PBAddProfilePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBAddProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBAddProfilePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBAddProfilePicture.Image = global::PlancksoftPOS.Properties.Resources.istockphoto_1166351637_612x612;
            this.PBAddProfilePicture.Location = new System.Drawing.Point(857, 78);
            this.PBAddProfilePicture.Name = "PBAddProfilePicture";
            this.PBAddProfilePicture.Size = new System.Drawing.Size(80, 71);
            this.PBAddProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBAddProfilePicture.TabIndex = 31;
            this.PBAddProfilePicture.TabStop = false;
            this.PBAddProfilePicture.Click += new System.EventHandler(this.PBAddProfilePicture_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox7.Controls.Add(this.BtnSearchItem);
            this.groupBox7.Controls.Add(this.nudItemBarCodeSearch);
            this.groupBox7.Controls.Add(this.dtpSearch2);
            this.groupBox7.Controls.Add(this.label56);
            this.groupBox7.Controls.Add(this.label57);
            this.groupBox7.Controls.Add(this.label58);
            this.groupBox7.Controls.Add(this.dtpSearch1);
            this.groupBox7.Controls.Add(this.txtItemNameSearch);
            this.groupBox7.Controls.Add(this.label59);
            this.groupBox7.Depth = 0;
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox7.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox7.Size = new System.Drawing.Size(1867, 92);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.Text = "البحث عن القطع";
            // 
            // BtnSearchItem
            // 
            this.BtnSearchItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearchItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSearchItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnSearchItem.Depth = 0;
            this.BtnSearchItem.HighEmphasis = true;
            this.BtnSearchItem.Icon = null;
            this.BtnSearchItem.Location = new System.Drawing.Point(1760, 30);
            this.BtnSearchItem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnSearchItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSearchItem.Name = "BtnSearchItem";
            this.BtnSearchItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnSearchItem.Size = new System.Drawing.Size(64, 36);
            this.BtnSearchItem.TabIndex = 75;
            this.BtnSearchItem.Text = "البحث";
            this.BtnSearchItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnSearchItem.UseAccentColor = false;
            this.BtnSearchItem.UseVisualStyleBackColor = true;
            this.BtnSearchItem.Click += new System.EventHandler(this.BtnSearchItem_Click);
            // 
            // nudItemBarCodeSearch
            // 
            this.nudItemBarCodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudItemBarCodeSearch.AnimateReadOnly = false;
            this.nudItemBarCodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.nudItemBarCodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.nudItemBarCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.nudItemBarCodeSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.nudItemBarCodeSearch.Depth = 0;
            this.nudItemBarCodeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudItemBarCodeSearch.HideSelection = true;
            this.nudItemBarCodeSearch.LeadingIcon = null;
            this.nudItemBarCodeSearch.Location = new System.Drawing.Point(1571, 29);
            this.nudItemBarCodeSearch.MaxLength = 32767;
            this.nudItemBarCodeSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.nudItemBarCodeSearch.Name = "nudItemBarCodeSearch";
            this.nudItemBarCodeSearch.PasswordChar = '\0';
            this.nudItemBarCodeSearch.PrefixSuffixText = null;
            this.nudItemBarCodeSearch.ReadOnly = false;
            this.nudItemBarCodeSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudItemBarCodeSearch.SelectedText = "";
            this.nudItemBarCodeSearch.SelectionLength = 0;
            this.nudItemBarCodeSearch.SelectionStart = 0;
            this.nudItemBarCodeSearch.ShortcutsEnabled = true;
            this.nudItemBarCodeSearch.Size = new System.Drawing.Size(167, 48);
            this.nudItemBarCodeSearch.TabIndex = 0;
            this.nudItemBarCodeSearch.TabStop = false;
            this.nudItemBarCodeSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.nudItemBarCodeSearch.TrailingIcon = null;
            this.nudItemBarCodeSearch.UseSystemPasswordChar = false;
            // 
            // dtpSearch2
            // 
            this.dtpSearch2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSearch2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtpSearch2.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpSearch2.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpSearch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearch2.Location = new System.Drawing.Point(714, 46);
            this.dtpSearch2.Name = "dtpSearch2";
            this.dtpSearch2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpSearch2.RightToLeftLayout = true;
            this.dtpSearch2.Size = new System.Drawing.Size(208, 20);
            this.dtpSearch2.TabIndex = 3;
            this.dtpSearch2.Visible = false;
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.AutoSize = true;
            this.label56.Depth = 0;
            this.label56.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label56.Location = new System.Drawing.Point(756, 20);
            this.label56.MouseState = MaterialSkin.MouseState.HOVER;
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(67, 19);
            this.label56.TabIndex = 23;
            this.label56.Text = "تاريخ البحث إلى";
            this.label56.Visible = false;
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label57.AutoSize = true;
            this.label57.Depth = 0;
            this.label57.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label57.Location = new System.Drawing.Point(1602, 3);
            this.label57.MouseState = MaterialSkin.MouseState.HOVER;
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(57, 19);
            this.label57.TabIndex = 16;
            this.label57.Text = "باركود القطعه";
            // 
            // label58
            // 
            this.label58.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label58.AutoSize = true;
            this.label58.Depth = 0;
            this.label58.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label58.Location = new System.Drawing.Point(1318, 3);
            this.label58.MouseState = MaterialSkin.MouseState.HOVER;
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(45, 19);
            this.label58.TabIndex = 7;
            this.label58.Text = "إسم القطعه";
            // 
            // dtpSearch1
            // 
            this.dtpSearch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSearch1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtpSearch1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpSearch1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dtpSearch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearch1.Location = new System.Drawing.Point(928, 46);
            this.dtpSearch1.Name = "dtpSearch1";
            this.dtpSearch1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpSearch1.RightToLeftLayout = true;
            this.dtpSearch1.Size = new System.Drawing.Size(217, 20);
            this.dtpSearch1.TabIndex = 2;
            this.dtpSearch1.Visible = false;
            // 
            // txtItemNameSearch
            // 
            this.txtItemNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemNameSearch.AnimateReadOnly = false;
            this.txtItemNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtItemNameSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtItemNameSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtItemNameSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtItemNameSearch.Depth = 0;
            this.txtItemNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNameSearch.HideSelection = true;
            this.txtItemNameSearch.LeadingIcon = null;
            this.txtItemNameSearch.Location = new System.Drawing.Point(1151, 29);
            this.txtItemNameSearch.MaxLength = 32767;
            this.txtItemNameSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtItemNameSearch.Name = "txtItemNameSearch";
            this.txtItemNameSearch.PasswordChar = '\0';
            this.txtItemNameSearch.PrefixSuffixText = null;
            this.txtItemNameSearch.ReadOnly = false;
            this.txtItemNameSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemNameSearch.SelectedText = "";
            this.txtItemNameSearch.SelectionLength = 0;
            this.txtItemNameSearch.SelectionStart = 0;
            this.txtItemNameSearch.ShortcutsEnabled = true;
            this.txtItemNameSearch.Size = new System.Drawing.Size(416, 48);
            this.txtItemNameSearch.TabIndex = 1;
            this.txtItemNameSearch.TabStop = false;
            this.txtItemNameSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtItemNameSearch.TrailingIcon = null;
            this.txtItemNameSearch.UseSystemPasswordChar = false;
            // 
            // label59
            // 
            this.label59.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label59.AutoSize = true;
            this.label59.Depth = 0;
            this.label59.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label59.Location = new System.Drawing.Point(976, 20);
            this.label59.MouseState = MaterialSkin.MouseState.HOVER;
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(65, 19);
            this.label59.TabIndex = 18;
            this.label59.Text = "تاريخ البحث من";
            this.label59.Visible = false;
            // 
            // InventoryQuantify
            // 
            this.InventoryQuantify.BackColor = System.Drawing.Color.White;
            this.InventoryQuantify.Controls.Add(this.groupBox45);
            this.InventoryQuantify.Controls.Add(this.groupBox46);
            this.InventoryQuantify.Location = new System.Drawing.Point(4, 34);
            this.InventoryQuantify.Name = "InventoryQuantify";
            this.InventoryQuantify.Size = new System.Drawing.Size(1873, 913);
            this.InventoryQuantify.TabIndex = 4;
            this.InventoryQuantify.Text = "جرد المستودعات";
            // 
            // groupBox45
            // 
            this.groupBox45.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox45.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox45.Controls.Add(this.button13);
            this.groupBox45.Controls.Add(this.WarehousesQuantityList);
            this.groupBox45.Controls.Add(this.label47);
            this.groupBox45.Depth = 0;
            this.groupBox45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox45.Location = new System.Drawing.Point(2, -1);
            this.groupBox45.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox45.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox45.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox45.Size = new System.Drawing.Size(1871, 79);
            this.groupBox45.TabIndex = 23;
            this.groupBox45.Text = "البحث عن المستودع";
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button13.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button13.Depth = 0;
            this.button13.HighEmphasis = true;
            this.button13.Icon = null;
            this.button13.Location = new System.Drawing.Point(1774, 35);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button13.MouseState = MaterialSkin.MouseState.HOVER;
            this.button13.Name = "button13";
            this.button13.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button13.Size = new System.Drawing.Size(64, 36);
            this.button13.TabIndex = 76;
            this.button13.Text = "البحث";
            this.button13.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button13.UseAccentColor = false;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // WarehousesQuantityList
            // 
            this.WarehousesQuantityList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WarehousesQuantityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WarehousesQuantityList.FormattingEnabled = true;
            this.WarehousesQuantityList.Location = new System.Drawing.Point(1509, 47);
            this.WarehousesQuantityList.Name = "WarehousesQuantityList";
            this.WarehousesQuantityList.Size = new System.Drawing.Size(235, 24);
            this.WarehousesQuantityList.TabIndex = 17;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label47.AutoSize = true;
            this.label47.Depth = 0;
            this.label47.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label47.Location = new System.Drawing.Point(1595, 27);
            this.label47.MouseState = MaterialSkin.MouseState.HOVER;
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(38, 19);
            this.label47.TabIndex = 16;
            this.label47.Text = "المستودع";
            // 
            // groupBox46
            // 
            this.groupBox46.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox46.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox46.Controls.Add(this.pictureBox47);
            this.groupBox46.Controls.Add(this.dgvWarehouseInventory);
            this.groupBox46.Depth = 0;
            this.groupBox46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox46.Location = new System.Drawing.Point(2, 76);
            this.groupBox46.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox46.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox46.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox46.Size = new System.Drawing.Size(1871, 925);
            this.groupBox46.TabIndex = 22;
            this.groupBox46.Text = "مخزون البضائع في المستودع";
            // 
            // pictureBox47
            // 
            this.pictureBox47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox47.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox47.Location = new System.Drawing.Point(1774, 21);
            this.pictureBox47.Name = "pictureBox47";
            this.pictureBox47.Size = new System.Drawing.Size(64, 45);
            this.pictureBox47.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox47.TabIndex = 24;
            this.pictureBox47.TabStop = false;
            this.pictureBox47.Click += new System.EventHandler(this.pictureBox47_Click);
            // 
            // dgvWarehouseInventory
            // 
            this.dgvWarehouseInventory.AllowUserToAddRows = false;
            this.dgvWarehouseInventory.AllowUserToDeleteRows = false;
            this.dgvWarehouseInventory.AllowUserToOrderColumns = true;
            this.dgvWarehouseInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouseInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvWarehouseInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouseInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn46,
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn49});
            this.dgvWarehouseInventory.Location = new System.Drawing.Point(12, 19);
            this.dgvWarehouseInventory.Name = "dgvWarehouseInventory";
            this.dgvWarehouseInventory.ReadOnly = true;
            this.dgvWarehouseInventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvWarehouseInventory.Size = new System.Drawing.Size(1756, 772);
            this.dgvWarehouseInventory.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn32.HeaderText = "اسم القطعه";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn37.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn37.HeaderText = "باركود القطعه";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn38.DataPropertyName = "Item Quantity";
            this.dataGridViewTextBoxColumn38.HeaderText = "عدد القطعه";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn42.DataPropertyName = "Item Buy Price";
            this.dataGridViewTextBoxColumn42.HeaderText = "سعر الشراء";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Item Price";
            this.dataGridViewTextBoxColumn45.HeaderText = "سعر القطعه";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn46.DataPropertyName = "Item Price Tax";
            this.dataGridViewTextBoxColumn46.HeaderText = "سعر القطعه بالضريبه";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn47.DataPropertyName = "Favorite Category";
            this.dataGridViewTextBoxColumn47.HeaderText = "المصنف المفضل";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn48.DataPropertyName = "Warehouse ID";
            this.dataGridViewTextBoxColumn48.HeaderText = "المستودع";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn49.DataPropertyName = "Item Type";
            this.dataGridViewTextBoxColumn49.HeaderText = "تصنيف الماده";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.ReadOnly = true;
            // 
            // IncomingOutgoingItems
            // 
            this.IncomingOutgoingItems.BackColor = System.Drawing.Color.White;
            this.IncomingOutgoingItems.Controls.Add(this.groupBox48);
            this.IncomingOutgoingItems.Location = new System.Drawing.Point(4, 34);
            this.IncomingOutgoingItems.Name = "IncomingOutgoingItems";
            this.IncomingOutgoingItems.Size = new System.Drawing.Size(1873, 913);
            this.IncomingOutgoingItems.TabIndex = 5;
            this.IncomingOutgoingItems.Text = "سند إدخال و إخراج";
            // 
            // groupBox48
            // 
            this.groupBox48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox48.Controls.Add(this.btnPickClientForImportExport);
            this.groupBox48.Controls.Add(this.txtClientNameImportExport);
            this.groupBox48.Controls.Add(this.nudClientIDImportExport);
            this.groupBox48.Controls.Add(this.lblClientIDImportExport);
            this.groupBox48.Controls.Add(this.lblClientNameImportExport);
            this.groupBox48.Controls.Add(this.button15);
            this.groupBox48.Controls.Add(this.button36);
            this.groupBox48.Controls.Add(this.button38);
            this.groupBox48.Controls.Add(this.button14);
            this.groupBox48.Controls.Add(this.label46);
            this.groupBox48.Controls.Add(this.EntryExitItemBuyPrice);
            this.groupBox48.Controls.Add(this.dvgEntryExitItems);
            this.groupBox48.Controls.Add(this.WarehouseEntryExitList);
            this.groupBox48.Controls.Add(this.label103);
            this.groupBox48.Controls.Add(this.EntryExitType);
            this.groupBox48.Controls.Add(this.label53);
            this.groupBox48.Controls.Add(this.WarehouseEntryExitItemBarCode);
            this.groupBox48.Controls.Add(this.WarehouseEntryExitItemName);
            this.groupBox48.Controls.Add(this.EntryExitProductionDate);
            this.groupBox48.Controls.Add(this.label48);
            this.groupBox48.Controls.Add(this.label79);
            this.groupBox48.Controls.Add(this.EntryExitWarningQuantity);
            this.groupBox48.Controls.Add(this.EntryExitExpirationDate);
            this.groupBox48.Controls.Add(this.EntryExitEntryDate);
            this.groupBox48.Controls.Add(this.label94);
            this.groupBox48.Controls.Add(this.label96);
            this.groupBox48.Controls.Add(this.label97);
            this.groupBox48.Controls.Add(this.EntryExitItemQuantity);
            this.groupBox48.Controls.Add(this.label98);
            this.groupBox48.Controls.Add(this.label101);
            this.groupBox48.Depth = 0;
            this.groupBox48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox48.Location = new System.Drawing.Point(0, 0);
            this.groupBox48.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox48.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox48.Size = new System.Drawing.Size(1873, 913);
            this.groupBox48.TabIndex = 48;
            this.groupBox48.Text = "اضافة سند إدخال و إخراج";
            // 
            // btnPickClientForImportExport
            // 
            this.btnPickClientForImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickClientForImportExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPickClientForImportExport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPickClientForImportExport.Depth = 0;
            this.btnPickClientForImportExport.HighEmphasis = true;
            this.btnPickClientForImportExport.Icon = null;
            this.btnPickClientForImportExport.Location = new System.Drawing.Point(1765, 156);
            this.btnPickClientForImportExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPickClientForImportExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPickClientForImportExport.Name = "btnPickClientForImportExport";
            this.btnPickClientForImportExport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPickClientForImportExport.Size = new System.Drawing.Size(89, 36);
            this.btnPickClientForImportExport.TabIndex = 90;
            this.btnPickClientForImportExport.Text = "إختيار العميل";
            this.btnPickClientForImportExport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPickClientForImportExport.UseAccentColor = false;
            this.btnPickClientForImportExport.UseVisualStyleBackColor = true;
            this.btnPickClientForImportExport.Click += new System.EventHandler(this.btnPickClientForImportExport_Click);
            // 
            // txtClientNameImportExport
            // 
            this.txtClientNameImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientNameImportExport.AnimateReadOnly = false;
            this.txtClientNameImportExport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtClientNameImportExport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtClientNameImportExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtClientNameImportExport.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtClientNameImportExport.Depth = 0;
            this.txtClientNameImportExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientNameImportExport.HideSelection = true;
            this.txtClientNameImportExport.LeadingIcon = null;
            this.txtClientNameImportExport.Location = new System.Drawing.Point(510, 77);
            this.txtClientNameImportExport.MaxLength = 32767;
            this.txtClientNameImportExport.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClientNameImportExport.Name = "txtClientNameImportExport";
            this.txtClientNameImportExport.PasswordChar = '\0';
            this.txtClientNameImportExport.PrefixSuffixText = null;
            this.txtClientNameImportExport.ReadOnly = true;
            this.txtClientNameImportExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtClientNameImportExport.SelectedText = "";
            this.txtClientNameImportExport.SelectionLength = 0;
            this.txtClientNameImportExport.SelectionStart = 0;
            this.txtClientNameImportExport.ShortcutsEnabled = true;
            this.txtClientNameImportExport.Size = new System.Drawing.Size(393, 48);
            this.txtClientNameImportExport.TabIndex = 89;
            this.txtClientNameImportExport.TabStop = false;
            this.txtClientNameImportExport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtClientNameImportExport.TrailingIcon = null;
            this.txtClientNameImportExport.UseSystemPasswordChar = false;
            // 
            // nudClientIDImportExport
            // 
            this.nudClientIDImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudClientIDImportExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudClientIDImportExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudClientIDImportExport.Location = new System.Drawing.Point(107, 105);
            this.nudClientIDImportExport.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.nudClientIDImportExport.Name = "nudClientIDImportExport";
            this.nudClientIDImportExport.ReadOnly = true;
            this.nudClientIDImportExport.Size = new System.Drawing.Size(397, 20);
            this.nudClientIDImportExport.TabIndex = 86;
            // 
            // lblClientIDImportExport
            // 
            this.lblClientIDImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientIDImportExport.AutoSize = true;
            this.lblClientIDImportExport.Depth = 0;
            this.lblClientIDImportExport.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientIDImportExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientIDImportExport.Location = new System.Drawing.Point(293, 78);
            this.lblClientIDImportExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientIDImportExport.Name = "lblClientIDImportExport";
            this.lblClientIDImportExport.Size = new System.Drawing.Size(46, 19);
            this.lblClientIDImportExport.TabIndex = 88;
            this.lblClientIDImportExport.Text = "رمز العميل";
            // 
            // lblClientNameImportExport
            // 
            this.lblClientNameImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientNameImportExport.AutoSize = true;
            this.lblClientNameImportExport.Depth = 0;
            this.lblClientNameImportExport.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientNameImportExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientNameImportExport.Location = new System.Drawing.Point(692, 55);
            this.lblClientNameImportExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientNameImportExport.Name = "lblClientNameImportExport";
            this.lblClientNameImportExport.Size = new System.Drawing.Size(43, 19);
            this.lblClientNameImportExport.TabIndex = 87;
            this.lblClientNameImportExport.Text = "إسم العميل";
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button15.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button15.Depth = 0;
            this.button15.HighEmphasis = true;
            this.button15.Icon = null;
            this.button15.Location = new System.Drawing.Point(1772, 348);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button15.MouseState = MaterialSkin.MouseState.HOVER;
            this.button15.Name = "button15";
            this.button15.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button15.Size = new System.Drawing.Size(82, 36);
            this.button15.TabIndex = 80;
            this.button15.Text = "إتمام العمليه";
            this.button15.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button15.UseAccentColor = false;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button36
            // 
            this.button36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button36.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button36.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button36.Depth = 0;
            this.button36.HighEmphasis = true;
            this.button36.Icon = null;
            this.button36.Location = new System.Drawing.Point(1782, 300);
            this.button36.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button36.MouseState = MaterialSkin.MouseState.HOVER;
            this.button36.Name = "button36";
            this.button36.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button36.Size = new System.Drawing.Size(72, 36);
            this.button36.TabIndex = 79;
            this.button36.Text = "حذف ماده";
            this.button36.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button36.UseAccentColor = false;
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button38
            // 
            this.button38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button38.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button38.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button38.Depth = 0;
            this.button38.HighEmphasis = true;
            this.button38.Icon = null;
            this.button38.Location = new System.Drawing.Point(1777, 252);
            this.button38.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button38.MouseState = MaterialSkin.MouseState.HOVER;
            this.button38.Name = "button38";
            this.button38.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button38.Size = new System.Drawing.Size(77, 36);
            this.button38.TabIndex = 78;
            this.button38.Text = "إضافة ماده";
            this.button38.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button38.UseAccentColor = false;
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button14.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button14.Depth = 0;
            this.button14.HighEmphasis = true;
            this.button14.Icon = null;
            this.button14.Location = new System.Drawing.Point(1776, 204);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button14.MouseState = MaterialSkin.MouseState.HOVER;
            this.button14.Name = "button14";
            this.button14.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button14.Size = new System.Drawing.Size(78, 36);
            this.button14.TabIndex = 77;
            this.button14.Text = "إختيار ماده";
            this.button14.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button14.UseAccentColor = false;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label46.AutoSize = true;
            this.label46.Depth = 0;
            this.label46.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label46.Location = new System.Drawing.Point(941, 82);
            this.label46.MouseState = MaterialSkin.MouseState.HOVER;
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(49, 19);
            this.label46.TabIndex = 49;
            this.label46.Text = "سعر الشراء";
            // 
            // EntryExitItemBuyPrice
            // 
            this.EntryExitItemBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitItemBuyPrice.DecimalPlaces = 2;
            this.EntryExitItemBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitItemBuyPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitItemBuyPrice.Location = new System.Drawing.Point(909, 105);
            this.EntryExitItemBuyPrice.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.EntryExitItemBuyPrice.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.EntryExitItemBuyPrice.Name = "EntryExitItemBuyPrice";
            this.EntryExitItemBuyPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EntryExitItemBuyPrice.Size = new System.Drawing.Size(110, 20);
            this.EntryExitItemBuyPrice.TabIndex = 48;
            // 
            // dvgEntryExitItems
            // 
            this.dvgEntryExitItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgEntryExitItems.BackgroundColor = System.Drawing.Color.White;
            this.dvgEntryExitItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEntryExitItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntryExitItemName,
            this.EntryExitItemBarCode,
            this.EntryExitItemQuantity2,
            this.EntryExitItemWarehouse,
            this.EntryExitItemVendorItemBuyPrice,
            this.EntryExitItemWarningQuantity,
            this.EntryExitItemProductionDate,
            this.EntryExitItemEndDate,
            this.EntryExitItemEntryDate});
            this.dvgEntryExitItems.Location = new System.Drawing.Point(7, 131);
            this.dvgEntryExitItems.Name = "dvgEntryExitItems";
            this.dvgEntryExitItems.ReadOnly = true;
            this.dvgEntryExitItems.Size = new System.Drawing.Size(1725, 738);
            this.dvgEntryExitItems.TabIndex = 49;
            this.dvgEntryExitItems.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvgEntryExitItems_RowHeaderMouseClick);
            // 
            // EntryExitItemName
            // 
            this.EntryExitItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemName.DataPropertyName = "Item Name";
            this.EntryExitItemName.HeaderText = "اسم الماده";
            this.EntryExitItemName.Name = "EntryExitItemName";
            this.EntryExitItemName.ReadOnly = true;
            // 
            // EntryExitItemBarCode
            // 
            this.EntryExitItemBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemBarCode.DataPropertyName = "Item BarCode";
            this.EntryExitItemBarCode.HeaderText = "باركود الماده";
            this.EntryExitItemBarCode.Name = "EntryExitItemBarCode";
            this.EntryExitItemBarCode.ReadOnly = true;
            // 
            // EntryExitItemQuantity2
            // 
            this.EntryExitItemQuantity2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemQuantity2.DataPropertyName = "Item Quantity";
            this.EntryExitItemQuantity2.HeaderText = "عدد القطع";
            this.EntryExitItemQuantity2.Name = "EntryExitItemQuantity2";
            this.EntryExitItemQuantity2.ReadOnly = true;
            // 
            // EntryExitItemWarehouse
            // 
            this.EntryExitItemWarehouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemWarehouse.DataPropertyName = "Item Warehouse";
            this.EntryExitItemWarehouse.HeaderText = "المستودع";
            this.EntryExitItemWarehouse.Name = "EntryExitItemWarehouse";
            this.EntryExitItemWarehouse.ReadOnly = true;
            // 
            // EntryExitItemVendorItemBuyPrice
            // 
            this.EntryExitItemVendorItemBuyPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemVendorItemBuyPrice.DataPropertyName = "VendorItemBuyPrice";
            this.EntryExitItemVendorItemBuyPrice.HeaderText = "سعر الشراء";
            this.EntryExitItemVendorItemBuyPrice.Name = "EntryExitItemVendorItemBuyPrice";
            this.EntryExitItemVendorItemBuyPrice.ReadOnly = true;
            // 
            // EntryExitItemWarningQuantity
            // 
            this.EntryExitItemWarningQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemWarningQuantity.DataPropertyName = "Item Warning Quantity";
            this.EntryExitItemWarningQuantity.HeaderText = "تنبيه الكميه";
            this.EntryExitItemWarningQuantity.Name = "EntryExitItemWarningQuantity";
            this.EntryExitItemWarningQuantity.ReadOnly = true;
            // 
            // EntryExitItemProductionDate
            // 
            this.EntryExitItemProductionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemProductionDate.DataPropertyName = "Production Date";
            this.EntryExitItemProductionDate.HeaderText = "تاريخ الانتاج";
            this.EntryExitItemProductionDate.Name = "EntryExitItemProductionDate";
            this.EntryExitItemProductionDate.ReadOnly = true;
            // 
            // EntryExitItemEndDate
            // 
            this.EntryExitItemEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemEndDate.DataPropertyName = "End Date";
            this.EntryExitItemEndDate.HeaderText = "تاريخ انتهاء الصلاحيه";
            this.EntryExitItemEndDate.Name = "EntryExitItemEndDate";
            this.EntryExitItemEndDate.ReadOnly = true;
            // 
            // EntryExitItemEntryDate
            // 
            this.EntryExitItemEntryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntryExitItemEntryDate.DataPropertyName = "Entry Date";
            this.EntryExitItemEntryDate.HeaderText = "تاريخ الادخال";
            this.EntryExitItemEntryDate.Name = "EntryExitItemEntryDate";
            this.EntryExitItemEntryDate.ReadOnly = true;
            // 
            // WarehouseEntryExitList
            // 
            this.WarehouseEntryExitList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WarehouseEntryExitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WarehouseEntryExitList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarehouseEntryExitList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.WarehouseEntryExitList.FormattingEnabled = true;
            this.WarehouseEntryExitList.Location = new System.Drawing.Point(1174, 51);
            this.WarehouseEntryExitList.Name = "WarehouseEntryExitList";
            this.WarehouseEntryExitList.Size = new System.Drawing.Size(137, 21);
            this.WarehouseEntryExitList.TabIndex = 46;
            // 
            // label103
            // 
            this.label103.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label103.AutoSize = true;
            this.label103.Depth = 0;
            this.label103.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label103.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label103.Location = new System.Drawing.Point(1208, 25);
            this.label103.MouseState = MaterialSkin.MouseState.HOVER;
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(38, 19);
            this.label103.TabIndex = 47;
            this.label103.Text = "المستودع";
            // 
            // EntryExitType
            // 
            this.EntryExitType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EntryExitType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitType.FormattingEnabled = true;
            this.EntryExitType.Items.AddRange(new object[] {
            "ادخال Import",
            "اخراج Export"});
            this.EntryExitType.Location = new System.Drawing.Point(941, 51);
            this.EntryExitType.Name = "EntryExitType";
            this.EntryExitType.Size = new System.Drawing.Size(227, 21);
            this.EntryExitType.TabIndex = 11;
            // 
            // label53
            // 
            this.label53.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label53.AutoSize = true;
            this.label53.Depth = 0;
            this.label53.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label53.Location = new System.Drawing.Point(1723, 23);
            this.label53.MouseState = MaterialSkin.MouseState.HOVER;
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(45, 19);
            this.label53.TabIndex = 7;
            this.label53.Text = "إسم القطعه";
            // 
            // WarehouseEntryExitItemBarCode
            // 
            this.WarehouseEntryExitItemBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WarehouseEntryExitItemBarCode.AnimateReadOnly = false;
            this.WarehouseEntryExitItemBarCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.WarehouseEntryExitItemBarCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.WarehouseEntryExitItemBarCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WarehouseEntryExitItemBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.WarehouseEntryExitItemBarCode.Depth = 0;
            this.WarehouseEntryExitItemBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarehouseEntryExitItemBarCode.HideSelection = true;
            this.WarehouseEntryExitItemBarCode.LeadingIcon = null;
            this.WarehouseEntryExitItemBarCode.Location = new System.Drawing.Point(1434, 51);
            this.WarehouseEntryExitItemBarCode.MaxLength = 32767;
            this.WarehouseEntryExitItemBarCode.MouseState = MaterialSkin.MouseState.OUT;
            this.WarehouseEntryExitItemBarCode.Name = "WarehouseEntryExitItemBarCode";
            this.WarehouseEntryExitItemBarCode.PasswordChar = '\0';
            this.WarehouseEntryExitItemBarCode.PrefixSuffixText = null;
            this.WarehouseEntryExitItemBarCode.ReadOnly = false;
            this.WarehouseEntryExitItemBarCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WarehouseEntryExitItemBarCode.SelectedText = "";
            this.WarehouseEntryExitItemBarCode.SelectionLength = 0;
            this.WarehouseEntryExitItemBarCode.SelectionStart = 0;
            this.WarehouseEntryExitItemBarCode.ShortcutsEnabled = true;
            this.WarehouseEntryExitItemBarCode.Size = new System.Drawing.Size(215, 48);
            this.WarehouseEntryExitItemBarCode.TabIndex = 0;
            this.WarehouseEntryExitItemBarCode.TabStop = false;
            this.WarehouseEntryExitItemBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WarehouseEntryExitItemBarCode.TrailingIcon = null;
            this.WarehouseEntryExitItemBarCode.UseSystemPasswordChar = false;
            // 
            // WarehouseEntryExitItemName
            // 
            this.WarehouseEntryExitItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WarehouseEntryExitItemName.AnimateReadOnly = false;
            this.WarehouseEntryExitItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.WarehouseEntryExitItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.WarehouseEntryExitItemName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WarehouseEntryExitItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.WarehouseEntryExitItemName.Depth = 0;
            this.WarehouseEntryExitItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarehouseEntryExitItemName.HideSelection = true;
            this.WarehouseEntryExitItemName.LeadingIcon = null;
            this.WarehouseEntryExitItemName.Location = new System.Drawing.Point(1655, 50);
            this.WarehouseEntryExitItemName.MaxLength = 32767;
            this.WarehouseEntryExitItemName.MouseState = MaterialSkin.MouseState.OUT;
            this.WarehouseEntryExitItemName.Name = "WarehouseEntryExitItemName";
            this.WarehouseEntryExitItemName.PasswordChar = '\0';
            this.WarehouseEntryExitItemName.PrefixSuffixText = null;
            this.WarehouseEntryExitItemName.ReadOnly = false;
            this.WarehouseEntryExitItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WarehouseEntryExitItemName.SelectedText = "";
            this.WarehouseEntryExitItemName.SelectionLength = 0;
            this.WarehouseEntryExitItemName.SelectionStart = 0;
            this.WarehouseEntryExitItemName.ShortcutsEnabled = true;
            this.WarehouseEntryExitItemName.Size = new System.Drawing.Size(212, 48);
            this.WarehouseEntryExitItemName.TabIndex = 1;
            this.WarehouseEntryExitItemName.TabStop = false;
            this.WarehouseEntryExitItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WarehouseEntryExitItemName.TrailingIcon = null;
            this.WarehouseEntryExitItemName.UseSystemPasswordChar = false;
            // 
            // EntryExitProductionDate
            // 
            this.EntryExitProductionDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitProductionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EntryExitProductionDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitProductionDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitProductionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitProductionDate.Location = new System.Drawing.Point(525, 33);
            this.EntryExitProductionDate.Name = "EntryExitProductionDate";
            this.EntryExitProductionDate.Size = new System.Drawing.Size(199, 20);
            this.EntryExitProductionDate.TabIndex = 8;
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.AutoSize = true;
            this.label48.Depth = 0;
            this.label48.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label48.Location = new System.Drawing.Point(1489, 25);
            this.label48.MouseState = MaterialSkin.MouseState.HOVER;
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 19);
            this.label48.TabIndex = 16;
            this.label48.Text = "باركود القطعه";
            // 
            // label79
            // 
            this.label79.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label79.AutoSize = true;
            this.label79.Depth = 0;
            this.label79.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label79.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label79.Location = new System.Drawing.Point(587, 2);
            this.label79.MouseState = MaterialSkin.MouseState.HOVER;
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(52, 19);
            this.label79.TabIndex = 45;
            this.label79.Text = "تاريخ الإنتاج";
            // 
            // EntryExitWarningQuantity
            // 
            this.EntryExitWarningQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitWarningQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitWarningQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitWarningQuantity.Location = new System.Drawing.Point(730, 33);
            this.EntryExitWarningQuantity.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.EntryExitWarningQuantity.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.EntryExitWarningQuantity.Name = "EntryExitWarningQuantity";
            this.EntryExitWarningQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EntryExitWarningQuantity.Size = new System.Drawing.Size(194, 20);
            this.EntryExitWarningQuantity.TabIndex = 7;
            // 
            // EntryExitExpirationDate
            // 
            this.EntryExitExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitExpirationDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EntryExitExpirationDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitExpirationDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitExpirationDate.Location = new System.Drawing.Point(1230, 105);
            this.EntryExitExpirationDate.Name = "EntryExitExpirationDate";
            this.EntryExitExpirationDate.Size = new System.Drawing.Size(199, 20);
            this.EntryExitExpirationDate.TabIndex = 9;
            // 
            // EntryExitEntryDate
            // 
            this.EntryExitEntryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitEntryDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EntryExitEntryDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitEntryDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitEntryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitEntryDate.Location = new System.Drawing.Point(1025, 105);
            this.EntryExitEntryDate.Name = "EntryExitEntryDate";
            this.EntryExitEntryDate.Size = new System.Drawing.Size(199, 20);
            this.EntryExitEntryDate.TabIndex = 10;
            // 
            // label94
            // 
            this.label94.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label94.AutoSize = true;
            this.label94.Depth = 0;
            this.label94.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label94.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label94.Location = new System.Drawing.Point(791, 3);
            this.label94.MouseState = MaterialSkin.MouseState.HOVER;
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(45, 19);
            this.label94.TabIndex = 43;
            this.label94.Text = "تنبيه الكميه";
            // 
            // label96
            // 
            this.label96.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label96.AutoSize = true;
            this.label96.Depth = 0;
            this.label96.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label96.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label96.Location = new System.Drawing.Point(1270, 85);
            this.label96.MouseState = MaterialSkin.MouseState.HOVER;
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(89, 19);
            this.label96.TabIndex = 41;
            this.label96.Text = "تاريخ إنتهاء الصلاحيه";
            // 
            // label97
            // 
            this.label97.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label97.AutoSize = true;
            this.label97.Depth = 0;
            this.label97.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label97.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label97.Location = new System.Drawing.Point(1329, 25);
            this.label97.MouseState = MaterialSkin.MouseState.HOVER;
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(46, 19);
            this.label97.TabIndex = 11;
            this.label97.Text = "عدد القطعه";
            // 
            // EntryExitItemQuantity
            // 
            this.EntryExitItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryExitItemQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryExitItemQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.EntryExitItemQuantity.Location = new System.Drawing.Point(1317, 52);
            this.EntryExitItemQuantity.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.EntryExitItemQuantity.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.EntryExitItemQuantity.Name = "EntryExitItemQuantity";
            this.EntryExitItemQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EntryExitItemQuantity.Size = new System.Drawing.Size(110, 20);
            this.EntryExitItemQuantity.TabIndex = 2;
            // 
            // label98
            // 
            this.label98.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label98.AutoSize = true;
            this.label98.Depth = 0;
            this.label98.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label98.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label98.Location = new System.Drawing.Point(1092, 85);
            this.label98.MouseState = MaterialSkin.MouseState.HOVER;
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(56, 19);
            this.label98.TabIndex = 39;
            this.label98.Text = "تاريخ الإدخال";
            // 
            // label101
            // 
            this.label101.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label101.AutoSize = true;
            this.label101.Depth = 0;
            this.label101.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label101.Location = new System.Drawing.Point(1011, 25);
            this.label101.MouseState = MaterialSkin.MouseState.HOVER;
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(39, 19);
            this.label101.TabIndex = 37;
            this.label101.Text = "نوع السند";
            // 
            // AddTypes
            // 
            this.AddTypes.BackColor = System.Drawing.Color.White;
            this.AddTypes.Controls.Add(this.flowLayoutPanel3);
            this.AddTypes.Location = new System.Drawing.Point(4, 34);
            this.AddTypes.Name = "AddTypes";
            this.AddTypes.Padding = new System.Windows.Forms.Padding(3);
            this.AddTypes.Size = new System.Drawing.Size(1873, 913);
            this.AddTypes.TabIndex = 1;
            this.AddTypes.Text = "إضافة صنف";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel3.Controls.Add(this.label29);
            this.flowLayoutPanel3.Controls.Add(this.ItemTypeEntry);
            this.flowLayoutPanel3.Controls.Add(this.label30);
            this.flowLayoutPanel3.Controls.Add(this.ItemTypeAddButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.MinimumSize = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1867, 907);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Depth = 0;
            this.label29.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label29.Location = new System.Drawing.Point(1767, 0);
            this.label29.MouseState = MaterialSkin.MouseState.HOVER;
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(97, 19);
            this.label29.TabIndex = 10;
            this.label29.Text = "إضافة تصنيف مواد جديد";
            // 
            // ItemTypeEntry
            // 
            this.ItemTypeEntry.AnimateReadOnly = false;
            this.ItemTypeEntry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ItemTypeEntry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ItemTypeEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ItemTypeEntry.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ItemTypeEntry.Depth = 0;
            this.ItemTypeEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTypeEntry.HideSelection = true;
            this.ItemTypeEntry.LeadingIcon = null;
            this.ItemTypeEntry.Location = new System.Drawing.Point(1513, 22);
            this.ItemTypeEntry.MaxLength = 32767;
            this.ItemTypeEntry.MouseState = MaterialSkin.MouseState.OUT;
            this.ItemTypeEntry.Name = "ItemTypeEntry";
            this.ItemTypeEntry.PasswordChar = '\0';
            this.ItemTypeEntry.PrefixSuffixText = null;
            this.ItemTypeEntry.ReadOnly = false;
            this.ItemTypeEntry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ItemTypeEntry.SelectedText = "";
            this.ItemTypeEntry.SelectionLength = 0;
            this.ItemTypeEntry.SelectionStart = 0;
            this.ItemTypeEntry.ShortcutsEnabled = true;
            this.ItemTypeEntry.Size = new System.Drawing.Size(351, 48);
            this.ItemTypeEntry.TabIndex = 0;
            this.ItemTypeEntry.TabStop = false;
            this.ItemTypeEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ItemTypeEntry.TrailingIcon = null;
            this.ItemTypeEntry.UseSystemPasswordChar = false;
            this.ItemTypeEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemTypeInsertKeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Depth = 0;
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label30.Location = new System.Drawing.Point(1513, 73);
            this.label30.MouseState = MaterialSkin.MouseState.HOVER;
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(351, 19);
            this.label30.TabIndex = 11;
            this.label30.Text = "أصناف المواد المضافه";
            // 
            // ItemTypeAddButton
            // 
            this.ItemTypeAddButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ItemTypeAddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ItemTypeAddButton.Image = global::PlancksoftPOS.Properties.Resources.plus;
            this.ItemTypeAddButton.Location = new System.Drawing.Point(1796, 95);
            this.ItemTypeAddButton.Name = "ItemTypeAddButton";
            this.ItemTypeAddButton.Size = new System.Drawing.Size(68, 49);
            this.ItemTypeAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ItemTypeAddButton.TabIndex = 0;
            this.ItemTypeAddButton.TabStop = false;
            this.ItemTypeAddButton.Click += new System.EventHandler(this.ItemTypeAddButton_Click);
            // 
            // AddFavorites
            // 
            this.AddFavorites.BackColor = System.Drawing.Color.White;
            this.AddFavorites.Controls.Add(this.flowLayoutPanel1);
            this.AddFavorites.Location = new System.Drawing.Point(4, 34);
            this.AddFavorites.Name = "AddFavorites";
            this.AddFavorites.Size = new System.Drawing.Size(1873, 913);
            this.AddFavorites.TabIndex = 2;
            this.AddFavorites.Text = "إضافة مجلد مفضلات";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Controls.Add(this.label22);
            this.flowLayoutPanel1.Controls.Add(this.FavoriteCategoryEntry);
            this.flowLayoutPanel1.Controls.Add(this.label23);
            this.flowLayoutPanel1.Controls.Add(this.FavoriteCategoryAddButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1873, 913);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Depth = 0;
            this.label22.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label22.Location = new System.Drawing.Point(1774, 0);
            this.label22.MouseState = MaterialSkin.MouseState.HOVER;
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 19);
            this.label22.TabIndex = 10;
            this.label22.Text = "اضافة مجلد مفضل جديد";
            // 
            // FavoriteCategoryEntry
            // 
            this.FavoriteCategoryEntry.AnimateReadOnly = false;
            this.FavoriteCategoryEntry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.FavoriteCategoryEntry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.FavoriteCategoryEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FavoriteCategoryEntry.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.FavoriteCategoryEntry.Depth = 0;
            this.FavoriteCategoryEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FavoriteCategoryEntry.HideSelection = true;
            this.FavoriteCategoryEntry.LeadingIcon = null;
            this.FavoriteCategoryEntry.Location = new System.Drawing.Point(1519, 22);
            this.FavoriteCategoryEntry.MaxLength = 32767;
            this.FavoriteCategoryEntry.MouseState = MaterialSkin.MouseState.OUT;
            this.FavoriteCategoryEntry.Name = "FavoriteCategoryEntry";
            this.FavoriteCategoryEntry.PasswordChar = '\0';
            this.FavoriteCategoryEntry.PrefixSuffixText = null;
            this.FavoriteCategoryEntry.ReadOnly = false;
            this.FavoriteCategoryEntry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FavoriteCategoryEntry.SelectedText = "";
            this.FavoriteCategoryEntry.SelectionLength = 0;
            this.FavoriteCategoryEntry.SelectionStart = 0;
            this.FavoriteCategoryEntry.ShortcutsEnabled = true;
            this.FavoriteCategoryEntry.Size = new System.Drawing.Size(351, 48);
            this.FavoriteCategoryEntry.TabIndex = 0;
            this.FavoriteCategoryEntry.TabStop = false;
            this.FavoriteCategoryEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.FavoriteCategoryEntry.TrailingIcon = null;
            this.FavoriteCategoryEntry.UseSystemPasswordChar = false;
            this.FavoriteCategoryEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FavoriteCategoryKeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Depth = 0;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label23.Location = new System.Drawing.Point(1519, 73);
            this.label23.MouseState = MaterialSkin.MouseState.HOVER;
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(351, 19);
            this.label23.TabIndex = 11;
            this.label23.Text = "المفضلات المضافه";
            // 
            // FavoriteCategoryAddButton
            // 
            this.FavoriteCategoryAddButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FavoriteCategoryAddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FavoriteCategoryAddButton.Image = global::PlancksoftPOS.Properties.Resources.plus;
            this.FavoriteCategoryAddButton.Location = new System.Drawing.Point(1802, 95);
            this.FavoriteCategoryAddButton.Name = "FavoriteCategoryAddButton";
            this.FavoriteCategoryAddButton.Size = new System.Drawing.Size(68, 49);
            this.FavoriteCategoryAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FavoriteCategoryAddButton.TabIndex = 0;
            this.FavoriteCategoryAddButton.TabStop = false;
            this.FavoriteCategoryAddButton.Click += new System.EventHandler(this.FavoriteCategoryAddButton_Click);
            // 
            // AddWarehouses
            // 
            this.AddWarehouses.BackColor = System.Drawing.Color.White;
            this.AddWarehouses.Controls.Add(this.flowLayoutPanel2);
            this.AddWarehouses.Location = new System.Drawing.Point(4, 34);
            this.AddWarehouses.Name = "AddWarehouses";
            this.AddWarehouses.Size = new System.Drawing.Size(1873, 913);
            this.AddWarehouses.TabIndex = 3;
            this.AddWarehouses.Text = "إضافة مستودع";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel2.Controls.Add(this.label26);
            this.flowLayoutPanel2.Controls.Add(this.WarehouseEntry);
            this.flowLayoutPanel2.Controls.Add(this.label27);
            this.flowLayoutPanel2.Controls.Add(this.WarehouseAddButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1873, 913);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Depth = 0;
            this.label26.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label26.Location = new System.Drawing.Point(1790, 0);
            this.label26.MouseState = MaterialSkin.MouseState.HOVER;
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 19);
            this.label26.TabIndex = 10;
            this.label26.Text = "إضافة مستودع جديد";
            // 
            // WarehouseEntry
            // 
            this.WarehouseEntry.AnimateReadOnly = false;
            this.WarehouseEntry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.WarehouseEntry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.WarehouseEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WarehouseEntry.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.WarehouseEntry.Depth = 0;
            this.WarehouseEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarehouseEntry.HideSelection = true;
            this.WarehouseEntry.LeadingIcon = null;
            this.WarehouseEntry.Location = new System.Drawing.Point(1519, 22);
            this.WarehouseEntry.MaxLength = 32767;
            this.WarehouseEntry.MouseState = MaterialSkin.MouseState.OUT;
            this.WarehouseEntry.Name = "WarehouseEntry";
            this.WarehouseEntry.PasswordChar = '\0';
            this.WarehouseEntry.PrefixSuffixText = null;
            this.WarehouseEntry.ReadOnly = false;
            this.WarehouseEntry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WarehouseEntry.SelectedText = "";
            this.WarehouseEntry.SelectionLength = 0;
            this.WarehouseEntry.SelectionStart = 0;
            this.WarehouseEntry.ShortcutsEnabled = true;
            this.WarehouseEntry.Size = new System.Drawing.Size(351, 48);
            this.WarehouseEntry.TabIndex = 0;
            this.WarehouseEntry.TabStop = false;
            this.WarehouseEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WarehouseEntry.TrailingIcon = null;
            this.WarehouseEntry.UseSystemPasswordChar = false;
            this.WarehouseEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WarehouseInsertKeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Depth = 0;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label27.Location = new System.Drawing.Point(1519, 73);
            this.label27.MouseState = MaterialSkin.MouseState.HOVER;
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(351, 19);
            this.label27.TabIndex = 11;
            this.label27.Text = "المستودعات المضافه";
            // 
            // WarehouseAddButton
            // 
            this.WarehouseAddButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WarehouseAddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WarehouseAddButton.Image = global::PlancksoftPOS.Properties.Resources.plus;
            this.WarehouseAddButton.Location = new System.Drawing.Point(1802, 95);
            this.WarehouseAddButton.Name = "WarehouseAddButton";
            this.WarehouseAddButton.Size = new System.Drawing.Size(68, 49);
            this.WarehouseAddButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WarehouseAddButton.TabIndex = 0;
            this.WarehouseAddButton.TabStop = false;
            this.WarehouseAddButton.Click += new System.EventHandler(this.WarehouseAddButton_Click);
            // 
            // Expenses
            // 
            this.Expenses.BackColor = System.Drawing.Color.White;
            this.Expenses.Controls.Add(this.tabControl5);
            this.Expenses.Location = new System.Drawing.Point(4, 34);
            this.Expenses.Name = "Expenses";
            this.Expenses.Size = new System.Drawing.Size(1881, 951);
            this.Expenses.TabIndex = 3;
            this.Expenses.Text = "المصروفات";
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.SearchExpenses);
            this.tabControl5.Controls.Add(this.AddExpenses);
            this.tabControl5.Depth = 0;
            this.tabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl5.ItemSize = new System.Drawing.Size(131, 30);
            this.tabControl5.Location = new System.Drawing.Point(0, 0);
            this.tabControl5.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl5.Multiline = true;
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.RightToLeftLayout = true;
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(1881, 951);
            this.tabControl5.TabIndex = 0;
            // 
            // SearchExpenses
            // 
            this.SearchExpenses.BackColor = System.Drawing.Color.White;
            this.SearchExpenses.Controls.Add(this.groupBox31);
            this.SearchExpenses.Location = new System.Drawing.Point(4, 34);
            this.SearchExpenses.Name = "SearchExpenses";
            this.SearchExpenses.Padding = new System.Windows.Forms.Padding(3);
            this.SearchExpenses.Size = new System.Drawing.Size(1873, 913);
            this.SearchExpenses.TabIndex = 0;
            this.SearchExpenses.Text = "البحث عن المصروفات";
            // 
            // groupBox31
            // 
            this.groupBox31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox31.Controls.Add(this.pictureBox34);
            this.groupBox31.Controls.Add(this.dgvExpenses);
            this.groupBox31.Controls.Add(this.groupBox22);
            this.groupBox31.Controls.Add(this.textBox2);
            this.groupBox31.Controls.Add(this.label17);
            this.groupBox31.Controls.Add(this.textBox1);
            this.groupBox31.Controls.Add(this.label16);
            this.groupBox31.Controls.Add(this.dateTimePicker7);
            this.groupBox31.Controls.Add(this.label14);
            this.groupBox31.Controls.Add(this.dateTimePicker8);
            this.groupBox31.Controls.Add(this.label15);
            this.groupBox31.Controls.Add(this.pictureBox33);
            this.groupBox31.Depth = 0;
            this.groupBox31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox31.Location = new System.Drawing.Point(3, 3);
            this.groupBox31.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox31.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox31.Size = new System.Drawing.Size(1867, 907);
            this.groupBox31.TabIndex = 0;
            // 
            // pictureBox34
            // 
            this.pictureBox34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox34.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox34.Location = new System.Drawing.Point(1761, 85);
            this.pictureBox34.Name = "pictureBox34";
            this.pictureBox34.Size = new System.Drawing.Size(102, 116);
            this.pictureBox34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox34.TabIndex = 32;
            this.pictureBox34.TabStop = false;
            this.pictureBox34.Click += new System.EventHandler(this.pictureBox34_Click);
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            this.dgvExpenses.AllowUserToOrderColumns = true;
            this.dgvExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column29,
            this.Column30,
            this.Column31,
            this.Column37,
            this.Column32});
            this.dgvExpenses.Location = new System.Drawing.Point(6, 85);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvExpenses.Size = new System.Drawing.Size(1749, 816);
            this.dgvExpenses.TabIndex = 34;
            // 
            // Column29
            // 
            this.Column29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column29.DataPropertyName = "Expense ID";
            this.Column29.HeaderText = "رقم المصروف";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            // 
            // Column30
            // 
            this.Column30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column30.DataPropertyName = "Expense Name";
            this.Column30.HeaderText = "اسم المصروف";
            this.Column30.Name = "Column30";
            this.Column30.ReadOnly = true;
            // 
            // Column31
            // 
            this.Column31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column31.DataPropertyName = "Expense Cost";
            this.Column31.HeaderText = "تكلفة المصروف";
            this.Column31.Name = "Column31";
            this.Column31.ReadOnly = true;
            // 
            // Column37
            // 
            this.Column37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column37.DataPropertyName = "Employee ID";
            this.Column37.HeaderText = "رمز المستخدم";
            this.Column37.Name = "Column37";
            this.Column37.ReadOnly = true;
            // 
            // Column32
            // 
            this.Column32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column32.DataPropertyName = "Expense Date";
            this.Column32.HeaderText = "تاريخ المصروف";
            this.Column32.Name = "Column32";
            this.Column32.ReadOnly = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox22.Controls.Add(this.CapitalAmountnud);
            this.groupBox22.Depth = 0;
            this.groupBox22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox22.Location = new System.Drawing.Point(697, 3);
            this.groupBox22.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox22.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox22.Size = new System.Drawing.Size(192, 84);
            this.groupBox22.TabIndex = 35;
            this.groupBox22.Text = "رأس المال";
            // 
            // CapitalAmountnud
            // 
            this.CapitalAmountnud.DecimalPlaces = 2;
            this.CapitalAmountnud.Enabled = false;
            this.CapitalAmountnud.Location = new System.Drawing.Point(6, 35);
            this.CapitalAmountnud.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.CapitalAmountnud.Minimum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            -2147483648});
            this.CapitalAmountnud.Name = "CapitalAmountnud";
            this.CapitalAmountnud.ReadOnly = true;
            this.CapitalAmountnud.Size = new System.Drawing.Size(180, 22);
            this.CapitalAmountnud.TabIndex = 0;
            this.CapitalAmountnud.Enter += new System.EventHandler(this.CapitalAmountnud_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.AnimateReadOnly = false;
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.Depth = 0;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.HideSelection = true;
            this.textBox2.LeadingIcon = null;
            this.textBox2.Location = new System.Drawing.Point(1318, 61);
            this.textBox2.MaxLength = 32767;
            this.textBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.PrefixSuffixText = null;
            this.textBox2.ReadOnly = false;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(221, 48);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox2.TrailingIcon = null;
            this.textBox2.UseSystemPasswordChar = false;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Depth = 0;
            this.label17.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label17.Location = new System.Drawing.Point(1380, 36);
            this.label17.MouseState = MaterialSkin.MouseState.HOVER;
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 19);
            this.label17.TabIndex = 34;
            this.label17.Text = "إسم الموظف";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AnimateReadOnly = false;
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.HideSelection = true;
            this.textBox1.LeadingIcon = null;
            this.textBox1.Location = new System.Drawing.Point(1545, 61);
            this.textBox1.MaxLength = 32767;
            this.textBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PrefixSuffixText = null;
            this.textBox1.ReadOnly = false;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(221, 48);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TrailingIcon = null;
            this.textBox1.UseSystemPasswordChar = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Depth = 0;
            this.label16.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label16.Location = new System.Drawing.Point(1600, 36);
            this.label16.MouseState = MaterialSkin.MouseState.HOVER;
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 19);
            this.label16.TabIndex = 32;
            this.label16.Text = "إسم المصروف";
            // 
            // dateTimePicker7
            // 
            this.dateTimePicker7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker7.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker7.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker7.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker7.CustomFormat = "";
            this.dateTimePicker7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker7.Location = new System.Drawing.Point(895, 60);
            this.dateTimePicker7.Name = "dateTimePicker7";
            this.dateTimePicker7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker7.RightToLeftLayout = true;
            this.dateTimePicker7.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker7.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Depth = 0;
            this.label14.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label14.Location = new System.Drawing.Point(954, 36);
            this.label14.MouseState = MaterialSkin.MouseState.HOVER;
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 19);
            this.label14.TabIndex = 30;
            this.label14.Text = "تاريخ البحث إلى";
            this.label14.Visible = false;
            // 
            // dateTimePicker8
            // 
            this.dateTimePicker8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker8.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker8.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker8.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.dateTimePicker8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker8.Location = new System.Drawing.Point(1101, 61);
            this.dateTimePicker8.Name = "dateTimePicker8";
            this.dateTimePicker8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker8.RightToLeftLayout = true;
            this.dateTimePicker8.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker8.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Depth = 0;
            this.label15.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label15.Location = new System.Drawing.Point(1153, 36);
            this.label15.MouseState = MaterialSkin.MouseState.HOVER;
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 19);
            this.label15.TabIndex = 29;
            this.label15.Text = "تاريخ البحث من";
            this.label15.Visible = false;
            // 
            // pictureBox33
            // 
            this.pictureBox33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox33.Image = global::PlancksoftPOS.Properties.Resources.search;
            this.pictureBox33.Location = new System.Drawing.Point(1772, 41);
            this.pictureBox33.Name = "pictureBox33";
            this.pictureBox33.Size = new System.Drawing.Size(47, 39);
            this.pictureBox33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox33.TabIndex = 31;
            this.pictureBox33.TabStop = false;
            this.pictureBox33.Click += new System.EventHandler(this.pictureBox33_Click);
            // 
            // AddExpenses
            // 
            this.AddExpenses.BackColor = System.Drawing.Color.White;
            this.AddExpenses.Controls.Add(this.groupBox33);
            this.AddExpenses.Location = new System.Drawing.Point(4, 34);
            this.AddExpenses.Name = "AddExpenses";
            this.AddExpenses.Padding = new System.Windows.Forms.Padding(3);
            this.AddExpenses.Size = new System.Drawing.Size(1873, 913);
            this.AddExpenses.TabIndex = 1;
            this.AddExpenses.Text = "إضافة مصروف";
            // 
            // groupBox33
            // 
            this.groupBox33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox33.Controls.Add(this.button3);
            this.groupBox33.Controls.Add(this.button2);
            this.groupBox33.Controls.Add(this.numericUpDown1);
            this.groupBox33.Controls.Add(this.label20);
            this.groupBox33.Controls.Add(this.textBox4);
            this.groupBox33.Controls.Add(this.label19);
            this.groupBox33.Depth = 0;
            this.groupBox33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox33.Location = new System.Drawing.Point(3, 3);
            this.groupBox33.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox33.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox33.Size = new System.Drawing.Size(1867, 907);
            this.groupBox33.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button3.Depth = 0;
            this.button3.HighEmphasis = true;
            this.button3.Icon = null;
            this.button3.Location = new System.Drawing.Point(1675, 165);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button3.MouseState = MaterialSkin.MouseState.HOVER;
            this.button3.Name = "button3";
            this.button3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button3.Size = new System.Drawing.Size(64, 36);
            this.button3.TabIndex = 79;
            this.button3.Text = "مسح";
            this.button3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button3.UseAccentColor = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button2.Depth = 0;
            this.button2.HighEmphasis = true;
            this.button2.Icon = null;
            this.button2.Location = new System.Drawing.Point(1741, 165);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button2.MouseState = MaterialSkin.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button2.Size = new System.Drawing.Size(111, 36);
            this.button2.TabIndex = 78;
            this.button2.Text = "إضافة المصروف";
            this.button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button2.UseAccentColor = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.numericUpDown1.Location = new System.Drawing.Point(1628, 105);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(221, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Enter += new System.EventHandler(this.numericUpDown1_Enter);
            this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Depth = 0;
            this.label20.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label20.Location = new System.Drawing.Point(1696, 78);
            this.label20.MouseState = MaterialSkin.MouseState.HOVER;
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 19);
            this.label20.TabIndex = 44;
            this.label20.Text = "كمية المصروف";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.AnimateReadOnly = false;
            this.textBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.Depth = 0;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.HideSelection = true;
            this.textBox4.LeadingIcon = null;
            this.textBox4.Location = new System.Drawing.Point(1628, 39);
            this.textBox4.MaxLength = 32767;
            this.textBox4.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.PrefixSuffixText = null;
            this.textBox4.ReadOnly = false;
            this.textBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox4.SelectedText = "";
            this.textBox4.SelectionLength = 0;
            this.textBox4.SelectionStart = 0;
            this.textBox4.ShortcutsEnabled = true;
            this.textBox4.Size = new System.Drawing.Size(221, 48);
            this.textBox4.TabIndex = 0;
            this.textBox4.TabStop = false;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox4.TrailingIcon = null;
            this.textBox4.UseSystemPasswordChar = false;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Depth = 0;
            this.label19.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label19.Location = new System.Drawing.Point(1696, 12);
            this.label19.MouseState = MaterialSkin.MouseState.HOVER;
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 19);
            this.label19.TabIndex = 40;
            this.label19.Text = "اسم المصروف";
            // 
            // IncomingOutgoing
            // 
            this.IncomingOutgoing.BackColor = System.Drawing.Color.White;
            this.IncomingOutgoing.Controls.Add(this.groupBox21);
            this.IncomingOutgoing.Controls.Add(this.groupBox20);
            this.IncomingOutgoing.Controls.Add(this.groupBox19);
            this.IncomingOutgoing.Location = new System.Drawing.Point(4, 34);
            this.IncomingOutgoing.Name = "IncomingOutgoing";
            this.IncomingOutgoing.Size = new System.Drawing.Size(1881, 951);
            this.IncomingOutgoing.TabIndex = 7;
            this.IncomingOutgoing.Text = "الصادر و الوارد و رأس المال";
            // 
            // groupBox21
            // 
            this.groupBox21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox21.Controls.Add(this.label116);
            this.groupBox21.Controls.Add(this.label115);
            this.groupBox21.Controls.Add(this.label91);
            this.groupBox21.Controls.Add(this.label80);
            this.groupBox21.Controls.Add(this.dvgCapital);
            this.groupBox21.Controls.Add(this.pictureBox27);
            this.groupBox21.Controls.Add(this.pictureBox24);
            this.groupBox21.Depth = 0;
            this.groupBox21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox21.Location = new System.Drawing.Point(-4, 521);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox21.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox21.Size = new System.Drawing.Size(1660, 432);
            this.groupBox21.TabIndex = 2;
            this.groupBox21.Text = "الأرباح";
            // 
            // label116
            // 
            this.label116.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label116.AutoSize = true;
            this.label116.Depth = 0;
            this.label116.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label116.Location = new System.Drawing.Point(1583, 279);
            this.label116.MouseState = MaterialSkin.MouseState.HOVER;
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(43, 19);
            this.label116.TabIndex = 32;
            this.label116.Text = "رأس المال";
            // 
            // label115
            // 
            this.label115.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label115.AutoSize = true;
            this.label115.Depth = 0;
            this.label115.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label115.Location = new System.Drawing.Point(1577, 237);
            this.label115.MouseState = MaterialSkin.MouseState.HOVER;
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(49, 19);
            this.label115.TabIndex = 31;
            this.label115.Text = "صافي الربح";
            // 
            // label91
            // 
            this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label91.AutoSize = true;
            this.label91.Depth = 0;
            this.label91.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label91.Location = new System.Drawing.Point(1532, 301);
            this.label91.MouseState = MaterialSkin.MouseState.HOVER;
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(1, 0);
            this.label91.TabIndex = 30;
            // 
            // label80
            // 
            this.label80.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label80.AutoSize = true;
            this.label80.Depth = 0;
            this.label80.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label80.Location = new System.Drawing.Point(1532, 260);
            this.label80.MouseState = MaterialSkin.MouseState.HOVER;
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(1, 0);
            this.label80.TabIndex = 28;
            // 
            // dvgCapital
            // 
            this.dvgCapital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgCapital.BackgroundColor = System.Drawing.Color.White;
            this.dvgCapital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCapital.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column22,
            this.Column26});
            this.dvgCapital.Location = new System.Drawing.Point(0, 6);
            this.dvgCapital.Name = "dvgCapital";
            this.dvgCapital.ReadOnly = true;
            this.dvgCapital.Size = new System.Drawing.Size(1526, 423);
            this.dvgCapital.TabIndex = 0;
            // 
            // Column22
            // 
            this.Column22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column22.DataPropertyName = "Date";
            this.Column22.HeaderText = "التاريخ";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            // 
            // Column26
            // 
            this.Column26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column26.DataPropertyName = "Total Revenue";
            this.Column26.HeaderText = "الربح الصافي";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            // 
            // pictureBox27
            // 
            this.pictureBox27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox27.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox27.Location = new System.Drawing.Point(1532, 140);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(104, 94);
            this.pictureBox27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox27.TabIndex = 29;
            this.pictureBox27.TabStop = false;
            this.pictureBox27.Click += new System.EventHandler(this.pictureBox27_Click);
            // 
            // pictureBox24
            // 
            this.pictureBox24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox24.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox24.Location = new System.Drawing.Point(1532, 21);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(104, 91);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox24.TabIndex = 26;
            this.pictureBox24.TabStop = false;
            this.pictureBox24.Click += new System.EventHandler(this.pictureBox24_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox20.Controls.Add(this.pictureBox9);
            this.groupBox20.Controls.Add(this.pictureBox23);
            this.groupBox20.Controls.Add(this.dgvImports);
            this.groupBox20.Depth = 0;
            this.groupBox20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox20.Location = new System.Drawing.Point(-4, 0);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox20.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox20.Size = new System.Drawing.Size(892, 522);
            this.groupBox20.TabIndex = 0;
            this.groupBox20.Text = "الوارد";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox9.Location = new System.Drawing.Point(827, 64);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(59, 49);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 28;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pictureBox23
            // 
            this.pictureBox23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox23.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox23.Location = new System.Drawing.Point(827, 19);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(53, 39);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox23.TabIndex = 27;
            this.pictureBox23.TabStop = false;
            this.pictureBox23.Click += new System.EventHandler(this.pictureBox23_Click);
            // 
            // dgvImports
            // 
            this.dgvImports.BackgroundColor = System.Drawing.Color.White;
            this.dgvImports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column35,
            this.Column36});
            this.dgvImports.Location = new System.Drawing.Point(-11, 10);
            this.dgvImports.Name = "dgvImports";
            this.dgvImports.ReadOnly = true;
            this.dgvImports.Size = new System.Drawing.Size(825, 504);
            this.dgvImports.TabIndex = 1;
            // 
            // Column35
            // 
            this.Column35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column35.DataPropertyName = "Date";
            this.Column35.HeaderText = "التاريخ";
            this.Column35.Name = "Column35";
            this.Column35.ReadOnly = true;
            // 
            // Column36
            // 
            this.Column36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column36.DataPropertyName = "Total Cost";
            this.Column36.HeaderText = "التكلفه الكامله";
            this.Column36.Name = "Column36";
            this.Column36.ReadOnly = true;
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox19.Controls.Add(this.pictureBox8);
            this.groupBox19.Controls.Add(this.pictureBox22);
            this.groupBox19.Controls.Add(this.dgvExports);
            this.groupBox19.Depth = 0;
            this.groupBox19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox19.Location = new System.Drawing.Point(885, -1);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox19.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox19.Size = new System.Drawing.Size(775, 523);
            this.groupBox19.TabIndex = 1;
            this.groupBox19.Text = "الصادر";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox8.Location = new System.Drawing.Point(687, 64);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(85, 49);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 27;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox22
            // 
            this.pictureBox22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox22.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox22.Location = new System.Drawing.Point(687, 19);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(85, 39);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox22.TabIndex = 26;
            this.pictureBox22.TabStop = false;
            this.pictureBox22.Click += new System.EventHandler(this.pictureBox22_Click);
            // 
            // dgvExports
            // 
            this.dgvExports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExports.BackgroundColor = System.Drawing.Color.White;
            this.dgvExports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column33,
            this.Column34});
            this.dgvExports.Location = new System.Drawing.Point(6, 10);
            this.dgvExports.Name = "dgvExports";
            this.dgvExports.ReadOnly = true;
            this.dgvExports.Size = new System.Drawing.Size(675, 507);
            this.dgvExports.TabIndex = 0;
            // 
            // Column33
            // 
            this.Column33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column33.DataPropertyName = "Date";
            this.Column33.HeaderText = "التاريخ";
            this.Column33.Name = "Column33";
            this.Column33.ReadOnly = true;
            // 
            // Column34
            // 
            this.Column34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column34.DataPropertyName = "Total Cost";
            this.Column34.HeaderText = "التكلفه الكامله";
            this.Column34.Name = "Column34";
            this.Column34.ReadOnly = true;
            // 
            // Employees
            // 
            this.Employees.BackColor = System.Drawing.Color.White;
            this.Employees.Controls.Add(this.tabControl8);
            this.Employees.Location = new System.Drawing.Point(4, 34);
            this.Employees.Name = "Employees";
            this.Employees.Size = new System.Drawing.Size(1881, 951);
            this.Employees.TabIndex = 10;
            this.Employees.Text = "شؤون الموظفين";
            // 
            // tabControl8
            // 
            this.tabControl8.Controls.Add(this.EmployeesManagement);
            this.tabControl8.Controls.Add(this.DaysOff);
            this.tabControl8.Depth = 0;
            this.tabControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl8.ItemSize = new System.Drawing.Size(93, 30);
            this.tabControl8.Location = new System.Drawing.Point(0, 0);
            this.tabControl8.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl8.Multiline = true;
            this.tabControl8.Name = "tabControl8";
            this.tabControl8.RightToLeftLayout = true;
            this.tabControl8.SelectedIndex = 0;
            this.tabControl8.Size = new System.Drawing.Size(1881, 951);
            this.tabControl8.TabIndex = 1;
            // 
            // EmployeesManagement
            // 
            this.EmployeesManagement.BackColor = System.Drawing.Color.White;
            this.EmployeesManagement.Controls.Add(this.groupBox49);
            this.EmployeesManagement.Controls.Add(this.groupBox52);
            this.EmployeesManagement.Location = new System.Drawing.Point(4, 34);
            this.EmployeesManagement.Name = "EmployeesManagement";
            this.EmployeesManagement.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeesManagement.Size = new System.Drawing.Size(1873, 913);
            this.EmployeesManagement.TabIndex = 0;
            this.EmployeesManagement.Text = "إدارة الموظفين";
            // 
            // groupBox49
            // 
            this.groupBox49.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox49.Controls.Add(this.label2);
            this.groupBox49.Controls.Add(this.label1);
            this.groupBox49.Controls.Add(this.DateEmployeeTo);
            this.groupBox49.Controls.Add(this.DateEmployeeFrom);
            this.groupBox49.Controls.Add(this.groupBox50);
            this.groupBox49.Controls.Add(this.dgvEmployees);
            this.groupBox49.Controls.Add(this.pictureBox2);
            this.groupBox49.Depth = 0;
            this.groupBox49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox49.Location = new System.Drawing.Point(0, 0);
            this.groupBox49.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox49.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox49.Size = new System.Drawing.Size(910, 908);
            this.groupBox49.TabIndex = 1;
            this.groupBox49.Text = "جدول الموظفين";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(791, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "From";
            // 
            // DateEmployeeTo
            // 
            this.DateEmployeeTo.Location = new System.Drawing.Point(208, 21);
            this.DateEmployeeTo.Name = "DateEmployeeTo";
            this.DateEmployeeTo.Size = new System.Drawing.Size(263, 22);
            this.DateEmployeeTo.TabIndex = 39;
            // 
            // DateEmployeeFrom
            // 
            this.DateEmployeeFrom.Location = new System.Drawing.Point(514, 21);
            this.DateEmployeeFrom.Name = "DateEmployeeFrom";
            this.DateEmployeeFrom.Size = new System.Drawing.Size(262, 22);
            this.DateEmployeeFrom.TabIndex = 38;
            // 
            // groupBox50
            // 
            this.groupBox50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox50.Controls.Add(this.button35);
            this.groupBox50.Controls.Add(this.button37);
            this.groupBox50.Controls.Add(this.button16);
            this.groupBox50.Controls.Add(this.button32);
            this.groupBox50.Controls.Add(this.SalaryDeduction);
            this.groupBox50.Controls.Add(this.label111);
            this.groupBox50.Controls.Add(this.AbsenceHours);
            this.groupBox50.Controls.Add(this.AbsenceDate);
            this.groupBox50.Controls.Add(this.label107);
            this.groupBox50.Controls.Add(this.label106);
            this.groupBox50.Controls.Add(this.label109);
            this.groupBox50.Controls.Add(this.AbsenceEmpName);
            this.groupBox50.Controls.Add(this.label99);
            this.groupBox50.Controls.Add(this.EditEmployeeAddress);
            this.groupBox50.Controls.Add(this.label95);
            this.groupBox50.Controls.Add(this.EditEmployeePhone);
            this.groupBox50.Controls.Add(this.EditEmployeeSalary);
            this.groupBox50.Controls.Add(this.label92);
            this.groupBox50.Controls.Add(this.label54);
            this.groupBox50.Controls.Add(this.EditEmployeeName);
            this.groupBox50.Depth = 0;
            this.groupBox50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox50.Location = new System.Drawing.Point(5, 274);
            this.groupBox50.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox50.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox50.Size = new System.Drawing.Size(905, 625);
            this.groupBox50.TabIndex = 1;
            this.groupBox50.Text = "االتعديل على الموظفين و الإجازات";
            // 
            // button35
            // 
            this.button35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button35.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button35.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button35.Depth = 0;
            this.button35.HighEmphasis = true;
            this.button35.Icon = null;
            this.button35.Location = new System.Drawing.Point(588, 298);
            this.button35.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button35.MouseState = MaterialSkin.MouseState.HOVER;
            this.button35.Name = "button35";
            this.button35.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button35.Size = new System.Drawing.Size(88, 36);
            this.button35.TabIndex = 84;
            this.button35.Text = "إضافة الحسم";
            this.button35.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button35.UseAccentColor = false;
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button37
            // 
            this.button37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button37.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button37.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button37.Depth = 0;
            this.button37.HighEmphasis = true;
            this.button37.Icon = null;
            this.button37.Location = new System.Drawing.Point(801, 232);
            this.button37.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button37.MouseState = MaterialSkin.MouseState.HOVER;
            this.button37.Name = "button37";
            this.button37.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button37.Size = new System.Drawing.Size(86, 36);
            this.button37.TabIndex = 83;
            this.button37.Text = "إضافة إجازه";
            this.button37.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button37.UseAccentColor = false;
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button16.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button16.Depth = 0;
            this.button16.HighEmphasis = true;
            this.button16.Icon = null;
            this.button16.Location = new System.Drawing.Point(592, 106);
            this.button16.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button16.MouseState = MaterialSkin.MouseState.HOVER;
            this.button16.Name = "button16";
            this.button16.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button16.Size = new System.Drawing.Size(89, 36);
            this.button16.TabIndex = 82;
            this.button16.Text = "حذف  موظف";
            this.button16.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button16.UseAccentColor = false;
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button32
            // 
            this.button32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button32.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button32.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button32.Depth = 0;
            this.button32.HighEmphasis = true;
            this.button32.Icon = null;
            this.button32.Location = new System.Drawing.Point(760, 106);
            this.button32.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button32.MouseState = MaterialSkin.MouseState.HOVER;
            this.button32.Name = "button32";
            this.button32.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button32.Size = new System.Drawing.Size(96, 36);
            this.button32.TabIndex = 81;
            this.button32.Text = "تحديث  موظف";
            this.button32.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button32.UseAccentColor = false;
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // SalaryDeduction
            // 
            this.SalaryDeduction.DecimalPlaces = 2;
            this.SalaryDeduction.Location = new System.Drawing.Point(683, 312);
            this.SalaryDeduction.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.SalaryDeduction.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.SalaryDeduction.Name = "SalaryDeduction";
            this.SalaryDeduction.Size = new System.Drawing.Size(208, 22);
            this.SalaryDeduction.TabIndex = 40;
            // 
            // label111
            // 
            this.label111.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label111.AutoSize = true;
            this.label111.Depth = 0;
            this.label111.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label111.Location = new System.Drawing.Point(754, 283);
            this.label111.MouseState = MaterialSkin.MouseState.HOVER;
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(49, 19);
            this.label111.TabIndex = 39;
            this.label111.Text = "حسم الراتب";
            // 
            // AbsenceHours
            // 
            this.AbsenceHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AbsenceHours.FormattingEnabled = true;
            this.AbsenceHours.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "يوم اجازه"});
            this.AbsenceHours.Location = new System.Drawing.Point(556, 174);
            this.AbsenceHours.Name = "AbsenceHours";
            this.AbsenceHours.Size = new System.Drawing.Size(123, 24);
            this.AbsenceHours.TabIndex = 38;
            // 
            // AbsenceDate
            // 
            this.AbsenceDate.Location = new System.Drawing.Point(350, 175);
            this.AbsenceDate.Name = "AbsenceDate";
            this.AbsenceDate.Size = new System.Drawing.Size(200, 22);
            this.AbsenceDate.TabIndex = 37;
            // 
            // label107
            // 
            this.label107.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label107.AutoSize = true;
            this.label107.Depth = 0;
            this.label107.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label107.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label107.Location = new System.Drawing.Point(424, 148);
            this.label107.MouseState = MaterialSkin.MouseState.HOVER;
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(29, 19);
            this.label107.TabIndex = 36;
            this.label107.Text = "التاريخ";
            // 
            // label106
            // 
            this.label106.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label106.AutoSize = true;
            this.label106.Depth = 0;
            this.label106.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label106.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label106.Location = new System.Drawing.Point(571, 148);
            this.label106.MouseState = MaterialSkin.MouseState.HOVER;
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(54, 19);
            this.label106.TabIndex = 35;
            this.label106.Text = "عدد الساعات";
            // 
            // label109
            // 
            this.label109.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label109.AutoSize = true;
            this.label109.Depth = 0;
            this.label109.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label109.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label109.Location = new System.Drawing.Point(754, 148);
            this.label109.MouseState = MaterialSkin.MouseState.HOVER;
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(50, 19);
            this.label109.TabIndex = 31;
            this.label109.Text = "إسم الموظف";
            // 
            // AbsenceEmpName
            // 
            this.AbsenceEmpName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AbsenceEmpName.AnimateReadOnly = false;
            this.AbsenceEmpName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.AbsenceEmpName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.AbsenceEmpName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AbsenceEmpName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AbsenceEmpName.Depth = 0;
            this.AbsenceEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbsenceEmpName.HideSelection = true;
            this.AbsenceEmpName.LeadingIcon = null;
            this.AbsenceEmpName.Location = new System.Drawing.Point(685, 175);
            this.AbsenceEmpName.MaxLength = 32767;
            this.AbsenceEmpName.MouseState = MaterialSkin.MouseState.OUT;
            this.AbsenceEmpName.Name = "AbsenceEmpName";
            this.AbsenceEmpName.PasswordChar = '\0';
            this.AbsenceEmpName.PrefixSuffixText = null;
            this.AbsenceEmpName.ReadOnly = false;
            this.AbsenceEmpName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AbsenceEmpName.SelectedText = "";
            this.AbsenceEmpName.SelectionLength = 0;
            this.AbsenceEmpName.SelectionStart = 0;
            this.AbsenceEmpName.ShortcutsEnabled = true;
            this.AbsenceEmpName.Size = new System.Drawing.Size(207, 48);
            this.AbsenceEmpName.TabIndex = 30;
            this.AbsenceEmpName.TabStop = false;
            this.AbsenceEmpName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AbsenceEmpName.TrailingIcon = null;
            this.AbsenceEmpName.UseSystemPasswordChar = false;
            // 
            // label99
            // 
            this.label99.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label99.AutoSize = true;
            this.label99.Depth = 0;
            this.label99.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label99.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label99.Location = new System.Drawing.Point(98, 22);
            this.label99.MouseState = MaterialSkin.MouseState.HOVER;
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(60, 19);
            this.label99.TabIndex = 29;
            this.label99.Text = "عنوان الموظف";
            // 
            // EditEmployeeAddress
            // 
            this.EditEmployeeAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditEmployeeAddress.AnimateReadOnly = false;
            this.EditEmployeeAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.EditEmployeeAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.EditEmployeeAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EditEmployeeAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.EditEmployeeAddress.Depth = 0;
            this.EditEmployeeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditEmployeeAddress.HideSelection = true;
            this.EditEmployeeAddress.LeadingIcon = null;
            this.EditEmployeeAddress.Location = new System.Drawing.Point(46, 49);
            this.EditEmployeeAddress.MaxLength = 32767;
            this.EditEmployeeAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.EditEmployeeAddress.Name = "EditEmployeeAddress";
            this.EditEmployeeAddress.PasswordChar = '\0';
            this.EditEmployeeAddress.PrefixSuffixText = null;
            this.EditEmployeeAddress.ReadOnly = false;
            this.EditEmployeeAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EditEmployeeAddress.SelectedText = "";
            this.EditEmployeeAddress.SelectionLength = 0;
            this.EditEmployeeAddress.SelectionStart = 0;
            this.EditEmployeeAddress.ShortcutsEnabled = true;
            this.EditEmployeeAddress.Size = new System.Drawing.Size(207, 48);
            this.EditEmployeeAddress.TabIndex = 28;
            this.EditEmployeeAddress.TabStop = false;
            this.EditEmployeeAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditEmployeeAddress.TrailingIcon = null;
            this.EditEmployeeAddress.UseSystemPasswordChar = false;
            // 
            // label95
            // 
            this.label95.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label95.AutoSize = true;
            this.label95.Depth = 0;
            this.label95.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label95.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label95.Location = new System.Drawing.Point(298, 22);
            this.label95.MouseState = MaterialSkin.MouseState.HOVER;
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(72, 19);
            this.label95.TabIndex = 27;
            this.label95.Text = "رقم هاتف الموظف";
            // 
            // EditEmployeePhone
            // 
            this.EditEmployeePhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditEmployeePhone.AnimateReadOnly = false;
            this.EditEmployeePhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.EditEmployeePhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.EditEmployeePhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EditEmployeePhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.EditEmployeePhone.Depth = 0;
            this.EditEmployeePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditEmployeePhone.HideSelection = true;
            this.EditEmployeePhone.LeadingIcon = null;
            this.EditEmployeePhone.Location = new System.Drawing.Point(259, 49);
            this.EditEmployeePhone.MaxLength = 32767;
            this.EditEmployeePhone.MouseState = MaterialSkin.MouseState.OUT;
            this.EditEmployeePhone.Name = "EditEmployeePhone";
            this.EditEmployeePhone.PasswordChar = '\0';
            this.EditEmployeePhone.PrefixSuffixText = null;
            this.EditEmployeePhone.ReadOnly = false;
            this.EditEmployeePhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EditEmployeePhone.SelectedText = "";
            this.EditEmployeePhone.SelectionLength = 0;
            this.EditEmployeePhone.SelectionStart = 0;
            this.EditEmployeePhone.ShortcutsEnabled = true;
            this.EditEmployeePhone.Size = new System.Drawing.Size(207, 48);
            this.EditEmployeePhone.TabIndex = 26;
            this.EditEmployeePhone.TabStop = false;
            this.EditEmployeePhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditEmployeePhone.TrailingIcon = null;
            this.EditEmployeePhone.UseSystemPasswordChar = false;
            // 
            // EditEmployeeSalary
            // 
            this.EditEmployeeSalary.DecimalPlaces = 2;
            this.EditEmployeeSalary.Location = new System.Drawing.Point(472, 49);
            this.EditEmployeeSalary.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.EditEmployeeSalary.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.EditEmployeeSalary.Name = "EditEmployeeSalary";
            this.EditEmployeeSalary.Size = new System.Drawing.Size(208, 22);
            this.EditEmployeeSalary.TabIndex = 23;
            // 
            // label92
            // 
            this.label92.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label92.AutoSize = true;
            this.label92.Depth = 0;
            this.label92.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label92.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label92.Location = new System.Drawing.Point(556, 22);
            this.label92.MouseState = MaterialSkin.MouseState.HOVER;
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(28, 19);
            this.label92.TabIndex = 22;
            this.label92.Text = "الراتب";
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Depth = 0;
            this.label54.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label54.Location = new System.Drawing.Point(754, 22);
            this.label54.MouseState = MaterialSkin.MouseState.HOVER;
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(50, 19);
            this.label54.TabIndex = 22;
            this.label54.Text = "إسم الموظف";
            // 
            // EditEmployeeName
            // 
            this.EditEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditEmployeeName.AnimateReadOnly = false;
            this.EditEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.EditEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.EditEmployeeName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EditEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.EditEmployeeName.Depth = 0;
            this.EditEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditEmployeeName.HideSelection = true;
            this.EditEmployeeName.LeadingIcon = null;
            this.EditEmployeeName.Location = new System.Drawing.Point(686, 49);
            this.EditEmployeeName.MaxLength = 32767;
            this.EditEmployeeName.MouseState = MaterialSkin.MouseState.OUT;
            this.EditEmployeeName.Name = "EditEmployeeName";
            this.EditEmployeeName.PasswordChar = '\0';
            this.EditEmployeeName.PrefixSuffixText = null;
            this.EditEmployeeName.ReadOnly = false;
            this.EditEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EditEmployeeName.SelectedText = "";
            this.EditEmployeeName.SelectionLength = 0;
            this.EditEmployeeName.SelectionStart = 0;
            this.EditEmployeeName.ShortcutsEnabled = true;
            this.EditEmployeeName.Size = new System.Drawing.Size(207, 48);
            this.EditEmployeeName.TabIndex = 0;
            this.EditEmployeeName.TabStop = false;
            this.EditEmployeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EditEmployeeName.TrailingIcon = null;
            this.EditEmployeeName.UseSystemPasswordChar = false;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column54,
            this.dataGridViewTextBoxColumn50,
            this.dataGridViewTextBoxColumn53,
            this.Column62,
            this.Column56,
            this.Column57});
            this.dgvEmployees.Location = new System.Drawing.Point(5, 49);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(899, 219);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployees_RowHeaderMouseClick);
            // 
            // Column54
            // 
            this.Column54.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column54.DataPropertyName = "Employee ID";
            this.Column54.HeaderText = "رقم الموظف";
            this.Column54.Name = "Column54";
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn50.DataPropertyName = "Employee Name";
            this.dataGridViewTextBoxColumn50.HeaderText = "اسم الموظف";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn53.DataPropertyName = "Employee Salary";
            this.dataGridViewTextBoxColumn53.HeaderText = "الراتب";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            // 
            // Column62
            // 
            this.Column62.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column62.DataPropertyName = "Deducted Salary";
            this.Column62.HeaderText = "الراتب مع الخصم";
            this.Column62.Name = "Column62";
            // 
            // Column56
            // 
            this.Column56.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column56.DataPropertyName = "Employee Phone";
            this.Column56.HeaderText = "رقم الهاتف";
            this.Column56.Name = "Column56";
            // 
            // Column57
            // 
            this.Column57.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column57.DataPropertyName = "Employee Address";
            this.Column57.HeaderText = "العنوان";
            this.Column57.Name = "Column57";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox2.Location = new System.Drawing.Point(862, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupBox52
            // 
            this.groupBox52.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox52.Controls.Add(this.button34);
            this.groupBox52.Controls.Add(this.label105);
            this.groupBox52.Controls.Add(this.AddEmployeeAddress);
            this.groupBox52.Controls.Add(this.label104);
            this.groupBox52.Controls.Add(this.AddEmployeePhone);
            this.groupBox52.Controls.Add(this.AddEmployeeSalary);
            this.groupBox52.Controls.Add(this.label100);
            this.groupBox52.Controls.Add(this.label102);
            this.groupBox52.Controls.Add(this.AddEmployeeName);
            this.groupBox52.Depth = 0;
            this.groupBox52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox52.Location = new System.Drawing.Point(916, 0);
            this.groupBox52.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox52.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox52.Size = new System.Drawing.Size(957, 903);
            this.groupBox52.TabIndex = 2;
            this.groupBox52.Text = "تسجيل الموظفين";
            // 
            // button34
            // 
            this.button34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button34.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button34.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button34.Depth = 0;
            this.button34.HighEmphasis = true;
            this.button34.Icon = null;
            this.button34.Location = new System.Drawing.Point(873, 291);
            this.button34.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button34.MouseState = MaterialSkin.MouseState.HOVER;
            this.button34.Name = "button34";
            this.button34.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button34.Size = new System.Drawing.Size(64, 36);
            this.button34.TabIndex = 80;
            this.button34.Text = "التسجيل";
            this.button34.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button34.UseAccentColor = false;
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // label105
            // 
            this.label105.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label105.AutoSize = true;
            this.label105.Depth = 0;
            this.label105.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label105.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label105.Location = new System.Drawing.Point(709, 207);
            this.label105.MouseState = MaterialSkin.MouseState.HOVER;
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(60, 19);
            this.label105.TabIndex = 26;
            this.label105.Text = "عنوان الموظف";
            // 
            // AddEmployeeAddress
            // 
            this.AddEmployeeAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmployeeAddress.AnimateReadOnly = false;
            this.AddEmployeeAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.AddEmployeeAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.AddEmployeeAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddEmployeeAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AddEmployeeAddress.Depth = 0;
            this.AddEmployeeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEmployeeAddress.HideSelection = true;
            this.AddEmployeeAddress.LeadingIcon = null;
            this.AddEmployeeAddress.Location = new System.Drawing.Point(540, 234);
            this.AddEmployeeAddress.MaxLength = 32767;
            this.AddEmployeeAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.AddEmployeeAddress.Name = "AddEmployeeAddress";
            this.AddEmployeeAddress.PasswordChar = '\0';
            this.AddEmployeeAddress.PrefixSuffixText = null;
            this.AddEmployeeAddress.ReadOnly = false;
            this.AddEmployeeAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddEmployeeAddress.SelectedText = "";
            this.AddEmployeeAddress.SelectionLength = 0;
            this.AddEmployeeAddress.SelectionStart = 0;
            this.AddEmployeeAddress.ShortcutsEnabled = true;
            this.AddEmployeeAddress.Size = new System.Drawing.Size(397, 48);
            this.AddEmployeeAddress.TabIndex = 25;
            this.AddEmployeeAddress.TabStop = false;
            this.AddEmployeeAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddEmployeeAddress.TrailingIcon = null;
            this.AddEmployeeAddress.UseSystemPasswordChar = false;
            // 
            // label104
            // 
            this.label104.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label104.AutoSize = true;
            this.label104.Depth = 0;
            this.label104.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label104.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label104.Location = new System.Drawing.Point(697, 148);
            this.label104.MouseState = MaterialSkin.MouseState.HOVER;
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(72, 19);
            this.label104.TabIndex = 24;
            this.label104.Text = "رقم هاتف الموظف";
            // 
            // AddEmployeePhone
            // 
            this.AddEmployeePhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmployeePhone.AnimateReadOnly = false;
            this.AddEmployeePhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.AddEmployeePhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.AddEmployeePhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddEmployeePhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AddEmployeePhone.Depth = 0;
            this.AddEmployeePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEmployeePhone.HideSelection = true;
            this.AddEmployeePhone.LeadingIcon = null;
            this.AddEmployeePhone.Location = new System.Drawing.Point(540, 175);
            this.AddEmployeePhone.MaxLength = 32767;
            this.AddEmployeePhone.MouseState = MaterialSkin.MouseState.OUT;
            this.AddEmployeePhone.Name = "AddEmployeePhone";
            this.AddEmployeePhone.PasswordChar = '\0';
            this.AddEmployeePhone.PrefixSuffixText = null;
            this.AddEmployeePhone.ReadOnly = false;
            this.AddEmployeePhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddEmployeePhone.SelectedText = "";
            this.AddEmployeePhone.SelectionLength = 0;
            this.AddEmployeePhone.SelectionStart = 0;
            this.AddEmployeePhone.ShortcutsEnabled = true;
            this.AddEmployeePhone.Size = new System.Drawing.Size(397, 48);
            this.AddEmployeePhone.TabIndex = 23;
            this.AddEmployeePhone.TabStop = false;
            this.AddEmployeePhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddEmployeePhone.TrailingIcon = null;
            this.AddEmployeePhone.UseSystemPasswordChar = false;
            // 
            // AddEmployeeSalary
            // 
            this.AddEmployeeSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmployeeSalary.DecimalPlaces = 2;
            this.AddEmployeeSalary.Location = new System.Drawing.Point(543, 123);
            this.AddEmployeeSalary.Maximum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            0});
            this.AddEmployeeSalary.Minimum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            -2147483648});
            this.AddEmployeeSalary.Name = "AddEmployeeSalary";
            this.AddEmployeeSalary.Size = new System.Drawing.Size(394, 22);
            this.AddEmployeeSalary.TabIndex = 22;
            // 
            // label100
            // 
            this.label100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label100.AutoSize = true;
            this.label100.Depth = 0;
            this.label100.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label100.Location = new System.Drawing.Point(728, 96);
            this.label100.MouseState = MaterialSkin.MouseState.HOVER;
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(28, 19);
            this.label100.TabIndex = 21;
            this.label100.Text = "الراتب";
            // 
            // label102
            // 
            this.label102.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label102.AutoSize = true;
            this.label102.Depth = 0;
            this.label102.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label102.Location = new System.Drawing.Point(709, 31);
            this.label102.MouseState = MaterialSkin.MouseState.HOVER;
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(50, 19);
            this.label102.TabIndex = 20;
            this.label102.Text = "إسم الموظف";
            // 
            // AddEmployeeName
            // 
            this.AddEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmployeeName.AnimateReadOnly = false;
            this.AddEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.AddEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.AddEmployeeName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AddEmployeeName.Depth = 0;
            this.AddEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEmployeeName.HideSelection = true;
            this.AddEmployeeName.LeadingIcon = null;
            this.AddEmployeeName.Location = new System.Drawing.Point(540, 58);
            this.AddEmployeeName.MaxLength = 32767;
            this.AddEmployeeName.MouseState = MaterialSkin.MouseState.OUT;
            this.AddEmployeeName.Name = "AddEmployeeName";
            this.AddEmployeeName.PasswordChar = '\0';
            this.AddEmployeeName.PrefixSuffixText = null;
            this.AddEmployeeName.ReadOnly = false;
            this.AddEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddEmployeeName.SelectedText = "";
            this.AddEmployeeName.SelectionLength = 0;
            this.AddEmployeeName.SelectionStart = 0;
            this.AddEmployeeName.ShortcutsEnabled = true;
            this.AddEmployeeName.Size = new System.Drawing.Size(397, 48);
            this.AddEmployeeName.TabIndex = 0;
            this.AddEmployeeName.TabStop = false;
            this.AddEmployeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AddEmployeeName.TrailingIcon = null;
            this.AddEmployeeName.UseSystemPasswordChar = false;
            // 
            // DaysOff
            // 
            this.DaysOff.BackColor = System.Drawing.Color.White;
            this.DaysOff.Controls.Add(this.groupBox51);
            this.DaysOff.Location = new System.Drawing.Point(4, 34);
            this.DaysOff.Name = "DaysOff";
            this.DaysOff.Size = new System.Drawing.Size(1873, 913);
            this.DaysOff.TabIndex = 1;
            this.DaysOff.Text = "الإجازات";
            // 
            // groupBox51
            // 
            this.groupBox51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox51.Controls.Add(this.button33);
            this.groupBox51.Controls.Add(this.AbsenceTo);
            this.groupBox51.Controls.Add(this.label110);
            this.groupBox51.Controls.Add(this.AbsenceFrom);
            this.groupBox51.Controls.Add(this.label108);
            this.groupBox51.Controls.Add(this.dgvAbsence);
            this.groupBox51.Controls.Add(this.pictureBox48);
            this.groupBox51.Controls.Add(this.pictureBox43);
            this.groupBox51.Depth = 0;
            this.groupBox51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox51.Location = new System.Drawing.Point(0, 0);
            this.groupBox51.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox51.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox51.Size = new System.Drawing.Size(1873, 913);
            this.groupBox51.TabIndex = 2;
            this.groupBox51.Text = "جدول الاجازات اليوميه";
            // 
            // button33
            // 
            this.button33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button33.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button33.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button33.Depth = 0;
            this.button33.HighEmphasis = true;
            this.button33.Icon = null;
            this.button33.Location = new System.Drawing.Point(1277, 29);
            this.button33.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button33.MouseState = MaterialSkin.MouseState.HOVER;
            this.button33.Name = "button33";
            this.button33.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button33.Size = new System.Drawing.Size(83, 36);
            this.button33.TabIndex = 81;
            this.button33.Text = "حذف  غياب";
            this.button33.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button33.UseAccentColor = false;
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // AbsenceTo
            // 
            this.AbsenceTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AbsenceTo.Location = new System.Drawing.Point(1367, 43);
            this.AbsenceTo.Name = "AbsenceTo";
            this.AbsenceTo.Size = new System.Drawing.Size(200, 22);
            this.AbsenceTo.TabIndex = 34;
            // 
            // label110
            // 
            this.label110.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label110.AutoSize = true;
            this.label110.Depth = 0;
            this.label110.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label110.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label110.Location = new System.Drawing.Point(1429, 16);
            this.label110.MouseState = MaterialSkin.MouseState.HOVER;
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(45, 19);
            this.label110.TabIndex = 33;
            this.label110.Text = "التاريخ إلى";
            // 
            // AbsenceFrom
            // 
            this.AbsenceFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AbsenceFrom.Location = new System.Drawing.Point(1573, 43);
            this.AbsenceFrom.Name = "AbsenceFrom";
            this.AbsenceFrom.Size = new System.Drawing.Size(200, 22);
            this.AbsenceFrom.TabIndex = 31;
            // 
            // label108
            // 
            this.label108.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label108.AutoSize = true;
            this.label108.Depth = 0;
            this.label108.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label108.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label108.Location = new System.Drawing.Point(1640, 16);
            this.label108.MouseState = MaterialSkin.MouseState.HOVER;
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(43, 19);
            this.label108.TabIndex = 30;
            this.label108.Text = "التاريخ من";
            // 
            // dgvAbsence
            // 
            this.dgvAbsence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAbsence.BackgroundColor = System.Drawing.Color.White;
            this.dgvAbsence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column58,
            this.Column59,
            this.Column60,
            this.Column61});
            this.dgvAbsence.Location = new System.Drawing.Point(6, 81);
            this.dgvAbsence.Name = "dgvAbsence";
            this.dgvAbsence.Size = new System.Drawing.Size(1858, 865);
            this.dgvAbsence.TabIndex = 0;
            this.dgvAbsence.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAbsence_RowHeaderMouseClick);
            // 
            // Column58
            // 
            this.Column58.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column58.DataPropertyName = "Absence ID";
            this.Column58.HeaderText = "رقم الغياب";
            this.Column58.Name = "Column58";
            // 
            // Column59
            // 
            this.Column59.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column59.DataPropertyName = "Employee Name";
            this.Column59.HeaderText = "اسم الموظف";
            this.Column59.Name = "Column59";
            // 
            // Column60
            // 
            this.Column60.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column60.DataPropertyName = "Absence Date";
            this.Column60.HeaderText = "تاريخ الغياب";
            this.Column60.Name = "Column60";
            // 
            // Column61
            // 
            this.Column61.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column61.DataPropertyName = "Absence Hours";
            this.Column61.HeaderText = "ساعات الغياب";
            this.Column61.Name = "Column61";
            // 
            // pictureBox48
            // 
            this.pictureBox48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox48.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox48.Image = global::PlancksoftPOS.Properties.Resources.search;
            this.pictureBox48.Location = new System.Drawing.Point(1789, 36);
            this.pictureBox48.Name = "pictureBox48";
            this.pictureBox48.Size = new System.Drawing.Size(32, 27);
            this.pictureBox48.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox48.TabIndex = 32;
            this.pictureBox48.TabStop = false;
            this.pictureBox48.Click += new System.EventHandler(this.pictureBox48_Click);
            // 
            // pictureBox43
            // 
            this.pictureBox43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox43.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox43.Location = new System.Drawing.Point(1827, 36);
            this.pictureBox43.Name = "pictureBox43";
            this.pictureBox43.Size = new System.Drawing.Size(36, 27);
            this.pictureBox43.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox43.TabIndex = 26;
            this.pictureBox43.TabStop = false;
            this.pictureBox43.Click += new System.EventHandler(this.pictureBox43_Click);
            // 
            // Agents
            // 
            this.Agents.BackColor = System.Drawing.Color.White;
            this.Agents.Controls.Add(this.tabControl3);
            this.Agents.Location = new System.Drawing.Point(4, 34);
            this.Agents.Name = "Agents";
            this.Agents.Size = new System.Drawing.Size(1881, 951);
            this.Agents.TabIndex = 4;
            this.Agents.Text = "شؤون العملاء";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.AgentsDefinitions);
            this.tabControl3.Controls.Add(this.ClientBalanceCheck);
            this.tabControl3.Controls.Add(this.ImporterDefinitions);
            this.tabControl3.Controls.Add(this.ImporterBalanceChecks);
            this.tabControl3.Controls.Add(this.AgentsItemsDefinitions);
            this.tabControl3.Depth = 0;
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.ItemSize = new System.Drawing.Size(88, 30);
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl3.Multiline = true;
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.RightToLeftLayout = true;
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1881, 951);
            this.tabControl3.TabIndex = 0;
            this.tabControl3.SelectedIndexChanged += new System.EventHandler(this.tabControl3_SelectedIndexChanged);
            this.tabControl3.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl3_Selecting);
            // 
            // AgentsDefinitions
            // 
            this.AgentsDefinitions.BackColor = System.Drawing.Color.White;
            this.AgentsDefinitions.Controls.Add(this.groupBox15);
            this.AgentsDefinitions.Controls.Add(this.groupBox17);
            this.AgentsDefinitions.Location = new System.Drawing.Point(4, 34);
            this.AgentsDefinitions.Name = "AgentsDefinitions";
            this.AgentsDefinitions.Padding = new System.Windows.Forms.Padding(3);
            this.AgentsDefinitions.Size = new System.Drawing.Size(1873, 913);
            this.AgentsDefinitions.TabIndex = 0;
            this.AgentsDefinitions.Text = "تعريف العملاء";
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox15.Controls.Add(this.selectAllClients);
            this.groupBox15.Controls.Add(this.groupBox16);
            this.groupBox15.Controls.Add(this.dgvClients);
            this.groupBox15.Controls.Add(this.pictureBox21);
            this.groupBox15.Depth = 0;
            this.groupBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox15.Location = new System.Drawing.Point(0, 0);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox15.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox15.Size = new System.Drawing.Size(921, 913);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.Text = "جدول العملاء";
            // 
            // selectAllClients
            // 
            this.selectAllClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllClients.AutoSize = true;
            this.selectAllClients.Location = new System.Drawing.Point(763, 26);
            this.selectAllClients.Name = "selectAllClients";
            this.selectAllClients.Size = new System.Drawing.Size(105, 20);
            this.selectAllClients.TabIndex = 27;
            this.selectAllClients.Text = "إختيار الجميع";
            this.selectAllClients.UseVisualStyleBackColor = true;
            this.selectAllClients.CheckedChanged += new System.EventHandler(this.selectAllClients_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox16.Controls.Add(this.btnClientBalanceCheck);
            this.groupBox16.Controls.Add(this.btnClientDelete);
            this.groupBox16.Depth = 0;
            this.groupBox16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox16.Location = new System.Drawing.Point(3, 797);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox16.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox16.Size = new System.Drawing.Size(912, 114);
            this.groupBox16.TabIndex = 1;
            this.groupBox16.Text = "االتعديل على العملاء";
            // 
            // btnClientBalanceCheck
            // 
            this.btnClientBalanceCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientBalanceCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientBalanceCheck.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientBalanceCheck.Depth = 0;
            this.btnClientBalanceCheck.HighEmphasis = true;
            this.btnClientBalanceCheck.Icon = null;
            this.btnClientBalanceCheck.Location = new System.Drawing.Point(666, 20);
            this.btnClientBalanceCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientBalanceCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientBalanceCheck.Name = "btnClientBalanceCheck";
            this.btnClientBalanceCheck.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientBalanceCheck.Size = new System.Drawing.Size(86, 36);
            this.btnClientBalanceCheck.TabIndex = 88;
            this.btnClientBalanceCheck.Text = "كشف حساب";
            this.btnClientBalanceCheck.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientBalanceCheck.UseAccentColor = false;
            this.btnClientBalanceCheck.UseVisualStyleBackColor = true;
            this.btnClientBalanceCheck.Click += new System.EventHandler(this.btnClientBalanceCheck_Click);
            // 
            // btnClientDelete
            // 
            this.btnClientDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientDelete.Depth = 0;
            this.btnClientDelete.HighEmphasis = true;
            this.btnClientDelete.Icon = null;
            this.btnClientDelete.Location = new System.Drawing.Point(811, 20);
            this.btnClientDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientDelete.Name = "btnClientDelete";
            this.btnClientDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientDelete.Size = new System.Drawing.Size(83, 36);
            this.btnClientDelete.TabIndex = 83;
            this.btnClientDelete.Text = "حذف العميل";
            this.btnClientDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientDelete.UseAccentColor = false;
            this.btnClientDelete.UseVisualStyleBackColor = true;
            this.btnClientDelete.Click += new System.EventHandler(this.btnClientDelete_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column27,
            this.ClientIDDelete,
            this.Column38,
            this.Column39,
            this.Column10});
            this.dgvClients.Location = new System.Drawing.Point(3, 52);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.Size = new System.Drawing.Size(912, 745);
            this.dgvClients.TabIndex = 0;
            // 
            // Column27
            // 
            this.Column27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column27.DataPropertyName = "Client Name";
            this.Column27.HeaderText = "اسم العميل";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            // 
            // ClientIDDelete
            // 
            this.ClientIDDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientIDDelete.DataPropertyName = "Client ID";
            this.ClientIDDelete.HeaderText = "رمز العميل";
            this.ClientIDDelete.Name = "ClientIDDelete";
            this.ClientIDDelete.ReadOnly = true;
            // 
            // Column38
            // 
            this.Column38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column38.DataPropertyName = "Client Phone";
            this.Column38.HeaderText = "رقم العميل";
            this.Column38.Name = "Column38";
            this.Column38.ReadOnly = true;
            // 
            // Column39
            // 
            this.Column39.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column39.DataPropertyName = "Client Address";
            this.Column39.HeaderText = "عنوان العميل";
            this.Column39.Name = "Column39";
            this.Column39.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.DataPropertyName = "Client Email";
            this.Column10.HeaderText = "البريد الإلكتروني";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox21.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox21.Location = new System.Drawing.Point(873, 19);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(36, 27);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 26;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Click += new System.EventHandler(this.pictureBox21_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox17.Controls.Add(this.ClientEmail);
            this.groupBox17.Controls.Add(this.lblEmail);
            this.groupBox17.Controls.Add(this.ClientName);
            this.groupBox17.Controls.Add(this.btnClientAdd);
            this.groupBox17.Controls.Add(this.ClientAddress);
            this.groupBox17.Controls.Add(this.ClientPhone);
            this.groupBox17.Controls.Add(this.label21);
            this.groupBox17.Controls.Add(this.label18);
            this.groupBox17.Controls.Add(this.ClientID);
            this.groupBox17.Controls.Add(this.label82);
            this.groupBox17.Controls.Add(this.label83);
            this.groupBox17.Depth = 0;
            this.groupBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox17.Location = new System.Drawing.Point(917, 0);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox17.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox17.Size = new System.Drawing.Size(956, 968);
            this.groupBox17.TabIndex = 4;
            this.groupBox17.Text = "تسجيل العملاء";
            // 
            // ClientEmail
            // 
            this.ClientEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientEmail.AnimateReadOnly = false;
            this.ClientEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ClientEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ClientEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ClientEmail.Depth = 0;
            this.ClientEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientEmail.HideSelection = true;
            this.ClientEmail.LeadingIcon = null;
            this.ClientEmail.Location = new System.Drawing.Point(523, 272);
            this.ClientEmail.MaxLength = 32767;
            this.ClientEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.ClientEmail.Name = "ClientEmail";
            this.ClientEmail.PasswordChar = '\0';
            this.ClientEmail.PrefixSuffixText = null;
            this.ClientEmail.ReadOnly = false;
            this.ClientEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClientEmail.SelectedText = "";
            this.ClientEmail.SelectionLength = 0;
            this.ClientEmail.SelectionStart = 0;
            this.ClientEmail.ShortcutsEnabled = true;
            this.ClientEmail.Size = new System.Drawing.Size(424, 48);
            this.ClientEmail.TabIndex = 88;
            this.ClientEmail.TabStop = false;
            this.ClientEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ClientEmail.TrailingIcon = null;
            this.ClientEmail.UseSystemPasswordChar = false;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblEmail.Location = new System.Drawing.Point(718, 248);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 19);
            this.lblEmail.TabIndex = 89;
            this.lblEmail.Text = "البريد الإلكتروني";
            // 
            // ClientName
            // 
            this.ClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientName.AnimateReadOnly = false;
            this.ClientName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ClientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ClientName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ClientName.Depth = 0;
            this.ClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientName.HideSelection = true;
            this.ClientName.LeadingIcon = null;
            this.ClientName.Location = new System.Drawing.Point(523, 38);
            this.ClientName.MaxLength = 32767;
            this.ClientName.MouseState = MaterialSkin.MouseState.OUT;
            this.ClientName.Name = "ClientName";
            this.ClientName.PasswordChar = '\0';
            this.ClientName.PrefixSuffixText = null;
            this.ClientName.ReadOnly = false;
            this.ClientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClientName.SelectedText = "";
            this.ClientName.SelectionLength = 0;
            this.ClientName.SelectionStart = 0;
            this.ClientName.ShortcutsEnabled = true;
            this.ClientName.Size = new System.Drawing.Size(422, 48);
            this.ClientName.TabIndex = 87;
            this.ClientName.TabStop = false;
            this.ClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ClientName.TrailingIcon = null;
            this.ClientName.UseSystemPasswordChar = false;
            // 
            // btnClientAdd
            // 
            this.btnClientAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientAdd.Depth = 0;
            this.btnClientAdd.HighEmphasis = true;
            this.btnClientAdd.Icon = null;
            this.btnClientAdd.Location = new System.Drawing.Point(678, 324);
            this.btnClientAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientAdd.Name = "btnClientAdd";
            this.btnClientAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientAdd.Size = new System.Drawing.Size(80, 36);
            this.btnClientAdd.TabIndex = 82;
            this.btnClientAdd.Text = "حفظ العميل";
            this.btnClientAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientAdd.UseAccentColor = false;
            this.btnClientAdd.UseVisualStyleBackColor = true;
            this.btnClientAdd.Click += new System.EventHandler(this.btnClientAdd_Click);
            // 
            // ClientAddress
            // 
            this.ClientAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientAddress.AnimateReadOnly = false;
            this.ClientAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ClientAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ClientAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ClientAddress.Depth = 0;
            this.ClientAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientAddress.HideSelection = true;
            this.ClientAddress.LeadingIcon = null;
            this.ClientAddress.Location = new System.Drawing.Point(523, 194);
            this.ClientAddress.MaxLength = 32767;
            this.ClientAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.PasswordChar = '\0';
            this.ClientAddress.PrefixSuffixText = null;
            this.ClientAddress.ReadOnly = false;
            this.ClientAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClientAddress.SelectedText = "";
            this.ClientAddress.SelectionLength = 0;
            this.ClientAddress.SelectionStart = 0;
            this.ClientAddress.ShortcutsEnabled = true;
            this.ClientAddress.Size = new System.Drawing.Size(424, 48);
            this.ClientAddress.TabIndex = 7;
            this.ClientAddress.TabStop = false;
            this.ClientAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ClientAddress.TrailingIcon = null;
            this.ClientAddress.UseSystemPasswordChar = false;
            this.ClientAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClientAddress_KeyPress);
            // 
            // ClientPhone
            // 
            this.ClientPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientPhone.AnimateReadOnly = false;
            this.ClientPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ClientPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ClientPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ClientPhone.Depth = 0;
            this.ClientPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientPhone.HideSelection = true;
            this.ClientPhone.LeadingIcon = null;
            this.ClientPhone.Location = new System.Drawing.Point(523, 114);
            this.ClientPhone.MaxLength = 10;
            this.ClientPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.PasswordChar = '\0';
            this.ClientPhone.PrefixSuffixText = null;
            this.ClientPhone.ReadOnly = false;
            this.ClientPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClientPhone.SelectedText = "";
            this.ClientPhone.SelectionLength = 0;
            this.ClientPhone.SelectionStart = 0;
            this.ClientPhone.ShortcutsEnabled = true;
            this.ClientPhone.Size = new System.Drawing.Size(424, 48);
            this.ClientPhone.TabIndex = 6;
            this.ClientPhone.TabStop = false;
            this.ClientPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ClientPhone.TrailingIcon = null;
            this.ClientPhone.UseSystemPasswordChar = false;
            this.ClientPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClientPhone_KeyPress);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Depth = 0;
            this.label21.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label21.Location = new System.Drawing.Point(732, 167);
            this.label21.MouseState = MaterialSkin.MouseState.HOVER;
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 19);
            this.label21.TabIndex = 39;
            this.label21.Text = "العنوان";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Depth = 0;
            this.label18.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label18.Location = new System.Drawing.Point(723, 92);
            this.label18.MouseState = MaterialSkin.MouseState.HOVER;
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 19);
            this.label18.TabIndex = 37;
            this.label18.Text = "رقم تلفون";
            // 
            // ClientID
            // 
            this.ClientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ClientID.Location = new System.Drawing.Point(93, 48);
            this.ClientID.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.ClientID.Name = "ClientID";
            this.ClientID.Size = new System.Drawing.Size(424, 20);
            this.ClientID.TabIndex = 1;
            this.ClientID.Visible = false;
            this.ClientID.Enter += new System.EventHandler(this.ClientID_Enter);
            this.ClientID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClientID_KeyPress);
            // 
            // label82
            // 
            this.label82.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label82.AutoSize = true;
            this.label82.Depth = 0;
            this.label82.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label82.Location = new System.Drawing.Point(718, 16);
            this.label82.MouseState = MaterialSkin.MouseState.HOVER;
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(43, 19);
            this.label82.TabIndex = 21;
            this.label82.Text = "إسم العميل";
            // 
            // label83
            // 
            this.label83.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label83.AutoSize = true;
            this.label83.Depth = 0;
            this.label83.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label83.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label83.Location = new System.Drawing.Point(302, 26);
            this.label83.MouseState = MaterialSkin.MouseState.HOVER;
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(46, 19);
            this.label83.TabIndex = 20;
            this.label83.Text = "رمز العميل";
            this.label83.Visible = false;
            // 
            // ClientBalanceCheck
            // 
            this.ClientBalanceCheck.BackColor = System.Drawing.Color.White;
            this.ClientBalanceCheck.Controls.Add(this.materialCard1);
            this.ClientBalanceCheck.Controls.Add(this.materialCard2);
            this.ClientBalanceCheck.Location = new System.Drawing.Point(4, 34);
            this.ClientBalanceCheck.Name = "ClientBalanceCheck";
            this.ClientBalanceCheck.Padding = new System.Windows.Forms.Padding(3);
            this.ClientBalanceCheck.Size = new System.Drawing.Size(1873, 913);
            this.ClientBalanceCheck.TabIndex = 3;
            this.ClientBalanceCheck.Text = "كشف حساب العميل";
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnPrintClientBillItems);
            this.materialCard1.Controls.Add(this.dgvClientBillItems);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 330);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1872, 583);
            this.materialCard1.TabIndex = 5;
            this.materialCard1.Text = "المواد المشتراه بالفاتوره";
            // 
            // btnPrintClientBillItems
            // 
            this.btnPrintClientBillItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintClientBillItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnPrintClientBillItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintClientBillItems.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.btnPrintClientBillItems.Location = new System.Drawing.Point(1772, 19);
            this.btnPrintClientBillItems.Name = "btnPrintClientBillItems";
            this.btnPrintClientBillItems.Size = new System.Drawing.Size(100, 66);
            this.btnPrintClientBillItems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPrintClientBillItems.TabIndex = 31;
            this.btnPrintClientBillItems.TabStop = false;
            // 
            // dgvClientBillItems
            // 
            this.dgvClientBillItems.AllowUserToAddRows = false;
            this.dgvClientBillItems.AllowUserToDeleteRows = false;
            this.dgvClientBillItems.AllowUserToOrderColumns = true;
            this.dgvClientBillItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientBillItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientBillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientBillItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23});
            this.dgvClientBillItems.Location = new System.Drawing.Point(3, 19);
            this.dgvClientBillItems.Name = "dgvClientBillItems";
            this.dgvClientBillItems.ReadOnly = true;
            this.dgvClientBillItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvClientBillItems.Size = new System.Drawing.Size(1766, 547);
            this.dgvClientBillItems.TabIndex = 29;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn20.HeaderText = "اسم الماده";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn21.HeaderText = "باركود الماده";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Sold Quantity";
            this.dataGridViewTextBoxColumn22.HeaderText = "عدد البيع";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Item Price Tax";
            this.dataGridViewTextBoxColumn23.HeaderText = "سعر البيع بعد الضريبه";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // materialCard2
            // 
            this.materialCard2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.btnPayDebtBill);
            this.materialCard2.Controls.Add(this.dgvClientBills);
            this.materialCard2.Controls.Add(this.btnPrintClientBills);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(0, 1);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(1870, 329);
            this.materialCard2.TabIndex = 6;
            this.materialCard2.Text = "لائحة الفواتير";
            // 
            // btnPayDebtBill
            // 
            this.btnPayDebtBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayDebtBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayDebtBill.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPayDebtBill.Depth = 0;
            this.btnPayDebtBill.HighEmphasis = true;
            this.btnPayDebtBill.Icon = null;
            this.btnPayDebtBill.Location = new System.Drawing.Point(1783, 121);
            this.btnPayDebtBill.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPayDebtBill.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPayDebtBill.Name = "btnPayDebtBill";
            this.btnPayDebtBill.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPayDebtBill.Size = new System.Drawing.Size(82, 36);
            this.btnPayDebtBill.TabIndex = 83;
            this.btnPayDebtBill.Text = "دفع الفاتوره";
            this.btnPayDebtBill.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPayDebtBill.UseAccentColor = false;
            this.btnPayDebtBill.UseVisualStyleBackColor = true;
            this.btnPayDebtBill.Click += new System.EventHandler(this.btnPayDebtBill_Click);
            // 
            // dgvClientBills
            // 
            this.dgvClientBills.AllowUserToAddRows = false;
            this.dgvClientBills.AllowUserToDeleteRows = false;
            this.dgvClientBills.AllowUserToOrderColumns = true;
            this.dgvClientBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.ClientBillsPaidAmount,
            this.ClientBillsRemainderAmount,
            this.dataGridViewTextBoxColumn31,
            this.Column4,
            this.Column6,
            this.Column8});
            this.dgvClientBills.Location = new System.Drawing.Point(4, 9);
            this.dgvClientBills.Name = "dgvClientBills";
            this.dgvClientBills.ReadOnly = true;
            this.dgvClientBills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvClientBills.Size = new System.Drawing.Size(1763, 311);
            this.dgvClientBills.TabIndex = 28;
            this.dgvClientBills.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientBills_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Bill Number";
            this.dataGridViewTextBoxColumn24.HeaderText = "رقم الفاتوره";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Cashier Name";
            this.dataGridViewTextBoxColumn29.HeaderText = "اسم الكاشير";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Total Amount";
            this.dataGridViewTextBoxColumn30.HeaderText = "المبلغ الصافي";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            // 
            // ClientBillsPaidAmount
            // 
            this.ClientBillsPaidAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientBillsPaidAmount.DataPropertyName = "Paid Amount";
            this.ClientBillsPaidAmount.HeaderText = "المبلغ المدفوع";
            this.ClientBillsPaidAmount.Name = "ClientBillsPaidAmount";
            this.ClientBillsPaidAmount.ReadOnly = true;
            // 
            // ClientBillsRemainderAmount
            // 
            this.ClientBillsRemainderAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClientBillsRemainderAmount.DataPropertyName = "Remainder Amount";
            this.ClientBillsRemainderAmount.HeaderText = "المبلغ المتبقي";
            this.ClientBillsRemainderAmount.Name = "ClientBillsRemainderAmount";
            this.ClientBillsRemainderAmount.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn31.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "Status";
            this.Column4.HeaderText = "الحاله";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 65;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "Client ID";
            this.Column6.HeaderText = "رقم العميل";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "Client Name";
            this.Column8.HeaderText = "إسم العميل";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // btnPrintClientBills
            // 
            this.btnPrintClientBills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintClientBills.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnPrintClientBills.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintClientBills.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.btnPrintClientBills.Location = new System.Drawing.Point(1769, 21);
            this.btnPrintClientBills.Name = "btnPrintClientBills";
            this.btnPrintClientBills.Size = new System.Drawing.Size(98, 91);
            this.btnPrintClientBills.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPrintClientBills.TabIndex = 29;
            this.btnPrintClientBills.TabStop = false;
            this.btnPrintClientBills.Click += new System.EventHandler(this.btnPrintClientBills_Click);
            // 
            // ImporterDefinitions
            // 
            this.ImporterDefinitions.BackColor = System.Drawing.Color.White;
            this.ImporterDefinitions.Controls.Add(this.groupBox39);
            this.ImporterDefinitions.Controls.Add(this.groupBox40);
            this.ImporterDefinitions.Location = new System.Drawing.Point(4, 34);
            this.ImporterDefinitions.Name = "ImporterDefinitions";
            this.ImporterDefinitions.Padding = new System.Windows.Forms.Padding(3);
            this.ImporterDefinitions.Size = new System.Drawing.Size(1873, 913);
            this.ImporterDefinitions.TabIndex = 2;
            this.ImporterDefinitions.Text = "تعريف مورد";
            // 
            // groupBox39
            // 
            this.groupBox39.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox39.Controls.Add(this.selectAllVendors);
            this.groupBox39.Controls.Add(this.groupBox38);
            this.groupBox39.Controls.Add(this.dgvVendors);
            this.groupBox39.Controls.Add(this.pictureBox42);
            this.groupBox39.Depth = 0;
            this.groupBox39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox39.Location = new System.Drawing.Point(0, 0);
            this.groupBox39.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox39.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox39.Size = new System.Drawing.Size(921, 913);
            this.groupBox39.TabIndex = 5;
            this.groupBox39.Text = "جدول الموردين";
            // 
            // selectAllVendors
            // 
            this.selectAllVendors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllVendors.AutoSize = true;
            this.selectAllVendors.Location = new System.Drawing.Point(763, 26);
            this.selectAllVendors.Name = "selectAllVendors";
            this.selectAllVendors.Size = new System.Drawing.Size(105, 20);
            this.selectAllVendors.TabIndex = 28;
            this.selectAllVendors.Text = "إختيار الجميع";
            this.selectAllVendors.UseVisualStyleBackColor = true;
            this.selectAllVendors.CheckedChanged += new System.EventHandler(this.selectAllVendors_CheckedChanged);
            // 
            // groupBox38
            // 
            this.groupBox38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox38.Controls.Add(this.button8);
            this.groupBox38.Controls.Add(this.button9);
            this.groupBox38.Controls.Add(this.button6);
            this.groupBox38.Depth = 0;
            this.groupBox38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox38.Location = new System.Drawing.Point(3, 817);
            this.groupBox38.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox38.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox38.Size = new System.Drawing.Size(912, 96);
            this.groupBox38.TabIndex = 1;
            this.groupBox38.Text = "االتعديل على الموردين";
            // 
            // button8
            // 
            this.button8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button8.Depth = 0;
            this.button8.HighEmphasis = true;
            this.button8.Icon = null;
            this.button8.Location = new System.Drawing.Point(232, 14);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button8.MouseState = MaterialSkin.MouseState.HOVER;
            this.button8.Name = "button8";
            this.button8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button8.Size = new System.Drawing.Size(89, 36);
            this.button8.TabIndex = 88;
            this.button8.Text = "إضافة فاتوره";
            this.button8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button8.UseAccentColor = false;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button9.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button9.Depth = 0;
            this.button9.HighEmphasis = true;
            this.button9.Icon = null;
            this.button9.Location = new System.Drawing.Point(505, 14);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button9.MouseState = MaterialSkin.MouseState.HOVER;
            this.button9.Name = "button9";
            this.button9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button9.Size = new System.Drawing.Size(86, 36);
            this.button9.TabIndex = 87;
            this.button9.Text = "كشف حساب";
            this.button9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button9.UseAccentColor = false;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button6.Depth = 0;
            this.button6.HighEmphasis = true;
            this.button6.Icon = null;
            this.button6.Location = new System.Drawing.Point(718, 14);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button6.MouseState = MaterialSkin.MouseState.HOVER;
            this.button6.Name = "button6";
            this.button6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button6.Size = new System.Drawing.Size(85, 36);
            this.button6.TabIndex = 86;
            this.button6.Text = "حذف المورد";
            this.button6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button6.UseAccentColor = false;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dgvVendors
            // 
            this.dgvVendors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVendors.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendorClientName,
            this.VendorClientID,
            this.VendorClientPhone,
            this.VendorClientAddress,
            this.Column11});
            this.dgvVendors.Location = new System.Drawing.Point(5, 52);
            this.dgvVendors.Name = "dgvVendors";
            this.dgvVendors.ReadOnly = true;
            this.dgvVendors.Size = new System.Drawing.Size(910, 761);
            this.dgvVendors.TabIndex = 0;
            // 
            // VendorClientName
            // 
            this.VendorClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorClientName.DataPropertyName = "Client Name";
            this.VendorClientName.HeaderText = "اسم المورد";
            this.VendorClientName.Name = "VendorClientName";
            this.VendorClientName.ReadOnly = true;
            // 
            // VendorClientID
            // 
            this.VendorClientID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorClientID.DataPropertyName = "Client ID";
            this.VendorClientID.HeaderText = "رمز المورد";
            this.VendorClientID.Name = "VendorClientID";
            this.VendorClientID.ReadOnly = true;
            // 
            // VendorClientPhone
            // 
            this.VendorClientPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorClientPhone.DataPropertyName = "Client Phone";
            this.VendorClientPhone.HeaderText = "رقم المورد";
            this.VendorClientPhone.Name = "VendorClientPhone";
            this.VendorClientPhone.ReadOnly = true;
            // 
            // VendorClientAddress
            // 
            this.VendorClientAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorClientAddress.DataPropertyName = "Client Address";
            this.VendorClientAddress.HeaderText = "عنوان المورد";
            this.VendorClientAddress.Name = "VendorClientAddress";
            this.VendorClientAddress.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.DataPropertyName = "Client Email";
            this.Column11.HeaderText = "البريد الإلكتروني";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // pictureBox42
            // 
            this.pictureBox42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox42.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox42.Location = new System.Drawing.Point(873, 19);
            this.pictureBox42.Name = "pictureBox42";
            this.pictureBox42.Size = new System.Drawing.Size(36, 27);
            this.pictureBox42.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox42.TabIndex = 26;
            this.pictureBox42.TabStop = false;
            this.pictureBox42.Click += new System.EventHandler(this.pictureBox42_Click);
            // 
            // groupBox40
            // 
            this.groupBox40.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox40.Controls.Add(this.VendorEmail);
            this.groupBox40.Controls.Add(this.lblVendorEmail);
            this.groupBox40.Controls.Add(this.VendorName);
            this.groupBox40.Controls.Add(this.button7);
            this.groupBox40.Controls.Add(this.VendorAddress);
            this.groupBox40.Controls.Add(this.VendorPhone);
            this.groupBox40.Controls.Add(this.label39);
            this.groupBox40.Controls.Add(this.label40);
            this.groupBox40.Controls.Add(this.VendorID);
            this.groupBox40.Controls.Add(this.label41);
            this.groupBox40.Controls.Add(this.label42);
            this.groupBox40.Depth = 0;
            this.groupBox40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox40.Location = new System.Drawing.Point(917, 0);
            this.groupBox40.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox40.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox40.Size = new System.Drawing.Size(956, 968);
            this.groupBox40.TabIndex = 6;
            this.groupBox40.Text = "تسجيل الموردين";
            // 
            // VendorEmail
            // 
            this.VendorEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VendorEmail.AnimateReadOnly = false;
            this.VendorEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.VendorEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.VendorEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VendorEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.VendorEmail.Depth = 0;
            this.VendorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.VendorEmail.HideSelection = true;
            this.VendorEmail.LeadingIcon = null;
            this.VendorEmail.Location = new System.Drawing.Point(517, 272);
            this.VendorEmail.MaxLength = 32767;
            this.VendorEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.VendorEmail.Name = "VendorEmail";
            this.VendorEmail.PasswordChar = '\0';
            this.VendorEmail.PrefixSuffixText = null;
            this.VendorEmail.ReadOnly = false;
            this.VendorEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VendorEmail.SelectedText = "";
            this.VendorEmail.SelectionLength = 0;
            this.VendorEmail.SelectionStart = 0;
            this.VendorEmail.ShortcutsEnabled = true;
            this.VendorEmail.Size = new System.Drawing.Size(422, 48);
            this.VendorEmail.TabIndex = 87;
            this.VendorEmail.TabStop = false;
            this.VendorEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.VendorEmail.TrailingIcon = null;
            this.VendorEmail.UseSystemPasswordChar = false;
            // 
            // lblVendorEmail
            // 
            this.lblVendorEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendorEmail.AutoSize = true;
            this.lblVendorEmail.BackColor = System.Drawing.Color.White;
            this.lblVendorEmail.Depth = 0;
            this.lblVendorEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVendorEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblVendorEmail.Location = new System.Drawing.Point(700, 252);
            this.lblVendorEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblVendorEmail.Name = "lblVendorEmail";
            this.lblVendorEmail.Size = new System.Drawing.Size(68, 19);
            this.lblVendorEmail.TabIndex = 88;
            this.lblVendorEmail.Text = "البريد الإلكتروني";
            // 
            // VendorName
            // 
            this.VendorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VendorName.AnimateReadOnly = false;
            this.VendorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.VendorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.VendorName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.VendorName.Depth = 0;
            this.VendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.VendorName.HideSelection = true;
            this.VendorName.LeadingIcon = null;
            this.VendorName.Location = new System.Drawing.Point(521, 44);
            this.VendorName.MaxLength = 32767;
            this.VendorName.MouseState = MaterialSkin.MouseState.OUT;
            this.VendorName.Name = "VendorName";
            this.VendorName.PasswordChar = '\0';
            this.VendorName.PrefixSuffixText = null;
            this.VendorName.ReadOnly = false;
            this.VendorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VendorName.SelectedText = "";
            this.VendorName.SelectionLength = 0;
            this.VendorName.SelectionStart = 0;
            this.VendorName.ShortcutsEnabled = true;
            this.VendorName.Size = new System.Drawing.Size(422, 48);
            this.VendorName.TabIndex = 86;
            this.VendorName.TabStop = false;
            this.VendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.VendorName.TrailingIcon = null;
            this.VendorName.UseSystemPasswordChar = false;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button7.Depth = 0;
            this.button7.HighEmphasis = true;
            this.button7.Icon = null;
            this.button7.Location = new System.Drawing.Point(700, 324);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button7.MouseState = MaterialSkin.MouseState.HOVER;
            this.button7.Name = "button7";
            this.button7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button7.Size = new System.Drawing.Size(81, 36);
            this.button7.TabIndex = 85;
            this.button7.Text = "حفظ المورد";
            this.button7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button7.UseAccentColor = false;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // VendorAddress
            // 
            this.VendorAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VendorAddress.AnimateReadOnly = false;
            this.VendorAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.VendorAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.VendorAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VendorAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.VendorAddress.Depth = 0;
            this.VendorAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.VendorAddress.HideSelection = true;
            this.VendorAddress.LeadingIcon = null;
            this.VendorAddress.Location = new System.Drawing.Point(517, 193);
            this.VendorAddress.MaxLength = 32767;
            this.VendorAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.VendorAddress.Name = "VendorAddress";
            this.VendorAddress.PasswordChar = '\0';
            this.VendorAddress.PrefixSuffixText = null;
            this.VendorAddress.ReadOnly = false;
            this.VendorAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VendorAddress.SelectedText = "";
            this.VendorAddress.SelectionLength = 0;
            this.VendorAddress.SelectionStart = 0;
            this.VendorAddress.ShortcutsEnabled = true;
            this.VendorAddress.Size = new System.Drawing.Size(422, 48);
            this.VendorAddress.TabIndex = 7;
            this.VendorAddress.TabStop = false;
            this.VendorAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.VendorAddress.TrailingIcon = null;
            this.VendorAddress.UseSystemPasswordChar = false;
            this.VendorAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VendorAddress_KeyPress);
            // 
            // VendorPhone
            // 
            this.VendorPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VendorPhone.AnimateReadOnly = false;
            this.VendorPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.VendorPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.VendorPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VendorPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.VendorPhone.Depth = 0;
            this.VendorPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.VendorPhone.HideSelection = true;
            this.VendorPhone.LeadingIcon = null;
            this.VendorPhone.Location = new System.Drawing.Point(521, 117);
            this.VendorPhone.MaxLength = 10;
            this.VendorPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.VendorPhone.Name = "VendorPhone";
            this.VendorPhone.PasswordChar = '\0';
            this.VendorPhone.PrefixSuffixText = null;
            this.VendorPhone.ReadOnly = false;
            this.VendorPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VendorPhone.SelectedText = "";
            this.VendorPhone.SelectionLength = 0;
            this.VendorPhone.SelectionStart = 0;
            this.VendorPhone.ShortcutsEnabled = true;
            this.VendorPhone.Size = new System.Drawing.Size(422, 48);
            this.VendorPhone.TabIndex = 6;
            this.VendorPhone.TabStop = false;
            this.VendorPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.VendorPhone.TrailingIcon = null;
            this.VendorPhone.UseSystemPasswordChar = false;
            this.VendorPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VendorPhone_KeyPress);
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Depth = 0;
            this.label39.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label39.Location = new System.Drawing.Point(723, 173);
            this.label39.MouseState = MaterialSkin.MouseState.HOVER;
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 19);
            this.label39.TabIndex = 39;
            this.label39.Text = "العنوان";
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.White;
            this.label40.Depth = 0;
            this.label40.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label40.Location = new System.Drawing.Point(718, 100);
            this.label40.MouseState = MaterialSkin.MouseState.HOVER;
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(38, 19);
            this.label40.TabIndex = 37;
            this.label40.Text = "رقم تلفون";
            // 
            // VendorID
            // 
            this.VendorID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VendorID.Location = new System.Drawing.Point(80, 46);
            this.VendorID.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.VendorID.Name = "VendorID";
            this.VendorID.Size = new System.Drawing.Size(422, 22);
            this.VendorID.TabIndex = 1;
            this.VendorID.Visible = false;
            this.VendorID.Enter += new System.EventHandler(this.VendorID_Enter);
            this.VendorID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VendorID_KeyPress);
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.White;
            this.label41.Depth = 0;
            this.label41.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label41.Location = new System.Drawing.Point(712, 22);
            this.label41.MouseState = MaterialSkin.MouseState.HOVER;
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(44, 19);
            this.label41.TabIndex = 21;
            this.label41.Text = "إسم المورد";
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.White;
            this.label42.Depth = 0;
            this.label42.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label42.Location = new System.Drawing.Point(277, 28);
            this.label42.MouseState = MaterialSkin.MouseState.HOVER;
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(47, 19);
            this.label42.TabIndex = 20;
            this.label42.Text = "رمز المورد";
            this.label42.Visible = false;
            // 
            // ImporterBalanceChecks
            // 
            this.ImporterBalanceChecks.BackColor = System.Drawing.Color.White;
            this.ImporterBalanceChecks.Controls.Add(this.groupBox42);
            this.ImporterBalanceChecks.Controls.Add(this.groupBox43);
            this.ImporterBalanceChecks.Location = new System.Drawing.Point(4, 34);
            this.ImporterBalanceChecks.Name = "ImporterBalanceChecks";
            this.ImporterBalanceChecks.Padding = new System.Windows.Forms.Padding(3);
            this.ImporterBalanceChecks.Size = new System.Drawing.Size(1873, 913);
            this.ImporterBalanceChecks.TabIndex = 4;
            this.ImporterBalanceChecks.Text = "كشف حساب مورد";
            // 
            // groupBox42
            // 
            this.groupBox42.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox42.Controls.Add(this.pictureBox35);
            this.groupBox42.Controls.Add(this.dgvVendorBillItems);
            this.groupBox42.Depth = 0;
            this.groupBox42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox42.Location = new System.Drawing.Point(4, 341);
            this.groupBox42.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox42.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox42.Size = new System.Drawing.Size(1872, 654);
            this.groupBox42.TabIndex = 3;
            this.groupBox42.Text = "المواد المشتراه بالفاتوره";
            // 
            // pictureBox35
            // 
            this.pictureBox35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox35.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox35.Location = new System.Drawing.Point(1772, 19);
            this.pictureBox35.Name = "pictureBox35";
            this.pictureBox35.Size = new System.Drawing.Size(100, 66);
            this.pictureBox35.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox35.TabIndex = 31;
            this.pictureBox35.TabStop = false;
            this.pictureBox35.Click += new System.EventHandler(this.pictureBox35_Click_1);
            // 
            // dgvVendorBillItems
            // 
            this.dgvVendorBillItems.AllowUserToAddRows = false;
            this.dgvVendorBillItems.AllowUserToDeleteRows = false;
            this.dgvVendorBillItems.AllowUserToOrderColumns = true;
            this.dgvVendorBillItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVendorBillItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendorBillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorBillItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.VendorBillItemBuyPrice});
            this.dgvVendorBillItems.Location = new System.Drawing.Point(3, 19);
            this.dgvVendorBillItems.Name = "dgvVendorBillItems";
            this.dgvVendorBillItems.ReadOnly = true;
            this.dgvVendorBillItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvVendorBillItems.Size = new System.Drawing.Size(1766, 518);
            this.dgvVendorBillItems.TabIndex = 29;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn34.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn34.HeaderText = "اسم الماده";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn35.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn35.HeaderText = "باركود الماده";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Item Buy Quantity";
            this.dataGridViewTextBoxColumn36.HeaderText = "عدد البيع الشراء";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            // 
            // VendorBillItemBuyPrice
            // 
            this.VendorBillItemBuyPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorBillItemBuyPrice.DataPropertyName = "Item Buy Price";
            this.VendorBillItemBuyPrice.HeaderText = "سعر الشراء";
            this.VendorBillItemBuyPrice.Name = "VendorBillItemBuyPrice";
            this.VendorBillItemBuyPrice.ReadOnly = true;
            // 
            // groupBox43
            // 
            this.groupBox43.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox43.Controls.Add(this.dgvVendorBills);
            this.groupBox43.Controls.Add(this.pictureBox45);
            this.groupBox43.Depth = 0;
            this.groupBox43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox43.Location = new System.Drawing.Point(4, 6);
            this.groupBox43.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox43.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox43.Name = "groupBox43";
            this.groupBox43.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox43.Size = new System.Drawing.Size(1870, 329);
            this.groupBox43.TabIndex = 4;
            this.groupBox43.Text = "لائحة الفواتير";
            // 
            // dgvVendorBills
            // 
            this.dgvVendorBills.AllowUserToAddRows = false;
            this.dgvVendorBills.AllowUserToDeleteRows = false;
            this.dgvVendorBills.AllowUserToOrderColumns = true;
            this.dgvVendorBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVendorBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendorBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.VendorBillDate});
            this.dgvVendorBills.Location = new System.Drawing.Point(4, 9);
            this.dgvVendorBills.Name = "dgvVendorBills";
            this.dgvVendorBills.ReadOnly = true;
            this.dgvVendorBills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvVendorBills.Size = new System.Drawing.Size(1763, 311);
            this.dgvVendorBills.TabIndex = 28;
            this.dgvVendorBills.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVendorBills_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Bill Number";
            this.dataGridViewTextBoxColumn39.HeaderText = "رقم الفاتوره";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn40.DataPropertyName = "Cashier Name";
            this.dataGridViewTextBoxColumn40.HeaderText = "اسم الكاشير";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Total Amount";
            this.dataGridViewTextBoxColumn41.HeaderText = "المبلغ الصافي";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // VendorBillDate
            // 
            this.VendorBillDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendorBillDate.DataPropertyName = "Date";
            this.VendorBillDate.HeaderText = "التاريخ";
            this.VendorBillDate.Name = "VendorBillDate";
            this.VendorBillDate.ReadOnly = true;
            // 
            // pictureBox45
            // 
            this.pictureBox45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox45.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox45.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox45.Location = new System.Drawing.Point(1769, 21);
            this.pictureBox45.Name = "pictureBox45";
            this.pictureBox45.Size = new System.Drawing.Size(98, 91);
            this.pictureBox45.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox45.TabIndex = 29;
            this.pictureBox45.TabStop = false;
            this.pictureBox45.Click += new System.EventHandler(this.pictureBox45_Click);
            // 
            // AgentsItemsDefinitions
            // 
            this.AgentsItemsDefinitions.BackColor = System.Drawing.Color.White;
            this.AgentsItemsDefinitions.Controls.Add(this.groupBox34);
            this.AgentsItemsDefinitions.Controls.Add(this.groupBox23);
            this.AgentsItemsDefinitions.Location = new System.Drawing.Point(4, 34);
            this.AgentsItemsDefinitions.Name = "AgentsItemsDefinitions";
            this.AgentsItemsDefinitions.Padding = new System.Windows.Forms.Padding(3);
            this.AgentsItemsDefinitions.Size = new System.Drawing.Size(1873, 913);
            this.AgentsItemsDefinitions.TabIndex = 1;
            this.AgentsItemsDefinitions.Text = "تعريف مواد العميل";
            // 
            // groupBox34
            // 
            this.groupBox34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox34.Controls.Add(this.btnClientVendorItemsPickClientItem);
            this.groupBox34.Controls.Add(this.btnClientVendorItemsPriceClient);
            this.groupBox34.Controls.Add(this.textBox7);
            this.groupBox34.Controls.Add(this.numericUpDown2);
            this.groupBox34.Controls.Add(this.lblClientVendorItemsClientID);
            this.groupBox34.Controls.Add(this.lblClientVendorItemsClientName);
            this.groupBox34.Controls.Add(this.ClientPrice);
            this.groupBox34.Controls.Add(this.lblClientVendorItemsClientSellPrice);
            this.groupBox34.Controls.Add(this.SellPriceTax);
            this.groupBox34.Controls.Add(this.lblClientVendorItemsSellPriceTax);
            this.groupBox34.Controls.Add(this.SellPrice);
            this.groupBox34.Controls.Add(this.BuyPrice);
            this.groupBox34.Controls.Add(this.lblClientVendorItemsSellPrice);
            this.groupBox34.Controls.Add(this.lblClientVendorItemsBuyPrice);
            this.groupBox34.Depth = 0;
            this.groupBox34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox34.Location = new System.Drawing.Point(-1, 444);
            this.groupBox34.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox34.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox34.Size = new System.Drawing.Size(1875, 469);
            this.groupBox34.TabIndex = 1;
            this.groupBox34.Text = "تعريف مواد العميل";
            // 
            // btnClientVendorItemsPickClientItem
            // 
            this.btnClientVendorItemsPickClientItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientVendorItemsPickClientItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientVendorItemsPickClientItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientVendorItemsPickClientItem.Depth = 0;
            this.btnClientVendorItemsPickClientItem.HighEmphasis = true;
            this.btnClientVendorItemsPickClientItem.Icon = null;
            this.btnClientVendorItemsPickClientItem.Location = new System.Drawing.Point(1600, 145);
            this.btnClientVendorItemsPickClientItem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientVendorItemsPickClientItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientVendorItemsPickClientItem.Name = "btnClientVendorItemsPickClientItem";
            this.btnClientVendorItemsPickClientItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientVendorItemsPickClientItem.Size = new System.Drawing.Size(120, 36);
            this.btnClientVendorItemsPickClientItem.TabIndex = 85;
            this.btnClientVendorItemsPickClientItem.Text = "إضافة الماده للعميل";
            this.btnClientVendorItemsPickClientItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientVendorItemsPickClientItem.UseAccentColor = false;
            this.btnClientVendorItemsPickClientItem.UseVisualStyleBackColor = true;
            this.btnClientVendorItemsPickClientItem.Click += new System.EventHandler(this.btnClientVendorItemsPickClientItem_Click);
            // 
            // btnClientVendorItemsPriceClient
            // 
            this.btnClientVendorItemsPriceClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientVendorItemsPriceClient.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientVendorItemsPriceClient.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientVendorItemsPriceClient.Depth = 0;
            this.btnClientVendorItemsPriceClient.HighEmphasis = true;
            this.btnClientVendorItemsPriceClient.Icon = null;
            this.btnClientVendorItemsPriceClient.Location = new System.Drawing.Point(1764, 145);
            this.btnClientVendorItemsPriceClient.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientVendorItemsPriceClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientVendorItemsPriceClient.Name = "btnClientVendorItemsPriceClient";
            this.btnClientVendorItemsPriceClient.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientVendorItemsPriceClient.Size = new System.Drawing.Size(89, 36);
            this.btnClientVendorItemsPriceClient.TabIndex = 84;
            this.btnClientVendorItemsPriceClient.Text = "إختيار العميل";
            this.btnClientVendorItemsPriceClient.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientVendorItemsPriceClient.UseAccentColor = false;
            this.btnClientVendorItemsPriceClient.UseVisualStyleBackColor = true;
            this.btnClientVendorItemsPriceClient.Click += new System.EventHandler(this.btnClientVendorItemsPriceClient_Click);
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.AnimateReadOnly = false;
            this.textBox7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBox7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox7.Depth = 0;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.HideSelection = true;
            this.textBox7.LeadingIcon = null;
            this.textBox7.Location = new System.Drawing.Point(1472, 38);
            this.textBox7.MaxLength = 32767;
            this.textBox7.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.PrefixSuffixText = null;
            this.textBox7.ReadOnly = true;
            this.textBox7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox7.SelectedText = "";
            this.textBox7.SelectionLength = 0;
            this.textBox7.SelectionStart = 0;
            this.textBox7.ShortcutsEnabled = true;
            this.textBox7.Size = new System.Drawing.Size(393, 48);
            this.textBox7.TabIndex = 58;
            this.textBox7.TabStop = false;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox7.TrailingIcon = null;
            this.textBox7.UseSystemPasswordChar = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.numericUpDown2.Location = new System.Drawing.Point(1471, 116);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new System.Drawing.Size(397, 20);
            this.numericUpDown2.TabIndex = 55;
            // 
            // lblClientVendorItemsClientID
            // 
            this.lblClientVendorItemsClientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientVendorItemsClientID.AutoSize = true;
            this.lblClientVendorItemsClientID.Depth = 0;
            this.lblClientVendorItemsClientID.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientVendorItemsClientID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientVendorItemsClientID.Location = new System.Drawing.Point(1657, 89);
            this.lblClientVendorItemsClientID.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientVendorItemsClientID.Name = "lblClientVendorItemsClientID";
            this.lblClientVendorItemsClientID.Size = new System.Drawing.Size(46, 19);
            this.lblClientVendorItemsClientID.TabIndex = 57;
            this.lblClientVendorItemsClientID.Text = "رمز العميل";
            // 
            // lblClientVendorItemsClientName
            // 
            this.lblClientVendorItemsClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientVendorItemsClientName.AutoSize = true;
            this.lblClientVendorItemsClientName.Depth = 0;
            this.lblClientVendorItemsClientName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientVendorItemsClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientVendorItemsClientName.Location = new System.Drawing.Point(1654, 16);
            this.lblClientVendorItemsClientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientVendorItemsClientName.Name = "lblClientVendorItemsClientName";
            this.lblClientVendorItemsClientName.Size = new System.Drawing.Size(43, 19);
            this.lblClientVendorItemsClientName.TabIndex = 56;
            this.lblClientVendorItemsClientName.Text = "إسم العميل";
            // 
            // ClientPrice
            // 
            this.ClientPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientPrice.DecimalPlaces = 2;
            this.ClientPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ClientPrice.Location = new System.Drawing.Point(558, 99);
            this.ClientPrice.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.ClientPrice.Name = "ClientPrice";
            this.ClientPrice.Size = new System.Drawing.Size(397, 20);
            this.ClientPrice.TabIndex = 47;
            this.ClientPrice.Enter += new System.EventHandler(this.ClientPrice_Enter_1);
            // 
            // lblClientVendorItemsClientSellPrice
            // 
            this.lblClientVendorItemsClientSellPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientVendorItemsClientSellPrice.AutoSize = true;
            this.lblClientVendorItemsClientSellPrice.Depth = 0;
            this.lblClientVendorItemsClientSellPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientVendorItemsClientSellPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientVendorItemsClientSellPrice.Location = new System.Drawing.Point(716, 72);
            this.lblClientVendorItemsClientSellPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientVendorItemsClientSellPrice.Name = "lblClientVendorItemsClientSellPrice";
            this.lblClientVendorItemsClientSellPrice.Size = new System.Drawing.Size(61, 19);
            this.lblClientVendorItemsClientSellPrice.TabIndex = 51;
            this.lblClientVendorItemsClientSellPrice.Text = "سعر بيع العميل";
            // 
            // SellPriceTax
            // 
            this.SellPriceTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SellPriceTax.DecimalPlaces = 2;
            this.SellPriceTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellPriceTax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.SellPriceTax.Location = new System.Drawing.Point(558, 46);
            this.SellPriceTax.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.SellPriceTax.Name = "SellPriceTax";
            this.SellPriceTax.Size = new System.Drawing.Size(397, 20);
            this.SellPriceTax.TabIndex = 46;
            this.SellPriceTax.Enter += new System.EventHandler(this.SellPriceTax_Enter_1);
            // 
            // lblClientVendorItemsSellPriceTax
            // 
            this.lblClientVendorItemsSellPriceTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientVendorItemsSellPriceTax.AutoSize = true;
            this.lblClientVendorItemsSellPriceTax.Depth = 0;
            this.lblClientVendorItemsSellPriceTax.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientVendorItemsSellPriceTax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientVendorItemsSellPriceTax.Location = new System.Drawing.Point(685, 16);
            this.lblClientVendorItemsSellPriceTax.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientVendorItemsSellPriceTax.Name = "lblClientVendorItemsSellPriceTax";
            this.lblClientVendorItemsSellPriceTax.Size = new System.Drawing.Size(90, 19);
            this.lblClientVendorItemsSellPriceTax.TabIndex = 50;
            this.lblClientVendorItemsSellPriceTax.Text = "سعر البيع بعد الضريبه";
            // 
            // SellPrice
            // 
            this.SellPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SellPrice.DecimalPlaces = 2;
            this.SellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.SellPrice.Location = new System.Drawing.Point(1011, 97);
            this.SellPrice.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.Size = new System.Drawing.Size(397, 20);
            this.SellPrice.TabIndex = 45;
            this.SellPrice.Enter += new System.EventHandler(this.SellPrice_Enter_1);
            // 
            // BuyPrice
            // 
            this.BuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyPrice.DecimalPlaces = 2;
            this.BuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.BuyPrice.Location = new System.Drawing.Point(1011, 43);
            this.BuyPrice.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.BuyPrice.Name = "BuyPrice";
            this.BuyPrice.Size = new System.Drawing.Size(397, 20);
            this.BuyPrice.TabIndex = 44;
            this.BuyPrice.Enter += new System.EventHandler(this.BuyPrice_Enter_1);
            // 
            // lblClientVendorItemsSellPrice
            // 
            this.lblClientVendorItemsSellPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientVendorItemsSellPrice.AutoSize = true;
            this.lblClientVendorItemsSellPrice.Depth = 0;
            this.lblClientVendorItemsSellPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientVendorItemsSellPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientVendorItemsSellPrice.Location = new System.Drawing.Point(1136, 72);
            this.lblClientVendorItemsSellPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientVendorItemsSellPrice.Name = "lblClientVendorItemsSellPrice";
            this.lblClientVendorItemsSellPrice.Size = new System.Drawing.Size(90, 19);
            this.lblClientVendorItemsSellPrice.TabIndex = 49;
            this.lblClientVendorItemsSellPrice.Text = "سعر البيع قبل الضريبه";
            // 
            // lblClientVendorItemsBuyPrice
            // 
            this.lblClientVendorItemsBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientVendorItemsBuyPrice.AutoSize = true;
            this.lblClientVendorItemsBuyPrice.Depth = 0;
            this.lblClientVendorItemsBuyPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientVendorItemsBuyPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblClientVendorItemsBuyPrice.Location = new System.Drawing.Point(1169, 16);
            this.lblClientVendorItemsBuyPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientVendorItemsBuyPrice.Name = "lblClientVendorItemsBuyPrice";
            this.lblClientVendorItemsBuyPrice.Size = new System.Drawing.Size(49, 19);
            this.lblClientVendorItemsBuyPrice.TabIndex = 48;
            this.lblClientVendorItemsBuyPrice.Text = "سعر الشراء";
            // 
            // groupBox23
            // 
            this.groupBox23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox23.Controls.Add(this.pictureBox40);
            this.groupBox23.Controls.Add(this.DGVClientItems);
            this.groupBox23.Depth = 0;
            this.groupBox23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox23.Location = new System.Drawing.Point(-1, 0);
            this.groupBox23.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox23.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox23.Size = new System.Drawing.Size(1875, 444);
            this.groupBox23.TabIndex = 0;
            this.groupBox23.Text = "جدول المواد";
            // 
            // pictureBox40
            // 
            this.pictureBox40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox40.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox40.Location = new System.Drawing.Point(1836, 21);
            this.pictureBox40.Name = "pictureBox40";
            this.pictureBox40.Size = new System.Drawing.Size(36, 27);
            this.pictureBox40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox40.TabIndex = 27;
            this.pictureBox40.TabStop = false;
            this.pictureBox40.Click += new System.EventHandler(this.pictureBox40_Click);
            // 
            // DGVClientItems
            // 
            this.DGVClientItems.AllowUserToAddRows = false;
            this.DGVClientItems.AllowUserToDeleteRows = false;
            this.DGVClientItems.AllowUserToOrderColumns = true;
            this.DGVClientItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVClientItems.BackgroundColor = System.Drawing.Color.White;
            this.DGVClientItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClientItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28});
            this.DGVClientItems.Location = new System.Drawing.Point(5, 51);
            this.DGVClientItems.Name = "DGVClientItems";
            this.DGVClientItems.ReadOnly = true;
            this.DGVClientItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGVClientItems.Size = new System.Drawing.Size(1867, 387);
            this.DGVClientItems.TabIndex = 1;
            this.DGVClientItems.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVClientItems_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "اسم القطعه";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "باركود القطعه";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item Quantity";
            this.dataGridViewTextBoxColumn3.HeaderText = "عدد القطعه";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item Buy Price";
            this.dataGridViewTextBoxColumn4.HeaderText = "سعر الشراء";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Item Price";
            this.dataGridViewTextBoxColumn5.HeaderText = "سعر القطعه";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Item Price Tax";
            this.dataGridViewTextBoxColumn25.HeaderText = "سعر القطعه بالضريبه";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Favorite Category";
            this.dataGridViewTextBoxColumn26.HeaderText = "المصنف المفضل";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Warehouse ID";
            this.dataGridViewTextBoxColumn27.HeaderText = "المستودع";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Item Type";
            this.dataGridViewTextBoxColumn28.HeaderText = "تصنيف الماده";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // Alerts
            // 
            this.Alerts.BackColor = System.Drawing.Color.White;
            this.Alerts.Controls.Add(this.groupBox37);
            this.Alerts.Location = new System.Drawing.Point(4, 34);
            this.Alerts.Name = "Alerts";
            this.Alerts.Padding = new System.Windows.Forms.Padding(3);
            this.Alerts.Size = new System.Drawing.Size(1881, 951);
            this.Alerts.TabIndex = 8;
            this.Alerts.Text = "التنبيهات";
            // 
            // groupBox37
            // 
            this.groupBox37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox37.Controls.Add(this.dgvAlerts);
            this.groupBox37.Controls.Add(this.pictureBox41);
            this.groupBox37.Depth = 0;
            this.groupBox37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox37.Location = new System.Drawing.Point(3, 3);
            this.groupBox37.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox37.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox37.Size = new System.Drawing.Size(1875, 945);
            this.groupBox37.TabIndex = 2;
            this.groupBox37.Text = "التنبيهات";
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.AllowUserToAddRows = false;
            this.dgvAlerts.AllowUserToDeleteRows = false;
            this.dgvAlerts.AllowUserToOrderColumns = true;
            this.dgvAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlerts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column42,
            this.Column43,
            this.Column44,
            this.Column45,
            this.Column46,
            this.Column47});
            this.dgvAlerts.Location = new System.Drawing.Point(10, 20);
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.ReadOnly = true;
            this.dgvAlerts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAlerts.Size = new System.Drawing.Size(1769, 922);
            this.dgvAlerts.TabIndex = 34;
            // 
            // Column42
            // 
            this.Column42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column42.DataPropertyName = "Item BarCode";
            this.Column42.HeaderText = "باركود الماده";
            this.Column42.Name = "Column42";
            this.Column42.ReadOnly = true;
            // 
            // Column43
            // 
            this.Column43.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column43.DataPropertyName = "Item Name";
            this.Column43.HeaderText = "اسم الماده";
            this.Column43.Name = "Column43";
            this.Column43.ReadOnly = true;
            // 
            // Column44
            // 
            this.Column44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column44.DataPropertyName = "Start Date";
            this.Column44.HeaderText = "تاريخ الانتاج";
            this.Column44.Name = "Column44";
            this.Column44.ReadOnly = true;
            // 
            // Column45
            // 
            this.Column45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column45.DataPropertyName = "End Date";
            this.Column45.HeaderText = "تاريخ انتهاء الصلاحيه";
            this.Column45.Name = "Column45";
            this.Column45.ReadOnly = true;
            // 
            // Column46
            // 
            this.Column46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column46.DataPropertyName = "Quantity End";
            this.Column46.HeaderText = "كمية التحذير";
            this.Column46.Name = "Column46";
            this.Column46.ReadOnly = true;
            // 
            // Column47
            // 
            this.Column47.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column47.DataPropertyName = "Current Quantity";
            this.Column47.HeaderText = "الكميه الحاليه";
            this.Column47.Name = "Column47";
            this.Column47.ReadOnly = true;
            // 
            // pictureBox41
            // 
            this.pictureBox41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox41.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox41.Location = new System.Drawing.Point(1781, 20);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(96, 99);
            this.pictureBox41.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox41.TabIndex = 32;
            this.pictureBox41.TabStop = false;
            this.pictureBox41.Click += new System.EventHandler(this.pictureBox41_Click);
            // 
            // Taxes
            // 
            this.Taxes.BackColor = System.Drawing.Color.White;
            this.Taxes.Controls.Add(this.tabControl7);
            this.Taxes.Location = new System.Drawing.Point(4, 34);
            this.Taxes.Name = "Taxes";
            this.Taxes.Padding = new System.Windows.Forms.Padding(3);
            this.Taxes.Size = new System.Drawing.Size(1881, 951);
            this.Taxes.TabIndex = 9;
            this.Taxes.Text = "الضريبه";
            // 
            // tabControl7
            // 
            this.tabControl7.Controls.Add(this.TaxZReport);
            this.tabControl7.Depth = 0;
            this.tabControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl7.ItemSize = new System.Drawing.Size(101, 30);
            this.tabControl7.Location = new System.Drawing.Point(3, 3);
            this.tabControl7.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl7.Multiline = true;
            this.tabControl7.Name = "tabControl7";
            this.tabControl7.RightToLeftLayout = true;
            this.tabControl7.SelectedIndex = 0;
            this.tabControl7.Size = new System.Drawing.Size(1875, 945);
            this.tabControl7.TabIndex = 0;
            // 
            // TaxZReport
            // 
            this.TaxZReport.BackColor = System.Drawing.Color.White;
            this.TaxZReport.Controls.Add(this.groupBox44);
            this.TaxZReport.Location = new System.Drawing.Point(4, 34);
            this.TaxZReport.Name = "TaxZReport";
            this.TaxZReport.Padding = new System.Windows.Forms.Padding(3);
            this.TaxZReport.Size = new System.Drawing.Size(1867, 907);
            this.TaxZReport.TabIndex = 0;
            this.TaxZReport.Text = "تقرير الضريبه Z";
            // 
            // groupBox44
            // 
            this.groupBox44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox44.Controls.Add(this.pictureBox46);
            this.groupBox44.Controls.Add(this.pictureBox44);
            this.groupBox44.Controls.Add(this.dgvTaxZReport);
            this.groupBox44.Depth = 0;
            this.groupBox44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox44.Location = new System.Drawing.Point(3, 3);
            this.groupBox44.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox44.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox44.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox44.Size = new System.Drawing.Size(1861, 901);
            this.groupBox44.TabIndex = 1;
            // 
            // pictureBox46
            // 
            this.pictureBox46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox46.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox46.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox46.Location = new System.Drawing.Point(1717, 8);
            this.pictureBox46.Name = "pictureBox46";
            this.pictureBox46.Size = new System.Drawing.Size(78, 40);
            this.pictureBox46.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox46.TabIndex = 33;
            this.pictureBox46.TabStop = false;
            this.pictureBox46.Click += new System.EventHandler(this.pictureBox46_Click);
            // 
            // pictureBox44
            // 
            this.pictureBox44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox44.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox44.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox44.Location = new System.Drawing.Point(1801, 8);
            this.pictureBox44.Name = "pictureBox44";
            this.pictureBox44.Size = new System.Drawing.Size(59, 40);
            this.pictureBox44.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox44.TabIndex = 27;
            this.pictureBox44.TabStop = false;
            this.pictureBox44.Click += new System.EventHandler(this.pictureBox44_Click);
            // 
            // dgvTaxZReport
            // 
            this.dgvTaxZReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaxZReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaxZReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaxZReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column50,
            this.Column52,
            this.Column53,
            this.Column55,
            this.Column51,
            this.TaxTotal});
            this.dgvTaxZReport.Location = new System.Drawing.Point(0, 48);
            this.dgvTaxZReport.Name = "dgvTaxZReport";
            this.dgvTaxZReport.ReadOnly = true;
            this.dgvTaxZReport.Size = new System.Drawing.Size(1860, 914);
            this.dgvTaxZReport.TabIndex = 0;
            // 
            // Column50
            // 
            this.Column50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column50.DataPropertyName = "Bill Number";
            this.Column50.HeaderText = "رقم الفاتتوره";
            this.Column50.Name = "Column50";
            this.Column50.ReadOnly = true;
            // 
            // Column52
            // 
            this.Column52.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column52.DataPropertyName = "Total Amount";
            this.Column52.HeaderText = "قيمة الفاتوره";
            this.Column52.Name = "Column52";
            this.Column52.ReadOnly = true;
            // 
            // Column53
            // 
            this.Column53.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column53.DataPropertyName = "Tax";
            this.Column53.HeaderText = "قيمة الضريبه";
            this.Column53.Name = "Column53";
            this.Column53.ReadOnly = true;
            // 
            // Column55
            // 
            this.Column55.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column55.DataPropertyName = "Cashier Name";
            this.Column55.HeaderText = "اسم الكاشير";
            this.Column55.Name = "Column55";
            this.Column55.ReadOnly = true;
            // 
            // Column51
            // 
            this.Column51.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column51.DataPropertyName = "Date";
            this.Column51.HeaderText = "التاريخ";
            this.Column51.Name = "Column51";
            this.Column51.ReadOnly = true;
            // 
            // TaxTotal
            // 
            this.TaxTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TaxTotal.DataPropertyName = "TaxTotal";
            this.TaxTotal.HeaderText = "مجموع الضريبه";
            this.TaxTotal.Name = "TaxTotal";
            this.TaxTotal.ReadOnly = true;
            // 
            // posUsers
            // 
            this.posUsers.BackColor = System.Drawing.Color.White;
            this.posUsers.Controls.Add(this.groupBox10);
            this.posUsers.Location = new System.Drawing.Point(4, 34);
            this.posUsers.Name = "posUsers";
            this.posUsers.Size = new System.Drawing.Size(1881, 951);
            this.posUsers.TabIndex = 5;
            this.posUsers.Text = "المستخدمين";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox10.Controls.Add(this.groupBox11);
            this.groupBox10.Controls.Add(this.dgvUsers);
            this.groupBox10.Controls.Add(this.pictureBox16);
            this.groupBox10.Depth = 0;
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox10.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox10.Size = new System.Drawing.Size(1881, 951);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.Text = "جدول المستخدمين";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox11.Controls.Add(this.button19);
            this.groupBox11.Controls.Add(this.button20);
            this.groupBox11.Controls.Add(this.button22);
            this.groupBox11.Controls.Add(this.groupBox35);
            this.groupBox11.Controls.Add(this.cbAdminOrNotAdd);
            this.groupBox11.Controls.Add(this.label75);
            this.groupBox11.Controls.Add(this.txtUserPasswordAdd);
            this.groupBox11.Controls.Add(this.label76);
            this.groupBox11.Controls.Add(this.txtUserIDAdd);
            this.groupBox11.Controls.Add(this.label77);
            this.groupBox11.Controls.Add(this.txtUserNameAdd);
            this.groupBox11.Depth = 0;
            this.groupBox11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox11.Location = new System.Drawing.Point(5, 599);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox11.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox11.Size = new System.Drawing.Size(1871, 343);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.Text = "االتعديل على المستخدمين";
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button19.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button19.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button19.Depth = 0;
            this.button19.HighEmphasis = true;
            this.button19.Icon = null;
            this.button19.Location = new System.Drawing.Point(1679, 208);
            this.button19.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button19.MouseState = MaterialSkin.MouseState.HOVER;
            this.button19.Name = "button19";
            this.button19.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button19.Size = new System.Drawing.Size(91, 36);
            this.button19.TabIndex = 94;
            this.button19.Text = "حذف مستخدم";
            this.button19.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button19.UseAccentColor = false;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button20.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button20.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button20.Depth = 0;
            this.button20.HighEmphasis = true;
            this.button20.Icon = null;
            this.button20.Location = new System.Drawing.Point(1672, 160);
            this.button20.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button20.MouseState = MaterialSkin.MouseState.HOVER;
            this.button20.Name = "button20";
            this.button20.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button20.Size = new System.Drawing.Size(98, 36);
            this.button20.TabIndex = 93;
            this.button20.Text = "تحديث مستخدم";
            this.button20.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button20.UseAccentColor = false;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button22
            // 
            this.button22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button22.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button22.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button22.Depth = 0;
            this.button22.HighEmphasis = true;
            this.button22.Icon = null;
            this.button22.Location = new System.Drawing.Point(1672, 110);
            this.button22.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button22.MouseState = MaterialSkin.MouseState.HOVER;
            this.button22.Name = "button22";
            this.button22.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button22.Size = new System.Drawing.Size(96, 36);
            this.button22.TabIndex = 92;
            this.button22.Text = "إضافه مستخدم";
            this.button22.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button22.UseAccentColor = false;
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // groupBox35
            // 
            this.groupBox35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox35.Controls.Add(this.sell_edit);
            this.groupBox35.Controls.Add(this.openclose_edit);
            this.groupBox35.Controls.Add(this.personnel_edit);
            this.groupBox35.Controls.Add(this.settings_edit);
            this.groupBox35.Controls.Add(this.users_edit);
            this.groupBox35.Controls.Add(this.expenses_edit);
            this.groupBox35.Controls.Add(this.inventory_edit);
            this.groupBox35.Controls.Add(this.receipt_edit);
            this.groupBox35.Controls.Add(this.price_edit);
            this.groupBox35.Controls.Add(this.discount_edit);
            this.groupBox35.Controls.Add(this.Client_card_edit);
            this.groupBox35.Depth = 0;
            this.groupBox35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox35.Location = new System.Drawing.Point(6, 81);
            this.groupBox35.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox35.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox35.Size = new System.Drawing.Size(1051, 243);
            this.groupBox35.TabIndex = 27;
            this.groupBox35.Text = "الصلاحيات";
            // 
            // sell_edit
            // 
            this.sell_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sell_edit.AutoSize = true;
            this.sell_edit.Depth = 0;
            this.sell_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.sell_edit.Location = new System.Drawing.Point(642, 47);
            this.sell_edit.Margin = new System.Windows.Forms.Padding(0);
            this.sell_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.sell_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.sell_edit.Name = "sell_edit";
            this.sell_edit.ReadOnly = false;
            this.sell_edit.Ripple = true;
            this.sell_edit.Size = new System.Drawing.Size(90, 37);
            this.sell_edit.TabIndex = 10;
            this.sell_edit.Text = "مبيعات الكاش";
            this.sell_edit.UseVisualStyleBackColor = true;
            // 
            // openclose_edit
            // 
            this.openclose_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openclose_edit.AutoSize = true;
            this.openclose_edit.Depth = 0;
            this.openclose_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openclose_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.openclose_edit.Location = new System.Drawing.Point(622, 19);
            this.openclose_edit.Margin = new System.Windows.Forms.Padding(0);
            this.openclose_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.openclose_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.openclose_edit.Name = "openclose_edit";
            this.openclose_edit.ReadOnly = false;
            this.openclose_edit.Ripple = true;
            this.openclose_edit.Size = new System.Drawing.Size(110, 37);
            this.openclose_edit.TabIndex = 9;
            this.openclose_edit.Text = "فتح و إغلاق الكاش";
            this.openclose_edit.UseVisualStyleBackColor = true;
            // 
            // personnel_edit
            // 
            this.personnel_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.personnel_edit.AutoSize = true;
            this.personnel_edit.Depth = 0;
            this.personnel_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personnel_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.personnel_edit.Location = new System.Drawing.Point(939, 177);
            this.personnel_edit.Margin = new System.Windows.Forms.Padding(0);
            this.personnel_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.personnel_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.personnel_edit.Name = "personnel_edit";
            this.personnel_edit.ReadOnly = false;
            this.personnel_edit.Ripple = true;
            this.personnel_edit.Size = new System.Drawing.Size(95, 37);
            this.personnel_edit.TabIndex = 8;
            this.personnel_edit.Text = "تعديل الموظفين";
            this.personnel_edit.UseVisualStyleBackColor = true;
            // 
            // settings_edit
            // 
            this.settings_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_edit.AutoSize = true;
            this.settings_edit.Depth = 0;
            this.settings_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.settings_edit.Location = new System.Drawing.Point(633, 140);
            this.settings_edit.Margin = new System.Windows.Forms.Padding(0);
            this.settings_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.settings_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.settings_edit.Name = "settings_edit";
            this.settings_edit.ReadOnly = false;
            this.settings_edit.Ripple = true;
            this.settings_edit.Size = new System.Drawing.Size(99, 37);
            this.settings_edit.TabIndex = 7;
            this.settings_edit.Text = "تعديل الإعدادات";
            this.settings_edit.UseVisualStyleBackColor = true;
            // 
            // users_edit
            // 
            this.users_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.users_edit.AutoSize = true;
            this.users_edit.Depth = 0;
            this.users_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.users_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.users_edit.Location = new System.Drawing.Point(627, 106);
            this.users_edit.Margin = new System.Windows.Forms.Padding(0);
            this.users_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.users_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.users_edit.Name = "users_edit";
            this.users_edit.ReadOnly = false;
            this.users_edit.Ripple = true;
            this.users_edit.Size = new System.Drawing.Size(105, 37);
            this.users_edit.TabIndex = 6;
            this.users_edit.Text = "تعديل المستخدمين";
            this.users_edit.UseVisualStyleBackColor = true;
            // 
            // expenses_edit
            // 
            this.expenses_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expenses_edit.AutoSize = true;
            this.expenses_edit.Depth = 0;
            this.expenses_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.expenses_edit.Location = new System.Drawing.Point(634, 78);
            this.expenses_edit.Margin = new System.Windows.Forms.Padding(0);
            this.expenses_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.expenses_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.expenses_edit.Name = "expenses_edit";
            this.expenses_edit.ReadOnly = false;
            this.expenses_edit.Ripple = true;
            this.expenses_edit.Size = new System.Drawing.Size(98, 37);
            this.expenses_edit.TabIndex = 5;
            this.expenses_edit.Text = "إضافة مصاريف";
            this.expenses_edit.UseVisualStyleBackColor = true;
            // 
            // inventory_edit
            // 
            this.inventory_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inventory_edit.AutoSize = true;
            this.inventory_edit.Depth = 0;
            this.inventory_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.inventory_edit.Location = new System.Drawing.Point(939, 140);
            this.inventory_edit.Margin = new System.Windows.Forms.Padding(0);
            this.inventory_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.inventory_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.inventory_edit.Name = "inventory_edit";
            this.inventory_edit.ReadOnly = false;
            this.inventory_edit.Ripple = true;
            this.inventory_edit.Size = new System.Drawing.Size(96, 37);
            this.inventory_edit.TabIndex = 4;
            this.inventory_edit.Text = "تعديل المستودع";
            this.inventory_edit.UseVisualStyleBackColor = true;
            // 
            // receipt_edit
            // 
            this.receipt_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receipt_edit.AutoSize = true;
            this.receipt_edit.Depth = 0;
            this.receipt_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receipt_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.receipt_edit.Location = new System.Drawing.Point(881, 106);
            this.receipt_edit.Margin = new System.Windows.Forms.Padding(0);
            this.receipt_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.receipt_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.receipt_edit.Name = "receipt_edit";
            this.receipt_edit.ReadOnly = false;
            this.receipt_edit.Ripple = true;
            this.receipt_edit.Size = new System.Drawing.Size(154, 37);
            this.receipt_edit.TabIndex = 3;
            this.receipt_edit.Text = "تعديل الفواتير و جرد المبيعات";
            this.receipt_edit.UseVisualStyleBackColor = true;
            // 
            // price_edit
            // 
            this.price_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.price_edit.AutoSize = true;
            this.price_edit.Depth = 0;
            this.price_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.price_edit.Location = new System.Drawing.Point(952, 79);
            this.price_edit.Margin = new System.Windows.Forms.Padding(0);
            this.price_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.price_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.price_edit.Name = "price_edit";
            this.price_edit.ReadOnly = false;
            this.price_edit.Ripple = true;
            this.price_edit.Size = new System.Drawing.Size(83, 37);
            this.price_edit.TabIndex = 2;
            this.price_edit.Text = "تعديل السعر";
            this.price_edit.UseVisualStyleBackColor = true;
            // 
            // discount_edit
            // 
            this.discount_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discount_edit.AutoSize = true;
            this.discount_edit.Depth = 0;
            this.discount_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.discount_edit.Location = new System.Drawing.Point(928, 47);
            this.discount_edit.Margin = new System.Windows.Forms.Padding(0);
            this.discount_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.discount_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.discount_edit.Name = "discount_edit";
            this.discount_edit.ReadOnly = false;
            this.discount_edit.Ripple = true;
            this.discount_edit.Size = new System.Drawing.Size(107, 37);
            this.discount_edit.TabIndex = 1;
            this.discount_edit.Text = "إضافة الخصومات";
            this.discount_edit.UseVisualStyleBackColor = true;
            // 
            // Client_card_edit
            // 
            this.Client_card_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Client_card_edit.AutoSize = true;
            this.Client_card_edit.Depth = 0;
            this.Client_card_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Client_card_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.Client_card_edit.Location = new System.Drawing.Point(870, 19);
            this.Client_card_edit.Margin = new System.Windows.Forms.Padding(0);
            this.Client_card_edit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Client_card_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.Client_card_edit.Name = "Client_card_edit";
            this.Client_card_edit.ReadOnly = false;
            this.Client_card_edit.Ripple = true;
            this.Client_card_edit.Size = new System.Drawing.Size(165, 37);
            this.Client_card_edit.TabIndex = 0;
            this.Client_card_edit.Text = "إضافة بطاقة عميل و تعديل المواد";
            this.Client_card_edit.UseVisualStyleBackColor = true;
            // 
            // cbAdminOrNotAdd
            // 
            this.cbAdminOrNotAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAdminOrNotAdd.AutoSize = true;
            this.cbAdminOrNotAdd.Depth = 0;
            this.cbAdminOrNotAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdminOrNotAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.cbAdminOrNotAdd.Location = new System.Drawing.Point(962, 46);
            this.cbAdminOrNotAdd.Margin = new System.Windows.Forms.Padding(0);
            this.cbAdminOrNotAdd.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbAdminOrNotAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbAdminOrNotAdd.Name = "cbAdminOrNotAdd";
            this.cbAdminOrNotAdd.ReadOnly = false;
            this.cbAdminOrNotAdd.Ripple = true;
            this.cbAdminOrNotAdd.Size = new System.Drawing.Size(95, 37);
            this.cbAdminOrNotAdd.TabIndex = 3;
            this.cbAdminOrNotAdd.Text = "حساب إداري؟";
            this.cbAdminOrNotAdd.UseVisualStyleBackColor = true;
            // 
            // label75
            // 
            this.label75.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label75.AutoSize = true;
            this.label75.Depth = 0;
            this.label75.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label75.Location = new System.Drawing.Point(1174, 27);
            this.label75.MouseState = MaterialSkin.MouseState.HOVER;
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(72, 19);
            this.label75.TabIndex = 26;
            this.label75.Text = "كلمة السر الجديده";
            // 
            // txtUserPasswordAdd
            // 
            this.txtUserPasswordAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserPasswordAdd.AnimateReadOnly = false;
            this.txtUserPasswordAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserPasswordAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserPasswordAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUserPasswordAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserPasswordAdd.Depth = 0;
            this.txtUserPasswordAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPasswordAdd.HideSelection = true;
            this.txtUserPasswordAdd.LeadingIcon = null;
            this.txtUserPasswordAdd.Location = new System.Drawing.Point(1119, 54);
            this.txtUserPasswordAdd.MaxLength = 32767;
            this.txtUserPasswordAdd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUserPasswordAdd.Name = "txtUserPasswordAdd";
            this.txtUserPasswordAdd.PasswordChar = '*';
            this.txtUserPasswordAdd.PrefixSuffixText = null;
            this.txtUserPasswordAdd.ReadOnly = false;
            this.txtUserPasswordAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserPasswordAdd.SelectedText = "";
            this.txtUserPasswordAdd.SelectionLength = 0;
            this.txtUserPasswordAdd.SelectionStart = 0;
            this.txtUserPasswordAdd.ShortcutsEnabled = true;
            this.txtUserPasswordAdd.Size = new System.Drawing.Size(215, 48);
            this.txtUserPasswordAdd.TabIndex = 2;
            this.txtUserPasswordAdd.TabStop = false;
            this.txtUserPasswordAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserPasswordAdd.TrailingIcon = null;
            this.txtUserPasswordAdd.UseSystemPasswordChar = false;
            this.txtUserPasswordAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserPasswordAdd_KeyPress);
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label76.AutoSize = true;
            this.label76.Depth = 0;
            this.label76.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label76.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label76.Location = new System.Drawing.Point(1410, 26);
            this.label76.MouseState = MaterialSkin.MouseState.HOVER;
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(57, 19);
            this.label76.TabIndex = 20;
            this.label76.Text = "رمز المستخدم";
            // 
            // txtUserIDAdd
            // 
            this.txtUserIDAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserIDAdd.AnimateReadOnly = false;
            this.txtUserIDAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserIDAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserIDAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUserIDAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserIDAdd.Depth = 0;
            this.txtUserIDAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserIDAdd.HideSelection = true;
            this.txtUserIDAdd.LeadingIcon = null;
            this.txtUserIDAdd.Location = new System.Drawing.Point(1340, 54);
            this.txtUserIDAdd.MaxLength = 32767;
            this.txtUserIDAdd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUserIDAdd.Name = "txtUserIDAdd";
            this.txtUserIDAdd.PasswordChar = '\0';
            this.txtUserIDAdd.PrefixSuffixText = null;
            this.txtUserIDAdd.ReadOnly = false;
            this.txtUserIDAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserIDAdd.SelectedText = "";
            this.txtUserIDAdd.SelectionLength = 0;
            this.txtUserIDAdd.SelectionStart = 0;
            this.txtUserIDAdd.ShortcutsEnabled = true;
            this.txtUserIDAdd.Size = new System.Drawing.Size(215, 48);
            this.txtUserIDAdd.TabIndex = 1;
            this.txtUserIDAdd.TabStop = false;
            this.txtUserIDAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserIDAdd.TrailingIcon = null;
            this.txtUserIDAdd.UseSystemPasswordChar = false;
            this.txtUserIDAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserIDAdd_KeyPress);
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label77.AutoSize = true;
            this.label77.Depth = 0;
            this.label77.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label77.Location = new System.Drawing.Point(1640, 27);
            this.label77.MouseState = MaterialSkin.MouseState.HOVER;
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(54, 19);
            this.label77.TabIndex = 18;
            this.label77.Text = "إسم المستخدم";
            // 
            // txtUserNameAdd
            // 
            this.txtUserNameAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserNameAdd.AnimateReadOnly = false;
            this.txtUserNameAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserNameAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserNameAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUserNameAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserNameAdd.Depth = 0;
            this.txtUserNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNameAdd.HideSelection = true;
            this.txtUserNameAdd.LeadingIcon = null;
            this.txtUserNameAdd.Location = new System.Drawing.Point(1561, 53);
            this.txtUserNameAdd.MaxLength = 32767;
            this.txtUserNameAdd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUserNameAdd.Name = "txtUserNameAdd";
            this.txtUserNameAdd.PasswordChar = '\0';
            this.txtUserNameAdd.PrefixSuffixText = null;
            this.txtUserNameAdd.ReadOnly = false;
            this.txtUserNameAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserNameAdd.SelectedText = "";
            this.txtUserNameAdd.SelectionLength = 0;
            this.txtUserNameAdd.SelectionStart = 0;
            this.txtUserNameAdd.ShortcutsEnabled = true;
            this.txtUserNameAdd.Size = new System.Drawing.Size(207, 48);
            this.txtUserNameAdd.TabIndex = 0;
            this.txtUserNameAdd.TabStop = false;
            this.txtUserNameAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserNameAdd.TrailingIcon = null;
            this.txtUserNameAdd.UseSystemPasswordChar = false;
            this.txtUserNameAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNameAdd_KeyPress);
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.UserID,
            this.UserPassword,
            this.UserAuthority});
            this.dgvUsers.Location = new System.Drawing.Point(5, -3);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(1822, 599);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsers_RowHeaderMouseClick);
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.DataPropertyName = "User Name";
            this.UserName.HeaderText = "اسم المستخدم";
            this.UserName.Name = "UserName";
            // 
            // UserID
            // 
            this.UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserID.DataPropertyName = "User ID";
            this.UserID.HeaderText = "رمز المستخدم";
            this.UserID.Name = "UserID";
            // 
            // UserPassword
            // 
            this.UserPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserPassword.DataPropertyName = "User Password";
            this.UserPassword.HeaderText = "كلمة السر";
            this.UserPassword.Name = "UserPassword";
            // 
            // UserAuthority
            // 
            this.UserAuthority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserAuthority.DataPropertyName = "User Authority";
            this.UserAuthority.HeaderText = "الصلاحيه";
            this.UserAuthority.Name = "UserAuthority";
            // 
            // pictureBox16
            // 
            this.pictureBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox16.Image = global::PlancksoftPOS.Properties.Resources.refresh;
            this.pictureBox16.Location = new System.Drawing.Point(1833, 19);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(36, 27);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 26;
            this.pictureBox16.TabStop = false;
            this.pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click_1);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.White;
            this.Settings.Controls.Add(this.tabControl9);
            this.Settings.Location = new System.Drawing.Point(4, 34);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(1881, 951);
            this.Settings.TabIndex = 6;
            this.Settings.Text = "الإعدادات";
            // 
            // tabControl9
            // 
            this.tabControl9.Controls.Add(this.posSettings);
            this.tabControl9.Controls.Add(this.printersSettings);
            this.tabControl9.Depth = 0;
            this.tabControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl9.Location = new System.Drawing.Point(0, 0);
            this.tabControl9.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl9.Multiline = true;
            this.tabControl9.Name = "tabControl9";
            this.tabControl9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl9.RightToLeftLayout = true;
            this.tabControl9.SelectedIndex = 0;
            this.tabControl9.Size = new System.Drawing.Size(1881, 951);
            this.tabControl9.TabIndex = 7;
            // 
            // posSettings
            // 
            this.posSettings.BackColor = System.Drawing.Color.White;
            this.posSettings.Controls.Add(this.groupBox24);
            this.posSettings.Location = new System.Drawing.Point(4, 25);
            this.posSettings.Name = "posSettings";
            this.posSettings.Padding = new System.Windows.Forms.Padding(3);
            this.posSettings.Size = new System.Drawing.Size(1873, 922);
            this.posSettings.TabIndex = 0;
            this.posSettings.Text = "إعدادات البرمجية";
            // 
            // groupBox24
            // 
            this.groupBox24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox24.Controls.Add(this.switchDarkTheme);
            this.groupBox24.Controls.Add(this.button1);
            this.groupBox24.Controls.Add(this.groupBox9);
            this.groupBox24.Controls.Add(this.groupBox2);
            this.groupBox24.Controls.Add(this.groupBox5);
            this.groupBox24.Controls.Add(this.groupBox18);
            this.groupBox24.Depth = 0;
            this.groupBox24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox24.Location = new System.Drawing.Point(3, 3);
            this.groupBox24.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox24.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox24.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox24.Size = new System.Drawing.Size(1867, 916);
            this.groupBox24.TabIndex = 6;
            this.groupBox24.Text = "إعدادات البرمجيه";
            // 
            // switchDarkTheme
            // 
            this.switchDarkTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.switchDarkTheme.Controls.Add(this.AccentColorPanel);
            this.switchDarkTheme.Controls.Add(this.PrimaryLightColorPanel);
            this.switchDarkTheme.Controls.Add(this.PrimaryDarkColorPanel);
            this.switchDarkTheme.Controls.Add(this.PrimaryColorPanel);
            this.switchDarkTheme.Controls.Add(this.DarkAccentColorPanel);
            this.switchDarkTheme.Controls.Add(this.DarkPrimaryLightColorPanel);
            this.switchDarkTheme.Controls.Add(this.DarkPrimaryDarkColorPanel);
            this.switchDarkTheme.Controls.Add(this.DarkPrimaryColorPanel);
            this.switchDarkTheme.Controls.Add(this.lblLightColorScheme);
            this.switchDarkTheme.Controls.Add(this.lblDarkColorScheme);
            this.switchDarkTheme.Controls.Add(this.switchDarkBlackTextShade);
            this.switchDarkTheme.Controls.Add(this.switchBlackTextShade);
            this.switchDarkTheme.Controls.Add(this.lblColorSeperator1);
            this.switchDarkTheme.Controls.Add(this.lblTextShade);
            this.switchDarkTheme.Controls.Add(this.lblAccent);
            this.switchDarkTheme.Controls.Add(this.AccentColor);
            this.switchDarkTheme.Controls.Add(this.lblPrimaryLight);
            this.switchDarkTheme.Controls.Add(this.PrimaryLightColor);
            this.switchDarkTheme.Controls.Add(this.lblPrimaryDark);
            this.switchDarkTheme.Controls.Add(this.PrimaryDarkColor);
            this.switchDarkTheme.Controls.Add(this.lblPrimaryColor);
            this.switchDarkTheme.Controls.Add(this.PrimaryColor);
            this.switchDarkTheme.Controls.Add(this.lblColorSeperator2);
            this.switchDarkTheme.Controls.Add(this.lblDarkTextShade);
            this.switchDarkTheme.Controls.Add(this.lblDarkAccent);
            this.switchDarkTheme.Controls.Add(this.DarkAccentColor);
            this.switchDarkTheme.Controls.Add(this.lblDarkPrimaryLight);
            this.switchDarkTheme.Controls.Add(this.DarkPrimaryLightColor);
            this.switchDarkTheme.Controls.Add(this.lblDarkPrimaryDark);
            this.switchDarkTheme.Controls.Add(this.DarkPrimaryDarkColor);
            this.switchDarkTheme.Controls.Add(this.lblDarkPrimaryColor);
            this.switchDarkTheme.Controls.Add(this.DarkPrimaryColor);
            this.switchDarkTheme.Controls.Add(this.switchThemeScheme);
            this.switchDarkTheme.Depth = 0;
            this.switchDarkTheme.Dock = System.Windows.Forms.DockStyle.Right;
            this.switchDarkTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.switchDarkTheme.Location = new System.Drawing.Point(869, 66);
            this.switchDarkTheme.Margin = new System.Windows.Forms.Padding(14);
            this.switchDarkTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchDarkTheme.Name = "switchDarkTheme";
            this.switchDarkTheme.Padding = new System.Windows.Forms.Padding(14);
            this.switchDarkTheme.Size = new System.Drawing.Size(492, 800);
            this.switchDarkTheme.TabIndex = 30;
            // 
            // AccentColorPanel
            // 
            this.AccentColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AccentColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AccentColorPanel.Location = new System.Drawing.Point(456, 325);
            this.AccentColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.AccentColorPanel.Name = "AccentColorPanel";
            this.AccentColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.AccentColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AccentColorPanel.Size = new System.Drawing.Size(28, 24);
            this.AccentColorPanel.TabIndex = 101;
            this.AccentColorPanel.TabStop = false;
            // 
            // PrimaryLightColorPanel
            // 
            this.PrimaryLightColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PrimaryLightColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PrimaryLightColorPanel.Location = new System.Drawing.Point(345, 325);
            this.PrimaryLightColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.PrimaryLightColorPanel.Name = "PrimaryLightColorPanel";
            this.PrimaryLightColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.PrimaryLightColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PrimaryLightColorPanel.Size = new System.Drawing.Size(28, 24);
            this.PrimaryLightColorPanel.TabIndex = 100;
            this.PrimaryLightColorPanel.TabStop = false;
            // 
            // PrimaryDarkColorPanel
            // 
            this.PrimaryDarkColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PrimaryDarkColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PrimaryDarkColorPanel.Location = new System.Drawing.Point(226, 325);
            this.PrimaryDarkColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.PrimaryDarkColorPanel.Name = "PrimaryDarkColorPanel";
            this.PrimaryDarkColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.PrimaryDarkColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PrimaryDarkColorPanel.Size = new System.Drawing.Size(28, 24);
            this.PrimaryDarkColorPanel.TabIndex = 99;
            this.PrimaryDarkColorPanel.TabStop = false;
            // 
            // PrimaryColorPanel
            // 
            this.PrimaryColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PrimaryColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PrimaryColorPanel.Location = new System.Drawing.Point(103, 325);
            this.PrimaryColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.PrimaryColorPanel.Name = "PrimaryColorPanel";
            this.PrimaryColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.PrimaryColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PrimaryColorPanel.Size = new System.Drawing.Size(28, 24);
            this.PrimaryColorPanel.TabIndex = 98;
            this.PrimaryColorPanel.TabStop = false;
            // 
            // DarkAccentColorPanel
            // 
            this.DarkAccentColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DarkAccentColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DarkAccentColorPanel.Location = new System.Drawing.Point(458, 140);
            this.DarkAccentColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.DarkAccentColorPanel.Name = "DarkAccentColorPanel";
            this.DarkAccentColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.DarkAccentColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DarkAccentColorPanel.Size = new System.Drawing.Size(28, 24);
            this.DarkAccentColorPanel.TabIndex = 98;
            this.DarkAccentColorPanel.TabStop = false;
            // 
            // DarkPrimaryLightColorPanel
            // 
            this.DarkPrimaryLightColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DarkPrimaryLightColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DarkPrimaryLightColorPanel.Location = new System.Drawing.Point(343, 140);
            this.DarkPrimaryLightColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.DarkPrimaryLightColorPanel.Name = "DarkPrimaryLightColorPanel";
            this.DarkPrimaryLightColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.DarkPrimaryLightColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DarkPrimaryLightColorPanel.Size = new System.Drawing.Size(28, 24);
            this.DarkPrimaryLightColorPanel.TabIndex = 98;
            this.DarkPrimaryLightColorPanel.TabStop = false;
            // 
            // DarkPrimaryDarkColorPanel
            // 
            this.DarkPrimaryDarkColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DarkPrimaryDarkColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DarkPrimaryDarkColorPanel.Location = new System.Drawing.Point(223, 140);
            this.DarkPrimaryDarkColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.DarkPrimaryDarkColorPanel.Name = "DarkPrimaryDarkColorPanel";
            this.DarkPrimaryDarkColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.DarkPrimaryDarkColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DarkPrimaryDarkColorPanel.Size = new System.Drawing.Size(28, 24);
            this.DarkPrimaryDarkColorPanel.TabIndex = 98;
            this.DarkPrimaryDarkColorPanel.TabStop = false;
            // 
            // DarkPrimaryColorPanel
            // 
            this.DarkPrimaryColorPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DarkPrimaryColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DarkPrimaryColorPanel.Location = new System.Drawing.Point(103, 140);
            this.DarkPrimaryColorPanel.Margin = new System.Windows.Forms.Padding(14);
            this.DarkPrimaryColorPanel.Name = "DarkPrimaryColorPanel";
            this.DarkPrimaryColorPanel.Padding = new System.Windows.Forms.Padding(14);
            this.DarkPrimaryColorPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DarkPrimaryColorPanel.Size = new System.Drawing.Size(28, 24);
            this.DarkPrimaryColorPanel.TabIndex = 97;
            this.DarkPrimaryColorPanel.TabStop = false;
            // 
            // lblLightColorScheme
            // 
            this.lblLightColorScheme.AutoSize = true;
            this.lblLightColorScheme.Depth = 0;
            this.lblLightColorScheme.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLightColorScheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblLightColorScheme.Location = new System.Drawing.Point(214, 221);
            this.lblLightColorScheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLightColorScheme.Name = "lblLightColorScheme";
            this.lblLightColorScheme.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLightColorScheme.Size = new System.Drawing.Size(81, 19);
            this.lblLightColorScheme.TabIndex = 58;
            this.lblLightColorScheme.Text = "الألوان للشكل الفاتج";
            // 
            // lblDarkColorScheme
            // 
            this.lblDarkColorScheme.AutoSize = true;
            this.lblDarkColorScheme.Depth = 0;
            this.lblDarkColorScheme.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkColorScheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblDarkColorScheme.Location = new System.Drawing.Point(214, 45);
            this.lblDarkColorScheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkColorScheme.Name = "lblDarkColorScheme";
            this.lblDarkColorScheme.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDarkColorScheme.Size = new System.Drawing.Size(83, 19);
            this.lblDarkColorScheme.TabIndex = 57;
            this.lblDarkColorScheme.Text = "الألوان للشكل المظلم";
            // 
            // switchDarkBlackTextShade
            // 
            this.switchDarkBlackTextShade.AutoSize = true;
            this.switchDarkBlackTextShade.Depth = 0;
            this.switchDarkBlackTextShade.Location = new System.Drawing.Point(17, 186);
            this.switchDarkBlackTextShade.Margin = new System.Windows.Forms.Padding(0);
            this.switchDarkBlackTextShade.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchDarkBlackTextShade.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchDarkBlackTextShade.Name = "switchDarkBlackTextShade";
            this.switchDarkBlackTextShade.Ripple = true;
            this.switchDarkBlackTextShade.Size = new System.Drawing.Size(77, 37);
            this.switchDarkBlackTextShade.TabIndex = 56;
            this.switchDarkBlackTextShade.Text = "أسود";
            this.switchDarkBlackTextShade.UseVisualStyleBackColor = true;
            // 
            // switchBlackTextShade
            // 
            this.switchBlackTextShade.AutoSize = true;
            this.switchBlackTextShade.Depth = 0;
            this.switchBlackTextShade.Location = new System.Drawing.Point(14, 376);
            this.switchBlackTextShade.Margin = new System.Windows.Forms.Padding(0);
            this.switchBlackTextShade.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchBlackTextShade.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchBlackTextShade.Name = "switchBlackTextShade";
            this.switchBlackTextShade.Ripple = true;
            this.switchBlackTextShade.Size = new System.Drawing.Size(77, 37);
            this.switchBlackTextShade.TabIndex = 55;
            this.switchBlackTextShade.Text = "أسود";
            this.switchBlackTextShade.UseVisualStyleBackColor = true;
            // 
            // lblColorSeperator1
            // 
            this.lblColorSeperator1.AutoSize = true;
            this.lblColorSeperator1.Depth = 0;
            this.lblColorSeperator1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblColorSeperator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblColorSeperator1.Location = new System.Drawing.Point(3, 64);
            this.lblColorSeperator1.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblColorSeperator1.Name = "lblColorSeperator1";
            this.lblColorSeperator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblColorSeperator1.Size = new System.Drawing.Size(484, 19);
            this.lblColorSeperator1.TabIndex = 54;
            this.lblColorSeperator1.Text = "_____________________________________________________________________";
            // 
            // lblTextShade
            // 
            this.lblTextShade.AutoSize = true;
            this.lblTextShade.Depth = 0;
            this.lblTextShade.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTextShade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblTextShade.Location = new System.Drawing.Point(14, 352);
            this.lblTextShade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTextShade.Name = "lblTextShade";
            this.lblTextShade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTextShade.Size = new System.Drawing.Size(54, 19);
            this.lblTextShade.TabIndex = 53;
            this.lblTextShade.Text = "ظل النصوص";
            // 
            // lblAccent
            // 
            this.lblAccent.AutoSize = true;
            this.lblAccent.Depth = 0;
            this.lblAccent.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAccent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblAccent.Location = new System.Drawing.Point(349, 279);
            this.lblAccent.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAccent.Name = "lblAccent";
            this.lblAccent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccent.Size = new System.Drawing.Size(27, 19);
            this.lblAccent.TabIndex = 51;
            this.lblAccent.Text = "التمييز";
            // 
            // AccentColor
            // 
            this.AccentColor.AnimateReadOnly = false;
            this.AccentColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.AccentColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.AccentColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AccentColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AccentColor.Depth = 0;
            this.AccentColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccentColor.HideSelection = true;
            this.AccentColor.LeadingIcon = null;
            this.AccentColor.Location = new System.Drawing.Point(377, 301);
            this.AccentColor.MaxLength = 32767;
            this.AccentColor.MouseState = MaterialSkin.MouseState.OUT;
            this.AccentColor.Name = "AccentColor";
            this.AccentColor.PasswordChar = '\0';
            this.AccentColor.PrefixSuffixText = null;
            this.AccentColor.ReadOnly = false;
            this.AccentColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AccentColor.SelectedText = "";
            this.AccentColor.SelectionLength = 0;
            this.AccentColor.SelectionStart = 0;
            this.AccentColor.ShortcutsEnabled = true;
            this.AccentColor.Size = new System.Drawing.Size(73, 48);
            this.AccentColor.TabIndex = 50;
            this.AccentColor.TabStop = false;
            this.AccentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AccentColor.TrailingIcon = null;
            this.AccentColor.UseSystemPasswordChar = false;
            this.AccentColor.Click += new System.EventHandler(this.AccentColor_Click);
            this.AccentColor.TextChanged += new System.EventHandler(this.AccentColor_TextChanged);
            // 
            // lblPrimaryLight
            // 
            this.lblPrimaryLight.AutoSize = true;
            this.lblPrimaryLight.Depth = 0;
            this.lblPrimaryLight.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPrimaryLight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblPrimaryLight.Location = new System.Drawing.Point(235, 279);
            this.lblPrimaryLight.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrimaryLight.Name = "lblPrimaryLight";
            this.lblPrimaryLight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrimaryLight.Size = new System.Drawing.Size(62, 19);
            this.lblPrimaryLight.TabIndex = 49;
            this.lblPrimaryLight.Text = "الأساسي الغاتح";
            // 
            // PrimaryLightColor
            // 
            this.PrimaryLightColor.AnimateReadOnly = false;
            this.PrimaryLightColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PrimaryLightColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PrimaryLightColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PrimaryLightColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PrimaryLightColor.Depth = 0;
            this.PrimaryLightColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimaryLightColor.HideSelection = true;
            this.PrimaryLightColor.LeadingIcon = null;
            this.PrimaryLightColor.Location = new System.Drawing.Point(257, 301);
            this.PrimaryLightColor.MaxLength = 32767;
            this.PrimaryLightColor.MouseState = MaterialSkin.MouseState.OUT;
            this.PrimaryLightColor.Name = "PrimaryLightColor";
            this.PrimaryLightColor.PasswordChar = '\0';
            this.PrimaryLightColor.PrefixSuffixText = null;
            this.PrimaryLightColor.ReadOnly = false;
            this.PrimaryLightColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PrimaryLightColor.SelectedText = "";
            this.PrimaryLightColor.SelectionLength = 0;
            this.PrimaryLightColor.SelectionStart = 0;
            this.PrimaryLightColor.ShortcutsEnabled = true;
            this.PrimaryLightColor.Size = new System.Drawing.Size(80, 48);
            this.PrimaryLightColor.TabIndex = 48;
            this.PrimaryLightColor.TabStop = false;
            this.PrimaryLightColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PrimaryLightColor.TrailingIcon = null;
            this.PrimaryLightColor.UseSystemPasswordChar = false;
            this.PrimaryLightColor.Click += new System.EventHandler(this.PrimaryLightColor_Click);
            this.PrimaryLightColor.TextChanged += new System.EventHandler(this.PrimaryLightColor_TextChanged);
            // 
            // lblPrimaryDark
            // 
            this.lblPrimaryDark.AutoSize = true;
            this.lblPrimaryDark.Depth = 0;
            this.lblPrimaryDark.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPrimaryDark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblPrimaryDark.Location = new System.Drawing.Point(126, 279);
            this.lblPrimaryDark.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrimaryDark.Name = "lblPrimaryDark";
            this.lblPrimaryDark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrimaryDark.Size = new System.Drawing.Size(63, 19);
            this.lblPrimaryDark.TabIndex = 47;
            this.lblPrimaryDark.Text = "الأساسي المظلم";
            // 
            // PrimaryDarkColor
            // 
            this.PrimaryDarkColor.AnimateReadOnly = false;
            this.PrimaryDarkColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PrimaryDarkColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PrimaryDarkColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PrimaryDarkColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PrimaryDarkColor.Depth = 0;
            this.PrimaryDarkColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimaryDarkColor.HideSelection = true;
            this.PrimaryDarkColor.LeadingIcon = null;
            this.PrimaryDarkColor.Location = new System.Drawing.Point(137, 301);
            this.PrimaryDarkColor.MaxLength = 32767;
            this.PrimaryDarkColor.MouseState = MaterialSkin.MouseState.OUT;
            this.PrimaryDarkColor.Name = "PrimaryDarkColor";
            this.PrimaryDarkColor.PasswordChar = '\0';
            this.PrimaryDarkColor.PrefixSuffixText = null;
            this.PrimaryDarkColor.ReadOnly = false;
            this.PrimaryDarkColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PrimaryDarkColor.SelectedText = "";
            this.PrimaryDarkColor.SelectionLength = 0;
            this.PrimaryDarkColor.SelectionStart = 0;
            this.PrimaryDarkColor.ShortcutsEnabled = true;
            this.PrimaryDarkColor.Size = new System.Drawing.Size(83, 48);
            this.PrimaryDarkColor.TabIndex = 46;
            this.PrimaryDarkColor.TabStop = false;
            this.PrimaryDarkColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PrimaryDarkColor.TrailingIcon = null;
            this.PrimaryDarkColor.UseSystemPasswordChar = false;
            this.PrimaryDarkColor.Click += new System.EventHandler(this.PrimaryDarkColor_Click);
            this.PrimaryDarkColor.TextChanged += new System.EventHandler(this.PrimaryDarkColor_TextChanged);
            // 
            // lblPrimaryColor
            // 
            this.lblPrimaryColor.AutoSize = true;
            this.lblPrimaryColor.Depth = 0;
            this.lblPrimaryColor.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPrimaryColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblPrimaryColor.Location = new System.Drawing.Point(17, 279);
            this.lblPrimaryColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrimaryColor.Name = "lblPrimaryColor";
            this.lblPrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrimaryColor.Size = new System.Drawing.Size(35, 19);
            this.lblPrimaryColor.TabIndex = 45;
            this.lblPrimaryColor.Text = "الأساسي";
            // 
            // PrimaryColor
            // 
            this.PrimaryColor.AnimateReadOnly = false;
            this.PrimaryColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PrimaryColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PrimaryColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PrimaryColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PrimaryColor.Depth = 0;
            this.PrimaryColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimaryColor.HideSelection = true;
            this.PrimaryColor.LeadingIcon = null;
            this.PrimaryColor.Location = new System.Drawing.Point(14, 301);
            this.PrimaryColor.MaxLength = 32767;
            this.PrimaryColor.MouseState = MaterialSkin.MouseState.OUT;
            this.PrimaryColor.Name = "PrimaryColor";
            this.PrimaryColor.PasswordChar = '\0';
            this.PrimaryColor.PrefixSuffixText = null;
            this.PrimaryColor.ReadOnly = false;
            this.PrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PrimaryColor.SelectedText = "";
            this.PrimaryColor.SelectionLength = 0;
            this.PrimaryColor.SelectionStart = 0;
            this.PrimaryColor.ShortcutsEnabled = true;
            this.PrimaryColor.Size = new System.Drawing.Size(83, 48);
            this.PrimaryColor.TabIndex = 44;
            this.PrimaryColor.TabStop = false;
            this.PrimaryColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PrimaryColor.TrailingIcon = null;
            this.PrimaryColor.UseSystemPasswordChar = false;
            this.PrimaryColor.Click += new System.EventHandler(this.PrimaryColor_Click);
            this.PrimaryColor.TextChanged += new System.EventHandler(this.PrimaryColor_TextChanged);
            // 
            // lblColorSeperator2
            // 
            this.lblColorSeperator2.AutoSize = true;
            this.lblColorSeperator2.Depth = 0;
            this.lblColorSeperator2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblColorSeperator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblColorSeperator2.Location = new System.Drawing.Point(6, 240);
            this.lblColorSeperator2.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblColorSeperator2.Name = "lblColorSeperator2";
            this.lblColorSeperator2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblColorSeperator2.Size = new System.Drawing.Size(484, 19);
            this.lblColorSeperator2.TabIndex = 43;
            this.lblColorSeperator2.Text = "_____________________________________________________________________";
            // 
            // lblDarkTextShade
            // 
            this.lblDarkTextShade.AutoSize = true;
            this.lblDarkTextShade.Depth = 0;
            this.lblDarkTextShade.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkTextShade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblDarkTextShade.Location = new System.Drawing.Point(17, 167);
            this.lblDarkTextShade.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkTextShade.Name = "lblDarkTextShade";
            this.lblDarkTextShade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDarkTextShade.Size = new System.Drawing.Size(54, 19);
            this.lblDarkTextShade.TabIndex = 42;
            this.lblDarkTextShade.Text = "ظل النصوص";
            // 
            // lblDarkAccent
            // 
            this.lblDarkAccent.AutoSize = true;
            this.lblDarkAccent.Depth = 0;
            this.lblDarkAccent.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkAccent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblDarkAccent.Location = new System.Drawing.Point(344, 94);
            this.lblDarkAccent.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkAccent.Name = "lblDarkAccent";
            this.lblDarkAccent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDarkAccent.Size = new System.Drawing.Size(27, 19);
            this.lblDarkAccent.TabIndex = 40;
            this.lblDarkAccent.Text = "التمييز";
            // 
            // DarkAccentColor
            // 
            this.DarkAccentColor.AnimateReadOnly = false;
            this.DarkAccentColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.DarkAccentColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.DarkAccentColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DarkAccentColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.DarkAccentColor.Depth = 0;
            this.DarkAccentColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkAccentColor.HideSelection = true;
            this.DarkAccentColor.LeadingIcon = null;
            this.DarkAccentColor.Location = new System.Drawing.Point(377, 116);
            this.DarkAccentColor.MaxLength = 32767;
            this.DarkAccentColor.MouseState = MaterialSkin.MouseState.OUT;
            this.DarkAccentColor.Name = "DarkAccentColor";
            this.DarkAccentColor.PasswordChar = '\0';
            this.DarkAccentColor.PrefixSuffixText = null;
            this.DarkAccentColor.ReadOnly = false;
            this.DarkAccentColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DarkAccentColor.SelectedText = "";
            this.DarkAccentColor.SelectionLength = 0;
            this.DarkAccentColor.SelectionStart = 0;
            this.DarkAccentColor.ShortcutsEnabled = true;
            this.DarkAccentColor.Size = new System.Drawing.Size(75, 48);
            this.DarkAccentColor.TabIndex = 39;
            this.DarkAccentColor.TabStop = false;
            this.DarkAccentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DarkAccentColor.TrailingIcon = null;
            this.DarkAccentColor.UseSystemPasswordChar = false;
            this.DarkAccentColor.Click += new System.EventHandler(this.DarkAccentColor_Click);
            this.DarkAccentColor.TextChanged += new System.EventHandler(this.DarkAccentColor_TextChanged);
            // 
            // lblDarkPrimaryLight
            // 
            this.lblDarkPrimaryLight.AutoSize = true;
            this.lblDarkPrimaryLight.Depth = 0;
            this.lblDarkPrimaryLight.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkPrimaryLight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblDarkPrimaryLight.Location = new System.Drawing.Point(235, 94);
            this.lblDarkPrimaryLight.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkPrimaryLight.Name = "lblDarkPrimaryLight";
            this.lblDarkPrimaryLight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDarkPrimaryLight.Size = new System.Drawing.Size(62, 19);
            this.lblDarkPrimaryLight.TabIndex = 38;
            this.lblDarkPrimaryLight.Text = "الأساسي الغاتح";
            // 
            // DarkPrimaryLightColor
            // 
            this.DarkPrimaryLightColor.AnimateReadOnly = false;
            this.DarkPrimaryLightColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.DarkPrimaryLightColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.DarkPrimaryLightColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DarkPrimaryLightColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.DarkPrimaryLightColor.Depth = 0;
            this.DarkPrimaryLightColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkPrimaryLightColor.HideSelection = true;
            this.DarkPrimaryLightColor.LeadingIcon = null;
            this.DarkPrimaryLightColor.Location = new System.Drawing.Point(257, 116);
            this.DarkPrimaryLightColor.MaxLength = 32767;
            this.DarkPrimaryLightColor.MouseState = MaterialSkin.MouseState.OUT;
            this.DarkPrimaryLightColor.Name = "DarkPrimaryLightColor";
            this.DarkPrimaryLightColor.PasswordChar = '\0';
            this.DarkPrimaryLightColor.PrefixSuffixText = null;
            this.DarkPrimaryLightColor.ReadOnly = false;
            this.DarkPrimaryLightColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DarkPrimaryLightColor.SelectedText = "";
            this.DarkPrimaryLightColor.SelectionLength = 0;
            this.DarkPrimaryLightColor.SelectionStart = 0;
            this.DarkPrimaryLightColor.ShortcutsEnabled = true;
            this.DarkPrimaryLightColor.Size = new System.Drawing.Size(80, 48);
            this.DarkPrimaryLightColor.TabIndex = 37;
            this.DarkPrimaryLightColor.TabStop = false;
            this.DarkPrimaryLightColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DarkPrimaryLightColor.TrailingIcon = null;
            this.DarkPrimaryLightColor.UseSystemPasswordChar = false;
            this.DarkPrimaryLightColor.Click += new System.EventHandler(this.DarkPrimaryLightColor_Click);
            this.DarkPrimaryLightColor.TextChanged += new System.EventHandler(this.DarkPrimaryLightColor_TextChanged);
            // 
            // lblDarkPrimaryDark
            // 
            this.lblDarkPrimaryDark.AutoSize = true;
            this.lblDarkPrimaryDark.Depth = 0;
            this.lblDarkPrimaryDark.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkPrimaryDark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblDarkPrimaryDark.Location = new System.Drawing.Point(126, 94);
            this.lblDarkPrimaryDark.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkPrimaryDark.Name = "lblDarkPrimaryDark";
            this.lblDarkPrimaryDark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDarkPrimaryDark.Size = new System.Drawing.Size(63, 19);
            this.lblDarkPrimaryDark.TabIndex = 36;
            this.lblDarkPrimaryDark.Text = "الأساسي المظلم";
            // 
            // DarkPrimaryDarkColor
            // 
            this.DarkPrimaryDarkColor.AnimateReadOnly = false;
            this.DarkPrimaryDarkColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.DarkPrimaryDarkColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.DarkPrimaryDarkColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DarkPrimaryDarkColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.DarkPrimaryDarkColor.Depth = 0;
            this.DarkPrimaryDarkColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkPrimaryDarkColor.HideSelection = true;
            this.DarkPrimaryDarkColor.LeadingIcon = null;
            this.DarkPrimaryDarkColor.Location = new System.Drawing.Point(137, 116);
            this.DarkPrimaryDarkColor.MaxLength = 32767;
            this.DarkPrimaryDarkColor.MouseState = MaterialSkin.MouseState.OUT;
            this.DarkPrimaryDarkColor.Name = "DarkPrimaryDarkColor";
            this.DarkPrimaryDarkColor.PasswordChar = '\0';
            this.DarkPrimaryDarkColor.PrefixSuffixText = null;
            this.DarkPrimaryDarkColor.ReadOnly = false;
            this.DarkPrimaryDarkColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DarkPrimaryDarkColor.SelectedText = "";
            this.DarkPrimaryDarkColor.SelectionLength = 0;
            this.DarkPrimaryDarkColor.SelectionStart = 0;
            this.DarkPrimaryDarkColor.ShortcutsEnabled = true;
            this.DarkPrimaryDarkColor.Size = new System.Drawing.Size(80, 48);
            this.DarkPrimaryDarkColor.TabIndex = 35;
            this.DarkPrimaryDarkColor.TabStop = false;
            this.DarkPrimaryDarkColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DarkPrimaryDarkColor.TrailingIcon = null;
            this.DarkPrimaryDarkColor.UseSystemPasswordChar = false;
            this.DarkPrimaryDarkColor.Click += new System.EventHandler(this.DarkPrimaryDarkColor_Click);
            this.DarkPrimaryDarkColor.TextChanged += new System.EventHandler(this.DarkPrimaryDarkColor_TextChanged);
            // 
            // lblDarkPrimaryColor
            // 
            this.lblDarkPrimaryColor.AutoSize = true;
            this.lblDarkPrimaryColor.Depth = 0;
            this.lblDarkPrimaryColor.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkPrimaryColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblDarkPrimaryColor.Location = new System.Drawing.Point(17, 94);
            this.lblDarkPrimaryColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkPrimaryColor.Name = "lblDarkPrimaryColor";
            this.lblDarkPrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDarkPrimaryColor.Size = new System.Drawing.Size(35, 19);
            this.lblDarkPrimaryColor.TabIndex = 34;
            this.lblDarkPrimaryColor.Text = "الأساسي";
            // 
            // DarkPrimaryColor
            // 
            this.DarkPrimaryColor.AnimateReadOnly = false;
            this.DarkPrimaryColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.DarkPrimaryColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.DarkPrimaryColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DarkPrimaryColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.DarkPrimaryColor.Depth = 0;
            this.DarkPrimaryColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkPrimaryColor.HideSelection = true;
            this.DarkPrimaryColor.LeadingIcon = null;
            this.DarkPrimaryColor.Location = new System.Drawing.Point(14, 116);
            this.DarkPrimaryColor.MaxLength = 32767;
            this.DarkPrimaryColor.MouseState = MaterialSkin.MouseState.OUT;
            this.DarkPrimaryColor.Name = "DarkPrimaryColor";
            this.DarkPrimaryColor.PasswordChar = '\0';
            this.DarkPrimaryColor.PrefixSuffixText = null;
            this.DarkPrimaryColor.ReadOnly = false;
            this.DarkPrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DarkPrimaryColor.SelectedText = "";
            this.DarkPrimaryColor.SelectionLength = 0;
            this.DarkPrimaryColor.SelectionStart = 0;
            this.DarkPrimaryColor.ShortcutsEnabled = true;
            this.DarkPrimaryColor.Size = new System.Drawing.Size(83, 48);
            this.DarkPrimaryColor.TabIndex = 31;
            this.DarkPrimaryColor.TabStop = false;
            this.DarkPrimaryColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DarkPrimaryColor.TrailingIcon = null;
            this.DarkPrimaryColor.UseSystemPasswordChar = false;
            this.DarkPrimaryColor.Click += new System.EventHandler(this.DarkPrimaryColor_Click);
            this.DarkPrimaryColor.TextChanged += new System.EventHandler(this.DarkPrimaryColor_TextChanged);
            // 
            // switchThemeScheme
            // 
            this.switchThemeScheme.AutoSize = true;
            this.switchThemeScheme.Depth = 0;
            this.switchThemeScheme.Location = new System.Drawing.Point(14, 14);
            this.switchThemeScheme.Margin = new System.Windows.Forms.Padding(0);
            this.switchThemeScheme.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchThemeScheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchThemeScheme.Name = "switchThemeScheme";
            this.switchThemeScheme.Ripple = true;
            this.switchThemeScheme.Size = new System.Drawing.Size(110, 37);
            this.switchThemeScheme.TabIndex = 0;
            this.switchThemeScheme.Text = "الشكل المظلم";
            this.switchThemeScheme.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(650, 866);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(711, 36);
            this.button1.TabIndex = 96;
            this.button1.Text = "حفظ الإعدادات";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox9.Controls.Add(this.txtStoreAddress);
            this.groupBox9.Controls.Add(this.lblStoreAddress);
            this.groupBox9.Controls.Add(this.txtStorePhone);
            this.groupBox9.Controls.Add(this.lblStoreName);
            this.groupBox9.Controls.Add(this.txtStoreName);
            this.groupBox9.Controls.Add(this.lblStorePhone);
            this.groupBox9.Depth = 0;
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox9.Location = new System.Drawing.Point(1361, 66);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox9.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox9.Size = new System.Drawing.Size(492, 836);
            this.groupBox9.TabIndex = 35;
            this.groupBox9.Text = "الإعدادات الأساسية";
            // 
            // txtStoreAddress
            // 
            this.txtStoreAddress.AnimateReadOnly = false;
            this.txtStoreAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtStoreAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtStoreAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtStoreAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtStoreAddress.Depth = 0;
            this.txtStoreAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreAddress.HideSelection = true;
            this.txtStoreAddress.LeadingIcon = null;
            this.txtStoreAddress.Location = new System.Drawing.Point(17, 188);
            this.txtStoreAddress.MaxLength = 32767;
            this.txtStoreAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStoreAddress.Name = "txtStoreAddress";
            this.txtStoreAddress.PasswordChar = '\0';
            this.txtStoreAddress.PrefixSuffixText = null;
            this.txtStoreAddress.ReadOnly = false;
            this.txtStoreAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStoreAddress.SelectedText = "";
            this.txtStoreAddress.SelectionLength = 0;
            this.txtStoreAddress.SelectionStart = 0;
            this.txtStoreAddress.ShortcutsEnabled = true;
            this.txtStoreAddress.Size = new System.Drawing.Size(437, 48);
            this.txtStoreAddress.TabIndex = 30;
            this.txtStoreAddress.TabStop = false;
            this.txtStoreAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStoreAddress.TrailingIcon = null;
            this.txtStoreAddress.UseSystemPasswordChar = false;
            // 
            // lblStoreAddress
            // 
            this.lblStoreAddress.AutoSize = true;
            this.lblStoreAddress.Depth = 0;
            this.lblStoreAddress.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStoreAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblStoreAddress.Location = new System.Drawing.Point(17, 168);
            this.lblStoreAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStoreAddress.Name = "lblStoreAddress";
            this.lblStoreAddress.Size = new System.Drawing.Size(29, 19);
            this.lblStoreAddress.TabIndex = 31;
            this.lblStoreAddress.Text = "العنوان";
            // 
            // txtStorePhone
            // 
            this.txtStorePhone.AnimateReadOnly = false;
            this.txtStorePhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtStorePhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtStorePhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtStorePhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtStorePhone.Depth = 0;
            this.txtStorePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStorePhone.HideSelection = true;
            this.txtStorePhone.LeadingIcon = null;
            this.txtStorePhone.Location = new System.Drawing.Point(14, 117);
            this.txtStorePhone.MaxLength = 32767;
            this.txtStorePhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStorePhone.Name = "txtStorePhone";
            this.txtStorePhone.PasswordChar = '\0';
            this.txtStorePhone.PrefixSuffixText = null;
            this.txtStorePhone.ReadOnly = false;
            this.txtStorePhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStorePhone.SelectedText = "";
            this.txtStorePhone.SelectionLength = 0;
            this.txtStorePhone.SelectionStart = 0;
            this.txtStorePhone.ShortcutsEnabled = true;
            this.txtStorePhone.Size = new System.Drawing.Size(437, 48);
            this.txtStorePhone.TabIndex = 28;
            this.txtStorePhone.TabStop = false;
            this.txtStorePhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStorePhone.TrailingIcon = null;
            this.txtStorePhone.UseSystemPasswordChar = false;
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Depth = 0;
            this.lblStoreName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStoreName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblStoreName.Location = new System.Drawing.Point(14, 13);
            this.lblStoreName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(45, 19);
            this.lblStoreName.TabIndex = 3;
            this.lblStoreName.Text = "إسم المتجر";
            // 
            // txtStoreName
            // 
            this.txtStoreName.AnimateReadOnly = false;
            this.txtStoreName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtStoreName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtStoreName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtStoreName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtStoreName.Depth = 0;
            this.txtStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreName.HideSelection = true;
            this.txtStoreName.LeadingIcon = null;
            this.txtStoreName.Location = new System.Drawing.Point(14, 33);
            this.txtStoreName.MaxLength = 32767;
            this.txtStoreName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.PasswordChar = '\0';
            this.txtStoreName.PrefixSuffixText = null;
            this.txtStoreName.ReadOnly = false;
            this.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStoreName.SelectedText = "";
            this.txtStoreName.SelectionLength = 0;
            this.txtStoreName.SelectionStart = 0;
            this.txtStoreName.ShortcutsEnabled = true;
            this.txtStoreName.Size = new System.Drawing.Size(437, 48);
            this.txtStoreName.TabIndex = 0;
            this.txtStoreName.TabStop = false;
            this.txtStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStoreName.TrailingIcon = null;
            this.txtStoreName.UseSystemPasswordChar = false;
            // 
            // lblStorePhone
            // 
            this.lblStorePhone.AutoSize = true;
            this.lblStorePhone.Depth = 0;
            this.lblStorePhone.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStorePhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.lblStorePhone.Location = new System.Drawing.Point(14, 97);
            this.lblStorePhone.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStorePhone.Name = "lblStorePhone";
            this.lblStorePhone.Size = new System.Drawing.Size(43, 19);
            this.lblStorePhone.TabIndex = 29;
            this.lblStorePhone.Text = "رقم الهاتف";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.button29);
            this.groupBox2.Controls.Add(this.picLogoStore);
            this.groupBox2.Depth = 0;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(414, 66);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox2.Size = new System.Drawing.Size(236, 836);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.Text = "صورة المتجر";
            // 
            // button29
            // 
            this.button29.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button29.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button29.Depth = 0;
            this.button29.HighEmphasis = true;
            this.button29.Icon = null;
            this.button29.Location = new System.Drawing.Point(45, 217);
            this.button29.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button29.MouseState = MaterialSkin.MouseState.HOVER;
            this.button29.Name = "button29";
            this.button29.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button29.Size = new System.Drawing.Size(135, 36);
            this.button29.TabIndex = 95;
            this.button29.Text = "إعادة الصورة الأصلية";
            this.button29.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button29.UseAccentColor = false;
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // picLogoStore
            // 
            this.picLogoStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogoStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogoStore.Image = global::PlancksoftPOS.Properties.Resources.plancksoft_b_t;
            this.picLogoStore.Location = new System.Drawing.Point(14, 14);
            this.picLogoStore.Name = "picLogoStore";
            this.picLogoStore.Size = new System.Drawing.Size(208, 190);
            this.picLogoStore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoStore.TabIndex = 0;
            this.picLogoStore.TabStop = false;
            this.picLogoStore.Click += new System.EventHandler(this.picLogoStore_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox5.Controls.Add(this.label114);
            this.groupBox5.Controls.Add(this.receiptSpacingnud);
            this.groupBox5.Controls.Add(this.IncludeLogoReceipt);
            this.groupBox5.Depth = 0;
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox5.Location = new System.Drawing.Point(14, 66);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox5.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox5.Size = new System.Drawing.Size(400, 836);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.Text = "الطابعات";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Depth = 0;
            this.label114.Dock = System.Windows.Forms.DockStyle.Right;
            this.label114.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label114.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label114.Location = new System.Drawing.Point(314, 51);
            this.label114.MouseState = MaterialSkin.MouseState.HOVER;
            this.label114.Name = "label114";
            this.label114.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label114.Size = new System.Drawing.Size(72, 19);
            this.label114.TabIndex = 31;
            this.label114.Text = "عدد فراغ الفاتوره";
            // 
            // receiptSpacingnud
            // 
            this.receiptSpacingnud.Location = new System.Drawing.Point(6, 77);
            this.receiptSpacingnud.Maximum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            0});
            this.receiptSpacingnud.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.receiptSpacingnud.Name = "receiptSpacingnud";
            this.receiptSpacingnud.Size = new System.Drawing.Size(387, 22);
            this.receiptSpacingnud.TabIndex = 32;
            // 
            // IncludeLogoReceipt
            // 
            this.IncludeLogoReceipt.AutoSize = true;
            this.IncludeLogoReceipt.Depth = 0;
            this.IncludeLogoReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.IncludeLogoReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.IncludeLogoReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.IncludeLogoReceipt.Location = new System.Drawing.Point(14, 14);
            this.IncludeLogoReceipt.Margin = new System.Windows.Forms.Padding(0);
            this.IncludeLogoReceipt.MouseLocation = new System.Drawing.Point(-1, -1);
            this.IncludeLogoReceipt.MouseState = MaterialSkin.MouseState.HOVER;
            this.IncludeLogoReceipt.Name = "IncludeLogoReceipt";
            this.IncludeLogoReceipt.ReadOnly = false;
            this.IncludeLogoReceipt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IncludeLogoReceipt.Ripple = true;
            this.IncludeLogoReceipt.Size = new System.Drawing.Size(372, 37);
            this.IncludeLogoReceipt.TabIndex = 33;
            this.IncludeLogoReceipt.Text = "تضمين الشعار في الفاتوره";
            this.IncludeLogoReceipt.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox18.Controls.Add(this.nudTaxRate);
            this.groupBox18.Controls.Add(this.label78);
            this.groupBox18.Depth = 0;
            this.groupBox18.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox18.Location = new System.Drawing.Point(14, 14);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox18.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox18.Size = new System.Drawing.Size(1839, 52);
            this.groupBox18.TabIndex = 0;
            this.groupBox18.Text = "الضرائب";
            // 
            // nudTaxRate
            // 
            this.nudTaxRate.DecimalPlaces = 2;
            this.nudTaxRate.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudTaxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTaxRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.nudTaxRate.Location = new System.Drawing.Point(1503, 14);
            this.nudTaxRate.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.nudTaxRate.Name = "nudTaxRate";
            this.nudTaxRate.Size = new System.Drawing.Size(226, 20);
            this.nudTaxRate.TabIndex = 0;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Depth = 0;
            this.label78.Dock = System.Windows.Forms.DockStyle.Right;
            this.label78.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.label78.Location = new System.Drawing.Point(1729, 14);
            this.label78.MouseState = MaterialSkin.MouseState.HOVER;
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(96, 19);
            this.label78.TabIndex = 3;
            this.label78.Text = "% نسبة الضريبه بالمئه";
            // 
            // printersSettings
            // 
            this.printersSettings.BackColor = System.Drawing.Color.White;
            this.printersSettings.Controls.Add(this.flowLayoutPanel4);
            this.printersSettings.Location = new System.Drawing.Point(4, 25);
            this.printersSettings.Name = "printersSettings";
            this.printersSettings.Padding = new System.Windows.Forms.Padding(3);
            this.printersSettings.Size = new System.Drawing.Size(1873, 922);
            this.printersSettings.TabIndex = 1;
            this.printersSettings.Text = "الطابعات";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.MinimumSize = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1867, 916);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // Retrievals
            // 
            this.Retrievals.BackColor = System.Drawing.Color.White;
            this.Retrievals.Controls.Add(this.groupBox47);
            this.Retrievals.Location = new System.Drawing.Point(4, 34);
            this.Retrievals.Name = "Retrievals";
            this.Retrievals.Size = new System.Drawing.Size(1881, 951);
            this.Retrievals.TabIndex = 11;
            this.Retrievals.Text = "المرجعات";
            // 
            // groupBox47
            // 
            this.groupBox47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox47.Controls.Add(this.dgvReturnedItems);
            this.groupBox47.Controls.Add(this.pictureBox49);
            this.groupBox47.Depth = 0;
            this.groupBox47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox47.Location = new System.Drawing.Point(0, 0);
            this.groupBox47.Margin = new System.Windows.Forms.Padding(14);
            this.groupBox47.MouseState = MaterialSkin.MouseState.HOVER;
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Padding = new System.Windows.Forms.Padding(14);
            this.groupBox47.Size = new System.Drawing.Size(1881, 951);
            this.groupBox47.TabIndex = 3;
            this.groupBox47.Text = "جدول المرجعات";
            // 
            // dgvReturnedItems
            // 
            this.dgvReturnedItems.AllowUserToAddRows = false;
            this.dgvReturnedItems.AllowUserToDeleteRows = false;
            this.dgvReturnedItems.AllowUserToOrderColumns = true;
            this.dgvReturnedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturnedItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvReturnedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnedItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn54,
            this.dataGridViewTextBoxColumn55,
            this.Column9,
            this.dataGridViewTextBoxColumn52,
            this.dataGridViewTextBoxColumn51,
            this.dataGridViewTextBoxColumn57});
            this.dgvReturnedItems.Location = new System.Drawing.Point(10, 20);
            this.dgvReturnedItems.Name = "dgvReturnedItems";
            this.dgvReturnedItems.ReadOnly = true;
            this.dgvReturnedItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvReturnedItems.Size = new System.Drawing.Size(1775, 928);
            this.dgvReturnedItems.TabIndex = 34;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn54.DataPropertyName = "Transaction ID";
            this.dataGridViewTextBoxColumn54.HeaderText = "رقم السند";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn55.DataPropertyName = "Cashier Name";
            this.dataGridViewTextBoxColumn55.HeaderText = "اسم الكاشير";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "Bill ID";
            this.Column9.HeaderText = "رقم الفاتورة";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn52.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn52.HeaderText = "اسم الماده";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn51.DataPropertyName = "Item BarCode";
            this.dataGridViewTextBoxColumn51.HeaderText = "باركود الماده";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn57.DataPropertyName = "Item Quantity";
            this.dataGridViewTextBoxColumn57.HeaderText = "عدد القطع المرجعه";
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.ReadOnly = true;
            // 
            // pictureBox49
            // 
            this.pictureBox49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox49.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox49.Image = global::PlancksoftPOS.Properties.Resources.BtnPrint;
            this.pictureBox49.Location = new System.Drawing.Point(1788, 21);
            this.pictureBox49.Name = "pictureBox49";
            this.pictureBox49.Size = new System.Drawing.Size(95, 105);
            this.pictureBox49.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox49.TabIndex = 32;
            this.pictureBox49.TabStop = false;
            this.pictureBox49.Click += new System.EventHandler(this.pictureBox49_Click);
            // 
            // pnlActionMenu
            // 
            this.pnlActionMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlActionMenu.Controls.Add(this.btnPay);
            this.pnlActionMenu.Controls.Add(this.btnClientCard);
            this.pnlActionMenu.Controls.Add(this.btnNewInvoice);
            this.pnlActionMenu.Controls.Add(this.btnDiscounts);
            this.pnlActionMenu.Controls.Add(this.btnOpenCashDrawer);
            this.pnlActionMenu.Controls.Add(this.btnEditTotalPrice);
            this.pnlActionMenu.Controls.Add(this.btnItemLookup);
            this.pnlActionMenu.Controls.Add(this.btnPreviousBill);
            this.pnlActionMenu.Controls.Add(this.btnNextBill);
            this.pnlActionMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlActionMenu.Depth = 0;
            this.pnlActionMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlActionMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlActionMenu.Location = new System.Drawing.Point(3, 88);
            this.pnlActionMenu.Margin = new System.Windows.Forms.Padding(14);
            this.pnlActionMenu.MaximumSize = new System.Drawing.Size(270, 990);
            this.pnlActionMenu.MinimumSize = new System.Drawing.Size(10, 990);
            this.pnlActionMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlActionMenu.Name = "pnlActionMenu";
            this.pnlActionMenu.Padding = new System.Windows.Forms.Padding(14);
            this.pnlActionMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlActionMenu.Size = new System.Drawing.Size(10, 990);
            this.pnlActionMenu.TabIndex = 44;
            this.pnlActionMenu.Click += new System.EventHandler(this.pnlActionMenu_Click);
            // 
            // btnPay
            // 
            this.btnPay.AutoSize = false;
            this.btnPay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPay.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPay.Depth = 0;
            this.btnPay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPay.HighEmphasis = true;
            this.btnPay.Icon = null;
            this.btnPay.Location = new System.Drawing.Point(14, 302);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPay.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPay.Name = "btnPay";
            this.btnPay.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPay.Size = new System.Drawing.Size(0, 36);
            this.btnPay.TabIndex = 48;
            this.btnPay.Text = "الدفع";
            this.btnPay.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPay.UseAccentColor = false;
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // btnClientCard
            // 
            this.btnClientCard.AutoSize = false;
            this.btnClientCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClientCard.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClientCard.Depth = 0;
            this.btnClientCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientCard.HighEmphasis = true;
            this.btnClientCard.Icon = null;
            this.btnClientCard.Location = new System.Drawing.Point(14, 266);
            this.btnClientCard.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClientCard.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClientCard.Name = "btnClientCard";
            this.btnClientCard.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClientCard.Size = new System.Drawing.Size(0, 36);
            this.btnClientCard.TabIndex = 49;
            this.btnClientCard.Text = "بطافة العميل";
            this.btnClientCard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClientCard.UseAccentColor = false;
            this.btnClientCard.UseVisualStyleBackColor = true;
            this.btnClientCard.Click += new System.EventHandler(this.pictureBox25_Click);
            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.AutoSize = false;
            this.btnNewInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewInvoice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNewInvoice.Depth = 0;
            this.btnNewInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewInvoice.HighEmphasis = true;
            this.btnNewInvoice.Icon = null;
            this.btnNewInvoice.Location = new System.Drawing.Point(14, 230);
            this.btnNewInvoice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNewInvoice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNewInvoice.Size = new System.Drawing.Size(0, 36);
            this.btnNewInvoice.TabIndex = 50;
            this.btnNewInvoice.Text = "فاتوره جديده";
            this.btnNewInvoice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNewInvoice.UseAccentColor = false;
            this.btnNewInvoice.UseVisualStyleBackColor = true;
            this.btnNewInvoice.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.AutoSize = false;
            this.btnDiscounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDiscounts.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDiscounts.Depth = 0;
            this.btnDiscounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiscounts.HighEmphasis = true;
            this.btnDiscounts.Icon = null;
            this.btnDiscounts.Location = new System.Drawing.Point(14, 194);
            this.btnDiscounts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDiscounts.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDiscounts.Size = new System.Drawing.Size(0, 36);
            this.btnDiscounts.TabIndex = 51;
            this.btnDiscounts.Text = "الخصومات";
            this.btnDiscounts.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDiscounts.UseAccentColor = false;
            this.btnDiscounts.UseVisualStyleBackColor = true;
            this.btnDiscounts.Click += new System.EventHandler(this.pictureBox11_Click);
            // 
            // btnOpenCashDrawer
            // 
            this.btnOpenCashDrawer.AutoSize = false;
            this.btnOpenCashDrawer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenCashDrawer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOpenCashDrawer.Depth = 0;
            this.btnOpenCashDrawer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenCashDrawer.HighEmphasis = true;
            this.btnOpenCashDrawer.Icon = null;
            this.btnOpenCashDrawer.Location = new System.Drawing.Point(14, 158);
            this.btnOpenCashDrawer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOpenCashDrawer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenCashDrawer.Name = "btnOpenCashDrawer";
            this.btnOpenCashDrawer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOpenCashDrawer.Size = new System.Drawing.Size(0, 36);
            this.btnOpenCashDrawer.TabIndex = 52;
            this.btnOpenCashDrawer.Text = "فتح درج الكاش";
            this.btnOpenCashDrawer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOpenCashDrawer.UseAccentColor = false;
            this.btnOpenCashDrawer.UseVisualStyleBackColor = true;
            this.btnOpenCashDrawer.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnEditTotalPrice
            // 
            this.btnEditTotalPrice.AutoSize = false;
            this.btnEditTotalPrice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditTotalPrice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditTotalPrice.Depth = 0;
            this.btnEditTotalPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditTotalPrice.HighEmphasis = true;
            this.btnEditTotalPrice.Icon = null;
            this.btnEditTotalPrice.Location = new System.Drawing.Point(14, 122);
            this.btnEditTotalPrice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditTotalPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditTotalPrice.Name = "btnEditTotalPrice";
            this.btnEditTotalPrice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditTotalPrice.Size = new System.Drawing.Size(0, 36);
            this.btnEditTotalPrice.TabIndex = 53;
            this.btnEditTotalPrice.Text = "تعديل سعر الفاتوره";
            this.btnEditTotalPrice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditTotalPrice.UseAccentColor = false;
            this.btnEditTotalPrice.UseVisualStyleBackColor = true;
            this.btnEditTotalPrice.Click += new System.EventHandler(this.pictureBox26_Click);
            // 
            // btnItemLookup
            // 
            this.btnItemLookup.AutoSize = false;
            this.btnItemLookup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItemLookup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnItemLookup.Depth = 0;
            this.btnItemLookup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItemLookup.HighEmphasis = true;
            this.btnItemLookup.Icon = null;
            this.btnItemLookup.Location = new System.Drawing.Point(14, 86);
            this.btnItemLookup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnItemLookup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItemLookup.Name = "btnItemLookup";
            this.btnItemLookup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnItemLookup.Size = new System.Drawing.Size(0, 36);
            this.btnItemLookup.TabIndex = 54;
            this.btnItemLookup.Text = "البحث عن ماده";
            this.btnItemLookup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnItemLookup.UseAccentColor = false;
            this.btnItemLookup.UseVisualStyleBackColor = true;
            this.btnItemLookup.Click += new System.EventHandler(this.pictureBox37_Click);
            // 
            // btnPreviousBill
            // 
            this.btnPreviousBill.AutoSize = false;
            this.btnPreviousBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviousBill.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPreviousBill.Depth = 0;
            this.btnPreviousBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPreviousBill.HighEmphasis = true;
            this.btnPreviousBill.Icon = null;
            this.btnPreviousBill.Location = new System.Drawing.Point(14, 50);
            this.btnPreviousBill.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreviousBill.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousBill.Name = "btnPreviousBill";
            this.btnPreviousBill.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPreviousBill.Size = new System.Drawing.Size(0, 36);
            this.btnPreviousBill.TabIndex = 56;
            this.btnPreviousBill.Text = "فاتوره سابقه";
            this.btnPreviousBill.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviousBill.UseAccentColor = false;
            this.btnPreviousBill.UseVisualStyleBackColor = true;
            this.btnPreviousBill.Click += new System.EventHandler(this.pictureBox13_Click);
            // 
            // btnNextBill
            // 
            this.btnNextBill.AutoSize = false;
            this.btnNextBill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextBill.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNextBill.Depth = 0;
            this.btnNextBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNextBill.HighEmphasis = true;
            this.btnNextBill.Icon = null;
            this.btnNextBill.Location = new System.Drawing.Point(14, 14);
            this.btnNextBill.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNextBill.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextBill.Name = "btnNextBill";
            this.btnNextBill.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNextBill.Size = new System.Drawing.Size(0, 36);
            this.btnNextBill.TabIndex = 55;
            this.btnNextBill.Text = "فاتوره تاليه";
            this.btnNextBill.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNextBill.UseAccentColor = false;
            this.btnNextBill.UseVisualStyleBackColor = true;
            this.btnNextBill.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenu.Controls.Add(this.materialDivider4);
            this.pnlMenu.Controls.Add(this.materialDivider3);
            this.pnlMenu.Controls.Add(this.materialDivider2);
            this.pnlMenu.Controls.Add(this.materialDivider1);
            this.pnlMenu.Controls.Add(this.btnMenuRefunds);
            this.pnlMenu.Controls.Add(this.pnlMenuSettingsSub);
            this.pnlMenu.Controls.Add(this.btnMenuSettings);
            this.pnlMenu.Controls.Add(this.btnMenuUsers);
            this.pnlMenu.Controls.Add(this.pnlMenuTaxesSub);
            this.pnlMenu.Controls.Add(this.btnMenuTaxes);
            this.pnlMenu.Controls.Add(this.btnMenuAlerts);
            this.pnlMenu.Controls.Add(this.pnlMenuClientAffairsSub);
            this.pnlMenu.Controls.Add(this.btnMenuClientsVendors);
            this.pnlMenu.Controls.Add(this.pnlMenuEmployeesAffairsSub);
            this.pnlMenu.Controls.Add(this.btnMenuEmployeesAffairs);
            this.pnlMenu.Controls.Add(this.btnMenuIncomingOutgoing);
            this.pnlMenu.Controls.Add(this.pnlMenuExpensesSub);
            this.pnlMenu.Controls.Add(this.btnMenuExpenses);
            this.pnlMenu.Controls.Add(this.pnlMenuInventorySub);
            this.pnlMenu.Controls.Add(this.btnMenuInventory);
            this.pnlMenu.Controls.Add(this.pnlMenuSalesSub);
            this.pnlMenu.Controls.Add(this.btnHamburger);
            this.pnlMenu.Controls.Add(this.btnMenuSales);
            this.pnlMenu.Controls.Add(this.btnMenuCash);
            this.pnlMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenu.Depth = 0;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenu.Location = new System.Drawing.Point(1902, 88);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenu.MaximumSize = new System.Drawing.Size(250, 990);
            this.pnlMenu.MinimumSize = new System.Drawing.Size(15, 990);
            this.pnlMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenu.Size = new System.Drawing.Size(15, 990);
            this.pnlMenu.TabIndex = 41;
            this.pnlMenu.Click += new System.EventHandler(this.pnlMenu_Click);
            // 
            // materialDivider4
            // 
            this.materialDivider4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider4.Depth = 0;
            this.materialDivider4.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialDivider4.Location = new System.Drawing.Point(14, 585);
            this.materialDivider4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider4.Name = "materialDivider4";
            this.materialDivider4.Size = new System.Drawing.Size(0, 23);
            this.materialDivider4.TabIndex = 68;
            this.materialDivider4.Text = "materialDivider4";
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialDivider3.Location = new System.Drawing.Point(14, 562);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Size = new System.Drawing.Size(0, 23);
            this.materialDivider3.TabIndex = 67;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialDivider2.Location = new System.Drawing.Point(14, 539);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(0, 23);
            this.materialDivider2.TabIndex = 66;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialDivider1.Location = new System.Drawing.Point(14, 516);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(0, 23);
            this.materialDivider1.TabIndex = 65;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // btnMenuRefunds
            // 
            this.btnMenuRefunds.AutoSize = false;
            this.btnMenuRefunds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuRefunds.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuRefunds.Depth = 0;
            this.btnMenuRefunds.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuRefunds.HighEmphasis = true;
            this.btnMenuRefunds.Icon = null;
            this.btnMenuRefunds.Location = new System.Drawing.Point(14, 480);
            this.btnMenuRefunds.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuRefunds.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuRefunds.Name = "btnMenuRefunds";
            this.btnMenuRefunds.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuRefunds.Size = new System.Drawing.Size(0, 36);
            this.btnMenuRefunds.TabIndex = 64;
            this.btnMenuRefunds.Text = "المرجعات";
            this.btnMenuRefunds.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuRefunds.UseAccentColor = false;
            this.btnMenuRefunds.UseVisualStyleBackColor = true;
            this.btnMenuRefunds.Click += new System.EventHandler(this.btnMenuRefunds_Click);
            // 
            // pnlMenuSettingsSub
            // 
            this.pnlMenuSettingsSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuSettingsSub.Controls.Add(this.btnMenuSettingsSubPrinterSettings);
            this.pnlMenuSettingsSub.Controls.Add(this.btnMenuSettingsSubPOSSettings);
            this.pnlMenuSettingsSub.Depth = 0;
            this.pnlMenuSettingsSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuSettingsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuSettingsSub.Location = new System.Drawing.Point(14, 470);
            this.pnlMenuSettingsSub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuSettingsSub.MaximumSize = new System.Drawing.Size(222, 100);
            this.pnlMenuSettingsSub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuSettingsSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuSettingsSub.Name = "pnlMenuSettingsSub";
            this.pnlMenuSettingsSub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuSettingsSub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuSettingsSub.TabIndex = 63;
            // 
            // btnMenuSettingsSubPrinterSettings
            // 
            this.btnMenuSettingsSubPrinterSettings.AutoSize = false;
            this.btnMenuSettingsSubPrinterSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSettingsSubPrinterSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSettingsSubPrinterSettings.Depth = 0;
            this.btnMenuSettingsSubPrinterSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSettingsSubPrinterSettings.HighEmphasis = true;
            this.btnMenuSettingsSubPrinterSettings.Icon = null;
            this.btnMenuSettingsSubPrinterSettings.Location = new System.Drawing.Point(14, 50);
            this.btnMenuSettingsSubPrinterSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSettingsSubPrinterSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSettingsSubPrinterSettings.Name = "btnMenuSettingsSubPrinterSettings";
            this.btnMenuSettingsSubPrinterSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSettingsSubPrinterSettings.Size = new System.Drawing.Size(194, 36);
            this.btnMenuSettingsSubPrinterSettings.TabIndex = 50;
            this.btnMenuSettingsSubPrinterSettings.Text = "إعدادات الطابعات";
            this.btnMenuSettingsSubPrinterSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSettingsSubPrinterSettings.UseAccentColor = false;
            this.btnMenuSettingsSubPrinterSettings.UseVisualStyleBackColor = true;
            this.btnMenuSettingsSubPrinterSettings.Click += new System.EventHandler(this.btnMenuSettingsSubPrinterSettings_Click);
            // 
            // btnMenuSettingsSubPOSSettings
            // 
            this.btnMenuSettingsSubPOSSettings.AutoSize = false;
            this.btnMenuSettingsSubPOSSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSettingsSubPOSSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSettingsSubPOSSettings.Depth = 0;
            this.btnMenuSettingsSubPOSSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSettingsSubPOSSettings.HighEmphasis = true;
            this.btnMenuSettingsSubPOSSettings.Icon = null;
            this.btnMenuSettingsSubPOSSettings.Location = new System.Drawing.Point(14, 14);
            this.btnMenuSettingsSubPOSSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSettingsSubPOSSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSettingsSubPOSSettings.Name = "btnMenuSettingsSubPOSSettings";
            this.btnMenuSettingsSubPOSSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSettingsSubPOSSettings.Size = new System.Drawing.Size(194, 36);
            this.btnMenuSettingsSubPOSSettings.TabIndex = 49;
            this.btnMenuSettingsSubPOSSettings.Text = "إعدادات البرمجية";
            this.btnMenuSettingsSubPOSSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSettingsSubPOSSettings.UseAccentColor = false;
            this.btnMenuSettingsSubPOSSettings.UseVisualStyleBackColor = true;
            this.btnMenuSettingsSubPOSSettings.Click += new System.EventHandler(this.btnMenuSettingsSubPOSSettings_Click);
            // 
            // btnMenuSettings
            // 
            this.btnMenuSettings.AutoSize = false;
            this.btnMenuSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSettings.Depth = 0;
            this.btnMenuSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSettings.HighEmphasis = true;
            this.btnMenuSettings.Icon = null;
            this.btnMenuSettings.Location = new System.Drawing.Point(14, 434);
            this.btnMenuSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSettings.Name = "btnMenuSettings";
            this.btnMenuSettings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSettings.Size = new System.Drawing.Size(0, 36);
            this.btnMenuSettings.TabIndex = 62;
            this.btnMenuSettings.Text = "الإعدادات";
            this.btnMenuSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSettings.UseAccentColor = false;
            this.btnMenuSettings.UseVisualStyleBackColor = true;
            this.btnMenuSettings.Click += new System.EventHandler(this.btnMenuSettings_Click);
            // 
            // btnMenuUsers
            // 
            this.btnMenuUsers.AutoSize = false;
            this.btnMenuUsers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuUsers.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuUsers.Depth = 0;
            this.btnMenuUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuUsers.HighEmphasis = true;
            this.btnMenuUsers.Icon = null;
            this.btnMenuUsers.Location = new System.Drawing.Point(14, 398);
            this.btnMenuUsers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuUsers.Name = "btnMenuUsers";
            this.btnMenuUsers.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuUsers.Size = new System.Drawing.Size(0, 36);
            this.btnMenuUsers.TabIndex = 61;
            this.btnMenuUsers.Text = "المستخدمين";
            this.btnMenuUsers.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuUsers.UseAccentColor = false;
            this.btnMenuUsers.UseVisualStyleBackColor = true;
            this.btnMenuUsers.Click += new System.EventHandler(this.btnMenuUsers_Click);
            // 
            // pnlMenuTaxesSub
            // 
            this.pnlMenuTaxesSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuTaxesSub.Controls.Add(this.btnMenuTaxesSubTaxZReport);
            this.pnlMenuTaxesSub.Depth = 0;
            this.pnlMenuTaxesSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuTaxesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuTaxesSub.Location = new System.Drawing.Point(14, 388);
            this.pnlMenuTaxesSub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuTaxesSub.MaximumSize = new System.Drawing.Size(222, 60);
            this.pnlMenuTaxesSub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuTaxesSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuTaxesSub.Name = "pnlMenuTaxesSub";
            this.pnlMenuTaxesSub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuTaxesSub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuTaxesSub.TabIndex = 60;
            // 
            // btnMenuTaxesSubTaxZReport
            // 
            this.btnMenuTaxesSubTaxZReport.AutoSize = false;
            this.btnMenuTaxesSubTaxZReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuTaxesSubTaxZReport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuTaxesSubTaxZReport.Depth = 0;
            this.btnMenuTaxesSubTaxZReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuTaxesSubTaxZReport.HighEmphasis = true;
            this.btnMenuTaxesSubTaxZReport.Icon = null;
            this.btnMenuTaxesSubTaxZReport.Location = new System.Drawing.Point(14, 14);
            this.btnMenuTaxesSubTaxZReport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuTaxesSubTaxZReport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuTaxesSubTaxZReport.Name = "btnMenuTaxesSubTaxZReport";
            this.btnMenuTaxesSubTaxZReport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuTaxesSubTaxZReport.Size = new System.Drawing.Size(194, 36);
            this.btnMenuTaxesSubTaxZReport.TabIndex = 49;
            this.btnMenuTaxesSubTaxZReport.Text = "تقرير الضريبه Z";
            this.btnMenuTaxesSubTaxZReport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuTaxesSubTaxZReport.UseAccentColor = false;
            this.btnMenuTaxesSubTaxZReport.UseVisualStyleBackColor = true;
            this.btnMenuTaxesSubTaxZReport.Click += new System.EventHandler(this.btnMenuTaxesSubTaxZReport_Click);
            // 
            // btnMenuTaxes
            // 
            this.btnMenuTaxes.AutoSize = false;
            this.btnMenuTaxes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuTaxes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuTaxes.Depth = 0;
            this.btnMenuTaxes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuTaxes.HighEmphasis = true;
            this.btnMenuTaxes.Icon = null;
            this.btnMenuTaxes.Location = new System.Drawing.Point(14, 352);
            this.btnMenuTaxes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuTaxes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuTaxes.Name = "btnMenuTaxes";
            this.btnMenuTaxes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuTaxes.Size = new System.Drawing.Size(0, 36);
            this.btnMenuTaxes.TabIndex = 59;
            this.btnMenuTaxes.Text = "الضريبه";
            this.btnMenuTaxes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuTaxes.UseAccentColor = false;
            this.btnMenuTaxes.UseVisualStyleBackColor = true;
            this.btnMenuTaxes.Click += new System.EventHandler(this.btnMenuTaxes_Click);
            // 
            // btnMenuAlerts
            // 
            this.btnMenuAlerts.AutoSize = false;
            this.btnMenuAlerts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuAlerts.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuAlerts.Depth = 0;
            this.btnMenuAlerts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAlerts.HighEmphasis = true;
            this.btnMenuAlerts.Icon = null;
            this.btnMenuAlerts.Location = new System.Drawing.Point(14, 316);
            this.btnMenuAlerts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuAlerts.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuAlerts.Name = "btnMenuAlerts";
            this.btnMenuAlerts.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuAlerts.Size = new System.Drawing.Size(0, 36);
            this.btnMenuAlerts.TabIndex = 58;
            this.btnMenuAlerts.Text = "التنبيهات";
            this.btnMenuAlerts.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuAlerts.UseAccentColor = false;
            this.btnMenuAlerts.UseVisualStyleBackColor = true;
            this.btnMenuAlerts.Click += new System.EventHandler(this.btnMenuAlerts_Click);
            // 
            // pnlMenuClientAffairsSub
            // 
            this.pnlMenuClientAffairsSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuClientAffairsSub.Controls.Add(this.btnMenuClientsVendorsSubVendorItemsDefinitions);
            this.pnlMenuClientAffairsSub.Controls.Add(this.btnMenuClientsVendorsSubVendorBalanceCheck);
            this.pnlMenuClientAffairsSub.Controls.Add(this.btnMenuClientsVendorsSubVendorsDefinitions);
            this.pnlMenuClientAffairsSub.Controls.Add(this.btnMenuClientsVendorsSubClientsBalanceCheck);
            this.pnlMenuClientAffairsSub.Controls.Add(this.btnMenuClientsVendorsSubClientsDefinitions);
            this.pnlMenuClientAffairsSub.Depth = 0;
            this.pnlMenuClientAffairsSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuClientAffairsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuClientAffairsSub.Location = new System.Drawing.Point(14, 306);
            this.pnlMenuClientAffairsSub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuClientAffairsSub.MaximumSize = new System.Drawing.Size(222, 210);
            this.pnlMenuClientAffairsSub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuClientAffairsSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuClientAffairsSub.Name = "pnlMenuClientAffairsSub";
            this.pnlMenuClientAffairsSub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuClientAffairsSub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuClientAffairsSub.TabIndex = 57;
            // 
            // btnMenuClientsVendorsSubVendorItemsDefinitions
            // 
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.AutoSize = false;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Depth = 0;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Enabled = false;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.HighEmphasis = true;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Icon = null;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Location = new System.Drawing.Point(14, 158);
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Name = "btnMenuClientsVendorsSubVendorItemsDefinitions";
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Size = new System.Drawing.Size(194, 36);
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.TabIndex = 53;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Text = "تعريف مواد العميل";
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.UseAccentColor = false;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.UseVisualStyleBackColor = true;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Visible = false;
            this.btnMenuClientsVendorsSubVendorItemsDefinitions.Click += new System.EventHandler(this.btnMenuClientsVendorsSubVendoItemsDefinitions_Click);
            // 
            // btnMenuClientsVendorsSubVendorBalanceCheck
            // 
            this.btnMenuClientsVendorsSubVendorBalanceCheck.AutoSize = false;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Depth = 0;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.HighEmphasis = true;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Icon = null;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Location = new System.Drawing.Point(14, 122);
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuClientsVendorsSubVendorBalanceCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Name = "btnMenuClientsVendorsSubVendorBalanceCheck";
            this.btnMenuClientsVendorsSubVendorBalanceCheck.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Size = new System.Drawing.Size(194, 36);
            this.btnMenuClientsVendorsSubVendorBalanceCheck.TabIndex = 52;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Text = "كشف حساب مورد";
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.UseAccentColor = false;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.UseVisualStyleBackColor = true;
            this.btnMenuClientsVendorsSubVendorBalanceCheck.Click += new System.EventHandler(this.btnMenuClientsVendorsSubVendorBalanceCheck_Click);
            // 
            // btnMenuClientsVendorsSubVendorsDefinitions
            // 
            this.btnMenuClientsVendorsSubVendorsDefinitions.AutoSize = false;
            this.btnMenuClientsVendorsSubVendorsDefinitions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Depth = 0;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientsVendorsSubVendorsDefinitions.HighEmphasis = true;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Icon = null;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Location = new System.Drawing.Point(14, 86);
            this.btnMenuClientsVendorsSubVendorsDefinitions.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuClientsVendorsSubVendorsDefinitions.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Name = "btnMenuClientsVendorsSubVendorsDefinitions";
            this.btnMenuClientsVendorsSubVendorsDefinitions.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Size = new System.Drawing.Size(194, 36);
            this.btnMenuClientsVendorsSubVendorsDefinitions.TabIndex = 51;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Text = "تعريف مورد";
            this.btnMenuClientsVendorsSubVendorsDefinitions.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuClientsVendorsSubVendorsDefinitions.UseAccentColor = false;
            this.btnMenuClientsVendorsSubVendorsDefinitions.UseVisualStyleBackColor = true;
            this.btnMenuClientsVendorsSubVendorsDefinitions.Click += new System.EventHandler(this.btnMenuClientsVendorsSubVendorsDefinitions_Click);
            // 
            // btnMenuClientsVendorsSubClientsBalanceCheck
            // 
            this.btnMenuClientsVendorsSubClientsBalanceCheck.AutoSize = false;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Depth = 0;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.HighEmphasis = true;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Icon = null;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Location = new System.Drawing.Point(14, 50);
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuClientsVendorsSubClientsBalanceCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Name = "btnMenuClientsVendorsSubClientsBalanceCheck";
            this.btnMenuClientsVendorsSubClientsBalanceCheck.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Size = new System.Drawing.Size(194, 36);
            this.btnMenuClientsVendorsSubClientsBalanceCheck.TabIndex = 50;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Text = "كشف حساب العميل";
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.UseAccentColor = false;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.UseVisualStyleBackColor = true;
            this.btnMenuClientsVendorsSubClientsBalanceCheck.Click += new System.EventHandler(this.btnMenuClientsVendorsSubClientsBalanceCheck_Click);
            // 
            // btnMenuClientsVendorsSubClientsDefinitions
            // 
            this.btnMenuClientsVendorsSubClientsDefinitions.AutoSize = false;
            this.btnMenuClientsVendorsSubClientsDefinitions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuClientsVendorsSubClientsDefinitions.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuClientsVendorsSubClientsDefinitions.Depth = 0;
            this.btnMenuClientsVendorsSubClientsDefinitions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientsVendorsSubClientsDefinitions.HighEmphasis = true;
            this.btnMenuClientsVendorsSubClientsDefinitions.Icon = null;
            this.btnMenuClientsVendorsSubClientsDefinitions.Location = new System.Drawing.Point(14, 14);
            this.btnMenuClientsVendorsSubClientsDefinitions.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuClientsVendorsSubClientsDefinitions.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuClientsVendorsSubClientsDefinitions.Name = "btnMenuClientsVendorsSubClientsDefinitions";
            this.btnMenuClientsVendorsSubClientsDefinitions.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuClientsVendorsSubClientsDefinitions.Size = new System.Drawing.Size(194, 36);
            this.btnMenuClientsVendorsSubClientsDefinitions.TabIndex = 49;
            this.btnMenuClientsVendorsSubClientsDefinitions.Text = "تعريف العملاء";
            this.btnMenuClientsVendorsSubClientsDefinitions.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuClientsVendorsSubClientsDefinitions.UseAccentColor = false;
            this.btnMenuClientsVendorsSubClientsDefinitions.UseVisualStyleBackColor = true;
            this.btnMenuClientsVendorsSubClientsDefinitions.Click += new System.EventHandler(this.btnMenuClientsVendorsSubClientsDefinitions_Click);
            // 
            // btnMenuClientsVendors
            // 
            this.btnMenuClientsVendors.AutoSize = false;
            this.btnMenuClientsVendors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuClientsVendors.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuClientsVendors.Depth = 0;
            this.btnMenuClientsVendors.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientsVendors.HighEmphasis = true;
            this.btnMenuClientsVendors.Icon = null;
            this.btnMenuClientsVendors.Location = new System.Drawing.Point(14, 270);
            this.btnMenuClientsVendors.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuClientsVendors.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuClientsVendors.Name = "btnMenuClientsVendors";
            this.btnMenuClientsVendors.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuClientsVendors.Size = new System.Drawing.Size(0, 36);
            this.btnMenuClientsVendors.TabIndex = 56;
            this.btnMenuClientsVendors.Text = "شؤون العملاء";
            this.btnMenuClientsVendors.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuClientsVendors.UseAccentColor = false;
            this.btnMenuClientsVendors.UseVisualStyleBackColor = true;
            this.btnMenuClientsVendors.Click += new System.EventHandler(this.btnMenuClientsVendors_Click);
            // 
            // pnlMenuEmployeesAffairsSub
            // 
            this.pnlMenuEmployeesAffairsSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuEmployeesAffairsSub.Controls.Add(this.btnMenuEmployeesAffairsSubDaysOff);
            this.pnlMenuEmployeesAffairsSub.Controls.Add(this.btnMenuEmployeesAffairsSubEmployeesManagement);
            this.pnlMenuEmployeesAffairsSub.Depth = 0;
            this.pnlMenuEmployeesAffairsSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuEmployeesAffairsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuEmployeesAffairsSub.Location = new System.Drawing.Point(14, 260);
            this.pnlMenuEmployeesAffairsSub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuEmployeesAffairsSub.MaximumSize = new System.Drawing.Size(222, 100);
            this.pnlMenuEmployeesAffairsSub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuEmployeesAffairsSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuEmployeesAffairsSub.Name = "pnlMenuEmployeesAffairsSub";
            this.pnlMenuEmployeesAffairsSub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuEmployeesAffairsSub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuEmployeesAffairsSub.TabIndex = 55;
            // 
            // btnMenuEmployeesAffairsSubDaysOff
            // 
            this.btnMenuEmployeesAffairsSubDaysOff.AutoSize = false;
            this.btnMenuEmployeesAffairsSubDaysOff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuEmployeesAffairsSubDaysOff.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuEmployeesAffairsSubDaysOff.Depth = 0;
            this.btnMenuEmployeesAffairsSubDaysOff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuEmployeesAffairsSubDaysOff.HighEmphasis = true;
            this.btnMenuEmployeesAffairsSubDaysOff.Icon = null;
            this.btnMenuEmployeesAffairsSubDaysOff.Location = new System.Drawing.Point(14, 50);
            this.btnMenuEmployeesAffairsSubDaysOff.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuEmployeesAffairsSubDaysOff.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuEmployeesAffairsSubDaysOff.Name = "btnMenuEmployeesAffairsSubDaysOff";
            this.btnMenuEmployeesAffairsSubDaysOff.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuEmployeesAffairsSubDaysOff.Size = new System.Drawing.Size(194, 36);
            this.btnMenuEmployeesAffairsSubDaysOff.TabIndex = 50;
            this.btnMenuEmployeesAffairsSubDaysOff.Text = "الإجازات";
            this.btnMenuEmployeesAffairsSubDaysOff.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuEmployeesAffairsSubDaysOff.UseAccentColor = false;
            this.btnMenuEmployeesAffairsSubDaysOff.UseVisualStyleBackColor = true;
            this.btnMenuEmployeesAffairsSubDaysOff.Click += new System.EventHandler(this.btnMenuEmployeesAffairsSubDaysOff_Click);
            // 
            // btnMenuEmployeesAffairsSubEmployeesManagement
            // 
            this.btnMenuEmployeesAffairsSubEmployeesManagement.AutoSize = false;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Depth = 0;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.HighEmphasis = true;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Icon = null;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Location = new System.Drawing.Point(14, 14);
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuEmployeesAffairsSubEmployeesManagement.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Name = "btnMenuEmployeesAffairsSubEmployeesManagement";
            this.btnMenuEmployeesAffairsSubEmployeesManagement.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Size = new System.Drawing.Size(194, 36);
            this.btnMenuEmployeesAffairsSubEmployeesManagement.TabIndex = 49;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Text = "إدارة الموظفين";
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.UseAccentColor = false;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.UseVisualStyleBackColor = true;
            this.btnMenuEmployeesAffairsSubEmployeesManagement.Click += new System.EventHandler(this.btnMenuEmployeesAffairsSubEmployeesManagement_Click);
            // 
            // btnMenuEmployeesAffairs
            // 
            this.btnMenuEmployeesAffairs.AutoSize = false;
            this.btnMenuEmployeesAffairs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuEmployeesAffairs.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuEmployeesAffairs.Depth = 0;
            this.btnMenuEmployeesAffairs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuEmployeesAffairs.HighEmphasis = true;
            this.btnMenuEmployeesAffairs.Icon = null;
            this.btnMenuEmployeesAffairs.Location = new System.Drawing.Point(14, 224);
            this.btnMenuEmployeesAffairs.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuEmployeesAffairs.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuEmployeesAffairs.Name = "btnMenuEmployeesAffairs";
            this.btnMenuEmployeesAffairs.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuEmployeesAffairs.Size = new System.Drawing.Size(0, 36);
            this.btnMenuEmployeesAffairs.TabIndex = 54;
            this.btnMenuEmployeesAffairs.Text = "شؤون الموظفين";
            this.btnMenuEmployeesAffairs.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuEmployeesAffairs.UseAccentColor = false;
            this.btnMenuEmployeesAffairs.UseVisualStyleBackColor = true;
            this.btnMenuEmployeesAffairs.Click += new System.EventHandler(this.btnMenuEmployeesAffairs_Click);
            // 
            // btnMenuIncomingOutgoing
            // 
            this.btnMenuIncomingOutgoing.AutoSize = false;
            this.btnMenuIncomingOutgoing.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuIncomingOutgoing.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuIncomingOutgoing.Depth = 0;
            this.btnMenuIncomingOutgoing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuIncomingOutgoing.HighEmphasis = true;
            this.btnMenuIncomingOutgoing.Icon = null;
            this.btnMenuIncomingOutgoing.Location = new System.Drawing.Point(14, 188);
            this.btnMenuIncomingOutgoing.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuIncomingOutgoing.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuIncomingOutgoing.Name = "btnMenuIncomingOutgoing";
            this.btnMenuIncomingOutgoing.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuIncomingOutgoing.Size = new System.Drawing.Size(0, 36);
            this.btnMenuIncomingOutgoing.TabIndex = 53;
            this.btnMenuIncomingOutgoing.Text = "الصادر و الوارد و رأس المال";
            this.btnMenuIncomingOutgoing.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuIncomingOutgoing.UseAccentColor = false;
            this.btnMenuIncomingOutgoing.UseVisualStyleBackColor = true;
            this.btnMenuIncomingOutgoing.Click += new System.EventHandler(this.btnMenuIncomingOutgoing_Click);
            // 
            // pnlMenuExpensesSub
            // 
            this.pnlMenuExpensesSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuExpensesSub.Controls.Add(this.btnMenuExpensesSubAddExpense);
            this.pnlMenuExpensesSub.Controls.Add(this.btnMenuExpensesSubSearchExpenses);
            this.pnlMenuExpensesSub.Depth = 0;
            this.pnlMenuExpensesSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuExpensesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuExpensesSub.Location = new System.Drawing.Point(14, 178);
            this.pnlMenuExpensesSub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuExpensesSub.MaximumSize = new System.Drawing.Size(222, 100);
            this.pnlMenuExpensesSub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuExpensesSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuExpensesSub.Name = "pnlMenuExpensesSub";
            this.pnlMenuExpensesSub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuExpensesSub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuExpensesSub.TabIndex = 52;
            // 
            // btnMenuExpensesSubAddExpense
            // 
            this.btnMenuExpensesSubAddExpense.AutoSize = false;
            this.btnMenuExpensesSubAddExpense.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuExpensesSubAddExpense.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuExpensesSubAddExpense.Depth = 0;
            this.btnMenuExpensesSubAddExpense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuExpensesSubAddExpense.HighEmphasis = true;
            this.btnMenuExpensesSubAddExpense.Icon = null;
            this.btnMenuExpensesSubAddExpense.Location = new System.Drawing.Point(14, 50);
            this.btnMenuExpensesSubAddExpense.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuExpensesSubAddExpense.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuExpensesSubAddExpense.Name = "btnMenuExpensesSubAddExpense";
            this.btnMenuExpensesSubAddExpense.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuExpensesSubAddExpense.Size = new System.Drawing.Size(194, 36);
            this.btnMenuExpensesSubAddExpense.TabIndex = 50;
            this.btnMenuExpensesSubAddExpense.Text = "إضافة مصروف";
            this.btnMenuExpensesSubAddExpense.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuExpensesSubAddExpense.UseAccentColor = false;
            this.btnMenuExpensesSubAddExpense.UseVisualStyleBackColor = true;
            this.btnMenuExpensesSubAddExpense.Click += new System.EventHandler(this.btnMenuExpensesSubAddExpense_Click);
            // 
            // btnMenuExpensesSubSearchExpenses
            // 
            this.btnMenuExpensesSubSearchExpenses.AutoSize = false;
            this.btnMenuExpensesSubSearchExpenses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuExpensesSubSearchExpenses.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuExpensesSubSearchExpenses.Depth = 0;
            this.btnMenuExpensesSubSearchExpenses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuExpensesSubSearchExpenses.HighEmphasis = true;
            this.btnMenuExpensesSubSearchExpenses.Icon = null;
            this.btnMenuExpensesSubSearchExpenses.Location = new System.Drawing.Point(14, 14);
            this.btnMenuExpensesSubSearchExpenses.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuExpensesSubSearchExpenses.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuExpensesSubSearchExpenses.Name = "btnMenuExpensesSubSearchExpenses";
            this.btnMenuExpensesSubSearchExpenses.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuExpensesSubSearchExpenses.Size = new System.Drawing.Size(194, 36);
            this.btnMenuExpensesSubSearchExpenses.TabIndex = 49;
            this.btnMenuExpensesSubSearchExpenses.Text = "البحث عن المصروفات";
            this.btnMenuExpensesSubSearchExpenses.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuExpensesSubSearchExpenses.UseAccentColor = false;
            this.btnMenuExpensesSubSearchExpenses.UseVisualStyleBackColor = true;
            this.btnMenuExpensesSubSearchExpenses.Click += new System.EventHandler(this.btnMenuExpensesSubSearchExpenses_Click);
            // 
            // btnMenuExpenses
            // 
            this.btnMenuExpenses.AutoSize = false;
            this.btnMenuExpenses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuExpenses.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuExpenses.Depth = 0;
            this.btnMenuExpenses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuExpenses.HighEmphasis = true;
            this.btnMenuExpenses.Icon = null;
            this.btnMenuExpenses.Location = new System.Drawing.Point(14, 142);
            this.btnMenuExpenses.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuExpenses.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuExpenses.Name = "btnMenuExpenses";
            this.btnMenuExpenses.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuExpenses.Size = new System.Drawing.Size(0, 36);
            this.btnMenuExpenses.TabIndex = 51;
            this.btnMenuExpenses.Text = "المصاريف";
            this.btnMenuExpenses.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuExpenses.UseAccentColor = false;
            this.btnMenuExpenses.UseVisualStyleBackColor = true;
            this.btnMenuExpenses.Click += new System.EventHandler(this.btnMenuExpenses_Click);
            // 
            // pnlMenuInventorySub
            // 
            this.pnlMenuInventorySub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuInventorySub.Controls.Add(this.btnMenuInventorySubAddWarehouses);
            this.pnlMenuInventorySub.Controls.Add(this.btnMenuInventorySubAddFavorites);
            this.pnlMenuInventorySub.Controls.Add(this.btnMenuInventorySubAddItemTypes);
            this.pnlMenuInventorySub.Controls.Add(this.btnMenuInventorySubIncomingOutgoingItems);
            this.pnlMenuInventorySub.Controls.Add(this.btnMenuInventorySubItemsQuantify);
            this.pnlMenuInventorySub.Controls.Add(this.btnMenuInventorySubInventory);
            this.pnlMenuInventorySub.Depth = 0;
            this.pnlMenuInventorySub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuInventorySub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuInventorySub.Location = new System.Drawing.Point(14, 132);
            this.pnlMenuInventorySub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuInventorySub.MaximumSize = new System.Drawing.Size(222, 250);
            this.pnlMenuInventorySub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuInventorySub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuInventorySub.Name = "pnlMenuInventorySub";
            this.pnlMenuInventorySub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuInventorySub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuInventorySub.TabIndex = 50;
            // 
            // btnMenuInventorySubAddWarehouses
            // 
            this.btnMenuInventorySubAddWarehouses.AutoSize = false;
            this.btnMenuInventorySubAddWarehouses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventorySubAddWarehouses.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventorySubAddWarehouses.Depth = 0;
            this.btnMenuInventorySubAddWarehouses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventorySubAddWarehouses.HighEmphasis = true;
            this.btnMenuInventorySubAddWarehouses.Icon = null;
            this.btnMenuInventorySubAddWarehouses.Location = new System.Drawing.Point(14, 194);
            this.btnMenuInventorySubAddWarehouses.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventorySubAddWarehouses.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventorySubAddWarehouses.Name = "btnMenuInventorySubAddWarehouses";
            this.btnMenuInventorySubAddWarehouses.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventorySubAddWarehouses.Size = new System.Drawing.Size(194, 36);
            this.btnMenuInventorySubAddWarehouses.TabIndex = 54;
            this.btnMenuInventorySubAddWarehouses.Text = "إضافة مستودع";
            this.btnMenuInventorySubAddWarehouses.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventorySubAddWarehouses.UseAccentColor = false;
            this.btnMenuInventorySubAddWarehouses.UseVisualStyleBackColor = true;
            this.btnMenuInventorySubAddWarehouses.Click += new System.EventHandler(this.btnMenuInventorySubAddWarehouses_Click);
            // 
            // btnMenuInventorySubAddFavorites
            // 
            this.btnMenuInventorySubAddFavorites.AutoSize = false;
            this.btnMenuInventorySubAddFavorites.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventorySubAddFavorites.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventorySubAddFavorites.Depth = 0;
            this.btnMenuInventorySubAddFavorites.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventorySubAddFavorites.HighEmphasis = true;
            this.btnMenuInventorySubAddFavorites.Icon = null;
            this.btnMenuInventorySubAddFavorites.Location = new System.Drawing.Point(14, 158);
            this.btnMenuInventorySubAddFavorites.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventorySubAddFavorites.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventorySubAddFavorites.Name = "btnMenuInventorySubAddFavorites";
            this.btnMenuInventorySubAddFavorites.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventorySubAddFavorites.Size = new System.Drawing.Size(194, 36);
            this.btnMenuInventorySubAddFavorites.TabIndex = 53;
            this.btnMenuInventorySubAddFavorites.Text = "إضافة مجلد مفضلات";
            this.btnMenuInventorySubAddFavorites.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventorySubAddFavorites.UseAccentColor = false;
            this.btnMenuInventorySubAddFavorites.UseVisualStyleBackColor = true;
            this.btnMenuInventorySubAddFavorites.Click += new System.EventHandler(this.btnMenuInventorySubAddFavorites_Click);
            // 
            // btnMenuInventorySubAddItemTypes
            // 
            this.btnMenuInventorySubAddItemTypes.AutoSize = false;
            this.btnMenuInventorySubAddItemTypes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventorySubAddItemTypes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventorySubAddItemTypes.Depth = 0;
            this.btnMenuInventorySubAddItemTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventorySubAddItemTypes.HighEmphasis = true;
            this.btnMenuInventorySubAddItemTypes.Icon = null;
            this.btnMenuInventorySubAddItemTypes.Location = new System.Drawing.Point(14, 122);
            this.btnMenuInventorySubAddItemTypes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventorySubAddItemTypes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventorySubAddItemTypes.Name = "btnMenuInventorySubAddItemTypes";
            this.btnMenuInventorySubAddItemTypes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventorySubAddItemTypes.Size = new System.Drawing.Size(194, 36);
            this.btnMenuInventorySubAddItemTypes.TabIndex = 52;
            this.btnMenuInventorySubAddItemTypes.Text = "إضافة صنف";
            this.btnMenuInventorySubAddItemTypes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventorySubAddItemTypes.UseAccentColor = false;
            this.btnMenuInventorySubAddItemTypes.UseVisualStyleBackColor = true;
            this.btnMenuInventorySubAddItemTypes.Click += new System.EventHandler(this.btnMenuInventorySubAddItemTypes_Click);
            // 
            // btnMenuInventorySubIncomingOutgoingItems
            // 
            this.btnMenuInventorySubIncomingOutgoingItems.AutoSize = false;
            this.btnMenuInventorySubIncomingOutgoingItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventorySubIncomingOutgoingItems.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventorySubIncomingOutgoingItems.Depth = 0;
            this.btnMenuInventorySubIncomingOutgoingItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventorySubIncomingOutgoingItems.HighEmphasis = true;
            this.btnMenuInventorySubIncomingOutgoingItems.Icon = null;
            this.btnMenuInventorySubIncomingOutgoingItems.Location = new System.Drawing.Point(14, 86);
            this.btnMenuInventorySubIncomingOutgoingItems.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventorySubIncomingOutgoingItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventorySubIncomingOutgoingItems.Name = "btnMenuInventorySubIncomingOutgoingItems";
            this.btnMenuInventorySubIncomingOutgoingItems.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventorySubIncomingOutgoingItems.Size = new System.Drawing.Size(194, 36);
            this.btnMenuInventorySubIncomingOutgoingItems.TabIndex = 51;
            this.btnMenuInventorySubIncomingOutgoingItems.Text = "سند إدخال و إخراج";
            this.btnMenuInventorySubIncomingOutgoingItems.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventorySubIncomingOutgoingItems.UseAccentColor = false;
            this.btnMenuInventorySubIncomingOutgoingItems.UseVisualStyleBackColor = true;
            this.btnMenuInventorySubIncomingOutgoingItems.Click += new System.EventHandler(this.btnMenuInventorySubIncomingOutgoingItems_Click);
            // 
            // btnMenuInventorySubItemsQuantify
            // 
            this.btnMenuInventorySubItemsQuantify.AutoSize = false;
            this.btnMenuInventorySubItemsQuantify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventorySubItemsQuantify.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventorySubItemsQuantify.Depth = 0;
            this.btnMenuInventorySubItemsQuantify.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventorySubItemsQuantify.HighEmphasis = true;
            this.btnMenuInventorySubItemsQuantify.Icon = null;
            this.btnMenuInventorySubItemsQuantify.Location = new System.Drawing.Point(14, 50);
            this.btnMenuInventorySubItemsQuantify.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventorySubItemsQuantify.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventorySubItemsQuantify.Name = "btnMenuInventorySubItemsQuantify";
            this.btnMenuInventorySubItemsQuantify.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventorySubItemsQuantify.Size = new System.Drawing.Size(194, 36);
            this.btnMenuInventorySubItemsQuantify.TabIndex = 50;
            this.btnMenuInventorySubItemsQuantify.Text = "جرد المستودعات";
            this.btnMenuInventorySubItemsQuantify.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventorySubItemsQuantify.UseAccentColor = false;
            this.btnMenuInventorySubItemsQuantify.UseVisualStyleBackColor = true;
            this.btnMenuInventorySubItemsQuantify.Click += new System.EventHandler(this.btnMenuInventorySubItemsQuantify_Click);
            // 
            // btnMenuInventorySubInventory
            // 
            this.btnMenuInventorySubInventory.AutoSize = false;
            this.btnMenuInventorySubInventory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventorySubInventory.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventorySubInventory.Depth = 0;
            this.btnMenuInventorySubInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventorySubInventory.HighEmphasis = true;
            this.btnMenuInventorySubInventory.Icon = null;
            this.btnMenuInventorySubInventory.Location = new System.Drawing.Point(14, 14);
            this.btnMenuInventorySubInventory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventorySubInventory.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventorySubInventory.Name = "btnMenuInventorySubInventory";
            this.btnMenuInventorySubInventory.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventorySubInventory.Size = new System.Drawing.Size(194, 36);
            this.btnMenuInventorySubInventory.TabIndex = 49;
            this.btnMenuInventorySubInventory.Text = "المستودع";
            this.btnMenuInventorySubInventory.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventorySubInventory.UseAccentColor = false;
            this.btnMenuInventorySubInventory.UseVisualStyleBackColor = true;
            this.btnMenuInventorySubInventory.Click += new System.EventHandler(this.btnMenuInventorySubInventory_Click);
            // 
            // btnMenuInventory
            // 
            this.btnMenuInventory.AutoSize = false;
            this.btnMenuInventory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuInventory.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuInventory.Depth = 0;
            this.btnMenuInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInventory.HighEmphasis = true;
            this.btnMenuInventory.Icon = null;
            this.btnMenuInventory.Location = new System.Drawing.Point(14, 96);
            this.btnMenuInventory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuInventory.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuInventory.Name = "btnMenuInventory";
            this.btnMenuInventory.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuInventory.Size = new System.Drawing.Size(0, 36);
            this.btnMenuInventory.TabIndex = 49;
            this.btnMenuInventory.Text = "المستودع";
            this.btnMenuInventory.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuInventory.UseAccentColor = false;
            this.btnMenuInventory.UseVisualStyleBackColor = true;
            this.btnMenuInventory.Click += new System.EventHandler(this.btnMenuInventory_Click);
            // 
            // pnlMenuSalesSub
            // 
            this.pnlMenuSalesSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMenuSalesSub.Controls.Add(this.btnMenuSalesSubSoldItems);
            this.pnlMenuSalesSub.Controls.Add(this.btnMenuSalesSubTravelingUntravelingSales);
            this.pnlMenuSalesSub.Controls.Add(this.btnMenuSalesSubEditInvoices);
            this.pnlMenuSalesSub.Controls.Add(this.btnMenuSalesSubSales);
            this.pnlMenuSalesSub.Depth = 0;
            this.pnlMenuSalesSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuSalesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMenuSalesSub.Location = new System.Drawing.Point(14, 86);
            this.pnlMenuSalesSub.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMenuSalesSub.MaximumSize = new System.Drawing.Size(222, 180);
            this.pnlMenuSalesSub.MinimumSize = new System.Drawing.Size(222, 0);
            this.pnlMenuSalesSub.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMenuSalesSub.Name = "pnlMenuSalesSub";
            this.pnlMenuSalesSub.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMenuSalesSub.Size = new System.Drawing.Size(222, 10);
            this.pnlMenuSalesSub.TabIndex = 48;
            // 
            // btnMenuSalesSubSoldItems
            // 
            this.btnMenuSalesSubSoldItems.AutoSize = false;
            this.btnMenuSalesSubSoldItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSalesSubSoldItems.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSalesSubSoldItems.Depth = 0;
            this.btnMenuSalesSubSoldItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSalesSubSoldItems.HighEmphasis = true;
            this.btnMenuSalesSubSoldItems.Icon = null;
            this.btnMenuSalesSubSoldItems.Location = new System.Drawing.Point(14, 122);
            this.btnMenuSalesSubSoldItems.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSalesSubSoldItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSalesSubSoldItems.Name = "btnMenuSalesSubSoldItems";
            this.btnMenuSalesSubSoldItems.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSalesSubSoldItems.Size = new System.Drawing.Size(194, 36);
            this.btnMenuSalesSubSoldItems.TabIndex = 52;
            this.btnMenuSalesSubSoldItems.Text = "جرد الكميات المباعه";
            this.btnMenuSalesSubSoldItems.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSalesSubSoldItems.UseAccentColor = false;
            this.btnMenuSalesSubSoldItems.UseVisualStyleBackColor = true;
            this.btnMenuSalesSubSoldItems.Click += new System.EventHandler(this.btnMenuSalesSubSoldItems_Click);
            // 
            // btnMenuSalesSubTravelingUntravelingSales
            // 
            this.btnMenuSalesSubTravelingUntravelingSales.AutoSize = false;
            this.btnMenuSalesSubTravelingUntravelingSales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSalesSubTravelingUntravelingSales.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSalesSubTravelingUntravelingSales.Depth = 0;
            this.btnMenuSalesSubTravelingUntravelingSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSalesSubTravelingUntravelingSales.HighEmphasis = true;
            this.btnMenuSalesSubTravelingUntravelingSales.Icon = null;
            this.btnMenuSalesSubTravelingUntravelingSales.Location = new System.Drawing.Point(14, 86);
            this.btnMenuSalesSubTravelingUntravelingSales.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSalesSubTravelingUntravelingSales.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSalesSubTravelingUntravelingSales.Name = "btnMenuSalesSubTravelingUntravelingSales";
            this.btnMenuSalesSubTravelingUntravelingSales.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSalesSubTravelingUntravelingSales.Size = new System.Drawing.Size(194, 36);
            this.btnMenuSalesSubTravelingUntravelingSales.TabIndex = 51;
            this.btnMenuSalesSubTravelingUntravelingSales.Text = "المبيعات المرحله و الغير مرحله";
            this.btnMenuSalesSubTravelingUntravelingSales.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSalesSubTravelingUntravelingSales.UseAccentColor = false;
            this.btnMenuSalesSubTravelingUntravelingSales.UseVisualStyleBackColor = true;
            this.btnMenuSalesSubTravelingUntravelingSales.Click += new System.EventHandler(this.btnMenuSalesSubTravelingUntravelingSales_Click);
            // 
            // btnMenuSalesSubEditInvoices
            // 
            this.btnMenuSalesSubEditInvoices.AutoSize = false;
            this.btnMenuSalesSubEditInvoices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSalesSubEditInvoices.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSalesSubEditInvoices.Depth = 0;
            this.btnMenuSalesSubEditInvoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSalesSubEditInvoices.HighEmphasis = true;
            this.btnMenuSalesSubEditInvoices.Icon = null;
            this.btnMenuSalesSubEditInvoices.Location = new System.Drawing.Point(14, 50);
            this.btnMenuSalesSubEditInvoices.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSalesSubEditInvoices.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSalesSubEditInvoices.Name = "btnMenuSalesSubEditInvoices";
            this.btnMenuSalesSubEditInvoices.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSalesSubEditInvoices.Size = new System.Drawing.Size(194, 36);
            this.btnMenuSalesSubEditInvoices.TabIndex = 50;
            this.btnMenuSalesSubEditInvoices.Text = "التعديل على الفواتير";
            this.btnMenuSalesSubEditInvoices.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSalesSubEditInvoices.UseAccentColor = false;
            this.btnMenuSalesSubEditInvoices.UseVisualStyleBackColor = true;
            this.btnMenuSalesSubEditInvoices.Click += new System.EventHandler(this.btnMenuSalesSubEditInvoices_Click);
            // 
            // btnMenuSalesSubSales
            // 
            this.btnMenuSalesSubSales.AutoSize = false;
            this.btnMenuSalesSubSales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSalesSubSales.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSalesSubSales.Depth = 0;
            this.btnMenuSalesSubSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSalesSubSales.HighEmphasis = true;
            this.btnMenuSalesSubSales.Icon = null;
            this.btnMenuSalesSubSales.Location = new System.Drawing.Point(14, 14);
            this.btnMenuSalesSubSales.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSalesSubSales.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSalesSubSales.Name = "btnMenuSalesSubSales";
            this.btnMenuSalesSubSales.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSalesSubSales.Size = new System.Drawing.Size(194, 36);
            this.btnMenuSalesSubSales.TabIndex = 49;
            this.btnMenuSalesSubSales.Text = "المبيعات";
            this.btnMenuSalesSubSales.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSalesSubSales.UseAccentColor = false;
            this.btnMenuSalesSubSales.UseVisualStyleBackColor = true;
            this.btnMenuSalesSubSales.Click += new System.EventHandler(this.btnMenuSalesSubSales_Click);
            // 
            // btnHamburger
            // 
            this.btnHamburger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHamburger.AutoSize = true;
            this.btnHamburger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHamburger.Depth = 0;
            this.btnHamburger.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnHamburger.Location = new System.Drawing.Point(236, 3);
            this.btnHamburger.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHamburger.Name = "btnHamburger";
            this.btnHamburger.Size = new System.Drawing.Size(12, 19);
            this.btnHamburger.TabIndex = 47;
            this.btnHamburger.Text = "☰";
            this.btnHamburger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHamburger.Visible = false;
            this.btnHamburger.Click += new System.EventHandler(this.lblHamburger_Click);
            // 
            // btnMenuSales
            // 
            this.btnMenuSales.AutoSize = false;
            this.btnMenuSales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuSales.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuSales.Depth = 0;
            this.btnMenuSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSales.HighEmphasis = true;
            this.btnMenuSales.Icon = null;
            this.btnMenuSales.Location = new System.Drawing.Point(14, 50);
            this.btnMenuSales.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuSales.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuSales.Name = "btnMenuSales";
            this.btnMenuSales.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuSales.Size = new System.Drawing.Size(0, 36);
            this.btnMenuSales.TabIndex = 46;
            this.btnMenuSales.Text = "المبيعات";
            this.btnMenuSales.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuSales.UseAccentColor = false;
            this.btnMenuSales.UseVisualStyleBackColor = true;
            this.btnMenuSales.Click += new System.EventHandler(this.btnMenuSales_Click);
            // 
            // btnMenuCash
            // 
            this.btnMenuCash.AutoSize = false;
            this.btnMenuCash.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenuCash.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenuCash.Depth = 0;
            this.btnMenuCash.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuCash.HighEmphasis = true;
            this.btnMenuCash.Icon = null;
            this.btnMenuCash.Location = new System.Drawing.Point(14, 14);
            this.btnMenuCash.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMenuCash.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenuCash.Name = "btnMenuCash";
            this.btnMenuCash.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenuCash.Size = new System.Drawing.Size(0, 36);
            this.btnMenuCash.TabIndex = 45;
            this.btnMenuCash.Text = "الكاش";
            this.btnMenuCash.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenuCash.UseAccentColor = false;
            this.btnMenuCash.UseVisualStyleBackColor = true;
            this.btnMenuCash.Click += new System.EventHandler(this.btnMenuCash_Click);
            // 
            // timeDateTimer
            // 
            this.timeDateTimer.Enabled = true;
            this.timeDateTimer.Interval = 1000;
            this.timeDateTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // itemBarCodeEntryTimer
            // 
            this.itemBarCodeEntryTimer.Interval = 300;
            this.itemBarCodeEntryTimer.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // lastBillNumberUpdaterTimer
            // 
            this.lastBillNumberUpdaterTimer.Enabled = true;
            this.lastBillNumberUpdaterTimer.Interval = 3000;
            this.lastBillNumberUpdaterTimer.Tick += new System.EventHandler(this.lastBillNumberUpdaterTimer_Tick);
            // 
            // updateSystem
            // 
            this.updateSystem.Enabled = true;
            this.updateSystem.Interval = 3600000;
            this.updateSystem.Tick += new System.EventHandler(this.updateSystem_Tick);
            // 
            // PlancksoftPOS
            // 
            this.PlancksoftPOS.ContextMenuStrip = this.Menu;
            this.PlancksoftPOS.Icon = ((System.Drawing.Icon)(resources.GetObject("PlancksoftPOS.Icon")));
            this.PlancksoftPOS.Text = "PlancksoftPOS";
            this.PlancksoftPOS.Visible = true;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Menu.Depth = 0;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اللغةToolStripMenuItem,
            this.المظهرToolStripMenuItem,
            this.الخروجToolStripMenuItem});
            this.Menu.MouseState = MaterialSkin.MouseState.HOVER;
            this.Menu.Name = "Menu";
            this.Menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu.Size = new System.Drawing.Size(110, 70);
            // 
            // اللغةToolStripMenuItem
            // 
            this.اللغةToolStripMenuItem.AutoSize = false;
            this.اللغةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.العربيةToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.اللغةToolStripMenuItem.Name = "اللغةToolStripMenuItem";
            this.اللغةToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.اللغةToolStripMenuItem.Text = "اللغة";
            // 
            // العربيةToolStripMenuItem
            // 
            this.العربيةToolStripMenuItem.AutoSize = false;
            this.العربيةToolStripMenuItem.CheckOnClick = true;
            this.العربيةToolStripMenuItem.Name = "العربيةToolStripMenuItem";
            this.العربيةToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.العربيةToolStripMenuItem.Text = "العربية";
            this.العربيةToolStripMenuItem.Click += new System.EventHandler(this.العربيةToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.AutoSize = false;
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // المظهرToolStripMenuItem
            // 
            this.المظهرToolStripMenuItem.AutoSize = false;
            this.المظهرToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.فاتحToolStripMenuItem,
            this.مظلمToolStripMenuItem});
            this.المظهرToolStripMenuItem.Name = "المظهرToolStripMenuItem";
            this.المظهرToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.المظهرToolStripMenuItem.Text = "المظهر";
            // 
            // فاتحToolStripMenuItem
            // 
            this.فاتحToolStripMenuItem.AutoSize = false;
            this.فاتحToolStripMenuItem.Name = "فاتحToolStripMenuItem";
            this.فاتحToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.فاتحToolStripMenuItem.Text = "فاتح";
            this.فاتحToolStripMenuItem.Click += new System.EventHandler(this.فاتحToolStripMenuItem_Click);
            // 
            // مظلمToolStripMenuItem
            // 
            this.مظلمToolStripMenuItem.AutoSize = false;
            this.مظلمToolStripMenuItem.Name = "مظلمToolStripMenuItem";
            this.مظلمToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.مظلمToolStripMenuItem.Text = "مظلم";
            this.مظلمToolStripMenuItem.Click += new System.EventHandler(this.مظلمToolStripMenuItem_Click);
            // 
            // الخروجToolStripMenuItem
            // 
            this.الخروجToolStripMenuItem.AutoSize = false;
            this.الخروجToolStripMenuItem.Name = "الخروجToolStripMenuItem";
            this.الخروجToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.الخروجToolStripMenuItem.Text = "الخروج";
            this.الخروجToolStripMenuItem.Click += new System.EventHandler(this.الخروجToolStripMenuItem_Click);
            // 
            // hamburger_menu_sales_sub_timer
            // 
            this.hamburger_menu_sales_sub_timer.Interval = 10;
            this.hamburger_menu_sales_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_sales_sub_timer_Tick);
            // 
            // hamburger_menu_inventory_sub_timer
            // 
            this.hamburger_menu_inventory_sub_timer.Interval = 10;
            this.hamburger_menu_inventory_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_inventory_sub_timer_Tick);
            // 
            // hamburger_menu_expenses_sub_timer
            // 
            this.hamburger_menu_expenses_sub_timer.Interval = 10;
            this.hamburger_menu_expenses_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_expenses_sub_timer_Tick);
            // 
            // hamburger_menu_employees_affairs_sub_timer
            // 
            this.hamburger_menu_employees_affairs_sub_timer.Interval = 10;
            this.hamburger_menu_employees_affairs_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_employees_affairs_sub_timer_Tick);
            // 
            // hamburger_menu_clients_affairs_sub_timer
            // 
            this.hamburger_menu_clients_affairs_sub_timer.Interval = 10;
            this.hamburger_menu_clients_affairs_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_clients_affairs_sub_timer_Tick_1);
            // 
            // hamburger_menu_taxes_sub_timer
            // 
            this.hamburger_menu_taxes_sub_timer.Interval = 10;
            this.hamburger_menu_taxes_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_taxes_sub_timer_Tick_1);
            // 
            // hamburger_menu_settings_sub_timer
            // 
            this.hamburger_menu_settings_sub_timer.Interval = 10;
            this.hamburger_menu_settings_sub_timer.Tick += new System.EventHandler(this.hamburger_menu_settings_sub_timer_Tick_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlActionMenu);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlancksoftPOS - الشاشه الرئيسيه";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Cash.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlOpenCloseCash.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openRegisterBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeRegisterBtn)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsPendingPurchase)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseNewPriceTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseNewPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseRemovalQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingPurchaseNewQuantity)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.Sales.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.InvoicesSales.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillItems)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBillNumberSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            this.EditInvoices.ResumeLayout(false);
            this.groupBox30.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillsEdit)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillEditNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsRemainderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsPaidAmount)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBillNumberEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            this.TravelingUntravelingSales.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortedSales)).EndInit();
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnPortedSales)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.SoldItems.ResumeLayout(false);
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox30)).EndInit();
            this.groupBox27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).EndInit();
            this.Inventory.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.posInventory.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInventory)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox99)).EndInit();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuditemPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuditemPriceTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBAddProfilePicture)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.InventoryQuantify.ResumeLayout(false);
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseInventory)).EndInit();
            this.IncomingOutgoingItems.ResumeLayout(false);
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClientIDImportExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryExitItemBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEntryExitItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryExitWarningQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryExitItemQuantity)).EndInit();
            this.AddTypes.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTypeAddButton)).EndInit();
            this.AddFavorites.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FavoriteCategoryAddButton)).EndInit();
            this.AddWarehouses.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseAddButton)).EndInit();
            this.Expenses.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.SearchExpenses.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CapitalAmountnud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox33)).EndInit();
            this.AddExpenses.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.IncomingOutgoing.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCapital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            this.groupBox20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).EndInit();
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExports)).EndInit();
            this.Employees.ResumeLayout(false);
            this.tabControl8.ResumeLayout(false);
            this.EmployeesManagement.ResumeLayout(false);
            this.groupBox49.ResumeLayout(false);
            this.groupBox49.PerformLayout();
            this.groupBox50.ResumeLayout(false);
            this.groupBox50.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryDeduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditEmployeeSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox52.ResumeLayout(false);
            this.groupBox52.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddEmployeeSalary)).EndInit();
            this.DaysOff.ResumeLayout(false);
            this.groupBox51.ResumeLayout(false);
            this.groupBox51.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).EndInit();
            this.Agents.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.AgentsDefinitions.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientID)).EndInit();
            this.ClientBalanceCheck.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintClientBillItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientBillItems)).EndInit();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintClientBills)).EndInit();
            this.ImporterDefinitions.ResumeLayout(false);
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).EndInit();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VendorID)).EndInit();
            this.ImporterBalanceChecks.ResumeLayout(false);
            this.groupBox42.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorBillItems)).EndInit();
            this.groupBox43.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox45)).EndInit();
            this.AgentsItemsDefinitions.ResumeLayout(false);
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellPriceTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuyPrice)).EndInit();
            this.groupBox23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientItems)).EndInit();
            this.Alerts.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            this.Taxes.ResumeLayout(false);
            this.tabControl7.ResumeLayout(false);
            this.TaxZReport.ResumeLayout(false);
            this.groupBox44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxZReport)).EndInit();
            this.posUsers.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.Settings.ResumeLayout(false);
            this.tabControl9.ResumeLayout(false);
            this.posSettings.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.switchDarkTheme.ResumeLayout(false);
            this.switchDarkTheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccentColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryLightColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryDarkColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkAccentColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkPrimaryLightColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkPrimaryDarkColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkPrimaryColorPanel)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoStore)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptSpacingnud)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxRate)).EndInit();
            this.printersSettings.ResumeLayout(false);
            this.Retrievals.ResumeLayout(false);
            this.groupBox47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).EndInit();
            this.pnlActionMenu.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlMenuSettingsSub.ResumeLayout(false);
            this.pnlMenuTaxesSub.ResumeLayout(false);
            this.pnlMenuClientAffairsSub.ResumeLayout(false);
            this.pnlMenuEmployeesAffairsSub.ResumeLayout(false);
            this.pnlMenuExpensesSub.ResumeLayout(false);
            this.pnlMenuInventorySub.ResumeLayout(false);
            this.pnlMenuSalesSub.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ItemTypeInsertKeyPress(object sender, KeyPressEventArgs e)
        {
            ItemTypeInsert();
        }

        private void FavoriteCategoryKeyPress(object sender, KeyPressEventArgs e)
        {
            FavoriteCategoryInsert();
        }

        #endregion

        public MenuStrip menuStrip1;
        public MaterialTabControl tabControl1;
        public System.Windows.Forms.TabPage Cash;
        public MaterialCard groupBox1;
        public System.Windows.Forms.TabPage Sales;
        public ToolStripMenuItem aToolStripMenuItem;
        public ToolStripMenuItem خروجToolStripMenuItem1;
        public System.Windows.Forms.TabPage Inventory;
        public System.Windows.Forms.TabPage Expenses;
        public System.Windows.Forms.TabPage Agents;
        public System.Windows.Forms.TabPage posUsers;
        public System.Windows.Forms.TabPage Settings;
        public System.Windows.Forms.TabPage IncomingOutgoing;
        public MaterialCard groupBox3;
        public System.Windows.Forms.NumericUpDown pendingPurchaseRemovalQuantity;
        public System.Windows.Forms.DataGridView ItemsPendingPurchase;
        public MaterialLabel richTextBox4;
        public System.Windows.Forms.NumericUpDown pendingPurchaseNewQuantity;
        public System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.Timer timeDateTimer;
        public System.Windows.Forms.PictureBox openRegisterBtn;
        public System.Windows.Forms.PictureBox closeRegisterBtn;
        public MaterialCard groupBox10;
        public System.Windows.Forms.DataGridView dgvUsers;
        public MaterialCard groupBox11;
        public MaterialLabel label76;
        public MaterialTextBox2 txtUserIDAdd;
        public MaterialLabel label77;
        public MaterialTextBox2 txtUserNameAdd;
        public System.Windows.Forms.PictureBox pictureBox16;
        public MaterialCheckbox cbAdminOrNotAdd;
        public MaterialLabel label75;
        public MaterialTextBox2 txtUserPasswordAdd;
        public MaterialCard groupBox20;
        public MaterialCard groupBox19;
        public System.Windows.Forms.DataGridView dgvImports;
        public System.Windows.Forms.DataGridView dgvExports;
        public System.Windows.Forms.PictureBox pictureBox23;
        public System.Windows.Forms.PictureBox pictureBox22;
        public MaterialTabControl tabControl3;
        public System.Windows.Forms.TabPage AgentsDefinitions;
        public MaterialCard groupBox15;
        public MaterialCard groupBox16;
        public System.Windows.Forms.DataGridView dgvClients;
        public System.Windows.Forms.PictureBox pictureBox21;
        public MaterialCard groupBox17;
        public System.Windows.Forms.NumericUpDown ClientID;
        public MaterialLabel label82;
        public MaterialLabel label83;
        public MaterialLabel label51;
        public System.Windows.Forms.NumericUpDown pendingPurchaseNewPriceTax;
        public MaterialLabel label50;
        public System.Windows.Forms.NumericUpDown pendingPurchaseNewPrice;
        public MaterialSkin.Controls.MaterialButton button23;
        public MaterialLabel richTextBox6;
        public MaterialTabControl tabControl4;
        public System.Windows.Forms.TabPage InvoicesSales;
        public MaterialCard groupBox13;
        public System.Windows.Forms.NumericUpDown nudBillNumberSearch;
        public MaterialLabel label85;
        public System.Windows.Forms.PictureBox pictureBox19;
        public MaterialCard groupBox14;
        public System.Windows.Forms.DataGridView dgvBillItems;
        public System.Windows.Forms.PictureBox pictureBox20;
        public MaterialCard groupBox12;
        public System.Windows.Forms.DataGridView dgvBills;
        public System.Windows.Forms.PictureBox pictureBox17;
        public System.Windows.Forms.PictureBox pictureBox18;
        public System.Windows.Forms.TabPage TravelingUntravelingSales;
        public MaterialCard groupBox26;
        public System.Windows.Forms.DataGridView dgvPortedSales;
        public System.Windows.Forms.PictureBox pictureBox6;
        public System.Windows.Forms.PictureBox pictureBox7;
        public MaterialCard groupBox25;
        public System.Windows.Forms.DataGridView dgvUnPortedSales;
        public System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Timer itemBarCodeEntryTimer;
        public System.Windows.Forms.PictureBox pictureBox9;
        public System.Windows.Forms.PictureBox pictureBox8;
        public System.Windows.Forms.DataGridView dgvLoginLogout;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.TabPage SoldItems;
        public MaterialCard groupBox28;
        public System.Windows.Forms.DateTimePicker dateTimePicker3;
        public MaterialLabel label3;
        public System.Windows.Forms.DateTimePicker dateTimePicker4;
        public MaterialLabel label5;
        public System.Windows.Forms.PictureBox pictureBox30;
        public MaterialCard groupBox27;
        public System.Windows.Forms.PictureBox pictureBox29;
        public System.Windows.Forms.DataGridView dgvItemProfit;
        public System.Windows.Forms.TabPage EditInvoices;
        public MaterialCard groupBox29;
        public System.Windows.Forms.NumericUpDown nudBillNumberEdit;
        public System.Windows.Forms.DateTimePicker dateTimePicker5;
        public MaterialLabel label6;
        public MaterialLabel label7;
        public System.Windows.Forms.DateTimePicker dateTimePicker6;
        public MaterialLabel label8;
        public System.Windows.Forms.PictureBox pictureBox28;
        public MaterialCard groupBox30;
        public System.Windows.Forms.DataGridView dgvBillsEdit;
        public System.Windows.Forms.PictureBox pictureBox31;
        public System.Windows.Forms.PictureBox pictureBox32;
        public System.Windows.Forms.NumericUpDown BillsTotalAmount;
        public MaterialLabel label9;
        public MaterialLabel label11;
        public MaterialTextBox2 BillsCashierName;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public MaterialLabel label84;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        public MaterialLabel label87;
        public System.Windows.Forms.NumericUpDown BillsRemainderAmount;
        public MaterialLabel label12;
        public System.Windows.Forms.NumericUpDown BillsPaidAmount;
        public MaterialLabel label10;
        public System.Windows.Forms.NumericUpDown BillEditNumber;
        public MaterialLabel label13;
        public MaterialTabControl tabControl5;
        public System.Windows.Forms.TabPage SearchExpenses;
        public MaterialCard groupBox31;
        public System.Windows.Forms.DateTimePicker dateTimePicker7;
        public MaterialLabel label14;
        public System.Windows.Forms.DateTimePicker dateTimePicker8;
        public MaterialLabel label15;
        public System.Windows.Forms.PictureBox pictureBox33;
        public System.Windows.Forms.DataGridView dgvExpenses;
        public System.Windows.Forms.PictureBox pictureBox34;
        public System.Windows.Forms.TabPage AddExpenses;
        public MaterialTextBox2 textBox2;
        public MaterialLabel label17;
        public MaterialTextBox2 textBox1;
        public MaterialLabel label16;
        public MaterialCard groupBox33;
        public MaterialLabel label20;
        public MaterialTextBox2 textBox4;
        public MaterialLabel label19;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Drawing.Printing.PrintDocument printDocument2;
        public MaterialLabel label21;
        public MaterialLabel label18;
        public System.Windows.Forms.PictureBox picLogo;
        public MaterialTextBox2 ClientAddress;
        public MaterialTextBox2 ClientPhone;
        public System.Windows.Forms.TabPage AgentsItemsDefinitions;
        public MaterialCard groupBox34;
        public System.Windows.Forms.NumericUpDown ClientPrice;
        public MaterialLabel lblClientVendorItemsClientSellPrice;
        public System.Windows.Forms.NumericUpDown SellPriceTax;
        public MaterialLabel lblClientVendorItemsSellPriceTax;
        public System.Windows.Forms.NumericUpDown SellPrice;
        public System.Windows.Forms.NumericUpDown BuyPrice;
        public MaterialLabel lblClientVendorItemsSellPrice;
        public MaterialLabel lblClientVendorItemsBuyPrice;
        public MaterialCard groupBox23;
        public System.Windows.Forms.DataGridView DGVClientItems;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        public MaterialLabel lblClientVendorItemsClientID;
        public MaterialLabel lblClientVendorItemsClientName;
        public MaterialTextBox2 textBox7;
        public System.Windows.Forms.PictureBox pictureBox40;
        public MaterialCard groupBox35;
        public MaterialCheckbox expenses_edit;
        public MaterialCheckbox inventory_edit;
        public MaterialCheckbox receipt_edit;
        public MaterialCheckbox price_edit;
        public MaterialCheckbox discount_edit;
        public MaterialCheckbox Client_card_edit;
        public MaterialCheckbox settings_edit;
        public MaterialCheckbox users_edit;
        public MaterialTabControl tabControl6;
        public System.Windows.Forms.TabPage posInventory;
        public MaterialCard groupBox7;
        public MaterialTextBox2 nudItemBarCodeSearch;
        public System.Windows.Forms.DateTimePicker dtpSearch2;
        public MaterialLabel label56;
        public MaterialLabel label57;
        public MaterialLabel label58;
        public System.Windows.Forms.DateTimePicker dtpSearch1;
        public MaterialTextBox2 txtItemNameSearch;
        public MaterialLabel label59;
        public MaterialCard groupBox8;
        public MaterialLabel label36;
        public System.Windows.Forms.DateTimePicker ProductionDate;
        public System.Windows.Forms.NumericUpDown QuantityWarning;
        public MaterialLabel label35;
        public MaterialLabel label34;
        public System.Windows.Forms.DateTimePicker ExpirationDate;
        public MaterialLabel label33;
        public System.Windows.Forms.DateTimePicker EntryDate;
        public System.Windows.Forms.ComboBox ItemType;
        public MaterialLabel label28;
        public System.Windows.Forms.ComboBox Warehouse;
        public MaterialLabel label25;
        public System.Windows.Forms.NumericUpDown nudItemBuyPrice;
        public MaterialLabel label4;
        public System.Windows.Forms.PictureBox PBAddProfilePicture;
        public System.Windows.Forms.ComboBox FavoriteCategories;
        public System.Windows.Forms.PictureBox pictureBox99;
        public System.Windows.Forms.PictureBox BtnPrint;
        public MaterialLabel label64;
        public System.Windows.Forms.NumericUpDown nuditemPriceTax;
        public MaterialLabel label63;
        public System.Windows.Forms.NumericUpDown nuditemPrice;
        public MaterialLabel label55;
        public System.Windows.Forms.NumericUpDown nudItemQuantity;
        public MaterialLabel label60;
        public MaterialLabel label61;
        public MaterialTextBox2 txtItemBarCode;
        public MaterialLabel label62;
        public MaterialTextBox2 txtItemName;
        public System.Windows.Forms.DataGridView DgvInventory;
        public System.Windows.Forms.TabPage AddTypes;
        public System.Windows.Forms.TabPage AddFavorites;
        public System.Windows.Forms.TabPage AddWarehouses;
        public FlowLayoutPanel flowLayoutPanel3;
        public MaterialLabel label29;
        public MaterialTextBox2 ItemTypeEntry;
        public MaterialLabel label30;
        public System.Windows.Forms.PictureBox ItemTypeAddButton;
        public FlowLayoutPanel flowLayoutPanel1;
        public MaterialLabel label22;
        public MaterialTextBox2 FavoriteCategoryEntry;
        public MaterialLabel label23;
        public System.Windows.Forms.PictureBox FavoriteCategoryAddButton;
        public FlowLayoutPanel flowLayoutPanel2;
        public MaterialLabel label26;
        public MaterialTextBox2 WarehouseEntry;
        public MaterialLabel label27;
        public System.Windows.Forms.PictureBox WarehouseAddButton;
        public ToolStripMenuItem ادارةالمستودعToolStripMenuItem;
        public ToolStripMenuItem اضافةصنفToolStripMenuItem;
        public ToolStripMenuItem اضافةمستودعToolStripMenuItem;
        public ToolStripMenuItem اضافةمستودعToolStripMenuItem1;
        public MaterialCard groupBox36;
        public ToolStripMenuItem اضافةمادهToolStripMenuItem;
        public System.Windows.Forms.TabPage Alerts;
        public MaterialCard groupBox37;
        public System.Windows.Forms.DataGridView dgvAlerts;
        public System.Windows.Forms.PictureBox pictureBox41;
        public MaterialLabel label38;
        public System.Windows.Forms.ComboBox comboBox2;
        public MaterialLabel label37;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TabPage ImporterDefinitions;
        public MaterialCard groupBox39;
        public MaterialCard groupBox38;
        public System.Windows.Forms.DataGridView dgvVendors;
        public System.Windows.Forms.PictureBox pictureBox42;
        public MaterialCard groupBox40;
        public MaterialTextBox2 VendorAddress;
        public MaterialTextBox2 VendorPhone;
        public MaterialLabel label39;
        public MaterialLabel label40;
        public System.Windows.Forms.NumericUpDown VendorID;
        public MaterialLabel label41;
        public MaterialLabel label42;
        public System.Windows.Forms.TabPage ClientBalanceCheck;
        public System.Windows.Forms.TabPage ImporterBalanceChecks;
        public MaterialCard groupBox42;
        public System.Windows.Forms.DataGridView dgvVendorBillItems;
        public MaterialCard groupBox43;
        public System.Windows.Forms.DataGridView dgvVendorBills;
        public System.Windows.Forms.PictureBox pictureBox45;
        public System.Windows.Forms.TabPage Taxes;
        public MaterialTabControl tabControl7;
        public System.Windows.Forms.TabPage TaxZReport;
        public MaterialCard groupBox44;
        public System.Windows.Forms.DataGridView dgvTaxZReport;
        public System.Windows.Forms.PictureBox pictureBox44;
        public System.Windows.Forms.PictureBox pictureBox46;
        public System.Windows.Forms.TabPage InventoryQuantify;
        public MaterialCard groupBox45;
        public System.Windows.Forms.ComboBox WarehousesQuantityList;
        public MaterialLabel label47;
        public MaterialCard groupBox46;
        public System.Windows.Forms.PictureBox pictureBox47;
        public System.Windows.Forms.DataGridView dgvWarehouseInventory;
        public System.Windows.Forms.TabPage IncomingOutgoingItems;
        public MaterialTextBox2 WarehouseEntryExitItemBarCode;
        public MaterialLabel label48;
        public MaterialLabel label53;
        public MaterialTextBox2 WarehouseEntryExitItemName;
        public MaterialCard groupBox48;
        public System.Windows.Forms.ComboBox EntryExitType;
        public System.Windows.Forms.DateTimePicker EntryExitProductionDate;
        public MaterialLabel label79;
        public System.Windows.Forms.NumericUpDown EntryExitWarningQuantity;
        public System.Windows.Forms.DateTimePicker EntryExitExpirationDate;
        public System.Windows.Forms.DateTimePicker EntryExitEntryDate;
        public MaterialLabel label94;
        public MaterialLabel label96;
        public MaterialLabel label97;
        public System.Windows.Forms.NumericUpDown EntryExitItemQuantity;
        public MaterialLabel label98;
        public MaterialLabel label101;
        public System.Windows.Forms.ComboBox WarehouseEntryExitList;
        public MaterialLabel label103;
        public MaterialLabel label46;
        public System.Windows.Forms.NumericUpDown EntryExitItemBuyPrice;
        public System.Windows.Forms.TabPage Employees;
        public MaterialCheckbox personnel_edit;
        public MaterialTabControl tabControl8;
        public System.Windows.Forms.TabPage EmployeesManagement;
        public System.Windows.Forms.TabPage DaysOff;
        public MaterialCard groupBox49;
        public MaterialCard groupBox50;
        public MaterialTextBox2 EditEmployeeName;
        public System.Windows.Forms.DataGridView dgvEmployees;
        public System.Windows.Forms.PictureBox pictureBox2;
        public MaterialCard groupBox52;
        public MaterialLabel label100;
        public MaterialLabel label102;
        public MaterialTextBox2 AddEmployeeName;
        public MaterialLabel label92;
        public MaterialLabel label54;
        public System.Windows.Forms.NumericUpDown AddEmployeeSalary;
        public System.Windows.Forms.NumericUpDown EditEmployeeSalary;
        public MaterialLabel label99;
        public MaterialTextBox2 EditEmployeeAddress;
        public MaterialLabel label95;
        public MaterialTextBox2 EditEmployeePhone;
        public MaterialLabel label105;
        public MaterialTextBox2 AddEmployeeAddress;
        public MaterialLabel label104;
        public MaterialTextBox2 AddEmployeePhone;
        public MaterialCard groupBox51;
        public System.Windows.Forms.DataGridView dgvAbsence;
        public System.Windows.Forms.PictureBox pictureBox43;
        public System.Windows.Forms.DateTimePicker AbsenceTo;
        public MaterialLabel label110;
        public System.Windows.Forms.DateTimePicker AbsenceFrom;
        public MaterialLabel label108;
        public System.Windows.Forms.PictureBox pictureBox48;
        public System.Windows.Forms.DateTimePicker AbsenceDate;
        public MaterialLabel label107;
        public MaterialLabel label106;
        public MaterialLabel label109;
        public MaterialTextBox2 AbsenceEmpName;
        public System.Windows.Forms.ComboBox AbsenceHours;
        public System.Windows.Forms.NumericUpDown SalaryDeduction;
        public MaterialLabel label111;
        public System.Windows.Forms.DataGridView dvgEntryExitItems;
        public MaterialCard groupBox22;
        public System.Windows.Forms.NumericUpDown CapitalAmountnud;
        public System.Windows.Forms.TabPage Retrievals;
        public MaterialCard groupBox47;
        public System.Windows.Forms.DataGridView dgvReturnedItems;
        public System.Windows.Forms.PictureBox pictureBox49;
        public MaterialCheckbox openclose_edit;
        public MaterialCard pnlActionMenu;
        public MaterialCard panel2;
        public MaterialCard pnlOpenCloseCash;
        public MaterialCard panel3;
        public MaterialCard panel5;
        public MaterialCard panel4;
        public MaterialCard panel7;
        public MaterialCard panel6;
        public MaterialCard panel9;
        public MaterialCard panel8;
        public MaterialCard panel11;
        public MaterialCard panel10;
        public MaterialCard panel12;
        public MaterialCard panel13;
        public MaterialCard panel14;
        public MaterialCard panel16;
        public MaterialCard panel15;
        public MaterialCard panel17;
        public MaterialCard panel18;
        public System.Windows.Forms.DataGridViewTextBoxColumn pendingPurchaseItemName;
        public System.Windows.Forms.DataGridViewTextBoxColumn pendingPurchaseItemBarCode;
        public System.Windows.Forms.DataGridViewTextBoxColumn pendingPurchaseItemQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn pendingPurchaseItemPrice;
        public System.Windows.Forms.DataGridViewTextBoxColumn pendingPurchaseItemPriceTax;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column64;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        public System.Windows.Forms.DataGridViewTextBoxColumn TotalPorted;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        public System.Windows.Forms.DataGridViewTextBoxColumn TotalUnPorted;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemName;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemBarCode;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemQuantity2;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemWarehouse;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemVendorItemBuyPrice;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemWarningQuantity;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemProductionDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemEndDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn EntryExitItemEntryDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column37;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column35;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column36;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column34;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column54;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column62;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column56;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column57;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column58;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column59;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column60;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column61;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        public System.Windows.Forms.DataGridViewTextBoxColumn VendorBillItemBuyPrice;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        public System.Windows.Forms.DataGridViewTextBoxColumn VendorBillDate;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column42;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column43;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column44;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column45;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column46;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column47;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column50;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column52;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column53;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column55;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column51;
        public System.Windows.Forms.DataGridViewTextBoxColumn TaxTotal;
        public System.Windows.Forms.PictureBox pictureBox35;
        public System.Windows.Forms.DataGridViewTextBoxColumn BillNumber;
        public System.Windows.Forms.DataGridViewTextBoxColumn BillCashierName;
        public System.Windows.Forms.DataGridViewTextBoxColumn BillTotalAmount;
        public System.Windows.Forms.DataGridViewTextBoxColumn BillPaidAmount;
        public System.Windows.Forms.DataGridViewTextBoxColumn BillRemainderAmount;
        public System.Windows.Forms.DataGridViewTextBoxColumn BillPaymentType;
        public System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        public System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        public System.Windows.Forms.DataGridViewTextBoxColumn UserPassword;
        public System.Windows.Forms.DataGridViewTextBoxColumn UserAuthority;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer lastBillNumberUpdaterTimer;
        private System.Windows.Forms.Timer updateSystem;
        private System.Windows.Forms.NotifyIcon PlancksoftPOS;
        private MaterialContextMenuStrip Menu;
        private ToolStripMenuItem اللغةToolStripMenuItem;
        private ToolStripMenuItem العربيةToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem الخروجToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column48;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column49;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPriceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemSellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemSellPriceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn FavoriteCategoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemFavoriteCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryWarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemTypeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPicture;
        private MaterialTabControl tabControl9;
        private System.Windows.Forms.TabPage posSettings;
        private System.Windows.Forms.TabPage printersSettings;
        private FlowLayoutPanel flowLayoutPanel4;
        private MaterialCheckbox cbSalesDateSearch;
        private MaterialSkin.Controls.MaterialButton button17;
        private MaterialSkin.Controls.MaterialButton button24;
        private MaterialSkin.Controls.MaterialButton button18;
        private MaterialSkin.Controls.MaterialButton button25;
        private MaterialSkin.Controls.MaterialButton button26;
        private MaterialSkin.Controls.MaterialButton BillsEditButton;
        private MaterialSkin.Controls.MaterialButton BtnSearchItem;
        private MaterialSkin.Controls.MaterialButton BtnDeleteItem;
        private MaterialSkin.Controls.MaterialButton BtnUpdateItem;
        private MaterialSkin.Controls.MaterialButton BtnAddItem;
        private MaterialSkin.Controls.MaterialButton button13;
        private MaterialSkin.Controls.MaterialButton button15;
        private MaterialSkin.Controls.MaterialButton button36;
        private MaterialSkin.Controls.MaterialButton button38;
        private MaterialSkin.Controls.MaterialButton button14;
        private MaterialSkin.Controls.MaterialButton button3;
        private MaterialSkin.Controls.MaterialButton button2;
        private MaterialSkin.Controls.MaterialButton button34;
        private MaterialSkin.Controls.MaterialButton button16;
        private MaterialSkin.Controls.MaterialButton button32;
        private MaterialSkin.Controls.MaterialButton button35;
        private MaterialSkin.Controls.MaterialButton button37;
        private MaterialSkin.Controls.MaterialButton button33;
        private MaterialSkin.Controls.MaterialButton btnClientAdd;
        private MaterialSkin.Controls.MaterialButton btnClientDelete;
        private MaterialSkin.Controls.MaterialButton btnClientVendorItemsPriceClient;
        private MaterialSkin.Controls.MaterialButton btnClientVendorItemsPickClientItem;
        private MaterialSkin.Controls.MaterialButton button7;
        private MaterialSkin.Controls.MaterialButton button8;
        private MaterialSkin.Controls.MaterialButton button9;
        private MaterialSkin.Controls.MaterialButton button6;
        private MaterialSkin.Controls.MaterialButton button19;
        private MaterialSkin.Controls.MaterialButton button20;
        private MaterialSkin.Controls.MaterialButton button22;
        public MaterialCard groupBox24;
        private MaterialSkin.Controls.MaterialButton button1;
        public MaterialCard groupBox9;
        public MaterialTextBox2 txtStorePhone;
        public MaterialLabel lblStoreName;
        public MaterialTextBox2 txtStoreName;
        public MaterialLabel lblStorePhone;
        public MaterialCard groupBox5;
        public MaterialLabel label114;
        public System.Windows.Forms.NumericUpDown receiptSpacingnud;
        private MaterialCheckbox IncludeLogoReceipt;
        public MaterialCard groupBox2;
        private MaterialSkin.Controls.MaterialButton button29;
        public System.Windows.Forms.PictureBox picLogoStore;
        public MaterialCard groupBox18;
        public System.Windows.Forms.NumericUpDown nudTaxRate;
        public MaterialLabel label78;
        private MaterialSkin.Controls.MaterialCard switchDarkTheme;
        private MaterialSkin.Controls.MaterialSwitch switchThemeScheme;
        private MaterialSkin.Controls.MaterialLabel label65;
        private MaterialSkin.Controls.MaterialLabel label66;
        private MaterialSkin.Controls.MaterialLabel dateTimeLbl;
        private MaterialSkin.Controls.MaterialLabel label45;
        private MaterialSkin.Controls.MaterialLabel label71;
        private MaterialSkin.Controls.MaterialLabel cashierNameLbl;
        private MaterialSkin.Controls.MaterialLabel label112;
        private MaterialSkin.Controls.MaterialLabel richTextBox5;
        private MaterialSkin.Controls.MaterialLabel richTextBox1;
        private MaterialSkin.Controls.MaterialLabel richTextBox2;
        private MaterialSkin.Controls.MaterialLabel richTextBox3;
        private MaterialSkin.Controls.MaterialLabel label52;
        private MaterialSkin.Controls.MaterialLabel label49;
        public MaterialCard groupBox21;
        public MaterialLabel label116;
        public MaterialLabel label115;
        public MaterialLabel label91;
        public MaterialLabel label80;
        public System.Windows.Forms.DataGridView dvgCapital;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        public System.Windows.Forms.PictureBox pictureBox27;
        public System.Windows.Forms.PictureBox pictureBox24;
        private ToolStripMenuItem المظهرToolStripMenuItem;
        private ToolStripMenuItem فاتحToolStripMenuItem;
        private ToolStripMenuItem مظلمToolStripMenuItem;
        public MaterialCheckbox sell_edit;
        public MaterialLabel lblDarkPrimaryColor;
        public MaterialTextBox2 DarkPrimaryColor;
        public MaterialLabel lblDarkPrimaryDark;
        public MaterialTextBox2 DarkPrimaryDarkColor;
        public MaterialLabel lblDarkPrimaryLight;
        public MaterialTextBox2 DarkPrimaryLightColor;
        public MaterialLabel lblDarkAccent;
        public MaterialTextBox2 DarkAccentColor;
        public MaterialLabel lblDarkTextShade;
        public MaterialLabel lblColorSeperator2;
        public MaterialLabel lblColorSeperator1;
        public MaterialLabel lblTextShade;
        public MaterialLabel lblAccent;
        public MaterialTextBox2 AccentColor;
        public MaterialLabel lblPrimaryLight;
        public MaterialTextBox2 PrimaryLightColor;
        public MaterialLabel lblPrimaryDark;
        public MaterialTextBox2 PrimaryDarkColor;
        public MaterialLabel lblPrimaryColor;
        public MaterialTextBox2 PrimaryColor;
        private MaterialSwitch switchBlackTextShade;
        private MaterialSwitch switchDarkBlackTextShade;
        public MaterialLabel lblDarkColorScheme;
        public MaterialLabel lblLightColorScheme;
        internal System.Windows.Forms.PictureBox AccentColorPanel;
        internal System.Windows.Forms.PictureBox PrimaryLightColorPanel;
        internal System.Windows.Forms.PictureBox PrimaryDarkColorPanel;
        internal System.Windows.Forms.PictureBox PrimaryColorPanel;
        internal System.Windows.Forms.PictureBox DarkAccentColorPanel;
        internal System.Windows.Forms.PictureBox DarkPrimaryLightColorPanel;
        internal System.Windows.Forms.PictureBox DarkPrimaryDarkColorPanel;
        internal System.Windows.Forms.PictureBox DarkPrimaryColorPanel;
        public MaterialTextBox2 ClientName;
        public MaterialTextBox2 VendorName;
        private MaterialButton btnPickClientForImportExport;
        public MaterialTextBox2 txtClientNameImportExport;
        public System.Windows.Forms.NumericUpDown nudClientIDImportExport;
        public MaterialLabel lblClientIDImportExport;
        public MaterialLabel lblClientNameImportExport;
        private System.Windows.Forms.CheckBox selectAllClients;
        public MaterialCard materialCard1;
        public System.Windows.Forms.PictureBox btnPrintClientBillItems;
        public System.Windows.Forms.DataGridView dgvClientBillItems;
        public MaterialCard materialCard2;
        public System.Windows.Forms.DataGridView dgvClientBills;
        public System.Windows.Forms.PictureBox btnPrintClientBills;
        private MaterialButton btnClientBalanceCheck;
        private MaterialButton btnPayDebtBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private MaterialCard pnlMenu;
        private MaterialButton btnMenuCash;
        private MaterialLabel btnHamburger;
        private System.Windows.Forms.Timer hamburger_menu_sales_sub_timer;
        private MaterialButton btnPay;
        private MaterialButton btnClientCard;
        private MaterialButton btnNewInvoice;
        private MaterialButton btnDiscounts;
        private MaterialButton btnOpenCashDrawer;
        private MaterialButton btnEditTotalPrice;
        private MaterialButton btnItemLookup;
        private MaterialButton btnNextBill;
        private MaterialButton btnPreviousBill;
        private MaterialButton btnMenuSales;
        private MaterialCard pnlMenuSalesSub;
        private MaterialButton btnMenuSalesSubSoldItems;
        private MaterialButton btnMenuSalesSubTravelingUntravelingSales;
        private MaterialButton btnMenuSalesSubEditInvoices;
        private MaterialButton btnMenuSalesSubSales;
        private MaterialCard pnlMenuInventorySub;
        private MaterialButton btnMenuInventorySubAddItemTypes;
        private MaterialButton btnMenuInventorySubIncomingOutgoingItems;
        private MaterialButton btnMenuInventorySubItemsQuantify;
        private MaterialButton btnMenuInventorySubInventory;
        private MaterialButton btnMenuInventory;
        private MaterialButton btnMenuInventorySubAddWarehouses;
        private MaterialButton btnMenuInventorySubAddFavorites;
        private MaterialButton btnMenuExpenses;
        private MaterialCard pnlMenuExpensesSub;
        private MaterialButton btnMenuExpensesSubAddExpense;
        private MaterialButton btnMenuExpensesSubSearchExpenses;
        private MaterialButton btnMenuIncomingOutgoing;
        private MaterialButton btnMenuEmployeesAffairs;
        private MaterialCard pnlMenuEmployeesAffairsSub;
        private MaterialButton btnMenuEmployeesAffairsSubDaysOff;
        private MaterialButton btnMenuEmployeesAffairsSubEmployeesManagement;
        private MaterialButton btnMenuClientsVendors;
        private MaterialCard pnlMenuClientAffairsSub;
        private MaterialButton btnMenuClientsVendorsSubClientsBalanceCheck;
        private MaterialButton btnMenuClientsVendorsSubClientsDefinitions;
        private MaterialButton btnMenuClientsVendorsSubVendorsDefinitions;
        private MaterialButton btnMenuClientsVendorsSubVendorBalanceCheck;
        private MaterialButton btnMenuClientsVendorsSubVendorItemsDefinitions;
        private MaterialButton btnMenuAlerts;
        private MaterialButton btnMenuTaxes;
        private MaterialCard pnlMenuTaxesSub;
        private MaterialButton btnMenuTaxesSubTaxZReport;
        private MaterialButton btnMenuUsers;
        private MaterialCard pnlMenuSettingsSub;
        private MaterialButton btnMenuSettingsSubPOSSettings;
        private MaterialButton btnMenuSettings;
        private MaterialButton btnMenuSettingsSubPrinterSettings;
        private MaterialButton btnMenuRefunds;
        private MaterialDivider materialDivider1;
        private MaterialDivider materialDivider4;
        private MaterialDivider materialDivider3;
        private MaterialDivider materialDivider2;
        private System.Windows.Forms.Timer hamburger_menu_inventory_sub_timer;
        private System.Windows.Forms.Timer hamburger_menu_expenses_sub_timer;
        private System.Windows.Forms.Timer hamburger_menu_employees_affairs_sub_timer;
        private System.Windows.Forms.Timer hamburger_menu_clients_affairs_sub_timer_Tick;
        private System.Windows.Forms.Timer hamburger_menu_taxes_sub_timer_Tick;
        private System.Windows.Forms.Timer hamburger_menu_settings_sub_timer_Tick;
        private System.Windows.Forms.Timer hamburger_menu_clients_affairs_sub_timer;
        private System.Windows.Forms.Timer hamburger_menu_taxes_sub_timer;
        private System.Windows.Forms.Timer hamburger_menu_settings_sub_timer;
        private System.Windows.Forms.CheckBox selectAllVendors;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientBillsPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientBillsRemainderAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public MaterialTextBox2 txtStoreAddress;
        public MaterialLabel lblStoreAddress;
        private Label label2;
        private Label label1;
        public DateTimePicker DateEmployeeTo;
        public DateTimePicker DateEmployeeFrom;
        private TabControl tabControl2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        public MaterialTextBox2 ClientEmail;
        public MaterialLabel lblEmail;
        public MaterialTextBox2 VendorEmail;
        public MaterialLabel lblVendorEmail;
        private DataGridViewTextBoxColumn Column20;
        private DataGridViewTextBoxColumn Column21;
        private DataGridViewTextBoxColumn Column23;
        private DataGridViewTextBoxColumn Column63;
        private DataGridViewTextBoxColumn Column24;
        private DataGridViewTextBoxColumn Column25;
        private DataGridViewTextBoxColumn Column27;
        private DataGridViewTextBoxColumn ClientIDDelete;
        private DataGridViewTextBoxColumn Column38;
        private DataGridViewTextBoxColumn Column39;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn VendorClientName;
        private DataGridViewTextBoxColumn VendorClientID;
        private DataGridViewTextBoxColumn VendorClientPhone;
        private DataGridViewTextBoxColumn VendorClientAddress;
        private DataGridViewTextBoxColumn Column11;
    }
}

