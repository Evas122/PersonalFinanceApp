using PersonalFinanceApp.Common.Storage.Entities;
using PersonalFinanceApp.User.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Report.Storage.Entities
{
    [Table("Reports", Schema = "Report")]
    public class Report : BaseEntity
    {
        public string? Title { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string? Content { get; set; }
        public Guid UserId { get; set; }
        public PersonalFinanceApp.User.Storage.Entities.User? User { get; set; }
    }
}
