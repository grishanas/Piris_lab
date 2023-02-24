using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.db;
using lab.classes;

namespace lab.Logic
{
    public class CreditCardLogic
    {
        private readonly DBCreditCardContext _dbCreditCardContext;
        private readonly DBAccountContext _dBAccountContext;

        public CreditCardLogic(DBCreditCardContext dbCreditCardContext, DBAccountContext dBAccountContext)
        {
            _dbCreditCardContext = dbCreditCardContext;
            _dBAccountContext = dBAccountContext;
        }

        public async Task<bool> CreateCreditCard(CreateCreditCard CreateCreditCard)
        {
            if (CreateCreditCard.userAccountID.account_code != "2400")
                throw new Exception();
            var acc = await _dBAccountContext.GetAccount(new AccountID(CreateCreditCard.userAccountID));
            if (acc == null)
                throw new ArgumentNullException(nameof(acc));

            var CreditCard = new CreditCard(CreateCreditCard) { account_id=acc.account_id,account_code=acc.account_code};

            await _dbCreditCardContext.AddCreditCard(CreditCard);
            return true;

        }

        public async Task<Account> LogIn(UserCreditCard user, string password)
        {
            if(await _dbCreditCardContext.LogIn(user, password))
                return await _dBAccountContext.GetAccount( await _dbCreditCardContext.GetAccount(user));
            throw new Exception();

        }
    }
}
