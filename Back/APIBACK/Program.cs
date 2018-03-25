using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Obj;

namespace APIBACK
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var r = QRCode.Decode(File.ReadAllBytes(@"D:\Users\maksa\Desktop\Juntas-superficie-de-madera-textura-de-fondo-900x1440.jpg"));
            //Console.WriteLine(r?.Text);
            //Console.Read();
            //return;
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
            .ConfigureAppConfiguration(conf => conf.AddJsonFile("appsettings.Secret.json", false))
                .UseUrls("http://*:80")
                .UseStartup<Startup>()
                .Build();
    }
}
