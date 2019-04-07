using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MVA_Beginner.Pages
{

    public class ReadModel : PageModel
    {

        private readonly AppDBContext _db;

        public ReadModel(AppDBContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        public IList<Customer> Customers { get; private set; }

        [HttpGet]
        public async Task OnGetAsync()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Customer customer = await _db.Customers.FindAsync(id);
            if(customer!=null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}