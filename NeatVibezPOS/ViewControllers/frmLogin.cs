using NeatVibezPOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeatVibezPOS
{
    internal partial class frmLogin : Form
    {
        private const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        private const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";

        private Connection Connection = new Connection();
        private Mutex _mutex;

        private class Item
        {
            internal string Name;
            internal string UID;
            internal Item(string UID, string Name)
            {
                this.UID = UID;
                this.Name = Name;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return UID;
            }
        }

        internal static byte[] GetSha512Hash(string plainText)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] computedHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return computedHash;
        }


        internal static string GetHash256Str(string message)
        {
            byte[] hashed = GetSha512Hash(message);
            string result = BitConverter.ToString(hashed).Replace("-", "");
            return result;
        }

        internal frmLogin()
        {
            InitializeComponent();
            try
            {
                try
                {
                    if (Convert.ToDateTime(Decrypt256(Settings.Default.LicenseExpiration)) < DateTime.Now)
                    {
                        Settings.Default["LicenseKey"] = "";
                        Settings.Default.Save();
                    }
                }
                catch (Exception e)
                {
                    Settings.Default["LicenseKey"] = "";
                    Settings.Default.Save();
                }
                if (Decrypt256(Settings.Default.LicenseKey) != GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName))
                {
                    frmLicense frm0 = new frmLicense();
                    frm0.ShowDialog();
                }
                if (Decrypt256(Settings.Default.LicenseKey) == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName))
                {
                    if (!Connection.CheckConnection(Settings.Default.ComputerName, Settings.Default.DBName, Settings.Default.DBUID, Settings.Default.DBPWD))
                    {
                        frmDBConfigure frm1 = new frmDBConfigure();
                        frm1.ShowDialog();

                        MessageBox.Show(".الرجاء اعادة تشغيل البرمجيه", Application.ProductName);
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (!Connection.CheckAdmin()) // if admin is not registered, open a form to make one.
                        {
                            this.Hide();
                            frmRegisterAdmin registerAdmin = new frmRegisterAdmin();
                            registerAdmin.ShowDialog();
                            RetrieveUsersList();
                        }
                        else // else stay at login page.
                        {
                            // get list of UIDs from DB.

                            RetrieveUsersList();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                frmDBConfigure frm1 = new frmDBConfigure();
                frm1.ShowDialog();
            }
        }
        
        /// <summary>
        /// AES decryption
        /// </summary>
        private string Decrypt256(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }

        internal void RetrieveUsersList()
        {
            txtUID.Items.Clear();
            Tuple<Account[], DataTable> retrievedUsersList = Connection.RetrieveUsersList();
            foreach (Account account in retrievedUsersList.Item1)
            {
                txtUID.Items.Add(new Item(account.GetAccountUID(), account.GetAccountName()));
            }
            try
            {
                txtUID.SelectedIndex = 0;
            } catch(Exception error)
            {

            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUID.Text == "" && txtPWD.Text == "")
            {
                MessageBox.Show(".الرجاء ملأ البيانات الصحيحه و عدم ترك فراغات", Application.ProductName);
                return;
            }
            Account newAccount = new Account();
            newAccount.SetAccountUID(txtUID.Text);
            newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPWD.Text, "NeatVibezPOS"));

            Tuple<bool, string, bool> result = Connection.Login(newAccount);
            if (result.Item1)
            {
                if (result.Item2 != "notloggedin...")
                {
                    newAccount.SetAccountName(result.Item2);
                    newAccount.SetAccountAuthority(Convert.ToInt32(result.Item3));
                    frmMain frm2 = new frmMain(newAccount);
                    frm2.Show();
                    this.Hide();
                    Connection.LogLogin(txtUID.Text, DateTime.Now);
                }
            }
            else MessageBox.Show(".المستخدم غير مسجل", Application.ProductName);
            txtUID.Text = "";
            txtPWD.Text = "";
        }

        private void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
                BtnLogin.PerformClick();
        }

        private void txtUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnLogin.PerformClick();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MessageBoxManager.Yes = "نعم";
                MessageBoxManager.No = "لا";
                MessageBoxManager.Register();
                DialogResult status = MessageBox.Show("هل أنت متأكد من رغبتك بالخروج؟", Application.ProductName, MessageBoxButtons.YesNo);
                MessageBoxManager.Unregister();
                if (status == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception error)
            { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "0";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "1";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "2";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "3";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "4";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "5";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "6";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "7";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "8";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "9";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtPWD.Text = "";
        }

        private void txtUID_Enter(object sender, EventArgs e)
        {
            RetrieveUsersList();
        }
    }
}
