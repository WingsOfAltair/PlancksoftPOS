using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeatVibezPOS
{
    internal partial class frmItemLookup : Form
    {
        Connection Connection = new Connection();
        internal DialogResult dialogResult = new DialogResult();
        internal Item selectedItem = new Item();
        string UID;

        private class ItemTypeCategory
        {
            internal string Name;
            internal ItemTypeCategory(string Name)
            {
                this.Name = Name;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        internal frmItemLookup(SortedList<int, string> itemtypes, string UID)
        {
            InitializeComponent();
            this.UID = UID;

            foreach(KeyValuePair<int, string> itemType in itemtypes)
            {
                comboBox1.Items.Add(new ItemTypeCategory(itemType.Value));
            }

            DGVItemsLookup.DataSource = Connection.SearchItems("", "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemNametxt.Text = "";
            ItemBarCodetxt.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ItemTypeID;
            if (comboBox1.SelectedItem != null)
                ItemTypeID = Connection.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
            else ItemTypeID = 0;
            DGVItemsLookup.DataSource = Connection.SearchItems(ItemNametxt.Text, ItemBarCodetxt.Text, ItemTypeID).Item2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DGVItemsLookup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedItem.SetName(DGVItemsLookup.Rows[e.RowIndex].Cells[0].Value.ToString());
                selectedItem.SetBarCode(DGVItemsLookup.Rows[e.RowIndex].Cells[1].Value.ToString());
                selectedItem.SetQuantity(Convert.ToInt32(DGVItemsLookup.Rows[e.RowIndex].Cells[2].Value.ToString()));
                selectedItem.SetBuyPrice(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells[3].Value.ToString()));
                selectedItem.SetPrice(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells[4].Value.ToString()));
                selectedItem.SetPriceTax(Convert.ToDecimal(DGVItemsLookup.Rows[e.RowIndex].Cells[5].Value.ToString()));
                if (comboBox1.Text != "")
                {
                    int ItemTypeID = Connection.RetrieveItemTypeID(comboBox1.SelectedItem.ToString());
                    selectedItem.SetItemTypeID(ItemTypeID);
                } else
                {
                    selectedItem.SetItemTypeID(0);
                }
                selectedItem.vendorQuantity = Convert.ToInt32(numericUpDown1.Value);

                this.dialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            } catch (Exception error)
            {
                MessageBox.Show(".الرجاء الاختيار مره اخرى", Application.ProductName);
                return;
            }
        }

        private void ItemNametxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            button1.PerformClick();
        }

        private void ItemBarCodetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button1.PerformClick();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                DGVPrinter.ImbeddedImage logo = new DGVPrinter.ImbeddedImage
                {
                    ImageAlignment = DGVPrinter.Alignment.Left,
                    ImageLocation = DGVPrinter.Location.Absolute,
                    ImageX = 0,
                    ImageY = 0,
                    theImage = Properties.Resources.Gtown_Logo
                };
                printer.ImbeddedImageList.Add(logo);
                printer.Title = "تقرير المواد";
                printer.SubTitle = string.Format("التاريخ: {0}", DateTime.Now.Date.ToString("dddd dd/MM/yyyy", new CultureInfo("ar-AE")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = ".التقرير نتج من المستخدم: " + this.UID;
                printer.FooterSpacing = 15;
                printer.printDocument.DefaultPageSettings.Landscape = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
                printer.PrintDataGridView(DGVItemsLookup);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show(ex.Message.ToString(), Application.ProductName);
            }
        }
    }
}
