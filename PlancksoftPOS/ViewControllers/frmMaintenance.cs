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
using System.Security.Cryptography;

namespace PlancksoftPOS
{
    public partial class frmMaintenance : MaterialForm
    {
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmMaintenance()
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
                Text = "عن البرمجية";
                btnClose.Text = "إغلاق";
                lblPlancksoft1.Text = "تم تصميم و برمجة هذا النظام من قبل مؤسسة Plancksoft";
                lblPlancksoft2.Text = ":للإستفسارات والصيانة, الرجاء الإتصال بالرقم التالي";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "About";
                btnClose.Text = "Close";
                lblPlancksoft1.Text = "This software system was designed and programmed by Plancksoft";
                lblPlancksoft2.Text = "For inquiries and maintenance, please contact the number below:";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMaintenance_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
