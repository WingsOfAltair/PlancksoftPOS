using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlancksoftPOS
{

    public partial class frmColorPicker : MaterialForm
    {
        internal string hexColor = "";
        internal Color argbColor;
        internal DialogResult colorDialogResult = new DialogResult();

        public frmColorPicker(string hexColor)
        {
            InitializeComponent();
            this.hexColor = hexColor;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();


        private void frmColorPicker_Load(object sender, EventArgs e)
        {
            argbColor = ColorTranslator.FromHtml(hexColor);
            textBox1.Text = Convert.ToInt16(argbColor.R).ToString();
            textBox2.Text = Convert.ToInt16(argbColor.G).ToString();
            textBox3.Text = Convert.ToInt16(argbColor.B).ToString();
            panel1.BackColor = Color.FromArgb(argbColor.R, argbColor.G, argbColor.B);
            setTB();
        }

        private void colorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = panel1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }

        }

        public static string ToRGB(Color c)
        {
            return $"{c.R.ToString()},{c.G.ToString()},{c.B.ToString()}";
        }
        public string ToHex(Color c)
        {
            return $"#{c.R.ToString("X2")}{c.G.ToString("X2")}{c.B.ToString("X2")}";
        }

        private void copyToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ToHex(panel1.BackColor));
        }

        private void copyToRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ToRGB(panel1.BackColor));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            setTB();
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void setTB()
        {
            textBox1.Text = trackBar1.Value.ToString();
            textBox2.Text = trackBar2.Value.ToString();
            textBox3.Text = trackBar3.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar2.Value = int.Parse(textBox2.Text);
            }
            catch (Exception)
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar3.Value = int.Parse(textBox3.Text);
            }
            catch (Exception)
            {

            }
        }

        private void frmColorPicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            colorDialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            hexColor = ToHex(panel1.BackColor);
            colorDialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
