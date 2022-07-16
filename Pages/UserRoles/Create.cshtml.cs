using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityCore.Data;
using IdentityCore.Models;

namespace IdentityCore.Pages.UserRoles
{
    public class CreateModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;

        public CreateModel(IdentityCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            // ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserName"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["RoleName"] = new SelectList(_context.Roles, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ApplicationUserRole ApplicationUserRole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ApplicationUserRole.Add(ApplicationUserRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}