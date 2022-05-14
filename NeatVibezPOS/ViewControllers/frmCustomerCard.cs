using Dependencies;
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
    public partial class frmCustomerCard : Form
    {
        Connection Connection = new Connection();
        public Customer customer = new Customer();
        public DialogResult dialogResult;
        public List<Item> saleItems = new List<Item>();


        public frmCustomerCard()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.server.SearchCustomers(customerName.Text, "", itemName.Text);
            dgvCustomers.DataSource = RetrievedCustomers;
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
                            MessageBox.Show(".الرجاء اختيار ماده من الجدول اعلاه", Application.ProductName);
                    }
                }

                dialogResult = DialogResult.OK;
                this.Close();
            } catch (Exception error)
            {
                MessageBox.Show(".لم نستطع اختيار مادة العميل", Application.ProductName);
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
    }
}
