using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dependencies;
using PlancksoftPOS.Properties;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Globalization;

namespace PlancksoftPOS
{
    public partial class frmRegisterAdmin : MaterialForm
    {
        public Connection Connection = new Connection();
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmRegisterAdmin()
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }

            applyLocalizationOnUI();
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "تسجيل الحساب الإداري";
                lblUID.Text = "رمز المستخدم الإداري";
                lblPassword.Text = "الكلمه السريه";
                lblAdminName.Text = "اسم المستخدم (رئيس قسم الصيانه)";
                btnRegisterAdmin.Text = "التسجيل";
                btnClear.Text = "مسح";
                btnClose.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Administrator ِAccount Registration";
                lblUID.Text = "Admin Account ID";
                lblPassword.Text = "Password";
                lblAdminName.Text = "User Name (Head of IT)";
                btnRegisterAdmin.Text = "Register";
                btnClear.Text = "Clear";
                btnClose.Text = "Close";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtAdminName.Text = "";
        }

        private void btnRegisterAdmin_Click(object sender, EventArgs e)
        {
            if (txtUID.Text != "" && txtPassword.Text != "" && txtAdminName.Text != "")
            {
                Account newAccount = new Account();
                newAccount.SetAccountUID(txtUID.Text);
                newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPassword.Text, "PlancksoftPOS"));
                newAccount.SetAccountName(txtAdminName.Text);
                newAccount.Client_card_edit = true;
                newAccount.discount_edit = true;
                newAccount.price_edit = true;
                newAccount.receipt_edit = true;
                newAccount.inventory_edit = true;
                newAccount.expenses_add = true;
                newAccount.users_edit = true;
                newAccount.settings_edit = true;
                newAccount.personnel_edit = true;
                newAccount.openclose_edit = true;
                newAccount.sell_edit = true;

                if (Connection.server.RegisterAdmin(newAccount))
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".تم تسجيل الحساب الاداري", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("The Administrative Account was registered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    this.Hide();
                    Application.OpenForms[0].Show();
                    this.Close();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تسجيل الحساب الاداري", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("We were unable to register the Administrator account.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
                btnRegisterAdmin.PerformClick();
        }

        private void txtAdminName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnRegisterAdmin.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmRegisterAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.exited)
            {
                Program.exited = true;
                this.Close();
            }
        }

        private void frmRegisterAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
