namespace PUCBanking.Accounts.API.Models {
    public class Account {

        private const double INITIAL_CARD_LIMIT = 1000;
        private Account() { }
        private Account(Guid id,
            string username,
            double cardLimit,
            DateTime createdOn) {
        
            this.Id = id;
            this.Username = username;
            this.CardLimit = cardLimit;
            this.CreatedOn = createdOn;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public double CardLimit { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public static Account CreateAccountForNewUser(Guid id, string username) {
            return new Account(id, username, INITIAL_CARD_LIMIT, DateTime.UtcNow);
        }
    }
}
