using DataAccessLayer;
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
    public partial class frmSales : Form
    {
        public Connection Connection = new Connection();
        public List<Item> saleItems = new List<Item>();

        public DialogResult dialogResult;

        public frmSales()
        {
            InitializeComponent();
        }

        public void searchItemName_TextChanged(object sender, EventArgs e)
        {
            if (searchItemName.Text != "")
            {
                Tuple<List<Item>, DataTable> RetrievedItems;
                RetrievedItems = Connection.server.SearchItems(searchItemName.Text, "", 0);
                searchItemDGV.DataSource = RetrievedItems.Item2;
            }
        }

        public void searchItemBarCode_TextChanged(object sender, EventArgs e)
        {
            if (searchItemBarCode.Text != "")
            {
                Tuple<List<Item>, DataTable> RetrievedItems;
                RetrievedItems = Connection.server.SearchItems("", searchItemBarCode.Text, 0);
                searchItemDGV.DataSource = RetrievedItems.Item2;
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
        }
    }
}
