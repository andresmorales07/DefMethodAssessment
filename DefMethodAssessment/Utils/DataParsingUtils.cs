using DefMethodAssessment.Models;
using DefMethodAssessment.Services;

namespace DefMethodAssessment.Utils;

public static class DataParsingUtils
{
  public static DelimiterType GetDelimiterType(string content)
  {
    if (content.Contains(',')) return DelimiterType.Comma;
    if (content.Contains('|')) return DelimiterType.Pipe;
    return DelimiterType.Space; // if the content doesn't have , or | then the delimiter would be spaces
  }

  public static Person ParseCommaDelimitedLine(string line)
  {
    var parts = line.Split(',');

    //check if the line is properly formatted
    if (parts.Length != 5) throw new ArgumentException("Comma-delimited line is improperly formatted");

    var lastName = parts[0].Trim();
    var firstName = parts[1].Trim();
    var gender = parts[2].Trim();
    var favoriteColor = parts[3].Trim();
    var dob = parts[4].Trim();

    var dateOfBirth = DateTimeOffset.Parse(dob);

    var person = new Person
    {
      LastName = lastName,
      FirstName = firstName,
      FavoriteColor = favoriteColor,
      DateOfBirth = dateOfBirth,
      Gender = gender
    };

    return person;
  }

  public static Person ParsePipeDelimitedLine(string line)
  {
    var parts = line.Split('|');

    //check if line is properly formatted
    if (parts.Length != 6) throw new ArgumentException("Pipe-delimited line is improperly formatted");

    var lastName = parts[0].Trim();
    var firstName = parts[1].Trim();
    var middleInitial = parts[2].Trim();
    var gender = parts[3].Trim();
    var favoriteColor = parts[4].Trim();
    var dob = parts[5].Trim();

    var dateOfBirth = DateTimeOffset.Parse(dob);

    var person = new Person
    {
      LastName = lastName,
      FirstName = firstName,
      MiddleInitial = middleInitial,
      FavoriteColor = favoriteColor,
      DateOfBirth = dateOfBirth,
      Gender = gender == "M" ? "Male" : "Female"
    };

    return person;
  }

  public static Person ParseSpaceDelimitedLine(string line)
  {
    var parts = line.Split(" ");

    //check if line is properly formatted
    if (parts.Length != 6) throw new ArgumentException("Space-delimited line is improperly formatted");

    var lastName = parts[0].Trim();
    var firstName = parts[1].Trim();
    var middleInitial = parts[2].Trim();
    var gender = parts[3].Trim();
    var dob = parts[4].Trim();
    var favoriteColor = parts[5].Trim();

    var dateOfBirth = DateTimeOffset.Parse(dob);

    var person = new Person
    {
      LastName = lastName,
      FirstName = firstName,
      MiddleInitial = middleInitial,
      DateOfBirth = dateOfBirth,
      FavoriteColor = favoriteColor,
      Gender = gender == "M" ? "Male" : "Female"
    };

    return person;
  }

  public static IEnumerable<Person> DoSort1(IEnumerable<Person> people)
  {
    return people.OrderBy(p => p.Gender).ThenBy(p => p.LastName).ToList();
  }

  public static IEnumerable<Person> DoSort2(IEnumerable<Person> people)
  {
    return people.OrderBy(p => p.DateOfBirth).ThenBy(p => p.LastName);
  }

  public static IEnumerable<Person> DoSort3(IEnumerable<Person> people)
  {
    return people.OrderByDescending(p => p.LastName);
  }
}