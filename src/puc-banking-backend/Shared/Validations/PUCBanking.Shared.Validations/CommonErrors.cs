using FluentResults;

namespace PUCBanking.Shared.Validations {
    public class ArgumentNullError : Error {
        public ArgumentNullError(string name) : base($"O Argumento '{name}' não pode ser nulo.") { }
    }
}
