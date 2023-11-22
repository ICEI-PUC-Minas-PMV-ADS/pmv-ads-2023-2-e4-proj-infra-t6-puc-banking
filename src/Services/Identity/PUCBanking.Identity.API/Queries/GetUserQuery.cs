using PUCBanking.Shared.CQRS;
using System.ComponentModel.DataAnnotations;

namespace PUCBanking.Identity.API.Queries {
    public class GetUserQuery : IQuery {
        public string Email { get; set; } = null!;
    }
}
