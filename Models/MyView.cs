using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Models
{
    public class MyView
    {
        [Key]
        public int MyViewId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(450)")] // match with primary key
        [ForeignKey("User")]                 // primary key AspNetUseres.Id
        public string UserId { get; set; }
        
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Column1 { get; set; }

        [Required]
        public string Column2 { get; set; }

        [Required]
        public string Column3 { get; set; }
    }
}