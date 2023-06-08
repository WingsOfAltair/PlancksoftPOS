using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies.Security
{
    public class InstallationID
    {
        public static string getOfflineInstallId()
        {
            ManagementScope Scope;
            Scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            Scope.Connect();
            ObjectQuery Query = new ObjectQuery("SELECT OfflineInstallationId FROM SoftwareLicensingProduct");
            ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);

            foreach (ManagementObject WmiObject in Searcher.Get())
            {
                if (WmiObject["OfflineInstallationId"] != null)
                {
                    StringBuilder sb = new StringBuilder();
                    bool fRun = false;
                    for (int i = 0; i < WmiObject["OfflineInstallationId"].ToString().Length; i++)
                    {
                        if (i % 7 == 0)
                        {
                            if (fRun)
                                sb.Append('-');
                            else
                                fRun = true; //Stops a '-' being added at the 1st position.
                        }
                        sb.Append(WmiObject["OfflineInstallationId"].ToString()[i]);
                    }
                    return sb.ToString();
                }
            }
            return ""; //Making the compiler happy.
        }
    }
}
