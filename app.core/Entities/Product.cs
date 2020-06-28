using App.Core.BaseEntities;

namespace App.Core.Entities
{
    public class Product : DefaultEntity
    {
        public string Name {get;set;}
        public int CategoryId { get; set; }
    }
}