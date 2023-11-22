using Microsoft.Extensions.DependencyInjection;

namespace PUCBanking.Shared.CQRS {
    public sealed class CommandHandler {

        private readonly IServiceProvider _serviceProvider;
        public CommandHandler(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task<TCommandResult> Handle<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommand
            where TCommandResult : ICommandResult {

            var commandHandler = _serviceProvider
                .GetService<ICommandHandler<TCommand, TCommandResult>>();

            if (commandHandler is null)
                throw new InvalidOperationException($"Nenhum manipulador de comando encontrado para '{typeof(ICommand)}'.");

            return await commandHandler.Handle(command);
        }
    }
}
