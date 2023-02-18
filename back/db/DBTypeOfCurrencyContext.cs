using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBTypeOfCurrencyContext:DbContext
    {
        public DbSet<type_of_currency> currencies { get; set; }


        public DBTypeOfCurrencyContext() : base()
        {

        }
        public DBTypeOfCurrencyContext(DbContextOptions<DBTypeOfCurrencyContext> options) : base(options)
        {

        }

        #region Add Currency

        public async Task<bool> AddCurrency(type_of_currency currency)
        {

            if (currency == null)
                throw new ArgumentNullException(nameof(currency));
            if (currency.id == null)
                throw new ArgumentNullException(nameof(currency));

            currencies.Add(currency);
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
            catch { }

            return true;

        }

        #endregion

        #region Delete Currency

        public async Task<bool> DeleteCurrency(type_of_currency currency)
        {
            try
            {
                currencies.Remove(currency);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
        #endregion


        #region Get Currency

        public async Task<List<type_of_currency>> GetCurrencies()
        {
            return await currencies.ToListAsync();
        }

        public async Task<type_of_currency> GetCurrency(int id)
        {
            return await currencies.FirstAsync(x => x.id == id);
        }

        #endregion

        #region Update Currency

        public async Task<bool> UpdateCurrency(type_of_currency currency)
        {
            type_of_currency currenc = null;
            try
            {
                currenc = currencies.FirstOrDefault(x => x.id == currency.id);

            }
            catch (Exception e)
            {
                throw;

            }

            if (currenc != null)
            {
                currenc.name = currency.name;
                currencies.Update(currenc);
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
