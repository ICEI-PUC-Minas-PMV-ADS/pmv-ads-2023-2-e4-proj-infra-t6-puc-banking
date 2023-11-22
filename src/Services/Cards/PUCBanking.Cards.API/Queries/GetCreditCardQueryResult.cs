using PUCBanking.Shared.CQRS;

namespace PUCBanking.Cards.API.Queries {
    public class GetCreditCardQueryResult : IQueryResult {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string HolderName { get; set; } = null!;
        public long Number { get; set; }
        public int SecurityCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public double CreditLimit { get; set; }
        public double AvailableCreditLimit { get; set; }
        public int BestDayToPay { get; set; }
    }
}
