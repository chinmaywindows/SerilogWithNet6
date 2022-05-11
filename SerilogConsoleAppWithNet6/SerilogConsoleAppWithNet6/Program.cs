// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Serilog;

#region InitConfig

var configFile = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .ReadFrom.Configuration(configFile)
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Logger.Information("Started logging...");

#endregion




try
{
    Console.WriteLine("Hello, World!");
    Console.ReadLine();
    Console.ReadKey();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
    
}
finally
{
    Log.Information("Shutting the program..Complete");
    Log.CloseAndFlush();
}



