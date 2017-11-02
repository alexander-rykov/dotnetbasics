using System;

namespace CsvParserApp.Models
{
    public class UserRating
    {
        public User User { get; set; }

        public Movie Movie { get; set; }

        public double Rating { get; set; }

        public DateTime RateDate { get; set; }
    }
}
