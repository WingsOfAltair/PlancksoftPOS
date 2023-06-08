using System;
using Dependencies;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace PlancksoftPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                try
                {
                    string LicenseKey = MD5Encryption.Encrypt(Environment.MachineName + "_" + Environment.UserName + "_" + Application.ProductName + "_" + Environment.ProcessorCount + "_" + Dependencies.Security.InstallationID.getOfflineInstallId(), "PlancksoftPOS");
                    Console.WriteLine(LicenseKey);
                    Console.WriteLine("Done. Paste your clipboard content to the key generator software.");
                    Clipboard.SetText(LicenseKey);

                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to create License Key data.");
                    Console.ReadLine();
                }
            }))
            {

            };
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
