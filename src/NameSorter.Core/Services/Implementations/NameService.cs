using System.Reflection.Metadata;

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

    // Read file
    var unsortedNames = fileService.ReadListFromFile(filePath);
    if (unsortedNames == null || unsortedNames.Count <= 0)
    {
      Console.WriteLine(ErrorMessage.NO_VALID_NAME_IN_FILE);
      return;
    }

    // Sort names
    var sortedNames = SortList(unsortedNames);
    WriteNamesToConsole(sortedNames);
    fileService.SaveListToFile(Constants.SORTED_FILE_PATH, sortedNames);
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
    Console.WriteLine(Constants.SORTED_NAMES_TITLE);
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
        Console.WriteLine(ErrorMessage.INVALID_FILE_PATH);
        filePath = Console.ReadLine();
      }
    }

    return filePath;
  }
  #endregion
}