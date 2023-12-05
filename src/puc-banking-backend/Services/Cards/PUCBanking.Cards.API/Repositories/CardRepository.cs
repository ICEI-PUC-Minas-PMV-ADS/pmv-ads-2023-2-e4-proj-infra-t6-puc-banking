using Microsoft.EntityFrameworkCore;

namespace PUCBanking.Cards.API.Repositories {
    public class CardRepository {

        private readonly CardContext _context;
        public CardRepository(CardContext context) {
            _context = context;
        }

        public async Task<CreditCard?> FindUserCreditCard(string userEmail) {

            var card = await _context.Cards.FirstOrDefaultAsync(x => x.UserEmail == userEmail);

            return card;
        }
        public async Task<CreditCard?> FindUserCreditCard(long cardNumber) {

            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Number == cardNumber);

            return card;
        }
        public async Task SaveCreditCard(CreditCard creditCard) {

            if (await _context.Cards.AnyAsync(x => x.UserEmail == creditCard.UserEmail)) {
                throw new InvalidOperationException("Usuário já tem um cartão associado.");
            }

            await _context.Cards.AddAsync(creditCard);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges() {
            await _context.SaveChangesAsync();
        }
    }
}
