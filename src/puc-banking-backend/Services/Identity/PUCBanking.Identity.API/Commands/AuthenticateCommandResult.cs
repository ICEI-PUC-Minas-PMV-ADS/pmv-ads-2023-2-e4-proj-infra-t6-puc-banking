using System.Text.Json.Serialization;

namespace PUCBanking.Identity.API.Commands {
    public class AuthenticateCommandResult : ICommandResult {
        public Guid Id { get; set; }
        public string Token { get; set; } = null!;
        public string Message { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AuthenticateCommandStatus Status { get; set; }
    }
    public enum AuthenticateCommandStatus {
        UserAuthenticated,
        UserNotFound,
        Error
    }
}
