namespace PucBookStore.Models {
    public class Basket {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
