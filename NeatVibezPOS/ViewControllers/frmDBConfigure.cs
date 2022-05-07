using NeatVibezPOS.Properties;
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
    public partial class frmDBConfigure : Form
    {
        Connection Connection = new Connection();

        public frmDBConfigure()
        {
            InitializeComponent();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    if (Connection.server.CheckConnection(textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text))
                    {
                        Settings.Default["ComputerName"] = textBox4.Text;
                        Settings.Default["DBName"] = textBox1.Text;
                        Settings.Default["DBUID"] = textBox2.Text;
                        Settings.Default["DBPWD"] = textBox3.Text;
                        Settings.Default.Save();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(".لا يمكن الاتصال بقاعدة البيانات", Application.ProductName);
                    }
                }
                else
                {
                    MessageBox.Show(".الرجاء املاء جميع المعلومات", Application.ProductName);
                }
            } catch (Exception error)
            {
                MessageBox.Show(".لا يمكن الاتصال بقاعدة البيانات", Application.ProductName);
            }
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void frmDBConfigure_Load(object sender, EventArgs e)
        {
            textBox4.Text = Environment.MachineName;
        }

        public void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                button2.PerformClick();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
