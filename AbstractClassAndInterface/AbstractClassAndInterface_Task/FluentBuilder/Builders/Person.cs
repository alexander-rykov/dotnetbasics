using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder.Builders
{
  public class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }

    public string StreetAddress { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }

    public string CompanyName { get; set; }
    public string Position { get; set; }
    public int AnnualIncome { get; set; }

    public static PersonBuilder Create()
    {
      return new PersonBuilder(new Person());
    }
  }
}
