using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBAccountCodeContext:DbContext
    {
        public DbSet<Account_code> codes { get; set; }


        public DBAccountCodeContext() : base()
        {

        }
        public DBAccountCodeContext(DbContextOptions<DBAccountCodeContext> options) : base(options)
        {

        }

        #region Add code

        public async Task<bool> AddCode(Account_code code)
        {

            if (code == null)
                throw new ArgumentNullException(nameof(code));
            if (code.account_code == null)
                throw new ArgumentNullException(nameof(code));

            codes.Add(code);
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

        #region Delete code

        public async Task<bool> DeleteCode(string code)
        {
            var cod = await codes.FirstAsync(x => x.account_code == code);

            if (cod == null)
                throw new Exception();

            try
            {
                codes.Remove(cod);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteCode(Account_code code)
        {
            try
            {
                codes.Remove(code);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
        #endregion


        #region Get Code

        public async Task<List<Account_code>> GetCode()
        {
            return await codes.ToListAsync();
        }

        public async Task<Account_code> GetCode(string id)
        {
            return await codes.FirstAsync(x => x.account_code == id);
        }

        #endregion

        #region Update Code

        public async Task<bool> UpdateCode(Account_code code)
        {
            Account_code cod = null;
            try
            {
                cod = codes.FirstOrDefault(x => x.account_code == code.account_code);

            }
            catch (Exception e)
            {
                throw;

            }

            if (cod != null)
            {
                cod.description = code.description;
                codes.Update(code);
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
