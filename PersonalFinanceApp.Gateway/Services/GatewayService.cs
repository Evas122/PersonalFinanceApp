using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using PersonalFinanceApp.Gateway.Resolvers;
using PersonalFinanceApp.Report.CrossCutting.Dtos;

using PersonalFinanceApp.Transaction.CrossCutting.Dtos;

namespace PersonalFinanceApp.Gateway.Services
{
    public class GatewayService
    {
        private readonly TransactionDataResolver _transactionUserResolver;
        private readonly BudgetDataResolver _budgetUserResolver;
        private readonly ReportDataResolver _reportUserResolver;

        public GatewayService(TransactionDataResolver transactionUserResolver, BudgetDataResolver budgetUserResolver, ReportDataResolver reportUserResolver)
        {
            _transactionUserResolver = transactionUserResolver;
            _budgetUserResolver = budgetUserResolver;
            _reportUserResolver = reportUserResolver;
        }

        public async Task<IEnumerable<TransactionDto>> GetUserTransactionsAsync(Guid userId)
        {
            return await _transactionUserResolver.GetUserTransactionsAsync(userId);
        }

        public async Task<IEnumerable<BudgetDto>> GetUserBudgetsAsync(Guid userId)
        {
            return await _budgetUserResolver.GetUserBudgetsAsync(userId);
        }

        public async Task<IEnumerable<ReportDto>> GetUserReportsAsync(Guid userId)
        {
            return await _reportUserResolver.GetUserReportsAsync(userId);
        }
    }
}
