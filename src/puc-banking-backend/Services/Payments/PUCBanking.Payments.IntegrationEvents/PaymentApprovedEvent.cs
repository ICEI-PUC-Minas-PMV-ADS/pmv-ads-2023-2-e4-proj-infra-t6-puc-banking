using PUCBanking.Shared.EventBus;

namespace PUCBanking.Payments.IntegrationEvents {
    public class PaymentApprovedEvent : IIntegrationEvent {
        public Guid Id => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public Guid TransactionId { get; set; }
        public string UserEmail { get; set; }
        public double Value { get; set; }
    }
}
