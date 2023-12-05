namespace PUCBanking.Identity.API.Queries {
    public class GetUserQuery : IQuery {
        public string Email { get; set; } = null!;
    }
}
