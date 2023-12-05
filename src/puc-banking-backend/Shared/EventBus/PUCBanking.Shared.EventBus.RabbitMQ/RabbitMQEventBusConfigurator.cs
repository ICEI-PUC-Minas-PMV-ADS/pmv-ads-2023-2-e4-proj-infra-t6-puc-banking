using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace PUCBanking.Shared.EventBus.RabbitMQ {
    public static class RabbitMQEventBusConfigurator {
        public static void UseRabbitMQEventBus(this IServiceCollection services, Action<RabbitMQEventBusOptions> action) {

            var options = new RabbitMQEventBusOptions();

            action.Invoke(options);

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddSingleton<RabbitMQPersistentConnection>(sp => {
                var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory() {
                    HostName = options.ConnectionString,
                    DispatchConsumersAsync = true
                };

                var retryCount = options.RetryCount;

                return new RabbitMQPersistentConnection(factory, logger, retryCount);
            });

            services.AddSingleton<IEventBus, RabbitMQEventBus>(sp =>
            {
                var subscriptionClientName = options.SubscriptionClientName;
                var rabbitMQPersistentConnection = sp.GetRequiredService<RabbitMQPersistentConnection>();
                var logger = sp.GetRequiredService<ILogger<RabbitMQEventBus>>();
                var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                var retryCount = options.RetryCount;

                return new RabbitMQEventBus(rabbitMQPersistentConnection, logger, sp, eventBusSubscriptionsManager, options.BrokenName, subscriptionClientName, retryCount);
            });
        }
        public static void RegisterIntegrationEvent<TEvent, TEventHandler>(this IServiceCollection services)
            where TEvent : IIntegrationEvent
            where TEventHandler : class, IIntegrationEventHandler<TEvent> {

            services.AddScoped<IIntegrationEventHandler, TEventHandler>();
            services.AddScoped<TEventHandler>();
        }
    }
}
