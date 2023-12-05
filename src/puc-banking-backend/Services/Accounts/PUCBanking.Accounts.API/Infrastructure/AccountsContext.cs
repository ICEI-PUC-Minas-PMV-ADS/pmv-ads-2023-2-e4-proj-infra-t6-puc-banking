using Microsoft.EntityFrameworkCore;
using PUCBanking.Accounts.API.Models;

namespace PUCBanking.Accounts.API.Infrastructure {
    public class AccountsContext : DbContext {
        public AccountsContext(DbContextOptions<AccountsContext> options)
            : base(options){ }

        public DbSet<Account> Accounts { get; set; }
    }
}
