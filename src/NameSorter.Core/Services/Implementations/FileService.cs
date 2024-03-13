
public class FileService : IFileService
{
    public List<string> ReadListFromFile(string filePath)
    {
        return new List<string>{filePath};
    }
}