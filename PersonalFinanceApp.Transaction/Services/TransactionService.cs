using PersonalFinanceApp.Common.Api.Service;
using PersonalFinanceApp.Common.CrossCutting.Dtos;
using PersonalFinanceApp.Transaction.CrossCutting.Dtos;
using PersonalFinanceApp.Transaction.Extensions;
using PersonalFinanceApp.Transaction.Storage;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Transaction.Services
{
    public class TransactionService : CrudServiceBase<TransactionDbContext, Storage.Entities.Transaction, TransactionDto>
    {
        private TransactionDbContext _transactionDbContext;

        public TransactionService(TransactionDbContext transactionDbContext) : base(transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
            
        }

        public async Task<TransactionDto> GetById(Guid id)
        {
            var transaction = await base.GetById(id);

            return transaction.ToDto();
        }

        public async Task<IEnumerable<TransactionDto>> Get()
        {
            var transactions = await base.Get();
            return transactions.Select(e => e.ToDto());
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionByUserId(Guid userId)
        {
            var transactions = await _transactionDbContext.Set<Storage.Entities.Transaction>()
                .Where(e => e.UserId == userId)
                .ToListAsync();

            return transactions.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<TransactionDto>> Create(TransactionDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<TransactionDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<TransactionDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<TransactionDto>> Update(TransactionDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }

     
    }
}
