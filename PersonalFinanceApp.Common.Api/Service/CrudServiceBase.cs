using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Common.CrossCutting.Dtos;
using PersonalFinanceApp.Common.Storage;
using PersonalFinanceApp.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Common.Api.Service
{
    public class CrudServiceBase<TDbContext, TEntity, TDto>
            where TDbContext : TechnicalTrainingContext
            where TEntity : BaseEntity
            where TDto : class
    {
        public readonly TDbContext _dbContext;
        protected virtual Task OnBeforeRecordCreatedAsync(TDbContext dbContext, TEntity entity) => Task.CompletedTask;
        protected virtual Task ONAfterRecordCreatedAsync(TDbContext dbContext, TEntity entity) => Task.CompletedTask;

        public CrudServiceBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CrudOperationResult<TDto>> Delete(Guid id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id!.Equals(id));

            if (entity == null)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound,
                };
            }

                _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();
            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };
        }

        public async Task<Guid> Create(TEntity entity)
        {
            await OnBeforeRecordCreatedAsync(_dbContext, entity);

            _dbContext 
                .Set<TEntity>()
                .Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<CrudOperationResult<TDto>> Update(TEntity newEntity)
        {
            var entityBeforeUpdate = await GetById(newEntity.Id);

            if(entityBeforeUpdate == null)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound,
                };
            }

            _dbContext.Entry(newEntity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };
        }

        protected async Task<TEntity> GetById(Guid id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(e => e.Id!.Equals(id))
                .SingleOrDefaultAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var entities = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }
    }
}
