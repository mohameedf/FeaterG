using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeaterG.Data;
using FeaterG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FeaterG.Pages.Users
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }
        public async Task<IActionResult> OnGetAsync(string Id)
        {
            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == Id);
            return Page();
        }
        public async Task<IActionResult> OnPost(ApplicationUser applicationUser)
        {
            var applicationUser2 = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == applicationUser.Id);
            applicationUser2.FullName = applicationUser.FullName;
            applicationUser2.PhoneNumber = applicationUser.PhoneNumber;
            await _db.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
