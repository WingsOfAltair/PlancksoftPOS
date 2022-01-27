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
    internal partial class frmCloseRegister : Form
    {

        private decimal moneyInRegister;
        internal DialogResult dialogResult;
        Connection Connection = new Connection();

        internal frmCloseRegister(string cashierName, decimal moneyInRegister)
        {
            InitializeComponent();
            this.moneyInRegister = moneyInRegister;
            label2.Text = cashierName;
            richTextBox1.AppendText(".الرجاء إدخال موجودات النقد في الكاش في الخانه في الأسفل");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= this.moneyInRegister && numericUpDown1.Value >= Connection.GetTotalSalesAmount())
            {
                this.dialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(".المال في الصندوق أقل من مال فتح الصندوق لذلك لا يمكن اتمام العمليه");
                return;
            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
