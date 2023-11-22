using Microsoft.EntityFrameworkCore;
using PUCBanking.Accounts.API.Models;

namespace PUCBanking.Accounts.API.Infrastructure {
    public class AccountContext : DbContext {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
    }
}
