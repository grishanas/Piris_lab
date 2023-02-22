using lab.db;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;


namespace lab.Transaction.BusinessLogic
{
    public class AccountOperation
    {
        protected readonly DBAccountContext _accounts;
        protected readonly DBCreditContext _creditContext;
        protected readonly DBDebitContext _debitContext;
        protected readonly DBBalanceContext _dBBalanceContext;
        protected readonly long _id = 0;
        protected const int Active = 1;
        protected const int Passive = 2;

        public AccountOperation() : base()
        {

        }
        public AccountOperation(DBAccountContext accounts, DBCreditContext creditContext, DBDebitContext debitContext, DBBalanceContext dBBalanceContext)
        {
            _accounts = accounts;
            _creditContext = creditContext;
            _debitContext = debitContext;
            _dBBalanceContext = dBBalanceContext;
        }

        protected void CreateOperation(Account source, Account destination, Balance amount)
        {
            if (source.account_type == Active)
            {
                if (destination.account_type == Active)
                {
                    Credit sourceOperation = new Credit(source, destination);
                    var destinationOperation = new Debit(source, destination);
                    sourceOperation.time = destinationOperation.time = amount.time;
                    sourceOperation.count = destinationOperation.count = amount.count;
                    try
                    {
                        _creditContext.Add(sourceOperation);
                        _debitContext.Add(destinationOperation);
                        _creditContext.SaveChanges();
                        _debitContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                else
                {
                    Credit sourceOperation = new Credit(source, destination);
                    sourceOperation.time = amount.time;
                    sourceOperation.count = amount.count;
                    try
                    {
                        _creditContext.AddRange(sourceOperation);
                        _creditContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                }
            }
            else
            {
                if (destination.account_type == Active)
                {
                    Debit sourceOperation = new Debit(source, destination);
                    sourceOperation.time = amount.time;
                    sourceOperation.count = amount.count;
                    try
                    {
                        _debitContext.AddRange(sourceOperation);
                        _debitContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                else
                {
                    Debit sourceOperation = new Debit(source, destination);
                    var destinationOperation = new Credit(source, destination);
                    sourceOperation.time = destinationOperation.time = amount.time;
                    sourceOperation.count = destinationOperation.count = amount.count;
                    try
                    {
                        _creditContext.Add(destinationOperation);
                        _debitContext.Add(sourceOperation);
                        _creditContext.SaveChanges();
                        _debitContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<Balance> BalanceCalculation(Account account)
        {
            var acc1 = new AccountID(account);
            var time = DateTime.Now;

            var oldBalance = await _dBBalanceContext.GetBalance(acc1, account.last_update);
            if (oldBalance == null)
            {
                oldBalance = new Balance(account) { count = 0,time=DateTime.MinValue };
            }

            
            var debit = await _debitContext.GetAllTransactionForThePeriodDestination(acc1, oldBalance.time, time);
            if (debit == null)
            {
                debit = new List<Debit>();
                debit.Add(new Debit() { count = 0 });
            }
            var credit = await _creditContext.GetAllTransactionForThePeriodSource(acc1, oldBalance.time, time);
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

            Balance balance = null;
            if (account.account_type==Active)
                balance = new Balance(account) { count = oldBalance.count - creditAmount + debitAmount, time = time };
            if(account.account_type==Passive)
                balance = new Balance(account) { count = oldBalance.count + creditAmount - debitAmount, time = time };
            return balance;
        }
    }
}
