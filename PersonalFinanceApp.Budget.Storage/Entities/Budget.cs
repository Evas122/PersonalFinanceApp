using PersonalFinanceApp.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Budget.Storage.Entities
{
    [Table("Budgets", Schema = "Budget")]
    public class Budget : BaseEntity
    {
        public string? Name { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public List<BudgetCategory>? BudgetCategories { get; set; } = new List<BudgetCategory>();
        public PersonalFinanceApp.User.Storage.Entities.User? User { get; set; }
    }
}
