using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PUCBanking.Shared.EventBus {
    public static class EventBusConfigurator {
        public static void UseEventBus(this IApplicationBuilder app) {

            using (var scope = app.ApplicationServices.CreateScope()) {

                var eventBus = scope.ServiceProvider.GetService<IEventBus>();
                var eventHandlers = scope.ServiceProvider.GetServices<IIntegrationEventHandler>();

                foreach (var eventHandler in eventHandlers) {

                    var eventHandlerType = eventHandler.GetType();
                    var eventHandlerInterfaceType = eventHandlerType.GetInterfaces()
                        .FirstOrDefault(x => x.IsGenericType && x
                        .GetInterfaces()
                        .Contains(typeof(IIntegrationEventHandler)));

                    if (eventHandlerInterfaceType is null)
                        continue;

                    var eventType = eventHandlerInterfaceType.GenericTypeArguments[0];

                    eventBus.Subscribe(eventType, eventHandler);
                }
            }
        }
    }
}
