namespace PUCBanking.Shared.EventBus {
    public interface IEventBus {
        void Publish(IIntegrationEvent @event);
        void Subscribe<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T>;
        void Subscribe(Type eventType, IIntegrationEventHandler eventHandler);
    }
}
