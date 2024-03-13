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
    SortNamesFromFile(args);
  }

  private void SortNamesFromFile(string[] args)
  {
    if (!ValidateArgs(args))
    {
      return;
    }

    var unsortedNames = fileService.ReadListFromFile(args[0]);
    var sortedNames = nameService.SortList(unsortedNames);
    fileService.SaveListToFile("./sorted-names-list.txt", sortedNames);
    sortedNames.ForEach(name => Console.WriteLine(name));
  }

  private bool ValidateArgs(string[] args)
  {
    if (args.Length <= 0)
    {
      Console.WriteLine("ERROR: Please input the file path!");
      return false;
    }
    return true;
  }
}