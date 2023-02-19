﻿using lab.db;
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
        private async Task<Balance> CalcilateBalanceToInterestRate(Account account)
        {
            if ((DateOnly.FromDateTime(account.start_date) > DateOnly.FromDateTime(DateTime.Now)) || (DateOnly.FromDateTime(account.end_date) <= DateOnly.FromDateTime(DateTime.Now)))
                throw new Exception();
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
            var balance = new Balance(account) { count = oldBalance.count - creditAmount + debitAmount, time = time };

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
                    account.account_code = "2470";
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
            if (IsValidCredit(userAccount.account_code))
                throw new Exception();
            var FundAcc =await _accounts.GetAccountFromCode("7327");
            var balance = BalanceCalculation(FundAcc);
            var acc = new Account(userAccount);
            acc.account_type = Active;
            Account acc1 = null;
            switch(acc.account_code)
            {
                case ("2400"):
                    acc1 = new Account(userAccount);
                    acc1.interest_rate = 0;
                    acc1.account_code = "2470";
                    acc1.account_type = Active;
                    break;
            }

            balance.Wait();
            if (balance.Result.count < amount)
                throw new Exception();
            var newBalance=new Balance(acc) { count = amount,time= DateTime.Now};
            CreateOperation(FundAcc, acc, newBalance);

            var Balnc = BalanceCalculation(acc);
            return acc;


        }

    }
}