using System;

namespace CsvParserApp.Models
{
    public class UserTag
    {
        public User User { get; set; }

        public Movie Movie { get; set; }

        public string Tag { get; set; }

        public DateTime TagDate { get; set; }
    }
}
