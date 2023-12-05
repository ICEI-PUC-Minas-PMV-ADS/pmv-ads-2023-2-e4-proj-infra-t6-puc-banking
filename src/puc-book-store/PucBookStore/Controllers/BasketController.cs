using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PucBookStore.Contracts;
using PucBookStore.Data;
using PucBookStore.Data.Repositories;
using PucBookStore.Events;
using PucBookStore.Models;
using PucBookStore.ViewModels;

namespace PucBookStore.Controllers {
    public class BasketController : Controller {

        private readonly BasketRepository _basketRepository;
        private readonly ApplicationContext _context;
        public BasketController(BasketRepository basketRepository, ApplicationContext context) {
            _basketRepository = basketRepository;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookOnBasket([FromBody] AddBookOnBasketRequest request) {

            var viewModel = new HomeViewModel();
            viewModel.Books = await _context.Books.ToListAsync();

            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.BookId));

            var basket = await _basketRepository.GetBasket(request.BasketUsername);

            if (basket.Items
                .Any(x => x.BookId == book.Id)) {
                return BadRequest(new BasketItemAlreadyAddedEvent(book.Id));
            }

            basket.Items.Add(new BasketItem {
                Id = Guid.NewGuid(),
                BookId = book.Id,
                Author = book.Author,
                Price = book.Price,
                Title = book.Title,
                Year = book.Year,
                Description = book.Description,
                DownloadUrl = book.DownloadUrl,
                PreviewUrl = book.PreviewUrl,
            });

            await _basketRepository.UpdateBasketAsync(basket);

            return Ok(new BasketItemAddedEvent(book.Id));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBookOnBasket([FromBody] RemoveBookOnBasketRequest request) {

            var basket = await _basketRepository.GetBasket(request.BasketUsername);
            var book = basket.Items.FirstOrDefault(b => b.BookId == Guid.Parse(request.BookId));

            if (book is null) {
                return BadRequest(new BasketItemNotFoundEvent());
            }

            basket.Items.Remove(book);

            await _basketRepository.UpdateBasketAsync(basket);

            return Ok(new BasketItemRemovedEvent());
        }
    }
}
