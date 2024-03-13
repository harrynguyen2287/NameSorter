public interface IFileService
{
  List<string> ReadListFromFile(string filePath);
  void SaveListToFile(string filePath, List<string> contents);
}