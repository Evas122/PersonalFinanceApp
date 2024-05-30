using PersonalFinanceApp.Budget.CrossCutting.Dtos;

namespace PersonalFinanceApp.Budget.Extensions
{
    public static class BudgetExtension
    {

        public static BudgetDto ToDto(this PersonalFinanceApp.Budget.Storage.Entities.Budget entity)
        {
            return new BudgetDto
            {
                Id = entity.Id,
                Name = entity.Name,
                TotalAmount = entity.TotalAmount,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                UserId = entity.UserId,
                BudgetCategories = entity.BudgetCategories.Select(x =>
                    new BudgetCategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        AllocatedAmount = x.AllocatedAmount,
                        BudgetId = x.BudgetId,
                    }).ToList()

            };
        }
    }
}

