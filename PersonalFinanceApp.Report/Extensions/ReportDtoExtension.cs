using PersonalFinanceApp.Report.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Report.Storage.Entities;
namespace PersonalFinanceApp.Report.Extensions
{
    public static class ReportDtoExtension
    {

        public static Entities.Report ToEntity(this ReportDto dto)
        {
            return new Entities.Report
            {
                Id = dto.Id,
                Title = dto.Title,
                GeneratedAt = dto.GeneratedAt,
                Content = dto.Content,
                UserId = dto.UserId,
            };
        }
    }
}
