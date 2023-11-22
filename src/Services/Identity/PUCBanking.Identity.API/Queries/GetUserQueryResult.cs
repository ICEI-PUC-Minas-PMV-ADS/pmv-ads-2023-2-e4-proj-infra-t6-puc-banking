using PUCBanking.Shared.CQRS;
using System.Text.Json.Serialization;

namespace PUCBanking.Identity.API.Queries {
    public class GetUserQueryResult : IQueryResult {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserStatus Status { get; set; }
    }
}
