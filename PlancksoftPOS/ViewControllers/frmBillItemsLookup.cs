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
using System.Reflection;

namespace PlancksoftPOS
{
    public partial class frmBillItemsLookup : MaterialForm
    {
        Connection Connection = new Connection();
        public DialogResult dialogResult = new DialogResult();
        public Item selectedItem = new Item();
        string UID;
        int BillNumber = -1;
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

        public frmBillItemsLookup(int BillID, string UID)
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
            this.BillNumber = BillID;

            try
            {
                Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveBillItems(BillNumber);
                dgvBillItems.DataSource = RetrievedItems.Item2;
            }
            catch (Exception ex)
            {
                DataTable Item = new DataTable();
                dgvBillItems.DataSource = Item;
            }
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "البحث عن المواد في الفاتورة";
                btnClear.Text = "مسح";
                btnSearch.Text = "البحث";
                btnClose.Text = "الخروج";
                dgvBillItems.Columns["Column20"].HeaderText = "اسم الماده";
                dgvBillItems.Columns["Column21"].HeaderText = "باركود الماده";
                dgvBillItems.Columns["Column23"].HeaderText = "عدد البيع";
                dgvBillItems.Columns["Column63"].HeaderText = "العدد من أصل";
                dgvBillItems.Columns["Column24"].HeaderText = "السعر";
                dgvBillItems.Columns["Column25"].HeaderText = "السعر بعد الضريبه";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Bill Items Lookup";
                btnClear.Text = "Clear";
                btnSearch.Text = "Search";
                btnClose.Text = "Close";
                dgvBillItems.Columns["Column20"].HeaderText = "Item Name";
                dgvBillItems.Columns["Column21"].HeaderText = "Item Barcode";
                dgvBillItems.Columns["Column23"].HeaderText = "Sold Quantity";
                dgvBillItems.Columns["Column63"].HeaderText = "Original Quantity";
                dgvBillItems.Columns["Column24"].HeaderText = "Price";
                dgvBillItems.Columns["Column25"].HeaderText = "Price after Tax";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<List<Item>, DataTable> RetrievedItems = Connection.server.RetrieveBillItems(BillNumber);
                dgvBillItems.DataSource = RetrievedItems.Item2;
            }
            catch (Exception ex)
            {
                DataTable Item = new DataTable();
                dgvBillItems.DataSource = Item;
            }


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

        private void btnClear_Click(object sender, EventArgs e)
        {
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvBillItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedItem.SetName(dgvBillItems.Rows[e.RowIndex].Cells["Column20"].Value.ToString());
                selectedItem.SetBarCode(dgvBillItems.Rows[e.RowIndex].Cells["Column21"].Value.ToString());
                selectedItem.SetTimesSold(Convert.ToInt32(dgvBillItems.Rows[e.RowIndex].Cells["Column23"].Value.ToString()));

                this.dialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(".الرجاء الاختيار مره اخرى", Application.ProductName);
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
