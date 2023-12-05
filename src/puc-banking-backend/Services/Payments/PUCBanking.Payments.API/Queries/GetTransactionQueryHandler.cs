namespace PUCBanking.Payments.API.Queries {
    public class GetTransactionQueryHandler
        : IQueryHandler<GetTransactionQuery, GetTransactionQueryResult> {

        private readonly TransactionRepository _repository;
        public GetTransactionQueryHandler(TransactionRepository repository) {
            _repository = repository;
        }

        public async Task<GetTransactionQueryResult> Handle(GetTransactionQuery query) {
            
            var transaction = await _repository
                .GetTransaction(query.TransactionId);

            if (transaction is null) {
                return null;
            }

            return new GetTransactionQueryResult {
                Id = query.TransactionId,
                Status = transaction.Status,
            };
        }
    }
}
