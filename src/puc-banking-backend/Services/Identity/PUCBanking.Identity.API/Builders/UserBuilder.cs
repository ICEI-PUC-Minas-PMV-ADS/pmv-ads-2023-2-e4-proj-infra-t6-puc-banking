using FluentResults;

namespace PUCBanking.Identity.API.Builders {
    public class UserBuilder {

        private readonly PasswordService _passwordService;
        private Result<User> _result;
        private User _user;
        public UserBuilder(PasswordService passwordService) {
            _passwordService = passwordService;
        }
        public UserBuilder CreateNew() {
            _result = new Result<User>();
            _user = new User();
            _user.Id = Guid.NewGuid();

            return this;
        }
        public UserBuilder WithFirstName(string firstName) {

            if (_result is null || _user is null) {
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

            _user.FirstName = firstName;

            return this;
        }
        public UserBuilder WithLastName(string lastName) {

            if (_result is null || _user is null) {
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

            _user.LastName = lastName;

            return this;
        }
        public UserBuilder WithEmail(string email) {

            if (_result is null || _user is null) {
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

            _user.Email = email;

            return this;
        }
        public UserBuilder WithPassword(string password) {

            if (_result is null || _user is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (password is null) {
                _result.WithError(new ArgumentNullError(nameof(password)));
                return this;
            }

            PasswordValidations.Normalize(ref password);

            if (PasswordValidations.IsBlank(password)) {
                _result.WithError<PasswordIsBlankError>();
                return this;
            }

            if (PasswordValidations.IsInvalid(password)) {
                _result.WithError<PasswordIsInvalidError>();
                return this;
            }

            _user.Password = password;

            return this;
        }
        public UserBuilder EncryptPassword() {

            if (_result is null || _user is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (_user.Password is null) {
                _result.WithError("A Senha do usuário não foi definida.");
                return this; ;
            }

            _user.Password = _passwordService
                .EncryptPassword(_user.Password);

            return this;
        }
        public Result<User> Build() {

            if (_result is null || _user is null) {
                throw new InvalidOperationException("Call 'CreateNew' method for create a new user.");
            }

            if (_result.IsSuccess) {
                _result.WithValue(_user);
            }

            return _result;
        }
    }
}
