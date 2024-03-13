namespace NameSorter.Core.Services;
public class NameService : INameService
{
  private readonly IFileService fileService;

  public NameService(IFileService fileService)
  {
    this.fileService = fileService;
  }

  public void SortNamesFromFilePath(string[] args)
  {
    // Get file path
    var filePath = GetFilePathFromArgs(args);

    // Read file and sort names
    var unsortedNames = fileService.ReadListFromFile(filePath);
    var sortedNames = SortList(unsortedNames);
    WriteNamesToConsole(sortedNames);
    fileService.SaveListToFile("./sorted-names-list.txt", sortedNames);
  }

  public List<string> SortList(List<string> unsortedNames)
  {
    return unsortedNames
        .OrderBy(name => name.Split(' ').Last())
        .ThenBy(name => string.Join(" ", name.Split(' ').TakeWhile(n => n != name.Split(' ').Last())))
        .ToList();
  }

  public void WriteNamesToConsole(List<string> sortedNames)
  {
    Console.WriteLine("Sorted Names:");
    sortedNames.ForEach(name => Console.WriteLine(name));
  }

  #region Private Methods
  private string GetFilePathFromArgs(string[] args)
  {
    string? filePath = "";
    while (string.IsNullOrEmpty(filePath))
    {
      if (args.Length > 0)
      {
        filePath = args[0];
      }
      else
      {
        Console.WriteLine("Please input the file path:");
        filePath = Console.ReadLine();
      }
    }

    return filePath;
  }
  #endregion
}