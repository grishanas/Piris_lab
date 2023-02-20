using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    public class Account
    {
        public string account_id { get; set; }
        public string bank_name { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public DateTime deadline { get; set; }
        public decimal interest_rate { get; set; }
        public CurrencyType currency_type { get; set; }
        public AccountCode account_code { get; set; }
        public AccountType account_type { get; set; }
        public int client_id { get; set; }
        public Balance? balance { get; set; }
    }
}
