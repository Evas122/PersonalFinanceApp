using PersonalFinanceApp.Transaction.Storage.Enums;
using PersonalFinanceApp.User.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Transaction.CrossCutting.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionCategory Category { get; set; }
        public Guid UserId { get; set; }
        public UserDto? User { get; set; }
    }
}
