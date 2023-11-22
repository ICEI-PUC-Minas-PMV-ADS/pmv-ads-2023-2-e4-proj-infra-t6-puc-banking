using PUCBanking.Shared.EventBus;

namespace PUCBanking.Accounts.IntegrationEvents {
    public class AccountCreatedEvent : IIntegrationEvent {
        public Guid Id => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public Guid AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public double CardLimit { get; set; }
    }
}
