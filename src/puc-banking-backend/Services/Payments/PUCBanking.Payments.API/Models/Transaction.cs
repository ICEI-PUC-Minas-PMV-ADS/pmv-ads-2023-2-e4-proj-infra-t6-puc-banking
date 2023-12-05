namespace PUCBanking.Payments.API.Models {
    public class Transaction {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserEmail { get; set; } = null!;
        public double Value { get; set; }
        public string Name { get; set; } = null!;
        public long CardNumber { get; set; }
        public string CardHolderName { get; set; } = null!;
        public int CardCVV { get; set; }
        public DateTime CardExpires { get; set; }
        public TransactionStatus Status { get; set; }
    }

    public enum TransactionStatus {
        PendingOfConfirmation,
        Approved,
        Reproved,
    }
}
