using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PucBookStore.Data;
using PucBookStore.Models;

namespace PucBookStore.Areas.Identity.Pages.Account {
    public class IndexModel : PageModel
    {
        public readonly ApplicationContext _context;
        public IndexModel(ApplicationContext context) {
            _context = context;
        }

        public List<UserBook> UserBooks { get; set; } = new List<UserBook>();
        public async Task OnGet() {
            var userBooks = await _context.UserBooks
                   .Where(b => b.Username == User.Identity.Name)
                   .ToListAsync();

            UserBooks = userBooks;
        }
    }
}
