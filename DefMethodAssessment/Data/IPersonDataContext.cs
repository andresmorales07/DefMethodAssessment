using DefMethodAssessment.Models;

namespace DefMethodAssessment.Data;

public interface IPersonDataContext
{
  void AddPerson(Person person);
  List<Person> GetPeople();
}