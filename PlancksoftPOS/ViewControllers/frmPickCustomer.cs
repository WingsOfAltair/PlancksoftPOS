using Dependencies;
using PlancksoftPOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlancksoftPOS
{
    public partial class frmPickCustomer : Form
    {
        Connection Connection = new Connection();
        public Customer pickedCustomer = new Customer();
        public DialogResult dialogResult;
        public int ID = 0;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmPickCustomer()
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

            DataTable RetrievedCustomers = Connection.server.SearchCustomers("", "", "");
            DGVCustomers.DataSource = RetrievedCustomers;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "اختيار الزبون";
                groupBox1.Text = "جدول الزبائن";
                label1.Text = "اسم الزبون";
                label2.Text = "رمز الزبون";
                button1.Text = "اختيار الزبون";
                button2.Text = "اغلاق";
                button3.Text = "مسح";
                DGVCustomers.Columns["Column1"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["Column2"].HeaderText = "رقم الزبون";
                DGVCustomers.Columns["Column3"].HeaderText = "اسم الماده";
                DGVCustomers.Columns["Column4"].HeaderText = "باركود الماده";
                DGVCustomers.Columns["Column5"].HeaderText = "سعر العميل";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Customer Picker";
                groupBox1.Text = "Customers Grid";
                label1.Text = "Customer Name";
                label2.Text = "Customer ID";
                button1.Text = "Pick Customer";
                button2.Text = "Close";
                button3.Text = "Clear";
                DGVCustomers.Columns["Column1"].HeaderText = "Customer Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Customer ID";
                DGVCustomers.Columns["Column3"].HeaderText = "Item Name";
                DGVCustomers.Columns["Column4"].HeaderText = "Item Barcode";
                DGVCustomers.Columns["Column5"].HeaderText = "Client Price";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (!DGVCustomers.Rows[this.ID].IsNewRow) {
                pickedCustomer.CustomerID = Convert.ToInt32(DGVCustomers.Rows[this.ID].Cells[1].Value.ToString());
                pickedCustomer.CustomerName = DGVCustomers.Rows[this.ID].Cells[0].Value.ToString();

                dialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show(".يجب عليك اختيار زبون من فضلك", Application.ProductName);
                return;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.server.SearchCustomers(textBox1.Text, "", "");
            DGVCustomers.DataSource = RetrievedCustomers;


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["Column2"].HeaderText = "رقم الزبون";
                DGVCustomers.Columns["Column3"].HeaderText = "اسم الماده";
                DGVCustomers.Columns["Column4"].HeaderText = "باركود الماده";
                DGVCustomers.Columns["Column5"].HeaderText = "سعر العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "Customer Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Customer ID";
                DGVCustomers.Columns["Column3"].HeaderText = "Item Name";
                DGVCustomers.Columns["Column4"].HeaderText = "Item Barcode";
                DGVCustomers.Columns["Column5"].HeaderText = "Client Price";
            }
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.server.SearchCustomers("", textBox2.Text, "");
            DGVCustomers.DataSource = RetrievedCustomers;


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["Column2"].HeaderText = "رقم الزبون";
                DGVCustomers.Columns["Column3"].HeaderText = "اسم الماده";
                DGVCustomers.Columns["Column4"].HeaderText = "باركود الماده";
                DGVCustomers.Columns["Column5"].HeaderText = "سعر العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "Customer Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Customer ID";
                DGVCustomers.Columns["Column3"].HeaderText = "Item Name";
                DGVCustomers.Columns["Column4"].HeaderText = "Item Barcode";
                DGVCustomers.Columns["Column5"].HeaderText = "Client Price";
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["Column2"].HeaderText = "رقم الزبون";
                DGVCustomers.Columns["Column3"].HeaderText = "اسم الماده";
                DGVCustomers.Columns["Column4"].HeaderText = "باركود الماده";
                DGVCustomers.Columns["Column5"].HeaderText = "سعر العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "Customer Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Customer ID";
                DGVCustomers.Columns["Column3"].HeaderText = "Item Name";
                DGVCustomers.Columns["Column4"].HeaderText = "Item Barcode";
                DGVCustomers.Columns["Column5"].HeaderText = "Client Price";
            }
        }

        public void DGVCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ID = e.RowIndex;
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        public void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
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
