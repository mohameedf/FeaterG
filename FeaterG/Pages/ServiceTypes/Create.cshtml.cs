using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeaterG.Data;
using FeaterG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FeaterG.Pages.ServiceTypes
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public ServiceType ServiceType { get; set; }
        public async Task <IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }
            await _db.ServiceType.AddAsync(ServiceType);
            await _db.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
