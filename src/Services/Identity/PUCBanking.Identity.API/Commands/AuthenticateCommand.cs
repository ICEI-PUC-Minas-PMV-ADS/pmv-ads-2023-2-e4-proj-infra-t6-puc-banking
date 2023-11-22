using PUCBanking.Shared.CQRS;
using System.ComponentModel.DataAnnotations;

namespace PUCBanking.Identity.API.Commands {
    public class AuthenticateCommand : ICommand {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
