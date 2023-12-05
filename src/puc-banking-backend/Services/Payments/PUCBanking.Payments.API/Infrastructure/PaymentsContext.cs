using Microsoft.EntityFrameworkCore;

namespace PUCBanking.Payments.API.Infrastructure {
    public class PaymentsContext : DbContext {
        public PaymentsContext(DbContextOptions<PaymentsContext> options)
            : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
