using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBAccountTypeContext:DbContext
    {
        public DbSet<Account_type> types { get; set; }


        public DBAccountTypeContext() : base()
        {

        }
        public DBAccountTypeContext(DbContextOptions<DBAccountTypeContext> options) : base(options)
        {

        }

        #region Add code

        public async Task<bool> AddCode(Account_type type)
        {

            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (type.id == null)
                throw new ArgumentNullException(nameof(type));

            types.Add(type);
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

        public async Task<bool> DeleteCode(int code)
        {
            var cod = await types.FirstAsync(x => x.id == code);

            if (cod == null)
                throw new Exception();

            try
            {
                types.Remove(cod);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }


        public async Task<bool> DeleteCode(Account_type code)
        {
            try
            {
                types.Remove(code);
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

        public async Task<List<Account_type>> GetCode()
        {
            return await types.ToListAsync();
        }

        public async Task<Account_type> GetCode(int id)
        {
            return await types.FirstAsync(x => x.id == id);
        }

        #endregion

        #region Update Code

        public async Task<bool> UpdateCode(Account_type code)
        {
            Account_type cod = null;
            try
            {
                cod = types.FirstOrDefault(x => x.id == code.id);

            }
            catch (Exception e)
            {
                throw;

            }

            if (cod != null)
            {
                cod.name = code.name;
                types.Update(code);
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

