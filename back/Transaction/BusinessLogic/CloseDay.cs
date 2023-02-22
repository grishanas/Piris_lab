using lab.db;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.Transaction.BusinessLogic
{
    public class CloseDay
    {
        private readonly DBAccountContext _accounts;
        private readonly DepositLogic _depositLogic;
        private readonly DBBalanceContext _balanceContext;
        private readonly DBDebitContext _dbDebitContext;
        private readonly DBCreditContext _dbCreditContext;
        private readonly CreditLogic _creditLogic;

        private readonly long _id = 0;
        private const int Active = 1;
        private const int Passive = 2;

        private enum FindBalance
        {
            d1230 = 1230,
            d1231 = 1231,
            d1010 = 1010,
            d1273 = 1273,
            d7327 = 7327,
            d2400 = 2400,
            d2700 = 2700
        }

        private enum CreditEnum
        {
            d2400 = 2400,
            d2700 = 2700
        }

        private enum Deposit
        {
            d1230=1230,
            d1231=1231
        }

        public CloseDay(DBAccountContext accounts, DepositLogic depositLogic,DBBalanceContext dBBalanceContext, 
            DBDebitContext dBDebitContext, DBCreditContext dBCreditContext, CreditLogic creditLogic)
        {
            _accounts = accounts;
            _depositLogic = depositLogic;
            _balanceContext = dBBalanceContext;
            _dbDebitContext = dBDebitContext;
            _dbCreditContext = dBCreditContext;
            _creditLogic = creditLogic;
        }

        private async Task<Balance> Balance(Account account)
        {
            if ((DateOnly.FromDateTime(account.start_date) > DateOnly.FromDateTime(DateTime.Now)) || (DateOnly.FromDateTime(account.end_date) <= DateOnly.FromDateTime(DateTime.Now)))
                throw new Exception();
            var acc1 = new AccountID(account);
            var time = DateTime.Now;

            var oldBalance = await _balanceContext.GetBalance(acc1, account.last_update);
            if (oldBalance == null)
            {
                oldBalance = new Balance(account) { count = 0 };
            }

            var debit = _dbDebitContext.GetAllTransactionForThePeriodSource(acc1, oldBalance.time, time);
            if (debit == null)
            {
                debit = new List<Debit>();
                debit.Add(new Debit() { count = 0 });
            }
            var credit =_dbCreditContext.GetAllTransactionForThePeriodDestination(acc1, oldBalance.time, time);
            if (credit == null)
            {
                credit = new List<Credit>();
                credit.Add(new Credit() { count = 0 });
            }


            decimal creditAmount = 0;
            decimal debitAmount = 0;
            if (credit != null)
                credit.ForEach(x => creditAmount += x.count);
            if (debit != null)
                debit.ForEach(x => debitAmount += x.count);
            Balance balance=null;
            if (account.account_type==Passive)
                balance = new Balance(account) { count = oldBalance.count + creditAmount - debitAmount, time = time };
            if (account.account_type == Active)
                balance = new Balance(account) { count = oldBalance.count - creditAmount + debitAmount, time = time };
            account.last_update = time;


            try
            {
                await _balanceContext.AddBalance(balance);

            }
            catch (Exception e)
            {
                throw;
            }
            return balance;

        }
    

        private bool IsCredit(Account account)
        {
            foreach (int i in Enum.GetValues(typeof(CreditEnum)))
            {
                if (account.account_code == i.ToString())
                    return true;
            }
            return false;
        }
        private bool IsDeposit(Account account)
        {
            foreach (int i in Enum.GetValues(typeof(Deposit)))
            {
                if (account.account_code == i.ToString())
                    return true;
            }
            return false;
        }
        public async Task<bool> Closeday()
        {
            var acs = _accounts.Accounts.ToList();
            foreach(var i in acs)
            {
                try
                {
                    if (IsDeposit(i))
                        await _depositLogic.CloseDay(i);
                    else if (IsCredit(i))
                        await _creditLogic.CloseDay(i);
                }
                catch(Exception e)
                {

                }
            }

            
            for (int i= 0; i< acs.Count;i++)
            {
                try
                {
                    Balance bal = null;

                    if (IsCredit(acs[i]))
                        bal= await _creditLogic.CalcilateBalanceToInterestRate(acs[i]);
                    else
                        bal = await Balance(acs[i]);

                    acs[i].last_update = bal.time;
                    _accounts.Update(acs[i]);
                    
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            try
            {
                _accounts.SaveChanges();
            }catch(Exception e)
            {

            }


            return true;
        }

        

    }
}
