using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using lab.classes;
using lab.MyException.DbException;

namespace lab.db
{
    public class DBCitezenshipContext:DbContext
    {
        public DbSet<Citizenship> citizenships { get; }


        public DBCitezenshipContext() : base()
        {

        }
        public DBCitezenshipContext(DbContextOptions<DBCitezenshipContext> options) : base(options)
        {

        }

        #region Add citezenship
        public async Task<bool> AddCitezenship(Citizenship citizenship)
        {
            if (citizenship == null)
                throw new ArgumentNullException();
            var city = await citizenships.FirstOrDefaultAsync(x=>x.id==citizenship.id || x.nationality==citizenship.nationality);
            if (city != null)
            {
                throw new DublicateException("there is already a member with this identifier",nameof(citizenship));
            }

            citizenships.Add(citizenship);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }

            return true;
        }
        #endregion

        #region Get citezenships
        public async Task<List<Citizenship>> GetCitizenships()
        {
            return await this.citizenships.ToListAsync();
        }
        #endregion

        #region Delete citezenship
        public async Task<bool> DeleteCitezenship(Citizenship citizenship)
        {
            citizenships.Remove(citizenship);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }
        #endregion

        public async Task<bool> UpdateCitezenship(Citizenship citizenship)
        {
            Citizenship citizen = null;
            try
            {
                citizen = citizenships.FirstOrDefault(x => x.id == citizen.id);

            }
            catch (Exception e)
            {
                throw;
            }

            if (citizen != null)
            {
                citizen.nationality =citizenship.nationality;

                citizenships.Update(citizen);
                try
                {
                    this.SaveChanges();
                }
                catch(Exception e)
                {
                    throw;
                }

            }
            else
            {
                throw new Exception();
            }

            return true;
        }

    }
}
