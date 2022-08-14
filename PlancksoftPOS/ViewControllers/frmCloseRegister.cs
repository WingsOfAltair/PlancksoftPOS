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
    public partial class frmCloseRegister : Form
    {

        public decimal moneyInRegister;
        public DialogResult dialogResult;
        Connection Connection = new Connection();
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmCloseRegister(string cashierName, decimal moneyInRegister)
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

            this.moneyInRegister = moneyInRegister;
            label2.Text = cashierName;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "اغلق الكاش";
                richTextBox1.Clear();
                richTextBox1.AppendText(".الرجاء إدخال موجودات النقد في الكاش في الخانه في الأسفل");
                label1.Text = "أدخل المبلغ في الصندوق";
                button2.Text = "اغلاق";
                button1.Text = "الغاء";
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
                Text = "Close Cash Register";
                richTextBox1.Clear();
                richTextBox1.AppendText("Please enter the amount of cash located inside of the cash register in the field below.");
                label1.Text = "Enter the amount located inside of the cash register";
                button2.Text = "Close";
                button1.Text = "Cancel";
                button3.Text = "Clear";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
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
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBox.Show(".المال في الصندوق أقل من مال فتح الصندوق لذلك لا يمكن اتمام العمليه", Application.ProductName);
                } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("The cash amount inside the cash register is less than the opening amount, therefore you cannot complete this operation.", Application.ProductName);
                }
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
