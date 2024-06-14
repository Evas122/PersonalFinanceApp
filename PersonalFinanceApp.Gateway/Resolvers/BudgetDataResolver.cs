using PersonalFinanceApp.Budget.CrossCutting.Dtos;

namespace PersonalFinanceApp.Gateway.Resolvers
{
    public class BudgetDataResolver
    {
        private readonly HttpClient _httpClient;

        public BudgetDataResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BudgetDto>> GetUserBudgetsAsync(Guid userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5794/budget/user/{userId}");
                response.EnsureSuccessStatusCode();
                var budgets = await response.Content.ReadFromJsonAsync<IEnumerable<BudgetDto>>();
                return budgets;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<BudgetDto>();
            }
        }
    }
}
