namespace PUCBanking.Cards.API.Models {
    public class CreditCard {
        private CreditCard() { }
        private CreditCard(Guid id,
            string username,
            string holderName,
            long number,
            int securityCode,
            DateTime createdOn,
            DateTime expiresOn,
            double creditLimit,
            double availableCreditLimit,
            int bestDayToPay) {
        
            this.Id = id;
            this.Username = username;
            this.HolderName = holderName;
            this.Number = number;
            this.SecurityCode = securityCode;
            this.CreatedOn = createdOn;
            this.ExpiresOn = expiresOn;
            this.CreditLimit = creditLimit;
            this.AvailableCreditLimit = availableCreditLimit;
            this.BestDayToPay = bestDayToPay;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string HolderName { get; private set; }
        public long Number { get; private set; }
        public int SecurityCode { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ExpiresOn { get; private set; }
        public double CreditLimit { get; private set; }
        public double AvailableCreditLimit { get; private set; }
        public int BestDayToPay { get; private set; }

        public static CreditCard GenerateCreditCard(string username, string holderName, double initialLimit) {

            try {

                var random = new Random();
                var cardNumber = Convert.ToInt64(GenerateMasterCardNumber());
                var cardSecurityCode = random.Next(100, 999);
                var cardCreatedDate = DateTime.UtcNow;
                var cardExpiresDate = DateTime.UtcNow.AddYears(5);
                var cardPayDay = random.Next(5, 20);

                return new CreditCard(Guid.NewGuid(),
                    username, holderName,
                    cardNumber, cardSecurityCode,
                    cardCreatedDate, cardExpiresDate,
                    initialLimit, initialLimit, cardPayDay);
            } catch (Exception ex) {
                return null;
            }
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
