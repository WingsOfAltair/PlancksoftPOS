using MaterialSkin;
using PlancksoftPOS.Properties;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PlancksoftPOS
{
    static class Program
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
        static public MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            if (PriorProcess() != null)
                Application.Exit();
            else
            {
                materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.EnforceBackcolorOnAllComponents = false;

                if ((ThemeSchemeChoice.ThemeScheme)Settings.Default.pickedThemeScheme == ThemeSchemeChoice.ThemeScheme.Dark)
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Red300, Primary.DeepOrange400, Primary.Orange100, Accent.Orange100, TextShade.BLACK);
                }
                else
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    Program.materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.BLACK);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
        }

        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }
    }
}
