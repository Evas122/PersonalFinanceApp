using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceApp.Transaction.Storage.Enums;
using PersonalFinanceApp.Common.Storage.Entities;
using PersonalFinanceApp.User.Storage.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace PersonalFinanceApp.Transaction.Storage.Entities
{
    [Table("Transactions", Schema = "Transaction")]
    public class Transaction : BaseEntity
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionCategory Category { get; set; }
        public Guid UserId { get; set; }
        public virtual PersonalFinanceApp.User.Storage.Entities.User? User { get; set; }
    }
}
