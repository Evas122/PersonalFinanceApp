using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Currency.CrossCutting.Dtos
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
       
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Symbol { get; set; }

    }
}
