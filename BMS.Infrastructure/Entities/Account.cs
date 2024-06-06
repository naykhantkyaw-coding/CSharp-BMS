using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Infrastructure.Entities
{
    [Table("Tbl_Account")]
    internal class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountNo { get; set; }
        public string CustomerNo { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }

    }
}
