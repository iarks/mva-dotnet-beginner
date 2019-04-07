using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MVA_Beginner.Pages
{
    
    public class EditModel : PageModel
    {
        private readonly AppDBContext _db;

        public EditModel(AppDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        [HttpGet]
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _db.Customers.FindAsync(id);
            if(Customer==null) { return RedirectToPage("/read"); }
            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            _db.Attach(Customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException e)
            {
                throw new Exception($"Customer {Customer.ID}", e);
            }

            if (Customer == null) { return RedirectToPage("/read"); }
            return RedirectToPage("/read");
        }
    }
}