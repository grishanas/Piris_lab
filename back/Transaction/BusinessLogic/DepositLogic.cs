using lab.db;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.Transaction.BusinessLogic
{
    public class DepositLogic
    {
        private readonly DBAccountContext _accounts;
        private readonly DBCreditContext _creditContext;
        private readonly DBDebitContext _debitContext;
        private readonly DBBalanceContext _dBBalanceContext;
        private readonly DBClientContext _dBClientContext;
        private const int Active = 1;
        private const int Passive = 2;
        protected enum ValidOperation
        {
            CheckOut = 1010,
        }

        protected enum RecallDebit
        {
            d1230=1230,
            d1231=1231,
        }
        protected enum notRecallDebit
        {
            d1240=1240,
        }
        

        public DepositLogic() : base()
        {

        }
        public DepositLogic(DBAccountContext accounts, DBCreditContext creditContext, DBDebitContext debitContext, DBBalanceContext dBBalanceContext, DBClientContext dBClientContext)
        {
            _accounts = accounts;
            _creditContext = creditContext;
            _debitContext = debitContext;
            _dBBalanceContext = dBBalanceContext;
            _dBClientContext = dBClientContext;
        }


        protected async Task<Account> CreateActiveDeposite(UserAccount userAccount)
        {
            var Acc = new Account(userAccount);
            var Client = await _dBClientContext.GetClient(userAccount.client_id);
            Acc.client_id = Client.client_id;
            Acc.account_type = Passive;
            return Acc;
        }

        protected async Task<Account> CreatePassiveDeposit(UserAccount userAccount)
        {
            var Acc = new Account(userAccount);
            try
            {
                //тут должна быть какая-то проверка
                var Client = await _dBClientContext.GetClient(userAccount.client_id);
                Acc.client_id = Client.client_id;
                Acc.account_type = Active;
                Acc.interest_rate = 0;
            }
            catch(Exception e)
            {

            }
            switch(Acc.account_code)
            {
                case ("1230"):
                case ("1231"):
                    {
                        Acc.account_code = "1273";
                        Acc.account_type = Passive;
                        break;
                    };
               default: throw new Exception();
            }

            return Acc;
        }

        public async Task<bool> AddDeposit(UserAccount userAccount)
        {
            var acc = await CreateActiveDeposite(userAccount);
            var acc2 = await CreatePassiveDeposit(userAccount);

            try
            {
                await _accounts.AddAccount(acc);
                await _accounts.AddAccount( acc2);
            }
            catch
            {
                throw;
            }
            return true;
        }


        protected bool IsValidCashInOutOperation(UserAccountID account)
        {

            foreach (int i in Enum.GetValues(typeof(ValidOperation)))
            {
                if (account.account_code == i.ToString())
                    return true;
            }
            throw new Exception();
        }
        private enum ValidDeposit
        {
            DemandDepositInNathionalBank = 1230,
            DemandDepositInBank = 1231,

        }

        protected bool IsValidDeposit(UserAccountID account)
        {
            foreach (int i in Enum.GetValues(typeof(ValidDeposit)))
            {
                if (account.account_code == i.ToString())
                    return true;
            }
            throw new Exception();
        }

        public async Task<bool> SendToFund(Account source)
        {
            var balance = await  BalanceCalculation(source);
            var destination = await _accounts.GetAccountFromCode("7327");
            CreateOperation(source, destination, balance);
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

        protected void CreateOperation(Account source, Account destination, decimal amount)
        {
            if (source.account_type == Active)
            {
                if (destination.account_type == Active)
                {
                    throw new Exception("no implementation");
                }
                else
                {
                    Credit sourceOperation = new Credit(source, destination);
                    sourceOperation.time = DateTime.Now;
                    sourceOperation.count = amount;
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
                    sourceOperation.time = DateTime.Now;
                    sourceOperation.count = amount;
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
                    sourceOperation.time = destinationOperation.time = DateTime.Now;
                    sourceOperation.count = destinationOperation.count = amount;
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


        protected bool IsRecallDebit(string accountCode)
        {
            foreach (int i in Enum.GetValues(typeof(RecallDebit)))
            {
                if (accountCode == i.ToString())
                    return true;
            }
            throw new Exception();

        }
        public async Task<bool> CashOut(UserAccountID source, UserAccountID destination, decimal amount)
        {

            if (!IsValidCashInOutOperation(destination))
                throw new Exception();
            if (!IsValidDeposit(source))
                throw new Exception();

            var DestinationAcc = _accounts.GetAccount(new AccountID(destination) { account_type = Passive });
            var SourceAccs = await _accounts.GetAccounts( source.account_id);

            int Recall = -1;
            Account SourceAcc = null;
            for(int i=0;i<SourceAccs.Count;i++)
            {
                if (IsRecallDebit(SourceAccs[i].account_code))
                    Recall = i;
                else
                    SourceAcc = SourceAccs[i];
            }

            DestinationAcc.Wait();

            if (SourceAcc == null || DestinationAcc.Result == null)
                throw new Exception();

            if (DateOnly.FromDateTime(SourceAcc.deadline) <= DateOnly.FromDateTime(DateTime.Now))
                throw new Exception();

            if (Recall == -1)
            {
                //без отзывной
                SourceAcc = SourceAccs.Last();
                var balance = await _dBBalanceContext.GetBalance(new AccountID(SourceAcc), SourceAcc.last_update);
                if (balance.count < amount)
                    throw new Exception();
                var time = DateTime.Now;
                CreateOperation(SourceAcc, DestinationAcc.Result, new Balance(SourceAcc) { count=amount,time=time});
            }
            else
            {
                var time = DateTime.Now;
                var InterestBalance = await _dBBalanceContext.GetBalance(new AccountID(SourceAcc), SourceAcc.last_update);
                if (InterestBalance.count > amount)
                {
                    CreateOperation(SourceAcc, DestinationAcc.Result, new Balance(SourceAcc) { count = amount, time = time });
                }
                else
                {
                    var bodyDebit = await _dBBalanceContext.GetBalance(new AccountID(SourceAccs[Recall]), SourceAccs[Recall].last_update);
                    if(bodyDebit.count + InterestBalance.count > amount)
                    {
                        InterestBalance.time = time;
                        CreateOperation(SourceAcc, DestinationAcc.Result,InterestBalance);
                        CreateOperation(SourceAccs[Recall], DestinationAcc.Result, new Balance(SourceAccs[Recall]) { count=amount-InterestBalance.count,time=time});
                    }
                    else
                    {
                        throw new Exception("Not enought money");
                    }
                }
            }

            return true;
        }

        public async Task<Balance>  BalanceCalculation(Account account)
        {
            var acc1 = new AccountID(account);
            var time = DateTime.Now;

            var oldBalance = await _dBBalanceContext.GetBalance(acc1, account.last_update);
            if (oldBalance == null)
            {
                oldBalance = new Balance(account) { count = 0 };
            }

            var debit = _debitContext.GetAllTransactionForThePeriodSource(acc1, oldBalance.time, time);
            if (debit == null)
            {
                debit = new List<Debit>();
                debit.Add(new Debit() { count = 0 });
            }
            var credit = _creditContext.GetAllTransactionForThePeriodDestination(acc1, oldBalance.time, time);
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

            return balance;
        }


        protected async Task<bool> SaveBalance(Account account, Balance balance)
        {
            account.last_update = balance.time;
            _accounts.UpdateAccount(account);
            try
            {
                _dBBalanceContext.Add(balance);
                _dBBalanceContext.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<Balance> CalculateBalanceForInterest(Account account)
        {
            if ((DateOnly.FromDateTime(account.start_date) > DateOnly.FromDateTime(DateTime.Now))|| (DateOnly.FromDateTime(account.end_date) <= DateOnly.FromDateTime(DateTime.Now)))
                return new Balance() { count = 0 };
            var deposit = new AccountID(account);
            if (!IsValidDeposit(deposit))
                throw new Exception();
            var time = DateTime.Now;
            var oldBalance = await _dBBalanceContext.GetBalance(deposit, account.last_update);
            if (oldBalance == null)
            {
                oldBalance = new Balance(account) { count = 0 };
            }

            var debit = _debitContext.GetAllTransactionForThePeriodSource(deposit, account.start_date, time);
            if (debit == null)
            {
                debit = new List<Debit>();
                debit.Add(new Debit() { count = 0 });
            }
            var credit = _creditContext.GetAllTransactionForThePeriodDestination(deposit, account.start_date, time);
            if (credit == null)
            {
                credit = new List<Credit>();
                credit.Add(new Credit() { count = 0 });
            }

            if (DateOnly.FromDateTime(account.end_date) == DateOnly.FromDateTime(DateTime.Now))
            {
                var amount = new Balance(account);
                debit.ForEach(x =>
                {
                    if (x.account_destination_code == "7327")
                        amount.count+= x.count;
                });
                amount.time = time;
                CreateOperation(await _accounts.GetAccountFromCode("7327"), account, amount);
                await SaveBalance(account, amount);
            }
            for (int i = 0; i < debit.Count;)
            {

                if (debit[i].account_destination_code == "7327")
                {
                    debit.Remove(debit[i]);
                    i--;
                }
                i++;

            }

            decimal creditAmount = 0;
            decimal debitAmount = 0;
            if (credit != null)
                credit.ForEach(x => creditAmount += x.count);
            if (debit != null)
                debit.ForEach(x => debitAmount += x.count);
            var balance = new Balance(account) { count = oldBalance.count + creditAmount + debitAmount, time = time };

            return balance;
        }


        public async Task<Balance> DepositInterestCalculate(Account account)
        {
            var balance = await CalculateBalanceForInterest(account);

            var interest = new Balance();
            if (balance.count > 0)
                interest.count = decimal.Multiply(balance.count, Convert.ToDecimal(account.interest_rate));
            interest.time = balance.time;

            return interest;
        }

        public async Task<bool> CloseDay(Account account)
        {
            var balance = await BalanceCalculation(account);
            if (balance.count > 0)
                await SendToFund(account);
            await SimpleInterestRate(account);

            return true;

        }

        public async Task<bool> SimpleInterestRate(Account account)
        {

            var balance= await DepositInterestCalculate(account);
            if(balance.count <= 0)
                return false;
            switch (account.account_code)
            {
                case ("1230"):
                case ("1231"):
                    {
                        var acc = account.Copy();
                        acc.account_type = Passive;
                        acc.account_code = "1273";
                        var acc1 = await _accounts.GetAccountFromCode("7327");
                        CreateOperation(acc1, acc, balance);
                        break;
                    }                     
            }
            return true;
        }
    }
}
