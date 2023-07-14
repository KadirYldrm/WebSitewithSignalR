// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using c1811066_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace c1811066_project.Areas.Identity.Pages.Account.Manage
{
    public class PictureModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly c1811066_CENG382PROJECTContext _context;

        public PictureModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            c1811066_CENG382PROJECTContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public BufferedSingleFileUploadDb? FileUpload { get; set; }

        public byte[] Picture { get; set; }

        public UserProfile UserDetails { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }
        public string UserId { get; private set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>


        private async Task LoadAsync(IdentityUser user)
        {
            UserDetails = _context.UserProfiles.Where(p => p.UserId == user.Id).FirstOrDefault();
            if (UserDetails != null)
            {
                Picture = UserDetails.Picture;
            }
            else
            {
                //Read Image File into Image object.
                string path = "./wwwroot/images/empty_Profile.png";
                var memoryStream = new MemoryStream();
                using (var stream = System.IO.File.OpenRead(path))
                {
                    await new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name)).CopyToAsync(memoryStream);
                    Picture = memoryStream.ToArray();
                };
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            UserDetails = _context.UserProfiles.Where(p => p.UserId == user.Id).FirstOrDefault();
            if (UserDetails.Picture != Picture)
            {
                var memoryStream = new MemoryStream();
                await FileUpload.FormFile.CopyToAsync(memoryStream);
                UserDetails.Picture = memoryStream.ToArray();
                UserDetails.UserId = user.Id;

                _context.UserProfiles.Update(UserDetails);
                await _context.SaveChangesAsync();
                StatusMessage = "Your profile photo is changed.";

                return RedirectToPage();
            }
            return RedirectToPage();
        }

        
    }
}
