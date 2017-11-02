using System.Collections.Generic;

namespace CsvParserApp.XmlModels
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<MovieGenre> Genres { get; set; }

        public List<MovieTag> Tags { get; set; }

        public List<MovieRating> Ratings { get; set; }
    }
}
