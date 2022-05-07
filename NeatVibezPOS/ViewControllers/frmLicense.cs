using NeatVibezPOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeatVibezPOS
{
    public partial class frmLicense : Form
    {
        public const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        public const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";

        public frmLicense()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName))
            {
                Settings.Default["LicenseKey"] = Encrypt256(GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName));
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddYears(10).ToString());
                Settings.Default.Save();
                this.Close();
            } else
            {
                MessageBox.Show(".مفتاح الرخصه غير صحيح", Application.ProductName);
                textBox1.Text = "";
                textBox1.Select();
            }

        }

        public string Encrypt256(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
