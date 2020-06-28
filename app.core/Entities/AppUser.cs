using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace App.Core.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }      
        public DateTime? DOB { get; set; }
        public bool? Twofactor_GoogleAuthen { get; set; }
    }
}