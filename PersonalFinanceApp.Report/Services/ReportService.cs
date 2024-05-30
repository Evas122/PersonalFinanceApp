using PersonalFinanceApp.Common.Api.Service;
using PersonalFinanceApp.Common.CrossCutting.Dtos;
using PersonalFinanceApp.Report.CrossCutting.Dtos;
using PersonalFinanceApp.Report.Extensions;
using PersonalFinanceApp.Report.Storage;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Report.Services
{
    public class ReportService : CrudServiceBase<ReportDbContext, Storage.Entities.Report, ReportDto>
    {
        private ReportDbContext _reportDbContext;

        public ReportService(ReportDbContext reportDbContext) : base(reportDbContext)
        {
            _reportDbContext = reportDbContext;
        }

        public async Task<ReportDto> GetById(Guid id)
        {
            var report = await base.GetById(id);

            return report.ToDto();
        }

        public async Task<IEnumerable<ReportDto>> Get()
        {
            var reports = await base.Get();
            return reports.Select(e => e.ToDto());
        }

        public async Task<IEnumerable<ReportDto>> GetReportByUserId(Guid userId)
        {
            var reports = await _reportDbContext.Set<Storage.Entities.Report>()
                .Where(e => e.UserId == userId)
                .ToListAsync();

            return reports.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<ReportDto>> Create(ReportDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<ReportDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<ReportDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<ReportDto>> Update(ReportDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}
