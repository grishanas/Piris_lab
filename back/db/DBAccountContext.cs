using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;


namespace lab.db
{
    public class DBAccountContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        private readonly DBClientContext _dbClientContext;
        private readonly DBAccountCodeContext _dbCodeContext;
        private readonly DBAccountTypeContext _dBAccountTypeContext;
        private readonly DBTypeOfCurrencyContext _dBTypeOfCurrencyContext;
        private readonly DBBalanceContext _dBBalanceContext;

        public DBAccountContext() : base()
        {

        }
        public DBAccountContext(DbContextOptions<DBAccountContext> options, DBClientContext dbClientContext, DBAccountCodeContext dbCodeContext, DBAccountTypeContext dBAccountTypeContext, DBTypeOfCurrencyContext dBTypeOfCurrencyContext, DBBalanceContext dBBalanceContext) : base(options)
        {
            _dbClientContext = dbClientContext;
            _dbCodeContext = dbCodeContext;
            _dBAccountTypeContext = dBAccountTypeContext;
            _dBTypeOfCurrencyContext = dBTypeOfCurrencyContext;
            _dBBalanceContext = dBBalanceContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => new { a.account_code, a.account_id});
        }


        #region CreateAccount 
        public async Task<Account> CreateAccount(UserAccount user)
        {
            //var Client = await _dbClientContext.GetClient(user.client_id);
            var Acc = new Account(user);
            Acc.client_id = 0;
            Acc.account_type = 2;
            await AddAccount(Acc);
            return Acc;
        }
        #endregion

        #region Add account

        public async Task<bool> AddAccount(Account account)
        {

            if (account == null)
                throw new ArgumentNullException(nameof(account));;

            Accounts.Add(account);
            try
            {
                this.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw; //new Exception(ex.Message);
            }
            catch (DbUpdateException ex)
            {

                throw new Exception(ex.InnerException.HResult.ToString()); //new Exception(ex.Message);*/
            }
            catch { throw; }


            return true;

        }

        #endregion

        #region Delete account

        public async Task<bool> DeleteAccount(Account account)
        {
            try
            {
                Accounts.Remove(account);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
        #endregion


        #region Get account

        public async Task<List<SendAccount>> GetAccounts()
        {
            var accounts = await Accounts.ToListAsync();
            var accs = new List<SendAccount>();
            foreach(var account in accounts)
            {
                var sendAcc = new SendAccount(account);
                sendAcc.account_type = await _dBAccountTypeContext.GetCode(account.account_type);
                sendAcc.account_code = await _dbCodeContext.GetCode(account.account_code);
                sendAcc.currency_type = await _dBTypeOfCurrencyContext.GetCurrency(account.currency_type);
                sendAcc.balance = await _dBBalanceContext.GetBalance(new AccountID(account), account.last_update);
                accs.Add(sendAcc);
            }
            return accs;

        }

        public async Task<Account> GetAccount(long client_id)
        {
            return await Accounts.FirstOrDefaultAsync(x => x.client_id == client_id);
        }

        public async Task<Account> GetAccountFromCode(string code)
        {
            return await Accounts.FirstAsync(x => x.account_code == code);
        }

        public async Task<Account>? GetAccount (AccountID id)
        {
            return await Accounts.FirstOrDefaultAsync(x => x.account_id == id.account_id && x.account_code==id.account_code);
        }

        public async Task<List<Account>> GetAccounts(string account_id)
        {
            return await Accounts.Where(x => x.account_id == account_id).ToListAsync();
        }
        #endregion

        #region Update account

        public  void UpdateAccount(Account account)
        {


            Accounts.Update(account);


            this.SaveChanges(true);


        }

        #endregion
    }
}
