using System;

namespace CsvParserApp.XmlModels
{
    public class MovieRating
    {
        public int UserId { get; set; }

        public double Rating { get; set; }

        public DateTime RateDate { get; set; }
    }
}
