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
    public partial class frmPickCustomerLookup : MaterialForm
    {
        Connection Connection = new Connection();
        public Customer pickedCustomer = new Customer();
        public DialogResult dialogResult;
        public int ID = 0;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmPickCustomerLookup()
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

            DataTable RetrievedCustomers = Connection.server.SearchCustomersInfo("", "").Item2;
            DGVCustomers.DataSource = RetrievedCustomers;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "اختيار الزبون";
                lblCustomerName.Text = "اسم الزبون";
                lblCustomerID.Text = "رمز الزبون";
                btnPickCustomer.Text = "اختيار الزبون";
                btnClose.Text = "اغلاق";
                btnClear.Text = "مسح";
                DGVCustomers.Columns["Column1"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["Column2"].HeaderText = "رقم الزبون";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Customer Picker";
                lblCustomerName.Text = "Customer Name";
                lblCustomerID.Text = "Customer ID";
                btnPickCustomer.Text = "Pick Customer";
                btnClose.Text = "Close";
                btnClear.Text = "Clear";
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "Client Name";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "Client ID";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPickCustomer_Click(object sender, EventArgs e)
        {
            if (!DGVCustomers.Rows[this.ID].IsNewRow)
            {
                pickedCustomer.CustomerID = Convert.ToInt32(DGVCustomers.Rows[this.ID].Cells[0].Value.ToString());
                pickedCustomer.CustomerName = DGVCustomers.Rows[this.ID].Cells[1].Value.ToString();

                dialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(".يجب عليك اختيار زبون من فضلك", Application.ProductName);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtCustomerID.Text = "";


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "رقم الزبون";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "Client Name";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "Client ID";
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.server.SearchCustomersInfo(txtCustomerName.Text, "").Item2;
            DGVCustomers.DataSource = RetrievedCustomers;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "رقم الزبون";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "Client Name";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "Client ID";
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.server.SearchCustomersInfo("", txtCustomerID.Text).Item2;
            DGVCustomers.DataSource = RetrievedCustomers;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "رقم الزبون";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["CustomerPickCustomerName"].HeaderText = "Client Name";
                DGVCustomers.Columns["CustomerPickCustomerID"].HeaderText = "Client ID";
            }
        }

        private void DGVCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ID = e.RowIndex;
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnPickCustomer.PerformClick();
        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnPickCustomer.PerformClick();
        }
    }
}
