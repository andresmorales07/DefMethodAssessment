namespace DefMethodAssessment.Services;

public class FileReaderService : IFileReaderService
{
  public async Task<string?> ReadTextAsync(string filePath)
  {
    try
    {
      return await File.ReadAllTextAsync(filePath);
    }
    //if an error occurs, log to console and return null
    //can handle more specific exceptions in a separate catch if needed (like FileNotFound)
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      return null;
    }
  }
}