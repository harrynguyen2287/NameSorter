namespace NameSorter.Core.Services;
public class NameService : INameService
{
  public List<string> SortList(List<string> unsortedNames)
  {
    return unsortedNames
        .OrderBy(name => name.Split(' ').Last())
        .ThenBy(name => string.Join(" ", name.Split(' ').TakeWhile(n => n != name.Split(' ').Last())))
        .ToList();
  }
}