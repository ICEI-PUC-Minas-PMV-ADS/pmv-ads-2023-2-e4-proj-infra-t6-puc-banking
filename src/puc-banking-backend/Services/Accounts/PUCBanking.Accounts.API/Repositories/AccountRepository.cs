using Microsoft.EntityFrameworkCore;

namespace PUCBanking.Accounts.API.Repositories {
    public class AccountRepository {

        private readonly AccountsContext _context;
        public AccountRepository(AccountsContext context) {
            _context = context;
        }
        public async Task<Account?> FindAccount(Guid id) {

            var account = await _context.Accounts.FindAsync(id);

            return account;
        }
        public async Task<Account?> FindAccount(string email) {

            var account = await _context.Accounts
                .FirstOrDefaultAsync(x => x.Email == email);

            return account;
        }
        public async Task SaveAccount(Account account) {

            if (await _context.Accounts
                .AnyAsync(x => x.Id == account.Id)) {
                throw new InvalidOperationException("Usuário já existe.");
            }

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}
