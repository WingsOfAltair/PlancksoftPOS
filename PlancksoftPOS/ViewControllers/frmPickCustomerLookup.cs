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
    public partial class frmPickClientLookup : MaterialForm
    {
        Connection Connection = new Connection();
        public Client pickedClient = new Client();
        public DialogResult dialogResult;
        public int ID = 0;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public bool eligible = false;

        public frmPickClientLookup()
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            frmLogin.pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;

            DataTable RetrievedClients = Connection.server.SearchClientsInfo("", "");

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;

                if (RetrievedClients == null || RetrievedClients.Rows.Count < 1)
                {
                    FlexibleMaterialForm.Show(this, ".الرحاء تعريف عميل للحصول على تخويل للدخول", "!لا يوجد تعريف مسبق لعميل",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, false,
                        FlexibleMaterialForm.ButtonsPosition.Center);
                    this.Close();
                    return;
                } else
                {
                    this.eligible = true;
                }
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;

                if (RetrievedClients == null || RetrievedClients.Rows.Count < 1)
                {
                    FlexibleMaterialForm.Show(this, "Please define a client to be eligible for entry.", "No predefined defined clients!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, false,
                        FlexibleMaterialForm.ButtonsPosition.Center);
                    this.Close();
                    return;
                }
                else
                {
                    this.eligible = true;
                }
            }

            applyLocalizationOnUI();

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
                DGVClients.Columns["ClientPickClientName"].HeaderText = "إسم العميل";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "رقم العميل";
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
                DGVClients.Columns["ClientPickClientName"].HeaderText = "Client Name";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "Client ID";
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
            try
            {
                if (!DGVClients.Rows[this.ID].IsNewRow)
                {
                    pickedClient.ClientID = Convert.ToInt32(DGVClients.Rows[this.ID].Cells["ClientPickClientID"].Value.ToString());
                    pickedClient.ClientName = DGVClients.Rows[this.ID].Cells["ClientPickClientName"].Value.ToString();

                    dialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MaterialMessageBox.Show(".يجب عليك اختيار زبون من فضلك", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    return;
                }
            } catch(Exception ex)
            {
                MaterialMessageBox.Show(".يجب عليك اختيار زبون من فضلك", false, FlexibleMaterialForm.ButtonsPosition.Center);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtClientName.Text = "";
            txtClientID.Text = "";


            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClients.Columns["ClientPickClientName"].HeaderText = "اسم العميل";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "رقم العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClients.Columns["ClientPickClientName"].HeaderText = "Client Name";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "Client ID";
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedClients = Connection.server.SearchClientsInfo(txtClientName.Text, "");
            DGVClients.DataSource = RetrievedClients;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClients.Columns["ClientPickClientName"].HeaderText = "اسم العميل";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "رقم العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClients.Columns["ClientPickClientName"].HeaderText = "Client Name";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "Client ID";
            }
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            DataTable RetrievedClients = Connection.server.SearchClientsInfo("", txtClientID.Text);
            DGVClients.DataSource = RetrievedClients;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                DGVClients.Columns["ClientPickClientName"].HeaderText = "اسم العميل";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "رقم العميل";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                DGVClients.Columns["ClientPickClientName"].HeaderText = "Client Name";
                DGVClients.Columns["ClientPickClientID"].HeaderText = "Client ID";
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

        private void frmPickClientLookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.exited)
            {
                Program.exited = true;
                this.Close();
            }
        }

        private void frmPickClientLookup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
