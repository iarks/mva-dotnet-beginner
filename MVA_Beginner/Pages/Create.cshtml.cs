using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MVA_Beginner.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _db;

        public CreateModel(AppDBContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }
       
        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); };

            await _db.AddAsync(Customer);
            await _db.SaveChangesAsync();

            Message = $"Customer Created - {Customer.Name}";

            return RedirectToPage("/read");
        }
    }
}