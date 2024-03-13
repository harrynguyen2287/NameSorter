using Microsoft.Extensions.DependencyInjection;
using NameSorter.Core.Services;

namespace NameSorter.Core.DependencyInjections;
public static class CoreDependencies
{
  public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
  {
    services.AddTransient<INameService, NameService>();
    services.AddTransient<IFileService, FileService>();

    return services;
  }
}