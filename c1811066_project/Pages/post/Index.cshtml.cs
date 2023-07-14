﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using c1811066_project.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace c1811066_project.Pages.post
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly c1811066_project.Models.c1811066_CENG382PROJECTContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(c1811066_project.Models.c1811066_CENG382PROJECTContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<UserPost> UserPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            UserPost = await _context.UserPosts.ToListAsync();
           
        }
    }
}
