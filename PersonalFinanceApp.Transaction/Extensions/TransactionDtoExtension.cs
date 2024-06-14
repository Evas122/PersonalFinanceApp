using PersonalFinanceApp.Transaction.CrossCutting.Dtos;
using PersonalFinanceApp.User.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Transaction.Storage.Entities;
namespace PersonalFinanceApp.Transaction.Extensions
{
    public static class TransactionDtoExtension
    {

        public static Entities.Transaction ToEntity(this TransactionDto dto)
        {
            return new Entities.Transaction
            {
                Id = dto.Id,
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date,
                Category = dto.Category,
                UserId = dto.UserId
            };
        }
    }
}
