using PlancksoftPOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlancksoftPOS
{
    public partial class frmItemRefund : Form
    {
        Connection Connection = new Connection();
        SortedList<int, string> itemtypes = new SortedList<int, string>();
        string UID;
        public static LanguageChoice.Languages pickedLanguage = LanguageChoice.Languages.Arabic;
        public frmItemRefund(SortedList<int, string> itemtypes, string UID)
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

            this.itemtypes = itemtypes;
            this.UID = UID;
        }

        public void applyLocalizationOnUI()
        {
            if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
            {
                Text = "ارجاع المواد";
                label1.Text = "اسم الماده";
                label2.Text = "باركود الماده";
                label4.Text = "عدد القطع";
                button1.Text = "اختيار الماده";
                button2.Text = "ارجاع الماده";
                button3.Text = "الغاء";
                اللغةToolStripMenuItem.Text = "اللغة";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "الخروج";
                RightToLeft = RightToLeft.Yes;
                RightToLeftLayout = true;
            }
            else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
            {
                Text = "Items Return";
                label1.Text = "Item Name";
                label2.Text = "Item Barcode";
                label4.Text = "Item Amount";
                button1.Text = "Pick Item";
                button2.Text = "Return Item";
                button3.Text = "Close";
                اللغةToolStripMenuItem.Text = "Language";
                العربيةToolStripMenuItem.Text = "العربية";
                englishToolStripMenuItem.Text = "English";
                الخروجToolStripMenuItem.Text = "Exit";
                RightToLeft = RightToLeft.No;
                RightToLeftLayout = false;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (ItemNametxt.Text != "" && ItemBarCodetxt.Text != "")
            {
                if (Connection.server.ReturnItem(ItemNametxt.Text, ItemBarCodetxt.Text, Convert.ToInt32(ItemQuantitynud.Value), this.UID))
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".تم ارجاع الماده للمستودع", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("The item was returned to the warehouse.", Application.ProductName);
                    }
                        this.Close();
                } else
                {
                    if (frmLogin.pickedLanguage == LanguageChoice.Languages.Arabic)
                    {
                        MessageBox.Show(".لم يتم ارجاع الماده للمستودع", Application.ProductName);
                    }
                    else if (frmLogin.pickedLanguage == LanguageChoice.Languages.English)
                    {
                        MessageBox.Show("The item was not returned to the warehouse.", Application.ProductName);
                    }
                        return;
                }
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLookup itemLookup = new frmItemLookup(this.itemtypes, this.UID);

                itemLookup.ShowDialog(this);
                if (itemLookup.dialogResult == DialogResult.OK)
                {
                    try
                    {
                        ItemNametxt.Text = itemLookup.selectedItem.ItemName;
                        ItemBarCodetxt.Text = itemLookup.selectedItem.ItemBarCode;
                    } catch(Exception error)
                    {

                    }
                }
            }
            catch (Exception error)
            {

            }
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
