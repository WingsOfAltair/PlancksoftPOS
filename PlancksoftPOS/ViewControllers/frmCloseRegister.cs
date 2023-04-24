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
    public partial class frmCloseRegister : MaterialForm
    {
        Connection Connection = new Connection();
        public decimal moneyInRegister;
        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmCloseRegister(string cashierName, decimal moneyInRegister)
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

            this.moneyInRegister = moneyInRegister;
            lblCashierName.Text = cashierName;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "اغلق الكاش";
                rtbDescription.Clear();
                rtbDescription.AppendText(".الرجاء إدخال موجودات النقد في الكاش في الخانه في الأسفل");
                lblEnterMoneyAmountInCash.Text = "أدخل المبلغ في الصندوق";
                btnCancel.Text = "إلغاء";
                btnSubmit.Text = "إتمام";
                btnClear.Text = "مسح";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Close Cash Register";
                rtbDescription.Clear();
                rtbDescription.AppendText("Please enter the amount of cash located inside of the cash register in the field below.");
                lblEnterMoneyAmountInCash.Text = "Enter the amount located inside of the cash register";
                btnCancel.Text = "Cancel";
                btnSubmit.Text = "Submit";
                btnClear.Text = "Clear";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBox.Show("The cash amount inside the cash register is less than the opening amount, therefore you cannot complete this operation.", Application.ProductName);
                }
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnSubmit.PerformClick();
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
