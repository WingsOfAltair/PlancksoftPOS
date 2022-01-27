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
    public partial class frmPickCustomer : Form
    {
        Connection Connection = new Connection();
        internal Customer pickedCustomer = new Customer();
        internal DialogResult dialogResult;
        private int ID = 0;

        public frmPickCustomer()
        {
            InitializeComponent();
            DataTable RetrievedCustomers = Connection.SearchCustomers("", "");
            DGVCustomers.DataSource = RetrievedCustomers;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.SearchCustomers(textBox1.Text, "");
            DGVCustomers.DataSource = RetrievedCustomers;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedCustomers = Connection.SearchCustomers("", textBox2.Text);
            DGVCustomers.DataSource = RetrievedCustomers;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void DGVCustomers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ID = e.RowIndex;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }
    }
}
