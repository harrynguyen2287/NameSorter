
public class FileService : IFileService
{
  public List<string> ReadListFromFile(string filePath)
  {
    return File.ReadAllLines(filePath).ToList();
  }

  public void SaveListToFile(string filePath, List<string> contents)
  {
    File.WriteAllLines(filePath, contents);
  }
}