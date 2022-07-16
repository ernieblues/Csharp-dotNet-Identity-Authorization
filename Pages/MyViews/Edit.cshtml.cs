using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityCore.Data;
using IdentityCore.Models;

namespace IdentityCore.Pages.MyViews
{
    public class EditModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;

        public EditModel(IdentityCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyView MyView { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyView = await _context.MyViews
                .Include(m => m.User).FirstOrDefaultAsync(m => m.MyViewId == id);

            if (MyView == null)
            {
                return NotFound();
            }
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MyView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyViewExists(MyView.MyViewId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MyViewExists(int id)
        {
            return _context.MyViews.Any(e => e.MyViewId == id);
        }
    }
}
