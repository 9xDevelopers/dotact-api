using app.core.BaseEntities;

namespace app.core.Entities
{
    public class Product : DefaultEntity
    {
        public string Name {get;set;}
        public int CategoryId { get; set; }
    }
}