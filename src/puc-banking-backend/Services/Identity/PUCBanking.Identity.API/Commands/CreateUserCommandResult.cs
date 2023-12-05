using System.Text.Json.Serialization;

namespace PUCBanking.Identity.API.Commands {
    public class CreateUserCommandResult : ICommandResult {
        public Guid Id { get; set; }
        public string Message { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CommandResultStatus Status { get; set; }
        public enum CommandResultStatus {
            UserCreated,
            UserAlreadyExists,
            Error
        }
    }
}
