using PersonalFinanceApp.Gateway.Resolvers;
using PersonalFinanceApp.Gateway.Services;

namespace PersonalFinanceApp.Gateway.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGatewayServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GatewayService>();
            serviceCollection.AddHttpClient<TransactionDataResolver>();
            serviceCollection.AddHttpClient<BudgetDataResolver>();
            serviceCollection.AddHttpClient<ReportDataResolver>();
            return serviceCollection;
        }
    }
}
