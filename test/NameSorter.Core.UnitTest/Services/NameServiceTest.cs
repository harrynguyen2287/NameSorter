using FluentAssertions;
using Moq;
using NameSorter.Core.Services;

public class NameServiceTest
{
  private readonly INameService nameService;
  private readonly Mock<IFileService> mockFileService;
  private List<string> unsortedList;
  private List<string> expectedList;
  private const string UNSORTED_FILE_PATH = "./test/unsorted-names-list.txt";

  public NameServiceTest()
  {
    mockFileService = new Mock<IFileService>();
    nameService = new NameService(mockFileService.Object);
    unsortedList = new List<string>{
      "Janet Parsons",
      "Vaughn Lewis",
      "Adonis Julius Archer",
      "Shelby Nathan Yoder",
      "Marin Alvarez",
      "London Lindsey",
      "Beau Tristan Bentley",
      "Leo Gardner",
      "Hunter Uriah Mathew Clarke",
      "Mikayla Lopez",
      "Frankie Conner Ritter",
      "Harry Nguyen"
    };

    expectedList = new List<string>{
      "Marin Alvarez",
      "Adonis Julius Archer",
      "Beau Tristan Bentley",
      "Hunter Uriah Mathew Clarke",
      "Leo Gardner",
      "Vaughn Lewis",
      "London Lindsey",
      "Mikayla Lopez",
      "Harry Nguyen",
      "Janet Parsons",
      "Frankie Conner Ritter",
      "Shelby Nathan Yoder"
    };
  }

  [Fact]
  public void SortList_ShouldReturnTheExpectedValue()
  {
    // When
    var actual = nameService.SortList(unsortedList);

    // Then
    actual.Should().NotBeNull();
    actual.Count.Should().Be(expectedList.Count);
    actual.Should().Equal(expectedList);
  }

  [Fact]
  public void SortNamesFromFilePath_ShouldSortAndPrintTheExpectedValue()
  {
    // Given
    mockFileService.Setup(service => service.ReadListFromFile(UNSORTED_FILE_PATH)).Returns(unsortedList);
    mockFileService.Setup(service => service.SaveListToFile(Constants.SORTED_FILE_PATH, expectedList));
    nameService.WriteNamesToConsole(expectedList);
    StringWriter expectedWriter = new StringWriter();
    Console.SetOut(expectedWriter);
    var expected = expectedWriter.ToString();

    // When
    nameService.SortNamesFromFilePath([UNSORTED_FILE_PATH]);
    StringWriter actualWriter = new StringWriter();
    Console.SetOut(actualWriter);
    var actual = actualWriter.ToString();

    // Then
    actual.Should().Be(expected);
    mockFileService.Verify(s => s.SaveListToFile(Constants.SORTED_FILE_PATH, expectedList), Times.Once);
  }
}