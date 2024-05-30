using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Budget.Storage.Entities;
namespace PersonalFinanceApp.Budget.Extensions
{
    public static class BudgetDtoExtension
    {

        public static Entities.Budget ToEntity(this BudgetDto dto)
        {
            return new Entities.Budget
            {
                Id = dto.Id,
                Name = dto.Name,
                TotalAmount = dto.TotalAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                UserId = dto.UserId,
                BudgetCategories = dto.BudgetCategories.Select(x =>
                    new Entities.BudgetCategory
                    {
                        Id = x.Id,
                        Name = x.Name,
                        AllocatedAmount = x.AllocatedAmount,
                        BudgetId = x.BudgetId,
                    }).ToList(),

            };

        }

    }
}
