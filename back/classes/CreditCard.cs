using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab.classes;

namespace lab.classes
{

    public class CreateCreditCard
    {
        public string id { get; set; }
        public DateTime valid_time { get; set; }
        public string password { get; set; }
        
        public UserAccountID userAccountID { get; set; }
    }
    public class UserCreditCard
    {
        public string id { get; set; }
        public DateTime valid_time { get; set; }

    }

    [Table("creditcard")]
    public class CreditCard
    {
        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        public DateTime valid_time { get; set; }

        public string password { get; set; }

        public Account ParentAccount { get; set; }

        public bool is_blocked { get; set; }

        public byte count { get; set; }

        public CreditCard() { }

        public CreditCard(CreateCreditCard creditCard) { 
            id = creditCard.id;
            valid_time = creditCard.valid_time;
            password = creditCard.password;
            is_blocked = false;
            count = 0;
        }

    }
}
