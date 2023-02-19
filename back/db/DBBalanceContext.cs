using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBBalanceContext: DbContext
    {
        public DbSet<Balance> context { get; set; }

        public DBBalanceContext() : base()
        {

        }
        public DBBalanceContext(DbContextOptions<DBBalanceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>().HasKey(k=>new { k.account_id,k.account_code,k.time});
        }

        public async Task<List<Balance>>? GetLastDayBalance()
        {
            var lastDay=context.Last();
            var allLastDay = context.Where(x => x.time == lastDay.time).ToList();
            return allLastDay;
        }

        public async Task<bool> AddBalance(Balance balance)
        {
            context.Add(balance);
            this.SaveChanges();
            return true;
        }

        public async Task<Balance>? GetBalance(AccountID accountID, DateTime lastUpdate)
        {
            try
            {
                return await context.FirstOrDefaultAsync(x => x.account_id == accountID.account_id && x.account_code == accountID.account_code && x.time == lastUpdate);
            }
            catch (Exception e)
            {
                throw;
            }
            throw new Exception();
        }

        
    }

    public class DBDebitContext:DbContext
    {
        public DbSet<Debit> context { get; set; }

        public DBDebitContext() : base()
        {

        }
        public DBDebitContext(DbContextOptions<DBDebitContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Debit>().HasKey(k => new { 
                k.account_source_id,
                k.account_destination_id,
                k.account_source_code,
                k.account_destination_code,
                k.time });
        }

        public async Task<List<Debit>>? GetAllTransactionForThePeriod(AccountID source,AccountID destination, DateTime startDate,DateTime endDate)
        {
            var tmp=context.Where(
                x=>x.time>=startDate&& x.time<endDate
                &&x.account_destination_id==destination.account_id
                &&x.account_destination_code==destination.account_code
                &&x.account_source_id==source.account_id
                &&x.account_source_code==source.account_code
                )
                .ToList();
            return tmp;
        }

        public List<Debit>? GetAllTransactionForThePeriodSource(AccountID source, DateTime startDate, DateTime endDate)
        {
            try
            {  
               return context.Where(
                    x => x.time >= startDate && x.time < endDate
                    && x.account_source_id == source.account_id
                    && x.account_source_code == source.account_code
                    )
                    .ToList();
            }
            catch(Exception e)
            {

            }
            return null;
        }
        public async Task<List<Debit>>? GetAllTransactionForThePeriodDestination(AccountID destination, DateTime startDate, DateTime endDate)
        {
            var tmp = context.Where(
                x => x.time >= startDate && x.time < endDate
                && x.account_destination_id == destination.account_id
                && x.account_destination_code == destination.account_code
                )
                .ToList();
            return tmp;
        }

        public async Task<bool> AddDebit(Debit debit)
        {
            context.Add(debit);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }


    }

    public class DBCreditContext:DbContext
    {
        public DbSet<Credit> context { get; set; }
        public DBCreditContext() : base()
        {

        }
        public DBCreditContext(DbContextOptions<DBCreditContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>().HasKey(k => new {
                k.account_source_id,
                k.account_destination_id,
                k.account_source_code,
                k.account_destination_code,
                k.time
            });
        }

        public async Task<List<Credit>>? GetAllTransactionForThePeriod(AccountID source, AccountID destination, DateTime startDate, DateTime endDate)
        {
            var tmp = context.Where(
                x => x.time >= startDate && x.time < endDate
                && x.account_destination_id == destination.account_id
                && x.account_destination_code == destination.account_code
                && x.account_source_id == source.account_id
                && x.account_source_code == source.account_code
                )
                .ToList();
            return tmp;
        }

        public async Task<List<Credit>>? GetAllTransactionForThePeriodSource(AccountID source, DateTime startDate, DateTime endDate)
        {
            var tmp = context.Where(
                x => x.time >= startDate && x.time < endDate
                && x.account_source_id == source.account_id
                && x.account_source_code == source.account_code
                )
                .ToList();
            return tmp;
        }
        public List<Credit>? GetAllTransactionForThePeriodDestination(AccountID destination, DateTime startDate, DateTime endDate)
        {
            try
            {
                return context.Where(
                    x => x.time >= startDate && x.time < endDate
                    && x.account_destination_id == destination.account_id
                    && x.account_destination_code == destination.account_code
                    )
                    .ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<bool> AddCredit(Credit credit)
        {
            context.Add(credit);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }


    }
}
