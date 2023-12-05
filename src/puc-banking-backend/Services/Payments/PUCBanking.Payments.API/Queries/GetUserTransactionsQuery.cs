namespace PUCBanking.Payments.API.Queries {
    public class GetUserTransactionsQuery : IQuery {
        public string UserEmail { get; set; }
    }
}
