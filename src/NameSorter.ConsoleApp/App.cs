using NameSorter.Core.Services;

namespace NameSorter.ConsoleApp;

public class App
{
  private readonly INameService nameService;

  public App(INameService nameService)
  {
    this.nameService = nameService;
  }

  public void Run(string[] args)
  {
    nameService.SortNamesFromFilePath(args);
  }
}