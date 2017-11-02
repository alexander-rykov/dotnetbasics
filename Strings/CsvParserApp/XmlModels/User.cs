using System.Collections.Generic;

namespace CsvParserApp.XmlModels
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> TaggedMovies { get; set; }

        public List<int> RatedMovies { get; set; }
    }
}
