using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeaterG.Data;
using FeaterG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FeaterG.Pages.ServiceTypes
{
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ServiceType ServiceType { get; set; }
        public async Task<IActionResult> OnGetAsync( int? Id)
        {
            ServiceType = await _db.ServiceType.FirstOrDefaultAsync(m => m.Id == Id);
            return Page();
        }
        public async Task<IActionResult> OnPost(ServiceType ServiceType)
        {
            if(ServiceType == null) { return NotFound(); }
            _db.ServiceType.Remove(ServiceType);
            await _db.SaveChangesAsync();
           
            return Redirect("Index");
        }
    }
}
