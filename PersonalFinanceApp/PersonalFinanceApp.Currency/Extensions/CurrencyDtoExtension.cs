using PersonalFinanceApp.Currency.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Currency.Storage.Entities;
namespace PersonalFinanceApp.Currency.Extensions
{
    public static class CurrencyDtoExtension
    {

        public static Entities.Currency ToEntity(this CurrencyDto dto)
        {
            return new Entities.Currency
            {
                Code = dto.Code,
                Name = dto.Name,
                Symbol = dto.Symbol,
            };
        }
    }
}
