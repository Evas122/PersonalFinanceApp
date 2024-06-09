using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using PersonalFinanceApp.Common.Api.Service;
using PersonalFinanceApp.Common.CrossCutting.Dtos;
using PersonalFinanceApp.Report.CrossCutting.Dtos;
using PersonalFinanceApp.Transaction.CrossCutting.Dtos;
using PersonalFinanceApp.User.CrossCutting.Dtos;
using PersonalFinanceApp.User.Extensions;
using PersonalFinanceApp.User.Storage;

namespace PersonalFinanceApp.User.Services
{
    public class UserService : CrudServiceBase<UserDbContext, Storage.Entities.User, UserDto>
    {
        private readonly UserDbContext _userDbContext;
        private readonly HttpClient _httpClient;

        public UserService(UserDbContext userDbContext, HttpClient httpClient) : base(userDbContext)
        {
            _userDbContext = userDbContext;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TransactionDto>> GetUserTransactionASync(Guid userId)
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

        public async Task<IEnumerable<BudgetDto>> GetUserBudgetASync(Guid userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5055/budget/user/{userId}");

                response.EnsureSuccessStatusCode();

                var budgets = await response.Content.ReadFromJsonAsync<IEnumerable<BudgetDto>>();
                return budgets;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<BudgetDto>();
            }
            
        }

        public async Task<IEnumerable<ReportDto>> GetUserReportASync(Guid userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:5034/report/user/{userId}");

                var reports = await response.Content.ReadFromJsonAsync<IEnumerable<ReportDto>>();
                return reports;
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<ReportDto>();
            }
               
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await base.GetById(id);

            return user.ToDto();
        }

        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await base.Get();
            return users.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<UserDto>> Create(UserDto dto)
        {
            var entity = dto.ToEntity();
            
            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<UserDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<UserDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<UserDto>> Update(UserDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
