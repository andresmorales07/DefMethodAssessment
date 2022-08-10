using DefMethodAssessment.Data;
using DefMethodAssessment.Models;
using static DefMethodAssessment.Utils.DataParsingUtils;

namespace DefMethodAssessment.Services;

public class DataParsingService : IDataParsingService
{
  private readonly IPersonDataContext _dataContext;
  //file names are hard coded for now, can be updated to read from command line args or a config file
  private readonly List<string> _fileNames = new() { "comma.txt", "pipe.txt", "space.txt" };
  private readonly IFileReaderService _fileReaderService;
  //input dir can be made configurable or part of command line args
  private readonly string _inputDir = "Inputs";

  public DataParsingService(IFileReaderService fileReaderService, IPersonDataContext dataContext)
  {
    _fileReaderService = fileReaderService;
    _dataContext = dataContext;
  }

  public async Task Run()
  {
    //read data from each file
    foreach (var fileName in _fileNames)
    {
      //generate the full path to the input files
      var path = $"{_inputDir}/{fileName}";
      var fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);

      //get the contents
      var content = await _fileReaderService.ReadTextAsync(fullPath);

      //if it failed to get the file contents, move on
      if (content == null) continue;

      //parse the contents
      ParseFileContent(content);
    }

    //get the full list of people from the data context
    var people = _dataContext.GetPeople();

    Console.WriteLine("Output 1:");
    PrintPersonList(DoSort1(people));

    Console.WriteLine();

    Console.WriteLine("Output 2:");
    PrintPersonList(DoSort2(people));

    Console.WriteLine();

    Console.WriteLine("Output 3:");
    PrintPersonList(DoSort3(people));
  }

  private void ParseFileContent(string content)
  {
    var delimiterType = GetDelimiterType(content);
    var lines = content.Split('\n');

    foreach (var line in lines)
      try
      {
        var person = delimiterType switch
        {
          DelimiterType.Comma => ParseCommaDelimitedLine(line),
          DelimiterType.Pipe => ParsePipeDelimitedLine(line),
          DelimiterType.Space => ParseSpaceDelimitedLine(line),
          _ => throw new ArgumentOutOfRangeException()
        };

        //add person to data context
        _dataContext.AddPerson(person);
      }
      catch (Exception e)
      {
        Console.WriteLine($"Failed to parse line: {e.Message}");
      }
  }
  
  private static void PrintPersonList(IEnumerable<Person> people)
  {
    foreach (var person in people)
      Console.WriteLine(person.ToString());
  }
}