using PersonalFinanceApp.Report.CrossCutting.Dtos;
using Entities = PersonalFinanceApp.Report.Storage.Entities;
namespace PersonalFinanceApp.Report.Extensions
{
    public static class ReportExtension
    {

        public static ReportDto ToDto(this Entities.Report entity)
        {
            return new ReportDto
            {
                Id = entity.Id,
                Title = entity.Title,
                GeneratedAt = entity.GeneratedAt,
                Content = entity.Content,
                UserId = entity.UserId,
            };
        }
    }
}
