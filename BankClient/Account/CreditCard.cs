using System;

namespace BankClient
{
    public class CreditCard
    {
        public string id { get; set; }
        public DateTime valid_time { get; set; }
        public string password { get; set; }
        public UserAccountID UserAccountID { get; set; }
    }
}
