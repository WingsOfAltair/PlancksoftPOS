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
    public partial class frmPay : Form
    {
        public decimal totalAmount = 0;
        public decimal moneyPaid = 0;
        public decimal paidAmount = 0;
        public decimal remainderAmount = 0;
        public bool paybycash = false;

        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmPay(decimal totalAmount = 0)
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

            textBox2.Text = totalAmount.ToString();
            textBox3.Text = Convert.ToString(this.paidAmount - this.totalAmount);
            textBox1.Select();

            if (frmMain.Authority == 1)
            {
                discountRateNUD.Maximum = 100;
            }
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "الدفع";
                label3.Text = "المبلغ المطلوب";
                label2.Text = "الباقي";
                label1.Text = "المبلغ المدفوع";
                Cash.Text = "دفع كاش";
                Visa.Text = "دفع Visa";
                button11.Text = "دفع";
                button12.Text = "تأجيل الدفع";
                button13.Text = "اغلاق";
                button14.Text = "مسح";
                cbWithDiscount.Text = "مع خصم";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Payment";
                label3.Text = "Amount Required";
                label2.Text = "Remainder";
                label1.Text = "Paid Amount";
                Cash.Text = "Cash Payment";
                Visa.Text = "Visa Payment";
                button11.Text = "Pay";
                button12.Text = "Postpone Payment";
                button13.Text = "Close";
                button14.Text = "Clear";
                cbWithDiscount.Text = "With Discount";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void button13_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void button12_Click(object sender, EventArgs e)
        {
            this.moneyPaid = 0;
            this.dialogResult = DialogResult.Ignore;
            this.Close();
        }

        public void button11_Click(object sender, EventArgs e)
        {
            if (Cash.Checked)
                this.paybycash = true;
            else this.paybycash = false;
            this.moneyPaid = Convert.ToDecimal(textBox1.Text);
            this.dialogResult = DialogResult.OK;
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
                dialogResult = DialogResult.OK;
            } else if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.totalAmount = Convert.ToDecimal(textBox2.Text);
                this.paidAmount = Convert.ToDecimal(textBox1.Text);
                this.remainderAmount = this.paidAmount - this.totalAmount;
                textBox2.Text = this.totalAmount.ToString();
                textBox3.Text = this.remainderAmount.ToString();
            } catch(Exception error) { }
        }

        public void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
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

        public void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
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

        public void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
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

        public void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
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

        public void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.Select();
        }

        public void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void cbWithDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWithDiscount.Checked)
            {
                discountRateNUD.Enabled = true;
            } else
            {
                discountRateNUD.Enabled = false;
            }
        }

        public void discountRateNUD_ValueChanged(object sender, EventArgs e)
        {
            decimal discount = Convert.ToDecimal(textBox2.Text) * (discountRateNUD.Value / 100);
            decimal newPrice = Convert.ToDecimal(textBox2.Text) - discount;
            textBox2.Text = newPrice.ToString();
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
