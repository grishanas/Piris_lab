namespace BankClient
{
    public class UserAccountID
    {
        public string account_id { get; set; }
        public string account_code { get; set; }

        public UserAccountID(Account account)
        {
            this.account_id = account.account_id;
            this.account_code = account.account_code.account_code;
        }
    }
}
