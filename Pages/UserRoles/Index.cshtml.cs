using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityCore.Data;
using IdentityCore.Models;

namespace IdentityCore.Pages.UserRoles
{
    public class IndexModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;

        public IndexModel(IdentityCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUserRole> ApplicationUserRole { get;set; }

        public async Task OnGetAsync()
        {
            ApplicationUserRole = await _context.ApplicationUserRole
                .Include(a => a.Role)
                .Include(a => a.User).ToListAsync();
        }
    }
}
