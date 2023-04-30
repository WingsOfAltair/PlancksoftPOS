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
using System.Threading;

namespace PlancksoftPOS
{
    public partial class frmLogin : MaterialForm
    {
        public const string AesIV256 = @"!QAZ2WSX#EDC4RFV";
        public const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";

        public Connection Connection = new Connection();
        public Mutex _mutex;

        public LanguageChoice languageChoice = new LanguageChoice();
        public ThemeSchemeChoice.ThemeScheme themeSchemeChoice = new ThemeSchemeChoice.ThemeScheme();
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;
        public bool closeApp = false;

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

        public frmLogin()
        {
            InitializeComponent();

            Program.materialSkinManager.AddFormToManage(this);

            pickedLanguage = (LanguageChoice.Languages)Settings.Default.pickedLanguage;
            themeSchemeChoice = (ThemeSchemeChoice.ThemeScheme)Settings.Default.pickedThemeScheme;

            if (pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (pickedLanguage == LanguageChoice.Languages.English)
            {
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }

            applyLocalizationOnUI();

            try
            {
                try
                {
                    if (Convert.ToDateTime(Decrypt256(Settings.Default.LicenseExpiration)) < DateTime.Now)
                    {
                        Settings.Default["LicenseKey"] = "";
                        Settings.Default.Save();
                        if (pickedLanguage == LanguageChoice.Languages.Arabic)
                            MaterialMessageBox.Show(".لقد إنتهت فترة صلاحية رخصة البرمجية, الرجاء التواصل مع الدعم الفني لشراء رخصة فعالة جديدة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        else if (pickedLanguage == LanguageChoice.Languages.English)
                            MaterialMessageBox.Show("The system's license validity duration has ended. Please contact technical support to purchase a new valid license.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    }
                }
                catch (Exception e)
                {
                    Settings.Default["LicenseKey"] = "";
                    Settings.Default.Save();
                    if (pickedLanguage == LanguageChoice.Languages.Arabic)
                        MaterialMessageBox.Show(".لقد إنتهت فترة صلاحية رخصة البرمجية, الرجاء التواصل مع الدعم الفني لشراء رخصة فعالة جديدة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                    else if (pickedLanguage == LanguageChoice.Languages.English)
                        MaterialMessageBox.Show("The system's license validity duration has ended. Please contact technical support to purchase a new valid license.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                }
                if (Decrypt256(Settings.Default.LicenseKey) != GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName))
                {
                    PlancksoftPOS.Visible = false;
                    frmLicense frm0 = new frmLicense();
                    frm0.ShowDialog();
                }
                if (Decrypt256(Settings.Default.LicenseKey) == GetHash256Str(Environment.MachineName + Environment.UserName + Application.ProductName))
                {
                    if (!Connection.server.CheckConnection())
                    {
                        if (pickedLanguage == LanguageChoice.Languages.Arabic)
                            MaterialMessageBox.Show(".لا يمكن الاتصال بشبكة السحابة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        else if (pickedLanguage == LanguageChoice.Languages.English)
                            MaterialMessageBox.Show("Unable to communicate with the cloud network.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (!Connection.server.CheckAdmin()) // if admin is not registered, open a form to make one.
                        {
                            PlancksoftPOS.Visible = false;
                            this.Hide();
                            frmRegisterAdmin registerAdmin = new frmRegisterAdmin();
                            registerAdmin.ShowDialog();
                            RetrieveUsersList();
                        }
                        else // else stay at login page.
                        {
                            // get list of UIDs from DB.

                            RetrieveUsersList();
                            PlancksoftPOS.Visible = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MaterialMessageBox.Show(e.ToString(), false, FlexibleMaterialForm.ButtonsPosition.Center);
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    MaterialMessageBox.Show(".لا يمكن الاتصال بشبكة السحابة", false, FlexibleMaterialForm.ButtonsPosition.Center);
                else if (pickedLanguage == LanguageChoice.Languages.English)
                    MaterialMessageBox.Show("Unable to communicate with the cloud network.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                Environment.Exit(0);
            }
        }

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
            }
            catch (Exception error)
            {

            }
        }

        public void applyLocalizationOnUI()
        {
            if (pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "شاشة الدخول";
                btnLogin.Text = "تسجيل الدخول";
                btnExit.Text = "الخروج";
                btnClear.Text = "مسح";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                المظهرToolStripMenuItem.Text = "المظهر";
                فاتحToolStripMenuItem.Text = "فاتح";
                مظلمToolStripMenuItem.Text = "مظلم";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Login window";
                btnLogin.Text = "Login";
                btnExit.Text = "Exit";
                btnClear.Text = "Clear";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                المظهرToolStripMenuItem.Text = "Theme";
                فاتحToolStripMenuItem.Text = "Light";
                مظلمToolStripMenuItem.Text = "Dark";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
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

        private void btn9_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "9";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "8";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "7";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "6";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "5";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "4";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "3";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "2";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "1";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = txtPassword.Text.Length;
            txtPassword.Select();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUID.Text == "" && txtPassword.Text == "")
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    MaterialMessageBox.Show(".الرجاء ملأ البيانات الصحيحه و عدم ترك فراغات", false, FlexibleMaterialForm.ButtonsPosition.Center);
                else if (pickedLanguage == LanguageChoice.Languages.English)
                    MaterialMessageBox.Show("Please fill all blank fields with valid data.", false, FlexibleMaterialForm.ButtonsPosition.Center);
                return;
            }
            Account newAccount = new Account();
            newAccount.SetAccountUID(txtUID.Text);
            newAccount.SetAccountPWD(MD5Encryption.Encrypt(txtPassword.Text, "PlancksoftPOS"));

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
                    PlancksoftPOS.Visible = false;
                    Connection.server.LogLogin(txtUID.Text, DateTime.Now);
                }
            }
            else
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                    MaterialMessageBox.Show(".المستخدم غير مسجل", false, FlexibleMaterialForm.ButtonsPosition.Center);
                else if (pickedLanguage == LanguageChoice.Languages.English)
                    MaterialMessageBox.Show("User Account is not registered.", false, FlexibleMaterialForm.ButtonsPosition.Center);
            }
            txtUID.Text = "";
            txtPassword.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
                    MessageBoxManager.Yes = "نعم";
                    MessageBoxManager.No = "لا";
                }
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    MessageBoxManager.Yes = "Yes";
                    MessageBoxManager.No = "No";
                }
                MessageBoxManager.Register();

                if (pickedLanguage == LanguageChoice.Languages.Arabic)
                {
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
                else if (pickedLanguage == LanguageChoice.Languages.English)
                {
                    DialogResult status = MessageBox.Show("Are you sure you would like to quit?", Application.ProductName, MessageBoxButtons.YesNo);
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
            }
            catch (Exception error)
            { }
        }

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void العربيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin.pickedLanguage = LanguageChoice.Languages.Arabic;
                Properties.Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.Arabic;
                Properties.Settings.Default.Save();
                englishToolStripMenuItem.Checked = false;
                العربيةToolStripMenuItem.Checked = true;
                applyLocalizationOnUI();
            }
            catch (Exception err) { }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin.pickedLanguage = LanguageChoice.Languages.English;
                Properties.Settings.Default.pickedLanguage = (int)LanguageChoice.Languages.English;
                Properties.Settings.Default.Save();
                englishToolStripMenuItem.Checked = true;
                العربيةToolStripMenuItem.Checked = false;
                applyLocalizationOnUI();
            }
            catch (Exception err) { }
        }

        private void مظلمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.materialSkinManager = MaterialSkinManager.Instance;
            Program.materialSkinManager.EnforceBackcolorOnAllComponents = false; ;

            Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            if (Properties.Settings.Default.darkTextShade == "BLACK")
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.BLACK);
            else
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.WHITE);
            Properties.Settings.Default.pickedThemeScheme = 1;
            Properties.Settings.Default.Save();
            مظلمToolStripMenuItem.Checked = true;
            فاتحToolStripMenuItem.Checked = false;
        }

        private void فاتحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.materialSkinManager = MaterialSkinManager.Instance;
            Program.materialSkinManager.EnforceBackcolorOnAllComponents = false; ;

            Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            if (Properties.Settings.Default.TextShade == "BLACK")
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.BLACK);
            else
                Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.WHITE);
            Properties.Settings.Default.pickedThemeScheme = 0;
            Properties.Settings.Default.Save();
            مظلمToolStripMenuItem.Checked = false;
            فاتحToolStripMenuItem.Checked = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            frmLogin.pickedLanguage = (LanguageChoice.Languages)Properties.Settings.Default.pickedLanguage;

            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                العربيةToolStripMenuItem.Checked = true;
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                englishToolStripMenuItem.Checked = true;
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }

            if (Properties.Settings.Default.pickedThemeScheme == (int)ThemeSchemeChoice.ThemeScheme.Dark)
            {
                Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                if (Properties.Settings.Default.darkTextShade.ToUpper() == "BLACK")
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.BLACK);
                else
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.darkPrimary, Properties.Settings.Default.darkPrimaryDark, Properties.Settings.Default.darkLightPrimary, Properties.Settings.Default.darkAccent, TextShade.WHITE);
                مظلمToolStripMenuItem.Checked = true;
                فاتحToolStripMenuItem.Checked = false;
            }
            else
            {
                Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                if (Properties.Settings.Default.TextShade.ToUpper() == "BLACK")
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.BLACK);
                else
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Properties.Settings.Default.Primary, Properties.Settings.Default.PrimaryDark, Properties.Settings.Default.LightPrimary, Properties.Settings.Default.Accent, TextShade.WHITE);
                مظلمToolStripMenuItem.Checked = false;
                فاتحToolStripMenuItem.Checked = true;
            }
        }
    }
}
