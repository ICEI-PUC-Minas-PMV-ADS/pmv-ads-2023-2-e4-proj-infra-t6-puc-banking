namespace PUCBanking.Payments.API.Queries {
    public class GetTransactionQuery : IQuery {
        public Guid TransactionId { get; set; }
    }
}
