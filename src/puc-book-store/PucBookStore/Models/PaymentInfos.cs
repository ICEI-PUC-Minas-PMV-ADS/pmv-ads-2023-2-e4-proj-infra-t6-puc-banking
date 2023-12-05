namespace PucBookStore.Models {
    public class PaymentInfos {
        public Guid Id { get; set; }
        public string Username { get; set; }
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

        public static PaymentInfos Empty => new PaymentInfos {
            FirstName = string.Empty,
            LastName = string.Empty,
            Email = string.Empty,
            Address = string.Empty,
            State = string.Empty,
            ZIP = string.Empty,
            CardCVV = string.Empty,
            CardName = string.Empty,
            CardNumber = string.Empty,
            CardExpiration = string.Empty
        };
    }
}
