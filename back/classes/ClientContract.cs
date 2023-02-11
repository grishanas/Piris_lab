using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("contract")]
    public class ClientContract
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string contract_id { get; set; }

        [Required]
        public int deposit_type { get; set; }

        [Required]
        public string client_id { get; set; }

        [Required]
        public int currency_type { get; set; }
        [Required]
        public DateTime start_date { get; set; }
        [Required]
        public DateTime end_time { get; set; }

        [Required]
        public DateTime contrcact_deadline {get;set;}

        [Required]
        public decimal contract_amount { get; set; }

        [Required]
        public float interest_rate { get; set; } 
    }
    [Table("deposit_type")]
    public class contract_type
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
    }

    [Table("type_of_currency")]
    public class type_of_currency
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set;}
    }
}
