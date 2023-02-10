using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("balance")]
    public class Balance
    {
        [Required]
        [StringLength(13)]
        public string account_id { get; set; }

        [Required]
        [Column("balance_time")]
        public DateTime time { get; set; }

        [Required]
        public decimal count { get; set; }
    }

    [Table("debit")]
    public class Debit
    {
        [Required]
        [StringLength(13)]
        public string account_id { get; set; }

        [Required]
        [Column("debit_time")]
        public DateTime time { get; set; }

        [Required]
        public decimal count { get; set; }
    }

    [Table("credit")]
    public class Credit
    {
        [Required]
        [StringLength(13)]
        public string account_id { get; set; }

        [Required]
        [Column("credit_time")]
        public DateTime time { get; set; }

        [Required]
        public decimal count { get; set; }
    }
}
