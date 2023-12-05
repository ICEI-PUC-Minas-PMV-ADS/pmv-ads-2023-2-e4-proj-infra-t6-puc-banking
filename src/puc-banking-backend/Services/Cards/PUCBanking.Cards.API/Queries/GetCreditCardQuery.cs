using PUCBanking.Shared.CQRS;

namespace PUCBanking.Cards.API.Queries {
    public class GetCreditCardQuery : IQuery {
        public string UserEmail { get; set; } = null!;
    }
}
