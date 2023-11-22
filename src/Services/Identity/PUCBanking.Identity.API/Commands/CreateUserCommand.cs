using PUCBanking.Shared.CQRS;
using System.ComponentModel.DataAnnotations;

namespace PUCBanking.Identity.API.Commands {
    public class CreateUserCommand : ICommand {

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
