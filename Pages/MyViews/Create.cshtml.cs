using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityCore.Data;
using IdentityCore.Models;

namespace IdentityCore.Pages.MyViews
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
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MyView MyView { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MyViews.Add(MyView);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}