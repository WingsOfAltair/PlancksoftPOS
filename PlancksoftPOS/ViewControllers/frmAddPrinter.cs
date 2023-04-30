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

namespace PlancksoftPOS
{
    public partial class frmAddPrinter : MaterialForm
    {
        SortedList<int, string> itemTypes;
        public string itemTypeName;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmAddPrinter(SortedList<int, string> itemtypes)
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            this.itemTypes = itemtypes;
            foreach (KeyValuePair<int, string> item in itemtypes)
            {
                cbItemTypes.Items.Add(item.Value);
            }

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
                Text = "إضافة صنف مواد لطابعة";
                lblItemTypes.Text = "أصناف المواد";
                btnCancel.Text = "إضافة صتف";
                btnAddItemType.Text = "الغاء";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "ِAdd an Item Type to Printer";
                lblItemTypes.Text = "Item Types";
                btnCancel.Text = "Add Type";
                btnAddItemType.Text = "Close";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnAddItemType_Click(object sender, EventArgs e)
        {
            try
            {
                this.itemTypeName = this.cbItemTypes.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            } catch(Exception err)
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لم نستطع إختيار طابعه لصنف الماده", false, FlexibleMaterialForm.ButtonsPosition.Center);
                } else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("Could not add printer to Item Type.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Program.materialSkinManager.RemoveFormToManage(this);
            this.Close();
        }

        private void frmAddPrinter_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
