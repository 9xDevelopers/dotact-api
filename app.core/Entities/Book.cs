using app.core.BaseEntities;
using System;

namespace app.core.Entities
{
    public class Book : BaseEntity<int>
    {
        public Book()
        {
        }

        public Book(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public DateTime Year { get; set; }
        public Author Author { get; set; }
    }
}