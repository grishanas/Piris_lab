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

        private readonly long _id = 0;
        private const int Active = 1;
        private const int Passive = 2;

        private enum Deposit
        {
            d1230=1230,
            d1231=1231
        }

        public CloseDay(DBAccountContext accounts, DepositLogic depositLogic)
        {
            _accounts = accounts;
            _depositLogic = depositLogic;
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
            }


            return true;
        }

        

    }
}
