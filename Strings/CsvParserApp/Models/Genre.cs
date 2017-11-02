using System.Collections.Generic;

namespace CsvParserApp.Models
{
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }

        public string Name { get; set; }

        public IList<Movie> Movies { get; }
    }
}
