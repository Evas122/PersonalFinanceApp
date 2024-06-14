using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using PersonalFinanceApp.Gateway.Resolvers;
using PersonalFinanceApp.Gateway.Services;
using PersonalFinanceApp.Report.CrossCutting.Dtos;
using PersonalFinanceApp.Transaction.CrossCutting.Dtos;

namespace PersonalFinanceApp.Gateway.Controllers
{
    [Route("gateway")]
    public class GatewayController : ControllerBase
    {
        private readonly GatewayService _gatewayService;

        public GatewayController(GatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet("{userId}/transactions")]
        public async Task<IEnumerable<TransactionDto>> GetUserTransactions(Guid userId)
        {
            return await _gatewayService.GetUserTransactionsAsync(userId);
        }

        [HttpGet("{userId}/budgets")]
        public async Task<IEnumerable<BudgetDto>> GetUserBudgets(Guid userId)
        {
            return await _gatewayService.GetUserBudgetsAsync(userId);
        }

        [HttpGet("{userId}/reports")]
        public async Task<IEnumerable<ReportDto>> GetUserReports(Guid userId)
        {
            return await _gatewayService.GetUserReportsAsync(userId);
        }
    }
}
