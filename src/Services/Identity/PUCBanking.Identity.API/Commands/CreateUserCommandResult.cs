using PUCBanking.Shared.CQRS;
using System.Text.Json.Serialization;

namespace PUCBanking.Identity.API.Commands {
    public class CreateUserCommandResult : ICommandResult {
        public Guid Id { get; set; }
        public string Message { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CreateUserCommandStatus Status { get; set; }
    }
    public enum CreateUserCommandStatus {
        UserCreated,
        UserAlreadyExists,
        Error
    }
}
