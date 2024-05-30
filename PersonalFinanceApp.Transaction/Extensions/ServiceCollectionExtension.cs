using PersonalFinanceApp.Transaction.Services;
using PersonalFinanceApp.Transaction.Storage;

namespace PersonalFinanceApp.Transaction.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<TransactionService>();
            serviceCollection.AddDbContext<TransactionDbContext, TransactionDbContext>();
            return serviceCollection;
        }
    }
}
