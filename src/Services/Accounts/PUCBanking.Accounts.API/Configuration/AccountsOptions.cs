namespace PUCBanking.Accounts.API.Configuration {
    public class AccountsOptions {
        public string ConnectionString { get; set; } = null!;
        public JwtBearerOptions JwtBearer { get; set; } = null!;
        public EventBus EventBus { get; set; } = null!;
    }
}
