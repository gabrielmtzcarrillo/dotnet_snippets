using Serilog;
using Serilog.Events;
using Serilog.Settings.Configuration;

// https://stackoverflow.com/a/65111169/3930332
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false);

        IConfiguration configuration = builder.Build();

        Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

        try
        {
            Log.Information("Application starting at {Time}", DateTime.Now);

            // Your app logic here
            Console.WriteLine("Hello from Serilog!");
            Log.Debug("This is a debug message");
            Log.Warning("This is a warning message");
            Log.Error("This is an error message with a value {Value}", 42);

            // Simulate work
            System.Threading.Thread.Sleep(1000);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An unhandled exception occurred");
        }
        finally
        {
            // Make sure everything is flushed before exit
            Log.CloseAndFlush();
        }
    }
}
