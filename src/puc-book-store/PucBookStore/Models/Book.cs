namespace PucBookStore.Models {
    public class Book {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string? PreviewUrl { get; set; }
        public string? DownloadUrl { get; set; }
    }
}
