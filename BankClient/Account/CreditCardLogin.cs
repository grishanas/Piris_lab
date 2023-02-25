using System;

namespace BankClient
{
    public class CreditCardLogin
    {
        public string id { get; set; }
        public DateTime valid_time { get; set; }
        public CreditCardLogin(CreditCard creditCard)
        {
            id = creditCard.id;
            valid_time = creditCard.valid_time;
        }
    }
}
