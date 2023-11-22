namespace PUCBanking.Identity.API.Configuration {
    public class JwtBearerOptions {
        public string Audience { get; set; } = null!;
        public bool ValidateAudience { get; set; }
        public string Issuer { get; set; } = null!;
        public bool ValidateIssuer { get; set; }
        public string SecretKey { get; set; } = null!;
        public short Expires { get; set; }
    }
}
