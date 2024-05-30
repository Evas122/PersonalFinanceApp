using PersonalFinanceApp.Budget.CrossCutting.Dtos;
using PersonalFinanceApp.Budget.Extensions;
using PersonalFinanceApp.Budget.Storage;
using PersonalFinanceApp.Common.Api.Service;
using PersonalFinanceApp.Common.CrossCutting.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace PersonalFinanceApp.Budget.Services
{
    public class BudgetService : CrudServiceBase<BudgetDbContext, Storage.Entities.Budget, BudgetDto>
    {
        private BudgetDbContext _budgetDbContext;

        public BudgetService(BudgetDbContext budgetDbContext) : base(budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }
        
        public async Task<BudgetDto> GetById(Guid id)
        {
            var budget = await base.GetById(id);

            return budget.ToDto();
        }

        public async Task<IEnumerable<BudgetDto>> Get()
        {
            var budgets = await base.Get();
            return budgets.Select(e => e.ToDto());
        }

        public async Task<IEnumerable<BudgetDto>> GetBudgetByUserId(Guid userId)
        {
            var budgets = await _budgetDbContext.Set<Storage.Entities.Budget>()
                .Where(e => e.UserId == userId)
                .ToListAsync();

            return budgets.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<BudgetDto>> Create(BudgetDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<BudgetDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<BudgetDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<BudgetDto>> Update(BudgetDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
