using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    public class UserAccount
    {

        [Required]
        public string account_id { get; set; }

        [Required]
        public string client_id { get; set; }

        public string bank_name { get; set; }

        public DateTime last_update { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
        public DateTime deadline { get; set; }
        public float interest_rate { get; set; }

        public int currency_type { get; set; }

        [Required]
        public string account_code { get; set; }

    }



    public class UserAccountID 
    {
        public string account_id { get; set; }

        public string account_code { get; set; }

    }

    public class AccountID: UserAccountID
    {
        public int account_type { get; set; }

        public AccountID() { }

        public AccountID(UserAccountID user)
        {
            this.account_code=user.account_code;
            this.account_id=user.account_id;
        }

        public AccountID(Account user)
        {
            this.account_type=user.account_type;
            this.account_code=user.account_code;
            this.account_id=user.account_id;
        }
    }


    [Table("Account")]
    public class Account
    {
        [Required]
        public string account_id { get; set; }

        public string bank_name { get; set; }

        public DateTime last_update { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public DateTime deadline { get; set; }
        public float interest_rate { get; set; }

        public int currency_type { get; set; }

        public string account_code { get; set; }

        public int account_type { get; set; }
        [Required]
        public  long client_id { get; set; }

        public Account()
        {

        }

        public Account Copy()
        {
            return (Account)this.MemberwiseClone();
        }
        
        public Account(UserAccount userAccount)
        {
            this.account_id = userAccount.account_id;
            this.bank_name = userAccount.bank_name;
            this.last_update = userAccount.last_update;
            this.start_date = userAccount.start_date;
            this.end_date = userAccount.end_date;
            this.deadline = userAccount.deadline;
            this.interest_rate = userAccount.interest_rate;
            this.currency_type = userAccount.currency_type;
            this.account_code = userAccount.account_code;
        }

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
