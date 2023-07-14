using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using c1811066_project.Models;
using Microsoft.AspNetCore.Authorization;

namespace c1811066_project.Pages.post
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly c1811066_project.Models.c1811066_CENG382PROJECTContext _context;

        public DetailsModel(c1811066_project.Models.c1811066_CENG382PROJECTContext context)
        {
            _context = context;
        }

      public UserPost UserPost { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserPosts == null)
            {
                return NotFound();
            }

            var userpost = await _context.UserPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (userpost == null)
            {
                return NotFound();
            }
            else 
            {
                UserPost = userpost;
            }
            return Page();
        }
    }
}
