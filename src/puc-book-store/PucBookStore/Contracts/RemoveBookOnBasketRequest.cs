namespace PucBookStore.Contracts {
    public class RemoveBookOnBasketRequest {
        public string BookId { get; set; }
        public string BasketUsername {  get; set; }
    }
}
