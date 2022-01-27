using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeatVibezPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread((ThreadStart)(() => {
                try
                {
                    string LicenseKey = MD5Encryption.Encrypt(Environment.MachineName + Environment.UserName + Application.ProductName, "NeatVibezPOS");
                    Console.WriteLine(LicenseKey);
                    Console.WriteLine("Done. Paste your clipboard content to the key generator software.");
                    Clipboard.SetText(LicenseKey);

                    Console.ReadLine();
                } catch (Exception e)
                {
                    Console.WriteLine("Unable to create License Key data.");
                    Console.ReadLine();
                }
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
