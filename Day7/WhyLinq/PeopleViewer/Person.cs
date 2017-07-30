using System;

namespace PeopleViewer
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Status { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}; {nameof(LastName)}: {LastName}; {nameof(Birthday)}: {Birthday.ToShortDateString()}; " +
                $"{nameof(Status)}: {Status}; {nameof(Salary)}; {Salary}";
        }

        //public override bool Equals(object obj)
        //{
        //    Person ps = obj as Person;
        //    if (ps == null)
        //        return false;
        //    else
        //        return ToString() == ps.ToString();
        //}
    }

}