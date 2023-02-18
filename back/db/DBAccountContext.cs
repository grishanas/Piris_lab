using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;


namespace lab.db
{
    public class DBAccountContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        private readonly DBClientContext _dbClientContext;

        public DBAccountContext() : base()
        {

        }
        public DBAccountContext(DbContextOptions<DBAccountContext> options, DBClientContext dbClientContext) : base(options)
        {
            _dbClientContext = dbClientContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(m => new { m.account_code, m.account_id});
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

        public async Task<List<Account>> GetAccounts()
        {
            return await Accounts.ToListAsync();
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
            return await Accounts.FirstOrDefaultAsync(x => x.account_id == id.account_id && x.account_code==id.account_code&&x.account_type==id.account_type);
        }

        #endregion

        #region Update account

        public async Task<bool> UpdateAccount(Account account)
        {
            Account acc = null;
            try
            {
                acc = Accounts.FirstOrDefault(x => x.account_id == account.account_id);

            }
            catch (Exception e)
            {
                throw;

            }

            if (acc != null)
            {
                acc.account_code = account.account_code;
                Accounts.Update(acc);
                // SaveChanges should be put in the try catch
                this.SaveChanges();

            }
            else
            {
                throw new Exception();
            }

            return true;
        }

        #endregion
    }
}
