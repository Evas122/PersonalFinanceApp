using PersonalFinanceApp.User.Services;
using PersonalFinanceApp.User.Storage;

namespace PersonalFinanceApp.User.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserService>();
            serviceCollection.AddDbContext<UserDbContext, UserDbContext>();
            return serviceCollection;
        }
    }
}
