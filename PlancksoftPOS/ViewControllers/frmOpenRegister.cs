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

namespace PlancksoftPOS
{
    public partial class frmOpenRegister : MaterialForm
    {
        public string cashierName;
        public decimal moneyInRegister = 0;
        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmOpenRegister(string cashierName = "")
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

            this.cashierName = cashierName;
            this.lblCashierName.Text = this.cashierName;
            rtbDescription.AppendText(".الرجاء إدخال المبلغ لبدء التسجيل في الكاش في الأسفل");
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "افتح الكاش";
                rtbDescription.Clear();
                rtbDescription.AppendText(".الرجاء إدخال موجودات النقد في الكاش في الخانه في الأسفل");
                lblEnterMoneyAmountInCash.Text = "أدخل المبلغ في الصندوق";
                btnSubmit.Text = "فتح";
                btnCancel.Text = "اغلاق";
                btnClear.Text = "مسح";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Open Cash Register";
                rtbDescription.Clear();
                rtbDescription.AppendText("Please enter the amount of cash located inside of the cash register in the field below.");
                lblEnterMoneyAmountInCash.Text = "Enter amount of cash in cash register";
                btnSubmit.Text = "Open";
                btnCancel.Text = "Cancel";
                btnClear.Text = "Clear";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.OK;
            this.moneyInRegister = nudAmountMoneyEntered.Value;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            nudAmountMoneyEntered.Value = 0;
        }

        private void nudAmountMoneyEntered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void frmOpenRegister_Load(object sender, EventArgs e)
        {
            nudAmountMoneyEntered.Focus();
            nudAmountMoneyEntered.Select();
        }

        private void nudAmountMoneyEntered_Enter(object sender, EventArgs e)
        {
            nudAmountMoneyEntered.Select(1, 1);
        }

        private void frmOpenRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    DialogResult exitDialog = FlexibleMaterialForm.Show(this, "هل أنت متأكد من رغبتك بالخروج؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, false, FlexibleMaterialForm.ButtonsPosition.Center);
                    if (exitDialog == DialogResult.Yes)
                    {
                        this.Close();
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
                        this.Close();
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
