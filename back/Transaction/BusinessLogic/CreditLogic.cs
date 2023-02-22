using lab.db;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;
using lab.Transaction.BusinessLogic;

namespace lab.Transaction.BusinessLogic
{
    public class CreditLogic:AccountOperation
    {
        private readonly DBClientContext _dbClientContext;
        protected enum ValidCredit
        {
            Credit = 2400,
        }


        public CreditLogic() : base()
        {

        }
        public CreditLogic(DBAccountContext accounts, DBCreditContext creditContext, DBDebitContext debitContext, DBBalanceContext dBBalanceContext, DBClientContext dBClientContext)
            :base(accounts, creditContext, debitContext, dBBalanceContext)
        {
            _dbClientContext = dBClientContext;
        }

        private bool IsValidCredit(string account_code)
        {

            foreach (int i in Enum.GetValues(typeof(ValidCredit)))
            {
                if (account_code == i.ToString())
                    return true;
            }
            return false;


        }
        public async Task<Balance> CalcilateBalanceToInterestRate(Account account)
        {

            var acc1 = new AccountID(account);
            var time = DateTime.Now;

            var oldBalance = await _dBBalanceContext.GetBalance(acc1, account.last_update);
            if (oldBalance == null)
            {
                oldBalance = new Balance(account) { count = 0 };
            }

            var debit = await _debitContext.GetAllTransactionForThePeriodDestination(acc1, DateTime.MinValue, time);
            if (debit == null)
            {
                debit = new List<Debit>();
                debit.Add(new Debit() { count = 0 });
            }
            var credit = await _creditContext.GetAllTransactionForThePeriodSource(acc1, DateTime.MinValue, time);
            if (credit == null)
            {
                credit = new List<Credit>();
                credit.Add(new Credit() { count = 0 });
            }
            for(int i =0; i < debit.Count; i++)
            {
                if(debit[i].account_source_code=="7327")
                {
                    debit.Remove(debit[i]);
                    i--;
                }
            }


            decimal creditAmount = 0;
            decimal debitAmount = 0;
            if (credit != null)
                credit.ForEach(x => creditAmount += x.count);
            if (debit != null)
                debit.ForEach(x => debitAmount += x.count);
            var balance = new Balance(account) { count = creditAmount - debitAmount, time = time };

            return balance;
        }

        public async Task<bool> UpdateAccount(Account acc)
        {
            var balance = await BalanceCalculation(acc);
            await _dBBalanceContext.AddBalance(balance);
            return true;
        }

        public async Task<bool> CloseDay(Account account)
        {
            if (IsValidCredit(account.account_code))
            {
                var balance = await CalcilateBalanceToInterestRate(account);

                if ((DateOnly.FromDateTime(account.start_date) > DateOnly.FromDateTime(DateTime.Now) 
                    && DateOnly.FromDateTime(account.end_date) <= DateOnly.FromDateTime(DateTime.Now))
                    ||balance.count!=0)
                {
                    balance.count = decimal.Multiply(balance.count, Convert.ToDecimal(account.interest_rate));
                    var FundAcc = await _accounts.GetAccountFromCode("7327");
                    account= account.Copy();
                    account.account_code="2470";
                    CreateOperation(account, FundAcc, balance);

                }
                else
                {
                    balance = await BalanceCalculation(account);
                    var FundAcc = await _accounts.GetAccountFromCode("7327");
                    CreateOperation(account, FundAcc, balance);
                }
            }
            return true;
        }

        public async Task<Account> CreareCredit(UserAccount userAccount,decimal amount)
        {
            userAccount = userAccount ?? throw new ArgumentNullException(nameof(userAccount));
            if (!IsValidCredit(userAccount.account_code))
                throw new Exception();
            var client = await _dbClientContext.GetClientFromDB(userAccount.client_id);
            var FundAcc =await _accounts.GetAccountFromCode("7327");
            var balance = BalanceCalculation(FundAcc);
            var acc = new Account(userAccount) {client_id = client.client_id };
            acc.account_type = Active;
            Account acc1 = null;
            switch(acc.account_code)
            {
                case ("2400"):
                    acc1 = new Account(userAccount) { client_id = client.client_id }; ;
                    acc1.interest_rate = 0;
                    acc1.account_code = "2470";
                    acc1.account_type = Active;
                    break;
                default:
                    throw new Exception("not a credit");
            }
            balance.Wait();
                if (balance.Result.count < amount)
                    throw new Exception("Bank don't have enought money");
            await this._accounts.AddAccount(acc1);
            await this._accounts.AddAccount(acc);
            var newBalance=new Balance(acc) { count = amount,time= DateTime.Now};
            CreateOperation(FundAcc, acc, newBalance);

            var Balnc = await BalanceCalculation(acc);
            _dBBalanceContext.AddBalance(Balnc);
            return acc;


        }

        public async Task<bool> CashOut(UserAccountID user,decimal amount)
        {
            var UserAccount = await _accounts.GetAccount(new AccountID(user) { account_type=Active});
            UserAccount = UserAccount ?? throw new ArgumentNullException(nameof(UserAccount));
            var balance = await BalanceCalculation(UserAccount)?? new Balance(UserAccount) { count=0,time=DateTime.Now};
            if (balance.count < amount)
                throw new Exception();
            var destination = await _accounts.GetAccountFromCode("1010");
            CreateOperation(UserAccount, destination, balance);
            return true;

        }

    }
}
