using Microsoft.EntityFrameworkCore;
using PUCBanking.Cards.API.Models;

namespace PUCBanking.Cards.API.Infrastructure {
    public class CardContext : DbContext {
        public CardContext(DbContextOptions<CardContext> options)
            : base(options) { }

        public DbSet<CreditCard> Cards { get; set; }
    }
}
