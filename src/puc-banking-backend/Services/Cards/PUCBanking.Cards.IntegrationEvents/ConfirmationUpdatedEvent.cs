using PUCBanking.Shared.EventBus;

namespace PUCBanking.Cards.IntegrationEvents {
    public class ConfirmationUpdatedEvent : IIntegrationEvent {
        public Guid Id => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.Now;
        public Guid TransactionId { get; set; }
        public string UserEmail { get; set; }
        public ConfirmationStatus Status { get; set; }
        public enum ConfirmationStatus {
            CardNotFound,
            InvalidInformations,
            WithoutCreditLimit,
            Confirmed
        }
    }
}