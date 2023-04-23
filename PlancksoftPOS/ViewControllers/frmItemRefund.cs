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
    public partial class frmItemRefund : MaterialForm
    {
        Connection Connection = new Connection();
        SortedList<int, string> itemtypes = new SortedList<int, string>();
        string UID;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmItemRefund(SortedList<int, string> itemtypes, string UID)
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

            this.itemtypes = itemtypes;
            this.UID = UID;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "ارجاع المواد";
                lblItemName.Text = "اسم الماده";
                lblItemBarcode.Text = "باركود الماده";
                lblItemQuantity.Text = "عدد القطع";
                btnItemSelect.Text = "اختيار الماده";
                btnItemReturn.Text = "ارجاع الماده";
                btnCancel.Text = "الغاء";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Items Return";
                lblItemName.Text = "Item Name";
                lblItemBarcode.Text = "Item Barcode";
                lblItemQuantity.Text = "Item Amount";
                btnItemSelect.Text = "Pick Item";
                btnItemReturn.Text = "Return Item";
                btnCancel.Text = "Close";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnItemSelect_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);

                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        txtItemName.Text = itemLookup.selectedItem.ItemName;
                        txtItemBarcode.Text = itemLookup.selectedItem.ItemBarCode;
                    }
                    catch (Exception error)
                    {

                    }
                }
            }
            catch (Exception error)
            {

            }
        }

        private void btnItemReturn_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text != "" && txtItemBarcode.Text != "")
            {
                if (Connection.server.ReturnItem(txtItemName.Text, txtItemBarcode.Text, Convert.ToInt32(ItemQuantitynud.Value), this.UID))
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم ارجاع الماده للمستودع", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("The item was returned to the warehouse.", Application.ProductName);
                    }
                    this.Close();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم يتم ارجاع الماده للمستودع", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("The item was not returned to the warehouse.", Application.ProductName);
                    }
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
