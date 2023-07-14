using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using c1811066_project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace c1811066_project.Pages.friends
{
    [Authorize]
    public class IndexModel : PageModel
    {
        
        private readonly c1811066_CENG382PROJECTContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(c1811066_CENG382PROJECTContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public Friend UserPost { get; set; } = default!;
        public bool aprrove { get; set; }
        public bool decline { get; set; }
        public List<Friend> Friend { get;set; }
        
        public async Task OnGetAsync()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var AllUsers = await (from u in _context.AspNetUsers
                                  where u.Id != userId
                                  select u).ToListAsync();
            Friend = new();

            foreach (var item in AllUsers)
            {
             
                var user = await _userManager.FindByIdAsync(item.Id);

                var userating = new Friend();
               
                userating.Friendid = item.UserName;
                userating.Userid = userId;
                userating.Aprrove = aprrove;
                await _context.Friends.AddAsync(userating);
                Friend.Add(userating);
                if (aprrove==true)
                {
                    Friend.Remove(userating);
                }
            }


            await _context.SaveChangesAsync();



        }
    }
}
