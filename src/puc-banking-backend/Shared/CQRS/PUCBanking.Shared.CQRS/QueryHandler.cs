using Microsoft.Extensions.DependencyInjection;

namespace PUCBanking.Shared.CQRS {
    public sealed class QueryHandler {

        private IServiceProvider _serviceProvider;
        public QueryHandler(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task<TQueryResult> Handle<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery
            where TQueryResult : IQueryResult {

            var queryHandler = _serviceProvider
                .GetService<IQueryHandler<TQuery, TQueryResult>>();

            if (queryHandler is null)
                throw new NotImplementedException($"Nenhum manipulador de consulta encontrado para '{typeof(IQuery)}'.");

            return await queryHandler.Handle(query);
        }
    }
}
