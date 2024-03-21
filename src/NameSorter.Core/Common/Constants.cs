public static class Constants
{
  public const string SORTED_FILE_PATH = "./sorted-names-list.txt";
  public const string SORTED_NAMES_TITLE = "Sorted Names:";
}

public static class ErrorMessage
{
  public const string NO_VALID_NAME_IN_FILE = "There is no valid name in file";
  public const string INVALID_NAME_IN_FILE = "Invalid sort direction. Should be 'ASC' or 'DESC'";
  public const string INVALID_FILE_PATH = "Please input the file path:";
}

public static class SortDirection {
  public const string ASC = "ASC";
  public const string DESC = "DESC";
}