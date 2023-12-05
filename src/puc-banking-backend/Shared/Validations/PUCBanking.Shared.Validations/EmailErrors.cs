using FluentResults;

namespace PUCBanking.Shared.Validations {
    public class EmailIsBlankError : Error {
        public EmailIsBlankError() : base("O Email não pode estar em branco.") { }
    }
    public class EmailIsInvalidError : Error {
        public EmailIsInvalidError(string email) : base($"O valor '{email}' não é um endereço de email válido.") { }
    }
}
