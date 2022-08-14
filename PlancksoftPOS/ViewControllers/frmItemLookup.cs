using Dependencies;
using PlancksoftPOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlancksoftPOS
{
    public partial class frmItemLookup : Form
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

            frmLogin.pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
                العربيةToolStripMenuItem.Checked = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
                englishToolStripMenuItem.Checked = true;
            }

            applyLocalizationOnUI();

            this.UID = UID;

            foreach(KeyValuePair<int, string> itemType in itemtypes)
            {
                comboBox1.Items.Add(new ItemTypeCategory(itemType.Value));
            }

            DGVItemsLookup.DataSource = Connection.server.SearchItems("", "", 0);
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "البحث عن المواد";
                label1.Text = "اسم الماده";
                label2.Text = "باركود الماده";
                label3.Text = "تصنيف الماده";
                label4.Text = "عدد القطع";
                button2.Text = "مسح";
                button1.Text = "البحث";
                button3.Text = "الخروج";
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
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Items Lookup";
                label1.Text = "Item Name";
                label2.Text = "Item Barcode";
                label3.Text = "Item Type";
                label4.Text = "Item Amount";
                button2.Text = "Clear";
                button1.Text = "Search";
                button3.Text = "Close";
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
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            ItemNametxt.Text = "";
            ItemBarCodetxt.Text = "";
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

        public void button1_Click(object sender, EventArgs e)
        {
            int ItemTypeID;
            if (comboBox1.SelectedItem != null)
                ItemTypeID = Connection.server.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
            else ItemTypeID = 0;
            DGVItemsLookup.DataSource = Connection.server.SearchItems(ItemNametxt.Text, ItemBarCodetxt.Text, ItemTypeID).Item2;


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

        public void button3_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void DGVItemsLookup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedItem.SetName(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemName"].Value.ToString());
                selectedItem.SetBarCode(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemBarCode"].Value.ToString());
                selectedItem.SetQuantity(Convert.ToInt32(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemQuantity"].Value.ToString()));
                selectedItem.SetBuyPrice(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemBuyPrice"].Value.ToString()));
                selectedItem.SetPrice(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemPrice"].Value.ToString()));
                selectedItem.SetPriceTax(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells["ItemPriceTax"].Value.ToString()));
                if (comboBox1.Text != "")
                {
                    int ItemTypeID = Connection.server.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
                    selectedItem.SetItemTypeID(ItemTypeID);
                } else
                {
                    selectedItem.SetItemTypeID(0);
                }
                selectedItem.vendorQuantity = Convert.ToInt32(numericUpDown1.Value);

                this.dialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            } catch (Exception error)
            {
                MessageBox.Show(".الرجاء الاختيار مره اخرى", Application.ProductName);
                return;
            }
        }

        public void ItemNametxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            button1.PerformClick();
        }

        public void ItemBarCodetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        public void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        public void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
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

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void العربيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.pickedLanguage = LanguageChoice.Languages.Arabic;
            Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.Arabic;
            Settings.Default.Save();
            englishToolStripMenuItem.Checked = false;
            العربيةToolStripMenuItem.Checked = true;
            PlancksoftPOS.Dispose();
            applyLocalizationOnUI();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.pickedLanguage = LanguageChoice.Languages.English;
            Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.English;
            Settings.Default.Save();
            englishToolStripMenuItem.Checked = true;
            العربيةToolStripMenuItem.Checked = false;
            PlancksoftPOS.Dispose();
            applyLocalizationOnUI();
        }
    }
}
