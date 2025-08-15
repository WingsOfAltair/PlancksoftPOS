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
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Microsoft.TeamFoundation.Common;

namespace PlancksoftPOS
{
    public partial class frmPay : MaterialForm
    {
        public decimal originalTotal = 0;
        public decimal totalAmount = 0;
        public decimal moneyPaid = 0;
        public decimal paidAmount = 0;
        public decimal remainderAmount = 0;
        public bool paybycash = true;
        public decimal discountedAmount = 0;

        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmPay(decimal totalAmount = 0, decimal paidAmount = -9999, decimal remainderAmount = -9999, bool postponed = false, bool hideDiscounts = false)
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

            originalTotal = totalAmount;
            txtRequiredAmount.Text = totalAmount.ToString();
            txtRemainderAmount.Text = Convert.ToString(this.totalAmount - this.paidAmount);
            if (paidAmount != -9999)
            {
                this.totalAmount = totalAmount;
                this.paidAmount = paidAmount;
                this.remainderAmount = remainderAmount;
                txtRemainderAmount.Text = Convert.ToString(this.remainderAmount);
            }
            txtPaidAmount.Select();

            rbCash.Checked = true;
            rbVisa.Checked = false;

            if (frmMain.Authority == 1)
            {
                nudDiscountRate.Maximum = 100;
            }

            if (postponed)
            {
                btnClientPay.Enabled = false;
                btnClientPay.Visible = false;

                btnDelayPayment.Enabled = false;
                btnDelayPayment.Visible = false;
            }
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "الدفع";
                lblRequiredAmount.Text = "المبلغ المطلوب";
                lblRemainderAmount.Text = "الباقي";
                lblPaidAmount.Text = "المبلغ المدفوع";
                rbCash.Text = "دفع كاش";
                rbVisa.Text = "دفع Visa";
                btnPay.Text = "دفع";
                btnClientPay.Text = "دفع عميل";
                btnDelayPayment.Text = "تأجيل الدفع";
                btnCancel.Text = "اغلاق";
                btnClear.Text = "مسح";
                cbWithDiscount.Text = "مع خصم";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Payment";
                lblRequiredAmount.Text = "Amount Required";
                lblRemainderAmount.Text = "Remainder";
                lblPaidAmount.Text = "Paid Amount";
                rbCash.Text = "Cash Payment";
                rbVisa.Text = "Visa Payment";
                btnPay.Text = "Pay";
                btnClientPay.Text = "Client Pay";
                btnDelayPayment.Text = "Postpone Payment";
                btnCancel.Text = "Close";
                btnClear.Text = "Clear";
                cbWithDiscount.Text = "With Discount";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text = "";
            txtRemainderAmount.Text = "";
            nudDiscountRate.Value = 0;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "9";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "8";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "7";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "6";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "5";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "4";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "3";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "2";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "1";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += "0";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text += ".";
            txtPaidAmount.SelectionStart = txtPaidAmount.Text.Length;
            txtPaidAmount.SelectionLength = 0;
            txtPaidAmount.Select();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (rbCash.Checked)
                this.paybycash = true;
            else this.paybycash = false;
            this.totalAmount = originalTotal;
            this.moneyPaid = Convert.ToDecimal(txtPaidAmount.Text);
            this.dialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelayPayment_Click(object sender, EventArgs e)
        {
            this.totalAmount = originalTotal;
            this.moneyPaid = 0;
            this.dialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void cbWithDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWithDiscount.Checked)
            {
                nudDiscountRate.Enabled = true;
            }
            else
            {
                nudDiscountRate.Enabled = false;
            }
            nudDiscountRate.Value = 0;
            txtRequiredAmount.Text = originalTotal.ToString();
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.totalAmount = Convert.ToDecimal(txtRequiredAmount.Text);
                this.paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                this.remainderAmount = Convert.ToDecimal(txtRequiredAmount.Text) - this.paidAmount;
                //txtRequiredAmount.Text = this.totalAmount.ToString();
                txtRemainderAmount.Text = this.remainderAmount.ToString();
            }
            catch (Exception error) { }
        }

        private void nudDiscountRate_ValueChanged(object sender, EventArgs e)
        {
            decimal discount = Convert.ToDecimal(txtRequiredAmount.Text) * (nudDiscountRate.Value / 100);
            discountedAmount = discount;
            decimal newPrice = Convert.ToDecimal(txtRequiredAmount.Text) - discount;
            txtRequiredAmount.Text = newPrice.ToString();
        }

        private void txtRequiredAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.totalAmount = Convert.ToDecimal(txtRequiredAmount.Text);
                this.paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                this.remainderAmount = Convert.ToDecimal(txtRequiredAmount.Text) - this.paidAmount;
                //txtRequiredAmount.Text = this.totalAmount.ToString();
                txtRemainderAmount.Text = this.remainderAmount.ToString();
            }
            catch (Exception error) { }
        }

        private void btnClientPay_Click(object sender, EventArgs e)
        {
            if (!txtPaidAmount.Text.IsNullOrEmpty())
            {
                if (rbCash.Checked)
                    this.paybycash = true;
                else this.paybycash = false;
                this.moneyPaid = Convert.ToDecimal(txtPaidAmount.Text);
                this.totalAmount = originalTotal;
                this.dialogResult = DialogResult.Retry;
                this.Close();
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".الرجاء إدخال مبلغ الدفع", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    return;
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Please enter the payment amount.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    return;
                }
            }
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnPay.PerformClick();
        }

        private void frmPay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.exited)
            {
                Program.exited = true;
                this.Close();
            }
        }

        private void frmPay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
