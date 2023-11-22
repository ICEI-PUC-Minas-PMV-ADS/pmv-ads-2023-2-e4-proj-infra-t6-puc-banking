using Microsoft.EntityFrameworkCore;

namespace PUCBanking.Identity.API.Infrastructure {
    public class IdentityContext : DbContext {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
