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
    public partial class frmSales : Form
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
                Text = "Sales";
                label53.Text = "اسم القطعه";
                label54.Text = "باركود القطعه";
                label1.Text = "نسبة الخصم بالمئه (رقم)";
                label4.Text = "عدد قطع الخصم)";
                label2.Text = "تاريخ بدء الخصم)";
                label3.Text = "تاريخ انتهاء الخصم)";
                button1.Text = "تأكيد الخصم";
                button2.Text = "اغلاق";
                button3.Text = "مسح";
                searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "رقم القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "باركود القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "عدد القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "سعر القطعة";
                searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "سعر القطعه بعد الضريبه";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Discounts";
                label53.Text = "Item Name";
                label54.Text = "Item Barcode";
                label1.Text = "Percentage of Sale";
                label4.Text = "Quantity of on sale items";
                label2.Text = "Sale start date";
                label3.Text = "Sale end date";
                button1.Text = "Commit Sale";
                button2.Text = "Close";
                button3.Text = "Clear";
                searchItemDGV.Columns["dataGridViewTextBoxColumn41"].HeaderText = "Item ID";
                searchItemDGV.Columns["dataGridViewTextBoxColumn1"].HeaderText = "Item Name";
                searchItemDGV.Columns["dataGridViewTextBoxColumn2"].HeaderText = "Item Barcode";
                searchItemDGV.Columns["dataGridViewTextBoxColumn3"].HeaderText = "Item Quantity";
                searchItemDGV.Columns["dataGridViewTextBoxColumn4"].HeaderText = "Item Price";
                searchItemDGV.Columns["dataGridViewTextBoxColumn5"].HeaderText = "Item Price Tax";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void searchItemName_TextChanged(object sender, EventArgs e)
        {
            if (searchItemName.Text != "")
            {
                Tuple<List<Item>, DataTable> RetrievedItems;
                RetrievedItems = Connection.server.SearchItems(searchItemName.Text, "", 0);
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

        public void searchItemBarCode_TextChanged(object sender, EventArgs e)
        {
            if (searchItemBarCode.Text != "")
            {
                Tuple<List<Item>, DataTable> RetrievedItems;
                RetrievedItems = Connection.server.SearchItems("", searchItemBarCode.Text, 0);
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

        public void button1_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataGridViewRow item in searchItemDGV.Rows)
            {
                if (saleRate.Text != "")
                {
                    if (!item.IsNewRow && !found)
                    {
                        Item newItem = new Item();
                        if (item.Selected)
                        {
                            newItem.SetName(item.Cells[1].Value.ToString());
                            newItem.SetBarCode(item.Cells[2].Value.ToString());
                            newItem.SetSaleRate(Convert.ToInt32(saleRate.Text));
                            newItem.DateStart = dateTimePicker1.Value;
                            newItem.DateEnd = dateTimePicker2.Value;
                            newItem.QuantityEnd = Convert.ToInt32(SaleQuantity.Value);
                            saleItems.Add(newItem);

                            found = true;
                            dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    } else
                    {
                        if (!found)
                            MessageBox.Show(".الرجاء اختيار ماده من الجدول اعلاه", Application.ProductName);
                    }
                } else
                {
                    MessageBox.Show("Please enter a sale rate", Application.ProductName);
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void frmSales_Load(object sender, EventArgs e)
        {
            searchItemName.SelectionStart = searchItemName.Text.Length;
            searchItemName.SelectionLength = 0;
            searchItemName.Select();
        }

        public void saleRate_Enter(object sender, EventArgs e)
        {
            saleRate.Select(1, 1);
        }

        public void frmSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public void searchItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public void searchItemBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public void saleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            searchItemName.Text = "";
            searchItemBarCode.Text = "";
            saleRate.Value = 0;

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
