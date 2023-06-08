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
using System.Security.Cryptography;

namespace PlancksoftPOS
{
    public partial class frmLicense : MaterialForm
    {
        public const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        public const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;

        public frmLicense()
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            frmLogin.pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {

            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {

            }

            applyLocalizationOnUI();
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "الترخيص و التفعيل";
                btnClear.Text = "مسح";
                btnActivate.Text = "التفعيل";
                btnClose.Text = "الخروج";
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Licensing & Activation";
                btnClear.Text = "Clear";
                btnActivate.Text = "Activate";
                btnClose.Text = "Close";
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

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (txtLicenseKey.Text == MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId() + "|1"), "PlancksoftPOS"))
            {
                Settings.Default["LicenseKey"] = MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId()), "PlancksoftPOS");
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddMonths(1).ToString());
                Settings.Default.Save();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة شهر واحد", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("The software system was activated with a new License valid for one month.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                this.Close();
            }
            else if (txtLicenseKey.Text == MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId() + "|2"), "PlancksoftPOS"))
            {
                Settings.Default["LicenseKey"] = MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId()), "PlancksoftPOS");
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddMonths(6).ToString());
                Settings.Default.Save();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة ستة أشهر", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("The software system was activated with a new License valid for six months.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                this.Close();
            }
            else if (txtLicenseKey.Text == MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId() + "|3"), "PlancksoftPOS"))
            {
                Settings.Default["LicenseKey"] = MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId()), "PlancksoftPOS");
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddYears(1).ToString());
                Settings.Default.Save();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة سنة واحدة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("The software system was activated with a new License valid for one year.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                this.Close();
            }
            else if (txtLicenseKey.Text == MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId() + "|4"), "PlancksoftPOS"))
            {
                Settings.Default["LicenseKey"] = MD5Encryption.Encrypt(GetHash256Str(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId()), "PlancksoftPOS");
                Settings.Default["LicenseExpiration"] = Encrypt256(DateTime.Now.AddMonths(1000).ToString());
                Settings.Default.Save();
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".لقد تم تغغيل البرمجية برخصة جديدة فعالة لمدة حياة البرمجية", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("The software system was activated with a new License valid for the entire lifetime of this product.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                this.Close();
            }
            else
            {
                if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MaterialMessageBox.Show(".مفتاح الرخصه غير صحيح", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                {
                    MaterialMessageBox.Show("License Key is incorrect.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                txtLicenseKey.Text = "";
                txtLicenseKey.Select();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLicenseKey.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLicenseKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                btnActivate.PerformClick();
            }
        }

        private void frmLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.exited)
            {
                Program.exited = true;
                this.Close();
            }
        }

        private void frmLicense_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.exited = false;
            Program.materialSkinManager.RemoveFormToManage(this);
        }
    }
}
