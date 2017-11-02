using System.Collections.Generic;

namespace CsvParserApp.Models
{
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genre>();
            Tags = new List<UserTag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public IList<Genre> Genres { get; }

        public IList<UserTag> Tags { get; }
    }
}
