namespace PucBookStore.Models {
    public class UserBook {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public string? PreviewUrl { get; set; }
        public string? DownloadUrl { get; set; }
    }
}
