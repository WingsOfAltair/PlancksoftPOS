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
    public partial class frmEditPrinter : MaterialForm
    {
        public int printerID = 0;
        public string printerName, machineName;
        public DialogResult dialogResult;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmEditPrinter(int printerID, string printerName, string machineName)
        {
            InitializeComponent();

            this.printerID = printerID;
            this.printerName = printerName;
            this.machineName = machineName;
            txtPrinterName.Text = printerName;
            txtMachineName.Text = machineName;

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
                Text = "تعديل الطابعه";
                lblPrinterName.Text = "إسم الطابعه";
                lblMachineName.Text = "إسم الجهاز";
                btnEditPrinter.Text = "تعديل الطابعه";
                btnClose.Text = "إغلاق";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Printer Edit";
                lblPrinterName.Text = "Printer Name";
                lblMachineName.Text = "Machine Name";
                btnEditPrinter.Text = "Edit Printer";
                btnClose.Text = "Close";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmEditPrice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.exited)
            {
                Program.exited = true;
                this.Close();
            }
        }

        private void btnEditPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                Connection connection = new Connection();
                if (connection.server.UpdatePrinters(printerID, txtPrinterName.Text, txtMachineName.Text))
                {
                    dialogResult = DialogResult.OK;
                    this.Close();
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم نتمكن من تحديث بياتات الطابعه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("Could not update printer details.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
            }
            catch (Exception err)
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نتمكن من تحديث بياتات الطابعه", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Could not update printer details.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                return;
            }
        }
    }
}
