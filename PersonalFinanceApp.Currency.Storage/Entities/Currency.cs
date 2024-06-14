using PersonalFinanceApp.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Currency.Storage.Entities
{
    [Table("Currencies", Schema = "Currency")]
    public class Currency : BaseEntity
    {
        [Required]
        [MaxLength(3)]
        public string? Code { get; set; } 

        [Required]
        public string? Name { get; set; } 

        public string? Symbol { get; set; } 

        
    }
}
