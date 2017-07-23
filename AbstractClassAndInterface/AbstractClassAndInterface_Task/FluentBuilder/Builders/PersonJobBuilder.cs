namespace FluentBuilder.Builders
{
  public class PersonJobBuilder
  {
    private Person person;
    public PersonJobBuilder(Person person)
    {
      this.person = person;
    }
    public PersonJobBuilder At(string companyName)
    {
      person.CompanyName = companyName;
      return this;
    }
    public PersonJobBuilder AsA(string position)
    {
      person.Position = position;
      return this;
    }
    public PersonJobBuilder Earning(int dollarsPerMonth)
    {
      person.AnnualIncome = dollarsPerMonth;
      return this;
    }
    public PersonAddressBuilder Lives
    {
      get
      {
        return new PersonAddressBuilder(person);
      }
    }
    public static implicit operator Person(PersonJobBuilder builder)
    {
      return builder.person;
    }
  }
}
