using System;

namespace app.core.Models
{
    public class Book : BaseEntity
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
    }
}