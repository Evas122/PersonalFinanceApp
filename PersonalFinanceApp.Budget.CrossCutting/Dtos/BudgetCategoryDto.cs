using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Budget.CrossCutting.Dtos
{
    public class BudgetCategoryDto
    {
        public Guid Id  { get; set; }
        public string? Name { get; set; }
        public decimal AllocatedAmount { get; set; }
        public Guid BudgetId { get; set; }
    }
}
