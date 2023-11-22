using PUCBanking.Accounts.API.Repositories;
using PUCBanking.Shared.CQRS;

namespace PUCBanking.Accounts.API.Queries {
    public class GetAccountQueryHandler
        : IQueryHandler<GetAccountQuery, GetAccountQueryResult> {

        private readonly AccountRepository _repository;
        public GetAccountQueryHandler(AccountRepository repository) {
            _repository = repository;
        }
        public async Task<GetAccountQueryResult> Handle(GetAccountQuery query) {

            var user = await _repository.FindAccount(query.Username);

            if (user is null) {
                return null;
            }

            return new GetAccountQueryResult {
                Id = user.Id,
                Username = user.Username,    
                CardLimit = user.CardLimit,
                CreatedOn = user.CreatedOn
            };
        }
    }
}
