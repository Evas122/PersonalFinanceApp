using PersonalFinanceApp.User.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Report.CrossCutting.Dtos
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string? Content { get; set; }
        public Guid UserId { get; set; }
        public UserDto? User { get; set; }
    }
}
