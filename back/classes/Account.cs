using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [Required]
        public string account_id { get; set; }

        [Required]
        public int account_type { get; set; }
        [Required]
        public int contract_id { get; set; }

        [Required]
        public string account_code { get; set; }
    }

    [Table("Account_code")]
    public class Account_code
    {
        [Key]
        [Required]
        public string account_code { get; set; }

        public string description { get; set; }
    }

    [Table("Account_type")]
    public class Account_type
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
    }
}
