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

namespace PlancksoftPOS
{
    public partial class frmEditPrice : MaterialForm
    {
        public decimal moneyDeduction = 0;
        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmEditPrice()
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
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "تعديل السعر";
                lblEnterAmount.Text = "المبلغ المدفوع الجديد";
                btnCancel.Text = "عدم تعديل السعر";
                btnEditPrice.Text = "تعديل السعر";
                btnClear.Text = "مسح";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Price Edit";
                lblEnterAmount.Text = "New Paid Amount";
                btnCancel.Text = "Do not alter price";
                btnEditPrice.Text = "Alter price";
                btnClear.Text = "Clear";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            try
            {
                this.moneyDeduction = Convert.ToDecimal(txtAmount.Text);
                dialogResult = DialogResult.OK;
                this.Close();
            } catch(Exception err)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".المبلغ المدخل خطأ في الصيغة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("The entered number is invalid.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && txtAmount.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);

            if (e.KeyChar == (Char)Keys.Enter)
            {
                btnEditPrice.PerformClick();
            }
            else if (e.KeyChar == (Char)Keys.Escape)
            {
                dialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "9";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "8";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "7";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "6";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "5";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "4";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "3";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "2";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "1";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtAmount.Text += "0";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            txtAmount.Text += ".";
            txtAmount.SelectionStart = txtAmount.Text.Length;
            txtAmount.SelectionLength = 0;
            txtAmount.Select();
        }

        private void frmEditPrice_FormClosing(object sender, FormClosingEventArgs e)
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
