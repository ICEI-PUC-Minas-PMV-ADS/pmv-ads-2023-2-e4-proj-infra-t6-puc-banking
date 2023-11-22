using PUCBanking.Shared.CQRS;
using System.ComponentModel.DataAnnotations;

namespace PUCBanking.Cards.API.Queries {
    public class GetCreditCardQuery : IQuery {

        [Required]
        public string Username { get; set; } = null!;
    }
}
