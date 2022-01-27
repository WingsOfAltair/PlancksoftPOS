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
    public partial class frmAuth : Form
    {
        public DialogResult dialogResult = new DialogResult();
        public string password;

        public frmAuth()
        {
            InitializeComponent();
            textBox1.Focus();
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.password = textBox1.Text;
            dialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
            {
                button1.PerformClick();
            } else if (e.KeyChar == (Char)Keys.Escape)
            {
                button2.PerformClick();
            }
        }
    }
}
