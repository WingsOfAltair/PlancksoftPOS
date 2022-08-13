using PlancksoftPOS.Properties;
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

namespace PlancksoftPOS
{
    public partial class frmLicense : Form
    {
        public const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        public const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmLicense()
        {
            InitializeComponent();

            frmLogin.pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
                العربيةToolStripMenuItem.Checked = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
                englishToolStripMenuItem.Checked = true;
            }

            applyLocalizationOnUI();
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "الترخيص و التفعيل";
                label1.Text = "مفتاح الرخصه";
                button3.Text = "مسح";
                button2.Text = "التفعيل";
                button1.Text = "الخروج";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Licensing & Activation";
                label1.Text = "License Key";
                button3.Text = "Clear";
                button2.Text = "Activate";
                button1.Text = "Close";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
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
            if (textBox1.Text == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName + "|1"))
            {
                Settings.Default["LicenseKey"] = Encrypt256(GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName));
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddMonths(1).ToString());
                Settings.Default.Save();
                MessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة شهر واحد", Application.ProductName);
                this.Close();
            } else if (textBox1.Text == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName + "|2"))
            {
                Settings.Default["LicenseKey"] = Encrypt256(GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName));
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddMonths(6).ToString());
                Settings.Default.Save();
                MessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة ستة أشهر", Application.ProductName);
                this.Close();
            }
            else if (textBox1.Text == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName + "|3"))
            {
                Settings.Default["LicenseKey"] = Encrypt256(GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName));
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddYears(1).ToString());
                Settings.Default.Save();
                MessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة سنة واحدة", Application.ProductName);
                this.Close();
            }
            else if (textBox1.Text == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName + "|4"))
            {
                Settings.Default["LicenseKey"] = Encrypt256(GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName));
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddMonths(1000).ToString());
                Settings.Default.Save();
                MessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة حياة البرمجية", Application.ProductName);
                this.Close();
            }
            else
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

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void العربيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.pickedLanguage = LanguageChoice.Languages.Arabic;
            Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.Arabic;
            Settings.Default.Save();
            englishToolStripMenuItem.Checked = false;
            العربيةToolStripMenuItem.Checked = true;
            PlancksoftPOS.Dispose();
            applyLocalizationOnUI();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.pickedLanguage = LanguageChoice.Languages.English;
            Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.English;
            Settings.Default.Save();
            englishToolStripMenuItem.Checked = true;
            العربيةToolStripMenuItem.Checked = false;
            PlancksoftPOS.Dispose();
            applyLocalizationOnUI();
        }
    }
}
