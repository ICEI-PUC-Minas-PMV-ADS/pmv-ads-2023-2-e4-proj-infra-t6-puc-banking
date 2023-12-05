using Microsoft.EntityFrameworkCore;

namespace PUCBanking.Payments.API.Repositories {
    public class TransactionRepository {

        private readonly PaymentsContext _context;
        public TransactionRepository(PaymentsContext context) {
            _context = context;
        }

        public async Task<Transaction?> GetTransaction(Guid id) {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<Transaction>> GetTransactions(string UserEmail) {
            return await _context.Transactions
                .Where(x => x.UserEmail == UserEmail)
                .ToListAsync();
        }
        public async Task AddTransaction(Transaction transaction) {

            if (transaction == null) {
                throw new ArgumentNullException(nameof(transaction));
            }

            await _context.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges() {
            await _context.SaveChangesAsync();
        }
    }
}
