// https://stackoverflow.com/a/65111169/3930332

using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

IConfiguration config = builder.Build();

string? message = config.GetValue<string>("Test:Message");

Console.WriteLine(message);
