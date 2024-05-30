using PersonalFinanceApp.Budget.Services;
using PersonalFinanceApp.Budget.Storage;

namespace PersonalFinanceApp.Budget.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBudgetServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<BudgetService>();
            serviceCollection.AddDbContext<BudgetDbContext, BudgetDbContext>();
            return serviceCollection;
        }
    }
}
