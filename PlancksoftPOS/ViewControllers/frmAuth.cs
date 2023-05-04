using MaterialSkin.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PlancksoftPOS
{
    public partial class frmAuth : MaterialForm
    {
        public DialogResult dialogResult = new DialogResult();
        public string password;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;
        public frmAuth()
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            frmLogin.pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;

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

            txtAccountPassword.Focus();
            txtAccountPassword.Select();
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "ادخل كلمة السر للحساب";
                btnSubmit.Text = "تمام";
                btnCancel.Text = "اغلاق";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Enter the password to your account";
                btnSubmit.Text = "Submit";
                btnCancel.Text = "Close";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.password = txtAccountPassword.Text;
            dialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAccountPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
            {
                btnCancel.PerformClick();
            }
            else if (e.KeyChar == (Char)Keys.Escape)
            {
                btnSubmit.PerformClick();
            }
        }

        private void frmAuth_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    DialogResult exitDialog = FlexibleMaterialForm.Show(this, "هل أنت متأكد من رغبتك بالخروج؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    if (exitDialog == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else if (exitDialog == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    DialogResult exitDialog = FlexibleMaterialForm.Show(this, "Are you sure you would like to quit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    if (exitDialog == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else if (exitDialog == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception error)
            { }
        }
    }
}
