using Microsoft.Extensions.DependencyInjection;

namespace PUCBanking.Shared.CQRS {
    public static class QueryConfigurator {
        public static void UseQueries(this IServiceCollection services) {
            services.AddTransient<QueryHandler>();
        }
        public static IServiceCollection RegisterQueryHandler<TQuery, TQueryHandler, TQueryResult>(this IServiceCollection services)
            where TQuery : IQuery
            where TQueryResult : IQueryResult
            where TQueryHandler : class, IQueryHandler<TQuery, TQueryResult> {

            services.AddTransient<IQueryHandler<TQuery, TQueryResult>, TQueryHandler>();

            return services;
        }
    }
}
