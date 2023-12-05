namespace PucBookStore.Contracts {
    public class CheckoutRequest {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? ZIP { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? CardExpiration { get; set; }
        public string? CardCVV { get; set; }
        public bool SaveInfos { get; set; }
    }
}
