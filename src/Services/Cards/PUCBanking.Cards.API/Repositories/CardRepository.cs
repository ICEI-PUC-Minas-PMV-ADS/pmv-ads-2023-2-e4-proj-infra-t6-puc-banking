using Microsoft.EntityFrameworkCore;
using PUCBanking.Cards.API.Infrastructure;
using PUCBanking.Cards.API.Models;

namespace PUCBanking.Cards.API.Repositories {
    public class CardRepository {

        private readonly CardContext _context;
        public CardRepository(CardContext context) {
            _context = context;
        }

        public async Task<CreditCard?> FindUserCreditCard(string username) {

            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Username == username);

            return card;
        }

        public async Task SaveCreditCard(CreditCard creditCard) {

            if (await _context.Cards.AnyAsync(x => x.Username == creditCard.Username)) {
                throw new InvalidOperationException("Usuário já tem um cartão associado.");
            }

            await _context.Cards.AddAsync(creditCard);
            await _context.SaveChangesAsync();
        }
    }
}
