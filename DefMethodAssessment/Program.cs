using DefMethodAssessment.Data;
using DefMethodAssessment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DefMethodAssessment;
// Note: actual namespace depends on the project name.

public static class Program
{
  public static void Main(string[] args)
  {
    //set up DI
    var services = new ServiceCollection();
    services.AddSingleton<IPersonDataContext, PersonDataContext>(); //for storing file data, only one is needed
    services.AddTransient<IFileReaderService, FileReaderService>(); //handles operations involving the file system
    services.AddSingleton<IDataParsingService, DataParsingService>(); //main driver for the app

    var serviceProvider = services.BuildServiceProvider();
    var dataParsingService = serviceProvider.GetService<IDataParsingService>();
    dataParsingService?.Run();
  }
}