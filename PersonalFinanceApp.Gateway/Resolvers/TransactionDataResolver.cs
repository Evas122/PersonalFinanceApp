using PersonalFinanceApp.Transaction.CrossCutting.Dtos;

namespace PersonalFinanceApp.Gateway.Resolvers
{
    public class TransactionDataResolver
    {
        private readonly HttpClient _httpClient;

        public TransactionDataResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TransactionDto>> GetUserTransactionsAsync(Guid userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5052/transaction/user/{userId}");
                response.EnsureSuccessStatusCode();
                var transactions = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionDto>>();
                return transactions;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<TransactionDto>();
            }
        }
    }
}
