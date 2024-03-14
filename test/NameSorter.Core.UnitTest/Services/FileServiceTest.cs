using Moq;

public class FileServiceTest : IDisposable
{
  private readonly IFileService fileService;
  private List<string> contents;
  private const string TEST_FILE_PATH = "test-input.txt";
  public FileServiceTest()
  {
    fileService = new FileService();
    contents = new List<string>
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
        };
  }
  [Fact]
  public void ReadListFromFile_ShouldReturnExpectedValue()
  {
    // Given
    File.WriteAllLines(TEST_FILE_PATH, contents);

    // When
    List<string> result = fileService.ReadListFromFile(TEST_FILE_PATH);

    // Then
    Assert.Equal(contents, result);
  }

  [Fact]
  public void SaveListToFile_ShouldSaveSuccessfully()
  {
    // When
    fileService.SaveListToFile(TEST_FILE_PATH, contents);

    // Then
    var result = File.ReadAllLines(TEST_FILE_PATH).ToList();
    Assert.Equal(contents, result);
  }

  public void Dispose()
  {
    // Clean up
    File.Delete(TEST_FILE_PATH);
  }
}