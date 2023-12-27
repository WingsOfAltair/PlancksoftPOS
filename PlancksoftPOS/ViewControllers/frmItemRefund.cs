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
        int BillID = -1;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;
        bool keepRunning = true;

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
                lblBillID.Text = "رقم الفاتورة";
                btnItemSelect.Text = "اختيار الماده";
                btnSelectBill.Text = "إختيار الفاتورة";
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
                lblBillID.Text = "Bill ID";
                btnItemSelect.Text = "Pick Item";
                btnSelectBill.Text = "Select Bill";
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
                BillID = Convert.ToInt32(txtBillID.Text);
                frmBillItemsLookup BillItemLookup = new frmBillItemsLookup(BillID, this.UID);

                BillItemLookup.ShowDialog(this);
                if (BillItemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        txtItemName.Text = BillItemLookup.selectedItem.ItemName;
                        txtItemBarcode.Text = BillItemLookup.selectedItem.ItemBarCode;
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

        private void btnSelectBill_Click(object sender, EventArgs e)
        {
            try
            {
                frmBillLookup billLookup = new frmBillLookup(this.UID);

                billLookup.ShowDialog(this);
                if (billLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        txtBillID.Text = billLookup.selectedBill.getBillNumber().ToString();
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
                        MaterialMessageBox.Show(".تم ارجاع الماده للمستودع", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("The item was returned to the warehouse.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    keepRunning = !keepRunning;
                    this.Close();
                }
                else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MaterialMessageBox.Show(".لم يتم ارجاع الماده للمستودع", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MaterialMessageBox.Show("The item was not returned to the warehouse.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            keepRunning = !keepRunning;
            if (!keepRunning)
                this.Close();
        }

        private void frmItemRefund_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!keepRunning)
            {
                if (!Program.exited)
                {
                    Program.exited = true;
                    this.Close();

                }
            } else
            {
                e.Cancel = true;
            }
        }

        private void frmItemRefund_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!keepRunning)
            {
                Program.exited = false;
                Program.materialSkinManager.RemoveFormToManage(this);
            }
        }
    }
}
