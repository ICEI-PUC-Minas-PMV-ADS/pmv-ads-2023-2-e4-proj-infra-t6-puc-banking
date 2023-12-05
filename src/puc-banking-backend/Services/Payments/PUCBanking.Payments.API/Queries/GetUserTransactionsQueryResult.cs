namespace PUCBanking.Payments.API.Queries {
    public class GetUserTransactionsQueryResult : IQueryResult {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
