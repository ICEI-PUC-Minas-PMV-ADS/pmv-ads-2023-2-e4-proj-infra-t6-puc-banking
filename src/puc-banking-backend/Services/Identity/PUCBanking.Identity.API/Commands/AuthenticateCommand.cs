namespace PUCBanking.Identity.API.Commands {
    public class AuthenticateCommand : ICommand {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
