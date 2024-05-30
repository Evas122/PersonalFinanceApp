using PersonalFinanceApp.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;

namespace PersonalFinanceApp.User.Storage.Entities
{
    [Table("Users", Schema = "User")]
    public class User : BaseEntity
    {
        [MaxLength(128)]
        public string? Username { get; set; }
        [MaxLength(128)]
        public string? Email { get; set; }
        [MaxLength(128)]
        public string? Password { get; set; }

    }
}
