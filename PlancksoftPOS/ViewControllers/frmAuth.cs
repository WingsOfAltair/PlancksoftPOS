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
    public partial class frmAuth : Form
    {
        public DialogResult dialogResult = new DialogResult();
        public string password;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmAuth()
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

            textBox1.Focus();
            textBox1.Select();
        }



        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "ادخل كلمة السر للحساب";
                button1.Text = "تمام";
                button2.Text = "اغلاق";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Enter the password to your account";
                button1.Text = "Submit";
                button2.Text = "Close";
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
            this.password = textBox1.Text;
            dialogResult = DialogResult.OK;
            this.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
            العربيةToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
            PlancksoftPOS.Dispose();
            applyLocalizationOnUI();
        }
    }
}
