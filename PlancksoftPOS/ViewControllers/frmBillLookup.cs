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
    public partial class frmBillLookup : MaterialForm
    {
        Connection Connection = new Connection();
        public DialogResult dialogResult = new DialogResult();
        public Bill selectedBill = new Bill();
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

        public frmBillLookup(string UID)
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

            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveBills();
            dgvBills.DataSource = RetrievedBills.Item2;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "البحث عن فاتورة";
                btnClear.Text = "مسح";
                btnSearch.Text = "البحث";
                btnClose.Text = "الخروج";
                dgvBills.Columns["Column15"].HeaderText = "رقم الفاتوره";
                dgvBills.Columns["Column16"].HeaderText = "اسم الكاشير";
                dgvBills.Columns["Column17"].HeaderText = "المبلغ الصافي";
                dgvBills.Columns["Column18"].HeaderText = "المبلغ المدفوع";
                dgvBills.Columns["Column19"].HeaderText = "المبلغ الباقي";
                dgvBills.Columns["Column5"].HeaderText = "طريقة الدفع";
                dgvBills.Columns["Column64"].HeaderText = "التاريخ";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Bills Lookup";
                btnClear.Text = "Clear";
                btnSearch.Text = "Search";
                btnClose.Text = "Close";
                dgvBills.Columns["Column15"].HeaderText = "Bill ID";
                dgvBills.Columns["Column16"].HeaderText = "Cashier Name";
                dgvBills.Columns["Column17"].HeaderText = "Net Total";
                dgvBills.Columns["Column18"].HeaderText = "Paid Amount";
                dgvBills.Columns["Column19"].HeaderText = "Remainder";
                dgvBills.Columns["Column5"].HeaderText = "Payment Method";
                dgvBills.Columns["Column64"].HeaderText = "Date";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Tuple<List<Bill>, DataTable> RetrievedBills = Connection.server.RetrieveBills();
            dgvBills.DataSource = RetrievedBills.Item2;


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

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvBills.Rows.Clear();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvBills_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedBill.SetBillNumber(Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["Column15"].Value.ToString()));

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
