using PUCBanking.Shared.CQRS;

namespace PUCBanking.Accounts.API.Queries {
    public class GetAccountQueryResult : IQueryResult {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public double CardLimit { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
