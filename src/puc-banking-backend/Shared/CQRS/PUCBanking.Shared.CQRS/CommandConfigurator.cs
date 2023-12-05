using Microsoft.Extensions.DependencyInjection;

namespace PUCBanking.Shared.CQRS {
    public static class CommandConfigurator {
        public static void UseCommands(this IServiceCollection services) {
            services.AddTransient<CommandHandler>();
        }
        public static IServiceCollection RegisterCommandHandler<TCommand, TCommandHandler, TCommandResult>(this IServiceCollection services)
            where TCommand : ICommand
            where TCommandResult : ICommandResult
            where TCommandHandler : class, ICommandHandler<TCommand, TCommandResult> {

            services.AddTransient<ICommandHandler<TCommand, TCommandResult>, TCommandHandler>();

            return services;
        }
    }
}
