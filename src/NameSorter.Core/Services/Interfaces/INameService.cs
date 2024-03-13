namespace NameSorter.Core.Services;
public interface INameService
{
  List<string> SortList(List<string> unsortedNames);
}