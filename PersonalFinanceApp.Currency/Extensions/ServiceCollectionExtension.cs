using PersonalFinanceApp.Currency.Services;
using PersonalFinanceApp.Currency.Storage;

namespace PersonalFinanceApp.Currency.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCurrencyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CurrencyService>();
            serviceCollection.AddDbContext<CurrencyDbContext, CurrencyDbContext>();
            return serviceCollection;
        }
    }
}
