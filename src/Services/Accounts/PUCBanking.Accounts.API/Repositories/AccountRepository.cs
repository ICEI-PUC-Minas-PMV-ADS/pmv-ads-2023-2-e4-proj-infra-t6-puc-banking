using Microsoft.EntityFrameworkCore;
using PUCBanking.Accounts.API.Infrastructure;
using PUCBanking.Accounts.API.Models;

namespace PUCBanking.Accounts.API.Repositories {
    public class AccountRepository {

        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) {
            _context = context;
        }

        public async Task<Account?> FindAccount(Guid id) {

            var account = await _context.Accounts.FindAsync(id);

            return account;
        }
        public async Task<Account?> FindAccount(string username) {

            var account = await _context.Accounts
                .FirstOrDefaultAsync(x => x.Username == username);

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
