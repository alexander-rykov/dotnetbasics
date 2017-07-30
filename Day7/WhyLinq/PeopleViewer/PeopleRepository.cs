using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PeopleViewer.Library
{
    public class PeopleRepository
    {
        public void GetPeopleAsync()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                e.Result = GetPeople();
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                var people = (List<Person>)e.Result;
                OnGetPeopleCompleted(new GetPeopleCompletedEventArgs(people));
            };
            worker.RunWorkerAsync();
        }

        public IEnumerable<Person> GetPeopleSync()
        {
                return GetPeople();
        }

        public event EventHandler<GetPeopleCompletedEventArgs> GetPeopleCompleted;

        protected void OnGetPeopleCompleted(GetPeopleCompletedEventArgs e)
        {
            GetPeopleCompleted?.Invoke(this, e);
        }

        private IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>
            {
                new Person() { FirstName="Alan", LastName="Parker",
                    Birthday = new DateTime( 1974, 11, 24), Status= 5, Salary= 16000 },
                new Person() { FirstName="Anna", LastName="Stil",
                    Birthday = new DateTime(1998,11, 3), Status = 9, Salary = 10120 }, 
                new Person() { FirstName="Inna", LastName="Salense",
                    Birthday = new DateTime(1995,4, 4), Status = 8, Salary = 12000 },
                new Person() { FirstName="Mark", LastName="Frien",
                    Birthday = new DateTime(1988, 3, 12), Status = 10, Salary = 12450},
                new Person() { FirstName="Robert", LastName="Spring",
                    Birthday =new DateTime(1964, 12, 12), Status = 7, Salary = 22000 },
                new Person() { FirstName="Frank", LastName="Eventer",
                    Birthday = new DateTime(1997, 11, 5), Status = 5, Salary = 9000 },
                new Person() { FirstName="Frank", LastName="Eventer",
                    Birthday = new DateTime(1997, 12, 5), Status = 15, Salary = 8000 },
                new Person() { FirstName="Frank", LastName="Eventer",
                    Birthday = new DateTime(1956, 5, 25), Status = 11, Salary = 19000 },
                new Person() { FirstName="Anna", LastName="Lasman",
                    Birthday = new DateTime(1989, 2, 17), Status = 4, Salary = 6000 },
            };

            return people;
        }
    }
}
