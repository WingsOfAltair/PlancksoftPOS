using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeatVibezPOS
{
    internal partial class frmSales : Form
    {
        private Connection Connection = new Connection();
        internal List<Item> saleItems = new List<Item>();

        internal DialogResult dialogResult;

        internal frmSales()
        {
            InitializeComponent();
        }

        private void searchItemName_TextChanged(object sender, EventArgs e)
        {
            if (searchItemName.Text != "")
            {
                Tuple<Item[], DataTable> RetrievedItems;
                RetrievedItems = Connection.SearchItems(searchItemName.Text, "");
                searchItemDGV.DataSource = RetrievedItems.Item2;
            }
        }

        private void searchItemBarCode_TextChanged(object sender, EventArgs e)
        {
            if (searchItemBarCode.Text != "")
            {
                Tuple<Item[], DataTable> RetrievedItems;
                RetrievedItems = Connection.SearchItems("", searchItemBarCode.Text);
                searchItemDGV.DataSource = RetrievedItems.Item2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            searchItemName.SelectionStart = searchItemName.Text.Length;
            searchItemName.SelectionLength = 0;
            searchItemName.Select();
        }

        private void saleRate_Enter(object sender, EventArgs e)
        {
            saleRate.Select(1, 1);
        }

        private void frmSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void searchItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void searchItemBarCode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            searchItemName.Text = "";
            searchItemBarCode.Text = "";
            saleRate.Value = 0;
        }
    }
}
