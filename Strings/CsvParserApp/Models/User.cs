using System.Collections.Generic;

namespace CsvParserApp.Models
{
    public class User
    {
        public User()
        {
            Tags = new List<UserTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<UserTag> Tags { get; }
    }
}
