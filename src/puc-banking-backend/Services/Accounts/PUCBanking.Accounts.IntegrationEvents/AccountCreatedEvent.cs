using PUCBanking.Shared.EventBus;

namespace PUCBanking.Accounts.IntegrationEvents {
    public class AccountCreatedEvent : IIntegrationEvent {
        public Guid Id => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public Guid AccountId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public double CardLimit { get; set; }
    }
}
