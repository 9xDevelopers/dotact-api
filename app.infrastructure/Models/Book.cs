using System;

namespace app.infrastructure.Models
{
    public class Book : BaseEntity
    {
        public String Title { get; set; }
        public DateTime Year { get; set; }
    }
}