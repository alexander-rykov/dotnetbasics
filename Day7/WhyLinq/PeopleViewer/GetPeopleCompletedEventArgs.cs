using System;
using System.Collections.Generic;

namespace PeopleViewer
{
    public class GetPeopleCompletedEventArgs : EventArgs
    {
        public IEnumerable<Person> Result { get; set; }

        public GetPeopleCompletedEventArgs(IEnumerable<Person> people)
        {
            Result = people;
        }
    }
}
