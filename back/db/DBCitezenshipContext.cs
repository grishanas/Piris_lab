using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using lab.classes;

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
