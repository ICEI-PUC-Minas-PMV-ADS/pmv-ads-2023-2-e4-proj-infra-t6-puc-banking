using PUCBanking.Shared.EventBus;

namespace PUCBanking.Payments.IntegrationEvents {
    public class WaitingConfirmationEvent : IIntegrationEvent {
        public Guid Id => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public Guid TransactionId { get; set; }
        public double Value { get; set; }
        public string Name { get; set; } = null!;
        public long CardNumber { get; set; }
        public string CardHolderName { get; set; } = null!;
        public int CardCVV { get; set; }
        public DateTime CardExpires { get; set; }
    }
}
