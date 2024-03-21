namespace NameSorter.Core.Services;
public interface INameService
{
  void SortNamesFromFilePath(string[] args);
  List<string> SortList(List<string> unsortedNames, string sortDirection);
  void WriteNamesToConsole(List<string> sortedNames);
}