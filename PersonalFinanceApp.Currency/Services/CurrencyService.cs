using PersonalFinanceApp.Common.Api.Service;
using PersonalFinanceApp.Common.CrossCutting.Dtos;
using PersonalFinanceApp.Currency.CrossCutting.Dtos;
using PersonalFinanceApp.Currency.Extensions;
using PersonalFinanceApp.Currency.Storage;

namespace PersonalFinanceApp.Currency.Services
{
    public class CurrencyService : CrudServiceBase<CurrencyDbContext, Storage.Entities.Currency, CurrencyDto>
    {
        private CurrencyDbContext _currencyDbContext;

        public CurrencyService(CurrencyDbContext currencyDbContext) : base(currencyDbContext)
        {
            _currencyDbContext = currencyDbContext;
        }

        public async Task<CurrencyDto> GetById(Guid id)
        {
            var currency = await base.GetById(id);

            return currency.ToDto();
        }

        public async Task<IEnumerable<CurrencyDto>> Get()
        {
            var currencies = await base.Get();
            return currencies.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<CurrencyDto>> Create(CurrencyDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<CurrencyDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CurrencyDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<CurrencyDto>> Update(CurrencyDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
