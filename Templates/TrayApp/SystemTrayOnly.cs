using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayApp
{
    internal class SystemTrayOnly: ApplicationContext
    {
        NotifyIcon _icon;
        ContextMenuStrip _menu;

        public SystemTrayOnly()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add("Exit", null, OnExit);

            _icon = new NotifyIcon();
            _icon.Icon = Icons.ResourceManager.GetObject("AppIcon") as System.Drawing.Icon;
            _icon.ContextMenuStrip = _menu;

            _icon.Visible = true;

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // Set minimum log level
            .Enrich.FromLogContext()
            .WriteTo.File(
                "logs/log-.txt",                       // File path pattern
                rollingInterval: RollingInterval.Day,   // New file every day
                retainedFileCountLimit: 7,              // Keep only last 7 files
                fileSizeLimitBytes: 10_000_000,         // Optional: 10 MB max per file
                rollOnFileSizeLimit: true               // Start a new file if limit exceeded
            )
            .CreateLogger();

            Log.Information("Application starting at {Time}", DateTime.Now);
        }

        void OnExit(object? sender, EventArgs e)
        {
            _icon.Visible = false;
            Log.CloseAndFlush();
            Application.Exit();
        }
    }
}
