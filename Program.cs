using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace netcoreConfig
{

    class Program
    {
        static public string DefaultConnectionString { get; } = @"someConnectionString";
        static IReadOnlyDictionary<string, string> DefaultConnectionStrings { get; } =
        new Dictionary<string, string>()
        {
            {"profile:Username", Environment.UserName},
            {"AppConfiguration:ConnectionString", DefaultConnectionString},
            {"width", "50"}
        };

        static public IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            args.ToList().ForEach(x => Console.WriteLine(x));
            
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(DefaultConnectionStrings);
            builder.AddJsonFile("./appsettings.json", false, true);
            //add args to config.
            builder.AddCommandLine(args);
            Configuration = builder.Build();

            //Console.SetWindowSize(Int32.Parse(Configuration["AppConfiguration:MainWindow:Width"]),Int32.Parse(Configuration["AppConfiguration:MainWindow:Height"]));
            Console.WriteLine($"Hello {Configuration.GetValue<string>("h")}");
            //debugging
            //Configuration.AsEnumerable().ToList().ForEach(x => Console.WriteLine(x.Value));
        }
    }
}
