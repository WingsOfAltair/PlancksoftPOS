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
    public partial class frmPickClient : MaterialForm
    {
        Connection Connection = new Connection();
        public Client pickedClient = new Client();
        public DialogResult dialogResult;
        public int ID = 0;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmPickClient(SortedList<int, string> itemtypes, string UID)
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

            DataTable RetrievedClients = Connection.server.SearchClients("", "", "");
            DGVClients.DataSource = RetrievedClients;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "اختيار العميل";
                lblClientName.Text = "اسم العميل";
                lblClientID.Text = "رمز العميل";
                btnPickClient.Text = "اختيار العميل";
                btnClose.Text = "اغلاق";
                btnClear.Text = "مسح";
                DGVClients.Columns["Column1"].HeaderText = "اسم العميل";
                DGVClients.Columns["Column2"].HeaderText = "رقم العميل";
                DGVClients.Columns["Column3"].HeaderText = "اسم الماده";
                DGVClients.Columns["Column4"].HeaderText = "باركود الماده";
                DGVClients.Columns["Column5"].HeaderText = "سعر العميل";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Client Picker";
                lblClientName.Text = "Client Name";
                lblClientID.Text = "Client ID";
                btnPickClient.Text = "Pick Client";
                btnClose.Text = "Close";
                btnClear.Text = "Clear";
                DGVClients.Columns["Column1"].HeaderText = "Client Name";
                DGVClients.Columns["Column2"].HeaderText = "Client ID";
                DGVClients.Columns["Column3"].HeaderText = "Item Name";
                DGVClients.Columns["Column4"].HeaderText = "Item Barcode";
                DGVClients.Columns["Column5"].HeaderText = "Client Price";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPickClient_Click(object sender, EventArgs e)
        {
            if (!DGVClients.Rows[this.ID].IsNewRow)
            {
                pickedClient.ClientID = Convert.ToInt32(DGVClients.Rows[this.ID].Cells[1].Value.ToString());
                pickedClient.ClientName = DGVClients.Rows[this.ID].Cells[0].Value.ToString();

                dialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(".يجب عليك اختيار زبون من فضلك", Application.ProductName);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            txtClientID.Text = "";

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClients.Columns["Column1"].HeaderText = "اسم العميل";
                DGVClients.Columns["Column2"].HeaderText = "رقم العميل";
                DGVClients.Columns["Column3"].HeaderText = "اسم الماده";
                DGVClients.Columns["Column4"].HeaderText = "باركود الماده";
                DGVClients.Columns["Column5"].HeaderText = "سعر العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClients.Columns["Column1"].HeaderText = "Client Name";
                DGVClients.Columns["Column2"].HeaderText = "Client ID";
                DGVClients.Columns["Column3"].HeaderText = "Item Name";
                DGVClients.Columns["Column4"].HeaderText = "Item Barcode";
                DGVClients.Columns["Column5"].HeaderText = "Client Price";
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedClients = Connection.server.SearchClients(txtClientName.Text, "", "");
            DGVClients.DataSource = RetrievedClients;


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClients.Columns["Column1"].HeaderText = "اسم العميل";
                DGVClients.Columns["Column2"].HeaderText = "رقم العميل";
                DGVClients.Columns["Column3"].HeaderText = "اسم الماده";
                DGVClients.Columns["Column4"].HeaderText = "باركود الماده";
                DGVClients.Columns["Column5"].HeaderText = "سعر العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClients.Columns["Column1"].HeaderText = "Client Name";
                DGVClients.Columns["Column2"].HeaderText = "Client ID";
                DGVClients.Columns["Column3"].HeaderText = "Item Name";
                DGVClients.Columns["Column4"].HeaderText = "Item Barcode";
                DGVClients.Columns["Column5"].HeaderText = "Client Price";
            }
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedClients = Connection.server.SearchClients("", txtClientID.Text, "");
            DGVClients.DataSource = RetrievedClients;


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClients.Columns["Column1"].HeaderText = "اسم العميل";
                DGVClients.Columns["Column2"].HeaderText = "رقم العميل";
                DGVClients.Columns["Column3"].HeaderText = "اسم الماده";
                DGVClients.Columns["Column4"].HeaderText = "باركود الماده";
                DGVClients.Columns["Column5"].HeaderText = "سعر العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClients.Columns["Column1"].HeaderText = "Client Name";
                DGVClients.Columns["Column2"].HeaderText = "Client ID";
                DGVClients.Columns["Column3"].HeaderText = "Item Name";
                DGVClients.Columns["Column4"].HeaderText = "Item Barcode";
                DGVClients.Columns["Column5"].HeaderText = "Client Price";
            }
        }

        private void DGVClients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ID = e.RowIndex;
        }

        private void txtClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnPickClient.PerformClick();
        }

        private void txtClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnPickClient.PerformClick();
        }
    }
}
