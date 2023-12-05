using PUCBanking.Shared.EventBus;

namespace PUCBanking.Identity.UnitTests.Mocks {
    internal class FakeEventBus : IEventBus {
        public void Publish(IIntegrationEvent @event) {
            Console.WriteLine($"Publicando evento: {@event.GetType()}");
        }

        public void Subscribe<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T> {
            throw new NotImplementedException();
        }

        public void Subscribe(Type eventType, IIntegrationEventHandler eventHandler) {       
        }
    }
}
