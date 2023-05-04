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
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Globalization;

namespace PlancksoftPOS
{
    public partial class frmSales : MaterialForm
    {
        public Connection Connection = new Connection();
        public List<Item> saleItems = new List<Item>();

        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmSales()
        {
            InitializeComponent();

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
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "Sales";
                lblItemName.Text = "إسم القطعه";
                lblItemBarcode.Text = "باركود القطعه";
                lblDiscountPercentage.Text = "نسبة الخصم بالمئه (رقم)";
                lblDiscountedItemQuantity.Text = "عدد قطع الخصم";
                lblDiscountStart.Text = "تاريخ بدء الخصم";
                lblDiscountEnd.Text = "تاريخ إنتهاء الخصم";
                btnDiscountConfirm.Text = "تأكيد الخصم";
                btnClear.Text = "مسح";
                btnClose.Text = "إغلاق";
                searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "رقم القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه بعد الضريبه";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Discounts";
                lblItemName.Text = "Item Name";
                lblItemBarcode.Text = "Item Barcode";
                lblDiscountPercentage.Text = "Percentage of Sale";
                lblDiscountedItemQuantity.Text = "Quantity of on sale items";
                lblDiscountStart.Text = "Sale start date";
                lblDiscountEnd.Text = "Sale end date";
                btnDiscountConfirm.Text = "Commit Sale";
                btnClear.Text = "Clear";
                btnClose.Text = "Close";
                searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Item ID";
                searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Item Price";
                searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Item Price Tax";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (txtItemName.Text != "")
            {
                Tuple<List<Item>, DataTable> RetrievedItems;
                RetrievedItems = Connection.server.SearchItems(txtItemName.Text, "", 0);
                searchItemDGV.DataSource = RetrievedItems.Item2;


                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "رقم القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه بعد الضريبه";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Item ID";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Item Price";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Item Price Tax";
                }
            }
        }

        private void txtItemBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtItemBarcode.Text != "")
            {
                Tuple<List<Item>, DataTable> RetrievedItems;
                RetrievedItems = Connection.server.SearchItems("", txtItemBarcode.Text, 0);
                searchItemDGV.DataSource = RetrievedItems.Item2;


                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "رقم القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر القطعة";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه بعد الضريبه";
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Item ID";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Item Price";
                    searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Item Price Tax";
                }
            }
        }

        private void btnDiscountConfirm_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataGridViewRow item in searchItemDGV.Rows)
            {
                if (nudDiscountPercentage.Text != "")
                {
                    if (!item.IsNewRow && !found)
                    {
                        Item newItem = new Item();
                        if (item.Selected)
                        {
                            newItem.SetName(item.Cells[1].Value.ToString());
                            newItem.SetBarCode(item.Cells[2].Value.ToString());
                            newItem.SetSaleRate(Convert.ToInt32(nudDiscountPercentage.Text));
                            newItem.DateStart = dtpDiscountStart.Value;
                            newItem.DateEnd = dtpDiscountEnd.Value;
                            newItem.QuantityEnd = Convert.ToInt32(nudDiscountItemQuantity.Value);
                            saleItems.Add(newItem);

                            found = true;
                            dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        if (!found)
                            MaterialMessageBox.Show(".الرجاء اختيار ماده من الجدول اعلاه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                else
                {
                    MaterialMessageBox.Show("Please enter a sale rate", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            txtItemName.SelectionStart = txtItemName.Text.Length;
            txtItemName.SelectionLength = 0;
            txtItemName.Select();
        }

        private void nudDiscountPercentage_Enter(object sender, EventArgs e)
        {
            nudDiscountPercentage.Select(1, 1);
        }

        private void frmSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtItemBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void saleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemName.Text = "";
            txtItemBarcode.Text = "";
            nudDiscountPercentage.Value = 0;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "رقم القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه بعد الضريبه";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Item ID";
                searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Item Price";
                searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Item Price Tax";
            }
        }

        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    DialogResult exitDialog = FlexibleMaterialForm.Show(this, "هل أنت متأكد من رغبتك بالخروج؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    if (exitDialog == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else if (exitDialog == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    DialogResult exitDialog = FlexibleMaterialForm.Show(this, "Are you sure you would like to quit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    if (exitDialog == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else if (exitDialog == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception error)
            { }
        }
    }
}
