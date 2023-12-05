using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PucBookStore.Data;
using PucBookStore.Data.Repositories;
using PucBookStore.Models;
using PucBookStore.ViewModels;
using System.Diagnostics;

namespace PucBookStore.Controllers {
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        private readonly BasketRepository _basketRepository;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context, BasketRepository basketRepository) {
            _logger = logger;
            _context = context;
            _basketRepository = basketRepository;
        }

        public async Task<IActionResult> Index(string basketUsername = null) {

            var viewModel = new HomeViewModel();

            if (User.Identity.IsAuthenticated) {

                var userBooks = await _context.UserBooks
                    .Where(b => b.Username == User.Identity.Name)
                    .ToListAsync();

                var books = await _context.Books.ToListAsync();

                viewModel.Books = books.Where(b => !userBooks.Any(a => a.Title == b.Title)).ToList();

                var basket = await _basketRepository.GetBasket(User.Identity.Name);

                if (basket is not null) {
                    viewModel.Basket = basket;
                } else {

                    viewModel.Basket = new Basket();
                    viewModel.Basket.Username = User.Identity.Name;

                    await _basketRepository.AddBasket(viewModel.Basket);
                }
            } else {

                var books = await _context.Books.ToListAsync();

                viewModel.Books = books;

                if (basketUsername is not null) {
                    viewModel.Basket = await _basketRepository.GetBasket(basketUsername);
                    viewModel.Basket.Username = basketUsername;
                } else {
                    viewModel.Basket = new Basket();
                    viewModel.Basket.Username = $"anon_{Guid.NewGuid()}";
                }

                await _basketRepository.AddBasket(viewModel.Basket);
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
