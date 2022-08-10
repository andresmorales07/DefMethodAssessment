using DefMethodAssessment.Models;

namespace DefMethodAssessment.Data;

public class PersonDataContext : IPersonDataContext
{
  private readonly List<Person> _people;

  public PersonDataContext()
  {
    _people = new List<Person>();
  }

  public void AddPerson(Person person)
  {
    _people.Add(person);
  }

  public List<Person> GetPeople()
  {
    return _people;
  }
}