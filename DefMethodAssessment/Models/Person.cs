namespace DefMethodAssessment.Models;

public class Person
{
  public string? FirstName { get; set; }
  public string? MiddleInitial { get; set; }
  public string? LastName { get; set; }
  public string? Gender { get; set; }
  public DateTimeOffset DateOfBirth { get; set; }
  public string? FavoriteColor { get; set; }

  public override string ToString()
  {
    var parts = new List<string?>
    {
      LastName,
      FirstName,
      Gender,
      DateOfBirth.ToString("M/d/yyyy"),
      FavoriteColor
    };
    return string.Join(" ", parts);
  }

#pragma warning disable CS0659
  public override bool Equals(object? obj)
#pragma warning restore CS0659
  {
    var person = obj as Person;
    if (person == null) return false;
    return LastName == person.LastName
           && FirstName == person.FirstName
           && MiddleInitial == person.MiddleInitial
           && DateOfBirth.Equals(person.DateOfBirth)
           && FavoriteColor == person.FavoriteColor
           && Gender == person.Gender;
  }
}