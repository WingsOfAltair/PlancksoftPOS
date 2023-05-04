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

        static public bool exited = false;

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
                    if (Settings.Default.darkTextShade == "BLACK")
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Settings.Default.darkPrimary, Settings.Default.darkPrimaryDark, Settings.Default.darkLightPrimary, Settings.Default.darkAccent, TextShade.BLACK);
                    else
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Settings.Default.darkPrimary, Settings.Default.darkPrimaryDark, Settings.Default.darkLightPrimary, Settings.Default.darkAccent, TextShade.WHITE);
                }
                else
                {
                    Program.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    if (Settings.Default.TextShade == "BLACK")
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Settings.Default.Primary, Settings.Default.PrimaryDark, Settings.Default.LightPrimary, Settings.Default.Accent, TextShade.BLACK);
                    else
                        Program.materialSkinManager.ColorScheme = new ColorScheme(Settings.Default.Primary, Settings.Default.PrimaryDark, Settings.Default.LightPrimary, Settings.Default.Accent, TextShade.WHITE);
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
