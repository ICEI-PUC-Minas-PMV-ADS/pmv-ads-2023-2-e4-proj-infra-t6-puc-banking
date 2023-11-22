namespace PUCBanking.Identity.API.Configuration {
    public class IdentityOptions {
        public string ConnectionString { get; set; } = null!;
        public JwtBearerOptions JwtBearer { get; set; } = null!;
        public EventBus EventBus { get; set; } = null!;
    }
}
