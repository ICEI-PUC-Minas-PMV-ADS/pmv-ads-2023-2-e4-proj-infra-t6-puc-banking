namespace PUCBanking.Accounts.API.Configuration {
    public class CardsOptions {
        public string ConnectionString { get; set; } = null!;
        public JwtBearerOptions JwtBearer { get; set; } = null!;
        public EventBus EventBus { get; set; } = null!;
    }
}
