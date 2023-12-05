namespace PucBookStore.Models {
    public class BasketItem {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Year { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? PreviewUrl { get; set; }
        public string? DownloadUrl { get; set; }
    }
}
