namespace FluentBuilder.Builders
{
  public class PersonBuilder
  {
    private Person person;
    public PersonBuilder(Person person)
    {
      this.person = person;
    }

    public PersonBuilder Called(string name)
    {
      person.Name = name;
      return this;
    }

    public PersonBuilder Age(int age)
    {
      person.Age = age;
      return this;
    }

    public PersonAddressBuilder Lives
    {
      get
      {
        return new PersonAddressBuilder(person);
      }
    }

    public static implicit operator Person(PersonBuilder pb)
    {
      return pb.person;
    }
  }
}
