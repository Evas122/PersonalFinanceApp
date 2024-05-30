using PersonalFinanceApp.Report.Services;
using PersonalFinanceApp.Report.Storage;

namespace PersonalFinanceApp.Report.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReportServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ReportService>();
            serviceCollection.AddDbContext<ReportDbContext, ReportDbContext>();
            return serviceCollection;
        }
    }
}
