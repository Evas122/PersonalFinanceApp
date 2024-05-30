using PersonalFinanceApp.Currency.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Currency.Storage.Entities;
namespace PersonalFinanceApp.Currency.Extensions
{
    public static class CurrencyExtension
    {

        public static CurrencyDto ToDto(this Entities.Currency entity)
        {
            return new CurrencyDto
            {
                Code = entity.Code,
                Name = entity.Name,
                Symbol = entity.Symbol,
            };
        }
    }
}
