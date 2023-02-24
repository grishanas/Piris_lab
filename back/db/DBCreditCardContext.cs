using Microsoft.EntityFrameworkCore;
using lab.classes.client;
using lab.classes;
using lab.MyException.DbException;
using System.Text.RegularExpressions;

namespace lab.db
{
    public class DBCreditCardContext:DbContext
    {
        public DbSet<CreditCard> CreditCard { get; set; }

        public DBCreditCardContext() : base()
        {

        }
        public DBCreditCardContext(DbContextOptions<DBCreditCardContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().HasKey(m => new { m.id, m.valid_time });
        }

        public async Task<bool> AddCreditCard(CreditCard creditCard)
        {
            CreditCard.Add(creditCard);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }

        protected async Task<CreditCard> GetCreditCard(UserCreditCard user)
        {

            var creditCard = await CreditCard.FirstOrDefaultAsync(x=>x.id==user.id&&x.valid_time==x.valid_time);
            return creditCard;
        }

        public async Task<Account> GetAccount(UserCreditCard user)
        {
            return CreditCard.FirstOrDefault(x => x.id == user.id && x.valid_time == user.valid_time).ParentAccount;
        }

        public async Task<bool> LogIn(UserCreditCard user, string password)
        {
            var CreditCard = await GetCreditCard(user);
            if (CreditCard.is_blocked == true)
                throw new Exception("Card is blocked");
            if (CreditCard.password != password)
            {
                CreditCard.count++;
                if (CreditCard.count == 3)
                    CreditCard.is_blocked = true;
                this.CreditCard.Update(CreditCard);
                this.SaveChanges();
                throw new Exception("not valid password");
            }
            CreditCard.count = 0;
            this.CreditCard.Update(CreditCard);
            this.SaveChanges();

            return true ;
        }






    }
}
