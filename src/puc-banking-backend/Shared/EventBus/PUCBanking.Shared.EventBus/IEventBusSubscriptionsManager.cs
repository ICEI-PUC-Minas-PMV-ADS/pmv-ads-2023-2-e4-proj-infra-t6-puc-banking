namespace PUCBanking.Shared.EventBus {
    public interface IEventBusSubscriptionsManager {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoved;
        void AddSubscription<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void AddSubscription(Type eventType, Type eventHandlerType);

        void RemoveSubscription<T, TH>()
                where TH : IIntegrationEventHandler<T>
                where T : IIntegrationEvent;
        bool HasSubscriptionsForEvent<T>() where T : IIntegrationEvent;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IIntegrationEvent;
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        string GetEventKey<T>();
    }
}
