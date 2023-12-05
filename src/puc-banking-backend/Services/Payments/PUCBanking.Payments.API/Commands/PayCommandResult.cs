namespace PUCBanking.Payments.API.Commands {
    public class PayCommandResult : ICommandResult {
        public Guid Id { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
