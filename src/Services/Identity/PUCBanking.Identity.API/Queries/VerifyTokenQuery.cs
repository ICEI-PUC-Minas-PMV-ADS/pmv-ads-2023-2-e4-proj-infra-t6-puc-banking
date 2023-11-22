using PUCBanking.Shared.CQRS;
using System.ComponentModel.DataAnnotations;

namespace PUCBanking.Identity.API.Queries {
    public class VerifyTokenQuery : IQuery {

        [Required]
        public string Token { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;
    }
}
