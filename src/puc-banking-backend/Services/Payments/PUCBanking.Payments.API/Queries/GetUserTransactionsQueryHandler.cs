namespace PUCBanking.Payments.API.Queries {
    public class GetUserTransactionsQueryHandler
        : IQueryHandler<GetUserTransactionsQuery, GetUserTransactionsQueryResult> {

        private readonly TransactionRepository _repository;
        public GetUserTransactionsQueryHandler(TransactionRepository repository) {
            _repository = repository;
        }

        public async Task<GetUserTransactionsQueryResult> Handle(GetUserTransactionsQuery query) {

            var transactions = await _repository
                .GetTransactions(query.UserEmail);

            return new GetUserTransactionsQueryResult {
                Transactions = transactions,
            };
        }
    }
}
