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
    public partial class frmPickCustomerLookup : Form
    {
        Connection Connection = new Connection();
        public Customer pickedCustomer = new Customer();
        public DialogResult dialogResult;
        public int ID = 0;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmPickCustomerLookup()
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

            DataTable RetrievedCustomers = Connection.server.SearchCustomersInfo("", "").Item2;
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
                button3.Text = "مسح";
                button1.Text = "اختيار الزبون";
                button2.Text = "اغلاق";
                DGVCustomers.Columns["Column1"].HeaderText = "اسم الزبون";
                DGVCustomers.Columns["Column2"].HeaderText = "رقم الزبون";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Client Picker";
                groupBox1.Text = "Clients Grid";
                label1.Text = "Client Name";
                label2.Text = "Client ID";
                button3.Text = "Clear";
                button1.Text = "Pick Client";
                button2.Text = "Close";
                DGVCustomers.Columns["Column1"].HeaderText = "Client Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Client ID";
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
                pickedCustomer.CustomerID = Convert.ToInt32(DGVCustomers.Rows[this.ID].Cells[0].Value.ToString());
                pickedCustomer.CustomerName = DGVCustomers.Rows[this.ID].Cells[1].Value.ToString();

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
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "Client Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Client ID";
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
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "Client Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Client ID";
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
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVCustomers.Columns["Column1"].HeaderText = "Client Name";
                DGVCustomers.Columns["Column2"].HeaderText = "Client ID";
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
