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
    public partial class frmCloseRegister : Form
    {

        public decimal moneyInRegister;
        public DialogResult dialogResult;
        Connection Connection = new Connection();

        public frmCloseRegister(string cashierName, decimal moneyInRegister)
        {
            InitializeComponent();
            this.moneyInRegister = moneyInRegister;
            label2.Text = cashierName;
            richTextBox1.AppendText(".الرجاء إدخال موجودات النقد في الكاش في الخانه في الأسفل");
        }

        public void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= this.moneyInRegister && numericUpDown1.Value >= Connection.server.GetTotalSalesAmount())
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

        public void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
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
