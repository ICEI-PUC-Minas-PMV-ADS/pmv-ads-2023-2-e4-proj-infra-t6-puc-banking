using PUCBanking.Shared.CQRS;

namespace PUCBanking.Accounts.API.Queries {
    public class GetAccountQuery : IQuery {
        public string UserEmail { get; set; }
    }
}
