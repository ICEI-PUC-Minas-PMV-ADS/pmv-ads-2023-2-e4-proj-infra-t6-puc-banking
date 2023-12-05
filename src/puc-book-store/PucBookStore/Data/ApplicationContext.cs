using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PucBookStore.Models;

namespace PucBookStore.Data {
    public class ApplicationContext : IdentityDbContext {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<PaymentInfos> PaymentInfos { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
    }
}
