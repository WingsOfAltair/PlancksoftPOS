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
    public partial class frmItemRefund : Form
    {
        Connection Connection = new Connection();
        SortedList<int, string> itemtypes = new SortedList<int, string>();
        string UID;
        public frmItemRefund(SortedList<int, string> itemtypes, string UID)
        {
            InitializeComponent();
            this.itemtypes = itemtypes;
            this.UID = UID;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (ItemNametxt.Text != "" && ItemBarCodetxt.Text != "")
            {
                if (Connection.server.ReturnItem(ItemNametxt.Text, ItemBarCodetxt.Text, Convert.ToInt32(ItemQuantitynud.Value), this.UID))
                {
                    MessageBox.Show(".تم ارجاع الماده للمستودع");
                    this.Close();
                } else
                {

                    MessageBox.Show(".لم يتم ارجاع الماده للمستودع");
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
    }
}
