using PucBookStore.Events;
using PucBookStore.Models;

namespace PucBookStore.ViewModels {
    public class HomeViewModel {
        public List<Book> Books { get; set; }
        public string BasketUsername { get; set; }
        public Basket Basket { get; set; }
        public Event Event { get; set; }
    }
}
