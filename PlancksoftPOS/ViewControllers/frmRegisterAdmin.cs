using Dependencies;
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
    public partial class frmRegisterAdmin : Form
    {
        public Connection Connection = new Connection();
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmRegisterAdmin()
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
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "تسجيل الحساب الإداري";
                label1.Text = "رمز المستخدم الإداري";
                label2.Text = "الكلمه السريه";
                label3.Text = "اسم المستخدم (رئيس قسم الصيانه)";
                BtnRegister.Text = "التسجيل";
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
                Text = "Administrator ِAccount Registration";
                label1.Text = "Admin Account ID";
                label2.Text = "Password";
                label3.Text = "User Name (Head of IT)";
                BtnRegister.Text = "Register";
                button3.Text = "Clear";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtUID.Text != "" && txtPWD.Text != "" && txtFname.Text != "")
            {
                Account newAccount = new Account();
                newAccount.SetAccountUID(txtUID.Text);
                newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPWD.Text, "PlancksoftPOS"));
                newAccount.SetAccountName(txtFname.Text);
                newAccount.customer_card_edit = true;
                newAccount.discount_edit = true;
                newAccount.price_edit = true;
                newAccount.receipt_edit = true;
                newAccount.inventory_edit = true;
                newAccount.expenses_add = true;
                newAccount.users_edit = true;
                newAccount.settings_edit = true;
                newAccount.personnel_edit = true;
                newAccount.openclose_edit = true;

                if (Connection.server.RegisterAdmin(newAccount))
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم تسجيل الحساب الاداري", Application.ProductName);
                    } else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("The Administrative Account was registered.", Application.ProductName);
                    }
                    this.Hide();
                    Application.OpenForms[0].Show();
                    this.Close();
                }
                else MessageBox.Show(".لم نتمكن من تسجيل الحساب الاداري");
            }
        }

        public void frmRegisterAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                /*(switch (e.CloseReason)
               {
                   case CloseReason.UserClosing:
                       e.Cancel = true;
                       return;
               }*/
            }
            catch (Exception error)
            { }
        }

        public void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
        }

        public void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            txtPWD.Text = "";
            txtFname.Text = "";
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
