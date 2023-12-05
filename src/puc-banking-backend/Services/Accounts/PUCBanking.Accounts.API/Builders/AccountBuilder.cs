using FluentResults;

namespace PUCBanking.Accounts.API.Builders {
    public class AccountBuilder {
        private Result<Account> _result;
        private Account _account;
        public AccountBuilder CreateNew() {
            _result = new Result<Account>();
            _account = new Account();

            _account.Id = Guid.NewGuid();
            _account.CreatedOn = DateTime.Now;

            return this;
        }
        public AccountBuilder WithFirstName(string firstName) {

            if (_result is null || _account is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (firstName is null) {
                _result.WithError(new ArgumentNullError(nameof(firstName)));
                return this;
            }

            PropertyValidations.Normalize(ref firstName);

            if (PropertyValidations.IsBlank(firstName)) {
                _result.WithError(new PropertyIsBlankError(nameof(firstName)));
                return this;
            }

            if (!PropertyValidations.HasMinLength(firstName, 3)) {
                _result.WithError(new PropertyLengthTooShortError(nameof(firstName), 3));
                return this;
            }

            if (!PropertyValidations.HasMaxLength(firstName, 50)) {
                _result.WithError(new PropertyLengthTooLongError(nameof(firstName), 50));
                return this;
            }

            _account.FirstName = firstName;

            return this;
        }
        public AccountBuilder WithLastName(string lastName) {

            if (_result is null || _account is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (lastName is null) {
                _result.WithError(new ArgumentNullError(nameof(lastName)));
                return this;
            }

            PropertyValidations.Normalize(ref lastName);

            if (PropertyValidations.IsBlank(lastName)) {
                _result.WithError(new PropertyIsBlankError(nameof(lastName)));
                return this;
            }

            if (!PropertyValidations.HasMinLength(lastName, 3)) {
                _result.WithError(new PropertyLengthTooShortError(nameof(lastName), 3));
                return this;
            }

            if (!PropertyValidations.HasMaxLength(lastName, 50)) {
                _result.WithError(new PropertyLengthTooLongError(nameof(lastName), 50));
                return this;
            }

            _account.LastName = lastName;

            return this;
        }
        public AccountBuilder WithEmail(string email) {

            if (_result is null || _account is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (email is null) {
                _result.WithError(new ArgumentNullError(nameof(email)));
                return this;
            }

            EmailValidations.Normalize(ref email);

            if (EmailValidations.IsBlank(email)) {
                _result.WithError<EmailIsBlankError>();
                return this;
            }

            if (EmailValidations.IsInvalidEmail(email)) {
                _result.WithError(new EmailIsInvalidError(email));
                return this;
            }

            _account.Email = email;

            return this;
        }
        public AccountBuilder WithInitialCardLimit(double cardLimit) {

            if (_result is null || _account is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (PropertyValidations.IsLower(cardLimit, 0)) {
                _result.WithError(new PropertyValueTooSmallError(nameof(cardLimit), 10));
                return this;
            }

            if (PropertyValidations.IsGreater(cardLimit, 10000)) {
                _result.WithError(new PropertyValueTooLongError(nameof(cardLimit), 10000));
                return this;
            }

            _account.CardLimit = cardLimit;

            return this;
        }
        public Result<Account> Build() {

            if (_result is null || _account is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (_result.IsSuccess) {
                _result.WithValue(_account);
            }

            return _result;
        }
    }
}
