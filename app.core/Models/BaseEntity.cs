using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.core.Models
{
    public abstract class BaseEntity<IdType> : IEntity<IdType> where IdType : IComparable 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public IdType Id { get; set; }

        public DateTime CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}