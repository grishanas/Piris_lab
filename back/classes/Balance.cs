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

        public string account_code { get; set; }

        [Required]
        [Column("balance_time")]
        public DateTime time { get; set; }

        [Required]
        public decimal count { get; set; }


        public Balance(Account acc)
        {
            this.account_id = acc.account_id;
            this.account_code = acc.account_code;
        }

        public Balance() { }
    }

    [Table("debit")]
    public class Debit
    {
        [Key]
        [Required]
        [StringLength(13)]
        public string account_source_id { get; set; }

        [Key] 
        public string account_source_code { get; set; }

        [Key]
        [Required]
        [StringLength(13)]
        public string account_destination_id { get; set; }
        [Key]
        public string account_destination_code { get; set; }
        [Key]
        [Required]
        [Column("debit_time")]
        public DateTime time { get; set; }

        [Required]
        public decimal count { get; set; }

        public Debit() {
            count = 0;
        }

        public Debit(Account source)
        {
            this.account_source_id = source.account_id;
            this.account_source_code = source.account_code;
            this.account_destination_id = source.account_id;
            this.account_destination_code = source.account_code;
        }
        public Debit(Account source,Account destionation)
        {
            this.account_source_id = source.account_id;
            this.account_source_code = source.account_code;
            this.account_destination_id = destionation.account_id;
            this.account_destination_code = destionation.account_code; 
        }
    }

    [Table("credit")]
    public class Credit
    {
        [Key]
        [Required]
        [StringLength(13)]
        public string account_source_id { get; set; }
        [Key]
        public string account_source_code { get; set; }
        [Key]
        [Required]
        [StringLength(13)]
        public string account_destination_id { get; set; }
        [Key]
        public string account_destination_code { get; set; }
        [Key]
        [Required]
        [Column("credit_time")]
        public DateTime time { get; set; }

        [Required]
        public decimal count { get; set; }

        public Credit()
        {
            count = 0;
        }

        public Credit(Account source, Account destionation)
        {
            this.account_source_id = source.account_id;
            this.account_source_code = source.account_code;
            this.account_destination_id = destionation.account_id;
            this.account_destination_code = destionation.account_code;
        }
        public Credit(Account source)
        {
            this.account_source_id = source.account_id;
            this.account_source_code = source.account_code;
            this.account_destination_id = source.account_id;
            this.account_destination_code = source.account_code;
        }
    }
}
