using PersonalFinanceApp.Transaction.CrossCutting.Dtos;
using PersonalFinanceApp.User.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Transaction.Storage.Entities;
namespace PersonalFinanceApp.Transaction.Extensions

{
    public static class TransactionExtension
    {

        public static TransactionDto ToDto(this Entities.Transaction entity)
        {
            return new TransactionDto
            {
                Id = entity.Id,
                Description = entity.Description,
                Amount = entity.Amount,
                Date = entity.Date,
                Category = entity.Category,
                UserId = entity.UserId,
            };
        }
    }
}
