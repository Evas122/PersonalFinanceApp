using PersonalFinanceApp.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Budget.Storage.Entities
{
    [Table("BudgetsCategories", Schema = "BudgetCategory")]
    public class BudgetCategory : BaseEntity
    {
        public string? Name { get; set; }
        public decimal AllocatedAmount { get; set; }
        public Guid BudgetId { get; set; }
        [ForeignKey("BudgetId")]
        public virtual Budget Budget { get; set; }

    }
}
