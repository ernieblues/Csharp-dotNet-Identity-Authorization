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
    public class DetailsModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;

        public DetailsModel(IdentityCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUserRole ApplicationUserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUserRole = await _context.ApplicationUserRole
                .Include(a => a.Role)
                .Include(a => a.User).FirstOrDefaultAsync(m => m.UserId == id);

            if (ApplicationUserRole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
