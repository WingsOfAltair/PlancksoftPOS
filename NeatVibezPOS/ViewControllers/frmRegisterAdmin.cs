using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeatVibezPOS
{
    public partial class frmRegisterAdmin : Form
    {
        public Connection Connection = new Connection();

        public frmRegisterAdmin()
        {
            InitializeComponent();
        }
        
        public void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtUID.Text != "" && txtPWD.Text != "" && txtFname.Text != "")
            {
                Account newAccount = new Account();
                newAccount.SetAccountUID(txtUID.Text);
                newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPWD.Text, "NeatVibezPOS"));
                newAccount.SetAccountName(txtFname.Text);
                newAccount.customer_card_edit = true;
                newAccount.discount_edit = true;
                newAccount.price_edit = true;
                newAccount.receipt_edit = true;
                newAccount.inventory_edit = true;
                newAccount.expenses_add = true;
                newAccount.users_edit = true;
                newAccount.settings_edit = true;
                newAccount.personnel_edit = true;
                newAccount.openclose_edit = true;

                if (Connection.server.RegisterAdmin(newAccount))
                {
                    MessageBox.Show(".تم تسجيل الحساب الاداري");
                    this.Hide();
                    Application.OpenForms[0].Show();
                    this.Close();
                }
                else MessageBox.Show(".لم نتمكن من تسجيل الحساب الاداري");
            }
        }

        public void frmRegisterAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                /*(switch (e.CloseReason)
               {
                   case CloseReason.UserClosing:
                       e.Cancel = true;
                       return;
               }*/
            }
            catch (Exception error)
            { }
        }

        public void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
        }

        public void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnRegister.PerformClick();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            txtPWD.Text = "";
            txtFname.Text = "";
        }
    }
}
