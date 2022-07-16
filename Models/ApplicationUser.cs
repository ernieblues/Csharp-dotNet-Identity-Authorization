using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public virtual ICollection<MyView> MyViews { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
