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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUserRole ApplicationUserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string userid, string roleid)
        {
            if (userid == null || roleid == null)
            {
                return NotFound();
            }

            ApplicationUserRole = await _context.ApplicationUserRole
                .Include(a => a.Role)
                .Include(a => a.User).FirstOrDefaultAsync(m => m.UserId == userid && m.RoleId == roleid);

            if (ApplicationUserRole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userid, string roleid)
        {
            if (userid == null || roleid == null)
            {
                return NotFound();
            }

            ApplicationUserRole = await _context.ApplicationUserRole.FindAsync(userid, roleid);

            if (ApplicationUserRole != null)
            {
                _context.ApplicationUserRole.Remove(ApplicationUserRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
