using PUCBanking.Shared.CQRS;

namespace PUCBanking.Identity.API.Queries {
    public class VerifyTokenQueryResult : IQueryResult {
        public bool IsValid { get; set; }
        public bool IsExpired { get; set; }
    }
}
