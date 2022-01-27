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
    internal partial class frmOpenRegister : Form
    {

        internal string cashierName;
        internal decimal moneyInRegister = 0;
        internal DialogResult dialogResult;

        internal frmOpenRegister(string cashierName = "")
        {
            InitializeComponent();
            this.cashierName = cashierName;
            this.label2.Text = this.cashierName;
            richTextBox1.AppendText(".الرجاء إدخال المبلغ لبدء التسجيل في الكاش في الأسفل");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.OK;
            this.moneyInRegister = numericUpDown1.Value;
            this.Close();
        }

        private void frmPayCash_Load(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
            numericUpDown1.Select();
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button2.PerformClick();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(1, 1);
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }
    }
}
