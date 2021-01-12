using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KnxDataCollector
{
    public class Program
    {

        private static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(var ip in host.AddressList)
            {
                if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return "https://" + ip.ToString();
                } 
            }
            return "";
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseUrls(GetIpAddress());
                });
    }
}
