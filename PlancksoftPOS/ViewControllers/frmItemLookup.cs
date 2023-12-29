using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dependencies;
using PlancksoftPOS.Properties;
using System.Globalization;

namespace PlancksoftPOS
{
    public partial class frmItemLookup : MaterialForm
    {
        Connection Connection = new Connection();
        public DialogResult dialogResult = new DialogResult();
        public Item selectedItem = new Item();
        string UID;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

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

        public frmItemLookup(SortedList<int, string> itemtypes, string UID)
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            frmLogin.pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }

            applyLocalizationOnUI();

            this.UID = UID;

            foreach (KeyValuePair<int, string> itemType in itemtypes)
            {
                cbItemType.Items.Add(new ItemTypeCategory(itemType.Value));
            }

            DGVItemsLookup.DataSource = Connection.server.SearchItems("", "", 0);
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "البحث عن المواد";
                lblItemName.Text = "اسم الماده";
                lblItemBarcode.Text = "باركود الماده";
                lblItemType.Text = "تصنيف الماده";
                lblItemQuantity.Text = "عدد القطع";
                btnClear.Text = "مسح";
                btnSearch.Text = "البحث";
                btnClose.Text = "الخروج";
                DGVItemsLookup.Columns["ItemID"].HeaderText = "رقم القطعه";
                DGVItemsLookup.Columns["ItemName"].HeaderText = "اسم القطعه";
                DGVItemsLookup.Columns["ItemBarCode"].HeaderText = "باركود القطعه";
                DGVItemsLookup.Columns["ItemQuantity"].HeaderText = "عدد القطعه";
                DGVItemsLookup.Columns["ItemBuyPrice"].HeaderText = "سعر الشراء";
                DGVItemsLookup.Columns["ItemPrice"].HeaderText = "سعر البيع";
                DGVItemsLookup.Columns["ItemPriceTax"].HeaderText = "سعر البيع مع الضريبه";
                DGVItemsLookup.Columns["WarehouseID"].HeaderText = "رقم المستودع";
                DGVItemsLookup.Columns["Warehouse"].HeaderText = "المستودع";
                DGVItemsLookup.Columns["ItemType"].HeaderText = "رقم تصنيف الماده";
                DGVItemsLookup.Columns["ItemTypeName"].HeaderText = "تصنيف الماده";
                DGVItemsLookup.Columns["FavoriteCategory"].HeaderText = "رقم المجلد المفضل";
                DGVItemsLookup.Columns["FavoriteCategoryName"].HeaderText = "المجلد المفضل";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Items Lookup";
                lblItemName.Text = "Item Name";
                lblItemBarcode.Text = "Item Barcode";
                lblItemType.Text = "Item Type";
                lblItemQuantity.Text = "Item Amount";
                btnClear.Text = "Clear";
                btnSearch.Text = "Search";
                btnClose.Text = "Close";
                DGVItemsLookup.Columns["ItemID"].HeaderText = "Item ID";
                DGVItemsLookup.Columns["ItemName"].HeaderText = "Item Name";
                DGVItemsLookup.Columns["ItemBarCode"].HeaderText = "Item Barcode";
                DGVItemsLookup.Columns["ItemQuantity"].HeaderText = "Item Quantity";
                DGVItemsLookup.Columns["ItemBuyPrice"].HeaderText = "Item Buy Price";
                DGVItemsLookup.Columns["ItemPrice"].HeaderText = "Item Price";
                DGVItemsLookup.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                DGVItemsLookup.Columns["WarehouseID"].HeaderText = "Warehouse ID";
                DGVItemsLookup.Columns["Warehouse"].HeaderText = "Warehouse";
                DGVItemsLookup.Columns["ItemType"].HeaderText = "Item Type ID";
                DGVItemsLookup.Columns["ItemTypeName"].HeaderText = "Item Type";
                DGVItemsLookup.Columns["FavoriteCategory"].HeaderText = "Favorite Category ID";
                DGVItemsLookup.Columns["FavoriteCategoryName"].HeaderText = "Favorite Category";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ItemTypeID;
            if (cbItemType.SelectedItem != null)
                ItemTypeID = Connection.server.RetrieveItemTypeID(cbItemType.SelectedItem.ToString());
            else ItemTypeID = 0;
            DGVItemsLookup.DataSource = Connection.server.SearchItems(txtItemName.Text, txtItemBarcode.Text, ItemTypeID).Item2;


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVItemsLookup.Columns["ItemID"].HeaderText = "رقم القطعه";
                DGVItemsLookup.Columns["ItemName"].HeaderText = "اسم القطعه";
                DGVItemsLookup.Columns["ItemBarCode"].HeaderText = "باركود القطعه";
                DGVItemsLookup.Columns["ItemQuantity"].HeaderText = "عدد القطعه";
                DGVItemsLookup.Columns["ItemBuyPrice"].HeaderText = "سعر الشراء";
                DGVItemsLookup.Columns["ItemPrice"].HeaderText = "سعر البيع";
                DGVItemsLookup.Columns["ItemPriceTax"].HeaderText = "سعر البيع مع الضريبه";
                DGVItemsLookup.Columns["WarehouseID"].HeaderText = "رقم المستودع";
                DGVItemsLookup.Columns["Warehouse"].HeaderText = "المستودع";
                DGVItemsLookup.Columns["ItemType"].HeaderText = "رقم تصنيف الماده";
                DGVItemsLookup.Columns["ItemTypeName"].HeaderText = "تصنيف الماده";
                DGVItemsLookup.Columns["FavoriteCategory"].HeaderText = "رقم المجلد المفضل";
                DGVItemsLookup.Columns["FavoriteCategoryName"].HeaderText = "المجلد المفضل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVItemsLookup.Columns["ItemID"].HeaderText = "Item ID";
                DGVItemsLookup.Columns["ItemName"].HeaderText = "Item Name";
                DGVItemsLookup.Columns["ItemBarCode"].HeaderText = "Item Barcode";
                DGVItemsLookup.Columns["ItemQuantity"].HeaderText = "Item Quantity";
                DGVItemsLookup.Columns["ItemBuyPrice"].HeaderText = "Item Buy Price";
                DGVItemsLookup.Columns["ItemPrice"].HeaderText = "Item Price";
                DGVItemsLookup.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                DGVItemsLookup.Columns["WarehouseID"].HeaderText = "Warehouse ID";
                DGVItemsLookup.Columns["Warehouse"].HeaderText = "Warehouse";
                DGVItemsLookup.Columns["ItemType"].HeaderText = "Item Type ID";
                DGVItemsLookup.Columns["ItemTypeName"].HeaderText = "Item Type";
                DGVItemsLookup.Columns["FavoriteCategory"].HeaderText = "Favorite Category ID";
                DGVItemsLookup.Columns["FavoriteCategoryName"].HeaderText = "Favorite Category";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemName.Text = "";
            txtItemBarcode.Text = "";
            cbItemType.SelectedIndex = -1;
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVItemsLookup.Columns["ItemID"].HeaderText = "رقم القطعه";
                DGVItemsLookup.Columns["ItemName"].HeaderText = "اسم القطعه";
                DGVItemsLookup.Columns["ItemBarCode"].HeaderText = "باركود القطعه";
                DGVItemsLookup.Columns["ItemQuantity"].HeaderText = "عدد القطعه";
                DGVItemsLookup.Columns["ItemBuyPrice"].HeaderText = "سعر الشراء";
                DGVItemsLookup.Columns["ItemPrice"].HeaderText = "سعر البيع";
                DGVItemsLookup.Columns["ItemPriceTax"].HeaderText = "سعر البيع مع الضريبه";
                DGVItemsLookup.Columns["WarehouseID"].HeaderText = "رقم المستودع";
                DGVItemsLookup.Columns["Warehouse"].HeaderText = "المستودع";
                DGVItemsLookup.Columns["ItemType"].HeaderText = "رقم تصنيف الماده";
                DGVItemsLookup.Columns["ItemTypeName"].HeaderText = "تصنيف الماده";
                DGVItemsLookup.Columns["FavoriteCategory"].HeaderText = "رقم المجلد المفضل";
                DGVItemsLookup.Columns["FavoriteCategoryName"].HeaderText = "المجلد المفضل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVItemsLookup.Columns["ItemID"].HeaderText = "Item ID";
                DGVItemsLookup.Columns["ItemName"].HeaderText = "Item Name";
                DGVItemsLookup.Columns["ItemBarCode"].HeaderText = "Item Barcode";
                DGVItemsLookup.Columns["ItemQuantity"].HeaderText = "Item Quantity";
                DGVItemsLookup.Columns["ItemBuyPrice"].HeaderText = "Item Buy Price";
                DGVItemsLookup.Columns["ItemPrice"].HeaderText = "Item Price";
                DGVItemsLookup.Columns["ItemPriceTax"].HeaderText = "Item Price Tax";
                DGVItemsLookup.Columns["WarehouseID"].HeaderText = "Warehouse ID";
                DGVItemsLookup.Columns["Warehouse"].HeaderText = "Warehouse";
                DGVItemsLookup.Columns["ItemType"].HeaderText = "Item Type ID";
                DGVItemsLookup.Columns["ItemTypeName"].HeaderText = "Item Type";
                DGVItemsLookup.Columns["FavoriteCategory"].HeaderText = "Favorite Category ID";
                DGVItemsLookup.Columns["FavoriteCategoryName"].HeaderText = "Favorite Category";
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
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
                printer.Title = "تقرير المواد";
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
                printer.PrintDataGridView(DGVItemsLookup);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DGVItemsLookup_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedItem.SetName(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemName"].Value.ToString());
                selectedItem.SetBarCode(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemBarCode"].Value.ToString());
                selectedItem.SetQuantity(Convert.ToInt32(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemQuantity"].Value.ToString()));
                selectedItem.SetBuyPrice(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemBuyPrice"].Value.ToString()));
                selectedItem.SetPrice(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemPrice"].Value.ToString()));
                selectedItem.SetPriceTax(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemPriceTax"].Value.ToString()));
                if (cbItemType.Text != "")
                {
                    int ItemTypeID = Connection.server.RetrieveItemTypeID(cbItemType.SelectedItem.ToString());
                    selectedItem.SetItemTypeID(ItemTypeID);
                }
                else
                {
                    selectedItem.SetItemTypeID(0);
                }
                selectedItem.vendorQuantity = Convert.ToInt32(nudItemQuantity.Value);

                this.dialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".الرجاء الاختيار مره اخرى", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please pick again.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                return;
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnSearch.PerformClick();
        }

        private void txtItemBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnSearch.PerformClick();
        }

        private void nudItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnSearch.PerformClick();
        }

        private void cbItemType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnSearch.PerformClick();
        }

        private void frmItemLookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.exited)
            {
                Program.exited = true;
                this.Close();
            }
        }

        private void frmItemLookup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
