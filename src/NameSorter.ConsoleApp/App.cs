using NameSorter.Core.Services;

namespace NameSorter.ConsoleApp;

public class App
{
  private readonly INameService nameService;
  private readonly IFileService fileService;

  public App(INameService nameService, IFileService fileService)
  {
    this.nameService = nameService;
    this.fileService = fileService;
  }

  public void Run(string[] args)
  {
    var unsortedNames = fileService.ReadListFromFile(args[0]);
    unsortedNames.ForEach(name => Console.WriteLine("Unsorted Names: {0}", name))
    ;
  }
}