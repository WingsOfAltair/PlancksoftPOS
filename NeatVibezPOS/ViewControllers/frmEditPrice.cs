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
    public partial class frmEditPrice : Form
    {

        public decimal moneyDeduction = 0;
        public DialogResult dialogResult;

        public frmEditPrice()
        {
            InitializeComponent();
        }

        public void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button11_Click(object sender, EventArgs e)
        {
            this.moneyDeduction = Convert.ToDecimal(textBox1.Text);
            dialogResult = DialogResult.OK;
            this.Close();
        }

        public void button12_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBox1.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);

            if (e.KeyChar == (Char)Keys.Enter)
            {
                button11.PerformClick();
            } else if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
