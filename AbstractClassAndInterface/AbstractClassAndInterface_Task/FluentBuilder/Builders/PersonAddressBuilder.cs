namespace FluentBuilder.Builders
{
  public class PersonAddressBuilder
  {
    private Person person;
    public PersonAddressBuilder(Person person)
    {
      this.person = person;
    }
    public PersonAddressBuilder At(string streetAddress)
    {
      person.StreetAddress = streetAddress;
      return this;
    }
    public PersonAddressBuilder WithPostCode(string postCode)
    {
      person.PostCode = postCode;
      return this;
    }
    public PersonAddressBuilder In(string country)
    {
      person.Country = country;
      return this;
    }

    public PersonJobBuilder Works
    {
      get
      {
        return new PersonJobBuilder(person);
      }
    }
    public static implicit operator Person(PersonAddressBuilder builder)
    {
      return builder.person;
    }
  }
}
