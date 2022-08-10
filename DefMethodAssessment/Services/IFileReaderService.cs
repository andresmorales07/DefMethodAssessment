namespace DefMethodAssessment.Services;

public interface IFileReaderService
{
  /// <summary>
  ///   Read the contents of the file at the specified path and return it as a string.
  /// </summary>
  /// <param name="filePath">The path of the file</param>
  /// <returns>The contents of the file as a string. Returns null if the file doesn't exist or an error occurs.</returns>
  Task<string?> ReadTextAsync(string filePath);
}