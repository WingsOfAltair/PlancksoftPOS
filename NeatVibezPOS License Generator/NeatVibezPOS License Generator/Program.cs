using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
                    Console.WriteLine("Please enter your clipboard content here:");
                    string Hash = Console.ReadLine();
                    string LicenseKey = GetHash256Str(MD5Encryption.Decrypt(Hash, "NeatVibezPOS"));
                    Console.WriteLine(LicenseKey);
                    Console.WriteLine("Done. Activate/PASTE into your NeatVibezPOS software copy using this License Key now.");
                    Clipboard.SetText(LicenseKey);

                    Console.ReadLine();
                } catch (Exception e) { Console.WriteLine("Unable to generate the License Key.");
                    Console.ReadLine();
                }
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        internal static byte[] GetSha512Hash(string plainText)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] computedHash = sha512.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return computedHash;
        }


        internal static string GetHash256Str(string message)
        {
            byte[] hashed = GetSha512Hash(message);
            string result = BitConverter.ToString(hashed).Replace("-", "");
            return result;
        }
    }
}
