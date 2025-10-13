using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    webBuilder.UseKestrel(options =>
                    {
                        // HTTP (optional, e.g. for redirect)
                        options.ListenAnyIP(5000);

                        // HTTPS endpoint using your PFX cert
                        options.ListenAnyIP(5002, listenOptions =>
                        {
                            listenOptions.UseHttps(
                                "C:\\temp\\192.168.1.29.pfx",
                                "P@ssw0rd!"
                            );
                        });

                        // Optional: remove body size limit
                        options.Limits.MaxRequestBodySize = null;
                    });
                });
        }
}
