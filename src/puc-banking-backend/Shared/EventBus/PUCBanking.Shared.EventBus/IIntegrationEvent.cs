namespace PUCBanking.Shared.EventBus {
    public interface IIntegrationEvent {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }
    }
}
