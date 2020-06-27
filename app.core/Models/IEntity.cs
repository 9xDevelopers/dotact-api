using System;

namespace app.core.Models
{
    public interface IEntity<IdType> where IdType:IComparable
    {
        public IdType Id { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
    }
}