namespace PUCBanking.Payments.API.Configuration {
    public class PaymentsOptions {
        public string ConnectionString { get; set; } = null!;
        public JwtBearerOptions JwtBearer { get; set; } = null!;
        public EventBus EventBus { get; set; } = null!;
    }
}
