using System;

namespace app.core.BaseEntities
{
    public interface IEntity<IdType> where IdType : IComparable
    {
        public IdType Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}