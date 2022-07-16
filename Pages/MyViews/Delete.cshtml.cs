using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityCore.Data;
using IdentityCore.Models;

namespace IdentityCore.Pages.MyViews
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;

        public DeleteModel(IdentityCore.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyView = await _context.MyViews.FindAsync(id);

            if (MyView != null)
            {
                _context.MyViews.Remove(MyView);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
