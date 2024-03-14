using Moq;
using NameSorter.ConsoleApp;
using NameSorter.Core.Services;

public class AppTest
{
  private readonly Mock<INameService> mockNameService;
  private readonly App app;
  private const string UNSORTED_FILE_PATH = "./test/unsorted-names-list.txt";

  public AppTest()
  {
    mockNameService = new Mock<INameService>();
    app = new App(mockNameService.Object);
  }

  [Fact]
  public void Run_ShouldRunSortNamesFromFilePathAtLeastOnce()
  {
    // Given
    var args = new string[] { UNSORTED_FILE_PATH };
    mockNameService.Setup(service => service.SortNamesFromFilePath(args));

    // When
    app.Run(args);

    // Then
    mockNameService.Verify(s => s.SortNamesFromFilePath(args), Times.Once);
  }
}