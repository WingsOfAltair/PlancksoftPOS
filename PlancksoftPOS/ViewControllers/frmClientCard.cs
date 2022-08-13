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
    public partial class frmClientCard : Form
    {
        Connection Connection = new Connection();
        public Customer customer = new Customer();
        public DialogResult dialogResult;
        public List<Item> saleItems = new List<Item>();
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;


        public frmClientCard()
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
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "شاشة بطاقة العميل";
                groupBox1.Text = "البحث عن العميل";
                label1.Text = "اسم العميل";
                label2.Text = "اسم الماده";
                button3.Text = "مسح";
                button1.Text = "بحث";
                button2.Text = "خروج";
                dgvCustomers.Columns["Column1"].HeaderText = "اسم العميل";
                dgvCustomers.Columns["Column2"].HeaderText = "رمز العميل";
                dgvCustomers.Columns["Column3"].HeaderText = "اسم الماده";
                dgvCustomers.Columns["Column4"].HeaderText = "سعر العميل";
                dgvCustomers.Columns["Column5"].HeaderText = "باركود الماده";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Client Card Module";
                groupBox1.Text = "Client Search";
                label1.Text = "Client Name";
                label2.Text = "Item Name";
                button3.Text = "Clear";
                button1.Text = "Search";
                button2.Text = "Close";
                dgvCustomers.Columns["Column1"].HeaderText = "Client Name";
                dgvCustomers.Columns["Column2"].HeaderText = "Client ID";
                dgvCustomers.Columns["Column3"].HeaderText = "Item Name";
                dgvCustomers.Columns["Column4"].HeaderText = "Client Price";
                dgvCustomers.Columns["Column5"].HeaderText = "Item Barcode";
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
            DataTable RetrievedCustomers = Connection.server.SearchCustomers(customerName.Text, "", itemName.Text);
            dgvCustomers.DataSource = RetrievedCustomers;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                dgvCustomers.Columns["Column1"].HeaderText = "اسم العميل";
                dgvCustomers.Columns["Column2"].HeaderText = "رمز العميل";
                dgvCustomers.Columns["Column3"].HeaderText = "اسم الماده";
                dgvCustomers.Columns["Column4"].HeaderText = "سعر العميل";
                dgvCustomers.Columns["Column5"].HeaderText = "باركود الماده";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                dgvCustomers.Columns["Column1"].HeaderText = "Client Name";
                dgvCustomers.Columns["Column2"].HeaderText = "Client ID";
                dgvCustomers.Columns["Column3"].HeaderText = "Item Name";
                dgvCustomers.Columns["Column4"].HeaderText = "Client Price";
                dgvCustomers.Columns["Column5"].HeaderText = "Item Barcode";
            }
        }

        public void dgvCustomers_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                customer.CustomerName = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                customer.CustomerID = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString());


                bool found = false;
                foreach (DataGridViewRow item in dgvCustomers.Rows)
                {
                    if (!item.IsNewRow && !found)
                    {
                        Item newItem = new Item();
                        if (item.Selected)
                        {
                            newItem.SetName(item.Cells[2].Value.ToString());
                            newItem.SetBarCode(item.Cells[3].Value.ToString());
                            newItem.customerPrice = Convert.ToDecimal(item.Cells[4].Value.ToString());
                            saleItems.Add(newItem);

                            found = true;
                            dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        if (!found)
                        {
                            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                            {
                                MessageBox.Show(".الرجاء اختيار ماده من الجدول اعلاه", Application.ProductName);
                            }
                        }
                        else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                        {
                            MessageBox.Show("Please pick an item from the grid above.", Application.ProductName);
                        }
                    }
                }

                dialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception error)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".لم نستطع اختيار مادة العميل", Application.ProductName);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("Unable to choose customer item.", Application.ProductName);
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void customerName_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.server.SearchCustomers(customerName.Text, "", "");
            dgvCustomers.DataSource = RetrievedCustomers;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            customerName.Text = "";
        }

        public void button4_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.None;
            this.Close();
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
