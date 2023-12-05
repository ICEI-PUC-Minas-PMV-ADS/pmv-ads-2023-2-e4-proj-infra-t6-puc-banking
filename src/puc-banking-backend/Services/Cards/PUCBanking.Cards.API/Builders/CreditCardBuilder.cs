using FluentResults;
using PUCBanking.Shared.Validations;

namespace PUCBanking.Cards.API.Builders {
    public class CreditCardBuilder {
        private Result<CreditCard> _result;
        private CreditCard _creditCard;
        public CreditCardBuilder CreateNew() {
            _result = new Result<CreditCard>();

            var random = new Random();

            _creditCard = new CreditCard();
            _creditCard.Id = Guid.NewGuid();
            _creditCard.Number = Convert.ToInt64(GenerateMasterCardNumber());
            _creditCard.CVV = random.Next(100, 999);
            _creditCard.CreatedOn = DateTime.UtcNow;
            _creditCard.ExpiresOn = DateTime.UtcNow.AddYears(5);

            return this;
        }
        public CreditCardBuilder WithHolderName(string holderName) {

            if (_result is null || _creditCard is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (holderName is null) {
                _result.WithError(new ArgumentNullError(nameof(holderName)));
                return this;
            }

            PropertyValidations.Normalize(ref holderName);

            if (PropertyValidations.IsBlank(holderName)) {
                _result.WithError(new PropertyIsBlankError(nameof(holderName)));
                return this;
            }

            if (!PropertyValidations.HasMinLength(holderName, 3)) {
                _result.WithError(new PropertyLengthTooShortError(nameof(holderName), 3));
                return this;
            }

            if (!PropertyValidations.HasMaxLength(holderName, 100)) {
                _result.WithError(new PropertyLengthTooLongError(nameof(holderName), 100));
                return this;
            }

            _creditCard.HolderName = holderName;

            return this;
        }
        public CreditCardBuilder WithUserEmail(string userEmail) {

            if (_result is null || _creditCard is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (userEmail is null) {
                _result.WithError(new ArgumentNullError(nameof(userEmail)));
                return this;
            }

            EmailValidations.Normalize(ref userEmail);

            if (EmailValidations.IsBlank(userEmail)) {
                _result.WithError<EmailIsBlankError>();
                return this;
            }

            if (EmailValidations.IsInvalidEmail(userEmail)) {
                _result.WithError(new EmailIsInvalidError(userEmail));
                return this;
            }

            _creditCard.UserEmail = userEmail;

            return this;
        }
        public CreditCardBuilder WithInitialCardLimit(double cardLimit) {

            if (_result is null || _creditCard is null) {
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

            _creditCard.CreditLimit = cardLimit;
            _creditCard.AvailableCreditLimit = cardLimit;

            return this;
        }
        public Result<CreditCard> Build() {

            if (_result is null || _creditCard is null) {
                throw new InvalidOperationException("É necessário chamar o método 'CreateNew' primeiro.");
            }

            if (_result.IsSuccess) {
                _result.WithValue(_creditCard);
            }

            return _result;
        }

        private const string MASTERCARD_PREFIX = "53";
        private const int MASTERCARD_LENTGH = 16;
        private static string GenerateMasterCardNumber() {

            var random = new Random();
            string ccnumber = MASTERCARD_PREFIX;

            while (ccnumber.Length < (MASTERCARD_LENTGH - 1)) {
                double rnd = (random.NextDouble() * 1.0f - 0f);

                ccnumber += Math.Floor(rnd * 10);
            }

            var reversedCCnumberstring = ccnumber.ToCharArray().Reverse();
            var reversedCCnumberList = reversedCCnumberstring.Select(c => Convert.ToInt32(c.ToString()));

            int sum = 0;
            int pos = 0;
            int[] reversedCCnumber = reversedCCnumberList.ToArray();

            while (pos < MASTERCARD_LENTGH - 1) {
                int odd = reversedCCnumber[pos] * 2;

                if (odd > 9)
                    odd -= 9;

                sum += odd;

                if (pos != (MASTERCARD_LENTGH - 2))
                    sum += reversedCCnumber[pos + 1];

                pos += 2;
            }

            int checkdigit =
                Convert.ToInt32((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10;

            ccnumber += checkdigit;

            return ccnumber;
        }
    }
}
