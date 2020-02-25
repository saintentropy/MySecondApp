using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MySecondApp
{
    class Program
    {
        public static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } =
            new Dictionary<string, string>()
            {
                ["Profile:UserName"] = Environment.UserName,
                ["AppConfiguration:MainWindow:Height"] = "10",
                ["AppConfiguration:MainWindow:Width"] = "100"
            };

        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            //configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = configurationBuilder.Build();
            Console.SetWindowSize(Int32.Parse(Configuration["AppConfiguration:MainWindow:Width"]), (Int32.Parse(Configuration["AppConfiguration:MainWindow:Height"])));
            Console.WriteLine($"Hello {Configuration["Profile:UserName"]}");
            Console.WriteLine($"{Configuration["AppConfiguration:MainWindow:Height"]}");

            while (true)
            {
                var w = Int32.Parse(Configuration["AppConfiguration:MainWindow:Width"] ?? "100");
                var h = Int32.Parse(Configuration["AppConfiguration:MainWindow:Height"] ?? "10");
                Console.SetWindowSize(w, h);
            }


        }
    }
}
