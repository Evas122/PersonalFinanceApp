using PersonalFinanceApp.Report.CrossCutting.Dtos;

namespace PersonalFinanceApp.Gateway.Resolvers
{
    public class ReportDataResolver
    {
        private readonly HttpClient _httpClient;

        public ReportDataResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ReportDto>> GetUserReportsAsync(Guid userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5034/report/user/{userId}");
                response.EnsureSuccessStatusCode();
                var reports = await response.Content.ReadFromJsonAsync<IEnumerable<ReportDto>>();
                return reports;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ReportDto>();
            }
        }
    }
}
