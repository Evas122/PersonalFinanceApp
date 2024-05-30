using PersonalFinanceApp.Budget.Storage.Entities;
using PersonalFinanceApp.User.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Budget.CrossCutting.Dtos
{
    public class BudgetDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public List<BudgetCategoryDto>? BudgetCategories { get; set; } = new List<BudgetCategoryDto>();
        
    }
}
