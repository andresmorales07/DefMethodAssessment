using DefMethodAssessment.Models;
using static DefMethodAssessment.Utils.DataParsingUtils;

namespace DefMethodAssessmentTests;

[TestClass]
public class DataParsingUtilsTest
{
  [TestMethod]
  public void TestParseCommaDelimitedLine()
  {
    var line = "Abercrombie, Neil, Male, Tan, 2/13/1943";

    var expected = new Person
    {
      LastName = "Abercrombie",
      FirstName = "Neil",
      DateOfBirth = DateTimeOffset.Parse("2/13/1943"),
      FavoriteColor = "Tan",
      Gender = "Male"
    };

    var actual = ParseCommaDelimitedLine(line);

    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void TestParsePipeDelimitedLine()
  {
    var line = "Smith | Steve | D | M | Red | 3-3-1985";

    var expected = new Person
    {
      LastName = "Smith",
      FirstName = "Steve",
      DateOfBirth = DateTimeOffset.Parse("3-3-1985"),
      Gender = "Male",
      FavoriteColor = "Red",
      MiddleInitial = "D"
    };

    var actual = ParsePipeDelimitedLine(line);

    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void TestParseSpaceDelimitedLine()
  {
    var line = "Seles Monica H F 12-2-1973 Black";

    var expected = new Person
    {
      LastName = "Seles",
      FirstName = "Monica",
      MiddleInitial = "H",
      Gender = "Female",
      DateOfBirth = DateTimeOffset.Parse("12-2-1973"),
      FavoriteColor = "Black"
    };

    var actual = ParseSpaceDelimitedLine(line);

    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void TestGetDelimiterType()
  {
    var content = @"Smith | Steve | D | M | Red | 3-3-1985
    Bonk | Radek | S | M | Green | 6-3-1975
    Bouillon | Francis | G | M | Blue | 6-3-1975";

    var expected = DelimiterType.Pipe;
    var actual = GetDelimiterType(content);

    Assert.AreEqual(expected, actual);
  }
}