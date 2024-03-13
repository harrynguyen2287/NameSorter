using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameSorter.ConsoleApp;
using NameSorter.Core.DependencyInjections;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Add dependencies
builder.Services.AddTransient<App>();
builder.Services.AddCoreDependencies();

// Start App
using IHost host = builder.Build();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
  services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}