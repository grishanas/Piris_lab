using lab.db;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.Transaction.BusinessLogic
{
    public class CashInOut
    {
        private readonly DBAccountContext _accounts;
        private readonly DBCreditContext _creditContext;
        private readonly DBDebitContext _debitContext;
        private readonly DBBalanceContext _dBBalanceContext;
        private readonly long _id = 0;
        private const int Active = 1;
        private const int Passive = 2;
        protected enum ValidOperation
        {
            CheckOut = 1010,
        }

        public CashInOut() : base()
        {

        }
        public CashInOut(DBAccountContext accounts, DBCreditContext creditContext, DBDebitContext debitContext, DBBalanceContext dBBalanceContext)
        {
            _accounts = accounts;
            _creditContext = creditContext;
            _debitContext = debitContext;
            _dBBalanceContext = dBBalanceContext;
        }

        public async Task<bool> CashIn(decimal amount)
        {
            var acc =await _accounts.GetAccount(_id);

            var balance = await BalanceCalculation(acc);
            var Debit = new Debit(acc);
            Debit.time = DateTime.Now;
            Debit.count = amount;
            await _debitContext.AddDebit(Debit);

            return true;
        }

        public async Task<bool> CashOut(decimal amount)
        {
            var acc = await _accounts.GetAccount(_id);

            var balance = await BalanceCalculation(acc);
            var oldBalance = await _dBBalanceContext.GetBalance(new AccountID(acc), acc.last_update);
            if (balance.count- oldBalance.count < amount)
                throw new Exception();
            var Cred = new Credit(acc);
            Cred.time = DateTime.Now;
            Cred.count = amount;
            await _creditContext.AddCredit(Cred);
            return true;
        }

        public async Task<bool> CloseOperation()
        {
            var acc = await _accounts.GetAccount(_id);
            var balance = await BalanceCalculation(acc);
            acc.last_update = balance.time;

            _accounts.Update(acc);
            _dBBalanceContext.Add(balance);
            try
            {
                _accounts.SaveChanges();
                _dBBalanceContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> TransferCash(AccountID ID,decimal amount)
        {
            var source = await _accounts.GetAccount(_id);
            var destination = await _accounts.GetAccount(ID);
            var balance = await BalanceCalculation(source);
            var oldBalance = await _dBBalanceContext.GetBalance(new AccountID(source), source.last_update) ?? new Balance(source) { time=DateTime.Now};
            if (balance.count - oldBalance.count < amount)
                throw new Exception();
            CreateOperation(source, destination, new Balance(source) { count = amount, time=DateTime.Now });
            return true;
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
                    sourceOperation.time =amount.time;
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
                oldBalance = new Balance(account) { count = 0};
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
            if(account.account_type==Active)
                balance = new Balance(account) { count = oldBalance.count - creditAmount + debitAmount, time = time };
            if (account.account_type == Passive)
                balance = new Balance(account) { count = oldBalance.count + creditAmount - debitAmount, time = time };
            return balance;
        }


    }
}
