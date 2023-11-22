namespace PUCBanking.Shared.EventBus {
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IIntegrationEvent {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler {
    }
}
