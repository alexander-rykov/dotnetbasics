using PeopleViewer;
using PeopleViewer.Library;
using System.Collections.Generic;
using System.Linq;

namespace StandardQueryOperators
{
    public abstract class BaseTestClass
    {
        protected List<Person> personList { get; set; }

        public BaseTestClass()
        {
            personList = new PeopleRepository().GetPeopleSync().ToList();
        }
    }
}
