using PUCBanking.Shared.CQRS;

namespace PUCBanking.Accounts.API.Queries {
    public class GetAccountQueryResult : IQueryResult {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public double CardLimit { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
