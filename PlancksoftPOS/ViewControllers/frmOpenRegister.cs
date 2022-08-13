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
    public partial class frmOpenRegister : Form
    {

        public string cashierName;
        public decimal moneyInRegister = 0;
        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmOpenRegister(string cashierName = "")
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

            this.cashierName = cashierName;
            this.label2.Text = this.cashierName;
            richTextBox1.AppendText(".الرجاء إدخال المبلغ لبدء التسجيل في الكاش في الأسفل");
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "افتح الكاش";
                richTextBox1.Clear();
                richTextBox1.AppendText(".الرجاء إدخال موجودات النقد في الكاش في الخانه في الأسفل");
                label1.Text = "أدخل المبلغ في الصندوق";
                button2.Text = "فتح";
                button1.Text = "اغلاق";
                button3.Text = "مسح";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Open Cash Register";
                richTextBox1.Clear();
                richTextBox1.AppendText("Please enter the amount of cash located inside of the cash register in the field below.");
                label1.Text = "Enter amount of cash in cash register";
                button2.Text = "Open";
                button1.Text = "Close";
                button3.Text = "Clear";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.OK;
            this.moneyInRegister = numericUpDown1.Value;
            this.Close();
        }

        public void frmPayCash_Load(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
            numericUpDown1.Select();
        }

        public void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
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

        public void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(1, 1);
        }

        public void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void العربيةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
