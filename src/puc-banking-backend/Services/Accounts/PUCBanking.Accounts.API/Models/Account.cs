namespace PUCBanking.Accounts.API.Models {
    public class Account {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public double CardLimit { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
