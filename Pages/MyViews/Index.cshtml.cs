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
    public class IndexModel : PageModel
    {
        private readonly IdentityCore.Data.ApplicationDbContext _context;

        public IndexModel(IdentityCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MyView> MyView { get;set; }

        public async Task OnGetAsync()
        {
            MyView = await _context.MyViews
                .Include(m => m.User).ToListAsync();
        }
    }
}
