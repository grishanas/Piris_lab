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

        private readonly long _id = 0;
        private const int Active = 1;
        private const int Passive = 2;

        private enum FindBalance
        {
            d1230 = 1230,
            d1231 = 1231,
            d1010 = 1010,
            d1273 = 1273,
            d7327 = 7327
        }

        private enum Deposit
        {
            d1230=1230,
            d1231=1231
        }

        public CloseDay(DBAccountContext accounts, DepositLogic depositLogic,DBBalanceContext dBBalanceContext,DBDebitContext dBDebitContext, DBCreditContext dBCreditContext)
        {
            _accounts = accounts;
            _depositLogic = depositLogic;
            _balanceContext = dBBalanceContext;
            _dbDebitContext = dBDebitContext;
            _dbCreditContext = dBCreditContext;
        }

        private async Task<bool> PassiveBalance(Account account)
        {
            if ((DateOnly.FromDateTime(account.start_date) > DateOnly.FromDateTime(DateTime.Now)) || (DateOnly.FromDateTime(account.end_date) <= DateOnly.FromDateTime(DateTime.Now)))
                return false;
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
            var credit = _dbCreditContext.GetAllTransactionForThePeriodDestination(acc1, oldBalance.time, time);
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
            var balance = new Balance(account) { count = oldBalance.count + creditAmount - debitAmount, time = time };

            account.last_update = time;

            _accounts.Update(account);
            _balanceContext.Add(balance);

            try
            {
                _accounts.SaveChanges();
                _balanceContext.SaveChanges();

            }catch(Exception e)
            {
                throw;
            }
            return true;

        }
        private async Task<bool> ActiveBalance(Account account)
        {
            if ((DateOnly.FromDateTime(account.start_date) > DateOnly.FromDateTime(DateTime.Now)) || (DateOnly.FromDateTime(account.end_date) <= DateOnly.FromDateTime(DateTime.Now)))
                return false;
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
            var credit = _dbCreditContext.GetAllTransactionForThePeriodDestination(acc1, oldBalance.time, time);
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
            var balance = new Balance(account) { count = oldBalance.count - creditAmount + debitAmount, time = time };

            account.last_update = time;

            _accounts.Update(account);
            _balanceContext.Add(balance);

            try
            {
                _accounts.SaveChanges();
                _balanceContext.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        private bool IsNeedBalance(Account account)
        {
            foreach (int i in Enum.GetValues(typeof(FindBalance)))
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
                if (IsDeposit(i))
                    await _depositLogic.CloseDay(i);
                if(IsNeedBalance(i))
                {
                    if(i.account_type==1)
                    {
                        await ActiveBalance(i);
                    }
                    if(i.account_type==2)
                    {
                        await PassiveBalance(i);
                    }
                }
            }


            return true;
        }

        

    }
}
