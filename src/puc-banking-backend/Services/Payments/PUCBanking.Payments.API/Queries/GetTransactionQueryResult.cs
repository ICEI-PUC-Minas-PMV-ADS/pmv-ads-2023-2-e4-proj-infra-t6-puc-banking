namespace PUCBanking.Payments.API.Queries {
    public class GetTransactionQueryResult : IQueryResult {
        public Guid Id { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
