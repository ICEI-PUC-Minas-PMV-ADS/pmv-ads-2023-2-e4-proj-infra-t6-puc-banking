using Microsoft.EntityFrameworkCore;
using PUCBanking.Identity.API.Infrastructure;
using PUCBanking.Identity.API.Models;
using System.Text;

namespace PUCBanking.Identity.UnitTests {
    public static class DevSettings {

        private static IdentityContext InMemoryDatabaseInstance;
        public static IdentityContext GetInMemoryDatabase(bool seedDatabase) {

            if (InMemoryDatabaseInstance is not null) {
                return InMemoryDatabaseInstance;
            }

            var options = new DbContextOptionsBuilder<IdentityContext>().
                UseInMemoryDatabase("pucbanking-identity").
                UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).
                Options;

            var database = new IdentityContext(options);

            if (seedDatabase) {
                SeedDatabase(database);
            }

            InMemoryDatabaseInstance = database;

            return database;
        }

        private static void SeedDatabase(IdentityContext context) {
            context.Users.AddRange(DefaultUsers());
            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        private static List<User> DefaultUsers() {
            return new List<User> {
                new User() {
                    Id = Guid.Parse("ba56273d-0c8b-4ea6-90ac-691494d1f402"),
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Email = "batman@mail.com",
                    Password = "Teste@123" },
                new User() {
                    Id = Guid.Parse("b6a5e02a-40cd-4a47-960c-1a189ecd821a"),
                    FirstName = "Robin",
                    LastName = "Francis",
                    Email = "robin@mail.com",
                    Password = "Teste@123" },
            };
        }
    }

    public static class AsyncHelper {
        public static TResult RunSync<TResult>(this Task<TResult> task) {
            return task.GetAwaiter().GetResult();
        }
    }

    public static class StringUtils {
        public static string CreateLongString(string pattern, int times) {
            
            var stringBuilder = new StringBuilder();

            for(int i = 0; i < times; i++) {
                stringBuilder.Append(pattern);
            }

            return stringBuilder.ToString();
        }
    }
}
