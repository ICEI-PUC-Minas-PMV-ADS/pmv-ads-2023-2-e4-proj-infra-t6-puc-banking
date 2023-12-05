using Newtonsoft.Json;
using PucBookStore.Models;

namespace PucBookStore.Data {
    internal static class ApplicationContextSeed {
        public static void SeedContext(ApplicationContext context) {

            if (context is null) {
                throw new ArgumentNullException("context");
            }

            var books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText("books.json"));

            if (books is not null) {

                foreach (var book in books) {

                    if (context.Books
                        .Any(x => x.Title == book.Title)) {
                        continue;
                    }

                    context.Books.Add(book);
                }
            }

            context.SaveChanges();
        }
    }
}
