using Serilog;
using Serilog.Events;

class Program
{
    static void Main(string[] args)
    {
        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // Set minimum log level
            .Enrich.FromLogContext()
            .WriteTo.Console()     // Optional: write logs to console
            .WriteTo.File(
                "logs/log-.txt",                       // File path pattern
                rollingInterval: RollingInterval.Day,   // New file every day
                retainedFileCountLimit: 7,              // Keep only last 7 files
                fileSizeLimitBytes: 10_000_000,         // Optional: 10 MB max per file
                rollOnFileSizeLimit: true               // Start a new file if limit exceeded
            )
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
