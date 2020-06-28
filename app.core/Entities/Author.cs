using App.Core.BaseEntities;
using System.Collections.Generic;

namespace App.Core.Entities
{
    public class Author : BaseEntity<int>
    {
        public Author()
        {
        }

        public Author(string name, string country, ICollection<Book> books)
        {
            Name = name;
            Country = country;
            Books = books;
        }

        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}