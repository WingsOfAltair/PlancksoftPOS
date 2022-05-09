using DataAccessLayer;
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
    public partial class frmLogin : Form
    {
        public const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        public const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";

        public Connection Connection = new Connection();
        public Mutex _mutex;

        public class Item
        {
            public string Name;
            public string UID;
            public Item(string UID, string Name)
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

        public static byte[] GetSha512Hash(string plainText)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] computedHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return computedHash;
        }


        public static string GetHash256Str(string message)
        {
            byte[] hashed = GetSha512Hash(message);
            string result = BitConverter.ToString(hashed).Replace("-", "");
            return result;
        }

        public frmLogin()
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
                    if (!Connection.server.CheckConnection())
                    {
                        MessageBox.Show(".لا يمكن الاتصال بالخادم أو قاعدة البيانات", Application.ProductName);
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (!Connection.server.CheckAdmin()) // if admin is not registered, open a form to make one.
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
                MessageBox.Show(".لا يمكن الاتصال بالخادم أو قاعدة البيانات", Application.ProductName);
                Environment.Exit(0);
            }
        }
        
        /// <summary>
        /// AES decryption
        /// </summary>
        public string Decrypt256(string text)
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

        public void RetrieveUsersList()
        {
            txtUID.Items.Clear();
            Tuple<List<Account>, DataTable> retrievedUsersList = Connection.server.RetrieveUsersList();
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

        public void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUID.Text == "" && txtPWD.Text == "")
            {
                MessageBox.Show(".الرجاء ملأ البيانات الصحيحه و عدم ترك فراغات", Application.ProductName);
                return;
            }
            Account newAccount = new Account();
            newAccount.SetAccountUID(txtUID.Text);
            newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPWD.Text, "NeatVibezPOS"));

            Tuple<bool, string, bool> result = Connection.server.Login(newAccount);
            if (result.Item1)
            {
                if (result.Item2 != "notloggedin...")
                {
                    newAccount.SetAccountName(result.Item2);
                    newAccount.SetAccountAuthority(Convert.ToInt32(result.Item3));
                    frmMain frm2 = new frmMain(newAccount);
                    frm2.Show();
                    this.Hide();
                    Connection.server.LogLogin(txtUID.Text, DateTime.Now);
                }
            }
            else MessageBox.Show(".المستخدم غير مسجل", Application.ProductName);
            txtUID.Text = "";
            txtPWD.Text = "";
        }

        public void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            if (e.KeyChar == (Char)Keys.Enter)
                BtnLogin.PerformClick();
        }

        public void txtUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                BtnLogin.PerformClick();
        }

        public void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
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

        public void button10_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "0";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "1";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "2";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "3";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "4";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button5_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "5";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "6";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button7_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "7";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button8_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "8";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button9_Click(object sender, EventArgs e)
        {
            txtPWD.Text += "9";
            txtPWD.SelectionStart = txtPWD.Text.Length;
            txtPWD.SelectionLength = txtPWD.Text.Length;
            txtPWD.Select();
        }

        public void button11_Click(object sender, EventArgs e)
        {
            txtPWD.Text = "";
        }

        public void txtUID_Enter(object sender, EventArgs e)
        {
            RetrieveUsersList();
        }
    }
}
