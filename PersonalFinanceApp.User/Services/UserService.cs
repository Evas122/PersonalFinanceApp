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
