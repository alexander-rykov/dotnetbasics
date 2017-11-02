using System.Collections.Generic;

namespace CsvParserApp.Models
{
    public class MovieDataSet
    {
        public MovieDataSet()
        {
            Movies = new List<Movie>();
            Genres = new List<Genre>();
            Users = new List<User>();
        }

        public IList<Movie> Movies { get; }

        public IList<Genre> Genres { get; }

        public IList<User> Users { get; }
    }
}
